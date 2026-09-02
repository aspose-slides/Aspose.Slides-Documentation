---
title: Tạo Hình Thu Nhỏ của Các Hình Dạng trong Bản Thuyết Trình bằng JavaScript
linktitle: Hình Thu Nhỏ Hình Dạng
type: docs
weight: 70
url: /vi/nodejs-java/create-shape-thumbnails/
keywords:
- hình thu nhỏ hình dạng
- hình ảnh hình dạng
- render hình dạng
- kết xuất hình dạng
- giới hạn trực quan
- giới hạn hình dạng
- PowerPoint
- bản thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo hình thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint bằng JavaScript và Aspose.Slides cho Node.js – dễ dàng tạo và xuất hình thu nhỏ bản thuyết trình."
---
## **Giới thiệu**

Aspose.Slides được sử dụng để tạo các tệp thuyết trình trong đó mỗi trang là một slide. Các slide này có thể được xem bằng cách mở tệp thuyết trình bằng Microsoft PowerPoint. Nhưng đôi khi, các nhà phát triển có thể cần xem hình ảnh của các hình dạng riêng biệt trong một trình xem ảnh. Trong những trường hợp như vậy, Aspose.Slides giúp bạn tạo các hình thu nhỏ của các hình dạng trên slide. Cách sử dụng tính năng này được mô tả trong bài viết này.

Bài viết này giải thích cách tạo hình thu nhỏ slide theo các cách khác nhau:

- Tạo hình thu nhỏ cho một hình dạng bên trong một slide.
- Tạo hình thu nhỏ cho một hình dạng trên slide với kích thước do người dùng định nghĩa.
- Tạo hình thu nhỏ cho một hình dạng trong giới hạn của hiển thị hình dạng.

## **Tạo hình thu nhỏ hình dạng từ slide**

Để tạo hình thu nhỏ cho một hình dạng từ bất kỳ slide nào bằng Aspose.Slides cho Node.js qua Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. [Lấy hình thu nhỏ hình dạng](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getImage--) của slide đã tham chiếu với tỉ lệ mặc định.
1. Lưu ảnh thu nhỏ ở định dạng ảnh bạn muốn.

```javascript
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Tạo một ảnh tỉ lệ đầy đủ
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Lưu ảnh vào đĩa ở định dạng PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tạo hình thu nhỏ hình dạng với hệ số thu phóng do người dùng định nghĩa**

Để tạo hình thu nhỏ cho một hình dạng trên slide bằng Aspose.Slides cho Node.js qua Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. [Lấy hình thu nhỏ hình dạng](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) của slide đã tham chiếu với kích thước do người dùng định nghĩa.
1. Lưu ảnh thu nhỏ ở định dạng ảnh bạn muốn.

```javascript
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Tạo một ảnh tỉ lệ đầy đủ
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Lưu ảnh vào đĩa ở định dạng PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tạo hình thu nhỏ hình dạng trong giới hạn**

Phương pháp này cho phép các nhà phát triển tạo hình thu nhỏ trong giới hạn hiển thị của hình dạng. Nó tính đến tất cả các hiệu ứng của hình dạng. Hình thu nhỏ được tạo sẽ bị giới hạn bởi giới hạn của slide. Để tạo hình thu nhỏ cho một hình dạng trên slide trong giới hạn hiển thị của nó, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy ảnh thu nhỏ của slide đã tham chiếu với giới hạn hình dạng được xem như hiển thị.
1. Lưu ảnh thu nhỏ ở định dạng ảnh bạn muốn.

```javascript
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Tạo một ảnh tỉ lệ đầy đủ
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Lưu ảnh vào đĩa ở định dạng PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lấy giới hạn hình ảnh thực tế của một hình dạng**

Các thuộc tính khung của một [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/)—các phương thức `getX()`, `getY()`, `getWidth()` và `getHeight()`—mô tả hình chữ nhật được lưu trong mô hình bản trình bày. Nội dung thực tế được render có thể vượt ra ngoài khung đó hoặc chiếm một hình chữ nhật khác được căn trục. Việc xoay, viền, đầu mũi tên, bố cục và tràn văn bản, hình học SmartArt được tạo ra, và các hiệu ứng render khác đều có thể thay đổi khu vực chiếm dụng.

Hãy sử dụng [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getVisualBounds--) để tính toán khu vực chiếm dụng mà không cần tạo hình ảnh. Phương thức này trả về một đối tượng [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) trong tọa độ slide. Hình chữ nhật trả về không bị cắt theo slide, vì vậy tọa độ của nó có thể âm khi nội dung vượt ra ngoài gốc slide.

Ví dụ sau lấy và so sánh khung và giới hạn hình ảnh thực tế:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Bạn có thể sử dụng cùng một hình chữ nhật để căn chỉnh các hình dạng lân cận sang trái, phải, trên hoặc dưới; dự trữ đủ không gian trong bố cục được tạo; hoặc phát hiện nội dung nằm ngoài vùng cho phép. Giới hạn hình ảnh thực tế đặc biệt hữu ích cho SmartArt, hộp văn bản, mũi tên, hình ảnh, các hình dạng xoay, và các nhóm hình dạng, nơi khung lưu trữ có thể không đại diện cho kết quả render đầy đủ.

Sử dụng [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getVisualBounds--) khi bạn cần tọa độ cho việc bố trí hoặc xác thực và không cần bitmap. Sử dụng [Shape.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getImage--) khi bạn cần render hình dạng. Với [ShapeThumbnailBounds](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` định kích thước ảnh từ giới hạn hình dạng, bao gồm cài đặt viền, trong khi `ShapeThumbnailBounds.Appearance` định kích thước từ hiển thị của hình dạng và giới hạn kết quả trong giới hạn slide. Ngược lại, [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getVisualBounds--) chỉ trả về hình chữ nhật đã tính và không cắt nó theo slide.

## **Câu hỏi thường gặp**

**Định dạng ảnh nào có thể được sử dụng khi lưu hình thu nhỏ hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [xuất ra dưới dạng SVG vector](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/writeassvg/) bằng cách lưu nội dung của hình dạng dưới dạng SVG.

**Sự khác nhau giữa giới hạn Shape và Appearance là gì khi render hình thu nhỏ?**

`Shape` sử dụng hình học của hình dạng; `Appearance` tính đến [các hiệu ứng trực quan](/slides/vi/nodejs-java/shape-effect/) (bóng, hào quang, v.v.).

**Điều gì xảy ra nếu một hình dạng được đánh dấu là ẩn? Nó vẫn sẽ được render thành hình thu nhỏ không?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn chỉ ảnh hưởng đến việc hiển thị trong trình chiếu nhưng không ngăn việc tạo ảnh của hình dạng.

**Có hỗ trợ các nhóm hình dạng, biểu đồ, SmartArt và các đối tượng phức tạp khác không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartart/)) đều có thể được lưu dưới dạng hình thu nhỏ hoặc dưới dạng SVG.

**Phông chữ được cài đặt hệ thống có ảnh hưởng tới chất lượng hình thu nhỏ cho các hình dạng văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/nodejs-java/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/nodejs-java/font-substitution/)) để tránh việc fallback không mong muốn và việc bố trí lại văn bản.