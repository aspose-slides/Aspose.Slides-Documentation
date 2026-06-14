---
title: Lấy giới hạn đoạn văn từ bài thuyết trình trên Android
linktitle: Đoạn văn
type: docs
weight: 60
url: /vi/androidjava/paragraph/
keywords:
- giới hạn đoạn văn
- giới hạn phần văn bản
- tọa độ đoạn văn
- tọa độ phần
- kích thước đoạn văn
- kích thước phần văn bản
- khung văn bản
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn văn và phần văn bản trong Aspose.Slides cho Android thông qua Java để tối ưu vị trí văn bản trong các bản PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn và phần văn bản trong Aspose.Slides. Nó trình bày cách truy xuất hình chữ nhật của đoạn văn trong `TextFrame` bằng cách sử dụng `getRect()`, cách lấy tọa độ đoạn văn và phần bên trong khung văn bản của ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc ngắt dòng tới giới hạn, chuyển đổi sang pixel và các giá trị định dạng đoạn văn “hiệu quả”.

## **Lấy tọa độ đoạn văn và phần trong TextFrame**
Sử dụng Aspose.Slides cho Android thông qua Java, các nhà phát triển hiện có thể lấy tọa độ hình chữ nhật cho Paragraph trong collection các đoạn văn của TextFrame. Nó cũng cho phép bạn lấy [the coordinates of portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPortion#getCoordinates--) trong collection các phần của một đoạn văn. Trong chủ đề này, chúng tôi sẽ minh họa bằng một ví dụ cách lấy tọa độ hình chữ nhật cho đoạn văn cùng với vị trí của phần bên trong đoạn văn.

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
Bằng cách sử dụng phương thức [**getRect()**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraph#getRect--), các nhà phát triển có thể lấy hình chữ nhật giới hạn của đoạn văn.

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

## **Lấy kích thước của đoạn văn và phần bên trong TextFrame của ô bảng**

Để lấy kích thước và tọa độ của [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Portion) hoặc [Paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Paragraph) trong khung văn bản của ô bảng, bạn có thể sử dụng các phương thức [IPortion.getRect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPortion#getRect--) và [IParagraph.getRect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraph#getRect--).

Mã mẫu dưới đây minh họa hoạt động mô tả:

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

**Các tọa độ trả về cho đoạn văn và phần văn bản được đo bằng đơn vị nào?**

Bằng điểm (points), trong đó 1 inch = 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc ngắt từ có ảnh hưởng đến giới hạn của đoạn văn không?**

Có. Nếu [wrapping](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) được bật trong [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/), văn bản sẽ bị ngắt để vừa với chiều rộng khu vực, làm thay đổi giới hạn thực tế của đoạn văn.

**Có thể ánh xạ tọa độ đoạn văn sang pixel trong hình ảnh xuất ra một cách đáng tin cậy không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixels = points × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render/ xuất.

**Làm thế nào để lấy các tham số định dạng đoạn văn “hiệu quả”, tính đến kế thừa kiểu?**

Sử dụng [effective paragraph formatting data structure](/slides/vi/androidjava/shape-effective-properties/); nó trả về các giá trị hợp nhất cuối cùng cho thụt lề, khoảng cách, ngắt dòng, RTL và các thuộc tính khác.