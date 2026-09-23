---
title: "Truy xuất và Cập nhật Thuộc tính Chế độ xem Bản trình bày trong Python qua Java"
linktitle: "Thuộc tính Chế độ xem"
type: docs
weight: 80
url: /vi/python-java/presentation-view-properties/
keywords:
- "thuộc tính chế độ xem"
- "chế độ xem bình thường"
- "nội dung đề cương"
- "biểu tượng đề cương"
- "bộ chia dọc tự động gắn"
- "chế độ xem đơn"
- "trạng thái thanh"
- "kích thước chiều"
- "tự điều chỉnh"
- "thu phóng mặc định"
- "PowerPoint"
- "OpenDocument"
- "bản trình bày"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Khám phá thuộc tính chế độ xem của Aspose.Slides cho Python qua Java để tùy chỉnh slide PPT, PPTX và ODP — điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: bản slide tự nó, một vùng nội dung bên và một vùng nội dung phía dưới. Thuộc tính chế độ xem bình thường mô tả vị trí của các vùng nội dung này. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem ở cùng trạng thái như khi bản trình bày được lưu lần cuối.

Phương thức [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của một bản trình bày.

Các lớp [NormalViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewrestoredproperties/) và kiểu liệt kê [SplitterBarStateType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/) đã được thêm.

## **Về NormalViewProperties**

Đại diện cho các thuộc tính chế độ xem bình thường.

Các phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) xác định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Các phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) xác định liệu bộ chia dọc có nên bật vào trạng thái thu nhỏ khi vùng bên đủ nhỏ.

Các phương thức [getPreferSingleView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) và [setPreferSingleView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) xác định liệu người dùng có muốn xem một vùng nội dung đơn trên toàn cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu được bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) xác định trạng thái mà thanh chia dọc hoặc ngang sẽ được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung phía dưới slide; thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Restored).

Các phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) và [getRestoredTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredTop) xác định kích thước của vùng slide bên trái hoặc phía trên trong chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), tương ứng.

## **Về Khôi phục NormalViewProperties**

Xác định kích thước của vùng slide (độ rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredTop), độ cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ nor phóng to).

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) chỉ định kích thước của vùng slide (độ rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredTop), độ cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) xác định liệu kích thước của vùng nội dung bên có nên tự điều chỉnh để bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Ví dụ bên dưới cho thấy cách truy cập [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) cho một bản trình bày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Khôi phục các thuộc tính chế độ xem của bản trình bày.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Giá trị Thu phóng Mặc định**

{{% alert color="info" title="Note" %}}
Aspose.Slides cho Python thông qua Java hỗ trợ thiết lập giá trị thu phóng mặc định để nó đã được áp dụng khi bản trình bày mở. Điều này có thể thực hiện bằng cách đặt [ViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/) của một bản trình bày. [getSlideViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getSlideViewProperties) và [getNotesViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNotesViewProperties) có thể được cấu hình bằng chương trình. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách đặt [View Properties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/) của [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) trong Aspose.Slides.
{{% /alert %}}

Để đặt các thuộc tính xem, thực hiện các bước sau:
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Đặt [View Properties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/) cho [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
3. Ghi bản trình bày thành tệp [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Trong ví dụ bên dưới, chúng tôi đặt giá trị thu phóng cho cả chế độ xem slide và chế độ xem ghi chú.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Đặt các thuộc tính chế độ xem của bản trình bày.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Phần trăm thu phóng cho chế độ xem slide.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Phần trăm thu phóng cho chế độ xem ghi chú.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Khoảng cách Lưới**

Sử dụng [Presentation.getViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getViewProperties) để truy cập cài đặt chế độ xem trên toàn bộ bản trình bày. Các phương thức [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getGridSpacing) và [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#setGridSpacing) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền tảng. Cài đặt này áp dụng cho toàn bộ bản trình bày, không phải cho một slide riêng lẻ. Khoảng cách lưới được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ sau mở một tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, đặt khoảng cách một phần tư inch, và lưu kết quả.

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

Lưới khác với [drawing guides](/slides/vi/python-java/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng cách đều đặn, trong khi các hướng dẫn vẽ là các đường căn chỉnh ngang hoặc dọc được đặt vị trí riêng lẻ. Thêm, di chuyển hoặc xóa các hướng dẫn vẽ không thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG, hoặc trình chiếu. Lưu khoảng cách lưới không đảm bảo rằng trình chỉnh sửa sẽ hiển thị lưới: khả năng hiển thị cũng phụ thuộc vào tùy chọn của người xem hoặc trình chỉnh sửa.

## **Hiển thị hoặc Ẩn Bình luận Khi Mở Bản trình bày**

Sử dụng [Presentation.getViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getViewProperties) để truy cập cài đặt chế độ xem trên toàn bộ bản trình bày. Sử dụng [ViewProperties.getShowComments](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getShowComments) và [ViewProperties.setShowComments](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#setShowComments) để đọc hoặc thay đổi tùy chọn lưu trữ về việc có nên hiển thị bình luận khi bản trình bày mở trong PowerPoint hoặc trình chỉnh sửa tương thích khác.

Cài đặt này chỉ kiểm soát tùy chọn chế độ xem được lưu. Nó không thêm, xóa, chỉnh sửa hoặc giải quyết bình luận. Ẩn bình luận vẫn giữ nguyên nội dung, tác giả, vị trí, trả lời và trạng thái của chúng. Xem [Presentation Comments](/slides/vi/python-java/presentation-comments/) để biết các thao tác thay đổi bình luận.

Ví dụ sau yêu cầu một tệp `comments.pptx` hiện có chứa bình luận. Nó in ra cài đặt hiển thị hiện tại, yêu cầu ẩn bình luận và lưu một PPTX mới mà không xóa bất kỳ bình luận nào. Nó cũng sử dụng [ViewProperties.setLastView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#setLastView) kết hợp với [ViewType.SlideView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewtype/#SlideView) để cấu hình chế độ chỉnh sửa ban đầu cùng với khả năng hiển thị bình luận.

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

Cài đặt này không quyết định liệu bình luận có được bao gồm trong xuất PDF, HTML, hình ảnh, ghi chú hoặc tài liệu phát tay hay không. Hãy cấu hình các tùy chọn xuất riêng biệt cho từng định dạng.

## **Câu hỏi thường gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình bày?**

Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định việc lưới có được hiển thị hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Việc xóa các hướng dẫn vẽ có thay đổi khoảng cách lưới không?**

Không. Các hướng dẫn vẽ và khoảng cách lưới là các cài đặt độc lập. Xóa các hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình bày không?**

[View settings](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getViewProperties) được định nghĩa ở mức bản trình bày ([Normal View]/[Slide View]), không phải theo từng phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng tùy chọn người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với View Properties đã định trước để các bản trình bày mới mở cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getViewProperties) được lưu ở mức bản trình bày, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu với cùng cấu hình chế độ xem ban đầu.