---
title: 在 .NET 中將簡報儲存為唯讀模式
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
description: "使用 Aspose.Slides for .NET 以唯讀模式載入和儲存 PowerPoint 檔案（PPT、PPTX），在不更動簡報的情況下提供精確的投影片預覽。"
---
## **簡介**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 設定，作為使用者保護簡報的選項之一。您可能會想使用此唯讀設定來保護簡報，當

- 您想防止意外編輯並確保簡報內容安全。  
- 您想提醒使用者您提供的簡報是最終版本。  

在為簡報選取 **Always Open Read-Only** 選項後，使用者開啟簡報時，會看到 **Read-Only** 建議，並可能看到以下訊息：*To prevent accidental changes, the author has set this file to open as read-only.*

**Read-Only** 建議是一種簡單卻有效的阻嚇方式，因為使用者必須執行特定動作才能移除它，才允許編輯簡報。如果您不希望使用者對簡報進行修改，且想以禮貌的方式告知他們，那麼 **Read-Only** 建議可能是個不錯的選擇。

> 若以較舊的 Microsoft PowerPoint 應用程式開啟具 **Read-Only** 保護的簡報——該版本不支援近期推出的功能——則會忽略 **Read-Only** 建議（簡報會正常開啟）。

## **套用唯讀模式**

Aspose.Slides for .NET 允許您將簡報設定為 **Read-Only**，也就是說使用者（開啟簡報後）會看到 **Read-Only** 建議。以下範例程式碼示範如何使用 Aspose.Slides 在 C# 中將簡報設定為 **Read-Only**：

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Note**: **Read-Only** 建議僅用於阻嚇編輯或防止使用者對 PowerPoint 簡報進行意外變更。若有動機且懂行的人決定編輯您的簡報，他們仍能輕易移除唯讀設定。如果您真的需要防止未授權的編輯，建議使用[更嚴格的加密與密碼保護](https://docs.aspose.com/slides/zh-hant/net/password-protected-presentation/)。 

{{% /alert %}} 

## **常見問題**

**「Read-Only recommended」與完整密碼保護有何不同？**

「Read-Only recommended」僅會顯示建議以唯讀模式開啟檔案，且易於繞過。[密碼保護](/slides/zh-hant/net/password-protected-presentation/)則真正限制開啟或編輯，適用於需要實際安全控制的情況。

**「Read-Only recommended」可以與浮水印結合以進一步阻止編輯嗎？**

可以。此建議可搭配[浮水印](/slides/zh-hant/net/watermark/)作為視覺阻嚇；兩者是獨立機制，能良好協同運作。

**啟用建議後，巨集或外部工具仍能修改檔案嗎？**

可以。此建議不會阻止程式化的變更。若要防止自動化編輯，請使用[密碼與加密](/slides/zh-hant/net/password-protected-presentation/)。 

**「Read-Only recommended」與「IsEncrypted」及「IsWriteProtected」旗標有何關聯？**

它們是不同的訊號。「Read-Only recommended」屬於軟性、可選的提示；[IsWriteProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/iswriteprotected/) 與 [IsEncrypted](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/isencrypted/) 則表示依賴密碼或加密的實際寫入或讀取限制。