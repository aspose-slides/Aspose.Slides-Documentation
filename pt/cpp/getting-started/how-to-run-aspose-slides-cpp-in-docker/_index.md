---
title: Como Executar Aspose.Slides for C++ no Docker
type: docs
weight: 140
url: /pt/cpp/how-to-run-aspose-slides-cpp-in-docker/
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
- configuração do projeto
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Execute Aspose.Slides em contêineres Docker: configure imagens, dependências, fontes e licenciamento para construir serviços escaláveis que processam PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides for C++ pode ser executado dentro de contêineres Docker. Para executar Aspose.Slides for C++ em um ambiente Linux, você pode usar um arquivo Docker. 

## **Descrição do Dockerfile**

Por exemplo, você pode usar este arquivo Docker para Aspose.Slides for C++ com Ubuntu 16.04: 

```
FROM ubuntu:16.04

RUN apt-get update && apt-get install software-properties-common -y \
 && add-apt-repository ppa:ubuntu-toolchain-r/test \
 && apt-get update && apt-get upgrade libstdc++6 -y --no-install-recommends\
 && apt-get install -y --no-install-recommends  \
    unzip \
    cmake \
    make \
    clang-3.9 \
    gcc-6 \
    g++-6 \
    fontconfig \
    libglu1-mesa \ 
 && update-alternatives --install /usr/bin/clang   clang   /usr/bin/clang-3.9 30 \
 && update-alternatives --install /usr/bin/clang++ clang++ /usr/bin/clang++-3.9 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/clang-3.9 40 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/clang++-3.9 40 \
 && update-alternatives --install /usr/bin/gcc gcc /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/g++ g++ /usr/bin/g++-6 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/g++-6 30

ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v

VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

O arquivo contém três partes principais (procedimentos):

1. Instalando as ferramentas necessárias para executar Aspose.Slides for C++:

```
FROM ubuntu:16.04

RUN apt-get update && apt-get install software-properties-common -y \
 && add-apt-repository ppa:ubuntu-toolchain-r/test \
 && apt-get update && apt-get upgrade libstdc++6 -y --no-install-recommends\
 && apt-get install -y --no-install-recommends  \
    unzip \
    cmake \
    make \
    clang-3.9 \
    gcc-6 \
    g++-6 \
    fontconfig \
    libglu1-mesa \ 
 && update-alternatives --install /usr/bin/clang   clang   /usr/bin/clang-3.9 30 \
 && update-alternatives --install /usr/bin/clang++ clang++ /usr/bin/clang++-3.9 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/clang-3.9 40 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/clang++-3.9 40 \
 && update-alternatives --install /usr/bin/gcc gcc /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/g++ g++ /usr/bin/g++-6 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/g++-6 30
```

2. Instalando o pacote msttcorefonts (por padrão, o EULA do pacote msttcorefonts não é aceito): 

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. Declarando a pasta /slides-cpp como ponto de montagem para fornecer acesso à pasta de fontes slides-cpp na máquina host; Construindo e executando exemplos:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **Compilando e Executando uma Imagem**

1. [Instalar Docker](https://docs.docker.com/engine/install/) no sistema host.

2. Criar uma imagem.  

   O diretório de trabalho do terminal deve conter um arquivo Dockerfile com o conteúdo acima. 

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Baixar e descompactar [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/pt/cpp).

4. Compartilhar a pasta com Aspose.Slides for C++ para permitir que o Docker a use:  
   - No Windows, clique com o botão direito no ícone do Docker na barra de tarefas. Selecione Configurações.  
   - Acesse Recursos > Compartilhamento de Arquivos.  

5. Executar a imagem como um contêiner por meio de um destes métodos:

* Método A: criar e executar um contêiner nomeado:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Para a segunda e subsequentes execuções, você deve usar:

```
docker start slides-cpp-ubuntu -i
```

* Método B: criar e executar um contêiner temporário sem nome:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Você verá a compilação e a execução do projeto de exemplo:

```
-- A identificação do compilador CXX é Clang 3.9.1
-- Verificando o compilador CXX funcionando: /usr/bin/clang++
-- Verificando o compilador CXX funcionando: /usr/bin/clang++ -- funciona
-- Detectando informações ABI do compilador CXX
-- Detectando informações ABI do compilador CXX - concluído
-- Detectando recursos de compilação CXX
-- Detectando recursos de compilação CXX - concluído
-- Configuração concluída
-- Geração concluída
-- Arquivos de compilação foram gravados em: /slides-cpp/sample/build
Scanning dependencies of target Aspose.Slides.Cpp.Examples
[ 14%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/chart.cpp.o
[ 42%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/main.cpp.o
[ 42%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/presentation_export.cpp.o
[ 57%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/smart_art.cpp.o
[ 71%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/text.cpp.o
[ 85%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/thumbnail.cpp.o
[100%] Linking CXX executable Aspose.Slides.Cpp.Examples
[100%] Built target Aspose.Slides.Cpp.Examples

Running examples...

Running Chart::SampleChart...
Running Thumbnail::SampleThumbnail...
Running Text::SampleAddText...
Running SmartArt::SampleCreation...
Running SmartArt::SampleCloning...
Running SmartArt::SampleNodesTextEditing...
Running SmartArt::SampleNodeAdd...
Running SmartArt::SampleColorStyleEditing...
Running SmartArt::SampleQuickStyleEditing...
Running SmartArt::SampleNodeRemove...
Running SmartArt::SampleRemoveSmartArt...
Running PresentationExport::Export...
Saving presentation as PDF...OK
Saving presentation as XPS...OK
Saving presentation as SWF...OK
Saving presentation as HTML...OK
Saving presentation as PDF...OK
Saving presentation as XPS...OK
Saving presentation as SWF...OK
Saving presentation as HTML...OK
```