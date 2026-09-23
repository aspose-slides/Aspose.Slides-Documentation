---
title: Truy xuất và Cập nhật Thuộc tính Hiển thị Bản trình chiếu trong .NET
linktitle: Thuộc tính Hiển thị
type: docs
weight: 80
url: /vi/net/presentation-view-properties/
keywords:
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- gắn thanh chia dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- phóng to mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khám phá các thuộc tính hiển thị của Aspose.Slides cho .NET để tùy chỉnh định dạng slide PPT, PPTX và ODP — điều chỉnh bố cục, mức phóng to và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: bản trình chiếu riêng, một vùng nội dung bên và một vùng nội dung ở dưới. Các thuộc tính liên quan tới việc định vị các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Thuộc tính [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/iviewproperties/properties/normalviewproperties) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình chiếu.

[INormalViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/inormalviewrestoredproperties) giao diện và các lớp con của chúng, enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/net/aspose.slides/splitterbarstatetype) đã được thêm.

## **Giới thiệu về INormalViewProperties**

Biểu thị các thuộc tính chế độ xem bình thường.

Thuộc tính **ShowOutlineIcons** xác định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Thuộc tính **SnapVerticalSplitter** xác định liệu thanh chia dọc có tự động gắn vào trạng thái thu gọn khi vùng bên đủ nhỏ không.

Thuộc tính **PreferSingleView** xác định liệu người dùng muốn xem một vùng nội dung duy nhất chiếm toàn bộ cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể hiển thị một trong các vùng nội dung trên toàn bộ cửa sổ.

Các thuộc tính **VerticalBarState** và **HorizontalBarState** chỉ định trạng thái mà thanh chia dọc hoặc ngang sẽ được hiển thị. Thanh chia ngang tách bản trình chiếu khỏi vùng nội dung phía dưới bản trình chiếu, thanh chia dọc tách bản trình chiếu khỏi vùng nội dung bên. Các giá trị có thể là: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** và **SplitterBarStateType.Restored.**

Các thuộc tính **RestoredLeft** và **RestoredTop** chỉ định kích thước của vùng bản trình chiếu trên hoặc bên trong chế độ xem bình thường, khi giá trị **SplitterBarStateType.Restored** được áp dụng cho **VerticalBarState** và **HorizontalBarState** tương ứng.

## **Về việc khôi phục INormalViewProperties**

Xác định kích thước của vùng bản trình chiếu (chiều rộng khi là con của RestoredTop, chiều cao khi là con của RestoredLeft) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu gọn hay phóng đại).

Thuộc tính **DimensionSize** chỉ định kích thước của vùng bản trình chiếu (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Thuộc tính **AutoAdjust** chỉ định liệu kích thước của vùng nội dung bên có nên tự điều chỉnh cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Ví dụ dưới đây cho thấy cách bạn có thể truy cập các thuộc tính **ViewProperties.NormalViewProperties** cho một bản trình chiếu.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Khôi phục các thuộc tính hiển thị của bản trình chiếu
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Đặt giá trị phóng to mặc định**

Aspose.Slides for .NET hiện đã hỗ trợ thiết lập giá trị phóng to mặc định cho bản trình chiếu sao cho khi mở bản trình chiếu, mức phóng to đã được đặt sẵn. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties) của một bản trình chiếu. Các thuộc tính chế độ xem slide cũng như [NotesViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/properties/notesviewproperties) có thể được thiết lập bằng mã. Trong chủ đề này, chúng ta sẽ xem một ví dụ về cách thiết lập View Properties của Presentation trong Aspose.Slides.

Để thiết lập các thuộc tính chế độ xem, hãy làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)
1. Đặt View [Properties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties) của Presentation
1. Ghi bản trình chiếu ra tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã đặt giá trị phóng to cho chế độ xem slide cũng như chế độ xem ghi chú.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Cài đặt các thuộc tính hiển thị của bản trình chiếu
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Giá trị phóng to bằng phần trăm cho chế độ xem slide
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Giá trị phóng to bằng phần trăm cho chế độ xem ghi chú 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Đặt khoảng cách lưới**

