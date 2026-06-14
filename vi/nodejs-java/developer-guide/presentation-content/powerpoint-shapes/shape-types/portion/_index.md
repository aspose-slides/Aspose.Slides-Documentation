---
title: Quản lý các đoạn văn bản trong bài thuyết trình bằng JavaScript
linktitle: Đoạn văn bản
type: docs
weight: 70
url: /vi/nodejs-java/portion/
keywords:
- đoạn văn bản
- phần văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách quản lý các đoạn văn bản trong bản trình chiếu PowerPoint bằng JavaScript và Aspose.Slides cho Node.js thông qua Java, nâng cao hiệu suất và khả năng tùy chỉnh."
---
## **Tổng quan**

Phần văn bản đại diện cho một đoạn văn bản cụ thể bên trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy vị trí của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

Bài viết này trình bày cách lấy tọa độ của phần đầu của một phần bằng cách sử dụng phương thức `getCoordinates()`. Nó cũng nêu bật các kịch bản thường gặp liên quan đến phần, chẳng hạn như áp dụng siêu liên kết cho một đoạn văn bản duy nhất, hiểu cách định dạng được giải quyết qua phần, đoạn, khung văn bản và kế thừa theme, và xử lý các trường hợp phông chữ được chỉ định không khả dụng. Ngoài ra, nó lưu ý rằng màu nền, màu sắc và độ trong suốt của văn bản có thể được đặt khác nhau cho từng phần riêng lẻ trong cùng một đoạn.

## **Lấy tọa độ vị trí của Phần**
[**getCoordinates()**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Portion#getCoordinates--) phương thức đã được thêm vào lớp [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) cho phép lấy tọa độ của phần đầu của phần.

```javascript
// Khởi tạo lớp Presentation đại diện cho PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Định hình lại ngữ cảnh của bản trình chiếu
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Bạn có thể áp dụng siêu liên kết chỉ cho một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/nodejs-java/manage-hyperlinks/) cho một phần riêng lẻ; chỉ đoạn văn bản đó sẽ có thể nhấp, không phải toàn bộ đoạn.

**Kế thừa kiểu dáng hoạt động như thế nào: Phần ghi đè gì, và gì được lấy từ Đoạn/TextFrame?**

Các thuộc tính cấp Phần có ưu tiên cao nhất. Nếu một thuộc tính chưa được đặt trên [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/), engine sẽ lấy nó từ [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/); nếu tại đó cũng chưa được đặt, sẽ lấy từ [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) hoặc kiểu style của [theme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/theme/).

**Điều gì sẽ xảy ra nếu phông chữ được chỉ định cho một Phần không có trên máy/serv­er mục tiêu?**

[Quy tắc thay thế phông chữ](/slides/vi/nodejs-java/font-selection-sequence/) sẽ được áp dụng. Văn bản có thể thay đổi cách hiển thị: các chỉ số, cách gạch ngang và độ rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Bạn có thể đặt độ trong suốt hoặc gradient màu nền văn bản cho một Phần riêng biệt mà không ảnh hưởng tới phần còn lại của đoạn không?**

Có, màu văn bản, nền và độ trong suốt ở cấp độ [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) có thể khác nhau so với các đoạn lân cận.