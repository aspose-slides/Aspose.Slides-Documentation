---
title: 在 PHP 中建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/php-java/create-presentation/
keywords:
- 建立簡報
- 新簡報
- 建立 PPT
- 新 PPT
- 建立 PPTX
- 新 PPTX
- 建立 ODP
- 新 ODP
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 建立簡報 — 程式化產生 PPT、PPTX 與 ODP 檔案，並可靠地儲存。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中建立簡報、在其第一張投影片上加入文字方塊，並將結果儲存為檔案。也說明如何建立並儲存空白簡報，以及如何開啟支援格式的現有簡報並將其儲存為其他格式。最後的簡短 FAQ 針對格式、範本、投影片大小、單位、記憶體使用、執行緒、授權、數位簽章與 VBA 支援等常見問題提供說明。

在開始之前，請使用 Composer 安裝 Aspose.Slides for PHP via Java，並在 Apache Tomcat 中啟動 PHP/Java Bridge。完整設定請參閱 [Installation](/slides/zh-hant/php-java/installation/)。以下範例假設 Tomcat 正在 `localhost:8080` 上執行，且 Composer 的 `vendor` 資料夾與腳本位於同一目錄。

## **建立 PowerPoint 簡報**

若要建立簡報並在其第一張投影片上放置文字方塊，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別的實例。新的簡報已預設包含一張空白投影片。
2. 透過其索引 0，從 [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) 回傳的集合中取得該投影片。
3. 使用 [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) 方法加入矩形，並以 [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/) 設定其文字。
4. 使用 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 方法將簡報儲存為 PPTX 檔案。

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh-hant/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

這兩行 `require_once` 會從 Tomcat 載入 PHP/Java Bridge 客戶端，並從 Composer 套件載入 Aspose.Slides 類別。矩形的左上角距投影片左邊緣 50 點、上邊緣 50 點，矩形寬 400 點、高 100 點。儲存的檔案包含一張含有該矩形與文字的投影片。若未授權，Aspose.Slides 亦會在每張儲存的投影片上加上評估水印；請參閱 [Licensing](/slides/zh-hant/php-java/licensing/)。

{{% alert color="info" title="Note" %}}
Aspose.Slides 於 Tomcat 內部讀寫檔案，而非在 PHP 程序中執行，因此像 `"hello.pptx"` 這類相對路徑會相對於 Tomcat 的工作目錄解析。此頁面的範例使用 `__DIR__` 建立絕對路徑，讓檔案從腳本所在目錄讀取與儲存。
{{% /alert %}}

## **建立與儲存簡報**

若要建立空白簡報並儲存它，請建立 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別的實例，並以 [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) 列舉中的任意格式儲存。結果會得到一個包含一張空白投影片的簡報。

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh-hant/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **開啟並儲存簡報**

若要將簡報從一種格式轉換為另一種格式，請將檔案路徑傳入 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 建構式以開啟，然後以目標格式儲存。Aspose.Slides 會從檔案本身偵測輸入格式（如 PPT、PPTX 或 ODP）。

以下範例假設腳本旁有一個名為 *Sample.odp* 的 OpenDocument 簡報，並將其儲存為 PPTX。

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh-hant/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

### 可以將新簡報儲存為哪些格式？

您可以儲存為 [PPTX、PPT 與 ODP](/slides/zh-hant/php-java/save-presentation/)，並匯出為 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/php-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/php-java/render-a-slide-as-an-svg-image/)，以及 [images](/slides/zh-hant/php-java/convert-powerpoint-to-png/)，等等。

### 可以從範本 (POTX/POTM) 開始，並儲存為一般的 PPTX 嗎？

可以。載入範本後儲存為所需格式；POTX、POTM、PPTM 與類似格式[受到支援](/slides/zh-hant/php-java/supported-file-formats/)。

### 建立簡報時，如何控制投影片尺寸/寬高比？

設定 [slide size](/slides/zh-hant/php-java/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

### 大小與座標以什麼單位測量？

以點為單位：1 吋等於 72 點。

### 如何處理包含大量媒體檔案的超大型簡報以降低記憶體使用量？

使用 [BLOB management strategies](/slides/zh-hant/php-java/manage-blob/)，透過暫存檔限制記憶體中的儲存，並偏好基於檔案的工作流程，而非純粹的記憶體串流。

### 可以平行建立/儲存簡報嗎？

您無法在 [multiple threads](/slides/zh-hant/php-java/multithreading/) 中同時操作同一個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)。請為每個執行緒或行程執行獨立的實例。

### 如何移除試用版水印與限制？

每個行程只需 [Apply a license](/slides/zh-hant/php-java/licensing/)。授權 XML 必須保持未修改，若有多執行緒，授權設定亦需同步。

### 我可以為建立的 PPTX 加上數位簽章嗎？

可以。[Digital signatures](/slides/zh-hant/php-java/digital-signature-in-powerpoint/)（新增與驗證）在簡報中受到支援。

### 在建立的簡報中是否支援巨集 (VBA)？

可以。您可以 [create/edit VBA projects](/slides/zh-hant/php-java/presentation-via-vba/) 並儲存支援巨集的檔案，如 PPTM/PPSM。