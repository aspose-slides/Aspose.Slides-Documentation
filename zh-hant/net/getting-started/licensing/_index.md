---
title: 授權
type: docs
weight: 80
url: /zh-hant/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中套用、管理與除錯授權。透過我們的逐步授權指南，確保不間斷使用完整功能。"
---
## **概觀**

Aspose.Slides 可以在評估模式或使用有效授權下使用。評估版提供與授權版相同的功能，但在開啟或儲存簡報時會加入評估浮水印，且僅允許從一張投影片中提取文字。

本文說明 Aspose.Slides 的授權機制以及在使用程式庫之前如何套用授權。授權可以透過 `License` 類別從檔案、串流或嵌入式資源載入。本文亦示範如何驗證授權是否正確套用。

## **評估 Aspose.Slides**

{{% alert color="info" %}} 

您可以從[它的 NuGet 下載頁面](https://www.nuget.org/packages/Aspose.Slides.NET/)下載 **Aspose.Slides for NET** 的評估版。評估版提供與產品授權版相同的功能。評估套件與購買的套件相同，僅需在程式碼中加入幾行以套用授權，即可將評估版轉為授權版。

在您對 **Aspose.Slides** 的評估滿意後，您可以[購買授權](https://purchase.aspose.com/buy)。我們建議您了解不同的訂閱類型。如有問題，請聯絡 Aspose 銷售團隊。

每份 Aspose 授權皆附帶一年免費升級（含在訂閱期間內發布的新版本或修正）服務。無論是授權產品或評估版的使用者，都可獲得免費且無限制的技術支援。

{{% /alert %}} 

**評估版限制**

* 雖然 Aspose.Slides 評估版（未指定授權）提供完整功能，但在開啟或儲存文件時會在文件頂部插入評估浮水印。 
* 從簡報投影片中提取文字時僅限於一張投影片。

{{% alert color="info" %}} 

若要在不受限制的情況下測試 Aspose.Slides，您可以索取**30 天臨時授權**。請參閱[取得臨時授權](https://purchase.aspose.com/temporary-license)頁面以取得更多資訊。

{{% /alert %}}

## **Aspose.Slides 的授權**
* 評估版在購買授權並加入少量程式碼（套用授權）後即變為授權版。
* 授權是一個純文字 XML 檔案，包含產品名稱、授權開發人員數量、訂閱到期日等資訊。 
* 授權檔案已經數位簽章，請勿修改檔案內容。即使不小心多加一個換行，也會導致授權失效。
* Aspose.Slides for .NET 通常會在以下位置尋找授權檔案：
  * 明確指定的路徑
  * 包含元件 DLL 的資料夾（包含於 Aspose.Slides）
  * 呼叫元件 DLL 的組件所在的資料夾（包含於 Aspose.Slides）
  * 包含入口組件（您的 .exe）的資料夾
  * 呼叫元件 DLL 的組件內的嵌入式資源（包含於 Aspose.Slides）。
* 為避免評估版的限制，必須在使用 Aspose.Slides 前先設定授權。每個應用程式或程序只需要設定一次授權。

{{% alert color="info" %}} 

您可能想了解[計量授權](https://docs.aspose.com/slides/zh-hant/net/metered-licensing/)。

{{% /alert %}} 


## **套用授權**
授權可以從**檔案**、**串流**或**嵌入式資源**載入。

{{% alert color="info" %}}

Aspose.Slides 提供[License](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license) 類別供授權相關操作使用。

{{% /alert %}} 

{{% alert color="warning" %}} 

新授權只能在 21.4 版或更新的 Aspose.Slides 中啟用。較早的版本使用不同的授權系統，無法辨識這些授權。

{{% /alert %}}

### **檔案**
設定授權的最簡方法是將授權檔案放置在包含元件 DLL 的同一資料夾（包含於 Aspose.Slides），且僅指定檔名，不需路徑。

以下 C# 程式碼示範如何設定授權檔案：

``` csharp
// 實例化 License 類別 
Aspose.Slides.License license = new Aspose.Slides.License();

// 設定授權檔案路徑
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

如果將授權檔案放在其他目錄，呼叫[SetLicense](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license/setlicense/#setlicense_1) 方法時，所指定的明確路徑最後的檔名必須與授權檔案相同。

例如，您可以將授權檔名改為 *Aspose.Slides.lic.xml*。此時，在程式碼中必須傳入包含 *Aspose.Slides.lic.xml* 的完整路徑給 [SetLicense](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license/setlicense/#setlicense_1) 方法。

{{% /alert %}}

### **串流**
您可以從串流載入授權。以下 C# 程式碼示範如何從串流套用授權：

``` csharp
// 實例化 License 類別
Aspose.Slides.License license = new Aspose.Slides.License();

// 將授權檔案以串流方式開啟
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// 透過串流設定授權
license.SetLicense(licenseStream);
```

### **嵌入式資源**
您可以將授權包裝進應用程式（避免遺失），方法是將授權檔案加入呼叫元件 DLL 的其中一個組件的嵌入式資源（包含於 Aspose.Slides）。

以下說明如何將授權檔案加入為嵌入式資源：

1. 在 Visual Studio 中，以 **檔案** > **加入現有項目** > **加入** 的方式將授權（.lic）檔案加入專案。 
2. 在 **方案總管** 中選取該檔案。 
3. 在 **內容** 視窗將 **Build Action** 設為 **Embedded Resource**。 
4. 若要存取嵌入於組件中的授權，將授權檔案加入為嵌入式資源後，將檔名傳給 `SetLicense` 方法。 

`License` 類別會自動在嵌入式資源中尋找授權檔案。您不需要在 Microsoft .NET Framework 中呼叫 `System.Reflection.Assembly` 類別的 `GetExecutingAssembly` 與 `GetManifestResourceStream` 方法。

以下 C# 程式碼示範如何將授權設定為嵌入式資源：

``` csharp
// 實例化 License 類別
Aspose.Slides.License license = new Aspose.Slides.License();

// 傳遞嵌入於組件中的授權檔案名稱
license.SetLicense("Aspose.Slides.lic");
```

## **驗證授權**

若要確認授權是否正確設定，您可以進行驗證。以下 C# 程式碼示範如何驗證授權：

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

{{% alert title="注意" color="warning" %}} 

[license.SetLicense](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license/setlicense/) 方法不是執行緒安全的。如果此方法必須同時由多個執行緒呼叫，建議使用同步基元（例如 lock）以避免問題。 

{{% /alert %}}

## **常見問題**

### 我可以在完全離線的環境（沒有網路）中套用授權嗎？

可以。授權驗證是使用本機的授權檔案完成的，無需網路連線。

### 一年訂閱到期後會發生什麼事？函式庫會停止運作嗎？

不會。授權為永久性：在訂閱結束日前發布的版本仍可繼續使用，只是若要使用更新的發行版則需重新續訂。