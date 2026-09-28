---
title: 시스템 요구 사항
type: docs
weight: 60
url: /ko/net/system-requirements/
keywords:
- 시스템 요구 사항
- 지원 플랫폼
- 대상 프레임워크
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "설치하기 전에 Aspose.Slides for .NET에 필요한 사항을 확인하십시오: 각 NuGet 패키지가 대상하는 프레임워크, 지원되는 운영 체제 및 프로세서, 그리고 Linux에 필요한 라이브러리와 글꼴."
---
## **소개**

Aspose.Slides for .NET은 독립형 라이브러리이며 Microsoft PowerPoint 또는 Microsoft Office가 필요하지 않습니다. 두 개의 NuGet 패키지, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)와 [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)로 배포됩니다. 두 패키지는 동일한 Aspose.Slides 네임스페이스와 클래스를 제공하지만, 대상 프레임워크와 슬라이드 렌더링 방식이 달라 실행 환경과 필요 사항이 달라집니다.

이 문서는 각 패키지가 지원하는 .NET 버전 및 플랫폼, Linux에 필요한 시스템 라이브러리와 글꼴을 나열하고, 설정을 확인하는 간단한 프로그램을 포함합니다. 프로젝트에 패키지를 추가하려면 [Installation](/slides/ko/net/installation/)를 참조하십시오.

## **지원되는 .NET 버전**

각 패키지는 대상 프레임워크별로 하나의 Aspose.Slides 빌드를 포함하며, NuGet은 프로젝트의 대상 프레임워크와 일치하는 빌드를 선택합니다.

| 패키지 | 패키지의 대상 프레임워크 | 프로젝트에서 대상 지정 가능 |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 이상; .NET 6 이상, .NET 8, .NET 9, .NET 10 포함 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 이상, .NET 8, .NET 9, .NET 10 포함 |

`netstandard2.0` 빌드는 .NET Standard 2.0 클래스 라이브러리가 Aspose.Slides.NET을 참조하도록 허용합니다. 해당 라이브러리를 사용하는 애플리케이션은 자신의 대상 프레임워크에 맞는 빌드를 실행합니다. 예를 들어 .NET 8 애플리케이션은 `net6.0` 빌드를 사용합니다.

## **지원되는 운영 체제 및 프로세서**

**Aspose.Slides.NET**은 프로세서에 독립적인 (AnyCPU) 관리 코드를 포함하므로 이를 로드하는 .NET 런타임의 프로세서 아키텍처에서 실행됩니다. 슬라이드는 Microsoft의 System.Drawing.Common 라이브러리를 통해 그려지며, Microsoft는 이를 [Windows 전용](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)으로 지원합니다. Linux에서는 `libgdiplus` 라이브러리와 시작 스위치가 필요하며, 이는 [Linux](#linux) 섹션에 설명되어 있습니다. Debian, Ubuntu, Alpine Linux와 같이 `libgdiplus`를 제공하는 배포판에서 실행됩니다.

**Aspose.Slides.NET6.CrossPlatform**은 자체 그래픽 엔진을 사용합니다. 이 엔진은 플랫폼별 네이티브 라이브러리이며, 패키지는 각 플랫폼당 하나의 빌드를 포함하므로 다음 플랫폼에서만 작동합니다:

| 운영 체제 | 프로세서 | 비고 |
|---|---|---|
| Windows | x86, x64 | ARM64 Windows는 지원되지 않습니다. |
| Linux | x64, ARM64 | x64에서는 glibc 2.23 이상, ARM64에서는 glibc 2.39 이상이 필요합니다. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform은 musl 기반 Alpine Linux와 같은 배포판이나 glibc 버전이 낮은 배포판(예: CentOS 7)에서는 실행되지 않으며, 이러한 시스템에서는 Aspose.Slides.NET을 사용하십시오.

Windows에서는 Aspose.Slides.NET6.CrossPlatform의 네이티브 라이브러리가 Microsoft Visual C++ 런타임(*MSVCP140.dll* 및 *VCRUNTIME140.dll*, x64에서는 *VCRUNTIME140_1.dll*)을 사용합니다. 대상 머신에 이 파일들이 없을 경우 [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170)을 설치하십시오.

## **Linux**

두 패키지 모두 Linux에서 추가 시스템 라이브러리가 필요합니다. 이 라이브러리가 없으면 [Create Presentations](/slides/ko/net/create-presentation/)에 있는 첫 번째 예제가 파일을 저장하는 대신 예외를 발생시킵니다. 아래 명령은 Debian 및 Ubuntu용이며, 해당 배포판에서는 각 라이브러리가 `fonts-dejavu-core` 글꼴도 함께 설치하므로 별도 글꼴 패키지를 추가하지 않아도 텍스트가 올바르게 렌더링됩니다.

### **Aspose.Slides.NET6.CrossPlatform**

패키지의 Linux 라이브러리는 `fontconfig` 라이브러리를 필요로 합니다:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

이 없이 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)을 만들면 `TypeInitializationException`이 발생하고, 내부 `DllNotFoundException`에서 `libfontconfig.so.1`을 열 수 없다고 보고합니다.

