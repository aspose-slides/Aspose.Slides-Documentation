---
title: "Aspose.Slides를 사용하여 PPT, PPTX 및 ODP에서 텍스트 추출하는 방법"
linktitle: 슬라이드
type: docs
weight: 30
url: /ko/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- 클라우드 플랫폼
- 클라우드 통합
- 텍스트 추출
- 텍스트 추출
- PPT
- PPTX
- ODP
- 프레젠테이션 파일
- 크로스 플랫폼
- 오피스 독립형
- 메모 및 댓글
- 기업 색인
- 데이터 풍부화
- .NET
- Aspose.Slides
description: "Aspose.Slides API를 사용하여 인기 있는 클라우드 플랫폼에서 프레젠테이션의 텍스트를 추출하고, PPT, PPTX 및 ODP에 대한 검색, 분석 및 내보내기를 자동화합니다."
---
## **소개**

Aspose.Slides는 **강력하고 고수준의 API**를 제공하여 **PPT, PPTX 및 ODP**를 포함한 프레젠테이션 파일에서 텍스트를 추출합니다. PPTX만 지원하고 복잡한 XML 파싱이 필요한 Open XML SDK와 달리 Aspose.Slides는 텍스트 추출을 간소화하여 추출된 콘텐츠를 워크플로에 통합하는 데 집중할 수 있도록 합니다.

## **PresentationFactory.Instance.GetPresentationText 로 빠른 텍스트 추출**

프레젠테이션에서 텍스트를 추출하려면 **Aspose.Slides API**가 정적 메서드 `PresentationFactory.Instance.GetPresentationText`를 제공합니다. 이 메서드는 프레젠테이션 파일이나 데이터 스트림을 사용해 작업할 수 있는 여러 오버로드를 포함하며 **슬라이드, 마스터 슬라이드, 레이아웃, 노트 및 댓글**의 텍스트를 캡처합니다. 추출된 텍스트는 `IPresentationText` 인터페이스를 통해 액세스됩니다.

예시 사용법:

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```

## **GetPresentationText의 작동 모드**

`PresentationFactory`의 `GetPresentationText` 메서드는 `TextExtractionArrangingMode` 매개변수를 사용하여 텍스트 추출 방식을 세밀하게 조정할 수 있으며, 이 매개변수는 출력에서 텍스트가 어떻게 정리되는지를 제어합니다.

### **사용 가능한 모드**

- **TextExtractionArrangingMode.Unarranged** – 원본 슬라이드 레이아웃을 무시하고 자유 형식으로 텍스트를 추출합니다.  
- **TextExtractionArrangingMode.Arranged** – 각 슬라이드에 배치된 순서대로 텍스트 순서를 유지합니다.

사용 예시:

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```

## **PresentationFactory 메서드의 주요 장점**

- **전체 프레젠테이션을 로드할 필요 없음**: 메모리 사용량을 최소화하고 처리 속도를 높입니다.  
- **대용량 파일에 최적화**: 큰 프레젠테이션도 효율적으로 처리하여 텍스트를 빠르게 추출합니다.  
- **노트 및 댓글을 가져옴**: 사용자 주석을 포함해 콘텐츠를 포괄적으로 커버합니다.  
- **색인 및 콘텐츠 분석에 이상적**: 자동 처리와 데이터 풍부화가 필요한 기업 시스템에 최적입니다.  
- **오피스 독립적**: Microsoft PowerPoint가 설치되지 않아도 작동하며 완전한 독립 솔루션을 제공합니다.  
- **다중 포맷 지원**: **PPT, PPTX 및 ODP**와 원활하게 작동합니다.  
- **유연하고 강력한 API**: 구조화된 텍스트 추출을 위한 다양한 메서드를 제공합니다.  
- **전체 슬라이드 커버리지**: **레이아웃, 마스터 슬라이드, 일반 슬라이드, 배경, 발표자 노트 및 댓글**의 텍스트를 추출합니다.  
- **크로스 플랫폼 호환성**: **Windows, Linux, macOS** 및 클라우드 환경에서 동작합니다.  
- **고성능 및 확장성**: **SaaS 애플리케이션** 및 대규모 엔터프라이즈 배포에 적합합니다.

## **지원 운영 체제**

Aspose.Slides는 다양한 운영 체제에서 실행됩니다:

- **Windows** (예: Windows 7, 8, 10, 11 및 Server 에디션)  
- **Linux** (Ubuntu, Debian, Fedora, CentOS 등 다양한 배포판)  
- **macOS** (10.15 Catalina 및 이후 최신 버전 포함)  

## **지원 프로그래밍 언어**

Aspose.Slides는 여러 플랫폼 및 언어와 통합됩니다:

- **C#** – 주로 Aspose.Slides for .NET을 통해 지원됩니다.  
- **Java** – Aspose.Slides for Java와 함께 제공되는 전체 기능 API.  
- **C++** – 성능 중심 C++ 애플리케이션을 위해 Aspose.Slides를 활용합니다.  
- **Python via .NET** – .NET 상호 운용성을 사용하여 Aspose.Slides 기능을 통합합니다.  
- **기타 .NET 호환 언어** – .NET이 지원되는 모든 환경에서 라이브러리를 사용할 수 있습니다.

## **결론**

Aspose.Slides는 PowerPoint 및 OpenDocument 프레젠테이션에 대해 **포괄적인 텍스트 추출**을 제공하며, Open XML SDK와 비교했을 때 **다양한 파일 형식, 직관적인 텍스트 구조화 및 간편한 구현**을 지원합니다. **슬라이드와 노트부터 템플릿 콘텐츠까지**, **Aspose.Slides**는 프레젠테이션 텍스트를 추출하고 관리하기 위한 고효율, 풍부한 기능을 갖춘 솔루션입니다.