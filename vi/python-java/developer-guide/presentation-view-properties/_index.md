---
title: Truy xuất và Cập nhật Thuộc tính hiển thị Bản trình chiếu trong Python qua Java
linktitle: Thuộc tính hiển thị
type: docs
weight: 80
url: /vi/python-java/presentation-view-properties/
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
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khám phá các thuộc tính hiển thị của Aspose.Slides cho Python qua Java để tùy chỉnh các slide PPT, PPTX và ODP — điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: bản trình chiếu tự nó, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính chế độ xem bình thường mô tả vị trí của các vùng nội dung này. Thông tin này cho phép ứng dụng lưu trạng thái chế độ xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Phương thức [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) đã được thêm để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của một bản trình chiếu.

Các lớp [NormalViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/) và [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewrestoredproperties/) và kiểu liệt kê [SplitterBarStateType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/) đã được thêm.

## **Về NormalViewProperties**

Đại diện cho các thuộc tính chế độ xem bình thường.

Các phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) chỉ định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Các phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) chỉ định liệu thanh chia dọc có nên tự động thu nhỏ khi vùng bên đủ nhỏ hay không.

Các phương thức [getPreferSingleView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) và [setPreferSingleView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) chỉ định liệu người dùng có ưu tiên xem một vùng nội dung duy nhất toàn màn hình hơn chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) chỉ định trạng thái mà thanh chia ngang hoặc dọc nên được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung bên dưới slide; thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Restored).

Các phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) và [getRestoredTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredTop) chỉ định kích thước của vùng slide trên hoặc bên của chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/python-java/aspose.slides/splitterbarstatetype/#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), tương ứng.

## **Về việc Khôi phục NormalViewProperties**

Xác định kích thước của vùng slide (chiều rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredTop), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) trong chế độ xem bình thường, khi vùng có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng đại).

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) chỉ định kích thước của vùng slide (chiều rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredTop), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) chỉ định liệu kích thước của vùng nội dung bên có nên bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Ví dụ dưới đây cho thấy cách truy cập [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) cho một bản trình chiếu.

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

    # Khôi phục các thuộc tính hiển thị của bản trình chiếu.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Giá Trị Thu Phóng Mặc Định**

{{% alert color="info" title="Note" %}}
Aspose.Slides cho Python qua Java hỗ trợ đặt giá trị thu phóng mặc định để nó đã được áp dụng ngay khi bản trình chiếu mở. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/) của một bản trình chiếu. [getSlideViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getSlideViewProperties) cũng như [getNotesViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNotesViewProperties) có thể được cấu hình bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ cách đặt [View Properties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/) của [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) trong Aspose.Slides.
{{% /alert %}}

Để đặt các thuộc tính chế độ xem, hãy làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Đặt [View Properties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/) của [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Ghi bản trình chiếu dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Trong ví dụ dưới đây, chúng tôi đặt giá trị thu phóng cho cả chế độ xem slide và chế độ xem ghi chú.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Đặt các thuộc tính hiển thị của bản trình chiếu.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Phần trăm thu phóng cho chế độ xem slide.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Phần trăm thu phóng cho chế độ xem ghi chú.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Khoảng Cách Lưới**

Sử dụng [Presentation.getViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getViewProperties) để truy cập các cài đặt chế độ xem toàn bộ bản trình chiếu. Các phương thức [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getGridSpacing) và [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#setGridSpacing) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền. Cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho một slide riêng lẻ. Khoảng cách lưới được xác định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, như yêu cầu trong tài liệu API.

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

Lưới khác với [drawing guides](/slides/vi/python-java/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng đều đặn, trong khi các hướng dẫn vẽ được đặt vị trí riêng biệt thành các đường căn chỉnh ngang hoặc dọc. Thêm, di chuyển hoặc xóa các hướng dẫn vẽ không làm thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là trợ giúp chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc bản trình chiếu. Lưu khoảng cách lưới không đảm bảo rằng một trình chỉnh sửa sẽ hiển thị lưới: khả năng hiển thị cũng phụ thuộc vào sở thích của người xem hoặc trình chỉnh sửa.

## **Câu Hỏi Thường Gặp**

**Tại sao lưới không hiển thị khi tôi mở lại bản trình chiếu?**

Tệp lưu trữ khoảng cách lưới, nhưng trình chỉnh sửa kiểm soát việc lưới có hiển thị hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Việc xóa các hướng dẫn vẽ có thay đổi khoảng cách lưới không?**

Không. Các hướng dẫn vẽ và khoảng cách lưới là các cài đặt độc lập. Xóa các hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình chiếu không?**

[Cài đặt chế độ xem](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getViewProperties) được định nghĩa ở mức bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), không theo từng phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với các Thuộc tính chế độ xem được định trước để các bản trình chiếu mới mở theo cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getViewProperties) được lưu ở mức bản trình chiếu, bạn có thể nhúng chúng vào một mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình chế độ xem ban đầu.