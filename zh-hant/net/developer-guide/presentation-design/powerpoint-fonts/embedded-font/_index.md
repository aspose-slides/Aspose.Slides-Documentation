---
title: 在 .NET 中的簡報嵌入字型
linktitle: 已嵌入字型
type: docs
weight: 40
url: /zh-hant/net/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得已嵌入字型
- 加入已嵌入字型
- 移除已嵌入字型
- 壓縮已嵌入字型
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 中管理已嵌入的字型。使用 C# 來新增、取得、移除與壓縮字型，以保留文字外觀並減少檔案大小。"
---
## **簡介**

嵌入字型會把字型資料儲存在 PowerPoint 簡報內。當檢視器支援嵌入字型時，即使目標系統未安裝該字型，也能使用這些字型顯示文字。這有助於保留換行、文字間距以及投影片版面配置。

Aspose.Slides for .NET 讓您透過 [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) 屬性在 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 中取得、加入與移除嵌入字型。您也可以透過移除簡報未使用的字元來減少嵌入字型資料的大小。

以下範例使用 PPTX 檔案。嵌入字型前，請確保字型資料可供 Aspose.Slides 使用，且其授權允許嵌入。

## **取得與移除嵌入字型**

使用 [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) 列出簡報中儲存的字型。若要移除其中一個字型，將該列表中的字型傳遞給 [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/)，然後儲存簡報。

以下範例列出 `EmbeddedFonts.pptx` 中的嵌入字型，並在出現 Calibri 時將其移除：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

移除嵌入字型會刪除其儲存的字型資料；不會改變文字所指派的字型。如果目標系統已安裝該字型，文字仍會使用它。否則，渲染可能需要 [font substitution](/slides/zh-hant/net/font-substitution/)，這可能會影響版面配置。

## **檢查字型資料與嵌入權限**

使用 [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) 介面在嵌入前檢查字型。呼叫 [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) 取得簡報使用的字型。對於每個字型，傳遞一個 [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) 物件與所需的 [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) 值給 [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/)。該方法會回傳該字型樣式的二進位資料，若請求的字型或樣式不存在則回傳 `null`。不要將 `null` 結果傳遞給 [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/)，因為該方法需要位元組陣列。

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) 是一個旗標列舉，報告字型中儲存的嵌入限制：

- `Installable` 允許嵌入並在其他系統上永久安裝，須符合字型授權。
- `Restricted` 禁止嵌入，除非取得字型合法擁有者的許可，且此旗標為唯一的使用權限旗標。
- `PreviewPrint` 允許暫時使用以檢視與列印；包含該字型的文件必須為唯讀。
- `Editable` 允許暫時使用，且文件可編輯與儲存。
- `NoSubsetting` 為額外限制，禁止僅嵌入字形子集。若出現此旗標，必須嵌入所有字元。
- `BitmapOnly` 為額外限制，只允許嵌入點陣字形，不能嵌入輪廓資料。若字型沒有點陣字形，則無法嵌入。

前四個值描述使用權限，而 `NoSubsetting` 與 `BitmapOnly` 可以與它們結合。使用位元運算檢查這些修飾子。由於 `Installable` 為零，請勿使用 `HasFlag` 來偵測它；請將使用權限位遮罩並與 `Installable` 比較。當前的字型應最多設定一個使用權限位。為了相容於設定多個位元的舊版字型，以下輔助程式會選取限制最寬鬆的權限：`Editable`、`PreviewPrint`、`Restricted`。

以下範例稽核 `GetFonts` 回傳的每個字型的正規、粗體、斜體與粗斜體資料。若樣式不可用、字型受限、僅點陣或僅預覽列印，或已嵌入，則會跳過。若任何可用樣式具有 `NoSubsetting`，則會為該字型家族嵌入所有字元。

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

此檢查會報告每個字型檔案中編碼的限制。它不會授予授權、證明您已合法取得字型，也不會取代在分發嵌入副本前檢查字型授權協議的步驟。

## **加入嵌入字型**

使用 [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) 來嵌入字型。其多載接受 [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) 物件或包含字型資料的位元組陣列。[EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 列舉控制包含哪些字元：

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 會嵌入字型的所有字元。當收件人需要編輯簡報並輸入新文字時使用此選項。
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 只嵌入簡報中實際使用的字元，以減少檔案大小。對於主要供檢視的完成簡報請選擇此選項。

以下範例使用 [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) 取得 `Fonts.pptx` 中使用的字型，並嵌入尚未嵌入的字型。要加入的字型必須在執行程式的機器上可用。已存在的嵌入字型會保留其目前的字元集。

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **壓縮嵌入字型**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) 透過移除未使用的字元來減少嵌入字型資料。它針對已嵌入的字型運作，縮減幅度取決於簡報中未使用字型資料的多少。

以下範例壓縮 `EmbeddedFonts.pptx` 中的字型，並將結果儲存為另一個檔案：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

若收件人日後可能需要加入文字，請保留原始檔案。壓縮過程中移除的字元將不再可從嵌入的字型取得，即使最初已嵌入全部字元。

若希望在匯出時讓匹配的已註冊字型取得優先權而不移除嵌入字型，請參閱 [Prefer Registered Fonts over Embedded Fonts](/slides/zh-hant/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) （.NET 26.11 或更新版本）。

## **常見問題**

**如何檢查嵌入字型在渲染時是否仍會被替代？**

在執行渲染的環境中呼叫 [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/)，即可看到 Aspose.Slides 會替換哪些字型。同時檢查 [font substitution](/slides/zh-hant/net/font-substitution/) 設定與 [font fallback](/slides/zh-hant/net/fallback-font/) 規則。回退處理缺少的字元，因此嵌入字型並不會解決字型本身不包含的字元。

**是否應該嵌入像 Arial 與 Calibri 這類常見字型？**

應根據目標環境決定。如果所有開啟或渲染簡報的機器皆已安裝所需字型，嵌入可能會增加不必要的檔案大小。若收件人或伺服器可能缺少這些字型，且其授權允許，則嵌入可協助保留預期的外觀。