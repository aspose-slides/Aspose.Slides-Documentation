---
title: Chuyển đổi PPT và PPTX sang JPG trên Android
linktitle: PowerPoint sang JPG
type: docs
weight: 60
url: /vi/androidjava/convert-powerpoint-to-jpg/
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
- xuất PPT sang JPG
- xuất PPTX sang JPG
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint (PPT, PPTX) sang hình ảnh JPG chất lượng cao trong Java với Aspose.Slides cho Android bằng các ví dụ mã nhanh và đáng tin cậy."
---
## **Giới thiệu**

Chuyển đổi các bản trình bày PowerPoint và OpenDocument sang hình ảnh JPG giúp việc chia sẻ slide, tối ưu hiệu năng và nhúng nội dung vào trang web hoặc ứng dụng. Aspose.Slides cho Android thông qua Java cho phép bạn chuyển đổi các tệp PPTX, PPT và ODP thành hình ảnh JPEG chất lượng cao. Hướng dẫn này giải thích các phương pháp chuyển đổi khác nhau.

Với những tính năng này, bạn có thể dễ dàng triển khai trình xem bài thuyết trình của riêng mình và tạo ảnh thu nhỏ cho mỗi slide. Điều này có thể hữu ích nếu bạn muốn bảo vệ các slide khỏi việc sao chép hoặc trình chiếu bản thuyết trình ở chế độ chỉ đọc. Aspose.Slides cho phép bạn chuyển đổi toàn bộ bản thuyết trình hoặc một slide cụ thể sang các định dạng hình ảnh.

## **Chuyển Đổi Các Slide Bản Thuyết Trình Sang Hình Ảnh JPG**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Lấy đối tượng slide kiểu [ISlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/) từ bộ sưu tập trả về bởi phương thức [Presentation.getSlides()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlides--).
3. Tạo một hình ảnh của slide bằng cách sử dụng phương thức [ISlide.getImage(float, float)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getImage-float-float-).
4. Gọi phương thức [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) trên đối tượng hình ảnh. Truyền tên tệp đầu ra và định dạng hình ảnh làm đối số.

{{% alert color="primary" %}} 

**Lưu ý:** Quá trình chuyển đổi PPT, PPTX hoặc ODP sang JPG khác với việc chuyển đổi sang các định dạng khác trong API Aspose.Slides Android qua Java. Đối với các định dạng khác, bạn thường sử dụng phương thức [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Tuy nhiên, để chuyển đổi sang JPG, bạn cần sử dụng phương thức [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

{{% /alert %}} 

```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Tạo một hình ảnh slide với tỷ lệ đã chỉ định.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // Lưu hình ảnh vào đĩa ở định dạng JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển Đổi Các Slide Sang JPG Với Kích Thước Tùy Chỉnh**

Để thay đổi kích thước của các hình ảnh JPG kết quả, bạn có thể thiết lập kích thước hình ảnh bằng cách truyền vào phương thức [ISlide.getImage(Size)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-). Điều này cho phép bạn tạo ra các hình ảnh với giá trị chiều rộng và chiều cao cụ thể, đảm bảo đầu ra đáp ứng yêu cầu về độ phân giải và tỷ lệ khung hình. Tính linh hoạt này đặc biệt hữu ích khi tạo hình ảnh cho các ứng dụng web, báo cáo hoặc tài liệu, nơi cần kích thước hình ảnh chính xác.

```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Tạo một hình ảnh slide với kích thước đã chỉ định.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // Lưu hình ảnh vào đĩa ở định dạng JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kết Xuất Bình Luận Khi Lưu Slide Dưới Dạng Hình Ảnh**

Aspose.Slides cho Android thông qua Java cung cấp tính năng cho phép bạn kết xuất các bình luận trên slide của bản trình bày khi chuyển đổi chúng thành hình ảnh JPG. Tính năng này đặc biệt hữu ích để bảo lưu các chú thích, phản hồi hoặc thảo luận do các cộng tác viên thêm vào trong bản trình bày PowerPoint. Bằng cách kích hoạt tùy chọn này, bạn đảm bảo các bình luận hiển thị trong hình ảnh được tạo, giúp việc xem xét và chia sẻ phản hồi trở nên dễ dàng hơn mà không cần mở tệp bản trình bày gốc.

Giả sử chúng ta có một tệp bản trình bày, "sample.pptx", với một slide chứa bình luận:

![Slide có bình luận](slide_with_comments.png)

Mã Java sau đây chuyển đổi slide sang hình ảnh JPG đồng thời giữ lại các bình luận:

```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // Chuyển slide đầu tiên thành hình ảnh.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình JPG có bình luận](image_with_comments.png)

## **Xem Thêm**

Xem các tùy chọn khác để chuyển đổi PPT, PPTX hoặc ODP sang hình ảnh, chẳng hạn như:

- [Chuyển Đổi PowerPoint sang GIF](/slides/vi/androidjava/convert-powerpoint-to-animated-gif/)
- [Chuyển Đổi PowerPoint sang PNG](/slides/vi/androidjava/convert-powerpoint-to-png/)
- [Chuyển Đổi PowerPoint sang TIFF](/slides/vi/androidjava/convert-powerpoint-to-tiff/)
- [Chuyển Đổi PowerPoint sang SVG](/slides/vi/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Để xem cách Aspose.Slides chuyển đổi bản trình bày PowerPoint sang hình ảnh JPG, hãy thử các công cụ chuyển đổi trực tuyến miễn phí này: PowerPoint [PPTX sang JPG](https://products.aspose.app/slides/vi/conversion/pptx-to-jpg) và [PPT sang JPG](https://products.aspose.app/slides/vi/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Trình Chuyển Đổi PPTX sang JPG Trực Tuyến Miễn Phí](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose cung cấp một [ứng dụng web Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể ghép các hình ảnh [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và vân vân. 

Bằng cách áp dụng các nguyên tắc giống nhau được mô tả trong bài viết này, bạn có thể chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Để biết thêm thông tin, xem các trang sau: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/java/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/java/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/java/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/java/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/java/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/java/conversion/svg-to-png/).

{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Phương pháp này có hỗ trợ chuyển đổi hàng loạt không?**

Có, Aspose.Slides cho phép chuyển đổi hàng loạt nhiều slide sang JPG trong một thao tác duy nhất.

**Quá trình chuyển đổi có hỗ trợ SmartArt, biểu đồ và các đối tượng phức tạp khác không?**

Có, Aspose.Slides kết xuất tất cả nội dung, bao gồm SmartArt, biểu đồ, bảng, hình dạng và hơn thế nữa. Tuy nhiên, độ chính xác khi kết xuất có thể hơi khác so với PowerPoint, đặc biệt khi sử dụng phông chữ tùy chỉnh hoặc thiếu.

**Có bất kỳ giới hạn nào về số lượng slide có thể được xử lý không?**

Aspose.Slides tự nó không đặt ra bất kỳ giới hạn nghiêm ngặt nào về số lượng slide bạn có thể xử lý. Tuy nhiên, bạn có thể gặp lỗi hết bộ nhớ khi làm việc với các bản trình bày lớn hoặc hình ảnh độ phân giải cao.