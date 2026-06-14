---
title: Chuyển đổi PPT và PPTX sang JPG trong Java
linktitle: PowerPoint sang JPG
type: docs
weight: 60
url: /vi/java/convert-powerpoint-to-jpg/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang JPG
- bài thuyết trình sang JPG
- slide sang JPG
- PPT sang JPG
- PPTX sang JPG
- lưu PowerPoint dưới dạng JPG
- lưu bài thuyết trình dưới dạng JPG
- lưu slide dưới dạng JPG
- lưu PPT dưới dạng JPG
- lưu PPTX dưới dạng JPG
- xuất PPT sang JPG
- xuất PPTX sang JPG
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint (PPT, PPTX) sang hình ảnh JPG chất lượng cao trong Java với Aspose.Slides cho Java bằng các ví dụ mã nhanh và đáng tin cậy."
---
## **Giới thiệu**

Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang hình ảnh JPG giúp chia sẻ slide, tối ưu hiệu năng và nhúng nội dung vào website hoặc ứng dụng. Aspose.Slides cho phép bạn chuyển đổi các tệp PPTX, PPT và ODP thành hình ảnh JPEG chất lượng cao. Hướng dẫn này giải thích các phương pháp chuyển đổi khác nhau.

Với các tính năng này, bạn có thể dễ dàng triển khai trình xem bản trình chiếu của riêng mình và tạo ảnh thu nhỏ cho mỗi slide. Điều này có thể hữu ích nếu bạn muốn bảo vệ slide khỏi việc sao chép hoặc trình diễn bản trình chiếu ở chế độ chỉ đọc. Aspose.Slides cho phép bạn chuyển đổi toàn bộ bản trình chiếu hoặc một slide cụ thể sang các định dạng ảnh.

## **Chuyển đổi PowerPoint PPT/PPTX sang JPG**

1. Tạo một thể hiện của loại [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy đối tượng slide của loại [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide) từ bộ sưu tập [Presentation.getSlides()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--).
3. Tạo ảnh thu nhỏ cho mỗi slide và sau đó chuyển đổi nó sang JPG. Phương thức [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide#getImage-float-float-) được sử dụng để lấy ảnh thu nhỏ của một slide, nó trả về đối tượng [Images](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Images) như kết quả. Phương thức [getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) phải được gọi từ slide cần thiết của loại [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide), các tỷ lệ của ảnh thu nhỏ kết quả được truyền vào phương thức.
4. Sau khi bạn lấy được ảnh thu nhỏ của slide, gọi phương pháp [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) từ đối tượng ảnh thu nhỏ. Đưa tên tệp kết quả và định dạng ảnh vào phương pháp này.

{{% alert color="primary" %}}
**Lưu ý**: việc chuyển đổi PPT/PPTX sang JPG khác với việc chuyển đổi sang các loại khác trong API Aspose.Slides. Đối với các loại khác, bạn thường sử dụng phương thức [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), nhưng ở đây bạn cần phương thức [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Tạo ảnh toàn kích thước
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

Để thay đổi kích thước của ảnh thu nhỏ và hình ảnh JPG kết quả, bạn có thể đặt giá trị *ScaleX* và *ScaleY* bằng cách truyền chúng vào các phương thức [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide#getImage-float-float-).

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Định nghĩa kích thước
    int desiredX = 1200;
    int desiredY = 800;
    // Lấy giá trị tỷ lệ của X và Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Tạo ảnh toàn kích thước
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

## **Hiển thị Bình luận Khi Lưu Slide dưới dạng Hình ảnh**

Aspose.Slides cho Java cung cấp một chức năng cho phép bạn hiển thị bình luận trên các slide của bản trình chiếu khi chuyển đổi chúng thành hình ảnh. đoạn mã Java sau đây minh họa hoạt động này:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

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

{{% alert title="Tip" color="primary" %}}
Aspose cung cấp một [ứng dụng web Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể ghép các ảnh [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và nhiều hơn nữa.

Bằng việc áp dụng cùng các nguyên tắc được mô tả trong bài viết này, bạn có thể chuyển đổi ảnh từ định dạng này sang định dạng khác. Để biết thêm thông tin, xem các trang sau: chuyển đổi [image sang JPG](https://products.aspose.com/slides/vi/java/conversion/image-to-jpg/); chuyển đổi [JPG sang image](https://products.aspose.com/slides/vi/java/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/java/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/java/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/java/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Phương pháp này có hỗ trợ chuyển đổi hàng loạt không?**

Có, Aspose.Slides cho phép chuyển đổi hàng loạt nhiều slide sang JPG trong một thao tác duy nhất.

**Việc chuyển đổi có hỗ trợ SmartArt, biểu đồ và các đối tượng phức tạp khác không?**

Có, Aspose.Slides sẽ render tất cả nội dung, bao gồm SmartArt, biểu đồ, bảng, hình dạng và hơn thế nữa. Tuy nhiên, độ chính xác của việc render có thể hơi khác so với PowerPoint, đặc biệt khi sử dụng phông chữ tùy chỉnh hoặc thiếu phông chữ.

**Có bất kỳ giới hạn nào về số lượng slide có thể xử lý không?**

Aspose.Slides tự nó không áp đặt bất kỳ giới hạn nghiêm ngặt nào về số lượng slide bạn có thể xử lý. Tuy nhiên, bạn có thể gặp lỗi hết bộ nhớ khi làm việc với các bản trình chiếu lớn hoặc ảnh có độ phân giải cao.

## **See Also**

Xem các tùy chọn khác để chuyển đổi PPT/PPTX sang hình ảnh như:

- [Chuyển đổi PPT/PPTX sang SVG](/slides/vi/java/render-a-slide-as-an-svg-image/).