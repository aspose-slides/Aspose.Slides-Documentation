---
title: 在 JavaScript 中自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/nodejs-java/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 抑制拼寫檢查
- 校對語言
- 語言識別碼
- 多語言文字
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中為 PowerPoint 與 OpenDocument 簡報文字設定校對語言，包含預設值與多語言段落。"
---
## **概述**

Aspose.Slides for Node.js via Java 讓您可為單一文字片段設定校對中繼資料。使用 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 來指定校對語言，使用 [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) 允許或抑制拼寫檢查，並使用 [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) 來控制更廣泛的「不校對」狀態。因為這些設定是在片段層級套用，一個段落可以包含多種語言和不同的校對規則。

本文說明如何將語言指派給特定文字，如何使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 為新文字設定預設語言，建立多語言段落，在 `SpellCheck` 與 `ProofDisabled` 之間做選擇，以及在使用 [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) 時保留預期的設定。這些屬性僅儲存簡報應用程式的中繼資料；它們不會翻譯文字、執行字典式拼寫檢查，或回傳錯字。

## **設定文字的校對語言**

建立或載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)，透過 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#getPortionFormat--) 取得所需的文字片段，並指派其語言識別碼。下列範例建立一個圖形，將英式英語設為校對語言，並使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) 儲存結果：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定新文字的預設語言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 指定 Aspose.Slides 為新建立的文字指派的校對語言。當簡報中大部分或全部新文字使用相同語言時，此設定非常有用。它不會變更已明確設定語言的文字之語言中繼資料。

以下範例建立一個簡報，其新文字使用德語校對規則：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在同一段落中使用多種語言**

一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 包含多個文字片段的集合。為每種語言建立獨立的 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/)，並分別設定其 `LanguageId`。

此範例建立一個段落，其中包含英文與法文片段：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **為單獨的文字片段啟用或抑制拼寫檢查**

[PortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/) 繼承自 [BasePortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/) 定義的通用文字屬性。透過 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#getPortionFormat--) 取得片段的格式，並使用 [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) 來控制簡報應用程式是否檢查該片段的拼寫。預設值為 `false`：`true` 允許拼寫檢查，`false` 則抑制檢查。

此設定僅套用於單一文字片段。同一段落中的不同片段因此可以使用不同的值。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 與 `setSpellCheck` 互補：`setLanguageId` 指定校對語言，而 `setSpellCheck` 決定是否允許對該片段執行拼寫檢查。

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) 也會控制校對，但它以 [NullableBool](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/nullablebool/) 表示更廣泛的「不校對」狀態。當您需要專門針對拼寫檢查的布林開關時，使用 `setSpellCheck`；當您需要保留或明確控制簡報的「不校對」中繼資料（包括 `NotDefined` 狀態）時，使用 `setProofDisabled`。若同時設定兩個屬性，請保持其值一致；不要將 `setSpellCheck(true)` 與 `setProofDisabled(NullableBool.True)` 混用。

這些屬性會設定 PowerPoint 與其他簡報應用程式使用的校對中繼資料。Aspose.Slides 不會使用它們執行字典式拼寫檢查或回傳錯字清單。

以下完整範例建立輸入簡報，載入後為同一段落中的兩個片段指定不同的拼寫檢查設定與校對語言，儲存結果，重新開啟並驗證儲存的值：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) 會合併具有相同格式的相鄰片段。僅因 `SpellCheck` 差異不會使片段保持分離；合併後的片段會保留第一個片段的 `SpellCheck` 值。如果片段需要不同的拼寫檢查設定，請在指派這些設定之前呼叫 `joinPortionsWithSameFormatting`，或在合併後檢查產生的片段邊界並重新套用設定。具有不同 `LanguageId` 值的片段仍會保持分離，因為它們的校對語言格式不同。

## **常見問題**

**語言 ID 會翻譯文字嗎？**

不會。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 只儲存拼寫與文法的校對中繼資料，並不會改變文字內容。請先自行翻譯文字，然後為每個已翻譯的片段設定適當的語言識別碼。

**校對語言會控制字型、斷字或換行嗎？**

不會。語言識別碼僅用於校對。文字的呈現與版面主要取決於可用的 [fonts](/slides/zh-hant/nodejs-java/powerpoint-fonts/)、書寫系統以及文字框設定。為確保正確呈現，請提供所需字型、設定 [font substitution](/slides/zh-hant/nodejs-java/font-substitution/)，或在簡報中 [embed fonts](/slides/zh-hant/nodejs-java/embedded-font/)。

**一個段落可以使用多種校對語言嗎？**

可以。如多語言段落範例所示，將每種語言指派給獨立的片段即可。

**應該使用 `setDefaultTextLanguage` 還是 `setLanguageId`？**

當您想為新建立的文字設定預設語言時，請使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)。當特定片段需要明確的校對語言，或段落包含多種語言時，請使用 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)。