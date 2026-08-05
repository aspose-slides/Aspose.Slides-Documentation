---
title: Tạo Hình Thu Nhỏ của Các Hình Dạng trong Bản Trình chiếu trên Android
linktitle: Hình Thu Nhỏ Hình Dạng
type: docs
weight: 70
url: /vi/androidjava/create-shape-thumbnails/
keywords:
- hình thu nhỏ hình dạng
- hình ảnh hình dạng
- kết xuất hình dạng
- kết xuất hình dạng
- giới hạn trực quan
- giới hạn hình dạng
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo hình thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint bằng Aspose.Slides cho Android qua Java – dễ dàng tạo và xuất hình thu nhỏ bản trình chiếu."
---
## **Giới thiệu**

Aspose.Slides for Android via Java có thể được sử dụng để tạo tệp trình chiếu trong đó mỗi trang tương ứng với một slide. Các slide có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Tuy nhiên, các nhà phát triển đôi khi cần xem hình ảnh của các hình dạng riêng biệt trong một trình xem ảnh. Trong những trường hợp này, Aspose.Slides for Android via Java giúp họ tạo ra các hình thu nhỏ của các hình dạng trong slide.

Trong chủ đề này, chúng tôi sẽ chỉ cách tạo hình thu nhỏ cho slide trong các tình huống khác nhau:

- Tạo hình thu nhỏ cho một hình dạng trong slide.
- Tạo hình thu nhỏ cho một hình dạng slide với kích thước do người dùng định nghĩa.
- Tạo hình thu nhỏ cho một hình dạng trong giới hạn của ngoại hình hình dạng.

## **Tạo hình thu nhỏ cho hình dạng từ một slide**
Để tạo hình thu nhỏ cho một hình dạng từ bất kỳ slide nào bằng Aspose.Slides for Android via Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu tới bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. [Lấy hình thu nhỏ của hình dạng](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#getImage--) của slide được tham chiếu với tỷ lệ mặc định.
1. Lưu hình thu nhỏ ở định dạng ảnh bạn muốn.

Mã mẫu này cho thấy cách tạo hình thu nhỏ cho một hình dạng từ slide:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo một hình ảnh ở tỷ lệ đầy đủ
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
Để tạo hình thu nhỏ cho một hình dạng slide bằng Aspose.Slides for Android via Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu tới bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. [Lấy hình thu nhỏ của hình dạng](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) của slide được tham chiếu với kích thước do người dùng xác định.
1. Lưu hình thu nhỏ ở định dạng ảnh bạn muốn.

Mã mẫu này cho thấy cách tạo hình thu nhỏ cho một hình dạng dựa trên hệ số tỷ lệ đã định nghĩa:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo một hình ảnh ở tỷ lệ đầy đủ
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

## **Tạo hình thu nhỏ dựa trên giới hạn của ngoại hình hình dạng**
Phương pháp tạo hình thu nhỏ cho các hình dạng này cho phép các nhà phát triển tạo hình thu nhỏ trong giới hạn của ngoại hình hình dạng. Nó tính đến tất cả các hiệu ứng của hình dạng. Hình thu nhỏ được tạo ra bị giới hạn bởi giới hạn của slide. Để tạo hình thu nhỏ cho một hình dạng trong giới hạn của ngoại hình của nó, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu tới bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình thu nhỏ của slide được tham chiếu với giới hạn của hình dạng làm ngoại hình.
1. Lưu hình thu nhỏ ở định dạng ảnh bạn muốn.

Mã mẫu dựa trên các bước trên:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tạo một hình ảnh ở tỷ lệ đầy đủ
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

Các thuộc tính khung của [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) — các phương thức `getX()`, `getY()`, `getWidth()` và `getHeight()` — mô tả hình chữ nhật được lưu trong mô hình trình chiếu. Nội dung thực tế được vẽ có thể mở rộng ra ngoài khung đó hoặc chiếm một hình chữ nhật vuông góc khác. Việc xoay, viền, đầu mũi tên, bố cục và tràn văn bản, hình học SmartArt được tạo ra và các hiệu ứng render khác đều có thể thay đổi khu vực chiếm dụng.

Sử dụng [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getVisualBounds--) để tính toán khu vực chiếm dụng mà không cần tạo ảnh. Phương thức trả về một đối tượng [RectF](https://developer.android.com/reference/android/graphics/RectF) trong tọa độ slide. Hình chữ nhật trả về không được cắt theo slide, vì vậy tọa độ của nó có thể âm khi nội dung mở rộng ra ngoài gốc slide.

`Shape.getVisualBounds` hiện chưa được khai báo trong giao diện [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/). Do đó, hãy giữ đối tượng hình dạng lấy từ bộ sưu tập hình dạng của slide dưới dạng giá trị giao diện và ép kiểu chỉ khi gọi phương thức.

Ví dụ dưới đây lấy và so sánh khung và giới hạn trực quan:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Cùng một đối tượng [RectF](https://developer.android.com/reference/android/graphics/RectF) có thể được sử dụng để căn chỉnh các hình dạng lân cận sang trái, phải, trên hoặc dưới; dành đủ không gian trong bố cục được tạo; hoặc phát hiện nội dung nằm ngoài vùng cho phép. Giới hạn trực quan đặc biệt hữu ích cho SmartArt, hộp văn bản, mũi tên, hình ảnh, hình dạng xoay và nhóm hình dạng, nơi khung lưu trữ có thể không đại diện cho kết quả render đầy đủ.

Sử dụng [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getVisualBounds--) khi bạn cần tọa độ cho bố cục hoặc kiểm tra và không cần bitmap. Sử dụng [IShape.getImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getImage--) khi bạn cần render hình dạng. Với [ShapeThumbnailBounds](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` định kích thước ảnh dựa trên giới hạn của hình dạng, bao gồm cài đặt viền, trong khi `ShapeThumbnailBounds.Appearance` định kích thước từ ngoại hình của hình dạng và giới hạn kết quả trong giới hạn slide. Ngược lại, [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getVisualBounds--) chỉ trả về hình chữ nhật đã tính và không cắt nó theo slide.

## **Câu hỏi thường gặp**

**Các định dạng ảnh nào có thể được sử dụng khi lưu hình thu nhỏ của hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [xuất dưới dạng vector SVG](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) bằng cách lưu nội dung hình dạng dưới dạng SVG.

**Sự khác nhau giữa giới hạn Shape và Appearance khi tạo hình thu nhỏ là gì?**

`Shape` sử dụng hình học của hình dạng; `Appearance` tính đến [visual effects](/slides/vi/androidjava/shape-effect/) (bóng đổ, phát sáng, v.v.).

**Nếu một hình dạng được đánh dấu là ẩn thì sẽ xảy ra điều gì? Nó vẫn được render thành hình thu nhỏ không?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn chỉ ảnh hưởng tới việc hiển thị trong chế độ trình chiếu chứ không ngăn việc tạo ảnh cho hình dạng.

**Các nhóm hình dạng, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/) và [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/smartart/)) đều có thể được lưu dưới dạng hình thu nhỏ hoặc dưới dạng SVG.

**Các phông chữ được cài đặt hệ thống có ảnh hưởng đến chất lượng hình thu nhỏ của các hình dạng văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/androidjava/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/androidjava/font-substitution/)) để tránh việc sử dụng phông thay thế không mong muốn và làm thay đổi bố cục văn bản.