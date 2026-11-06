---
title: Quản lý nhận xét trong bản trình chiếu trên Android
linktitle: Nhận xét bản trình chiếu
type: docs
weight: 100
url: /vi/androidjava/presentation-comments/
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
- xóa nhận xét
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý nhận xét trong bản trình chiếu với Aspose.Slides cho Android qua Java: thêm, đọc, chỉnh sửa, trả lời và xóa nhận xét trong các bản PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bản trình chiếu bằng Aspose.Slides cho Android qua Java. Nó giới thiệu các kiểu liên quan đến nhận xét chính và trình bày cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với các trả lời và nhận xét hiện đại, và xóa nhận xét khỏi một bản trình chiếu.

Các ví dụ bao quát các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi trả lời, và xóa các nhận xét đã chọn hoặc toàn bộ nhận xét.

Trong PowerPoint, nhận xét hiển thị dưới dạng chú thích trên các slide. Khi chọn một nhận xét, nội dung và cuộc thảo luận liên quan sẽ được hiển thị.

Để yêu cầu hiển thị hoặc ẩn nhận xét khi một bản trình chiếu mở mà không thay đổi nội dung nhận xét, xem [Hiển thị hoặc Ẩn Nhận xét Khi Mở Bản Trình chiếu](/slides/vi/androidjava/presentation-view-properties/).

## **Tại sao nên thêm nhận xét vào bản trình chiếu?**

Bạn có thể sử dụng nhận xét để cung cấp phản hồi và hợp tác với đồng nghiệp khi xem xét các bản trình chiếu.

Aspose.Slides cho Android qua Java cung cấp các API sau để làm việc với nhận xét:

* Lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) cung cấp quyền truy cập vào các tác giả nhận xét của bản trình chiếu.
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/) đại diện cho các nhận xét liên quan tới một tác giả cụ thể.
* Giao diện [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/) cung cấp thông tin về một nhận xét, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, ký hiệu và các nhận xét liên quan.

## **Thêm Nhận xét vào Slide**

Ví dụ tạo hai slide và đăng ký một tác giả nhận xét bằng [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-). Nó sử dụng [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) để đặt một nhận xét trên mỗi slide, sau đó lấy các nhận xét của slide đầu tiên cho tác giả đó bằng [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-). Console hiển thị nội dung của nhận xét đầu tiên hai lần, minh chứng việc truy cập qua cả slide và tác giả, và bản trình chiếu đã lưu chứa cả hai nhận xét.

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

## **Tìm hoặc Tạo Tác Giả Nhận Xét**

Khi một quy trình kiểm duyệt tự động xử lý cùng một bản trình chiếu nhiều lần, tìm kiếm trong tập hợp trả về bởi [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) trước khi thêm tác giả. [findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) khớp cả tên và ký hiệu và trả về một mảng các tác giả phù hợp, hoặc mảng rỗng nếu không có khớp. Ngược lại, [findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) tìm kiếm chỉ theo tên, bất kể ký hiệu. Gọi [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) với một tên và ký hiệu đã tồn tại trong tập hợp sẽ ném ngoại lệ.

Ví dụ yêu cầu một tệp bản trình chiếu có ít nhất một slide. Trong mỗi trong hai lượt, nó tái sử dụng tác giả đầu tiên khớp, hoặc tạo mới chỉ khi kết quả rỗng. Nếu có nhiều khớp, nó chọn phần tử đầu tiên của mảng mà không hợp nhất hoặc xóa các tác giả khác. Sau đó nó gọi [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) cho tác giả được chọn và lưu bản trình chiếu. Lượt thứ hai mở đầu ra của lượt thứ nhất và lặp lại thao tác.

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

Lượt thứ hai thêm một nhận xét khác mà không thêm tác giả mới hoặc xóa các nhận xét hiện có. Tệp cuối cùng, `review_pass_2.pptx`, chứa cả hai nhận xét mới bên cạnh bất kỳ nhận xét gốc nào. Tái sử dụng một tác giả không loại bỏ trùng lặp nhận xét: để tránh việc thêm lặp lại cùng một nhận xét, hãy thực hiện phát hiện trùng lặp riêng trước khi thêm.

## **Truy cập Nhận xét Slide**

Ví dụ mở một bản trình chiếu hiện có và đọc tập hợp trả về bởi [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--). Đối với mỗi tác giả, nó duyệt qua tập hợp trả về bởi [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--) và in ra số slide, nội dung nhận xét, tên tác giả và thời gian tạo. Bản trình chiếu đầu vào phải chứa nhận xét để tạo ra đầu ra console.

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

## **Trả lời Nhận xét**

Một nhận xét cha là nhận xét gốc ở đầu một cây phân cấp trả lời. Các phương thức [IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) và [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) cho phép bạn lấy hoặc đặt cha của một nhận xét.

