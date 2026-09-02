---
title: Quản lý bình luận trong bài thuyết trình trên Android
linktitle: Bình luận bài thuyết trình
type: docs
weight: 100
url: /vi/androidjava/presentation-comments/
keywords:
- bình luận
- bình luận hiện đại
- bình luận PowerPoint
- bình luận bài thuyết trình
- bình luận slide
- thêm bình luận
- truy cập bình luận
- chỉnh sửa bình luận
- trả lời bình luận
- xóa bình luận
- xoá bình luận
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Quản lý bình luận trong bài thuyết trình với Aspose.Slides cho Android qua Java: thêm, đọc, chỉnh sửa, trả lời và xóa bình luận trong các bài thuyết trình PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý bình luận trong bài thuyết trình bằng Aspose.Slides for Android via Java. Nó giới thiệu các kiểu liên quan đến bình luận chính và trình bày cách thêm bình luận vào các slide, truy cập các bình luận hiện có, làm việc với các trả lời và bình luận hiện đại, và xóa bình luận khỏi một bài thuyết trình.

Các ví dụ bao phủ các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán bình luận cho tác giả, đọc nội dung và siêu dữ liệu của bình luận, xây dựng chuỗi trả lời, và xóa các bình luận đã chọn hoặc tất cả các bình luận.

Trong PowerPoint, bình luận xuất hiện như các chú thích trên slide. Chọn một bình luận sẽ hiển thị nội dung và cuộc thảo luận liên quan.

## **Tại sao nên thêm bình luận vào bài thuyết trình?**

Bạn có thể sử dụng bình luận để cung cấp phản hồi và hợp tác với đồng nghiệp khi xem xét các bài thuyết trình.

Aspose.Slides for Android via Java cung cấp các API sau để làm việc với bình luận:

* Lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) cung cấp quyền truy cập vào các tác giả bình luận của bài thuyết trình.
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icommentcollection/) đại diện cho các bình luận được liên kết với một tác giả cụ thể.
* Giao diện [IComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icomment/) cung cấp thông tin về một bình luận, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, ký hiệu và các bình luận liên quan.

## **Thêm bình luận vào slide**

Ví dụ sau đây cho thấy cách thêm bình luận vào các slide trong một bài thuyết trình PowerPoint:

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

## **Truy cập bình luận của slide**

Ví dụ sau đây cho thấy cách truy cập các bình luận hiện có trong một bài thuyết trình PowerPoint:

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

## **Trả lời bình luận**

Một bình luận cha là bình luận gốc ở đầu cấp độ trả lời. Các phương thức [IComment.getParentComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icomment/#getParentComment--) và [IComment.setParentComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) cho phép bạn lấy hoặc đặt bình luận cha.

Ví dụ sau đây cho thấy cách thêm các trả lời và kiểm tra cấu trúc phân cấp bình luận kết quả:

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
* Khi phương thức [IComment.remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icomment/#remove--) được sử dụng để xóa một bình luận, tất cả các trả lời cho bình luận đó cũng sẽ bị xóa.
* Nếu [IComment.setParentComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxeditexception/) sẽ được ném ra.
{{% /alert %}}

## **Thêm bình luận hiện đại**

Bình luận hiện đại có thể được liên kết với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong một AutoShape. Phương thức [ICommentCollection.addModernComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) chấp nhận một đối số [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) ngoài slide và các tọa độ của dấu đánh dấu bình luận.

Khi truyền `null` cho tham số shape, bình luận sẽ là bình luận cấp slide. Dấu đánh dấu của nó được định vị bằng các tọa độ cung cấp, nhưng không gắn với một hình dạng cụ thể, vì vậy [IModernComment.getShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#getShape--) trả về `null`. Khi cung cấp một [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/), bình luận được neo vào hình dạng đó. Các tọa độ vẫn xác định vị trí của dấu đánh dấu bình luận trên slide, trong khi việc liên kết với hình dạng có thể được truy xuất qua [IModernComment.getShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#getShape--).

### **Neót một bình luận hiện đại vào hình dạng**

Ví dụ sau tạo cả một bình luận hiện đại cấp slide và một bình luận hiện đại được neo vào một AutoShape cụ thể. Sau đó đọc hình dạng liên quan từ mỗi bình luận.

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

### **Neót bình luận vào các loại hình dạng khác nhau**

Bất kỳ đối tượng slide nào triển khai [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) đều có thể được sử dụng làm neo hình dạng. Các ví dụ phổ biến bao gồm [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iconnector/) và các thể hiện [IGraphicalObject](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/igraphicalobject/) như biểu đồ.

Ví dụ sau tạo một số loại hình dạng phổ biến và gắn một bình luận hiện đại vào mỗi loại.

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

### **Neót bình luận vào văn bản và đặt trạng thái**

Đối với một bình luận hiện đại liên kết với một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/), các phương thức [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) và [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) truy cập vị trí bắt đầu của đoạn văn bản được chọn trong khung văn bản của hình dạng. Các phương thức [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) và [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) truy cập độ dài của phần chọn. Cùng nhau, các giá trị này liên kết bình luận với một phạm vi văn bản cụ thể bên trong AutoShape.

Các phương thức [IModernComment.getStatus](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#getStatus--) và [IModernComment.setStatus](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) truy cập một giá trị từ các hằng số [ModernCommentStatus](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — không có trạng thái bình luận hiện đại cụ thể nào được định nghĩa.
- `Active` — bình luận đang hoạt động.
- `Resolved` — bình luận đã được giải quyết.
- `Closed` — bình luận đã đóng.

Ví dụ sau tạo một bình luận hiện đại neo vào hình dạng, liên kết nó với một lựa chọn văn bản, đánh dấu là đã giải quyết, lưu bài thuyết trình và xác minh các giá trị sau khi mở lại tệp.

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

### **Kiểm tra các bình luận hiện đại hiện có**

Để kiểm tra một bài thuyết trình hiện có, xác định các bình luận triển khai [IModernComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/), sau đó kiểm tra [IModernComment.getShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) và [IModernComment.getStatus](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Một hình dạng `null` cho biết bình luận cấp slide. Đối với neo [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/), các phương thức lựa chọn văn bản xác định phạm vi liên quan trong khung văn bản của hình dạng.

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

## **Xóa bình luận**

### **Xóa tất cả bình luận và tác giả bình luận**

Ví dụ sau cho thấy cách xóa tất cả bình luận và tác giả bình luận khỏi một bài thuyết trình:

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

### **Xóa bình luận cụ thể**

Ví dụ sau cho thấy cách xóa các bình luận cụ thể khỏi một slide:

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

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho bình luận hiện đại không?**

Có. Các phương thức [IModernComment.getStatus](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#getStatus--) và [IModernComment.setStatus](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) truy cập một giá trị [ModernCommentStatus](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái được lưu trong bài thuyết trình và có thể được đọc lại sau khi mở lại tệp.

**Các cuộc thảo luận dạng chuỗi (chuỗi trả lời) có được hỗ trợ không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi bình luận có thể tham chiếu đến [bình luận cha](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icomment/#getParentComment--) của nó, cho phép tạo chuỗi trả lời. API không định nghĩa một giới hạn cụ thể về độ sâu lồng nhau.

**Vị trí của dấu đánh dấu bình luận trên slide được xác định trong hệ tọa độ nào?**

Vị trí dấu đánh dấu được xác định bằng các tọa độ dạng số thực trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.