---
title: Quản lý tiêu đề và chân trang của bản trình chiếu bằng C++
linktitle: Tiêu đề và Chân trang
type: docs
weight: 140
url: /vi/cpp/presentation-header-and-footer/
keywords:
- tiêu đề
- văn bản tiêu đề
- chân trang
- văn bản chân trang
- đặt tiêu đề
- đặt chân trang
- tài liệu phát tay
- ghi chú
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách quản lý các trình giữ chỗ chân trang, ngày-giờ, số slide và tiêu đề trên các slide, trang ghi chú và tài liệu phát tay bằng Aspose.Slides cho C++."
---
## **Tổng quan**

PowerPoint sử dụng các trình giữ chỗ tiêu đề và chân trang khác nhau tùy thuộc vào loại trang. Aspose.Slides cho C++ cho phép bạn kiểm soát văn bản và hiển thị của các trình giữ chỗ này thông qua các giao diện quản lý tiêu đề/chân trang.

Các trình giữ chỗ có sẵn phụ thuộc vào phạm vi:

| Phạm vi | Tiêu đề | Chân trang | Ngày/giờ | Số slide/trang |
|---|---|---|---|---|
| Slide thường | Không | Có | Có | Có |
| Mẫu ghi chú | Có | Có | Có | Có |
| Slide ghi chú | Có | Có | Có | Có |
| Mẫu tài liệu phát tay | Có | Có | Có | Có |

Một slide trình chiếu thường không có trình giữ chỗ tiêu đề. Tiêu đề có sẵn trên các trang ghi chú và tài liệu phát tay. Đối với các slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide/thay vì.

Phạm vi của một thay đổi phụ thuộc vào trình quản lý bạn sử dụng. Giao diện [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideheaderfootermanager/) điều khiển một slide thường. Giao diện [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inotesslideheaderfootermanager/) điều khiển một slide ghi chú. Các trình quản lý master và layout cũng có thể lan truyền cài đặt tới các slide phụ thuộc, trong khi giao diện [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) điều khiển master tài liệu phát tay.

## **Đặt Chân trang, Ngày/Giờ và Số Slide trên Các Slide Thường**

Đối với các slide thường, quy trình cơ bản là truy cập trình quản lý tiêu đề/chân trang của mỗi slide, đặt văn bản chân trang và ngày/giờ, bật các trình giữ chỗ cần thiết và lưu bản trình chiếu. Số slide được tạo bởi bản trình chiếu, vì vậy bạn chỉ cần kiểm soát hiển thị của chúng.

Sử dụng [`SetFooterText`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) và [`SetDateTimeText`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) để đặt văn bản, và sử dụng [`SetFooterVisibility`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) và [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) để hiển thị các trình giữ chỗ tương ứng.

Ví dụ toàn diện sau áp dụng cùng một chân trang, văn bản ngày/giờ và hiển thị số slide cho tất cả các slide thường:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Nếu bạn cần cập nhật chỉ một slide, truy cập slide đó trực tiếp qua [`Presentation::get_Slide`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_slide/) thay vì lặp qua toàn bộ bộ sưu tập slide.

## **Đặt Tiêu đề và Chân trang trên Mẫu Ghi chú**

Mẫu ghi chú định nghĩa định dạng chung và hành vi của các trình giữ chỗ cho các trang ghi chú. Sử dụng giao diện [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslideheaderfootermanager/) khi bạn muốn thay đổi chỉ mẫu ghi chú.

Ví dụ sau đặt tiêu đề, chân trang và văn bản ngày/giờ trên mẫu ghi chú và làm cho tất cả các trình giữ chỗ được hỗ trợ hiển thị trên mẫu đó:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

Phương thức [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) trả về `nullptr` khi bản trình chiếu không chứa mẫu ghi chú.

## **Áp dụng Cài đặt Mẫu Ghi chú cho Các Slide Ghi chú Con**

Mẫu ghi chú có thể áp dụng cài đặt tiêu đề và chân trang cho chính nó và cho tất cả các slide ghi chú phụ thuộc. Sử dụng các phương pháp lan truyền chuyên dụng trên [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslideheaderfootermanager/) khi cùng một cài đặt cần được áp dụng trên toàn bộ cấu trúc ghi chú.

