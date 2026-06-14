---
title: Tạo Hình Thu Nhỏ cho Các Shape trong Bản Trình Chiếu bằng Java
linktitle: Hình Thu Nhỏ Shape
type: docs
weight: 70
url: /vi/java/create-shape-thumbnails/
keywords:
- hình thu nhỏ shape
- hình ảnh shape
- render shape
- render shape
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo các hình thu nhỏ shape chất lượng cao từ các slide PowerPoint bằng Aspose.Slides cho Java – dễ dàng tạo và xuất các hình thu nhỏ của bản trình chiếu."
---
## **Giới thiệu**

Aspose.Slides for Java có thể được sử dụng để tạo tệp trình chiếu trong đó mỗi trang tương ứng với một slide. Các slide có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Tuy nhiên, đôi khi các nhà phát triển cần xem các hình ảnh của các shape riêng biệt trong một trình xem ảnh. Trong những trường hợp này, Aspose.Slides for Java giúp họ tạo ra các hình thu nhỏ của các shape trong slide.

Bài viết này giải thích cách tạo hình thu nhỏ cho slide bằng các cách khác nhau:

- Tạo hình thu nhỏ cho shape trong một slide.
- Tạo hình thu nhỏ cho shape trong slide với kích thước do người dùng xác định.
- Tạo hình thu nhỏ cho shape trong giới hạn của phần hiển thị của shape.

## **Tạo hình thu nhỏ cho Shape từ một Slide**
Để tạo hình thu nhỏ cho shape từ bất kỳ slide nào bằng Aspose.Slides for Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
2. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
3. Lấy hình thu nhỏ của shape bằng [Get the shape thumbnail image](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#getImage--) của slide đã tham chiếu ở tỉ lệ mặc định.
4. Lưu hình thu nhỏ dưới định dạng ảnh mà bạn muốn.

Mã mẫu này cho bạn thấy cách tạo hình thu nhỏ cho shape từ một slide:

```java
// Tạo một lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo một hình ảnh với tỉ lệ đầy đủ
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Lưu hình ảnh vào đĩa ở định dạng PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tạo hình thu nhỏ với hệ số tỷ lệ do người dùng định nghĩa**
Để tạo hình thu nhỏ cho shape của một slide bằng Aspose.Slides for Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
2. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
3. Lấy hình thu nhỏ của shape bằng [Get the shape thumbnail image](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#getImage-int-float-float-) của slide đã tham chiếu với kích thước do người dùng xác định.
4. Lưu hình thu nhỏ dưới định dạng ảnh mà bạn muốn.

Mã mẫu này cho bạn thấy cách tạo hình thu nhỏ cho shape dựa trên hệ số tỷ lệ đã định nghĩa:

```java
// Tạo một lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo một hình ảnh tỉ lệ đầy đủ
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Lưu hình ảnh vào đĩa ở định dạng PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tạo hình thu nhỏ dựa trên giới hạn hiển thị của Shape**
Phương pháp tạo hình thu nhỏ cho shape này cho phép các nhà phát triển tạo hình thu nhỏ trong giới hạn của phần hiển thị của shape. Nó tính đến tất cả các hiệu ứng của shape. Hình thu nhỏ được tạo ra bị giới hạn bởi giới hạn của slide. Để tạo hình thu nhỏ cho shape trong slide trong giới hạn của phần hiển thị, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
2. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
3. Lấy hình thu nhỏ của slide đã tham chiếu với giới hạn shape dưới dạng appearance.
4. Lưu hình thu nhỏ dưới định dạng ảnh mà bạn muốn.

Mã mẫu dưới đây dựa trên các bước trên:

```java
// Tạo một lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo một hình ảnh tỉ lệ đầy đủ
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Lưu hình ảnh vào đĩa ở định dạng PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Các định dạng ảnh nào có thể được sử dụng khi lưu hình thu nhỏ của shape?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imageformat/), và các định dạng khác. Shapes cũng có thể được [xuất ra dạng vector SVG](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) bằng cách lưu nội dung của shape dưới dạng SVG.

**Sự khác nhau giữa giới hạn Shape và Appearance khi render hình thu nhỏ là gì?**

`Shape` sử dụng hình học của shape; `Appearance` tính đến [visual effects](/slides/vi/java/shape-effect/) (bóng, hào quang, v.v.).

**Điều gì xảy ra nếu một shape được đánh dấu là ẩn? Nó vẫn sẽ được render thành hình thu nhỏ không?**

Một shape ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn chỉ ảnh hưởng tới việc hiển thị trong trình chiếu nhưng không ngăn việc tạo ảnh của shape.

**Các shape nhóm, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/smartart/)) đều có thể được lưu dưới dạng hình thu nhỏ hoặc SVG.

**Các phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng hình thu nhỏ của shape văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/java/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/java/font-substitution/)) để tránh việc fallback không mong muốn và việc thay đổi bố cục văn bản.