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
description: "在 Aspose.Slides for Java 中套用、管理與疑難排解授權。透過我們的步驟指南，確保不間斷使用全部功能。"
---
## **概述**

Aspose.Slides 可以在評估模式或使用有效授權的情況下使用。評估版本提供與授權版本相同的功能，但在打開或保存簡報時會添加評估浮水印，且將文字提取限制為一張投影片。

本文說明 Aspose.Slides 的授權機制以及在使用程式庫之前如何套用授權。授權可以使用 `License` 類別從檔案、串流或嵌入資源載入。本文亦示範如何驗證授權是否已正確套用。

## **評估 Aspose.Slides**
{{% alert color="info" %}} 

您可以從其[下載頁面](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)下載 **Aspose.Slides for Java** 的評估版。評估版提供與產品授權版相同的功能。評估套件與購買的套件相同。只要在程式碼中加入少量程式碼（以套用授權），評估版即可變為授權版。

當您對 **Aspose.Slides** 的評估滿意後，您可以[購買授權](https://purchase.aspose.com/buy)。我們建議您了解不同的訂閱類型。如有任何問題，請聯絡 Aspose 銷售團隊。

每份 Aspose 授權皆包含一年期的訂閱，可免費升級至訂閱期間內釋出的新版本或修補程式。擁有授權產品（甚至是評估版）的使用者可獲得免費且無限制的技術支援。

{{% /alert %}} 

**評估版限制**

* 雖然 Aspose.Slides 評估版（未指定授權）提供完整的產品功能，但在開啟與儲存操作時會在文件頂部插入評估浮水印。
* 在從簡報投影片提取文字時，僅限於一張投影片。

{{% alert color="info" %}} 

若要在無限制的情況下測試 Aspose.Slides，您可以申請 **30 天臨時授權**。詳情請參閱[取得臨時授權的方法](https://purchase.aspose.com/temporary-license)頁面。

{{% /alert %}}

## **Aspose.Slides 的授權**

* 購買授權並在程式碼中加入少量程式碼（以套用授權）後，評估版即會變為授權版。
* 授權是一個純文字 XML 檔案，包含產品名稱、授權開發人員數量、訂閱到期日等資訊。
* 授權檔案經數位簽章，請勿修改檔案。即使不小心在檔案內容中加入額外的換行，也會使授權失效。
* Aspose.Slides for Java 通常會在以下位置尋找授權檔案：
  * 明確指定的路徑
  * 含有 Aspose.Slides.jar 的資料夾
* 為避免評估版的限制，您需要在使用 **Aspose.Slides** 前設定授權。每個應用程式或程序只需設定一次授權。

{{% alert color="info" %}} 

您可能想查看[計量授權](/slides/zh-hant/java/metered-licensing/)。

{{% /alert %}} 


## **套用授權**

授權可以從**檔案**或**串流**載入。

{{% alert color="info" %}}

Aspose.Slides 提供 [License](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/License) 類別以執行授權相關操作。

{{% /alert %}} 

{{% alert color="warning" %}}

新授權僅能在 21.4 版或更新的 Aspose.Slides 中啟用。較早的版本使用不同的授權系統，無法辨識這些授權。

{{% /alert %}}

### **檔案**

設定授權最簡單的方法是將授權檔案放置於含有 Aspose.Slides.jar 或您應用程式的 jar 檔的資料夾中。

以下 Java 程式碼示範如何設定授權檔案：

``` java
// 實例化 License 類別
com.aspose.slides.License license = new com.aspose.slides.License();

// 設定授權檔案路徑
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

如果將授權檔案放在其他目錄，當您呼叫 [SetLicense](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/License#setLicense-java.lang.String-) 方法時，指定的完整路徑最後的檔名必須與您的授權檔案相同。

例如，您可以將授權檔案名稱改為 *Aspose.Slides.Java.lic.xml*。接著，在程式碼中必須將指向該檔案（以 *Aspose.Slides.Java.lic.xml* 結尾）的路徑傳遞給 [SetLicense](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/License#setLicense-java.lang.String-) 方法。

{{% /alert %}}

### **串流**

您可以從串流載入授權。以下 Java 程式碼示範如何從串流套用授權：

``` java
// 實例化 License 類別
com.aspose.slides.License license = new com.aspose.slides.License();

// 設定授權（透過串流）
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

如果透過 Java 使用 Aspose.Slides for PHP，您可以透過 PHP/Java Bridge 設定授權。此橋接讓您能以 PHP 語法使用 Java 類別。更多資訊請參閱[PHP 中的授權](/slides/zh-hant/php-java/licensing/)。

## **驗證授權**

若要檢查授權是否已正確設定，您可以驗證它。以下 Java 程式碼示範如何驗證授權：

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

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/License#setLicense-java.io.InputStream-) 方法不是執行緒安全的。若此方法需同時由多個執行緒呼叫，建議使用同步原語（例如鎖）以避免問題。 

{{% /alert %}}

## **常見問題**

### 是否可以在完全離線環境（無網路連線）下套用授權？

可以。授權驗證會在本機使用授權檔案完成，無需網路連線。

### 一年期訂閱到期後會發生什麼情況？程式庫會停止運作嗎？

不會。授權為永久授權：您仍可繼續使用訂閱結束日期前發佈的版本，僅在未續訂的情況下無法使用更新的版本。