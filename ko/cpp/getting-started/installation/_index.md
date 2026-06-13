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
- Windows
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides를 빠르게 설치하는 방법을 배웁니다. 단계별 가이드, 시스템 요구 사항 및 코드 샘플을 제공하여 오늘 바로 PowerPoint 프레젠테이션 작업을 시작하세요!"
---
## **개요**

이 문서에서는 Windows에서 Aspose.Slides를 설치하는 방법을 설명합니다. NuGet 기반 설치에 중점을 두고 NuGet Package Manager 또는 Package Manager Console을 사용하여 라이브러리를 Visual Studio 프로젝트에 추가하는 방법을 보여줍니다. 또한 패키지를 업데이트하고 필요에 따라 프리릴리스 빌드를 설치하는 방법도 설명합니다.

## **Windows**
NuGet은 PC에서 C++용 Aspose API를 다운로드하고 설치하는 가장 간단한 방법을 제공합니다. 

### **옵션 1: NuGet Package Manager를 통해 Aspose.Slides for C++ 설치 또는 업데이트**

1. Microsoft Visual Studio를 엽니다. 
2. 간단한 콘솔 앱을 만듭니다. 또는 원하는 프로젝트를 열 수 있습니다. 
3. **Tools** > **NuGet package manager** 로 이동합니다.
4. **Browse** 아래에 텍스트 필드에 *Aspose.Slides.Cpp* 를 입력합니다. 

![todo:image_alt_text](installation_1.png)

3. 필요한 버전 **Aspose.Slides.Cpp** 를 클릭한 다음 **Install** 를 클릭합니다. 
   * Aspose.Slides를 업데이트하려면(이미 설치된 경우) 대신 **Update** 를 클릭합니다. 

선택한 API가 다운로드되어 프로젝트에 참조됩니다.

### **옵션 2: Package Manager Console을 통해 Aspose.Slides 설치 또는 업데이트**

Package Manager Console을 사용하여 [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) 를 참조하려면 다음을 수행합니다:

1. Visual Studio에서 솔루션/프로젝트를 엽니다.

1. **Tools** > **NuGet Package Manager** > **Package Manager Console** 로 이동합니다. 

Package Manager Console이 열립니다. 

![todo:image_alt_text](installation_2.png)

4. 다음 명령을 입력합니다: `Install-Package Aspose.Slides.Cpp` 
> x86 버전을 설치하려면 Aspose.Slides.Cpp.x86 패키지를 사용합니다: `Install-Package Aspose.Slides.Cpp.x86`

5. Enter 키를 누릅니다.

최신 정식 릴리스가 애플리케이션에 설치됩니다. 

   * 대안으로, 명령에 `-prerelease` 접미사를 추가하여 최신 릴리스(핫픽스 포함)를 함께 설치하도록 지정할 수 있습니다.

![todo:image_alt_text](installation_3.png)

다운로드가 완료되면 확인 메시지가 표시됩니다.  

![todo:image_alt_text](installation_4.png)

[Aspose EULA](https://about.aspose.com/legal/eula)에 익숙하지 않은 경우 URL에 언급된 라이선스를 확인하시기 바랍니다.  

Package Manager Console에서 `Update-Package Aspose.Slides.Cpp` 명령을 실행하여 Aspose.Slides 패키지 업데이트를 확인할 수 있습니다. 업데이트가 발견되면 자동으로 설치됩니다. 최신 릴리스를 업데이트하려면 `-prerelease` 접미사를 사용할 수도 있습니다.

### **Include 및 lib 폴더 사용**
1. 최신 Aspose.Slides for C++ 버전을 [Download](https://downloads.aspose.com/slides/ko/cpp) 합니다.
1. 폴더를 압축 해제하여 프로덕션 환경에 배치합니다.
1. Aspose.Slides for C++ 를 사용하려면 프로젝트에 Include 및 lib 폴더를 참조합니다

## **FAQ**

**무료 버전 또는 평가판 제한이 있나요?**

예, 기본적으로 Aspose.Slides는 평가 모드로 실행되며 워터마크가 표시되고 기타 제한이 있을 수 있습니다. 제한을 해제하려면 유효한 [license](/slides/ko/cpp/licensing/) 를 적용해야 합니다.