---
title: Lấy Giới Hạn Đoạn Văn từ Bản Thuyết Trình trong Java
linktitle: Đoạn Văn
type: docs
weight: 60
url: /vi/java/paragraph/
keywords:
- giới hạn đoạn văn
- giới hạn phần văn bản
- tọa độ đoạn văn
- tọa độ phần
- kích thước đoạn văn
- kích thước phần văn bản
- khung văn bản
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách truy xuất giới hạn đoạn văn và phần văn bản trong Aspose.Slides cho Java để tối ưu vị trí văn bản trong các bản thuyết trình PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của đoạn văn và các phần văn bản trong Aspose.Slides. Nó cho thấy cách truy xuất hình chữ nhật của đoạn văn trong `TextFrame` bằng cách sử dụng `getRect()`, cách lấy tọa độ đoạn văn và phần bên trong khung văn bản của ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc gói văn bản tới giới hạn, chuyển đổi sang pixel, và các giá trị định dạng đoạn văn “hiệu quả”.

## **Lấy tọa độ đoạn văn và phần trong TextFrame**
Sử dụng Aspose.Slides for Java, các nhà phát triển giờ có thể lấy tọa độ hình chữ nhật cho đoạn văn trong bộ sưu tập Paragraphs của TextFrame. Nó cũng cho phép bạn lấy [tọa độ của phần](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPortion#getCoordinates--) trong bộ sưu tập phần của một đoạn văn. Trong chủ đề này, chúng tôi sẽ trình bày bằng một ví dụ cách lấy tọa độ hình chữ nhật cho đoạn văn cùng vị trí của phần bên trong đoạn văn.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Lấy tọa độ hình chữ nhật của một đoạn văn**
Sử dụng phương thức [**getRect()**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IParagraph#getRect--) các nhà phát triển có thể lấy hình chữ nhật giới hạn của đoạn văn.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lấy kích thước của đoạn văn và phần bên trong khung văn bản của ô bảng**

Để lấy kích thước và tọa độ của [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Portion) hoặc [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Paragraph) trong khung văn bản ô bảng, bạn có thể sử dụng các phương thức [IPortion.getRect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPortion#getRect--) và [IParagraph.getRect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IParagraph#getRect--).

Mã mẫu sau minh họa hoạt động đã mô tả:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Các đơn vị đo nào được sử dụng cho tọa độ trả về của đoạn văn và các phần văn bản?**

Đơn vị là điểm, trong đó 1 inch = 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc gói từ có ảnh hưởng tới giới hạn của đoạn văn không?**

Có. Nếu [wrapping](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframeformat/#setWrapText-byte-) được bật trong [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/), văn bản sẽ ngắt để vừa với chiều rộng khu vực, làm thay đổi giới hạn thực tế của đoạn văn.

**Có thể ánh xạ tọa độ đoạn văn một cách đáng tin cậy sang pixel trong hình ảnh xuất ra không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixels = points × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render/xuất.

**Làm sao để lấy các tham số định dạng đoạn văn “hiệu quả”, có tính đến kế thừa kiểu dáng?**

Sử dụng [cấu trúc dữ liệu định dạng đoạn văn hiệu quả](/slides/vi/java/shape-effective-properties/); nó trả về các giá trị hợp nhất cuối cùng cho thụt lề, khoảng cách, gói văn bản, RTL và các thuộc tính khác.