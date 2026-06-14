---
title: Thêm hình dạng vào bản trình chiếu
type: docs
weight: 30
url: /vi/net/adding-shapes-to-presentation/
---
## **VSTO**
Dưới đây là đoạn mã mẫu để thêm hình dạng đường:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Để thêm một đường đơn giản vào một slide được chọn của bản trình chiếu, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp Presentation
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó
- Thêm một AutoShape loại Line bằng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes
- Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bản trình chiếu.

``` csharp

   //Khởi tạo lớp Presentation đại diện cho file PPTX

  Presentation pres = new Presentation();

  //Lấy slide đầu tiên

  ISlide slide = pres.Slides[0];

  //Thêm một AutoShape loại line

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Tải xuống mã chạy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Tải xuống mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)