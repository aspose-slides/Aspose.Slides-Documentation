---
title: Chuyển đổi các slide PowerPoint sang PNG trong Java
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/java/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bản trình chiếu sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- lưu PPT dưới dạng PNG
- lưu PPTX dưới dạng PNG
- xuất PPT sang PNG
- xuất PPTX sang PNG
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint sang hình ảnh PNG chất lượng cao nhanh chóng với Aspose.Slides cho Java, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu PowerPoint thành hình ảnh PNG bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tải các tệp bản trình chiếu ở các định dạng như PPT, PPTX và ODP, hiển thị các slide dưới dạng hình ảnh và lưu kết quả ở định dạng PNG.

Bài viết cũng trình bày cách tùy chỉnh các hình ảnh PNG được tạo bằng cách đặt giá trị tỉ lệ hoặc chỉ định chiều rộng và chiều cao mong muốn.

## **Chuyển đổi PowerPoint sang PNG**

Thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy đối tượng slide từ bộ sưu tập [Presentation.getSlides()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) dưới giao diện [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide).
3. Sử dụng phương thức [ISlide.getImage()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide) để lấy hình thu nhỏ cho mỗi slide.
4. Sử dụng phương thức [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) để lưu hình thu nhỏ của slide dưới định dạng PNG.

Đoạn mã Java sau cho thấy cách chuyển đổi bản trình chiếu PowerPoint sang PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Nếu bạn muốn tạo các tệp PNG với một tỉ lệ nhất định, bạn có thể đặt giá trị cho `desiredX` và `desiredY`, chúng sẽ xác định kích thước của hình thu nhỏ kết quả. 

Đoạn mã Java sau minh họa hoạt động đã mô tả:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Nếu bạn muốn tạo các tệp PNG với một kích thước nhất định, bạn có thể truyền các đối số `width` và `height` mong muốn cho `ImageSize`. 

Đoạn mã này cho bạn thấy cách chuyển đổi PowerPoint sang PNG trong khi chỉ định kích thước cho các hình ảnh: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Làm thế nào tôi có thể xuất chỉ một hình dạng cụ thể (ví dụ: biểu đồ hoặc ảnh) thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo hình thu nhỏ cho các hình dạng riêng lẻ](/slides/vi/java/create-shape-thumbnails/); bạn có thể render một hình dạng thành hình ảnh PNG.

**Chuyển đổi song song có được hỗ trợ trên máy chủ không?**

Có, nhưng [không chia sẻ](/slides/vi/java/multithreading/) một thể hiện bản trình chiếu duy nhất giữa các luồng. Hãy sử dụng một thể hiện riêng cho mỗi luồng hoặc tiến trình.

**Các hạn chế của phiên bản dùng thử khi xuất sang PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/java/licensing/) cho đến khi giấy phép được cấp.