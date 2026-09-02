---
title: Python에서 프레젠테이션 댓글 관리
linktitle: 프레젠테이션 댓글
type: docs
weight: 100
url: /ko/python-net/presentation-comments/
keywords:
- 댓글
- 최신 댓글
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 프레젠테이션 댓글을 관리합니다: PowerPoint 프레젠테이션에서 댓글을 추가, 읽기, 편집, 답글 달기 및 제거합니다."
---
## **개요**

이 문서는 Aspose.Slides for Python via .NET을 사용하여 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 유형을 소개하고 슬라이드에 댓글을 추가하고, 기존 댓글에 접근하고, 답글 및 최신 댓글을 다루며, 프레젠테이션에서 댓글을 제거하는 방법을 보여줍니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다루며, 저자에게 댓글을 할당하고, 댓글 텍스트와 메타데이터를 읽고, 답글 체인을 구성하고, 선택된 댓글 또는 모든 댓글을 제거하는 방법을 포함합니다.

PowerPoint에서 댓글은 슬라이드에 표시되는 주석으로 나타납니다. 댓글을 선택하면 텍스트와 관련 토론이 표시됩니다.

## **프레젠테이션에 댓글을 추가하는 이유**

프레젠테이션을 검토할 때 동료와 피드백을 주고받으며 협업하려면 댓글을 사용할 수 있습니다.

Aspose.Slides for Python via .NET은 댓글 작업을 위한 다음 API를 제공합니다.

* 프레젠테이션의 댓글 저자에 접근할 수 있는 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스.
* 개별 저자와 연결된 댓글을 나타내는 [CommentCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/commentcollection/) 클래스.
* 저자, 생성 시간, 위치 및 텍스트 등 댓글 정보를 제공하는 [Comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/comment/) 클래스.
* 이름, 이니셜 및 연관된 댓글을 포함한 저자 정보를 제공하는 [CommentAuthor](https://reference.aspose.com/slides/ko/python-net/aspose.slides/commentauthor/) 클래스.

## **슬라이드 댓글 추가**

다음 예제는 PowerPoint 프레젠테이션에 슬라이드 댓글을 추가하는 방법을 보여줍니다:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드 댓글 접근**

다음 예제는 PowerPoint 프레젠테이션에서 기존 댓글에 접근하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **댓글에 답글 달기**

상위 댓글(parent comment)은 답글 계층 구조의 최상위 원본 댓글을 의미합니다. [Comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/comment/) 클래스의 [parent_comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/comment/parent_comment/) 속성을 통해 댓글의 상위 댓글을 가져오거나 설정할 수 있습니다.

다음 예제는 답글을 추가하고 결과 댓글 계층 구조를 조사하는 방법을 보여줍니다:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="경고" %}}
* [Comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/comment/) 클래스의 [remove](https://reference.aspose.com/slides/ko/python-net/aspose.slides/comment/remove/) 메서드를 사용해 댓글을 삭제하면 해당 댓글에 대한 모든 답글도 함께 삭제됩니다.
* [parent_comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/comment/parent_comment/) 속성이 순환 참조를 만들 경우, [PptxEditException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **최신 댓글 추가**

최신 댓글은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위에 연결될 수 있습니다. [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/commentcollection/add_modern_comment/) 메서드는 슬라이드와 댓글 마커 좌표 외에 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 인수를 추가로 받습니다.

`None`을 shape 인수에 전달하면 댓글은 슬라이드 수준 댓글이 됩니다. 마커는 제공된 좌표에 배치되지만 특정 도형과 연결되지 않으므로 [ModernComment.shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/shape/)은 `None`을 반환합니다. [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/)이 제공되면 댓글이 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 댓글 마커 위치를 정의하고, 도형 연결은 [ModernComment.shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/shape/)을 통해 확인할 수 있습니다.

### **도형에 최신 댓글 고정**

다음 예제는 슬라이드 수준 최신 댓글과 특정 AutoShape에 고정된 최신 댓글을 모두 생성하고, 각각의 댓글에서 연결된 도형을 읽습니다.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **다양한 도형 유형에 댓글 고정**

[Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/)에서 파생된 모든 슬라이드 객체를 도형 앵커로 사용할 수 있습니다. 일반적인 예로 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ko/python-net/aspose.slides/connector/), 그리고 차트와 같은 [GraphicalObject](https://reference.aspose.com/slides/ko/python-net/aspose.slides/graphicalobject/) 인스턴스가 있습니다.

다음 예제는 여러 일반 도형 유형을 생성하고 각각에 최신 댓글을 연결합니다.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **텍스트에 댓글 고정 및 상태 설정**

[AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)에 연결된 최신 댓글의 경우, [ModernComment.text_selection_start](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/text_selection_start/)은 도형 텍스트 프레임에서 선택된 텍스트의 시작 위치를 지정하고, [ModernComment.text_selection_length](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/text_selection_length/)은 선택 길이를 지정합니다. 이 두 속성을 함께 사용하면 댓글을 AutoShape 내부의 특정 텍스트 범위와 연결할 수 있습니다.

[ModernComment.status](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/status/) 속성은 [ModernCommentStatus](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncommentstatus/) 열거형 값으로 읽거나 업데이트할 수 있습니다.

- `NOT_DEFINED` — 특정 최신 댓글 상태가 정의되지 않음.
- `ACTIVE` — 댓글이 활성 상태.
- `RESOLVED` — 댓글이 해결됨.
- `CLOSED` — 댓글이 닫힘.

다음 예제는 도형에 고정된 최신 댓글을 생성하고, 텍스트 선택을 연결한 뒤, 상태를 해결됨(`RESOLVED`)으로 표시하고 프레젠테이션을 저장한 후 파일을 다시 열어 값을 확인합니다.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = draw.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **기존 최신 댓글 검사**

기존 프레젠테이션을 검사하려면 어떤 댓글이 [ModernComment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/) 인스턴스인지 확인하고, [ModernComment.shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/text_selection_length/), 그리고 [ModernComment.status](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/status/)를 살펴봅니다. `None` 도형은 슬라이드 수준 댓글을 의미합니다. [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)에 앵커된 경우 텍스트 선택 속성이 도형 텍스트 프레임 내의 관련 범위를 식별합니다.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **댓글 제거**

### **모든 댓글 및 댓글 저자 제거**

다음 예제는 프레젠테이션에서 모든 댓글과 댓글 저자를 제거하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **특정 댓글 제거**

다음 예제는 슬라이드에서 특정 댓글을 제거하는 방법을 보여줍니다:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides가 최신 댓글에 대한 해결 상태를 지원하나요?**

예. [ModernComment.status](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/status/)는 [ModernCommentStatus](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncommentstatus/) 값으로 읽고 설정할 수 있으며, `RESOLVED`도 포함됩니다. 상태는 프레젠테이션에 저장되며 파일을 다시 열어도 읽을 수 있습니다.

**스레드형 토론(답글 체인)이 지원되며, 중첩 제한이 있나요?**

예. 각 댓글은 [parent comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/comment/parent_comment/)을 참조할 수 있어 답글 체인을 만들 수 있습니다. API는 특정 중첩 깊이 제한을 정의하지 않습니다.

**댓글 마커 위치는 슬라이드의 어떤 좌표계로 정의되나요?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되며, 이를 통해 슬라이드 내 원하는 정확한 위치에 마커를 배치할 수 있습니다.