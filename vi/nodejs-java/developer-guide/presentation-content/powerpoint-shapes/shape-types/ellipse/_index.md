---
title: Thêm Các Hình Elip Vào Bản Trình Chiếu Trong JavaScript
linktitle: Elip
type: docs
weight: 30
url: /vi/nodejs-java/ellipse/
keywords:
- elip
- hình dạng
- thêm elip
- tạo elip
- vẽ elip
- elip có định dạng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo, định dạng và thao tác các hình elip trong Aspose.Slides cho Node.js trên các bản trình chiếu PPT và PPTX—kèm ví dụ mã JavaScript."
---
## **Tổng quan**

Bài viết này minh họa cách thêm các hình elip vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một hình elip đơn giản, tạo một hình elip có định dạng, và lưu bản trình chiếu đã cập nhật dưới dạng tệp PPTX. Ngoài ra còn đề cập đến các câu hỏi liên quan như làm việc với vị trí và kích thước của elip, kiểm soát thứ tự chồng lên nhau, và áp dụng hiệu ứng hoạt ảnh.

## **Tạo Elip**
Để thêm một hình elip đơn giản vào một slide được chọn của bản trình chiếu, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Ellipse bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection).
- Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình elip vào slide đầu tiên

```javascript
// Tạo một thể hiện của lớp Presentation đại diện cho PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm AutoShape loại ellipse
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Ghi tệp PPTX ra đĩa
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tạo Elip Định Dạng**
Để thêm một hình elip được định dạng tốt hơn vào một slide, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Ellipse bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection).
- Đặt loại Fill của Ellipse thành Solid.
- Đặt màu của Ellipse bằng thuộc tính SolidFillColor.Color được cung cấp bởi đối tượng [FillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FillFormat) liên kết với đối tượng [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape).
- Đặt màu của các đường viền của Ellipse.
- Đặt độ rộng của các đường viền của Ellipse.
- Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình elip được định dạng vào slide đầu tiên của bản trình chiếu.

```javascript
// Tạo một thể hiện của lớp Presentation đại diện cho PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm AutoShape loại ellipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Áp dụng một số định dạng cho hình elip
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Áp dụng một số định dạng cho đường viền của Ellipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Ghi tệp PPTX ra đĩa
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **Câu hỏi thường gặp**

**Làm thế nào để đặt vị trí và kích thước chính xác của một hình elip so với đơn vị của slide?**

Các tọa độ và kích thước thường được chỉ định **theo điểm**. Để có kết quả dự đoán được, hãy dựa vào kích thước slide và chuyển đổi milimét hoặc inches cần thiết sang điểm trước khi gán giá trị.

**Làm thế nào để đặt một hình elip lên trên hoặc dưới các đối tượng khác (kiểm soát thứ tự chồng lên nhau)?**

Điều chỉnh thứ tự vẽ của đối tượng bằng cách đưa nó lên phía trước hoặc gửi nó xuống phía sau. Điều này cho phép hình elip chồng lên các đối tượng khác hoặc hiển thị những đối tượng nằm dưới nó.

**Làm thế nào để tạo hoạt ảnh cho việc xuất hiện hoặc nhấn mạnh của một hình elip?**

[Apply](/slides/vi/nodejs-java/shape-animation/) các hiệu ứng entrance, emphasis hoặc exit cho hình dạng, và cấu hình trigger và thời gian để điều phối khi nào và cách hoạt ảnh được phát.