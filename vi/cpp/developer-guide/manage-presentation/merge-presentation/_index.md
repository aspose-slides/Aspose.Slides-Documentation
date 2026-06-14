---
title: Kết hợp hiệu quả các bản trình bày trong C++
linktitle: Kết hợp các bản trình bày
type: docs
weight: 40
url: /vi/cpp/merge-presentation/
keywords:
- kết hợp PowerPoint
- kết hợp bản trình bày
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- gộp PowerPoint
- gộp bản trình bày
- gộp slide
- gộp PPT
- gộp PPTX
- gộp ODP
- C++
- Aspose.Slides
description: "Dễ dàng kết hợp các bản trình bày PowerPoint (PPT, PPTX) và OpenDocument (ODP) với Aspose.Slides cho C++, giúp tối ưu quy trình làm việc của bạn."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hợp nhất các bản trình bày bằng cách sao chép các slide từ một bản trình bày sang bản khác. Bài viết này giải thích cách hợp nhất toàn bộ bản trình bày hoặc các slide được chọn, sử dụng slide master hoặc bố cục cụ thể trong quá trình hợp nhất, xử lý các bản trình bày có kích thước slide khác nhau, và thêm các slide đã hợp nhất vào một phần của bản trình bày. Nó cũng đề cập đến các lưu ý thực tiễn liên quan đến nội dung đã hợp nhất, bao gồm ghi chú người thuyết trình, bình luận, tệp nguồn được bảo vệ bằng mật khẩu và việc sử dụng luồng.

## **Hợp nhất bản trình bày**

Khi bạn hợp nhất một bản trình bày vào bản khác, bạn thực tế đang kết hợp các slide của chúng thành một bản trình bày duy nhất để có được một tệp.

{{% alert title="Info" color="info" %}}

Hầu hết các chương trình trình bày (PowerPoint hoặc OpenOffice) không có chức năng cho phép người dùng kết hợp các bản trình bày theo cách này.

