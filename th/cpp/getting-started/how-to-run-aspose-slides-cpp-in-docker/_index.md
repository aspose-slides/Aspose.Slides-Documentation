---
title: วิธีการรัน Aspose.Slides for C++ ใน Docker
type: docs
weight: 140
url: /th/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- ดาวน์โหลด Aspose.Slides
- ติดตั้ง Aspose.Slides
- การติดตั้ง Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- ความเข้ากันได้ข้ามแพลตฟอร์ม
- การแยกการพึ่งพา
- การปรับใช้ที่ง่ายขึ้น
- การตั้งค่าโครงการ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียกใช้ Aspose.Slides ในคอนเทนเนอร์ Docker: กำหนดค่าภาพ, การพึ่งพา, ฟอนต์, และลิขสิทธิ์ เพื่อสร้างบริการที่สามารถขยายได้และประมวลผลไฟล์ PowerPoint และ OpenDocument."
---
## **บทนำ**

Aspose.Slides for C++ สามารถทำงานภายในคอนเทนเนอร์ Docker ได้ หากต้องการรัน Aspose.Slides for C++ ในสภาพแวดล้อม Linux คุณสามารถใช้ไฟล์ Docker ได้  

## **คำอธิบาย Dockerfile**

ตัวอย่างเช่น คุณสามารถใช้ไฟล์ Docker นี้สำหรับ Aspose.Slides for C++ กับ Ubuntu 16.04:  

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

ไฟล์นี้ประกอบด้วยสามส่วนหลัก (ขั้นตอน):

1. ติดตั้งเครื่องมือที่จำเป็นสำหรับรัน Aspose.Slides for C++:  

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

2. ติดตั้งแพ็กเกจ msttcorefonts (โดยค่าเริ่มต้น ข้อตกลงการใช้ msttcorefonts ยังไม่ได้รับการยอมรับ):  

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. กำหนดโฟลเดอร์ /slides-cpp เป็นจุดเมาท์เพื่อให้เข้าถึงโฟลเดอร์ซอร์สของ slides-cpp บนเครื่องโฮสต์; สร้างและรันตัวอย่าง:  

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **การสร้างและรันอิมเมจ**

1. [ติดตั้ง Docker](https://docs.docker.com/engine/install/) บนระบบโฮสต์.

2. สร้างอิมเมจ.  

   ไดเร็กทอรีทำงานของเทอร์มินัลควรมีไฟล์ Dockerfile ที่มีเนื้อหาข้างต้น.  

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. ดาวน์โหลดและแตกไฟล์ [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/th/cpp).

4. แชร์โฟลเดอร์กับ Aspose.Slides for C++ เพื่อให้ Docker ใช้งานได้:  
   - ใน Windows ให้คลิกขวาที่ไอคอน Docker บนแถบงานของคุณ แล้วเลือก Settings.  
   - ไปที่ Resources > File Sharing.  

5. รันอิมเมจเป็นคอนเทนเนอร์โดยใช้วิธีใดวิธีหนึ่งต่อไปนี้:

* วิธี A: สร้างและเรียกใช้คอนเทนเนอร์ที่มีชื่อ:  

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

สำหรับการเปิดครั้งที่สองและต่อเนื่อง คุณต้องใช้:  

```
docker start slides-cpp-ubuntu -i
```

* วิธี B: สร้างและเรียกใช้คอนเทนเนอร์ชั่วคราวที่ไม่มีชื่อ:  

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

คุณจะเห็นการสร้างและการดำเนินงานของโครงการตัวอย่าง:  

```
-- ตัวระบุคอมไพเลอร์ CXX คือ Clang 3.9.1
-- ตรวจสอบคอมไพเลอร์ CXX ที่ทำงานได้: /usr/bin/clang++
-- ตรวจสอบคอมไพเลอร์ CXX ที่ทำงานได้: /usr/bin/clang++ -- ทำงานได้
-- กำลังตรวจจับข้อมูล ABI ของคอมไพเลอร์ CXX
-- ตรวจจับข้อมูล ABI ของคอมไพเลอร์ CXX - เสร็จ
-- กำลังตรวจจับคุณลักษณะการคอมไพล์ของ CXX
-- ตรวจจับคุณลักษณะการคอมไพล์ของ CXX - เสร็จ
-- การกำหนดค่าเสร็จ
-- การสร้างเสร็จ
-- ไฟล์การสร้างได้ถูกเขียนไปยัง: /slides-cpp/sample/build
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