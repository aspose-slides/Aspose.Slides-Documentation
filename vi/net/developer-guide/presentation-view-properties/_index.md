---
title: Lấy và Cập nhật Thuộc tính Xem Bản trình bày trong .NET
linktitle: Thuộc tính Xem
type: docs
weight: 80
url: /vi/net/presentation-view-properties/
keywords:
- thuộc tính xem
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- đặt chốt thanh chia dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Khám phá thuộc tính xem của Aspose.Slides cho .NET để tùy chỉnh các định dạng slide PPT, PPTX và ODP — điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba khu vực nội dung: slide, một khu vực nội dung bên và một khu vực nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các khu vực nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình bày được lưu lần cuối.

Thuộc tính [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/iviewproperties/properties/normalviewproperties) đã được thêm để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình bày.  

[INormalViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/inormalviewrestoredproperties) interface và các lớp con của chúng, [SplitterBarStateType](https://reference.aspose.com/slides/vi/net/aspose.slides/splitterbarstatetype) enum đã được thêm.

## **Về INormalViewProperties**

Biểu diễn các thuộc tính chế độ xem bình thường.

Thuộc tính **ShowOutlineIcons** chỉ định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ khu vực nội dung nào của chế độ xem bình thường hay không.

Thuộc tính **SnapVerticalSplitter** chỉ định liệu thanh chia dọc có nên chốt vào trạng thái thu nhỏ khi khu vực bên đủ nhỏ.

Thuộc tính **PreferSingleView** chỉ định liệu người dùng muốn xem một khu vực nội dung duy nhất toàn cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba khu vực nội dung hay không. Nếu bật, ứng dụng có thể chọn hiển thị một trong các khu vực nội dung trên toàn cửa sổ.

Các thuộc tính **VerticalBarState** và **HorizontalBarState** chỉ định trạng thái mà thanh chia dọc hoặc ngang sẽ được hiển thị. Thanh chia ngang phân tách slide khỏi khu vực nội dung phía dưới slide, thanh chia dọc phân tách slide khỏi khu vực nội dung bên. Các giá trị có thể là: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** và **SplitterBarStateType.Restored**.

Các thuộc tính **RestoredLeft** và **RestoredTop** chỉ định kích thước của khu vực slide trên cùng hoặc bên khi **SplitterBarStateType.Restored** được áp dụng cho **VerticalBarState** và **HorizontalBarState** tương ứng.

## **Về việc Khôi phục INormalViewProperties**

Chỉ định kích thước của khu vực slide (rộng khi là con của RestoredTop, cao khi là con của RestoredLeft) của chế độ xem bình thường, khi khu vực có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng đại).

Thuộc tính **DimensionSize** chỉ định kích thước của khu vực slide (rộng khi là con của restoredTop, cao khi là con của restoredLeft).

Thuộc tính **AutoAdjust** chỉ định liệu kích thước của khu vực nội dung bên có nên bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách truy cập các thuộc tính **ViewProperties.NormalViewProperties** cho một bản trình bày.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Khôi phục các thuộc tính xem của bản trình bày
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Đặt Giá trị Thu phóng Mặc định**

Aspose.Slides for .NET hiện hỗ trợ đặt giá trị thu phóng mặc định cho bản trình bày sao cho khi bản trình bày được mở, thu phóng đã được đặt sẵn. Điều này có thể thực hiện bằng cách đặt [ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties) của một bản trình bày. Thuộc tính Slide View cũng như [NotesViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/properties/notesviewproperties) có thể được đặt thông qua mã. Trong chủ đề này, chúng ta sẽ xem một ví dụ về cách đặt Thuộc tính Xem của Presentation trong Aspose.Slides.

Để đặt các thuộc tính xem, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)
2. Đặt [Properties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties) của Presentation
3. Ghi bản trình bày ra file PPTX

Trong ví dụ dưới đây, chúng tôi đã đặt giá trị thu phóng cho chế độ xem slide cũng như chế độ xem ghi chú.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Đặt các thuộc tính xem của bản trình bày
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Giá trị thu phóng tính bằng phần trăm cho chế độ xem slide
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Giá trị thu phóng tính bằng phần trăm cho chế độ xem ghi chú 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt các cài đặt xem khác nhau cho các phần khác nhau của bản trình bày không?**

[View settings](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/viewproperties/) được định nghĩa ở mức bản trình bày ([Normal View](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/slideviewproperties/)), không phải theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính xem.

**Tôi có thể chuẩn bị một mẫu với Các Thuộc tính Xem đã định trước để các bản trình bày mới mở theo cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/viewproperties/) được lưu ở mức bản trình bày, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình xem ban đầu.