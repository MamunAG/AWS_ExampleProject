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

        stage('Deployment') {
            steps {
                echo 'Deployment start.'
            }
        }

        stage('Checkout SCM') {
            steps{
                script{
                    git credentials: 'github_uk',
                    url: 'https://github.com/MamunAG/AWS_Deployment.git',
                    branch: 'main'
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
