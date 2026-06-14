---
title: Thêm các hình ellipse vào bản trình chiếu trong .NET
linktitle: Ellipse
type: docs
weight: 30
url: /vi/net/ellipse/
keywords:
- ellipse
- hình dạng
- thêm ellipse
- tạo ellipse
- vẽ ellipse
- ellipse định dạng
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tạo, định dạng và thao tác các hình ellipse trong Aspose.Slides cho .NET trên các bản trình chiếu PPT và PPTX—kèm theo các ví dụ code C#."
---
## **Tổng quan**

Bài viết này hướng dẫn cách thêm các hình ellipse vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một ellipse đơn giản, tạo một ellipse có định dạng, và lưu bản trình chiếu đã cập nhật dưới dạng tệp PPTX. Nó cũng đề cập đến các câu hỏi liên quan như làm việc với vị trí và kích thước của ellipse, kiểm soát thứ tự xếp chồng, và áp dụng hiệu ứng hoạt hình.

## **Tạo một Ellipse**
Để thêm một ellipse đơn giản vào slide được chọn của bản trình chiếu, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)lớp
2. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó
3. Thêm một AutoShape loại Ellipse bằng cách sử dụng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes
4. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã thêm một ellipse vào slide đầu tiên.

```c#
 // Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{

    // Lấy slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Thêm AutoShape loại ellipse
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Ghi tệp PPTX ra đĩa
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Tạo một Ellipse Được Định Dạng**
Để thêm một ellipse được định dạng tốt hơn vào một slide, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
3. Thêm một AutoShape loại Ellipse bằng cách sử dụng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes.
4. Đặt Fill Type của Ellipse thành Solid.
5. Đặt Color của Ellipse bằng thuộc tính SolidFillColor.Color được cung cấp bởi đối tượng FillFormat liên kết với đối tượng IShape.
6. Đặt Color cho các đường của Ellipse.
7. Đặt Width cho các đường của Ellipse.
8. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một ellipse được định dạng vào slide đầu tiên của bản trình chiếu.

```c#
 // Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{

    // Lấy slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Thêm AutoShape loại ellipse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Áp dụng một số định dạng cho hình ellipse
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Áp dụng một số định dạng cho đường viền của Ellipse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Ghi tệp PPTX ra đĩa
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Làm sao để đặt vị trí và kích thước chính xác của một ellipse so với đơn vị của slide?**

Các tọa độ và kích thước thường được chỉ định **theo điểm**. Để có kết quả dự đoán được, hãy tính toán dựa trên kích thước slide và chuyển đổi milimet hoặc inch cần thiết sang điểm trước khi gán giá trị.

**Làm sao để đặt một ellipse ở trên hoặc dưới các đối tượng khác (kiểm soát thứ tự xếp chồng)?**

Điều chỉnh thứ tự vẽ của đối tượng bằng cách đưa nó lên phía trước hoặc gửi nó ra phía sau. Điều này cho phép ellipse chồng lên các đối tượng khác hoặc hiển thị các đối tượng bên dưới nó.

**Làm sao để tạo hoạt ảnh cho việc xuất hiện hoặc nhấn mạnh của một ellipse?**

[Apply](/slides/vi/net/shape-animation/) các hiệu ứng entrance, emphasis hoặc exit lên shape, và cấu hình trigger và thời gian để điều khiển khi nào và cách hoạt ảnh diễn ra.