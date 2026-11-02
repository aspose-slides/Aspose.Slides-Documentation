---
title: Quản lý danh sách có dấu đầu dòng và đánh số trong bài thuyết trình bằng JavaScript
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
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng danh sách có dấu đầu dòng, hình ảnh, đa cấp và đánh số trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides for Node.js via Java."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java cho phép bạn tạo và định dạng danh sách có dấu đầu dòng và danh sách đánh số trong các bài thuyết trình PowerPoint và OpenDocument. Một mục danh sách là một đoạn văn mà cài đặt dấu đầu dòng được kiểm soát thông qua định dạng đoạn văn của nó.

Sử dụng lớp [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) để truy cập các cài đặt danh sách ở mức đoạn. Điểm vào chính là `Paragraph.getParagraphFormat().getBullet()`, trả về một đối tượng [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) . Với đối tượng này, bạn có thể đặt loại dấu đầu dòng, ký hiệu, hình ảnh, màu, kích thước, kiểu đánh số và số bắt đầu.

Bài viết này mô tả cách:

- tạo danh sách có dấu đầu dòng với ký hiệu tùy chỉnh
- tạo dấu đầu dòng hình ảnh
- tạo danh sách đa cấp bằng cách đặt độ sâu đoạn
- tạo danh sách đánh số
- kiểm tra và thay đổi định dạng danh sách trong một bài thuyết trình hiện có
- đọc các ký hiệu và số thực tế của danh sách cùng với nội dung đoạn văn

## **Tạo danh sách có dấu đầu dòng**

Để tạo danh sách có dấu đầu dòng, thêm các đối tượng [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) vào một [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) và đặt `BulletFormat.setType` thành [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/). Sau đó bạn có thể đặt `BulletFormat.setChar`, `BulletFormat.getColor` và `BulletFormat.setHeight` để kiểm soát giao diện của dấu đầu dòng.

Mã JavaScript sau đây minh họa cách tạo danh sách có dấu đầu dòng trong một slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Tạo danh sách đánh số**

Sử dụng danh sách đánh số khi thứ tự các mục quan trọng. Đặt `BulletFormat.setType` thành [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/). Bạn cũng có thể chọn định dạng đánh số bằng `BulletFormat.setNumberedBulletStyle` hoặc đặt `BulletFormat.setNumberedBulletStartWith` khi danh sách cần bắt đầu từ một giá trị khác 1.

Mã JavaScript sau đây cho thấy cách tạo danh sách đánh số trong một slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

![Các dấu đầu dòng đánh số](numbered_bullets.png)

## **Tạo dấu đầu dòng hình ảnh**

Aspose.Slides cho phép bạn thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh. Dấu đầu dòng hình ảnh hoạt động tốt nhất với các hình ảnh đơn giản vẫn đọc được ở kích thước nhỏ, chẳng hạn như biểu tượng hoặc tệp PNG trong suốt nhỏ.

{{% alert color="info" title="Note" %}}
Lý tưởng nhất, nếu bạn dự định thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh, nên chọn đồ họa đơn giản với nền trong suốt. Những hình ảnh như vậy hoạt động tốt làm ký hiệu dấu đầu dòng tùy chỉnh.

Hãy lưu ý rằng hình ảnh sẽ được thu nhỏ xuống một kích thước rất nhỏ. Vì lý do này, chúng tôi khuyến nghị mạnh mẽ chọn một hình ảnh vẫn rõ ràng và hiệu quả về mặt hình ảnh khi được sử dụng làm dấu đầu dòng trong danh sách.
{{% /alert %}}

Để tạo dấu đầu dòng hình ảnh, thêm một hình ảnh vào [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) bằng `Presentation.getImages().addImage` và gán đối tượng [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) trả về cho `BulletFormat.getPicture().setImage`. Đặt `BulletFormat.setType` thành [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) trước khi gán hình ảnh.

Giả sử chúng ta có một "image.png":

![Một hình ảnh cho các dấu đầu dòng](picture_for_bullets.png)

Mã JavaScript sau đây cho thấy cách tạo dấu đầu dòng hình ảnh trong một slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

![Các dấu đầu dòng hình ảnh](picture_bullets.png)

## **Tạo danh sách đa cấp**

Sử dụng `ParagraphFormat.setDepth` để đặt các mục danh sách ở các cấp độ khác nhau. Cấp độ 0 là cấp cao nhất, cấp độ 1 là cấp con của nó, và cứ tiếp tục như vậy.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Để thay đổi định dạng danh sách trong một bài thuyết trình hiện có, truy cập đoạn mục tiêu và cập nhật cài đặt `ParagraphFormat.getBullet` của nó. Các thuộc tính đã dùng để tạo danh sách cũng có thể được dùng để kiểm tra hoặc sửa đổi các danh sách được tải từ tệp PPT, PPTX hoặc ODP.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Đọc giá trị dấu đầu dòng thực tế**

