---
title: Quản lý nhận xét bản trình bày trong Node.js
linktitle: Nhận xét bản trình bày
type: docs
weight: 100
url: /vi/nodejs-java/presentation-comments/
keywords:
- nhận xét
- nhận xét hiện đại
- nhận xét PowerPoint
- nhận xét bản trình bày
- nhận xét slide
- thêm nhận xét
- truy cập nhận xét
- chỉnh sửa nhận xét
- trả lời nhận xét
- xoá nhận xét
- xóa nhận xét
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý nhận xét bản trình bày với Aspose.Slides cho Node.js thông qua Java: thêm, đọc, chỉnh sửa, trả lời và xóa nhận xét trong các bản trình bày PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bản trình bày bằng Aspose.Slides cho Node.js thông qua Java. Nó giới thiệu các kiểu liên quan đến nhận xét chính và trình bày cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với các phản hồi và nhận xét hiện đại, và xóa nhận xét khỏi bản trình bày.

Các ví dụ bao gồm các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi trả lời, và xóa các nhận xét đã chọn hoặc tất cả các nhận xét.

Trong PowerPoint, nhận xét xuất hiện dưới dạng chú thích trên các slide. Khi chọn một nhận xét, nội dung và cuộc thảo luận liên quan sẽ được hiển thị.

Để yêu cầu hiển thị hoặc ẩn nhận xét khi mở một bản trình bày mà không thay đổi các nhận xét, hãy xem [Show or Hide Comments When Opening a Presentation](/slides/vi/nodejs-java/presentation-view-properties/).

## **Tại sao cần thêm nhận xét vào bản trình bày?**

Bạn có thể sử dụng nhận xét để đưa ra phản hồi và cộng tác với đồng nghiệp khi xem xét bản trình bày.

Aspose.Slides cho Node.js thông qua Java cung cấp các API sau để làm việc với nhận xét:

* Lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) cung cấp quyền truy cập vào các tác giả nhận xét của bản trình bày.
* Lớp [CommentCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/commentcollection/) đại diện cho các nhận xét liên quan đến một tác giả cụ thể.
* Lớp [Comment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/) cung cấp thông tin về một nhận xét, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, chữ viết tắt và các nhận xét liên quan.

## **Thêm Nhận xét cho Slide**

Ví dụ sau cho thấy cách thêm nhận xét vào các slide trong một bản trình bày PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Truy cập Nhận xét của Slide**

Ví dụ sau cho thấy cách truy cập các nhận xét hiện có trong một bản trình bày PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Trả lời Nhận xét**

Một nhận xét cha là nhận xét gốc ở đầu của một cấu trúc trả lời. Các phương thức [Comment.getParentComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/getparentcomment/) và [Comment.setParentComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/setparentcomment/) cho phép bạn lấy hoặc đặt nhận xét cha của một nhận xét.

Ví dụ sau cho thấy cách thêm phản hồi và kiểm tra cấu trúc nhận xét kết quả:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Khi phương thức [Comment.remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/remove/) được sử dụng để xóa một nhận xét, tất cả các phản hồi của nhận xét đó cũng sẽ bị xóa.
* Nếu [Comment.setParentComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/setparentcomment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxeditexception/) sẽ bị ném.
{{% /alert %}}

## **Thêm Nhận xét Hiện đại**

Nhận xét hiện đại có thể được liên kết với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/). Phương thức [CommentCollection.addModernComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) chấp nhận một đối số [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) ngoài slide và tọa độ của dấu nhận xét.

Khi `null` được truyền cho đối số shape, nhận xét là một nhận xét ở mức slide. Dấu của nó được định vị bằng các tọa độ đã cung cấp, nhưng không được liên kết với một shape cụ thể, vì vậy [ModernComment.getShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getshape/) trả về `null`. Khi một [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) được cung cấp, nhận xét được gắn vào shape đó. Các tọa độ vẫn xác định vị trí của dấu nhận xét trên slide, trong khi việc liên kết shape có thể được lấy thông qua [ModernComment.getShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Gắn Nhận xét Hiện đại vào một Shape**

Ví dụ sau tạo cả một nhận xét hiện đại ở mức slide và một nhận xét hiện đại được gắn vào một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) cụ thể. Sau đó nó đọc shape liên quan từ mỗi nhận xét.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gắn Nhận xét vào Các Loại Shape Khác nhau**

Bất kỳ đối tượng slide nào kế thừa từ [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) đều có thể được sử dụng làm điểm gắn shape. Các ví dụ phổ biến bao gồm [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/connector/), và các thể hiện [GraphicalObject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sau tạo một số loại shape phổ biến và gắn một nhận xét hiện đại vào mỗi shape.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gắn Nhận xét vào Văn bản và Đặt Trạng Thái**

Đối với một nhận xét hiện đại liên kết với một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/), các phương thức [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) và [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) truy cập vị trí bắt đầu của văn bản được chọn trong khung văn bản của shape. Các phương thức [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) và [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) truy cập độ dài của vùng chọn. Cùng nhau, các giá trị này liên kết nhận xét với một đoạn văn bản cụ thể bên trong [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).

Các phương thức [ModernComment.getStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getstatus/) và [ModernComment.setStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị từ liệt kê [ModernCommentStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncommentstatus/) :

- `NotDefined` — không có trạng thái nhận xét hiện đại cụ thể nào được định nghĩa.
- `Active` — nhận xét đang hoạt động.
- `Resolved` — nhận xét đã được giải quyết.
- `Closed` — nhận xét đã đóng.

Ví dụ sau tạo một nhận xét hiện đại được gắn vào shape, liên kết nó với một đoạn văn bản được chọn, đánh dấu là đã giải quyết, lưu bản trình bày và xác minh các giá trị sau khi mở lại tệp.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Kiểm tra Nhận xét Hiện đại hiện có**

Để kiểm tra một bản trình bày hiện có, xác định các nhận xét là các thể hiện của [ModernComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/), sau đó kiểm tra [ModernComment.getShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), và [ModernComment.getStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getstatus/). Một shape `null` cho biết là nhận xét ở mức slide. Đối với một anchor [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/), các phương thức lựa chọn văn bản xác định đoạn văn bản liên quan trong khung văn bản của shape.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Xóa Nhận xét**

### **Xóa Tất cả Nhận xét và Tác giả Nhận xét**

Ví dụ sau cho thấy cách xóa tất cả nhận xét và tác giả nhận xét khỏi một bản trình bày:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Xóa Nhận xét Cụ thể**

Ví dụ sau cho thấy cách xóa các nhận xét cụ thể khỏi một slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho nhận xét hiện đại không?**

Có. Các phương thức [ModernComment.getStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getstatus/) và [ModernComment.setStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị [ModernCommentStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái này được lưu trong bản trình bày và có thể được đọc lại sau khi tệp được mở lại.

**Các cuộc thảo luận dạng chuỗi (reply chains) có được hỗ trợ không, và có giới hạn về mức độ lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu tới [parent comment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/getparentcomment/), cho phép tạo chuỗi trả lời. API không định nghĩa giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu nhận xét trên slide được xác định trong hệ tọa độ nào?**

Vị trí của dấu nhận xét được xác định bằng các tọa độ dấu chấm thập phân trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.