---
title: Lấy giới hạn đoạn văn từ bản trình bày trong Java
linktitle: Giới hạn đoạn văn
type: docs
weight: 43
url: /vi/java/paragraph-bounds/
keywords:
- giới hạn đoạn văn
- tọa độ đoạn văn
- kích thước đoạn văn
- khung văn bản
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn văn trong Aspose.Slides cho Java để tối ưu vị trí văn bản trong các bản trình bày PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn trong Aspose.Slides. Nó cho thấy cách lấy hình chữ nhật của đoạn từ một [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) bằng cách sử dụng [IParagraph.getRect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IParagraph#getRect--), cách lấy tọa độ đoạn bên trong khung văn bản của ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc gói văn bản đến giới hạn, chuyển đổi pixel và các giá trị định dạng đoạn “effective”.

## **Lấy tọa độ hình chữ nhật của một đoạn**

Sử dụng [IParagraph.getRect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IParagraph#getRect--) để lấy hình chữ nhật bao quanh của một đoạn.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Lấy kích thước của một đoạn trong khung văn bản ô bảng**

Để lấy kích thước và tọa độ của một [IParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/) trong khung văn bản của ô bảng, sử dụng [IParagraph.getRect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IParagraph#getRect--). Hình chữ nhật trả về là tương đối so với khung văn bản của ô bảng, vì vậy hãy cộng vị trí bảng và độ dịch của ô khi bạn cần tọa độ ở cấp slide.

Ví dụ sau lấy giới hạn của đoạn bên trong ô bảng và vẽ các hình chữ nhật trên slide để hiển thị những giới hạn đó:

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

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

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

**Các tọa độ đoạn được đo bằng đơn vị nào?**

Chúng được đo bằng điểm, trong đó 1 inch bằng 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc ngắt từ có ảnh hưởng đến giới hạn của đoạn không?**

Có. Nếu [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) được bật cho [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/), văn bản sẽ ngắt để phù hợp với độ rộng khu vực, điều này thay đổi giới hạn thực tế của đoạn.

**Có thể ánh xạ chắc chắn các tọa độ đoạn sang pixel trong hình ảnh xuất ra không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixels = points x (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render hoặc xuất.

**Làm thế nào để lấy các tham số định dạng đoạn "effective", tính đến kế thừa kiểu?**

Sử dụng [effective paragraph formatting data structure](/slides/vi/java/shape-effective-properties/); nó trả về các giá trị tổng hợp cuối cùng cho thụt lề, khoảng cách, cuộn, RTL và hơn nữa.