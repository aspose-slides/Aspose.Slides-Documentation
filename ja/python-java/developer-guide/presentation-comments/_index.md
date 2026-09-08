---
title: Python via Java でプレゼンテーションコメントを管理する
linktitle: プレゼンテーションコメント
type: docs
weight: 100
url: /ja/python-java/presentation-comments/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してプレゼンテーションコメントを管理します：PowerPoint プレゼンテーション内のコメントを追加、読み取り、編集、返信、削除を迅速かつ簡単に行います。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用したプレゼンテーションコメントの管理方法を説明します。主なコメント関連の型を紹介し、スライドへのコメント追加、既存コメントへのアクセス、返信やモダンコメントの操作、プレゼンテーションからのコメント削除の方法を実演します。

例では、PowerPoint の一般的なレビューや共同作業シナリオ（コメントを作者に割り当てる、コメントテキストやメタデータを取得する、返信チェーンを構築する、選択したコメントまたはすべてのコメントを削除する）を取り上げています。

PowerPoint では、コメントはスライド上の注釈として表示されます。コメントを選択すると、そのテキストと関連するディスカッションが表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際、コメントを使用してフィードバックを提供したり、同僚と共同作業したりできます。

Aspose.Slides for Python via Java は、コメント操作のために次の API を提供します：

* The [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスは、プレゼンテーションのコメント作成者へのアクセスを提供します。
* The [CommentCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commentcollection/) クラスは、個々の作成者に関連付けられたコメントを表します。
* The [Comment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/comment/) クラスは、コメントの作成者、作成時刻、位置、テキストなどの情報を提供します。
* The [CommentAuthor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commentauthor/) クラスは、作成者の名前、イニシャル、および関連コメントの情報を提供します。

## **スライドコメントの追加**

以下の例は、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています。

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

## **スライドコメントへのアクセス**

以下の例は、PowerPoint プレゼンテーション内の既存コメントにアクセスする方法を示しています。

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

## **コメントへの返信**

親コメントは、返信階層の最上位にある元のコメントです。[Comment.getParentComment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/comment/#getParentComment) および [Comment.setParentComment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/comment/#setParentComment) メソッドを使用して、コメントの親を取得または設定できます。

以下の例は、返信を追加し、結果として得られるコメント階層を検査する方法を示しています。

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
* [Comment.remove] メソッドでコメントを削除すると、そのコメントへのすべての返信も削除されます。
* [Comment.setParentComment] が循環参照を作成した場合、[PptxEditException] がスローされます。
{{% /alert %}}

## **モダンコメントの追加**

モダンコメントは、スライド自体、特定のシェイプ、または [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) 内のテキスト範囲に関連付けることができます。[CommentCollection.addModernComment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commentcollection/#addModernComment) メソッドは、スライドとコメントマーカー座標に加えて [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) 引数を受け取ります。

`None` がシェイプ引数として渡された場合、コメントはスライドレベルのコメントとなります。マーカーは指定された座標で配置されますが、特定のシェイプには関連付けられないため、[ModernComment.getShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#getShape) は `None` を返します。シェイプが指定された場合、コメントはそのシェイプに固定されます。座標は依然としてスライド上のマーカ位置を定義し、シェイプの関連付けは [ModernComment.getShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#getShape) で取得できます。

### **シェイプにモダンコメントを固定する**

以下の例は、スライドレベルのモダンコメントと、特定の [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) に固定されたモダンコメントの両方を作成し、各コメントから関連シェイプを取得します。

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

### **異なるシェイプタイプへのコメント固定**

[Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) を継承する任意のスライドオブジェクトをシェイプアンカーとして使用できます。一般的な例としては、[AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/ja/python-java/aspose.slides/connector/)、およびチャートなどの [GraphicalObject](https://reference.aspose.com/slides/ja/python-java/aspose.slides/graphicalobject/) インスタンスがあります。

以下の例は、いくつかの一般的なシェイプタイプを作成し、それぞれにモダンコメントを関連付けます。

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

### **テキストにコメントを固定しステータスを設定する**

[AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) に関連付けられたモダンコメントの場合、[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#getTextSelectionStart) と [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#setTextSelectionStart) はシェイプのテキストフレーム内で選択されたテキストの開始位置にアクセスします。[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#getTextSelectionLength) と [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#setTextSelectionLength) は選択範囲の長さにアクセスします。これらの値を組み合わせることで、コメントを AutoShape 内の特定のテキスト範囲に関連付けます。

[ModernComment.getStatus](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#getStatus) と [ModernComment.setStatus](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#setStatus) メソッドは、[ModernCommentStatus](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncommentstatus/) 定数から次の値にアクセスします：

- [NotDefined](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncommentstatus/#NotDefined) — 特定のモダンコメントステータスが定義されていません。
- [Active](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncommentstatus/#Active) — コメントがアクティブです。
- [Resolved](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncommentstatus/#Resolved) — コメントが解決済みです。
- [Closed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncommentstatus/#Closed) — コメントがクローズされています。

以下の例は、シェイプに固定されたモダンコメントを作成し、テキスト選択に関連付け、解決済みとしてマークし、プレゼンテーションを保存してファイルを再度開いた後に値を検証します。

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

### **既存のモダンコメントを検査する**

既存のプレゼンテーションを検査するには、どのコメントが [ModernComment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/) のインスタンスであるかを確認し、[ModernComment.getShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#getShape)、[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#getTextSelectionStart)、[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#getTextSelectionLength)、および [ModernComment.getStatus](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#getStatus) を調べます。`None` のシェイプはスライドレベルのコメントを示します。[AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) に固定された場合、テキスト選択メソッドはシェイプのテキストフレーム内の関連範囲を特定します。

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

## **コメントの削除**

### **すべてのコメントとコメント作成者を削除する**

以下の例は、プレゼンテーションからすべてのコメントとコメント作成者を削除する方法を示しています。

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

### **特定のコメントを削除する**

以下の例は、スライドから特定のコメントを削除する方法を示しています。

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

**Aspose.Slides はモダンコメントの解決ステータスをサポートしていますか？**

はい。[ModernComment.getStatus](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#getStatus) と [ModernComment.setStatus](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncomment/#setStatus) は、`Resolved` を含む [ModernCommentStatus](https://reference.aspose.com/slides/ja/python-java/aspose.slides/moderncommentstatus/) の値にアクセスできます。ステータスはプレゼンテーションに保存され、ファイルを再度開いた後でも読み取れます。

**スレッド化されたディスカッション（返信チェーン）はサポートされますか？また、ネストの上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/comment/#getParentComment) を参照できるため、返信チェーンが可能です。API には特定のネスト深度の制限は定義されていません。

**コメントマーカーの位置はスライド上のどの座標系で定義されていますか？**

マーカー位置はスライド座標系の浮動小数点座標で定義されるため、スライド上の任意の場所に正確に配置できます。