---
title: Quản lý các đoạn văn bản PowerPoint trong JavaScript
linktitle: Quản lý Đoạn văn
type: docs
weight: 40
url: /vi/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- thêm văn bản
- thêm đoạn văn
- quản lý văn bản
- quản lý đoạn văn
- quản lý dấu đầu dòng
- thụt lề đoạn văn
- thụt lề treo
- dấu đầu dòng đoạn văn
- danh sách có đánh số
- danh sách có dấu đầu dòng
- thuộc tính đoạn văn
- nhập HTML
- văn bản sang HTML
- đoạn văn sang HTML
- đoạn văn sang hình ảnh
- văn bản sang hình ảnh
- xuất đoạn văn
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng các đoạn văn, phần, dấu đầu dòng, danh sách có đánh số, thụt lề, nội dung HTML và hình ảnh đoạn văn với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides cho Node.js thông qua Java biểu diễn văn bản dưới dạng một cấu trúc phân cấp của khung văn bản, đoạn văn và phần văn bản:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) đại diện cho vùng chứa văn bản trong một hình dạng và cung cấp quyền truy cập vào bộ sưu tập đoạn văn của nó.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) đại diện cho một đoạn văn trong khung văn bản và cung cấp quyền truy cập vào các phần và định dạng cấp độ đoạn.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) đại diện cho một đoạn văn bản trong một đoạn. Mỗi phần có thể có văn bản và định dạng ký tự riêng.

Do đó một đoạn văn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn văn**

Tạo các đoạn văn trong khung văn bản của một hình dạng và sử dụng các phần để định dạng các chạy văn bản riêng lẻ. Phần này cho thấy cách kết hợp nhiều phần trong mỗi đoạn và áp dụng các màu, kích thước phông và kiểu khác nhau.

### **Tạo Đoạn Văn với Nhiều Phần**

Ví dụ JavaScript sau tạo ba đoạn, mỗi đoạn chứa ba chạy văn bản trong bộ sưu tập trả về bởi [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/). Nó tái sử dụng đoạn mặc định và phần rỗng của nó, sau đó thêm các đoạn và phần còn lại. Định dạng được áp dụng qua [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/): phần đầu tiên trong mỗi đoạn có màu đỏ, in đậm và 15 điểm; phần thứ hai có màu xanh, in nghiêng và 18 điểm. Phần thứ ba giữ nguyên định dạng mặc định:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tạo Danh sách Đánh dấu và Đánh số**

Sắp xếp văn bản đoạn thành các danh sách với ký hiệu, số hoặc hình ảnh tùy chỉnh. Các ví dụ trong phần này bao gồm định dạng dấu đầu dòng, danh sách đa cấp và số bắt đầu tùy chỉnh.

### **Tạo Danh sách Đánh dấu hoặc Đánh số**

Dấu đầu dòng và đánh số giúp người đọc nhanh chóng quét các mục liên quan. Trong Aspose.Slides, cài đặt danh sách được định nghĩa qua [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/).

Ví dụ JavaScript này thêm một dấu đầu dòng ký hiệu và một mục đánh số vào cùng một khung văn bản. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) chọn loại dấu đầu dòng, trong khi [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) cung cấp ký hiệu và [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) chọn kiểu đánh số. Cả hai mục đều sử dụng dấu đầu dòng màu đen với chiều cao 100 % và thụt lề đoạn 25 điểm:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sử dụng Đánh dấu Hình ảnh**

Đánh dấu hình ảnh cho phép bạn sử dụng một hình ảnh tùy chỉnh thay vì ký hiệu hoặc số.

Ví dụ JavaScript này tải `image.png` từ thư mục làm việc của ứng dụng, thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình bày dưới dạng một [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) và sử dụng nó làm dấu đầu dòng cho đoạn. Nó gọi [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) để sử dụng dấu đầu dòng hình ảnh và gán hình ảnh qua [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/). [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) được đặt ở 100 % để kích thước dấu đầu dòng tương đối với văn bản đoạn:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Tạo Danh sách Đa cấp**

Đặt [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) để đặt các đoạn ở các mức độ khác nhau của một danh sách. Cấp cao nhất có độ sâu `0`.

Ví dụ JavaScript này gán các giá trị [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) từ 0 đến 3 cho bốn đoạn, tạo một cấu trúc phân cấp trong một khung văn bản. Mỗi đoạn sử dụng dấu đầu dòng ký hiệu, với [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) luân phiên giữa dấu tròn và dấu gạch ngang để phân biệt các mức lân cận:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bắt đầu các Mục Đánh số với Giá trị Tùy chỉnh**

