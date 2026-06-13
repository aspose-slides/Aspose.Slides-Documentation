---
title: Python에서 PowerPoint 슬라이드를 PNG로 변환
linktitle: 슬라이드 PNG
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
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하고, 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

Aspose.Slides for Python via .NET을 사용하면 PowerPoint 프레젠테이션을 PNG로 변환하는 작업이 간단합니다. 프레젠테이션을 로드하고, 슬라이드를 순회하며, 각 슬라이드를 래스터 이미지로 렌더링하고, 결과를 PNG 파일로 저장합니다. 이는 슬라이드 미리보기를 생성하거나, 웹 페이지에 슬라이드를 삽입하거나, 후속 처리용 정적 자산을 만드는 데 이상적입니다.

## **슬라이드를 PNG로 변환**

이 섹션에서는 Aspose.Slides for Python via .NET을 사용하여 PowerPoint 프레젠테이션을 PNG 이미지로 변환하는 가장 간단한 예제를 보여줍니다.

다음 절차를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. `Presentation.slides` 컬렉션에서 슬라이드를 가져옵니다 (자세한 내용은 [Slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/) 클래스를 참조하십시오).
3. `Slide.get_image` 메서드를 사용하여 슬라이드의 썸네일을 생성합니다.
4. `Presentation.save` 메서드를 사용하여 슬라이드 썸네일을 PNG 형식으로 저장합니다.

다음 Python 코드는 PowerPoint 프레젠테이션을 PNG로 변환하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **맞춤 차원으로 슬라이드를 PNG로 변환**

맞춤 스케일로 슬라이드를 PNG로 내보내려면 `Slide.get_image` 메서드에 수평 및 수직 스케일 팩터를 전달합니다. 이 배율은 슬라이드 원본 크기에 비례하여 출력 크기를 조정합니다—예를 들어 `2.0` 은 너비와 높이를 모두 두 배로 확대합니다. 가로 세로 비율을 유지하려면 `scale_x`와 `scale_y`에 동일한 값을 사용하십시오.

다음 Python 코드는 위 작업을 시연합니다:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **맞춤 크기로 슬라이드를 PNG로 변환**

특정 크기로 PNG 파일을 생성하려면 원하는 `width`와 `height` 값을 전달합니다. 아래 코드는 이미지 크기를 지정하여 PowerPoint를 PNG로 변환하는 방법을 보여줍니다:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
Aspose의 무료 **PowerPoint-to-PNG 변환기**를 사용해 보실 수 있습니다—[PPTX to PNG](https://products.aspose.app/slides/ko/conversion/pptx-to-png) 및 [PPT to PNG](https://products.aspose.app/slides/ko/conversion/ppt-to-png). 이 도구들은 이 페이지에 설명된 프로세스를 실시간으로 구현한 예시를 제공합니다.
{{% /alert %}}

## **FAQ**

**전체 슬라이드가 아니라 특정 도형(예: 차트 또는 그림)만 내보내려면 어떻게 해야 하나요?**

Aspose.Slides는 [개별 도형에 대한 썸네일 생성](/slides/ko/python-net/create-shape-thumbnails/)을 지원합니다; 도형을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환을 지원하나요?**

예, 하지만 [공유하지 않음](/slides/ko/python-net/multithreading/) 단일 프레젠테이션 인스턴스를 스레드 간에 사용하지 마십시오. 스레드 또는 프로세스당 별도의 인스턴스를 사용하십시오.

**PNG로 내보낼 때 평가판 버전의 제한은 무엇인가요?**

평가 모드에서는 출력 이미지에 워터마크가 추가되고, 라이선스가 적용될 때까지 [기타 제한](/slides/ko/python-net/licensing/)이 적용됩니다.