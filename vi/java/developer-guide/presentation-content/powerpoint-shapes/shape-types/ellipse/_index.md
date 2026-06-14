---
title: Thêm Hình Bầu Dực vào Bản Trình Bày trong Java
linktitle: Hình Bầu Dực
type: docs
weight: 30
url: /vi/java/ellipse/
keywords:
- hình bầu dục
- hình dạng
- thêm hình bầu dục
- tạo hình bầu dục
- vẽ hình bầu dục
- hình bầu dục đã định dạng
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo, định dạng và thao tác các hình bầu dục trong Aspose.Slides cho Java trên các bản trình bày PPT và PPTX—kèm theo các ví dụ mã Java."
---
## **Tổng quan**

Bài viết này mô tả cách thêm các hình bầu dục vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó đề cập đến việc tạo một hình bầu dục đơn giản, tạo một hình bầu dục đã định dạng, và lưu bản trình bày đã cập nhật dưới dạng tệp PPTX. Ngoài ra, còn trả lời các câu hỏi liên quan như làm việc với vị trí và kích thước của hình bầu dục, kiểm soát thứ tự lớp, và áp dụng hiệu ứng hoạt hình.

## **Tạo một Hình bầu dục**
Để thêm một hình bầu dục đơn giản vào một slide đã chọn của bản trình bày, hãy thực hiện các bước sau:

- Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) class.
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một AutoShape kiểu Ellipse bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection).
- Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình bầu dục vào slide đầu tiên

```java
// Tạo đối tượng lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Thêm AutoShape loại ellipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Ghi tệp PPTX ra đĩa
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tạo một Hình bầu dục Định dạng**
Để thêm một hình bầu dục được định dạng tốt hơn vào một slide, hãy thực hiện các bước sau:

- Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) class.
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một AutoShape kiểu Ellipse bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection).
- Đặt Kiểu Đổ màu của Hình bầu dục thành Solid.
- Đặt Màu của Hình bầu dục bằng thuộc tính SolidFillColor.Color được khai báo bởi đối tượng [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IFillFormat) liên kết với đối tượng [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape).
- Đặt Màu của các đường viền của Hình bầu dục.
- Đặt Độ rộng của các đường viền của Hình bầu dục.
- Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình bầu dục đã định dạng vào slide đầu tiên của bản trình bày.

```java
// Tạo đối tượng lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm AutoShape loại ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Áp dụng một số định dạng cho hình ellipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Áp dụng một số định dạng cho đường viền của Ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Ghi tệp PPTX ra đĩa
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Làm thế nào để đặt vị trí và kích thước chính xác của hình bầu dục so với đơn vị của slide?**

Tọa độ và kích thước thường được chỉ định bằng points. Để có kết quả dự đoán được, hãy tính toán dựa trên kích thước slide và chuyển đổi milimet hoặc inch cần thiết sang points trước khi gán giá trị.

**Làm sao tôi có thể đặt hình bầu dục lên trên hoặc dưới các đối tượng khác (kiểm soát thứ tự lớp)?**

Điều chỉnh thứ tự vẽ của đối tượng bằng cách đưa nó lên trước hoặc gửi nó về sau. Điều này cho phép hình bầu dục chồng lên các đối tượng khác hoặc hiển thị các đối tượng ở dưới nó.

**Làm thế nào để tạo hoạt ảnh cho sự xuất hiện hoặc nhấn mạnh của hình bầu dục?**

[Áp dụng](/slides/vi/java/shape-animation/) các hiệu ứng vào, nhấn mạnh hoặc thoát cho hình dạng, và cấu hình triggers và timing để điều phối khi nào và cách hoạt ảnh diễn ra.