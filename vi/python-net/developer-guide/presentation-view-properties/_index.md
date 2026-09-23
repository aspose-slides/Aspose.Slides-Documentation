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
  - tự động thu gọn thanh chia dọc
  - chế độ xem đơn
  - trạng thái thanh
  - kích thước chiều
  - tự điều chỉnh
  - thu phóng mặc định
  - PowerPoint
  - bản trình bày
  - Python
  - Aspose.Slides
description: "Khám phá các thuộc tính hiển thị của Aspose.Slides cho Python via .NET để tùy chỉnh định dạng PPT, PPTX và ODP—điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường gồm ba vùng nội dung: slide, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình bày được lưu lần cuối.

Thuộc tính **Thuộc tính** [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/normal_view_properties/) đã được thêm để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình bày. 

Các lớp [NormalViewProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/normalviewrestoredproperties/) và các lớp kế thừa, enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/splitterbarstatetype/) đã được thêm.

## **Về INormalViewProperties** 

Đại diện cho các thuộc tính chế độ xem bình thường.

Thuộc tính **ShowOutlineIcons** chỉ định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Thuộc tính **SnapVerticalSplitter** chỉ định liệu thanh chia dọc có tự động thu gọn thành trạng thái tối thiểu khi vùng bên đủ nhỏ không.

Thuộc tính **PreferSingleView** chỉ định liệu người dùng ưu tiên xem một vùng nội dung duy nhất trên toàn màn hình thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn bộ cửa sổ.

Các thuộc tính **VerticalBarState** và **HorizontalBarState** chỉ định trạng thái mà thanh chia dọc hoặc ngang nên được hiển thị. Thanh chia ngang tách slide ra khỏi vùng nội dung bên dưới slide, thanh chia dọc tách slide ra khỏi vùng nội dung bên. Các giá trị có thể là: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** và **SplitterBarStateType.Restored**.

Các thuộc tính **RestoredLeft** và **RestoredTop** chỉ định kích thước của vùng slide trên hoặc bên của chế độ xem bình thường, khi giá trị **SplitterBarStateType.Restored** được áp dụng cho **VerticalBarState** và **HorizontalBarState** tương ứng.

## **Về việc Khôi phục INormalViewProperties**

Chỉ định kích thước của vùng slide (chiều rộng khi là con của RestoredTop, chiều cao khi là con của RestoredLeft) trong chế độ xem bình thường, khi vùng có kích thước khôi phục biến đổi (không phải tối thiểu cũng không phải tối đa). 

Thuộc tính **DimensionSize** chỉ định kích thước của vùng slide (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Thuộc tính **AutoAdjust** chỉ định liệu kích thước của vùng nội dung bên có tự điều chỉnh để bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách truy cập các thuộc tính **ViewProperties.NormalViewProperties** cho một bản trình bày.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Khôi phục các thuộc tính hiển thị của bản trình bày
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Giá Trị Thu Phóng Mặc Định**

Aspose.Slides for Python via .NET hiện hỗ trợ đặt giá trị thu phóng mặc định cho bản trình bày sao cho khi mở bản trình bày, mức thu phóng đã được thiết lập sẵn. Điều này có thể thực hiện bằng cách thiết lập [view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) của một bản trình bày. Thuộc tính View của Slide cũng như [notes_view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/notes_view_properties/) có thể được thiết lập bằng mã. Trong chủ đề này, chúng ta sẽ xem một ví dụ cách thiết lập View Properties của Presentation trong Aspose.Slides.

Để thiết lập các thuộc tính xem, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) 
1. Thiết lập [view properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/) của bản trình bày 
1. Ghi bản trình bày ra file PPTX 

Trong ví dụ dưới đây, chúng tôi đã đặt giá trị thu phóng cho chế độ xem slide cũng như chế độ xem ghi chú.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Thiết lập các thuộc tính hiển thị của bản trình bày
    presentation.view_properties.slide_view_properties.scale = 100 # Giá trị thu phóng theo phần trăm cho chế độ xem slide
    presentation.view_properties.notes_view_properties.scale = 100 # Giá trị thu phóng theo phần trăm cho chế độ xem ghi chú 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Khoảng Cách Lưới**

