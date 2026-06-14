---
title: 使用 Java 以唯讀模式儲存簡報
linktitle: 唯讀簡報
type: docs
weight: 30
url: /zh-hant/java/read-only-presentation/
keywords:
- 唯讀
- 保護簡報
- 防止編輯
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 以唯讀模式載入和儲存 PowerPoint 檔案 (PPT、PPTX)，提供精確的投影片預覽，同時不會更改您的簡報。"
---
## **簡介**

在 PowerPoint 2019 中，Microsoft 推出了 **Always Open Read-Only** 設定，作為使用者保護簡報的選項之一。您可能會在以下情況下使用此唯讀設定來保護簡報：

- 您希望防止意外編輯，保持簡報內容的安全。  
- 您希望提醒他人您提供的簡報已是最終版本。

當您為簡報選取 **Always Open Read-Only** 選項後，使用者開啟簡報時會看到 **Read-Only** 建議，並可能看到如下訊息：*為防止意外變更，作者已將此檔案設定為唯讀開啟。*

**Read-Only** 建議是一種簡單卻有效的阻嚇手段，因為使用者必須執行移除動作才能編輯簡報。如果您不希望使用者對簡報進行修改，且想以禮貌的方式告知他們，**Read-Only** 建議可能是一個不錯的選擇。

> 若帶有 **Read-Only** 保護的簡報在不支援此功能的舊版 Microsoft PowerPoint 中開啟，**Read-Only** 建議將被忽略（簡報會正常開啟）。

## **套用唯讀模式**

Aspose.Slides for Java 允許您將簡報設定為 **Read-Only**，這表示使用者（開啟簡報後）會看到 **Read-Only** 建議。以下示範程式碼說明如何在 Java 中使用 Aspose.Slides 將簡報設定為 **Read-Only**：

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**注意**：**Read-Only** 建議僅用於阻止或減少使用者對 PowerPoint 簡報的意外變更。若有動機且懂得操作的人想編輯您的簡報，他們仍可輕易移除唯讀設定。如果您真的需要防止未授權的編輯，建議使用[更嚴格的加密與密碼保護](https://docs.aspose.com/slides/zh-hant/java/password-protected-presentation/)。

{{% /alert %}} 

## **常見問題**

**「Read-Only recommended」與完整密碼保護有何不同？**

「Read-Only recommended」僅顯示一個建議，提示使用者以唯讀模式開啟檔案，且容易繞過。[Password protection](/slides/zh-hant/java/password-protected-presentation/) 會真正限制開啟或編輯，適用於需要真正安全控制的情況。

**「Read-Only recommended」能否與浮水印結合，以進一步阻止編輯？**

可以。此建議可與[浮水印](/slides/zh-hant/java/watermark/) 搭配使用，作為視覺上的阻嚇；兩者屬於獨立機制，搭配使用效果良好。

**啟用建議後，巨集或外部工具仍能修改檔案嗎？**

可以。此建議不會阻止程式化的變更。若需防止自動化編輯，請使用[密碼與加密](/slides/zh-hant/java/password-protected-presentation/)。

**「Read-Only recommended」與 `isEncrypted` 與 `isWriteProtected` 方法有何關聯？**

它們傳達的訊號不同。「Read-Only recommended」是一種軟性、可選的提示；[`isWriteProtected`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/protectionmanager/#isWriteProtected--) 與 [`isEncrypted`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/protectionmanager/#isEncrypted--) 則表示實際的寫入或讀取限制，需依賴密碼或加密機制。