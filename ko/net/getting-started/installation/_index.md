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
description: "Aspose.Slides for .NET을 빠르게 설치하는 방법을 배웁니다. 단계별 가이드, 시스템 요구 사항 및 코드 샘플 — 오늘부터 PowerPoint 프레젠테이션 작업을 시작하세요!"
---
## **개요**

이 문서에서는 Windows와 macOS에서 Aspose.Slides for .NET을 설치하는 방법을 설명합니다. NuGet 기반 설치에 중점을 두며 Windows에서 NuGet 패키지 관리자 또는 패키지 관리자 콘솔을 통해 Visual Studio 프로젝트에 라이브러리를 추가하는 방법을 보여줍니다. 또한 패키지를 업데이트하고 필요에 따라 사전 릴리스 빌드를 설치하는 방법도 설명합니다.

## **Windows**
NuGet은 PC에서 .NET용 Aspose API를 다운로드하고 설치하는 가장 쉬운 방법을 제공합니다. 

### **방법 1: NuGet 패키지 관리자를 통해 Aspose.Slides 설치 또는 업데이트**

1. Microsoft Visual Studio를 엽니다. 
2. 간단한 콘솔 앱을 만들거나 기존 프로젝트를 엽니다. 
3. **Tools** > **NuGet package manager** 로 이동합니다.
4. **Browse** 아래 텍스트 필드에 *Aspose Slides*를 검색합니다. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET**을 클릭한 다음 **Install**을 클릭합니다. 
   * 이미 설치된 경우 **Update**를 클릭하여 Aspose.Slides를 업데이트할 수 있습니다. 

선택한 API가 다운로드되어 프로젝트에 참조됩니다.

### **방법 2: 패키지 관리자 콘솔을 통해 Aspose.Slides 설치 또는 업데이트**

다음은 패키지 관리자 콘솔을 사용하여 [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/)를 참조하는 방법입니다:

1. Microsoft Visual Studio를 엽니다. 
2. 간단한 콘솔 앱을 만들거나 기존 프로젝트를 엽니다. 
3. **Tools** > **Library Package Manager** > **Package Manager Console** 로 이동합니다. 
![todo:image_alt_text](installation_2.png)
4. 다음 명령을 실행합니다: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
최신 정식 릴리스가 애플리케이션에 설치됩니다. 

* 또는 `-prerelease` 접미사를 추가하여 최신 릴리스(핫픽스 포함)를 설치하도록 지정할 수 있습니다.

 창 하단에 **Installing Aspose.Slides.NET** 팁이 표시됩니다. 
![todo:image_alt_text](installation_4.png)

다운로드가 완료되면 확인 메시지가 표시됩니다. 

[Aspose EULA](https://about.aspose.com/legal/eula)에 익숙하지 않다면 URL에 있는 라이선스를 읽어보시기 바랍니다. 
![todo:image_alt_text](installation_5.png)

애플리케이션에서 Aspose.Slides가 성공적으로 추가되고 참조된 것을 확인할 수 있습니다. 
![todo:image_alt_text](installation_6.png)

Package Manager Console에서 `Update-Package Aspose.Slides.NET` 명령을 실행하여 Aspose.Slides 패키지 업데이트를 확인할 수 있습니다. 업데이트가 존재하면 자동으로 설치됩니다. `-prerelease` 접미사를 사용하여 최신 릴리스를 업데이트할 수도 있습니다.
#### **공유 서버 환경에서 실행 시 고려 사항**
Aspose .NET 구성 요소는 **Full Trust** 권한 집합으로 실행할 것을 강력히 권장합니다. Aspose 구성 요소는 레지스트리 설정 및 가상 디렉터리 외부에 위치한 파일에 접근해야 할 경우가 있기 때문입니다(예: 글꼴을 읽어야 할 때).

또한 Aspose.NET 구성 요소는 코어 .NET 시스템 클래스를 기반으로 하며, 이러한 클래스 중 일부는 특정 상황에서 Full Trust 권한을 요구합니다.

여러 회사의 애플리케이션을 호스팅하는 인터넷 서비스 제공자는 대부분 **Medium Trust** 보안 수준을 적용합니다. .NET 2.0 환경에서는 이러한 보안 수준이 Aspose.Slides의 동작에 제한을 초래할 수 있습니다:

- **RegistryPermission**을 사용할 수 없습니다. 이는 문서 렌더링 시 설치된 글꼴을 열거하는 데 필요합니다.
- **FileIOPermission**이 제한됩니다. 이는 애플리케이션의 가상 디렉터리 계층 내 파일에만 접근할 수 있음을 의미합니다. 따라서 내보내기 작업 중 글꼴을 읽지 못할 수 있습니다. 

위 이유로 Aspose.Slides를 **Full Trust** 권한으로 실행할 것을 강력히 권장합니다. **Medium trust**를 사용할 경우 일부 라이브러리 기능(예: 렌더링)이 특정 작업 수행 시 정상적으로 동작하지 않을 수 있습니다. 

## **macOS**

NuGet은 macOS에서 .NET용 Aspose.Slides를 다운로드하고 설치하는 가장 쉬운 방법을 제공합니다. 

**필수 사전 작업**

macOS에서는 `System.Drawing` 네임스페이스가 다르게 동작하므로 mono-libgdiplus를 설치해야 합니다. 

> .NET 5 및 이전 버전에서는 [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet 패키지가 Windows, Linux, macOS에서 작동합니다. 그러나 플랫폼마다 차이가 있습니다. Linux와 macOS에서는 GDI+ 기능이 [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/) 라이브러리를 통해 구현됩니다. 이 라이브러리는 대부분의 Linux 배포판에 기본으로 설치되지 않으며 Windows 및 macOS의 GDI+ 전체 기능을 지원하지 않을 수 있습니다. 또한 libgdiplus가 전혀 제공되지 않는 플랫폼도 있습니다. Linux와 macOS에서 System.Drawing.Common 패키지의 타입을 사용하려면 libgdiplus를 별도로 설치해야 합니다. 자세한 내용은 [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) 또는 [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus)를 참조하십시오.

macOS에서 mono-libgdiplus를 별도로 설치하려면 .NET 문서의 [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus)를 확인하십시오. 

### **Aspose.Slides 설치**

1. Visual Studio를 엽니다. 
2. 간단한 콘솔 앱을 만들거나 기존 프로젝트를 엽니다.
3. **Project** > **Manage NuGet Packages...** 로 이동합니다.
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. 텍스트 필드에 *Aspose.Slides*를 입력합니다. 
5. **Aspose.Slides for .NET**을 클릭한 다음 **Add Package**를 클릭합니다. 
6. 간단한 코드 스니펫을 추가합니다.
   * [this page](/slides/ko/net/create-presentation/)의 코드를 복사할 수 있습니다.
7. 앱을 실행합니다.
8. 프로젝트의 *folder/bin/Debug/presentation_file_name* 폴더를 엽니다.

## **FAQ**

**무료 버전이나 체험 제한이 있나요?**

예, 기본적으로 Aspose.Slides는 평가 모드로 실행되며 워터마크가 표시되고 기타 제한이 있을 수 있습니다. 제한을 해제하려면 유효한 [license](/slides/ko/net/licensing/)를 적용해야 합니다.