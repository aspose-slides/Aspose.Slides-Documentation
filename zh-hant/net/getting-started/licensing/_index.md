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
description: "在 Aspose.Slides for .NET 中套用、管理與排除授權問題。透過我們的一步步授權指南，確保不間斷使用完整功能。"
---
## **概觀**

Aspose.Slides 可以在評估模式或使用有效授權下使用。評估版本提供與已授權版本相同的功能，但在開啟或儲存簡報時會加入評估浮水印，且文字擷取限制為一張投影片。

本文說明 Aspose.Slides 的授權運作方式以及在使用函式庫之前如何套用授權。授權可以透過 `License` 類別從檔案、串流或嵌入式資源載入。本文也示範如何驗證授權是否正確套用。

## **評估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以從 [其 NuGet 下載頁面](https://www.nuget.org/packages/Aspose.Slides.NET/) 下載 **Aspose.Slides for NET** 的評估版本。評估版本提供與產品已授權版本相同的功能。評估套件與購買的套件相同。只要在程式碼中加入幾行以套用授權，評估版本即會變為已授權。

當您對 **Aspose.Slides** 的評估滿意後，您可以 [購買授權](https://purchase.aspose.com/buy)。我們建議您瞭解不同的訂閱類型。如有任何問題，請聯繫 Aspose 銷售團隊。

每份 Aspose 授權皆附帶一年免費升級訂閱，可免費取得訂閱期間內的新版本或修補程式。已授權的產品或即使是評估版本的使用者皆可獲得免費且無限制的技術支援。

{{% /alert %}} 

**評估版本限制**

* 雖然 Aspose.Slides 評估版本（未指定授權）提供完整的產品功能，但在開啟與儲存操作時會在文件頂部插入評估浮水印。 
* 當從簡報投影片擷取文字時，僅限於一張投影片。

{{% alert color="primary" %}} 

若要在沒有任何限制的情況下測試 Aspose.Slides，您可以申請 **30 天臨時授權**。更多資訊請參閱 [取得臨時授權的方法](https://purchase.aspose.com/temporary-license) 頁面。

{{% /alert %}}

## **Aspose.Slides 的授權**
* 評估版本在您購買授權並加入幾行程式碼以套用授權後，即會變為已授權。
* 授權是一個純文字 XML 檔案，內含產品名稱、授權開發人員數量、訂閱到期日等資訊。
* 授權檔案已數位簽名，請勿修改檔案。即使不慎在內容中加入額外的換行字元，也會使其失效。
* Aspose.Slides for .NET 通常會在以下位置尋找授權檔案：
  * 明確指定的路徑
  * 包含元件 DLL 的資料夾（包含於 Aspose.Slides 中）
  * 呼叫元件 DLL 的組件所在的資料夾（包含於 Aspose.Slides 中）
  * 包含入口組件（您的 .exe）的資料夾
  * 呼叫元件 DLL 的組件所嵌入的資源（包含於 Aspose.Slides）。
* 為了避免評估版本的限制，您需要在使用 Aspose.Slides 前設定授權。每個應用程式或行程只需要設定一次授權。

{{% alert color="primary" %}} 

您可能想要查看 [Metered Licensing](https://docs.aspose.com/slides/zh-hant/net/metered-licensing/)。

{{% /alert %}} 


## **套用授權**
授權可以從 **檔案**、**串流** 或 **嵌入式資源** 載入。 

{{% alert color="primary" %}}

Aspose.Slides 提供 [License](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license) 類別來執行授權操作。

{{% /alert %}} 

{{% alert color="warning" %}} 

新授權只能在版本 21.4 或之後的 Aspose.Slides 中啟用。較早的版本使用不同的授權系統，將無法識別這些授權。

{{% /alert %}}

### **檔案**
設定授權的最簡方法是將授權檔案放在與元件 DLL 相同的資料夾（包含於 Aspose.Slides）中，並僅指定檔名而不含路徑。

以下 C# 程式碼示範如何設定授權檔案：

``` csharp
// 實例化 License 類別
Aspose.Slides.License license = new Aspose.Slides.License();

// 設定授權檔案路徑
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

如果將授權檔案放在其他目錄，當呼叫 [SetLicense](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license/setlicense/#setlicense_1) 方法時，指定的明確路徑結尾的授權檔名必須與實際授權檔案相同。

例如，您可以將授權檔名改為 *Aspose.Slides.lic.xml*。之後在程式碼中必須傳遞指向該檔案（結尾為 *Aspose.Slides.lic.xml*）的路徑給 [SetLicense](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license/setlicense/#setlicense_1) 方法。

{{% /alert %}}

### **串流**
您可以從串流載入授權。以下 C# 程式碼示範如何從串流套用授權：

``` csharp
// 實例化 License 類別 
Aspose.Slides.License license = new Aspose.Slides.License();

// 透過串流設定授權
license.SetLicense(myStream);
```

### **嵌入式資源**
您可以將授權與應用程式一起封裝（避免遺失），方法是將授權檔案加入呼叫元件 DLL 的其中一個組件的嵌入式資源中（包含於 Aspose.Slides）。

以下說明如何將授權檔案加入為嵌入式資源：

1. 在 Visual Studio 中，使用 **檔案** > **加入現有項目** > **加入** 的方式將授權（.lic）檔案加入專案。 
2. 在 **方案總管** 中選取該檔案。 
3. 在 **內容** 視窗中，將 **建置動作** 設為 **Embedded Resource**。 
4. 若要存取嵌入於組件中的授權，將授權檔案加入為嵌入式資源，然後將檔名傳遞給 `SetLicense` 方法。 


`License` 類別會自動在嵌入式資源中尋找授權檔案，您不需要在 Microsoft .NET Framework 中呼叫 `System.Reflection.Assembly` 類別的 `GetExecutingAssembly` 與 `GetManifestResourceStream` 方法。

以下 C# 程式碼示範如何將授權設定為嵌入式資源：

``` csharp
// 實例化 License 類別
Aspose.Slides.License license = new Aspose.Slides.License();

// 傳遞嵌入於組件中的授權檔案名稱
license.SetLicense("Aspose.Slides.lic");
```

## **驗證授權**

若要檢查授權是否正確設定，您可以驗證它。以下 C# 程式碼示範如何驗證授權：

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

{{% alert title="Note" color="warning" %}} 

[license.SetLicense](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/license/setlicense/) 方法不是執行緒安全的。若此方法需要同時由多個執行緒呼叫，建議使用同步基元（例如 lock）以避免問題。 

{{% /alert %}}

## **常見問題**

**Can I apply the license in a completely offline environment (no internet access)?**

是的。授權驗證在本機使用授權檔案完成，無需網際網路連線。

**What happens after the one-year subscription expires? Will the library stop working?**

不會。授權為永久性：您仍可繼續使用訂閱結束日前發布的版本；但若要使用更新的版本，則需重新續約。