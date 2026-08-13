---
title: Công khai API và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 16.2.0
linktitle: Aspose.Slides cho .NET 16.2.0
type: docs
weight: 230
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- cách tiếp cận cũ
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây lỗi trong Aspose.Slides cho .NET để di chuyển mượt mà các giải pháp bản trình bày PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thay đổi khác [added](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) hoặc [removed](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) đã được giới thiệu trong API Aspose.Slides for .NET 16.2.0.

{{% /alert %}} 
## **Thay đổi API công cộng**
#### **Thuộc tính UpdateDateTimeFields và UpdateSlideNumberFields đã bị loại bỏ**
Thuộc tính UpdateDateTimeFields và UpdateSlideNumberFields đã bị loại bỏ khỏi lớp Aspose.Slides.Presentation và giao diện Aspose.Slides.IPresentation.  
Thuộc tính Text của các lớp Aspose.Slides.TextFrame, Paragraph, Portion và các giao diện Aspose.Slides.ITextFrame, IParagraph, IPortion trả về văn bản với các trường "datetime" đã được cập nhật.  
Ngoài ra, các thuộc tính Presentation.DocumentProperties.CreatedTime, LastSavedTime và LastPrinted trở thành chỉ đọc.

#### **Enum Slides.Charts.CategoryAxisType đã được chuyển sang Public**
Được sử dụng trong các thuộc tính IAxis.CategoryAxisType và Axis.CategoryAxisType để xác định loại trục danh mục.  
- CategoryAxisType.Auto – loại trục danh mục sẽ được xác định tự động trong quá trình tuần tự hoá (hiện chưa được triển khai)  
- CategoryAxisType.Text – loại trục danh mục là Text  
- CategoryAxisType.Date – loại trục danh mục là DateTime  

#### **Trích xuất Văn bản Nhanh**
Phương thức tĩnh mới GetPresentationText đã được thêm vào lớp Presentation. Có hai overload cho phương thức này:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Tham số enum ExtractionMode cho biết cách tổ chức đầu ra của kết quả văn bản và có thể đặt thành các giá trị sau:  
- Unarranged – Văn bản thô mà không quan tâm đến vị trí trên slide  
- Arranged – Văn bản được sắp xếp theo thứ tự giống như trên slide  

Chế độ Unarranged có thể được sử dụng khi tốc độ là yếu tố quan trọng, nhanh hơn chế độ Arranged.  

PresentationText đại diện cho văn bản thô được trích xuất từ bản trình bày. Nó chứa thuộc tính SlidesText từ namespace Aspose.Slides.Util, trả về một mảng các đối tượng ISlideText. Mỗi đối tượng đại diện cho văn bản trên slide tương ứng. Đối tượng ISlideText có các thuộc tính sau:

- ISlideText.Text – Văn bản trên các shape của slide  
- ISlideText.MasterText – Văn bản trên các shape của master page cho slide này  
- ISlideText.LayoutText – Văn bản trên các shape của layout page cho slide này  
- ISlideText.NotesText – Văn bản trên các shape của notes page cho slide này  

Cũng có lớp SlideText triển khai giao diện ISlideText.

API mới có thể được sử dụng như sau:

``` csharp
using System;
using Aspose.Slides;

// Trích xuất văn bản mà không quan tâm đến vị trí của nó trên slide (chế độ nhanh nhất).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Trích xuất văn bản được sắp xếp theo cùng thứ tự như trên slide.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 

#### **Giao diện ILegacyDiagram và lớp LegacyDiagram đã được thêm**
Giao diện Aspose.Slides.ILegacyDiagram và lớp Aspose.Slides.LegacyDiagram được thêm để đại diện cho đối tượng sơ đồ legacy. Đối tượng sơ đồ legacy là định dạng cũ của các sơ đồ từ PowerPoint 97-2003.  
Lớp mới cung cấp các phương thức để chuyển đổi sơ đồ legacy sang đối tượng SmartArt có thể chỉnh sửa hiện đại hoặc sang GroupShape có thể chỉnh sửa.

#### **Thêm thành viên Enum Aspose.Slides.TextAlignment (JustifyLow)**
Một thành viên mới của enum TextAlignment đã được thêm:  
- JustifyLow – Canh đều Kashida thấp.

#### **Thuộc tính mới cho Aspose.Slides.IOleObjectFrame và OleObjectFrame**
Các thuộc tính mới đã được thêm vào giao diện IOleObjectFrame và lớp OleObjectFrame triển khai giao diện này. Các thuộc tính này dùng để cung cấp thông tin về đối tượng được nhúng vào bản trình bày:  
- EmbeddedFileExtension – Trả về phần mở rộng tệp cho đối tượng nhúng hiện tại hoặc chuỗi rỗng nếu đối tượng không phải là liên kết  
- EmbeddedFileLabel – Trả về tên tệp của đối tượng OLE được nhúng  
- EmbeddedFileName – Trả về đường dẫn của đối tượng OLE được nhúng

#### **Thuộc tính CategoryAxisType đã được thêm vào các lớp IAxis và Axis**
Thuộc tính CategoryAxisType xác định loại trục danh mục.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

using (Presentation pres = new Presentation(sourcePptxFileName))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;

    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

    pres.Save(pptxOutPath, SaveFormat.Pptx);
}
``` 

#### **Thuộc tính ShowLabelAsDataCallout đã được thêm vào lớp DataLabelFormat và giao diện IDataLabelFormat**
Thuộc tính ShowLabelAsDataCallout xác định liệu nhãn dữ liệu của biểu đồ được chỉ định có được hiển thị dưới dạng callout dữ liệu hay dưới dạng nhãn dữ liệu.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

    pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 

#### **Thuộc tính DrawSlidesFrame đã được thêm vào PdfOptions và XpsOptions**
Thuộc tính kiểu boolean DrawSlidesFrame đã được thêm vào các giao diện Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions và vào các lớp liên quan Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.  
Khung đen quanh mỗi slide sẽ được vẽ nếu thuộc tính này được đặt là 'true'.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```