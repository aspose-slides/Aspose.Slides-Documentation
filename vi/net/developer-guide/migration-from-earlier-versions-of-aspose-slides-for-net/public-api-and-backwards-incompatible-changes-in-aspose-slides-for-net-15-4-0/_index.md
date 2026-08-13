---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 15.4.0
linktitle: Aspose.Slides cho .NET 15.4.0
type: docs
weight: 150
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- phương pháp cũ
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển mượt mà các giải pháp bản trình bày PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác đã [được thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) hoặc [được xóa](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/), và các thay đổi khác được giới thiệu trong API Aspose.Slides cho .NET 15.4.0.

{{% /alert %}} 
## **Thay đổi API công khai**
#### **Enum OrganizationChartLayoutType đã được thêm vào**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType đại diện cho kiểu định dạng của các nút con trong biểu đồ tổ chức.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts đã được thêm vào**
Method Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts đặt các dịch chuyển mặc định không bằng không cho việc thụt lề đoạn văn và MarginLeft khi bật dấu đầu dòng (giống như PowerPoint làm khi bật dấu đầu dòng/đánh số đoạn trong đó). Nếu dấu đầu dòng bị tắt thì chỉ đặt lại thụt lề đoạn văn và MarginLeft (giống như PowerPoint làm khi tắt dấu đầu dòng/đánh số đoạn trong đó).

Xem ví dụ [tại đây](/slides/vi/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute đã được thêm vào**
Method Aspose.Slides.IConnector.Reroute định tuyến lại connector sao cho nó lấy đường ngắn nhất có thể giữa các hình nó kết nối. Để làm điều này, phương thức Reroute() có thể thay đổi StartShapeConnectionSiteIndex và EndShapeConnectionSiteIndex.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Method IPresentation.GetSlideById đã được thêm vào**
Method Aspose.Slides.IPresentation.GetSlideById(System.UInt32) trả về một Slide, MasterSlide hoặc LayoutSlide theo Id của slide.

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **Property IShape.ConnectionSiteCount đã được thêm vào**
Property Aspose.Slides.IShape.ConnectionSiteCount trả về số lượng vị trí kết nối trên hình.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArt.IsReversed đã được thêm vào**
Property Aspose.Slides.SmartArt.ISmartArt.IsReversed cho phép lấy hoặc đặt trạng thái của biểu đồ SmartArt liên quan đến (trái sang phải) LTR hoặc (phải sang trái) RTL, nếu biểu đồ hỗ trợ đảo ngược.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArt.Nodes đã được thêm vào**
Property Aspose.Slides.SmartArt.ISmartArt.Nodes trả về bộ sưu tập các nút gốc trong đối tượng SmartArt.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // chọn nút gốc thứ hai

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.IsHidden đã được thêm vào**
Property Aspose.Slides.SmartArt.ISmartArtNode.IsHidden trả về true nếu nút này là một nút ẩn trong mô hình dữ liệu.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; // trả về true

  if(hidden)

  {

    // thực hiện một số hành động hoặc thông báo

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.OrganizationChartLayout đã được thêm vào**
Property Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout cho phép lấy hoặc đặt loại biểu đồ tổ chức liên kết với nút hiện tại.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Set Method for Property ISmartArt.Layout đã được thêm vào**
Phương thức set cho thuộc tính Aspose.Slides.SmartArt.ISmartArt.Layout đã được thêm vào. Nó cho phép thay đổi loại bố cục của một biểu đồ hiện có.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Thay đổi API nhỏ**
**Đây là danh sách các thay đổi API nhỏ:**

|Enum Aspose.Slides.BevelColorMode |đã xóa, enum không được sử dụng |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |đã xóa, thuộc tính không được sử dụng |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |đã thêm |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |đã xóa |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |đã xóa vì lỗi thời |