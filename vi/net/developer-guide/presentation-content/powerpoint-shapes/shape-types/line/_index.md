---
title: Thêm Hình Dạng Đường vào Bản Trình Bày trong .NET
linktitle: Đường
type: docs
weight: 50
url: /vi/net/Line/
keywords:
- đường
- tạo đường
- thêm đường
- đường thẳng
- cấu hình đường
- tùy chỉnh đường
- kiểu gạch chấm
- đầu mũi tên
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thao tác định dạng đường trong bản trình bày PowerPoint với Aspose.Slides cho .NET. Khám phá các thuộc tính, phương thức và ví dụ."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các hình dạng đường vào các slide PowerPoint một cách lập trình. Bài viết này trình bày cách tạo một đường thẳng đơn giản và cách tùy chỉnh đường sao cho nó hiển thị dưới dạng mũi tên.

Bạn sẽ học cách thêm một hình dạng đường vào slide, điều chỉnh giao diện của nó và lưu bản trình bày đã cập nhật. Các ví dụ tập trung vào các cài đặt định dạng đường thực tế như kiểu, độ rộng, mẫu dash, tùy chọn đầu mũi tên và màu nền.

## **Tạo một Đường Thẳng Thuần**
Để thêm một đường thẳng đơn giản vào slide đã chọn trong bản trình bày, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class.
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Line bằng phương thức [AddAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/methods/addautoshape/index) được cung cấp bởi đối tượng Shapes.
- Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bản trình bày.

```c#
// Khởi tạo lớp PresentationEx đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{
    // Lấy slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Thêm một autoshape loại line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Ghi PPTX ra đĩa
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Tạo Đường Dạng Mũi Tên**
Aspose.Slides for .NET cũng cho phép các nhà phát triển cấu hình một số thuộc tính của đường để làm cho nó trông hấp dẫn hơn. Hãy thử cấu hình một vài thuộc tính của đường để nó giống như một mũi tên. Vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/vi/aspose.slides/)[](http://www.aspose.com/api/net/slides/vi/aspose.slides/).
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một AutoShape loại Line bằng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes.
- Đặt Line Style thành một trong các kiểu được Aspose.Slides for .NET cung cấp.
- Đặt Width của đường.
- Đặt [Dash Style](https://reference.aspose.com/slides/vi/net/aspose.slides/linedashstyle) của đường thành một trong các kiểu do Aspose.Slides for .NET cung cấp.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/net/aspose.slides/linearrowheadstyle) và Length của điểm bắt đầu của đường.
- Đặt Arrow Head Style và Length của điểm kết thúc của đường.
- Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

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

    // Ghi PPTX ra đĩa
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Tôi có thể chuyển một đường thông thường thành connector để nó "bắt" vào các hình dạng không?**

Không. Một đường thông thường (một [AutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) loại [Line](https://reference.aspose.com/slides/vi/net/aspose.slides/shapetype/)) sẽ không tự động trở thành connector. Để làm cho nó bắt vào các hình dạng, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/net/aspose.slides/connector/) chuyên dụng và các [API tương ứng](/slides/vi/net/connector/) cho việc kết nối.

**Nếu thuộc tính của một đường được kế thừa từ theme và khó xác định giá trị cuối cùng, tôi nên làm gì?**

[Đọc các thuộc tính hiệu quả](/slides/vi/net/shape-effective-properties/) thông qua các giao diện [ILineFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ilinefillformateffectivedata/) — các giao diện này đã tính đến việc kế thừa và các kiểu theme.

**Tôi có thể khóa một đường để ngăn chỉnh sửa (di chuyển, thay đổi kích thước) không?**

Có. Các Shapes cung cấp [đối tượng khóa](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/autoshapelock/) cho phép bạn [ngăn các thao tác chỉnh sửa](/slides/vi/net/applying-protection-to-presentation/).