---
title: 使用 Java 的密碼保護安全簡報
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/java/password-protected-presentation/
keywords:
- 鎖定 PowerPoint
- 鎖定簡報
- 解除鎖定 PowerPoint
- 解除簡報鎖定
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 輕鬆鎖定與解除鎖定受密碼保護的 PowerPoint 與 OpenDocument 簡報。保護您的簡報。"
---
## **簡介**

當您為簡報設定密碼保護時，即是設定一組密碼來對簡報施加特定限制。若要移除這些限制，必須輸入密碼。受密碼保護的簡報被視為已鎖定的簡報。

通常，您可以設定密碼以對簡報實施這些限制：

- **修改**
  
  如果您只想讓特定使用者修改您的簡報，您可以設定修改限制。此限制會阻止使用者在未提供密碼的情況下修改、變更或複製簡報中的元素。  
  
  然而，即使沒有密碼，使用者仍能存取並開啟您的文件。於唯讀模式下，使用者可以檢視內容——包括超連結、動畫、效果及其他元素——但無法複製項目或儲存簡報。

- **開啟**
  
  如果您只想讓特定使用者開啟您的簡報，您可以設定開啟限制。此限制會阻止使用者在未提供密碼的情況下檢視簡報內容。  
  
  技術上，開啟限制同時也會阻止使用者修改簡報——若無法開啟簡報，就無法對其進行修改或變更。

**注意：** 當您以密碼保護簡報以防止開啟時，簡報檔案會被加密。

## **Aspose.Slides 中的密碼保護**

**支援的格式**

Aspose.Slides 支援對以下格式的簡報執行密碼保護、加密與類似操作：

- PPTX 和 PPT - Microsoft PowerPoint 簡報
- ODP - OpenDocument 簡報
- OTP - OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您以以下方式對簡報使用密碼保護以防止修改：

- 加密簡報
- 為簡報設定寫入保護

**其他操作**

Aspose.Slides 讓您以以下方式執行其他與密碼保護與加密相關的工作：

- 解密簡報；開啟已加密的簡報
- 移除加密；停用密碼保護
- 移除簡報的寫入保護
- 取得已加密簡報的屬性
- 檢查簡報是否已加密
- 檢查簡報是否受密碼保護。

## **以密碼保護簡報**

您可以透過設定密碼來加密簡報。之後，若要修改已鎖定的簡報，使用者必須提供密碼。

若要加密或以密碼保護簡報，您必須使用 encrypt 方法（來自[IProtectionManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager)）為簡報設定密碼。將密碼傳遞給 encrypt 方法，然後使用 save 方法儲存已加密的簡報。

以下範例程式碼示範如何加密簡報：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **為簡報設定寫入保護**

您可以在簡報上加入「請勿修改」的標記。藉此告知使用者您不希望他們更改簡報內容。

**注意**：寫入保護過程不會加密簡報。因此，使用者若真的想修改簡報，仍然可以這麼做，但若要儲存變更，必須另存為不同名稱的簡報。

若要設定寫入保護，您必須使用 [setWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) 方法。以下範例程式碼示範如何為簡報設定寫入保護：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **載入已加密的簡報**

Aspose.Slides 允許您透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/) 傳入正確的密碼來載入已加密的簡報。

以下範例程式碼示範如何載入已加密的簡報：

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 在已解密的簡報中工作
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **從簡報中移除加密**

您可以移除簡報的加密或密碼保護。如此一來，使用者即可在無限制的情況下存取或修改簡報。

若要移除加密或密碼保護，您必須呼叫 [removeEncryption](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#removeEncryption--) 方法。以下範例程式碼示範如何從簡報中移除加密：

```java
import com.aspose.slides.*;

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

您可使用 Aspose.Slides 移除簡報檔案上的寫入保護。如此一來，使用者可隨意修改，且不會在執行此類操作時收到警告。

您可以透過使用 [removeWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) 方法來移除簡報的寫入保護。以下範例程式碼示範如何移除簡報的寫入保護：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **取得已加密簡報的屬性**

通常，使用者在取得已加密或受密碼保護的簡報的文件屬性時會遇到困難。然而，Aspose.Slides 提供了一種機制，使您在對簡報設定密碼保護的同時，仍保留使用者存取其屬性的能力。

**注意：** 預設情況下，Aspose.Slides 加密簡報時，簡報的文件屬性也會受到密碼保護。若您需要在加密後仍能存取文件屬性，Aspose.Slides 允許您這麼做。

若您希望使用者仍能存取已加密簡報的屬性，請將 `false` 傳遞給 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 方法。以下範例程式碼示範如何在加密簡報的同時仍提供使用者存取其文件屬性：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **僅載入已加密簡報的文件屬性**

若要在不載入投影片或其他內容的情況下檢查已加密簡報的中繼資料，請建立一個 [LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/) 物件，並將 `true` 傳遞給 [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-)。在此模式下，Aspose.Slides 會忽略密碼，僅載入公開可存取的文件屬性。

以下程式碼範例透過 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getDocumentProperties--) 讀取內建與自訂文件屬性：

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

此工作流程僅在簡報加密時文件屬性保持未加密（公開）時有效。若文件屬性已加密，將 `true` 傳遞給 `loadOptions.setOnlyLoadDocumentProperties` 會導致例外，因為此模式會忽略密碼。若要存取已加密的文件屬性或載入完整簡報（包括投影片與其他內容），請透過 [ILoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) 提供正確的密碼。

## **檢查簡報是否受密碼保護**

在載入簡報之前，您可能希望先檢查並確認簡報是否已被密碼保護。如此一來，可避免在未提供密碼而載入受密碼保護的簡報時發生錯誤與相關問題。

以下 Java 程式碼示範如何檢查簡報是否受密碼保護（不載入簡報本身）：

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。執行此任務時，可使用 [isEncrypted](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#isEncrypted--) 屬性，若簡報已加密則回傳 `true`，未加密則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否已加密：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **檢查簡報是否受寫入保護**

Aspose.Slides 允許您檢查簡報是否受寫入保護。執行此任務時，可使用 [isWriteProtected](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#isWriteProtected--) 屬性，若簡報受寫入保護則回傳 `true`，否則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否受寫入保護：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **驗證或確認已使用特定密碼**

您可能想要檢查並確認已使用特定密碼來保護簡報文件。Aspose.Slides 提供驗證密碼的方式。

以下範例程式碼示範如何驗證密碼：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // 檢查 "pass" 是否匹配
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

若簡報已使用指定密碼設為寫入保護，則回傳 `true`；否則回傳 `false`。

{{% alert color="info" title="See also" %}} 
- [PowerPoint 中的數位簽名](/slides/zh-hant/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代的加密方式，包括基於 AES 的演算法，確保您的簡報資料具有高水準的安全性。

**當嘗試開啟簡報時輸入錯誤密碼會發生什麼情況？**

若使用錯誤的密碼，會拋出例外，提示存取簡報被拒絕。此機制可防止未授權的存取，保護簡報內容。

**使用受密碼保護的簡報會有性能影響嗎？**

加密與解密過程可能在開啟和儲存時稍微增加負擔。大多數情況下，此性能影響甚微，對簡報任務的整體處理時間不會產生顯著影響。