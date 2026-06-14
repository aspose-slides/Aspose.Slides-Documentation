---
title: Hiệu quả hợp nhất các bản trình bày bằng Python
linktitle: Hợp nhất bản trình bày
type: docs
weight: 40
url: /vi/python-net/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất bản trình bày
- hợp nhất slide
- hợp nhất PPT
- hợp nhất PPTX
- hợp nhất ODP
- kết hợp PowerPoint
- kết hợp bản trình bày
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- Python
- Aspose.Slides
description: "Dễ dàng hợp nhất các bản trình bày PowerPoint (PPT, PPTX) và OpenDocument (ODP) với Aspose.Slides cho Python thông qua .NET, giúp tối ưu hoá quy trình làm việc của bạn."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hợp nhất các bản trình bày bằng cách sao chép các slide từ một bản trình bày sang bản trình bày khác. Bài viết này giải thích cách hợp nhất toàn bộ bản trình bày hoặc các slide được chọn, sử dụng slide master hoặc bố cục cụ thể trong quá trình hợp nhất, xử lý các bản trình bày có kích thước slide khác nhau, và thêm các slide đã hợp nhất vào một phần của bản trình bày. Nó cũng đề cập đến các lưu ý thực tiễn liên quan tới nội dung đã hợp nhất, bao gồm ghi chú diễn giả, bình luận, tệp nguồn được bảo vệ bằng mật khẩu và việc sử dụng thread.

## **Tối ưu hoá việc hợp nhất bản trình bày**

Với [Aspose.Slides for Python](https://products.aspose.com/slides/vi/python-net/), bạn có thể kết hợp các bản PowerPoint một cách liền mạch đồng thời giữ nguyên kiểu dáng, bố cục và mọi thành phần. Không giống như các công cụ khác, Aspose.Slides hợp nhất bản trình bày mà không làm mất chất lượng hay dữ liệu. Hợp nhất toàn bộ bộ slide, các slide riêng lẻ, hoặc thậm chí các định dạng tệp khác nhau (ví dụ: PPT sang PPTX).

### **Các tính năng hợp nhất**

- **Full Presentation Merge:** Tập hợp tất cả các slide thành một tệp duy nhất.  
- **Specific Slide Merge:** Chọn và kết hợp các slide đã chọn.  
- **Cross-Format Merge:** Tích hợp các bản trình bày có định dạng khác nhau, duy trì tính toàn vẹn.

## **Hợp nhất bản trình bày**

Khi bạn hợp nhất một bản trình bày vào bản khác, bạn thực tế đang gộp các slide của chúng thành một bản duy nhất để tạo ra một tệp. Hầu hết các chương trình trình bày—như PowerPoint hoặc OpenOffice—không cung cấp tính năng cho phép bạn hợp nhất bản trình bày theo cách này.

Tuy nhiên, [Aspose.Slides for Python](https://products.aspose.com/slides/vi/python-net/) cho phép bạn hợp nhất bản trình bày theo nhiều cách. Bạn có thể hợp nhất các bản trình bày với mọi hình dạng, kiểu dáng, văn bản, định dạng, bình luận và hoạt ảnh, mà không mất chất lượng hay dữ liệu.

**Xem thêm**

[Clone PowerPoint Slides in Python](/slides/vi/python-net/clone-slides/)

### **Những gì có thể hợp nhất**

Với Aspose.Slides, bạn có thể hợp nhất:

- Toàn bộ bản trình bày: tất cả các slide từ các bộ nguồn được kết hợp thành một bản trình bày duy nhất.  
- Các slide cụ thể: chỉ những slide đã chọn được kết hợp thành một bản trình bày duy nhất.  
- Các bản trình bày cùng định dạng (ví dụ: PPT→PPT, PPTX→PPTX) hoặc giữa các định dạng khác nhau (ví dụ: PPT→PPTX, PPTX→ODP).

### **Tùy chọn hợp nhất**

Bạn có thể kiểm soát:

- Mỗi slide trong bản trình bày đầu ra giữ nguyên kiểu dáng gốc, hoặc  
- Áp dụng một kiểu dáng duy nhất cho tất cả các slide trong bản trình bày đầu ra.

Để hợp nhất các bản trình bày, Aspose.Slides cung cấp các phương thức [add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) trên lớp [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/). Các overload của phương thức này xác định cách thực hiện việc hợp nhất. Mỗi đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) đều có một bộ sưu tập [slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/), vì vậy bạn gọi `add_clone` trên bộ sưu tập slide của bản trình bày đích.

Phương thức `add_clone` trả về một `Slide`—bản sao của slide nguồn. Các slide trong bản trình bày đầu ra là bản sao của các slide gốc, vì vậy bạn có thể chỉnh sửa các slide kết quả (ví dụ: áp dụng kiểu dáng, định dạng hoặc bố cục) mà không ảnh hưởng đến các bản trình bày nguồn.

## **Hợp nhất bản trình bày** 

Aspose.Slides cung cấp phương thức [add_clone(ISlide)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) cho phép bạn kết hợp các slide trong khi giữ nguyên bố cục và kiểu dáng (sử dụng các tham số mặc định).

Ví dụ Python sau cho thấy cách hợp nhất các bản trình bày:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Hợp nhất bản trình bày với Slide Master**

Aspose.Slides cung cấp phương thức [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) cho phép bạn hợp nhất các slide đồng thời áp dụng slide master từ một mẫu. Theo cách này, khi cần, bạn có thể thay đổi kiểu dáng của các slide trong bản trình bày đầu ra.

Ví dụ Python sau minh họa thao tác này:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Note" color="warning" %}}
Bố cục phù hợp dưới slide master được chỉ định sẽ được xác định tự động. Nếu không tìm thấy bố cục thích hợp và tham số boolean `allow_clone_missing_layout` của phương thức `add_clone` được đặt thành `True`, bố cục của slide nguồn sẽ được sử dụng thay thế. Ngược lại, một [PptxEditException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxeditexception/) sẽ được ném ra.
{{% /alert %}}

Để áp dụng một bố cục slide khác cho các slide trong bản trình bày đầu ra, hãy sử dụng phương thức [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) khi hợp nhất.

## **Hợp nhất các slide cụ thể từ các bản trình bày**

Hợp nhất các slide cụ thể từ nhiều bản trình bày hữu ích khi tạo các bộ slide tùy chỉnh. Aspose.Slides cho phép bạn chọn và nhập chỉ những slide bạn cần, đồng thời giữ nguyên định dạng, bố cục và thiết kế của slide gốc.

Ví dụ Python sau tạo một bản trình bày mới, thêm các slide tiêu đề từ hai bản trình bày khác và lưu kết quả vào một tệp:

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Hợp nhất bản trình bày với một Slide Layout**

Ví dụ Python sau cho thấy cách hợp nhất các slide từ nhiều bản trình bày đồng thời áp dụng một bố cục slide cụ thể để tạo ra một bản trình bày đầu ra duy nhất:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Hợp nhất bản trình bày với các kích thước slide khác nhau**

{{% alert title="Note" color="warning" %}}
Bạn không thể hợp nhất trực tiếp các bản trình bày có kích thước slide khác nhau.
{{% /alert %}}

Để hợp nhất hai bản trình bày có kích thước slide khác nhau, trước tiên hãy thay đổi kích thước một bản trình bày sao cho kích thước slide của nó khớp với bản còn lại.

Mã mẫu sau minh họa quy trình này:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Hợp nhất các slide vào một phần của bản trình bày**

Ví dụ Python sau cho thấy cách hợp nhất một slide cụ thể vào một phần của bản trình bày:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

Slide sẽ được thêm vào cuối phần.

{{% alert title="Tip" color="primary" %}}
Bạn đang tìm một **công cụ trực tuyến miễn phí** để **hợp nhất các bản PowerPoint**? Hãy thử [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/vi/merger).

- **Hợp nhất các tệp PowerPoint dễ dàng**: Kết hợp nhiều bản trình bày **PPT, PPTX, ODP** thành một tệp duy nhất.  
- **Hỗ trợ nhiều định dạng**: Hợp nhất **PPT sang PPTX**, **PPTX sang ODP**, và nhiều hơn nữa.  
- **Không cần cài đặt**: Hoạt động trực tiếp trong trình duyệt của bạn, nhanh chóng và an toàn.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/vi/merger)  

