---
title: Python via Java에서 프레젠테이션 주석 관리
linktitle: 프레젠테이션 주석
type: docs
weight: 100
url: /ko/python-java/presentation-comments/
keywords:
- 주석
- 최신 주석
- PowerPoint 주석
- 프레젠테이션 주석
- 슬라이드 주석
- 주석 추가
- 주석 접근
- 주석 편집
- 주석 회신
- 주석 제거
- 주석 삭제
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션의 주석을 빠르고 쉽게 추가, 읽기, 편집, 회신 및 제거하여 관리합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via Java를 사용하여 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 형식을 소개하고 슬라이드에 주석을 추가하고, 기존 주석에 접근하며, 회신 및 최신 주석을 다루고, 프레젠테이션에서 주석을 제거하는 방법을 시연합니다.

예제에서는 PowerPoint에서 흔히 발생하는 검토 및 협업 시나리오를 다룹니다. 예를 들어 작성자에게 주석을 할당하고, 주석 텍스트와 메타데이터를 읽으며, 회신 체인을 구축하고, 선택한 주석이나 모든 주석을 제거하는 방법을 보여줍니다.

PowerPoint에서 주석은 슬라이드에 표시되는 주석 형태로 나타납니다. 주석을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

## **프레젠테이션에 주석을 추가해야 하는 이유**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하려면 주석을 사용할 수 있습니다.

Aspose.Slides for Python via Java는 주석 작업을 위한 다음 API를 제공합니다.

* 프레젠테이션의 주석 작성자에 접근할 수 있는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스.
* 개별 작성자와 연결된 주석을 나타내는 [CommentCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commentcollection/) 클래스.
* 작성자, 생성 시간, 위치 및 텍스트 등 주석 정보를 제공하는 [Comment](https://reference.aspose.com/slides/ko/python-java/aspose.slides/comment/) 클래스.
* 이름, 이니셜 및 연결된 주석 등 작성자 정보를 제공하는 [CommentAuthor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commentauthor/) 클래스.

## **슬라이드 주석 추가**

다음 예제는 PowerPoint 프레젠테이션에 슬라이드 주석을 추가하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))
    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **슬라이드 주석 접근**

다음 예제는 PowerPoint 프레젠테이션에서 기존 주석에 접근하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **주석에 회신하기**