[**Aspose.Slides for C++**](https://products.aspose.com/slides/vi/cpp/) , tuy nhiên, cho phép bạn hợp nhất các bản trình bày theo nhiều cách khác nhau. Bạn có thể hợp nhất các bản trình bày cùng với mọi hình dạng, kiểu, văn bản, định dạng, bình luận, hoạt ảnh, v.v. mà không lo mất chất lượng hay dữ liệu.

**Xem thêm**

[Clone Slides](https://docs.aspose.com/slides/vi/cpp/clone-slides/)*.*

{{% /alert %}}

### **Những gì có thể hợp nhất**

Với Aspose.Slides, bạn có thể hợp nhất

* toàn bộ các bản trình bày. Tất cả các slide từ các bản trình bày sẽ nằm trong một bản trình bày
* các slide cụ thể. Các slide đã chọn sẽ nằm trong một bản trình bày
* các bản trình bày ở cùng một định dạng (PPT sang PPT, PPTX sang PPTX, v.v.) và ở các định dạng khác nhau (PPT sang PPTX, PPTX sang ODP, v.v.) với nhau.

{{% alert title="Note" color="warning" %}}

Ngoài các bản trình bày, Aspose.Slides cho phép bạn hợp nhất các tệp khác:

* [Images](https://products.aspose.com/slides/vi/cpp/merger/image-to-image/), chẳng hạn như [JPG to JPG](https://products.aspose.com/slides/vi/cpp/merger/jpg-to-jpg/) hoặc [PNG to PNG](https://products.aspose.com/slides/vi/cpp/merger/png-to-png/)
* Documents, chẳng hạn như [PDF to PDF](https://products.aspose.com/slides/vi/cpp/merger/pdf-to-pdf/) hoặc [HTML to HTML](https://products.aspose.com/slides/vi/cpp/merger/html-to-html/)
* Và hai loại tệp khác nhau như [image to PDF](https://products.aspose.com/slides/vi/cpp/merger/image-to-pdf/) hoặc [JPG to PDF](https://products.aspose.com/slides/vi/cpp/merger/jpg-to-pdf/) hoặc [TIFF to PDF](https://products.aspose.com/slides/vi/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Các tùy chọn hợp nhất**

Bạn có thể áp dụng các tùy chọn xác định:

* mỗi slide trong bản trình bày đầu ra giữ một kiểu duy nhất
* một kiểu cụ thể được sử dụng cho tất cả các slide trong bản trình bày đầu ra.

Để hợp nhất các bản trình bày, Aspose.Slides cung cấp các phương pháp [AddClone](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (từ giao diện [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide_collection)). Có một số triển khai của các phương pháp `AddClone` xác định các tham số quá trình hợp nhất bản trình bày. Mỗi đối tượng Presentation có một bộ sưu tập [Slides](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), vì vậy bạn có thể gọi một phương pháp `AddClone` từ bản trình bày mà bạn muốn hợp nhất các slide vào.

Phương pháp `AddClone` trả về một đối tượng `ISlide`, là bản sao của slide nguồn. Các slide trong bản trình bày đầu ra chỉ là bản sao của các slide từ nguồn. Do đó, bạn có thể thay đổi các slide kết quả (ví dụ, áp dụng kiểu hoặc tùy chọn định dạng hoặc bố cục) mà không lo ảnh hưởng tới các bản trình bày nguồn.

## **Hợp nhất bản trình bày**

Aspose.Slides cung cấp phương pháp [**AddClone (ISlide)**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) cho phép bạn kết hợp các slide trong khi các slide vẫn giữ nguyên bố cục và kiểu (các tham số mặc định).

Đoạn mã C++ dưới đây cho bạn thấy cách hợp nhất các bản trình bày:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Hợp nhất bản trình bày với Slide Master**

Aspose.Slides cung cấp phương pháp [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) cho phép bạn kết hợp các slide đồng thời áp dụng mẫu slide master. Bằng cách này, nếu cần, bạn có thể thay đổi kiểu cho các slide trong bản trình bày đầu ra.

Đoạn mã C++ dưới đây minh họa thao tác đã mô tả:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}}

Bố cục slide cho slide master được xác định tự động. Khi không thể xác định được bố cục phù hợp, nếu tham số boolean `allowCloneMissingLayout` của phương pháp `AddClone` được đặt thành true, sẽ sử dụng bố cục của slide nguồn. Ngược lại, sẽ ném ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

Nếu bạn muốn các slide trong bản trình bày đầu ra có bố cục slide khác, hãy sử dụng phương pháp [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) khi hợp nhất.

## **Hợp nhất các slide cụ thể từ bản trình bày**

Hợp nhất các slide cụ thể từ nhiều bản trình bày hữu ích cho việc tạo các bộ slide tùy chỉnh. Aspose.Slides C++ cho phép bạn chọn và nhập chỉ những slide cần thiết. API bảo tồn định dạng, bố cục và thiết kế của các slide gốc.

Đoạn mã C++ dưới đây tạo một bản trình bày mới, thêm các slide tiêu đề từ hai bản trình bày khác, và lưu kết quả vào một tệp:

```cpp
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

## **Hợp nhất bản trình bày với một Layout Slide**

Đoạn mã C++ này cho bạn thấy cách kết hợp các slide từ các bản trình bày đồng thời áp dụng bố cục slide mà bạn muốn để có một bản trình bày đầu ra duy nhất:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Hợp nhất bản trình bày với các kích thước slide khác nhau**

{{% alert title="Note" color="warning" %}}

Bạn không thể hợp nhất các bản trình bày có kích thước slide khác nhau.

{{% /alert %}}

Để hợp nhất 2 bản trình bày có kích thước slide khác nhau, bạn phải thay đổi kích thước của một trong các bản trình bày để kích thước khớp với bản trình bày còn lại.

Đoạn mã mẫu dưới đây thực hiện thao tác đã mô tả:

```cpp
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

## **Hợp nhất slide vào một phần của bản trình bày**

Đoạn mã C++ này cho bạn thấy cách hợp nhất một slide cụ thể vào một phần trong bản trình bày:

```cpp
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

{{% alert title="Tip" color="primary" %}}

Aspose cung cấp một [ứng dụng web Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể hợp nhất [JPG to JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG to PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), v.v.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Ghi chú người thuyết trình có được bảo tồn khi hợp nhất không?**

Có. Khi sao chép slide, Aspose.Slides chuyển toàn bộ các thành phần slide, bao gồm ghi chú, định dạng và hoạt ảnh.

**Bình luận và tác giả của chúng có được chuyển không?**

Bình luận, như một phần của nội dung slide, được sao chép cùng slide. Nhãn tác giả bình luận được bảo tồn dưới dạng đối tượng bình luận trong bản trình bày kết quả.

**Nếu bản trình bày nguồn được bảo vệ bằng mật khẩu thì sao?**

Phải [mở bằng mật khẩu](/slides/vi/cpp/password-protected-presentation/) qua [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/); sau khi tải, các slide đó có thể được sao chép an toàn vào tệp đích không bảo vệ (hoặc cũng có thể bảo vệ).

**Quá trình hợp nhất có an toàn với đa luồng không?**

Không sử dụng cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/cpp/multithreading/). Quy tắc được khuyến nghị là “một tài liệu — một luồng”; các tệp khác nhau có thể được xử lý song song trong các luồng riêng biệt.