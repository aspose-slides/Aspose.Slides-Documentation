---
title: Quản lý danh sách có dấu đầu dòng và đánh số trong bản trình chiếu bằng JavaScript
linktitle: Quản lý danh sách
type: docs
weight: 60
url: /vi/nodejs-java/manage-lists/
keywords:
- dấu đầu dòng
- danh sách có dấu đầu dòng
- danh sách đánh số
- dấu đầu dòng ký hiệu
- dấu đầu dòng hình ảnh
- dấu đầu dòng tùy chỉnh
- danh sách đa cấp
- tạo dấu đầu dòng
- thêm dấu đầu dòng
- thêm danh sách
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng danh sách có dấu đầu dòng, hình ảnh, đa cấp và đánh số trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java cho phép bạn tạo và định dạng các danh sách có dấu đầu dòng và đánh số trong các bản trình chiếu PowerPoint và OpenDocument. Một mục danh sách là một đoạn văn mà các cài đặt dấu đầu dòng được kiểm soát thông qua định dạng đoạn văn của nó.

Sử dụng lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) để truy cập các cài đặt danh sách ở mức độ đoạn văn. Điểm vào chính là `Paragraph.getParagraphFormat().getBullet()`, trả về một đối tượng [BulletFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/). Với đối tượng này, bạn có thể đặt loại dấu đầu dòng, ký hiệu, hình ảnh, màu sắc, kích thước, kiểu đánh số và số bắt đầu.

Bài viết này mô tả cách:

- tạo danh sách có dấu đầu dòng với ký hiệu tùy chỉnh
- tạo dấu đầu dòng dạng hình ảnh
- tạo danh sách đa cấp bằng cách đặt độ sâu đoạn văn
- tạo danh sách có đánh số
- kiểm tra và thay đổi định dạng danh sách trong một bản trình chiếu hiện có

## **Tạo danh sách có dấu đầu dòng**

Để tạo một danh sách có dấu đầu dòng, thêm các đối tượng [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) vào một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) và đặt `BulletFormat.setType` thành [BulletType.Symbol](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bullettype/). Sau đó bạn có thể đặt `BulletFormat.setChar`, `BulletFormat.getColor` và `BulletFormat.setHeight` để kiểm soát diện mạo của dấu đầu dòng.

Mã JavaScript dưới đây minh họa cách tạo một danh sách có dấu đầu dòng trong một slide:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các dấu đầu dòng ký hiệu](symbol_bullets.png)

## **Tạo danh sách có đánh số**

Sử dụng danh sách có đánh số khi thứ tự các mục quan trọng. Đặt `BulletFormat.setType` thành [BulletType.Numbered](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bullettype/). Bạn cũng có thể chọn định dạng đánh số bằng `BulletFormat.setNumberedBulletStyle` hoặc đặt `BulletFormat.setNumberedBulletStartWith` khi danh sách nên bắt đầu từ một giá trị khác 1.

Mã JavaScript dưới đây cho thấy cách tạo một danh sách có đánh số trong một slide:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các dấu đầu dòng có đánh số](numbered_bullets.png)

## **Tạo dấu đầu dòng dạng hình ảnh**

Aspose.Slides cho phép bạn thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh. Dấu đầu dòng dạng hình ảnh hoạt động tốt nhất với các hình ảnh đơn giản vẫn có thể đọc được ở kích thước nhỏ, chẳng hạn như biểu tượng hoặc các tệp PNG trong suốt nhỏ.

{{% alert color="primary" %}}
Lý tưởng nhất, nếu bạn dự định thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh, bạn nên chọn một đồ họa đơn giản với nền trong suốt. Các hình ảnh như vậy hoạt động tốt như các ký hiệu dấu đầu dòng tùy chỉnh.

Hãy nhớ rằng hình ảnh sẽ được thu nhỏ đến kích thước rất nhỏ. Vì lý do này, chúng tôi khuyến nghị mạnh mẽ chọn một hình ảnh vẫn rõ ràng và hiệu quả về mặt thị giác khi được sử dụng làm dấu đầu dòng trong danh sách.
{{% /alert %}}

Để tạo dấu đầu dòng dạng hình ảnh, thêm một hình ảnh vào [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) bằng `Presentation.getImages().addImage` và gán đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) trả về cho `BulletFormat.getPicture().setImage`. Đặt `BulletFormat.setType` thành [BulletType.Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bullettype/) trước khi gán hình ảnh.

Giả sử chúng ta có một "image.png":

![Một hình ảnh cho các dấu đầu dòng](picture_for_bullets.png)

Mã JavaScript dưới đây cho thấy cách tạo dấu đầu dòng dạng hình ảnh trong một slide:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Kết quả:

![Các dấu đầu dòng dạng hình ảnh](picture_bullets.png)

## **Tạo danh sách đa cấp**

Sử dụng `ParagraphFormat.setDepth` để đặt các mục danh sách ở các cấp độ khác nhau. Cấp độ 0 là cấp cao nhất, cấp độ 1 là cấp con bên dưới nó, và cứ tiếp tục như vậy.

Mã JavaScript dưới đây cho thấy cách tạo một danh sách có dấu đầu dòng đa cấp:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Danh sách đa cấp](multilevel_list.png)

## **Thay đổi danh sách hiện có**

Để thay đổi định dạng danh sách trong một bản trình chiếu hiện có, truy cập đoạn văn mục tiêu và cập nhật các cài đặt `ParagraphFormat.getBullet` của nó. Các thuộc tính được sử dụng để tạo danh sách cũng có thể được dùng để kiểm tra hoặc chỉnh sửa các danh sách được tải từ tệp PPT, PPTX hoặc ODP.

Mã JavaScript dưới đây thay đổi đoạn văn đầu tiên trong một text frame để sử dụng kiểu danh sách có đánh số:

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Có thể xuất danh sách có dấu đầu dòng và đánh số ra PDF hoặc hình ảnh không?**

Có. Aspose.Slides giữ nguyên định dạng danh sách khi định dạng đầu ra hỗ trợ bố cục văn bản và các tính năng dấu đầu dòng tương ứng.

**Có thể chỉnh sửa danh sách trong các bản trình chiếu hiện có không?**

Có. Tải bản trình chiếu, truy cập đoạn văn mục tiêu, kiểm tra hoặc cập nhật cài đặt `ParagraphFormat.getBullet` của nó, và lưu bản trình chiếu.

**Danh sách có thể chứa văn bản không phải Latin không?**

Có. Văn bản của mục danh sách có thể chứa ký tự Unicode, vì vậy bạn có thể tạo danh sách trong các bản trình chiếu đa ngôn ngữ. Đảm bảo các phông chữ được sử dụng trong bản trình chiếu hỗ trợ các ký tự bạn cần.