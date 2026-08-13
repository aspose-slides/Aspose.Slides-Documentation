---
title: .NET에서 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/net/slide-size/
keywords:
- 슬라이드 크기
- 화면 비율
- 표준
- 와이드스크린
- 4:3
- 16:9
- 슬라이드 크기 설정
- 슬라이드 크기 변경
- 사용자 지정 슬라이드 크기
- 특수 슬라이드 크기
- 고유 슬라이드 크기
- 전체 크기 슬라이드
- 화면 유형
- 확대/축소 하지 않음
- 맞춤 보장
- 최대화
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET 및 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하는 방법을 배우고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화하세요."
---
## **소개**

Aspose.Slides for .NET은 PowerPoint 프레젠테이션에서 슬라이드 크기와 가로 세로 비율을 조정하기 위한 포괄적인 도구를 제공하며, 인쇄 및 화면 표시 모두에 중요합니다.

주요 슬라이드 크기 및 비율:

- **Standard (4:3 Aspect Ratio)**: 구형 화면 및 장치에 이상적입니다.
- **Widescreen (16:9 Aspect Ratio)**: 최신 프로젝터 및 디스플레이에 권장됩니다.

프레젠테이션 전체에서 일관성을 유지하려면 모든 슬라이드에 동일한 슬라이드 크기와 가로 세로 비율이 적용됩니다. 최적의 결과를 얻으려면 프레젠테이션을 만들기 시작할 때 슬라이드 크기를 설정하여 문제를 방지하십시오.

{{% alert color="info" %}} 
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 가로 세로 비율을 사용합니다.
{{% /alert %}}

## **프레젠테이션에서 슬라이드 크기를 변경하는 방법**

이 예제는 C#에서 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **사용자 지정 슬라이드 크기 지정**

특정 용도에 맞게 슬라이드 크기를 조정하면, 예를 들어 고유한 용지 레이아웃이나 화면 사양에 맞출 때 도움이 됩니다. 다음은 Aspose.Slides for .NET으로 사용자 지정 슬라이드 크기를 설정하는 방법입니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 용지 크기
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **크기 조정 후 슬라이드 콘텐츠 처리**

크기 조정 후 슬라이드 내용이 왜곡될 수 있습니다. Aspose.Slides가 이 크기 조정을 어떻게 처리할지 제어할 수 있습니다:

- **`DoNotScale`**: 객체를 원래 크기로 유지하여 확대/축소를 방지합니다.
- **`EnsureFit`**: 작은 슬라이드에 맞게 객체를 확대/축소하여 내용 손실을 방지합니다.
- **`Maximize`**: 큰 슬라이드에 맞게 객체를 확대하여 미학적 일관성을 유지합니다.

`Maximize` 설정을 사용한 슬라이드 크기 조정 예제:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **자주 묻는 질문**

### 인치를 제외한 단위(예: 포인트 또는 밀리미터)로 사용자 지정 슬라이드 크기를 설정할 수 있나요?

예. Aspose.Slides는 내부적으로 포인트를 사용하며, 1 포인트는 인치의 1/72에 해당합니다. 밀리미터나 센티미터와 같은 모든 단위를 포인트로 변환한 뒤 변환된 값을 사용하여 슬라이드 너비와 높이를 정의할 수 있습니다.

### 매우 큰 사용자 지정 슬라이드 크기가 렌더링 시 성능 및 메모리 사용량에 영향을 미칩니까?

예. 포인트 단위의 큰 슬라이드 치수와 높은 렌더링 스케일을 함께 사용하면 메모리 사용량이 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 원하는 출력 품질을 얻기 위해 필요한 경우에만 렌더링 스케일을 조정하십시오.

### 비표준 슬라이드 크기를 하나 정의한 뒤, 크기가 다른 프레젠테이션에서 슬라이드를 병합할 수 있나요?

슬라이드 크기가 다를 경우 [merge presentations](/slides/ko/net/merge-presentation/)을 수행할 수 없습니다 — 먼저 한 프레젠테이션의 크기를 다른 프레젠테이션에 맞게 조정하십시오. 슬라이드 크기를 변경할 때는 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/net/aspose.slides/slidesizescaletype/) 옵션을 통해 기존 콘텐츠가 어떻게 처리될지 선택할 수 있습니다. 크기를 맞춘 후에는 서식을 유지하면서 슬라이드를 병합할 수 있습니다.

### 개별 도형이나 슬라이드의 특정 영역에 대한 썸네일을 생성할 수 있나요? 또한 새 슬라이드 크기를 반영합니까?

예. Aspose.Slides는 [entire slides](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/getimage/)와 [selected shapes](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/getimage/)에 대한 썸네일을 렌더링할 수 있습니다. 생성된 이미지는 현재 슬라이드 크기와 가로 세로 비율을 반영하여 일관된 프레이밍과 기하학을 보장합니다.