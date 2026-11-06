---
title: Quản lý Nhận xét Bản trình chiếu trong Node.js
linktitle: Nhận xét Bản trình chiếu
type: docs
weight: 100
url: /vi/nodejs-java/presentation-comments/
keywords:
- nhận xét
- nhận xét hiện đại
- nhận xét PowerPoint
- nhận xét bản trình chiếu
- nhận xét slide
- thêm nhận xét
- truy cập nhận xét
- chỉnh sửa nhận xét
- trả lời nhận xét
- xóa nhận xét
- xoá nhận xét
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý nhận xét bản trình chiếu với Aspose.Slides cho Node.js qua Java: thêm, đọc, chỉnh sửa, trả lời và xóa nhận xét trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bản trình chiếu bằng Aspose.Slides cho Node.js qua Java. Nó giới thiệu các kiểu liên quan đến nhận xét chính và trình diễn cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với trả lời và nhận xét hiện đại, và xóa nhận xét khỏi bản trình chiếu.

Ví dụ bao phủ các kịch bản đánh giá và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi trả lời, và xóa các nhận xét đã chọn hoặc tất cả các nhận xét.

Trong PowerPoint, nhận xét xuất hiện như các chú thích trên các slide. Khi chọn một nhận xét, nội dung và cuộc thảo luận liên quan sẽ hiển thị.

Để yêu cầu hiển thị hoặc ẩn nhận xét khi mở bản trình chiếu mà không thay đổi các nhận xét, xem [Hiển thị hoặc Ẩn Nhận xét Khi Mở Bản trình chiếu](/slides/vi/nodejs-java/presentation-view-properties/).

## **Tại sao nên thêm nhận xét vào bản trình chiếu?**

Bạn có thể sử dụng nhận xét để cung cấp phản hồi và cộng tác với đồng nghiệp khi xem xét bản trình chiếu.

Aspose.Slides cho Node.js qua Java cung cấp các API sau để làm việc với nhận xét:

