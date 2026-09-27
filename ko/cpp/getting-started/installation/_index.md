---
title: 설치
type: docs
weight: 70
url: /ko/cpp/installation/
keywords:
- Aspose.Slides 설치
- Aspose.Slides 다운로드
- Aspose.Slides 사용
- Aspose.Slides 설치
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Windows에서는 Visual Studio에서 NuGet을 사용하여 C++용 Aspose.Slides를 설치하고, Linux에서는 ZIP 패키지를 CMake와 함께 사용하여 설치하며, 첫 번째 프로그램으로 설치를 확인합니다."
---
## **개요**

Aspose.Slides for C++ 은 두 가지 형태로 제공됩니다:

| 형태 | 사용 대상 | 구입 위치 |
|---|---|---|
| NuGet 패키지: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64-bit) 및 [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32-bit) | Windows 용 Visual Studio C++ 프로젝트 | NuGet |
| Windows, Linux, macOS 용 ZIP 패키지 | NuGet 없이 빌드하는 경우(예: CMake 프로젝트) | [다운로드 페이지](https://releases.aspose.com/slides/cpp/) |

이 문서에서는 Windows 에서 Visual Studio 로 NuGet 패키지를 설치하는 방법과 Linux 에서 CMake 로 ZIP 패키지를 사용하는 방법을 보여줍니다. 두 경로 모두 동일한 확인 절차로 끝납니다: [프레젠테이션 만들기](/slides/ko/cpp/create-presentation/) 에 있는 첫 번째 예제를 빌드하고 실행합니다.

## **Windows**

Windows 에서는 NuGet 패키지를 Visual Studio C++ 프로젝트에 추가합니다. 이 패키지는 종속성인 CodePorting.Translator.Cs2Cpp.Framework 를 설치하고, 프로그램이 필요로 하는 DLL을 빌드 출력 폴더에 복사합니다.

빌드하려는 플랫폼에 맞는 패키지를 선택합니다: x64 용은 **Aspose.Slides.Cpp**, Win32(x86) 용은 **Aspose.Slides.Cpp.x86**. Aspose.Slides.Cpp 패키지는 Win32 빌드에 적용되지 않으므로 해당 환경에서는 헤더를 찾을 수 없습니다.

Windows 용 ZIP 패키지는 [다운로드 페이지](https://releases.aspose.com/slides/cpp/)에서도 제공됩니다.

### **방법 1: NuGet 패키지 관리자에서 Aspose.Slides 설치 또는 업데이트**

1. Microsoft Visual Studio 를 엽니다.  
2. C++ **콘솔 앱** 프로젝트를 만들거나 기존 프로젝트를 엽니다.  
3. **Solution Explorer** 에서 프로젝트를 마우스 오른쪽 버튼으로 클릭하고 **Manage NuGet Packages** 를 선택합니다(또는 **Project** > **Manage NuGet Packages** 로 이동).  
4. **Browse** 탭에서 *Aspose.Slides.Cpp* 를 검색합니다.  
![NuGet 패키지 관리자에서 Aspose.Slides.Cpp 검색하기](installation_1.png)  
5. **Aspose.Slides.Cpp**(또는 32비트 빌드인 경우 **Aspose.Slides.Cpp.x86**) 를 클릭한 다음 **Install** 를 클릭합니다.  
   * 이미 Aspose.Slides 를 설치했고 업데이트하려면 **Update** 를 클릭합니다.

패키지가 다운로드되고 프로젝트에 참조됩니다.

### **방법 2: 패키지 관리자 콘솔을 통해 Aspose.Slides 설치 또는 업데이트**

1. Microsoft Visual Studio 를 엽니다.  
2. C++ **콘솔 앱** 프로젝트를 만들거나 기존 프로젝트를 엽니다.  
3. **Tools** > **NuGet Package Manager** > **Package Manager Console** 로 이동합니다.  
![패키지 관리자 콘솔 열기](installation_2.png)  
4. 다음 명령을 실행합니다:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   32비트(Win32) 빌드인 경우 대신 x86 패키지를 설치합니다:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

![Install-Package 명령 실행하기](installation_3.png)

설치가 완료되면 확인 메시지가 표시됩니다. 패키지는 [Aspose EULA](https://about.aspose.com/legal/eula) 하에 배포됩니다.  
![설치 확인 메시지](installation_4.png)

패키지를 업데이트하려면 패키지 관리자 콘솔에서 `Update-Package Aspose.Slides.Cpp`(또는 `Update-Package Aspose.Slides.Cpp.x86`) 를 실행합니다.

### **설치 확인**

1. 프로젝트의 주요 *.cpp* 파일(`main` 이 포함된 파일) 내용을 [프레젠테이션 만들기](/slides/ko/cpp/create-presentation/) 에 있는 첫 번째 예제로 교체합니다.  
2. 툴바에서 **x64** 플랫폼을 선택하거나, Aspose.Slides.Cpp.x86 를 설치한 경우 **x86** 을 선택합니다.  
3. **Ctrl+F5** 를 눌러 프로그램을 빌드하고 실행합니다.

프로그램은 프로젝트 폴더에 *hello.pptx* 를 저장합니다. 이는 Visual Studio 가 프로그램을 실행할 때 기본 작업 디렉터리입니다.

## **Linux**

Linux 에서는 CMake 로 Linux ZIP 패키지를 사용합니다. 패키지에는 Aspose.Slides 라이브러리, 종속성 CodePorting.Translator.Cs2Cpp.Framework, 그리고 각각에 대한 CMake 구성 파일이 포함되어 있습니다. 라이브러리는 glibc 2.23 이상을 지원하는 x86_64 Linux 용으로 빌드되었습니다.

1. C++ 컴파일러, make, CMake, unzip, 그리고 Aspose.Slides 라이브러리가 의존하는 fontconfig 라이브러리를 설치합니다. Debian 및 Ubuntu 에서는 다음 명령을 사용합니다:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. 프로젝트 폴더를 만들고 해당 폴더로 이동합니다:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. [다운로드 페이지](https://releases.aspose.com/slides/cpp/)에서 Linux ZIP (**Aspose.Slides for C++ Linux**) 을 프로젝트 폴더로 다운로드하고, *aspose-slides-cpp* 하위 폴더에 압축을 풉니다:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. 프로젝트 폴더에 다음 내용을 가진 *CMakeLists.txt* 파일을 생성합니다:

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

   두 개의 `find_package` 호출은 압축 해제된 패키지에 있는 CMake 구성 파일을 로드합니다. Aspose.Slides 가 프레임워크에 의존하므로 프레임워크가 먼저 발견됩니다. `Aspose.Slides.Cpp` 타깃을 링크하면 포함 폴더와 두 라이브러리가 빌드에 추가됩니다.

5. [프레젠테이션 만들기](/slides/ko/cpp/create-presentation/) 에 있는 첫 번째 예제를 *main.cpp* 로 저장하고 프로젝트 폴더에 둡니다.  
6. 프로그램을 빌드하고 실행합니다:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

프로그램은 현재 폴더에 *hello.pptx* 를 저장합니다. CMake 는 라이브러리 위치를 프로그램에 기록하므로 *aspose-slides-cpp* 폴더가 제자리에 있는 한 `LD_LIBRARY_PATH` 를 설정할 필요가 없습니다.

프레젠테이션에 사용된 글꼴 또는 적절한 대체 글꼴은 시스템에 설치되어 있어야 합니다. 그렇지 않으면 PDF 또는 이미지로 변환할 때 텍스트가 올바르게 렌더링되지 않을 수 있습니다.

## **FAQ**

**무료 버전이나 평가 제한이 있나요?**

예. 라이선스가 없으면 Aspose.Slides 가 평가 모드로 실행되어 저장되는 모든 슬라이드에 평가 워터마크가 추가되고 프레젠테이션에서 읽은 텍스트가 잘립니다. 이 제한을 해제하려면 유효한 [라이선스](/slides/ko/cpp/licensing/) 를 적용하십시오.

**컴파일러가 *DOM/Presentation.h* 를 열 수 없다고 보고하는 이유는?**

설치한 패키지가 현재 빌드 플랫폼과 일치하지 않기 때문입니다. Aspose.Slides.Cpp 는 x64 빌드에만 적용되고, Aspose.Slides.Cpp.x86 는 Win32 빌드에만 적용됩니다. Visual Studio 에서 일치하는 플랫폼을 선택하거나 다른 패키지를 설치하십시오.