---
title: Python에서 PowerPoint 슬라이드를 PNG로 변환
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
description: "Python을 통해 Java에서 PowerPoint 슬라이드를 PNG 이미지로 변환합니다. 맞춤 스케일 또는 정확한 이미지 크기로 PPT, PPTX 및 ODP 프레젠테이션을 내보냅니다."
---
## **개요**

이 문서는 Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션을 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX 및 ODP 파일을 로드하고, 각 슬라이드를 렌더링한 뒤 별도의 PNG 이미지로 저장할 수 있습니다.

예제에서는 스케일 팩터 또는 정확한 너비와 높이를 사용하여 출력 크기를 제어하는 방법도 보여줍니다. 각 예제는 필요에 따라 Java 가상 머신을 시작하고 사용 후 프레젠테이션 및 이미지 리소스를 해제합니다.

## **PowerPoint를 PNG로 변환**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 사용하여 입력 파일을 로드합니다.  
2. [Presentation.getSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlides)를 사용하여 슬라이드를 가져옵니다.  
3. [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)를 사용하여 각 슬라이드를 렌더링합니다.  
4. [ImageFormat.Png](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imageformat/#Png)으로 렌더링된 이미지를 저장하고 리소스를 해제합니다.

다음 Python 예제는 모든 슬라이드를 기본 크기로 내보냅니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **사용자 지정 스케일로 PowerPoint를 PNG로 변환**

[Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)에 수평 및 수직 스케일 팩터를 전달하여 출력 크기를 늘리거나 줄일 수 있습니다. 예를 들어, 720 × 540 포인트 슬라이드를 두 축 모두 스케일 팩터 2로 렌더링하면 1440 × 1080 픽셀 이미지가 생성됩니다.

동일한 스케일 팩터를 사용하면 슬라이드의 종횡비를 유지합니다. 서로 다른 팩터는 슬라이드를 수평 또는 수직으로 늘립니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **사용자 지정 크기로 PowerPoint를 PNG로 변환**

정확한 픽셀 크기를 지정하려면 원하는 너비와 높이를 가진 Java `Dimension` 객체를 [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)에 전달합니다. 왜곡을 방지하려면 원본 슬라이드와 동일한 종횡비의 크기를 선택하세요.

다음 예제는 각 슬라이드를 960 × 720 픽셀 PNG 이미지로 저장합니다:

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
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**전체 슬라이드가 아니라 차트나 그림과 같은 개별 도형을 내보낼 수 있나요?**

예. Aspose.Slides는 개별 도형에 대한 썸네일 생성([generating thumbnails for individual shapes](/slides/ko/python-java/create-shape-thumbnails/))을 지원하며, 이를 PNG 이미지로 저장할 수 있습니다.

**서버에서 프레젠테이션을 병렬로 변환할 수 있나요?**

각 스레드 또는 프로세스마다 별도의 Presentation 인스턴스를 사용하고, 파일이 덮어쓰여지지 않도록 고유한 출력 경로를 사용하세요. 스레드 간에 Presentation 인스턴스를 공유하지 마세요. 자세한 내용은 [Multithreading](/slides/ko/python-java/multithreading/)을 참조하세요.

**PNG로 내보낼 때 평가판 버전 제한은 무엇인가요?**

평가 모드에서는 출력 이미지에 워터마크가 추가되고 [other restrictions](/slides/ko/python-java/licensing/)가 적용됩니다. 라이선스를 적용하면 이러한 제한이 제거됩니다.