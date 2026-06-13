---
title: .NET에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드를 SVG로
type: docs
weight: 50
url: /ko/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint를 SVG로
- 프레젠테이션을 SVG로
- 슬라이드를 SVG로
- PPT를 SVG로
- PPTX를 SVG로
- PPT를 SVG로 저장
- PPTX를 SVG로 저장
- PPT를 SVG로 내보내기
- PPTX를 SVG로 내보내기
- 슬라이드 렌더링
- 슬라이드 변환
- 슬라이드 내보내기
- 벡터 이미지
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 슬라이드를 SVG 이미지로 렌더링하는 방법을 배우세요. 간단한 C# 코드 예제로 고품질 비주얼을 구현합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 슬라이드를 SVG 이미지로 렌더링하는 방법을 설명합니다. SVG 형식과 확장성, 접근성, 웹 개발에 적합함을 포함한 장점에 대해 서술합니다.

프레젠테이션 파일을 로드하고 슬라이드를 순회하며 각 슬라이드를 개별 SVG 파일로 저장하는 방법을 배우게 됩니다. 이 문서는 PPT, PPTX, ODP 및 PPS를 포함한 PowerPoint 및 OpenDocument 프레젠테이션 형식을 다루며, `Presentation` 클래스와 `WriteAsSvg` 메서드를 사용하여 프로그래밍 방식으로 변환하는 방법을 보여줍니다.

## **SVG 형식**
SVG—Scalable Vector Graphics의 약자—는 2차원 이미지를 렌더링하는 데 사용되는 표준 그래픽 유형 또는 포맷입니다. SVG는 이미지 를 XML 기반 벡터 형태로 저장하며, 동작이나 외관을 정의하는 세부 정보를 포함합니다. 

SVG는 확장성, 인터랙티브성, 성능, 접근성, 프로그래밍 가능성 등 매우 높은 기준을 만족하는 몇 안 되는 이미지 포맷 중 하나입니다. 이러한 이유로 웹 개발에서 일반적으로 사용됩니다. 

다음과 같은 상황에서 SVG 파일을 사용하고 싶을 수 있습니다.

- **프레젠테이션을 *매우 큰 형식*으로 인쇄하고자 할 때.** SVG 이미지는 어떤 해상도나 규모로도 확장될 수 있습니다. 품질 저하 없이 필요에 따라 SVG 이미지를 여러 번 크기 조정할 수 있습니다.
- **슬라이드의 차트와 그래프를 *다양한 매체 또는 플랫폼*에서 사용하고자 할 때.** 대부분의 뷰어가 SVG 파일을 해석할 수 있습니다.
- **가능한 가장 작은 이미지 크기로 사용하고자 할 때.** SVG 파일은 일반적으로 다른 포맷의 고해상도 이미지보다 작으며, 특히 비트맵 기반 포맷(JPEG 또는 PNG)보다 더 작습니다.

## **슬라이드를 SVG 이미지로 렌더링**

Aspose.Slides for .NET은 프레젠테이션의 슬라이드를 SVG 이미지로 내보낼 수 있게 해 줍니다. 다음 단계에 따라 SVG 이미지를 생성하십시오:

