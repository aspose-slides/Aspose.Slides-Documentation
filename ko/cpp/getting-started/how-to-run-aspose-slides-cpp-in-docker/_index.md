---
title: Docker에서 Aspose.Slides for C++ 실행 방법
type: docs
weight: 140
url: /ko/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- Aspose.Slides 설치
- Docker
- Windows
- macOS
- Linux
- 크로스 플랫폼 호환성
- 의존성 격리
- 간소화된 배포
- 프로젝트 설정
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Docker 컨테이너에서 Aspose.Slides를 실행: 이미지, 의존성, 폰트 및 라이선스를 구성하여 PowerPoint와 OpenDocument를 처리하는 확장 가능한 서비스를 구축합니다."
---
## **소개**

Aspose.Slides for C++는 Docker 컨테이너 내에서 실행할 수 있습니다. Linux 환경에서 Aspose.Slides for C++를 실행하려면 Docker 파일을 사용할 수 있습니다.

## **Dockerfile 설명**

예를 들어 Ubuntu 16.04와 함께 Aspose.Slides for C++에 이 Docker 파일을 사용할 수 있습니다:

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

파일은 세 가지 주요 부분(절차)으로 구성됩니다:

1. Aspose.Slides for C++ 실행에 필요한 도구 설치:

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

2. msttcorefonts 패키지 설치 (기본적으로 msttcorefonts 패키지 EULA가 수락되지 않음):

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. /slides-cpp 폴더를 마운트 지점으로 선언하여 호스트 머신의 slides-cpp 소스 폴더에 접근할 수 있도록 함; 예제 빌드 및 실행:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **이미지 빌드 및 실행**

1. [Install Docker](https://docs.docker.com/engine/install/)를 호스트 시스템에 설치합니다.

2. 이미지를 빌드합니다.

   터미널 작업 디렉터리에 위 내용이 포함된 Dockerfile 파일이 있어야 합니다.

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/ko/cpp)를 다운로드하고 압축을 풉니다.
4. Docker가 사용할 수 있도록 Aspose.Slides for C++ 폴더를 공유합니다:
   - Windows에서는 작업 표시줄의 Docker 아이콘을 오른쪽 클릭하고 Settings를 선택합니다.
   - Resources > File Sharing을 차례대로 진행합니다.
5. 다음 방법 중 하나로 이미지를 컨테이너로 실행합니다:

* Method A: 이름이 지정된 컨테이너를 생성하고 실행:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

두 번째 및 이후 실행에서는 다음을 사용해야 합니다:

```
docker start slides-cpp-ubuntu -i
```

* Method B: 이름이 없는 임시 컨테이너를 생성하고 실행:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

샘플 프로젝트의 빌드 및 실행이 표시됩니다:

```
-- CXX 컴파일러 식별은 Clang 3.9.1입니다
-- 작동하는 CXX 컴파일러 확인: /usr/bin/clang++
-- 작동하는 CXX 컴파일러 확인: /usr/bin/clang++ -- 작동
-- CXX 컴파일러 ABI 정보 감지 중
-- CXX 컴파일러 ABI 정보 감지 - 완료
-- CXX 컴파일 기능 감지 중
-- CXX 컴파일 기능 감지 - 완료
-- 구성 완료
-- 생성 완료
-- 빌드 파일이 다음 위치에 작성되었습니다: /slides-cpp/sample/build
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