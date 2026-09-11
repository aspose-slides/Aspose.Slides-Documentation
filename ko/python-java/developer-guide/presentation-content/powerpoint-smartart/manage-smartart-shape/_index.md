---
title: Python을 사용하여 프레젠테이션에서 SmartArt 그래픽 관리
linktitle: SmartArt 그래픽
type: docs
weight: 20
url: /ko/python-java/manage-smartart-shape/
keywords:
- SmartArt 객체
- SmartArt 그래픽
- SmartArt 스타일
- SmartArt 색상
- SmartArt 만들기
- SmartArt 추가
- SmartArt 편집
- SmartArt 변경
- SmartArt 접근
- SmartArt 레이아웃 유형
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 PowerPoint SmartArt 생성, 편집 및 스타일링을 자동화하고, 간결한 코드 예제와 성능 중심 가이드를 제공합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 SmartArt 그래픽을 프로그래밍 방식으로 만들고 관리할 수 있습니다. 이 문서에서는 슬라이드에 SmartArt 도형을 추가하고, 기존 SmartArt 도형에 접근하며, 특정 레이아웃 유형으로 SmartArt를 찾고, SmartArt 스타일 또는 색상 스타일을 변경하여 시각적 모양을 업데이트하는 방법을 설명합니다.

예제에서는 프레젠테이션 슬라이드의 도형 컬렉션을 통해 SmartArt 도형을 작업하는 방법, 도형이 SmartArt인지 확인하고 해당 속성을 수정하거나 검사하는 방법을 보여줍니다.

## **SmartArt 도형 만들기**
Aspose.Slides for Python via Java는 SmartArt 도형을 만들기 위한 API를 제공합니다. 슬라이드에 SmartArt 도형을 만들려면 아래 단계에 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드를 가져옵니다.
1. [SmartArtLayoutType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartlayouttype/)을 지정하여 [SmartArt 도형 추가](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addSmartArt)합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # SmartArt 도형을 추가합니다.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # 프레젠테이션을 저장합니다.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**그림: 슬라이드에 추가된 SmartArt 도형**|

## **슬라이드에서 SmartArt 도형에 접근**
다음 예제는 프레젠테이션 슬라이드의 SmartArt 도형에 접근합니다. 슬라이드의 모든 도형을 반복하면서 해당 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 인스턴스인지 확인합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # 첫 번째 슬라이드의 모든 도형을 반복합니다.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **특정 레이아웃 유형을 가진 SmartArt 도형에 접근**
다음 예제는 [SmartArt.getLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/#getLayout) 메서드가 반환하는 특정 레이아웃 유형을 가진 SmartArt 도형에 접근합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. 첫 번째 슬라이드의 모든 도형을 반복합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 인스턴스인지 확인합니다.
1. SmartArt 도형이 지정된 레이아웃 유형을 가지고 있는지 확인하고 필요한 작업을 수행합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # 첫 번째 슬라이드의 모든 도형을 반복합니다.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt 레이아웃을 확인합니다.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **SmartArt 도형 스타일 변경**
이 예제는 SmartArt 도형의 빠른 스타일을 변경하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. 첫 번째 슬라이드의 모든 도형을 반복합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 인스턴스인지 확인합니다.
1. 지정된 스타일을 가진 SmartArt 도형을 찾습니다.
1. SmartArt 도형에 새 스타일을 설정합니다.
1. 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 첫 번째 슬라이드의 모든 도형을 반복합니다.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt 스타일을 확인하고 변경합니다.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**그림: 스타일이 변경된 SmartArt 도형**|

## **SmartArt 도형 색상 스타일 변경**
이 예제는 특정 색상 스타일을 가진 SmartArt 도형에 접근하여 해당 스타일을 변경합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. 첫 번째 슬라이드의 모든 도형을 반복합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 인스턴스인지 확인합니다.
1. 지정된 색상 스타일을 가진 SmartArt 도형을 찾습니다.
1. SmartArt 도형에 새 색상 스타일을 설정합니다.
1. 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 첫 번째 슬라이드의 모든 도형을 반복합니다.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt 스타일을 확인하고 변경합니다.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**그림: 색상 스타일이 변경된 SmartArt 도형**|

## **FAQ**

**SmartArt를 단일 개체로 애니메이션할 수 있나요?**

예. SmartArt는 도형이므로 다른 도형과 마찬가지로 애니메이션 API를 통해 [표준 애니메이션](/slides/ko/python-java/powerpoint-animation/) (입장, 퇴장, 강조, 움직임 경로) 등을 적용할 수 있습니다.

**슬라이드에서 내부 ID를 모를 경우 특정 SmartArt를 어떻게 찾을 수 있나요?**

대체 텍스트를 설정하고 해당 값을 사용하여 도형을 검색합니다—이는 대상 도형을 찾는 권장 방법입니다.([대체 텍스트]https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#setAlternativeText)

**SmartArt를 다른 도형과 그룹화할 수 있나요?**

예. SmartArt를 다른 도형(그림, 표 등)과 그룹화한 다음 [그룹을 조작](/slides/ko/python-java/group/)할 수 있습니다.

**특정 SmartArt의 이미지(예: 미리보기 또는 보고서용)를 어떻게 얻을 수 있나요?**

도형의 썸네일/이미지를 내보낼 수 있습니다; 라이브러리는 [개별 도형을 렌더링](/slides/ko/python-java/create-shape-thumbnails/)하여 래스터 파일(PNG/JPG/TIFF)로 저장할 수 있습니다.

**전체 프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지되나요?**

예. 렌더링 엔진은 [PDF 내보내기](/slides/ko/python-java/convert-powerpoint-to-pdf/) 시 높은 충실도를 목표로 하며, 다양한 품질 및 호환성 옵션을 제공합니다.