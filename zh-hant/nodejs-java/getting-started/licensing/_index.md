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
- 評估版本
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中套用、管理與排除授權問題。透過我們的步驟式授權指南，確保不間斷使用全部功能。"
---
## **簡介**

有時為了獲得最佳評估結果，可能需要實作操作。基於此，Aspose.Slides 提供不同的購買方案，並提供免費試用以及 30 天臨時授權供評估使用。

{{% alert color="info" title="Note" %}}
請注意，我們有多項一般政策與慣例，指導您如何評估、正確授權以及購買我們的產品。您可以在[購買政策與常見問題](https://purchase.aspose.com/policies)章節中找到相關資訊。
{{% /alert %}}

## **評估 Aspose.Slides**
您可以輕鬆下載 Aspose.Slides 進行評估。評估套件與正式購買的套件相同。只要在程式碼中加入幾行授權設定，評估版本即會轉為正式授權。

## **評估版本限制**
Aspose.Slides 的評估版本（未指定授權）提供完整的產品功能，但有兩項限制：

* 它會在每個儲存的簡報的每張投影片上加入評估水印文字框。
* 程式從簡報讀取的文字若超過五個字元，將僅保留前五個字元，並在後方加上 `... text has been truncated due to evaluation version limitation.`；五個字元或以下的文字則保持不變，程式寫入的文字則完整儲存。

{{% alert color="info" title="Note" %}}
若您想在不受評估版本限制的情況下測試 Aspose.Slides，可申請 **30 天臨時授權**。更多資訊請參考[如何取得臨時授權？](https://purchase.aspose.com/temporary-license)。
{{% /alert %}}

## **關於授權**
您可以從其[下載頁面](https://releases.aspose.com/slides/zh-hant/nodejs-java/)輕鬆下載 Aspose.Slides for Node.js via Java 的評估版本。此評估版本具備與正式授權版本相同的功能，並受到上述限制。當您購買授權並在程式碼中加入幾行設定後，評估版本即會轉為正式授權。

授權檔是一個純文字 XML 檔案，內含產品名稱、授權開發人員數量、訂閱到期日等資訊。檔案已經數位簽署，請勿修改檔案內容。即使不小心在檔案內容加入額外的換行，也會使其失效。

為避免評估版本的限制，您必須在使用 **Aspose.Slides** 前先設定授權。每個應用程式或處理程序只需設定一次授權即可。

{{% alert color="info" title="Note" %}}
您可能想了解[計量授權](/slides/zh-hant/nodejs-java/metered-licensing/)。
{{% /alert %}}

## **已購買授權**

購買後，您需要套用授權檔或串流。

{{% alert color="info" title="Note" %}}
您需要設定授權：
* 每個處理程序僅一次
* 在使用其他 Aspose.Slides 類別之前
{{% /alert %}}

{{% alert color="info" title="Note" %}}
您可以在[價格資訊](https://purchase.aspose.com/pricing/slides/zh-hant/family)頁面找到定價資訊。
{{% /alert %}}

### **在 Aspose.Slides for Node.js via Java 中設定授權**

授權可從以下位置套用：

* 明確路徑
* 串流
* 作為計量授權——全新授權機制

{{% alert color="info" title="Note" %}}
使用 **setLicense** 方法為元件授權。

雖然多次呼叫 **setLicense** 不會造成傷害，但會浪費資源（處理器）。
{{% /alert %}}

#### **使用檔案套用授權**

此程式碼片段用於設定授權檔：

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides 在保持 Node.js 執行的 Java 虛擬機中運行，因此必須明確結束程序。
process.exit(0);
```

呼叫 setLicense 方法時，授權名稱應與授權檔案名稱相同。例如，您可以將授權檔案名稱改為「Aspose.Slides.lic.xml」。然後，在程式碼中必須將新的授權名稱（Aspose.Slides.lic.xml）傳遞給 setLicense 方法。如果檔案遺失或不含有效授權，[setLicense](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/license/setlicense/) 會拋出例外，使腳本以錯誤結束。

#### **從串流套用授權**

要從串流套用授權，請將 [License](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/license/) 物件與可讀串流傳遞給靜態 [setLicenseFromStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/license/setlicense/) 方法。串流會以非同步方式讀取，若串流未包含有效授權，回呼函式會收到錯誤：

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides 在保持 Node.js 執行的 Java 虛擬機中運行，因此必須明確結束程序。
    process.exit(0);
});
```

授權會在整個串流讀取完成且回呼函式執行前套用，因此請在回呼中開始其他 Aspose.Slides 工作。

兩個範例在完成後會呼叫 `process.exit(0)`，因為執行 Aspose.Slides 的 Java 虛擬機會使 Node.js 持續運行。在實際應用中，請在結束程序前繼續執行您的 Aspose.Slides 程式碼。

## **常見問題**

### 我可以在完全離線的環境（無網路連線）下套用授權嗎？

可以。授權驗證在本機使用授權檔完成，無需網路連線。

### 一年訂閱到期後會發生什麼情況？函式庫會停止運作嗎？

不會。授權為永久式：您可以繼續使用訂閱結束日前發布的版本；若未續約，則無法使用較新版本。