---
title: Quản lý các đoạn văn bản trong bản trình chiếu bằng Java
linktitle: Phần văn bản
type: docs
weight: 70
url: /vi/java/portion/
keywords:
- đoạn văn bản
- phần văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý các đoạn văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Java, nâng cao hiệu suất và khả năng tùy chỉnh."
---
## **Tổng quan**

Một đoạn văn bản đại diện cho một phần cụ thể của văn bản trong một đoạn và cho phép bạn làm việc với phần đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các đoạn có thể được sử dụng khi bạn cần lấy vị trí của một phần văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

Bài viết này giới thiệu cách lấy tọa độ của đầu một đoạn bằng phương thức `getCoordinates()`. Nó cũng nêu bật các kịch bản thường gặp liên quan đến đoạn, chẳng hạn như áp dụng siêu liên kết cho một phần văn bản duy nhất, hiểu cách định dạng được giải quyết qua đoạn, đoạn văn, khung văn bản và kế thừa từ chủ đề, cũng như xử lý trường hợp phông chữ được chỉ định không có sẵn. Ngoài ra, tài liệu còn lưu ý rằng màu nền, màu sắc và độ trong suốt của văn bản có thể được đặt khác nhau cho từng đoạn riêng lẻ trong cùng một đoạn.

## **Lấy tọa độ của một đoạn văn bản**
[**getCoordinates()**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPortion#getCoordinates--) phương thức đã được thêm vào [IPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/) và [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) cho phép lấy tọa độ của đầu đoạn.

```java
// Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Định hình lại ngữ cảnh của bản trình chiếu
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng siêu liên kết chỉ cho một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [gắn một siêu liên kết](/slides/vi/java/manage-hyperlinks/) cho một đoạn riêng lẻ; chỉ phần đó sẽ có thể nhấp được, không phải toàn bộ đoạn.

**Cách kế thừa kiểu dáng hoạt động như thế nào: một Portion ghi đè gì, và gì được lấy từ Paragraph/TextFrame?**

Các thuộc tính ở mức Portion có độ ưu tiên cao nhất. Nếu một thuộc tính chưa được đặt trên [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/), engine sẽ lấy từ [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/); nếu vẫn chưa, từ [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/) hoặc kiểu dáng của [theme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/theme/).

**Điều gì xảy ra nếu phông chữ được chỉ định cho một Portion không có trên máy hoặc máy chủ mục tiêu?**

[Font substitution rules](/slides/vi/java/font-selection-sequence/) được áp dụng. Văn bản có thể được tái bố trí: các chỉ số, cách gạch ngang và độ rộng có thể thay đổi, điều này ảnh hưởng đến việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient cho màu nền văn bản của một Portion riêng biệt mà không ảnh hưởng đến các phần còn lại của đoạn không?**

Có, màu văn bản, nền và độ trong suốt ở mức [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) có thể khác nhau so với các đoạn lân cận.