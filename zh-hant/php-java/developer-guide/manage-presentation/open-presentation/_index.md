---
title: 在 PHP 中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/php-java/open-presentation/
keywords:
- 開啟 PowerPoint
- 開啟簡報
- 開啟 PPTX
- 開啟 PPT
- 開啟 ODP
- 載入簡報
- 載入 PPTX
- 載入 PPT
- 載入 ODP
- 受保護的簡報
- 大型簡報
- 外部資源
- 二進位物件
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中開啟 PowerPoint 與 OpenDocument 簡報、提供開啟密碼、控制資源載入，並使用 Aspose.Slides for PHP via Java 減少記憶體使用。"
---
## **簡介**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/zh-hant/php-java/) 可以從檔案和串流載入 PowerPoint 和 OpenDocument 簡報。載入簡報後，您可以檢查其結構、編輯投影片、管理資源，並以原始或其他支援的格式儲存它。

可透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/) 類別自訂載入行為。例如，您可以提供開啟密碼、將大型二進位物件保留在 Java 堆之外、控制外部資源，或省略嵌入的二進位資料。

## **開啟簡報**

要開啟現有簡報，將其檔案路徑傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 建構函式。使用完畢後請釋放簡報，以便立即釋放檔案句柄、暫存資料和其他資源。

以下 PHP 範例示範如何開啟簡報並取得投影片數量：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **開啟受密碼保護的簡報**

開啟密碼會加密簡報內容。若要載入完整簡報，請將正確的密碼傳遞給 [LoadOptions::setPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setPassword) 並將選項提供給 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 建構函式。若密碼缺失或不正確，載入將失敗。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

有關密碼偵測、驗證與加密工作流程，請參閱 [Password-Protect Presentations](/slides/zh-hant/php-java/password-protected-presentation/)。如果已加密的簡報特意以公開文件屬性儲存，則可在未提供密碼的情況下讀取這些屬性；請參閱 [Manage Presentation Properties](/slides/zh-hant/php-java/presentation-properties/)。

## **開啟大型簡報**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) 會傳回控制 Aspose.Slides 如何處理二進位大型物件（如影像、音訊與視訊）的選項。您可以保持來源檔案鎖定、允許暫存檔案，並限制保留在記憶體中的 BLOB 資料量。

以下 PHP 程式碼示範載入大型簡報（例如 2 GB）：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="注意" %}}
使用 [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) 時，來源檔案會保持鎖定，直至釋放簡報實例為止。請勿在該實例存活期間移動、覆寫或刪除來源檔案。

Aspose.Slides 在載入時可能會複製輸入串流的內容。對於大型簡報而言，檔案路徑通常比串流更有效率。請參閱 [Manage BLOBs](/slides/zh-hant/php-java/manage-blob/)，以取得其他儲存與記憶體管理選項。
{{% /alert %}}

## **控制外部資源**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) 透過 PHP/Java Bridge 接受 Java [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iresourceloadingcallback/) 介面的實作。回呼可以提供替代資料、重新導向資源、使用預設載入器，或跳過資源。當簡報含有必須依照應用程式特定安全性或儲存規則解析的外部影像時，此功能相當有用。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **載入不含嵌入二進位物件的簡報**

簡報可能包含應用程式不需要或不想保留的嵌入二進位資料。範例包括：

- VBA 專案，可透過 [Presentation::getVbaProject](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getVbaProject) 取得；
- 嵌入的 OLE 資料，可透過 [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 取得；
- ActiveX 控制項資料，可透過 [Control::getActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/control/#getActiveXControlBinary) 取得。

將 [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 設為 `true`，即可在載入時移除這些二進位資料。將載入的簡報儲存以保留清理後的結果。

此選項可減少不必要的嵌入負載暴露風險，但並非完整的惡意程式偵測或內容清理系統。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**如何判斷檔案已損毀且無法開啟？**

Aspose.Slides 在載入期間會拋出解析或格式例外。請將此失敗與密碼錯誤的例外分別處理，以便應用程式能準確回報原因。

**如果缺少必需的字型會發生什麼情況？**

簡報仍可載入，但在渲染與匯出時可能會使用替代字型。您可以 [設定字型替代](/slides/zh-hant/php-java/font-substitution/) 或 [提供自訂字型](/slides/zh-hant/php-java/custom-font/) 以使輸出更可預測。

**載入簡報時是否也會載入其嵌入的媒體？**

嵌入的音訊與視訊可透過簡報物件模型取得。外部資源會依照已設定的資源載入行為進行解析，若無法存取其位置，則可能無法取得。