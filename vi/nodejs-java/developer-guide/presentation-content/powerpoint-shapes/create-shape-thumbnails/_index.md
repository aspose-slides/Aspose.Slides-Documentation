---
title: Tạo Hình Thu Nhỏ Cho Các Hình Dạng Bản Trình Chiếu trong JavaScript
linktitle: Hình Thu Nhỏ Hình Dạng
type: docs
weight: 70
url: /vi/nodejs-java/create-shape-thumbnails/
keywords:
- hình thu nhỏ hình dạng
- hình ảnh hình dạng
- kết xuất hình dạng
- kết xuất hình dạng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo các hình thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint bằng JavaScript và Aspose.Slides cho Node.js – dễ dàng tạo và xuất các hình thu nhỏ của bản trình chiếu."
---
## **Giới thiệu**

Aspose.Slides được sử dụng để tạo các tệp trình chiếu, trong đó mỗi trang là một slide. Các slide này có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Tuy nhiên đôi khi, các nhà phát triển có thể cần xem ảnh của các hình dạng riêng biệt trong trình xem ảnh. Trong những trường hợp như vậy, Aspose.Slides giúp bạn tạo hình ảnh thu nhỏ của các hình dạng trên slide. Cách sử dụng tính năng này được mô tả trong bài viết này.

Bài viết này giải thích cách tạo hình thu nhỏ slide theo các cách khác nhau:

- Tạo hình thu nhỏ một hình dạng bên trong slide.
- Tạo hình thu nhỏ một hình dạng trên slide với kích thước do người dùng định nghĩa.
- Tạo hình thu nhỏ trong phạm vi của hiển thị hình dạng.

## **Tạo Hình Thu Nhỏ Hình Dạng Từ Slide**

Để tạo hình thu nhỏ một hình dạng từ bất kỳ slide nào bằng Aspose.Slides cho Node.js qua Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. [Lấy hình thu nhỏ của hình dạng](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getImage--) của slide đã tham chiếu ở tỉ lệ mặc định.
1. Lưu hình ảnh thu nhỏ ở định dạng ảnh bạn muốn.

```javascript
// Tạo một lớp Presentation đại diện cho tệp bản trình chiếu
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Tạo một hình ảnh ở tỉ lệ đầy đủ
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Lưu hình ảnh vào đĩa ở định dạng PNG
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

## **Tạo Hình Thu Nhỏ Hình Dạng Với Hệ Số Thu Phóng Do Người Dùng Định Nghĩa**

Để tạo hình thu nhỏ của hình dạng trên slide bằng Aspose.Slides cho Node.js qua Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. [Lấy hình thu nhỏ của hình dạng](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) của slide đã tham chiếu với kích thước do người dùng định nghĩa.
1. Lưu hình ảnh thu nhỏ ở định dạng ảnh bạn muốn.

```javascript
// Tạo một lớp Presentation đại diện cho tệp bản trình chiếu
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Tạo một hình ảnh ở tỉ lệ đầy đủ
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Lưu hình ảnh vào đĩa ở định dạng PNG
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

## **Tạo Hình Thu Nhỏ Hình Dạng Theo Giới Hạn**

Phương pháp tạo hình thu nhỏ các hình dạng này cho phép các nhà phát triển tạo một hình thu nhỏ trong giới hạn của hiển thị hình dạng. Nó tính đến tất cả các hiệu ứng của hình dạng. Hình thu nhỏ được tạo sẽ bị giới hạn bởi giới hạn của slide. Để tạo hình thu nhỏ của một hình dạng trên slide trong phạm vi hiển thị của nó, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với giới hạn hình dạng được coi là hiển thị.
1. Lưu hình ảnh thu nhỏ ở định dạng ảnh bạn muốn.

```javascript
// Tạo một lớp Presentation đại diện cho tệp bản trình chiếu
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Tạo một hình ảnh ở tỉ lệ đầy đủ
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Lưu hình ảnh vào đĩa ở định dạng PNG
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

## **FAQ**

**Các định dạng hình ảnh nào có thể được sử dụng khi lưu hình thu nhỏ của hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [xuất ra dưới dạng SVG vector](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/writeassvg/) bằng cách lưu nội dung của hình dạng dưới dạng SVG.

**Sự khác biệt giữa giới hạn Shape và Appearance khi render một hình thu nhỏ là gì?**

`Shape` sử dụng hình học của hình dạng; `Appearance` tính đến [các hiệu ứng hình ảnh](/slides/vi/nodejs-java/shape-effect/) (bóng, ánh sáng, v.v.).

**Nếu một hình dạng được đánh dấu là ẩn thì sẽ xảy ra gì? Nó vẫn được render thành hình thu nhỏ không?**

Một hình dạng bị ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn chỉ ảnh hưởng đến hiển thị trình chiếu nhưng không ngăn việc tạo ra hình ảnh của hình dạng.

**Các hình dạng nhóm, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/) và [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartart/)) đều có thể được lưu dưới dạng hình thu nhỏ hoặc SVG.

**Phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng hình thu nhỏ của các hình dạng văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/nodejs-java/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/nodejs-java/font-substitution/)) để tránh các phông chữ dự phòng không mong muốn và việc di chuyển lại văn bản.