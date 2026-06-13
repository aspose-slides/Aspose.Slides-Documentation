---
title: Aspose.Slides for Python의 멀티스레딩
linktitle: 멀티스레딩
type: docs
weight: 200
url: /ko/python-net/multithreading/
keywords:
- 멀티스레딩
- 여러 스레드
- 병렬 작업
- 슬라이드 변환
- 슬라이드 이미지 변환
- 파워포인트
- 오픈도큐먼트
- 프레젠테이션
- 파이썬
- Aspose.Slides
description: ".NET 멀티스레딩을 통한 Aspose.Slides for Python은 PowerPoint와 OpenDocument 처리 속도를 높입니다. 효율적인 프레젠테이션 워크플로를 위한 모범 사례를 살펴보세요."
---
## **소개**

프레젠테이션을 사용한 병렬 작업은 (구문 분석/로드/복제 제외) 가능하고 대부분의 경우 잘 진행되지만, 라이브러리를 여러 스레드에서 사용할 경우 잘못된 결과가 발생할 가능성이 약간 있습니다.

멀티스레드 환경에서 단일 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 사용하지 **않을** 것을 강력히 권장합니다. 이는 예측할 수 없는 오류나 쉽게 감지되지 않는 실패를 초래할 수 있기 때문입니다.

여러 스레드에서 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 로드, 저장 및/또는 복제하는 것은 **안전하지** 않습니다. 이러한 작업은 지원되지 **않습니다**. 이러한 작업을 수행해야 하는 경우, 여러 단일 스레드 프로세스를 사용해 작업을 병렬화해야 하며 각 프로세스는 자체 프레젠테이션 인스턴스를 사용해야 합니다.

## **프레젠테이션 슬라이드를 병렬로 이미지로 변환**

예를 들어, PowerPoint 프레젠테이션의 모든 슬라이드를 PNG 이미지로 병렬 변환하고 싶다고 가정해 보겠습니다. 여러 스레드에서 단일 `Presentation` 인스턴스를 사용하는 것은 안전하지 않으므로, 프레젠테이션 슬라이드를 별개의 프레젠테이션으로 분할하고 각 프레젠테이션을 별도 스레드에서 사용하여 슬라이드를 이미지로 병렬 변환합니다. 다음 코드 예제는 이를 수행하는 방법을 보여줍니다.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # 슬라이드 i를 별도의 프레젠테이션으로 추출합니다.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # 슬라이드를 이미지로 변환합니다.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# 모든 작업이 완료될 때까지 기다립니다.
for task in conversion_tasks:
    task.result()

del presentation
```

## **자주 묻는 질문**

**모든 스레드에서 라이선스 설정을 호출해야 하나요?**

아니요. 스레드가 시작되기 전에 프로세스/앱 도메인당 한 번만 수행하면 충분합니다. [라이선스 설정](/slides/ko/python-net/licensing/)이 동시에 호출될 수 있는 경우(예: 지연 초기화 중) 해당 호출을 동기화해야 합니다. 라이선스 설정 메서드 자체가 스레드 안전하지 않기 때문입니다.

**`Presentation` 또는 `Slide` 객체를 스레드 간에 전달할 수 있나요?**

스레드 간에 "실시간" 프레젠테이션 객체를 전달하는 것은 권장되지 않습니다. 스레드당 독립적인 인스턴스를 사용하거나 각 스레드용으로 별도의 프레젠테이션/슬라이드 컨테이너를 미리 생성하십시오. 이 방법은 단일 프레젠테이션 인스턴스를 스레드 간에 공유하지 말라는 일반 권고와 일치합니다.

**각 스레드가 자체 `Presentation` 인스턴스를 갖는 경우, PDF, HTML, 이미지와 같은 다양한 형식으로의 내보내기를 병렬화해도 안전한가요?**

네. 독립적인 인스턴스와 별도의 출력 경로를 사용하면 이러한 작업은 일반적으로 올바르게 병렬화됩니다. 공유 프레젠테이션 객체와 공유 I/O 스트림을 피하십시오.

**멀티스레딩 환경에서 전역 글꼴 설정(폴더, 대체)은 어떻게 해야 하나요?**

스레드를 시작하기 전에 모든 전역 글꼴 설정을 초기화하고 병렬 작업 중에는 변경하지 않으십시오. 이렇게 하면 공유 글꼴 리소스에 대한 경쟁 상황을 방지할 수 있습니다.