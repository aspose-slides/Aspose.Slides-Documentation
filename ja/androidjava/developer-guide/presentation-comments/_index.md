---
title: Android でのプレゼンテーション コメントの管理
linktitle: プレゼンテーション コメント
type: docs
weight: 100
url: /ja/androidjava/presentation-comments/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してプレゼンテーション コメントを管理します。PowerPoint プレゼンテーション内のコメントを簡単かつ迅速に追加、読み取り、編集、返信、削除できます。"
---
## **概要**

この記事では、Aspose.Slides for Android via Java を使用してプレゼンテーションのコメントを管理する方法を説明します。主なコメント関連の型を紹介し、スライドへのコメントの追加、既存コメントへのアクセス、返信やモダンコメントの操作、プレゼンテーションからのコメントの削除方法をデモンストレーションします。

これらの例は、PowerPoint での一般的なレビューおよびコラボレーションシナリオ、例えばコメントを作者に割り当てる、コメントのテキストやメタデータを読み取る、返信チェーンを構築する、選択したコメントまたはすべてのコメントを削除する、などをカバーしています。

PowerPoint では、コメントはスライド上の注釈として表示されます。コメントを選択すると、そのテキストと関連するディスカッションが表示されます。

## **なぜプレゼンテーションにコメントを追加するのか？**

プレゼンテーションをレビューする際に、コメントを使用してフィードバックを提供したり、同僚と共同作業したりできます。

Aspose.Slides for Android via Java は、コメント操作のために以下の API を提供します：

* The [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [ICommentCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icommentcollection/) interface, which represents the comments associated with an individual author.
* The [IComment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icomment/) interface, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **スライドコメントの追加**

次の例は、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    PointF position = new PointF(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **スライドコメントへのアクセス**

次の例は、PowerPoint プレゼンテーション内の既存コメントにアクセスする方法を示しています：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **コメントへの返信**

親コメントは、返信階層の最上部にある元のコメントです。`[IComment.getParentComment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icomment/#getParentComment--)` および `[IComment.setParentComment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-)` メソッドを使用して、コメントの親を取得または設定できます。

次の例は、返信を追加し、 resulting comment hierarchy を検査する方法を示しています：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    PointF position = new PointF(10, 10);
    Date createdTime = new Date();

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* `[IComment.remove](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icomment/#remove--)` メソッドでコメントを削除すると、そのコメントへのすべての返信も削除されます。
* `[IComment.setParentComment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-)` が循環参照を作成すると、`[PptxEditException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxeditexception/)` がスローされます。
{{% /alert %}}

## **モダンコメントの追加**

モダンコメントは、スライド自体、特定のシェイプ、または AutoShape 内のテキスト範囲に関連付けることができます。`[ICommentCollection.addModernComment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-)` メソッドは、スライドとコメントマーカー座標に加えて `[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/)` 引数を受け取ります。

`null` がシェイプ引数として渡された場合、コメントはスライドレベルのコメントとなります。そのマーカーは提供された座標で配置されますが、特定のシェイプには関連付けられないため、`[IModernComment.getShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#getShape--)` は `null` を返します。`[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/)` が指定された場合、コメントはそのシェイプに固定されます。座標は依然としてスライド上のコメントマーカーの位置を定義し、シェイプの関連付けは `[IModernComment.getShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#getShape--)` を通じて取得できます。

### **モダンコメントをシェイプに固定する**

次の例は、スライドレベルのモダンコメントと特定の AutoShape に固定されたモダンコメントの両方を作成し、各コメントから関連シェイプを取得します。

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    PointF slideCommentPosition = new PointF(20, 20);
    PointF shapeCommentPosition = new PointF(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **異なるシェイプタイプへのコメント固定**

`[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/)` を実装する任意のスライドオブジェクトをシェイプのアンカーとして使用できます。一般的な例として、`[IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/)`、`[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/)`、`[IGroupShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/igroupshape/)`、`[IConnector](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iconnector/)`、およびチャートなどの `[IGraphicalObject](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/igraphicalobject/)` インスタンスがあります。

次の例は、いくつかの一般的なシェイプタイプを作成し、各シェイプにモダンコメントを関連付けます。

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    PointF autoShapeCommentPosition = new PointF(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    PointF pictureCommentPosition = new PointF(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    PointF groupCommentPosition = new PointF(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    PointF connectorCommentPosition = new PointF(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    PointF chartCommentPosition = new PointF(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **テキストへのコメント固定とステータス設定**

`[IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/)` に関連付けられたモダンコメントの場合、`[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--)` および `[IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-)` はシェイプのテキストフレーム内で選択されたテキストの開始位置にアクセスします。`[IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--)` および `[IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-)` は選択範囲の長さにアクセスします。これらの値により、コメントは AutoShape 内の特定のテキスト範囲に関連付けられます。

`[IModernComment.getStatus](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#getStatus--)` および `[IModernComment.setStatus](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-)` メソッドは、`[ModernCommentStatus](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/moderncommentstatus/)` 定数から次のいずれかの値にアクセスします：

- `NotDefined` — 特定のモダンコメントステータスは定義されていません。
- `Active` — コメントはアクティブです。
- `Resolved` — コメントは解決済みです。
- `Closed` — コメントはクローズされています。

次の例は、シェイプに固定されたモダンコメントを作成し、テキスト選択に関連付け、解決済みとしてマークし、プレゼンテーションを保存してからファイルを再度開いた際に値を検証します。

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    PointF commentPosition = new PointF(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **既存のモダンコメントの検査**

既存のプレゼンテーションを検査するには、どのコメントが `[IModernComment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/)` を実装しているか確認し、次に `[IModernComment.getShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#getShape--)`、`[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--)`、`[IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--)`、および `[IModernComment.getStatus](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#getStatus--)` を調べます。`null` のシェイプはスライドレベルのコメントを示します。`[IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/)` がアンカーの場合、テキスト選択メソッドはシェイプのテキストフレーム内の関連範囲を特定します。

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **コメントの削除**

### **すべてのコメントとコメント作成者の削除**

次の例は、プレゼンテーションからすべてのコメントとコメント作成者を削除する方法を示しています：

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **特定のコメントの削除**

次の例は、スライドから特定のコメントを削除する方法を示しています：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    PointF firstCommentPosition = new PointF(0.2f, 0.2f);
    PointF secondCommentPosition = new PointF(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides はモダンコメントの解決済みステータスをサポートしていますか？**

はい。`[IModernComment.getStatus](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#getStatus--)` および `[IModernComment.setStatus](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-)` は `[ModernCommentStatus](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/moderncommentstatus/)` の値にアクセスでき、`Resolved` を含みます。このステータスはプレゼンテーションに保存され、ファイルを再度開いた後でも読み取ることができます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？ ネストの上限はありますか？**

はい。各コメントは `[parent comment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icomment/#getParentComment--)` を参照できるため、返信チェーンを実現できます。API には特定のネスト深さ上限は定義されていません。

**スライド上のコメントマーカーの位置はどの座標系で定義されていますか？**

マーカーポジションはスライド座標系の浮動小数点座標で定義されており、スライド上の任意の位置に正確に配置できます。