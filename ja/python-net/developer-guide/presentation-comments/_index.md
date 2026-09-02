---
title: Python でプレゼンテーション コメントを管理する
linktitle: プレゼンテーション コメント
type: docs
weight: 100
url: /ja/python-net/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPoint コメント
- プレゼンテーション コメント
- スライド コメント
- コメントの追加
- コメントへのアクセス
- コメントの編集
- コメントへの返信
- コメントの削除
- コメントの削除
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションのコメントを追加、読み取り、編集、返信、削除できるように管理します。"
---
## **概要**

この記事では、Aspose.Slides for Python via .NET を使用したプレゼンテーション コメントの管理方法を説明します。コメントに関連する主要な型を紹介し、スライドへのコメントの追加、既存コメントへのアクセス、返信および最新コメントの操作、プレゼンテーションからのコメントの削除方法を実演します。

例は、PowerPoint の一般的なレビューおよびコラボレーション シナリオ（コメントを作成者に割り当てる、コメントテキストとメタデータを読み取る、返信チェーンを構築する、選択したコメントまたはすべてのコメントを削除する）をカバーしています。

PowerPoint では、コメントはスライド上の注釈として表示されます。コメントを選択すると、そのテキストと関連する議論が表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際に、コメントを使用してフィードバックを提供したり、同僚と共同作業を行ったりできます。

Aspose.Slides for Python via .NET は、コメント操作用に次の API を提供します。

* The [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [CommentCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.
* The [Comment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/ja/python-net/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **スライドコメントの追加**

以下の例は、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています：

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

## **スライドコメントへのアクセス**

以下の例は、PowerPoint プレゼンテーション内の既存コメントにアクセスする方法を示しています：

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

## **コメントへの返信**

親コメントは、返信階層のトップにある元のコメントです。The [parent_comment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/comment/parent_comment/) property of the [Comment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/comment/) class lets you get or set the parent of a comment.

以下の例は、返信を追加し、結果として得られるコメント階層を検査する方法を示しています：

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

{{% alert color="warning" title="警告" %}}

* When the [remove](https://reference.aspose.com/slides/ja/python-net/aspose.slides/comment/remove/) method of the [Comment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/comment/) class is used to delete a comment, all replies to that comment are also deleted.
* If the [parent_comment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/comment/parent_comment/) property creates a circular reference, a [PptxEditException](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pptxeditexception/) is thrown.

{{% /alert %}}

## **最新コメントの追加**

最新コメントは、スライド自体、特定のシェイプ、または AutoShape 内のテキスト範囲に関連付けることができます。The [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/commentcollection/add_modern_comment/) method accepts a [Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) argument in addition to the slide and comment-marker coordinates.

`None` がシェイプ引数として渡された場合、コメントはスライドレベルのコメントになります。マーカーは指定された座標で配置されますが、特定のシェイプには紐付けられないため、[ModernComment.shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/shape/) は `None` を返します。シェイプが指定された場合、コメントはそのシェイプに固定されます。座標は依然としてスライド上のコメントマーカーの位置を定義し、シェイプとの関連は [ModernComment.shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/shape/) から取得できます。

### **シェイプに最新コメントを固定する**

以下の例は、スライドレベルの最新コメントと、特定の AutoShape に固定された最新コメントの両方を作成し、各コメントから関連シェイプを取得します。

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

### **さまざまなシェイプタイプへのコメント固定**

[Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) から派生したスライドオブジェクトはすべてシェイプアンカーとして使用できます。一般的な例として [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/ja/python-net/aspose.slides/connector/)、およびチャートなどの [GraphicalObject](https://reference.aspose.com/slides/ja/python-net/aspose.slides/graphicalobject/) インスタンスがあります。

以下の例は、いくつかの一般的なシェイプタイプを作成し、各シェイプに最新コメントを関連付けます。

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

### **テキストにコメントを固定しステータスを設定する**

[AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) に関連付けられた最新コメントの場合、[ModernComment.text_selection_start](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/text_selection_start/) はシェイプのテキストフレーム内で選択されたテキストの開始位置を示し、[ModernComment.text_selection_length](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/text_selection_length/) は選択範囲の長さを示します。これらのプロパティを組み合わせることで、コメントを AutoShape 内の特定のテキスト範囲に関連付けます。

[ModernComment.status](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/status/) プロパティは、[ModernCommentStatus](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncommentstatus/) 列挙体の値で読み取りまたは更新できます。

- `NOT_DEFINED` — 特定の最新コメントステータスは定義されていません。
- `ACTIVE` — コメントはアクティブです。
- `RESOLVED` — コメントは解決済みです。
- `CLOSED` — コメントはクローズされています。

以下の例は、シェイプに固定された最新コメントを作成し、テキスト選択に関連付け、解決済みとしてマークし、プレゼンテーションを保存してファイルを再度開いた後に値を確認します。

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

### **既存の最新コメントの検査**

既存のプレゼンテーションを検査するには、どのコメントが [ModernComment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/) インスタンスであるかを確認し、[ModernComment.shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/shape/)、[ModernComment.text_selection_start](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/text_selection_start/)、[ModernComment.text_selection_length](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/text_selection_length/)、および [ModernComment.status](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/status/) を調べます。`None` のシェイプはスライドレベルのコメントを示します。[AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) アンカーの場合、テキスト選択プロパティはシェイプのテキストフレーム内の対象範囲を特定します。

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

## **コメントの削除**

### **すべてのコメントとコメント作成者の削除**

以下の例は、プレゼンテーションからすべてのコメントとコメント作成者を削除する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **特定のコメントの削除**

以下の例は、スライドから特定のコメントを削除する方法を示しています：

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

**Aspose.Slides は最新コメントの解決ステータスをサポートしていますか？**

はい。[ModernComment.status](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncomment/status/) は [ModernCommentStatus](https://reference.aspose.com/slides/ja/python-net/aspose.slides/moderncommentstatus/) の値で読み取り・設定でき、`RESOLVED` も含まれます。ステータスはプレゼンテーションに保存され、ファイルを再度開いた後でも読み取れます。

**スレッド化されたディスカッション（返信チェーン）はサポートされますか？ また、ネストの上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/comment/parent_comment/) を参照できるため、返信チェーンを作成できます。API には特定のネスト深さ上限は定義されていません。

**コメントマーカーの位置はスライドのどの座標系で定義されていますか？**

マーカーの位置はスライド座標系の浮動小数点座標で定義されており、スライド上の任意の場所に正確に配置できます。