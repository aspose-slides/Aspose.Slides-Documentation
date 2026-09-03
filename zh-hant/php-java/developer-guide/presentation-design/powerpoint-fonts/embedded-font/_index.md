---
title: 使用 PHP 在簡報中嵌入字型
linktitle: 嵌入字型
type: docs
weight: 40
url: /zh-hant/php-java/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得嵌入字型
- 加入嵌入字型
- 移除嵌入字型
- 壓縮嵌入字型
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理 PowerPoint 中的嵌入字型。新增、取得、移除與壓縮字型，以保留文字外觀並減少檔案大小。"
---
## **簡介**

嵌入字型會將字型資料儲存在 PowerPoint 簡報內。當檢視程式支援嵌入字型時，即使目標系統未安裝這些字型，也能以該字型顯示文字。這有助於保留換行、文字間距與投影片版面配置。

Aspose.Slides for PHP via Java 讓您能透過由 [Presentation::getFontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getFontsManager) 回傳的 [FontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/) 類別，取得、加入與移除嵌入字型。您也可以透過移除簡報未使用的字元，減少嵌入字型資料的大小。

以下範例適用於 PPTX 檔案。在嵌入字型之前，請確認該字型資料可供 Aspose.Slides 使用，且其授權允許嵌入。

## **取得與移除嵌入字型**

使用 [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 列出簡報中儲存的字型。要移除其中一個字型，將該清單中的字型傳遞給 [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont)，然後儲存簡報。

下列範例會列出 `EmbeddedFonts.pptx` 中的嵌入字型，並在存在時移除 Calibri：

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

移除嵌入字型會刪除其儲存的字型資料；不會變更文字所指派的字型。如果該字型已安裝在目標系統上，文字仍可使用它。否則，渲染可能需要[字型替代](/slides/zh-hant/php-java/font-substitution/)，這可能會影響版面配置。

## **檢查字型資料與嵌入權限**

使用 [FontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/) 類別於嵌入前檢查字型。呼叫 [FontsManager::getFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/#getFonts) 取得簡報中使用的字型。對於每個字型，將 [FontData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontdata/) 物件與所需的 [FontStyleType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontstyletype/) 值傳遞給 [FontsManager::getFontBytes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/#getFontBytes)。此方法會回傳該字型樣式的二進位資料，若請求的字型或樣式不存在則回傳 `null`。不要將 `null` 結果傳遞給 [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel)，因為該方法需要位元組陣列。

[EmbeddingLevel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/embeddinglevel/) 是一個旗標列舉，用來回報字型中儲存的嵌入限制：

- `Installable` 允許嵌入並在其他系統上永久安裝，須遵守字型授權。
- `Restricted` 禁止嵌入，除非取得字型合法所有者的許可（當它是唯一的使用權限旗標時）。
- `PreviewPrint` 允許暫時用於檢視與列印；包含該字型的文件必須是唯讀的。
- `Editable` 允許暫時使用，且文件可以編輯與儲存。
- `NoSubsetting` 為額外限制，禁止僅嵌入字形子集。若有此旗標，必須嵌入所有字元。
- `BitmapOnly` 為額外限制，只允許嵌入點陣圖字形而非向量輪廓。若字型沒有點陣圖字形，則無法嵌入。

前四個值描述使用權限，而 `NoSubsetting` 與 `BitmapOnly` 可與之結合。請使用位元運算檢查這些修飾子。由於 `Installable` 為零，應對使用權限位元做遮罩，並將結果與 `Installable` 比較，而非將其視為旗標檢查。目前的字型應最多只設定一個使用權限位元。為相容於設定了多個位元的舊字型，以下輔助程式會選取限制最少的權限：先檢查 `Editable`，若無則 `PreviewPrint`，最後 `Restricted`。

以下範例稽核 `FontsManager::getFonts` 所回傳的每個字型的常規、粗體、斜體與粗斜體資料。它會跳過不可用的樣式、受限制的字型、僅點陣圖的字型、因僅限於預覽與列印而輸出仍可編輯的字型，以及已嵌入的字型。若任何可用樣式具有 `NoSubsetting`，則為該字型系列嵌入所有字元。

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

此檢查會回報每個字型檔案中編碼的限制。它不會授予授權、證明您合法取得字型，亦不取代在分發嵌入副本前檢查字型授權協議的程序。

## **加入嵌入字型**

使用 [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) 來嵌入字型。其多載接受 [FontData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontdata/) 物件或包含字型資料的位元組陣列。[EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/embedfontcharacters/) 列舉控制包含哪些字元：

- `All` 會嵌入字型中的所有字元。當收件者需要編輯簡報並輸入新文字時，請使用此選項。
- `OnlyUsed` 只會嵌入簡報中使用的字元，以減少檔案大小。適用於主要供檢視的完成簡報。

以下範例使用 [FontsManager::getFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/#getFonts) 取得 `Fonts.pptx` 中使用的字型，並嵌入尚未嵌入的字型。要加入的字型必須在執行程式的機器上可用。已嵌入的字型會保留其現有字元集。

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

## **壓縮嵌入字型**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#compressEmbeddedFonts) 透過移除未使用的字元來減少嵌入字型資料。它作用於已嵌入的字型，因而縮減幅度取決於簡報中未使用字型資料的多少。

以下範例會壓縮 `EmbeddedFonts.pptx` 中的字型，並將結果儲存為另一個檔案：

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

如果收件者日後可能需要加入文字，請保留原始檔。壓縮時移除的字元將不再可從嵌入字型取得，即使您最初已嵌入所有字元。

## **常見問題**

**如何檢查嵌入的字型在渲染時是否仍會被替代？**

在您渲染簡報的環境中呼叫 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/#getSubstitutions) 以查看 Aspose.Slides 會替換哪些字型。也請檢查[字型替代](/slides/zh-hant/php-java/font-substitution/)設定與[字型回退](/slides/zh-hant/php-java/fallback-font/)規則。回退會處理缺少的字元，因此嵌入字型並不會解決該字型本身不包含的字元。

**我應該嵌入常見字型，例如 Arial 與 Calibri 嗎？**

應根據目標環境做決策。若所需字型在每台開啟或渲染簡報的機器上皆可取得，則嵌入它們可能會增加不必要的檔案大小。若收件者或伺服器可能缺少這些字型，則嵌入它們可以協助保留預期的外觀，前提是其授權允許。