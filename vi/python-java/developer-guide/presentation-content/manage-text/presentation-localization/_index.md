---
title: Tự động hoá Định vị Bản trình chiếu trong Python qua Java
linktitle: Định vị Bản trình chiếu
type: docs
weight: 100
url: /vi/python-java/presentation-localization/
keywords:
- thay đổi ngôn ngữ
- kiểm tra chính tả
- tắt kiểm tra chính tả
- ngôn ngữ kiểm tra
- id ngôn ngữ
- văn bản đa ngôn ngữ
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Thiết lập ngôn ngữ kiểm tra cho văn bản bản trình chiếu PowerPoint và OpenDocument trong Python qua Java với Aspose.Slides, bao gồm các ngôn ngữ mặc định và các đoạn văn đa ngôn ngữ."
---
## **Tổng quan**

Aspose.Slides for Python via Java cho phép bạn cấu hình siêu dữ liệu kiểm tra chính tả cho các phần văn bản riêng lẻ. Sử dụng [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId) để xác định ngôn ngữ kiểm tra, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setSpellCheck) để cho phép hoặc ngăn chặn kiểm tra chính tả, và [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setProofDisabled) để kiểm soát trạng thái không kiểm tra rộng hơn. Vì các cài đặt này được áp dụng ở mức phần, một đoạn văn có thể chứa nhiều ngôn ngữ và các quy tắc kiểm tra khác nhau.

Bài viết này giải thích cách gán ngôn ngữ cho văn bản cụ thể, đặt ngôn ngữ mặc định cho văn bản mới bằng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), xây dựng các đoạn văn đa ngôn ngữ, chọn giữa [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setSpellCheck) và [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setProofDisabled), và giữ nguyên các cài đặt mong muốn khi sử dụng [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Các thuộc tính này lưu trữ siêu dữ liệu cho các ứng dụng trình chiếu; chúng không dịch văn bản, không thực hiện kiểm tra chính tả dựa trên từ điển, hoặc trả về các từ sai chính tả.

## **Đặt Ngôn Ngữ Kiểm Tra Chính Tả cho Văn Bản**

Tạo hoặc tải một [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), truy cập phần văn bản cần thiết qua [Portion.getPortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getPortionFormat), và gán định danh ngôn ngữ cho nó. Ví dụ sau tạo một hình dạng, đặt tiếng Anh Anh quốc làm ngôn ngữ kiểm tra, và lưu kết quả bằng [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Ngôn Ngữ Mặc Định cho Văn Bản Mới**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) để chỉ định ngôn ngữ kiểm tra mà Aspose.Slides gán cho văn bản mới tạo. Cài đặt này hữu ích khi hầu hết hoặc toàn bộ văn bản mới trong bản trình chiếu sử dụng cùng một ngôn ngữ. Nó không thay đổi siêu dữ liệu ngôn ngữ của văn bản đã có ngôn ngữ rõ ràng.

Ví dụ sau tạo một bản trình chiếu mà văn bản mới sử dụng quy tắc kiểm tra tiếng Đức:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sử Dụng Nhiều Ngôn Ngữ trong Một Đoạn Văn**

Một [Paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/) chứa một tập hợp các phần văn bản. Tạo một [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) riêng cho mỗi ngôn ngữ và đặt [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId) một cách độc lập.

Ví dụ này tạo một đoạn văn với các phần tiếng Anh và tiếng Pháp:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bật hoặc Tắt Kiểm Tra Chính Tả cho Các Phần Riêng Lẻ**

[PortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/) kế thừa các thuộc tính văn bản chung được định nghĩa bởi [BasePortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/). Truy cập định dạng của một phần qua [Portion.getPortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getPortionFormat) và sử dụng [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setSpellCheck) để kiểm soát liệu ứng dụng trình chiếu có được phép kiểm tra chính tả cho phần đó hay không. Giá trị mặc định là `False`: `True` cho phép kiểm tra chính tả, trong khi `False` tắt nó.

Cài đặt này áp dụng cho từng phần văn bản riêng lẻ. Các phần khác nhau trong cùng một đoạn văn vì vậy có thể sử dụng các giá trị khác nhau. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId) và [setSpellCheck](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setSpellCheck) có mục đích bổ trợ: [setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId) xác định ngôn ngữ kiểm tra, trong khi [setSpellCheck](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setSpellCheck) quyết định có cho phép kiểm tra chính tả cho phần đó hay không.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setProofDisabled) cũng kiểm soát việc kiểm tra, nhưng nó đại diện cho trạng thái "không kiểm tra" rộng hơn dưới dạng một [NullableBool](https://reference.aspose.com/slides/vi/python-java/aspose.slides/nullablebool/). Sử dụng [setSpellCheck](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setSpellCheck) khi bạn cần một công tắc Boolean trực tiếp cho kiểm tra chính tả. Sử dụng [setProofDisabled](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setProofDisabled) khi bạn cần duy trì hoặc kiểm soát một cách rõ ràng siêu dữ liệu "không kiểm tra" của bản trình chiếu, bao gồm cả trạng thái [NullableBool.NotDefined](https://reference.aspose.com/slides/vi/python-java/aspose.slides/nullablebool/#NotDefined). Nếu bạn đặt cả hai thuộc tính, hãy giữ giá trị của chúng nhất quán; không kết hợp [setSpellCheck](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setSpellCheck) đặt thành `True` với [setProofDisabled](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setProofDisabled) đặt thành trạng thái [NullableBool.True](https://reference.aspose.com/slides/vi/python-java/aspose.slides/nullablebool/#True).

Các thuộc tính này cấu hình siêu dữ liệu kiểm tra được sử dụng bởi PowerPoint và các ứng dụng trình chiếu khác. Aspose.Slides không sử dụng chúng để thực hiện kiểm tra chính tả dựa trên từ điển hoặc trả về danh sách các từ sai chính tả.

Ví dụ hoàn chỉnh sau tạo một bản trình chiếu đầu vào, tải nó, gán các cài đặt kiểm tra chính tả và ngôn ngữ kiểm tra khác nhau cho hai phần trong cùng một đoạn, lưu kết quả, mở lại và xác minh các giá trị đã lưu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) kết hợp các phần liền kề có cùng định dạng. Chỉ có sự khác nhau trong [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setSpellCheck) không đủ để giữ các phần tách biệt; sau khi chúng được ghép, phần kết quả giữ giá trị [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setSpellCheck) của phần đầu tiên. Nếu các phần cần cài đặt kiểm tra chính tả khác nhau, hãy gọi [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) trước khi gán các cài đặt đó, hoặc kiểm tra ranh giới của phần kết quả và áp dụng lại các cài đặt sau. Các phần có giá trị [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId) khác nhau vẫn tách biệt vì định dạng ngôn ngữ kiểm tra của chúng khác nhau.

