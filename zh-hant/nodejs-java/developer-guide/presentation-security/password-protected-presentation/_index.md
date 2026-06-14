---
title: 在 JavaScript 中使用密碼保護簡報
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/nodejs-java/password-protected-presentation/
keywords:
- 鎖定 PowerPoint
- 鎖定簡報
- 解除鎖定 PowerPoint
- 解除鎖定簡報
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
- Node.js
- JavaScript
- Aspose.Slides
description: 輕鬆使用 Aspose.Slides for Node.js（透過 Java）鎖定與解除鎖定受密碼保護的 PowerPoint 與 OpenDocument 簡報。確保您的簡報安全。
---
## **簡介**

當您對簡報設定密碼保護時，表示您正在設定一組密碼，以對簡報施加特定限制。若要移除這些限制，必須輸入密碼。受密碼保護的簡報被視為已鎖定的簡報。

通常，您可以設定密碼以對簡報施加這些限制：

- **修改**

  若您只想讓特定使用者修改簡報，您可以設定修改限制。此限制會阻止人員修改、變更或複製簡報中的內容（除非提供密碼）。

  然而，即使未輸入密碼，使用者仍可存取您的文件並開啟它。在唯讀模式下，使用者可以檢視簡報內的內容或項目——超連結、動畫、效果等——但無法複製項目或儲存簡報。

- **開啟**

  若您只想讓特定使用者開啟簡報，您可以設定開啟限制。此限制會阻止人員甚至檢視簡報內容（除非提供密碼）。

  從技術上講，開啟限制亦會阻止使用者修改簡報：當人員無法開啟簡報時，便無法對其進行修改或變更。

  **注意**：當您對簡報設定密碼以防止開啟時，簡報檔案會被加密。

## **線上設定簡報密碼保護**

1. 前往我們的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock) 頁面。  

   ![todo:image_alt_text](slides-lock.png)

2. 點擊 **拖放或上傳檔案**。

3. 在電腦上選取您想要設定密碼保護的檔案。

4. 輸入您偏好的編輯保護密碼；輸入您偏好的檢視保護密碼。

5. 如果您希望使用者看到最終版的簡報，請勾選 **Mark as final** 核取方塊。

6. 點擊 **PROTECT NOW.**  

7. 點擊 **DOWNLOAD NOW.**

## **Aspose.Slides 中的簡報密碼保護**
**支援格式**

Aspose.Slides 支援對以下格式的簡報進行密碼保護、加密及類似操作：

- PPTX and PPT - Microsoft PowerPoint 簡報
- ODP - OpenDocument 簡報
- OTP - OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您透過以下方式使用密碼保護來防止簡報被修改：

- 加密簡報
- 設定寫入保護至簡報

**其他操作**

Aspose.Slides 允許您以以下方式執行其他與密碼保護與加密相關的任務：

- 解密簡報；開啟已加密的簡報
- 移除加密；停用密碼保護
- 移除簡報的寫入保護
- 取得已加密簡報的屬性
- 檢查簡報是否已加密
- 檢查簡報是否已受密碼保護。

## **加密簡報**

您可以透過設定密碼來加密簡報。之後若要修改已鎖定的簡報，使用者必須提供密碼。

若要加密或設定密碼保護，必須使用 encrypt 方法（來自 [ProtectionManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager)）為簡報設定密碼。將密碼傳遞給 encrypt 方法，然後使用 save 方法儲存已加密的簡報。

以下範例程式碼示範如何加密簡報：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **設定簡報寫入保護**

您可以在簡報上加入「請勿修改」的標記。如此一來，您即可告訴使用者您不希望他們對簡報做出變更。

**注意**：寫入保護過程不會加密簡報。因此，使用者—如果他們真的想—仍可修改簡報，但若要儲存變更，必須以不同的檔名建立簡報。

若要設定寫入保護，必須使用 [setWriteProtection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) 方法。以下範例程式碼示範如何為簡報設定寫入保護：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **解密簡報；開啟已加密的簡報**

Aspose.Slides 允許您在傳入密碼後載入已加密的檔案。若要解密簡報，必須呼叫 [removeEncryption](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) 方法且不帶參數。之後您需要輸入正確的密碼以載入簡報。

以下範例程式碼示範如何解密簡報：

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // 使用已解密的簡報
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **移除加密；停用密碼保護**

您可以移除簡報的加密或密碼保護。如此一來，使用者即可在沒有任何限制的情況下存取或修改簡報。

若要移除加密或密碼保護，必須呼叫 [removeEncryption](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) 方法。以下範例程式碼示範如何從簡報中移除加密：

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **移除簡報的寫入保護**

您可以使用 Aspose.Slides 移除簡報檔案上的寫入保護。如此一來，使用者即可自由修改，且在執行此類操作時不會收到警告。

您可以透過使用 [removeWriteProtection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) 方法來移除簡報的寫入保護。以下範例程式碼示範如何移除簡報的寫入保護：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **取得已加密簡報的屬性**

通常使用者在取得已加密或受密碼保護的簡報文件屬性時會遇到困難。Aspose.Slides  however, 提供了一種機制，讓您在密碼保護簡報的同時，仍能讓使用者存取該簡報的屬性。

**注意**：當 Aspose.Slides 加密簡報時，簡報的文件屬性預設也會受到密碼保護。但如果您希望即使在簡報加密後仍能存取其屬性，Aspose.Slides 允許您這樣做。

若您希望使用者在您加密的簡報上仍保有存取屬性的能力，可將 [encryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) 屬性設為 `true`。以下範例程式碼示範如何在加密簡報的同時提供使用者存取文件屬性的方式：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **載入簡報前檢查是否已受密碼保護**

在載入簡報之前，您可能想先檢查並確認簡報未被密碼保護。如此一來，可避免在未提供密碼的情況下載入受密碼保護的簡報時產生錯誤等問題。

以下 JavaScript 程式碼示範如何在不載入簡報本身的情況下檢查簡報是否受密碼保護：

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。要執行此檢查，可使用 [isEncrypted](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) 屬性，若簡報已加密則回傳 `true`，否則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否已加密：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **檢查簡報是否已寫入保護**

Aspose.Slides 允許您檢查簡報是否已寫入保護。要執行此檢查，可使用 [isWriteProtected](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) 屬性，若簡報已寫入保護則回傳 `true`，否則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否已寫入保護：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **驗證或確認已使用特定密碼保護簡報**

您可能想檢查並確認已使用特定密碼保護簡報文件。Aspose.Slides 提供了驗證密碼的方式。

以下範例程式碼示範如何驗證密碼：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // 檢查 "pass" 是否匹配
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

若使用指定的密碼加密了簡報，則回傳 `true`；否則回傳 `false`。

{{% alert color="primary" title="另請參考" %}} 
- [PowerPoint 中的數位簽章](/slides/zh-hant/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的簡報資料具高層次的安全性。

**若在嘗試開啟簡報時輸入錯誤的密碼，會發生什麼情況？**

系統會拋出例外，提示存取簡報被拒絕。此機制有助於防止未授權的存取並保護簡報內容。

**在處理受密碼保護的簡報時，是否會有效能影響？**

加密與解密過程可能在開啟與儲存操作時帶來輕微的額外開銷。在大多數情況下，此效能影響較小，對您的簡報處理任務整體執行時間影響不大。