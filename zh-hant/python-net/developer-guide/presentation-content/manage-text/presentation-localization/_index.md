---
title: 使用 Python 自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/python-net/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 抑制拼寫檢查
- 校對語言
- 語言 id
- 多語言文字
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 為 PowerPoint 與 OpenDocument 簡報文字設定校對語言，包括預設值與多語言段落。"
---
## **概述**

Aspose.Slides for Python via .NET 讓您能為單獨的文字部分設定校對中繼資料。使用 [BasePortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/language_id/) 來識別校對語言，使用 [BasePortionFormat.spell_check](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/spell_check/) 來允許或抑制拼寫檢查，並使用 [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/proof_disabled/) 來控制更廣泛的「不校對」狀態。由於這些設定是套用在文字部分層級，一個段落可以包含多種語言及不同的校對規則。

本文說明如何將語言指派給特定文字，如何使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/default_text_language/) 為新文字設定預設語言，建立多語言段落，於 `spell_check` 與 `proof_disabled` 之間選擇，並在使用 [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) 時保留預期的設定。這些屬性僅儲存簡報應用程式的中繼資料；它們不會翻譯文字、執行基於字典的拼寫檢查，或回傳拼寫錯誤的單字。

## **設定文字的校對語言**

建立或載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)，透過 [Portion.portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/portion_format/) 取得所需的文字部分，並指派其語言識別碼。以下範例建立一個圖形，將英式英語設為校對語言，並使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 儲存結果。

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

## **設定新文字的預設語言**

使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/default_text_language/) 來指定 Aspose.Slides 為新建立的文字指派的校對語言。當簡報中的大部分或全部新文字使用相同語言時，此設定非常有用。它不會變更已具明確語言的文字之語言中繼資料。

以下範例建立一個簡報，其新文字使用德語校對規則：

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

## **在單一段落中使用多種語言**

[Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 包含文字部分的集合。為每種語言建立單獨的 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/)，並獨立設定其 `language_id`。

此範例建立一個包含英文與法文部分的段落：

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

## **為個別文字部分啟用或抑制拼寫檢查**

[PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/) 繼承自 [BasePortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/) 定義的共通文字屬性。透過 [Portion.portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/portion_format/) 取得文字部分的格式，並設定 [BasePortionFormat.spell_check](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/spell_check/) 以控制簡報應用程式是否檢查該部分的拼寫。預設值為 `False`：`True` 允許拼寫檢查，`False` 則抑制它。

此設定套用於單一文字部分。因此，同一段落中的不同部分可以使用不同的值。[BasePortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/language_id/) 與 `spell_check` 互為補充：`language_id` 用於識別校對語言，而 `spell_check` 決定是否允許對該部分進行拼寫檢查。

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/proof_disabled/) 亦控制校對，但它以 [NullableBool](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/nullablebool/) 表示更廣泛的「不校對」狀態。當您需要針對拼寫檢查的直接布林開關時，請使用 `spell_check`。當您需要保留或明確控制簡報的「不校對」中繼資料（包括其 `NOT_DEFINED` 狀態）時，請使用 `proof_disabled`。若同時設定兩個屬性，請保持其值一致；不要將 `spell_check = True` 與 `proof_disabled = slides.NullableBool.TRUE` 結合使用。

這些屬性設定 PowerPoint 及其他簡報應用程式使用的校對中繼資料。Aspose.Slides 不會利用它們執行基於字典的拼寫檢查或回傳錯字清單。

以下完整範例建立一個輸入簡報，載入它，為同一段落中的兩個部分指派不同的拼寫檢查設定與校對語言，儲存結果，重新開啟，並驗證儲存的值：

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

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) 會合併具有相同格式的相鄰部分。僅 `spell_check` 的差異不會使這些部分保持分離；合併後，結果的部分會保留第一個部分的 `spell_check` 值。若部分需要不同的拼寫檢查設定，請在指派這些設定之前呼叫 `join_portions_with_same_formatting`，或在合併後檢查結果部分的邊界並重新套用設定。具有不同 `language_id` 值的部分會保持分離，因為它們的校對語言格式不同。

## **常見問題**

**語言 ID 會翻譯文字嗎？**

不會。[BasePortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/language_id/) 只儲存拼寫與文法的校對中繼資料，並不會改變文字內容。請先自行翻譯文字，之後再為每個已翻譯的部分設定合適的語言識別碼。

**校對語言會控制字型、斷字或換行嗎？**

不會。語言識別碼僅用於校對。文字的呈現與版面配置主要取決於可用的 [fonts](/slides/zh-hant/python-net/powerpoint-fonts/)、書寫系統以及文字框設定。為確保可靠的呈現，請提供所需字型、設定 [font substitution](/slides/zh-hant/python-net/font-substitution/)，或在簡報中 [embed fonts](/slides/zh-hant/python-net/embedded-font/)。

**一個段落可以使用多種校對語言嗎？**

可以。請將每種語言指派給獨立的部分，如多語言段落範例所示。

**我該使用 `default_text_language` 還是 `language_id`？**

當您想為新建立的文字設定預設值時，請使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/default_text_language/)。當特定部分需要明確的校對語言，或段落包含多種語言時，請使用 [BasePortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/language_id/)。