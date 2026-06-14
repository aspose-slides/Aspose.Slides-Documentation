---
title: 授權
description: "Aspose.Slides for Node.js via .NET 提供不同的購買方案，或提供免費試用與 30 天臨時授權以根據授權與訂閱政策進行評估。"
type: docs
weight: 80
url: /zh-hant/nodejs-net/licensing/
---
有時為了獲得最佳的評估結果，可能需要親自操作。為此，Aspose.Slides 提供了不同的購買方案，並且提供免費試用和 30 天臨時許可證供評估使用。

{{% alert color="primary" %}}
請注意，有多項一般政策與實踐指導您如何評估、正確授權以及購買我們的產品。您可以在["購買政策與常見問題"](https://purchase.aspose.com/policies) 部分找到它們。
{{% /alert %}}

## **Evaluate Aspose.Slides**
您可以輕鬆下載 Aspose.Slides 進行評估。評估套件與購買套件相同。只要在程式碼中加入幾行以套用授權，評估版即會轉為授權版。

## **Evaluation Version Limitation**
Aspose.Slides 的評估版（未指定授權）提供完整的產品功能，但在開啟和儲存文件時會在文件頂部插入評估水印。從簡報投影片中擷取文字時也僅限於單一投影片。

{{% alert color="primary" %}} 
如果您想在不受評估版限制的情況下測試 Aspose.Slides，您可以申請 **30 天臨時許可證**。更多資訊請參閱[如何取得臨時許可證？](https://purchase.aspose.com/temporary-license)。
{{% /alert %}} 

## **About the License**
您可以輕鬆從其[下載頁面](https://releases.aspose.com/slides/zh-hant/nodejs-net/) 下載 Aspose.Slides for Node.js via .NET 的評估版。該評估版提供與授權版 **完全相同的功能**。此外，在購買授權並在程式碼中加入幾行以套用授權後，評估版即會轉為授權版。

授權是一個純文字 XML 檔案，內含產品名稱、授權開發人員人數、訂閱到期日等資訊。該檔案已經數位簽章，請勿修改檔案。即使無意中在檔案內容加入額外的換行，也會使其失效。

為避免與評估版相關的限制，您需要在使用 **Aspose.Slides** 前設定授權。每個應用程式或流程只需設定一次授權。

## Purchased License
購買後，您需要套用授權檔案或串流。 

{{% alert color="primary" %}}
您需要設定授權：
* 每個應用程式域僅一次
* 在使用任何其他 Aspose.Slides 類別之前
{{% /alert %}}

{{% alert color="primary" %}}
您可以在[“價格資訊”](https://purchase.aspose.com/pricing/slides/zh-hant/family) 頁面找到定價資訊。
{{% /alert %}}

### **Setting a License in Aspose.Slides for Node.js via .NET**

授權可從以下位置套用：

* 明確路徑
* 串流
* 計量授權 – 一種新授權機制

{{% alert color="primary" %}}
使用 **setLicense** 方法為元件授權。

雖然多次呼叫 **setLicense** 不會造成傷害，但會浪費資源（處理器）。
{{% /alert %}}

{{% alert color="warning" %}}
新授權只能在 21.4 版或更新的 Aspose.Slides 中啟用。較早版本使用不同的授權系統，無法識別這些授權。
{{% /alert %}}

#### **Applying a License Using a File**

此程式碼片段用於設定授權檔案：

**Node.js**

```javascript
// 匯入 Aspose.Slides 模組以操作 PowerPoint 檔案
const asposeSlides = require('aspose.slides.via.net');

// 此函式設定 Aspose.Slides 函式庫的授權
function setupAsposeSlidesLicense() {
	
    // 從 Aspose.Slides 模組初始化 License 類別
    var license = new asposeSlides.License();
    
    // 從檔案套用授權
    // 將 "your_license_file.lic" 替換為實際授權檔案的路徑
    license.setLicense("your_license_file.lic");
}

// 執行函式以設定 Aspose.Slides 的授權
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}
呼叫 setLicense 方法時，授權名稱應與授權檔案的名稱相同。舉例來說，您可以將授權檔案名稱更改為「Aspose.Slides.lic.xml」。然後在程式碼中，必須將新授權名稱 (Aspose.Slides.lic.xml) 傳遞給 setLicense 方法。
{{% /alert %}}