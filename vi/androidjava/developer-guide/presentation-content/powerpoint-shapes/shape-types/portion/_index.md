---
title: Quản lý các phần văn bản trong bản trình chiếu trên Android
linktitle: Phần Văn Bản
type: docs
weight: 70
url: /vi/androidjava/portion/
keywords:
- phần văn bản
- đoạn văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý các phần văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Android thông qua Java, nâng cao hiệu suất và khả năng tùy chỉnh."
---
## **Giới thiệu**

Một phần văn bản đại diện cho một đoạn văn bản cụ thể bên trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy vị trí của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc điều khiển hành vi văn bản ở mức chi tiết hơn.

## **Lấy tọa độ của một phần văn bản**
[**getCoordinates()**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPortion#getCoordinates--) phương thức đã được thêm vào lớp [IPortion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/) và [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portion/) cho phép lấy tọa độ của phần đầu của đoạn.

```java
// Khởi tạo lớp Presentation đại diện cho PPTX
Presentation pres = new Presentation();
try {
    // Định dạng lại ngữ cảnh của bản trình chiếu
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

**Tôi có thể áp dụng siêu liên kết chỉ cho một phần của văn bản trong cùng một đoạn không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/androidjava/manage-hyperlinks/) cho một phần riêng lẻ; chỉ đoạn đó sẽ có thể nhấp, không phải toàn bộ đoạn.

**Cách kế thừa kiểu dáng hoạt động như thế nào: Portion ghi đè gì, và gì được lấy từ Paragraph/TextFrame?**

Các thuộc tính ở mức Portion có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portion/), engine sẽ lấy nó từ [Paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraph/); nếu cũng không được đặt ở đó, thì từ [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/) hoặc kiểu [theme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/theme/) .

**Điều gì sẽ xảy ra nếu phông chữ được chỉ định cho một Portion không có trên máy/máy chủ mục tiêu?**

[Quy tắc thay thế phông chữ](/slides/vi/androidjava/font-selection-sequence/) được áp dụng. Văn bản có thể thay đổi dòng: các chỉ số, cách tách từ và chiều rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient của phần điền văn bản riêng cho Portion mà không ảnh hưởng đến phần còn lại của đoạn không?**

Có, màu văn bản, màu nền và độ trong suốt ở mức [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portion/) có thể khác với các đoạn lân cận.