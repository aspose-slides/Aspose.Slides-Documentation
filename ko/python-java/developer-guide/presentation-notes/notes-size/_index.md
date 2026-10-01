---
title: 파이썬에서 Java를 통해 노트 페이지 크기 및 방향 변경
linktitle: 노트 페이지 크기
type: docs
weight: 10
url: /ko/python-java/notes-size/
keywords:
- 노트 페이지 크기
- 노트 방향
- 가로 노트
- 세로 노트
- 유인물 크기
- 파워포인트
- 프레젠테이션
- PPT
- PPTX
- 파이썬
- 자바
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 노트 페이지 크기를 읽고 변경하며, 방향을 전환하고, 저장된 크기를 확인하고, 노트 또는 유인물을 PDF와 이미지로 내보냅니다."
---
## **개요**

프레젠테이션의 노트 페이지 설정에 액세스하려면 [Presentation.getNotesSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getNotesSize)를 사용합니다. 이 메서드는 페이지 차원을 설정하는 [setSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notessize/#setSize) 메서드를 가진 [NotesSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notessize/) 객체를 반환합니다. 설정 객체 자체는 교체할 수 없지만, 이 메서드를 통해 새 차원을 할당할 수 있습니다.

너비와 높이는 인치당 72포인트인 **포인트** 단위로 지정됩니다. 예를 들어, 900 × 600 포인트는 12.5 × 8⅓ 인치입니다. 이러한 설정은 개별 슬라이드의 노트가 아니라 프레젠테이션 전체에 적용됩니다.

| 설정 | 목적 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getNotesSize) | 노트 페이지 차원 및 유인물 내보내기에 사용되는 페이지 차원을 제어합니다. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlideSize) | [SlideSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesize/)를 통해 정규 프레젠테이션 슬라이드 차원을 제어합니다. |

두 설정 중 하나를 변경해도 다른 설정이 자동으로 변경되지 않습니다. 노트 페이지 방향을 변경해도 일반 슬라이드가 회전하지 않습니다. 일반 슬라이드 크기를 조정하려면 [Slide Size](/slides/ko/python-java/slide-size/)를 참조하세요.

아래 예제는 기존 `sample.pptx` 파일을 사용합니다. 내보내기 예제의 경우 최소 하나의 슬라이드에 발표자 노트가 포함된 프레젠테이션을 사용하세요. 각 예제는 독립적으로 실행할 수 있습니다.

## **노트 페이지 크기 및 방향 읽기**

너비와 높이를 읽고 비교하여 방향을 판단합니다: 페이지가 더 넓으면 가로 방향, 더 높으면 세로 방향이며, 차원이 동일하면 정사각형 페이지입니다. 이 예제는 표준 용지 크기를 가정하지 않고 실제 포인트 단위 차원을 출력합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **용지 크기를 변경하지 않고 가로 방향으로 전환**

방향만 변경하려면 기존 너비와 높이를 서로 교환합니다. 이렇게 하면 맞춤 용지 크기를 포함한 양쪽 길이가 보존됩니다. 아래 조건은 이미 가로 방향인 페이지가 세로 방향으로 다시 전환되는 것을 방지하고 정사각형 페이지는 그대로 유지합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

세로 방향의 경우 `size.getWidth() > size.getHeight()` 일 때 동일한 할당을 사용합니다. 용지 크기도 함께 변경하려는 경우가 아니면 A4나 Letter 차원을 대체하지 마세요.

## **맞춤 노트 페이지 크기 설정 및 검증**

두 차원을 동시에 할당한 다음 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)을 사용하여 프레젠테이션을 저장합니다. 이 예제는 900 × 600 포인트 가로 페이지를 설정하고 PPTX 형식으로 저장한 뒤, 저장된 파일을 다시 열어 지속된 값을 확인합니다. 비교 시 부동소수점 값에 대해 0.01 포인트 허용 오차를 허용하지만, 모든 파일 형식에 대한 정밀성을 보장하지는 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

예상 결과는 `900.0 x 600.0 points` 및 `Size preserved: True` 입니다. 새로 연 프레젠테이션을 확인하면 메모리 상의 설정이 아니라 저장된 파일을 검증합니다.

## **노트 및 유인물 내보내기**

페이지 차원은 노트 또는 유인물 레이아웃에 사용할 수 있는 영역을 정의합니다. 이 차원만으로 레이아웃이 활성화되는 것은 아니며, 내보내기 옵션도 설정해야 합니다. 일반 슬라이드 내보내기는 슬라이드 차원을 계속 사용합니다.

### **노트를 PDF 및 PNG로 내보내기**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/)를 [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions)에 할당하여 PDF에 노트를 포함합니다. 이 예제는 또한 [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)와 [RenderingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/)를 사용하여 노트가 있는 첫 번째 슬라이드를 PNG로 렌더링합니다.

