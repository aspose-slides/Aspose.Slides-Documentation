---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 14.8.0
linktitle: Aspose.Slides cho .NET 14.8.0
type: docs
weight: 100
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- phương pháp kế thừa
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [đã thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) hoặc [đã loại bỏ](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/), và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Thuộc tính đã thay đổi**
#### **Đã thêm giao diện IVbaProject, thay đổi thuộc tính Presentation.VbaProject**
Thuộc tính VbaProject của lớp Presentation đã được thay thế. Thay vì biểu diễn thô dưới dạng byte của dự án VBA, đã thêm triển khai giao diện IVbaProject mới.

Sử dụng thuộc tính IVbaProject để quản lý các dự án VBA được nhúng trong một bản trình chiếu. Bạn có thể thêm các tham chiếu dự án mới, chỉnh sửa các mô-đun hiện có và tạo mô-đun mới.

Bạn cũng có thể tạo một dự án VBA mới bằng cách sử dụng lớp VbaProject, lớp này thực hiện giao diện IVbaProject.

Ví dụ sau đây minh họa việc tạo một dự án VBA đơn giản chứa một mô-đun và thêm hai tham chiếu cần thiết vào các thư viện.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Tạo dự án VBA mới

    pres.VbaProject = new VbaProject();

    // Thêm mô-đun trống vào dự án VBA

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Đặt mã nguồn cho mô-đun

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Tạo tham chiếu đến <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Tạo tham chiếu đến Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Thêm các tham chiếu vào dự án VBA

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Ví dụ này cho thấy cách sao chép một dự án VBA từ bản trình chiếu hiện có sang bản mới.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Đã thêm giao diện, thuộc tính và các tùy chọn khai báo**
#### **Đã thêm thuộc tính Aspose.Slides.Charts.IChartSeries.Overlap**
Thuộc tính Aspose.Slides.Charts.IChartSeries.Overlap xác định mức độ chồng lấn của các thanh và cột trên biểu đồ 2D (từ -100 đến 100).

Đây không chỉ là thuộc tính của series này mà còn của tất cả các series trong nhóm series cha — đây là một phép chiếu của thuộc tính nhóm tương ứng. Vì vậy thuộc tính này là chỉ đọc.

- Sử dụng thuộc tính ParentSeriesGroup để truy cập nhóm series cha.
- Sử dụng thuộc tính ParentSeriesGroup.Overlap có thể đọc/ghi để thay đổi giá trị.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **Đã thêm thuộc tính Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
Thuộc tính Aspose.Slides.Charts.IChartSeriesGroup.Overlap xác định mức độ chồng lấn của các thanh và cột trên biểu đồ 2D (từ -100 đến 100).

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Đã thêm giá trị Enum ShapeThumbnailBounds.Appearance**
Phương pháp tạo hình thu nhỏ hình dạng này cho phép bạn tạo hình thu nhỏ trong giới hạn của cách hiển thị của nó. Nó tính đến tất cả các hiệu ứng hình dạng. Hình thu nhỏ được tạo ra bị giới hạn bởi kích thước slide.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```