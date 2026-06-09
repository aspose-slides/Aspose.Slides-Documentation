---
title: Πώς να Εκτελέσετε το Aspose.Slides για C++ σε Docker
type: docs
weight: 140
url: /el/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- λήψη Aspose.Slides
- εγκατάσταση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- διαλειτουργικότητα πολλαπλών πλατφορμών
- απομόνωση εξαρτήσεων
- απλοποιημένη ανάπτυξη
- ρύθμιση έργου
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εκτέλεση Aspose.Slides σε Docker containers: διαμόρφωση εικόνων, εξαρτήσεων, γραμματοσειρών και αδειοδότησης για δημιουργία επεκτάσιμων υπηρεσιών που επεξεργάζονται PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Το Aspose.Slides for C++ μπορεί να εκτελείται μέσα σε docker containers. Για να εκτελέσετε το Aspose.Slides for C++ σε περιβάλλον Linux, μπορείτε να χρησιμοποιήσετε ένα αρχείο docker. 

## **Περιγραφή Dockerfile**

Για παράδειγμα, μπορείτε να χρησιμοποιήσετε αυτό το αρχείο docker για το Aspose.Slides for C++ με Ubuntu 16.04: 

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

Το αρχείο περιέχει τρία κύρια μέρη (διαδικασίες):

1. Εγκατάσταση των εργαλείων που απαιτούνται για την εκτέλεση του Aspose.Slides for C++:

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

2. Εγκατάσταση του πακέτου msttcorefonts (εξ ορισμού, η συμφωνία χρήσης (EULA) του πακέτου msttcorefonts δεν έχει γίνει αποδεκτή): 

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. Δήλωση του φακέλου /slides-cpp ως σημείο προσάρτησης για να παρέχει πρόσβαση στο φάκελο πηγαίων κώδικων slides-cpp του κεντρικού υπολογιστή· Δημιουργία και εκτέλεση παραδειγμάτων:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **Δημιουργία και Εκτέλεση Εικόνας**

1. [Εγκατάσταση Docker](https://docs.docker.com/engine/install/) σε σύστημα υποδοχής.

2. Δημιουργήστε μια εικόνα. 

   Ένας φάκελος εργασίας τερματικού πρέπει να περιέχει ένα αρχείο Dockerfile με το παραπάνω περιεχόμενο. 

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Κατεβάστε και αποσυμπιέστε το [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/el/cpp).
4. Κοινοποιήστε το φάκελο με το Aspose.Slides for C++ ώστε το Docker να το χρησιμοποιήσει: 
   - Σε Windows, κάντε δεξί κλικ στο εικονίδιο του Docker στη γραμμή εργασιών. Επιλέξτε Ρυθμίσεις.
   - Μεταβείτε στις Πηγές > Κοινή Χρήση Αρχείων. 
5. Εκτελέστε την εικόνα ως κοντέινερ χρησιμοποιώντας μία από τις μεθόδους αυτές:

* Μέθοδος A: δημιουργία και εκτέλεση ενός ονομαστικού κοντέινερ:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Για τη δεύτερη και τις επόμενες εκκινήσεις, πρέπει να χρησιμοποιήσετε:

```
docker start slides-cpp-ubuntu -i
```

* Μέθοδος B: δημιουργία και εκτέλεση ενός ανώνυμου προσωρινού κοντέινερ:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Θα δείτε τη δημιουργία και την εκτέλεση του δείγματος έργου:

```
-- The CXX compiler identification is Clang 3.9.1
-- Check for working CXX compiler: /usr/bin/clang++
-- Check for working CXX compiler: /usr/bin/clang++ -- works
-- Detecting CXX compiler ABI info
-- Detecting CXX compiler ABI info - done
-- Detecting CXX compile features
-- Detecting CXX compile features - done
-- Configuring done
-- Generating done
-- Build files have been written to: /slides-cpp/sample/build
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