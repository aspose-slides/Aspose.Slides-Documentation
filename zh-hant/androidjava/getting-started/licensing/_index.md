---
title: 授權
type: docs
weight: 90
url: /zh-hant/androidjava/licensing/
keywords:
- 授權
- 臨時授權
- 設定授權
- 使用授權
- 驗證授權
- 授權檔案
- 評估版本
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android via Java 中套用、管理與排除授權問題。透過我們的授權指南，確保不間斷使用完整功能。"
---
## **概述**

Aspose.Slides 可以在評估模式或使用有效許可的情況下使用。評估版本提供與授權版本相同的功能，但在開啟或儲存簡報時會加入評估水印，且文字擷取限制為一張幻燈片。

本文說明了 Aspose.Slides 的授權運作方式，以及在使用程式庫之前如何套用授權。授權可透過 `License` 類別從檔案、串流或內嵌資源載入。本文也示範了如何驗證授權是否已正確套用。

## **評估 Aspose.Slides**

{{% alert color="info" %}} 

您可以從其[下載頁面](https://releases.aspose.com/slides/zh-hant/androidjava/)下載 **Aspose.Slides for Android via Java** 的評估版本。評估版本提供與產品授權版本相同的功能。評估套件與購買的套件相同。只要在程式碼中加入幾行以套用授權，評估版本即會變為授權版。

在您對 **Aspose.Slides** 的評估滿意後，您可以[購買授權](https://purchase.aspose.com/buy)。我們建議您了解不同的訂閱類型。如有任何問題，請聯絡 Aspose 銷售團隊。

每一份 Aspose 授權皆附帶一年期訂閱，可免費升級至該訂閱期間內發布的新版本或修補程式。擁有授權產品（甚至是評估版本）的使用者皆可獲得免費且無限制的技術支援。

{{% /alert %}} 

**評估版本限制**

* 雖然 Aspose.Slides 評估版本（未指定授權）提供完整功能，但在開啟與儲存文件時會在文件頂部插入評估水印。 
* 從簡報幻燈片擷取文字時僅限於一張幻燈片。

{{% alert color="info" %}} 

若要在不受限制的情況下測試 Aspose.Slides，您可以申請**30 天臨時授權**。詳情請參閱[如何取得臨時授權](https://purchase.aspose.com/temporary-license)頁面。

{{% /alert %}}

## **Aspose.Slides 的授權**

* 評估版本在您購買授權並加入幾行程式碼以套用授權後，即會變為授權版。
* 授權是一個純文字 XML 檔案，內含產品名稱、授權開發人員人數、訂閱到期日等資訊。 
* 授權檔案已經數位簽名，請勿修改檔案。即使是無意間在內容中加入額外的換行，也會使授權失效。
* Aspose.Slides for Android via Java 通常會在以下位置尋找授權：
  * 明確指定的路徑
  * 含有 Aspose.Slides.jar 的資料夾
* 為避免評估版本的限制，您必須在使用 **Aspose.Slides** 前先設定授權。每個應用程式或處理序只需設定一次授權。

## **套用授權**

授權可以從 **檔案** 或 **串流** 載入。

{{% alert color="info" %}}

Aspose.Slides 提供[License](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/license/)類別供授權相關操作使用。

{{% /alert %}} 

{{% alert color="warning" %}}

新授權只能在 21.4 版或更新的 Aspose.Slides 中啟用。較舊版本使用不同的授權系統，無法識別這些授權。

{{% /alert %}}

### **檔案**

設定授權最簡單的方法是將授權檔案放置於含有 Aspose.Slides.jar 或您應用程式 jar 的資料夾中。

此 Java 程式碼示範如何設定授權檔案：

``` java
// 實例化 License 類別
com.aspose.slides.License license = new com.aspose.slides.License();

// 設定授權檔案路徑
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

如果將授權檔案放在其他目錄，當您呼叫[SetLicense](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)方法時，指定的明確路徑最後的檔案名稱必須與您的授權檔案名稱相同。

例如，您可以將授權檔案名稱改為*Aspose.Slides.Android.via.Java.lic.xml*。接著在程式碼中，必須將指向該檔案（結尾為*Aspose.Slides.Android.via.Java.lic.xml*）的路徑傳遞給[SetLicense](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)方法。

{{% /alert %}}

### **串流**

您可以從串流載入授權。以下 Java 程式碼示範如何從串流套用授權：

``` java
// 實例化 License 類別
com.aspose.slides.License license = new com.aspose.slides.License();

// 透過串流設定授權
license.setLicense(new java.io.FileInputStream("AspNet.Slides.Android.via.Java.lic"));
```

## **驗證授權**

若要檢查授權是否正確設定，您可以進行驗證。以下 Java 程式碼示範如何驗證授權：

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **執行緒安全性**

{{% alert title="注意" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 方法並非執行緒安全。如果必須在多個執行緒同時呼叫此方法，建議使用同步原語（例如鎖）以避免問題。 

{{% /alert %}}

## **常見問題**

### 我可以在完全離線的環境（無網際網路連線）下套用授權嗎？

可以。授權驗證是在本機使用授權檔案完成，無需網際網路連線。

### 當一年期訂閱到期後會發生什麼事？程式庫會停止運作嗎？

不會。授權為永久性：您仍可繼續使用訂閱結束日前發布的版本；但若未續訂，將無法使用更新的版本。