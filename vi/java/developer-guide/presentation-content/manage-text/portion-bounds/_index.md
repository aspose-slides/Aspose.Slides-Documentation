---
title: Lấy Giới Hạn Phần Văn Bản từ Bản Trình Chiếu trong Java
linktitle: Giới Hạn Phần
type: docs
weight: 47
url: /vi/java/portion-bounds/
keywords:
- giới hạn phần văn bản
- phần văn bản
- đoạn văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn phần văn bản trong các bản trình chiếu PowerPoint bằng Aspose.Slides cho Java."
---
## **Tổng quan**

Một phần văn bản đại diện cho một đoạn văn bản cụ thể bên trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy giới hạn của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

Bài viết này mô tả cách lấy hình chữ nhật bao quanh của một phần bằng cách sử dụng [IPortion.getRect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPortion#getRect--). Nó cũng chỉ ra cách lấy tọa độ của đầu phần bằng cách sử dụng [IPortion.getCoordinates](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPortion#getCoordinates--). Ngoài ra, nó làm nổi bật các kịch bản thường gặp liên quan đến phần, chẳng hạn như áp dụng siêu liên kết cho một đoạn văn bản duy nhất, hiểu cách định dạng được giải quyết qua phần, đoạn, khung văn bản và kế thừa chủ đề, và xử lý các trường hợp phông chữ được chỉ định không có sẵn.

## **Lấy giới hạn của một phần văn bản**

Sử dụng [IPortion.getRect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPortion#getRect--) để lấy hình chữ nhật bao quanh của một phần văn bản:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Lấy tọa độ của một phần văn bản**

Sử dụng [IPortion.getCoordinates](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPortion#getCoordinates--) để lấy tọa độ của đầu một phần văn bản:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Tôi có thể áp dụng siêu liên kết cho chỉ một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/java/manage-hyperlinks/) cho một phần riêng lẻ; chỉ đoạn đó sẽ có thể nhấp được, không phải toàn bộ đoạn.

**Cách hoạt động của kế thừa kiểu dáng: phần nào ghi đè và gì được lấy từ đoạn hoặc khung văn bản?**

Các thuộc tính cấp phần có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [IPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/), Aspose.Slides sẽ lấy nó từ [IParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/). Nếu cũng không được đặt ở đó, Aspose.Slides sẽ sử dụng kiểu của [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) hoặc [theme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/theme/).

**Điều gì xảy ra nếu phông chữ được chỉ định cho một phần không có trên máy hoặc máy chủ đích?**

[Các quy tắc thay thế phông chữ](/slides/vi/java/font-selection-sequence/) được áp dụng. Văn bản có thể tái bố trí: các chỉ số, cách gạch ngang và độ rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient cho phần văn bản riêng biệt mà không ảnh hưởng tới phần còn lại của đoạn không?**

Có, màu văn bản, độ tô và độ trong suốt ở cấp [IPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/) có thể khác với các đoạn lân cận.