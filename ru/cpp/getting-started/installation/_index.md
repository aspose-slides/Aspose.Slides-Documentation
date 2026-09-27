---
title: Установка
type: docs
weight: 70
url: /ru/cpp/installation/
keywords:
- установить Aspose.Slides
- скачать Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Установите Aspose.Slides для C++ в Windows из NuGet в Visual Studio либо в Linux из ZIP‑пакета с CMake и проверьте установку с помощью первой программы."
---
## **Обзор**

Aspose.Slides for C++ распространяется в двух формах:

| Форма | Для чего использовать | Где получить |
|---|---|---|
| NuGet packages: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64-bit) and [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32-bit) | C++ проекты Visual Studio в Windows | NuGet |
| ZIP‑пакеты для Windows, Linux и macOS | Сборки без NuGet, например проекты CMake | The [страница загрузки](https://releases.aspose.com/slides/ru/cpp/) |

В этой статье показано, как установить пакет NuGet в Visual Studio на Windows и как использовать ZIP‑пакет с CMake в Linux. Оба пути завершаются одинаковой проверкой: собрать и запустить первый пример в [Создание презентаций](/slides/ru/cpp/create-presentation/).

## **Windows**

В Windows добавьте пакет NuGet в проект Visual Studio C++. Пакет также устанавливает свою зависимость CodePorting.Translator.Cs2Cpp.Framework и копирует DLL‑файлы, необходимые вашей программе, в папку вывода сборки.

Выберите пакет в зависимости от платформы сборки: **Aspose.Slides.Cpp** для x64 и **Aspose.Slides.Cpp.x86** для Win32 (x86). Пакет Aspose.Slides.Cpp не применяется к сборке Win32, поэтому компилятор не может найти его заголовочные файлы.

ZIP‑пакет для Windows также доступен на [странице загрузки](https://releases.aspose.com/slides/ru/cpp/).

### **Метод 1: Установка или обновление Aspose.Slides через менеджер пакетов NuGet**

1. Откройте Microsoft Visual Studio.  
2. Создайте проект C++ **Console App** или откройте существующий проект.  
3. В **Solution Explorer** щелкните правой кнопкой мыши проект и выберите **Manage NuGet Packages** (или перейдите в **Project** > **Manage NuGet Packages**).  
4. В разделе **Browse** выполните поиск *Aspose.Slides.Cpp*.  
![Поиск Aspose.Slides.Cpp в менеджере пакетов NuGet](installation_1.png)  
5. Нажмите **Aspose.Slides.Cpp** (или **Aspose.Slides.Cpp.x86** для 32‑разрядной сборки), а затем нажмите **Install**.  
   *Если вы уже установили Aspose.Slides и хотите обновить его, вместо этого нажмите **Update**.*  

Пакет загружается и добавляется в ваш проект.

### **Метод 2: Установка или обновление Aspose.Slides через консоль менеджера пакетов**

1. Откройте Microsoft Visual Studio.  
2. Создайте проект C++ **Console App** или откройте существующий проект.  
3. Перейдите в **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
![Открытие консоли менеджера пакетов](installation_2.png)  
4. Выполните эту команду:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   Для 32‑разрядной (Win32) сборки установите пакет x86 вместо этого:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

![Выполнение команды Install-Package](installation_3.png)

После завершения установки появляются сообщения подтверждения. Пакет распространяется в соответствии с [лицензионным соглашением Aspose](https://about.aspose.com/legal/eula).  
![Сообщения подтверждения установки](installation_4.png)

Чтобы обновить пакет, выполните `Update-Package Aspose.Slides.Cpp` (или `Update-Package Aspose.Slides.Cpp.x86`) в консоли менеджера пакетов.

### **Проверка установки**

1. Замените содержимое основного *.cpp* файла проекта (файла, содержащего `main`) первым примером из [Создание презентаций](/slides/ru/cpp/create-presentation/).  
2. На панели инструментов выберите платформу **x64** или **x86**, если вы установили Aspose.Slides.Cpp.x86.  
3. Нажмите **Ctrl+F5**, чтобы собрать и запустить программу.  

Программа сохраняет *hello.pptx* в папке проекта, которая является каталогом работы по умолчанию при запуске программы из Visual Studio.

## **Linux**

В Linux используйте ZIP‑пакет для Linux вместе с CMake. Он содержит библиотеку Aspose.Slides, её зависимость CodePorting.Translator.Cs2Cpp.Framework и файл конфигурации CMake для каждой из них. Библиотеки построены для Linux x86_64 с glibc 2.23 или новее.

1. Установите компилятор C++, make, CMake, unzip и библиотеку fontconfig, от которой зависят библиотеки Aspose.Slides. На Debian и Ubuntu:  
   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Создайте папку проекта и перейдите в неё:  
   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Скачайте Linux‑ZIP (**Aspose.Slides for C++ Linux**) со [страницы загрузки](https://releases.aspose.com/slides/ru/cpp/) в папку проекта и распакуйте его в подпапку *aspose-slides-cpp*:  
   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Создайте файл *CMakeLists.txt* в папке проекта со следующим содержимым:  
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

   Два вызова `find_package` загружают файлы конфигурации CMake из распакованного пакета. Сначала находится framework, поскольку Aspose.Slides зависит от него. Связывание цели `Aspose.Slides.Cpp` добавляет каталоги include и обе библиотеки в сборку.

5. Сохраните первый пример из [Создание презентаций](/slides/ru/cpp/create-presentation/) как *main.cpp* в папке проекта.  
6. Соберите и запустите программу:  
   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

Программа сохраняет *hello.pptx* в текущей папке. CMake записывает расположение библиотек в программу, поэтому не требуется задавать `LD_LIBRARY_PATH`, пока папка *aspose-slides-cpp* находится на месте.

Шрифты, используемые в ваших презентациях, или подходящие их заменители должны быть установлены в системе, чтобы текст корректно отображался при преобразовании слайдов в PDF или изображения.

## **FAQ**

**Существует ли бесплатная версия или ограничение пробной версии?**

Да. Без лицензии Aspose.Slides работает в режиме оценки: он добавляет водяной знак оценки на каждый сохраняемый слайд и обрезает текст, считанный из презентаций. Чтобы убрать эти ограничения, примените действительную [лицензию](/slides/ru/cpp/licensing/).

**Почему компилятор сообщает, что не может открыть *DOM/Presentation.h*?**

Установленный пакет не соответствует платформе сборки. Aspose.Slides.Cpp применяется только к сборкам x64, а Aspose.Slides.Cpp.x86 — только к сборкам Win32. Выберите соответствующую платформу в Visual Studio или установите другой пакет.