Ví dụ tạo nhận xét từ hai tác giả và sử dụng [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) để xây dựng các trả lời, bao gồm một trả lời cho một trả lời khác. Truyền `null` vào [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) lấy các nhận xét từ mọi tác giả; console thụt lề mỗi mục theo độ sâu trong cây trả lời. Ví dụ lưu toàn bộ cuộc thảo luận, gọi [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) trên nhận xét gốc đầu tiên, và lưu một bản trình chiếu thứ hai với nhận xét đó và các trả lời của nó đã bị xóa.

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
* Khi phương thức [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) được sử dụng để xóa một nhận xét, tất cả các trả lời cho nhận xét đó cũng sẽ bị xóa.
* Nếu [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm Nhận xét Hiện đại**

Nhận xét hiện đại có thể được liên kết với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong AutoShape. Phương thức [ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) nhận một đối số [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) ngoài slide và tọa độ dấu nhận xét.

Khi `null` được truyền cho đối số shape, nhận xét là nhận xét ở mức slide. Dấu của nó được định vị bởi tọa độ cung cấp, nhưng không liên kết với một hình dạng cụ thể, vì vậy [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) trả về `null`. Khi một [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) được cung cấp, nhận xét được neo vào hình dạng đó. Các tọa độ vẫn xác định vị trí của dấu nhận xét trên slide, trong khi liên kết hình dạng có thể được truy xuất qua [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--).

### **Gắn Nhận xét Hiện đại vào Hình dạng**

Ví dụ gọi [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) hai lần: một lần với shape `null` cho nhận xét ở mức slide và một lần với một hình chữ nhật làm neo. Đọc [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) in ra `true` cho kiểm tra null của nhận xét slide-level và `Revenue title` cho nhận xét đã neo. Cả hai nhận xét đều được lưu cùng bản trình chiếu.

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

### **Gắn Nhận xét vào Các Loại Hình dạng Khác nhau**

Bất kỳ đối tượng slide nào thực hiện [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) đều có thể được dùng làm neo hình dạng. Các ví dụ phổ biến gồm [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/) và các thể hiện [IGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/) như biểu đồ.

Ví dụ sử dụng [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) để liên kết một nhận xét với mỗi trong năm loại hình dạng: một AutoShape, một picture frame, một group, một connector và một chart. Hình ảnh được sử dụng chứa dữ liệu ảnh nhúng, vì vậy không cần ảnh bên ngoài. Mỗi nhận xét có vị trí dấu riêng, và bản trình chiếu đã lưu giữ lại mọi liên kết hình dạng.

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

### **Gắn Nhận xét vào Văn bản và Đặt Trạng thái**

Đối với một nhận xét hiện đại được liên kết với [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), các phương thức [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) và [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) truy cập vị trí bắt đầu của đoạn văn bản đã chọn trong khung văn bản của hình dạng. Các phương thức [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) và [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) truy cập độ dài của phần chọn. Cùng nhau, các giá trị này liên kết nhận xét với một đoạn văn bản cụ thể trong AutoShape.

Các phương thức [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) và [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) truy cập một giá trị từ các hằng số [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — không có trạng thái nhận xét hiện đại cụ thể nào được định nghĩa.
- `Active` — nhận xét đang hoạt động.
- `Resolved` — nhận xét đã được giải quyết.
- `Closed` — nhận xét đã đóng.

Ví dụ gắn một nhận xét hiện đại vào các từ "quarterly revenue" trong văn bản của một hình chữ nhật. Nó tính vị trí bắt đầu chọn dựa trên văn bản và truyền cho [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-), sau đó dùng [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) để đặt số ký tự đã chọn. Sau khi gọi [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) với `Resolved`, nó lưu và mở lại bản trình chiếu. Bốn kiểm tra console mỗi lần đều in `true`, xác nhận rằng neo hình dạng, đoạn văn bản và trạng thái đã được bảo tồn.

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

### **Kiểm tra Nhận xét Hiện đại Hiện có**

Ví dụ yêu cầu một bản trình chiếu hiện có chứa các nhận xét hiện đại và in ra nội dung, trạng thái và chi tiết neo của chúng. Để kiểm tra, xác định các nhận xét triển khai [IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/), sau đó xem [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), và [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Một shape `null` cho biết đây là nhận xét mức slide. Đối với neo [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), các phương thức chọn văn bản xác định đoạn văn bản liên quan trong khung văn bản của hình dạng.

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

## **Xóa Nhận xét**

Aspose.Slides cho Android qua Java cho phép bạn xóa tất cả nhận xét và các tác giả của chúng khỏi một bản trình chiếu hoặc xóa các nhận xét đã chọn trong khi giữ lại các phần còn lại. Các ví dụ sau minh họa cả hai cách và lưu bản trình chiếu đã cập nhật.

### **Xóa Tất cả Nhận xét và Tác Giả Nhận xét**

Ví dụ mở một bản trình chiếu hiện có và gọi [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--) cho mỗi tác giả, sau đó gọi [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--) để xóa các tác giả. Bản trình chiếu đã lưu không còn nhận xét hay tác giả nhận xét nào. Sử dụng một bản trình chiếu có nhận xét để quan sát việc xóa.

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

### **Xóa Nhận xét Cụ thể**

Ví dụ tạo hai nhận xét trên một slide và sử dụng [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) để tìm nhận xét của mỗi tác giả. Nó thu thập các nhận xét có nội dung bằng "comment 1" trước khi gọi [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-), tránh thay đổi tập hợp trong khi lựa chọn. Bản trình chiếu đã lưu chỉ còn lại "comment 2".

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

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho nhận xét hiện đại không?**

Có. [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) và [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) truy cập một giá trị từ [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái này được lưu trong bản trình chiếu và có thể đọc lại sau khi tệp được mở lại.

**Có hỗ trợ các cuộc thảo luận dạng chuỗi (reply chains) không, và có giới hạn độ sâu không?**

Có. Mỗi nhận xét có thể tham chiếu tới [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) của nó, cho phép tạo chuỗi trả lời. API không định nghĩa một giới hạn độ sâu cụ thể.

**Vị trí của dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí dấu nhận xét được định nghĩa bằng các tọa độ kiểu float trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.