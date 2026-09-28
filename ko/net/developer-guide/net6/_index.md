---
title: ".NET 6 및 이후용 크로스 플랫폼 패키지"
linktitle: "크로스 플랫폼 패키지"
type: docs
weight: 235
url: /ko/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- 크로스 플랫폼
- .NET 6 지원
- 리눅스
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides.NET6.CrossPlatform 패키지를 언제 사용해야 하는지 알아보세요: 존재 이유, 지원 플랫폼, libgdiplus 대신 Linux에서 필요한 사항."
---
## **소개**

Aspose.Slides for .NET은 두 개의 NuGet 패키지로 배포됩니다. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)은 Microsoft의 System.Drawing.Common 라이브러리를 통해 슬라이드를 그립니다. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)은 자체 그래픽 엔진을 사용하여 그립니다. 이 문서에서는 두 번째 패키지가 존재하는 이유, 실행되는 환경, Linux에서 필요한 사항, 그리고 하나의 프로젝트에서 System.Drawing.Common과 어떻게 공존하는지를 설명합니다.

## **왜 별도 패키지가 필요한가**

.NET 6부터 Microsoft는 System.Drawing.Common을 **Windows에서만** 지원합니다[only on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). 그 결과 Linux에서는 Aspose.Slides.NET이 `System.Drawing.EnableUnixSupport` 스위치와 `libgdiplus` 라이브러리를 추가로 필요로 하며, 프로젝트가 System.Drawing.Common 7 이상을 참조하면 실패합니다. [System Requirements](/slides/ko/net/system-requirements/)에 이러한 조건이 설명되어 있습니다.

Aspose.Slides.NET6.CrossPlatform은 System.Drawing.Common이나 `libgdiplus`를 사용하지 않습니다. 그래픽 엔진은 패키지에 포함된 네이티브 라이브러리이며, 지원되는 각 플랫폼별로 하나씩 제공됩니다. 두 패키지는 동일한 Aspose.Slides 네임스페이스와 클래스를 제공하므로, 패키지 참조만 교체하면 코드 변경 없이 전환할 수 있습니다.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| 그래픽 | System.Drawing.Common | 패키지에 포함된 네이티브 그래픽 엔진 |
| 대상 프레임워크 | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux 요구 사항 | `libgdiplus`와 `System.Drawing.EnableUnixSupport` 스위치 | `fontconfig` |
| Alpine Linux | 지원됨 | 지원되지 않음 |

## **지원되는 플랫폼**

Aspose.Slides.NET6.CrossPlatform은 .NET 6 이후 버전에서 다음 플랫폼에서 동작합니다:

- **Windows**: x86 및 x64. 네이티브 라이브러리는 Microsoft Visual C++ 런타임을 사용합니다; 자세한 내용은 [System Requirements](/slides/ko/net/system-requirements/)를 확인하십시오.
- **Linux**: glibc 2.23 이상을 갖춘 x64와 glibc 2.39 이상을 갖춘 ARM64.
- **macOS**: x64(Intel) 및 ARM64(Apple silicon).

Windows ARM64, Alpine Linux 또는 musl 기반의 다른 배포판, 혹은 glibc 버전이 오래된 배포판(예: CentOS 7)에서는 실행되지 않습니다. 이러한 시스템에서는 Aspose.Slides.NET을 사용하십시오.

## **Linux에 설치**

Linux에서는 패키지가 `fontconfig` 라이브러리를 필요로 하지만 `libgdiplus`는 필요하지 않습니다. Debian 및 Ubuntu에서는 `fontconfig`를 설치한 뒤 프로젝트에 패키지를 추가합니다:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Debian 및 Ubuntu에서는 `libfontconfig1`이 DejaVu 폰트를 함께 설치하므로 별도의 폰트 패키지 없이 텍스트가 올바르게 렌더링됩니다. `fontconfig` 없이 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/)을 생성하면 `TypeInitializationException`이 발생하고, 내부 `DllNotFoundException`에 `libfontconfig.so.1`을 열 수 없다는 내용이 표시됩니다. [System Requirements](/slides/ko/net/system-requirements/)에 포함된 간단한 프로그램을 통해 설정을 확인할 수 있습니다.

## **클라우드 및 컨테이너 호스트**

`libgdiplus`가 필요 없기 때문에 Aspose.Slides.NET6.CrossPlatform은 `libgdiplus`를 설치할 수 없는 Linux 호스트에서 사용할 패키지입니다. 다만 `fontconfig`와 폰트는 여전히 필요하며, 최소 이미지에는 포함되지 않을 수 있습니다. 예를 들어 .NET 8용 AWS Lambda 베이스 이미지에는 두 항목 모두 없습니다. 해당 이미지에 기반한 컨테이너에서 `dnf install -y fontconfig`를 실행하면 Noto Sans 폰트도 함께 설치됩니다.

특정 클라우드 플랫폼에 대한 가이드는 [Aspose.Slides on Cloud Platforms](/slides/ko/net/slides-on-cloud-platforms/)를 참고하십시오.

## **같은 프로젝트에서 System.Drawing.Common 사용하기 (CS0433)**

Aspose.Slides.NET6.CrossPlatform을 사용하는 프로젝트는 System.Drawing.Common을 직접 또는 다른 패키지를 통해 동시에 참조할 수 있습니다. 현재 버전의 Aspose.Slides는 `System` 네임스페이스에 공개 타입을 제공하지 않으므로 두 라이브러리가 충돌하지 않으며, 같은 파일에서 `Aspose.Slides`와 `System.Drawing` 네임스페이스를 모두 임포트할 수 있습니다.

컴파일러가 `Image`나 `Graphics`와 같이 두 라이브러리 모두에 존재하는 타입 때문에 CS0433 오류를 표시한다면, 프로젝트에서 오래된 버전의 Aspose.Slides를 사용하고 있는 것입니다. 패키지를 최신 버전으로 업데이트하십시오. Aspose.Slides는 렌더링된 이미지를 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 객체로 반환하며, 이는 [Modern API](/slides/ko/net/modern-api/)에서 설명하고 있습니다.

## **FAQ**

**Aspose.Slides.NET에서 Aspose.Slides.NET6.CrossPlatform으로 전환할 때 코드 변경이 필요합니까?**

아니요. 두 패키지는 동일한 Aspose.Slides 네임스페이스와 클래스를 제공하므로 패키지 참조만 교체하면 됩니다. Aspose.Slides.NET6.CrossPlatform은 `System.Drawing.EnableUnixSupport` 스위치를 필요로 하지 않습니다. 프로젝트에 두 패키지 중 하나만 추가하십시오.

**Aspose.Slides.NET6.CrossPlatform을 .NET Framework 프로젝트에서 사용할 수 있습니까?**

아니요. 이 패키지는 .NET 6 및 이후 버전만 대상합니다. .NET Framework 4.6.2 이상에서는 Aspose.Slides.NET을 사용하십시오.