## **FAQ**

**ID ngôn ngữ có dịch văn bản không?**

Không. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId) lưu trữ siêu dữ liệu kiểm tra cho chính tả và ngữ pháp; nó không thay đổi nội dung văn bản. Hãy dịch văn bản riêng biệt, sau đó đặt định danh ngôn ngữ phù hợp cho mỗi phần đã dịch.

**Ngôn ngữ kiểm tra có kiểm soát phông chữ, dấu gạch nối hoặc ngắt dòng không?**

Không. Định danh ngôn ngữ chỉ dùng cho việc kiểm tra. Việc hiển thị và bố cục văn bản chủ yếu phụ thuộc vào [fonts](/slides/vi/python-java/powerpoint-fonts/), hệ thống viết và cài đặt khung văn bản. Để hiển thị ổn định, hãy cung cấp các phông chữ cần thiết, cấu hình [font substitution](/slides/vi/python-java/font-substitution/), hoặc [embed fonts](/slides/vi/python-java/embedded-font/) trong bản trình chiếu.

**Một đoạn văn có thể sử dụng nhiều ngôn ngữ kiểm tra không?**

Có. Gán mỗi ngôn ngữ cho một phần riêng, như trong ví dụ đoạn văn đa ngôn ngữ.

**Tôi nên sử dụng [setDefaultTextLanguage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) hay [setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) khi bạn muốn một ngôn ngữ mặc định cho văn bản mới tạo. Sử dụng [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId) khi một phần cụ thể cần một ngôn ngữ kiểm tra rõ ràng hoặc khi một đoạn văn chứa nhiều ngôn ngữ.