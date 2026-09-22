---
title: "Lấy và Cập nhật Thuộc tính Hiển thị Bản trình bày trong C++"
linktitle: "Thuộc tính Hiển thị"
type: docs
weight: 80
url: /vi/cpp/presentation-view-properties/
keywords:
- "thuộc tính hiển thị"
- "chế độ xem bình thường"
- "nội dung đề cương"
- "biểu tượng đề cương"
- "bắt dính thanh chia dọc"
- "chế độ xem đơn"
- "trạng thái thanh"
- "kích thước chiều"
- "tự điều chỉnh"
- "phóng to mặc định"
- "PowerPoint"
- "OpenDocument"
- "bản trình bày"
- "C++"
- "Aspose.Slides"
description: "Khám phá các thuộc tính hiển thị của Aspose.Slides cho C++ để tùy chỉnh các định dạng PPT, PPTX và ODP—điều chỉnh bố cục, mức phóng to và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: slide, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái hiển thị vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình bày được lưu lần cuối.

Phương thức [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình bày. 

Các giao diện [INormalViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inormalviewrestoredproperties/) và các thành phần kế thừa, cùng enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/splitterbarstatetype/) đã được bổ sung.

## **Về INormalViewProperties**

Đại diện cho các thuộc tính chế độ xem bình thường.

Thuộc tính **ShowOutlineIcons** chỉ định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Thuộc tính **SnapVerticalSplitter** chỉ định liệu thanh chia dọc có tự động thu nhỏ khi vùng bên đủ nhỏ không.

Thuộc tính **PreferSingleView** chỉ định liệu người dùng ưu tiên xem một vùng nội dung duy nhất trên toàn cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể lựa chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các thuộc tính **VerticalBarState** và **HorizontalBarState** chỉ định trạng thái mà thanh chia dọc hoặc ngang sẽ được hiển thị. Thanh chia dọc tách slide khỏi vùng nội dung bên, thanh chia ngang tách slide khỏi vùng nội dung phía dưới slide. Các giá trị có thể là: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** và **SplitterBarStateType.Restored**.

Các thuộc tính **RestoredLeft** và **RestoredTop** chỉ định kích thước của vùng slide phía trên hoặc bên khi giá trị **SplitterBarStateType.Restored** được áp dụng cho **VerticalBarState** và **HorizontalBarState** tương ứng.

## **Về việc khôi phục INormalViewProperties**

Xác định kích thước của vùng slide (độ rộng khi là con của RestoredTop, độ cao khi là con của RestoredLeft) của chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng đại).

Thuộc tính **DimensionSize** chỉ định kích thước của vùng slide (độ rộng khi là con của restoredTop, độ cao khi là con của restoredLeft).

Thuộc tính **AutoAdjust** chỉ định liệu vùng nội dung bên có tự điều chỉnh để bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách truy cập các thuộc tính **ViewProperties.NormalViewProperties** cho một bản trình bày.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Khôi phục các thuộc tính hiển thị của bản trình bày
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Cài đặt Giá trị Phóng to Mặc định**

Aspose.Slides for C++ hiện hỗ trợ thiết lập giá trị phóng to mặc định cho bản trình bày sao cho khi bản trình bày được mở, mức phóng to đã được đặt sẵn. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/) của một bản trình bày. Các thuộc tính chế độ xem slide cũng như [get_NotesViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/get_notesviewproperties/) có thể được thiết lập bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách thiết lập View Properties cho Presentation trong Aspose.Slides.

Để thiết lập các thuộc tính hiển thị, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/)
2. Thiết lập View [Properties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/) của Presentation
3. Ghi bản trình bày thành tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã thiết lập giá trị phóng to cho chế độ xem slide cũng như chế độ xem ghi chú.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Đặt các thuộc tính hiển thị của bản trình bày
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Giá trị phóng to dưới dạng phần trăm cho chế độ xem slide
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Giá trị phóng to dưới dạng phần trăm cho chế độ xem ghi chú 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Cài đặt Khoảng cách Lưới**

Sử dụng [Presentation::get_ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_viewproperties/) để truy cập các thiết lập hiển thị toàn bản trình bày. Các phương thức [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iviewproperties/get_gridspacing/) và [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iviewproperties/set_gridspacing/) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền tảng. Cài đặt này áp dụng cho toàn bộ bản trình bày, không phải chỉ một slide riêng lẻ. Khoảng cách lưới được tính bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ sau mở một tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, thiết lập khoảng cách một phần tư inch và lưu kết quả.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Lưới khác với [drawing guides](/slides/vi/cpp/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng đều đặn, trong khi các hướng dẫn vẽ là các đường căn chỉnh ngang hoặc dọc được đặt vị trí riêng biệt. Thêm, di chuyển hoặc xóa các hướng dẫn vẽ không thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là trợ giúp chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc trình chiếu. Lưu khoảng cách lưới không đảm bảo một trình chỉnh sửa sẽ hiển thị lưới: khả năng hiển thị còn phụ thuộc vào tùy chỉnh của người xem hoặc trình chỉnh sửa.

## **Câu hỏi thường gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình bày?**

Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định có hiển thị lưới hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Việc xóa các drawing guides có thay đổi khoảng cách lưới không?**

Không. Drawing guides và khoảng cách lưới là các cài đặt độc lập. Xóa các hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt hiển thị khác nhau cho các phần khác nhau của bản trình bày không?**

[View settings](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_viewproperties/) được định nghĩa ở mức bản trình bày ([Normal View](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), không phải theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn tài liệu khi mở.

**Tôi có thể định trước các trạng thái hiển thị khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Ứng dụng xem có thể tôn trọng tùy chỉnh của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính hiển thị.

**Tôi có thể chuẩn bị một mẫu với View Properties đã định trước để các bản trình bày mới mở theo cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_viewproperties/) được lưu ở mức bản trình bày, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu đó với cấu hình hiển thị ban đầu giống nhau.