---
title: 시스템 요구 사항
type: docs
weight: 80
url: /ko/cpp/system-requirements/
keywords:
- 시스템 요구 사항
- 운영 체제
- 설치
- 종속성
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 시스템 요구 사항을 확인하십시오. Windows, Linux 및 macOS에서 원활한 PowerPoint 및 OpenDocument 지원을 보장합니다."
---
## **소개**

Aspose.Slides는 Microsoft PowerPoint가 설치되어 있을 필요가 없습니다. Aspose.Slides는 독립적인 Microsoft PowerPoint 문서 생성, 변환, 페이지 레이아웃 및 렌더링 엔진이기 때문입니다.

## **지원 운영 체제**
Aspose.Slides for C++는 네이티브 C++ 라이브러리입니다. Aspose.Slides for C++는 다음 64비트 및 32비트 운영 체제와 플랫폼을 지원합니다:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- OS Ubuntu 16.04 이상.
- CentOS 8 이상.
- Fedora 24 이상.
- 그 외 glibc 2.23 이상을 지원하는 Linux x86_64.

### **macOS**
- macOS Monterey 12.1 이상.

## **개발 환경**
Windows, Linux 또는 macOS용 애플리케이션을 개발할 때 Aspose.Slides for C++를 사용할 수 있습니다.

### **Windows**
- Microsoft Visual Studio 2017 이상.
- CMake 3.18 이상.

### **Linux**
- Clang 3.9 이상.
- GCC 6.1 이상.
- CMake 3.18 이상.

### **macOS**
- Xcode 13.4 이상.

## **FAQ**

**변환 및 렌더링을 위해 Microsoft PowerPoint를 설치해야 합니까?**

아니요, PowerPoint는 필요하지 않습니다. Aspose.Slides는 프레젠테이션을 [생성](/slides/ko/cpp/create-presentation/), 수정, [변환](/slides/ko/cpp/convert-presentation/), 그리고 [렌더링](/slides/ko/cpp/convert-powerpoint-to-png/)하기 위한 독립 실행형 엔진입니다.

**올바른 렌더링을 위해 어떤 글꼴이 필요합니까?**

실제로 프레젠테이션에 사용된 글꼴이나 적절한 [대체 글꼴](/slides/ko/cpp/font-substitution/)이 시스템에 존재해야 합니다. Linux/macOS에서 일관된 렌더링을 보장하려면 일반적인 글꼴 패키지를 설치하는 것이 좋습니다.

**Linux에서 사용자 정의 글꼴이 대체 글꼴이나 누락된 텍스트로 표시되는 이유는 무엇입니까?**

글꼴 파일에 일관성이 없거나 손상된 name-table 항목이 있으면 Linux 글꼴 매칭 스택(FreeType/fontconfig)이 잘못된 레코드를 선택해 해당 글꼴을 찾지 못할 수 있습니다. name-table 레코드가 수정된 글꼴 버전을 사용하거나 일관된 대체 글꼴을 설치하면 이 문제가 해결됩니다.