---
title: Chuyển Đổi Các Slide Bản Trình Bày Sang Hình Ảnh trong Java
linktitle: Slide sang Hình Ảnh
type: docs
weight: 35
url: /vi/java/convert-slide/
keywords:
- chuyển đổi slide
- xuất slide
- slide sang hình ảnh
- lưu slide dưới dạng hình ảnh
- slide sang EMF
- slide sang PNG
- slide sang JPEG
- slide sang bitmap
- slide sang TIFF
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Chuyển đổi các slide từ bản trình bày PPT, PPTX và ODP sang PNG, JPEG, GIF, TIFF, EMF và các định dạng hình ảnh khác trong Java bằng Aspose.Slides."
---
## **Giới thiệu**

Aspose.Slides for Java có thể render các slide riêng lẻ từ các bản trình bày PowerPoint và OpenDocument dưới dạng PNG, JPEG, GIF, TIFF và các định dạng hình ảnh khác.

Để chuyển đổi một slide thành hình ảnh, hãy làm theo các bước sau:

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Chọn slide mà bạn muốn render.
3. Nếu cần, cấu hình việc render bằng lớp [RenderingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/renderingoptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/).
4. Gọi phương thức [ISlide.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#getImage--) . Phương thức này trả về một đối tượng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/).
5. Gọi phương thức [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) và chỉ định định dạng đầu ra bằng một giá trị [ImageFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imageformat/).

## **Chuyển Đổi Slide Thành Hình Ảnh PNG**

Cách chuyển đổi đơn giản nhất sử dụng cài đặt render mặc định. Đối tượng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) được tạo ra có thể được xử lý trong bộ nhớ hoặc lưu vào tệp.

Ví dụ Java sau render slide đầu tiên và lưu nó dưới dạng hình ảnh PNG:

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

## **Chuyển Đổi Các Slide Thành Hình Ảnh Với Kích Thước Tùy Chỉnh**

Sử dụng phương thức overload của [ISlide.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) nhận một giá trị [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) để render slide với kích thước pixel chính xác.

Ví dụ sau tạo một hình ảnh JPEG kích thước 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

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

## **Chuyển Đổi Các Slide Có Ghi Chú và Bình Luận Thành Hình Ảnh**

Mặc định, hình ảnh slide không bao gồm ghi chú hoặc bình luận. Truyền một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notescommentslayoutingoptions/) vào phương thức [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) để kiểm soát vị trí hiển thị ghi chú và bình luận.

