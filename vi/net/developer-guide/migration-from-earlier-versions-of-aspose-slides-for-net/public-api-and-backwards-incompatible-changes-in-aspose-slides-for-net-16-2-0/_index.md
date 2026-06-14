---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 16.2.0
linktitle: Aspose.Slides cho .NET 16.2.0
type: docs
weight: 230
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để chuyển đổi mượt mà các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 
Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [đã thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) hoặc [đã xoá](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 16.2.0.
{{% /alert %}} 
## **Thay đổi API công cộng**
#### **Thuộc tính UpdateDateTimeFields và UpdateSlideNumberFields đã bị xóa**
Các thuộc tính UpdateDateTimeFields và UpdateSlideNumberFields đã bị xóa khỏi lớp Aspose.Slides.Presentation và giao diện Aspose.Slides.IPresentation.
Thuộc tính Text của các lớp Aspose.Slides.TextFrame, Paragraph, Portion và các giao diện Aspose.Slides.ITextFrame, IParagraph, IPortion trả về văn bản với các trường "datetime" đã được cập nhật.
Ngoài ra, các thuộc tính Presentation.DocumentProperties.CreatedTime, LastSavedTime và LastPrinted trở thành chỉ đọc.
#### **Enum Slides.Charts.CategoryAxisType đã được chuyển sang công cộng**
Được sử dụng trong các thuộc tính IAxis.CategoryAxisType và Axis.CategoryAxisType để xác định loại trục danh mục.
CategoryAxisType.Auto - loại trục danh mục sẽ được xác định tự động trong quá trình tuần tự hoá (hiện hành vi này chưa được triển khai)
CategoryAxisType.Text - loại trục danh mục là Text
CategoryAxisType.Date - loại trục danh mục là DateTime
#### **Trích xuất Văn bản Nhanh**
The new static method GetPresentationText has been added to Presentation class. There are two overloads for this method:
``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 
Tham số enum ExtractionMode chỉ ra chế độ tổ chức đầu ra của kết quả văn bản và có thể được đặt thành các giá trị sau:
Unarranged - Văn bản thô mà không quan tâm đến vị trí trên slide
Arranged - Văn bản được sắp xếp theo cùng thứ tự như trên slide
Chế độ Unarranged có thể được sử dụng khi tốc độ là ưu tiên, nó nhanh hơn chế độ Arranged.
PresentationText đại diện cho văn bản thô được trích xuất từ bản trình chiếu. Nó chứa thuộc tính SlidesText từ không gian tên Aspose.Slides.Util, trả về một mảng các đối tượng ISlideText. Mỗi đối tượng đại diện cho văn bản trên slide tương ứng. Đối tượng ISlideText có các thuộc tính sau:
ISlideText.Text - Văn bản trên các hình dạng của slide
ISlideText.MasterText - Văn bản trên các hình dạng của trang master cho slide này
ISlideText.LayoutText - Văn bản trên các hình dạng của trang bố cục cho slide này
ISlideText.NotesText - Văn bản trên các hình dạng của trang ghi chú cho slide này
Cũng có một lớp SlideText triển khai giao diện ISlideText.
The new API can be used like this:
``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Giao diện ILegacyDiagram và lớp LegacyDiagram đã được thêm**
Interface Aspose.Slides.ILegacyDiagram và lớp Aspose.Slides.LegacyDiagram đã được thêm để đại diện cho đối tượng sơ đồ kế thừa. Đối tượng sơ đồ kế thừa là định dạng cũ của sơ đồ từ PowerPoint 97-2003.
Lớp mới cung cấp các phương thức để chuyển đổi sơ đồ kế thừa sang đối tượng SmartArt hiện đại có thể chỉnh sửa hoặc sang GroupShape có thể chỉnh sửa.
#### **Thành viên Enum Aspose.Slides.TextAlignment mới được thêm (JustifyLow)**
Đã thêm một thành viên mới vào enum TextAlignment: JustifyLow - Căn chỉnh Kashida thấp.
#### **Thuộc tính mới cho Aspose.Slides.IOleObjectFrame và OleObjectFrame**
Đã thêm các thuộc tính mới vào giao diện IOleObjectFrame và lớp OleObjectFrame triển khai giao diện này. Các thuộc tính này được sử dụng để cung cấp thông tin về một đối tượng được nhúng vào bản trình chiếu:
EmbeddedFileExtension - Trả về phần mở rộng tệp cho đối tượng nhúng hiện tại hoặc chuỗi rỗng nếu đối tượng không phải là liên kết
EmbeddedFileLabel - Trả về tên tệp của đối tượng OLE được nhúng
EmbeddedFileName - Trả về đường dẫn của đối tượng OLE được nhúng
#### **Thuộc tính CategoryAxisType mới đã được thêm vào các lớp IAxis và Axis**
Thuộc tính CategoryAxisType xác định loại trục danh mục.
``` csharp

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
#### **Thuộc tính ShowLabelAsDataCallout mới đã được thêm vào lớp DataLabelFormat và giao diện IDataLabelFormat**
Thuộc tính ShowLabelAsDataCallout xác định liệu nhãn dữ liệu của biểu đồ được chỉ định sẽ được hiển thị dưới dạng chú thích dữ liệu hay là nhãn dữ liệu.
``` csharp

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
Thuộc tính bool DrawSlidesFrame đã được thêm vào các giao diện Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions và các lớp liên quan Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions. Khung đen quanh mỗi slide sẽ được vẽ nếu thuộc tính này được đặt là 'true'.
``` csharp

 using (Presentation pres = new Presentation("input.pptx"))
{
    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });
}
```