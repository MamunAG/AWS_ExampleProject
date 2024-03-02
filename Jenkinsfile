pipeline {
    agent any
 
    environment {
        // Define environment variables if needed

       // DOCKER_HUB_CREDENTIALS = credentials('DockerhubCred')
       // DOCKER_IMAGE_NAME = '1almamun/aws_docker_example'
       // DOCKER_IMAGE_TAG = 'latest'

        registry = '1almamun/aws_docker_example'
        registryCredentialUp = 'docker_up'
        dockerImage = ''
    }

    stages {
        stage('Start') {
            steps {
                echo 'Pipeline start.'
            }
        }
    
        stage('Building image') {
            steps{
                script {
                    dockerImage = docker.build registry + ":$BUILD_NUMBER"
                }
            }
        }

        stage('Push to dockerhub') {
            steps{
                script {
                    docker.withRegistry( '', registryCredentialUp ) {
                        dockerImage.push()
                    }   
                }
            }
        }

        stage('Cleaning up') {
            steps{
                sh "docker rmi $registry:$BUILD_NUMBER"
            }
        }

        stage('Tigger CD Pipeline') {
            steps{
                script {
                    sh "curl -v -k -user jenkins:1102759c67a7f67103f88f4943c7434ffe POST -H 'cache-control:no-cache' -H 'content-type:application/x-www-form-urlencoded' --data 'IMAGE_TAG=${BUILD_NUMBER}' 'http://119.148.39.65:8081/job/CD_Pipeline/buildWithParameters?token=gitops-config' " 
                }
            }
        }
    }
 
    post {
        success {
            echo 'Docker image build and push successful!'
        }
        failure {
            error 'Docker image build or push failed!'
        }
    }
}
