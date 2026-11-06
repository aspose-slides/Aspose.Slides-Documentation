---
title: 管理 Android 上的簡報註解
linktitle: 簡報註解
type: docs
weight: 100
url: /zh-hant/androidjava/presentation-comments/
keywords:
- 註解
- 現代註解
- PowerPoint 註解
- 簡報註解
- 投影片註解
- 新增註解
- 存取註解
- 編輯註解
- 回覆註解
- 移除註解
- 刪除註解
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 管理簡報註解：在 PowerPoint 簡報中快速輕鬆地新增、讀取、編輯、回覆以及移除註解。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Android via Java 來管理簡報註解。它介紹了主要的註解相關類型，並示範如何在投影片上新增註解、存取現有註解、處理回覆與現代註解，以及從簡報中移除註解。  
這些範例涵蓋了 PowerPoint 中常見的審閱與協作情境，例如將註解指派給作者、讀取註解文字與中繼資料、建立回覆鏈，以及移除選取的註解或全部註解。  
在 PowerPoint 中，註解以投影片上的標註形式顯示。選取註解時會顯示其文字及相關討論。  
在簡報開啟時要求顯示或隱藏註解（不變更註解本身），請參閱[在開啟簡報時顯示或隱藏註解](/slides/zh-hant/androidjava/presentation-view-properties/)。

## **為何在簡報中加入註解？**

在審閱簡報時，您可以使用註解提供回饋並與同事協作。  
Aspose.Slides for Android via Java 為處理註解提供以下 API：

* [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別，提供存取簡報的註解作者。
* [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/) 介面，代表與單一作者相關的註解集合。
* [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/) 介面，提供註解資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/) 類別，提供作者資訊，包括名稱、縮寫與相關註解。

## **新增投影片註解**

此範例建立兩張投影片，並使用 [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) 註冊一位註解作者。它使用 [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) 在每張投影片上放置一則註解，然後使用 [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) 取得該作者在第一張投影片的註解。主控台會兩次顯示第一則註解的文字，示範透過投影片與作者兩種方式存取，且儲存的簡報包含兩則註解。

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

        String commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **尋找或建立註解作者**

當自動化審閱重複處理相同簡報時，於新增作者之前先搜尋由 [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) 回傳的集合。[findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) 同時比對名稱與縮寫，回傳符合的作者陣列；若無符合則回傳空陣列。相比之下，[findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) 只依名稱搜尋，與縮寫無關。若以已存在於集合中的名稱與縮寫呼叫 [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-)，將拋出例外。  
此範例需要一個至少包含一張投影片的簡報檔案。於兩次執行中，若找到匹配的作者則重複使用第一個匹配者，只有在結果為空時才建立新作者。若有多筆匹配，會選取陣列的第一個元素，而不合併或移除其他作者。接著對選定的作者呼叫 [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) 並儲存簡報。第二次執行會開啟第一次的輸出檔並重複此操作。

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

final String authorName = "Reviewer";
final String authorInitials = "RV";

String inputFile = "input.pptx";
PointF position = new PointF(20, 20);

