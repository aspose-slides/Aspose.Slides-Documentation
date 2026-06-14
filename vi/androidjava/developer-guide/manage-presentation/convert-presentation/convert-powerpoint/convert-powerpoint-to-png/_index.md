---
title: Chuyển đổi các slide PowerPoint sang PNG trên Android
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/androidjava/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bài thuyết trình sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- lưu PPT dưới dạng PNG
- lưu PPTX dưới dạng PNG
- xuất PPT sang PNG
- xuất PPTX sang PNG
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình PowerPoint sang ảnh PNG chất lượng cao một cách nhanh chóng với Aspose.Slides cho Android qua Java, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bản trình chiếu PowerPoint sang ảnh PNG bằng Aspose.Slides. Nó cho thấy cách tải các tệp trình chiếu ở các định dạng như PPT, PPTX và ODP, render các slide thành hình ảnh và lưu kết quả ở định dạng PNG.

Bài viết cũng trình bày cách tùy chỉnh các ảnh PNG được tạo bằng cách đặt giá trị tỉ lệ hoặc chỉ định chiều rộng và chiều cao mong muốn.

## **Chuyển đổi PowerPoint sang PNG**

Thực hiện các bước sau:

1. Tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy đối tượng slide từ bộ sưu tập [Presentation.getSlides()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) dưới giao diện [ISlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlide).
3. Sử dụng phương thức [ISlide.getImage()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlide) để lấy hình thu nhỏ cho mỗi slide.
4. Sử dụng phương thức [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) để lưu hình thu nhỏ của slide ở định dạng PNG.

Đoạn mã Java này cho bạn thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PNG:

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

Nếu bạn muốn nhận các tệp PNG với một tỉ lệ nhất định, bạn có thể đặt giá trị cho `desiredX` và `desiredY`, những giá trị này xác định kích thước của hình thu nhỏ kết quả.

Đoạn mã Java này minh họa thao tác đã mô tả:

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

Nếu bạn muốn nhận các tệp PNG với một kích thước nhất định, bạn có thể truyền các đối số `width` và `height` mong muốn cho `ImageSize`.

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

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể xuất chỉ một hình dạng cụ thể (ví dụ: biểu đồ hoặc ảnh) thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo hình thu nhỏ cho các hình dạng riêng lẻ](/slides/vi/androidjava/create-shape-thumbnails/); bạn có thể render một hình dạng thành ảnh PNG.

**Có hỗ trợ chuyển đổi song song trên máy chủ không?**

Có, nhưng [không chia sẻ](/slides/vi/androidjava/multithreading/) một thể hiện presentation duy nhất giữa các luồng. Hãy sử dụng một thể hiện riêng cho mỗi luồng hoặc quy trình.

**Những hạn chế của phiên bản dùng thử khi xuất ra PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/androidjava/licensing/) cho đến khi cấp phép.