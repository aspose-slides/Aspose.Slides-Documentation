---
title: Python을 사용한 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/python-net/slide-size/
keywords:
- 슬라이드 크기
- 종횡비
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
- 크기 조정 안 함
- 맞춤 보장
- 최대화
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
descriptions: "Python과 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하는 방법을 배우고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화하세요."
---
## **소개**

Aspose.Slides는 PowerPoint 프레젠테이션의 슬라이드 크기와 종횡비를 조정하는 포괄적인 도구를 제공하여 인쇄 및 화면 표시 모두에 중요합니다.

인기 슬라이드 크기 및 비율:

- **Standard (4:3 Aspect Ratio)**: 오래된 화면 및 장치에 적합합니다.
- **Widescreen (16:9 Aspect Ratio)**: 최신 프로젝터 및 디스플레이에 권장됩니다.

프레젠테이션 전체에 일관성을 유지하십시오. 하나의 슬라이드 크기와 종횡비가 모든 슬라이드에 적용됩니다. 최적의 결과를 위해 프레젠테이션을 만들기 시작할 때 슬라이드 크기를 설정하여 복잡함을 방지하세요.

{{% alert color="primary" %}}
Aspose.Slides로 만든 프레젠테이션은 기본적으로 표준 4:3 종횡비를 사용합니다.
{{% /alert %}}

## **프레젠테이션에서 슬라이드 크기 변경**

이 샘플 코드는 Python에서 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **맞춤 슬라이드 크기 지정**

일반적인 슬라이드 크기(4:3 및 16:9)가 작업에 적합하지 않은 경우 특정하거나 고유한 슬라이드 크기를 사용할 수 있습니다. 예를 들어 프레젠테이션에서 맞춤 페이지 레이아웃으로 전체 크기의 슬라이드를 인쇄하거나 특정 화면 유형에 표시하려는 경우 맞춤 크기 설정을 사용하는 것이 도움이 될 수 있습니다.

이 샘플 코드는 Python에서 .NET을 통해 Aspose.Slides for Python을 사용하여 프레젠테이션에 맞춤 슬라이드 크기를 지정하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 용지 크기
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **크기 조정 후 슬라이드 콘텐츠 처리**

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지 또는 개체)이 왜곡될 수 있습니다. 기본적으로 개체는 새로운 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 그러나 프레젠테이션의 슬라이드 크기를 변경할 때 Aspose.Slides가 슬라이드의 콘텐츠를 처리하는 방식을 지정하는 설정을 선택할 수 있습니다.

목표에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- `DO_NOT_SCALE`

  슬라이드의 개체 크기를 조정하고 싶지 않은 경우 이 설정을 사용합니다.

- `ENSURE_FIT`

  더 작은 슬라이드 크기로 축소하면서 모든 개체가 슬라이드에 맞도록 Aspose.Slides가 자동으로 축소하도록 하려면 이 설정을 사용합니다(이렇게 하면 내용 손실을 방지할 수 있습니다).

- `MAXIMIZE`

  더 큰 슬라이드 크기로 확대하면서 개체를 새 슬라이드 크기에 비례하도록 확대하려면 이 설정을 사용합니다.

이 샘플 코드는 프레젠테이션 슬라이드 크기를 변경할 때 `MAXIMIZE` 설정을 사용하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**인치 이외의 단위(예: 포인트 또는 밀리미터)로 맞춤 슬라이드 크기를 설정할 수 있나요?**

네. Aspose.Slides는 내부적으로 포인트를 사용하며, 1포인트는 1/72인치와 같습니다. 밀리미터나 센티미터와 같은 다른 단위를 포인트로 변환한 뒤 변환된 값을 사용하여 슬라이드 너비와 높이를 정의할 수 있습니다.

**매우 큰 맞춤 슬라이드 크기가 렌더링 중 성능 및 메모리 사용량에 영향을 미치나요?**

네. 포인트 단위의 슬라이드 크기가 클수록 렌더링 스케일이 높아져 메모리 소비와 처리 시간이 증가합니다. 실용적인 슬라이드 크기를 목표로 하고 필요한 경우에만 렌더링 스케일을 조정하여 원하는 출력 품질을 얻으세요.

**비표준 슬라이드 크기를 정의한 뒤 크기가 다른 프레젠테이션의 슬라이드를 병합할 수 있나요?**

다른 슬라이드 크기를 가진 상태에서는 [프레젠테이션 병합](/slides/ko/python-net/merge-presentation/)을 할 수 없습니다 — 먼저 하나의 프레젠테이션을 다른 프레젠테이션과 크기를 맞게 조정하세요. 슬라이드 크기를 변경할 때는 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesizescaletype/) 옵션을 사용하여 기존 콘텐츠 처리 방식을 선택할 수 있습니다. 크기를 맞춘 후에는 서식을 유지하면서 슬라이드를 병합할 수 있습니다.

**개별 도형이나 슬라이드의 특정 영역에 대한 썸네일을 생성할 수 있나요? 그리고 새 슬라이드 크기를 반영하나요?**

네. Aspose.Slides는 [전체 슬라이드](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/)와 [선택한 도형](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_image/)에 대한 썸네일을 렌더링할 수 있습니다. 생성된 이미지는 현재 슬라이드 크기와 종횡비를 반영하여 일관된 프레이밍과 기하학을 보장합니다.