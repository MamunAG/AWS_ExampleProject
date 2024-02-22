pipeline {
    agent any
 
    environment {
        // Define environment variables if needed

        DOCKER_HUB_CREDENTIALS = credentials('DockerhubCred')
        DOCKER_IMAGE_NAME = '1almamun/aws_docker_example'
        DOCKER_IMAGE_TAG = 'latest'


        registry = '1almamun/aws_docker_example'
        registryCredentialUp = 'DockerHubUserPass'
        dockerImage = ''


    }

    stages {
        stage('Start') {
            steps {
                echo 'Pipeline start.'
            }
        }

    
        stage('Building our image') {
            steps{
                script {
                    dockerImage = docker.build registry + ":$BUILD_NUMBER"
                }
            }
        }

        stage('Deploy our image') {
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