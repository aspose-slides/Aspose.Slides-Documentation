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
description: "使用 Aspose.Slides for Java 以唯讀模式載入並儲存 PowerPoint 檔案（PPT、PPTX），提供精確的投影片預覽而不更動您的簡報。"
---
## **簡介**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 設定，作為使用者保護簡報的選項之一。您可能想在以下情況下使用此唯讀設定來保護簡報：

- 您想防止意外編輯，並確保簡報內容的安全。 
- 您想提醒使用者您提供的簡報是最終版本。 

在您為簡報選取 **Always Open Read-Only** 選項後，使用者開啟簡報時會看到 **Read-Only** 建議，並可能看到以下訊息：*為防止意外變更，作者已將此檔案設定為唯讀開啟。*

**Read-Only** 建議是一個簡單且有效的阻嚇手段，因為使用者必須先執行動作才能移除它，才可編輯簡報。如果您不希望使用者對簡報進行變更，並希望以禮貌的方式提醒他們，則 **Read-Only** 建議可能是您的好選擇。 

> 如果帶有 **Read-Only** 保護的簡報在較舊的 Microsoft PowerPoint 應用程式中開啟——該程式不支援最近引入的功能——則 **Read-Only** 建議會被忽略（簡報會正常開啟）。

## **套用唯讀模式**

Aspose.Slides for Java 允許您將簡報設定為 **Read-Only**，這表示使用者（在開啟簡報後）會看到 **Read-Only** 建議。以下範例程式碼示範如何使用 Aspose.Slides 在 Java 中將簡報設定為 **Read-Only**：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**注意**: **Read-Only** 建議僅用於阻止編輯或避免使用者對 PowerPoint 簡報造成意外變更。如果有意圖且懂得操作的人決定編輯您的簡報，他們可以輕易移除唯讀設定。如果您真的需要防止未經授權的編輯，建議使用[更嚴格的加密與密碼保護](https://docs.aspose.com/slides/zh-hant/java/password-protected-presentation/)。 

{{% /alert %}} 

## **常見問題**

### 「Read-Only recommended」與完整密碼保護有何不同？

「Read-Only recommended」僅顯示以唯讀模式開啟檔案的建議，且容易繞過。[密碼保護](/slides/zh-hant/java/password-protected-presentation/)實際限制開啟或編輯，適用於您需要真正安全控制的情況。

### 「Read-Only recommended」是否可以與浮水印結合，以進一步阻止編輯？

可以。「Read-Only recommended」可以與[浮水印](/slides/zh-hant/java/watermark/)搭配使用，作為視覺阻嚇；兩者屬於不同機制，且能良好協同。

### 啟用建議時，巨集或外部工具仍能修改檔案嗎？

可以。此建議不會阻止程式化的變更。若要防止自動化編輯，請使用[密碼與加密](/slides/zh-hant/java/password-protected-presentation/)。

### 「Read-Only recommended」與 'isEncrypted' 與 'isWriteProtected' 方法有何關係？

它們是不同的訊號。「Read-Only recommended」是一個軟性、可選的提示；[isWriteProtected](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/protectionmanager/#isWriteProtected--) 與 [isEncrypted](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/protectionmanager/#isEncrypted--) 表示實際的寫入或讀取限制，這些限制取決於密碼或加密。