---
title: Installazione
type: docs
weight: 70
url: /it/cpp/installation/
keywords:
- installare Aspose.Slides
- scaricare Aspose.Slides
- usare Aspose.Slides
- installazione Aspose.Slides
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Installa Aspose.Slides per C++ su Windows da NuGet in Visual Studio, o su Linux dal pacchetto ZIP con CMake, e verifica l'installazione con un primo programma."
---
## **Panoramica**

Aspose.Slides for C++ è distribuito in due forme:

| Forma | Per cosa usarla | Dove ottenerla |
|---|---|---|
| Pacchetti NuGet: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64‑bit) e [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32‑bit) | Progetti Visual Studio C++ su Windows | NuGet |
| Pacchetti ZIP per Windows, Linux e macOS | Compilazioni senza NuGet, come progetti CMake | La [pagina di download](https://releases.aspose.com/slides/cpp/) |

Questo articolo mostra come installare il pacchetto NuGet in Visual Studio su Windows e come usare il pacchetto ZIP con CMake su Linux. Entrambi i percorsi terminano con la stessa verifica: compilare ed eseguire il primo esempio in [Create Presentations](/slides/it/cpp/create-presentation/).

## **Windows**

Su Windows, aggiungi il pacchetto NuGet a un progetto Visual Studio C++. Il pacchetto installa anche la sua dipendenza, CodePorting.Translator.Cs2Cpp.Framework, e copia le DLL necessarie nella cartella di output della compilazione.

Scegli il pacchetto in base alla piattaforma di destinazione: **Aspose.Slides.Cpp** per x64 e **Aspose.Slides.Cpp.x86** per Win32 (x86). Il pacchetto Aspose.Slides.Cpp non si applica a una compilazione Win32, quindi il compilatore non trova le sue intestazioni.

È disponibile anche un pacchetto ZIP per Windows nella [pagina di download](https://releases.aspose.com/slides/cpp/).

### **Metodo 1: Installare o aggiornare Aspose.Slides dal gestore pacchetti NuGet**

1. Apri Microsoft Visual Studio.  
2. Crea un progetto **Console App** C++, oppure apri un progetto esistente.  
3. In **Solution Explorer**, fai clic con il tasto destro sul progetto e seleziona **Manage NuGet Packages** (o vai su **Project** > **Manage NuGet Packages**).  
4. Nella scheda **Browse**, cerca *Aspose.Slides.Cpp*.  
![Ricerca di Aspose.Slides.Cpp nel gestore pacchetti NuGet](installation_1.png)  
5. Fai clic su **Aspose.Slides.Cpp** (o **Aspose.Slides.Cpp.x86** per una compilazione a 32 bit) e poi su **Install**.  
   * Se hai già installato Aspose.Slides e vuoi aggiornarlo, fai clic su **Update** invece.

Il pacchetto viene scaricato e aggiunto al tuo progetto.

### **Metodo 2: Installare o aggiornare Aspose.Slides tramite la console del gestore pacchetti**

1. Apri Microsoft Visual Studio.  
2. Crea un progetto **Console App** C++, oppure apri un progetto esistente.  
3. Vai su **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
![Apertura della console del gestore pacchetti](installation_2.png)  
4. Esegui questo comando:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   Per una compilazione a 32 bit (Win32), installa invece il pacchetto x86:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

![Esecuzione del comando Install-Package](installation_3.png)

Al termine dell'installazione compaiono i messaggi di conferma. Il pacchetto è distribuito sotto la [Aspose EULA](https://about.aspose.com/legal/eula).  
![Messaggi di conferma dell'installazione](installation_4.png)

Per aggiornare il pacchetto, esegui `Update-Package Aspose.Slides.Cpp` (o `Update-Package Aspose.Slides.Cpp.x86`) nella Package Manager Console.

### **Verifica dell'installazione**

1. Sostituisci il contenuto del file *.cpp* principale del progetto (quello che contiene `main`) con il primo esempio in [Create Presentations](/slides/it/cpp/create-presentation/).  
2. nella barra degli strumenti, seleziona la piattaforma **x64**, o **x86** se hai installato Aspose.Slides.Cpp.x86.  
3. Premi **Ctrl+F5** per compilare ed eseguire il programma.

Il programma salva *hello.pptx* nella cartella del progetto, che è la directory di lavoro predefinita quando Visual Studio avvia un programma.

## **Linux**

Su Linux, usa il pacchetto ZIP per Linux con CMake. Contiene la libreria Aspose.Slides, la sua dipendenza CodePorting.Translator.Cs2Cpp.Framework e un file di configurazione CMake per ciascuna di esse. Le librerie sono compilate per Linux x86_64 con glibc 2.23 o successiva.

1. Installa un compilatore C++, make, CMake, unzip e la libreria fontconfig, su cui le librerie Aspose.Slides fanno affidamento. Su Debian e Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Crea una cartella di progetto e spostati al suo interno:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Scarica il pacchetto ZIP Linux (**Aspose.Slides for C++ Linux**) dalla [pagina di download](https://releases.aspose.com/slides/cpp/) nella cartella di progetto e decomprimilo nella sottocartella *aspose-slides-cpp*:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Crea un file denominato *CMakeLists.txt* nella cartella di progetto con questo contenuto:

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

   Le due chiamate `find_package` caricano i file di configurazione CMake dal pacchetto decompresso. Il framework viene trovato per primo perché Aspose.Slides dipende da esso. Il collegamento al target `Aspose.Slides.Cpp` aggiunge le cartelle di inclusione e entrambe le librerie alla build.

5. Salva il primo esempio in [Create Presentations](/slides/it/cpp/create-presentation/) come *main.cpp* nella cartella di progetto.  
6. Compila ed esegui il programma:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

Il programma salva *hello.pptx* nella cartella corrente. CMake registra la posizione delle librerie nel programma, quindi non è necessario impostare `LD_LIBRARY_PATH` finché la cartella *aspose-slides-cpp* rimane al suo posto.

I caratteri tipografici usati nelle presentazioni, o eventuali sostituti idonei, devono essere installati sul sistema affinché il testo venga visualizzato correttamente quando converti le diapositive in PDF o immagini.

## **FAQ**

**Esiste una versione gratuita o limitata nella prova?**

Sì. Senza licenza, Aspose.Slides funziona in modalità di valutazione: aggiunge una filigrana di valutazione a ogni diapositiva salvata e tronca il testo letto dalle presentazioni. Per rimuovere queste limitazioni, applica una licenza valida [license](/slides/it/cpp/licensing/).

**Perché il compilatore segnala che non può aprire *DOM/Presentation.h*?**

Il pacchetto installato non corrisponde alla piattaforma di compilazione. Aspose.Slides.Cpp si applica solo a build x64, e Aspose.Slides.Cpp.x86 solo a build Win32. Seleziona la piattaforma corrispondente in Visual Studio oppure installa l'altro pacchetto.