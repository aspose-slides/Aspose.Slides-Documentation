---
title: PowerPoint 슬라이드를 Python에서 PNG로 변환
linktitle: PowerPoint를 PNG로
type: docs
weight: 30
url: /ko/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint를 PNG로 변환
- 프레젠테이션을 PNG로 변환
- 슬라이드를 PNG로 변환
- PPT를 PNG로 변환
- PPTX를 PNG로 변환
- ODP를 PNG로 변환
- PowerPoint를 PNG로
- 프레젠테이션을 PNG로
- 슬라이드를 PNG로
- PPT를 PNG로
- PPTX를 PNG로
- ODP를 PNG로
- Python
- Aspose.Slides
description: "PowerPoint와 OpenDocument 프레젠테이션을 Aspose.Slides for Python via .NET으로 고품질 PNG 이미지로 빠르게 변환하여 정밀하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via .NET을 사용하여 프레젠테이션 슬라이드를 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX, ODP와 같은 형식의 프레젠테이션을 로드하고 각 슬라이드를 렌더링한 뒤 별도의 PNG 이미지로 저장할 수 있습니다.

아래 예제에서는 기본 배율로 렌더링하기, 배율을 높이기, 출력 크기를 픽셀 단위로 지정하기, 그리고 그라디언트 렌더링 스타일을 선택하기를 시연합니다.

## **PowerPoint를 PNG로 변환**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고 [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 컬렉션을 통해 슬라이드에 접근합니다. 예제에서는 매개변수 없이 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/)을 호출해 썸네일을 만들고, 이어서 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/)와 [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)을 사용해 각 렌더링된 슬라이드를 PNG 이미지로 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
매개변수가 없는 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 오버로드는 배율 0.2로 렌더링합니다. 예를 들어 720 × 540 포인트 크기의 슬라이드는 144 × 108 픽셀 썸네일을 생성합니다. 출력 크기를 제어하려면 아래와 같이 배율 인수나 명시적인 이미지 크기를 사용하는 오버로드를 이용하십시오.
{{% /alert %}}

## **PowerPoint를 PNG로 변환 (사용자 지정 배율)**

[Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/)에 가로 및 세로 배율 인수를 전달하여 렌더링 크기를 제어합니다. 이 예제에서는 두 배율이 모두 2이므로 720 × 540 포인트 슬라이드가 1440 × 1080 픽셀 이미지가 됩니다. 동일한 배율을 사용하면 슬라이드의 종횡비가 유지됩니다. 각 이미지는 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/)를 사용해 PNG 형식으로 저장됩니다.

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **PowerPoint를 PNG로 변환 (사용자 지정 크기)**

픽셀 단위로 출력 크기를 지정하려면 배율 인수 대신 크기를 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/)에 전달합니다. 이 예제에서는 모든 슬라이드를 960 × 720 픽셀로 렌더링하고 결과를 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/)로 저장합니다. 슬라이드의 종횡비와 일치하도록 크기를 선택하면 이미지가 늘어나지 않습니다.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **그라디언트 렌더링 스타일 선택**

슬라이드에 그라디언트 채우기가 포함되어 있지만 내보낸 PNG에서 전환이 PowerPoint에서 보는 것보다 더 밝거나 다르게 보인다고 가정해 보십시오. [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/)의 [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) 속성을 사용하여 그라디언트가 렌더링되는 방식을 선택할 수 있습니다.

[gradient-styles.pptx](gradient-styles.pptx)를 다운로드하여 애플리케이션의 작업 디렉터리에 배치합니다. 첫 번째 슬라이드에는 상단에 시안‑오렌지, 하단에 파랑‑노랑 선형 그라디언트가 각각 두 개의 정지점(0%와 100%)을 가지고 있습니다.

다음 예제는 이 프레젠테이션을 로드하고 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/)을 사용해 동일한 첫 번째 슬라이드를 두 모드 모두에서 렌더링합니다.

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

| Default | PowerPointUI |
| --- | --- |
| ![시안‑오렌지 및 파랑‑노랑 그라디언트가 Default 스타일로 렌더링됨](gradient-Default.png) | ![같은 그라디언트가 PowerPointUI 스타일로 렌더링됨](gradient-PowerPointUI.png) |

이 예제에서 `DEFAULT`는 중간 색상이 더 밝게 나오고, `POWER_POINT_UI`는 중간 색상이 더 어둡게 나옵니다. 차이는 그라디언트의 색상과 정지점에 따라 달라집니다.

표준 Aspose.Slides 출력이 요구에 맞는 경우 `DEFAULT`를 선택하십시오. PowerPoint와 외형을 맞추는 것이 우선인 경우 `POWER_POINT_UI`를 사용해 보십시오. 두 출력을 비교하여 원하는 결과와 일치하는지 확인하십시오; 어느 모드도 보편적으로 우수하다고 할 수 없습니다.

## **FAQ**

**특정 도형(예: 차트나 사진)을 전체 슬라이드 대신 내보내려면 어떻게 해야 하나요?**

Aspose.Slides는 [개별 도형에 대한 썸네일 생성](/slides/ko/python-net/create-shape-thumbnails/)을 지원하므로 도형을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환이 지원되나요?**

예. 각 스레드 또는 프로세스마다 별도의 프레젠테이션 인스턴스를 사용하십시오; [스레드 간에 단일 인스턴스를 공유하지 마십시오](/slides/ko/python-net/multithreading/).

**PNG로 내보낼 때 평가판 제한은 무엇인가요?**

평가 모드에서는 출력 이미지에 워터마크가 추가되고 [다른 제한](/slides/ko/python-net/licensing/)이 적용되며 라이선스를 적용할 때까지 지속됩니다.