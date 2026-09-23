---
title: Truy xuất và Cập nhật Thuộc tính Xem Bản trình bày trong C++
linktitle: Thuộc tính Xem
type: docs
weight: 80
url: /vi/cpp/presentation-view-properties/
keywords: 
- thuộc tính xem
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bắt dính thanh tách dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Khám phá các thuộc tính xem của Aspose.Slides cho C++ để tùy chỉnh các định dạng slide PPT, PPTX và ODP — điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba khu vực nội dung: slide chính, khu vực nội dung bên và khu vực nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các khu vực nội dung này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như lúc lưu lần cuối.

Phương thức [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) đã được thêm để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình bày. 

Các giao diện [INormalViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inormalviewrestoredproperties/) và các lớp con của chúng, enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/splitterbarstatetype/) đã được bổ sung.

## **Về INormalViewProperties**

Biểu diễn các thuộc tính chế độ xem bình thường.

Thuộc tính **ShowOutlineIcons** chỉ định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ khu vực nội dung nào của chế độ xem bình thường hay không.

Thuộc tính **SnapVerticalSplitter** chỉ định liệu thanh tách dọc có tự động co về trạng thái thu nhỏ khi khu vực bên đủ nhỏ không.

Thuộc tính **PreferSingleView** chỉ định liệu người dùng muốn xem một khu vực nội dung duy nhất trên toàn cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba khu vực nội dung hay không. Khi bật, ứng dụng có thể chọn hiển thị một trong các khu vực nội dung trên toàn cửa sổ.

Các thuộc tính **VerticalBarState** và **HorizontalBarState** chỉ định trạng thái mà thanh tách dọc hoặc ngang sẽ được hiển thị. Thanh tách ngang tách slide khỏi khu vực nội dung phía dưới, thanh tách dọc tách slide khỏi khu vực nội dung bên. Các giá trị có thể là: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** và **SplitterBarStateType.Restored**.

Các thuộc tính **RestoredLeft** và **RestoredTop** chỉ định kích thước của khu vực slide ở trên hoặc bên trong chế độ xem bình thường, khi giá trị **SplitterBarStateType.Restored** được áp dụng cho **VerticalBarState** và **HorizontalBarState** tương ứng.

## **Về việc khôi phục INormalViewProperties**

Chỉ định kích thước của khu vực slide (chiều rộng khi là con của RestoredTop, chiều cao khi là con của RestoredLeft) trong chế độ xem bình thường, khi khu vực có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng đại).

Thuộc tính **DimensionSize** chỉ định kích thước của khu vực slide (chiều rộng khi là con của RestoredTop, chiều cao khi là con của RestoredLeft).

Thuộc tính **AutoAdjust** chỉ định liệu khu vực nội dung bên có tự điều chỉnh để bù đắp kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách truy cập các thuộc tính **ViewProperties.NormalViewProperties** cho một bản trình bày.

``` cpp
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

// Khôi phục các thuộc tính xem của bản trình bày
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Đặt giá trị thu phóng mặc định**

Aspose.Slides for C++ hiện hỗ trợ đặt giá trị thu phóng mặc định cho bản trình bày sao cho khi mở bản trình bày, mức thu phóng đã được áp dụng sẵn. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/) của một bản trình bày. Các Thuộc tính chế độ xem slide cũng như [get_NotesViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/get_notesviewproperties/) có thể được thiết lập bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách đặt Thuộc tính Xem của bản trình bày trong Aspose.Slides.

Để thiết lập các thuộc tính xem, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) 
1. Thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/) của bản trình bày 
1. Ghi bản trình bày dưới dạng tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã đặt giá trị thu phóng cho chế độ xem slide cũng như chế độ xem ghi chú.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Đặt các thuộc tính xem của bản trình bày
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Giá trị thu phóng theo phần trăm cho chế độ xem slide
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Giá trị thu phóng theo phần trăm cho chế độ xem ghi chú 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Đặt khoảng cách lưới**

Sử dụng [Presentation::get_ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_viewproperties/) để truy cập các cài đặt chế độ xem toàn bản trình bày. Các phương thức [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iviewproperties/get_gridspacing/) và [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iviewproperties/set_gridspacing/) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền tảng. Cài đặt này áp dụng cho toàn bộ bản trình bày, không phải cho một slide riêng lẻ. Khoảng cách lưới được xác định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

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

Lưới khác với [drawing guides](/slides/vi/cpp/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng đều đặn, trong khi các hướng dẫn vẽ là các đường thẳng ngang hoặc dọc được đặt vị trí riêng lẻ. Thêm, di chuyển hoặc xóa bỏ các hướng dẫn vẽ không làm thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được render như nội dung slide trong PDF, hình ảnh, SVG hoặc trong chế độ trình chiếu. Lưu khoảng cách lưới không đảm bảo một trình chỉnh sửa sẽ hiển thị lưới; khả năng hiển thị còn phụ thuộc vào tùy chọn của người xem hoặc trình chỉnh sửa.

## **Hiển thị hoặc ẩn bình luận khi mở bản trình bày**

Sử dụng [Presentation::get_ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_viewproperties/) để truy cập các cài đặt chế độ xem toàn bản trình bày. Sử dụng [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iviewproperties/get_showcomments/) và [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iviewproperties/set_showcomments/) để lưu tùy chọn về việc có hiển thị bình luận khi bản trình bày được mở trong PowerPoint hoặc trình chỉnh sửa tương thích khác.

Cài đặt này chỉ kiểm soát tùy chọn lưu trạng thái xem. Nó không thêm, xóa, chỉnh sửa hoặc giải quyết bình luận. Ẩn bình luận giữ nguyên nội dung, tác giả, vị trí, phản hồi và trạng thái của chúng. Xem [Presentation Comments](/slides/vi/cpp/presentation-comments/) để biết các thao tác thay đổi bình luận.

Ví dụ sau yêu cầu một tệp `comments.pptx` hiện có có chứa bình luận. Nó in ra tùy chọn hiển thị hiện tại, yêu cầu ẩn bình luận và lưu một tệp PPTX mới mà không xóa bất kỳ bình luận nào. Nó cũng sử dụng [IViewProperties::set_LastView](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iviewproperties/set_lastview/) cùng với [ViewType::SlideView](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewtype/) để cấu hình chế độ chỉnh sửa ban đầu cùng với tính năng hiển thị bình luận.

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
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Cài đặt này không quyết định việc bình luận có được bao gồm trong các xuất PDF, HTML, hình ảnh, ghi chú hoặc tài liệu rút gọn hay không. Hãy cấu hình các tùy chọn xuất riêng biệt tương ứng.

## **FAQ**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình bày?**

Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định liệu lưới có được hiển thị hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Việc xóa các hướng dẫn vẽ có làm thay đổi khoảng cách lưới không?**

Không. Các hướng dẫn vẽ và khoảng cách lưới là các cài đặt độc lập. Xóa hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình bày không?**

[View settings](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_viewproperties/) được định nghĩa ở mức bản trình bày ([Normal View](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), không phải theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích người dùng, nhưng tệp chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với các Thuộc tính Xem đã định trước để các bản trình bày mới mở cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_viewproperties/) được lưu ở mức bản trình bày, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu đó với cấu hình chế độ xem ban đầu giống nhau.