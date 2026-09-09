---
title: Python via Java를 사용한 프레젠테이션 텍스트 상자 관리
linktitle: 텍스트 상자 관리
type: docs
weight: 20
url: /ko/python-java/manage-textbox/
keywords:
- 텍스트 상자
- 텍스트 프레임
- 텍스트 추가
- 텍스트 업데이트
- 텍스트 상자 생성
- 텍스트 상자 확인
- 텍스트 열 추가
- 하이퍼링크 추가
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 상자를 생성, 식별, 서식 지정 및 업데이트합니다."
---
## **소개**

Aspose.Slides for Python via Java에서 슬라이드 텍스트는 도형에 속하는 텍스트 프레임에 저장됩니다. [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 클래스는 가장 일반적인 텍스트가 포함된 도형을 나타내며 해당 텍스트를 [AutoShape.getTextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/#getTextFrame) 메서드를 통해 노출합니다.

{{% alert color="info" title="Note" %}}

모든 자동 도형은 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)을 상속하지만, 모든 도형이 자동 도형이거나 텍스트 프레임을 지원하는 것은 아닙니다. 기존 프레젠테이션을 처리할 때 텍스트에 접근하기 전에 도형이 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 인스턴스인지 확인하십시오.

{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

텍스트 상자를 만들려면 슬라이드에 자동 도형을 추가하고, 텍스트 프레임에 텍스트를 추가한 다음 프레젠테이션을 저장합니다. 다음 예제는 직사각형 텍스트 상자를 생성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addAutoShape)에 전달되는 좌표와 크기는 포인트 단위로 측정됩니다. [AutoShape.addTextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/#addTextFrame)은 제공된 텍스트로 텍스트 프레임을 초기화합니다.

## **텍스트 상자 도형 확인**

[AutoShape.isTextBox](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/#isTextBox) 메서드를 사용하여 자동 도형이 텍스트 상자로 취급되는지 확인합니다. 프레젠테이션에 텍스트가 포함된 자동 도형과 순수 그래픽 자동 도형이 모두 포함된 경우에 유용합니다.

![텍스트 상자와 도형](istextbox.png)

다음 예제는 프레젠테이션의 모든 자동 도형을 검사합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

새로 추가된 자동 도형은 비어 있지 않은 텍스트를 포함할 때까지 텍스트 상자로 간주되지 않습니다. 해당 텍스트는 [AutoShape.addTextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/#addTextFrame) 또는 [TextFrame.setText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#setText)으로 제공할 수 있습니다. 빈 문자열을 추가하거나 할당하면 [AutoShape.isTextBox](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/#isTextBox)은 `False`를 반환합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

첫 번째 두 호출은 `True`를 출력하고, 마지막 두 호출은 `False`를 출력합니다.

## **텍스트 프레임을 소유하는 도형 찾기**

일반 텍스트 처리 코드는 어느 프레젠테이션 객체에 포함되어 있는지 모르는 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)을 받을 수 있습니다. 읽기 전용 [TextFrame.getParentShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getParentShape) 메서드를 사용하여 소유자인 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)으로 돌아갈 수 있습니다.

자동 도형이나 다른 텍스트가 포함된 도형이 소유한 텍스트 프레임의 경우, [TextFrame.getParentShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getParentShape)은 소유자를 반환하고 [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getParentCell)은 `None`을 반환합니다. 접근하기 전에 반환된 값을 확인하십시오. 도형과 테이블 셀 소유자를 모두 식별하려면 SmartArt 노드와 연결된 도형을 포함하여 [Search and Replace Text](/slides/ko/python-java/search-and-replace-text/)를 참조하십시오.

## **텍스트 상자에 열 추가**

[TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setColumnCount) 메서드는 텍스트 프레임을 열로 나누고, [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setColumnSpacing) 메서드는 열 사이의 간격을 포인트 단위로 설정합니다. 두 설정 모두 [TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/)에 속하며 기존 텍스트 상자의 텍스트 프레임을 통해 변경할 수 있습니다. 텍스트는 같은 도형 내에서 열 사이에 재배치되며, 다른 도형으로 이어지지는 않습니다.

다음 예제는 열 간격이 10포인트인 3열 텍스트 상자를 만들고, 프레젠테이션을 저장한 뒤 출력 파일에서 저장된 설정을 다시 읽어옵니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **개별 열에서 텍스트 추출**

[TextFrame.splitTextByColumns](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#splitTextByColumns) 메서드를 사용하여 기존 텍스트 프레임에서 각 시각적 열에 할당된 텍스트를 가져올 수 있습니다. 이 메서드는 열 기반 읽기 순서대로 각 열에 대한 문자열 하나씩을 반환합니다. 단일 열 텍스트 프레임은 요소가 하나인 배열을 반환하고, 빈 열은 빈 문자열로 표시됩니다. 반환된 문자열에는 일반 텍스트만 포함되며, 구간 수준 서식은 보존되지 않습니다.

이는 다음과 같은 경우에 유용합니다:

- 열 기반 읽기 순서를 유지하면서 텍스트를 추출합니다.
- 다중 열 슬라이드의 내용을 인덱싱하거나 비교합니다.
- 각 열을 별도의 파일, 데이터베이스 필드 또는 기타 목적지에 내보냅니다.
- [TextFrameFormat.setColumnCount]로 열 수를, [TextFrameFormat.setColumnSpacing]으로 간격을, 글꼴이나 텍스트 프레임 크기를 변경한 후 텍스트가 재배치되는 방식을 검사합니다.

이 메서드는 현재 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)에 배분된 텍스트만 보고하며, 별도의 도형이나 텍스트 상자 사이에 텍스트를 자동으로 흐르게 하지 않습니다. 열 배분은 사용 가능한 글꼴 및 기타 텍스트 레이아웃 설정에 따라 달라질 수 있으므로 일관된 결과가 필요할 때는 해당 글꼴이 확보되어 있는지 확인하십시오.

다음 예제는 프레젠테이션을 로드하고, 텍스트 프레임이 있는 첫 번째 다중 열 자동 도형을 찾아 구성된 열 수를 읽은 뒤 각 열의 텍스트를 별도 파일에 씁니다. 텍스트 프레임을 제공하지 않는 도형은 건너뛰어집니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **텍스트 업데이트**

프레젠테이션 전체의 텍스트를 업데이트하려면 슬라이드와 도형을 순회하며 자동 도형을 선택한 뒤 텍스트 구간을 편집합니다. 구간 수준에서 작업하면 텍스트와 문자 서식을 모두 변경할 수 있습니다.

다음 예제는 자동 도형 텍스트에서 `years`를 `months`로 모두 교체하고, 영향을 받은 구간을 굵게 만듭니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 순회는 자동 도형의 텍스트만 업데이트합니다. 표, 차트, SmartArt 또는 그룹 도형에 저장된 텍스트는 해당 객체 컬렉션을 별도로 순회해야 합니다.

## **하이퍼링크가 있는 텍스트 상자 추가**

하이퍼링크는 특정 텍스트 구간에 할당할 수 있으므로 해당 텍스트만 클릭 가능한 링크가 됩니다. [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick)을 사용하여 구간을 외부 URL과 연결하십시오.

다음 예제는 링크된 텍스트를 생성하고 프레젠테이션에 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**텍스트 상자와 마스터 또는 레이아웃 슬라이드의 텍스트 자리 표시자 간 차이점은 무엇인가요?**

[placeholder](/slides/ko/python-java/manage-placeholder/)는 [master slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/) 또는 [layout slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/)으로부터 위치와 서식을 상속받을 수 있습니다. 일반 텍스트 상자는 생성된 슬라이드에 독립적인 도형이며 레이아웃이 변경되어도 자리 표시자 동작을 획득하지 않습니다.

**차트, 테이블 또는 SmartArt의 텍스트를 변경하지 않고 텍스트를 교체하려면 어떻게 해야 하나요?**

Update Text 예제에 보여진 대로 순회를 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 인스턴스로 제한하십시오. 차트, 테이블 및 SmartArt는 자체 객체 모델에 텍스트를 저장하므로 해당 루프에 의해 수정되지 않습니다.