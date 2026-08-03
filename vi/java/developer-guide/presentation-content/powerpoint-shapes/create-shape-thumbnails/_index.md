---
title: Tạo Hình Thu Nhỏ Cho Các Hình Dạng Trong Bản Trình Chiếu Bằng Java
linktitle: Hình Thu Nhỏ Hình Dạng
type: docs
weight: 70
url: /vi/java/create-shape-thumbnails/
keywords:
- hình thu nhỏ hình dạng
- hình ảnh hình dạng
- render hình dạng
- kết xuất hình dạng
- giới hạn trực quan
- giới hạn hình dạng
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo hình thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint với Aspose.Slides cho Java – dễ dàng tạo và xuất hình thu nhỏ cho bản trình chiếu."
---
## **Giới thiệu**

Aspose.Slides for Java có thể được sử dụng để tạo tệp trình chiếu trong đó mỗi trang tương ứng với một slide. Các slide có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Tuy nhiên, các nhà phát triển đôi khi cần xem hình ảnh của các hình dạng riêng biệt trong một trình xem ảnh. Trong những trường hợp như vậy, Aspose.Slides for Java giúp họ tạo ra các hình ảnh thu nhỏ của các hình dạng trên slide.

Bài viết này giải thích cách tạo hình thu nhỏ cho slide theo các cách khác nhau:

- Tạo hình thu nhỏ của một hình dạng trong một slide.
- Tạo hình thu nhỏ của một hình dạng trên slide với kích thước do người dùng định nghĩa.
- Tạo hình thu nhỏ của một hình dạng trong giới hạn của hiển thị hình dạng.

## **Tạo hình thu nhỏ cho hình dạng từ một slide**

Để tạo hình thu nhỏ cho một hình dạng từ bất kỳ slide nào bằng Aspose.Slides for Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getImage--) của slide đã tham chiếu ở tỉ lệ mặc định.
1. Lưu hình thu nhỏ ở định dạng ảnh mà bạn muốn.

```java
// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo hình ảnh ở tỷ lệ đầy đủ
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

## **Tạo hình thu nhỏ với hệ số co dãn do người dùng xác định**

Để tạo hình thu nhỏ cho một hình dạng từ bất kỳ slide nào bằng Aspose.Slides for Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getImage-int-float-float-) của slide đã tham chiếu với kích thước do người dùng xác định.
1. Lưu hình thu nhỏ ở định dạng ảnh mà bạn muốn.

```java
// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo hình ảnh ở tỷ lệ đầy đủ
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

## **Tạo hình thu nhỏ hiển thị hình dạng dựa trên giới hạn**

Phương pháp tạo hình thu nhỏ cho các hình dạng này cho phép các nhà phát triển tạo hình thu nhỏ trong giới hạn của hiển thị hình dạng. Nó tính đến tất cả các hiệu ứng của hình dạng. Hình thu nhỏ được tạo ra bị giới hạn bởi giới hạn của slide. Để tạo hình thu nhỏ cho một hình dạng trên slide trong giới hạn của hiển thị, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với giới hạn hình dạng làm hiển thị.
1. Lưu hình thu nhỏ ở định dạng ảnh mà bạn muốn.

```java
// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo hình ảnh ở tỷ lệ đầy đủ
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

## **Lấy giới hạn trực quan thực tế của một hình dạng**

Các thuộc tính khung của [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) — các phương thức `getX()`, `getY()`, `getWidth()`, và `getHeight()` — mô tả hình chữ nhật lưu trong mô hình trình chiếu. Nội dung thực tế được vẽ có thể mở rộng ra ngoài khung đó hoặc chiếm một hình chữ nhật khác song song với trục. Việc xoay, viền, đầu mũi tên, bố cục và tràn văn bản, hình học SmartArt được tạo ra, và các hiệu ứng vẽ khác có thể làm thay đổi khu vực chiếm dụng.

Sử dụng [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getVisualBounds--) để tính toán khu vực chiếm dụng mà không tạo hình ảnh. Phương thức này trả về một đối tượng [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) trong tọa độ slide. Hình chữ nhật trả về không bị cắt theo slide, vì vậy tọa độ của nó có thể là số âm khi nội dung mở rộng ra ngoài gốc slide.

[Shape.getVisualBounds](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getVisualBounds--) hiện không được khai báo trong giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/). Do đó, giữ đối tượng shape lấy từ bộ sưu tập shape của slide dưới dạng một giá trị giao diện và chỉ ép kiểu khi gọi phương thức.

Ví dụ sau lấy và so sánh khung và giới hạn trực quan:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Cùng một [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) có thể được dùng để căn chỉnh các hình dạng lân cận tới cạnh trái, phải, trên hoặc dưới của nó; dự trữ đủ không gian trong bố cục được tạo; hoặc phát hiện nội dung nằm ngoài một khu vực cho phép. Các giới hạn trực quan đặc biệt hữu ích cho SmartArt, hộp văn bản, mũi tên, hình ảnh, hình dạng đã xoay và nhóm hình dạng, nơi khung lưu trữ có thể không đại diện cho kết quả vẽ đầy đủ.

Sử dụng [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getVisualBounds--) khi bạn cần tọa độ cho bố cục hoặc xác thực và không cần bitmap. Sử dụng [IShape.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getImage--) khi bạn cần vẽ hình dạng. Với [ShapeThumbnailBounds](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` tạo kích thước ảnh dựa trên giới hạn của hình dạng, bao gồm cài đặt viền, trong khi `ShapeThumbnailBounds.Appearance` tạo kích thước dựa trên hiển thị của hình dạng và giới hạn kết quả trong giới hạn của slide. Ngược lại, [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getVisualBounds--) chỉ trả về hình chữ nhật đã tính và không cắt nó theo slide.

## **FAQ**

**Các định dạng ảnh nào có thể được sử dụng khi lưu hình thu nhỏ của hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [xuất dưới dạng SVG vector](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) bằng cách lưu nội dung của hình dạng dưới dạng SVG.

**Sự khác biệt giữa giới hạn Shape và Appearance khi render hình thu nhỏ là gì?**

`Shape` sử dụng hình học của hình dạng; `Appearance` tính đến [các hiệu ứng trực quan](/slides/vi/java/shape-effect/) (bóng, phát sáng, v.v.).

**Nếu một hình dạng được đánh dấu là ẩn thì sẽ xảy ra gì? Nó vẫn sẽ được render thành hình thu nhỏ không?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn chỉ ảnh hưởng đến việc hiển thị trong chế độ trình chiếu nhưng không ngăn việc tạo ảnh của hình dạng.

**Các nhóm hình dạng, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/smartart/)) đều có thể được lưu dưới dạng hình thu nhỏ hoặc dưới dạng SVG.

**Các phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng hình thu nhỏ cho các hình dạng văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/java/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/java/font-substitution/)) để tránh việc fallback không mong muốn và việc bố cục lại văn bản.