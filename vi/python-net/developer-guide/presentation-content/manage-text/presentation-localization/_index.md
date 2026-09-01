---
title: Tự động hoá Địa phương hoá Bài thuyết trình với Python
linktitle: Địa phương hoá Bài thuyết trình
type: docs
weight: 100
url: /vi/python-net/presentation-localization/
keywords:
- thay đổi ngôn ngữ
- kiểm tra chính tả
- tắt kiểm tra chính tả
- ngôn ngữ kiểm tra
- mã ngôn ngữ
- văn bản đa ngôn ngữ
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Đặt ngôn ngữ kiểm tra cho văn bản PowerPoint và OpenDocument trong Python với Aspose.Slides, bao gồm các giá trị mặc định và đoạn đa ngôn ngữ."
---
## **Tổng quan**

Aspose.Slides for Python via .NET cho phép bạn cấu hình siêu dữ liệu kiểm tra chính tả cho các đoạn văn bản riêng lẻ. Sử dụng [BasePortionFormat.language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/language_id/) để xác định ngôn ngữ kiểm tra, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/spell_check/) để cho phép hoặc tắt kiểm tra chính tả, và [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/proof_disabled/) để điều khiển trạng thái không kiểm tra rộng hơn. Vì các cài đặt này được áp dụng ở mức đoạn, một đoạn văn có thể chứa nhiều ngôn ngữ và các quy tắc kiểm tra khác nhau.

Bài viết này giải thích cách gán ngôn ngữ cho văn bản cụ thể, đặt ngôn ngữ mặc định cho văn bản mới bằng [LoadOptions.default_text_language](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/default_text_language/), tạo các đoạn đa ngôn ngữ, chọn giữa `spell_check` và `proof_disabled`, và bảo tồn các cài đặt mong muốn khi sử dụng [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Các thuộc tính này lưu siêu dữ liệu cho các ứng dụng trình chiếu; chúng không dịch văn bản, không thực hiện kiểm tra chính tả dựa trên từ điển, hoặc trả về các từ sai chính tả.

## **Đặt ngôn ngữ kiểm tra cho văn bản**

Tạo hoặc tải một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), truy cập đoạn văn bản cần thiết qua [Portion.portion_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/portion_format/), và gán định danh ngôn ngữ cho nó. Ví dụ sau tạo một hình, đặt tiếng Anh Anh làm ngôn ngữ kiểm tra, và lưu kết quả bằng [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt ngôn ngữ mặc định cho văn bản mới**

Sử dụng [LoadOptions.default_text_language](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/default_text_language/) để chỉ định ngôn ngữ kiểm tra mà Aspose.Slides gán cho văn bản mới tạo. Cài đặt này hữu ích khi phần lớn hoặc toàn bộ văn bản mới trong một bài thuyết trình sử dụng cùng một ngôn ngữ. Nó không thay đổi siêu dữ liệu ngôn ngữ của văn bản đã có ngôn ngữ cụ thể.

Ví dụ sau tạo một bài thuyết trình mà văn bản mới sử dụng quy tắc kiểm tra tiếng Đức:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Sử dụng đa ngôn ngữ trong một đoạn**

Một [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) chứa một bộ sưu tập các đoạn văn bản. Tạo một [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) riêng cho mỗi ngôn ngữ và đặt `language_id` của nó một cách độc lập.

Ví dụ này tạo một đoạn chứa các phần tiếng Anh và tiếng Pháp:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Bật hoặc tắt kiểm tra chính tả cho các đoạn riêng lẻ**

[PortionFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/) kế thừa các thuộc tính văn bản chung được định nghĩa bởi [BasePortionFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/). Truy cập định dạng của một đoạn qua [Portion.portion_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/portion_format/) và đặt [BasePortionFormat.spell_check](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/spell_check/) để kiểm soát liệu một ứng dụng trình chiếu có được phép kiểm tra chính tả cho đoạn đó hay không. Giá trị mặc định là `False`: `True` cho phép kiểm tra chính tả, trong khi `False` tắt nó.

Cài đặt này áp dụng cho các đoạn văn bản riêng lẻ. Do đó, các đoạn khác nhau trong cùng một đoạn văn có thể sử dụng các giá trị khác nhau. [BasePortionFormat.language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/language_id/) và `spell_check` có mục đích bổ trợ: `language_id` xác định ngôn ngữ kiểm tra, trong khi `spell_check` quyết định liệu có cho phép kiểm tra chính tả cho đoạn hay không.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/proof_disabled/) cũng điều khiển việc kiểm tra, nhưng nó đại diện cho trạng thái "không kiểm tra" rộng hơn dưới dạng một [NullableBool](https://reference.aspose.com/slides/vi/python-net/aspose.slides/nullablebool/). Sử dụng `spell_check` khi bạn cần một công tắc Boolean trực tiếp riêng cho việc kiểm tra chính tả. Sử dụng `proof_disabled` khi bạn cần bảo tồn hoặc kiểm soát một cách rõ ràng siêu dữ liệu không kiểm tra của bài thuyết trình, bao gồm trạng thái `NOT_DEFINED` của nó. Nếu bạn thiết lập cả hai thuộc tính, hãy giữ giá trị của chúng nhất quán; không kết hợp `spell_check = True` với `proof_disabled = slides.NullableBool.TRUE`.

Những thuộc tính này cấu hình siêu dữ liệu kiểm tra được sử dụng bởi PowerPoint và các ứng dụng trình chiếu khác. Aspose.Slides không sử dụng chúng để thực hiện kiểm tra chính tả dựa trên từ điển hoặc trả về danh sách các từ sai chính tả.

Ví dụ đầy đủ sau tạo một bài thuyết trình đầu vào, tải nó, gán các cài đặt kiểm tra chính tả và ngôn ngữ kiểm tra khác nhau cho hai đoạn trong cùng một đoạn văn, lưu kết quả, mở lại và xác minh các giá trị đã lưu:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) kết hợp các đoạn liền kề có cùng định dạng. Chỉ có sự khác nhau ở `spell_check` không giữ các đoạn này riêng biệt; sau khi chúng được kết hợp, đoạn kết quả giữ giá trị `spell_check` của đoạn đầu tiên. Nếu các đoạn cần các cài đặt kiểm tra chính tả khác nhau, hãy gọi `join_portions_with_same_formatting` trước khi gán các cài đặt đó, hoặc kiểm tra ranh giới của đoạn kết quả và áp dụng lại các cài đặt sau đó. Các đoạn có giá trị `language_id` khác nhau vẫn giữ riêng biệt vì định dạng ngôn ngữ kiểm tra của chúng khác nhau.

