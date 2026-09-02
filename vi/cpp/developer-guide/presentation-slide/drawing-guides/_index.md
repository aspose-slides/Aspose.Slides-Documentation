---
title: Quản lý Đường hướng dẫn trong Bản trình bày bằng C++
linktitle: Đường hướng dẫn
type: docs
weight: 85
url: /vi/cpp/drawing-guides/
keywords:
- đường hướng dẫn
- hướng dẫn ngang
- hướng dẫn dọc
- hướng dẫn căn chỉnh
- chế độ xem slide
- slide chủ
- slide bố trí
- master ghi chú
- master tài liệu phát
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Thêm, truy cập và xóa các đường hướng dẫn ngang và dọc trong bản trình bày PowerPoint bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Các đường hướng dẫn là các đường ngang và dọc có thể điều chỉnh, giúp người dùng căn chỉnh các hình dạng một cách nhất quán khi chỉnh sửa bản trình bày trong PowerPoint. Chúng đặc biệt hữu ích khi một ứng dụng tạo ra bản trình bày sẽ được tinh chỉnh thủ công sau này: ứng dụng có thể lưu các công cụ căn chỉnh mà tác giả nên tuân theo khi thêm hoặc di chuyển nội dung.

Các đường hướng dẫn là công cụ hỗ trợ chỉnh sửa, không phải nội dung slide. Chúng không xuất hiện trong chế độ chiếu slide hay đầu ra đã được render. Aspose.Slides for C++ cung cấp chúng thông qua giao diện [IDrawingGuidesCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idrawingguidescollection/) . Một đường hướng dẫn được biểu diễn bằng [IDrawingGuide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idrawingguide/) và có hướng, vị trí và màu sắc.

Vị trí được đo bằng điểm (points) tính từ góc trên‑trái của slide hoặc master liên quan. Đường dọc sử dụng tọa độ ngang, thường nằm trong khoảng từ 0 tới chiều rộng slide. Đường ngang sử dụng tọa độ dọc, thường nằm trong khoảng từ 0 tới chiều cao slide.

## **Thêm Đường Hướng Dẫn vào Chế độ Xem Slide**

Sử dụng [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) để quản lý các đường hướng dẫn hiển thị khi chỉnh sửa các slide bình thường. Gọi [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idrawingguidescollection/add/) với một giá trị [Orientation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/orientation/) và một vị trí tính bằng điểm.

Ví dụ sau thêm một đường dọc ở phía bên phải của trung tâm slide và một đường ngang phía dưới nó:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Truy cập Đường Hướng Dẫn**

Phương thức [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idrawingguidescollection/get_count/) và phương thức [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idrawingguidescollection/idx_get/) cung cấp cách truy cập các đường hiện có. Các phương thức [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idrawingguide/get_position/) và [IDrawingGuide::get_Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idrawingguide/get_color/) trả về các thuộc tính hiện tại của một đường. Các phương thức setter tương ứng có thể thay đổi các thuộc tính đó.

Ví dụ sau đọc các đường hướng dẫn trong chế độ xem slide từ bản trình bày đã tạo ở trên:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **Thêm Đường Hướng Dẫn vào Slide Master và Layout**

Slide master và mỗi slide layout của nó có thể có bộ sưu tập đường hướng dẫn riêng. Sử dụng [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/get_drawingguides/) cho một slide master và [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/get_drawingguides/) cho một slide layout.

Ví dụ sau thêm một đường dọc vào slide master đầu tiên và một đường ngang vào slide layout đầu tiên:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Thêm Đường Hướng Dẫn vào Master Ghi chú và Handout**

Master ghi chú và handout master cũng hỗ trợ các đường hướng dẫn. Sử dụng [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslide/get_drawingguides/) và [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) để truy cập các bộ sưu tập của chúng. Nếu một bản trình bày không chứa một trong các master này, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) hoặc [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) sẽ tạo master mặc định và trả về nó.

Ví dụ sau thêm một đường ngang vào master ghi chú và một đường dọc vào handout master:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Xóa Đường Hướng Dẫn**

Gọi [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idrawingguidescollection/clear/) để xóa mọi đường khỏi một bộ sưu tập cụ thể. Việc xóa một bộ sưu tập không ảnh hưởng đến các đường được lưu trong phạm vi khác.

Ví dụ sau xóa các đường trong chế độ xem slide và tất cả các đường trên slide master, slide layout, master ghi chú và handout master mà không tạo các master còn thiếu:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Các đường hướng dẫn có xuất hiện trong chế độ chiếu slide hoặc hình ảnh xuất khẩu không?**

Không. Các đường hướng dẫn là công cụ căn chỉnh để chỉnh sửa và không được render như nội dung trình chiếu.

**Có thể thêm một đường hướng dẫn trực tiếp vào một slide bình thường riêng lẻ không?**

Các đường hướng dẫn chỉnh sửa cho slide bình thường được lưu trong thuộc tính chế độ xem slide của bản trình bày. Các bộ sưu tập đường riêng biệt có sẵn cho slide master, slide layout, master ghi chú và handout master.

**Đơn vị nào được sử dụng cho vị trí của đường hướng dẫn?**

Vị trí được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Vị trí dọc được đo từ cạnh trái, và vị trí ngang được đo từ cạnh trên.

**Việc xóa các đường hướng dẫn có loại bỏ các hình dạng hoặc thay đổi nội dung slide không?**

Không. Phương thức `Clear` chỉ xóa các đường trong bộ sưu tập được chọn. Các hình dạng và các nội dung slide khác vẫn không thay đổi.