Bắt đầu hợp nhất các tệp PowerPoint của bạn với **công cụ trực tuyến miễn phí của Aspose** ngay hôm nay!  
{{% /alert %}}

{{% alert title="Tip" color="primary" %}}
Aspose cung cấp một [ỨNG DỤNG COLLAGE MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể hợp nhất [JPG thành JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG thành PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), v.v. 
{{% /alert %}}

## **FAQ**

**Ghi chú diễn giả có được giữ lại khi hợp nhất không?**

Có. Khi sao chép các slide, Aspose.Slides chuyển giao tất cả các thành phần slide, bao gồm ghi chú, định dạng và hoạt ảnh.

**Bình luận và tác giả của chúng có được chuyển không?**

Bình luận, như là một phần của nội dung slide, được sao chép cùng slide. Nhãn tác giả bình luận được giữ lại dưới dạng đối tượng bình luận trong bản trình bày kết quả.

**Nếu bản trình bày nguồn được bảo vệ bằng mật khẩu thì sao?**

Cần [mở bằng mật khẩu](/slides/vi/python-net/password-protected-presentation/) thông qua [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/); sau khi tải, các slide đó có thể được sao chép an toàn vào tệp đích không bảo vệ (hoặc cũng có thể bảo vệ).

**Hoạt động hợp nhất có an toàn với thread không?**

Không sử dụng cùng một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) từ [nhiều thread](/slides/vi/python-net/multithreading/). Quy tắc được khuyến nghị là "một tài liệu — một thread"; các tệp khác nhau có thể được xử lý song song trong các thread riêng biệt.