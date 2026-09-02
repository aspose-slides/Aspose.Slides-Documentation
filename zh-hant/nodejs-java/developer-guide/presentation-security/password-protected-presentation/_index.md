---
title: 使用 JavaScript 為簡報設定密碼保護
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/nodejs-java/password-protected-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Node.js (via Java) 鎖定與解鎖受密碼保護的 PowerPoint 與 OpenDocument 簡報。保護您的簡報。"
---
## **簡介**

當您為簡報設定密碼保護時，即是設定一個密碼，以對簡報施加特定限制。要解除這些限制，必須輸入密碼。受密碼保護的簡報被視為已鎖定的簡報。

通常，您可以設定密碼以對簡報實施以下限制：

- **修改**

  若您只想讓特定使用者修改簡報，可設定修改限制。此限制會阻止未提供密碼的人修改、變更或複製簡報中的內容。

  但是，即使未輸入密碼，使用者仍能存取並開啟文件。在唯讀模式下，使用者可以檢視簡報內的內容或項目（超連結、動畫、效果等），但無法複製項目或儲存簡報。

- **開啟**

  若您只想讓特定使用者開啟簡報，可設定開啟限制。此限制會阻止未提供密碼的人檢視簡報內容。

  在技術上，開啟限制同時也會阻止使用者修改簡報：當使用者無法開啟簡報時，便無法對其進行修改或變更。

  **注意**：當您為防止開啟而設定密碼保護時，簡報檔案會被加密。

## **如何在線上為簡報設定密碼保護**

1. 前往我們的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock)頁面。

   ![todo:image_alt_text](slides-lock.png)

2. 點擊**Drop or upload your files**。

3. 從電腦中選取要設定密碼保護的檔案。

4. 輸入您偏好的編輯保護密碼；輸入您偏好的檢視保護密碼。

5. 若您希望使用者看到最終版的簡報，勾選**Mark as final**核取方塊。

6. 點擊**PROTECT NOW.** 

7. 點擊**DOWNLOAD NOW.**

## **Aspose.Slides 中的簡報密碼保護**
**支援的格式**

Aspose.Slides 支援以下格式的簡報進行密碼保護、加密及類似操作：

- PPTX 和 PPT - Microsoft PowerPoint 簡報
- ODP - OpenDocument 簡報
- OTP - OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您以以下方式使用密碼保護來防止簡報被修改：

- 加密簡報
- 為簡報設定寫入保護

**其他操作**

Aspose.Slides 允許您以以下方式執行其他與密碼保護和加密相關的任務：

- 解密簡報；開啟已加密的簡報
- 移除加密；停用密碼保護
- 從簡報中移除寫入保護
- 取得已加密簡報的屬性
- 檢查簡報是否已加密
- 檢查簡報是否已設定密碼保護。

## **加密簡報**

您可以透過設定密碼來加密簡報。之後，若要修改已鎖定的簡報，使用者必須提供密碼。

要加密或設定密碼保護，必須使用[ProtectionManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager)的`encrypt`方法為簡報設定密碼。將密碼傳遞給`encrypt`方法，然後使用`save`方法儲存已加密的簡報。

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

## **為簡報設定寫入保護**

您可以在簡報中添加「請勿修改」的標記。這樣即可告知使用者您不希望他們對簡報做出變更。

**注意**：寫入保護的過程不會加密簡報。因此，使用者—如果真的想要—仍可修改簡報，但若要儲存變更，必須以不同的名稱另存簡報。

要設定寫入保護，必須使用`setWriteProtection`方法。以下範例程式碼示範如何為簡報設定寫入保護：

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

Aspose.Slides 允許您在傳入密碼後載入已加密的檔案。若要解密簡報，必須呼叫不帶參數的`removeEncryption`方法。之後，需要輸入正確的密碼才能載入簡報。

以下範例程式碼示範如何解密簡報：

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // 處理已解密的簡報
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **移除加密；停用密碼保護**

您可以移除簡報的加密或密碼保護。如此一來，使用者即可在無限制的情況下存取或修改簡報。

要移除加密或密碼保護，必須呼叫`removeEncryption`方法。以下範例程式碼示範如何移除簡報的加密：

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

## **從簡報中移除寫入保護**

您可以使用 Aspose.Slides 移除簡報檔案上的寫入保護。如此一來，使用者可以隨意修改，且在執行此類操作時不會收到警告。

您可以透過呼叫`removeWriteProtection`方法來移除寫入保護。以下範例程式碼示範如何從簡報中移除寫入保護：

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

通常使用者在取得已加密或受密碼保護的簡報的文件屬性時會遇到困難。然而，Aspose.Slides 提供了一種機制，使您在對簡報設定密碼保護的同時，仍保留使用者存取其屬性的能力。

**注意**：預設情況下，當 Aspose.Slides 加密簡報時，簡報的文件屬性也會受到密碼保護。若您需要在加密後仍能存取文件屬性，Aspose.Slides 允許您這麼做。

若要讓使用者在加密後仍能存取簡報的屬性，請在[ProtectionManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/)上將`setEncryptDocumentProperties`設為`false`。以下範例程式碼示範如何在加密簡報的同時仍提供使用者存取文件屬性的功能：

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **僅從已加密簡報載入文件屬性**

若要在不載入投影片或其他內容的情況下檢查已加密簡報的中繼資料，請建立一個[LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/)物件，並將`setOnlyLoadDocumentProperties`設為`true`。在此模式下，Aspose.Slides 會忽略密碼，只載入公開可取得的文件屬性。

以下程式碼範例透過`getDocumentProperties`從[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)讀取內建和自訂文件屬性：

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // 讀取內建文件屬性。
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // 讀取自訂文件屬性。
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

此工作流程僅在簡報加密時，文件屬性被保留為未加密（公開）時有效。若文件屬性已加密，將`true`傳遞給`LoadOptions.setOnlyLoadDocumentProperties`會拋出例外，因為在此模式下會忽略密碼。若要存取已加密的文件屬性或載入包括投影片和其他內容的完整簡報，請透過`LoadOptions.setPassword`在[LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/)中提供正確的密碼。

## **在載入簡報前檢查其是否受密碼保護**

在載入簡報之前，您可能想先檢查並確認簡報未被密碼保護。如此可避免在未提供密碼的情況下載入受密碼保護的簡報時發生錯誤等問題。

以下 JavaScript 程式碼示範如何在不載入簡報本身的情況下檢查其是否受密碼保護：

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。您可以使用[isEncrypted](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--)屬性，若簡報已加密則回傳`true`，未加密則回傳`false`。

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

Aspose.Slides 允許您檢查簡報是否已寫入保護。您可以使用[isWriteProtected](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--)屬性，若簡報已寫入保護則回傳`true`，未寫入保護則回傳`false`。

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

若簡報已使用指定密碼加密，則回傳`true`；否則回傳`false`。

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/zh-hant/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問與答**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的簡報資料具備高安全性。

**若在開啟簡報時輸入錯誤的密碼會發生什麼情況？**

若使用錯誤的密碼，系統會拋出例外，提示存取簡報被拒絕。此機制有助於防止未授權存取並保護簡報內容。

**使用受密碼保護的簡報會有性能影響嗎？**

加密與解密過程可能在開啟和儲存操作時帶來輕微的額外負擔。在大多數情況下，這種性能影響微乎其微，並不會顯著影響簡報任務的整體處理時間。