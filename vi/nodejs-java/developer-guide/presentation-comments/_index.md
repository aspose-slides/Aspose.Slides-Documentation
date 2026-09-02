---
title: Quản lý bình luận trên bản trình chiếu trong Node.js
linktitle: Bình luận bản trình chiếu
type: docs
weight: 100
url: /vi/nodejs-java/presentation-comments/
keywords:
- bình luận
- bình luận hiện đại
- bình luận PowerPoint
- bình luận bản trình chiếu
- bình luận slide
- thêm bình luận
- truy cập bình luận
- chỉnh sửa bình luận
- phản hồi bình luận
- loại bỏ bình luận
- xóa bình luận
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý bình luận trên bản trình chiếu bằng Aspose.Slides cho Node.js qua Java: thêm, đọc, chỉnh sửa, trả lời và xóa bình luận trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý bình luận trên bản trình chiếu bằng Aspose.Slides for Node.js via Java. Nó giới thiệu các kiểu dữ liệu liên quan đến bình luận và trình bày cách thêm bình luận vào các slide, truy cập các bình luận hiện có, làm việc với các phản hồi và bình luận hiện đại, và xoá bình luận khỏi bản trình chiếu.

Các ví dụ bao phủ các kịch bản xem xét và cộng tác thường gặp trong PowerPoint, chẳng hạn như chỉ định bình luận cho tác giả, đọc nội dung và siêu dữ liệu của bình luận, xây dựng chuỗi phản hồi, và xoá các bình luận đã chọn hoặc tất cả bình luận.

Trong PowerPoint, bình luận xuất hiện dưới dạng chú thích trên các slide. Khi chọn một bình luận, nội dung và cuộc thảo luận liên quan sẽ được hiển thị.

## **Tại sao phải thêm bình luận vào bản trình chiếu?**

Bạn có thể sử dụng bình luận để cung cấp phản hồi và cộng tác với đồng nghiệp khi xem xét bản trình chiếu.

Aspose.Slides for Node.js via Java cung cấp các API sau để làm việc với bình luận:

* Lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) cung cấp truy cập tới các tác giả bình luận của bản trình chiếu.
* Lớp [CommentCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/commentcollection/) đại diện cho các bình luận liên kết với một tác giả cụ thể.
* Lớp [Comment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/) cung cấp thông tin về một bình luận, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, chữ viết tắt và các bình luận liên quan.

## **Thêm bình luận cho slide**

Ví dụ sau cho thấy cách thêm bình luận vào các slide trong một bản trình chiếu PowerPoint:

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

## **Truy cập bình luận của slide**

Ví dụ sau cho thấy cách truy cập các bình luận hiện có trong một bản trình chiếu PowerPoint:

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

## **Phản hồi bình luận**

Một bình luận cha là bình luận gốc ở đầu cây phản hồi. Các phương thức [Comment.getParentComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/getparentcomment/) và [Comment.setParentComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/setparentcomment/) cho phép bạn lấy hoặc đặt bình luận cha.

Ví dụ sau cho thấy cách thêm phản hồi và kiểm tra cấu trúc cây bình luận kết quả:

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
* Khi sử dụng phương thức [Comment.remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/remove/) để xoá một bình luận, tất cả các phản hồi của bình luận đó cũng sẽ bị xoá.
* Nếu [Comment.setParentComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/setparentcomment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm bình luận hiện đại**

Bình luận hiện đại có thể được liên kết với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/). Phương thức [CommentCollection.addModernComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) nhận một đối số [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) bên cạnh slide và tọa độ của dấu đánh dấu bình luận.

Khi truyền `null` cho đối số shape, bình luận sẽ là bình luận cấp slide. Dấu đánh dấu của nó được định vị bằng các tọa độ đã cung cấp, nhưng không được liên kết với một shape cụ thể, do đó [ModernComment.getShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getshape/) trả về `null`. Khi cung cấp một [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/), bình luận sẽ được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu đánh dấu trên slide, trong khi việc liên kết với shape có thể được truy xuất qua [ModernComment.getShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Neo một bình luận hiện đại vào shape**

Ví dụ sau tạo cả một bình luận hiện đại cấp slide và một bình luận hiện đại được neo vào một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) cụ thể. Sau đó nó đọc shape liên quan từ mỗi bình luận.

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

### **Neo bình luận vào các loại shape khác nhau**

Bất kỳ đối tượng slide nào kế thừa từ [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) đều có thể được dùng làm anchor cho shape. Các ví dụ phổ biến bao gồm [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/connector/), và các đối tượng [GraphicalObject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sau tạo một số loại shape thông dụng và liên kết một bình luận hiện đại với mỗi shape.

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

### **Neo bình luận vào văn bản và đặt trạng thái**

Đối với một bình luận hiện đại được liên kết với một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/), các phương thức [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) và [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) truy cập vị trí bắt đầu của đoạn văn bản đã chọn trong khung văn bản của shape. Các phương thức [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) và [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) truy cập độ dài của phần chọn. Cùng nhau, các giá trị này liên kết bình luận với một đoạn văn bản cụ thể bên trong [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).

Các phương thức [ModernComment.getStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getstatus/) và [ModernComment.setStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị từ enumeration [ModernCommentStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — không có trạng thái bình luận hiện đại cụ thể nào được xác định.
- `Active` — bình luận đang hoạt động.
- `Resolved` — bình luận đã được giải quyết.
- `Closed` — bình luận đã đóng.

Ví dụ sau tạo một bình luận hiện đại được neo vào shape, liên kết nó với một đoạn văn bản đã chọn, đánh dấu là đã giải quyết, lưu bản trình chiếu và kiểm tra các giá trị sau khi mở lại tệp.

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

### **Kiểm tra các bình luận hiện đại hiện có**

Để kiểm tra một bản trình chiếu hiện có, xác định các đối tượng [ModernComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/), sau đó xem xét [ModernComment.getShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), và [ModernComment.getStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getstatus/). Một shape `null` cho biết đây là bình luận cấp slide. Đối với anchor là một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/), các phương thức chọn văn bản sẽ chỉ ra đoạn văn bản liên quan trong khung văn bản của shape.

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

## **Xoá bình luận**

### **Xoá tất cả bình luận và tác giả bình luận**

Ví dụ sau cho thấy cách xoá tất cả bình luận và các tác giả bình luận khỏi một bản trình chiếu:

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

### **Xoá các bình luận cụ thể**

Ví dụ sau cho thấy cách xoá các bình luận cụ thể khỏi một slide:

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

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái giải quyết cho bình luận hiện đại không?**

Có. Các phương thức [ModernComment.getStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getstatus/) và [ModernComment.setStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị của [ModernCommentStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái được lưu trong bản trình chiếu và có thể đọc lại sau khi tệp được mở lại.

**Các cuộc thảo luận dạng chuỗi phản hồi có được hỗ trợ không, và có giới hạn mức độ lồng nhau không?**

Có. Mỗi bình luận có thể tham chiếu tới [parent comment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/getparentcomment/), cho phép tạo chuỗi phản hồi. API không đưa ra giới hạn cụ thể về độ sâu lồng nhau.

**Vị trí của dấu đánh dấu bình luận trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí dấu đánh dấu được xác định bằng các tọa độ dạng số thực trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.