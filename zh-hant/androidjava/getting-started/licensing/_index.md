---
title: 授權
type: docs
weight: 90
url: /zh-hant/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android via Java 中套用、管理與排除授權問題。透過我們的授權指南，確保不間斷使用完整功能。"
---
## **概觀**

Aspose.Slides 可以在評估模式或使用有效授權的情況下使用。評估版本提供與授權版本相同的功能，但在開啟或儲存簡報時會加入評估浮水印，且文字擷取僅限於一張投影片。

本文說明 Aspose.Slides 的授權運作方式以及在使用函式庫前如何套用授權。授權可以透過 `License` 類別從檔案、串流或嵌入式資源載入。本文亦示範如何驗證授權是否正確套用。

## **評估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以從其 [下載頁面](https://releases.aspose.com/slides/zh-hant/androidjava/) 下載 **Aspose.Slides for Android via Java** 的評估版本。評估版本提供與產品授權版相同的功能。評估套件與購買套件相同。只要在程式中加入幾行程式碼（套用授權），評估版本即可變為授權版。

在您對 **Aspose.Slides** 的評估滿意後，即可 [購買授權](https://purchase.aspose.com/buy)。我們建議您了解不同的訂閱類型。如有任何問題，請聯絡 Aspose 銷售團隊。

每一份 Aspose 授權均包含一年免費升級期限，可升級至訂閱期間內發布的新版或修正程式。持有授權產品（甚至評估版）的使用者可獲得免費且無限制的技術支援。

{{% /alert %}} 

**評估版本限制**

* 雖然 Aspose.Slides 評估版本（未指定授權）提供完整的產品功能，但在開啟與儲存操作時會在文件頂部插入評估浮水印。  
* 從簡報投影片擷取文字時僅限於一張投影片。

{{% alert color="primary" %}} 

若要在不受限制的情況下測試 Aspose.Slides，您可以申請 **30-Day Temporary License**。請參閱 [How to get a Temporary License](https://purchase.aspose.com/temporary-license) 頁面取得更多資訊。

{{% /alert %}}

## **Aspose.Slides 授權**

* 評估版本在您購買授權並在程式碼中加入幾行以套用授權後，即會變為授權版。  
* 授權是一個純文字 XML 檔案，內含產品名稱、授權開發人員數量、訂閱到期日等資訊。  
* 授權檔案經數位簽章保護，切勿修改檔案內容。即使不小心新增一個換行，也會使授權失效。  
* Aspose.Slides for Android via Java 通常會在以下位置尋找授權檔案：  
  * 明確指定的路徑  
  * 含有 Aspose.Slides.jar 的資料夾  
* 為避免評估版本的限制，必須在使用 **Aspose.Slides** 前先設定授權。每個應用程式或執行序只需設定一次授權。

## **套用授權**

授權可以從 **檔案** 或 **串流** 載入。

{{% alert color="primary" %}}

Aspose.Slides 提供 [License](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/license/) 類別以執行授權操作。

{{% /alert %}} 

{{% alert color="warning" %}}

新授權僅能在 21.4 版或更新的 Aspose.Slides 中啟用。較早的版本使用不同的授權系統，無法辨識這些授權。

{{% /alert %}}

### **檔案**

設定授權的最簡方法是將授權檔案放置在包含 Aspose.Slides.jar 或您應用程式 jar 的資料夾中。

以下 Java 程式碼示範如何設定授權檔案：

``` java
// 建立 License 類別的實例
com.aspose.slides.License license = new com.aspose.slides.License();

// 設定授權檔案路徑
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

如果將授權檔案放在其他目錄，當呼叫 [SetLicense](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 方法時，指定的明確路徑最後的檔案名稱必須與您的授權檔案相同。

例如，您可以將授權檔案名稱更改為 *Aspose.Slides.Android.via.Java.lic.xml*。接著，在程式碼中必須將路徑（以 *Aspose.Slides.Android.via.Java.lic.xml* 結尾）傳遞給 [SetLicense](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 方法。

{{% /alert %}}

### **串流**

您可以從串流載入授權。以下 Java 程式碼示範如何從串流套用授權：

``` java
// 建立 License 類別的實例
com.aspose.slides.License license = new com.aspose.slides.License();

// 透過串流設定授權
license.setLicense(new java.io.FileInputStream("Aspise.Slides.Android.via.Java.lic"));
```

## **驗證授權**

若要檢查授權是否正確設定，可進行驗證。以下 Java 程式碼示範如何驗證授權：

```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **執行緒安全性**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 方法不是執行緒安全的。若需同時從多個執行緒呼叫此方法，建議使用同步機制（如鎖）以避免問題。

{{% /alert %}}

## **常見問題**

**我可以在完全離線的環境（無網路存取）中套用授權嗎？**

可以。授權驗證完全在本機使用授權檔案執行，無需網際網路連線。

**一年訂閱到期後會發生什麼事？函式庫會停止運作嗎？**

不會。授權為永久授權：您仍可繼續使用訂閱結束日期之前發布的版本；但若未續約，將無法使用更新的版本。