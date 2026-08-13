---
title: 在 Android 上以唯讀模式儲存簡報
linktitle: 唯讀簡報
type: docs
weight: 30
url: /zh-hant/androidjava/read-only-presentation/
keywords:
- 唯讀
- 保護簡報
- 防止編輯
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 以唯讀模式儲存 PowerPoint 檔案（PPT、PPTX），提供精確的投影片預覽而不會更改您的簡報。"
---
## **簡介**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 設定，作為使用者用來保護簡報的選項之一。當以下情況時，您可能想使用此唯讀設定來保護簡報：

- 您希望防止意外編輯，並保護簡報內容的安全。 
- 您希望提醒他人您提供的簡報已是最終版本。 

在為簡報選取 **Always Open Read-Only** 選項後，使用者開啟簡報時，會看到 **Read-Only** 建議，並可能顯示以下訊息：*為防止意外變更，作者已將此檔案設定為唯讀開啟。*

**Read-Only** 建議是一種簡單卻有效的阻嚇手段，因為使用者必須先執行移除動作才可編輯簡報。若您不希望使用者對簡報進行變更，且想以禮貌的方式告知他們，**Read-Only** 建議可能是適合的選擇。 

> 如果帶有 **Read-Only** 保護的簡報在較舊的 Microsoft PowerPoint 應用程式中開啟（該版本不支援近期新增的功能），則 **Read-Only** 建議會被忽略（簡報會正常開啟）。

## **套用唯讀模式**

Aspose.Slides for Android via Java 允許您將簡報設定為 **Read-Only**，這表示使用者（在開啟簡報後）會看到 **Read-Only** 建議。下列範例程式碼示範如何使用 Aspose.Slides 於 Java 中將簡報設定為 **Read-Only**：

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

**注意**：**Read-Only** 建議僅用於阻止編輯或避免使用者對 PowerPoint 簡報造成意外變更。若有動機且具備相關知識的人決定編輯您的簡報，他們可以輕易移除唯讀設定。若您必須嚴格防止未授權的編輯，建議採用 [更嚴格的加密與密碼保護](https://docs.aspose.com/slides/zh-hant/androidjava/password-protected-presentation/)。

{{% /alert %}} 

## **常見問題**

### 「Read-Only recommended」與完整密碼保護有何不同？

「Read-Only recommended」僅顯示以唯讀模式開啟檔案的建議，且容易繞過。[密碼保護](/slides/zh-hant/androidjava/password-protected-presentation/) 會實際限制開啟或編輯，適用於需要真正安全控制的情況。

### 「Read-Only recommended」是否可與浮水印結合以進一步阻止編輯？

可以。「Read-Only recommended」可與 [浮水印](/slides/zh-hant/androidjava/watermark/) 結合，作為視覺阻嚇；兩者為獨立機制，且能良好協同。

### 啟用建議時，巨集或外部工具仍能修改檔案嗎？

可以。此建議並未阻止程式化的變更。若要防止自動化編輯，請使用 [密碼與加密](/slides/zh-hant/androidjava/password-protected-presentation/)。

### 「Read-Only recommended」與方法 'isEncrypted' 與 'isWriteProtected' 有何關聯？

它們傳遞不同的訊號。「Read-Only recommended」屬於軟性、可選的提示；[isWriteProtected](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) 與 [isEncrypted](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) 則表示實際的寫入或讀取限制，這些限制取決於密碼或加密。