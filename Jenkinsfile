pipeline {
    agent any
 
    environment {
        // Define environment variables if needed

        DOCKER_HUB_CREDENTIALS = credentials('DockerhubCred')
        DOCKER_IMAGE_NAME = '1almamun/aws_docker_example'
        DOCKER_IMAGE_TAG = 'latest'


        registry = '1almamun/aws_docker_example'
        registryCredential = '1almamun'
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
                    docker.withRegistry('https://registry.example.com', 'DockerHubUserPass') {
                    
                        def customImage = docker.build("1almamun/aws_docker_example:${env.BUILD_ID}")

                        /* Push the container to the custom Registry */
                        customImage.push()
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