---
title: 授權
description: "將授權檔案套用至 Aspose.Slides for Node.js via .NET，了解評估版的限制，並取得免費的 30 天暫時授權以進行測試。"
type: docs
weight: 80
url: /zh-hant/nodejs-net/licensing/
---
## **概述**

Aspose.Slides for Node.js via .NET 是一個同時支援評估與正式環境的 npm 套件。未取得授權時會以評估模式執行。購買授權或取得免費的 30 天暫時授權後，只需幾行程式碼即可套用，評估限制便會解除。

{{% alert color="info" title="Note" %}}

有關評估、授權與購買 Aspose 產品的一般政策，請參閱 [購買政策與常見問答](https://purchase.aspose.com/policies)。價格資訊請見 [定價資訊](https://purchase.aspose.com/pricing/slides/family) 頁面。

{{% /alert %}}

## **評估版限制**

評估版提供完整功能，但有兩項限制：

- **浮水印。** 每個儲存的簡報投影片皆會加上評估浮水印：投影片中央的鎖定文字方塊，內容顯示「Evaluation only」。相同的浮水印也會出現在 PDF、XPS、HTML 匯出以及投影片影像上。
- **文字截斷。** 從文字框、段落或區段讀取的文字會被截斷為前五個字元，後方接上「... text has been truncated due to evaluation version limitation.」的提示。Markdown 與 HTML5 匯出也會以相同方式截斷。程式碼寫入的文字則會完整保存。

[評估 Aspose.Slides](/slides/zh-hant/nodejs-net/evaluate-aspose-slides/) 詳細說明了上述兩項限制，並提供示範腳本。

{{% alert color="success" title="Tip" %}}

若想在不受評估限制的情況下測試 Aspose.Slides，可申請免費的 **30 天** 暫時授權。詳情請參閱 [如何取得暫時授權？](https://purchase.aspose.com/temporary-license)。

{{% /alert %}}

## **關於授權**

授權是一個純文字的 XML 檔案，內含產品名稱、授權開發人員數量與訂閱到期日等資訊。該檔案已數位簽署，請勿自行修改：即使是不小心加入的額外換行也會使授權失效。

## **套用授權**

使用 `License` 類別的 `setLicense` 方法套用授權。請在建立任何 `Presentation` 物件前於程式執行期間呼叫一次。再次呼叫不會造成問題，只是重複已完成的工作。

以下腳本示範從名為 `Aspose.Slides.lic` 的檔案套用授權。請將檔名改為您的授權檔案名稱或完整路徑；檔案名稱可自行命名。

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

檔名或相對路徑會根據當前工作目錄（執行 `node` 的資料夾）解析。請將授權檔案放於專案資料夾並從該資料夾執行腳本，或直接提供完整路徑。

若無法找到檔案或檔案不是有效授權，`setLicense` 會拋出錯誤，Aspose.Slides 仍會以評估模式運作。腳本會捕捉錯誤並顯示其訊息。檔案遺失時，訊息開頭為 `License "Aspose.Slides.lic" doesn't exist or access is restricted.`，並列出所有搜尋過的路徑。

在此套件中，授權僅能從檔案套用。`License` 不接受串流，套件也未提供計量授權功能。欲了解套件所封裝的類別，請參閱 Aspose.Slides for .NET API 參考中的 [License](https://reference.aspose.com/slides/net/aspose.slides/license/)。