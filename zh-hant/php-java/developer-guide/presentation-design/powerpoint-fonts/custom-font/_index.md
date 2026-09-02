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
description: "使用 Aspose.Slides for PHP 透過 Java 在 PowerPoint 投影片中自訂字型，確保您的簡報在任何裝置上保持清晰且一致。"
---
## **概觀**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型、透過文件層級的字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

載入的字型會在簡報渲染或匯出（例如 PDF、影像以及其他支援的格式）時使用，確保在不同環境下的輸出保持一致。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

註冊自訂字型以供渲染與將字型嵌入 PPTX 檔案是兩件不同的事。若必須將字型儲存在簡報本身，請明確使用字型嵌入功能。

簡報主題可以為各種書寫系統參照不同的字型家族。這些對映僅儲存字型名稱，並不會安裝或載入字型檔案。請參閱[Script‑Specific Theme Fonts](/slides/zh-hant/php-java/script-specific-font-mappings/) 以管理對映，並使用以下載入選項讓參照的字型可用於一致的渲染。

{{% alert color="info" title="注意" %}}

Aspose Slides 允許您使用 [loadExternalFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法載入以下字型：

* TrueType（.ttf）與 TrueType Collection（.ttc）字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在簡報中載入使用的字型，而不必在系統上安裝它們。這會影響匯出結果——如 PDF、影像及其他支援格式——讓產出的文件在不同環境中保持一致。字型會從自訂目錄載入。

1. 指定一個或多個包含字型檔案的資料夾。
2. 呼叫靜態 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法，從這些資料夾載入字型。
3. 載入並渲染/匯出簡報。
4. 呼叫 [FontsLoader::clearCache](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#clearCache--) 清除字型快取。

以下程式碼範例說明字型載入流程：

```php
// 定義包含自訂字型檔案的資料夾。
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Load custom fonts from the specified folders.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // 使用載入的字型渲染/匯出簡報（例如 PDF、影像或其他格式）。
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // 工作完成後清除字型快取。
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="注意" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 會將額外的資料夾加入字型搜尋路徑，但不會變更字型初始化順序。  
字型的初始化順序如下：

1. 作業系統的預設字型路徑。  
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/) 載入的路徑。

{{%/alert %}}

## **取得自訂字型資料夾**
Aspose.Slides 提供 [getFontFolders](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#getFontFolders--) 方法，讓您取得字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

以下 PHP 程式碼示範如何使用 [getFontFolders](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#getFontFolders--)：

```php
# 此行會輸出搜尋字型檔案的資料夾。
# 這些資料夾是透過 LoadExternalFonts 方法加入的以及系統字型資料夾。
$fontFolders = FontsLoader::getFontFolders();
```

## **指定簡報使用的自訂字型**
Aspose.Slides 提供 [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 方法，讓您指定將與簡報一起使用的外部字型。

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
    # 處理簡報
    # CustomFont1、CustomFont2 以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字型均可供簡報使用
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **外部管理字型**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，允許您從二進位資料載入外部字型。

以下 PHP 程式碼示範以位元組陣列載入字型的流程：

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
        # 簡報生命週期內已載入外部字型
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **常見問題集**

### 自訂字型會影響所有格式 (PDF、PNG、SVG、HTML) 的匯出嗎？

會。已連結的字型會在渲染器中使用於所有匯出格式。

### 自訂字型會自動嵌入產生的 PPTX 檔案嗎？

不會。為渲染註冊字型與將字型嵌入 PPTX 並非同一件事。若需要將字型隨簡報檔案一起保存，必須使用明確的[嵌入功能](/slides/zh-hant/php-java/embedded-font/)。

### 當自訂字型缺少某些字形時，我可以控制回退行為嗎？

可以。請設定[字型取代](/slides/zh-hant/php-java/font-substitution/)、[取代規則](/slides/zh-hant/php-java/font-replacement/)以及[回退集合](/slides/zh-hant/php-java/fallback-font/)，以明確定義在請求字形缺失時使用哪一個字型。

### 我能在 Linux/Docker 容器中使用字型而不必全系統安裝嗎？

可以。只要指向自己的字型資料夾或從位元組陣列載入字型，即可避免依賴容器映像中的系統字型目錄。

### 有關授權——我可以在沒有限制的情況下嵌入任何自訂字型嗎？

字型授權遵循使用者自行負責。授權條款各異，有些授權禁止嵌入或商業使用。發布輸出前，務必先確認字型的最終使用者授權協議 (EULA)。