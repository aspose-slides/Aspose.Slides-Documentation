---
title: .NET에서 프레젠테이션 접근성 관리
linktitle: 프레젠테이션 접근성
type: docs
weight: 30
url: /ko/net/presentation-accessibility/
keywords:
- 프레젠테이션 접근성
- 대체 텍스트
- 대체 텍스트 제목
- 대체 텍스트 설명
- 장식으로 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PPT, PPTX 및 ODP 파일의 프레젠테이션 접근성 검사를 자동화하고 화면 판독기 경험을 개선하며 준수를 높입니다."
---
## **소개**

대체 텍스트는 보조 기술을 사용하는 사람이 이미지, 차트 및 기타 정보성 도형의 의미를 이해하도록 돕습니다. 이 문서에서는 Aspose.Slides for .NET을 사용하여 대체 텍스트 제목 및 설명을 읽고 업데이트하는 방법, 코드에서 사용되는 도형 이름과 접근성 설명을 구분하는 방법, 그리고 도형이 장식용으로 표시되었는지 확인하는 방법을 설명합니다.

이 기능들은 프레젠테이션 접근성을 지원하지만 이를 보장하지는 않습니다. 읽기 순서, 색 대비, 텍스트 가독성 및 기타 접근성 요구사항도 검토해야 합니다.

## **대체 텍스트 제목 및 설명 관리**

대체 텍스트를 사용하여 이미지를 볼 수 없는 사람에게 이미지, 차트 및 기타 정보성 도형의 의미를 설명합니다. 다음 속성들은 서로 다른 목적을 제공합니다:

| 속성 또는 내용 | 목적 |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/alternativetexttitle/) | 대체 설명에 대한 짧은 제목입니다. |
| [AlternativeText](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/alternativetext/) | 슬라이드 상황에서 도형의 내용 또는 목적에 대한 의미 있는 설명입니다. |
| [Name](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/name/) | 프레젠테이션에서 특정 도형을 찾기 위해 코드가 사용할 수 있는 도형 이름입니다. |
| Visible text | 슬라이드에 표시되는 내용으로, 도형의 텍스트나 차트의 제목 및 레이블 등이 있습니다. 대체 텍스트를 업데이트해도 이 내용은 변경되지 않습니다. |

프레젠테이션을 템플릿으로 재사용할 때, 코드는 업데이트하기 전에 [Name](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/name/)으로 도형을 찾을 수 있습니다. 이 이름은 시각적 요소가 독자에게 전달하는 내용을 설명하는 대체 텍스트와는 다른 목적을 가집니다. 이름으로 검색하면 설명을 개선하거나 번역할 수 있으며, 코드가 도형을 찾는 방식을 변경하지 않습니다. 이름은 편집 가능하고 고유성을 보장하지 않으므로, 해당 이름이 의도한 도형과 일치하는지 확인하십시오; 자세히 보려면 [Identify and Find Shapes](/slides/ko/net/shape-manipulations/#identify-and-find-shapes)를 참조하세요.

다음 예제는 첫 번째 슬라이드의 첫 번째 도형으로 사무실 입구 이미지가 포함된 `input.pptx` 파일이 필요합니다. 해당 이미지는 장식용으로 표시되지 않아야 합니다. 예제는 현재 대체 텍스트 제목 및 설명을 읽어 출력하고, 두 값을 업데이트한 뒤 프레젠테이션을 `output.pptx`로 저장합니다. 실제 이미지와 전달하는 정보를 반영하도록 문구를 조정하십시오.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

대체 텍스트를 추가한다고 해서 프레젠테이션 접근성이나 접근성 표준 준수가 보장되는 것은 아닙니다. 설명의 정확성과 적절성을 검토하고, 읽기 순서, 색 대비, 가독성 텍스트 및 기타 접근성 요구사항도 확인하십시오. 정보 전달이 필요한 시각 요소는 장식용으로 표시하면 안 되며, 다음 섹션에서는 [IsDecorative](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/isdecorative/)를 확인하는 방법을 보여줍니다.

## **장식으로 표시**

장식으로 표시 플래그는 순수하게 장식적인 시각 요소에 설정되어 화면 판독기가 이를 건너뛰게 하여 불필요한 소리를 줄이고 의미 있는 컨텐츠에 집중하도록 합니다. 배경, 장식 요소, 간격용 도형 등에 적용하고, 정보 전달이 필요한 차트, 아이콘 또는 이미지에는 절대 적용하지 마십시오. Aspose.Slides는 이 플래그를 제공하여 탐지 및 검증을 가능하게 하며, 자동화된 접근성 검사 및 정리를 지원합니다.

![Mark as Decorative](mark_as_decorative.png)

다음 코드 샘플은 도형이 장식으로 표시되었는지 확인하는 방법을 보여줍니다.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **FAQ**

**대체 텍스트 제목 및 설명에는 무엇을 넣어야 하나요?**  
짧은 제목을 사용하여 주제를 식별하고, 설명을 통해 시각 요소가 슬라이드 상황에서 전달하는 정보를 설명합니다. 차트의 경우, 단순히 "차트"라고 말하기보다 관련 추세나 비교를 설명하십시오.

**템플릿에서 도형을 찾기 위해 대체 텍스트를 사용해야 하나요?**  
도형을 찾을 때는 [Name](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/name/)을 사용하고 기대한 도형인지 확인하는 것이 좋습니다. 대체 텍스트는 편집되거나 번역될 수 있어 정확히 일치하는 설명을 검색하는 코드를 깨뜨릴 수 있습니다; 자세히 보려면 [Identify and Find Shapes](/slides/ko/net/shape-manipulations/)를 참조하세요.

**도형은 언제 장식으로 표시해야 하나요?**  
정보를 제공하지 않는 순수 장식용 시각 요소에만 장식 플래그를 사용하십시오. 의미를 전달하는 이미지와 차트에는 적절한 설명이 필요합니다.

**대체 텍스트를 추가하면 프레젠테이션이 완전히 접근 가능해지나요?**  
아니요. 대체 텍스트는 접근성의 일부만 다룹니다. 읽기 순서, 색 대비, 텍스트 가독성 및 기타 적용 가능한 요구사항도 검토해야 하며, 이러한 속성만 설정한다고 해서 준수가 보장되는 것은 아닙니다.