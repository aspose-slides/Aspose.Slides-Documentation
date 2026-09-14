---
title: Python을 통해 Java에서 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/python-java/slide-size/
keywords:
- 슬라이드 크기
- 가로세로 비율
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
- 화면 유형
- 크기 조정 안 함
- 맞춤 보장
- 최대화
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python을 통해 Java와 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하는 방법을 배우고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화합니다."
---
## **소개**

Aspose.Slides는 인쇄와 화면 표시 모두에 중요한 PowerPoint 프레젠테이션의 슬라이드 크기와 가로세로 비율을 조정하기 위한 포괄적인 도구를 제공합니다.

주요 슬라이드 크기 및 비율:

- **표준 (4:3 가로세로 비율)**: 구형 화면 및 장치에 이상적입니다.
- **와이드스크린 (16:9 가로세로 비율)**: 최신 프로젝터 및 디스플레이에 권장됩니다.

프레젠테이션 전반에 일관성을 유지하십시오. 단일 슬라이드 크기와 가로세로 비율이 모든 슬라이드에 적용됩니다. 최적의 결과를 위해 프레젠테이션 생성 초기에 슬라이드 크기를 설정하여 복잡함을 방지하십시오.

{{% alert color="info" title="Note" %}}
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 비율을 사용합니다.
{{% /alert %}}

## **프레젠테이션에서 슬라이드 크기 변경**

이 샘플 코드는 Aspose.Slides를 사용하여 Java를 통해 Python에서 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **프레젠테이션에서 사용자 지정 슬라이드 크기 지정**

일반적인 슬라이드 크기(4:3 및 16:9)가 작업에 적합하지 않은 경우 특정하거나 고유한 슬라이드 크기를 사용할 수 있습니다. 예를 들어 프레젠테이션을 사용자 정의 페이지 레이아웃으로 전체 크기 슬라이드를 인쇄하거나 특정 화면 유형에 표시하려는 경우, 사용자 지정 크기 설정을 활용하면 유리합니다.

이 샘플 코드는 Java를 통해 Python에서 Aspose.Slides를 사용하여 프레젠테이션에 사용자 지정 슬라이드 크기를 지정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **크기 조정 후 슬라이드 콘텐츠 처리**

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지 또는 개체)이 왜곡될 수 있습니다. 기본적으로 개체는 새로운 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 그러나 프레젠테이션의 슬라이드 크기를 변경할 때 Aspose.Slides가 슬라이드의 콘텐츠를 처리하는 방식을 결정하는 설정을 지정할 수 있습니다.

목표에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- [DoNotScale](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  슬라이드의 객체가 크기 조정되지 않도록 하려면 이 설정을 사용하십시오.

- [EnsureFit](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  작은 슬라이드 크기로 축소하면서 모든 객체가 슬라이드에 맞도록 Aspose.Slides가 축소하도록 하려면 이 설정을 사용하십시오.

- [Maximize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesizescaletype/#Maximize)

  큰 슬라이드 크기로 확대하면서 객체를 새로운 슬라이드 크기에 비례하도록 확대하려면 이 설정을 사용하십시오.

이 샘플 코드는 프레젠테이션 슬라이드 크기를 변경할 때 [Maximize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesizescaletype/#Maximize) 설정을 사용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **FAQ**

**인치를 제외한 단위(예: 포인트 또는 밀리미터)로 사용자 지정 슬라이드 크기를 설정할 수 있나요?**

예. Aspose.Slides는 내부적으로 포인트를 사용하며, 1 포인트는 1/72인치에 해당합니다. 밀리미터나 센티미터와 같은 단위를 포인트로 변환한 뒤 슬라이드 너비와 높이에 사용할 수 있습니다.

**매우 큰 사용자 지정 슬라이드 크기가 렌더링 중 성능 및 메모리 사용에 영향을 미칩니까?**

예. 포인트 단위의 슬라이드 크기가 커지고 렌더링 스케일이 높아지면 메모리 사용량이 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 원하는 출력 품질을 얻을 때만 렌더링 스케일을 조정하십시오.

**하나의 비표준 슬라이드 크기를 정의한 뒤 다른 크기의 프레젠테이션 슬라이드를 병합할 수 있나요?**

다른 슬라이드 크기를 가진 프레젠테이션은 [프레젠테이션 병합](/slides/ko/python-java/merge-presentation/)할 수 없습니다—먼저 한 프레젠테이션을 다른 프레젠테이션에 맞게 크기를 조정해야 합니다. 슬라이드 크기를 변경할 때는 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesizescaletype/) 옵션을 사용해 기존 콘텐츠 처리 방식을 선택할 수 있습니다. 크기를 맞춘 후에는 형식을 유지하면서 슬라이드를 병합할 수 있습니다.

**슬라이드의 개별 도형이나 특정 영역에 대한 썸네일을 생성할 수 있으며, 새로운 슬라이드 크기를 반영하나요?**

예. Aspose.Slides는 [전체 슬라이드](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)와 [선택된 도형](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage) 모두에 대한 썸네일을 렌더링할 수 있습니다. 결과 이미지에는 현재 슬라이드 크기와 가로세로 비율이 반영되어 일관된 프레이밍과 기하학을 유지합니다.