for (int pass = 1; pass <= 2; pass++) {
    Presentation presentation = new Presentation(inputFile);
    try {
        ICommentAuthor[] matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        ICommentAuthor author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, new Date());

        String outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

第二次執行會新增另一則註解，但不會新增作者或移除現有註解。最終檔案 `review_pass_2.pptx` 同時包含兩則新註解以及任何原有註解。重複使用作者不會去除重複的註解：若要避免重複加入相同註解，請在新增前自行實作重複偵測機制。

## **存取投影片註解**

此範例開啟現有簡報，讀取由 [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) 回傳的集合。對每位作者，遍歷由 [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--) 回傳的集合，並印出投影片編號、註解文字、作者名稱與建立時間。輸入的簡報必須包含註解才能產生主控台輸出。

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

## **回覆註解**

父註解是回覆層級最上層的原始註解。[IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) 與 [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 方法可取得或設定註解的父註解。  
此範例由兩位作者建立註解，並使用 [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 建立回覆，包括對其他回覆的回覆。將 `null` 傳遞給 [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) 會取得所有作者的註解；主控台會根據回覆層級深度縮排每筆條目。範例將完整討論儲存後，對第一個根註解呼叫 [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--)，並儲存第二個簡報，該簡報已移除該註解及其回覆。

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

    ICommentAuthor originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    IComment secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    IComment subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    IComment separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    IComment separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* 使用 [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) 方法刪除註解時，該註解的所有回覆也會被刪除。  
* 若 [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 產生循環參照，則會拋出 [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **新增現代註解**

現代註解可以關聯到投影片本身、特定圖形，或 AutoShape 內的文字範圍。[ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) 方法接受一個 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 參數，此外還需提供投影片與註解標記的座標。  
當形狀參數傳入 `null` 時，註解為投影片層級的註解。其標記依提供的座標定位，但不與特定圖形關聯，因而 [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) 會回傳 `null`。若提供 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 則註解錨定於該圖形。座標仍決定註解標記在投影片上的位置，圖形關聯可透過 [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) 取得。

### **將現代註解錨定至圖形**

此範例呼叫兩次 [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-)：一次以 `null` 圖形建立投影片層級的註解，另一次以矩形作為錨點。讀取 [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) 時，投影片層級註解的空檢查會印出 `true`，而錨定的註解則印出 `Revenue title`。兩則註解皆隨簡報一起儲存。

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

### **將註解錨定至不同類型的圖形**

任何實作 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 的投影片物件皆可作為圖形錨點。常見範例包括 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/) 以及 [IGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/)（如圖表）等實例。  
此範例使用 [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) 分別為五種圖形類型關聯註解：AutoShape、圖片框、群組、連接線與圖表。圖片使用嵌入式影像資料，無需外部影像。每則註解都有各自的標記位置，儲存的簡報會保留所有五個圖形的關聯。

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
import android.util.Base64;
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
    byte[] imageData = Base64.decode(imageBase64, Base64.DEFAULT);
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

### **將註解錨定至文字並設定其狀態**

對於關聯至 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) 的現代註解，[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) 與 [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) 取得圖形文字框中所選文字的起始位置。[IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 與 [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) 取得選取的長度。這兩者共同將註解與 AutoShape 內特定文字範圍關聯。  
[IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) 與 [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) 方法存取 [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) 常數中的值：

- `NotDefined` — 未定義特定的現代註解狀態。  
- `Active` — 註解為啟用狀態。  
- `Resolved` — 註解已解決。  
- `Closed` — 註解已關閉。  

此範例將現代註解錨定至矩形文字中的「quarterly revenue」字樣。它從文字計算零基的選取起始位置，並傳遞給 [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-)，再使用 [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) 設定選取的字元數。呼叫 [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) 並傳入 `Resolved` 後，儲存並重新開啟簡報。四個主控台檢查皆應印出 `true`，以確認圖形錨點、文字範圍與狀態均被保留。

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

### **檢查現有的現代註解**

此範例需要一個已包含現代註解的簡報，並印出其文字、狀態與錨點資訊。檢查時，先確認哪些註解實作 [IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/)，再檢視 [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--)、[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--)、[IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 與 [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--)。`null` 形狀表示投影片層級的註解。對於 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) 錨點，文字選取方法會指出在圖形文字框中的相關範圍。

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

## **移除註解**

Aspose.Slides for Android via Java 允許您從簡報中移除所有註解及其作者，或僅刪除選取的註解而保留其他部分。以下範例示範兩種做法，並儲存更新後的簡報。

### **移除所有註解與註解作者**

此範例開啟現有簡報，對每位作者呼叫 [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--)，接著呼叫 [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--) 移除作者本身。儲存的簡報不含註解與註解作者。請使用含有註解的簡報以觀察移除效果。

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

### **移除特定註解**

此範例在同一張投影片上建立兩則註解，並使用 [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) 依作者取得註解。它先收集文字等於「comment 1」的註解，然後呼叫 [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-)，以避免在選取過程中修改集合。儲存的簡報僅保留「comment 2」。

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

**Aspose.Slides 是否支援現代註解的已解決狀態？**  
是的。[IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) 與 [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) 可存取 [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) 的值，包括 `Resolved`。此狀態會儲存在簡報中，重新開啟檔案後仍可讀取。

**是否支援串接式討論（回覆鏈），且是否有限制巢狀深度？**  
是的。每則註解都可以參照其 [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--)，因此支援回覆鏈。API 並未定義具體的巢狀深度限制。

**註解標記在投影片上的位置是以什麼座標系統定義的？**  
標記位置以投影片座標系統的浮點座標定義，您可以精確地將其放置於投影片上。