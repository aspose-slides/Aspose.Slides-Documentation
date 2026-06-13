---
title: Aspose.Slides for C++ को Docker में कैसे चलाएँ
type: docs
weight: 140
url: /hi/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- Aspose.Slides डाउनलोड करें
- Aspose.Slides स्थापित करें
- Aspose.Slides स्थापना
- Docker
- Windows
- macOS
- Linux
- क्रॉस-प्लेटफ़ॉर्म संगतता
- निर्भरताओं का पृथक्करण
- सरलित परिनियोजन
- प्रोजेक्ट सेटअप
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Docker कंटेनरों में Aspose.Slides चलाएँ: छवियों, निर्भरताओं, फ़ॉन्ट्स और लाइसेंसिंग को कॉन्फ़िगर करके PowerPoint और OpenDocument को प्रोसेस करने वाली स्केलेबल सेवाएँ बनाएं।"
---
## **परिचय**

Aspose.Slides for C++ डॉकर कंटेनरों के अंदर चल सकता है। Linux वातावरण में Aspose.Slides for C++ चलाने के लिए, आप एक डॉकर फ़ाइल का उपयोग कर सकते हैं। 

## **Dockerfile विवरण**

उदाहरण के लिए, आप Ubuntu 16.04 के साथ Aspose.Slides for C++ के लिए यह डॉकर फ़ाइल उपयोग कर सकते हैं: 

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

फ़ाइल में तीन मुख्य भाग (प्रक्रियाएँ) होते हैं:

1. Aspose.Slides for C++ चलाने के लिए आवश्यक टूल्स की स्थापना:

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

2. msttcorefonts पैकेज की स्थापना (डिफ़ॉल्ट रूप से, msttcorefonts पैकेज की EULA स्वीकार नहीं की गई है):

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. होस्ट मशीन पर slides‑cpp स्रोत फ़ोल्डर तक पहुंच प्रदान करने के लिए /slides-cpp फ़ोल्डर को माउंट पॉइंट के रूप में घोषित करना; उदाहरणों का निर्माण और चलाना:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **इमेज बनाना और चलाना**

1. [Docker स्थापित करें](https://docs.docker.com/engine/install/) होस्ट सिस्टम पर।

2. इमेज बनाएं।  

   टर्मिनल की कार्यशील डायरेक्टरी में ऊपर दिया गया सामग्री वाला Dockerfile फ़ाइल होना चाहिए। 

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/hi/cpp) डाउनलोड करें और अनज़िप करें।

4. Docker को उपयोग करने के लिए Aspose.Slides for C++ के साथ फ़ोल्डर साझा करें:  
   - Windows में, टास्कबार पर Docker आइकन पर राइट‑क्लिक करें। Settings चुनें।  
   - Resources > File Sharing पर जाएँ।  

5. इमेज को कंटेनर के रूप में चलाने के लिए इन विधियों में से किसी एक का उपयोग करें:

* विधि A: एक नामित कंटेनर बनाएं और निष्पादित करें:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

दूसरे और बाद के लॉन्च के लिए, आपको उपयोग करना होगा:

```
docker start slides-cpp-ubuntu -i
```

* विधि B: एक अनाम अस्थायी कंटेनर बनाएं और निष्पादित करें:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

आप नमूना प्रोजेक्ट के निर्माण और निष्पादन को देखेंगे:

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