## **Câu hỏi thường gặp**

**ID ngôn ngữ có dịch văn bản không?**

Không. [BasePortionFormat.language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/language_id/) lưu siêu dữ liệu kiểm tra cho chính tả và ngữ pháp; nó không thay đổi nội dung văn bản. Dịch văn bản riêng biệt, sau đó đặt định danh ngôn ngữ thích hợp cho mỗi đoạn đã dịch.

**Ngôn ngữ kiểm tra có kiểm soát phông chữ, gạch ngang hay ngắt dòng không?**

Không. Định danh ngôn ngữ chỉ dùng cho việc kiểm tra. Việc hiển thị và bố cục văn bản chủ yếu phụ thuộc vào [phông chữ](/slides/vi/python-net/powerpoint-fonts/), hệ thống viết, và các cài đặt khung văn bản. Để hiển thị đáng tin, cung cấp các phông chữ cần thiết, cấu hình [thay thế phông chữ](/slides/vi/python-net/font-substitution/), hoặc [nhúng phông chữ](/slides/vi/python-net/embedded-font/) trong bài thuyết trình.

**Một đoạn có thể sử dụng nhiều ngôn ngữ kiểm tra không?**

Có. Gán mỗi ngôn ngữ cho một đoạn riêng, như trong ví dụ đoạn đa ngôn ngữ.

**Tôi nên sử dụng `default_text_language` hay `language_id`?**

Sử dụng [LoadOptions.default_text_language](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/default_text_language/) khi bạn muốn một ngôn ngữ mặc định cho văn bản mới tạo. Sử dụng [BasePortionFormat.language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/language_id/) khi một đoạn cụ thể cần một ngôn ngữ kiểm tra rõ ràng hoặc khi một đoạn văn chứa nhiều ngôn ngữ.