부모 주석은 회신 계층 구조의 최상위에 있는 원본 주석입니다. [Comment.getParentComment](https://reference.aspose.com/slides/ko/python-java/aspose.slides/comment/#getParentComment) 및 [Comment.setParentComment](https://reference.aspose.com/slides/ko/python-java/aspose.slides/comment/#setParentComment) 메서드를 사용하면 주석의 부모를 가져오거나 설정할 수 있습니다.

다음 예제는 회신을 추가하고 결과 주석 계층 구조를 검사하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* [Comment.remove](https://reference.aspose.com/slides/ko/python-java/aspose.slides/comment/#remove) 메서드로 주석을 삭제하면 해당 주석에 대한 모든 회신도 함께 삭제됩니다.
* [Comment.setParentComment](https://reference.aspose.com/slides/ko/python-java/aspose.slides/comment/#setParentComment) 메서드가 순환 참조를 만들면 [PptxEditException](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **최신 주석 추가**

최신 주석은 슬라이드 자체, 특정 도형, 또는 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 내부의 텍스트 범위와 연결될 수 있습니다. [CommentCollection.addModernComment](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commentcollection/#addModernComment) 메서드는 슬라이드와 주석 마커 좌표 외에 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 인수를 추가로 받습니다.

`None`을 shape 인수에 전달하면 주석은 슬라이드 수준 주석이 됩니다. 마커는 제공된 좌표에 따라 배치되지만 특정 도형과 연결되지 않으므로 [ModernComment.getShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#getShape) 은 `None`을 반환합니다. [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)가 제공되면 주석은 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 주석 마커 위치를 정의하고, 도형 연결은 [ModernComment.getShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#getShape) 로 확인할 수 있습니다.

### **도형에 최신 주석 고정하기**

다음 예제는 슬라이드 수준 최신 주석과 특정 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)에 고정된 최신 주석을 모두 생성한 뒤, 각 주석에서 연결된 도형을 읽어옵니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **다양한 도형 유형에 주석 고정하기**

[Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)을 상속하는 모든 슬라이드 개체는 도형 고정점으로 사용할 수 있습니다. 일반적인 예로는 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ko/python-java/aspose.slides/connector/), 그리고 차트와 같은 [GraphicalObject](https://reference.aspose.com/slides/ko/python-java/aspose.slides/graphicalobject/) 인스턴스가 있습니다.

다음 예제는 여러 일반 도형 유형을 생성하고 각 도형에 최신 주석을 연결합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")
    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **텍스트에 주석을 고정하고 상태 설정하기**

[AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)에 연결된 최신 주석의 경우 [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#getTextSelectionStart) 및 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#setTextSelectionStart) 를 사용해 도형 텍스트 프레임에서 선택된 텍스트의 시작 위치에 접근합니다. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#getTextSelectionLength) 및 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#setTextSelectionLength) 은 선택 영역의 길이에 접근합니다. 이 값들을 함께 사용하면 주석을 AutoShape 내부의 특정 텍스트 범위와 연결할 수 있습니다.

[ModernComment.getStatus](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#getStatus) 및 [ModernComment.setStatus](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#setStatus) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncommentstatus/) 상수 중 하나의 값을 반환하거나 설정합니다.

- [NotDefined](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncommentstatus/#NotDefined) — 특정 최신 주석 상태가 정의되지 않음.
- [Active](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncommentstatus/#Active) — 주석이 활성 상태임.
- [Resolved](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncommentstatus/#Resolved) — 주석이 해결됨.
- [Closed](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncommentstatus/#Closed) — 주석이 닫힘.

다음 예제는 도형에 고정된 최신 주석을 만들고, 텍스트 선택을 연결하고, 해결됨으로 표시한 뒤 프레젠테이션을 저장하고 파일을 다시 연 후 값을 확인합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **기존 최신 주석 검사하기**

기존 프레젠테이션을 검사하려면 어떤 주석이 [ModernComment](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/) 인스턴스인지 확인한 후, [ModernComment.getShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#getTextSelectionLength), [ModernComment.getStatus](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#getStatus) 를 살펴봅니다. `None` 도형은 슬라이드 수준 주석임을 나타냅니다. [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)에 고정된 경우 텍스트 선택 메서드가 해당 도형 텍스트 프레임 내의 연관 범위를 식별합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **주석 제거**

### **모든 주석 및 주석 작성자 제거**

다음 예제는 프레젠테이션에서 모든 주석과 주석 작성자를 제거하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **특정 주석 제거**

다음 예제는 슬라이드에서 특정 주석을 제거하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides에서 최신 주석에 대한 해결 상태를 지원합니까?**

예. [ModernComment.getStatus](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#getStatus) 및 [ModernComment.setStatus](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncomment/#setStatus) 메서드를 통해 `Resolved` 를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/ko/python-java/aspose.slides/moderncommentstatus/) 값을 접근할 수 있습니다. 해당 상태는 프레젠테이션에 저장되며 파일을 다시 연 뒤에도 읽을 수 있습니다.

**스레드형 토론(회신 체인)이 지원되며 중첩 제한이 있나요?**

예. 각 주석은 [parent comment](https://reference.aspose.com/slides/ko/python-java/aspose.slides/comment/#getParentComment) 를 참조할 수 있어 회신 체인을 만들 수 있습니다. API에 특정 중첩 깊이 제한은 정의되어 있지 않습니다.

**슬라이드에서 주석 마커 위치는 어떤 좌표계로 정의되나요?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되며, 이를 통해 슬라이드 내 원하는 정확한 위치에 마커를 배치할 수 있습니다.