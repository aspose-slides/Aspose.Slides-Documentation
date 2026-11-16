---
title: "Truy xuất và Cập nhật Thuộc tính Hiển thị Bản trình chiếu trong C++"
linktitle: "Thuộc tính Hiển thị"
type: docs
weight: 80
url: /vi/cpp/presentation-view-properties/
keywords:
- "thuộc tính hiển thị"
- "chế độ xem thường"
- "nội dung dàn ý"
- "biểu tượng dàn ý"
- "định vị thanh chia dọc"
- "chế độ xem đơn"
- "trạng thái thanh"
- "kích thước chiều"
- "tự động điều chỉnh"
- "thu phóng mặc định"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "C++"
- "Aspose.Slides"
description: "Sử dụng Aspose.Slides for C++ để cấu hình bố cục chế độ xem thường, thu phóng slide và ghi chú, khoảng cách lưới, và khả năng hiển thị nhận xét trong các bản trình chiếu PowerPoint."
---
## **Giới thiệu**

Trong chế độ xem thường của PowerPoint, slide xuất hiện giữa một ô bên để hiển thị các ảnh thu nhỏ hoặc dàn ý và một ô ghi chú ở dưới. Aspose.Slides for C++ cung cấp các tùy chỉnh đã lưu của bản trình chiếu thông qua [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Những tùy chỉnh này bao gồm bố cục ô, mức thu phóng, khoảng cách lưới và hiển thị nhận xét.

## **Về INormalViewProperties**

Sử dụng [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) để truy cập giao diện [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) điều khiển việc hiển thị biểu tượng bên cạnh tiêu đề slide trong dàn ý. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) cho phép ô bên dính vào trạng thái thu nhỏ khi người dùng thu hẹp nó. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) cho biết ưu tiên hiển thị một ô trong toàn bộ cửa sổ.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) điều khiển bộ chia giữa ô bên và slide. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) điều khiển bộ chia phía trên ô ghi chú. Cả hai chấp nhận một giá trị [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) là `Minimized`, `Maximized` hoặc `Restored`.

## **Về khôi phục INormalViewProperties**

Khi một bộ chia được khôi phục, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) cung cấp kích thước đã lưu của ô bên và [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) cung cấp kích thước đã lưu của khu vực slide phía trên. Cả hai đều phơi bày [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Phương thức [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) của nó chấp nhận phần trăm từ 0 đến 100, và [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) kiểm soát việc trình chỉnh sửa tự động điều chỉnh kích thước khi cửa sổ được thay đổi kích cỡ.

Ví dụ này cập nhật một bản trình chiếu hiện có. Nó khôi phục bộ chia ngang, đặt kích thước khu vực slide phía trên mà [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) cung cấp thành 80 % với chế độ tự động điều chỉnh được bật, và phóng to bộ chia dọc. Nó cũng bật biểu tượng dàn ý bằng [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) cho chế độ xem dàn ý.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Đặt giá trị thu phóng mặc định**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) và [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) lưu các cài đặt thu phóng độc lập cho trình chỉnh sửa. Các cài đặt này không ảnh hưởng đến kích thước slide, phát trình chiếu, hay độ phân giải xuất ảnh.

Ví dụ này mở một bản trình chiếu hiện có và bật cân bằng tự động với [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) để khớp slide với cửa sổ chỉnh sửa. Đối với trang ghi chú, nó tắt cân bằng tự động và dùng [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) để đặt mức thu phóng cố định 80 %.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Đặt khoảng cách lưới**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) đặt khoảng cách giữa các đường lưới trong toàn bộ bản trình chiếu. Nó nhận một giá trị dương tính bằng điểm, với 72 điểm mỗi inch. Ví dụ này in ra khoảng cách hiện tại trong một bản trình chiếu hiện có và lưu lưới một phần tư inch bằng cách đặt khoảng cách thành 18 điểm.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Lưới lặp lại theo một khoảng cố định. [Hướng dẫn vẽ](/slides/vi/cpp/drawing-guides/) đánh dấu các vị trí ngang hoặc dọc riêng lẻ. Cả hai đều là công cụ hỗ trợ chỉnh sửa và chỉ xuất hiện trong các trình chỉnh sửa hiển thị chúng. Các buổi trình chiếu và xuất ra PDF, ảnh hoặc SVG sẽ không bao gồm chúng.

## **Hiển thị hoặc Ẩn nhận xét khi mở bản trình chiếu**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) lưu một tùy chọn mà các trình chỉnh sửa tương thích sử dụng khi mở bản trình chiếu. Đối với một bản trình chiếu hiện có có nhận xét, ví dụ này in ra cài đặt hiện tại và lưu một bản sao với nhận xét ẩn. Nó cũng gọi [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) với [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) để bản sao mở trong chế độ xem slide.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Việc ẩn nhận xét vẫn giữ nguyên nội dung, tác giả, vị trí, phản hồi và trạng thái của chúng. Để thay đổi nội dung nhận xét, hãy xem [Presentation Comments](/slides/vi/cpp/presentation-comments/). Cài đặt xuất kiểm soát việc nhận xét có xuất hiện trong PDF, HTML, ảnh, ghi chú hay tài liệu phát tay hay không.

## **Câu hỏi thường gặp**

**Tại sao lưới lại ẩn khi tôi mở lại bản trình chiếu?**

Bản trình chiếu lưu khoảng cách lưới. Để thấy lưới, hãy bật hiển thị lưới trong trình chỉnh sửa.

**Việc xóa hướng dẫn vẽ có làm thay đổi khoảng cách lưới không?**

Không. Thêm, di chuyển hoặc xóa một hướng dẫn không làm thay đổi khoảng cách lưới.

**Các phần khác nhau của một bản trình chiếu có thể có cài đặt xem khác nhau không?**

Không. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) áp dụng cho toàn bộ bản trình chiếu.

**Tôi có thể lưu các cài đặt xem khác nhau cho các người dùng khác nhau không?**

Tệp chỉ lưu một bộ thuộc tính xem cho mọi người. Trình chỉnh sửa có thể áp dụng các tùy chỉnh địa phương của người dùng.

**Tôi có thể lưu cài đặt xem trong mẫu không?**

Có. Các bản trình chiếu tạo từ mẫu sẽ kế thừa các cài đặt xem đã lưu của mẫu.