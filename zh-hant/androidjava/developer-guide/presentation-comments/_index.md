---
title: 在 Android 上管理簡報評論
linktitle: 簡報評論
type: docs
weight: 100
url: /zh-hant/androidjava/presentation-comments/
keywords:
- 評論
- 現代評論
- PowerPoint 評論
- 簡報評論
- 投影片評論
- 新增評論
- 存取評論
- 編輯評論
- 回覆評論
- 移除評論
- 刪除評論
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 來管理簡報評論：快速且輕鬆地在 PowerPoint 簡報中新增、閱讀、編輯、回覆以及移除評論。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Android via Java 來管理簡報評論。它會介紹主要的與評論相關的型別，並示範如何在投影片上新增評論、存取現有評論、處理回覆與現代評論，以及如何從簡報中移除評論。

這些範例涵蓋 PowerPoint 中常見的審閱與協作情境，例如指派評論給作者、讀取評論文字與中繼資料、建立回覆鏈，以及移除選取的評論或全部評論。

在 PowerPoint 中，評論會以註記的形式顯示在投影片上。選取評論時會顯示其文字與相關討論。

## **為何在簡報中加入評論？**

在審閱簡報時，可使用評論提供回饋並與同事協作。

Aspose.Slides for Android via Java 提供以下 API 以操作評論：

* [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別，提供存取簡報評論作者的功能。
* [ICommentCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icommentcollection/) 介面，代表與特定作者相關的評論集合。
* [IComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icomment/) 介面，提供評論的資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/commentauthor/) 類別，提供作者資訊，包含名稱、縮寫與關聯的評論。

## **新增投影片評論**

以下範例示範如何在 PowerPoint 簡報的投影片中新增評論：

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

## **存取投影片評論**

以下範例示範如何在 PowerPoint 簡報中存取現有評論：

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

## **回覆評論**

父評論是回覆層級頂端的原始評論。[IComment.getParentComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icomment/#getParentComment--) 與 [IComment.setParentComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 方法可讓您取得或設定評論的父項。

以下範例示範如何新增回覆並檢查產生的評論層級結構：

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

{{% alert color="warning" title="警告" %}}
* 使用 [IComment.remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icomment/#remove--) 方法刪除評論時，該評論的所有回覆也會一起被刪除。
* 若 [IComment.setParentComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 產生循環參照，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **新增現代評論**

現代評論可以與投影片本身、特定形狀，或 AutoShape 內的文字範圍關聯。 [ICommentCollection.addModernComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) 方法除了接受投影片與評論標記座標外，亦接受一個 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 參數。

當傳入 `null` 作為形狀參數時，該評論為投影片層級的評論。其標記位置由提供的座標決定，但不會與特定形狀關聯，因此 [IModernComment.getShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#getShape--) 會回傳 `null`。若提供了 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/)，則評論會錨定在該形狀上。座標仍然決定評論標記在投影片上的位置，而形狀的關聯可透過 [IModernComment.getShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#getShape--) 取得。

### **將現代評論錨定至形狀**

以下範例同時建立投影片層級的現代評論以及錨定於特定 AutoShape 的現代評論，並讀取每個評論所關聯的形狀：

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

### **將評論錨定至不同類型的形狀**

任何實作了 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 的投影片物件皆可作為形狀錨點。常見的例子包括 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iconnector/) 與 [IGraphicalObject](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/igraphicalobject/)（如圖表）等實例。

以下範例建立多種常見形狀類型，並為每一個形狀關聯一則現代評論：

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

### **將評論錨定至文字並設定其狀態**

對於關聯於 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 的現代評論，[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) 與 [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) 可取得形狀文字框中所選文字的起始位置。 [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 與 [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) 可取得選取的長度。這兩個值共同將評論與 AutoShape 內的特定文字範圍關聯起來。

[IModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#getStatus--) 與 [IModernComment.setStatus](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) 方法可取得 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/moderncommentstatus/) 常數中的值：

- `NotDefined` — 未定義特定的現代評論狀態。
- `Active` — 評論處於活躍狀態。
- `Resolved` — 評論已解決。
- `Closed` — 評論已關閉。

以下範例建立一個錨定於形狀的現代評論，將其與文字選取關聯，標記為已解決，儲存簡報，並在重新開啟檔案後驗證各項值：

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

### **檢查現有的現代評論**

要檢查現有的簡報，先判斷哪些評論實作了 [IModernComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/)，之後檢查 [IModernComment.getShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#getShape--)、[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--)、[IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 與 [IModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#getStatus--)。`null` 形狀表示投影片層級的評論。若是以 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 為錨點，文字選取方法會指出該形狀文字框中相關的文字範圍。

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

## **移除評論**

### **移除所有評論與評論作者**

以下範例示範如何從簡報中移除所有評論與評論作者：

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

### **移除特定評論**

以下範例示範如何從投影片中移除特定評論：

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

## **常見問題**

**Aspose.Slides 是否支援現代評論的已解決狀態？**

是的。 [IModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#getStatus--) 與 [IModernComment.setStatus](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) 可取得 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/moderncommentstatus/) 中的值，包括 `Resolved`。此狀態會儲存在簡報中，重新開啟檔案後仍可再次讀取。

**是否支援串接式討論（回覆鏈），且有巢狀深度限制嗎？**

支援。每則評論都可以參照其 [parent comment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icomment/#getParentComment--)，從而形成回覆鏈。API 並未定義特定的巢狀深度上限。

**評論標記在投影片上的位置使用哪種座標系統定義？**

標記位置是以浮點座標在投影片座標系統中定義的，允許您精確地將其放置於投影片的任意位置。