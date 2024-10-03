---
title: Как запустить Aspose.Slides для C++ в Docker
type: docs
weight: 140
url: /ru/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords: "Запуск Aspose.Slides для C++ в контейнере Docker, Aspose Docker, Aspose.Slides для C++ в Docker"
description: "Запустите Aspose.Slides для C++ в контейнере Docker для Linux."
---

Aspose.Slides для C++ может работать внутри контейнеров Docker. Для запуска Aspose.Slides для C++ в среде Linux вы можете использовать файл Docker.

## Описание Dockerfile

Например, вы можете использовать этот файл Docker для Aspose.Slides для C++ с Ubuntu 16.04:

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

1. Установка инструментов, необходимых для запуска Aspose.Slides для C++:

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

3. Объявление папки /slides-cpp как точки монтирования для доступа к источникам slides-cpp на хостовой машине; сборка и запуск примеров:

```cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## Сборка и запуск образа

1. [Установите Docker](https://docs.docker.com/engine/install/) на хостовую систему.

2. Соберите образ.

   Рабочий каталог терминала должен содержать файл Dockerfile с вышеуказанным содержимым.

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Загрузите и разархивируйте [Aspose.Slides для C++ YY.M Linux](https://downloads.aspose.com/slides/cpp).
4. Поделитесь папкой с Aspose.Slides для C++, чтобы разрешить использование Docker:
   - В Windows щелкните правой кнопкой мыши на значке Docker на панели задач. Выберите Настройки.
   - Перейдите в Разделы > Обмен файлами.
5. Запустите образ как контейнер одним из этих методов:

* Метод A: создайте и выполните именованный контейнер:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Для второго и последующих запусков вам нужно использовать:

```
docker start slides-cpp-ubuntu -i
```

* Метод B: создайте и выполните безымянный временный контейнер:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Вы увидите сборку и выполнение примерного проекта:

```
-- Идентификатор компилятора CXX Clang 3.9.1
-- Проверка работоспособности компилятора CXX: /usr/bin/clang++
-- Проверка работоспособности компилятора CXX: /usr/bin/clang++ -- работает
-- Определение информации о ABI компилятора CXX
-- Определение информации о ABI компилятора CXX - завершено
-- Определение особенностей компиляции CXX
-- Определение особенностей компиляции CXX - завершено
-- Конфигурация завершена
-- Генерация завершена
-- Файлы сборки записаны в: /slides-cpp/sample/build
Сканирование зависимостей цели Aspose.Slides.Cpp.Examples
[ 14%] Сборка CXX объекта CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/chart.cpp.o
[ 42%] Сборка CXX объекта CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/main.cpp.o
[ 42%] Сборка CXX объекта CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/presentation_export.cpp.o
[ 57%] Сборка CXX объекта CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/smart_art.cpp.o
[ 71%] Сборка CXX объекта CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/text.cpp.o
[ 85%] Сборка CXX объекта CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/thumbnail.cpp.o
[100%] Линковка исполняемого файла CXX Aspose.Slides.Cpp.Examples
[100%] Цель Aspose.Slides.Cpp.Examples собрана

Запуск примеров...

Запуск Chart::SampleChart...
Запуск Thumbnail::SampleThumbnail...
Запуск Text::SampleAddText...
Запуск SmartArt::SampleCreation...
Запуск SmartArt::SampleCloning...
Запуск SmartArt::SampleNodesTextEditing...
Запуск SmartArt::SampleNodeAdd...
Запуск SmartArt::SampleColorStyleEditing...
Запуск SmartArt::SampleQuickStyleEditing...
Запуск SmartArt::SampleNodeRemove...
Запуск SmartArt::SampleRemoveSmartArt...
Запуск PresentationExport::Export...
Сохранение презентации в PDF...ОК
Сохранение презентации в XPS...ОК
Сохранение презентации в SWF...ОК
Сохранение презентации в HTML...ОК
Сохранение презентации в PDF...ОК
Сохранение презентации в XPS...ОК
Сохранение презентации в SWF...ОК
Сохранение презентации в HTML...ОК
```