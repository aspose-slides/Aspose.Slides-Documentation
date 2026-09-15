---
title: 計量授權
type: docs
weight: 100
url: /zh-hant/python-java/metered-licensing/
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
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 計量授權如何讓您彈性處理 PowerPoint 和 OpenDocument 檔案，僅為實際使用的部分付費。"
---
## **簡介**

計量授權是一種可與現有授權方式並行使用的授權機制。如果您希望根據使用 Aspose.Slides API 功能的情況計費，請選擇計量授權。

## **套用計量金鑰**

{{% alert color="info" title="注意" %}}

計量授權是一種全新的授權機制，可與現有授權方式並行使用。如果您希望根據使用 Aspose.Slides API 功能的情況計費，請選擇計量授權。

購買計量授權時，您會取得金鑰（而非授權檔）。此計量金鑰可使用 Aspose 提供的 [Metered](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/metered/) 類別套用於計量操作。欲了解更多資訊，請參閱 [計量授權常見問題](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}}

1. 建立 [Metered](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/metered/) 類別的實例。

1. 將您的公鑰與私鑰傳遞給 [setMeteredKey](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/metered/#setMeteredKey) 方法。

1. 執行一些處理（執行任務）。

1. 呼叫 [Metered](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/metered/) 類別的 [getConsumptionQuantity](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/metered/#getConsumptionQuantity) 方法。

您應該會看到截至目前已消耗的 API 請求數量。

下列範例程式碼展示如何使用計量授權：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# 建立 Metered 類別的實例。
metered = Metered()

try:
    # 將公鑰與私鑰傳遞給 Metered 物件。
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # 取得 API 呼叫前的消耗數量。
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # 在此使用 Aspose.Slides API 執行某些操作。
    # ...

    # 取得 API 呼叫後的消耗數量。
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="警告"  %}}

使用計量授權時，需要穩定的網際網路連線，因為授權機制會持續透過網路與我們的服務互動並執行計算。

{{% /alert %}}

## **常見問題**

**我可以在同一個應用程式中同時使用計量授權與一般授權（永久或暫時）嗎？**

是的。計量授權是可與現有[授權方式](/slides/zh-hant/python-java/licensing/)並行使用的額外授權機制。您可以在應用程式啟動時選擇使用哪種機制。

**在計量授權下，究竟是以操作次數還是檔案數量作為消耗的計算依據？**

計算的是 API 使用量，也就是請求或操作的次數。您可以透過[消耗追蹤方法](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/metered/)取得目前的消耗量。

**計量授權適用於實例頻繁重新啟動的微服務與無伺服器環境嗎？**

是的。由於計費是在 API 呼叫層級完成的，頻繁冷啟動的情境仍然相容，只要具備穩定的網路連線以進行計量計算即可。

**使用計量授權與永久授權時，函式庫的功能是否有差異？**

不會。這僅涉及授權與計費機制，產品功能保持相同。

**計量授權與試用版及暫時授權之間有何關聯？**

試用版會有功能限制與浮水印，[暫時授權](https://purchase.aspose.com/temporary-license/)可在 30 天內移除限制，而計量授權則移除限制，並根據實際使用量收費。

**我能否在超過消耗門檻時自動做出回應以控制預算？**

可以。常見做法是定期透過[追蹤方法](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/metered/)讀取目前的消耗量，並在應用程式或監控層面自行實作限制或警示。