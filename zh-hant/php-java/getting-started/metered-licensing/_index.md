---
title: 計量授權
type: docs
weight: 100
url: /zh-hant/php-java/metered-licensing/
keywords:
- 授權
- 計量授權
- 授權金鑰
- 公開金鑰
- 私密金鑰
- 消耗量
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP via Java 計量授權如何讓您彈性處理 PowerPoint 與 OpenDocument 檔案，僅為實際使用的部分付費。"
---
## **簡介**

Metered licensing 是一種可與現有授權方式並用的授權機制。如果您想根據使用 Aspose.Slides API 功能的情況計費，就選擇計量授權。

## **套用計量金鑰**

當您購買計量授權時，您會取得金鑰（而非授權檔案）。這些計量金鑰可透過 Aspose 提供的 [Metered](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/metered/) 類別進行套用。更多細節請參考 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

1. 建立 [Metered](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/metered/) 類別的實例。

1. 將您的公開金鑰與私密金鑰傳遞給 [setMeteredKey](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) 方法。

1. 執行一些處理（執行任務）。

1. 呼叫 `Metered` 類別的 [getConsumptionQuantity](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/metered/#getConsumptionQuantity--) 方法。

您應該會看到截至目前已消耗的 API 請求數量/金額。

以下範例程式碼示範如何使用計量授權：

```php
// 建立 Metered 類別的實例
$metered = new Metered();

try {
    // 將公開金鑰與私密金鑰傳遞給 Metered 物件
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // 取得 API 呼叫前的已消耗數量值
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // 在此使用 Aspose.Slides API 執行一些操作
    // ...

    // 取得 API 呼叫後的已消耗數量值
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

要使用計量授權，您需要穩定的網際網路連線，因為授權機制會透過網路不斷與我們的服務互動並進行計算。

{{% /alert %}} 

## **常見問題**

**我可以在同一應用程式中同時使用計量授權與一般授權（永久或暫時性）嗎？**

可以。計量授權是可與現有[授權方法](/slides/zh-hant/php-java/licensing/)一起使用的額外授權機制。您可以在應用程式啟動時選擇套用哪種機制。

**在計量授權下，究竟如何計算消耗：是操作次數還是檔案數？**

計算的是 API 使用量，即請求或操作的次數。您可以透過[消耗追蹤方法](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/metered/)取得目前的消耗量。

**計量授權適用於實例頻繁重新啟動的微服務與無伺服器環境嗎？**

可以。由於計算以 API 呼叫層級進行，即使頻繁的冷啟動也相容，只要有穩定的網路連線供計量計算即可。

**使用計量授權與永久授權時，函式庫的功能是否有差異？**

沒有。這僅涉及授權與計費機制，產品功能保持一致。

**計量授權與試用版及暫時授權之間的關係是什麼？**

試用版有功能限制與浮水印，[暫時授權](https://purchase.aspose.com/temporary-license/)可在 30 天內移除限制，而計量授權則移除限制並依實際使用量收費。

**我能否在超過消耗門檻時自動執行動作以控制預算？**

可以。常見的做法是定期透過[追蹤方法](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/metered/)讀取目前的消耗量，並在應用程式或監控層面實作自訂的限制或警示。