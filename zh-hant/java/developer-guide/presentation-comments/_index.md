---
title: 在 Java 中管理簡報批註
linktitle: 簡報批註
type: docs
weight: 100
url: /zh-hant/java/presentation-comments/
keywords:
- 批註
- 現代批註
- PowerPoint 批註
- 簡報批註
- 投影片批註
- 新增批註
- 存取批註
- 編輯批註
- 回覆批註
- 移除批註
- 刪除批註
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 管理簡報批註：快速且輕鬆地在 PowerPoint 簡報中新增、讀取、編輯、回覆及移除批註。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Java 管理簡報批註。它介紹主要的批註相關型別，並示範如何將批註加入投影片、存取現有批註、處理回覆與現代批註，以及如何從簡報中移除批註。

這些範例涵蓋 PowerPoint 中常見的審閱與協作情境，例如指派批註給作者、讀取批註文字與中繼資料、建立回覆鏈，以及移除選取的批註或全部批註。

在 PowerPoint 中，批註會以註解的形式顯示在投影片上。選取批註時會顯示其文字與相關討論。

## **為何要在簡報中加入批註？**

在審閱簡報時，您可以使用批註提供回饋並與同事協作。

Aspose.Slides for Java 提供以下 API 以處理批註：

* [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別，可存取簡報的批註作者。
* [ICommentCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icommentcollection/) 介面，代表與單一作者相關的批註集合。
* [IComment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icomment/) 介面，提供關於批註的資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/commentauthor/) 類別，提供作者資訊，包括名稱、縮寫與相關批註。

## **加入投影片批註**

下列範例示範如何在 PowerPoint 簡報的投影片中加入批註：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    Point2D.Float position = new Point2D.Float(0.2f, 0.2f);
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

## **存取投影片批註**

下列範例示範如何存取 PowerPoint 簡報中的現有批註：

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

## **回覆批註**

父批註是回覆層級最上層的原始批註。[IComment.getParentComment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icomment/#getParentComment--) 與 [IComment.setParentComment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 方法讓您取得或設定批註的父批註。

下列範例示範如何加入回覆並檢查產生的批註層級結構：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Point2D.Float position = new Point2D.Float(10, 10);
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
* 當使用 [IComment.remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icomment/#remove--) 方法刪除批註時，該批註的所有回覆亦會被刪除。  
* 若 [IComment.setParentComment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 產生循環參照，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxeditexception/)。  
{{% /alert %}}

## **加入現代批註**

現代批註可以關聯到投影片本身、特定圖形，或 AutoShape 內的文字範圍。[ICommentCollection.addModernComment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 方法除了接受投影片與批註標記座標外，還接受一個 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 參數。

當 shape 參數傳入 `null` 時，該批註為投影片層級批註。其標記位置由提供的座標決定，但不會與特定圖形關聯，因而 [IModernComment.getShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#getShape--) 會回傳 `null`。若傳入 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/)，則批註會錨定於該圖形。座標仍然決定批註標記在投影片上的位置，而圖形關聯可透過 [IModernComment.getShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#getShape--) 取得。

### **將現代批註錨定到圖形**

下列範例同時建立投影片層級的現代批註以及錨定於特定 AutoShape 的現代批註，然後讀取每個批註所關聯的圖形：

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    Point2D.Float slideCommentPosition = new Point2D.Float(20, 20);
    Point2D.Float shapeCommentPosition = new Point2D.Float(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **將批註錨定到不同類型的圖形**

任何實作 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 的投影片物件皆可作為圖形錨點。常見例子包括 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iconnector/) 與 [IGraphicalObject](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/igraphicalobject/)（如圖表）等實例。

下列範例建立多種常見圖形類型，並為每一個圖形關聯一個現代批註：

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
import java.awt.geom.Point2D;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    Point2D.Float autoShapeCommentPosition = new Point2D.Float(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    Point2D.Float pictureCommentPosition = new Point2D.Float(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    Point2D.Float groupCommentPosition = new Point2D.Float(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    Point2D.Float connectorCommentPosition = new Point2D.Float(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    Point2D.Float chartCommentPosition = new Point2D.Float(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **將批註錨定到文字並設定其狀態**

對於關聯於 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 的現代批註，[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) 與 [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) 可取得形狀文字框中選取文字的起始位置。[IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 與 [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) 可取得選取的長度。這兩個值共同將批註與 AutoShape 內的特定文字範圍關聯起來。

[IModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#getStatus--) 與 [IModernComment.setStatus](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#setStatus-byte-) 方法可取得或設定來自 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/moderncommentstatus/) 常數的值：

- `NotDefined` — 未定義特定的現代批註狀態。  
- `Active` — 批註為啟用狀態。  
- `Resolved` — 批註已解決。  
- `Closed` — 批註已關閉。  

下列範例建立一個錨定於圖形的現代批註，將其與文字選取關聯，標記為已解決，儲存簡報，並在重新開啟檔案後驗證其值：

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
import java.awt.geom.Point2D;
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
    Point2D.Float commentPosition = new Point2D.Float(60, 60);
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

### **檢查現有的現代批註**

若要檢查已存在的簡報，先確認哪些批註實作了 [IModernComment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/)，然後檢查 [IModernComment.getShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#getShape--)、[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--)、[IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 與 [IModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#getStatus--)。`null` 的 shape 表示此批註為投影片層級批註。若為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 錨點，文字選取方法會指出該圖形文字框中的相關範圍。

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

## **移除批註**

### **移除所有批註與批註作者**

下列範例示範如何移除簡報中的全部批註與批註作者：

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

### **移除特定批註**

下列範例示範如何從投影片中移除特定批註：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    Point2D.Float firstCommentPosition = new Point2D.Float(0.2f, 0.2f);
    Point2D.Float secondCommentPosition = new Point2D.Float(0.3f, 0.2f);
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

**Aspose.Slides 是否支援現代批註的已解決狀態？**

是的。[IModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#getStatus--) 與 [IModernComment.setStatus](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imoderncomment/#setStatus-byte-) 可存取 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/moderncommentstatus/) 值，包括 `Resolved`。此狀態會儲存在簡報中，重新開啟檔案後仍可讀取。

**是否支援串接討論（回覆鏈），且有巢狀深度限制嗎？**

是的。每個批註都可以參照其 [parent comment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icomment/#getParentComment--)，從而形成回覆鏈。API 並未定義特定的巢狀深度上限。

**批註標記在投影片上的位置是以哪種座標系統定義的？**

標記位置使用投影片座標系統的浮點座標，讓您能精確定位於投影片上的任意位置。