---
title: Instalação
type: docs
weight: 70
url: /pt/cpp/installation/
keywords:
- instalar Aspose.Slides
- baixar Aspose.Slides
- usar Aspose.Slides
- instalação Aspose.Slides
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Instale Aspose.Slides para C++ no Windows via NuGet no Visual Studio, ou no Linux a partir do pacote ZIP com CMake, e verifique a instalação com um primeiro programa."
---
## **Visão geral**

Aspose.Slides for C++ é distribuído em duas formas:

| Forma | Para que usar | Onde obter |
|---|---|---|
| Pacotes NuGet: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64 bits) e [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32 bits) | Projetos C++ do Visual Studio no Windows | NuGet |
| Pacotes ZIP para Windows, Linux e macOS | Compilações sem NuGet, como projetos CMake | A [página de download](https://releases.aspose.com/slides/pt/cpp/) |

Este artigo mostra como instalar o pacote NuGet no Visual Studio no Windows e como usar o pacote ZIP com CMake no Linux. Ambos os caminhos terminam com a mesma verificação: compilar e executar o primeiro exemplo em [Create Presentations](/slides/pt/cpp/create-presentation/).

## **Windows**

No Windows, adicione o pacote NuGet a um projeto C++ do Visual Studio. O pacote também instala sua dependência, CodePorting.Translator.Cs2Cpp.Framework, e copia as DLLs que seu programa precisa para a pasta de saída da compilação.

Escolha o pacote de acordo com a plataforma que você compila: **Aspose.Slides.Cpp** para x64 e **Aspose.Slides.Cpp.x86** para Win32 (x86). O pacote Aspose.Slides.Cpp não é aplicado a uma compilação Win32, portanto o compilador não encontra seus headers lá.

Um pacote ZIP para Windows também está disponível na [página de download](https://releases.aspose.com/slides/pt/cpp/).

### **Método 1: Instalar ou atualizar Aspose.Slides a partir do Gerenciador de Pacotes NuGet**

1. Abra o Microsoft Visual Studio.  
2. Crie um projeto C++ **Console App**, ou abra um projeto existente.  
3. No **Solution Explorer**, clique com o botão direito no projeto e selecione **Manage NuGet Packages** (ou vá em **Project** > **Manage NuGet Packages**).  
4. Em **Browse**, procure por *Aspose.Slides.Cpp*.  
   ![Procurando por Aspose.Slides.Cpp no Gerenciador de Pacotes NuGet](installation_1.png)  
5. Clique em **Aspose.Slides.Cpp** (ou **Aspose.Slides.Cpp.x86** para uma compilação de 32 bits) e então clique em **Install**.  
   * Se você já instalou Aspose.Slides e deseja atualizá-lo, clique em **Update**.  

O pacote é baixado e referenciado no seu projeto.

### **Método 2: Instalar ou atualizar Aspose.Slides através do Console do Gerenciador de Pacotes**

1. Abra o Microsoft Visual Studio.  
2. Crie um projeto C++ **Console App**, ou abra um projeto existente.  
3. Vá em **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
   ![Abrindo o Console do Gerenciador de Pacotes](installation_2.png)  
4. Execute este comando:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   Para uma compilação de 32 bits (Win32), instale o pacote x86 em vez disso:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

   ![Executando o comando Install-Package](installation_3.png)

   Quando a instalação termina, aparecem mensagens de confirmação. O pacote é distribuído sob a [Aspose EULA](https://about.aspose.com/legal/eula).  
   ![Mensagens de confirmação da instalação](installation_4.png)

   Para atualizar o pacote, execute `Update-Package Aspose.Slides.Cpp` (ou `Update-Package Aspose.Slides.Cpp.x86`) no Console do Gerenciador de Pacotes.

### **Verificar a Instalação**

1. Substitua o conteúdo do arquivo *.cpp* principal do projeto (o arquivo que contém `main`) pelo primeiro exemplo em [Create Presentations](/slides/pt/cpp/create-presentation/).  
2. Na barra de ferramentas, selecione a plataforma **x64**, ou **x86** se você instalou Aspose.Slides.Cpp.x86.  
3. Pressione **Ctrl+F5** para compilar e executar o programa.  

O programa salva *hello.pptx* na pasta do projeto, que é o diretório de trabalho padrão quando o Visual Studio executa um programa.

## **Linux**

No Linux, use o pacote ZIP para Linux com CMake. Ele contém a biblioteca Aspose.Slides, sua dependência CodePorting.Translator.Cs2Cpp.Framework e um arquivo de configuração CMake para cada uma delas. As bibliotecas são compiladas para Linux x86_64 com glibc 2.23 ou posterior.

1. Instale um compilador C++, make, CMake, unzip e a biblioteca fontconfig, da qual as bibliotecas Aspose.Slides dependem. No Debian e Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Crie uma pasta de projeto e navegue até ela:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Baixe o ZIP Linux (**Aspose.Slides for C++ Linux**) da [página de download](https://releases.aspose.com/slides/pt/cpp/) para a pasta do projeto e extraia-o para a subpasta *aspose-slides-cpp*:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Crie um arquivo chamado *CMakeLists.txt* na pasta do projeto com este conteúdo:

   ```cmake
   cmake_minimum_required(VERSION 3.13)
   project(HelloSlides CXX)

   set(CMAKE_CXX_STANDARD 14)
   set(CMAKE_CXX_STANDARD_REQUIRED ON)

   set(ASPOSE_SLIDES_DIR "${CMAKE_CURRENT_SOURCE_DIR}/aspose-slides-cpp")
   find_package(CodePorting.Translator.Cs2Cpp.Framework REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)
   find_package(Aspose.Slides.Cpp REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)

   add_executable(hello main.cpp)
   target_link_libraries(hello PRIVATE Aspose.Slides.Cpp)
   ```

   As duas chamadas `find_package` carregam os arquivos de configuração CMake do pacote descompactado. O framework é encontrado primeiro porque o Aspose.Slides depende dele. Vincular o alvo `Aspose.Slides.Cpp` adiciona as pastas de inclusão e ambas as bibliotecas à compilação.

5. Salve o primeiro exemplo em [Create Presentations](/slides/pt/cpp/create-presentation/) como *main.cpp* na pasta do projeto.  
6. Compile e execute o programa:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

O programa salva *hello.pptx* na pasta atual. O CMake registra a localização das bibliotecas no programa, de modo que você não precisa definir `LD_LIBRARY_PATH` enquanto a pasta *aspose-slides-cpp* permanecer no local.

As fontes usadas em suas apresentações, ou substitutos adequados, devem estar instaladas no sistema para que o texto seja renderizado corretamente ao converter slides para PDF ou imagens.

## **FAQ**

**Existe uma versão gratuita ou limitação de avaliação?**

Sim. Sem uma licença, Aspose.Slides funciona no modo de avaliação: adiciona uma marca d'água de avaliação a cada slide que salva e trunca o texto lido das apresentações. Para remover essas limitações, aplique uma [licença](/slides/pt/cpp/licensing/) válida.

**Por que o compilador relata que não pode abrir *DOM/Presentation.h*?**

O pacote instalado não corresponde à plataforma que você está compilando. Aspose.Slides.Cpp aplica‑se apenas a compilações x64, e Aspose.Slides.Cpp.x86 apenas a compilações Win32. Selecione a plataforma correspondente no Visual Studio ou instale o outro pacote.