---
title: Como Executar Aspose.Slides para Java no Docker
type: docs
weight: 75
url: /pt/java/how-to-run-aspose-slides-in-docker/
keywords:
- download do Aspose.Slides
- instalação do Aspose.Slides
- instalação do Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- compatibilidade multiplataforma
- isolamento de dependências
- implantação simplificada
- configuração do projeto
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Execute o Aspose.Slides em contêineres Docker: configure imagens, dependências, fontes e licenciamento para criar serviços escaláveis que processam PowerPoint e OpenDocument."
---
## **Introdução**

Este guia explica como containerizar uma aplicação Java usando Aspose Slides com Docker. Os principais benefícios incluem:

- **Compatibilidade multiplataforma** - Executa em Windows, macOS e Linux
- **Isolamento de dependências** - Não requer instalações de sistema
- **Implantação simplificada** - Compartilhamento e execução fáceis

## **1. Instalação do Docker**

### **Windows**

**Requisitos:**

- Windows 10/11 Pro/Enterprise/Education (64-bit) com WSL 2 habilitado
- Para a edição Home: requer instalação manual do WSL 2

**Etapas:**

1. Baixe o [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. Execute o instalador e siga o assistente de configuração
3. Reinicie o computador quando solicitado
4. Verifique a instalação:
   ```powershell
   docker --version
   ```

### **macOS**

**Requisitos:**

- macOS 10.15 (Catalina) ou mais recente
- Processador Apple Silicon ou Intel

**Etapas:**

1. Baixe o [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. Arraste o aplicativo para a pasta `Applications`
3. Inicie o Docker e aguarde a inicialização
4. Verifique a instalação:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Instalação:**

```bash
# Atualizar listas de pacotes
sudo apt update && sudo apt upgrade -y

# Instalar pré-requisitos
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Adicionar a chave GPG oficial do Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Adicionar um repositório estável
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Instalar o Docker Engine
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Permitir que o usuário atual execute comandos Docker
sudo usermod -aG docker $USER
newgrp docker

# Verificar a instalação
docker --version
```

## **2. Configuração do Dockerfile**

### **Imagem base**

```dockerfile
FROM ubuntu:24.04
```
> **Observação**: Usa a [official Ubuntu image](https://hub.docker.com/_/ubuntu) do Docker Hub.

### **Dependências**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: ambiente de tempo de execução Java
- **Pacotes de fontes**: inclui Microsoft Core Fonts

### **Configuração do Aspose.Slides**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Download da biblioteca Aspose Slides com versão fixa

## **3. Configuração do Projeto**

### **Estrutura de arquivos**

```
aspose-docker/
├── Dockerfile          # Configuração do contêiner
├── TestAspose.java     # Código da aplicação
└── output/             # Pasta com PDFs gerados (criada automaticamente)
```

### **Dockerfile**

Crie um arquivo chamado `Dockerfile` com:
```dockerfile
FROM ubuntu:24.04

# Definir variáveis de ambiente
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Criar um diretório de trabalho
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Instalar dependências
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Configurar fontes
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Baixar Aspose.Slides para /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Copiar o código-fonte
COPY TestAspose.java ${APP_DIR}/

# Criar o script de execução
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Conceder explicitamente permissões de execução ao script
RUN chmod 755 ${APP_DIR}/run.sh

# Compilar o código Java
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Definir o diretório de trabalho
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Aplicação Java**

Crie `TestAspose.java` com:
```java
import com.aspose.slides.*;

public class TestAspose {
    public static void main(String[] args) throws Exception {
        System.out.println("Creating presentation...");
        
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 190, 300, 25);
            autoShape.getTextFrame().setText("Greetings from Docker!");
            
            presentation.save("/tmp/output/output.pdf", SaveFormat.Pdf);
        } finally {
            if (presentation != null) presentation.dispose();
        }
        System.out.println("Presentation saved as output.pdf");
    }
}
```

## **4. Compilação e Execução**

### **Construir a imagem**

   Execute o comando a seguir no diretório onde o Dockerfile está localizado para construir a imagem Docker:
   ```powershell
   docker build -t aspose-test .
   ```
   
- `-t` nomeia a imagem como "aspose-test"
- `.` usa o Dockerfile do diretório atual

### **Executar o contêiner**

   Execute o comando a seguir no diretório onde o Dockerfile está localizado para executar o contêiner Docker:
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```
   
- `-v` monta o diretório de saída
- Cria `output.pdf` na pasta local `output`