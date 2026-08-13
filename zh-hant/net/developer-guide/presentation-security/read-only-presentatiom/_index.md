---
title: 在 .NET 中以唯讀模式儲存簡報
linktitle: 唯讀簡報
type: docs
weight: 30
url: /zh-hant/net/read-only-presentation/
keywords:
- 唯讀
- 保護簡報
- 防止編輯
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 以唯讀模式載入和儲存 PowerPoint 檔案（PPT、PPTX），提供精確的投影片預覽且不會更改您的簡報。"
---
## **簡介**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 設定，作為使用者保護簡報的選項之一。您可能想在以下情況使用此唯讀設定來保護簡報：

- 您希望防止意外編輯，保護簡報內容的安全。  
- 您希望提醒他人您提供的簡報已是最終版本。

當您為簡報選取 **Always Open Read-Only** 選項後，使用者開啟簡報時會看到 **Read-Only** 的建議，並可能出現如下訊息：*為防止意外變更，作者已將此檔案設定為唯讀開啟。*

唯讀建議是一種簡單但有效的阻嚇措施，因為使用者必須先移除它才能編輯簡報。如果您不希望使用者對簡報進行變更，且想以禮貌的方式告知他們，唯讀建議可能是個不錯的選擇。

> 若含有 **Read-Only** 保護的簡報在較舊的 Microsoft PowerPoint 應用程式中開啟（該版本不支援此新功能），則 **Read-Only** 建議會被忽略（簡報會正常開啟）。

## **套用唯讀模式**

Aspose.Slides for .NET 允許您將簡報設定為 **Read-Only**，也就是使用者（開啟簡報後）會看到 **Read-Only** 的建議。以下範例程式碼示範如何使用 C# 透過 Aspose.Slides 將簡報設定為 **Read-Only**：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**注意**：**Read-Only** 建議僅是用來阻嚇編輯或防止使用者對 PowerPoint 簡報造成意外變更。如果有動機且懂得操作的人想編輯您的簡報，他們仍能輕易移除唯讀設定。若您確實需要防止未授權的編輯，建議改用[更嚴格的加密與密碼保護](https://docs.aspose.com/slides/zh-hant/net/password-protected-presentation/)。

{{% /alert %}} 

## **常見問題**

### 「Read-Only recommended」與完整密碼保護有何不同？

「Read-Only recommended」僅顯示建議將檔案以唯讀模式開啟，且容易繞過。[密碼保護](/slides/zh-hant/net/password-protected-presentation/)實際限制開啟或編輯，適用於需要真正安全控制的情況。

### 「Read-Only recommended」可以與浮水印結合以進一步阻嚇編輯嗎？

可以。此建議可與[浮水印](/slides/zh-hant/net/watermark/)一起使用，作為視覺阻嚇；兩者為獨立機制，能相互配合。

### 啟用此建議後，巨集或外部工具仍能修改檔案嗎？

會。此建議不會阻止程式化的變更。若要防止自動化編輯，請使用[密碼與加密](/slides/zh-hant/net/password-protected-presentation/)。

### 「Read-Only recommended」與「IsEncrypted」與「IsWriteProtected」旗標有何關聯？

它們是不同的訊號。「Read-Only recommended」屬於軟性、可選的提示；[IsWriteProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/iswriteprotected/)與[IsEncrypted](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/isencrypted/)則表示實際的寫入或讀取限制，需依賴密碼或加密。