---
title: 計量授權
type: docs
weight: 90
url: /zh-hant/net/metered-licensing/
keywords:
- 授權
- 計量授權
- 授權金鑰
- 公鑰
- 私鑰
- 消耗量
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 計量授權如何讓您彈性處理 PowerPoint 與 OpenDocument 檔案，僅為實際使用量付費。"
---
## **簡介**

計量授權是一種可與現有授權方式並存的授權機制。如果您希望根據使用 Aspose.Slides API 功能的情況計費，請選擇計量授權。

## **套用計量金鑰**

當您購買計量授權時，會取得金鑰（而非授權檔案）。此計量金鑰可透過 Aspose 提供的 [Metered](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/metered/) 類別進行套用。欲了解更多資訊，請參閱 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

1. 建立 [Metered](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/metered/) 類別的實例。
1. 將您的公鑰與私鑰傳遞給 [SetMeteredKey](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/metered/setmeteredkey/) 方法。
1. 執行一些處理（執行任務）。
1. 呼叫 `Metered` 類別的 [GetConsumptionQuantity](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/metered/getconsumptionquantity/) 方法。

您應該會看到迄今為止已使用的 API 請求數量/次數。

以下範例程式碼示範如何使用計量授權：

```cs
// 建立 Metered 類別的實例
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// 將公鑰與私鑰傳遞給 Metered 物件
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// 在 API 呼叫前取得計量資料的數量
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// 在此使用 Aspose.Slides API 做一些操作
// ...

// 在 API 呼叫後取得計量資料的數量
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 
若要使用計量授權，您需要穩定的網際網路連線，因為授權機制會持續透過網路與我們的服務互動並執行計算。
{{% /alert %}} 

## **常見問題**

**我可以在同一應用程式中同時使用計量授權與一般授權（永久或暫時）嗎？**

可以。計量授權是一種可與現有的 [授權方式](/slides/zh-hant/net/licensing/) 並存的額外授權機制。您可以在應用程式啟動時選擇要套用的機制。

**在計量授權下，究竟是以操作還是檔案計算消耗？**

會以 API 使用量計算，也就是請求或操作的次數。您可以透過 [消耗追蹤方法](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/metered/) 獲得目前的消耗量。

**計量授權適用於實例頻繁重新啟動的微服務與無伺服器環境嗎？**

是的。由於計算是在 API 呼叫層級完成的，所以即使頻繁冷啟動的情境也相容，只要有穩定的網路連線以供計量計算即可。

**使用計量授權與永久授權時，函式庫的功能會有差異嗎？**

不會。這僅關乎授權與計費機制，產品本身的功能保持一致。

**計量授權與試用版及暫時授權之間的關係是什麼？**

試用版有功能限制與浮水印，[暫時授權](https://purchase.aspose.com/temporary-license/) 可在 30 天內移除限制，而計量授權則在移除限制的同時，依實際使用量收費。

**我能透過自動在超過消耗門檻時做出回應來控制預算嗎？**

可以。常見的做法是定期透過 [追蹤方法](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/metered/) 讀取目前的消耗量，並在應用程式或監控層面自行實作限制或警示。