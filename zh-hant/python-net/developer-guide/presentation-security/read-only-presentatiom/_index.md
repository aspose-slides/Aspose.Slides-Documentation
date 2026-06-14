---
title: 使用 Python 以唯讀模式儲存投影片
linktitle: 唯讀投影片
type: docs
weight: 30
url: /zh-hant/python-net/read-only-presentation/
keywords:
- 唯讀
- 保護投影片
- 防止編輯
- PowerPoint
- 投影片
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 以唯讀模式載入並儲存 PowerPoint 檔案（PPT、PPTX），提供精確的投影片預覽，且不會更改您的投影片。"
---
## **簡介**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 設定，作為使用者用來保護投影片的選項之一。當您想要使用此唯讀設定來保護投影片時，可能出於以下情況：

- 您希望防止意外編輯並保持投影片內容的安全。 
- 您希望提醒他人您提供的投影片是最終版本。 

當您為投影片選取 **Always Open Read-Only** 選項後，使用者開啟投影片時，會看到 **Read-Only** 的建議，並可能看到以下訊息：*為防止意外變更，作者已設定此檔案以唯讀方式開啟。*

**Read-Only** 建議是一種簡單但有效的阻嚇手段，因為使用者必須執行額外步驟才能移除它，才能編輯投影片。若您不希望使用者對投影片進行變更，且想以禮貌的方式告知他們，**Read-Only** 建議可能是適合的選擇。 

> 若含有 **Read-Only** 保護的投影片在較舊的 Microsoft PowerPoint 應用程式中開啟—該應用程式不支援此新功能—則會忽略 **Read-Only** 建議（投影片會正常開啟）。

## **套用唯讀模式**

Aspose.Slides for Python via .NET 允許您將投影片設定為 **Read-Only**，此設定讓使用者（開啟投影片後）會看到 **Read-Only** 建議。以下範例程式碼示範如何在 Python 中使用 Aspose.Slides 將投影片設定為 **Read-Only**：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**注意**：**Read-Only** 建議僅用於阻止編輯或避免使用者對 PowerPoint 投影片造成意外變更。若有動機且懂得操作的人決定編輯您的投影片，他們仍然可以輕易移除唯讀設定。若您需要嚴格防止未授權的編輯，建議使用[更嚴格的加密與密碼保護](https://docs.aspose.com/slides/zh-hant/python-net/password-protected-presentation/)。 

{{% /alert %}} 

## **常見問題**

**Read-Only recommended** 與完整密碼保護有何不同？

`Read-Only recommended` 僅顯示建議以唯讀模式開啟檔案，且容易繞過。[密碼保護](/slides/zh-hant/python-net/password-protected-presentation/) 真正限制開啟或編輯，適用於需要真正安全控制的情況。

**Read-Only recommended** 可以與浮水印結合以進一步阻止編輯嗎？

可以。此建議可與 [浮水印](/slides/zh-hant/python-net/watermark/) 結合，作為視覺阻嚇；兩者屬於獨立機制，能良好協同。

**Read-Only recommended** 啟用時，巨集或外部工具仍能修改檔案嗎？

可以。此建議不會阻止程式化的變更。若要防止自動化編輯，請使用 [密碼與加密](/slides/zh-hant/python-net/password-protected-presentation/)。 

**Read-Only recommended** 與旗標 `is_encrypted` 與 `is_write_protected` 有何關聯？

它們是不同的訊號。`Read-Only recommended` 為軟性、可選的提示；[is_write_protected](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/is_write_protected/) 與 [is_encrypted](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/is_encrypted/) 則表示實際的寫入或讀取限制，取決於密碼或加密。