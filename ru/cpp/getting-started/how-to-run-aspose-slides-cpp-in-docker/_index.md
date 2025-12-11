---
title: Как запустить Aspose.Slides для C++ в Docker
type: docs
weight: 140
url: /ru/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- скачать Aspose.Slides
- установить Aspose.Slides
- установка Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- кроссплатформенная совместимость
- изоляция зависимостей
- упрощённое развертывание
- настройка проекта
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Запустите Aspose.Slides в контейнерах Docker: настройте образы, зависимости, шрифты и лицензирование для создания масштабируемых сервисов, обрабатывающих PowerPoint и OpenDocument."
---

Aspose.Slides for C++ может работать внутри контейнеров Docker. Чтобы запустить Aspose.Slides for C++ в среде Linux, можно использовать файл Docker.

## **Описание Dockerfile**

Например, вы можете использовать этот файл Docker для Aspose.Slides for C++ с Ubuntu 16.04: 
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


Файл содержит три основные части (процедуры):

1. Установка инструментов, необходимых для запуска Aspose.Slides for C++: 
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


2. Установка пакета msttcorefonts (по умолчанию EULA пакета msttcorefonts не принята): 
```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```


3. Объявление папки /slides-cpp точкой монтирования для предоставления доступа к папке sources slides-cpp на хост‑машине; Сборка и запуск примеров: 
``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```


## **Сборка и запуск образа**

1. [Установите Docker](https://docs.docker.com/engine/install/) на хост‑системе.

2. Соберите образ. 

   Текущий рабочий каталог терминала должен содержать файл Dockerfile с содержимым, приведённым выше. 
```
docker build -t aspose-slides-ubuntu-16.04 .
```


3. Скачайте и распакуйте [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/cpp).

4. Поделитесь папкой с Aspose.Slides for C++ чтобы Docker мог её использовать: 
   - В Windows щёлкните правой кнопкой мыши значок Docker на панели задач. Выберите Settings.
   - Перейдите в Resources > File Sharing. 

5. Запустите образ как контейнер, воспользовавшись одним из следующих методов:

* Метод A: создать и выполнить именованный контейнер: 
```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```


Для второго и последующих запусков необходимо использовать: 
```
docker start slides-cpp-ubuntu -i
```


* Метод B: создать и выполнить безимянный временный контейнер: 
```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```


Вы увидите сборку и исполнение образца проекта: 
``` 
-- Идентификация компилятора CXX: Clang 3.9.1
-- Проверка работоспособности компилятора CXX: /usr/bin/clang++
-- Проверка работоспособности компилятора CXX: /usr/bin/clang++ -- работает
-- Определение информации ABI компилятора CXX
-- Определение информации ABI компилятора CXX - выполнено
-- Определение возможностей компиляции CXX
-- Определение возможностей компиляции CXX - выполнено
-- Конфигурирование завершено
-- Генерация завершена
-- Файлы сборки записаны в: /slides-cpp/sample/build
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
