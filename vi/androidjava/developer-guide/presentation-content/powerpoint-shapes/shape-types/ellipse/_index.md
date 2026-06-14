---
title: Thêm Ellipses vào Bản trình chiếu trên Android
linktitle: Ellipse
type: docs
weight: 30
url: /vi/androidjava/ellipse/
keywords:
- ellipse
- hình dạng
- thêm ellipse
- tạo ellipse
- vẽ ellipse
- ellipse đã định dạng
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo, định dạng và thao tác các hình ellipse trong Aspose.Slides cho Android trên các bản trình chiếu PPT và PPTX—có kèm ví dụ mã Java."
---
## **Tổng quan**

Bài viết này trình bày cách thêm các hình ellipse vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một ellipse đơn giản, tạo một ellipse được định dạng, và lưu bản trình chiếu đã cập nhật dưới dạng tệp PPTX. Nó cũng đề cập đến các câu hỏi liên quan như làm việc với vị trí và kích thước của ellipse, kiểm soát thứ tự xếp chồng, và áp dụng hiệu ứng hoạt hình.

## **Tạo một Ellipse**
Để thêm một ellipse đơn giản vào một slide đã chọn của bản trình chiếu, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Ellipse bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection).
- Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một ellipse vào slide đầu tiên

```java
// Khởi tạo lớp Presentation đại diện cho PPTX
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

## **Tạo một Ellipse Định dạng**
Để thêm một ellipse được định dạng tốt hơn vào một slide, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Ellipse bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection).
- Đặt Fill Type của Ellipse thành Solid.
- Đặt Color của Ellipse bằng thuộc tính SolidFillColor.Color được cung cấp bởi đối tượng [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IFillFormat) liên kết với đối tượng [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape).
- Đặt Color cho các đường viền của Ellipse.
- Đặt Width cho các đường viền của Ellipse.
- Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một ellipse đã định dạng vào slide đầu tiên của bản trình chiếu.

```java
// Khởi tạo lớp Presentation đại diện cho PPTX
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

**Làm thế nào để đặt vị trí và kích thước chính xác của một ellipse so với đơn vị của slide?**

Các tọa độ và kích thước thường được chỉ định **theo points**. Để có kết quả dự đoán được, hãy dựa trên kích thước slide và chuyển đổi milimet hoặc inch cần thiết sang points trước khi gán giá trị.

**Làm thế nào để đặt một ellipse lên trên hoặc dưới các đối tượng khác (kiểm soát thứ tự xếp chồng)?**

Điều chỉnh thứ tự vẽ của đối tượng bằng cách đưa nó lên phía trước hoặc gửi nó ra phía sau. Điều này cho phép ellipse chồng lên các đối tượng khác hoặc hiển thị những gì nằm dưới nó.

**Làm thế nào để tạo hoạt ảnh cho việc xuất hiện hoặc nhấn mạnh một ellipse?**

[Apply](/slides/vi/androidjava/shape-animation/) các hiệu ứng entrance, emphasis hoặc exit cho hình, và cấu hình trigger và timing để điều khiển thời gian và cách hoạt ảnh được phát.