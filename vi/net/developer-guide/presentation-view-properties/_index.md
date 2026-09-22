---
title: Truy xuất và Cập nhật Thuộc tính chế độ xem Bài thuyết trình trong .NET
linktitle: Thuộc tính chế độ xem
type: docs
weight: 80
url: /vi/net/presentation-view-properties/
keywords:
- thuộc tính chế độ xem
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
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá các thuộc tính chế độ xem của Aspose.Slides for .NET để tùy chỉnh định dạng slide PPT, PPTX và ODP — điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: chính slide, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính liên quan tới vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái hiển thị vào tệp, để khi mở lại, chế độ xem vẫn ở trạng thái giống như khi bài thuyết trình được lưu lần cuối.

Thuộc tính [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/iviewproperties/properties/normalviewproperties) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bài thuyết trình. 

Các giao diện [INormalViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/inormalviewrestoredproperties) và các lớp con của chúng, cũng như enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/net/aspose.slides/splitterbarstatetype) đã được thêm.

## **Về INormalViewProperties**

Đại diện cho các thuộc tính chế độ xem bình thường.

Thuộc tính **ShowOutlineIcons** chỉ định liệu ứng dụng có hiển thị các biểu tượng khi hiển thị nội dung phác thảo trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Thuộc tính **SnapVerticalSplitter** chỉ định liệu thanh chia dọc có tự động chuyển tới trạng thái thu nhỏ khi vùng bên đủ nhỏ hay không.

Thuộc tính **PreferSingleView** chỉ định liệu người dùng muốn xem một vùng nội dung duy nhất toàn màn hình thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các thuộc tính **VerticalBarState** và **HorizontalBarState** chỉ định trạng thái mà thanh chia ngang hoặc dọc sẽ hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung bên dưới slide, thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** và **SplitterBarStateType.Restored**.

Các thuộc tính **RestoredLeft** và **RestoredTop** chỉ định kích thước của vùng slide trên hoặc bên trong chế độ xem bình thường, khi giá trị **SplitterBarStateType.Restored** được áp dụng cho **VerticalBarState** và **HorizontalBarState** tương ứng.

## **Về việc khôi phục INormalViewProperties** 

Xác định kích thước của vùng slide (chiều rộng khi là con của RestoredTop, chiều cao khi là con của RestoredLeft) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng to). 

Thuộc tính **DimensionSize** chỉ định kích thước của vùng slide (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Thuộc tính **AutoAdjust** chỉ định liệu kích thước của vùng nội dung bên có nên bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Ví dụ dưới đây cho thấy cách bạn có thể truy cập các thuộc tính **ViewProperties.NormalViewProperties** cho một bài thuyết trình.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Khôi phục các thuộc tính chế độ xem của bài thuyết trình
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Đặt giá trị thu phóng mặc định**

Aspose.Slides for .NET hiện hỗ trợ thiết lập giá trị thu phóng mặc định cho bài thuyết trình sao cho khi mở bài thuyết trình, mức thu phóng đã được đặt sẵn. Điều này có thể thực hiện bằng cách đặt [ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties) của một bài thuyết trình. Các Thuộc tính chế độ xem Slide cũng như [NotesViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/properties/notesviewproperties) có thể được đặt bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách đặt Thuộc tính chế độ xem cho Presentation trong Aspose.Slides.

Để đặt các thuộc tính chế độ xem, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) 
1. Đặt [Properties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties) của Presentation 
1. Ghi bài thuyết trình ra tệp PPTX 

Trong ví dụ dưới đây, chúng tôi đã đặt giá trị thu phóng cho chế độ xem slide cũng như chế độ xem ghi chú.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Đặt các thuộc tính chế độ xem của bài thuyết trình
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Giá trị thu phóng dưới dạng phần trăm cho chế độ xem slide
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Giá trị thu phóng dưới dạng phần trăm cho chế độ xem ghi chú 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Đặt khoảng cách lưới**

Sử dụng [Presentation.ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/viewproperties/) để truy cập các cài đặt chế độ xem toàn bộ bài thuyết trình. Thuộc tính [IViewProperties.GridSpacing](https://reference.aspose.com/slides/vi/net/aspose.slides/iviewproperties/gridspacing/) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền. Cài đặt này áp dụng cho toàn bộ bài thuyết trình, không phải cho một slide riêng lẻ. Khoảng cách lưới được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, như yêu cầu trong tài liệu API.

Ví dụ sau mở một tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, thiết lập khoảng cách một phần tư inch và lưu kết quả.

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

Lưới khác với [drawing guides](/slides/vi/net/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng thời gian đều, trong khi drawing guides là các đường hướng ngang hoặc dọc được đặt vị trí riêng lẻ. Thêm, di chuyển hoặc xóa drawing guides không thay đổi khoảng cách lưới.

Cả lưới và drawing guides đều là công cụ hỗ trợ chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc trình chiếu. Lưu khoảng cách lưới không đảm bảo rằng một trình chỉnh sửa sẽ hiển thị lưới: khả năng hiển thị còn phụ thuộc vào tùy chọn của người xem hoặc trình chỉnh sửa.

## **Câu hỏi thường gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bài thuyết trình?**

Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định có hiển thị lưới hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Việc xóa drawing guides có thay đổi khoảng cách lưới không?**

Không. Drawing guides và khoảng cách lưới là các cài đặt độc lập. Xóa guides không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bài thuyết trình không?**

Các [View settings](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/viewproperties/) được định nghĩa ở mức độ bài thuyết trình ([Normal View](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/slideviewproperties/)), không theo từng phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định nghĩa trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng tùy chọn người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với View Properties đã định trước để các bài thuyết trình mới mở cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/viewproperties/) được lưu ở mức độ bài thuyết trình, bạn có thể nhúng chúng vào một mẫu và tạo các tài liệu mới từ mẫu đó với cùng cấu hình chế độ xem ban đầu.