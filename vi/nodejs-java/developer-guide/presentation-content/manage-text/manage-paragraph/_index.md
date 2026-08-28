---
title: Quản lý các đoạn văn bản PowerPoint trong JavaScript
linktitle: Quản lý Đoạn
type: docs
weight: 40
url: /vi/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- thêm văn bản
- thêm đoạn
- quản lý văn bản
- quản lý đoạn
- quản lý dấu đầu dòng
- thụt lề đoạn
- thụt lề treo
- dấu đầu dòng đoạn
- danh sách đánh số
- danh sách dấu đầu dòng
- thuộc tính đoạn
- nhập HTML
- văn bản sang HTML
- đoạn sang HTML
- đoạn sang hình ảnh
- văn bản sang hình ảnh
- xuất đoạn
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng các đoạn, phần, dấu đầu dòng, danh sách đánh số, thụt lề, nội dung HTML và hình ảnh đoạn với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides cho Node.js qua Java biểu diễn văn bản dưới dạng một cây phân cấp gồm các khung văn bản, đoạn và phần:

* [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) đại diện cho vùng chứa văn bản trong một hình dạng và cung cấp quyền truy cập vào bộ sưu tập đoạn của nó.
* [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) đại diện cho một đoạn trong một khung văn bản và cung cấp quyền truy cập vào các phần và định dạng ở mức độ đoạn.
* [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) đại diện cho một đoạn văn bản trong một đoạn. Mỗi phần có thể có định dạng ký tự riêng.

Do đó một đoạn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và các định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn**

### **Tạo Đoạn với Nhiều Phần**

Các bước sau tạo một khung văn bản với ba đoạn, mỗi đoạn chứa ba phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide tương ứng qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của hình.
5. Sử dụng đoạn mặc định và thêm hai đối tượng [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) nữa vào khung văn bản.
6. Thêm đủ đối tượng [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) cho mỗi đoạn để chứa ba phần. Đoạn mặc định đã chứa một phần trống.
7. Đặt văn bản cho mỗi phần.
8. Áp dụng định dạng ký tự qua [Portion.getPortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/getportionformat/).
9. Lưu bản trình chiếu đã sửa đổi.

Ví dụ JavaScript thực hiện các bước trên:

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

## **Tạo Danh sách Dấu đầu dòng và Đánh số**

### **Tạo Danh sách Dấu đầu dòng hoặc Đánh số**

Dấu đầu dòng và đánh số giúp người đọc nhanh chóng quét các mục liên quan. Trong Aspose.Slides, cài đặt danh sách được định nghĩa qua [BulletFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/).

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide tương ứng qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide đã chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của hình.
5. Xóa đoạn mặc định khỏi khung văn bản.
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) cho dấu đầu dòng ký hiệu.
7. Đặt [BulletFormat.setType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/settype/) thành [BulletType.Symbol](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bullettype/) và chỉ định ký tự dấu đầu dòng.
8. Đặt văn bản đoạn, thụt lề, màu dấu đầu dòng và chiều cao dấu đầu dòng.
9. Thêm đoạn vào khung văn bản.
10. Tạo đoạn thứ hai và đặt [BulletFormat.setType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/settype/) thành [BulletType.Numbered](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bullettype/).
11. Cấu hình kiểu dấu đầu dòng đánh số và thêm đoạn vào khung văn bản.
12. Lưu bản trình chiếu.

Ví dụ JavaScript tạo một dấu đầu dòng ký hiệu và một dấu đầu dòng đánh số:

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

### **Sử dụng Dấu đầu dòng Hình ảnh**

Dấu đầu dòng hình ảnh cho phép bạn sử dụng một ảnh tùy chỉnh thay vì ký hiệu hoặc số.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide tương ứng qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) và truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của nó.
4. Xóa đoạn mặc định khỏi khung văn bản.
5. Tải ảnh dấu đầu dòng và thêm vào bộ sưu tập ảnh của bản trình chiếu dưới dạng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/).
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) và đặt văn bản cho nó.
7. Đặt [BulletFormat.setType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/settype/) thành [BulletType.Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bullettype/).
8. Gán ảnh qua [BulletFormat.getPicture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/getpicture/) và đặt chiều cao dấu đầu dòng.
9. Thêm đoạn vào khung văn bản.
10. Lưu bản trình chiếu đã sửa đổi.

