---
title: Lấy giới hạn phần văn bản từ bản trình chiếu bằng JavaScript
linktitle: Giới hạn phần
type: docs
weight: 47
url: /vi/nodejs-java/portion-bounds/
keywords:
- giới hạn phần văn bản
- phần văn bản
- phần văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn phần văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Một phần văn bản đại diện cho một đoạn văn bản cụ thể bên trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy giới hạn của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi của văn bản ở mức chi tiết hơn.

Bài viết này cho thấy cách lấy hình chữ nhật bao quanh của một phần bằng cách sử dụng [Portion.getRect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/getrect/). Nó cũng chỉ ra cách lấy tọa độ của đầu phần bằng cách sử dụng [Portion.getCoordinates](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/getcoordinates/). Ngoài ra, bài viết còn nhấn mạnh các kịch bản thường gặp liên quan đến phần, chẳng hạn như áp dụng siêu liên kết cho một đoạn văn bản duy nhất, hiểu cách định dạng được giải quyết qua phần, đoạn, khung văn bản và kế thừa theme, và xử lý các trường hợp phông chữ được chỉ định không có sẵn.

## **Lấy giới hạn của một phần văn bản**

Sử dụng [Portion.getRect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/getrect/) để lấy hình chữ nhật bao quanh của một phần văn bản:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Lấy tọa độ của một phần văn bản**

Sử dụng [Portion.getCoordinates](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/getcoordinates/) để lấy tọa độ của đầu một phần văn bản:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng siêu liên kết chỉ cho một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [assign a hyperlink](/slides/vi/nodejs-java/manage-hyperlinks/) cho một phần riêng lẻ; chỉ đoạn văn bản đó sẽ có thể nhấp, không phải toàn bộ đoạn.

**Thế kế kiểu dáng hoạt động như thế nào: một phần ghi đè gì, và phần nào được lấy từ đoạn hoặc khung văn bản?**

Các thuộc tính ở mức Portion có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/), Aspose.Slides sẽ lấy nó từ [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/). Nếu ở đó cũng không được đặt, Aspose.Slides sẽ sử dụng kiểu của [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) hoặc [theme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/theme/).

**Điều gì sẽ xảy ra nếu phông chữ được chỉ định cho một phần không có trên máy hoặc máy chủ mục tiêu?**

[Font substitution rules](/slides/vi/nodejs-java/font-selection-sequence/) sẽ được áp dụng. Văn bản có thể được tái bố trí: các chỉ số, cách tách từ và chiều rộng có thể thay đổi, điều này ảnh hưởng đến vị trí chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient riêng cho phần văn bản mà không ảnh hưởng đến phần còn lại của đoạn không?**

Có, màu văn bản, màu nền và độ trong suốt ở mức [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) có thể khác nhau với các đoạn lân cận.