Sử dụng [Presentation.ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/viewproperties/) để truy cập các cài đặt chế độ xem toàn bộ bản trình chiếu. Thuộc tính [IViewProperties.GridSpacing](https://reference.aspose.com/slides/vi/net/aspose.slides/iviewproperties/gridspacing/) đọc hoặc thay đổi khoảng thời gian của lưới chỉnh sửa nền. Cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho một slide riêng lẻ. Khoảng cách lưới được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ sau mở một tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, đặt khoảng cách một phần tư inch và lưu kết quả.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Lưới khác với [drawing guides](/slides/vi/net/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng thời gian đều, trong khi các guide vẽ là các đường căn chỉnh ngang hoặc dọc được đặt vị trí riêng lẻ. Thêm, di chuyển hoặc xóa các guide vẽ không thay đổi khoảng cách lưới.

Cả lưới và các guide vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc trong buổi chiếu slide. Lưu khoảng cách lưới không đảm bảo rằng một trình chỉnh sửa sẽ hiển thị lưới: việc hiển thị còn tùy thuộc vào sở thích của người xem hoặc trình chỉnh sửa.

## **Hiển thị hoặc Ẩn bình luận khi mở bản trình chiếu**

Sử dụng [Presentation.ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/viewproperties/) để truy cập các cài đặt chế độ xem toàn bộ bản trình chiếu. Đọc hoặc thay đổi [IViewProperties.ShowComments](https://reference.aspose.com/slides/vi/net/aspose.slides/iviewproperties/showcomments/) để lưu một tùy chọn về việc có nên hiển thị bình luận khi bản trình chiếu mở trong PowerPoint hoặc trình chỉnh sửa tương thích khác.

Cài đặt này chỉ kiểm soát tùy chọn chế độ xem được lưu. Nó không thêm, xóa, chỉnh sửa hoặc giải quyết bình luận. Ẩn bình luận giữ nguyên nội dung, tác giả, vị trí, trả lời và trạng thái của chúng. Xem [Presentation Comments](/slides/vi/net/presentation-comments/) để biết các thao tác thay đổi bình luận.

Ví dụ sau yêu cầu một tệp `comments.pptx` hiện có chứa bình luận. Nó in ra cài đặt hiện tại về khả năng hiển thị, yêu cầu ẩn bình luận và lưu một tệp PPTX mới mà không xóa bất kỳ bình luận nào. Nó cũng đặt [IViewProperties.LastView](https://reference.aspose.com/slides/vi/net/aspose.slides/iviewproperties/lastview/) thành [ViewType.SlideView](https://reference.aspose.com/slides/vi/net/aspose.slides/viewtype/) để cấu hình chế độ chỉnh sửa ban đầu cùng với khả năng hiển thị bình luận.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Cài đặt này không quyết định liệu bình luận có được bao gồm trong các xuất PDF, HTML, hình ảnh, ghi chú hoặc tài liệu phát tay hay không. Hãy cấu hình các tùy chọn xuất riêng biệt cho từng định dạng.

## **Câu hỏi thường gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình chiếu?**

"Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định việc lưới có hiển thị hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa."

**Việc xóa các drawing guides có thay đổi khoảng cách lưới không?**

"Không. Drawing guides và khoảng cách lưới là các cài đặt độc lập. Xóa các guide không làm thay đổi khoảng cách lưới đã lưu."

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình chiếu không?**

"[View settings](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/viewproperties/) được định nghĩa ở mức bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/slideviewproperties/)), không phải cho từng phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở."

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**

"Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng tùy chọn của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính chế độ xem."

**Tôi có thể chuẩn bị một mẫu với View Properties đã được định trước để các bản trình chiếu mới mở theo cùng cách không?**

"Có. Vì [view properties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/viewproperties/) được lưu ở mức bản trình chiếu, bạn có thể nhúng chúng vào một mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình chế độ xem ban đầu."