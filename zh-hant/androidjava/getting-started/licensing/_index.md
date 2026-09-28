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
- 評估版
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android via Java 中套用、管理與排除授權問題。透過我們的授權指南，確保持續不間斷地使用全部功能。"
---
## **概觀**

Aspose.Slides 可以在評估模式或使用有效許可證的情況下使用。評估版提供與授權版相同的功能，但會在每個儲存的簡報的每張投影片上添加評估水印，並截斷程式碼從簡報中讀取的文字。

此文章說明了 Aspose.Slides 的授權機制以及在使用函式庫之前如何套用授權。授權可透過 [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) 類別從檔案、串流或內嵌資源載入。文章亦示範如何驗證授權是否正確套用。

## **評估 Aspose.Slides**

{{% alert color="info" title="注意" %}}
您可以從其[下載頁面](https://releases.aspose.com/slides/androidjava/)下載 **Aspose.Slides for Android via Java** 的評估版本。評估版提供與產品授權版相同的功能。評估套件與購買的套件相同。只要在程式碼中加入幾行程式以套用授權，評估版即可變為授權版。

當您對 **Aspose.Slides** 的評估滿意後，即可[購買授權](https://purchase.aspose.com/pricing/slides/android-java/)。我們建議您了解不同的訂閱類型。如有任何疑問，請聯絡 Aspose 銷售團隊。

每個 Aspose 授權均包含一年免費升級訂閱，可於訂閱期間內取得新版本或修補程式。持有授權產品（甚至是評估版本）的使用者皆可免費且無限制取得技術支援。
{{% /alert %}} 

**評估版限制**

* 評估版（未指定授權）提供完整的產品功能，但會在每個儲存的簡報的每張投影片上添加評估水印文字方塊。
* 程式碼從簡報中讀取的文字會被截斷為前幾個字元，並附帶評估限制的說明；程式碼寫入的文字則會完整保存。

{{% alert color="info" title="注意" %}}
若要在無限制的情況下測試 Aspose.Slides，您可以申請 **30 天臨時授權**。請參閱[如何取得臨時授權](https://purchase.aspose.com/temporary-license)頁面以取得更多資訊。
{{% /alert %}}

## **Aspose.Slides 的授權**

* 購買授權並在程式碼中加入幾行以套用授權後，評估版即可變為授權版。
* 授權是一個純文字 XML 檔案，內含產品名稱、授權的開發人員數量、訂閱到期日等資訊。
* 授權檔案已數位簽署，請勿修改檔案內容。即使不小心在檔案內容中加入額外的換行，也會使授權失效。
* Aspose.Slides for Android via Java 通常會在以下位置尋找授權：
  * 明確指定的路徑
  * 含有 Aspose.Slides.jar 的資料夾
* 為避免評估版的限制，您必須在使用 **Aspose.Slides** 前先設定授權。每個應用程式或執行序只需設定一次授權。

## **套用授權**

授權可以從 **檔案** 或 **串流** 載入。

{{% alert color="info" title="注意" %}}
Aspose.Slides 提供 [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) 類別供授權相關操作使用。
{{% /alert %}} 

{{% alert color="warning" title="警告" %}}
新授權僅能在 21.4 版或更新版本的 Aspose.Slides 中啟用。較早的版本使用不同的授權系統，無法辨識這些授權。
{{% /alert %}}

### **檔案**

設定授權的最簡方法是將授權檔案放在含有 Aspose.Slides.jar 的資料夾或您應用程式的 jar 中。

{{% alert color="info" title="注意" %}}
在 Android 上，函式庫與您的應用程式會被打包成 APK，沒有實體資料夾可以放置函式庫的 JAR 檔，類似 *Aspose.Slides.Android.via.Java.lic* 的相對路徑也不會指向您應用程式中的檔案。請將授權檔案加入應用程式的 assets，然後如 [從 App 資產串流](#stream-from-app-assets) 所示從串流載入。
{{% /alert %}}

以下 Java 程式碼示範如何設定授權檔案：

``` java
// 實例化 License 類別
com.aspose.slides.License license = new com.aspose.slides.License();

// 設定授權檔案路徑
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="警告" %}}
若將授權檔案放在不同目錄，呼叫 [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 方法時，指定路徑最後的檔案名稱必須與您的授權檔案名稱相同。

例如，您可以將授權檔案名稱改為 *Aspose.Slides.Android.via.Java.lic.xml*。此時在程式碼中必須傳入以 *Aspose.Slides.Android.via.Java.lic.xml* 結尾的完整路徑給 [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 方法。
{{% /alert %}}

### **串流**

您可以從串流載入授權。以下 Java 程式碼示範如何從串流套用授權：

``` java
// 實例化 License 類別
com.aspose.slides.License license = new com.aspose.slides.License();

// 透過串流設定授權
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **從 App 資產串流**

在 Android 應用程式中，將授權檔案放入 *app/src/main/assets* 資料夾（即 *assets* 資料夾），使其隨 APK 打包。使用 [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) 方法開啟檔案，並將串流傳遞給 [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 方法。以下程式碼在 `Activity` 內執行，例如在其 `onCreate` 方法中，在應用程式使用 Aspose.Slides 之前：

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

傳遞給 [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) 方法的檔名是相對於 *assets* 資料夾的。如果檔案不存在，程式碼會記錄錯誤，Aspose.Slides 仍會以評估模式運作。若要檢查授權是否已套用，請參閱[驗證授權](#validating-a-license)。

## **驗證授權**

若要檢查授權是否正確設定，您可以驗證它。以下 Java 程式碼示範如何驗證授權：

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

{{% alert color="warning" title="警告" %}}
[setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 方法不是執行緒安全的。如果必須同時從多個執行緒呼叫此方法，建議使用同步機制（例如鎖）以避免問題。
{{% /alert %}}

## **FAQ**

### 我可以在完全離線的環境（無網路）中套用授權嗎？

可以。授權驗證完全在本機使用授權檔案完成，無需網路連線。

### 一年訂閱到期後會發生什麼事？函式庫會停止運作嗎？

不會。授權是永久性的：您可持續使用訂閱結束日前發佈的版本，只是若要使用更新的版本則需要續約。