_*단계: PowerPoint를 SVG로 변환(C#)_*

다음 샘플 코드는 .NET을 사용한 이러한 변환을 설명합니다.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>단계: PowerPoint를 SVG로 변환(C#)</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>단계: PPT를 SVG로 변환(C#)</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>단계: PPTX를 SVG로 변환(C#)</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>단계: ODP를 SVG로 변환(C#)</strong></a>

**코드 단계:**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
   * _.ppt_ 확장자를 사용하여 **PPT** 파일을 _Presentation_ 클래스에 로드합니다.
   * _.pptx_ 확장자를 사용하여 **PPTX** 파일을 _Presentation_ 클래스에 로드합니다.
   * _.odp_ 확장자를 사용하여 **ODP** 파일을 _Presentation_ 클래스에 로드합니다.
   * _.pps_ 확장자를 사용하여 **PPS** 파일을 _Presentation_ 클래스에 로드합니다.
2. 프레젠테이션의 모든 슬라이드를 순회합니다.
3. FileStream을 사용하여 각 슬라이드를 별개의 SVG 파일로 작성합니다.

{{% alert color="primary" %}} 

Aspose.Slides for .NET의 PPT를 SVG로 변환하는 기능을 구현한 우리의 [무료 웹 애플리케이션](https://products.aspose.app/slides/ko/conversion/ppt-to-svg)을 사용해 보실 수 있습니다.

{{% /alert %}} 

다음 C# 샘플 코드는 Aspose.Slides를 사용해 PowerPoint를 SVG로 변환하는 방법을 보여 줍니다:

``` csharp
// Presentation 개체는 PPT, PPTX, ODP 등과 같은 PowerPoint 형식을 로드할 수 있습니다.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **자주 묻는 질문**

**결과 SVG가 브라우저마다 다르게 보이는 이유는 무엇인가요?**  
브라우저 엔진마다 특정 SVG 기능에 대한 지원이 다르게 구현됩니다. [SVGOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/) 매개변수를 사용하면 이러한 호환성 차이를 완화할 수 있습니다.

**슬라이드뿐 아니라 개별 도형도 SVG로 내보낼 수 있나요?**  
예. 모든 [shape can be saved as a separate SVG](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/writeassvg/) 로, 아이콘, 픽토그램 및 그래픽 재사용에 편리합니다.

**여러 슬라이드를 하나의 SVG(스트립/문서)로 결합할 수 있나요?**  
표준 시나리오는 하나의 슬라이드 → 하나의 SVG입니다. 여러 슬라이드를 하나의 SVG 캔버스로 결합하는 작업은 애플리케이션 수준에서 수행하는 후처리 단계입니다.

## **관련 항목** 

이 문서는 아래 주제도 다룹니다. 코드는 위와 동일합니다.

_포맷_: **PowerPoint**
- [C# PowerPoint를 SVG 코드로 변환](#csharp-powerpoint-to-svg)
- [C# PowerPoint SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint SVG 프로그래밍 방식](#csharp-powerpoint-to-svg)
- [C# PowerPoint SVG 라이브러리](#csharp-powerpoint-to-svg)
- [C# PowerPoint를 SVG로 저장](#csharp-powerpoint-to-svg)
- [C# PowerPoint에서 SVG 생성](#csharp-powerpoint-to-svg)
- [C# PowerPoint에서 SVG 만들기](#csharp-powerpoint-to-svg)
- [C# PowerPoint SVG 변환기](#csharp-powerpoint-to-svg)

_포맷_: **PPT**
- [C# PPT를 SVG 코드로 변환](#csharp-ppt-to-svg)
- [C# PPT SVG API](#csharp-ppt-to-svg)
- [C# PPT SVG 프로그래밍 방식](#csharp-ppt-to-svg)
- [C# PPT SVG 라이브러리](#csharp-ppt-to-svg)
- [C# PPT를 SVG로 저장](#csharp-ppt-to-svg)
- [C# PPT에서 SVG 생성](#csharp-ppt-to-svg)
- [C# PPT에서 SVG 만들기](#csharp-ppt-to-svg)
- [C# PPT SVG 변환기](#csharp-ppt-to-svg)

_포맷_: **PPTX**
- [C# PPTX를 SVG 코드로 변환](#csharp-pptx-to-svg)
- [C# PPTX SVG API](#csharp-pptx-to-svg)
- [C# PPTX SVG 프로그래밍 방식](#csharp-pptx-to-svg)
- [C# PPTX SVG 라이브러리](#csharp-pptx-to-svg)
- [C# PPTX를 SVG로 저장](#csharp-pptx-to-svg)
- [C# PPTX에서 SVG 생성](#csharp-pptx-to-svg)
- [C# PPTX에서 SVG 만들기](#csharp-pptx-to-svg)
- [C# PPTX SVG 변환기](#csharp-pptx-to-svg)

_포맷_: **ODP**
- [C# ODP를 SVG 코드로 변환](#csharp-odp-to-svg)
- [C# ODP SVG API](#csharp-odp-to-svg)
- [C# ODP SVG 프로그래밍 방식](#csharp-odp-to-svg)
- [C# ODP SVG 라이브러리](#csharp-odp-to-svg)
- [C# ODP를 SVG로 저장](#csharp-odp-to-svg)
- [C# ODP에서 SVG 생성](#csharp-odp-to-svg)
- [C# ODP에서 SVG 만들기](#csharp-odp-to-svg)
- [C# ODP SVG 변환기](#csharp-odp-to-svg)