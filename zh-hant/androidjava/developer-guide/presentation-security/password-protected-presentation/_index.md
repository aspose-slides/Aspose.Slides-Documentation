---
title: 在 Android 上使用密碼保護投影片
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/androidjava/password-protected-presentation/
keywords:
- 鎖定 PowerPoint
- 鎖定投影片
- 解鎖 PowerPoint
- 解鎖投影片
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 透過 Java，輕鬆鎖定與解鎖受密碼保護的 PowerPoint 與 OpenDocument 投影片。保障您的投影片安全。"
---
## **簡介**

當您以密碼保護投影片時，表示您正在設定一個密碼以對投影片施加特定限制。若要移除這些限制，必須輸入密碼。受密碼保護的投影片視為已鎖定的投影片。

通常，您可以設定密碼以對投影片實施這些限制：

- **修改**

  如果您只想讓特定使用者修改您的投影片，您可以設定修改限制。此限制會防止他人修改、變更或複製投影片內的內容（除非提供密碼）。

  然而，在此情況下，即使未輸入密碼，使用者仍能存取並開啟您的文件。在唯讀模式下，使用者可以檢視內容或投影片內的超連結、動畫、特效等，但無法複製項目或儲存投影片。

- **開啟**

  如果您只想讓特定使用者開啟您的投影片，您可以設定開啟限制。此限制會防止他人甚至檢視投影片內容（除非提供密碼）。

  技術上，開啟限制亦會阻止使用者修改投影片：當人無法開啟投影片時，便無法對其進行修改或變更。

  **注意** 當您以密碼保護投影片以防止開啟時，投影片檔案會被加密。

## **Aspose.Slides 中的投影片密碼保護**
**支援的格式**

Aspose.Slides 支援密碼保護、加密及類似操作，適用於以下格式：

- PPTX 和 PPT - Microsoft PowerPoint 投影片
- ODP - OpenDocument 投影片
- OTP - OpenDocument 投影片範本

**支援的操作**

Aspose.Slides 允許您對投影片使用密碼保護，以以下方式防止修改：

- 加密投影片
- 對投影片設定寫入保護

**其他操作**

Aspose.Slides 允許您以以下方式執行其他與密碼保護和加密相關的任務：

- 解密投影片；開啟加密的投影片
- 移除加密；停用密碼保護
- 從投影片移除寫入保護
- 取得加密投影片的屬性
- 檢查投影片是否已加密
- 檢查投影片是否受密碼保護

## **加密投影片**

您可以透過設定密碼來加密投影片。之後，若要修改已鎖定的投影片，使用者必須提供密碼。

若要加密或以密碼保護投影片，必須使用 encrypt 方法（來自[IProtectionManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager)）為投影片設定密碼。您將密碼傳遞給 encrypt 方法，然後使用 save 方法儲存已加密的投影片。

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

## **設定投影片寫入保護**

您可以在投影片加入「請勿修改」的標記。如此即可告訴使用者您不希望他們對投影片進行變更。

**注意** 寫入保護過程不會加密投影片。因此，使用者—若真的想—仍可修改投影片，但若要儲存變更，必須以不同的檔名建立投影片。

若要設定寫入保護，必須使用[setWriteProtection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) 方法。以下範例程式碼示範如何對投影片設定寫入保護：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **載入加密的投影片**

Aspose.Slides 允許您透過傳入密碼載入加密檔案。若要解密投影片，必須呼叫[removeEncryption](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) 方法且不帶參數。接著您需輸入正確的密碼才能載入投影片。

以下範例程式碼示範如何解密投影片：

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

## **移除投影片的加密**

您可以移除投影片的加密或密碼保護。如此，使用者即可在不受限制的情況下存取或修改投影片。

若要移除加密或密碼保護，必須呼叫[removeEncryption](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) 方法。以下範例程式碼示範如何從投影片移除加密：

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

您可以使用 Aspose.Slides 移除投影片檔案上的寫入保護。如此，使用者即可隨意修改，且不會在執行此類操作時收到警告。

您可以透過呼叫[removeWriteProtection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) 方法來移除投影片的寫入保護。以下範例程式碼示範如何從投影片移除寫入保護：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **取得加密投影片的屬性**

通常，使用者難以取得加密或受密碼保護投影片的文件屬性。然而，Aspose.Slides 提供一種機制，讓您在以密碼保護投影片的同時，仍保留使用者存取該投影片屬性的方式。

**注意** 當 Aspose.Slides 加密投影片時，投影片的文件屬性預設也會受到密碼保護。但如果您需要在投影片加密後仍能存取其屬性，Aspose.Slides 允許您如此操作。

若您希望使用者仍能存取已加密投影片的屬性，可將[encryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) 屬性設為 `true`。以下範例程式碼示範如何在加密投影片的同時，提供使用者存取其文件屬性的方式：

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

在載入投影片之前，您可能想先檢查並確認投影片並未受密碼保護。如此可避免在未提供密碼而載入受密碼保護的投影片時產生錯誤或類似問題。

以下 Java 程式碼示範如何檢查投影片是否受密碼保護（無需實際載入投影片）：

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **檢查投影片是否已加密**

Aspose.Slides 允許您檢查投影片是否已加密。執行此操作時，可使用[isEncrypted](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) 屬性，若投影片已加密則回傳 `true`，未加密則回傳 `false`。

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

Aspose.Slides 允許您檢查投影片是否受寫入保護。執行此操作時，可使用[isWriteProtected](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) 屬性，若投影片受寫入保護則回傳 `true`，未受寫入保護則回傳 `false`。

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

您可能想檢查並確認已使用特定密碼來保護投影片文件。Aspose.Slides 提供驗證密碼的方式。

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

若投影片已使用指定密碼加密，則回傳 `true`；否則回傳 `false`。

{{% alert color="primary" title="另請參閱" %}} 
- [PowerPoint 中的數位簽章](/slides/zh-hant/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的投影片具備高層次的資料安全性。

**在嘗試開啟投影片時，若輸入錯誤的密碼會發生什麼情況？**

若使用錯誤的密碼，系統會拋出例外，提示存取投影片被拒絕。此機制有助於防止未授權存取，保護投影片內容。

**在處理受密碼保護的投影片時，是否會有效能影響？**

加密與解密過程在開啟與儲存操作時可能會產生輕微的額外負擔。大多數情況下，此效能影響較小，對投影片任務的整體處理時間不會產生顯著影響。