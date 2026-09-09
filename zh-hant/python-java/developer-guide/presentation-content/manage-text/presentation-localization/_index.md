---
title: 在 Python 中透過 Java 自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/python-java/presentation-localization/
keywords:
- 更改語言
- 拼寫檢查
- 抑制拼寫檢查
- 校對語言
- 語言識別碼
- 多語言文字
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 於 Python 透過 Java 為 PowerPoint 與 OpenDocument 簡報文字設定校對語言，包括預設值與多語言段落。"
---
## **概述**

Aspose.Slides for Python via Java 讓您能夠為單一文字片段設定校對中繼資料。使用[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setLanguageId) 指定校對語言，使用[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setSpellCheck) 允許或抑制拼寫檢查，並使用[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setProofDisabled) 控制更廣泛的「不校對」狀態。由於這些設定是依片段層級套用，一個段落可以包含多種語言以及不同的校對規則。

本文說明如何將語言指派給特定文字、使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 為新文字設定預設語言、建立多語言段落、在[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setSpellCheck) 與[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setProofDisabled) 之間做選擇，並在使用[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) 時保留預期的設定。這些屬性僅儲存簡報應用程式使用的中繼資料；它們不會翻譯文字、執行字典式拼寫檢查，或回傳拼寫錯誤的單字。

## **設定文字的校對語言**

建立或載入一個[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/)，透過[Portion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#getPortionFormat) 取得所需的文字片段，並指派其語言識別碼。下列範例建立一個圖形、將英式英文設為校對語言，並使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 儲存結果：

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

## **設定新文字的預設語言**

使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 指定 Aspose.Slides 為新建立的文字分配的校對語言。當簡報中大部分或全部新文字使用相同語言時，此設定相當實用。它不會變更已明確設定語言之文字的語言中繼資料。

下列範例建立一個簡報，其新文字使用德語校對規則：

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

## **在同一段落中使用多種語言**

一個[Paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/) 包含多個文字片段的集合。為每種語言建立獨立的[Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/)，並分別設定其[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setLanguageId)。

此範例建立一個段落，內含英文與法文片段：

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

## **為單獨的文字片段啟用或抑制拼寫檢查**

[PortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/) 繼承自[BasePortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/) 定義的通用文字屬性。透過[Portion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#getPortionFormat) 取得片段的格式，並使用[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setSpellCheck) 控制簡報應用程式是否可對該片段執行拼寫檢查。預設值為 `False`：`True` 允許拼寫檢查，`False` 則抑制。

此設定適用於單一文字片段。同一段落中的不同片段因此可以使用不同的設定。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setLanguageId) 與[setSpellCheck](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setSpellCheck) 扮演互補角色：前者識別校對語言，後者決定是否允許對該片段進行拼寫檢查。

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setProofDisabled) 也會控制校對，但它以[NullableBool](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/nullablebool/) 形式表示更廣泛的「不校對」狀態。當您需要針對拼寫檢查的直接布林開關時，使用[setSpellCheck]。當您需要保留或明確控制簡報的「不校對」中繼資料（包括[NullableBool.NotDefined](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/nullablebool/#NotDefined) 狀態）時，使用[setProofDisabled]。若同時設定兩個屬性，請保持其值一致；不要將[setSpellCheck] 設為 `True` 同時將[setProofDisabled] 設為[NullableBool.True]。

這些屬性負責設定 PowerPoint 及其他簡報應用程式使用的校對中繼資料。Aspose.Slides 不會使用它們執行字典式拼寫檢查或回傳拼寫錯誤清單。

以下完整範例建立輸入簡報、載入它、為同一段落中的兩個片段指派不同的拼寫檢查設定與校對語言、儲存結果、重新開啟並驗證儲存值：

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) 會合併具相同格式的相鄰片段。僅因[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setSpellCheck) 不同而不會讓片段保持分離；合併後的片段會保留第一個片段的[setSpellCheck] 值。若片段需要不同的拼寫檢查設定，請在指派這些設定之前呼叫[joinPortionsWithSameFormatting]，或在合併後檢查結果片段的邊界並重新套用設定。因為[BasePortionFormat.setLanguageId] 值不同而導致校對語言格式不同的片段，仍會保持分離。

## **常見問題**

**語言 ID 會翻譯文字嗎？**

不會。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setLanguageId) 僅儲存拼寫與文法校對的中繼資料；它不會更改文字內容。請先自行翻譯文字，然後為每個已翻譯的片段設定適當的語言識別碼。

**校對語言會控制字型、斷字或換行嗎？**

不會。語言識別碼僅用於校對。文字呈現與版面配置主要受可用的[fonts](/slides/zh-hant/python-java/powerpoint-fonts/)、書寫系統以及文字框設定影響。為確保可靠的渲染，請提供所需字型、設定[font substitution](/slides/zh-hant/python-java/font-substitution/)，或在簡報中[embed fonts](/slides/zh-hant/python-java/embedded-font/)。

**一個段落可以使用多個校對語言嗎？**

可以。請如多語言段落範例所示，將每種語言指派給獨立的片段。

**應該使用[setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 還是[setLanguageId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setLanguageId)？**

當您想為新建立的文字設定預設語言時，使用[LoadOptions.setDefaultTextLanguage]。當特定片段需要明確的校對語言，或段落包含多種語言時，使用[BasePortionFormat.setLanguageId]。