---
title: 授權
type: docs
weight: 80
url: /zh-hant/php-java/licensing/
keywords:
- 授權
- 臨時授權
- 設定授權
- 使用授權
- 驗證授權
- 授權檔案
- 評估版
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中套用、管理與排除授權問題。透過我們的逐步授權指南，確保不間斷使用所有完整功能。"
---
## **簡介**

有時，為了獲得最佳的評估結果，可能需要實作方式。為此，Aspose.Slides 提供不同的購買方案，並提供免費試用與 30 天臨時授權以供評估。

{{% alert color="info" title="Note" %}}
請注意，有多項一般政策與實務指引，可協助您了解如何評估、正確授權與購買我們的產品。您可在["購買政策與常見問題"](https://purchase.aspose.com/policies)部分找到相關資訊。
{{% /alert %}}

## **評估 Aspose.Slides**
您可以輕鬆下載 Aspose.Slides 進行評估。評估套件與購買套件相同。只要在程式碼中加入幾行授權設定，即可使評估版本轉為正式授權。

## **評估版限制**
Aspose.Slides 的評估版（未指定授權）提供完整產品功能，但有兩項限制：

* 它會在每個已儲存的簡報的每張投影片中間加入評估水印文字框。
* 程式從簡報讀取的文字會被截斷，只保留前幾個字元，並附加評估限制的提示。程式寫入的文字則會完整儲存。

{{% alert color="info" title="Note" %}}
如果想要在不受評估版限制的情況下測試 Aspose.Slides，您可以申請 **30 天臨時授權**。更多資訊請參考[如何取得臨時授權？](https://purchase.aspose.com/temporary-license)。
{{% /alert %}} 

## **關於授權**
您可以輕鬆從其[下載頁面](https://packagist.org/packages/aspose/slides)下載 Aspose.Slides for PHP via Java 的評估版。該評估版提供與授權版 **完全相同的功能**。此外，只要購買授權並在程式碼中加入幾行授權設定，即可使評估版轉為授權版。

授權是一個純文字 XML 檔案，內含產品名稱、授權開發人員數量、訂閱到期日等資訊。該檔案已經數位簽署，請勿修改檔案內容。即使不小心在檔案中加入額外的換行，也會使其失效。

為避免評估版的限制，您須在使用 **Aspose.Slides** 前設定授權。每個應用程式或處理序只需要設定一次授權即可。

{{% alert color="info" title="Note" %}}
您可能想要參考[Metered Licensing](/slides/zh-hant/php-java/metered-licensing/)。
{{% /alert %}} 

## **已購買授權**

購買後，您需要套用授權檔或資料流。 

{{% alert color="info" title="Note" %}}
您需要設定授權：
* 每個應用程式域僅一次
* 在使用任何其他 Aspose.Slides 類別之前
{{% /alert %}}

{{% alert color="info" title="Note" %}}
您可以在[“Pricing Information”](https://purchase.aspose.com/pricing/slides/zh-hant/family)頁面找到定價資訊。
{{% /alert %}}

### **在 Aspose.Slides for PHP via Java 中設定授權**

授權可從以下位置套用：

* 明確路徑
* 資料流
* 作為 Metered License – 一種新授權機制

{{% alert color="info" title="Note" %}}
使用 **setLicense** 方法為元件授權。

雖然多次呼叫 **setLicense** 不會造成問題，但會浪費資源（CPU）。
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
新授權只能在 21.4 版或更新的 Aspose.Slides 中啟用。早期版本使用不同的授權系統，無法識別這些授權。
{{% /alert %}}

#### **使用檔案套用授權**

此程式碼片段用於設定授權檔：

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh-hant/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

範例假設授權檔與腳本位於同一目錄，並傳入其絕對路徑：Aspose.Slides 於 Tomcat 內執行，無法以相對路徑解析腳本資料夾。呼叫 setLicense 方法時，授權檔名稱應與實際檔案名稱相同。例如，可將授權檔名稱改為 "Aspose.Slides.lic.xml"，然後在程式碼中將新名稱 (Aspose.Slides.lic.xml) 傳入 setLicense 方法。

#### **從資料流套用授權**

此程式碼片段用於從資料流套用授權：

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh-hant/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **常見問題**

### 我可以在完全離線的環境（無網路）中套用授權嗎？

可以。授權驗證在本機使用授權檔進行，無需網路連線。

### 一年訂閱到期後會發生什麼情況？函式庫會停止運作嗎？

不會。授權是永久性的：您可以繼續使用訂閱結束日前發佈的版本；若要使用更新的發行版，則需續約。