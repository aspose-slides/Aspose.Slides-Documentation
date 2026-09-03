---
title: 在 JavaScript 中嵌入演示文稿的字体
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/nodejs-java/embedded-font/
keywords:
- 添加字体
- 嵌入字体
- 字体嵌入
- 获取嵌入字体
- 添加嵌入字体
- 移除嵌入字体
- 压缩嵌入字体
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 管理 PowerPoint 中的嵌入字体。添加、检索、移除和压缩字体，以保持文本外观并减小文件大小。"
---
## **简介**

嵌入字体会将字体数据存储在 PowerPoint 演示文稿中。当查看器支持嵌入字体时，即使目标系统未安装这些字体，也能使用它们显示文本。这有助于保留换行、文字间距和幻灯片布局。

Aspose.Slides for Node.js via Java 让您通过由 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getfontsmanager/) 返回的 [FontsManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/) 类检索、添加和移除嵌入字体。您还可以通过删除演示文稿未使用的字符来减小嵌入字体数据的大小。

下面的示例使用 PPTX 文件。嵌入字体之前，请确保字体数据可供 Aspose.Slides 使用，并且其许可证允许嵌入。

## **获取和移除嵌入字体**

使用 [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) 列出存储在演示文稿中的字体。要移除某个字体，请将该列表中的字体传递给 [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/)，然后保存演示文稿。

下面的示例列出 `EmbeddedFonts.pptx` 中的嵌入字体，并在存在时移除 Calibri：

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

移除嵌入字体会删除其存储的字体数据；但不会更改已分配给文本的字体。如果目标系统已安装该字体，文本仍可使用它。否则，渲染可能需要 [font substitution](/slides/zh/nodejs-java/font-substitution/)，这会影响布局。

## **检查字体数据及嵌入权限**

使用 [FontsManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/) 类在嵌入前检查字体。调用 [FontsManager.getFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getfonts/) 可检索演示文稿中使用的字体。对于每个字体，传入一个 [FontData](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontdata/) 对象和所需的 [FontStyleType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontstyletype/) 值，调用 [FontsManager.getFontBytes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/#getFontBytes)。该方法返回该字体样式的二进制数据，若请求的字体或样式不可用则返回 `null`。不要将 `null` 结果传递给 [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel)，因为该方法需要字节数组。在 Node.js 中，使用 `java.newArray` 将返回的 JavaScript 数组转换为 Java 字节数组后再传给 `getFontEmbeddingLevel`。

[EmbeddingLevel](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/embeddinglevel/) 报告字体中存储的嵌入限制，以一组标志表示：

- `Installable` 允许嵌入并在另一系统上永久安装，受字体许可证约束。
- `Restricted` 除非获得字体合法所有者的许可，否则禁止嵌入（当它是唯一的使用权限标志时）。
- `PreviewPrint` 允许临时用于查看和打印；包含该字体的文档必须为只读。
- `Editable` 允许临时使用，并且文档可编辑和保存。
- `NoSubsetting` 是额外限制，禁止仅嵌入子集字形。存在此标志时必须嵌入所有字符。
- `BitmapOnly` 是额外限制，只允许嵌入位图字形而非轮廓数据。如果字体没有位图字形，则无法嵌入。

前四个值描述使用权限，`NoSubsetting` 和 `BitmapOnly` 可以与它们组合。使用按位运算检查这些修饰符。由于 `Installable` 为零，请对使用权限位进行掩码，并将结果与 `Installable` 比较，而不是将其视为标志。当前字体应至多设置一个使用权限位。为兼容设置了多个位的旧字体，下面的辅助代码会选择最不受限制的权限：`Editable` → `PreviewPrint` → `Restricted`。

下面的示例审计 `getFonts` 返回的每种字体的常规、粗体、斜体和粗斜体数据。它会跳过不可用的样式、受限制的字体、仅位图字体、仅限预览和打印的字体（因为输出保持可编辑），以及已经嵌入的字体。如果任何可用样式带有 `NoSubsetting`，则为该字体族嵌入所有字符。

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

此检查报告每个字体文件中编码的限制。它并不授予许可证、证明您合法获取了字体，也不能替代在分发嵌入副本之前检查字体许可证协议的步骤。

## **添加嵌入字体**

使用 [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) 嵌入字体。其重载接受 [FontData](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontdata/) 对象或包含字体数据的字节数组。[EmbedFontCharacters](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/embedfontcharacters/) 控制包含哪些字符：

- `All` 嵌入字体中的所有字符。当收件人需要编辑演示文稿并输入新文本时使用此选项。
- `OnlyUsed` 仅嵌入演示文稿中使用的字符，以减小文件大小。对已完成且主要用于观看的演示文稿请选择此选项。

下面的示例使用 [FontsManager.getFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getfonts/) 检索 `Fonts.pptx` 中使用的字体，并嵌入那些尚未嵌入的字体。要添加的字体必须在运行代码的机器上可用。已有的嵌入字体会保留其当前字符集。

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

## **压缩嵌入字体**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/compressembeddedfonts/) 通过删除未使用的字符来减小嵌入字体数据。它作用于已经嵌入的字体，因此大小的缩减取决于演示文稿中未使用的字体数据量。

下面的示例压缩 `EmbeddedFonts.pptx` 中的字体，并将结果保存为单独的文件：

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

如果收件人以后可能需要添加文本，请保留原始文件。压缩期间删除的字符将不再可从嵌入的字体中获取，即使最初已经嵌入了所有字符。

## **常见问答**

**如何检查嵌入字体在渲染时是否仍会被替换？**

在渲染演示文稿的环境中调用 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)，查看 Aspose.Slides 将替换哪些字体。同时检查 [font substitution](/slides/zh/nodejs-java/font-substitution/) 设置和 [font fallback](/slides/zh/nodejs-java/fallback-font/) 规则。回退处理缺失字符，因此嵌入字体并不能解决字体本身不包含的字符。

**是否应该嵌入常用字体如 Arial 和 Calibri？**

依据目标环境决定。如果所需字体在每台打开或渲染演示文稿的机器上都已可用，嵌入它们可能会导致不必要的文件增大。如果收件人或服务器可能缺少这些字体，且其许可证允许嵌入，则嵌入可以帮助保持预期的外观。