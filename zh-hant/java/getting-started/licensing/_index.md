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
description: "在 Aspose.Slides for Java 中套用、管理與疑難排解授權。透過我們的步驟式授權指南，確保不間斷使用完整功能。"
---
## **概述**

Aspose.Slides 可以在評估模式或使用有效授權下使用。評估版本提供與授權版本相同的功能，但在開啟或儲存簡報時會加入評估水印，且文字擷取僅限於單一投影片。

本文說明 Aspose.Slides 的授權機制以及在使用函式庫之前如何套用授權。授權可透過 `License` 類別從檔案、串流或嵌入式資源載入。本文亦示範如何驗證授權是否正確套用。

## **評估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以從其[下載頁面](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)下載 **Aspose.Slides for Java** 的評估版。評估版提供與產品授權版相同的功能。評估套件與購買的套件相同。只要在程式碼中加入少許程式碼（以套用授權），評估版即可變為授權版。

當您對 **Aspose.Slides** 的評估滿意後，即可[購買授權](https://purchase.aspose.com/buy)。我們建議您了解不同的訂閱類型。如有任何問題，請聯絡 Aspose 銷售團隊。

每份 Aspose 授權均附帶一年訂閱，可免費升級至訂閱期間內發布的新版或修補程式。擁有授權產品（甚至是評估版）的使用者皆可獲得免費且無限制的技術支援。

{{% /alert %}} 

**評估版限制**

* 雖然未指定授權的 Aspose.Slides 評估版提供完整的產品功能，但在開啟或儲存文件時會在文件頂部插入評估水印。 
* 在從簡報投影片擷取文字時，僅限於單一投影片。

{{% alert color="primary" %}} 

若要在不受限制的情況下測試 Aspose.Slides，您可申請 **30 天臨時授權**。更多資訊請參閱[如何取得臨時授權](https://purchase.aspose.com/temporary-license)頁面。

{{% /alert %}}

## **Aspose.Slides 授權**

* 評估版在您購買授權並加入少量程式碼（以套用授權）後，即轉為授權版。 
* 授權是一個純文字 XML 檔案，內含產品名稱、授權開發人員數量、訂閱到期日等資訊。 
* 授權檔案已經數位簽署，禁止任何修改。即使是不小心在檔案內容添加額外的換行符號，也會使其失效。 
* Aspose.Slides for Java 通常會在以下位置尋找授權檔案：
  * 明確指定的路徑
  * 包含 Aspose.Slides.jar 的資料夾
* 為避免評估版的限制，您必須在使用 **Aspose.Slides** 前設定授權。每個應用程式或處理序只需設定一次授權。

{{% alert color="primary" %}} 

您可能想了解[計量授權](/slides/zh-hant/java/metered-licensing/)。

{{% /alert %}} 

## **套用授權**

授權可從 **檔案** 或 **串流** 載入。

{{% alert color="primary" %}}

Aspose.Slides 提供 [License](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/License) 類別以進行授權操作。

{{% /alert %}} 

{{% alert color="warning" %}}

新授權僅能在 21.4 版或更新版本的 Aspose.Slides 中啟用。較早版本使用不同的授權系統，無法辨識此類授權。

{{% /alert %}}

### **File**

設定授權最簡單的方法是將授權檔案放置於包含 Aspose.Slides.jar 或您應用程式的 jar 的資料夾中。

以下 Java 程式碼示範如何設定授權檔案：

``` java
// 實例化 License 類別
com.aspose.slides.License license = new com.aspose.slides.License();

// 設定授權檔案路徑
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

如果將授權檔案放在其他目錄，呼叫 [SetLicense](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/License#setLicense-java.lang.String-) 方法時，指定的明確路徑最後的檔名必須與授權檔案相同。

例如，您可以將授權檔案名稱改為 *Aspose.Slides.Java.lic.xml*。如此一來，在程式碼中必須將指向該檔案（結尾為 *Aspose.Slides.Java.lic.xml*）的路徑傳遞給 [SetLicense](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/License#setLicense-java.lang.String-) 方法。

{{% /alert %}}

### **Stream**

您可以從串流載入授權。以下 Java 程式碼示範如何從串流套用授權：

``` java
// 實例化 License 類別
com.aspose.slides.License license = new com.aspose.slides.License();

// 透過串流設定授權
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

如果您透過 Java 使用 Aspose.Slides for PHP，可以透過 PHP/Java 橋接設定授權。此橋接可讓您以 PHP 語法使用 Java 類別。欲了解更多資訊，請參閱[PHP 中的授權](/slides/zh-hant/php-java/licensing/)。

## **Validating a License**

若要檢查授權是否正確設定，可進行驗證。以下 Java 程式碼示範如何驗證授權：

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/License#setLicense-java.io.InputStream-) 方法不是執行緒安全的。如果必須同時由多個執行緒呼叫此方法，建議使用同步原語（例如 lock）以避免問題。 

{{% /alert %}}

## **常見問題**

**我能在完全離線的環境（無網際網路存取）中套用授權嗎？**

是的。授權驗證在本機使用授權檔案完成，無需網路連線。

**一年訂閱到期後會怎樣？函式庫會停止運作嗎？**

不會。授權為永久性：您仍可使用訂閱結束日前發布的版本，只是若未續約，將無法使用更新的發行版。