Sử dụng [Presentation.view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) để truy cập cài đặt xem toàn bộ bản trình bày. Thuộc tính [ViewProperties.grid_spacing](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/grid_spacing/) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền. Cài đặt này áp dụng cho toàn bộ bản trình bày, không phải cho một slide riêng lẻ. Khoảng cách lưới được tính bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ sau mở một file `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, đặt khoảng cách một phần tư inch và lưu kết quả.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Lưới khác với [drawing guides](/slides/vi/python-net/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng đều đặn, trong khi hướng dẫn vẽ là các đường căn chỉnh ngang hoặc dọc được đặt vị trí riêng lẻ. Thêm, di chuyển hoặc xóa hướng dẫn vẽ không làm thay đổi khoảng cách lưới.

Cả lưới và hướng dẫn vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được render thành nội dung slide trong PDF, hình ảnh, SVG, hoặc bản trình chiếu. Lưu khoảng cách lưới không đảm bảo rằng một trình chỉnh sửa sẽ hiển thị lưới: khả năng hiển thị còn phụ thuộc vào tùy chọn của người xem hoặc trình chỉnh sửa.

## **Hiển Thị hoặc Ẩn Bình Luận Khi Mở Bản Trình Bày**

Sử dụng [Presentation.view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) để truy cập cài đặt xem toàn bộ bản trình bày. Đọc hoặc thay đổi [ViewProperties.show_comments](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/show_comments/) để lưu tùy chọn liệu bình luận có được hiển thị khi bản trình bày mở trong PowerPoint hoặc trình chỉnh sửa tương thích khác hay không.

Cài đặt này chỉ điều khiển tùy chọn xem được lưu. Nó không thêm, xóa, chỉnh sửa hoặc giải quyết bình luận. Ẩn bình luận vẫn giữ nguyên nội dung, tác giả, vị trí, phản hồi và trạng thái của chúng. Xem [Presentation Comments](/slides/vi/python-net/presentation-comments/) để biết các thao tác thay đổi bình luận.

Ví dụ sau yêu cầu một file `comments.pptx` hiện có chứa bình luận. Nó in ra cài đặt hiển thị hiện tại, yêu cầu ẩn bình luận và lưu một file PPTX mới mà không xóa bất kỳ bình luận nào. Nó cũng đặt [ViewProperties.last_view](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/last_view/) thành [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewtype/) để cấu hình chế độ chỉnh sửa ban đầu cùng với khả năng hiển thị bình luận.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Cài đặt này không quyết định liệu bình luận có được bao gồm trong các xuất PDF, HTML, hình ảnh, ghi chú hoặc tài liệu phát tay hay không. Hãy cấu hình các tùy chọn xuất riêng biệt theo nhu cầu.

## **Câu Hỏi Thường Gặp**

**Tại sao lưới không hiển thị khi tôi mở lại bản trình bày?**

File lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định việc lưới có hiển thị hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Xóa hướng dẫn vẽ có thay đổi khoảng cách lưới không?**

Không. Hướng dẫn vẽ và khoảng cách lưới là hai cài đặt độc lập. Xóa hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt xem khác nhau cho các phần khác nhau của bản trình bày không?**

[Cài đặt xem](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) được định nghĩa ở mức bản trình bày ([Normal View](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/slide_view_properties/)), không phải theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong file và được chia sẻ. Các ứng dụng xem có thể tôn trọng tùy chọn của người dùng, nhưng file tự nó chỉ chứa một bộ thuộc tính xem.

**Tôi có thể chuẩn bị một mẫu với các View Properties đã định nghĩa trước để các bản trình bày mới mở cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) được lưu ở mức bản trình bày, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình xem ban đầu.