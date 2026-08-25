---
title: Quản lý các phần slide trong bản trình bày với C++
linktitle: Phần Slide
type: docs
weight: 100
url: /vi/cpp/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- lấy slide của phần
- xử lý slide của phần
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Quản lý các phần slide với Aspose.Slides cho C++: tạo, đổi tên, sắp xếp lại, lấy và xử lý các slide của phần trong bản trình bày PPTX."
---
## **Giới thiệu**

Các phần (section) sắp xếp các slide liên tiếp thành các nhóm có tên mà không thay đổi nội dung slide. Với Aspose.Slides cho C++, bạn có thể tạo, sắp xếp lại, đổi tên, kiểm tra và xóa các phần thông qua phương thức [Presentation::get_Sections](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_sections/).

Các phần đặc biệt hữu ích khi:

- một bản trình bày lớn cần được chia thành các chủ đề hoặc chương logic;
- các nhóm slide khác nhau được giao cho các cộng tác viên khác nhau;
- slide cần được xử lý, di chuyển hoặc hợp nhất theo nhóm.

Chọn các tên phần ngắn gọn mô tả mục đích của các slide được nhóm lại. Vì phần là một phần của cấu trúc bản trình bày, hãy sử dụng API của phần để xác định thành viên thay vì suy ra từ vị trí slide.

## **Tạo và quản lý phần**

Sử dụng [ISectionCollection::AddSection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isectioncollection/addsection/) để tạo một phần bằng cách chỉ định tên và slide bắt đầu. Aspose.Slides xác định các slide thuộc phần dựa trên cấu trúc phần hiện tại của bản trình bày.

Cùng [ISectionCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isectioncollection/) cũng cho phép bạn:

- di chuyển một phần cùng với các slide của nó bằng cách sử dụng [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- xóa chỉ định nghĩa phần bằng [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isectioncollection/removesection/), mà giữ lại các slide;
- xóa một phần và các slide của nó bằng [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- thêm một phần trống ở cuối bằng [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isectioncollection/appendemptysection/).

Ví dụ sau tạo hai phần, di chuyển một trong số chúng, xóa nó cùng các slide và thêm một phần trống vào cuối:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

Sau các thao tác này, bản trình bày chứa phần `Introduction` với các slide của nó và một phần trống `Appendix`. Phần `Results` và các slide của nó đã bị xóa.

## **Đổi tên phần**

Để đổi tên một phần, gọi [ISection::set_Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/set_name/). Các slide và vị trí của phần vẫn không thay đổi.

Ví dụ sau tạo một phần và thay đổi tên của nó:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **Lấy slide từ phần**

Phương thức [Presentation::get_Sections](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_sections/) trả về một [ISectionCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isectioncollection/) mà bạn có thể duyệt. Đối với mỗi [ISection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/), gọi [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/getslideslistofsection/) để lấy các slide hiện đang thuộc về nó. Phương thức trả về một [ISectionSlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isectionslidecollection/), cung cấp đếm, truy cập theo chỉ mục và duyệt.

Ví dụ sau tạo hai phần có nội dung và một phần trống, sau đó in [tên](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/get_name/), [định danh](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/get_sectionid/), [slide bắt đầu](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/get_startedfromslide/), số slide và số thứ tự slide của mỗi phần. Nó sử dụng truy cập theo chỉ mục để đọc slide đầu tiên và vòng lặp `for` dựa trên phạm vi để xử lý mọi slide. Đối với phần trống, bộ sưu tập trả về có đếm bằng zero, không sử dụng truy cập theo chỉ mục và việc duyệt không thực hiện bất kỳ vòng lặp nào.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

Thành viên của phần được xác định bởi cấu trúc phần của bản trình bày. Không tính toán phạm vi của phần một cách thủ công từ [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/get_startedfromslide/), chỉ mục slide và slide bắt đầu của phần tiếp theo.

Các chỉnh sửa cấu trúc có thể thay đổi cả các slide được trả về cho một phần và số thứ tự slide của chúng. Điều này bao gồm việc sắp xếp lại slide, sao chép một slide vào một phần, di chuyển một phần cùng với các slide của nó, xóa slide và xóa phần. Ví dụ tiếp theo gọi [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/getslideslistofsection/) sau mỗi thay đổi như vậy thay vì giữ các giả định về giới hạn trước đây của phần.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

Gọi [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/getslideslistofsection/) lại mỗi khi slide hoặc phần được sắp xếp lại, sao chép, di chuyển hoặc xóa. Điều này giữ cho việc xử lý tiếp theo phù hợp với cấu trúc hiện tại của bản trình bày.

Định dạng PPT (PowerPoint 97–2003) không bảo lưu siêu dữ liệu phần. Hãy sử dụng quy trình này với định dạng hỗ trợ phần, chẳng hạn PPTX; việc chuyển đổi sang PPT sẽ xóa cấu trúc phần cần thiết cho việc duyệt sau này.

## **Câu hỏi thường gặp**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu phần, vì vậy việc nhóm phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể “ẩn” toàn bộ một phần không?**

Không. Một phần không có trạng thái hiển thị. Để ẩn nội dung của nó, hãy gọi [ISlide::set_Hidden](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/set_hidden/) cho mỗi slide trong phần đó.

**Làm sao tìm phần chứa một slide cụ thể?**

Duyệt [Presentation::get_Sections](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_sections/), gọi [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/getslideslistofsection/) cho mỗi phần, và so sánh các slide trả về với slide mục tiêu. Đối với phần không rỗng, [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/get_startedfromslide/) trả về slide đầu tiên; đối với phần rỗng, nó trả về `nullptr`.