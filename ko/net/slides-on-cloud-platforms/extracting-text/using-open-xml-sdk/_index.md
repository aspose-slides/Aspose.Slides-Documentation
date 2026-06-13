---
title: ".NET에서 Open XML SDK를 사용하여 PPT, PPTX 및 ODP 파일에서 텍스트를 추출하는 방법"
linktitle: Open XML SDK
type: docs
weight: 20
url: /ko/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- 클라우드 플랫폼
- 클라우드 통합
- Open XML SDK
- PPTX 텍스트 추출
- .NET 슬라이드 처리
- 프레젠테이션 텍스트 추출
- 마스터 슬라이드
- 발표자 메모
- 슬라이드에서 텍스트 추출
- C#
description: "Open XML SDK를 사용하여 .NET에서 PPT, PPTX 및 ODP 파일의 텍스트를 추출하는 방법을 배우고, XML 기반 접근, 성능 팁 및 클라우드 앱을 위한 변환 우회 방법을 제공합니다."
---
## **개요**

이 문서는 .NET에서 Open XML SDK를 사용하여 프레젠테이션 파일에서 텍스트를 추출하는 방법을 설명합니다. PPTX 파일에 대해 직접 XML에 접근하여 슬라이드를 렌더링하거나 Microsoft PowerPoint가 필요 없이 구조화된 슬라이드 요소에서 텍스트를 가져오는 데 중점을 둡니다. 또한 처리 속도 향상 및 메모리 사용량 감소와 같은 성능 이점도 설명합니다.

PPT 및 ODP 파일의 경우 Open XML SDK로 텍스트를 직접 추출할 수 없음을 설명합니다. 대신 이러한 형식을 먼저 PPTX로 변환한 뒤 변환된 파일에서 텍스트를 추출해야 합니다.

## **Open XML SDK**

**Open XML SDK**는 특히 Open XML 표준을 따르는 **PPTX** 파일에서 프레젠테이션 파일의 텍스트를 추출하기 위한 고도로 구조화되고 효율적인 방법을 제공합니다. 기본 XML에 직접 접근함으로써 기존 방식보다 슬라이드 콘텐츠를 더 빠르고 유연하게 처리할 수 있습니다.

## **직접 XML 액세스**

- **텍스트 직접 분석**: Open XML SDK를 사용하면 슬라이드를 렌더링하지 않고 XML 파트에서 텍스트를 추출할 수 있습니다.
- **구조화된 요소**: 텍스트가 명확히 정의된 XML 태그에 저장되므로 검색 및 처리가 단순합니다.

### **예시: 슬라이드 XML 콘텐츠에서 텍스트 직접 추출**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **성능 이점**

- **빠른 추출**: PowerPoint나 기타 고수준 API를 열어야 하는 오버헤드를 제거합니다.
- **낮은 메모리 사용량**: 관련 XML 파트만 접근하여 리소스 소비를 줄입니다.
- **Microsoft PowerPoint 불필요**: 추가 설치 요구 사항이 없습니다.

### **예시: 전체 프레젠테이션을 로드하지 않고 효율적으로 텍스트 추출**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **텍스트 요소 식별**

### **프레젠테이션에서 텍스트 추출에 대한 세부 사항**

프레젠테이션에서 텍스트를 추출할 때 다음 요소를 고려하세요.

- **텍스트가 다양한 섹션에 존재할 수 있음**: 일반 슬라이드, 마스터 슬라이드, 레이아웃 또는 발표자 메모.
- **기본 플레이스홀더**: 마스터 슬라이드와 레이아웃에 포함된 플레이스홀더(예: “Click to edit Master title style”)는 실제 프레젠테이션 내용이 아닐 수 있습니다.
- **빈 텍스트 또는 숨김 텍스트 필터링**: 일부 요소는 비어 있거나 표시되지 않을 수 있습니다.

### **텍스트를 포함하는 태그**

**PPTX** 파일에서 텍스트는 일반적으로 다음에 저장됩니다.
- `<a:p>`(단락) 내부의 `<a:t>` 요소
- `<a:p>` 내부의 `<a:r>` 요소(단락 내 텍스트 세그먼트)

### **예시: 슬라이드에서 모든 텍스트 요소 추출**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP 및 PPT**

### **텍스트를 직접 추출할 수 없음**

- **PPTX**와 달리 **PPT**(바이너리 형식)와 **ODP**(OpenDocument Presentation)는 Open XML SDK에서 지원되지 않습니다.
- **PPT**는 폐쇄형 바이너리 형식으로 저장되어 텍스트 추출이 복잡합니다.
- **ODP**는 **OpenDocument XML**을 사용하며 구조가 PPTX와 다릅니다.

### **우회 방법: PPTX로 변환**

**PPT** 또는 **ODP**에서 텍스트를 추출하려면 권장되는 접근 방식은 다음과 같습니다.

1. PowerPoint 또는 타사 도구를 사용해 **PPT → PPTX** 변환.  
2. LibreOffice 또는 PowerPoint를 통해 **ODP → PPTX** 변환.  
3. 변환된 PPTX에서 Open XML SDK를 사용해 **텍스트 추출**.

### **예시: LibreOffice 명령줄을 이용한 ODP → PPTX 변환**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **지원되는 플랫폼 및 프레임워크**

- **Windows**: .NET Framework 4.6.1 이상, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **클라우드 환경**: Microsoft Azure Functions, AWS Lambda(.NET Core), Docker 컨테이너.
- **Office 애플리케이션 호환성**: Microsoft Office 설치 불필요.
- **지원 프로그래밍 언어**: Open XML SDK는 **C#**, **VB.NET**, **F#** 및 기타 .NET 지원 언어와 함께 사용할 수 있습니다.

## **결론**

**PPTX 텍스트 추출**에 Open XML SDK를 활용하면 효율성과 명확성을 동시에 얻을 수 있으며, **PPT 및 ODP**는 원활한 처리를 위해 초기 변환 단계가 필요합니다. 이 접근 방식을 채택하면 **고성능**, **유연성**, 그리고 현대 .NET 애플리케이션과의 **넓은 호환성**을 보장할 수 있습니다.