* The [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class, cung cấp quyền truy cập vào các tác giả nhận xét của bản trình chiếu.
* The [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) class, đại diện cho các nhận xét liên kết với một tác giả cụ thể.
* The [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) class, cung cấp thông tin về một nhận xét, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* The [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) class, cung cấp thông tin về một tác giả, bao gồm tên, chữ viết tắt và các nhận xét liên quan.

## **Thêm Nhận xét cho Slide**

Ví dụ tạo hai slide và đăng ký một tác giả nhận xét bằng [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). Nó sử dụng [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) để đặt một nhận xét trên mỗi slide, sau đó truy xuất các nhận xét của slide đầu tiên cho tác giả đó bằng [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/). Console hiển thị nội dung của nhận xét đầu tiên hai lần, cho thấy cách truy cập qua cả slide và tác giả, và bản trình chiếu đã lưu chứa cả hai nhận xét.

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

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tìm hoặc Tạo Tác giả Nhận xét**

Khi một quy trình kiểm tra tự động xử lý cùng một bản trình chiếu nhiều lần, hãy tìm trong bộ sưu tập trả về bởi [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) trước khi thêm tác giả. [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) khớp cả tên và chữ viết tắt và trả về một mảng các tác giả phù hợp, hoặc một mảng rỗng nếu không có khớp. Ngược lại, [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) tìm chỉ theo tên, bất kể chữ viết tắt. Gọi [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) với tên và chữ viết tắt đã tồn tại trong bộ sưu tập sẽ ném ngoại lệ.

Ví dụ yêu cầu một tệp bản trình chiếu có ít nhất một slide. Trong mỗi trong hai vòng, nó tái sử dụng tác giả khớp đầu tiên, hoặc tạo mới chỉ khi kết quả rỗng. Nếu có nhiều khớp, nó chọn phần tử mảng đầu tiên mà không hợp nhất hoặc xóa các tác giả khác. Sau đó nó gọi [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) cho tác giả đã chọn và lưu bản trình chiếu. Vòng thứ hai mở đầu ra của vòng đầu tiên và lặp lại thao tác.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

Vòng thứ hai thêm một nhận xét khác mà không thêm tác giả mới hoặc xóa các nhận xét hiện có. Tệp cuối cùng, `review_pass_2.pptx`, chứa cả hai nhận xét mới cùng với bất kỳ nhận xét gốc nào. Tái sử dụng một tác giả không loại bỏ trùng lặp nhận xét: để tránh việc liên tục thêm cùng một nhận xét, hãy thực hiện phát hiện trùng lặp riêng trước khi thêm.

## **Truy cập Nhận xét của Slide**

Ví dụ mở một bản trình chiếu hiện có và đọc bộ sưu tập trả về bởi [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/). Đối với mỗi tác giả, nó lặp qua bộ sưu tập trả về bởi [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) và in ra số slide, nội dung nhận xét, tên tác giả và thời gian tạo. Bản trình chiếu đầu vào phải chứa nhận xét để tạo ra output trên console.

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

Một nhận xét cha là nhận xét gốc ở đầu một cây trả lời. Các phương thức [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) và [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) cho phép bạn lấy hoặc đặt cha của một nhận xét.

Ví dụ tạo nhận xét từ hai tác giả và sử dụng [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) để xây dựng các trả lời, bao gồm một trả lời cho một trả lời khác. Truyền `null` vào [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) sẽ lấy nhận xét từ tất cả các tác giả; console thụt lề mỗi mục theo độ sâu trong cây trả lời. Ví dụ lưu toàn bộ cuộc thảo luận, gọi [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) trên nhận xét gốc đầu tiên, và lưu một bản trình chiếu thứ hai với nhận xét đó và các trả lời của nó đã bị xóa.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Khi phương thức [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) được sử dụng để xóa một nhận xét, tất cả các trả lời cho nhận xét đó cũng sẽ bị xóa.
* Nếu [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm Nhận xét Hiện đại**

Nhận xét hiện đại có thể được liên kết với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong AutoShape. Phương thức [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) nhận một đối số [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) bên cạnh slide và tọa độ của dấu nhận xét.

Khi `null` được truyền cho đối số shape, nhận xét là một nhận xét ở mức slide. Dấu của nó được đặt theo tọa độ cung cấp, nhưng không gắn với một shape cụ thể, vì vậy [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) trả về `null`. Khi cung cấp một [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), nhận xét được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu nhận xét trên slide, trong khi thông tin kết nối shape có thể lấy qua [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Gắn Nhận xét Hiện đại vào một Hình dạng**

Ví dụ gọi [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) hai lần: một lần với shape `null` cho một nhận xét ở mức slide và một lần với một hình chữ nhật làm neo. Đọc [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) in ra `true` cho kiểm tra null của nhận xét ở mức slide và `Revenue title` cho nhận xét đã neo. Cả hai nhận xét đều được lưu cùng với bản trình chiếu.

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

### **Gắn Nhận xét vào Các Loại Hình dạng Khác nhau**

Bất kỳ đối tượng slide nào kế thừa từ [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) đều có thể được dùng làm neo shape. Các ví dụ phổ biến bao gồm [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/), và các thể hiện [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sử dụng [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) để liên kết một nhận xét với mỗi trong năm loại shape: một AutoShape, một picture frame, một group, một connector và một chart. Hình ảnh được nhúng dữ liệu ảnh, vì vậy không cần ảnh bên ngoài. Mỗi nhận xét có vị trí dấu riêng, và bản trình chiếu đã lưu giữ lại tất cả năm liên kết shape.

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

### **Gắn Nhận xét vào Văn bản và Đặt Trạng thái của Nó**

Đối với một nhận xét hiện đại được liên kết với một [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), các phương thức [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) và [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) truy cập vị trí bắt đầu của đoạn văn bản đã chọn trong khung văn bản của shape. Các phương thức [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) và [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) truy cập độ dài của phần chọn. Cùng nhau, các giá trị này liên kết nhận xét với một đoạn văn bản cụ thể bên trong AutoShape.

Các phương thức [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) và [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị từ enum [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — không có trạng thái nhận xét hiện đại cụ thể nào được định nghĩa.
- `Active` — nhận xét đang hoạt động.
- `Resolved` — nhận xét đã được giải quyết.
- `Closed` — nhận xét đã đóng.

Ví dụ neo một nhận xét hiện đại vào các từ "quarterly revenue" trong văn bản của một hình chữ nhật. Nó tính vị trí bắt đầu lựa chọn (zero‑based) từ văn bản và truyền vào [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) và sử dụng [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) để đặt số ký tự đã chọn. Sau khi gọi [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) với `Resolved`, nó lưu và mở lại bản trình chiếu. Bốn kiểm tra trên console mỗi lần đều in ra `true`, xác nhận rằng neo shape, đoạn văn bản và trạng thái đã được bảo toàn.

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
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

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

### **Kiểm tra Các Nhận xét Hiện đại Hiện có**

Ví dụ yêu cầu một bản trình chiếu hiện có chứa các nhận xét hiện đại và in ra nội dung, trạng thái và chi tiết neo của chúng. Để kiểm tra, xác định những nhận xét nào là thể hiện của [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/), sau đó kiểm tra [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), và [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). Một shape `null` cho biết đó là nhận xét ở mức slide. Đối với một neo [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), các phương thức lựa chọn văn bản xác định đoạn văn bản liên quan trong khung văn bản của shape.

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

Aspose.Slides cho Node.js qua Java cho phép bạn xóa tất cả các nhận xét và tác giả của chúng khỏi một bản trình chiếu hoặc xóa các nhận xét đã chọn trong khi giữ lại những phần còn lại. Các ví dụ sau minh họa cả hai cách và lưu bản trình chiếu đã cập nhật.

### **Xóa Tất cả Nhận xét và Tác giả Nhận xét**

Ví dụ mở một bản trình chiếu hiện có và gọi [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) cho mỗi tác giả, sau đó gọi [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) để xóa các tác giả. Bản trình chiếu đã lưu không chứa nhận xét cũng như tác giả nhận xét. Hãy sử dụng một bản trình chiếu có chứa nhận xét để quan sát việc xóa.

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

Ví dụ tạo hai nhận xét trên một slide và sử dụng [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) để tìm nhận xét của mỗi tác giả. Nó thu thập các nhận xét có nội dung bằng "comment 1" trước khi gọi [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/), tránh thay đổi bộ sưu tập trong quá trình chọn. Bản trình chiếu đã lưu chỉ còn lại "comment 2".

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

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho nhận xét hiện đại không?**

Có. [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) và [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị từ enum [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái được lưu trong bản trình chiếu và có thể đọc lại sau khi tệp được mở lại.

**Các cuộc thảo luận dạng chuỗi (chuỗi trả lời) có được hỗ trợ không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu tới [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) của nó, cho phép tạo chuỗi trả lời. API không định nghĩa một giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí của dấu nhận xét được xác định bằng các tọa độ dấu chấm động trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.