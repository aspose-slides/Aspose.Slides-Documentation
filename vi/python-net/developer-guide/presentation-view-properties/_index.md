---
title: Lấy và Cập nhật Thuộc tính Xem Bản trình chiếu trong Python
linktitle: Thuộc tính Xem
type: docs
weight: 80
url: /vi/python-net/presentation-view-properties/
keywords:
- thuộc tính xem
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bộ chia dọc tự chốt
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- phóng đại mặc định
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Khám phá các thuộc tính xem của Aspose.Slides cho Python via .NET để tùy chỉnh định dạng slide PPT, PPTX và ODP—điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: slide tự nó, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem vẫn ở cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Thuộc tính [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/normal_view_properties/) đã được thêm để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình chiếu.  

[NormalViewProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/normalviewrestoredproperties/) các lớp và các lớp con của chúng, [SplitterBarStateType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/splitterbarstatetype/) enum đã được thêm.

## **Về INormalViewProperties**

Biểu diễn các thuộc tính chế độ xem bình thường.

Thuộc tính **ShowOutlineIcons** chỉ định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Thuộc tính **SnapVerticalSplitter** chỉ định liệu bộ chia dọc có nên chốt vào trạng thái thu nhỏ khi vùng bên đủ nhỏ hay không.

Thuộc tính **PreferSingleView** chỉ định liệu người dùng có ưu tiên xem một vùng nội dung duy nhất toàn màn hình so với chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các thuộc tính **VerticalBarState** và **HorizontalBarState** chỉ định trạng thái mà thanh chia dọc hoặc ngang sẽ hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung bên dưới slide, thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** và **SplitterBarStateType.Restored.**

Các thuộc tính **RestoredLeft** và **RestoredTop** chỉ định kích thước của vùng slide phía trên hoặc bên của chế độ xem bình thường, khi giá trị **SplitterBarStateType.Restored** được áp dụng cho **VerticalBarState** và **HorizontalBarState** tương ứng.

## **Về việc khôi phục INormalViewProperties**

Chỉ định kích thước của vùng slide (độ rộng khi là con của RestoredTop, độ cao khi là con của RestoredLeft) trong chế độ xem bình thường, khi vùng có kích thước khôi phục biến đổi (không phải ở trạng thái thu nhỏ hay tối đa).  

Thuộc tính **DimensionSize** chỉ định kích thước của vùng slide (độ rộng khi là con của restoredTop, độ cao khi là con của restoredLeft).  

Thuộc tính **AutoAdjust** chỉ định liệu kích thước của vùng nội dung bên có nên bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.  

Ví dụ dưới đây cho thấy cách bạn có thể truy cập các thuộc tính **ViewProperties.NormalViewProperties** cho một bản trình chiếu.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Khôi phục các thuộc tính xem của bản trình chiếu
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt giá trị phóng đại mặc định**

Aspose.Slides for Python via .NET hiện hỗ trợ việc đặt giá trị phóng đại mặc định cho bản trình chiếu sao cho khi mở bản trình chiếu, mức phóng đã được thiết lập. Điều này có thể thực hiện bằng cách thiết lập [view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) của một bản trình chiếu. Các Thuộc tính Xem Slide cũng như [notes_view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/notes_view_properties/) có thể được đặt theo chương trình. Trong chủ đề này, chúng ta sẽ xem xét qua một ví dụ cách thiết lập Thuộc tính Xem của Bản trình chiếu trong Aspose.Slides.

Để thiết lập các thuộc tính xem, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/)  
1. Đặt [view properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/) của bản trình chiếu  
1. Ghi bản trình chiếu dưới dạng tệp PPTX  

Trong ví dụ dưới đây, chúng tôi đã đặt giá trị phóng đại cho chế độ xem slide cũng như chế độ xem ghi chú.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Đặt các thuộc tính xem của bản trình chiếu
    presentation.view_properties.slide_view_properties.scale = 100 # Giá trị thu phóng tính bằng phần trăm cho chế độ xem slide
    presentation.view_properties.notes_view_properties.scale = 100 # Giá trị thu phóng tính bằng phần trăm cho chế độ xem ghi chú 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt khoảng cách lưới**

Sử dụng [Presentation.view_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) để truy cập cài đặt xem toàn bộ bản trình chiếu. Thuộc tính [ViewProperties.grid_spacing](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/grid_spacing/) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền. Cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho một slide riêng lẻ. Khoảng cách lưới được xác định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ sau mở một tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, đặt khoảng cách một phần tư inch và lưu kết quả.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Lưới khác với [drawing guides](/slides/vi/python-net/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng cách đều, trong khi các hướng dẫn vẽ là các đường căn chỉnh ngang hoặc dọc được đặt riêng lẻ. Thêm, di chuyển hoặc xóa các hướng dẫn vẽ không làm thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc trình chiếu. Lưu khoảng cách lưới không đảm bảo rằng một trình chỉnh sửa sẽ hiển thị lưới: tính hiển thị cũng phụ thuộc vào tùy chọn của người xem hoặc trình chỉnh sửa.

## **Câu hỏi thường gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình chiếu?**  
Tệp lưu trữ khoảng cách lưới, nhưng trình chỉnh sửa kiểm soát việc hiển thị lưới. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Việc xóa các hướng dẫn vẽ có thay đổi khoảng cách lưới không?**  
Không. Các hướng dẫn vẽ và khoảng cách lưới là các cài đặt độc lập. Xóa các hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt cài đặt xem khác nhau cho các phần khác nhau của bản trình chiếu không?**  
Các [view settings](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) được định nghĩa ở mức bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/slide_view_properties/)), không phải theo từng phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái xem khác nhau cho các người dùng khác nhau không?**  
Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính xem.

**Tôi có thể chuẩn bị một mẫu với các View Properties đã định sẵn để các bản trình chiếu mới mở theo cùng cách không?**  
Có. Vì các [view properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/view_properties/) được lưu ở mức bản trình chiếu, bạn có thể nhúng chúng vào một mẫu và tạo tài liệu mới từ mẫu đó với cấu hình xem ban đầu giống nhau.