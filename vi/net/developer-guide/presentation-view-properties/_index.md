---
title: Truy xuất và Cập nhật Thuộc tính Hiển thị Bản trình chiếu trong .NET
linktitle: Thuộc tính Hiển thị
type: docs
weight: 80
url: /vi/net/presentation-view-properties/
keywords:
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung dàn ý
- biểu tượng dàn ý
- bắt dọc bộ chia
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho .NET để cấu hình bố cục chế độ xem bình thường, thu phóng slide và ghi chú, khoảng cách lưới và khả năng hiển thị bình luận trong các bản trình chiếu PowerPoint."
---
## **Giới thiệu**

Trong chế độ xem bình thường của PowerPoint, slide xuất hiện giữa một khung bên cho hình thu nhỏ hoặc dàn ý và một khung ghi chú phía dưới. Aspose.Slides for .NET cung cấp các tùy chọn chỉnh sửa đã lưu của bản trình chiếu thông qua [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Các tùy chọn này bao gồm bố cục khung, mức thu phóng, khoảng cách lưới và khả năng hiển thị bình luận.

## **Về INormalViewProperties**

Sử dụng [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) để truy cập giao diện [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) kiểm soát việc hiển thị biểu tượng bên cạnh tiêu đề slide trong dàn ý. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) cho phép khung bên bám vào trạng thái thu nhỏ khi người dùng thu hẹp nó. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) cho biết sở thích hiển thị một khung trong cửa sổ đầy đủ.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) kiểm soát thanh chia giữa khung bên và slide. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) kiểm soát thanh chia phía trên khung ghi chú. Cả hai chấp nhận một giá trị [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) là `Minimized`, `Maximized`, hoặc `Restored`.

## **Về việc Khôi phục INormalViewProperties**

Khi một thanh chia được khôi phục, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) cung cấp kích thước đã lưu của khung bên và [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) cung cấp kích thước đã lưu của khu vực slide phía trên. Cả hai đều hiển thị [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). Thuộc tính [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) của nó chấp nhận phần trăm từ 0 đến 100, và [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) kiểm soát việc trình chỉnh sửa điều chỉnh kích thước khi cửa sổ được thay đổi kích thước.

Ví dụ này cập nhật một bản trình chiếu hiện có. Nó khôi phục thanh chia ngang, đặt [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) thành 80% với tính năng tự động điều chỉnh được bật, và phóng to thanh chia dọc. Nó cũng bật [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) cho chế độ xem dàn ý.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```
## **Đặt Giá Trị Thu Phóng Mặc Định**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) và [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) lưu các cài đặt thu phóng riêng biệt cho trình chỉnh sửa. Những cài đặt này không ảnh hưởng đến kích thước slide, phát trình chiếu, hoặc độ phân giải xuất hình ảnh.

Ví dụ này mở một bản trình chiếu hiện có và bật [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) để vừa slide với cửa sổ chỉnh sửa. Đối với trang ghi chú, nó tắt việc thu phóng tự động và đặt [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) ở mức thu phóng cố định 80%.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```
## **Đặt Khoảng Cách Lưới**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) đặt khoảng cách giữa các dòng lưới chỉnh sửa trong toàn bộ bản trình chiếu. Nó nhận giá trị dương tính bằng điểm, với 72 điểm một inch. Ví dụ này in ra khoảng cách hiện tại trong một bản trình chiếu hiện có và lưu một lưới một phần tư inch bằng cách đặt khoảng cách thành 18 điểm.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Lưới lặp lại với khoảng cách cố định. [Hướng dẫn vẽ](/slides/vi/net/drawing-guides/) đánh dấu các vị trí ngang hoặc dọc riêng lẻ. Cả hai đều là công cụ hỗ trợ chỉnh sửa và chỉ xuất hiện trong các trình chỉnh sửa hiển thị chúng. Trình chiếu và xuất ra PDF, hình ảnh, hoặc SVG không bao gồm chúng.

## **Hiển Thị hoặc Ẩn Bình Luận Khi Mở Bản Trình Chiếu**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) lưu một tùy chọn mà các trình chỉnh sửa tương thích sử dụng khi mở bản trình chiếu. Đối với một bản trình chiếu hiện có có bình luận, ví dụ này in ra thiết lập hiện tại và lưu một bản sao với bình luận ẩn. Nó cũng đặt [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) thành [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) để bản sao mở ở chế độ xem slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Việc ẩn bình luận giữ lại nội dung, tác giả, vị trí, phản hồi và trạng thái của chúng. Để thay đổi các bình luận, xem [Bình luận Bản Trình Chiếu](/slides/vi/net/presentation-comments/). Cài đặt xuất quyết định việc bình luận có xuất hiện trong PDF, HTML, hình ảnh, ghi chú, hoặc tài liệu phát tay hay không.

## **Câu hỏi thường gặp**

**Tại sao lưới bị ẩn khi tôi mở lại bản trình chiếu?**

Bản trình chiếu lưu khoảng cách lưới. Để xem lưới, bật tính năng hiển thị lưới trong trình chỉnh sửa.

**Việc xóa hướng dẫn vẽ có thay đổi khoảng cách lưới không?**

Không. Thêm, di chuyển hoặc xóa một hướng dẫn không làm thay đổi khoảng cách lưới.

**Các phần khác nhau của bản trình chiếu có thể có cài đặt xem khác nhau không?**

Không. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) áp dụng cho toàn bộ bản trình chiếu.

**Tôi có thể lưu các cài đặt xem khác nhau cho các người dùng khác nhau không?**

Tệp lưu một bộ thuộc tính xem cho tất cả mọi người. Trình chỉnh sửa cũng có thể áp dụng các tùy chỉnh cục bộ của người dùng.

**Tôi có thể lưu cài đặt xem trong mẫu không?**

Có. Các bản trình chiếu được tạo từ mẫu sẽ kế thừa các cài đặt xem đã lưu của mẫu.