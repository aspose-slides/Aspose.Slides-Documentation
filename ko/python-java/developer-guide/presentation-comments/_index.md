---
title: Python via Java를 사용한 프레젠테이션 댓글 관리
linktitle: 프레젠테이션 댓글
type: docs
weight: 100
url: /ko/python-java/presentation-comments/
keywords:
- 댓글
- 현대 댓글
- PowerPoint 댓글
- 프레젠테이션 댓글
- 슬라이드 댓글
- 댓글 추가
- 댓글 접근
- 댓글 편집
- 댓글 답글
- 댓글 제거
- 댓글 삭제
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션의 댓글을 빠르고 쉽게 추가, 읽기, 편집, 답글 달기 및 제거합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via Java를 사용하여 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 타입을 소개하고, 슬라이드에 댓글을 추가하고, 기존 댓글에 접근하고, 답글 및 최신 댓글을 다루며, 프레젠테이션에서 댓글을 제거하는 방법을 보여줍니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다룹니다. 예를 들어 작성자에게 댓글을 할당하고, 댓글 텍스트와 메타데이터를 읽고, 답글 체인을 구성하고, 선택된 댓글 또는 모든 댓글을 제거하는 방법을 포함합니다.

PowerPoint에서 댓글은 슬라이드에 표시되는 주석 형태로 나타납니다. 댓글을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

프레젠테이션을 열 때 댓글 자체를 변경하지 않고 표시 여부를 요청하려면 [프레젠테이션 열 때 댓글 표시 또는 숨기기](/slides/ko/python-java/presentation-view-properties/)를 참조하십시오.

## **왜 프레젠테이션에 댓글을 추가합니까?**

프레젠테이션을 검토할 때 댓글을 사용하여 피드백을 제공하고 동료와 협업할 수 있습니다.

Aspose.Slides for Python via Java는 댓글 작업을 위한 다음 API를 제공합니다.

