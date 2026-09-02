---
title: Chuyển Đổi Các Slide Bài Thuyết Trình Sang Ảnh Trên Android
linktitle: Slide sang Ảnh
type: docs
weight: 35
url: /vi/androidjava/convert-slide/
keywords:
- chuyển đổi slide
- xuất slide
- slide sang ảnh
- lưu slide dưới dạng ảnh
- slide sang EMF
- slide sang PNG
- slide sang JPEG
- slide sang bitmap
- slide sang TIFF
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các slide từ các bài thuyết trình PPT, PPTX và ODP sang PNG, JPEG, GIF, TIFF, EMF và các định dạng ảnh khác trên Android với Aspose.Slides."
---
## **Giới thiệu**

Aspose.Slides for Android via Java có thể render các slide riêng lẻ từ các bài thuyết trình PowerPoint và OpenDocument dưới dạng PNG, JPEG, GIF, TIFF và các định dạng ảnh khác.

Để chuyển đổi một slide thành ảnh, thực hiện các bước sau:

1. Tải bài thuyết trình bằng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Chọn slide mà bạn muốn render.
3. Nếu cần, cấu hình việc render bằng lớp [RenderingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/renderingoptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/).
4. Gọi phương thức [ISlide.getImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getImage--) . Phương thức này trả về một đối tượng [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/).
5. Gọi phương thức [IImage.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) và chỉ định định dạng đầu ra bằng một giá trị [ImageFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imageformat/).

## **Chuyển đổi một Slide sang Ảnh PNG**

Cách chuyển đổi đơn giản nhất sử dụng các cài đặt render mặc định. Đối tượng [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) kết quả có thể được xử lý trong bộ nhớ hoặc lưu vào file.

Ví dụ Java sau render slide đầu tiên và lưu nó dưới dạng ảnh PNG:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi Slides sang Ảnh với Kích thước Tùy chỉnh**

Sử dụng phiên bản overload của [ISlide.getImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) chấp nhận giá trị [Size](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides.android/size/) để render slide với kích thước pixel chính xác.

Ví dụ sau tạo một ảnh JPEG kích thước 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi Slides có Ghi chú và Bình luận sang Ảnh**

Mặc định, ảnh slide không bao gồm ghi chú hay bình luận. Truyền một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) vào phương thức [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) để kiểm soát vị trí hiển thị ghi chú và bình luận.

Ví dụ sau đặt ghi chú bị cắt ngắn bên dưới slide và bình luận sang bên phải:

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Đối với việc chuyển đổi slide sang ảnh, không truyền [BottomFull](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notespositions/) vào phương thức [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Ghi chú có thể chứa nhiều văn bản hơn kích thước ảnh cố định cho phép. Thay vào đó, sử dụng [BottomTruncated](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notespositions/) .
{{% /alert %}}

## **Chuyển đổi Slides sang Ảnh sử dụng Tùy chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/) cho phép bạn kiểm soát kích thước, độ phân giải và các thuộc tính khác của ảnh TIFF đã render.

Ví dụ sau render slide đầu tiên dưới dạng ảnh TIFF 2160 × 2880 với độ phân giải 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi Tất cả Slides sang Ảnh**

Duyệt qua bộ sưu tập slide để chuyển đổi toàn bộ bài thuyết trình thành một loạt ảnh. Các slide ẩn sẽ được bao gồm trừ khi bạn bỏ qua chúng một cách rõ ràng.

Ví dụ sau render mỗi slide dưới dạng ảnh JPEG với hệ số phóng to ngang và dọc là 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tạo Đầu ra Enhanced Metafile**

Enhanced Metafile (EMF) hữu ích khi cần trao đổi đồ họa dựa trên vector với Microsoft Office hoặc các ứng dụng Windows khác hỗ trợ metafile của Windows. Khác với ảnh dựa trên pixel, EMF có thể giữ lại các thao tác vẽ vector và có thể phóng to mà không mất độ sắc nét. Tuy nhiên, EMF chủ yếu là định dạng tương thích cho các ứng dụng hỗ trợ metafile của Windows, không phải là định dạng trao đổi toàn cầu. Thêm nữa, nội dung slide phức tạp như ảnh bitmap và một số hiệu ứng có thể được lưu dưới dạng các phần tử raster trong container metafile vector.

### **Xuất một Slide sang EMF**

Phương thức [ISlide.writeAsEmf](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) ghi một [ISlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/) vào một luồng đích ở định dạng EMF. Ví dụ sau tải một bài thuyết trình, chọn slide đầu tiên và ghi nó vào luồng file EMF:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Người gọi sở hữu luồng được truyền cho [ISlide.writeAsEmf](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) và chịu trách nhiệm đóng luồng đó, như đã chỉ ra ở trên.

### **Chuyển đổi Ảnh SVG sang EMF và Thêm vào Bài thuyết trình**

Sử dụng [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) để chuyển đổi nội dung SVG sang EMF. Các byte kết quả có thể được thêm vào bài thuyết trình thông qua [IImageCollection.addImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) và đặt trên slide bằng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Ví dụ sau tạo một [SvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgimage/) từ markup SVG, chuyển đổi nó thành EMF trong bộ nhớ, chèn metafile vào slide đầu tiên và lưu bài thuyết trình:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) không chịu trách nhiệm sở hữu luồng đích. Một [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) lưu toàn bộ dữ liệu sinh ra trong bộ nhớ, vì vậy không cần đặt lại vị trí trước khi gọi `toByteArray`. Mảng byte trả về vẫn hợp lệ sau khi luồng được đóng.

Việc tạo EMF khả dụng trên các phiên bản Android và cấu hình thiết bị được hỗ trợ, nhưng quá trình render có thể khác nhau khi thiếu phông chữ hoặc các phụ thuộc đồ họa. Cài đặt các phông chữ được sử dụng trong nội dung nguồn hoặc cấu hình các thay thế phù hợp, theo dõi [hướng dẫn cài đặt](/slides/vi/androidjava/install-aspose-slides-for-android-via-java/) cho Aspose.Slides for Android via Java, và kiểm tra kết quả trong ứng dụng tiêu thụ EMF mục tiêu. Các ứng dụng trên nền tảng không phải Windows thường có hỗ trợ hạn chế hoặc không nhất quán trong việc hiển thị và chỉnh sửa metafile Windows.

## **Hiển thị Emoji Màu**

{{% alert title="Note" color="info" %}}
Để render emoji màu đúng cách khi chuyển đổi slide của bài thuyết trình thành ảnh, các phông chữ emoji được sử dụng trong bài thuyết trình phải được cài đặt và có sẵn trên hệ thống thực hiện việc chuyển đổi. Ví dụ, nếu bài thuyết trình sử dụng **Segoe UI Emoji** và phông chữ này thiếu, emoji có thể hiển thị dưới dạng đơn sắc trong các ảnh đầu ra.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render slide với hoạt ảnh không?**

Không. Phương thức [ISlide.getImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getImage--) tạo ra một ảnh tĩnh của slide và không xuất hoạt ảnh.

**Có thể xuất các slide ẩn dưới dạng ảnh không?**

Có. Các slide ẩn có thể được render giống như các slide thường. Bao gồm chúng trong vòng xử lý, như đã minh họa trong ví dụ ở trên.

**Các bóng và hiệu ứng khác có được giữ trong ảnh slide không?**

Có. Aspose.Slides render bóng, độ trong suốt và các hiệu ứng đồ họa được hỗ trợ khác trong ảnh slide.