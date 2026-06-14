---
title: 計量授權
type: docs
weight: 100
url: /zh-hant/nodejs-java/metered-licensing/
keywords:
- 授權
- 計量授權
- 授權金鑰
- 公鑰
- 私鑰
- 消耗數量
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何透過 Java 計量授權的 Aspose.Slides for Node.js，彈性處理 PowerPoint 與 OpenDocument 檔案，僅為實際使用量付費。"
---
## **簡介**

計量授權是一種可以與現有授權方式一起使用的授權機制。如果您希望根據使用 Aspose.Slides API 功能的情況收費，則可選擇計量授權。

## **套用計量金鑰**

購買計量授權時，您會取得金鑰（而非授權檔案）。此計量金鑰可使用 Aspose 提供的用於計量操作的 [Metered](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/metered/) 類別套用。更多細節請參閱 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

1. 建立 [Metered](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/metered/) 類別的實例。

1. 將您的公鑰與私鑰傳遞給 [setMeteredKey](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/metered/#setMeteredKey) 方法。

1. 執行一些處理（執行任務）。

1. 呼叫 `Metered` 類別的 [getConsumptionQuantity](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) 方法。

您應該會看到目前為止已消耗的 API 請求次數/數量。

以下範例程式碼展示如何使用計量授權：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 建立 Metered 類別的實例
var metered = new aspose.slides.Metered();

// 將公鑰與私鑰傳遞給 Metered 物件
metered.setMeteredKey("<valid public key>", "<valid private key>");

// 取得 API 呼叫前的已消耗數量值
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// 在此使用 Aspose.Slides API 做一些事
// ...

// 取得 API 呼叫後的已消耗數量值
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 
若要使用計量授權，您需要穩定的網路連線，因為授權機制會持續透過網路與我們的服務互動並執行計算。
{{% /alert %}} 

## **常見問題**

**我可以在同一應用程式中同時使用計量授權與一般授權（永久或暫時）嗎？**

可以。計量授權是一種額外的授權機制，可與現有的 [licensing methods](/slides/zh-hant/nodejs-java/licensing/) 共同使用。您可以在應用程式啟動時選擇套用哪種機制。

**在計量授權中，到底是以操作次數還是檔案數量來計算消耗？**

以 API 使用量計算，也就是請求或操作的次數。您可以透過 [consumption-tracking methods](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/metered/) 取得目前的消耗情況。

**計量授權適用於經常重啟的微服務與無伺服器環境嗎？**

可以。由於計算是在 API 呼叫層級完成，頻繁的冷啟動情境仍相容，只要有穩定的網路連線以供計量計算即可。

**使用計量授權與永久授權時，函式庫的功能是否有所不同？**

不會。這僅涉及授權與計費機制，產品本身的功能與永久授權完全相同。

**計量授權與試用版及暫時授權之間的關係是什麼？**

試用版會有功能限制與浮水印，[temporary license](https://purchase.aspose.com/temporary-license/) 可在 30 天內解除限制，而計量授權則在移除限制的同時，依實際使用量收費。

**我可以在超過消耗門檻時自動做出反應，以控制預算嗎？**

可以。常見做法是定期透過 [tracking methods](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/metered/) 讀取目前的消耗，並在應用程式或監控層面自行實作限制或警示。