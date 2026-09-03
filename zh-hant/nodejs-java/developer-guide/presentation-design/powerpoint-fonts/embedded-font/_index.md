---
title: 在 JavaScript 中於簡報嵌入字體
linktitle: 已嵌入字體
type: docs
weight: 40
url: /zh-hant/nodejs-java/embedded-font/
keywords:
- 新增字體
- 嵌入字體
- 字體嵌入
- 取得已嵌入字體
- 新增已嵌入字體
- 移除已嵌入字體
- 壓縮已嵌入字體
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 管理 PowerPoint 中的嵌入字體。添加、取得、移除及壓縮字體，以保持文字外觀並減少檔案大小。"
---
## **簡介**

嵌入字體會將字型資料儲存在 PowerPoint 簡報內。當檢視器支援嵌入字體時，即使目標系統未安裝該字體，也能使用這些字體顯示文字。這有助於保留換行、文字間距與投影片版面配置。

Aspose.Slides for Node.js via Java 讓您能透過由 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getfontsmanager/) 傳回的 [FontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/) 類別取得、添加與移除嵌入字體。您也可以透過移除簡報未使用的字元來減少嵌入字體資料的大小。

以下範例適用於 PPTX 檔案。在嵌入字體之前，請確保該字體資料可供 Aspose.Slides 使用，且其授權允許嵌入。

## **取得與移除嵌入字體**

使用 [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) 可列出儲存在簡報中的字體。若要移除其中一個，將該列表中的字體傳遞給 [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/)，然後儲存簡報。

以下範例列出 `EmbeddedFonts.pptx` 中的嵌入字體，並在存在時移除 Calibri：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

移除嵌入字體會刪除其儲存的字體資料；不會改變文字所指派的字體。若目標系統已安裝該字體，文字仍可使用它。否則，呈現可能需要[字體替代](/slides/zh-hant/nodejs-java/font-substitution/)，這可能會影響版面配置。

## **檢查字體資料與嵌入許可權**

在嵌入字體之前，請使用 [FontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/) 類別檢查字體。呼叫 [FontsManager.getFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getfonts/) 可取得簡報中使用的字體。對於每個字體，將 [FontData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontdata/) 物件與所需的 [FontStyleType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontstyletype/) 值傳遞給 [FontsManager.getFontBytes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/#getFontBytes)。此方法會回傳該字體樣式的二進位資料，若請求的字體或樣式不存在則回傳 `null`。請勿將 `null` 結果傳遞給 [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel)，因為該方法需要位元組陣列。在 Node.js 中，於傳遞給 `getFontEmbeddingLevel` 之前，先使用 `java.newArray` 將回傳的 JavaScript 陣列轉換為 Java 位元組陣列。

[EmbeddingLevel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/embeddinglevel/) 會報告字體中儲存的嵌入限制，作為一組旗標：

- `Installable` 允許嵌入並可在其他系統上永久安裝，需遵守字體授權。
- `Restricted` 禁止嵌入，除非在它是唯一使用許可旗標時取得字體合法擁有者的授權。
- `PreviewPrint` 允許暫時用於檢視與列印；包含該字體的文件必須為唯讀。
- `Editable` 允許暫時使用，且文件可被編輯與儲存。
- `NoSubsetting` 為額外限制，禁止僅嵌入字形子集。若出現此旗標，必須嵌入全部字元。
- `BitmapOnly` 為額外限制，只允許嵌入點陣字形而非輪廓資料。若字體沒有點陣字形，則無法嵌入。

前四個值描述使用許可，而 `NoSubsetting` 與 `BitmapOnly` 可以與它們結合。請使用位元運算檢查這些修飾。因為 `Installable` 為零，所以請遮罩使用許可位元，並將結果與 `Installable` 比較，而不是將其作為旗標檢查。現行字體應最多設定一個使用許可位元。為相容設定了多個位元的舊字體，以下輔助程式會選取限制最少的許可：`Editable`、`PreviewPrint`、`Restricted`。

以下範例稽核 `getFonts` 回傳的每個字體所提供的常規、粗體、斜體與粗斜體資料。它會跳過不可用的樣式、受限制的字體、僅點陣字體、因輸出仍可編輯而受限於預覽與列印的字體，以及已嵌入的字體。若任何可用樣式具備 `NoSubsetting`，則會為該字體家族嵌入全部字元。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此檢查會回報每個字體檔案中編碼的限制。它不會授予授權、證明您合法取得字體，亦不取代在分發嵌入副本之前檢查字體授權協議的程序。

## **添加嵌入字體**

使用 [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) 以嵌入字體。其多載接受 [FontData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontdata/) 物件或包含字體資料的位元組陣列。[EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/embedfontcharacters/) 控制所包含的字元：

- `All` 會嵌入字體中的全部字元。當接收者需要編輯簡報並輸入新文字時，請使用此選項。
- `OnlyUsed` 僅嵌入簡報中使用的字元，以減少檔案大小。對於主要供檢視的最終簡報，請選擇此選項。

以下範例使用 [FontsManager.getFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getfonts/) 取得 `Fonts.pptx` 中使用的字體，並嵌入尚未嵌入的字體。要添加的字體必須在執行程式的機器上可用。現有的嵌入字體會保留其目前的字元集合。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **壓縮嵌入字體**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/compressembeddedfonts/) 透過移除未使用的字元來減少嵌入字體資料。它作用於已嵌入的字體，因此大小縮減程度取決於簡報中未使用的字體資料量。

以下範例壓縮 `EmbeddedFonts.pptx` 中的字體，並將結果儲存為另一個檔案：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若接收者未來可能需要添加文字，請保留原始檔案。壓縮過程中移除的字元將不再能從嵌入字體取得，即使您最初已嵌入所有字元。

## **常見問答**

**如何檢查嵌入字體在呈現時是否仍會被替代？**

在您渲染簡報的環境中呼叫 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 以查看 Aspose.Slides 將會取代哪些字體。亦請檢查[字體替代](/slides/zh-hant/nodejs-java/font-substitution/)設定與[字體回退](/slides/zh-hant/nodejs-java/fallback-font/)規則。回退處理缺少的字元，因此即使嵌入字體，也不會解決該字體本身未包含的字元。

**是否應該嵌入常見字體，如 Arial 與 Calibri？**

請依據目標環境決定。如果所有開啟或呈現簡報的機器皆具備所需字體，嵌入它們可能會增加不必要的檔案大小。如果接收者或伺服器可能缺少這些字體，則嵌入它們可協助保留預期的外觀，前提是其授權允許如此。