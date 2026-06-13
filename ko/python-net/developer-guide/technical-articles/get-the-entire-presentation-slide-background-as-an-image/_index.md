---
title: 프레젠테이션에서 전체 슬라이드 배경을 이미지로 추출
linktitle: 전체 슬라이드 배경
type: docs
weight: 95
url: /ko/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 슬라이드
- 배경
- 슬라이드 배경
- 최종 배경
- 배경을 이미지로
- PowerPoint
- OpenDocument
- 프레젠테이션
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 .NET을 통해 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 전체 슬라이드 배경을 이미지로 추출하여 시각적 작업 흐름을 간소화합니다."
---
## **개요**

PowerPoint 프레젠테이션에서 슬라이드 배경은 슬라이드 배경 이미지, 프레젠테이션 테마, 색 구성표, 마스터 슬라이드 또는 레이아웃 슬라이드에 배치된 객체 등 여러 요소로 구성될 수 있습니다.

이 문서에서는 Aspose.Slides를 사용하여 전체 슬라이드 배경을 이미지로 추출하는 방법을 보여줍니다. 이 작업에 대한 단일 메서드가 없으므로, 선택한 슬라이드를 임시 프레젠테이션에 복제하고, 슬라이드의 도형을 제거한 다음, 결과 슬라이드 배경을 이미지로 변환하는 접근 방식을 사용합니다.

## **전체 슬라이드 배경 가져오기**

Aspose.Slides for Python은 전체 프레젠테이션 슬라이드 배경을 이미지로 추출하는 간단한 메서드를 제공하지 않지만, 아래 단계를 따라 수행할 수 있습니다:
1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스로 로드합니다.
2. 프레젠테이션에서 슬라이드 크기를 가져옵니다.
3. 슬라이드를 선택합니다.
4. 임시 프레젠테이션을 생성합니다.
5. 임시 프레젠테이션에 동일한 슬라이드 크기를 설정합니다.
6. 선택한 슬라이드를 임시 프레젠테이션에 복제합니다.
7. 복제된 슬라이드에서 도형을 삭제합니다.
8. 복제된 슬라이드를 이미지로 변환합니다.

다음 코드 예제는 전체 프레젠테이션 슬라이드 배경을 이미지로 추출합니다.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **FAQ**

**마스터 슬라이드의 복잡한 그라디언트, 텍스처 또는 그림 채우기가 결과 배경 이미지에 보존됩니까?**

예. Aspose.Slides는 슬라이드, 레이아웃 또는 마스터에 정의된 그라디언트, 그림 및 텍스처 채우기를 렌더링합니다. 상속된 마스터에서 모양을 분리해야 하는 경우, 내보내기 전에 현재 슬라이드에 [고유 배경 설정](/slides/ko/python-net/presentation-background/)을 적용하십시오.

**저장하기 전에 결과 배경 이미지에 워터마크를 추가할 수 있나요?**

예. 작업용 [슬라이드 복사본](/slides/ko/python-net/clone-slides/)에 [워터마크 추가](/slides/ko/python-net/watermark/) 도형이나 이미지를 (다른 콘텐츠 뒤에 배치해서) 추가한 다음 내보낼 수 있습니다. 이렇게 하면 워터마크가 포함된 배경 이미지를 생성할 수 있습니다.

**기존 슬라이드와 연결하지 않고 특정 레이아웃 또는 마스터의 배경을 가져올 수 있나요?**

예. 원하는 마스터 또는 레이아웃에 접근하여 필요한 크기의 [임시 슬라이드](/slides/ko/python-net/clone-slides/)에 적용한 뒤 해당 슬라이드를 내보내면 해당 레이아웃이나 마스터에서 파생된 배경을 얻을 수 있습니다.

**이미지 내보내기에 영향을 미치는 라이선스 제한이 있나요?**

렌더링 기능은 [유효한 라이선스](/slides/ko/python-net/licensing/)가 있으면 완전히 사용할 수 있습니다. 평가 모드에서는 워터마크와 같은 제한이 출력에 포함될 수 있습니다. 배치 내보내기를 실행하기 전에 프로세스당 한 번 라이선스를 활성화하십시오.