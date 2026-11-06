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
- 댓글 회신
- 댓글 제거
- 댓글 삭제
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 프레젠테이션 댓글을 관리합니다: PowerPoint 프레젠테이션에서 댓글을 추가, 읽기, 편집, 회신 및 제거합니다."
---
## **개요**

이 문서는 Aspose.Slides for Python via .NET를 사용하여 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 타입을 소개하고 슬라이드에 댓글을 추가하고, 기존 댓글에 접근하고, 회신 및 최신 댓글을 다루며, 프레젠테이션에서 댓글을 제거하는 방법을 보여줍니다.

예제에서는 PowerPoint에서 일반적인 검토 및 공동 작업 시나리오를 다루며, 작성자에게 댓글을 할당하고, 댓글 텍스트 및 메타데이터를 읽고, 회신 체인을 구축하고, 선택한 댓글이나 모든 댓글을 제거하는 방법을 보여줍니다.

PowerPoint에서 댓글은 슬라이드에 주석 형태로 표시됩니다. 댓글을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

프레젠테이션을 열 때 댓글 자체를 변경하지 않고 표시하거나 숨기려면 [Show or Hide Comments When Opening a Presentation](/slides/ko/python-net/presentation-view-properties/)를 참고하십시오.

## **프레젠테이션에 댓글을 추가하는 이유는?**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하기 위해 댓글을 사용할 수 있습니다.

Aspose.Slides for Python via .NET는 댓글 작업을 위한 다음 API를 제공합니다.

* The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스는 프레젠테이션의 댓글 작성자에 대한 액세스를 제공합니다.
* The [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) 클래스는 개별 작성자와 연결된 댓글을 나타냅니다.
* The [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) 클래스는 댓글의 작성자, 생성 시간, 위치 및 텍스트와 같은 정보를 제공합니다.
* The [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) 클래스는 이름, 이니셜 및 연결된 댓글을 포함한 작성자 정보를 제공합니다.

## **슬라이드 댓글 추가**

예제에서는 두 개의 슬라이드를 만든 뒤 [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/)를 사용해 댓글 작성자를 등록합니다. 그런 다음 [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/)를 사용해 각 슬라이드에 한 개씩 댓글을 배치하고, 해당 작성자에 대한 첫 번째 슬라이드의 댓글을 [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/)로 가져옵니다. 콘솔은 첫 번째 댓글의 텍스트를 두 번 표시하여 슬라이드와 작성자 모두를 통해 접근할 수 있음을 보여주며, 저장된 프레젠테이션에는 두 댓글이 모두 포함됩니다.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
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

## **댓글 작성자 찾기 또는 만들기**

자동 검토가 같은 프레젠테이션을 반복적으로 처리할 경우, 작성자를 추가하기 전에 [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) 컬렉션을 검색합니다. [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/)는 이름과 이니셜을 모두 일치시키며 일치하는 작성자 배열을 반환하고, 일치하는 것이 없으면 빈 배열을 반환합니다. 반면에 [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/)은 이니셜에 관계없이 이름만으로 검색합니다. 이미 컬렉션에 존재하는 이름과 이니셜으로 [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/)를 호출하면 예외가 발생합니다.

예제는 최소 하나의 슬라이드가 있는 프레젠테이션 파일이 필요합니다. 두 번의 반복에서 첫 번째 일치 작성자를 재사용하거나 결과가 비어 있을 때만 새로 생성합니다. 일치하는 항목이 여러 개이면 다른 작성자를 병합하거나 제거하지 않고 첫 번째 배열 요소를 선택합니다. 그런 다음 선택된 작성자를 위해 [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/)를 호출하고 프레젠테이션을 저장합니다. 두 번째 반복은 첫 번째 반복의 출력 파일을 열고 동일한 작업을 다시 수행합니다.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

두 번째 반복에서는 새 작성자를 추가하거나 기존 댓글을 제거하지 않고 또 다른 댓글만 추가합니다. 최종 파일 `review_pass_2.pptx`에는 원본 댓글과 새로운 두 댓글이 모두 포함됩니다. 작성자를 재사용한다고 해서 댓글이 중복 제거되는 것은 아니므로 동일한 댓글을 반복적으로 추가하지 않도록 별도의 중복 검사를 구현해야 합니다.

## **슬라이드 댓글 접근**

예제는 기존 프레젠테이션을 열고 [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) 컬렉션을 읽습니다. 각 작성자에 대해 [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/)를 순회하면서 슬라이드 번호, 댓글 텍스트, 작성자 이름 및 생성 시간을 출력합니다. 입력 프레젠테이션에 댓글이 포함되어 있어야 콘솔 출력이 생성됩니다.

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

## **댓글에 회신 달기**

부모 댓글은 회신 계층 구조의 최상위에 있는 원본 댓글을 의미합니다. [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) 클래스의 [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) 속성을 사용하면 댓글의 부모를 가져오거나 설정할 수 있습니다.

