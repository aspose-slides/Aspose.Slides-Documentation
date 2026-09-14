---
title: 使用 Python 以唯讀模式儲存簡報
linktitle: 唯讀簡報
type: docs
weight: 30
url: /zh-hant/python-java/read-only-presentation/
keywords:
- 唯讀
- 保護簡報
- 防止編輯
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在唯讀模式下載入並儲存 PowerPoint 檔案 (PPT、PPTX)，提供精確的投影片預覽且不會更改您的簡報。"
---
## **簡介**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 設定，作為使用者可用來保護簡報的選項之一。當以下情況時，您可能想使用此唯讀設定來保護簡報：

- 您希望防止意外編輯，並保持簡報內容的安全。
- 您希望告知他人您提供的簡報是最終版本。

在為簡報選取 **Always Open Read-Only** 選項之後，使用者開啟簡報時，會看到 **Read-Only** 建議，並可能看到以下訊息：*為防止意外變更，作者已將此檔案設定為唯讀開啟。*

Read-Only 建議是一種簡單且有效的阻嚇手段，因為使用者必須執行某些步驟才能移除它，才能編輯簡報。如果您不希望使用者更改簡報，且想以禮貌的方式告知他們，Read-Only 建議可能是一個不錯的選擇。

> 若具有 **Read-Only** 保護的簡報在較舊的 Microsoft PowerPoint 應用程式中開啟（該版本不支援最近推出的功能），則 **Read-Only** 建議會被忽略（簡報會正常開啟）。

## **套用唯讀模式**

Aspose.Slides for Python via Java 允許您將簡報設定為 **Read-Only**，這表示使用者（開啟簡報後）會看到 **Read-Only** 建議。以下範例程式碼示範如何在 Python 中使用 Aspose.Slides 將簡報設定為 **Read-Only**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
**Read-Only** 建議僅用於阻止編輯或防止使用者對 PowerPoint 簡報造成意外變更。若有動機且懂行的人決定編輯您的簡報，他們可以輕易移除唯讀設定。如果您真的需要防止未授權的編輯，建議改用[更嚴格的加密與密碼保護](/slides/zh-hant/python-java/password-protected-presentation/)。 
{{% /alert %}} 

## **常見問題**

**「Read-Only recommended」與完整密碼保護有何不同？**  
「Read-Only recommended」僅顯示將檔案以唯讀模式開啟的建議，且容易繞過。[密碼保護](/slides/zh-hant/python-java/password-protected-presentation/)實際限制開啟或編輯，當您需要真正的安全控制時適用。

**「Read-Only recommended」可以與浮水印結合以進一步阻止編輯嗎？**  
是的。此建議可以與[浮水印](/slides/zh-hant/python-java/watermark/)結合，作為視覺阻嚇；兩者屬於不同機制，能良好協同。

**啟用此建議後，巨集或外部工具仍能修改檔案嗎？**  
是的。此建議不會阻止程式化的變更。若要防止自動化編輯，請使用[密碼與加密](/slides/zh-hant/python-java/password-protected-presentation/)。

**「Read-Only recommended」與方法 [isEncrypted](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#isEncrypted) 以及 [isWriteProtected](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#isWriteProtected) 有何關聯？**  
它們傳遞的訊號不同。「Read-Only recommended」屬於軟性、可選的提示；[isWriteProtected](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#isWriteProtected) 以及 [isEncrypted](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#isEncrypted) 表示依賴密碼或加密的實際寫入或讀取限制。