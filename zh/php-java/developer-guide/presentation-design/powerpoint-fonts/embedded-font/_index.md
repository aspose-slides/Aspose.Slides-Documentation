---
title: 使用 PHP 在演示文稿中嵌入字体
linktitle: 嵌入的字体
type: docs
weight: 40
url: /zh/php-java/embedded-font/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 中管理嵌入字体。添加、检索、移除和压缩字体，以保持文本外观并减小文件大小。"
---
## **介绍**

嵌入字体会将字体数据存储在 PowerPoint 演示文稿内部。当查看器支持嵌入字体时，即使目标系统上未安装这些字体，也能使用它们显示文本。这有助于保持换行、文本间距以及幻灯片布局。

Aspose.Slides for PHP via Java 让您通过由 [Presentation::getFontsManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getFontsManager) 返回的 [FontsManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/) 类检索、添加和移除嵌入字体。您还可以通过删除演示文稿未使用的字符来减小嵌入字体数据的大小。

下面的示例使用 PPTX 文件。嵌入字体之前，请确保 Aspose.Slides 能访问该字体的数据，并且其许可证允许嵌入。

## **获取和移除嵌入字体**

使用 [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 列出演示文稿中存储的字体。要移除某个字体，请将该列表中的字体传递给 [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont)，然后保存演示文稿。

下面的示例列出 `EmbeddedFonts.pptx` 中的嵌入字体，并在存在时移除 Calibri：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

移除嵌入字体会删除其存储的字体数据；它不会改变文本所使用的字体。如果目标系统已安装该字体，文本仍然可以使用它。否则，渲染可能需要 [字体替换](/slides/zh/php-java/font-substitution/)，从而影响布局。

## **检查字体数据和嵌入权限**

使用 [FontsManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/) 类在嵌入前检查字体。调用 [FontsManager::getFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/#getFonts) 获取演示文稿中使用的字体。对于每个字体，传入一个 [FontData](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontdata/) 对象和所需的 [FontStyleType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontstyletype/) 值，调用 [FontsManager::getFontBytes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/#getFontBytes)。该方法返回该字体样式的二进制数据；如果请求的字体或样式不可用，则返回 `null`。不要将 `null` 结果传递给 [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel)，因为该方法需要字节数组。

[EmbeddingLevel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/embeddinglevel/) 是一个标志枚举，报告字体中存储的嵌入限制：

- `Installable` 允许嵌入并在其他系统上永久安装，前提是符合字体许可证。
- `Restricted` 除非获得字体合法所有者的许可，否则禁止嵌入（当它是唯一的使用许可标志时）。
- `PreviewPrint` 允许临时用于查看和打印；包含该字体的文档必须为只读。
- `Editable` 允许临时使用，并且文档可以被编辑和保存。
- `NoSubsetting` 是额外限制，禁止仅嵌入子集字形。出现此标志时必须嵌入所有字符。
- `BitmapOnly` 是额外限制，只允许嵌入位图字形而非轮廓数据。如果字体没有位图字形，则无法嵌入。

前四个值描述使用许可，`NoSubsetting` 和 `BitmapOnly` 可以与它们组合。使用按位运算检查修饰符。由于 `Installable` 为零，请使用掩码获取使用许可位并将结果与 `Installable` 比较，而不是将其视为标志。当前字体应最多设置一个使用许可位。为兼容设置了多个位的旧字体，下面的助手会选择限制最小的许可：先 `Editable`，再 `PreviewPrint`，最后 `Restricted`。

下面的示例审计由 `FontsManager::getFonts` 返回的每个字体的常规、粗体、斜体和粗斜体数据。它会跳过不可用的样式、受限字体、仅位图字体、仅限预览和打印的字体（因为输出保持可编辑），以及已经嵌入的字体。如果任何可用样式具有 `NoSubsetting`，则为该字体系列嵌入所有字符。

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此检查报告每个字体文件中编码的限制。它不授予许可证，也不证明您已合法取得该字体，更不会替代在分发嵌入副本前检查字体许可证协议的步骤。

## **添加嵌入字体**

使用 [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) 嵌入字体。其重载接受 [FontData](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontdata/) 对象或包含字体数据的字节数组。[EmbedFontCharacters](https://reference.aspose.com/slides/zh/php-java/aspose.slides/embedfontcharacters/) 枚举控制包含哪些字符：

- [All](https://reference.aspose.com/slides/zh/php-java/aspose.slides/embedfontcharacters/) 嵌入字体中的所有字符。收件人需要编辑演示文稿并输入新文本时使用此选项。
- [OnlyUsed](https://reference.aspose.com/slides/zh/php-java/aspose.slides/embedfontcharacters/) 仅嵌入演示文稿中实际使用的字符，以减小文件大小。对主要用于查看的成品演示文稿请选择此选项。

下面的示例使用 [FontsManager::getFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/#getFonts) 检索 `Fonts.pptx` 中使用的字体，并嵌入那些尚未嵌入的字体。要添加的字体必须在运行代码的机器上可用。已有的嵌入字体会保留其当前字符集。

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **压缩嵌入字体**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/#compressEmbeddedFonts) 通过移除未使用的字符来减小嵌入字体数据。它作用于已经嵌入的字体，因此大小缩减取决于演示文稿中未使用的字体数据量。

下面的示例压缩 `EmbeddedFonts.pptx` 中的字体，并将结果另存为单独的文件：

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果收件人以后可能需要添加文本，请保留原始文件。压缩期间移除的字符将不再可从嵌入字体中获取，即使您最初已经嵌入了所有字符。

## **常见问题**

**我如何检查嵌入字体在渲染时是否仍会被替换？**

在渲染演示文稿的环境中调用 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/#getSubstitutions) 以查看 Aspose.Slides 将替换哪些字体。同时检查 [字体替换](/slides/zh/php-java/font-substitution/) 设置和 [字体回退](/slides/zh/php-java/fallback-font/) 规则。回退处理缺失字符，因此嵌入字体并不能解决该字体本身不包含的字符。

**我是否应该嵌入常见字体如 Arial 和 Calibri？**

依据目标环境决定。如果所需字体在每台打开或渲染演示文稿的机器上都可用，嵌入它们可能会导致不必要的文件增大。如果收件人或服务器可能缺少这些字体，且其许可证允许嵌入，则嵌入可以帮助保持预期的外观。