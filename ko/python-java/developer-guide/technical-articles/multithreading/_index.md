---
title: Python via Java용 Aspose.Slides에서 멀티스레딩
linktitle: 멀티스레딩
type: docs
weight: 310
url: /ko/python-java/multithreading/
keywords:
- 멀티스레딩
- 복수 스레드
- 병렬 작업
- 슬라이드 변환
- 슬라이드 이미지 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java 멀티스레딩은 PowerPoint 및 OpenDocument 처리를 향상시킵니다. 효율적인 프레젠테이션 워크플로를 위한 모범 사례를 확인하십시오."
---
## **소개**

프레젠테이션을 사용한 병렬 작업은 (구문 분석, 로드 및 복제 제외) 가능하고 보통 잘 동작하지만, 라이브러리를 여러 스레드에서 사용할 경우 결과가 올바르지 않을 가능성이 조금 있습니다.

멀티스레드 환경에서 단일 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 사용하지 **않을 것을** 강력히 권장합니다. 이렇게 하면 예측할 수 없는 오류나 쉽게 감지되지 않는 실패가 발생할 수 있습니다.

여러 스레드에서 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 로드, 저장 및/또는 복제하는 것은 **안전하지** 않습니다. 이러한 작업은 **지원되지** 않습니다. 이러한 작업을 수행해야 하는 경우, 여러 단일 스레드 프로세스를 사용해 작업을 병렬화해야 하며 각 프로세스는 자체 프레젠테이션 인스턴스를 사용해야 합니다.

## **프레젠테이션 슬라이드를 병렬로 이미지로 변환**

PowerPoint 프레젠테이션의 모든 슬라이드를 병렬로 PNG 이미지로 변환하고 싶다고 가정해 보겠습니다. 여러 스레드에서 단일 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 사용하는 것은 안전하지 않으므로, 프레젠테이션 슬라이드를 별개의 프레젠테이션으로 나누고 각 프레젠테이션을 별도 스레드에서 사용해 슬라이드를 이미지로 병렬 변환합니다. 다음 코드 예제가 이를 수행하는 방법을 보여줍니다.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # 슬라이드를 별도의 프레젠테이션으로 추출합니다.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # 슬라이드를 별도 작업에서 이미지로 변환합니다.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # 모든 작업이 완료될 때까지 기다립니다.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **FAQ**

**각 스레드에서 라이선스 설정을 호출해야 하나요?**

아니오. 스레드가 시작되기 전에 프로세스당 한 번만 수행하면 충분합니다. [license setup](/slides/ko/python-java/licensing/)이 동시에 호출될 수 있는 경우(예: 지연 초기화 시), 해당 호출을 동기화해야 합니다. 라이선스 설정 메서드 자체가 스레드 안전하지 않기 때문입니다.

**스레드 간에 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 또는 [Slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/) 객체를 전달할 수 있나요?**

"실시간" 프레젠테이션 객체를 스레드 간에 전달하는 것은 권장되지 않습니다. 스레드당 독립적인 인스턴스를 사용하거나 각 스레드에 대해 별도의 프레젠테이션 또는 슬라이드 컨테이너를 미리 생성하십시오. 이 접근 방식은 스레드 간에 단일 프레젠테이션 인스턴스를 공유하지 말라는 일반 권고와 일치합니다.

**각 스레드가 자체 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 보유한다면 서로 다른 형식(PDF, HTML, 이미지)으로의 내보내기를 병렬화해도 안전한가요?**

예. 독립적인 인스턴스와 별도의 출력 경로를 사용하면 이러한 작업은 일반적으로 올바르게 병렬화됩니다. 공유 프레젠테이션 객체나 공유 I/O 스트림은 사용하지 않도록 하세요.

**멀티스레딩에서 전역 글꼴 설정(폴더, 치환)을 어떻게 처리해야 하나요?**

스레드를 시작하기 전에 모든 전역 [font settings](/slides/ko/python-java/powerpoint-fonts/)를 초기화하고, 병렬 작업 중에는 변경하지 마세요. 이렇게 하면 공유 글꼴 리소스에 대한 경쟁 상황을 방지할 수 있습니다.