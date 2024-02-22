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
                    // This step should not normally be used in your script. Consult the inline help for details.
                    withDockerRegistry(credentialsId: 'DockerHubUserPass', url: 'https://registry.hub.docker.com/v2/') {
                        //def customImage = docker.build("1almamun/aws_docker_example:${env.BUILD_ID}")

                        /* Push the container to the custom Registry */
                        //customImage.push()
                        echo 'successfully logged in.'
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