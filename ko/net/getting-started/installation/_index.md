---
title: 설치
type: docs
weight: 70
url: /ko/net/installation/
keywords:
- Aspose.Slides 설치
- Aspose.Slides 다운로드
- Aspose.Slides 사용
- Aspose.Slides 설치
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Windows, Linux 및 macOS에서 NuGet을 통해 .NET용 Aspose.Slides를 설치합니다: 두 패키지 중 하나를 선택하고 .NET CLI 또는 Visual Studio로 추가하며, Linux 선행 조건을 설치합니다."
---
## **개요**

이 문서에서는 Windows, Linux, macOS에서 프로젝트에 Aspose.Slides for .NET을 추가하는 방법을 설명합니다. Aspose.Slides는 NuGet을 통해 배포됩니다. .NET CLI를 사용하여 모든 운영 체제에서 추가할 수 있으며, Windows에서는 Visual Studio의 NuGet 패키지 관리자 또는 패키지 관리자 콘솔을 사용할 수 있습니다. 또한 두 NuGet 패키지 중 어떤 것을 선택해야 하는지와 Linux에 추가로 필요한 사항을 설명합니다.

설치하기 전에 지원되는 운영 체제, .NET 구현 및 추가 종속성에 대해 [System Requirements](/slides/ko/net/system-requirements/)를 검토하십시오.

## **패키지 선택**

Aspose.Slides for .NET은 두 개의 NuGet 패키지로 제공됩니다. 두 패키지는 동일한 Aspose.Slides 네임스페이스와 클래스를 제공하므로, 패키지를 전환해도 코드가 변경되지 않습니다; 패키지 참조와 플랫폼 요구 사항만 다릅니다.

| 패키지 | 사용 대상 | 추가 요구 사항 |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows 및 .NET Framework 애플리케이션 | Linux 및 macOS에서는 `libgdiplus` 라이브러리와 애플리케이션 시작 시 `System.Drawing.EnableUnixSupport` 스위치를 활성화해야 합니다 |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | Windows, Linux 및 macOS에서 .NET 6 이상 | Linux에서는 `fontconfig` 라이브러리를 설치해야 합니다(이미 설치되어 있지 않은 경우) |

확신이 서지 않으면 Windows에서는 Aspose.Slides.NET을, Linux와 macOS에서는 Aspose.Slides.NET6.CrossPlatform을 사용하십시오. Alpine Linux 및 glibc 버전이 2.23(x64) 또는 2.39(ARM64)보다 오래된 Linux 시스템에서는 Aspose.Slides.NET을 사용하십시오. [System Requirements](/slides/ko/net/system-requirements/)는 각 패키지의 지원 플랫폼을 나열합니다.

## **.NET CLI로 설치**

이 단계는 .NET SDK 6 이상이 설치된 Windows, Linux, macOS에서 작동합니다. 콘솔 애플리케이션을 만듭니다:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

그런 다음 플랫폼에 맞는 패키지를 추가하십시오. 프로젝트에는 두 패키지 중 하나만 추가합니다.

- Windows: `dotnet add package Aspose.Slides.NET`
- Linux 및 macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`(Linux에서는 먼저 필수 구성 요소를 설치하십시오; [Linux](#linux) 참고)

패키지가 정상적으로 작동하는지 확인하려면 *Program.cs* 내용을 [Create Presentations](/slides/ko/net/create-presentation/)의 첫 번째 예제로 교체하고 `dotnet run`을 실행하십시오. 그러면 프로젝트 폴더에 *hello.pptx*가 저장됩니다.

## **Windows**

### **방법 1: NuGet 패키지 관리자에서 Aspose.Slides 설치 또는 업데이트**

1. Microsoft Visual Studio를 엽니다.
2. 콘솔 앱을 만들거나 기존 프로젝트를 엽니다.
3. **Solution Explorer**에서 프로젝트를 마우스 오른쪽 버튼으로 클릭하고 **Manage NuGet Packages**를 선택합니다(또는 **Project** > **Manage NuGet Packages**로 이동).
4. **Browse** 아래에서 *Aspose.Slides*를 검색합니다.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET**를 클릭한 다음 **Install**을 클릭합니다.
   * 이미 Aspose.Slides를 설치했으며 업데이트하려면 대신 **Update**를 클릭합니다.

패키지가 다운로드되어 프로젝트에 참조됩니다.

### **방법 2: 패키지 관리자 콘솔을 통해 Aspose.Slides 설치 또는 업데이트**

다음은 패키지 관리자 콘솔을 사용하여 [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 패키지를 참조하는 방법입니다:

1. Microsoft Visual Studio를 엽니다.
2. 콘솔 앱을 만들거나 기존 프로젝트를 엽니다.
3. **Tools** > **NuGet Package Manager** > **Package Manager Console**로 이동합니다.
![패키지 관리자 콘솔 열기](installation_2.png)
4. 다음 명령을 실행합니다: `Install-Package Aspose.Slides.NET`
![Install-Package 명령 실행](installation_3.png)

최신 릴리스가 프로젝트에 설치됩니다.

창 하단에 **Installing Aspose.Slides.NET** 메시지가 표시됩니다.
![패키지 관리자 콘솔에서 설치 진행 상황](installation_4.png)

다운로드가 완료되면 확인 메시지가 나타납니다. 패키지는 [Aspose EULA](https://about.aspose.com/legal/eula) 하에 배포됩니다.
![설치 확인 메시지](installation_5.png)

Aspose.Slides가 이제 프로젝트에 추가되어 참조됩니다.
![프로젝트에 참조된 Aspose.Slides](installation_6.png)

패키지를 업데이트하려면 패키지 관리자 콘솔에서 `Update-Package Aspose.Slides.NET`을 실행합니다.

## **Linux**

위의 .NET CLI 단계를 사용하십시오. 패키지를 선택하고 배포판의 패키지 관리자를 사용하여 필수 구성 요소를 설치합니다. Debian 및 Ubuntu에서는:

- **Aspose.Slides.NET6.CrossPlatform**: `fontconfig`를 설치합니다.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: `libgdiplus`를 설치하고, Aspose.Slides를 사용하기 전에 System.Drawing에 대한 Unix 지원을 활성화합니다.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  애플리케이션 시작 시, Aspose.Slides 호출 전에 다음 문장을 추가하십시오. 상위 수준 문이 있는 *Program.cs*에서는 `using` 지시문 뒤에 넣습니다:

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  Alpine Linux 및 glibc 버전이 Aspose.Slides.NET6.CrossPlatform에 충분히 최신이 아닌 시스템에서 이 패키지를 사용하십시오.

프레젠테이션에 사용된 글꼴이나 적절한 대체 글꼴은 텍스트가 올바르게 렌더링되도록 시스템에 설치되어 있어야 합니다. [System Requirements](/slides/ko/net/system-requirements/)는 Alpine Linux에서 Aspose.Slides.NET이 필요로 하는 패키지(글꼴 포함)를 설명합니다.

## **macOS**

위의 .NET CLI 단계를 사용하고 **Aspose.Slides.NET6.CrossPlatform** 패키지를 사용하십시오. 이 패키지는 Intel(x86_64) 및 Apple silicon(ARM64) Mac을 모두 지원합니다:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**무료 버전이나 체험 제한이 있나요?**

예. 라이선스가 없으면 Aspose.Slides는 평가 모드로 실행되어 저장하는 모든 슬라이드에 평가 워터마크를 추가하고 프레젠테이션에서 읽은 텍스트를 잘라냅니다. 이러한 제한을 제거하려면 유효한 [license](/slides/ko/net/licensing/)를 적용하십시오.