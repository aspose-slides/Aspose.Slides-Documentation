---
title: PowerPoint 슬라이드를 .NET에서 PNG로 변환
linktitle: PowerPoint를 PNG로 변환
type: docs
weight: 30
url: /ko/net/convert-powerpoint-to-png/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PNG로 변환
- 프레젠테이션을 PNG로 변환
- 슬라이드를 PNG로 변환
- PPT를 PNG로 변환
- PPTX를 PNG로 변환
- PPT를 PNG로 저장
- PPTX를 PNG로 저장
- PPT를 PNG로 내보내기
- PPTX를 PNG로 내보내기
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하고, 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for .NET을 사용하여 프레젠테이션 슬라이드를 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX, ODP와 같은 형식의 프레젠테이션을 로드하고, 각 슬라이드를 렌더링한 다음 별도의 PNG 이미지로 저장할 수 있습니다.

아래 예제에서는 썸네일 렌더링, 스케일 팩터 설정, 픽셀 단위 출력 크기 지정, 그리고 그라디언트 렌더링 스타일 선택을 보여줍니다.

## **PowerPoint를 PNG로 변환**

프레젠테이션을 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스 로 로드하고 [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 컬렉션을 통해 슬라이드에 접근합니다. 예제에서는 매개변수 없이 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 를 호출하여 썸네일을 생성합니다. 그런 다음 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 를 [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) 와 함께 사용하여 렌더링된 각 슬라이드를 PNG 이미지로 저장합니다.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
매개변수가 없는 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 오버로드는 0.2 배율로 렌더링합니다. 예를 들어, 720 × 540 포인트 크기의 슬라이드는 144 × 108 픽셀 썸네일을 생성합니다. 출력 크기를 제어하려면 아래에 표시된 스케일 팩터가 있는 오버로드 또는 명시적인 이미지 크기를 사용하십시오.
{{% /alert %}}

## **맞춤 크기로 PowerPoint를 PNG로 변환**

렌더링된 크기를 제어하려면 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 에 가로 및 세로 스케일 팩터를 전달합니다. 이 예제에서는 두 팩터가 모두 2이므로 720 × 540 포인트 슬라이드가 1440 × 1080 픽셀 이미지가 됩니다. 동일한 스케일 팩터는 슬라이드의 가로세로 비율을 유지합니다. 각 이미지는 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 로 PNG 형식으로 저장됩니다.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **맞춤 크기로 PowerPoint를 PNG로 변환**

픽셀 단위 출력 크기를 지정하려면 스케일 팩터 대신 크기를 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 에 전달합니다. 이 예제에서는 모든 슬라이드를 960 × 720 픽셀로 렌더링하고 결과를 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 으로 저장합니다. 이미지가 늘어나는 것을 방지하려면 슬라이드의 가로세로 비율에 맞는 크기를 선택하십시오.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **그라디언트 렌더링 스타일 선택**

슬라이드에 그라디언트 채우기가 포함되어 있지만 내보낸 PNG의 전환이 PowerPoint에서 보는 것보다 더 밝거나 다르게 보인다고 가정합니다. [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) 속성을 [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) 에서 사용하여 그라디언트를 렌더링하는 방식을 선택할 수 있습니다.

[gradient-styles.pptx](gradient-styles.pptx) 을 다운로드하고 애플리케이션 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 두 개의 선형 그라디언트가 있습니다: 상단은 시안에서 오렌지로, 하단은 파랑에서 노랑으로 전환됩니다. 각 그라디언트는 0%와 100%에 두 개의 정지점을 가집니다.

다음 예제는 이 프레젠테이션을 로드하고 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 을 사용하여 두 모드 모두에서 동일한 첫 번째 슬라이드를 렌더링합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

| 기본 | PowerPointUI |
| --- | --- |
| ![기본으로 렌더링된 시안-오렌지 및 파랑-노랑 그라디언트](gradient-Default.png) | ![PowerPointUI로 렌더링된 동일한 그라디언트](gradient-PowerPointUI.png) |

이 예제에서 `Default`는 중간 색상이 더 밝게 나오고, `PowerPointUI`는 중간 색상이 더 어둡게 나옵니다. 차이는 그라디언트의 색상과 정지점에 따라 달라집니다.

표준 Aspose.Slides 출력이 필요에 맞는 경우 `Default` 를 선택하십시오. PowerPoint와 모양을 일치시키는 것이 우선일 경우 `PowerPointUI` 를 사용해 보세요. 두 출력물을 의도한 결과와 비교하십시오; 어느 모드도 보편적으로 더 좋다고 할 수 없습니다.

## **FAQ**

**전체 슬라이드가 아니라 차트나 그림과 같은 특정 모양만 내보내려면 어떻게 해야 하나요?**

Aspose.Slides는 [generating thumbnails for individual shapes](/slides/ko/net/create-shape-thumbnails/) 를 지원하여 모양을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환을 지원합니까?**

예. 각 스레드 또는 프로세스마다 별도의 프레젠테이션 인스턴스를 사용하십시오; [스레드 간에 단일 인스턴스를 공유하지 마십시오](/slides/ko/net/multithreading/).

**PNG로 내보낼 때 평가 버전 제한은 무엇입니까?**

평가 모드에서는 출력 이미지에 워터마크가 추가되고, 라이선스가 적용될 때까지 [다른 제한 사항](/slides/ko/net/licensing/) 이 적용됩니다.