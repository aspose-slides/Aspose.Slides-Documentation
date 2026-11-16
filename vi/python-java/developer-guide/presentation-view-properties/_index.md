---
title: Lấy và Cập nhật Thuộc tính Hiển thị Bản trình bày trong Python qua Java
linktitle: Thuộc tính Hiển thị
type: docs
weight: 80
url: /vi/python-java/presentation-view-properties/
keywords:
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bộ chia dọc tự động thu gọn
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho Python qua Java để cấu hình bố trí chế độ xem bình thường, mức thu phóng slide và ghi chú, khoảng cách lưới và khả năng hiển thị bình luận trong các bản trình bày PowerPoint."
---
## **Giới thiệu**

Trong chế độ xem bình thường của PowerPoint, slide hiển thị giữa một khung bên dành cho hình thu nhỏ hoặc đề cương và một khung ghi chú ở phía dưới. Aspose.Slides for Python via Java cung cấp các tùy chỉnh lưu trữ khi chỉnh sửa bản trình bày thông qua [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Các tùy chỉnh này bao gồm bố trí các khung, mức thu phóng, khoảng cách lưới và khả năng hiển thị bình luận.

## **Về NormalViewProperties**

Sử dụng [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) để truy cập lớp [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) kiểm soát việc có hiển thị biểu tượng bên cạnh tiêu đề slide trong đề cương hay không. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) cho phép khung bên tự động thu nhỏ khi người dùng thu hẹp nó. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) cho biết ưu tiên hiển thị một khung duy nhất trên toàn cửa sổ.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) kiểm soát thanh phân cách giữa khung bên và slide. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) kiểm soát thanh phân cách phía trên khung ghi chú. Cả hai chấp nhận giá trị của [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) là `Minimized`, `Maximized`, hoặc `Restored`.

## **Về việc khôi phục NormalViewProperties**

Khi một thanh phân cách được khôi phục, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) cung cấp kích thước đã lưu của khung bên và [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) cung cấp kích thước đã lưu của vùng slide trên. Cả hai trả về một thể hiện của [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Phương thức [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) của nó chấp nhận phần trăm từ 0 đến 100, và [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) kiểm soát việc trình chỉnh sửa tự động điều chỉnh kích thước khi cửa sổ được thay đổi kích thước.

Ví dụ này cập nhật một bản trình bày hiện có. Nó khôi phục thanh phân cách ngang, đặt kích thước trả về bởi [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) thành 80% với tự động điều chỉnh được bật, và mở rộng tối đa thanh phân cách dọc. Nó cũng gọi [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) để hiển thị biểu tượng trong chế độ xem đề cương.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Đặt Giá trị Thu phóng Mặc định**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) và [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) lưu các cài đặt thu phóng độc lập cho trình chỉnh sửa. Các cài đặt này không ảnh hưởng đến kích thước slide, việc phát trình chiếu, hay độ phân giải khi xuất ảnh.

Ví dụ này mở một bản trình bày hiện có và gọi [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) để vừa slide với cửa sổ chỉnh sửa. Đối với trang ghi chú, nó tắt tự động tỷ lệ và gọi [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) để đặt mức thu phóng cố định 80%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Đặt Khoảng cách Lưới**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) thiết lập khoảng cách giữa các đường lưới chỉnh sửa trong toàn bộ bản trình bày. Nó nhận một giá trị dương tính bằng point, với 72 point mỗi inch. Ví dụ này in khoảng cách hiện tại trong một bản trình bày hiện có và lưu lưới một phần tư inch bằng cách đặt khoảng cách thành 18 point.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lưới lặp lại với một khoảng cách cố định. [Hướng dẫn vẽ](/slides/vi/python-java/drawing-guides/) đánh dấu các vị trí ngang hoặc dọc riêng lẻ. Cả hai đều là công cụ hỗ trợ chỉnh sửa và chỉ xuất hiện trong các trình chỉnh sửa hiển thị chúng. Trình chiếu và xuất ra PDF, ảnh, hoặc SVG sẽ bỏ qua chúng.

## **Hiển thị hoặc Ẩn Bình luận Khi Mở Bản trình bày**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) lưu một tùy chọn mà các trình chỉnh hợp hỗ trợ sẽ sử dụng khi mở bản trình bày. Đối với một bản trình bày hiện có có bình luận, ví dụ này in cài đặt hiện tại và lưu một bản sao với bình luận bị ẩn. Nó cũng gọi [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) với [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) để bản sao mở ở chế độ xem slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Việc ẩn bình luận vẫn giữ nguyên nội dung, tác giả, vị trí, trả lời và trạng thái của chúng. Để thay đổi chính các bình luận, xem [Bình luận Bản trình bày](/slides/vi/python-java/presentation-comments/). Cài đặt xuất quyết định liệu bình luận có xuất hiện trong PDF, HTML, ảnh, ghi chú, hay tài liệu phát tay hay không.

## **Câu hỏi thường gặp**

**Tại sao lưới bị ẩn khi tôi mở lại bản trình bày?**

Bản trình bày lưu khoảng cách lưới. Để xem lưới, bật chế độ hiển thị lưới trong trình chỉnh sửa.

**Việc xóa các hướng dẫn vẽ có làm thay đổi khoảng cách lưới không?**

Không. Thêm, di chuyển hoặc xóa một hướng dẫn không làm thay đổi khoảng cách lưới.

**Các phần khác nhau của một bản trình bày có thể có các cài đặt hiển thị khác nhau không?**

Không. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) áp dụng cho toàn bộ bản trình bày.

**Tôi có thể lưu các cài đặt hiển thị khác nhau cho các người dùng khác nhau không?**

Tệp chỉ lưu một bộ thuộc tính hiển thị cho mọi người. Trình chỉnh sửa cũng có thể áp dụng các tùy chỉnh cục bộ của người dùng.

**Tôi có thể lưu cài đặt hiển thị trong một mẫu không?**

Có. Các bản trình bày được tạo từ mẫu sẽ kế thừa các cài đặt hiển thị đã lưu của mẫu.