* The [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스는 프레젠테이션의 댓글 작성자에 대한 접근을 제공합니다.
* The [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) 클래스는 개별 작성자와 연관된 댓글을 나타냅니다.
* The [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) 클래스는 댓글에 대한 정보(작성자, 생성 시간, 위치 및 텍스트)를 제공합니다.
* The [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) 클래스는 작성자에 대한 정보(이름, 이니셜 및 연관된 댓글)를 제공합니다.

## **슬라이드 댓글 추가**

예제는 두 개의 슬라이드를 만든 다음 [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor)으로 댓글 작성자를 등록합니다. [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment)를 사용해 각 슬라이드에 하나씩 댓글을 배치하고, 해당 작성자에 대해 첫 번째 슬라이드의 댓글을 [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments)로 가져옵니다. 콘솔은 첫 번째 댓글 텍스트를 두 번 표시하여 슬라이드와 작성자 모두에서 접근이 가능함을 보여 주며, 저장된 프레젠테이션에는 두 댓글이 모두 포함됩니다.

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

## **댓글 작성자 찾기 또는 만들기**

자동 검토가 동일한 프레젠테이션을 반복해서 처리할 때는 작성자를 추가하기 전에 [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors)로 반환된 컬렉션을 검색합니다. [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials)는 이름과 이니셜을 모두 일치시켜 일치하는 작성자 배열을 반환하고, 일치 항목이 없으면 빈 배열을 반환합니다. 반면에 [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName)는 이니셜에 관계없이 이름만으로 검색합니다. 이미 컬렉션에 존재하는 이름과 이니셜으로 [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor)를 호출하면 예외가 발생합니다.

예제는 최소 하나의 슬라이드가 있는 프레젠테이션 파일이 필요합니다. 두 번의 패스 각각에서 첫 번째 일치하는 작성자를 재사용하거나 결과가 비어 있을 때만 새로 만듭니다. 일치 항목이 여러 개이면 다른 작성자를 병합하거나 제거하지 않고 첫 번째 배열 요소를 선택합니다. 그런 다음 선택된 작성자에 대해 [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment)를 호출하고 프레젠테이션을 저장합니다. 두 번째 패스는 첫 번째 패스의 출력 파일을 열어 동일한 작업을 반복합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

두 번째 패스는 새로운 댓글을 추가하지만 다른 작성자를 추가하거나 기존 댓글을 제거하지는 않습니다. 최종 파일 `review_pass_2.pptx`에는 원래 댓글과 함께 두 새 댓글이 모두 포함됩니다. 작성자를 재사용해도 댓글이 중복 제거되지 않으므로, 동일한 댓글을 반복해서 추가하지 않으려면 추가하기 전에 별도의 중복 검사를 구현해야 합니다.

## **슬라이드 댓글 접근**

예제는 기존 프레젠테이션을 열고 [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors)로 반환된 컬렉션을 읽습니다. 각 작성자에 대해 [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments)로 반환된 컬렉션을 순회하면서 슬라이드 번호, 댓글 텍스트, 작성자 이름 및 생성 시간을 출력합니다. 입력 프레젠테이션에 댓글이 있어야 콘솔 출력이 생성됩니다.

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

## **댓글에 답글 달기**

부모 댓글은 답글 계층 구조의 최상위에 있는 원본 댓글입니다. [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment)와 [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) 메서드를 사용하면 댓글의 부모를 가져오거나 설정할 수 있습니다.

예제는 두 작성자의 댓글을 만든 다음 [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment)를 사용해 답글을 구성합니다. 여기에는 다른 답글에 대한 답글도 포함됩니다. `None`을 [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments)에 전달하면 모든 작성자의 댓글을 가져옵니다. 콘솔은 답글 계층 깊이에 따라 각 항목을 들여쓰기합니다. 예제는 전체 토론을 저장하고, 첫 번째 루트 댓글에 대해 [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove)를 호출한 뒤, 해당 댓글 및 그 답글이 제거된 두 번째 프레젠테이션을 저장합니다.

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
* [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) 메서드로 댓글을 삭제하면 해당 댓글에 대한 모든 답글도 함께 삭제됩니다.
* [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment)으로 순환 참조가 생성되면 [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **현대 댓글 추가**

현대 댓글은 슬라이드 자체, 특정 도형, 또는 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 내부 텍스트 범위에 연결될 수 있습니다. [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) 메서드는 슬라이드와 댓글 마커 좌표 외에 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 인수를 추가로 받습니다.

`None`을 shape 인수에 전달하면 슬라이드 수준 댓글이 됩니다. 마커는 제공된 좌표에 배치되지만 특정 도형과 연결되지 않으므로 [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape)는 `None`을 반환합니다. [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)가 제공되면 댓글이 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 마커 위치를 정의하고, 도형 연결은 [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape)으로 조회할 수 있습니다.

### **도형에 현대 댓글 고정**

예제는 [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment)를 두 번 호출합니다. 첫 번째는 슬라이드 수준 댓글을 위해 `None` shape를 사용하고, 두 번째는 사각형을 앵커로 사용합니다. [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape)를 읽어 슬라이드 수준 댓글의 `None` 확인에서는 `True`를, 고정된 댓글에서는 `Revenue title`을 출력합니다. 두 댓글 모두 프레젠테이션에 저장됩니다.

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

### **다양한 도형 유형에 댓글 고정**

[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)를 상속하는 모든 슬라이드 객체를 도형 앵커로 사용할 수 있습니다. 일반적인 예로는 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/), 그리고 차트와 같은 [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) 인스턴스가 있습니다.

예제는 [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment)를 사용해 다섯 가지 도형 유형(자동 도형, 그림 프레임, 그룹, 커넥터, 차트) 각각에 댓글을 연결합니다. 그림은 임베디드 이미지 데이터를 사용하므로 외부 이미지가 필요하지 않습니다. 각 댓글은 고유한 마커 위치를 가지며, 저장된 프레젠테이션은 다섯 도형 모두에 대한 연결을 유지합니다.

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

### **텍스트에 댓글 고정 및 상태 설정**

[AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)에 연결된 현대 댓글의 경우, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart)와 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart)으로 도형 텍스트 프레임에서 선택된 텍스트의 시작 위치에 접근합니다. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength)와 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength)으로 선택 길이를 접근합니다. 이 값들을 함께 사용하면 댓글을 자동 도형 내부 특정 텍스트 범위와 연결할 수 있습니다.

[ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus)와 [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) 상수 중 하나의 값을 가져오거나 설정합니다.

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — 특정 현대 댓글 상태가 정의되지 않음.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — 댓글이 활성 상태임.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — 댓글이 해결됨.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — 댓글이 닫힘.

예제는 사각형 텍스트에서 “quarterly revenue”라는 단어에 현대 댓글을 고정합니다. 텍스트에서 제로 기반 선택 시작 위치를 계산해 [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart)에 전달하고, [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength)으로 선택된 문자 수를 설정합니다. 그런 다음 `Resolved` 상태로 [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus)를 호출하고 프레젠테이션을 저장·재열기합니다. 네 개의 콘솔 검사는 각각 `True`를 출력하여 도형 앵커, 텍스트 범위, 상태가 유지됐음을 확인합니다.

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

### **기존 현대 댓글 검사**

예제는 현대 댓글이 포함된 기존 프레젠테이션을 요구하고, 각 댓글의 텍스트, 상태 및 앵커 세부 정보를 출력합니다. 이를 위해 먼저 댓글이 [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/) 인스턴스인지 확인한 뒤, [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength), [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus)를 검사합니다. `None` shape는 슬라이드 수준 댓글을 의미합니다. [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 앵커인 경우 텍스트 선택 메서드가 도형 텍스트 프레임 내의 연관 범위를 식별합니다.

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

## **댓글 제거**

Aspose.Slides for Python via Java를 사용하면 프레젠테이션에서 모든 댓글 및 작성자를 완전히 제거하거나, 특정 댓글만 삭제하면서 나머지는 유지할 수 있습니다. 다음 예제는 두 가지 접근 방식을 보여 주며, 업데이트된 프레젠테이션을 저장합니다.

### **모든 댓글 및 댓글 작성자 제거**

예제는 기존 프레젠테이션을 연 뒤 각 작성자에 대해 [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear)를 호출하고, 이어서 [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear)로 작성자 자체를 제거합니다. 저장된 프레젠테이션에는 댓글도 작성자도 포함되지 않습니다. 제거 효과를 확인하려면 댓글이 포함된 프레젠테이션을 사용하십시오.

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

### **특정 댓글 제거**

예제는 한 슬라이드에 두 개의 댓글을 만든 뒤 [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments)로 각 작성자의 댓글을 찾습니다. 텍스트가 “comment 1”인 댓글을 수집한 뒤 [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove)를 호출해 선택된 댓글을 삭제하고, 컬렉션이 선택 중에 변경되는 것을 방지합니다. 저장된 프레젠테이션에는 “comment 2”만 남습니다.

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

**Aspose.Slides가 현대 댓글에 대한 해결된 상태를 지원합니까?**

예. [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus)와 [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) 메서드를 통해 `Resolved`를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) 값을 접근할 수 있습니다. 상태는 프레젠테이션에 저장되며 파일을 다시 연 후에도 읽을 수 있습니다.

**스레드형 토론(답글 체인)이 지원되며 중첩 제한이 있나요?**

예. 각 댓글은 [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment)를 참조할 수 있어 답글 체인을 구성합니다. API에서는 특정 중첩 깊이 제한을 정의하지 않습니다.

**댓글 마커의 위치는 어떤 좌표계로 정의되나요?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되며, 슬라이드 상의 정확한 위치에 배치할 수 있습니다.