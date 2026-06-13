---
title: نحوه اجرای Aspose.Slides برای C++ در Docker
type: docs
weight: 140
url: /fa/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- دانلود Aspose.Slides
- نصب Aspose.Slides
- نصب Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- سازگاری چند پلتفرمی
- ایزولاسیون وابستگی‌ها
- استقرار ساده‌شده
- راه‌اندازی پروژه
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "اجرای Aspose.Slides در کانتینرهای Docker: پیکربندی ایمیج‌ها، وابستگی‌ها، فونت‌ها و لایسنس‌گذاری برای ساخت سرویس‌های مقیاس‌پذیر که PowerPoint و OpenDocument را پردازش می‌کنند."
---
## **مقدمه**

Aspose.Slides for C++ می‌تواند داخل کانتینرهای Docker اجرا شود. برای اجرای Aspose.Slides for C++ در محیط لینوکس، می‌توانید از یک Dockerfile استفاده کنید.

## **توضیح Dockerfile**

به عنوان مثال، می‌توانید این Dockerfile را برای Aspose.Slides for C++ با Ubuntu 16.04 استفاده کنید:

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

این فایل شامل سه بخش اصلی (روال) است:

1. نصب ابزارهای مورد نیاز برای اجرا کردن Aspose.Slides for C++:

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

2. نصب بسته msttcorefonts (به طور پیش‌فرض، توافق‌نامه EULA بسته msttcorefonts پذیرفته نشده است):

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. تعریف پوشه /slides-cpp به عنوان نقطه نصب برای دسترسی به پوشه منابع slides-cpp روی ماشین میزبان؛ ساخت و اجرای مثال‌ها:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **ساخت و اجرای یک ایمیج**

1. [Install Docker](https://docs.docker.com/engine/install/) روی سیستم میزبان.

2. ساخت یک ایمیج.

   یک دایرکتوری کاری در ترمینال باید شامل فایلی به نام Dockerfile با محتوای بالا باشد.

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. دانلود و استخراج [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/fa/cpp).

4. پوشه را با Aspose.Slides for C++ به اشتراک بگذارید تا Docker بتواند از آن استفاده کند:
   - در ویندوز، روی آیکون Docker در نوار وظیفه کلیک راست کنید. گزینه Settings را انتخاب کنید.
   - به بخش Resources > File Sharing بروید.

5. ایمیج را به عنوان یک کانتینر با استفاده از یکی از این روش‌ها اجرا کنید:

* روش A: ایجاد و اجرای یک کانتینر نام‌دار:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

برای اجراهای دوم و بعدی، باید از این دستور استفاده کنید:

```
docker start slides-cpp-ubuntu -i
```

* روش B: ایجاد و اجرای یک کانتینر موقت بدون نام:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

شما ساخت و اجرای پروژه نمونه را خواهید دید:

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