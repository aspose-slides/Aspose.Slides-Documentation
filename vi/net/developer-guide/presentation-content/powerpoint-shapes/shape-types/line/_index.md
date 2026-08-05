---
title: Thêm Hình Dạng Đường vào Bản Trình Chiếu trong .NET
linktitle: Đường
type: docs
weight: 50
url: /vi/net/line/
keywords:
- đường
- tạo đường
- thêm đường
- đường thẳng đơn giản
- cấu hình đường
- tùy chỉnh đường
- kiểu gạch
- đầu mũi tên
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thao tác định dạng đường trong các bản trình chiếu PowerPoint với Aspose.Slides cho .NET. Khám phá các thuộc tính, phương thức và ví dụ."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các hình dạng đường vào các slide PowerPoint một cách lập trình. Bài viết này hướng dẫn cách tạo một đường thẳng đơn giản và cách tùy chỉnh đường sao cho nó hiển thị như một mũi tên.

Bạn sẽ học cách thêm một hình dạng đường vào slide, điều chỉnh giao diện trực quan của nó, và lưu bản trình chiếu đã cập nhật. Các ví dụ tập trung vào các cài đặt định dạng đường thực tế như kiểu, độ rộng, mẫu gạch, tùy chọn đầu mũi tên và màu nền.

## **Tạo một Đường Thẳng Đơn Giản**
Để thêm một đường thẳng đơn giản vào slide được chọn của bản trình chiếu, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class.
- Lấy tham chiếu đến một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Line bằng cách sử dụng phương thức [AddAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/methods/addautoshape/index) được cung cấp bởi đối tượng Shapes.
- Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bản trình chiếu.

```c#
// Khởi tạo lớp PresentationEx đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{
    // Lấy slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Thêm một autoshape loại line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Ghi PPTX vào đĩa
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Tạo một Đường Dạng Mũi Tên**
Aspose.Slides for .NET cũng cho phép các nhà phát triển cấu hình một số thuộc tính của đường để làm cho nó trông hấp dẫn hơn. Hãy thử cấu hình một vài thuộc tính của đường để nó trông như một mũi tên. Vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/vi/aspose.slides/)[](http://www.aspose.com/api/net/slides/vi/aspose.slides/).
- Lấy tham chiếu đến một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Line bằng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes.
- Đặt Line Style thành một trong các kiểu được Aspose.Slides for .NET cung cấp.
- Đặt Width (độ rộng) của đường.
- Đặt [Dash Style](https://reference.aspose.com/slides/vi/net/aspose.slides/linedashstyle) của đường thành một trong các kiểu do Aspose.Slides for .NET cung cấp.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/net/aspose.slides/linearrowheadstyle) và Length (độ dài) của điểm đầu của đường.
- Đặt Arrow Head Style và Length của điểm cuối của đường.
- Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```c#
// Khởi tạo lớp PresentationEx đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{

    // Lấy slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Thêm một autoshape loại line
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Áp dụng một số định dạng cho đường
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Ghi PPTX vào đĩa
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Tôi có thể chuyển một đường thường thành connector để nó "bám" vào các hình dạng không?**

Không. Một đường thường (một [AutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) loại [Line](https://reference.aspose.com/slides/vi/net/aspose.slides/shapetype/)) sẽ không tự động trở thành connector. Để làm cho nó bám vào các hình dạng, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/net/aspose.slides/connector/) chuyên dụng và các [API tương ứng](/slides/vi/net/connector/) để kết nối.

**Nếu các thuộc tính của đường được kế thừa từ theme và khó xác định giá trị cuối cùng, tôi nên làm gì?**

[Đọc các thuộc tính hiệu quả](/slides/vi/net/shape-effective-properties/) thông qua các giao diện [ILineFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ilinefillformateffectivedata/) — chúng đã tính đến việc kế thừa và các kiểu theme.

**Tôi có thể khóa một đường khỏi việc chỉnh sửa (di chuyển, thay đổi kích thước) không?**

Có. Các Shapes cung cấp các [đối tượng khóa](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/autoshapelock/) cho phép bạn [không cho phép các thao tác chỉnh sửa](/slides/vi/net/applying-protection-to-presentation/).