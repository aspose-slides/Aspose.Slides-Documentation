---
title: Installation
type: docs
weight: 70
url: /fr/cpp/installation/
keywords:
- installer Aspose.Slides
- télécharger Aspose.Slides
- utiliser Aspose.Slides
- installation Aspose.Slides
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Installez Aspose.Slides pour C++ sous Windows à partir de NuGet dans Visual Studio, ou sous Linux à partir du package ZIP avec CMake, et vérifiez l'installation avec un premier programme."
---
## **Vue d'ensemble**

Aspose.Slides for C++ est distribué sous deux formes :

| Forme | Utilisation | Où l'obtenir |
|---|---|---|
| Packages NuGet : [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64 bits) et [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32 bits) | Projets Visual Studio C++ sous Windows | NuGet |
| Packages ZIP pour Windows, Linux et macOS | Constructions sans NuGet, comme les projets CMake | La [page de téléchargement](https://releases.aspose.com/slides/fr/cpp/) |

Cet article montre comment installer le package NuGet dans Visual Studio sous Windows et comment utiliser le package ZIP avec CMake sous Linux. Les deux voies se terminent par le même contrôle : compiler et exécuter le premier exemple dans [Créer des présentations](/slides/fr/cpp/create-presentation/).

## **Windows**

Sous Windows, ajoutez le package NuGet à un projet Visual Studio C++. Le package installe également sa dépendance, CodePorting.Translator.Cs2Cpp.Framework, et copie les DLL dont votre programme a besoin dans le dossier de sortie de la compilation.

Choisissez le package en fonction de la plateforme ciblée : **Aspose.Slides.Cpp** pour x64, et **Aspose.Slides.Cpp.x86** pour Win32 (x86). Le package Aspose.Slides.Cpp n'est pas appliqué à une construction Win32, de sorte que le compilateur ne trouve pas ses en‑têtes dans ce cas.

Un package ZIP Windows est également disponible depuis la [page de téléchargement](https://releases.aspose.com/slides/fr/cpp/).

### **Méthode 1 : installer ou mettre à jour Aspose.Slides depuis le gestionnaire de packages NuGet**

1. Ouvrez Microsoft Visual Studio.  
2. Créez un projet **Console App** C++, ou ouvrez un projet existant.  
3. Dans **Solution Explorer**, cliquez avec le bouton droit sur le projet et choisissez **Manage NuGet Packages** (ou allez dans **Project** > **Manage NuGet Packages**).  
4. Sous **Browse**, recherchez *Aspose.Slides.Cpp*.  
   ![Recherche d'Aspose.Slides.Cpp dans le gestionnaire de packages NuGet](installation_1.png)  
5. Cliquez sur **Aspose.Slides.Cpp** (ou **Aspose.Slides.Cpp.x86** pour une construction 32 bits) puis cliquez sur **Install**.  
   * Si vous avez déjà installé Aspose.Slides et souhaitez le mettre à jour, cliquez sur **Update** à la place.

Le package est téléchargé et référencé dans votre projet.

### **Méthode 2 : installer ou mettre à jour Aspose.Slides via la console du gestionnaire de packages**

1. Ouvrez Microsoft Visual Studio.  
2. Créez un projet **Console App** C++, ou ouvrez un projet existant.  
3. Allez dans **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
   ![Ouverture de la console du gestionnaire de packages](installation_2.png)  
4. Exécutez cette commande :

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   Pour une construction 32 bits (Win32), installez le package x86 à la place :

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

   ![Exécution de la commande Install-Package](installation_3.png)

Lorsque l'installation se termine, des messages de confirmation apparaissent. Le package est distribué sous la [Aspose EULA](https://about.aspose.com/legal/eula).  
![Messages de confirmation d'installation](installation_4.png)

Pour mettre à jour le package, exécutez `Update-Package Aspose.Slides.Cpp` (ou `Update-Package Aspose.Slides.Cpp.x86`) dans la console du gestionnaire de packages.

### **Vérifier l'installation**

1. Remplacez le contenu du fichier *.cpp* principal du projet (celui qui contient `main`) par le premier exemple dans [Créer des présentations](/slides/fr/cpp/create-presentation/).  
2. Dans la barre d'outils, choisissez la plateforme **x64**, ou **x86** si vous avez installé Aspose.Slides.Cpp.x86.  
3. Appuyez sur **Ctrl+F5** pour compiler et exécuter le programme.

Le programme enregistre *hello.pptx* dans le dossier du projet, qui est le répertoire de travail par défaut lorsque Visual Studio exécute un programme.

## **Linux**

Sous Linux, utilisez le package ZIP Linux avec CMake. Il contient la bibliothèque Aspose.Slides, sa dépendance CodePorting.Translator.Cs2Cpp.Framework, et un fichier de configuration CMake pour chacune d'elles. Les bibliothèques sont compilées pour Linux x86_64 avec glibc 2.23 ou ultérieur.

1. Installez un compilateur C++, make, CMake, unzip et la bibliothèque fontconfig, dont dépendent les bibliothèques Aspose.Slides. Sous Debian et Ubuntu :

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Créez un dossier de projet et déplacez‑vous dedans :

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Téléchargez le ZIP Linux (**Aspose.Slides for C++ Linux**) depuis la [page de téléchargement](https://releases.aspose.com/slides/fr/cpp/) dans le dossier du projet, puis décompressez‑le dans le sous‑dossier *aspose-slides-cpp* :

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Créez un fichier nommé *CMakeLists.txt* dans le dossier du projet avec le contenu suivant :

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

   Les deux appels `find_package` chargent les fichiers de configuration CMake du package décompressé. Le framework est trouvé en premier parce qu'Aspose.Slides en dépend. Lier la cible `Aspose.Slides.Cpp` ajoute les dossiers d’inclusion et les deux bibliothèques à la construction.

5. Enregistrez le premier exemple dans [Créer des présentations](/slides/fr/cpp/create-presentation/) sous le nom *main.cpp* dans le dossier du projet.  
6. Compilez et exécutez le programme :

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

Le programme enregistre *hello.pptx* dans le dossier courant. CMake enregistre l’emplacement des bibliothèques dans le programme, vous n’avez donc pas besoin de définir `LD_LIBRARY_PATH` tant que le dossier *aspose-slides-cpp* reste en place.

Les polices utilisées dans vos présentations, ou des substituts appropriés, doivent être installées sur le système pour que le texte s’affiche correctement lors de la conversion des diapositives en PDF ou en images.

## **FAQ**

**Existe‑t‑il une version gratuite ou une limitation d’essai ?**

Oui. Sans licence, Aspose.Slides fonctionne en mode d’évaluation : il ajoute un filigrane d’évaluation à chaque diapositive enregistrée et tronque le texte lu depuis les présentations. Pour supprimer ces limitations, appliquez une [licence](/slides/fr/cpp/licensing/) valide.

**Pourquoi le compilateur indique‑t‑il qu’il ne peut pas ouvrir *DOM/Presentation.h* ?**

Le package installé ne correspond pas à la plateforme que vous ciblez. Aspose.Slides.Cpp s’applique uniquement aux constructions x64, et Aspose.Slides.Cpp.x86 uniquement aux constructions Win32. Sélectionnez la plateforme correspondante dans Visual Studio, ou installez l’autre package.