---
title: 在 Android 上的演示文稿中嵌入字体
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/androidjava/embedded-font/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 管理 PowerPoint 中的嵌入字体。添加、检索、删除和压缩字体，以保持文本外观并降低文件大小。"
---
## **介绍**

嵌入字体会将字体数据存储在 PowerPoint 演示文稿中。当查看器支持嵌入字体时，即使目标系统未安装这些字体，也能使用这些字体显示文本。这有助于保留换行、文本间距和幻灯片布局。

Aspose.Slides for Android via Java 允许您通过由 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getFontsManager--) 返回的 [IFontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/) 接口检索、添加和删除嵌入字体。您还可以通过删除演示文稿未使用的字符来减小嵌入字体数据的大小。

下面的示例使用 PPTX 文件。在嵌入字体之前，请确保该字体的数据可供 Aspose.Slides 使用且其许可证允许嵌入。

## **获取和删除嵌入字体**

使用 [getEmbeddedFonts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) 列出演示文稿中存储的字体。要删除某个字体，请将列表中的字体传递给 [removeEmbeddedFont](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)，然后保存演示文稿。

下面的示例列出 `EmbeddedFonts.pptx` 中的嵌入字体，并在存在时移除 Calibri：
```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

删除嵌入字体会删除其存储的字体数据；但不会更改文本所使用的字体。如果目标系统已安装该字体，文本仍然可以使用它。否则，渲染可能需要[font substitution](/slides/zh/androidjava/font-substitution/)，这会影响布局。

## **检查字体数据和嵌入权限**

在嵌入字体之前，使用 [IFontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/) 接口检查字体。调用 [IFontsManager.getFonts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) 可检索演示文稿中使用的字体。对于每个字体，将一个 [IFontData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontdata/) 对象和所需的 [FontStyleType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fontstyletype/) 值传递给 [IFontsManager.getFontBytes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-)。该方法返回该字体样式的二进制数据；如果请求的字体或样式不可用，则返回 `null`。不要将 `null` 结果传递给 [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-)，因为该方法需要字节数组。

[EmbeddingLevel](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/embeddinglevel/) 是一个标志枚举，用于报告存储在字体中的嵌入限制：

- `Installable` 允许嵌入并在另一系统上永久安装，前提是符合字体许可证。
- `Restricted` 禁止嵌入，除非在它是唯一使用许可标志时从字体合法所有者处获得许可。
- `PreviewPrint` 允许临时用于查看和打印；包含该字体的文档必须为只读。
- `Editable` 允许临时使用并且文档可以被编辑和保存。
- `NoSubsetting` 是一种附加限制，禁止仅嵌入字形子集。出现此标志时必须嵌入所有字符。
- `BitmapOnly` 是一种附加限制，只允许嵌入位图字形，而不是轮廓数据。如果字体没有位图字形，则无法嵌入。

前四个值描述使用许可，而 `NoSubsetting` 和 `BitmapOnly` 可以与它们组合。使用按位运算检查这些修饰符。由于 `Installable` 为零，请对使用许可位进行掩码并将结果与 `Installable` 比较，而不是将其视为标志检查。当前字体应最多设置一个使用许可位。为兼容设置了多个位的旧字体，下面的辅助函数会选择最宽松的许可：先 `Editable`，再 `PreviewPrint`，最后 `Restricted`。

下面的示例审计 `getFonts` 返回的每个字体的常规、粗体、斜体和粗斜体数据。它会跳过不可用的样式、受限字体、仅位图字体、因输出仍可编辑而限制为预览和打印的字体，以及已经嵌入的字体。如果任何可用样式带有 `NoSubsetting`，则为该字体系列嵌入所有字符。
```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此检查报告每个字体文件中编码的限制。它不提供许可证，也不证明您合法获取了该字体，且不能替代在分发嵌入副本之前检查字体许可协议的步骤。

## **添加嵌入字体**

使用 [addEmbeddedFont](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) 可嵌入字体。其重载接受 [IFontData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontdata/) 对象或包含字体数据的字节数组。[EmbedFontCharacters](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/embedfontcharacters/) 枚举控制包含哪些字符：

- `[All]` 嵌入字体中的所有字符。收件人需要编辑演示文稿并输入新文本时使用此选项。
- `[OnlyUsed]` 仅嵌入演示文稿中使用的字符，以减小文件大小。对主要用于查看的已完成演示文稿请选择此选项。

下面的示例使用 [getFonts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) 检索 `Fonts.pptx` 中使用的字体，并嵌入尚未嵌入的字体。要添加的字体必须在 Android 设备上可用或已在 Aspose.Slides 中注册。已有的嵌入字体会保留其当前字符集。
```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **压缩嵌入字体**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 通过删除未使用的字符来减小嵌入字体数据。它作用于已经嵌入的字体，因此大小缩减取决于演示文稿中未使用的字体数据量。

下面的示例压缩 `EmbeddedFonts.pptx` 中的字体并将结果保存为单独的文件：
```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果收件人以后可能需要添加文本，请保留原始文件。压缩过程中删除的字符将不再可从嵌入字体中获取，即使您最初嵌入了所有字符。

## **常见问题**

**如何检查嵌入字体在渲染时是否仍会被替代？**

在渲染演示文稿的环境中调用 [getSubstitutions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--)，即可查看 Aspose.Slides 将替换哪些字体。同时检查[font substitution](/slides/zh/androidjava/font-substitution/)设置和[font fallback](/slides/zh/androidjava/fallback-font/)规则。Fallback 处理缺失字符，因此嵌入字体并不能解决该字体本身不包含的字符。

**我应该嵌入诸如 Arial 和 Calibri 等常用字体吗？**

应根据目标环境来决定。如果所需字体在每台打开或渲染演示文稿的设备上都可用，则嵌入它们可能会增加不必要的文件大小。如果收件人或服务器可能缺少这些字体，嵌入它们可以帮助保持预期的外观，前提是其许可证允许。