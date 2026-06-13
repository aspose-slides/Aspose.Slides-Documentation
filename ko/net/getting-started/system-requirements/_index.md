---
title: 시스템 요구 사항
type: docs
weight: 60
url: /ko/net/system-requirements/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 시스템 요구 사항을 확인하십시오. Windows, Linux 및 macOS에서 원활한 PowerPoint 및 OpenDocument 지원을 보장합니다."
---
## **소개**

Aspose.Slides for .NET은 Microsoft PowerPoint를 설치할 필요가 없습니다. Aspose.Slides는 독립적인 Microsoft PowerPoint 문서 생성, 변환, 페이지 레이아웃 및 렌더링 엔진이기 때문입니다.

## **지원되는 운영 체제**

Aspose.Slides for .NET은 .NET 또는 Mono 프레임워크가 설치된 모든 32비트 또는 64비트 운영 체제를 지원합니다(단, 이에 국한되지 않음).

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine 등)

### **Mac**

- Mac OS X

## **지원되는 프레임워크**

Aspose.Slides for .NET은 .NET 및 Mono 프레임워크를 지원합니다:

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **Mono Framework**

- MAC 및 Linux 플랫폼에서 MONO 지원

## **개발 환경**

Aspose.Slides for .NET은 .NET 플랫폼을 타깃으로 하는 모든 개발 환경에서 애플리케이션을 개발하는 데 사용할 수 있지만, 다음 환경은 명시적으로 지원됩니다:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides 주요 빌드**

현재 Aspose.Slides에는 두 가지 주요 빌드가 있습니다 — Aspose.Slides.NET 및 Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

이 제품의 기본 버전입니다. 표준 .NET 그래픽 엔진을 사용합니다.
- 비 Windows 플랫폼에서는 `libgdiplus` 라이브러리와 해당 종속성을 설치해야 할 수 있습니다.
- Aspose.Slides 25.3 버전 이전에는 비 Windows 플랫폼에서 Aspose.Slides ZIP 패키지의 .NET Standard 2.0 DLL을 사용해야 했습니다.
- Aspose.Slides 25.3 버전부터는 NuGet 패키지를 비 Windows 시스템에서도 직접 사용할 수 있습니다.
- 비 Windows 시스템에서 실행할 경우, 시작 시 다음 줄을 포함해야 합니다:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **버전 25.3부터 .NET을 지원하는 플랫폼(Linux aarch64(ARM64) 등)에서 이 패키지를 사용할 수 있습니다.**

#### **Linux Alpine용 추가 패키지**

Alpine Linux 컨테이너에서 Aspose.Slides for .NET을 실행할 경우, `libgdiplus`만 설치해도 충분하지 않을 수 있습니다. Alpine 컨테이너는 기본적으로 폰트를 포함하지 않습니다. 폰트가 없으면 렌더링 또는 변환 작업이 다음과 유사한 오류로 실패할 수 있습니다:
```text
System.ArgumentException: Font '?' cannot be found
```
Alpine에서 Aspose.Slides를 사용하려면 `libgdiplus`와 함께 최소 하나의 폰트 패키지를 설치하세요.

**옵션 1: DejaVu 폰트**

권장 옵션은 `ttf-dejavu` 패키지를 설치하는 것입니다:
```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` 패키지는 `fontconfig`, `encodings`, `mkfontscale`, `mkfontdir` 등 필요한 폰트 관련 의존성을 자동으로 설치합니다. 대부분의 사용 사례에서 추가 폰트 패키지는 필요하지 않습니다.

**옵션 2: Microsoft Core Fonts**

프레젠테이션에 Arial, Times New Roman, Courier New 또는 Verdana와 같은 Microsoft 전용 폰트가 사용되는 경우 대신 Microsoft Core Fonts를 설치하세요:
```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

프레젠테이션에 Microsoft 폰트가 필요한 경우에만 이 옵션을 사용하십시오. 대부분의 시나리오에서는 `ttf-dejavu`를 설치하는 것이 더 간단하고 안정적입니다.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Aspose.Slides 팀이 개발한 커스텀 크로스플랫폼 그래픽 엔진을 사용하는 버전입니다.  
비 Windows 플랫폼에서는 `fontconfig` 라이브러리가 필요할 수 있습니다.

**지원되는 플랫폼**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**지원되지 않는 플랫폼**
- *Windows 11 ARM* (ARM64) — *현재 고려 중이 아닙니다*

{{%  alert  title="Notes"  color="primary"  %}}  
Linux x64에서는 GLIBC 2.23 이상이 필요하고, Linux ARM64에서는 GLIBC 2.39 이상이 필요합니다. CentOS 7(GLIBC 2.14)과 같은 시스템은 지원되지 않습니다. CentOS 7 또는 Alpine과 같이 호환되지 않는 시스템에서 Aspose.Slides를 실행해야 하는 경우, 표준 패키지인 [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET)를 사용하십시오.  
{{% /alert %}}

## **자주 묻는 질문**

**변환 및 렌더링을 위해 Microsoft PowerPoint를 설치해야 합니까?**

아니요, PowerPoint는 필요하지 않습니다; Aspose.Slides는 프레젠테이션을 [생성](/slides/ko/net/create-presentation/), 수정, [변환](/slides/ko/net/convert-presentation/), 및 [렌더링](/slides/ko/net/convert-powerpoint-to-png/) 할 수 있는 독립 실행형 엔진입니다.

**올바른 렌더링을 위해 어떤 폰트가 필요합니까?**

프레젠테이션에 사용된 폰트 또는 적절한 대체 폰트가 운영 체제에 존재해야 합니다. Linux와 macOS에서는 일관된 렌더링을 보장하기 위해 일반적인 폰트 패키지를 설치하십시오.

Alpine Linux 컨테이너의 경우 `libgdiplus` 외에 최소 하나의 폰트 패키지를 설치해야 합니다. 권장 최소 구성은 `libgdiplus`와 `ttf-dejavu`입니다. Arial, Times New Roman, Courier New, Verdana와 같은 Microsoft 폰트가 필요한 경우 `fontconfig`와 함께 `msttcorefonts-installer`를 사용하십시오.

**Linux에서 커스텀 폰트가 대체 폰트나 누락된 텍스트로 표시되는 이유는 무엇입니까?**

폰트 파일에 이름 테이블 엔트리가 일관되지 않거나 손상된 경우, Linux의 폰트 매칭 스택(FreeType/fontconfig)이 잘못된 레코드를 선택하여 폰트를 찾지 못할 수 있습니다. 이름 테이블이 수정된 폰트 버전을 사용하거나 일관된 대체 폰트를 설치하면 문제가 해결됩니다.