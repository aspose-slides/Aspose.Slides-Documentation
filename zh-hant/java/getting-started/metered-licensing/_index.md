---
title: 計量授權
type: docs
weight: 100
url: /zh-hant/java/metered-licensing/
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
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 的計量授權如何讓您彈性處理 PowerPoint 和 OpenDocument 檔案，僅為實際使用付費。"
---
## **簡介**

計量授權是一種可與現有授權方式同時使用的授權機制。如果您希望根據使用 Aspose.Slides API 功能的情況計費，則選擇計量授權。

## **套用計量金鑰**

{{% alert color="info" %}} 

計量授權是一種可與現有授權方式同時使用的新授權機制。如果您希望根據使用 Aspose.Slides API 功能的情況計費，則選擇計量授權。

購買計量授權後，您將取得金鑰（而非授權檔案）。此計量金鑰可透過 Aspose 提供的 [Metered](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/metered/) 類別進行套用。更多細節請參閱 [計量授權常見問答](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 建立 [Metered](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/metered/) 類別的實例。

1. 將您的公鑰與私鑰傳遞給 [setMeteredKey](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) 方法。

1. 執行一些處理（執行任務）。

1. 呼叫 `Metered` 類別的 [getConsumptionQuantity](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/metered/#getConsumptionQuantity--) 方法。

您應該會看到截至目前為止已消耗的 API 請求數量。

以下範例程式碼示範如何使用計量授權：

```java
// 建立 Metered 類別的實例
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // 將公鑰與私鑰傳遞給 Metered 物件
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // 在 API 呼叫前取得已消耗的數量值
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // 在此使用 Aspose.Slides API 執行某些操作
    // ...

    // 在 API 呼叫後取得已消耗的數量值
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

要使用計量授權，您需要穩定的網際網路連線，因為授權機制會不斷與我們的服務互動並執行計算。

{{% /alert %}} 

## **常見問與答**

### 我可以在同一個應用程式中同時使用計量授權與一般授權（永久或暫時）嗎？

可以。計量授權是可與現有[授權方式](/slides/zh-hant/java/licensing/)一起使用的額外授權機制。您可以在應用程式啟動時選擇使用哪種機制。

### 計量授權的消耗究竟是以操作還是檔案來計算？

計算的是 API 使用量，也就是請求或操作的次數。您可以透過[消耗追蹤方法](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/metered/)取得目前的消耗量。

### 計量授權適用於微服務和無伺服器環境（實例頻繁重新啟動）嗎？

可以。由於計算是在 API 呼叫層級完成，因此即使頻繁冷啟動也相容，只要有穩定的網路存取以進行計量計算。

### 使用計量授權時，函式庫的功能是否與永久授權不同？

不會。這僅涉及授權與計費機制，產品本身的功能保持一致。

### 計量授權與試用版以及暫時授權有什麼關係？

試用版有功能限制與浮水印，[暫時授權](https://purchase.aspose.com/temporary-license/) 可在 30 天內移除限制，而計量授權則移除限制，並根據實際使用量收費。

### 我能否透過自動響應消耗阈值超標來控制預算？

可以。常見做法是定期透過[追蹤方法](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/metered/)讀取目前的消耗量，並在應用程式或監控層面實作自己的限制或警報。