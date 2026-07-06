---
title: "Lấy Giới Hạn Đoạn Văn từ Bản Trình Chiếu trong JavaScript"
linktitle: "Giới Hạn Đoạn Văn"
type: docs
weight: 43
url: /vi/nodejs-java/paragraph-bounds/
keywords:
- "giới hạn đoạn văn"
- "tọa độ đoạn văn"
- "kích thước đoạn văn"
- "khung văn bản"
- "PowerPoint"
- "bản trình chiếu"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Tìm hiểu cách lấy giới hạn đoạn văn trong Aspose.Slides cho Node.js thông qua Java để tối ưu vị trí văn bản trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn trong Aspose.Slides. Nó cho thấy cách truy xuất hình chữ nhật của một đoạn văn từ một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) bằng cách sử dụng [Paragraph.getRect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/getrect/), cách lấy tọa độ đoạn văn bên trong khung văn bản của ô bảng, và nhấn mạnh các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc bao gói văn bản đối với giới hạn, chuyển đổi pixel, và các giá trị định dạng đoạn văn hiệu quả.

## **Lấy tọa độ hình chữ nhật của một đoạn văn**

Sử dụng [Paragraph.getRect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/getrect/) để lấy hình chữ nhật bao quanh của một đoạn văn.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Lấy kích thước của một đoạn văn bên trong khung văn bản ô bảng**

Để lấy kích thước và tọa độ của một [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) trong khung văn bản của ô bảng, sử dụng [Paragraph.getRect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/getrect/). Hình chữ nhật trả về dựa trên khung văn bản của ô bảng, vì vậy hãy cộng thêm vị trí bảng và độ dịch của ô khi bạn cần tọa độ cấp slide.

Ví dụ sau lấy giới hạn đoạn văn bên trong ô bảng và vẽ các hình chữ nhật trên slide để trực quan hoá những giới hạn đó:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tọa độ đoạn văn được đo bằng đơn vị nào?**

Chúng được đo bằng điểm (points), trong đó 1 inch bằng 72 điểm. Điều này áp dụng cho mọi tọa độ và kích thước trên slide.

**Việc bao gói văn bản có ảnh hưởng đến giới hạn của đoạn văn không?**

Có. Nếu [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/setwraptext/) được bật cho [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/), văn bản sẽ ngắt để phù hợp với chiều rộng khu vực, điều này làm thay đổi giới hạn thực tế của đoạn văn.

**Có thể ánh xạ tọa độ đoạn văn sang pixel trong ảnh xuất ra một cách đáng tin cậy không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixel = điểm x (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render hoặc xuất.

**Làm sao tôi có thể lấy các tham số định dạng đoạn văn "hiệu quả", tính đến kế thừa kiểu?**

Sử dụng [effective paragraph formatting data structure](/slides/vi/nodejs-java/shape-effective-properties/); nó trả về các giá trị tổng hợp cuối cùng cho các lề, khoảng cách, bao gói, RTL, và nhiều hơn nữa.