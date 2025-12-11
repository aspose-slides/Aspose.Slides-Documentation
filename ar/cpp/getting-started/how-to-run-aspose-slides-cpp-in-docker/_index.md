---
title: كيفية تشغيل Aspose.Slides لـ C++ في Docker
type: docs
weight: 140
url: /ar/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- تنزيل Aspose.Slides
- تثبيت Aspose.Slides
- تثبيت Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- التوافق عبر الأنظمة
- عزل الاعتمادات
- نشر مبسط
- إعداد المشروع
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تشغيل Aspose.Slides في حاويات Docker: تكوين الصور، والاعتمادات، والخطوط، والترخيص لبناء خدمات قابلة للتوسعة تعالج PowerPoint و OpenDocument."
---

يمكن تشغيل Aspose.Slides for C++ داخل حاويات Docker. لتشغيل Aspose.Slides for C++ في بيئة لينكس، يمكنك استخدام ملف Docker. 

## **وصف Dockerfile**

على سبيل المثال، يمكنك استخدام هذا ملف Docker لـ Aspose.Slides for C++ مع Ubuntu 16.04: 
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

1. تثبيت الأدوات المطلوبة لتشغيل Aspose.Slides for C++:
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


2. تثبيت حزمة msttcorefonts (بشكل افتراضي، اتفاقية ترخيص المستخدم النهائي لحزمة msttcorefonts غير مقبولة):
```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```


3. إعلان مجلد /slides-cpp كنقطة تركيب لتوفير الوصول إلى مجلد مصادر slides-cpp على الجهاز المضيف؛ بناء وتشغيل الأمثلة:
``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```


## **بناء وتشغيل صورة**

1. [تثبيت Docker](https://docs.docker.com/engine/install/) على نظام المضيف.

2. بناء صورة. 

   يجب أن يحتوي دليل العمل في الطرفية على ملف Dockerfile بالمحتوى أعلاه. 
```
docker build -t aspose-slides-ubuntu-16.04 .
```


3. تحميل وفك ضغط [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/cpp).
4. مشاركة المجلد مع Aspose.Slides for C++ للسماح لـ Docker باستخدامه: 
   - في Windows، انقر بزر الماوس الأيمن على أيقونة Docker في شريط المهام. اختر الإعدادات.
   - انتقل إلى الموارد > مشاركة الملفات. 
5. تشغيل الصورة كحاوية عبر إحدى الطرق التالية:

* طريقة A: إنشاء وتنفيذ حاوية مسماة:
```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```


للإطلاقات الثانية وما بعدها، عليك استخدام:
```
docker start slides-cpp-ubuntu -i
```


* طريقة B: إنشاء وتنفيذ حاوية مؤقتة غير مسماة:
```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```


سترى بناء وتنفيذ مشروع العينة:
``` 
-- تعريف مترجم CXX هو Clang 3.9.1
-- التحقق من عمل مترجم CXX: /usr/bin/clang++
-- التحقق من عمل مترجم CXX: /usr/bin/clang++ -- يعمل
-- اكتشاف معلومات ABI لمترجم CXX
-- اكتشاف معلومات ABI لمترجم CXX - تم
-- اكتشاف ميزات تجميع CXX
-- اكتشاف ميزات تجميع CXX - تم
-- تم التكوين
-- تم الإنشاء
-- تم كتابة ملفات البناء إلى: /slides-cpp/sample/build
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
