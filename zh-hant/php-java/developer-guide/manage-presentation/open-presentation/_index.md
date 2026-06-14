---
title: 在 PHP 中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/php-java/open-presentation/
keywords:
- 開啟 PowerPoint
- 開啟 OpenDocument
- 開啟 簡報
- 開啟 PPTX
- 開啟 PPT
- 開啟 ODP
- 載入 簡報
- 載入 PPTX
- 載入 PPT
- 載入 ODP
- 受保護的簡報
- 大型簡報
- 外部資源
- 二進位物件
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，輕鬆開啟 PowerPoint（.pptx、.ppt）與 OpenDocument（.odp）簡報 — 快速、可靠、功能完整。"
---
## **簡介**

除了從頭建立 PowerPoint 簡報之外，Aspose.Slides 亦支援開啟現有簡報。載入簡報後，您可以取得其資訊、編輯投影片內容、加入新投影片、移除既有投影片等操作。

## **開啟簡報**

若要開啟既有簡報，請實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別，並將檔案路徑傳入其建構函式。

```php
// 實例化 Presentation 類別，並將檔案路徑傳入其建構函式。
$presentation = new Presentation("Sample.pptx");
try {
    // 印出簡報中投影片的總數。
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **開啟受密碼保護的簡報**

當需要開啟受密碼保護的簡報時，請將密碼傳遞給 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/) 類別的 [setPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setPassword) 方法，以解密並載入簡報。以下 PHP 程式碼示範此操作：

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // 對已解密的簡報執行操作。
} finally {
    $presentation->dispose();
}
```

## **開啟大型簡報**

Aspose.Slides 提供多種選項，尤其是 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/) 類別中的 [getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) 方法，以協助載入大型簡報。

以下 PHP 程式碼示範載入大型簡報（例如 2 GB）：

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // The large presentation has been loaded and can be used, while memory consumption remains low.

    // Make changes to the presentation.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Save the presentation to another file. Memory consumption remains low during this operation.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// It is OK to do it here. The source file is no longer locked by the presentation object.
unlink($filePath);
```

{{% alert color="info" title="資訊" %}}
為了繞過在使用串流時的某些限制，Aspose.Slides 可能會複製串流的內容。從串流載入大型簡報會導致簡報被複製，從而降低載入速度。因此，當需要載入大型簡報時，我們強烈建議使用簡報檔案路徑而非串流。

在建立包含大型物件（影片、音訊、高解析度影像等）的簡報時，您可以使用 [BLOB management](/slides/zh-hant/php-java/manage-blob/) 來降低記憶體消耗。
{{%/alert %}}

## **控制外部資源**

Aspose.Slides 提供 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iresourceloadingcallback/) 介面，讓您管理外部資源。以下 PHP 程式碼示範如何使用 `IResourceLoadingCallback` 介面：

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // 載入替代影像。
            $bytes = file_get_contents("aspose-logo.jpg");
            $javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // 設定替代 URL。
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // 跳過所有其他影像。
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **載入不含嵌入二進位物件的簡報**

PowerPoint 簡報可能包含以下類型的嵌入二進位物件：

- VBA 專案（可透過 [Presentation.getVbaProject](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getVbaProject) 取得）;
- OLE 物件嵌入資料（可透過 [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 取得）;
- ActiveX 控制項二進位資料（可透過 [Control.getActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/control/#getActiveXControlBinary) 取得）。

使用 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 方法，您可以在載入簡報時移除所有嵌入的二進位物件。

此方法對於去除可能的惡意二進位內容非常有用。以下 PHP 程式碼示範如何載入不含任何嵌入二進位內容的簡報：

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // 對簡報執行操作。
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**如何判斷檔案已損壞且無法開啟？**

在載入過程中會拋出解析/格式驗證例外。此類錯誤通常會提及 ZIP 結構無效或 PowerPoint 記錄損壞。

**開啟時若缺少必要字型會發生什麼情況？**

檔案仍會開啟，但後續的 [rendering/export](/slides/zh-hant/php-java/convert-presentation/) 可能會替換字型。請在執行環境中 [Configure font substitutions](/slides/zh-hant/php-java/font-substitution/) 或 [add the required fonts](/slides/zh-hant/php-java/custom-font/)。

**開啟時嵌入的媒體（影片/音訊）會如何處理？**

它們會作為簡報資源可供使用。若媒體透過外部路徑引用，請確保這些路徑在您的環境中可存取；否則在 [rendering/export](/slides/zh-hant/php-java/convert-presentation/) 時可能會遺漏該媒體。