---
title: 在 Android 上使用密碼保護簡報的安全性
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/androidjava/password-protected-presentation/
keywords:
- 鎖定 PowerPoint
- 鎖定簡報
- 解鎖 PowerPoint
- 解鎖簡報
- 保護 PowerPoint
- 保護簡報
- 設定密碼
- 新增密碼
- 加密 PowerPoint
- 加密簡報
- 解密 PowerPoint
- 解密簡報
- 寫入保護
- PowerPoint 安全性
- 簡報安全性
- 移除密碼
- 移除保護
- 移除加密
- 停用密碼
- 停用保護
- 移除寫入保護
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（透過 Java），輕鬆鎖定與解鎖受密碼保護的 PowerPoint 與 OpenDocument 簡報。保護您的簡報。"
---
## **介紹**

當您為簡報設定密碼保護時，即是設定一組密碼以對簡報實施特定限制。要解除這些限制，必須輸入密碼。受密碼保護的簡報被視為已鎖定的簡報。

通常，您可以設定密碼以對簡報施加以下限制：

- **修改**

  若您只希望特定使用者修改您的簡報，可設定修改限制。此限制會阻止使用者在未提供密碼的情況下修改、變更或複製簡報中的內容。

  但是，即使未輸入密碼，使用者仍能存取並開啟文件。於唯讀模式下，使用者可以檢視簡報內的內容或元素（超連結、動畫、特效等），但無法複製項目或儲存簡報。

- **開啟**

  若您只希望特定使用者開啟您的簡報，可設定開啟限制。此限制會阻止使用者查看簡報內容（除非提供密碼）。

  從技術上說，開啟限制同時也阻止使用者修改簡報：當使用者無法開啟簡報時，便無法對其進行修改或變更。

  **注意** 當您以密碼保護方式阻止簡報開啟時，簡報檔案會被加密。

## **Aspose.Slides 中的簡報密碼保護**
**支援的格式**

Aspose.Slides 支援以下格式的簡報進行密碼保護、加密及類似操作：

- PPTX 與 PPT – Microsoft PowerPoint 簡報
- ODP – OpenDocument 簡報
- OTP – OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您以以下方式使用密碼保護防止簡報被修改：

- 加密簡報
- 為簡報設定寫入保護

**其他操作**

Aspose.Slides 亦提供以下涉及密碼保護與加密的功能：

- 解密簡報；開啟加密的簡報
- 移除加密；停用密碼保護
- 從簡報移除寫入保護
- 取得加密簡報的屬性
- 檢查簡報是否已加密
- 檢查簡報是否已設定密碼保護

## **加密簡報**

您可以透過設定密碼來加密簡報。之後，若要修改已鎖定的簡報，使用者必須提供密碼。

要加密或設定密碼保護，必須使用 `encrypt` 方法（來自[IProtectionManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager)）為簡報設定密碼。將密碼傳入 `encrypt` 方法，然後使用 `save` 方法儲存已加密的簡報。

以下範例程式碼示範如何加密簡報：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **為簡報設定寫入保護**

您可以在簡報中加入「請勿修改」的標記，告訴使用者不要對簡報作變更。

**注意** 寫入保護的過程不會加密簡報。因此，使用者若真的想修改簡報，仍可進行，但要儲存變更時必須另存為不同名稱的檔案。

要設定寫入保護，必須使用[setWriteProtection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) 方法。以下範例程式碼示範如何為簡報設定寫入保護：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **載入加密的簡報**

Aspose.Slides 允許您在傳入密碼後載入加密檔案。若要解密簡報，必須呼叫[removeEncryption](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) 方法且不傳入參數。之後您需要輸入正確的密碼才能載入簡報。

以下範例程式碼示範如何解密簡報：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 使用已解密的簡報
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **從簡報中移除加密**

您可以移除簡報的加密或密碼保護，讓使用者在無限制的情況下存取或修改簡報。

要移除加密或密碼保護，必須呼叫[removeEncryption](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) 方法。以下範例程式碼示範如何從簡報中移除加密：

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

## **從簡報中移除寫入保護**

您可以使用 Aspose.Slides 移除簡報檔案上的寫入保護。如此一來，使用者即可隨意修改，且不會收到任何警告。

您可以透過呼叫[removeWriteProtection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) 方法移除寫入保護。以下範例程式碼示範如何從簡報中移除寫入保護：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **取得加密簡報的屬性**

通常使用者在取得已加密或受密碼保護的簡報文件屬性時會遇到困難。然而，Aspose.Slides 提供了一種機制，允許您在保護簡報密碼的同時，仍讓使用者存取其屬性。

**注意:** 預設情況下，Aspose.Slides 加密簡報時，簡報的文件屬性也會被密碼保護。如果您需要在加密後仍能存取文件屬性，Aspose.Slides 允許您這樣做。

若您希望使用者在簡報加密後仍能存取其屬性，請將 `false` 傳入[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)。以下範例程式碼示範如何在仍提供文件屬性存取的前提下加密簡報：

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

## **僅從加密的簡報載入文件屬性**

若只想檢查加密簡報的中繼資料而不載入投影片或其他內容，請建立一個[LoadOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/) 物件，並將 `true` 傳入[setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-)。在此模式下，Aspose.Slides 會忽略密碼，只載入可公開存取的文件屬性。

以下程式碼範例透過[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 讀取內建與自訂文件屬性：

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

此工作流程僅在文件屬性在加密簡報時被保留為未加密（公開）時有效。若文件屬性已加密，將 `true` 傳入 `loadOptions.setOnlyLoadDocumentProperties` 會拋出例外，因為此模式會忽略密碼。若需存取加密的文件屬性或載入完整簡報（包括投影片與其他內容），請透過[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) 提供正確的密碼。

## **檢查簡報是否受密碼保護**

在載入簡報之前，您可能想先確認簡報是否已設定密碼保護。如此可避免在未提供密碼的情況下載入受保護簡報時產生錯誤與相關問題。

以下 Java 程式碼示範如何在不載入簡報本身的情況下檢查其是否受密碼保護：

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。您可以使用[isEncrypted](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) 屬性，若簡報已加密則回傳 `true`，未加密則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否已加密：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **檢查簡報是否受寫入保護**

Aspose.Slides 允許您檢查簡報是否受寫入保護。您可以使用[isWriteProtected](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) 屬性，若簡報受寫入保護則回傳 `true`，否則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否受寫入保護：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **驗證或確認已使用特定密碼**

您可能想驗證並確認已使用特定密碼保護簡報文件。Aspose.Slides 提供驗證密碼的功能。

以下範例程式碼示範如何驗證密碼：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // 檢查 "pass" 是否匹配
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

若簡報已使用指定密碼加密，則回傳 `true`；否則回傳 `false`。

{{% alert color="primary" title="See also" %}} 
- [PowerPoint 中的數位簽章](/slides/zh-hant/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的簡報資料具有高等級的安全性。

**若在開啟簡報時輸入錯誤的密碼會發生什麼事？**

系統會拋出例外，提示存取簡報被拒絕。此機制有助於防止未經授權的存取，保護簡報內容。

**在處理受密碼保護的簡報時會有性能影響嗎？**

加密與解密過程可能在開啟與儲存時產生輕微開銷。大多數情況下，這種性能影響微乎其微，對整體處理時間影響不大。