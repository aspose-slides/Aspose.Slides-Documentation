---
title: كيفية تشغيل Aspose.Slides لـ C++ في Docker
type: docs
weight: 140
url: /cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords: "تشغيل Aspose.Slides لـ C++ في حاوية Docker، Aspose Docker، Aspose.Slides لـ C++ في Docker"
description: "تشغيل Aspose.Slides لـ C++ في حاوية Docker لنظام Linux."
---

يمكن تشغيل Aspose.Slides لـ C++ داخل حاويات Docker. لتشغيل Aspose.Slides لـ C++ في بيئة Linux، يمكنك استخدام ملف Docker.

## وصف Dockerfile

على سبيل المثال، يمكنك استخدام هذا الملف لـ Aspose.Slides لـ C++ مع Ubuntu 16.04: 

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

يحتوي الملف على ثلاثة أجزاء رئيسية (إجراءات):

1. تثبيت الأدوات المطلوبة لتشغيل Aspose.Slides لـ C++:

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

2. تثبيت حزمة msttcorefonts (بشكل افتراضي، لا يتم قبول EULA لحزمة msttcorefonts):

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. إعلان مجلد /slides-cpp كنقطة تحميل لتوفير الوصول إلى مجلد مصادر slides-cpp على الجهاز المضيف؛ بناء وتشغيل الأمثلة:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## بناء وتشغيل صورة

1. [قم بتثبيت Docker](https://docs.docker.com/engine/install/) على نظام المضيف.

2. قم ببناء صورة. 

   يجب أن يحتوي دليل العمل في الطرفية على ملف Dockerfile بمحتوى أعلاه. 

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. قم بتنزيل وفك ضغط [Aspose.Slides لـ C++ YY.M Linux](https://downloads.aspose.com/slides/cpp).
4. شارك المجلد مع Aspose.Slides لـ C++ للسماح لـ Docker باستخدامه: 
   - في Windows، انقر بزر الماوس الأيمن على أيقونة Docker في شريط المهام. اختر الإعدادات.
   - انتقل إلى الموارد > مشاركة الملفات. 
5. قم بتشغيل الصورة كحاوية من خلال أي من الطرق التالية:

* الطريقة A: إنشاء وتنفيذ حاوية مسماة:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

لاستخدامه في الإطلاقات الثانية وما بعدها، يجب عليك استخدام:

```
docker start slides-cpp-ubuntu -i
```

* الطريقة B: إنشاء وتنفيذ حاوية مؤقتة بدون اسم:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

سوف ترى بناء وتنفيذ مشروع العينة:

```
-- هوية مترجم CXX هي Clang 3.9.1
-- تحقق من عمل مترجم CXX: /usr/bin/clang++
-- تحقق من عمل مترجم CXX: /usr/bin/clang++ -- يعمل
-- اكتشاف معلومات ABI لمترجم CXX
-- اكتشاف معلومات ABI لمترجم CXX - تم
-- اكتشاف ميزات تجميع CXX
-- اكتشاف ميزات تجميع CXX - تم
-- الانتهاء من التكوين
-- الانتهاء من التوليد
-- تم كتابة ملفات البناء إلى: /slides-cpp/sample/build
تفحص التبعيات من الهدف Aspose.Slides.Cpp.Examples
[ 14%] بناء كائن CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/chart.cpp.o
[ 42%] بناء كائن CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/main.cpp.o
[ 42%] بناء كائن CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/presentation_export.cpp.o
[ 57%] بناء كائن CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/smart_art.cpp.o
[ 71%] بناء كائن CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/text.cpp.o
[ 85%] بناء كائن CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/thumbnail.cpp.o
[100%] ربط التنفيذ CXX Aspose.Slides.Cpp.Examples
[100%] تم بناء الهدف Aspose.Slides.Cpp.Examples

تشغيل الأمثلة...

تشغيل Chart::SampleChart...
تشغيل Thumbnail::SampleThumbnail...
تشغيل Text::SampleAddText...
تشغيل SmartArt::SampleCreation...
تشغيل SmartArt::SampleCloning...
تشغيل SmartArt::SampleNodesTextEditing...
تشغيل SmartArt::SampleNodeAdd...
تشغيل SmartArt::SampleColorStyleEditing...
تشغيل SmartArt::SampleQuickStyleEditing...
تشغيل SmartArt::SampleNodeRemove...
تشغيل SmartArt::SampleRemoveSmartArt...
تشغيل PresentationExport::Export...
حفظ العرض التقديمي كملف PDF...تم
حفظ العرض التقديمي كملف XPS...تم
حفظ العرض التقديمي كملف SWF...تم
حفظ العرض التقديمي كملف HTML...تم
حفظ العرض التقديمي كملف PDF...تم
حفظ العرض التقديمي كملف XPS...تم
حفظ العرض التقديمي كملف SWF...تم
حفظ العرض التقديمي كملف HTML...تم
```