---
title: Lấy Giới Hạn Phần Văn Bản từ Bản Trình Chiếu trên Android
linktitle: Giới Hạn Phần
type: docs
weight: 47
url: /vi/androidjava/portion-bounds/
keywords:
- giới hạn phần văn bản
- phần văn bản
- đoạn văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn phần văn bản trong các bản trình chiếu PowerPoint bằng Aspose.Slides cho Android thông qua Java."
---
## **Overview**

Một phần văn bản đại diện cho một đoạn văn bản cụ thể bên trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy giới hạn của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

Bài viết này mô tả cách lấy hình chữ nhật bao quanh của một phần bằng cách sử dụng [IPortion.getRect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPortion#getRect--). Nó cũng chỉ cách lấy tọa độ của đầu một phần bằng cách sử dụng [IPortion.getCoordinates](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPortion#getCoordinates--). Ngoài ra, nó nêu bật các kịch bản thường gặp liên quan đến phần, chẳng hạn áp dụng siêu liên kết cho một đoạn văn bản duy nhất, hiểu cách định dạng được giải quyết qua phần, đoạn, khung văn bản và kế thừa chủ đề, và xử lý các trường hợp phông chữ được chỉ định không có sẵn.

## **Get Bounds of a Text Portion**

Sử dụng [IPortion.getRect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPortion#getRect--) để lấy hình chữ nhật bao quanh của một phần văn bản:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Get Coordinates of a Text Portion**

Sử dụng [IPortion.getCoordinates](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPortion#getCoordinates--) để lấy tọa độ của đầu một phần văn bản:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Tôi có thể áp dụng siêu liên kết chỉ cho một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/androidjava/manage-hyperlinks/) cho một phần riêng lẻ; chỉ đoạn đó sẽ có thể nhấp, không phải toàn bộ đoạn.

**Kế thừa kiểu dáng hoạt động như thế nào: một phần ghi đè những gì, và những gì được lấy từ đoạn hoặc khung văn bản?**

Các thuộc tính ở cấp độ phần có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [IPortion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/), Aspose.Slides sẽ lấy nó từ [IParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraph/). Nếu ở đó cũng không được đặt, Aspose.Slides sẽ sử dụng kiểu [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) hoặc [theme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/theme/).

**Điều gì sẽ xảy ra nếu phông chữ được chỉ định cho một phần không có trên máy hoặc máy chủ mục tiêu?**

Áp dụng [quy tắc thay thế phông chữ](/slides/vi/androidjava/font-selection-sequence/). Văn bản có thể được chuyển dạng: các chỉ số, cách gạch nối và độ rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient cho phần văn bản riêng biệt mà không ảnh hưởng đến phần còn lại của đoạn không?**

Có, màu văn bản, độ đổ màu và độ trong suốt ở mức độ [IPortion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/) có thể khác nhau so với các đoạn lân cận.