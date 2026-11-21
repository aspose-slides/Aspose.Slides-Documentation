---
title: Python을 사용하여 프레젠테이션에서 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/python-net/slide-size/
keywords:
- 슬라이드 크기
- 가로 세로 비율
- 표준
- 와이드스크린
- 4:3
- 16:9
- 슬라이드 크기 설정
- 슬라이드 크기 변경
- 맞춤 슬라이드 크기
- 특수 슬라이드 크기
- 고유 슬라이드 크기
- 전체 크기 슬라이드
- 스크린 유형
- 축소 안 함
- 맞게 맞추기
- 최대화
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python과 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하는 방법을 배우고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화하십시오."
---
## **소개**

Aspose.Slides는 PowerPoint 프레젠테이션에서 슬라이드 크기와 가로 세로 비율을 조정하는 포괄적인 도구를 제공하며, 이는 인쇄와 화면 표시 모두에 중요합니다.  

일반적인 슬라이드 크기 및 비율:

- **표준 (4:3 가로 세로 비율)**: 오래된 화면 및 장치에 이상적입니다.
- **와이드스크린 (16:9 가로 세로 비율)**: 최신 프로젝터와 디스플레이에 권장됩니다.

프레젠테이션 전체에 일관성을 유지하려면 모든 슬라이드에 동일한 슬라이드 크기와 가로 세로 비율이 적용됩니다. 최적의 결과를 위해 프레젠테이션 생성 초기에 슬라이드 크기를 설정하여 문제를 방지하십시오.

{{% alert color="info" title="Note" %}}
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 가로 세로 비율을 사용합니다.
{{% /alert %}}

노트 및 유인물 페이지는 일반 슬라이드와 별도의 크기를 가집니다. 크기와 방향을 변경하려면 [Notes Page Size](/slides/ko/python-net/notes-size/)를 참조하십시오.

## **프레젠테이션에서 슬라이드 크기 변경**

다음 샘플 코드는 Aspose.Slides를 사용하여 Python에서 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **맞춤 슬라이드 크기 지정**

일반적인 슬라이드 크기(4:3 및 16:9)가 작업에 적합하지 않다면 특정하거나 고유한 슬라이드 크기를 사용할 수 있습니다. 예를 들어 프레젠테이션을 맞춤 페이지 레이아웃에 전체 크기로 인쇄하거나 특정 화면 유형에 표시하려는 경우 맞춤 크기 설정을 사용하면 도움이 됩니다.

다음 샘플 코드는 .NET을 통해 Python용 Aspose.Slides를 사용하여 프레젠테이션에 맞춤 슬라이드 크기를 지정하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 용지 크기
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **크기 조정 후 슬라이드 내용 처리**

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지나 개체)이 왜곡될 수 있습니다. 기본적으로 개체는 새 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 그러나 프레젠테이션의 슬라이드 크기를 변경할 때 Aspose.Slides가 슬라이드의 내용을 처리하는 방식을 결정하는 설정을 지정할 수 있습니다.

목표에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- `DO_NOT_SCALE`

  슬라이드의 개체를 크기 조정하고 싶지 않다면 이 설정을 사용하십시오.

- `ENSURE_FIT`

  작은 슬라이드 크기로 축소하고 Aspose.Slides가 슬라이드의 모든 개체를 축소하여 슬라이드에 모두 맞추도록 하려면(이렇게 하면 내용 손실을 방지) 이 설정을 사용하십시오.

- `MAXIMIZE`

  큰 슬라이드 크기로 확대하고 Aspose.Slides가 슬라이드 개체를 확대하여 새 슬라이드 크기에 비례하도록 하려면 이 설정을 사용하십시오.

다음 샘플 코드는 프레젠테이션 슬라이드 크기를 변경할 때 `MAXIMIZE` 설정을 사용하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**인치를 제외한 다른 단위(예: 포인트 또는 밀리미터)로 맞춤 슬라이드 크기를 설정할 수 있나요?**

예. Aspose.Slides는 내부적으로 포인트를 사용하며, 1 포인트는 1/72 인치에 해당합니다. 밀리미터나 센티미터와 같은 모든 단위를 포인트로 변환한 후 변환된 값을 사용하여 슬라이드 너비와 높이를 정의할 수 있습니다.

**매우 큰 맞춤 슬라이드 크기가 렌더링 시 성능 및 메모리 사용량에 영향을 미칩니까?**

예. 큰 슬라이드 크기(포인트 단위)에 높은 렌더링 스케일을 적용하면 메모리 사용량이 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 원하는 출력 품질을 얻기 위해 필요할 때만 렌더링 스케일을 조정하십시오.

**비표준 슬라이드 크기를 정의한 후 크기가 다른 프레젠테이션의 슬라이드를 병합할 수 있나요?**

다른 슬라이드 크기를 가진 상태에서는 [merge presentations](/slides/ko/python-net/merge-presentation/)을 할 수 없습니다 — 먼저 하나의 프레젠테이션 크기를 다른 프레젠테이션에 맞게 조정하십시오. 슬라이드 크기를 변경할 때는 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesizescaletype/) 옵션을 통해 기존 내용 처리 방식을 선택할 수 있습니다. 크기를 맞춘 후에는 서식을 유지하면서 슬라이드를 병합할 수 있습니다.

**슬라이드의 개별 도형이나 특정 영역에 대한 썸네일을 생성할 수 있으며, 새로운 슬라이드 크기를 반영합니까?**

예. Aspose.Slides는 [entire slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/)와 [selected shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_image/) 모두에 대한 썸네일을 렌더링할 수 있습니다. 생성된 이미지는 현재 슬라이드 크기와 가로 세로 비율을 반영하여 일관된 프레이밍과 기하학을 보장합니다.