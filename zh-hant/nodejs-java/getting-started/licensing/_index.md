---
title: 授權
type: docs
weight: 80
url: /zh-hant/nodejs-java/licensing/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中套用、管理與排除授權問題。透過我們的逐步授權指南，確保持續不間斷地使用全部功能。"
---
## **簡介**

有時為了獲得最佳的評估結果，可能需要親自操作。基於此原因，Aspose.Slides 提供不同的購買方案，並提供免費試用和 30 天臨時授權以供評估。

{{% alert color="primary" %}}
請注意，有多項一般政策與慣例指導您如何評估、正確授權以及購買我們的產品。您可以在 ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies) 章節中找到它們。
{{% /alert %}}

## **評估 Aspose.Slides**
您可以輕鬆下載 Aspose.Slides 進行評估。評估套件與購買的套件相同。只要在程式碼中加入幾行設定授權的程式，即可將評估版轉為已授權版。

## **評估版限制**
Aspose.Slides 的評估版（未指定授權）提供完整的產品功能，但在開啟和儲存文件時會在文件頂部插入評估浮水印。從簡報投影片提取文字時亦僅限於一張投影片。

{{% alert color="primary" %}} 
如果您想在不受評估版限制的情況下測試 Aspose.Slides，可申請 **30 Day Temporary License**。更多資訊請參考 [How to get a Temporary License?](https://purchase.aspose.com/temporary-license)。
{{% /alert %}} 

## **關於授權**
您可以輕鬆從其 [download page](https://releases.aspose.com/slides/zh-hant/nodejs-java/) 下載 Aspose.Slides for Node.js via Java 的評估版。評估版提供與授權版 **完全相同的功能**。此外，購買授權並在程式碼中加入幾行設定授權的程式碼後，評估版即可轉為已授權。

授權是一個純文字 XML 檔案，內含產品名稱、授權開發人員數量、訂閱到期日等資訊。該檔案已經數位簽章，請勿修改。即使不小心在檔案內容中加入額外的換行，也會使其失效。

為避免評估版的限制，您必須在使用 **Aspose.Slides** 前設定授權。每個應用程式或處理程序只需設定一次授權。

{{% alert color="primary" %}} 
您可能想了解 [Metered Licensing](https://docs.aspose.com/slides/zh-hant/nodejs-java/metered-licensing/)。
{{% /alert %}} 

## **已購買授權**

購買後，您需要套用授權檔案或串流。

{{% alert color="primary" %}}
您需要設定授權：
* 每個應用程式域僅一次
* 在使用任何其他 Aspose.Slides 類別之前
{{% /alert %}}

{{% alert color="primary" %}}
您可以在 [“Pricing Information”](https://purchase.aspose.com/pricing/slides/zh-hant/family) 頁面找到價格資訊。
{{% /alert %}}

### **在 Aspose.Slides for Node.js via Java 中設定授權**
授權可以從以下位置套用：

* 明確路徑
* 串流
* 作為計量授權 – 一種新授權機制

{{% alert color="primary" %}}
使用 **setLicense** 方法為元件授權。

雖然多次呼叫 **setLicense** 不會產生問題，但會浪費資源（處理器）。
{{% /alert %}}

{{% alert color="warning" %}}
新授權僅能在 21.4 或更新版本的 Aspose.Slides 中啟用。較早的版本使用不同的授權系統，將無法識別這些授權。
{{% /alert %}}

#### **使用檔案套用授權**
此程式碼片段用於設定授權檔案：

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

呼叫 setLicense 方法時，授權名稱應與授權檔案的名稱相同。例如，您可以將授權檔案名稱改為 "Aspose.Slides.lic.xml"。接著，在程式碼中必須將新授權名稱 (Aspose.Slides.lic.xml) 傳遞給 setLicense 方法。

#### **從串流套用授權**
此程式碼片段用於從串流套用授權：

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **常見問題**

**我可以在完全離線環境（無網際網路連線）中套用授權嗎？**
可以。授權驗證是使用授權檔案在本機執行，無需網際網路連線。

**一年訂閱到期後會發生什麼事？函式庫會停止運作嗎？**
不會。授權為永久性：您仍可使用訂閱結束日期之前發布的版本；但若未續訂，將無法使用更新的版本。