[BottomTruncated](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notespositions/) 모드는 노트를 한 페이지에 유지하며, 맞지 않는 노트는 잘립니다. PDF는 900 × 600 포인트 페이지를 사용합니다. 아래에서 사용한 1 × 1 이미지 스케일에서는 PNG가 900 × 600 픽셀입니다. 포인트는 페이지 기하학을 나타내고, 픽셀은 렌더링 스케일에 따라 달라지는 래스터 출력 크기를 나타냅니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

긴 노트가 있는 PDF 내보내기에서는 [BottomFull](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notespositions/)을 사용하면 필요에 따라 추가 페이지를 생성할 수 있습니다. 위의 단일 슬라이드 이미지 호출은 이 모드를 지원하지 않으니 사용하지 마세요. 크기를 조정한 후에는 잘린 노트와 기존 notes‑master 객체의 배치를 확인하십시오; 페이지 차원만 변경한다고 모든 콘텐츠가 맞춤을 보장하지는 않습니다. 노트 내보내기에 대한 자세한 내용은 [Convert PowerPoint to PDF with Notes](/slides/ko/python-java/convert-powerpoint-to-pdf-with-notes/)를 참조하세요.

### **유인물을 PDF로 내보내기**

한 페이지에 여러 슬라이드 썸네일을 배치하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/handoutlayoutingoptions/)를 사용합니다. 다음 예제는 900 × 600 포인트 페이지를 설정하고 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ko/python-java/aspose.slides/handouttype/)을 사용하여 페이지당 최대 네 개의 슬라이드를 배치합니다. 가로 프리셋은 슬라이드 순서를 제어하고, 페이지 방향은 너비와 높이에서 결정됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

페이지 크기를 변경하면 원본 슬라이드 차원을 바꾸지 않고 유인물 그리드에 사용 가능한 영역이 변경됩니다. 유인물 이미지를 만들려면 개별 슬라이드 이미지 메서드 대신 유인물 레이아웃과 함께 [Presentation.getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages)를 사용하세요. Aspose.Slides에서 프레젠테이션 수준 유인물 렌더링은 노트 페이지 차원을 사용하고, 개별 슬라이드 이미지 호출은 유인물 페이지를 생성하지 않습니다. 레이아웃 옵션은 [Handout Mode](/slides/ko/python-java/convert-powerpoint-in-handout-mode/)를 참조하세요.

## **뷰어, 내보내기 및 인쇄 시 페이지 크기**

저장된 프레젠테이션 크기, 내보낸 페이지 크기, 인쇄된 용지 크기를 구분하십시오:

- **Presentation viewers:** 뷰어는 자체 레이아웃 규칙을 사용해 노트를 표시하거나 인쇄할 수 있습니다. 다른 애플리케이션이 파일을 저장한 경우 파일을 다시 열고 차원을 확인하세요; 해당 애플리케이션의 형식 변환이 차원을 표준화할 수 있습니다.
- **Export formats:** 위의 노트와 유인물 PDF 예제는 구성된 페이지 차원을 사용합니다. 래스터 이미지에서는 정수 픽셀 차원과 렌더링 스케일을 사용하므로, 소수점 포인트 값이 이미지 출력에서 반올림될 수 있습니다. 일반 슬라이드 내보내기에는 노트 페이지 크기가 적용되지 않습니다.
- **Printer drivers:** 용지 선택, 자동 회전 및 페이지 맞춤 설정은 프레젠테이션이나 PDF에 저장된 차원을 변경하지 않고 물리적 출력에 영향을 줄 수 있습니다. 특정 용지 크기에 맞추려면 프린터 설정을 일치시키고 인쇄 미리보기를 확인하세요.

## **FAQ**

**한 슬라이드에만 노트 크기를 설정할 수 있나요?**

노트 페이지 크기는 프레젠테이션 수준 설정입니다. 개별 슬라이드마다 다른 노트 내용은 가질 수 있지만, 이 속성은 각 슬라이드에 별도의 페이지 크기를 제공하지 않습니다.

**노트 방향을 변경했는데 슬라이드가 변경되지 않은 이유는 무엇인가요?**

노트 페이지와 일반 슬라이드는 독립적인 차원을 가지고 있습니다. 슬라이드 자체의 크기를 변경하려면 일반 슬라이드 크기 설정을 사용하세요.

**저장하거나 인쇄한 결과가 다른 크기를 갖는 이유는 무엇인가요?**

우선 저장된 프레젠테이션을 다시 열고 노트 차원을 비교하세요. 차원이 변경되었다면 다른 애플리케이션에서 파일을 저장하거나 변환하면서 페이지 설정이 변경되었는지 확인합니다. 변경되지 않았다면 내보내기 레이아웃, 이미지 스케일, 뷰어 설정 및 프린터 용지 선택을 확인하세요.