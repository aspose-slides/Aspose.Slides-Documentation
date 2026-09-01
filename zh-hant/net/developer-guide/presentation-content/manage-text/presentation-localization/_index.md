---
title: 在 .NET 中自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/net/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 抑制拼寫檢查
- 校對語言
- 語言識別碼
- 多語言文字
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 為 PowerPoint 與 OpenDocument 簡報文字設定校對語言，包含預設值與多語言段落。"
---
## **概述**

Aspose.Slides for .NET 讓您可以為單一文字片段設定校對中繼資料。使用[IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/languageid/) 來辨識校對語言，使用[BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/spellcheck/) 以允許或抑制拼寫檢查，並使用[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/proofdisabled/) 來控制更廣泛的「不校對」狀態。因為這些設定是套用在片段層級，所以同一段落可以包含多種語言與不同的校對規則。

本文說明如何為特定文字指派語言、使用[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/defaulttextlanguage/) 設定新文字的預設語言、建立多語言段落、在 `SpellCheck` 與 `ProofDisabled` 之間做選擇，以及在使用[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/joinportionswithsameformatting/) 時保留預期的設定。這些屬性僅儲存簡報應用程式的中繼資料；它們不會翻譯文字、執行基於字典的拼寫檢查，或回傳錯字。

## **為文字設定校對語言**

建立或載入一個[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/)，透過[IPortion.PortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/portionformat/) 取得所需的文字片段，並指派其語言識別碼。以下範例建立一個圖形、將英式英語設為校對語言，並使用[Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 儲存結果：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **設定新文字的預設語言**

使用[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/defaulttextlanguage/) 指定 Aspose.Slides 為新建立的文字指派的校對語言。當簡報中大部分或全部新文字使用相同語言時，此設定特別有用。它不會變更已明確設定語言的文字的語言中繼資料。

以下範例建立一個簡報，其新文字使用德文校對規則：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **在同一段落中使用多種語言**

[IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 包含一系列文字片段。為每種語言建立一個獨立的[Portion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portion/)，並分別設定其 `LanguageId`。

此範例建立一個段落，內含英文與法文片段：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **為單一片段啟用或抑制拼寫檢查**

[IPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/) 繼承自[IBasePortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/) 所定義的通用文字屬性。透過[IPortion.PortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/portionformat/) 取得片段的格式，並設定[BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/spellcheck/) 以控制簡報應用程式是否檢查該片段的拼寫。預設值為 `false`：`true` 允許拼寫檢查，`false` 則抑制檢查。

此設定適用於單一文字片段，同段落中的不同片段因此可以使用不同的值。[BasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/languageid/) 與 `SpellCheck` 互補：`LanguageId` 用於辨識校對語言，`SpellCheck` 用於決定是否允許拼寫檢查。

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/proofdisabled/) 也會控制校對，但它以[NullableBool](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/nullablebool/) 形式表示更廣泛的「不校對」狀態。當您需要專門針對拼寫檢查的布林開關時，使用 `SpellCheck`；當您需要保留或明確控制簡報的「不校對」中繼資料（包括 `NotDefined` 狀態）時，使用 `ProofDisabled`。若同時設定兩個屬性，請保持其值一致；不要將 `SpellCheck = true` 與 `ProofDisabled = NullableBool.True` 同時使用。

這些屬性會設定 PowerPoint 與其他簡報應用程式使用的校對中繼資料。Aspose.Slides 不會利用它們執行字典式拼寫檢查或回傳錯字清單。

以下完整範例建立輸入簡報、載入簡報、為同一段落中的兩個片段指派不同的拼寫檢查設定與校對語言、儲存結果、重新開啟並驗證儲存的值：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/joinportionswithsameformatting/) 會合併具有相同格式的相鄰片段。僅 `SpellCheck` 的差異不會保持這些片段分離；合併後的片段會保留第一個片段的 `SpellCheck` 值。如果片段需要不同的拼寫檢查設定，請在指派這些設定之前呼叫 `JoinPortionsWithSameFormatting`，或在合併後檢查產生的片段邊界並重新套用設定。具有不同 `LanguageId` 值的片段會保持分離，因為其校對語言格式不同。

## **常見問題**

**語言 ID 會翻譯文字嗎？**

不會。[IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/languageid/) 只儲存拼寫與文法的校對中繼資料，並不會改變文字內容。請先自行翻譯文字，再為每個已翻譯的片段設定適當的語言識別碼。

**校對語言會控制字型、斷字或換行嗎？**

不會。語言識別碼僅用於校對。文字的呈現與版面配置主要取決於可用的[字型](/slides/zh-hant/net/powerpoint-fonts/)、書寫系統以及文字框設定。為確保正確呈現，請提供所需字型、設定[字型替代](/slides/zh-hant/net/font-substitution/)或在簡報中[嵌入字型](/slides/zh-hant/net/embedded-font/)。

**一個段落可以使用多種校對語言嗎？**

可以。如多語言段落範例所示，將每種語言指派給獨立的片段即可。

**應該使用 `DefaultTextLanguage` 還是 `LanguageId`？**

當您想為新建立的文字設定整體預設時，使用[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/defaulttextlanguage/)。當需要為特定片段指定明確的校對語言，或段落包含多種語言時，使用[IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/languageid/)。