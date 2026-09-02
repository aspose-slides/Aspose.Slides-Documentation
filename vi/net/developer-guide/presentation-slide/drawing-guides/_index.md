---
title: Quản lý Đường Dẫn Vẽ trong Bản Trình Chiếu trên .NET
linktitle: Đường Dẫn Vẽ
type: docs
weight: 85
url: /vi/net/drawing-guides/
keywords:
- đường dẫn vẽ
- đường dẫn ngang
- đường dẫn dọc
- đường dẫn căn chỉnh
- chế độ xem slide
- slide master
- slide layout
- notes master
- handout master
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Thêm, truy cập và xóa các đường dẫn vẽ ngang và dọc trong bản trình chiếu PowerPoint bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Đường dẫn vẽ là các đường ngang và dọc có thể điều chỉnh, giúp người dùng căn chỉnh các hình dạng một cách nhất quán khi chỉnh sửa bản thuyết trình trong PowerPoint. Chúng đặc biệt hữu ích khi một ứng dụng tạo ra bản thuyết trình sẽ được tinh chỉnh thủ công sau đó: ứng dụng có thể lưu các công cụ căn chỉnh mà tác giả nên tuân theo khi thêm hoặc di chuyển nội dung.

Đường dẫn vẽ là công cụ hỗ trợ chỉnh sửa, không phải nội dung slide. Chúng không xuất hiện trong buổi trình chiếu hoặc đầu ra đã render. Aspose.Slides for .NET cung cấp chúng thông qua giao diện [IDrawingGuidesCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/idrawingguidescollection/) . Một đường dẫn được đại diện bằng [IDrawingGuide](https://reference.aspose.com/slides/vi/net/aspose.slides/idrawingguide/) và có hướng, vị trí và màu sắc.

Vị trí được đo bằng điểm từ góc trên‑trái của slide hoặc master tương ứng. Đường dọc sử dụng tọa độ ngang, thường nằm trong khoảng từ 0 đến độ rộng của slide. Đường ngang sử dụng tọa độ dọc, thường nằm trong khoảng từ 0 đến độ cao của slide.

## **Thêm Đường Dẫn Vào Chế Độ Xem Slide**

Sử dụng [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/vi/net/aspose.slides/icommonslideviewproperties/drawingguides/) để quản lý các đường dẫn hiển thị khi chỉnh sửa các slide bình thường. Gọi [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/vi/net/aspose.slides/idrawingguidescollection/add/) với giá trị [Orientation](https://reference.aspose.com/slides/vi/net/aspose.slides/orientation/) và vị trí tính bằng điểm.

Ví dụ sau thêm một đường dọc ở phía bên phải của trung tâm slide và một đường ngang bên dưới nó:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Truy Cập Đường Dẫn Vẽ**

Thuộc tính và chỉ mục [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/vi/net/aspose.slides/idrawingguidescollection/count/) cung cấp quyền truy cập vào các đường dẫn hiện có. Các thuộc tính [IDrawingGuide.Orientation](https://reference.aspose.com/slides/vi/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/vi/net/aspose.slides/idrawingguide/position/) và [IDrawingGuide.Color](https://reference.aspose.com/slides/vi/net/aspose.slides/idrawingguide/color/) có thể được đọc hoặc thay đổi.

Ví dụ sau đọc các đường dẫn trong chế độ xem slide từ bản thuyết trình đã tạo ở trên:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Thêm Đường Dẫn Vào Slide Master và Layout**

Một slide master và mỗi slide layout của nó có thể có bộ sưu tập đường dẫn riêng. Sử dụng [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/drawingguides/) cho slide master và [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/drawingguides/) cho slide layout.

Ví dụ sau thêm một đường dọc vào slide master đầu tiên và một đường ngang vào slide layout đầu tiên:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Thêm Đường Dẫn Vào Notes và Handout Masters**

Các notes master và handout master cũng hỗ trợ các đường dẫn vẽ. Sử dụng [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/vi/net/aspose.slides/imasternotesslide/drawingguides/) và [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterhandoutslide/drawingguides/) để truy cập các bộ sưu tập của chúng. Nếu một bản thuyết trình không chứa một trong các master này, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) hoặc [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) sẽ tạo master mặc định và trả về nó.

Ví dụ sau thêm một đường ngang vào notes master và một đường dọc vào handout master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Xóa Các Đường Dẫn Vẽ**

Gọi [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides/idrawingguidescollection/clear/) để xóa mọi đường dẫn khỏi một bộ sưu tập cụ thể. Việc xóa một bộ sưu tập không ảnh hưởng tới các đường dẫn được lưu trong phạm vi khác.

Ví dụ sau xóa các đường dẫn trong chế độ xem slide và tất cả các đường dẫn trên slide master, slide layout, notes master và handout master mà không tạo các master bị thiếu:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **Câu Hỏi Thường Gặp**

**Các đường dẫn vẽ có xuất hiện trong buổi trình chiếu hoặc ảnh xuất ra không?**

Không. Đường dẫn vẽ là công cụ hỗ trợ căn chỉnh khi chỉnh sửa và không được render như nội dung bản thuyết trình.

**Có thể thêm một đường dẫn vẽ trực tiếp vào một slide bình thường riêng lẻ không?**

Các đường dẫn chỉnh sửa slide bình thường được lưu trong thuộc tính chế độ xem slide của bản thuyết trình. Các bộ sưu tập đường dẫn riêng biệt có sẵn cho slide master, slide layout, notes master và handout master.

**Đơn vị nào được sử dụng cho vị trí của đường dẫn?**

Vị trí được xác định bằng điểm, trong đó 72 điểm bằng một inch. Vị trí dọc được đo từ cạnh trái, và vị trí ngang được đo từ cạnh trên.

**Việc xóa các đường dẫn vẽ có làm mất hình dạng hoặc thay đổi nội dung slide không?**

Không. Phương thức `Clear` chỉ xóa các đường dẫn trong bộ sưu tập đã chọn. Các hình dạng và nội dung slide khác vẫn không thay đổi.