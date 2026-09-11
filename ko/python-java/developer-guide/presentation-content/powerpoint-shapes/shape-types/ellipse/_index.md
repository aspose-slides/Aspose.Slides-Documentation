---
title: Python을 통해 Java에서 프레젠테이션에 타원 추가
linktitle: 타원
type: docs
weight: 30
url: /ko/python-java/ellipse/
keywords:
- 타원
- 도형
- 타원 추가
- 타원 만들기
- 타원 그리기
- 서식이 지정된 타원
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PPT 및 PPTX 프레젠테이션에서 타원 모양을 만들고, 서식 지정하고, 조작하는 방법을 배웁니다—Python 코드 예제가 포함되어 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 타원 모양을 추가하는 방법을 보여줍니다. 간단한 타원 만들기, 서식이 지정된 타원 만들기, 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 내용을 다룹니다. 또한 타원의 위치 및 크기 작업, 스태킹 순서 제어, 애니메이션 효과 적용과 같은 관련 질문도 다룹니다.

## **타원 만들기**

프레젠테이션의 선택된 슬라이드에 간단한 타원을 추가하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
- 인덱스로 슬라이드에 대한 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/) 객체의 [addAutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 타원을 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 예제는 첫 번째 슬라이드에 타원을 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 타원 도형을 추가합니다.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **서식이 지정된 타원 만들기**

슬라이드에 서식이 지정된 타원을 추가하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
- 인덱스로 슬라이드에 대한 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/) 객체의 [addAutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 타원을 추가합니다.
- 타원의 채우기 유형을 단색으로 설정합니다.
- [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 객체와 연결된 [FillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fillformat/) 객체에서 [getSolidFillColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fillformat/#getSolidFillColor) 메서드를 사용하여 타원의 채우기 색상을 설정합니다.
- 타원 외곽선의 색상을 설정합니다.
- 타원 외곽선의 두께를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 예제는 프레젠테이션의 첫 번째 슬라이드에 서식이 지정된 타원을 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 타원 도형을 추가합니다.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # 타원의 채우기 형식을 지정합니다.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # 타원의 윤곽선 형식을 지정합니다.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**슬라이드 단위에 대한 타원의 정확한 위치와 크기를 어떻게 설정합니까?**

좌표와 크기는 일반적으로 **포인트** 단위로 지정됩니다. 예측 가능한 결과를 위해 슬라이드 크기를 기준으로 계산하고, 필요한 밀리미터 또는 인치를 포인트로 변환한 후 값을 할당하십시오.

**다른 객체 위나 아래에 타원을 배치하려면 어떻게 해야 합니까(스태킹 순서 제어)?**

객체를 앞쪽으로 가져오거나 뒤쪽으로 보내서 그리기 순서를 조정합니다. 이를 통해 타원이 다른 객체와 겹치거나 아래에 있는 객체를 표시할 수 있습니다.

**타원의 등장 또는 강조에 애니메이션을 적용하려면 어떻게 해야 합니까?**

[적용](/slides/ko/python-java/shape-animation/) 입장, 강조 또는 퇴장 효과를 모양에 적용하고, 트리거와 타이밍을 구성하여 애니메이션이 언제 어떻게 재생되는지 조정합니다.