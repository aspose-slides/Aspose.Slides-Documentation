---
title: 파이썬에서 PowerPoint 슬라이드를 PNG로 변환
linktitle: PowerPoint를 PNG로
type: docs
weight: 30
url: /ko/python-java/convert-powerpoint-to-png/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PNG로
- 프레젠테이션을 PNG로
- 슬라이드를 PNG로
- PPT를 PNG로
- PPTX를 PNG로
- PPT를 PNG로 저장
- PPTX를 PNG로 저장
- PPT를 PNG로 내보내기
- PPTX를 PNG로 내보내기
- Python
- Java
- Aspose.Slides
description: "파이썬을 통해 Java에서 PowerPoint 슬라이드를 PNG 이미지로 변환합니다. 사용자 정의 스케일 또는 정확한 이미지 크기로 PPT, PPTX 및 ODP 프레젠테이션을 내보냅니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via Java를 사용하여 프레젠테이션 슬라이드를 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX, ODP와 같은 형식의 프레젠테이션을 로드하고, 각 슬라이드를 렌더링한 뒤 개별 PNG 이미지로 저장할 수 있습니다.

아래 예제에서는 기본 스케일로 렌더링하고, 스케일을 확대하며, 픽셀 단위의 출력 크기를 지정하고, 그라디언트 렌더링 스타일을 선택하는 방법을 보여줍니다.

## **PowerPoint를 PNG로 변환**

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고 [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) 컬렉션을 통해 슬라이드에 접근합니다. 예제에서는 매개변수 없이 [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) 메서드를 호출해 썸네일을 만든 뒤, [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-)에 [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png)을 지정하여 각 렌더링된 슬라이드를 PNG 이미지로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
매개변수가 없는 [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) 오버로드는 스케일 0.2로 렌더링합니다. 예를 들어 720 × 540 포인트 크기의 슬라이드는 144 × 108 픽셀 썸네일을 생성합니다. 출력 크기를 제어하려면 아래에 표시된 스케일 팩터 또는 명시적인 이미지 크기를 사용하는 오버로드를 이용하십시오.
{{% /alert %}}

## **맞춤 크기로 PowerPoint를 PNG로 변환**

[Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage)에 가로 및 세로 스케일 팩터를 전달하여 렌더링된 크기를 제어합니다. 이 예제에서는 두 팩터가 모두 2이므로 720 × 540 포인트 슬라이드가 1440 × 1080 픽셀 이미지로 변환됩니다. 동일한 스케일 팩터는 슬라이드의 종횡비를 유지합니다. 각 렌더링된 이미지는 PNG 형식으로 저장됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **사용자 지정 크기로 PowerPoint를 PNG로 변환**

픽셀 단위의 출력 크기를 지정하려면 스케일 팩터 대신 크기를 [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage)에 전달합니다. 이 예제는 모든 슬라이드를 960 × 720 픽셀로 렌더링하고 PNG 형식으로 저장합니다. 슬라이드의 종횡비와 일치하는 크기를 선택하면 이미지가 늘어나지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **그라디언트 렌더링 스타일 선택**

슬라이드에 그라디언트 채우기가 포함되어 있지만, 내보낸 PNG에서 전환이 PowerPoint에서 보는 것보다 밝거나 다르게 보이는 경우가 있습니다. 이때 [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/)이 상속한 [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) 메서드를 사용하여 그라디언트 렌더링 방식을 선택할 수 있습니다.

[gradient-styles.pptx](gradient-styles.pptx)를 다운로드하여 애플리케이션 작업 디렉터리에 넣습니다. 첫 슬라이드에는 두 개의 선형 그라디언트가 있습니다: 위쪽은 청록색에서 주황색으로, 아래쪽은 파랑에서 노랑으로 변합니다. 각 그라디언트는 0%와 100% 두 지점을 가집니다.

다음 예제는 해당 프레젠테이션을 로드하고 첫 슬라이드를 두 모드 모두에서 [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage)으로 렌더링합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

아래 이미지는 동일한 슬라이드에서 두 가지 그라디언트 스타일을 적용한 결과를 보여줍니다.

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

이 예제에서 `Default`는 중간 색상이 더 밝게 나타나고, `PowerPointUI`는 중간 색상이 더 어둡게 나타납니다. 차이는 그라디언트의 색상 및 스톱에 따라 달라집니다.

표준 Aspose.Slides 출력이 요구에 부합한다면 `Default`를 선택하십시오. PowerPoint와 외관을 맞추는 것이 우선이라면 `PowerPointUI`를 사용해 보세요. 두 출력 모두를 비교하여 원하는 결과에 가장 가까운 방식을 선택하십시오. 어느 모드가 보편적으로 우수하다고 할 수는 없습니다.

## **FAQ**

**특정 도형(예: 차트 또는 그림)을 전체 슬라이드가 아니라 별도로 내보내려면 어떻게 해야 하나요?**

Aspose.Slides는 [generating thumbnails for individual shapes](/slides/ko/python-java/create-shape-thumbnails/)을 지원하므로 도형을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환이 지원되나요?**

예. 각 스레드 또는 프로세스마다 별도의 프레젠테이션 인스턴스를 사용하십시오. [do not share a single instance across threads](/slides/ko/python-java/multithreading/)를 반드시 지켜야 합니다.

**PNG로 내보낼 때 평가판 제한은 무엇인가요?**

평가판 모드에서는 출력 이미지에 워터마크가 추가되고, 라이선스가 적용될 때까지 [other restrictions](/slides/ko/python-java/licensing/)이 적용됩니다.