---
title: Python via Java에서 프레젠테이션 도형 썸네일 생성
linktitle: 도형 썸네일
type: docs
weight: 70
url: /ko/python-java/create-shape-thumbnails/
keywords:
- 도형 썸네일
- 도형 이미지
- 도형 렌더링
- 도형 렌더링
- 시각적 경계
- 도형 경계
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 슬라이드에서 고품질 도형 썸네일을 생성하고 – 프레젠테이션 썸네일을 손쉽게 만들고 내보냅니다."
---
## **소개**

Aspose.Slides for Python via Java은 각 페이지가 슬라이드에 해당하는 프레젠테이션 파일을 생성하는 데 사용할 수 있습니다. 슬라이드는 Microsoft PowerPoint로 프레젠테이션 파일을 열어 볼 수 있습니다. 그러나 개발자는 때때로 도형 이미지를 별도의 이미지 뷰어에서 확인해야 할 필요가 있습니다. 이러한 경우 Aspose.Slides for Python via Java은 슬라이드 도형의 썸네일 이미지를 생성하는 데 도움을 줍니다.

이 문서에서는 다양한 방법으로 도형 썸네일을 생성하는 방법을 설명합니다.

- 슬라이드 내부에서 도형 썸네일 생성
- 사용자 지정 크기로 슬라이드 도형의 썸네일 생성
- 도형 외형 경계 내에서 썸네일 생성

## **슬라이드에서 도형 썸네일 생성**
Aspose.Slides for Python via Java을 사용하여任意의 슬라이드에서 도형 썸네일을 생성하려면 다음을 수행합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스로 슬라이드에 대한 참조를 얻습니다.
3. 기본 배율로 참조된 슬라이드에 있는 도형의 [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage) 를 가져옵니다.
4. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 슬라이드에서 도형 썸네일을 생성하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = Presentation("Thumbnail.pptx")
try:
    # 전체 크기의 이미지를 생성합니다.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # 이미지를 PNG 형식으로 디스크에 저장합니다.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **사용자 정의 배율로 썸네일 생성**
Aspose.Slides for Python via Java을 사용하여 슬라이드 도형의 썸네일을 생성하려면 다음을 수행합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스로 슬라이드에 대한 참조를 얻습니다.
3. 사용자 정의 차원으로 참조된 슬라이드에 있는 도형의 [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage) 를 가져옵니다.
4. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 정의된 배율을 기반으로 도형 썸네일을 생성하는 방법을 보여줍니다.

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = Presentation("Thumbnail.pptx")
try:
    # 양쪽 방향으로 2배 비율로 스케일된 이미지를 생성합니다.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # 이미지를 PNG 형식으로 디스크에 저장합니다.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **경계 기반 도형 외형 썸네일 생성**
이 방법은 개발자가 도형 외형의 경계 내에서 썸네일을 생성하도록 합니다. 모든 도형 효과를 고려합니다. 생성된 도형 썸네일은 슬라이드 경계에 제한됩니다. 외형 경계 내에서 슬라이드 도형의 썸네일을 생성하려면 다음을 수행합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스로 슬라이드에 대한 참조를 얻습니다.
3. 외형 경계를 사용하여 참조된 슬라이드에 있는 도형의 썸네일 이미지를 가져옵니다.
4. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 위 단계에 기반합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = Presentation("Thumbnail.pptx")
try:
    # 전체 크기의 이미지를 생성합니다.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # 이미지를 PNG 형식으로 디스크에 저장합니다.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **도형의 실제 시각적 경계 가져오기**

[Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)의 프레임 속성—[getX](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getWidth), [getHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getHeight) 메서드—는 프레젠테이션 모델에 저장된 사각형을 설명합니다. 실제 렌더링되는 내용은 해당 프레임을 초과하거나 다른 축에 맞춰진 사각형을 차지할 수 있습니다. 회전, 외곽선, 화살촉, 텍스트 레이아웃 및 오버플로우, 생성된 SmartArt 기하학 및 기타 렌더링 효과가 차지하는 영역을 변경할 수 있습니다.

이미지를 만들지 않고 차지하는 영역을 계산하려면 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getVisualBounds) 를 사용하십시오. 이 메서드는 슬라이드 좌표계의 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 을 반환합니다. 반환된 사각형은 슬라이드에 클리핑되지 않으므로 내용이 슬라이드 원점을 초과하면 좌표가 음수가 될 수 있습니다.

다음 예제는 프레임 경계와 시각적 경계를 가져와 비교합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

동일한 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 을 사용하여 인접 도형을 왼쪽, 오른쪽, 위쪽 또는 아래쪽 가장자리와 정렬하거나, 생성된 레이아웃에 충분한 공간을 예약하거나, 허용된 영역 밖의 콘텐츠를 감지할 수 있습니다. 시각적 경계는 저장된 프레임이 전체 렌더링 결과를 나타내지 않을 수 있는 SmartArt, 텍스트 상자, 화살표, 이미지, 회전된 도형 및 그룹 도형에 특히 유용합니다.

레이아웃이나 검증을 위한 좌표가 필요하고 비트맵이 필요하지 않을 때는 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getVisualBounds) 를 사용하고, 도형을 렌더링해야 할 때는 [Shape.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage) 를 사용하십시오. [ShapeThumbnailBounds](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapethumbnailbounds/)에서 [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapethumbnailbounds/#Shape) 은 외곽선 설정을 포함한 도형 경계에서 이미지를 크기 조정하고, [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapethumbnailbounds/#Appearance) 은 도형 외형에서 이미지 크기를 조정하고 결과를 슬라이드 경계로 제한합니다. 반면에 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getVisualBounds) 은 계산된 사각형만 반환하고 슬라이드에 클리핑하지 않습니다.

## **FAQ**

**도형 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇입니까?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imageformat/) 등이며, 도형의 내용을 SVG 로 저장하여 [벡터 SVG 로 내보낼 수도](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#writeAsSvgToBytes) 있습니다.

**썸네일을 렌더링할 때 Shape 경계와 Appearance 경계의 차이는 무엇입니까?**

`Shape`는 도형의 기하학을 사용하고, `Appearance`는 [시각적 효과](/slides/ko/python-java/shape-effect/) (그림자, 발광 등)을 고려합니다.

**도형이 숨김 처리된 경우에도 썸네일이 생성됩니까?**

숨김 처리된 도형도 모델의 일부이며 렌더링될 수 있습니다. 숨김 플래그는 슬라이드 쇼 표시에는 영향을 주지만 도형 이미지 생성 자체를 방지하지는 않습니다.

**그룹 도형, 차트, SmartArt 및 기타 복합 객체가 지원됩니까?**

예. [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)로 표현되는 모든 객체(예: [GroupShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/), [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/))는 썸네일 또는 SVG 로 저장할 수 있습니다.

**시스템에 설치된 폰트가 텍스트 도형 썸네일 품질에 영향을 줍니까?**

예. 원하지 않는 폰트 대체와 텍스트 흐름 변형을 방지하려면 [필요한 폰트를 제공](/slides/ko/python-java/custom-font/)하거나 [폰트 대체를 구성](/slides/ko/python-java/font-substitution/)해야 합니다.