Sử dụng [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) để đặt số ban đầu hiển thị cho một đoạn được đánh số.

Ví dụ JavaScript này đặt [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) để sử dụng đánh số cho ba đoạn và gán các giá trị [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) là 2, 3 và 7. Giá trị bắt đầu được cấu hình riêng cho mỗi đoạn, cho phép các số hiển thị bỏ qua một số giá trị:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm soát Bố cục Đoạn văn và Thuộc tính Kết thúc**

Điều chỉnh lề và thụt lề của đoạn để kiểm soát vị trí của dòng đầu và các dòng gập. Bạn cũng có thể định dạng dấu kết thúc đoạn riêng biệt so với các phần văn bản hiển thị.

### **Đặt Thụt Lề Dòng Đầu tiên**

Sử dụng phương pháp [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) để kiểm soát thụt lề dòng đầu tiên của một đoạn. Cài đặt này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn. Giá trị dương dịch dòng đầu tiên sang phải, trong khi các dòng còn lại vẫn căn theo thân đoạn.

Sử dụng [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) khi bạn chỉ cần di chuyển dòng đầu tiên.

Ví dụ sau cho ba đoạn cùng [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) là 20 điểm và các giá trị [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) là 0, 20 và 40 điểm. Các dòng đầu tiên bắt đầu ở các vị trí offset ngày càng lớn, trong khi các dòng gập giữ nguyên lề trái:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Thụt lề dòng đầu tiên của các đoạn văn](first_line_indent.png)

### **Đặt Thụt Lề Treo**

Thụt lề treo là bố cục đoạn mà trong đó dòng đầu tiên bắt đầu bên trái các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng phương pháp [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/). Đặt thụt lề thành giá trị âm để di chuyển dòng đầu tiên sang trái so với thân đoạn.

Trong thực tế, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) xác định vị trí bên trái của thân đoạn, và [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) xác định vị trí của dòng đầu tiên so với lề đó. Để tạo thụt lề treo, đặt lề trái dương và thụt lề âm.

Định dạng này hữu ích cho thư mục, tham khảo, mục từ điển và các đoạn khác mà các dòng gập phải căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

Ví dụ JavaScript sau ghép các giá trị [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) là 40 và 60 điểm với các giá trị [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) là -20 và -30 điểm. Trong mỗi đoạn, dòng đầu tiên bắt đầu bên trái các dòng gập; đoạn thứ hai có thụt lề treo sâu hơn:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Thụt lề treo của các đoạn văn](hanging_indent.png)

### **Đặt Thuộc tính Chạy Đoạn Văn Kết thúc**

Phương pháp [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) kiểm soát định dạng của dấu kết thúc đoạn. Ví dụ sau tạo một [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) với [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) đặt thành 48 điểm và [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) đặt thành Times New Roman. Nó gán định dạng này cho dấu kết thúc của đoạn thứ hai, để các phần văn bản hiển thị không bị thay đổi:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đếm Dòng Được Hiển thị**

