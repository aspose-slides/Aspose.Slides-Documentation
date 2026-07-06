---
title: Lấy giới hạn đoạn văn từ các bản trình chiếu trên Android
linktitle: Giới hạn đoạn văn
type: docs
weight: 43
url: /vi/androidjava/paragraph-bounds/
keywords:
- giới hạn đoạn văn
- tọa độ đoạn văn
- kích thước đoạn văn
- khung văn bản
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn văn trong Aspose.Slides cho Android bằng Java để tối ưu vị trí văn bản trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn trong Aspose.Slides. Nó cho thấy cách truy xuất hình chữ nhật của đoạn văn từ một [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) bằng cách sử dụng [IParagraph.getRect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraph#getRect--), cách lấy tọa độ đoạn văn trong khung văn bản của ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc ngắt dòng văn bản đến giới hạn, chuyển đổi pixel, và các giá trị định dạng đoạn văn “effective”.

## **Lấy tọa độ hình chữ nhật của một đoạn văn**

Sử dụng [IParagraph.getRect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraph#getRect--) để lấy hình chữ nhật bao quanh của một đoạn văn.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Lấy kích thước của một đoạn văn trong khung văn bản của ô bảng**

Để lấy kích thước và tọa độ của một [IParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraph/) trong khung văn bản của ô bảng, sử dụng [IParagraph.getRect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraph#getRect--). Hình chữ nhật được trả về là tương đối so với khung văn bản của ô bảng, vì vậy hãy cộng vị trí bảng và offset của ô khi bạn cần tọa độ ở mức slide.

Ví dụ sau đây lấy giới hạn đoạn văn trong ô bảng và vẽ các hình chữ nhật trên slide để hiển thị các giới hạn đó:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Đơn vị đo của tọa độ đoạn văn là gì?**

Chúng được đo bằng điểm (points), trong đó 1 inch bằng 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc ngắt từ có ảnh hưởng đến giới hạn của đoạn văn không?**

Có. Nếu [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) được bật cho [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/), văn bản sẽ ngắt để phù hợp với chiều rộng khu vực, gây thay đổi giới hạn thực tế của đoạn văn.

**Có thể ánh xạ tọa độ đoạn văn sang pixel trong hình ảnh xuất ra một cách đáng tin cậy không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixel = điểm × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render hoặc xuất.

**Làm sao để lấy các tham số định dạng đoạn văn "effective", có tính đến kế thừa kiểu?**

Sử dụng [effective paragraph formatting data structure](/slides/vi/androidjava/shape-effective-properties/); nó trả về các giá trị tổng hợp cuối cùng cho thụt lề, khoảng cách, việc gói chữ, RTL và các thiết lập khác.