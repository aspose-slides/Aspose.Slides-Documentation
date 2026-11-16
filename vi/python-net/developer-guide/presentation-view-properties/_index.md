---
title: "Truy xuất và Cập nhật Thuộc tính Hiển thị Bản trình chiếu trong Python"
linktitle: "Thuộc tính Hiển thị"
type: docs
weight: 80
url: /vi/python-net/presentation-view-properties/
keywords:
- "thuộc tính hiển thị"
- "chế độ xem bình thường"
- "nội dung đề cương"
- "biểu tượng đề cương"
- "bắt dính thanh chia dọc"
- "chế độ xem đơn"
- "trạng thái thanh"
- "kích thước chiều"
- "tự động điều chỉnh"
- "phóng đại mặc định"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "Python"
- "Aspose.Slides"
description: "Sử dụng Aspose.Slides cho Python qua .NET để cấu hình bố cục chế độ xem bình thường, phóng đại slide và ghi chú, khoảng cách lưới, và hiển thị bình luận trong bản trình chiếu PowerPoint."
---
## **Giới thiệu**

Trong chế độ xem bình thường của PowerPoint, slide xuất hiện giữa một khung bên để hiển thị hình thu nhỏ hoặc đề cương và một khung ghi chú ở dưới. Aspose.Slides cho Python thông qua .NET cung cấp các tùy chọn chỉnh sửa đã lưu của bản trình chiếu qua [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Các tùy chọn này bao gồm bố cục khung, mức thu phóng, khoảng cách lưới và hiển thị bình luận.

## **Về NormalViewProperties**

Sử dụng [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) để truy cập vào đối tượng [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) kiểm soát việc hiển thị biểu tượng bên cạnh tiêu đề slide trong đề cương. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) cho phép khung bên bật vào trạng thái thu nhỏ khi người dùng thu hẹp nó. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) cho biết ưu tiên hiển thị một khung trong toàn cửa sổ.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) điều khiển thanh chia giữa khung bên và slide. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) điều khiển thanh chia phía trên khung ghi chú. Cả hai chấp nhận giá trị của [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) là `MINIMIZED`, `MAXIMIZED`, hoặc `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![Một trình chỉnh sửa khái niệm tách một bảng bên, khu vực slide và khu vực dưới với các thanh chia dọc và ngang được gắn nhãn.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*Trong chế độ xem bình thường, thanh chia dọc điều khiển độ rộng của khung bên. Thanh chia ngang điều khiển khoảng cách phía trên khung ghi chú.*
<!-- visual-explanation:presentation-view-properties:end -->

## **Về Khôi phục NormalViewProperties**

Khi một thanh chia được khôi phục, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) cung cấp kích thước đã lưu của khung bên và [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) cung cấp kích thước đã lưu của khu vực slide phía trên. Cả hai đều hiển thị [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Thuộc tính [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) của nó chấp nhận phần trăm từ 0 đến 100, và [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) kiểm soát việc trình chỉnh sửa điều chỉnh kích thước khi cửa sổ được thay đổi kích thước.

Ví dụ này cập nhật một bản trình chiếu hiện có. Nó khôi phục thanh chia ngang, đặt [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) thành 80% với việc tự động điều chỉnh được bật, và mở rộng thanh chia dọc lên mức tối đa. Nó cũng bật [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) cho chế độ xem đề cương.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt giá trị Phóng đại Mặc định**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) và [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) lưu các cài đặt phóng đại độc lập cho trình chỉnh sửa. Các cài đặt này không ảnh hưởng đến kích thước slide, phát slideshow, hay độ phân giải xuất hình ảnh.

Ví dụ này mở một bản trình chiếu hiện có và bật [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) để vừa slide với cửa sổ chỉnh sửa. Đối với trang ghi chú, nó tắt việc tự động thu phóng và đặt [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) thành mức phóng đại cố định 80%.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Khoảng cách Lưới**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) đặt khoảng cách giữa các đường lưới chỉnh sửa trong toàn bộ bản trình chiếu. Nó nhận một giá trị dương tính bằng điểm, với 72 điểm mỗi inch. Ví dụ này in khoảng cách hiện tại trong một bản trình chiếu hiện có và lưu một lưới một phần tư inch bằng cách đặt khoảng cách thành 18 điểm.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Lưới được lặp lại với khoảng cách cố định. [Hướng dẫn vẽ](/slides/vi/python-net/drawing-guides/) đánh dấu các vị trí ngang hoặc dọc riêng lẻ. Cả hai đều là công cụ hỗ trợ chỉnh sửa và chỉ hiển thị trong các trình chỉnh sửa có hiển thị chúng. Trình chiếu và việc xuất ra PDF, hình ảnh, hoặc SVG sẽ không bao gồm chúng.

## **Hiển thị hoặc Ẩn Bình luận Khi Mở Bản Trình chiếu**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) lưu một tùy chọn mà các trình chỉnh sửa tương thích sử dụng khi mở bản trình chiếu. Đối với một bản trình chiếu hiện có có bình luận, ví dụ này in thiết lập hiện tại và lưu một bản sao với bình luận được ẩn. Nó cũng đặt [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) thành [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) để bản sao mở trong chế độ xem slide.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Việc ẩn bình luận vẫn giữ lại văn bản, tác giả, vị trí, phản hồi và trạng thái của chúng. Để thay đổi các bình luận, xem [Bình luận Bản trình chiếu](/slides/vi/python-net/presentation-comments/). Các cài đặt xuất kiểm soát việc bình luận có xuất hiện trong PDF, HTML, hình ảnh, ghi chú, hoặc tài liệu rút gọn hay không.

## **Câu hỏi thường gặp**

**Tại sao lưới lại bị ẩn khi tôi mở lại bản trình chiếu?**  
Bản trình chiếu lưu khoảng cách lưới. Để xem lưới, bật khả năng hiển thị lưới trong trình chỉnh sửa.

**Việc xóa hướng dẫn vẽ có thay đổi khoảng cách lưới không?**  
Không. Thêm, di chuyển hoặc xóa một hướng dẫn không làm thay đổi khoảng cách lưới.

**Các phần khác nhau của bản trình chiếu có thể có cài đặt hiển thị khác nhau không?**  
Không. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) áp dụng cho toàn bộ bản trình chiếu.

**Tôi có thể lưu các cài đặt hiển thị khác nhau cho các người dùng khác nhau không?**  
Tệp lưu một bộ thuộc tính hiển thị cho mọi người. Trình chỉnh sửa cũng có thể áp dụng các tùy chọn cục bộ của người dùng.

**Tôi có thể lưu cài đặt hiển thị trong mẫu không?**  
Có. Các bản trình chiếu được tạo từ mẫu sẽ kế thừa các cài đặt hiển thị đã lưu của mẫu.