Đối với các quy tắc đoạn ảnh hưởng đến việc tự động ngắt dòng và dấu câu ở cuối dòng, xem [Kiểm soát Ngắt dòng](/slides/vi/nodejs-java/text-formatting/#control-line-breaking) và [Kiểm soát Dấu câu Treo](/slides/vi/nodejs-java/text-formatting/#control-hanging-punctuation).

Sử dụng [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) để đếm số dòng mà một đoạn chiếm sau khi bố cục văn bản, bao gồm cả ngắt dòng tự động. Điều này hữu ích khi kiểm tra độ dài văn bản và bố cục trong các mẫu trình chiếu.

Một đoạn là một mục trong [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/), và nó có thể chiếm nhiều dòng được hiển thị. Một ngắt dòng rõ ràng bên trong đoạn buộc một dòng mới mà không tạo đoạn mới. Ngắt dòng tự động tạo các dòng dựa trên chiều rộng có sẵn mà không chèn ký tự ngắt dòng vào văn bản. Vì vậy, đếm số đoạn hoặc ký tự ngắt dòng không cho ra số dòng đã hiển thị.

Ví dụ sau tạo một hình dạng văn bản, đếm các dòng của nó, thu hẹp hình dạng, rồi thay thế văn bản bằng một chuỗi ngắn hơn. Ví dụ bật tính năng gói lại với [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) và tắt tự động vừa với [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/) để chiều rộng hình dạng kiểm soát việc gói lại mà không tự động thu nhỏ văn bản hoặc thay đổi kích thước hình dạng. Mỗi phép đo sử dụng [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount). Kích thước hình dạng tính bằng điểm. Cuối cùng, ví dụ thêm một đoạn khác và cộng tổng số dòng qua toàn bộ khung văn bản.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Với văn bản và các kích thước này, thu hẹp hình dạng làm tăng số dòng, trong khi thay thế bằng chuỗi ngắn làm giảm số dòng. Các số đếm chính xác có thể thay đổi tùy vào việc có sẵn phông chữ và việc thay thế, kích thước phông, lề, thụt lề, gói lại và cài đặt tự động vừa. Hãy sử dụng các phông và cài đặt bố cục dự định cho môi trường mục tiêu khi kiểm tra mẫu.

Chỉ số dòng không quyết định liệu văn bản có tràn khỏi khung hay không. Chiều cao khả dụng, độ cao dòng, khoảng cách đoạn và dòng, và hành vi tự động vừa cũng quan trọng; ngay cả một dòng duy nhất cũng có thể vượt quá chiều rộng có sẵn khi tắt gói lại.

## **Nhập và Xuất Nội dung Đoạn văn**

Sử dụng HTML để đưa văn bản vào một bản trình chiếu hoặc xuất các đoạn hiện có để sử dụng bên ngoài. Phần này cũng cho thấy cách kết xuất các đoạn riêng lẻ thành hình ảnh, bao gồm các đoạn trong ô bảng.

### **Nhập Văn bản HTML vào Đoạn văn**

Sử dụng [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) để chuyển đổi markup HTML thành các đoạn và phần trong một khung văn bản.

Ví dụ JavaScript này đọc HTML từ `file.html` trong thư mục làm việc của ứng dụng và truyền markup cho [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/). Nó xóa đoạn mặc định của khung văn bản để khung chỉ chứa nội dung đã nhập. Hình chữ nhật để lại lề 10 điểm ở mỗi phía của slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = fs.readFileSync("file.html", "utf8");
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Xuất Văn bản Đoạn văn sang HTML**

Sử dụng [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) để xuất một phạm vi chọn các đoạn dưới dạng HTML. Khi tái sử dụng văn bản bản trình chiếu trên một trang web, bạn có thể muốn giữ nguyên cách nhấn mạnh nội địa mà không mang theo phông, kích thước hoặc kiểu hộp văn bản của bản trình chiếu. Đặt [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) để kiểm soát mức độ mà bộ xuất theo dõi kế thừa định dạng.

Tải về [the sample presentation](text-inheritance.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên chứa một hình dạng văn bản với văn bản “Inherited text; explicit red 18pt”. Đầu vào cố ý sử dụng nhiều cấp định dạng:

- Kiểu văn bản mặc định của bản trình bày cung cấp phông Calibri và kích thước 28 pt.
- Kiểu văn bản cấp một của khung văn bản cung cấp văn bản màu xanh và in nghiêng.
- Đoạn văn rõ ràng đặt văn bản in đậm.
- Phần thứ hai, “explicit red 18pt”, rõ ràng đặt văn bản màu đỏ và kích thước 18 pt.

Ví dụ hoàn chỉnh sau xuất cùng các đoạn ba lần. Nó truyền [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) cho phương pháp xuất và ghi mỗi kết quả thành một tệp HTML UTF‑8 riêng:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("text-inheritance.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();

            const modes = [aspose.slides.TextInheritanceLimit.All, aspose.slides.TextInheritanceLimit.TextBox, aspose.slides.TextInheritanceLimit.ParagraphOnly];
            const fileNames = ["All.html", "TextBox.html", "ParagraphOnly.html"];

            for (let i = 0; i < modes.length; i++) {
                const options = new aspose.slides.TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                fs.writeFileSync(fileNames[i], html, "utf8");
            }
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

HTML được tạo chứa CSS sau cho phần đầu tiên, “Inherited text; ”. Bảng liệt kê các khai báo liên quan; các thuộc tính được tạo khác đã bị loại bỏ để dễ đọc.

| Đầu ra | CSS liên quan cho phần đầu tiên | Hiển thị |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Văn bản màu xanh, in đậm, in nghiêng ở 28 pt trong Calibri, nếu phông đó khả dụng. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Văn bản màu xanh, in đậm, in nghiêng; trang hoặc trình duyệt cung cấp phông và kích thước. |
| `ParagraphOnly.html` | `font-weight:bold` | Văn bản in đậm; trang hoặc trình duyệt cung cấp phông, kích thước, màu và kiểu nghiêng. |

Phần thứ hai vẫn giữ `color:#ff0000`, `font-size:18pt` và `font-weight:bold` trong cả ba đầu ra. Nó cũng giữ in nghiêng với `All` và `TextBox`, nhưng không với `ParagraphOnly`. Vì vậy, việc hạn chế kế thừa không loại bỏ định dạng đã được gán rõ ràng cho một đoạn hoặc phần.

Mở các tệp trong cùng một trình duyệt để so sánh chúng. Trong hai chế độ bị hạn chế, các thuộc tính CSS bị bỏ qua sẽ được giải quyết bởi kiểu của trang đích hoặc mặc định của trình duyệt, vì vậy giao diện cuối cùng phụ thuộc vào nơi HTML được sử dụng.

### **Kết xuất Đoạn văn thành Hình ảnh**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) trực tiếp kết xuất một đoạn riêng lẻ và trả về một [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/). Lưu kết quả vào tệp hoặc luồng với [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Bạn không cần phải kết xuất toàn bộ hình dạng chứa hoặc cắt thủ công một bitmap.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) có thể trả về `null` nếu không tìm thấy đoạn trong bộ sưu tập cha, không có giới hạn hiển thị hợp lệ, hoặc không thể được kết xuất. Kiểm tra kết quả trước khi lưu và giải phóng hình ảnh đã trả về sau khi sử dụng.

#### **Kết xuất Đoạn văn ở Tỷ lệ Mặc định**

Ví dụ tạo một bản trình chiếu với một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn văn](paragraph_to_image_input.png)

Ví dụ sau chọn đoạn thứ hai ở chỉ mục 1 và gọi [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) mà không truyền tham số tỷ lệ. Nó kiểm tra hình dạng có chứa đoạn yêu cầu và việc kết xuất trả về một hình ảnh trước khi gọi [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) để lưu ở định dạng PNG. Khối `finally` giải phóng hình ảnh sau khi sử dụng.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình ảnh đoạn văn](paragraph_to_image_output.png)

#### **Kết xuất Đoạn văn trong Ô Bảng với Tỷ lệ**

Sử dụng phiên bản overload của [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) chấp nhận các tham số `scaleX` và `scaleY` để đặt hệ số tỷ lệ ngang và dọc. Ví dụ sau tạo một bảng, kết xuất đoạn trong ô đầu tiên với chiều rộng và chiều cao gấp đôi mặc định, và lưu kết quả dưới dạng ảnh PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Hệ số tỷ lệ `1` giữ trục đó ở kích thước pixel mặc định. Ví dụ, `2` cho cả hai hệ số tạo ra một hình ảnh có chiều rộng và chiều cao khoảng gấp đôi kích thước mặc định, tương đương với bốn lần số pixel. Các hệ số lớn hơn thường tạo ra văn bản sắc nét hơn cho việc phóng to hoặc xuất độ phân giải cao, nhưng chúng cũng làm tăng sử dụng bộ nhớ và kích thước tệp. Các hệ số dưới `1` tạo ra hình ảnh nhỏ hơn với ít chi tiết hơn. Sử dụng các hệ số bằng nhau để giữ tỷ lệ khung hình của đoạn; các hệ số ngang và dọc khác nhau sẽ kéo giãn kết quả một cách độc lập.

Kết xuất toàn bộ hình dạng bằng [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) vẫn hữu ích khi đầu ra cần bao gồm nền, viền hoặc ngữ cảnh hình ảnh khác của hình. Đối với hình ảnh chỉ chứa đoạn, hãy dùng [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage).

## **Câu hỏi thường gặp**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong khung văn bản không?**

Có. Đặt [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) để tắt gói lại sao cho các dòng không bị ngắt ở các cạnh của khung văn bản.

**Làm thế nào để tôi có được giới hạn chính xác trên slide của một đoạn văn cụ thể?**

Sử dụng [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) để lấy hình chữ nhật bao quanh đoạn. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) cung cấp giới hạn của một phần riêng lẻ.

**Căn chỉnh đoạn văn (trái, phải, trung tâm hoặc canh đều) được kiểm soát ở đâu?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) là cài đặt cấp đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ.

Để căn chỉnh dọc các phần có kích thước phông khác nhau trong mỗi dòng, xem [Align Fonts Within a Line](/slides/vi/nodejs-java/text-formatting/#align-fonts-within-a-line).

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn văn không?**

Có. Đặt [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) cho các phần riêng lẻ, vì vậy một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.