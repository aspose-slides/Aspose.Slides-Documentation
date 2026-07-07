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
description: "Aspose.Slides for .NET 시스템 요구 사항을 확인하세요. Windows, Linux 및 macOS에서 PowerPoint와 OpenDocument 지원이 원활하도록 보장합니다."
---
## **소개**

Aspose.Slides for .NET는 Microsoft PowerPoint를 설치할 필요가 없습니다. Aspose.Slides는 독립적인 Microsoft PowerPoint 문서 생성, 변환, 페이지 레이아웃 및 렌더링 엔진이기 때문입니다.

## **지원되는 운영 체제**

Aspose.Slides for .NET는 .NET 또는 Mono 프레임워크가 설치된 32비트 또는 64비트 운영 체제라면 모두 지원합니다(하지만 이에 국한되지 않음).

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine 및 기타)

### **Mac**

- Mac OS X

## **지원되는 프레임워크**

Aspose.Slides for .NET는 .NET 및 Mono 프레임워크를 지원합니다.

### **.NET 프레임워크**

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

### **Mono 프레임워크**

- MAC 및 Linux 플랫폼에서의 MONO 지원

## **개발 환경**

Aspose.Slides for .NET는 .NET 플랫폼을 대상으로 하는 모든 개발 환경에서 사용할 수 있지만, 다음 환경은 명시적으로 지원됩니다.

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

제품의 기본 버전입니다. 표준 .NET 그래픽 엔진을 사용합니다.
- 비 Windows 플랫폼에서는 `libgdiplus` 라이브러리와 그 종속성을 설치해야 할 수도 있습니다.
- Aspose.Slides 25.3 이전 버전에서는 비 Windows 플랫폼에서 Aspose.Slides ZIP 패키지에 포함된 .NET Standard 2.0 DLL을 사용해야 했습니다.
- Aspose.Slides 25.3부터는 NuGet 패키지를 비 Windows 시스템에서도 직접 사용할 수 있습니다.
- 비 Windows 시스템에서 실행할 때는 애플리케이션 시작 시 다음 라인을 포함해야 합니다:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **버전 25.3부터는 Linux aarch64 (ARM64)와 같이 .NET을 지원하는 플랫폼에서도 이 패키지를 사용할 수 있습니다.**

#### **Linux Alpine용 추가 패키지**

Alpine Linux 컨테이너에서 Aspose.Slides for .NET를 실행할 때 `libgdiplus`만 설치하면 충분하지 않을 수 있습니다. Alpine 컨테이너는 기본적으로 폰트를 포함하지 않으며, 폰트가 없으면 렌더링 또는 변환 작업이 다음과 같은 오류와 함께 실패할 수 있습니다:

```text
System.ArgumentException: Font '?' cannot be found
```
Alpine에서 Aspose.Slides를 사용하려면 `libgdiplus`와 최소 하나의 폰트 패키지를 함께 설치하십시오.

**옵션 1: DejaVu Fonts**

추천 옵션은 `ttf-dejavu` 패키지를 설치하는 것입니다:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` 패키지는 `fontconfig`, `encodings`, `mkfontscale`, `mkfontdir` 등 필요한 폰트 관련 종속성을 자동으로 설치합니다. 대부분의 사용 사례에서 추가 폰트 패키지는 필요하지 않습니다.

**옵션 2: Microsoft Core Fonts**

프레젠테이션에 Arial, Times New Roman, Courier New, Verdana와 같은 Microsoft 전용 폰트가 필요하면 대신 Microsoft Core Fonts를 설치하십시오:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

이 옵션은 프레젠테이션에 Microsoft 폰트가 반드시 필요한 경우에만 사용하십시오. 대부분의 시나리오에서는 `ttf-dejavu`를 설치하는 것이 더 간단하고 신뢰할 수 있습니다.

**글로벌화 지원을 위한 추가 요구 사항**

Alpine에서 적절한 글로벌화 지원을 활성화하려면 `icu-libs` 패키지를 설치하고 invariant 모드를 비활성화하십시오:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Aspose.Slides 팀이 자체 개발한 크로스 플랫폼 그래픽 엔진을 사용하는 버전입니다.  
비 Windows 플랫폼에서는 `fontconfig` 라이브러리가 필요할 수 있습니다.

**지원 플랫폼**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**지원되지 않는 플랫폼**
- *Windows 11 ARM* (ARM64) — *현재 고려 대상이 아님*

{{%  alert  title="Notes"  color="primary"  %}}  
Linux x64의 경우 GLIBC 2.23 이상이 필요하고, Linux ARM64의 경우 GLIBC 2.39 이상이 필요합니다. CentOS 7 (GLIBC 2.14)과 같은 시스템은 지원되지 않습니다. CentOS 7이나 Alpine과 같은 호환되지 않는 시스템에서 Aspose.Slides를 실행해야 하는 경우, 표준 패키지인 [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET)를 사용하십시오.  
{{% /alert %}} 

## **FAQ**

**변환 및 렌더링을 위해 Microsoft PowerPoint를 설치해야 하나요?**

아니요, PowerPoint는 필요하지 않습니다. Aspose.Slides는 [프레젠테이션 만들기](/slides/ko/net/create-presentation/), 수정, [변환](/slides/ko/net/convert-presentation/), 및 [렌더링](/slides/ko/net/convert-powerpoint-to-png/)을 위한 독립 엔진입니다.

**올바른 렌더링을 위해 어떤 폰트가 필요합니까?**

프레젠테이션에 사용된 폰트 또는 적절한 대체 폰트가 운영 체제에 설치되어 있어야 합니다. Linux 및 macOS에서는 일반적인 폰트 패키지를 설치하여 일관된 렌더링을 보장하십시오.

Alpine Linux 컨테이너의 경우 `libgdiplus`와 함께 최소 하나의 폰트 패키지를 설치해야 합니다. 권장 최소 설정은 `libgdiplus`와 `ttf-dejavu`입니다. Arial, Times New Roman, Courier New, Verdana와 같은 Microsoft 폰트가 필요하면 `msttcorefonts-installer`와 `fontconfig`를 함께 사용하십시오.

**Linux에서 사용자 정의 폰트가 대체 폰트나 누락된 텍스트로 표시되는 이유는 무엇인가요?**

폰트 파일에 이름 테이블 엔트리가 일관되지 않거나 손상된 경우, Linux의 폰트 매칭 스택(FreeType/fontconfig)이 잘못된 레코드를 선택하여 폰트를 해결하지 못할 수 있습니다. 이름 테이블 레코드가 수정된 폰트 버전을 사용하거나 일관된 대체 폰트를 설치하면 문제가 해결됩니다.