Ví dụ JavaScript tạo một dấu đầu dòng hình ảnh:

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

Đặt [ParagraphFormat.setDepth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setdepth/) để đặt các đoạn ở các mức độ khác nhau của danh sách. Mức cao nhất có độ sâu `0`.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) và xóa đoạn mặc định khỏi khung văn bản của nó.
3. Tạo bốn đoạn và cấu hình các ký hiệu dấu đầu dòng cho chúng.
4. Đặt giá trị [ParagraphFormat.setDepth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setdepth/) thành `0`, `1`, `2` và `3`.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

Ví dụ JavaScript tạo một danh sách dấu đầu dòng bốn cấp:

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

### **Bắt đầu Các Mục Đánh số với Giá trị Tùy chỉnh**

Sử dụng [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) để đặt số đầu tiên hiển thị cho một đoạn đánh số.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào một slide.
2. Xóa đoạn mặc định khỏi khung văn bản của hình.
3. Tạo ba đoạn đánh số.
4. Đặt [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) thành `2`, `3` và `7` cho các đoạn tương ứng.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

Ví dụ JavaScript gán một số bắt đầu tùy chỉnh cho mỗi đoạn:

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

## **Kiểm soát Bố cục Đoạn và Thuộc tính Kết thúc**

### **Đặt Thụt Lề Dòng Đầu**

Sử dụng [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) để kiểm soát thụt lề dòng đầu của một đoạn. Phương thức này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn. Giá trị dương dịch dòng đầu tiên sang phải, trong khi các dòng còn lại vẫn căn theo thân đoạn.

Sử dụng [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) khi bạn cần di chuyển toàn bộ đoạn. Dùng [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) khi chỉ muốn di chuyển dòng đầu.

Ví dụ dưới tạo một số đoạn và áp dụng các giá trị khác nhau của [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) để minh họa ảnh hưởng của thụt lề dòng đầu đối với bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của hình và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị khác nhau của [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình chiếu đã sửa đổi.

Mã này cho bạn thấy cách đặt thụt lề đoạn:

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

![Khoảng cách đầu dòng của các đoạn](first_line_indent.png)

### **Đặt Thụt Lề Treo**

Thụt lề treo là bố cục đoạn trong đó dòng đầu bắt đầu ở phía trái so với các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/). Cung cấp một giá trị âm để di chuyển dòng đầu sang trái so với thân đoạn.

Trong thực tế, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) xác định vị trí bên trái của thân đoạn, và [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) xác định vị trí của dòng đầu so với lề đó. Để tạo thụt lề treo, đưa một giá trị dương vào `setMarginLeft` và một giá trị âm vào `setIndent`.

