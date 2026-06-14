---
title: 在 Java 中使用密碼保護安全投影片
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
- 新增密碼
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
description: "了解如何使用 Aspose.Slides for Java 輕鬆鎖定與解除鎖定受密碼保護的 PowerPoint 與 OpenDocument 投影片。確保您的投影片安全。"
---
## **簡介**

當您使用密碼保護投影片時，表示您設定了一組密碼以對投影片施加特定限制。要移除這些限制，必須輸入密碼。受密碼保護的投影片被視為已鎖定的投影片。

通常，您可以設定密碼以對投影片施加以下限制：

- **修改**

如果您只想讓特定使用者修改投影片，可以設定修改限制。此限制會阻止使用者在未提供密碼的情況下修改、變更或複製投影片中的元素。

但是，即使沒有密碼，使用者仍然可以存取並開啟您的文件。在此唯讀模式下，使用者可以檢視內容——包括超連結、動畫、效果和其他元素——但無法複製項目或儲存投影片。

- **開啟**

如果您只想讓特定使用者開啟投影片，可以設定開啟限制。此限制會阻止使用者在未提供密碼的情況下甚至檢視投影片內容。

從技術上說，開啟限制也會阻止使用者修改投影片——如果無法開啟投影片，就無法進行任何修改。

**註**：當您以防止開啟的方式對投影片設定密碼保護時，投影片檔案會被加密。

## **Aspose.Slides 中的密碼保護**
**支援的格式**

Aspose.Slides 支援以下格式的投影片密碼保護、加密及類似操作：

- PPTX 和 PPT - Microsoft PowerPoint 投影片
- ODP - OpenDocument 投影片
- OTP - OpenDocument 投影片範本

**支援的操作**

Aspose.Slides 允許您以以下方式使用密碼保護投影片以防止修改：

- 加密投影片
- 為投影片設定寫入保護

**其他操作**

Aspose.Slides 允許您以以下方式執行其他與密碼保護和加密相關的任務：

- 解密投影片；開啟已加密的投影片
- 移除加密；停用密碼保護
- 移除投影片的寫入保護
- 取得已加密投影片的屬性
- 檢查投影片是否已加密
- 檢查投影片是否受密碼保護。

## **使用密碼保護投影片**

您可以透過設定密碼來加密投影片。之後，要修改已鎖定的投影片，使用者必須提供密碼。

要加密或以密碼保護投影片，必須使用 encrypt 方法（來自[IProtectionManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager)）為投影片設定密碼。將密碼傳遞給 encrypt 方法，並使用 save 方法儲存已加密的投影片。

此範例程式碼示範如何加密投影片：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **為投影片設定寫入保護**

您可以在投影片上添加「請勿修改」的標記。如此一來，您即可告訴使用者您不希望他們對投影片進行變更。

**註**寫入保護過程不會加密投影片。因此，使用者—如果真的想—仍然可以修改投影片，但若要儲存變更，必須以不同的名稱建立新投影片。

要設定寫入保護，必須使用[setWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) 方法。此範例程式碼示範如何為投影片設定寫入保護：

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

Aspose.Slides 允許您在傳入密碼後載入加密檔案。要解密投影片，必須呼叫[removeEncryption](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#removeEncryption--) 方法且不傳遞任何參數。之後必須輸入正確的密碼才能載入投影片。

此範例程式碼示範如何解密投影片：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 處理已解密的投影片
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **從投影片移除加密**

您可以移除投影片的加密或密碼保護。如此一來，使用者即可在沒有任何限制的情況下存取或修改投影片。

要移除加密或密碼保護，必須呼叫[removeEncryption](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#removeEncryption--) 方法。此範例程式碼示範如何從投影片移除加密：

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

您可以使用 Aspose.Slides 移除投影片檔案上的寫入保護。如此一來，使用者可隨意修改，且在執行此類操作時不會收到任何警告。

您可以透過使用[removeWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) 方法移除投影片的寫入保護。此範例程式碼示範如何從投影片移除寫入保護：

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

通常使用者很難取得已加密或受密碼保護投影片的文件屬性。Aspose.Slides 提供了一種機制，允許您在對投影片設定密碼保護的同時，仍保留使用者存取該投影片屬性的方式。

**註**當 Aspose.Slides 加密投影片時，投影片的文件屬性預設也會受到密碼保護。但如果您需要在投影片加密後仍能讓屬性可存取，Aspose.Slides 允許您精確執行此操作。

如果您希望使用者在您加密的投影片中仍能存取其屬性，可以將[encryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) 屬性設為 `true`。此範例程式碼示範如何在加密投影片的同時提供使用者存取文件屬性的方式：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **檢查投影片是否受密碼保護**

在載入投影片之前，您可能想先檢查並確認投影片未受到密碼保護。如此一來，可避免在未提供密碼的情況下載入受密碼保護的投影片時所產生的錯誤與相關問題。

此 Java 程式碼示範如何在不載入投影片本身的前提下檢查投影片是否受密碼保護：

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **檢查投影片是否已加密**

Aspose.Slides 允許您檢查投影片是否已加密。要執行此作業，可使用[isEncrypted](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#isEncrypted--) 屬性，若投影片已加密則回傳 `true`，未加密則回傳 `false`。

此範例程式碼示範如何檢查投影片是否已加密：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **檢查投影片是否受寫入保護**

Aspose.Slides 允許您檢查投影片是否受寫入保護。要執行此作業，可使用[isWriteProtected](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IProtectionManager#isWriteProtected--) 屬性，若投影片受寫入保護則回傳 `true`，未受寫入保護則回傳 `false`。

此範例程式碼示範如何檢查投影片是否受寫入保護：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **驗證或確認已使用特定密碼**

您可能想檢查並確認已使用特定密碼來保護投影片文件。Aspose.Slides 提供驗證密碼的功能。

此範例程式碼示範如何驗證密碼：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // 檢查是否與 "pass" 匹配
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

若投影片已使用指定密碼加密，會回傳 `true`；否則回傳 `false`。

{{% alert color="primary" title="另請參閱" %}} 
- [PowerPoint 中的數位簽章](/slides/zh-hant/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的投影片資料具備高水準的安全性。

**如果在嘗試開啟投影片時輸入錯誤的密碼會發生什麼情況？**

系統會拋出例外，提示存取投影片被拒絕。此機制可防止未授權的存取並保護投影片內容。

**在處理受密碼保護的投影片時是否會有效能影響？**

加密與解密過程可能在開啟和儲存時帶來輕微的開銷。大多數情況下，這種效能影響較小，對整體投影片處理時間的影響不顯著。