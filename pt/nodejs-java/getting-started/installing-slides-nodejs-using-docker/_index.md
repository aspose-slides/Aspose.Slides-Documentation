---
title: Instalar Aspose.Slides para Node.js via Java usando Docker
type: docs
weight: 75
url: /pt/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- baixar Aspose.Slides
- instalar Aspose.Slides
- instalação do Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- compatibilidade multiplataforma
- isolamento de dependências
- implantação simplificada
- configuração de projeto
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Execute Aspose.Slides em contêineres Docker: configure imagens, dependências, fontes e licenças para criar serviços escaláveis que processam PowerPoint e OpenDocument."
---
## Pré-requisitos:
* Instale o Docker na sua máquina. Você pode seguir o guia de instalação oficial [aqui](https://docs.docker.com/get-docker/).

## Etapas:

### 1. **Criar Dockerfile** 
   Crie um novo arquivo chamado Dockerfile no diretório do seu projeto com o seguinte conteúdo:
   ```
   # Use o Ubuntu 20.04 como imagem base
   FROM ubuntu:20.04

   # Atualize a lista de pacotes e instale os pacotes essenciais para adicionar repositórios e baixar arquivos
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Instale o Node.js versão 18.x do repositório Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Instale o Python 2.x, que é necessário para alguns pacotes npm como node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Instale o OpenJDK 11, que é necessário para as dependências Java do Aspose.Slides
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Instale o pacote build-essential, que inclui ferramentas como 'make' necessárias para compilar módulos nativos
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Instale o node-gyp globalmente, uma ferramenta usada para compilar add-ons nativos para Node.js
   RUN npm install -g node-gyp

   # Defina o diretório de trabalho dentro do contêiner para /app
   WORKDIR /app

   # Crie o arquivo package.json com os detalhes e dependências necessárias
   RUN echo '{\n\
     "name": "aspose-slides-app",\n\
     "version": "1.0.0",\n\
     "main": "index.js",\n\
     "scripts": {\n\
      "start": "node index.js"\n\
     },\n\
     "dependencies": {\n\
      "aspose.slides.via.java": "^25.12.0"\n\
     }\n\
   }' > package.json

   # Crie o arquivo index.js com código de exemplo para criar uma apresentação usando Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Instale o pacote Aspose.Slides via Java especificado no package.json
   RUN npm install aspose.slides.via.java

   # Defina o comando padrão para executar a aplicação quando o contêiner iniciar
   CMD ["node", "index.js"]
   ```

### 2. **Construir Imagem Docker**
   Execute o seguinte comando no diretório onde seu Dockerfile está localizado para compilar a imagem Docker:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Executar Contêiner Docker**
   Execute o contêiner e salve seu ID:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Acessar Aspose.Slides no Docker** 
   Após iniciar o contêiner, o script gerará um arquivo PPTX. Você pode encontrar o arquivo de saída gerado `NewPresentation.pptx` na pasta `/app` dentro do contêiner:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Remova o contêiner temporário:
   ```bash
   docker rm $CONTAINER_ID
   ```