---
title: 在 Java 中使用密碼保護投影片
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/java/password-protected-presentation/
keywords:
- 鎖定 PowerPoint
- 鎖定投影片
- 解除鎖定 PowerPoint
- 解除鎖定投影片
- 保護 PowerPoint
- 保護投影片
- 設定密碼
- 添加密碼
- 加密 PowerPoint
- 加密投影片
- 解密 PowerPoint
- 解密投影片
- 寫入保護
- PowerPoint 安全性
- 投影片安全性
- 移除密碼
- 移除保護
- 移除加密
- 停用密碼
- 停用保護
- 移除寫入保護
- PowerPoint
- OpenDocument
- 投影片
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 輕鬆鎖定與解除鎖定受密碼保護的 PowerPoint 與 OpenDocument 投影片，保護您的投影片安全。"
---
## **簡介**

當您對投影片套用密碼保護時，表示您設定了一個密碼以對投影片套加特定限制。若要移除這些限制，必須輸入密碼。受密碼保護的投影片被視為已鎖定的投影片。

通常，您可以設定密碼來對投影片套加這些限制：

- **修改**
- **開啟**

### **修改**

如果您只想讓特定使用者修改您的投影片，您可以設定修改限制。此限制會阻止未提供密碼的人修改、變更或複製投影片中的元素。

然而，即使未提供密碼，使用者仍然可以存取並開啟您的文件。在此唯讀模式下，使用者可以檢視內容，包括超連結、動畫、效果及其他元素，但無法複製項目或儲存投影片。

### **開啟**

如果您只想讓特定使用者開啟您的投影片，您可以設定開啟限制。此限制會阻止未提供密碼的人甚至查看投影片內容。

技術上，開啟限制同時也會阻止使用者修改您的投影片——若無法開啟投影片，就無法進行修改或變更。

**注意：** 當您以密碼保護投影片以防止開啟時，投影片檔案會被加密。

## **Aspose.Slides 中的密碼保護**
**支援的格式**

Aspose.Slides 支援以下格式的投影片進行密碼保護、加密及類似操作：

- PPTX 與 PPT - Microsoft PowerPoint 簡報
- ODP - OpenDocument 簡報
- OTP - OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您以以下方式使用密碼保護投影片以防止修改：

- 加密投影片
- 設定寫入保護於投影片

**其他操作**

Aspose.Slides 允許您以以下方式執行其他與密碼保護和加密相關的任務：

- 解密投影片；開啟已加密的投影片
- 移除加密；停用密碼保護
- 從投影片移除寫入保護
- 取得已加密投影片的屬性
- 檢查投影片是否已加密
- 檢查投影片是否受密碼保護。

## **使用密碼保護投影片**

您可以透過設定密碼來加密投影片。之後，若要修改已鎖定的投影片，使用者必須提供密碼。

要加密或以密碼保護投影片，必須使用 encrypt 方法（來自[IProtectionManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager)）為投影片設定密碼。將密碼傳遞給 encrypt 方法，並使用 save 方法儲存已加密的投影片。

以下範例程式碼示範如何加密投影片：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **設定投影片的寫入保護**

您可以在投影片上加入「請勿修改」的標記，告訴使用者您不希望他們對投影片進行變更。

**注意**寫入保護過程不會加密投影片。因此，使用者若真的想修改投影片，仍可進行修改，只是要儲存變更時，必須以不同的名稱另存新檔。

要設定寫入保護，必須使用[setWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) 方法。以下範例程式碼示範如何為投影片設定寫入保護：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **載入已加密的投影片**