최소 베이스 이미지에는 `fontconfig`가 포함되지 않을 수 있습니다. 예를 들어 .NET 8용 AWS Lambda 베이스 이미지에는 `fontconfig`와 글꼴이 전혀 포함되지 않습니다. 이를 기반으로 만든 컨테이너 이미지에서는 `dnf install -y fontconfig`를 실행하면 Noto Sans 글꼴도 함께 설치됩니다.

### **Aspose.Slides.NET**

Linux에서 패키지가 필요로 하는 두 가지는 다음과 같습니다:

1. `libgdiplus` 라이브러리:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. `System.Drawing.EnableUnixSupport` 스위치. 이 스위치는 Aspose.Slides 호출 이전에 애플리케이션 시작 시 활성화해야 합니다. 최상위 문이 있는 *Program.cs*에서는 `using` 지시문 뒤에 추가합니다:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

`libgdiplus`가 없으면 프레젠테이션 저장 시 `TypeInitializationException`이 발생하고, 내부 `DllNotFoundException`에서 `libgdiplus`를 로드할 수 없다고 보고합니다. 스위치를 설정하지 않으면 내부 예외가 `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`가 됩니다.

{{% alert color="warning" title="Warning" %}}
이 스위치는 Aspose.Slides.NET이 의존하는 System.Drawing.Common 6 버전에서만 작동합니다. Microsoft는 System.Drawing.Common 7에서 이를 제거했습니다. 프로젝트가 System.Drawing.Common 7 이상을 직접 또는 다른 패키지를 통해 참조하는 경우, `libgdiplus`를 설치하고 스위치를 활성화해도 Linux에서 `PlatformNotSupportedException`이 발생합니다. 이때는 Aspose.Slides.NET6.CrossPlatform을 사용하십시오.
{{% /alert %}}

### **Alpine Linux**

Alpine Linux에서는 위에서 설명한 스위치를 사용하여 Aspose.Slides.NET을 실행하십시오. Alpine 이미지에는 일반적으로 글꼴이 없으며 `libgdiplus`만 설치해도 글꼴이 함께 설치되지 않으므로, `libgdiplus`와 함께 최소 하나의 글꼴 패키지를 설치해야 합니다. 글꼴이 없으면 프레젠테이션 저장 시 다음 오류가 발생합니다:

```text
System.ArgumentException: Font '?' cannot be found.
```

**옵션 1: DejaVu 폰트**

추천 옵션은 `ttf-dejavu` 패키지입니다:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

현재 Alpine 릴리스에서는 `ttf-dejavu`가 `font-dejavu` 패키지를 설치하며, 이 패키지는 `fontconfig`와 필요한 글꼴 도구도 함께 설치합니다.

**옵션 2: Microsoft 코어 폰트**

프레젠테이션에 Arial, Times New Roman, Courier New, Verdana와 같은 Microsoft 글꼴이 사용되는 경우, 대신 Microsoft 코어 글꼴을 설치하십시오. `update-ms-fonts` 단계는 이미지 빌드 시 글꼴을 다운로드하므로 빌드에 인터넷 접근이 필요합니다:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **글로벌화 지원**