Ví dụ sau đặt các ghi chú đã cắt ngắn phía dưới slide và các bình luận ở phía bên phải:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

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
Đối với việc chuyển đổi slide sang hình ảnh, không truyền [BottomFull](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notespositions/) vào phương thức [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Ghi chú có thể chứa nhiều văn bản hơn kích thước hình ảnh cố định có thể chứa. Thay vào đó, sử dụng [BottomTruncated](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notespositions/).
{{% /alert %}}

## **Chuyển Đổi Các Slide Thành Hình Ảnh Bằng Tùy Chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/) cho phép bạn kiểm soát kích thước, độ phân giải và các thuộc tính khác của hình ảnh TIFF đã render.

Ví dụ sau render slide đầu tiên dưới dạng hình ảnh TIFF 2160 × 2880 với độ phân giải 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

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

{{% alert title="Warning" color="warning" %}}
Hỗ trợ TIFF không được bảo đảm trong các phiên bản Java trước JDK 9.
{{% /alert %}}

## **Chuyển Đổi Tất Cả Các Slide Thành Hình Ảnh**

Duyệt qua bộ sưu tập slide để chuyển đổi toàn bộ bản trình bày thành một loạt các hình ảnh. Các slide ẩn sẽ được bao gồm trừ khi bạn bỏ qua chúng một cách rõ ràng.

Ví dụ sau render mỗi slide thành hình ảnh JPEG với hệ số co dọc và ngang là 2:

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

## **Tạo Đầu Ra Metafile Nâng Cao (EMF)**

Enhanced Metafile (EMF) hữu ích khi cần trao đổi đồ họa dựa trên vector với Microsoft Office hoặc các ứng dụng Windows khác hỗ trợ metafile Windows. Khác với hình ảnh dựa trên pixel, EMF có thể giữ lại các thao tác vẽ vector và có thể phóng to mà không mất độ sắc nét. Tuy nhiên, EMF chủ yếu là định dạng tương thích cho các ứng dụng hỗ trợ metafile Windows, không phải là định dạng trao đổi chung. Ngoài ra, nội dung slide phức tạp, chẳng hạn như hình ảnh bitmap và một số hiệu ứng, có thể được lưu dưới dạng các phần tử raster bên trong container metafile vector.

### **Xuất Slide Sang EMF**

Phương thức [ISlide.writeAsEmf](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) ghi một [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/) vào luồng đích ở định dạng EMF. Ví dụ sau tải một bản trình bày, chọn slide đầu tiên và ghi nó vào luồng tệp EMF:

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

Người gọi sở hữu luồng được truyền vào [ISlide.writeAsEmf](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) và chịu trách nhiệm đóng luồng này, như đã minh họa ở trên.

### **Chuyển Đổi Hình Ảnh SVG Sang EMF Và Thêm Vào Bản Trình Bày**

Sử dụng [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) để chuyển đổi nội dung SVG sang EMF. Các byte kết quả có thể được thêm vào bản trình bày thông qua [IImageCollection.addImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) và đặt lên slide bằng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Ví dụ sau tạo một [SvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgimage/) từ mã SVG, chuyển đổi nó thành EMF trong bộ nhớ, chèn metafile vào slide đầu tiên và lưu bản trình bày:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) không chịu trách nhiệm sở hữu luồng đích. Một [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) lưu trữ tất cả dữ liệu tạo ra trong bộ nhớ, vì vậy không cần đặt lại vị trí trước khi gọi `toByteArray`. Mảng byte trả về vẫn hợp lệ sau khi luồng được đóng.

Việc tạo EMF khả dụng trên các hệ điều hành được hỗ trợ bởi Aspose.Slides for Java và cấu hình JDK đã chọn, nhưng quá trình render có thể khác nhau giữa các nền tảng khi thiếu phông chữ hoặc phụ thuộc đồ họa. Cài đặt các phông chữ được sử dụng trong nội dung nguồn hoặc cấu hình các thay thế phù hợp, tuân theo [yêu cầu nền tảng](/slides/vi/java/system-requirements/) cho Aspose.Slides for Java, và kiểm tra kết quả trong ứng dụng tiêu thụ EMF mục tiêu. Các ứng dụng trên Linux và macOS thường có hỗ trợ hạn chế hoặc không nhất quán đối với việc hiển thị và chỉnh sửa metafile Windows.

## **Render Emoji Màu**

{{% alert title="Note" color="info" %}}
Để render emoji màu đúng cách khi chuyển đổi slide trình chiếu sang hình ảnh, phông chữ emoji được sử dụng trong bản trình bày phải được cài đặt và có sẵn trên hệ thống thực hiện việc chuyển đổi. Ví dụ, nếu bản trình bày sử dụng **Segoe UI Emoji** và phông chữ này thiếu, các emoji có thể hiển thị dưới dạng đơn sắc trong các hình ảnh đầu ra.
{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Aspose.Slides có hỗ trợ render slide có hoạt ảnh không?**

Không. Phương thức [ISlide.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#getImage--) render một hình ảnh tĩnh của slide và không xuất hoạt ảnh.

**Có thể xuất các slide ẩn dưới dạng hình ảnh không?**

Có. Các slide ẩn có thể được render giống như các slide thường. Bao gồm chúng trong vòng lặp xử lý, như đã minh họa trong ví dụ ở trên.

**Các bóng đổ và các hiệu ứng khác có được bảo tồn trong hình ảnh slide không?**

Có. Aspose.Slides render các bóng đổ, độ trong suốt và các hiệu ứng đồ họa được hỗ trợ khác trong hình ảnh slide.