---
title: Chuyển đổi PPT và PPTX sang JPG trong Java
linktitle: PowerPoint sang JPG
type: docs
weight: 60
url: /vi/java/convert-powerpoint-to-jpg/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang JPG
- bản trình bày sang JPG
- slide sang JPG
- PPT sang JPG
- PPTX sang JPG
- lưu PowerPoint dưới dạng JPG
- lưu bản trình bày dưới dạng JPG
- lưu slide dưới dạng JPG
- lưu PPT dưới dạng JPG
- lưu PPTX dưới dạng JPG
- xuất PPT thành JPG
- xuất PPTX thành JPG
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint (PPT, PPTX) sang ảnh JPG chất lượng cao trong Java với Aspose.Slides cho Java bằng các ví dụ mã nhanh và đáng tin cậy."
---
## **Giới thiệu**

Việc chuyển đổi các bản trình bày PowerPoint và OpenDocument sang ảnh JPG giúp chia sẻ slide, tối ưu hiệu suất và nhúng nội dung vào trang web hoặc ứng dụng. Aspose.Slides cho phép bạn chuyển đổi các tệp PPTX, PPT và ODP thành ảnh JPEG chất lượng cao. Hướng dẫn này giải thích các phương pháp chuyển đổi khác nhau.

Với các tính năng này, việc triển khai trình xem bản trình bày của riêng bạn và tạo hình thu nhỏ cho mỗi slide trở nên dễ dàng. Điều này có thể hữu ích nếu bạn muốn bảo vệ các slide khỏi việc sao chép hoặc trình chiếu bản trình bày ở chế độ chỉ đọc. Aspose.Slides cho phép bạn chuyển đổi toàn bộ bản trình bày hoặc một slide cụ thể sang các định dạng ảnh.

## **Chuyển đổi PowerPoint PPT/PPTX sang JPG**

1. Tạo một thể hiện của kiểu [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy đối tượng slide kiểu [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide) từ bộ sưu tập [Presentation.getSlides()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) .
3. Tạo hình thu nhỏ cho mỗi slide và sau đó chuyển đổi nó sang JPG. [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide#getImage-float-float-) được sử dụng để lấy hình thu nhỏ của một slide, nó trả về đối tượng [Images](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Images). Phương thức [getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) phải được gọi từ slide cần thiết của kiểu [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide), các tỷ lệ của hình thu nhỏ kết quả được truyền vào phương thức.
4. Sau khi bạn đã lấy hình thu nhỏ của slide, gọi phương thức [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) từ đối tượng hình thu nhỏ. Truyền tên tệp kết quả và định dạng ảnh vào phương thức này.

{{% alert color="info" %}}
**Lưu ý**: việc chuyển đổi PPT/PPTX sang JPG khác với việc chuyển đổi sang các loại khác trong API Aspose.Slides. Đối với các loại khác, bạn thường sử dụng phương thức [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Tuy nhiên ở đây bạn cần phương thức [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Tạo ảnh tỷ lệ đầy đủ
        IImage slideImage = sld.getImage(1f, 1f);

        // Lưu ảnh vào đĩa ở định dạng JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chuyển đổi PowerPoint PPT/PPTX sang JPG với Kích thước Tùy chỉnh**

Để thay đổi kích thước của hình thu nhỏ và ảnh JPG kết quả, bạn có thể đặt giá trị *ScaleX* và *ScaleY* bằng cách truyền chúng vào các phương thức [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide#getImage-float-float-) .

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Định nghĩa kích thước
    int desiredX = 1200;
    int desiredY = 800;
    // Lấy các giá trị đã tỉ lệ của X và Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Tạo ảnh tỷ lệ đầy đủ
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Lưu ảnh vào đĩa ở định dạng JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kết xuất Bình luận Khi Lưu Slide dưới dạng Ảnh**

Aspose.Slides for Java cung cấp một tính năng cho phép bạn kết xuất các bình luận trong các slide của bản trình bày khi bạn chuyển đổi các slide đó thành ảnh. Đoạn mã Java sau minh họa thao tác này:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose cung cấp một [FREE Collage web app](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể hợp nhất ảnh [JPG to JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [photo grids](https://products.aspose.app/slides/vi/collage/photo-grid), và các tính năng khác. 

Sử dụng các nguyên tắc giống như trong bài viết này, bạn có thể chuyển đổi ảnh từ định dạng này sang định dạng khác. Để biết thêm thông tin, xem các trang này: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/java/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/java/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/java/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/java/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/java/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/java/conversion/svg-to-png/).
{{% /alert %}}

## **Câu hỏi thường gặp**

### Phương pháp này có hỗ trợ chuyển đổi hàng loạt không?

Có, Aspose.Slides cho phép chuyển đổi hàng loạt nhiều slide sang JPG trong một thao tác duy nhất.

### Chuyển đổi có hỗ trợ SmartArt, biểu đồ và các đối tượng phức tạp khác không?

Có, Aspose.Slides kết xuất tất cả nội dung, bao gồm SmartArt, biểu đồ, bảng, hình dạng và hơn thế nữa. Tuy nhiên, độ chính xác khi kết xuất có thể hơi khác so với PowerPoint, đặc biệt khi sử dụng phông chữ tùy chỉnh hoặc thiếu phông chữ.

### Có bất kỳ giới hạn nào về số lượng slide có thể được xử lý không?

Aspose.Slides không áp đặt bất kỳ giới hạn nghiêm ngặt nào về số lượng slide bạn có thể xử lý. Tuy nhiên, bạn có thể gặp lỗi hết bộ nhớ khi làm việc với các bản trình bày lớn hoặc ảnh độ phân giải cao.

## **Xem thêm**

Xem các tùy chọn khác để chuyển đổi PPT/PPTX sang ảnh như:

- [Chuyển đổi PPT/PPTX sang SVG](/slides/vi/java/render-a-slide-as-an-svg-image/).