---
title: Kết hợp các bài thuyết trình một cách hiệu quả trong C++
linktitle: Kết hợp các bài thuyết trình
type: docs
weight: 40
url: /vi/cpp/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất bài thuyết trình
- hợp nhất slide
- hợp nhất PPT
- hợp nhất PPTX
- hợp nhất ODP
- kết hợp PowerPoint
- kết hợp bài thuyết trình
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- C++
- Aspose.Slides
description: "Dễ dàng hợp nhất các bài thuyết trình PowerPoint (PPT, PPTX) và OpenDocument (ODP) bằng Aspose.Slides cho C++, giúp tối ưu hoá quy trình làm việc của bạn."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hợp nhất các bài thuyết trình bằng cách sao chép các slide từ một bài thuyết trình sang bài thuyết trình khác. Bài viết này giải thích cách hợp nhất toàn bộ bài thuyết trình hoặc các slide được chọn, sử dụng slide master hoặc bố cục cụ thể trong quá trình hợp nhất, xử lý các bài thuyết trình có kích thước slide khác nhau, và thêm các slide đã hợp nhất vào một phần của bài thuyết trình. Nó cũng đề cập đến các lưu ý thực tiễn liên quan đến nội dung đã hợp nhất, bao gồm ghi chú người thuyết trình, bình luận, tệp nguồn được bảo vệ bằng mật khẩu và việc sử dụng luồng.

## **Hợp nhất Bài thuyết trình**

Khi bạn hợp nhất một bài thuyết trình vào bài thuyết trình khác, bạn thực chất đang kết hợp các slide của chúng trong một bài thuyết trình duy nhất để có được một tệp.

{{% alert title="Info" color="info" %}}
Hầu hết các chương trình trình chiếu (PowerPoint hoặc OpenOffice) thiếu các chức năng cho phép người dùng kết hợp các bài thuyết trình theo cách này.

