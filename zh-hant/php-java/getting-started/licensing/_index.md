---
title: 授權
type: docs
weight: 80
url: /zh-hant/php-java/licensing/
keywords:
- 授權
- 暫時授權
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
description: "在 Aspose.Slides for PHP via Java 中套用、管理與除錯授權。透過我們的分步授權指南，確保不間斷取得完整功能。"
---
## **簡介**

有時為了取得最佳的評估結果，可能需要親自操作。基於此原因，Aspose.Slides 提供不同的購買方案，並提供免費試用以及 30 天暫時授權以供評估。

{{% alert color="primary" %}}
請注意，有多項一般政策與慣例可指導您如何評估、正確授權以及購買本公司的產品。您可以在 [「購買政策與常見問題」](https://purchase.aspose.com/policies) 章節中找到它們。
{{% /alert %}}

## **評估 Aspose.Slides**
您可以輕鬆下載 Aspose.Slides 進行評估。評估套件與購買套件相同。只要在程式碼中加入幾行以套用授權，評估版本即會變為授權版本。

## **評估版限制**
Aspose.Slides 的評估版（未指定授權）提供完整的產品功能，但在開啟與儲存文件時會在文件頂部插入評估水印。從簡報投影片中擷取文字時也僅限於單一投影片。

{{% alert color="primary" %}}
如果您想在不受評估版限制的情況下測試 Aspose.Slides，您可以申請 **30 天暫時授權**。請參閱 [如何取得暫時授權？](https://purchase.aspose.com/temporary-license) 了解更多資訊。
{{% /alert %}}

## **關於授權**
您可以透過 Java 從其 [下載頁面](https://packagist.org/packages/aspose/slides) 輕鬆下載 Aspose.Slides for PHP 的評估版。評估版提供與授權版 **完全相同的功能**。此外，只要您購買授權並加入幾行程式碼以套用授權，評估版即會轉為授權版。

授權是一個純文字 XML 檔案，內含產品名稱、授權給多少開發人員、訂閱到期日等資訊。該檔案具數位簽章，請勿修改檔案內容。即使不小心在檔案內容中加入額外的換行，也會使其失效。

為避免評估版的限制，您需要在使用 **Aspose.Slides** 前先設定授權。每個應用程式或處理程序只需設定一次授權即可。

{{% alert color="primary" %}}
您可能想參考 [計量授權](https://docs.aspose.com/slides/zh-hant/php-java/metered-licensing/)。
{{% /alert %}}

## **已購買授權**

購買後，您需要套用授權檔案或資料流。

{{% alert color="primary" %}}
您需要設定授權：
* 每個應用程式域僅一次
* 在使用任何其他 Aspose.Slides 類別之前
{{% /alert %}}

{{% alert color="primary" %}}
您可於 [「定價資訊」](https://purchase.aspose.com/pricing/slides/zh-hant/family) 頁面查詢價格資訊。
{{% /alert %}}

### **在 Aspose.Slides for PHP via Java 中設定授權**

授權可從以下位置套用：

* 明確路徑
* 資料流
* 作為計量授權 – 一種全新授權機制

{{% alert color="primary" %}}
使用 **setLicense** 方法為元件授權。

雖然多次呼叫 **setLicense** 不會造成傷害，但會浪費資源（處理器）。
{{% /alert %}}

{{% alert color="warning" %}}
新授權只能在 21.4 版或更新版本中啟用 Aspose.Slides。較舊版本使用不同的授權機制，無法辨識這些授權。
{{% /alert %}}

#### **使用檔案套用授權**

此程式碼片段用於設定授權檔案：

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

呼叫 setLicense 方法時，授權名稱應與授權檔案名稱相同。例如，您可以將授權檔案名稱更改為「Aspose.Slides.lic.xml」。之後，在程式碼中必須將新的授權名稱 (Aspose.Slides.lic.xml) 傳遞給 setLicense 方法。

#### **從資料流套用授權**

此程式碼片段用於從資料流套用授權：

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **常見問題**

**我可以在完全離線環境（無網際網路連線）中套用授權嗎？**

可以。授權驗證在本機使用授權檔案完成，無需網際網路連線。

**一年訂閱到期後會發生什麼事？函式庫會停止運作嗎？**

不會。此授權為永久授權：您仍可繼續使用訂閱結束日前發佈的版本，只是若未續約，將無法使用更新的版本。