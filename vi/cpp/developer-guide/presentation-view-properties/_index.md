---
title: Lấy và Cập nhật Thuộc tính Hiển thị Bản trình chiếu trong C++
linktitle: Thuộc tính Hiển thị
type: docs
weight: 80
url: /vi/cpp/presentation-view-properties/
keywords:
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bắt dính thanh chia dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- phóng to mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá các thuộc tính hiển thị của Aspose.Slides cho C++ để tùy chỉnh định dạng slide PPT, PPTX và ODP—điều chỉnh bố cục, mức phóng to và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: bản trình chiếu, một vùng nội dung phụ và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại chế độ xem sẽ ở cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Phương thức [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình chiếu. 

[INormalViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inormalviewrestoredproperties/) các giao diện và các lớp con của chúng, enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/splitterbarstatetype/) đã được thêm.

## **Về INormalViewProperties**

Biểu diễn các thuộc tính chế độ xem bình thường.

Thuộc tính **ShowOutlineIcons** xác định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Thuộc tính **SnapVerticalSplitter** xác định liệu thanh chia dọc có tự động chuyển tới trạng thái thu nhỏ khi vùng phụ đủ nhỏ hay không.

Thuộc tính **PreferSingleView** xác định liệu người dùng muốn xem một vùng nội dung duy nhất toàn màn hình thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các thuộc tính **VerticalBarState** và **HorizontalBarState** xác định trạng thái mà thanh chia ngang hoặc dọc sẽ được hiển thị. Thanh chia ngang tách bản trình chiếu khỏi vùng nội dung phía dưới, thanh chia dọc tách bản trình chiếu khỏi vùng nội dung phụ. Các giá trị có thể là: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** và **SplitterBarStateType.Restored.**

Các thuộc tính **RestoredLeft** và **RestoredTop** xác định kích thước của vùng bản trình chiếu phía trên hoặc bên của chế độ xem bình thường, khi giá trị **SplitterBarStateType.Restored** được áp dụng cho **VerticalBarState** và **HorizontalBarState** tương ứng.

## **Về việc khôi phục INormalViewProperties**

Xác định kích thước của vùng bản trình chiếu (chiều rộng khi là con của RestoredTop, chiều cao khi là con của RestoredLeft) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng đại). 

Thuộc tính **DimensionSize** xác định kích thước của vùng bản trình chiếu (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Thuộc tính **AutoAdjust** xác định liệu kích thước của vùng nội dung phụ có nên tự điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Ví dụ dưới đây cho thấy cách bạn có thể truy cập các thuộc tính **ViewProperties.NormalViewProperties** cho một bản trình chiếu.

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Khôi phục các thuộc tính hiển thị của bản trình chiếu
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Đặt Giá trị Phóng to Mặc định**

Aspose.Slides cho C++ hiện hỗ trợ đặt giá trị phóng to mặc định cho bản trình chiếu sao cho khi bản trình chiếu được mở, mức phóng to đã được thiết lập. Điều này có thể thực hiện bằng cách đặt [ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/) của một bản trình chiếu. Các thuộc tính chế độ xem slide cũng như [get_NotesViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/get_notesviewproperties/) có thể được đặt bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách đặt View Properties của Presentation trong Aspose.Slides.

Để đặt các thuộc tính chế độ xem, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Đặt [Properties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/) của Presentation.
1. Ghi bản trình chiếu dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã đặt giá trị phóng to cho chế độ xem slide cũng như chế độ xem ghi chú.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Đặt các thuộc tính hiển thị của bản trình chiếu
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Giá trị phóng to tính bằng phần trăm cho chế độ xem slide
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Giá trị phóng to tính bằng phần trăm cho chế độ xem ghi chú 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt các thiết lập chế độ xem khác nhau cho các phần khác nhau của bản trình chiếu không?**

[View settings](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_viewproperties/) được xác định ở mức độ bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), không theo từng phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp 자체 chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể tạo một mẫu với View Properties được định trước để các bản trình chiếu mới mở giống nhau không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_viewproperties/) được lưu ở mức độ bản trình chiếu, bạn có thể nhúng chúng vào một mẫu và tạo các tài liệu mới từ mẫu này với cùng cấu hình chế độ xem ban đầu.