[**Aspose.Slides for C++**](https://products.aspose.com/slides/vi/cpp/), tuy nhiên, cho phép bạn hợp nhất các bài thuyết trình theo nhiều cách khác nhau. Bạn có thể hợp nhất các bài thuyết trình với tất cả các hình dạng, kiểu dáng, văn bản, định dạng, bình luận, hoạt ảnh, v.v. mà không cần lo lắng về việc mất chất lượng hoặc dữ liệu.

**Xem thêm**
[Sao chép Slide](https://docs.aspose.com/slides/vi/cpp/clone-slides/)*.*
{{% /alert %}}

### **Những gì có thể hợp nhất**

Với Aspose.Slides, bạn có thể hợp nhất

* toàn bộ bài thuyết trình. Tất cả các slide từ các bài thuyết trình sẽ được đưa vào một bài thuyết trình
* các slide cụ thể. Các slide được chọn sẽ được đưa vào một bài thuyết trình
* các bài thuyết trình cùng định dạng (PPT sang PPT, PPTX sang PPTX, v.v.) và các định dạng khác nhau (PPT sang PPTX, PPTX sang ODP, v.v.) với nhau.

{{% alert title="Note" color="warning" %}} 
Ngoài các bài thuyết trình, Aspose.Slides cho phép bạn hợp nhất các tệp khác:

* [Hình ảnh](https://products.aspose.com/slides/vi/cpp/merger/image-to-image/), chẳng hạn như [JPG sang JPG](https://products.aspose.com/slides/vi/cpp/merger/jpg-to-jpg/) hoặc [PNG sang PNG](https://products.aspose.com/slides/vi/cpp/merger/png-to-png/)
* Tài liệu, chẳng hạn như [PDF sang PDF](https://products.aspose.com/slides/vi/cpp/merger/pdf-to-pdf/) hoặc [HTML sang HTML](https://products.aspose.com/slides/vi/cpp/merger/html-to-html/)
* Và hai loại tệp khác nhau như [hình ảnh sang PDF](https://products.aspose.com/slides/vi/cpp/merger/image-to-pdf/) hoặc [JPG sang PDF](https://products.aspose.com/slides/vi/cpp/merger/jpg-to-pdf/) hoặc [TIFF sang PDF](https://products.aspose.com/slides/vi/cpp/merger/tiff-to-pdf/).
{{% /alert %}}

### **Tùy chọn Hợp nhất**

Bạn có thể áp dụng các tùy chọn để xác định:

* mỗi slide trong bài thuyết trình đầu ra giữ một kiểu riêng biệt
* một kiểu cụ thể được sử dụng cho tất cả các slide trong bài thuyết trình đầu ra.

Để hợp nhất các bài thuyết trình, Aspose.Slides cung cấp các phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (từ giao diện [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide_collection)). Có một số triển khai của các phương thức `AddClone` xác định các tham số quá trình hợp nhất bài thuyết trình. Mỗi đối tượng Presentation có một bộ sưu tập [Slides](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), vì vậy bạn có thể gọi phương thức `AddClone` từ bài thuyết trình mà bạn muốn hợp nhất các slide.

Phương thức `AddClone` trả về một đối tượng `ISlide`, là bản sao của slide nguồn. Các slide trong bài thuyết trình đầu ra chỉ là bản sao của các slide từ nguồn. Do đó, bạn có thể thay đổi các slide kết quả (ví dụ, áp dụng kiểu, tùy chọn định dạng hoặc bố cục) mà không lo các bài thuyết trình nguồn bị ảnh hưởng.

## **Hợp nhất Bài thuyết trình**

Aspose.Slides cung cấp phương thức [**AddClone (ISlide)**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) cho phép bạn kết hợp các slide trong khi chúng giữ nguyên bố cục và kiểu (các tham số mặc định).

This C++ code shows you how to merge presentations:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Hợp nhất Bài thuyết trình với Slide Master**

Aspose.Slides cung cấp phương thức [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) cho phép bạn kết hợp các slide đồng thời áp dụng mẫu slide master. Theo cách này, nếu cần, bạn có thể thay đổi kiểu cho các slide trong bài thuyết trình đầu ra.

This code in C++ demonstrates the described operation:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Bố cục slide cho slide master được xác định tự động. Khi không thể xác định được bố cục phù hợp, nếu tham số boolean `allowCloneMissingLayout` của phương thức `AddClone` được đặt là true, sẽ sử dụng bố cục của slide nguồn. Ngược lại, sẽ ném ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).
{{% /alert %}}

Nếu bạn muốn các slide trong bài thuyết trình đầu ra có một bố cục slide khác, hãy sử dụng phương thức [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) thay thế khi hợp nhất.

## **Hợp nhất Các Slide Cụ Thể Từ Các Bài Thuyết Trình**

Hợp nhất các slide cụ thể từ nhiều bài thuyết trình hữu ích cho việc tạo các bộ slide tùy chỉnh. Aspose.Slides C++ cho phép bạn chọn và nhập chỉ những slide cần thiết. API giữ nguyên định dạng, bố cục và thiết kế của các slide gốc.

The following C++ code creates a new presentation, adds title slides from two other presentations, and saves the result to a file:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Được khai báo ở trên trong mã.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Hợp nhất Bài thuyết trình với Bố cục Slide**

This C++ code shows you how to combine slides from presentations while applying your preferred slide layout to them to get one output presentation:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Hợp nhất Bài thuyết trình với Kích thước Slide Khác nhau**

{{% alert title="Note" color="warning" %}} 
Bạn không thể hợp nhất các bài thuyết trình có kích thước slide khác nhau.
{{% /alert %}}

Để hợp nhất 2 bài thuyết trình có kích thước slide khác nhau, bạn phải thay đổi kích thước của một trong các bài thuyết trình để kích thước của nó khớp với bài thuyết trình còn lại.

This sample code demonstrates the described operation:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Hợp nhất Slide vào Phần của Bài Thuyết Trình**

This C++ code shows you how to merge a specific slide to a section in a presentation:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Slide được thêm vào cuối phần.

{{% alert title="Tip" color="info" %}} 
Aspose cung cấp một [ứng dụng web Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể hợp nhất các hình ảnh [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), v.v.
{{% /alert %}}

## **Câu hỏi thường gặp**

### Ghi chú người thuyết trình có được giữ lại khi hợp nhất không?

Có. Khi sao chép slide, Aspose.Slides chuyển giao tất cả các yếu tố của slide, bao gồm ghi chú, định dạng và hoạt ảnh.

### Bình luận và tác giả của chúng có được chuyển không?

Bình luận, là một phần của nội dung slide, được sao chép cùng slide. Nhãn tác giả của bình luận được giữ lại dưới dạng các đối tượng comment trong bài thuyết trình kết quả.

### Nếu bài thuyết trình nguồn được bảo vệ bằng mật khẩu thì sao?

Bạn phải [mở bằng mật khẩu](/slides/vi/cpp/password-protected-presentation/) thông qua [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/); sau khi tải, các slide đó có thể được sao chép an toàn vào tệp đích không bảo vệ (hoặc cũng có thể vào tệp được bảo vệ).

### Hoạt động hợp nhất có an toàn với đa luồng không?

Không nên sử dụng cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/cpp/multithreading/). Quy tắc được khuyên dùng là “một tài liệu — một luồng”; các tệp khác nhau có thể được xử lý song song trong các luồng riêng biệt.