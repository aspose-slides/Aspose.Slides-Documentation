---
title: 在 PHP 中自訂 PowerPoint 字型
linktitle: 自訂字型
type: docs
weight: 20
url: /zh-hant/php-java/custom-font/
keywords:
- 字型
- 自訂字型
- 外部字型
- 載入字型
- 管理字型
- 字型資料夾
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 投影片中自訂字型，確保您的簡報在任何裝置上都保持清晰且一致。"
---
## **概觀**

Aspose.Slides 允許您在簡報中使用自訂字型，而不必在作業系統上安裝它們。您可以從自訂資料夾載入字型，透過文件層級的字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

已載入的字型會在簡報渲染或匯出時使用，例如匯出為 PDF、影像及其他支援的格式。這有助於確保不同環境下的簡報輸出保持一致。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

註冊自訂字型供渲染使用與將字型嵌入 PPTX 檔案是分開的。如果必須將字型儲存在簡報內部，請明確使用字型嵌入功能。

{{% alert color="primary" %}} 
Aspose Slides 允許您使用 [loadExternalFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法載入這些字型：

* TrueType (.ttf) 與 TrueType Collection (.ttc) 字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在未安裝於系統的情況下載入簡報中使用的字型。這會影響匯出輸出——如 PDF、影像以及其他支援的格式——使最終文件在不同環境下保持一致。字型會從自訂目錄載入。

1. 指定一個或多個包含字型檔案的資料夾。
2. 呼叫靜態 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法，從這些資料夾載入字型。
3. 載入並渲染/匯出簡報。
4. 呼叫 [FontsLoader::clearCache](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#clearCache--) 以清除字型快取。

以下程式碼範例示範字型載入流程：

```php
// 定義包含自訂字型檔案的資料夾。
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// 從指定的資料夾載入自訂字型。
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // 使用已載入的字型渲染/匯出簡報（例如 PDF、影像或其他格式）。
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // 完成工作後清除字型快取。
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 會將額外的資料夾加入字型搜尋路徑，但不會改變字型初始化順序。字型會依以下順序初始化：

1. 作業系統的預設字型路徑。
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/) 載入的路徑。
{{%/alert %}}

## **取得自訂字型資料夾**
Aspose.Slides 提供 [getFontFolders](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#getFontFolders--) 方法，讓您取得字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法新增的資料夾以及系統字型資料夾。

以下 PHP 程式碼示範如何使用 [getFontFolders](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#getFontFolders--)：

```php
# 此行輸出搜尋字型檔案的資料夾。
# 這些資料夾是透過 LoadExternalFonts 方法新增的以及系統字型資料夾。
$fontFolders = FontsLoader::getFontFolders();
```

## **指定簡報使用的自訂字型**
Aspose.Slides 提供 [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 方法，讓您指定在簡報中使用的外部字型。

以下 PHP 程式碼示範如何使用 [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 方法：

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # 對簡報進行操作
    # CustomFont1、CustomFont2 以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字型都可供簡報使用
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **外部管理字型**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，讓您從二進位資料載入外部字型。

以下 PHP 程式碼示範位元組陣列字型載入流程：

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # 在簡報生命週期內已載入外部字型
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **常見問題**

**自訂字型是否會影響所有格式的匯出（PDF、PNG、SVG、HTML）？**

是。已連結的字型會被渲染器在所有匯出格式中使用。

**自訂字型會自動嵌入最終的 PPTX 嗎？**

不會。將字型註冊供渲染使用並不等同於將其嵌入 PPTX。如果需要字型隨簡報檔案一起保存，必須使用明確的 [embedding features](/slides/zh-hant/php-java/embedded-font/)。

**當自訂字型缺少某些字形時，我可以控制備援行為嗎？**

可以。請設定 [font substitution](/slides/zh-hant/php-java/font-substitution/)、[replacement rules](/slides/zh-hant/php-java/font-replacement/) 與 [fallback sets](/slides/zh-hant/php-java/fallback-font/)，以明確定義在請求的字形缺失時使用哪個字型。

**我可以在 Linux/Docker 容器中使用字型而不必在系統全域安裝嗎？**

可以。指向您自己的字型資料夾或從位元組陣列載入字型。這樣即可消除容器映像檔對系統字型目錄的任何依賴。

**關於授權—我可以無限制地嵌入任何自訂字型嗎？**

您必須自行遵守字型授權條款。授權條件各有不同，某些授權禁止嵌入或商業使用。發佈輸出前，請務必檢視該字型的最終使用者授權合約 (EULA)。