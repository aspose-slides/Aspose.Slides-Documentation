---
title: Quản lý SmartArt trong các bản trình chiếu PowerPoint bằng .NET
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/net/manage-smartart/
keywords:
- SmartArt
- văn bản SmartArt
- kiểu bố cục
- thuộc tính ẩn
- biểu đồ tổ chức
- biểu đồ tổ chức hình ảnh
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Học cách tạo và chỉnh sửa SmartArt PowerPoint với Aspose.Slides cho .NET bằng các mẫu mã C# rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo từ các nút, hình dạng nút và bố cục. Với Aspose.Slides for .NET, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức có hình ảnh.

## **Lấy Văn bản từ Đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản từ các hình dạng nút, duyệt qua [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), sau đó đọc [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) được trả về bởi [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

Ví dụ yêu cầu một bản trình chiếu có ít nhất một slide và một đối tượng SmartArt làm hình dạng đầu tiên trên slide đó. Nó in mỗi khung văn bản có sẵn ra console.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Thay đổi Kiểu Bố cục của Đối tượng SmartArt**

Bố cục SmartArt kiểm soát cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, đổi sang giá trị `BasicProcess`, và lưu bản trình chiếu. Vị trí và kích thước truyền vào [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) được đo bằng điểm. Đặt [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) để thay đổi bố cục.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Kiểm tra xem một nút SmartArt có bị ẩn hay không**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) chỉ ra liệu nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các phần tử sơ đồ nhìn thấy được.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` và kiểm tra trạng thái ẩn của nút vừa thêm. Nó in thông báo nếu nút bị ẩn và lưu sơ đồ.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Lấy hoặc Đặt Bố cục Biểu đồ Tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo phía trái, phải, hoặc cả hai bên, tùy theo [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) đã chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. Chỉ mục dựa trên số 0 chọn nút cấp cao nhất đầu tiên; các nút con của nó sử dụng cách sắp xếp đã chọn. Bản trình chiếu đã chỉnh sửa sau đó được lưu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Tạo Biểu đồ Tổ chức Hình ảnh**

Biểu đồ tổ chức hình ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có chứa chỗ giữ hình ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào slide. Ví dụ này lưu một sơ đồ có chỗ giữ hình ảnh; nó không điền hình ảnh vào các chỗ giữ.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Chuyển đổi Sơ đồ Cũ thành Nhóm Hình dạng**

Khi hiện đại hoá một bản trình chiếu hiện có, bạn có thể cần cập nhật một biểu đồ tổ chức ban đầu được tạo trong PowerPoint 97–2003. Aspose.Slides đại diện cho các sơ đồ cũ này dưới dạng đối tượng [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). Sử dụng [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) để chuyển một sơ đồ thành một nhóm các hình dạng để bạn có thể chỉnh sửa các thành phần hình ảnh riêng lẻ. Xem [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) để biết chi tiết.

Việc chuyển đổi sẽ thêm một nhóm mới vào bộ sưu tập hình dạng mà không xóa sơ đồ gốc. Sau khi chuyển đổi thành công, hãy xóa bản gốc bằng [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) để tránh nội dung trùng lặp. Thu thập các sơ đồ cũ vào một mảng trước khi chuyển đổi để việc thêm và xóa hình dạng không làm gián đoạn quá trình lặp.

Ví dụ sau mở một bản trình chiếu, tìm kiếm mọi slide, chuyển các sơ đồ thành nhóm các hình dạng, và lưu bản trình chiếu đã cập nhật dưới dạng PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

Bản trình chiếu đã lưu chứa các nhóm hình dạng có thể chỉnh sửa thay cho các sơ đồ cũ đã chuyển đổi, không còn sơ đồ gốc nào còn lại bên cạnh chúng. Mở tệp PPTX trong PowerPoint để chỉnh sửa các thành phần riêng lẻ trong mỗi nhóm, chẳng hạn như văn bản, màu nền hoặc vị trí của chúng.

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ lật hoặc đảo ngược cho các ngôn ngữ RTL không?**

Đúng. Thuộc tính [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) chuyển hướng sơ đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ việc đảo ngược.

**Làm thế nào tôi có thể sao chép SmartArt sang cùng một slide hoặc sang bản trình chiếu khác trong khi vẫn giữ định dạng?**

Bạn có thể [clone the SmartArt shape](/slides/vi/net/shape-manipulations/) bằng [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) hoặc [clone the whole slide](/slides/vi/net/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm thế nào tôi có thể hiển thị SmartArt dưới dạng ảnh raster để xem trước hoặc xuất ra web?**

[Render the slide](/slides/vi/net/convert-powerpoint-to-png/) hoặc toàn bộ bản trình chiếu sang PNG hoặc JPEG. SmartArt được hiển thị như một phần của slide.

**Làm thế nào tôi có thể tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều đối tượng?**

Đặt một giá trị [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) hoặc [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) đặc trưng trên hình dạng SmartArt, tìm kiếm giá trị đó trong [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), rồi kiểm tra xem hình dạng khớp có phải là [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/) hay không.