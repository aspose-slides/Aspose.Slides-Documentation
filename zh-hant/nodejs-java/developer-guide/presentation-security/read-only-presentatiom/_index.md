---
title: 使用 JavaScript 以唯讀模式儲存簡報
linktitle: 唯讀簡報
type: docs
weight: 30
url: /zh-hant/nodejs-java/read-only-presentation/
keywords:
- 唯讀
- 保護簡報
- 防止編輯
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 以唯讀模式載入與儲存 PowerPoint 檔案，提供精確的投影片預覽而不會更改您的簡報。"
---
## **簡介**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 設定，作為使用者可用來保護簡報的選項之一。您可能想在以下情況使用此唯讀設定來保護簡報：

- 您希望防止意外編輯，並保持簡報內容的安全。 
- 您希望提醒他人，您提供的簡報是最終版。 

當您為簡報選取 **Always Open Read-Only** 選項後，使用者開啟簡報時，會看到 **Read-Only** 建議，並可能看到以下訊息：*為防止意外變更，作者已將此檔案設為唯讀開啟。*

Read-Only 建議是一種簡單但有效的阻止手段，因為使用者必須執行步驟才能移除它，才能編輯簡報。如果您不希望使用者對簡報進行修改，且想以禮貌的方式告知他們，Read-Only 建議可能是個不錯的選擇。 

> 如果帶有 **Read-Only** 保護的簡報在較舊的 Microsoft PowerPoint 應用程式中開啟──該程式不支援最近新增的功能──，**Read-Only** 建議會被忽略（簡報會正常開啟）。

## **套用唯讀模式**

Aspose.Slides for Node.js via Java 允許您將簡報設定為 **Read-Only**，這表示使用者（在開啟簡報後）會看到 **Read-Only** 建議。以下範例程式碼示範如何使用 Aspose.Slides 於 JavaScript 中將簡報設定為 **Read-Only**：

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Note**：**Read-Only** 建議僅用於阻止編輯或避免使用者對 PowerPoint 簡報造成意外變更。如果有動機且懂得操作的人決定編輯您的簡報，他們可以輕易移除唯讀設定。如果您真的需要防止未授權的編輯，最好使用[more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/zh-hant/nodejs-java/password-protected-presentation/)。 

{{% /alert %}} 

## **常見問題**

**「Read-Only recommended」與完整密碼保護有何不同？**

「Read-Only recommended」僅顯示在唯讀模式下開啟檔案的建議，且很容易繞過。[Password protection](/slides/zh-hant/nodejs-java/password-protected-presentation/) 真正限制開啟或編輯，適用於需要實際安全控制的情況。

**「Read-Only recommended」可以與浮水印結合以進一步阻止編輯嗎？**

可以。此建議可與[watermarks](/slides/zh-hant/nodejs-java/watermark/) 結合，作為視覺阻嚇；兩者是獨立機制，且能良好配合。

**啟用建議時，巨集或外部工具仍能修改檔案嗎？**

可以。此建議不會阻止程式化變更。若要防止自動化編輯，請使用[passwords and encryption](/slides/zh-hant/nodejs-java/password-protected-presentation/)。 

**「Read-Only recommended」與旗標「IsEncrypted」和「IsWriteProtected」有何關聯？**

它們是不同的訊號。「Read-Only recommended」屬於柔性、可選的提示；[isWriteProtected](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) 與 [isEncrypted](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/isencrypted/) 則表示實際的寫入或讀取限制，取決於密碼或加密。