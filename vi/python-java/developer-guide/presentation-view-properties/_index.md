---
title: Truy xuất và Cập nhật Thuộc tính Xem Bản trình chiếu trong Python qua Java
linktitle: Thuộc tính Xem
type: docs
weight: 80
url: /vi/python-java/presentation-view-properties/
keywords:
- thuộc tính xem
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bộ tách dọc tự động ghép
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự điều chỉnh
- phóng to mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khám phá các thuộc tính xem của Aspose.Slides cho Python qua Java để tùy chỉnh các slide PPT, PPTX và ODP — điều chỉnh bố cục, mức phóng to và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: bản trình chiếu, một vùng nội dung bên cạnh và một vùng nội dung phía dưới. Thuộc tính chế độ xem bình thường mô tả vị trí của các vùng nội dung này. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Phương thức [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của một bản trình chiếu.

Các lớp [NormalViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/) và [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewrestoredproperties/) và kiểu liệt kê [SplitterBarStateType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/) đã được thêm.

## **Về NormalViewProperties**

Đại diện cho các thuộc tính chế độ xem bình thường.

Các phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) chỉ định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Các phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) chỉ định liệu thanh phân tách dọc có nên tự động chuyển sang trạng thái thu nhỏ khi vùng bên đủ nhỏ.

Các phương thức [getPreferSingleView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) và [setPreferSingleView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) chỉ định liệu người dùng muốn xem một vùng nội dung đơn trên toàn cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) chỉ định trạng thái mà thanh phân tách ngang hoặc dọc sẽ được hiển thị. Thanh phân tách ngang tách bản trình chiếu khỏi vùng nội dung phía dưới; thanh phân tách dọc tách bản trình chiếu khỏi vùng nội dung bên cạnh. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Restored).

Các phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) và [getRestoredTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredTop) chỉ định kích thước của vùng slide trên hoặc bên của chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) tương ứng.

## **Về việc Khôi phục NormalViewProperties**

Xác định kích thước của vùng slide (rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredTop), cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) của chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không thu nhỏ và không phóng đại).

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) chỉ định kích thước của vùng slide (rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredTop), cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) chỉ định liệu kích thước của vùng nội dung bên phải có nên tự điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Ví dụ bên dưới cho thấy cách truy cập [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) cho một bản trình chiếu.

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

    # Khôi phục các thuộc tính xem của bản trình chiếu.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Giá Trị Phóng To Mặc Định**

{{% alert color="info" title="Lưu ý" %}}

Aspose.Slides for Python via Java hỗ trợ thiết lập giá trị phóng to mặc định sao cho nó đã được áp dụng khi bản trình chiếu mở. Điều này có thể thực hiện bằng cách đặt [ViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/) của một bản trình chiếu. [getSlideViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getSlideViewProperties) cũng như [getNotesViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNotesViewProperties) có thể được cấu hình bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách đặt [View Properties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/) của [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) trong [Aspose.Slides](/slides/vi/).

{{% /alert %}}

Để đặt các thuộc tính xem, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Đặt [View Properties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/) cho [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
3. Ghi bản trình chiếu dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Đặt các thuộc tính xem của bản trình chiếu.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Phần trăm phóng to cho chế độ xem slide.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Phần trăm phóng to cho chế độ xem ghi chú.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt các cài đặt xem khác nhau cho các phần khác nhau của bản trình chiếu không?**

Các [View settings](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getViewProperties) được định nghĩa ở mức bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), không phải cho từng phần, vì vậy một bộ tham số duy nhất sẽ áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính xem.

**Tôi có thể chuẩn bị một mẫu với các View Properties đã được định trước để các bản trình chiếu mới mở theo cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getViewProperties) được lưu ở mức bản trình chiếu, bạn có thể nhúng chúng vào một mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình xem ban đầu.