Ví dụ, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) và [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) cập nhật tiêu đề mẫu ghi chú và tất cả tiêu đề con. Các phương pháp tương đương có sẵn cho chân trang, ngày/giờ và số slide.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Các phương pháp lan truyền được sử dụng ở trên là [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) và [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Đặt Tiêu đề và Chân trang trên Một Slide Ghi chú Cá nhân**

Một slide ghi chú thuộc về một slide thường cụ thể. Sử dụng giao diện [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inotesslideheaderfootermanager/) của nó khi bạn muốn tùy chỉnh chỉ trang ghi chú đó.

Phương thức [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inotesslidemanager/addnotesslide/) trả về slide ghi chú cho slide hiện tại và tạo một slide nếu nó chưa tồn tại. Ví dụ sau cấu hình trang ghi chú liên kết với slide đầu tiên của bản trình chiếu:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Nếu bạn trước tiên lan truyền cài đặt từ mẫu ghi chú và sau đó thay đổi một slide ghi chú cá nhân, các cài đặt per-slide sau này cho phép bạn tùy chỉnh trang ghi chú đó một cách độc lập.

## **Đặt Tiêu đề và Chân trang trên Mẫu Tài liệu Phát tay**

Các trang tài liệu phát tay sử dụng mẫu tài liệu phát tay cho các trình giữ chỗ tiêu đề, chân trang, ngày/giờ và số trang. Khác với các trang ghi chú, cài đặt tài liệu phát tay được quản lý qua mẫu tài liệu phát tay chứ không phải qua các slide phát tay riêng lẻ.

Sử dụng [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) để truy cập mẫu tài liệu phát tay. Nếu nó không tồn tại, gọi [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) để tạo mẫu tài liệu phát tay mặc định.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Hiểu Phạm vi và Kế thừa**

Chọn trình quản lý tiêu đề/chân trang phù hợp với phạm vi bạn muốn thay đổi:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideheaderfootermanager/) thay đổi cài đặt chân trang, ngày/giờ và số slide cho một slide thường.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslideheaderfootermanager/) điều khiển một slide bố cục và có thể lan truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslideheaderfootermanager/) điều khiển một master slide thường và có thể lan truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslideheaderfootermanager/) điều khiển master ghi chú và có thể lan truyền cài đặt tới tất cả các slide ghi chú phụ thuộc.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inotesslideheaderfootermanager/) thay đổi một slide ghi chú và hỗ trợ trình giữ chỗ tiêu đề bên cạnh chân trang, ngày/giờ và số slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) thay đổi master tài liệu phát tay và hỗ trợ tất cả bốn loại trình giữ chỗ.

Sử dụng việc lan truyền từ một master hoặc layout khi cùng một cài đặt cần áp dụng trên toàn bộ phân cấp của nó. Sử dụng một slide cá nhân hoặc trình quản lý slide ghi chú khi bạn cần cài đặt cục bộ cho một trang.

## **FAQ**

**Có thể thêm tiêu đề vào slide thường không?**

Không. PowerPoint không định nghĩa trình giữ chỗ tiêu đề cho các slide thường. Trên các slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide. Trình giữ chỗ tiêu đề có sẵn trên các trang ghi chú và tài liệu phát tay.

**Nếu trình giữ chỗ chân trang, ngày/giờ, hoặc số slide không hiển thị thì sao?**

Sử dụng trình quản lý tiêu đề/chân trang tương ứng để kiểm tra tính hiển thị và bật nó khi cần. Ví dụ, [`get_IsFooterVisible`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) báo cáo xem trình giữ chỗ chân trang có tồn tại hay không, và [`SetFooterVisibility`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) thay đổi tính hiển thị của nó.

**Làm sao để bắt đầu đánh số slide từ giá trị khác 1?**

Sử dụng [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/set_firstslidenumber/) để đặt số slide đầu tiên. Các trình giữ chỗ số slide sau đó sẽ sử dụng chuỗi đánh số đã cập nhật.

**Điều gì xảy ra với tiêu đề và chân trang khi xuất ra PDF, hình ảnh hoặc HTML?**

Các yếu tố tiêu đề và chân trang hiển thị được kết xuất cùng với phần còn lại của nội dung bản trình chiếu trong định dạng đầu ra. Ngoài hình thức của chúng phụ thuộc vào loại trang được xuất và các cài đặt hiển thị trình giữ chỗ tương ứng.