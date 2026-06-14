---
title: Trích xuất văn bản nâng cao từ các bản trình bày trong Python
linktitle: Trích xuất Văn bản
type: docs
weight: 90
url: /vi/python-net/extract-text-from-presentation/
keywords:
- trích xuất văn bản
- trích xuất văn bản từ slide
- trích xuất văn bản từ bản trình bày
- trích xuất văn bản từ PowerPoint
- trích xuất văn bản từ OpenDocument
- trích xuất văn bản từ PPT
- trích xuất văn bản từ PPTX
- trích xuất văn bản từ ODP
- lấy văn bản
- lấy văn bản từ slide
- lấy văn bản từ bản trình bày
- lấy văn bản từ PowerPoint
- lấy văn bản từ OpenDocument
- lấy văn bản từ PPT
- lấy văn bản từ PPTX
- lấy văn bản từ ODP
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Nhanh chóng trích xuất văn bản từ các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET. Thực hiện theo hướng dẫn đơn giản, từng bước của chúng tôi để tiết kiệm thời gian."
---
## **Tổng quan**

Việc trích xuất văn bản từ các bản trình bày là một nhiệm vụ phổ biến nhưng quan trọng đối với các nhà phát triển làm việc với nội dung slide. Dù bạn đang xử lý các tệp Microsoft PowerPoint ở định dạng PPT hoặc PPTX, hay các bản trình bày OpenDocument (ODP), việc truy cập và lấy dữ liệu văn bản có thể thiết yếu cho việc phân tích, tự động hoá, lập chỉ mục hoặc di chuyển nội dung.

Bài viết này cung cấp hướng dẫn toàn diện về cách hiệu quả trích xuất văn bản từ các định dạng bản trình bày khác nhau, bao gồm PPT, PPTX và ODP, bằng Aspose.Slides for Python via .NET. Bạn sẽ học cách lặp qua các phần tử của bản trình bày để lấy chính xác nội dung văn bản mà bạn cần.

## **Trích xuất văn bản từ một slide**

Aspose.Slides for Python via .NET cung cấp không gian tên [aspose.slides.util](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/) , trong đó có lớp [SlideUtil](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/). Lớp này cung cấp một số phương thức tĩnh nạp chồng để trích xuất toàn bộ văn bản từ một bản trình bày hoặc slide. Để trích xuất văn bản từ một slide trong bản trình bày, sử dụng phương thức [get_all_text_boxes](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Phương thức này nhận một đối tượng kiểu [BaseSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/) làm tham số. Khi thực thi, phương thức sẽ quét toàn bộ slide để tìm văn bản và trả về một mảng các đối tượng kiểu [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/), bảo toàn mọi định dạng văn bản.

Đoạn mã sau trích xuất toàn bộ văn bản từ slide đầu tiên của bản trình bày:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Trích xuất văn bản từ một bản trình bày**

Để quét văn bản từ toàn bộ bản trình bày, sử dụng phương thức tĩnh [get_all_text_frames](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/get_all_text_frames/) được cung cấp bởi lớp [SlideUtil](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/). Phương thức này nhận hai tham số:

1. Đầu tiên, một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) đại diện cho một bản trình bày PowerPoint hoặc OpenDocument mà văn bản sẽ được trích xuất.
2. Thứ hai, một giá trị `Boolean` chỉ định liệu các slide mẫu (master slides) có nên được bao gồm khi quét văn bản từ bản trình bày hay không.

Phương thức trả về một mảng các đối tượng kiểu [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/), bao gồm thông tin định dạng văn bản. Đoạn mã dưới đây quét văn bản và chi tiết định dạng từ một bản trình bày, bao gồm cả các slide mẫu.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Trích xuất văn bản có phân loại và nhanh chóng**

Lớp [PresentationFactory](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/) cũng cung cấp các phương thức để trích xuất toàn bộ văn bản từ các bản trình bày:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

Tham số enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textextractionarrangingmode/) chỉ định chế độ sắp xếp kết quả trích xuất văn bản và có thể được đặt thành các giá trị sau:
- `UNARRANGED` - Văn bản thô mà không quan tâm đến vị trí của nó trên slide.
- `ARRANGED` - Văn bản được sắp xếp theo cùng thứ tự như trên slide.

Chế độ `UNARRANGED` có thể được sử dụng khi tốc độ là yếu tố quan trọng; nó nhanh hơn chế độ `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationtext/) đại diện cho văn bản thô được trích xuất từ bản trình bày. Thuộc tính `slides_text` của nó trả về một mảng các đối tượng văn bản slide. Mỗi đối tượng đại diện cho văn bản trên slide tương ứng và có các thuộc tính sau:

- `text` - Văn bản trong các shape của slide.
- `master_text` - Văn bản trong các shape của slide mẫu (master) liên quan đến slide này.
- `layout_text` - Văn bản trong các shape của slide bố cục (layout) liên quan đến slide này.
- `notes_text` - Văn bản trong các shape của slide ghi chú (notes) liên quan đến slide này.
- `comments_text` - Văn bản trong các comment liên quan đến slide này.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **Câu hỏi thường gặp**

**Aspose.Slides xử lý các bản trình bày lớn trong quá trình trích xuất văn bản nhanh như thế nào?**

Aspose.Slides được tối ưu hoá cho hiệu năng cao và có thể xử lý ngay cả các [bản trình bày lớn](/slides/vi/python-net/open-presentation/), phù hợp cho các kịch bản xử lý thời gian thực hoặc hàng loạt.

**Aspose.Slides có thể trích xuất văn bản từ bảng và biểu đồ trong bản trình bày không?**

Có. Aspose.Slides có thể trích xuất văn bản từ nhiều thành phần slide, bao gồm bảng và các đối tượng liên quan đến biểu đồ, giúp bạn truy cập và phân tích nội dung văn bản trong các cấu trúc trình bày phổ biến.

**Tôi có cần giấy phép đặc biệt của Aspose.Slides để trích xuất văn bản từ bản trình bày không?**

Bạn có thể trích xuất văn bản bằng phiên bản dùng thử miễn phí của Aspose.Slides, tuy nhiên sẽ có [một số hạn chế](/slides/vi/python-net/licensing/), chẳng hạn chỉ xử lý được số lượng slide hạn chế. Để sử dụng không giới hạn và xử lý các bản trình bày lớn hơn, nên mua giấy phép đầy đủ.