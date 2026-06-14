---
title: Truy xuất và Cập nhật Thuộc tính Hiển thị Bản trình bày trong Python
linktitle: Thuộc tính Hiển thị
type: docs
weight: 80
url: /vi/python-net/presentation-view-properties/
keywords:
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- cắm thanh chia dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- phóng to mặc định
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá các thuộc tính hiển thị của Aspose.Slides cho Python via .NET để tùy chỉnh các định dạng PPT, PPTX và ODP—điều chỉnh bố cục, mức phóng to và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: slide itself, một vùng nội dung bên, và một vùng nội dung dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái hiển thị vào tệp, để khi mở lại, chế độ xem vẫn ở cùng trạng thái như khi bản trình bày được lưu lần cuối.

Thuộc tính [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/normal_view_properties/) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình bày. 

[NormalViewProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/normalviewrestoredproperties/) lớp và các lớp con của chúng, [SplitterBarStateType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/splitterbarstatetype/) enum đã được thêm.

## **Về INormalViewProperties** 

Đại diện cho các thuộc tính chế độ xem bình thường.

Thuộc tính **ShowOutlineIcons** chỉ định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Thuộc tính **SnapVerticalSplitter** chỉ định liệu thanh chia dọc có nên chốt vào trạng thái thu nhỏ khi vùng bên đủ nhỏ hay không.

Thuộc tính **PreferSingleView** chỉ định liệu người dùng muốn xem một vùng nội dung đơn đầy cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn bộ cửa sổ.

Các thuộc tính **VerticalBarState** và **HorizontalBarState** chỉ định trạng thái mà thanh chia ngang hoặc dọc sẽ hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung phía dưới slide, thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị khả dụng là: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** và **SplitterBarStateType.Restored.**

Các thuộc tính **RestoredLeft** và **RestoredTop** chỉ định kích thước của vùng slide phía trên hoặc bên trong chế độ xem bình thường, khi giá trị **SplitterBarStateType.Restored** được áp dụng cho **VerticalBarState** và **HorizontalBarState** tương ứng.

## **Về việc khôi phục INormalViewProperties**

Xác định kích thước của vùng slide (chiều rộng khi là con của RestoredTop, chiều cao khi là con của RestoredLeft) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng to). 

Thuộc tính **DimensionSize** chỉ định kích thước của vùng slide (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Thuộc tính **AutoAdjust** chỉ định liệu kích thước của vùng nội dung bên có nên điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Ví dụ dưới đây cho thấy cách bạn có thể truy cập các thuộc tính **ViewProperties.NormalViewProperties** cho một bản trình bày.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Khôi phục các thuộc tính hiển thị của bản trình bày
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Giá Trị Phóng To Mặc Định**

Aspose.Slides for Python via .NET hiện hỗ trợ thiết lập giá trị phóng to mặc định cho bản trình bày sao cho khi bản trình bày được mở, mức phóng to đã được đặt sẵn. Điều này có thể thực hiện bằng cách đặt [view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) của một bản trình bày. Thuộc tính Slide View cũng như [notes_view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/notes_view_properties/) có thể được đặt thông qua mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách thiết lập View Properties của Presentation trong Aspose.Slides.

Để thiết lập các thuộc tính hiển thị, hãy làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/)
2. Đặt [view properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/) của bản trình bày
3. Ghi bản trình bày dưới dạng tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã đặt giá trị phóng to cho slide view cũng như notes view.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Đặt các thuộc tính hiển thị của bản trình bày
    presentation.view_properties.slide_view_properties.scale = 100 # Giá trị phóng to tính bằng phần trăm cho chế độ xem slide
    presentation.view_properties.notes_view_properties.scale = 100 # Giá trị phóng to tính bằng phần trăm cho chế độ xem ghi chú 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể thiết lập các cài đặt hiển thị khác nhau cho các phần khác nhau của bản trình bày không?**

[View settings](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) được xác định ở mức độ bản trình bày ([Normal View](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/slide_view_properties/)), không phải theo từng phần, vì vậy một bộ tham số duy nhất được áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái hiển thị khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính hiển thị.

**Tôi có thể chuẩn bị một mẫu với View Properties được định trước để các bản trình bày mới mở cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) được lưu ở mức độ bản trình bày, bạn có thể nhúng chúng vào một mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình hiển thị ban đầu.