Định dạng này hữu ích cho thư mục, tham khảo, mục từ điển và các đoạn khác nơi các dòng gói phải căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của hình và xóa đoạn mặc định.
5. Tạo các đoạn và đưa một giá trị dương vào [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) cho mỗi đoạn.
6. Đưa một giá trị âm vào [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình chiếu đã sửa đổi.

Mã này cho bạn thấy cách đặt thụt lề treo cho một đoạn:

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

![Thụt lề treo của các đoạn](hanging_indent.png)

### **Đặt Thuộc tính Kết thúc Đoạn**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) điều khiển định dạng của ký tự kết thúc đoạn. Ví dụ dưới gán kích thước phông chữ và phông Latin cho ký tự kết thúc của đoạn thứ hai:

1. Tạo hoặc tải một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) và xóa đoạn mặc định của nó.
3. Tạo hai đoạn và thêm các phần văn bản vào chúng.
4. Tạo một [PortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/) cho ký tự kết thúc của đoạn thứ hai.
5. Đặt [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) và [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Gán định dạng bằng [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) và lưu bản trình chiếu.

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

## **Nhập và Xuất Nội dung Đoạn**

### **Nhập Văn bản HTML vào Đoạn**

Sử dụng [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) để chuyển đổi mã HTML thành các đoạn và phần trong một khung văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập một slide và thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).
3. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của hình và xóa đoạn mặc định.
4. Định nghĩa hoặc đọc chuỗi HTML nguồn.
5. Đưa chuỗi HTML vào [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Lưu bản trình chiếu đã sửa đổi.

Ví dụ JavaScript nhập HTML vào một khung văn bản:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Xuất Văn bản Đoạn ra HTML**

Sử dụng [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) để xuất một phạm vi đoạn đã chọn dưới dạng HTML.

1. Tạo hoặc tải một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide và tìm [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) chứa văn bản.
3. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của hình.
4. Gọi [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) với chỉ mục đoạn bắt đầu và số đoạn cần xuất.
5. Ghi chuỗi HTML trả về vào tệp.

Ví dụ JavaScript tự chứa này tạo một hình dạng văn bản và xuất tất cả các đoạn của nó:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

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
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
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

### **Render (Kết xuất) Đoạn dưới dạng Hình ảnh**

[Paragraph.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/#getImage) render (kết xuất) một đoạn riêng lẻ và trả về một [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/). Lưu kết quả vào tệp bằng [IImage.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/#save). Bạn không cần render toàn bộ hình dạng chứa hoặc cắt ảnh bitmap thủ công.

[Paragraph.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/#getImage) có thể trả về `null` nếu không tìm thấy đoạn trong bộ sưu tập cha, không có giới hạn render hợp lệ, hoặc không thể render. Kiểm tra kết quả trước khi lưu và giải phóng hình ảnh đã trả về sau khi sử dụng.

#### **Render Đoạn ở Tỷ lệ Mặc định**

Hộp văn bản dưới đây chứa ba đoạn:

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

Ví dụ dưới render đoạn thứ hai trong một hình dạng văn bản thông thường ở tỷ lệ mặc định và lưu hình ảnh trả về dưới dạng PNG. Khối `finally` đảm bảo hình ảnh được giải phóng đúng cách.

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

![Hình ảnh đoạn](paragraph_to_image_output.png)

#### **Render Đoạn trong Ô Bảng với Phóng to**

Sử dụng phương thức [Paragraph.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/#getImage) có tham số `scaleX` và `scaleY` để đặt hệ số phóng to theo chiều ngang và dọc. Ví dụ dưới tạo một bảng, render đoạn trong ô đầu tiên với độ rộng và chiều cao gấp đôi so với mặc định, và lưu kết quả dưới dạng PNG.

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

Hệ số `1` giữ trục đó ở kích thước pixel mặc định. Ví dụ, `2` cho cả hai trục tạo ra một hình ảnh có chiều rộng và chiều cao khoảng gấp đôi kích thước mặc định, tương đương bốn lần số pixel. Các hệ số lớn hơn thường tạo ra văn bản sắc nét hơn cho phóng to hoặc xuất độ phân giải cao, nhưng chúng cũng tăng mức sử dụng bộ nhớ và kích thước tệp. Hệ số dưới `1` tạo ra hình ảnh nhỏ hơn với ít chi tiết hơn. Sử dụng các hệ số bằng nhau để giữ tỉ lệ khung hình của đoạn; các hệ số ngang và dọc khác nhau sẽ kéo dài đầu ra một cách độc lập.

Render toàn bộ hình dạng bằng [Shape.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getImage) vẫn hữu ích khi đầu ra cần bao gồm nền, viền hoặc ngữ cảnh trực quan khác của hình dạng. Đối với hình ảnh chỉ chứa đoạn, hãy sử dụng [Paragraph.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/#getImage).

## **Câu hỏi thường gặp**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong khung văn bản không?**

Có. Đặt [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/setwraptext/) để tắt việc ngắt dòng, vì vậy các dòng không bị bẻ tại cạnh của khung văn bản.

**Làm sao tôi có thể lấy giới hạn chính xác trên slide của một đoạn cụ thể?**

Sử dụng [Paragraph.getRect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/getrect/) để lấy hình chữ nhật bao quanh đoạn. [Portion.getRect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#getRect) cung cấp giới hạn của một phần riêng lẻ.

**Vị trí căn chỉnh đoạn (trái, phải, giữa hoặc căn đều) được kiểm soát ở đâu?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setalignment/) là cài đặt mức độ đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng riêng lẻ của các phần.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn không?**

Có. Đặt [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) cho các phần riêng lẻ, để một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.