두 패키지 모두 .NET 글로벌화 지원이 필요합니다. Linux에서 .NET은 ICU 라이브러리를 통해 이를 제공합니다. [globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization)를 사용할 경우, [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 생성 시 `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode` 예외가 발생합니다.

일부 컨테이너 이미지에서는 이 모드를 기본으로 켜두기도 합니다. 예를 들어 Alpine Linux용 .NET 런타임 이미지(`runtime-deps`, `runtime`, `aspnet`)는 `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true`로 설정하고 ICU를 포함하지 않습니다. 이러한 이미지에서 빌드할 때는 ICU를 설치하고 모드를 끄십시오:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

또한 프로젝트 파일에 `InvariantGlobalization` 속성이 `true`로 설정되지 않았는지 확인하십시오.

## **설정 확인**

패키지와 그 요구 사항이 모두 갖춰졌는지 확인하려면 프레젠테이션을 저장하고 슬라이드를 이미지로 렌더링하는 프로그램을 실행하십시오. 저장 및 렌더링은 그래픽 라이브러리와 글꼴을 사용하므로, 위에서 설명한 Linux 요구 사항이 충족되어야 정상 동작합니다.

콘솔 애플리케이션을 만들고 [Installation](/slides/ko/net/installation/)에 따라 패키지를 추가한 뒤, *Program.cs* 내용을 아래 코드로 교체하고 `dotnet run`을 실행하십시오. Linux에서 Aspose.Slides.NET을 사용하는 경우, [Linux](#linux) 섹션에 나와 있는 `System.Drawing.EnableUnixSupport` 스위치 구문을 `using` 지시문 뒤에 추가하십시오. 이 프로그램은 최상위 문과 `using` 선언을 사용하므로 C# 9 이상이 필요합니다. .NET 6 이상을 대상으로 하는 프로젝트는 기본적으로 최신 C# 버전을 사용합니다; .NET Framework를 대상으로 하는 경우 프로젝트 파일의 `PropertyGroup`에 `<LangVersion>latest</LangVersion>`을 추가하십시오.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

프로그램은 첫 번째 슬라이드에 텍스트가 포함된 사각형을 추가하고, [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 메서드로 *hello.pptx* 파일로 저장합니다. 그런 다음 [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/)으로 슬라이드를 렌더링하고, [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/)를 사용해 *hello.png* 파일을 [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) 형식으로 저장합니다. 배율 1은 포인트당 한 픽셀을 렌더링하므로 기본 720 × 540 포인트 슬라이드가 720 × 540 픽셀 이미지가 됩니다. 텍스트가 사각형 안에 표시됩니다. 라이선스가 없으면 두 파일 모두 평가 워터마크가 포함되며, 자세한 내용은 [Licensing](/slides/ko/net/licensing/)를 참고하십시오. 요구 사항이 누락되면 프로그램은 [Linux](#linux) 섹션에 설명된 예외 중 하나를 발생시킵니다.

## **개발 도구**

프로젝트의 대상 프레임워크를 지원하는 모든 도구로 Aspose.Slides를 사용하는 애플리케이션을 빌드할 수 있습니다. Windows, Linux, macOS에서는 .NET SDK와 `dotnet` CLI를, Windows에서는 Visual Studio를 사용할 수 있습니다. [Installation](/slides/ko/net/installation/)에서 두 방법을 모두 안내합니다.

## **FAQ**

**Microsoft PowerPoint를 설치해야 변환 및 렌더링이 가능한가요?**

아니요, PowerPoint는 필요하지 않습니다. Aspose.Slides는 [프레젠테이션 생성](/slides/ko/net/create-presentation/), 수정, [변환](/slides/ko/net/convert-presentation/), 그리고 [렌더링](/slides/ko/net/convert-powerpoint-to-png/)을 위한 독립형 엔진입니다.

**어떤 패키지를 사용해야 하나요?**

Windows에서는 Aspose.Slides.NET을, Linux와 macOS에서는 Aspose.Slides.NET6.CrossPlatform을 사용하십시오. Alpine Linux, glibc 버전이 위에 명시된 것보다 낮은 Linux 시스템, 그리고 .NET Framework를 대상으로 하는 프로젝트에서는 Aspose.Slides.NET을 사용하십시오. 프로젝트당 두 패키지 중 하나만 추가하면 됩니다.

**올바른 렌더링을 위해 어떤 글꼴이 필요합니까?**

프레젠테이션에 사용된 글꼴 또는 적절한 대체 글꼴이 운영 체제에 설치되어 있어야 합니다. Linux와 macOS에서는 프레젠테이션에 필요한 글꼴 패키지를 설치해 일관된 렌더링을 확보하십시오. Alpine Linux에서는 `libgdiplus`와 함께 최소 하나의 글꼴 패키지를 설치해야 합니다(자세히는 [Alpine Linux](#alpine-linux) 참조).

**Linux에서 사용자 지정 글꼴이 대체 글꼴이나 누락된 텍스트로 표시되는 이유는 무엇인가요?**

글꼴 파일의 name-table 엔트리가 일관되지 않거나 손상된 경우, Linux의 글꼴 매칭 스택(FreeType/fontconfig)이 잘못된 레코드를 선택해 글꼴을 해석하지 못할 수 있습니다. name-table 레코드가 수정된 글꼴 버전을 사용하거나 일관된 대체 글꼴을 설치하면 문제가 해결됩니다.