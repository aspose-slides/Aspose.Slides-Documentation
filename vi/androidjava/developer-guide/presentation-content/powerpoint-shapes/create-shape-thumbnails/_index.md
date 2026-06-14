---
title: Tạo Hình Thu Nhỏ cho Các Hình Dạng trong Bài Thuyết Trình trên Android
linktitle: Hình Thu Nhỏ Hình Dạng
type: docs
weight: 70
url: /vi/androidjava/create-shape-thumbnails/
keywords:
- hình thu nhỏ hình dạng
- hình ảnh hình dạng
- kết xuất hình dạng
- kết xuất hình dạng
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tạo ra các hình thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint với Aspose.Slides for Android via Java – dễ dàng tạo và xuất các hình thu nhỏ cho bài thuyết trình."
---
## **Giới thiệu**

Aspose.Slides for Android via Java có thể được sử dụng để tạo các tệp trình chiếu trong đó mỗi trang tương ứng với một slide. Các slide có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Tuy nhiên, đôi khi các nhà phát triển cần xem riêng các hình ảnh của các hình dạng trong một trình xem ảnh. Trong những trường hợp như vậy, Aspose.Slides for Android via Java giúp họ tạo ra các hình thu nhỏ của các hình dạng trên slide.

Trong chủ đề này, chúng tôi sẽ chỉ cho bạn cách tạo hình thu nhỏ cho slide trong các tình huống khác nhau:

- Tạo hình thu nhỏ cho một hình dạng bên trong slide.
- Tạo hình thu nhỏ cho một hình dạng trên slide với kích thước do người dùng xác định.
- Tạo hình thu nhỏ cho một hình dạng trong giới hạn của ngoại hình của nó.

## **Tạo hình thu nhỏ cho hình dạng từ một slide**
Để tạo hình thu nhỏ cho một hình dạng từ bất kỳ slide nào bằng Aspose.Slides for Android via Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation]().
2. Lấy tham chiếu đến bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
3. [Lấy hình thu nhỏ của hình dạng] của slide được tham chiếu với tỷ lệ mặc định.
4. Lưu hình thu nhỏ dưới định dạng ảnh bạn ưa thích.

Mã mẫu này cho thấy cách tạo hình thu nhỏ cho một hình dạng từ slide:

```java
// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo ảnh ở kích thước đầy đủ
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Lưu ảnh vào ổ đĩa ở định dạng PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tạo hình thu nhỏ với yếu tố tỷ lệ do người dùng xác định**
Để tạo hình thu nhỏ của hình dạng trên slide bằng Aspose.Slides for Android via Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation]().
2. Lấy tham chiếu đến bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
3. [Lấy hình thu nhỏ của hình dạng] của slide được tham chiếu với các kích thước do người dùng xác định.
4. Lưu hình thu nhỏ dưới định dạng ảnh bạn ưa thích.

Mã mẫu này cho thấy cách tạo hình thu nhỏ cho một hình dạng dựa trên yếu tố tỷ lệ được định nghĩa:

```java
// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo ảnh ở kích thước đầy đủ
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Lưu ảnh vào ổ đĩa ở định dạng PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tạo hình thu nhỏ dựa trên giới hạn của ngoại hình hình dạng**
Phương pháp tạo hình thu nhỏ cho các hình dạng này cho phép các nhà phát triển tạo ra một hình thu nhỏ trong giới hạn của ngoại hình hình dạng. Nó tính đến tất cả các hiệu ứng của hình dạng. Hình thu nhỏ được tạo ra bị giới hạn bởi giới hạn của slide. Để tạo hình thu nhỏ cho một hình dạng trên slide trong giới hạn của ngoại hình, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation]().
2. Lấy tham chiếu đến bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
3. Lấy hình thu nhỏ của slide được tham chiếu với giới hạn hình dạng làm ngoại hình.
4. Lưu hình thu nhỏ dưới định dạng ảnh bạn ưa thích.

Mã mẫu dựa trên các bước trên:

```java
// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo ảnh ở kích thước đầy đủ
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Lưu ảnh vào ổ đĩa ở định dạng PNG
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

**Các định dạng ảnh nào có thể được sử dụng khi lưu hình thu nhỏ của hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](), và các định dạng khác. Các hình dạng cũng có thể được [xuất dưới dạng vector SVG]() bằng cách lưu nội dung hình dạng dưới dạng SVG.

**Sự khác biệt giữa giới hạn Shape và Appearance khi tạo hình thu nhỏ là gì?**

`Shape` sử dụng hình học của hình dạng; `Appearance` tính đến [hiệu ứng trực quan](/slides/vi/androidjava/shape-effect/) (bóng, phát sáng, v.v.).

**Nếu một hình dạng được đánh dấu là ẩn thì sao? Nó vẫn được tạo thành hình thu nhỏ chứ?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được tạo hình; cờ ẩn chỉ ảnh hưởng đến việc hiển thị trong trình chiếu nhưng không ngăn việc tạo hình ảnh của hình dạng.

**Có hỗ trợ các hình dạng nhóm, biểu đồ, SmartArt và các đối tượng phức tạp khác không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape]()(bao gồm [GroupShape](), [Chart]() và [SmartArt]()) đều có thể được lưu dưới dạng hình thu nhỏ hoặc SVG.

**Phông chữ được cài đặt hệ thống có ảnh hưởng đến chất lượng hình thu nhỏ cho các hình dạng văn bản không?**

Có. Bạn nên [cung cấp phông chữ cần thiết](/slides/vi/androidjava/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/androidjava/font-substitution/)) để tránh việc thay thế không mong muốn và việc văn bản bị ngắt dòng.