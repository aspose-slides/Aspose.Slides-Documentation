---
title: 授權
type: docs
weight: 80
url: /zh-hant/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中套用、管理與排除授權問題。透過我們的逐步授權指南，確保不間斷使用全部功能。"
---
## **概述**

Aspose.Slides 可以在評估模式或使用有效授權下使用。評估版本提供與授權版本相同的功能，但會在每個簡報保存的每張投影片上添加評估水印，並截斷程式從簡報中讀取的文字。

本文說明 Aspose.Slides 的授權運作方式，以及在使用函式庫之前如何套用授權。授權可以透過 `License` 類別從檔案、串流或內嵌資源載入。本文同時展示如何驗證授權是否正確套用。

## **評估 Aspose.Slides**

{{% alert color="info" title="Note" %}}

您可以從 [其 NuGet 下載頁面](https://www.nuget.org/packages/Aspose.Slides.NET/) 下載 **Aspose.Slides for .NET** 的評估版本。評估版本提供與產品授權版相同的功能。評估套件與購買套件相同，只要在程式碼中加入幾行以套用授權，即可將評估版本轉為授權版本。

在您滿意 **Aspose.Slides** 的評估結果後，可以 [購買授權](https://purchase.aspose.com/pricing/slides/zh-hant/net/)。我們建議您了解不同的訂閱類型。如有任何問題，請聯繫 Aspose 銷售團隊。

每一份 Aspose 授權都包含一年免費升級訂閱，於訂閱期間內可取得新版本或修正程式。使用授權產品或甚至評估版本的使用者，都可獲得免費且無限制的技術支援。

{{% /alert %}} 

**評估版本限制**

* 評估版本（未指定授權）提供完整產品功能，但會在每個簡報保存的每張投影片上添加評估水印文字框。
* 程式從簡報讀取的文字會被截斷為前幾個字元，並附加評估限制的說明。程式寫入的文字則會完整儲存。

{{% alert color="info" title="Note" %}}

若想在無限制的情況下測試 Aspose.Slides，您可以申請 **30 天臨時授權**。請參閱 [如何取得臨時授權](https://purchase.aspose.com/temporary-license) 頁面取得更多資訊。

{{% /alert %}}

## **Aspose.Slides 的授權方式**
* 評估版本在您購買授權並加入幾行程式碼（套用授權）後，即會轉為授權版本。
* 授權是一個純文字 XML 檔案，內含產品名稱、授權開發人員數量、訂閱到期日等資訊。
* 授權檔案已經數位簽章，請勿修改檔案。即使不小心在內容中加入額外的換行，也會使授權失效。
* Aspose.Slides for .NET 通常會在以下位置尋找授權檔案：
  * 明確指定的路徑
  * 包含元件 DLL 的資料夾（由 Aspose.Slides 提供）
  * 呼叫元件 DLL 的組件所在的資料夾（由 Aspose.Slides 提供）
  * 入口組件的資料夾（您的 .exe）
  * 呼叫元件 DLL 的組件內的內嵌資源（由 Aspose.Slides 提供）。
* 為避免評估版的限制，您需要在使用 Aspose.Slides 前先設定授權。每個應用程式或處理序只需設定一次授權。

{{% alert color="info" title="Note" %}}

您可能想參考 [計量授權](/slides/zh-hant/net/metered-licensing/)。

{{% /alert %}} 


## **套用授權**
授權可以從 **檔案**、**串流** 或 **內嵌資源** 載入。

{{% alert color="info" title="Note" %}}

Aspose.Slides 提供 [License](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license) 類別以執行授權相關操作。

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

新授權只能在 21.4 或更新的版本中啟用 Aspose.Slides。較早的版本使用不同的授權系統，無法識別這些授權。

{{% /alert %}}

### **檔案**
設定授權的最簡方法是將授權檔案放在與元件 DLL 相同的資料夾（由 Aspose.Slides 提供），並僅指定檔名而不含路徑。

以下 C# 程式碼示範如何設定授權檔案：

``` csharp
// 建立 License 類別的實例 
Aspose.Slides.License license = new Aspose.Slides.License();

// 設定授權檔案路徑
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}

如果將授權檔案放在其他目錄，呼叫 [SetLicense](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license/setlicense/#setlicense_1) 方法時，指定路徑最後的檔案名稱必須與實際授權檔案名稱相同。

例如，您可以將授權檔案名稱改為 *Aspose.Slides.lic.xml*。此時在程式碼中必須將包含 *Aspose.Slides.lic.xml* 的完整路徑傳遞給 [SetLicense](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license/setlicense/#setlicense_1) 方法。

{{% /alert %}}

### **串流**
您可以從串流載入授權。以下 C# 程式碼示範如何從串流套用授權：

``` csharp
// 建立 License 類別的實例
Aspose.Slides.License license = new Aspose.Slides.License();

// 以串流方式開啟授權檔案
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// 透過串流設定授權
license.SetLicense(licenseStream);
```

### **內嵌資源**
您可以將授權檔案加入為內嵌資源，與應用程式一起打包，以避免遺失。

以下步驟說明如何將授權檔案加入為內嵌資源：

1. 在 Visual Studio 中，以 **File** > **Add Existing Item** > **Add** 的方式將授權（.lic）檔案加入專案。
2. 在 **Solution Explorer** 中選取該檔案。
3. 在 **Properties** 視窗中，將 **Build Action** 設為 **Embedded Resource**。
4. 要存取嵌入於組件中的授權，將授權檔案加入為內嵌資源後，將檔案名稱傳遞給 `SetLicense` 方法。

`License` 類別會自動在內嵌資源中尋找授權檔案。您不必在 Microsoft .NET Framework 中呼叫 `System.Reflection.Assembly` 類別的 `GetExecutingAssembly` 與 `GetManifestResourceStream` 方法。

以下 C# 程式碼示範如何將授權設定為內嵌資源：

``` csharp
// 建立 License 類別的實例
Aspose.Slides.License license = new Aspose.Slides.License();

// 傳遞嵌入於組件中的授權檔案名稱
license.SetLicense("Aspose.Slides.lic");
```

## **驗證授權**

若要檢查授權是否正確設定，您可以進行驗證。以下 C# 程式碼示範如何驗證授權：

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **執行緒安全性**

{{% alert color="warning" title="Warning" %}}

`license.SetLicense` 方法不是執行緒安全的。如果必須同時從多個執行緒呼叫此方法，建議使用同步原語（例如 lock）以避免問題。

{{% /alert %}}

## **常見問題集**

### 我可以在完全離線的環境（無網路存取）下套用授權嗎？

可以。授權驗證是使用本機授權檔案完成的，不需要網路連線。

### 一年訂閱到期後會發生什麼事？函式庫會停止運作嗎？

不會。授權為永久授權：您仍可繼續使用訂閱到期日前發布的版本，只是若未續約則無法使用更新的版本。