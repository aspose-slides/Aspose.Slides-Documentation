---
title: 計量授權
type: docs
weight: 90
url: /zh-hant/python-net/metered-licensing/
keywords:
- 授權
- 計量授權
- 授權金鑰
- 公鑰
- 私鑰
- 消耗量
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python 透過 .NET 計量授權，如何讓您彈性處理 PowerPoint 與 OpenDocument 檔案，僅為實際使用量付費。"
---
## **簡介**

Metered licensing 是一種可與現有授權方式並用的授權機制。如果您希望根據使用 Aspose.Slides API 功能的情況計費，請選擇 metered licensing。

## **套用 Metered 金鑰**

{{% alert color="primary" %}} 

Metered licensing 是一種可與現有授權方式並用的全新授權機制。如果您希望根據使用 Aspose.Slides API 功能的情況計費，請選擇 metered licensing。

購買 metered 授權時，您會取得金鑰（而非授權檔案）。可以使用 Aspose 提供的 [Metered](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/metered/) 類別來套用此 metered 金鑰。欲了解更多細節，請參閱 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 建立 [Metered](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/metered/) 類別的執行個體。  
2. 將您的公鑰與私鑰傳入 [set_metered_key](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/metered/set_metered_key/#str-str) 方法。  
3. 執行一些處理（執行任務）。  
4. 呼叫 `Metered` 類別的 [get_consumption_quantity](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/metered/get_consumption_quantity/#) 方法。

您將會看到目前已消耗的 API 請求數量/金額。

以下範例程式碼示範如何使用 metered licensing：

```python
import aspose.slides as slides

# 建立 Metered 類別的實例
metered = slides.Metered()

# 將公鑰與私鑰傳入 Metered 物件
metered.set_metered_key("<valid public key>", "<valid private key>")

# 在 API 呼叫前取得已消耗的數量
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# 在此使用 Aspose.Slides API 執行一些操作
# ...

# 在 API 呼叫後取得已消耗的數量
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

使用 metered licensing 必須具備穩定的網際網路連線，因為授權機制會透過網路持續與我們的服務互動並執行計算。

{{% /alert %}} 

## **常見問題**

**我可以在同一個應用程式中同時使用 metered 授權與一般（永久或臨時）授權嗎？**

可以。Metered 是可與現有 [授權方法](/slides/zh-hant/python-net/licensing/) 並存的額外授權機制。您可以在應用程式啟動時決定要使用哪一種機制。

**在 metered 授權下，究竟是計算操作次數還是檔案數量？**

計算的是 API 使用情形，即請求或操作的次數。您可以透過 [consumption‑tracking 方法](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/metered/) 取得目前的消耗量。

**Metered 是否適用於經常重新啟動的微服務或無伺服器環境？**

適用。由於計費是以 API 呼叫層級進行統計，只要有穩定的網路連線以供 metered 計算，即可相容於頻繁的冷啟動情境。

**使用 metered 授權時，函式庫的功能是否會與永久授權不同？**

不會。這僅是授權與計費機制的差異，產品功能本身保持相同。

**Metered 與試用版及臨時授權之間的關係是什麼？**

試用版有功能限制與浮印；[臨時授權](https://purchase.aspose.com/temporary-license/) 可在 30 天內移除限制；metered 則移除限制，且依實際使用量收費。

**我能否在超過消費閾值時自動執行動作以控制預算？**

可以。常見做法是定期透過 [追蹤方法](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/metered/) 讀取目前消耗量，並在應用程式或監控層面實作自訂的限制或警示。