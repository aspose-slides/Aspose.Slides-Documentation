---
title: 授權
type: docs
weight: 90
url: /zh-hant/java/licensing/
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中套用、管理與除錯授權。透過我們的分步授權指南，確保不間斷存取完整功能。"
---
## **概觀**

Aspose.Slides 可以在評估模式或使用有效授權的情況下使用。評估版本提供與授權版本相同的功能，但會在每個保存的簡報的每一張投影片上添加評估浮水印，並截斷您透過 API 讀取的文字。

本文說明 Aspose.Slides 中的授權機制，以及如何在使用函式庫之前套用授權。授權可以透過 `License` 類別從檔案、串流或嵌入資源載入。本文亦示範如何驗證授權是否正確套用。

## **評估 Aspose.Slides**

{{% alert color="info" title="Note" %}}
您可以從其[下載頁面](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)下載 **Aspose.Slides for Java** 的評估版。評估版提供與授權版相同的功能。評估套件與購買的套件相同，只要在程式碼中加入幾行以套用授權，即可將評估版轉為授權版。

當您對 **Aspose.Slides** 的評估滿意後，即可[購買授權](https://purchase.aspose.com/pricing/slides/zh-hant/java/)。我們建議您瀏覽不同的訂閱類型。如有任何問題，請聯絡 Aspose 銷售團隊。

每份 Aspose 授權皆包含一年免費升級訂閱，期間可取得新版本或修正程式。持有授權產品（甚至是評估版）的使用者皆可獲得免費且無限制的技術支援。
{{% /alert %}} 

**評估版限制**

* 未指定授權的評估版提供完整的產品功能，但會在每個保存的簡報的每一張投影片上添加評估浮水印文字方塊。
* 您透過 API 讀取的文字（包括剛剛設定的文字）會被截斷為前幾個字元，並附上評估限制的說明。您寫入的文字則會完整保存。

{{% alert color="info" title="Note" %}}
若要在無限制的環境下測試 Aspose.Slides，您可以申請**30 天臨時授權**。詳情請參閱[如何取得臨時授權](https://purchase.aspose.com/temporary-license)頁面。
{{% /alert %}}

## **Aspose.Slides 的授權方式**

* 評估版在您購買授權並加入幾行程式碼以套用授權後即會變為授權版。
* 授權是一個純文字 XML 檔案，內含產品名稱、授權開發人員數量、訂閱到期日等資訊。
* 授權檔案已數位簽章，請勿自行修改。即使是額外新增一行換行亦會使授權失效。
* Aspose.Slides for Java 通常會在以下位置尋找授權：
  * 明確指定的路徑
  * Aspose.Slides.jar 所在的資料夾
* 為避免評估版的限制，您必須在使用 **Aspose.Slides** 前先設定授權。每個應用程式或處理序只需設定一次授權。

{{% alert color="info" title="Note" %}}
您可能想查看[計量授權](/slides/zh-hant/java/metered-licensing/)。
{{% /alert %}} 

## **套用授權**

授權可以從**檔案**或**串流**載入。

{{% alert color="info" title="Note" %}}
Aspose.Slides 提供[License](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/license/) 類別以執行授權相關操作。
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
新授權只能在 21.4 版或更新版本的 Aspose.Slides 中啟用。較早的版本使用不同的授權系統，無法識別此類授權。
{{% /alert %}}

### **檔案**

設定授權的最簡方式是將授權檔案放在 Aspose.Slides.jar 所在的資料夾或您的應用程式 jar 所在的資料夾中。

以下 Java 程式碼示範如何設定授權檔案：

``` java
// 實例化 License 類別
com.aspose.slides.License license = new com.aspose.slides.License();

// 設定授權檔案路徑
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
如果您將授權檔案放在其他目錄，呼叫[setLicense](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/license/#setLicense-java.lang.String-) 方法時，指定路徑最後的檔名必須與實際授權檔案名稱相同。

例如，您可以將授權檔案名稱改為 *Aspose.Slides.Java.lic.xml*。此時在程式碼中必須將完整路徑（以 *Aspose.Slides.Java.lic.xml* 結尾）傳遞給[setLicense](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/license/#setLicense-java.lang.String-) 方法。
{{% /alert %}}

### **串流**

您也可以從串流載入授權。以下 Java 程式碼示範如何從串流套用授權：

``` java
// 實例化 License 類別
com.aspose.slides.License license = new com.aspose.slides.License();

// 透過串流設定授權
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

如果您透過 Java 使用 Aspose.Slides for PHP，可以透過 PHP/Java 橋接設定授權。此橋接允許您在 PHP 語法中使用 Java 類別。更多資訊請參考[PHP 中的授權](/slides/zh-hant/php-java/licensing/)。

## **驗證授權**

要檢查授權是否正確設定，您可以進行驗證。以下 Java 程式碼示範如何驗證授權：

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **執行緒安全性**

{{% alert color="warning" title="Warning" %}}
[setLicense](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) 方法不是執行緒安全的。如果需要同時由多個執行緒呼叫，建議使用同步機制（例如 lock）以避免問題。
{{% /alert %}}

## **常見問題**

### 我可以在完全離線的環境（無網路）中套用授權嗎？

可以。授權驗證完全在本機使用授權檔案完成，無需網路連線。

### 一年訂閱到期後會發生什麼情況？函式庫會停止運作嗎？

不會。授權為永久授權：您仍可繼續使用訂閱結束日前發布的版本，只是無法在未續訂的情況下使用更新的版本。