Khi trích xuất nội dung bài thuyết trình, giữ các ký hiệu danh sách cạnh đoạn văn. Gọi [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective) và truy cập [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) để lấy định dạng dấu đầu dòng thực tế. Kiểm tra [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) trước khi đọc [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

Đối với danh sách đánh số, phân biệt ba giá trị sau:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) xác định định dạng, chẳng hạn số Ả Rập theo sau dấu chấm hoặc chữ cái thường theo sau dấu chấm.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) chỉ định số bắt đầu cho một nhóm các đoạn đánh số.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) trả về ký hiệu đã định dạng cho một đoạn cụ thể. Ví dụ, mục thứ hai trong danh sách bắt đầu ở 5 sẽ trả về `6.`.

Giữ [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDepth) với mỗi đoạn để duy trì mức lồng nhau của nó. Ký hiệu thực tế không mã hoá toàn bộ cây phân cấp: một mục lồng nhau có thể trả về `c.` thay vì một nhãn kết hợp như `6.c.`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Tạo một dấu đầu dòng hình ảnh mà không cần tệp hình ảnh bên ngoài.
    const svg = new aspose.slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    const bulletImage = presentation.getImages().addImage(svg);

    function addParagraph(text, depth, type, start, style) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.setText(text);

        const format = paragraph.getParagraphFormat();
        format.setDepth(java.newShort(depth));
        format.setMarginLeft(30 + depth * 40);
        format.setIndent(-28);
        format.setSpaceAfter(8);
        format.getDefaultPortionFormat().setFontHeight(22);
        format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(black);
        format.getBullet().setType(java.newByte(type));
        format.getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
        format.getBullet().getColor().setColor(black);
        if (type === aspose.slides.BulletType.Numbered) {
            format.getBullet().setNumberedBulletStyle(java.newByte(style));
            format.getBullet().setNumberedBulletStartWith(java.newShort(start));
        } else if (type === aspose.slides.BulletType.Symbol) {
            format.getBullet().setChar(java.newChar(0x2022));
        } else if (type === aspose.slides.BulletType.Picture) {
            format.getBullet().getPicture().setImage(bulletImage);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    addParagraph("First item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Second item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Next nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Deep item", 2, aspose.slides.BulletType.Numbered, 4, aspose.slides.NumberedBulletStyle.BulletRomanLCPeriod);
    addParagraph("Back to top level", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Symbol marker", 0, aspose.slides.BulletType.Symbol, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("No bullet", 0, aspose.slides.BulletType.None, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Picture marker", 0, aspose.slides.BulletType.Picture, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const loadedPresentation = new aspose.slides.Presentation("actual_bullet_values.pptx");
try {
    const loadedShape = loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Text | Depth | Type | Actual value");
    const paragraphs = loadedShape.getTextFrame().getParagraphs();
    for (let i = 0; i < paragraphs.getCount(); i++) {
        const paragraph = paragraphs.get_Item(i);
        const bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        let marker;
        switch (bullet.getType()) {
            case aspose.slides.BulletType.Numbered:
            case aspose.slides.BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case aspose.slides.BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case aspose.slides.BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        const typeName = Object.keys(aspose.slides.BulletType).find(name => aspose.slides.BulletType[name] === bullet.getType());
        console.log(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

Các danh sách nguồn được hiển thị bên dưới.

![Danh sách bắt đầu tại 5, mục lồng chữ cái và số La Mã, ký hiệu ký tự, đoạn không có dấu đầu dòng, và dấu đầu dòng hình ảnh xanh](actual_bullet_values.png)

Báo cáo khớp với các ký hiệu hiển thị trong PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Đối với [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) trả về `null`, không phải chuỗi rỗng. Xử lý các loại này riêng biệt: loại đầu tiên không có ký hiệu, trong khi loại thứ hai yêu cầu trích xuất hình ảnh dấu đầu dòng riêng biệt. Dấu đầu dòng hình ảnh không thể tái tạo chỉ bằng cách trích xuất ký hiệu văn bản.

## **Câu hỏi thường gặp**

**Có thể xuất danh sách có dấu đầu dòng và danh sách đánh số sang PDF hoặc hình ảnh không?**

Có. Aspose.Slides giữ nguyên định dạng danh sách khi định dạng đích hỗ trợ bố cục văn bản và tính năng dấu đầu dòng tương ứng.

**Tôi có thể chỉnh sửa danh sách trong các bài thuyết trình hiện có không?**

Có. Tải bài thuyết trình, truy cập đoạn mục tiêu, kiểm tra hoặc cập nhật cài đặt `ParagraphFormat.getBullet` của nó, và lưu lại bài thuyết trình.

**Danh sách có thể chứa văn bản không phải Latin không?**

Có. Văn bản mục danh sách có thể chứa ký tự Unicode, vì vậy bạn có thể tạo danh sách trong các bài thuyết trình đa ngôn ngữ. Đảm bảo các phông chữ được sử dụng trong bài thuyết trình hỗ trợ các ký tự bạn cần.