Aspose.Slides 允許您在傳遞密碼後載入已加密的檔案。若要解密投影片，必須呼叫[removeEncryption](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#removeEncryption--) 方法（不帶參數），然後輸入正確的密碼以載入投影片。

以下範例程式碼示範如何解密投影片：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 對已解密的投影片進行操作
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **從投影片移除加密**

您可以移除投影片的加密或密碼保護，讓使用者能在沒有任何限制的情況下存取或修改投影片。

要移除加密或密碼保護，必須呼叫[removeEncryption](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#removeEncryption--) 方法。以下範例程式碼示範如何從投影片移除加密：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **從投影片移除寫入保護**

您可以使用 Aspose.Slides 移除投影片檔案上的寫入保護。如此一來，使用者即可自由修改，且不會在執行此類操作時收到警告。

您可以透過呼叫[removeWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) 方法來移除寫入保護。以下範例程式碼示範如何從投影片移除寫入保護：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **取得已加密投影片的屬性**

通常使用者在取得已加密或受密碼保護投影片的文件屬性時會遇到困難。Aspose.Slides 提供了一種機制，允許您在對投影片加密的同時，仍保留使用者存取其屬性的能力。

**注意：** 預設情況下，Aspose.Slides 加密投影片時，投影片的文件屬性也會受到密碼保護。若您需要在加密後仍能存取文件屬性，Aspose.Slides 允許您這樣做。

如果您希望使用者在加密後仍能存取投影片的屬性，請將 `false` 傳遞給[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)。以下範例程式碼示範如何在加密投影片的同時仍提供使用者存取文件屬性的權限：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **僅從已加密投影片載入文件屬性**

若要在不載入投影片幻燈片或其他內容的情況下檢視已加密投影片的中繼資料，請建立一個[LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/) 物件，並將 `true` 傳遞給[setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-)。在此模式下，Aspose.Slides 會忽略密碼，只載入公開可存取的文件屬性。

以下程式碼示例透過[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getDocumentProperties--) 讀取內建與自訂文件屬性：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // 讀取內建文件屬性。
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // 讀取自訂文件屬性。
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

此工作流程僅在投影片加密時文件屬性保持未加密（公開）時有效。若文件屬性已加密，將 `true` 傳遞給 `loadOptions.setOnlyLoadDocumentProperties` 會導致例外，因為此模式會忽略密碼。若要存取已加密的文件屬性或載入完整的投影片（包括幻燈片及其他內容），請透過[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) 提供正確的密碼。

## **檢查投影片是否受密碼保護**

在載入投影片之前，您可能想先檢查並確認該投影片未受到密碼保護。這樣可避免在未提供密碼而載入受密碼保護的投影片時產生錯誤或相關問題。

以下 Java 程式碼示範如何在不實際載入投影片的情況下檢查投影片是否受密碼保護：

```java
IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **檢查投影片是否已加密**

Aspose.Slides 允許您檢查投影片是否已加密。您可以使用[isEncrypted](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#isEncrypted--) 屬性，若投影片已加密則回傳 `true`，否則回傳 `false`。

以下範例程式碼示範如何檢查投影片是否已加密：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **檢查投影片是否受寫入保護**

Aspose.Slides 允許您檢查投影片是否受寫入保護。您可以使用[isWriteProtected](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#isWriteProtected--) 屬性，若投影片受寫入保護則回傳 `true`，否則回傳 `false`。

以下範例程式碼示範如何檢查投影片是否受寫入保護：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **驗證或確認已使用特定密碼**

您可能想檢查並確認是否已使用特定密碼保護投影片文件。Aspose.Slides 提供了驗證密碼的功能。

以下範例程式碼示範如何驗證密碼：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // 檢查是否與 "pass" 匹配
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

若投影片已使用指定密碼加密，則回傳 `true`；否則回傳 `false`。

{{% alert color="primary" title="另請參閱" %}} 
- [PowerPoint 中的數位簽章](/slides/zh-hant/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的投影片資料具有高度的安全性。

**若在開啟投影片時輸入錯誤的密碼會發生什麼情況？**

系統會拋出例外，提示存取投影片被拒絕。此機制有助於防止未經授權的存取，保護投影片內容。

**使用受密碼保護的投影片會有哪些效能影響？**

加密與解密過程可能會在開啟與儲存時稍微增加一些負載。大多數情況下，此效能影響微乎其微，對整體處理時間影響不大。