예제에서는 두 작성자의 댓글을 만든 뒤 [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/)을 사용해 회신을 구축하며, 다른 회신에 대한 회신도 포함합니다. `None`을 [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/)에 전달하면 모든 작성자의 댓글을 가져옵니다; 콘솔은 회신 계층 깊이에 따라 각 항목을 들여쓰기 합니다. 예제는 전체 토론을 저장하고 첫 번째 루트 댓글에 대해 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/)를 호출한 뒤 그 댓글 및 회신이 제거된 두 번째 프레젠테이션을 저장합니다.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) 클래스의 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) 메서드를 사용해 댓글을 삭제하면 해당 댓글에 대한 모든 회신도 함께 삭제됩니다.
* [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) 속성이 순환 참조를 만들면 [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **최신 댓글 추가**

최신 댓글은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위에 연결될 수 있습니다. [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) 메서드는 슬라이드와 댓글 마커 좌표 외에 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 인수를 허용합니다.

`None`을 shape 인수로 전달하면 댓글은 슬라이드 수준 댓글이 됩니다. 마커는 제공된 좌표에 따라 배치되지만 특정 도형에 연결되지 않으며, [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/)은 `None`을 반환합니다. [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)가 제공되면 댓글이 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드 상의 마커 위치를 정의하고, 도형 연결은 [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/)을 통해 조회할 수 있습니다.

### **도형에 최신 댓글 고정**

예제는 [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/)을 두 번 호출합니다. 첫 번째는 슬라이드 수준 댓글을 위한 `None` shape, 두 번째는 사각형을 기준으로 고정합니다. [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/)을 읽으면 슬라이드 수준 댓글의 null 검사에서는 `True`가 출력되고, 고정된 댓글에서는 `Revenue title`이 출력됩니다. 두 댓글 모두 프레젠테이션에 저장됩니다.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **다양한 도형 유형에 댓글 고정**

[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)에서 파생된 모든 슬라이드 객체를 도형 고정으로 사용할 수 있습니다. 일반적인 예로는 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/), 그리고 차트와 같은 [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) 인스턴스가 있습니다.

예제는 [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/)을 사용해 다섯 가지 도형 유형(자동 도형, 그림 프레임, 그룹, 커넥터, 차트)에 각각 댓글을 연결합니다. 그림은 임베드된 이미지 데이터를 사용하므로 외부 이미지가 필요하지 않습니다. 각 댓글은 고유한 마커 위치를 갖고, 저장된 프레젠테이션은 모든 다섯 도형 연결을 보존합니다.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **텍스트에 댓글 고정 및 상태 설정**

[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)에 연결된 최신 댓글의 경우, [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/)은 도형 텍스트 프레임 내에서 선택된 텍스트의 시작 위치를 지정하고, [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/)은 선택 길이를 지정합니다. 이 두 속성은 댓글을 AutoShape 내부의 특정 텍스트 범위에 연결합니다.

[ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) 속성은 [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) 열거형 값으로 읽거나 업데이트할 수 있습니다.

- `NOT_DEFINED` — 특정 최신 댓글 상태가 정의되지 않음.
- `ACTIVE` — 댓글이 활성 상태.
- `RESOLVED` — 댓글이 해결됨.
- `CLOSED` — 댓글이 닫힘.

예제는 사각형 텍스트의 "quarterly revenue" 단어에 최신 댓글을 고정합니다. 텍스트에서 0 기반 [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/)을 계산하고, 선택된 문자 수만큼 [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/)을 설정합니다. 그런 다음 [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/)를 `RESOLVED`로 설정하고 프레젠테이션을 저장·재열어 봅니다. 네 개의 콘솔 검사는 각각 `True`를 출력하여 도형 고정, 텍스트 범위, 상태가 정상적으로 보존되었음을 확인합니다.

```python
from datetime import datetime

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
    comment_position = slides.PointF(60, 60)
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

예제는 최신 댓글이 포함된 기존 프레젠테이션을 요구하며, 각 댓글의 텍스트, 상태 및 고정 세부 정보를 출력합니다. 검사하려면 댓글이 [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) 인스턴스인지 확인한 뒤, [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/), 및 [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/)를 조사합니다. `None` shape은 슬라이드 수준 댓글을 의미합니다. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 고정인 경우, 텍스트 선택 속성이 도형 텍스트 프레임 내 해당 범위를 식별합니다.

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

## **댓글 삭제**

Aspose.Slides for Python via .NET를 사용하면 프레젠테이션에서 모든 댓글 및 해당 작성자를 제거하거나 선택된 댓글만 삭제하면서 나머지는 유지할 수 있습니다. 아래 예제들은 두 접근 방식을 보여 주며, 업데이트된 프레젠테이션을 저장합니다.

### **모든 댓글 및 댓글 작성자 삭제**

예제는 기존 프레젠테이션을 연 뒤 각 작성자에 대해 [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/)를 호출하고, 이어서 [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/)를 호출해 작성자 자체도 제거합니다. 저장된 프레젠테이션에는 댓글도 작성자도 포함되지 않습니다. 댓글이 포함된 프레젠테이션을 사용해 삭제 결과를 확인하십시오.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **특정 댓글 삭제**

예제는 한 슬라이드에 두 개의 댓글을 만든 뒤 [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/)을 사용해 각 작성자의 댓글을 찾습니다. 텍스트가 "comment 1"인 댓글을 수집한 뒤 [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/)를 호출해 컬렉션이 변경되는 동안 선택을 피합니다. 저장된 프레젠테이션에는 "comment 2"만 남습니다.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
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

**최신 댓글에 대해 해결된 상태를 지원합니까?**

예. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/)는 [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) 값으로 읽고 설정할 수 있으며, `RESOLVED`도 포함됩니다. 상태는 프레젠테이션에 저장되며 파일을 다시 열어도 읽을 수 있습니다.

**스레드형 토론(회신 체인)이 지원되며 중첩 제한이 있습니까?**

예. 각 댓글은 [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/)을 참조할 수 있어 회신 체인을 구현합니다. API에서는 특정 중첩 깊이 제한을 정의하고 있지 않습니다.

**슬라이드에서 댓글 마커 위치는 어떤 좌표계로 정의됩니까?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되며, 이를 통해 슬라이드 상의 정확한 위치에 마커를 배치할 수 있습니다.