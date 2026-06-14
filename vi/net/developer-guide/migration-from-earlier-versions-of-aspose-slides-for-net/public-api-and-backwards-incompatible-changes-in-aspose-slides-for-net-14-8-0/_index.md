---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 14.8.0
linktitle: Aspose.Slides cho .NET 14.8.0
type: docs
weight: 100
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- di chuyển
- mã legacy
- mã hiện đại
- cách tiếp cận legacy
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây lỗi trong Aspose.Slides cho .NET để dễ dàng di chuyển các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác [đã thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) hoặc [đã xóa](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Thay đổi API công cộng**
### **Thuộc tính đã thay đổi**
#### **Đã thêm giao diện IVbaProject, Đã thay đổi thuộc tính Presentation.VbaProject**
Thuộc tính VbaProject của lớp Presentation đã được thay thế. Thay vì h3. Thêm giao diện, thuộc tính và tùy chọn liệt kê, kiểu biểu diễn byte thô của dự án VBA, đã được thêm triển khai giao diện IVbaProject mới.

Sử dụng thuộc tính IVbaProject để quản lý các dự án VBA được nhúng trong một bản trình chiếu. Bạn có thể thêm các tham chiếu dự án mới, chỉnh sửa các mô-đun hiện có và tạo các mô-đun mới.

Ngoài ra, bạn có thể tạo một dự án VBA mới bằng cách sử dụng lớp VbaProject, lớp này thực thi giao diện IVbaProject.

Ví dụ sau cho thấy cách tạo một dự án VBA đơn giản chứa một mô-đun và thêm hai tham chiếu cần thiết vào các thư viện.

``` csharp

    using (Presentation pres = new Presentation())
    {
        // Tạo dự án VBA mới
        pres.VbaProject = new VbaProject();

        // Thêm mô-đun rỗng vào dự án VBA
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

Ví dụ này cho thấy cách sao chép một dự án VBA từ bản trình chiếu hiện có sang bản trình chiếu mới.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Đã thêm giao diện, thuộc tính và tùy chọn liệt kê**
#### **Đã thêm thuộc tính Aspose.Slides.Charts.IChartSeries.Overlap**
Thuộc tính Aspose.Slides.Charts.IChartSeries.Overlap xác định mức độ chồng lấn của các thanh và cột trên biểu đồ 2D (có giá trị từ -100 đến 100).

Đây là thuộc tính không chỉ áp dụng cho chuỗi này mà cho tất cả các chuỗi trong nhóm chuỗi cha - nó là một phép chiếu của thuộc tính nhóm tương ứng. Do đó, thuộc tính này chỉ đọc.

- Sử dụng thuộc tính ParentSeriesGroup để truy cập vào nhóm chuỗi cha.
- Sử dụng thuộc tính ParentSeriesGroup.Overlap để đọc/ghi và thay đổi giá trị.

``` csharp

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



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Đã thêm giá trị enum ShapeThumbnailBounds.Appearance**
Phương pháp tạo thumbnail hình dạng này cho phép bạn tạo một thumbnail hình dạng trong giới hạn của diện mạo của nó. Nó tính đến tất cả các hiệu ứng hình dạng. Thumbnail hình dạng được tạo ra bị giới hạn bởi giới hạn của slide.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}
```