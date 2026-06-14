---
title: Lấy Giới Hạn Đoạn Văn Bản từ Bản Trình bày trong JavaScript
linktitle: Đoạn văn
type: docs
weight: 60
url: /vi/nodejs-java/paragraph/
keywords:
- giới hạn đoạn văn
- giới hạn phần văn bản
- tọa độ đoạn văn
- tọa độ phần
- kích thước đoạn văn
- kích thước phần văn bản
- khung văn bản
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn văn và phần văn bản trong JavaScript với Aspose.Slides cho Node.js để tối ưu vị trí văn bản trong các bản trình bày PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn và phần văn bản trong Aspose.Slides. Nó chỉ ra cách truy xuất hình chữ nhật của một đoạn trong `TextFrame` bằng cách sử dụng `getRect()`, cách lấy tọa độ của đoạn và phần bên trong khung văn bản của ô bảng, và nhấn mạnh các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc xuống dòng văn bản tới giới hạn, chuyển đổi sang pixel, và các giá trị định dạng đoạn văn “effective”.

## **Lấy tọa độ Đoạn và Phần trong TextFrame**
Sử dụng Aspose.Slides cho Node.js qua Java, các nhà phát triển hiện có thể lấy tọa độ hình chữ nhật cho Paragraph trong bộ sưu tập đoạn của TextFrame. Nó cũng cho phép bạn lấy [the coordinates of portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Portion#getCoordinates--) trong bộ sưu tập phần của một đoạn. Trong chủ đề này, chúng ta sẽ minh họa bằng một ví dụ cách lấy tọa độ hình chữ nhật cho đoạn cùng với vị trí của phần bên trong đoạn.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```


## **Lấy tọa độ hình chữ nhật của Paragraph**
Sử dụng phương pháp [**getRect()**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Paragraph#getRect--) các nhà phát triển có thể lấy hình chữ nhật giới hạn của đoạn văn.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lấy kích thước của đoạn và phần trong khung văn bản ô bảng**

Để lấy kích thước và tọa độ của [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Portion) hoặc [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Paragraph) trong khung văn bản của ô bảng, bạn có thể sử dụng các phương pháp [Portion.getRect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Portion#getRect--) và [Paragraph.getRect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Paragraph#getRect--).

Mã mẫu này minh họa thao tác được mô tả:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Các đơn vị nào được sử dụng khi trả về tọa độ cho đoạn và phần văn bản?**

Trong điểm (points), trong đó 1 inch = 72 points. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc xuống dòng văn bản có ảnh hưởng đến giới hạn của đoạn không?**

Có. Nếu [wrapping](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/setwraptext/) được bật trong [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/), văn bản sẽ tự động ngắt để vừa với chiều rộng khu vực, làm thay đổi giới hạn thực tế của đoạn.

**Có thể ánh xạ tọa độ đoạn sang pixel trong hình ảnh xuất ra một cách đáng tin cậy không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixels = points × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho quá trình render/xuất.

**Làm sao để lấy các tham số định dạng đoạn “effective”, có tính đến kế thừa style?**

Sử dụng [effective paragraph formatting data structure](/slides/vi/nodejs-java/shape-effective-properties/); nó trả về các giá trị tổng hợp cuối cùng cho thụt lề, khoảng cách, việc gói chữ, RTL và các thuộc tính khác.