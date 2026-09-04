---
title: 在 JavaScript 中對簡報設定密碼保護
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/nodejs-java/password-protected-presentation/
keywords:
- 受密碼保護的簡報
- 開啟密碼
- 加密 PowerPoint
- 解密 PowerPoint
- 驗證簡報密碼
- 檢查簡報密碼
- 開啟加密的簡報
- 移除加密
- PowerPoint
- PPT
- PPTX
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides 加密、偵測、驗證、開啟及解密受密碼保護的 PowerPoint PPT 與 PPTX 簡報。"
---
## **概述**

開啟密碼會加密簡報。必須提供正確的密碼才能載入和檢視簡報內容，因此此保護提供機密性。

開啟密碼不同於寫入保護密碼。寫入保護限制修改，但不會加密內容或阻止載入簡報。若要管理修改簡報的密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/nodejs-java/write-protected-presentation/)。

以下工作流程適用於 PPT 與 PPTX 簡報。範例同時使用兩種格式，以說明檔案與串流行為的重要性。

## **使用開啟密碼加密簡報**

使用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#encrypt)指派開啟密碼。然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save)將加密的簡報保存下來。

以下範例會加密 PPTX 簡報：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **保持文件屬性公開**

預設情況下，Aspose.Slides 會將文件屬性納入簡報加密。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 方法可獨立於投影片內容加密來控制此行為。在必須讓索引、分類、搜尋或文件管理系統在未提供開啟密碼的情況下讀取中繼資料時，於呼叫[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#encrypt)之前傳入 `false`。

以下範例會加密 PPTX 簡報，同時將內建文件屬性保留為公開：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

傳入 `false` 給[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 不會使投影片、母片、版面配置、形狀、媒體或其他簡報內容公開。它僅影響文件屬性。若要在不載入加密內容的情況下讀取這些屬性，請參閱[Manage Presentation Properties](/slides/zh-hant/nodejs-java/presentation-properties/)。

## **載入加密的簡報**

將[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setPassword)設定為開啟密碼，並在載入檔案時將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)。若需要開啟密碼但未提供密碼或密碼不正確，載入將失敗。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 處理已解密的簡報。
} finally {
    presentation.dispose();
}
```

## **移除簡報的加密**

使用開啟密碼載入簡報，呼叫[ProtectionManager.removeEncryption](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#removeEncryption)，然後保存結果。保存後的簡報即可在不輸入密碼的情況下載入。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在載入前驗證開啟密碼**

使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo)取得[PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/)而不必建立完整的簡報實例。於請求或驗證密碼之前先檢查[PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected)。若存在保護，使用[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#checkPassword)驗證提供的值。

### **檔案路徑工作流程**

以下範例驗證 PPTX 檔案的開啟密碼，將驗證後的值傳遞給[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setPassword)，然後載入完整的簡報：

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **串流工作流程**

使用[PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream)檢查 Node.js 可讀串流。檢查完畢且串流已被消耗後，請在使用[Presentation.createPresentationFromStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#createPresentationFromStream)載入完整簡報之前建立新的串流。

以下範例使用 PPT 檔案：

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **checkPassword 回傳值**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#checkPassword)僅在簡報具備開啟密碼且提供的密碼正確時回傳 `true`。在以下情況皆會回傳 `false`：

- 密碼不正確。
- 簡報沒有設定開啟密碼。
- 提供的密碼為 `null` 或空字串。

此行為對 PPT 與 PPTX 簡報皆相同。

## **檢查已載入的簡報是否已加密**

使用正確密碼載入簡報後，檢查[ProtectionManager.isEncrypted](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#isEncrypted)以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，請如上使用[PresentationInfo.isPasswordProtected]。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **安全性建議**
{{% alert color="warning" title="Security" %}}
不要記錄開啟密碼或將其包含在診斷訊息中。避免不必要的重複驗證嘗試，僅在需要時在記憶體中保留密碼，並在立即載入簡報時重複使用已成功驗證的結果。

即使簡報內容已加密，公開的文件屬性仍可能透露作者姓名、標題、主旨、關鍵字、公司資訊、註解及自訂值。請將敏感的中繼資料與簡報一併加密。將屬性保留為公開應僅在系統必須在沒有開啟密碼的情況下進行索引、分類、搜尋或管理檔案時，作為明確的決策。
{{% /alert %}}

## **在線上為簡報設定密碼保護**

1. 開啟 [Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock) 應用程式。
2. 選取或上傳簡報。
3. 輸入觀看保護的密碼。
4. （可選）為編輯保護輸入另一組密碼。
5. 套用保護並下載產生的檔案。

{{% alert color="info" title="See also" %}}
- [寫入保護簡報](/slides/zh-hant/nodejs-java/write-protected-presentation/)
- [PowerPoint 數位簽章](/slides/zh-hant/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何不同？**

開啟密碼會加密簡報，且必須提供才能載入其內容。寫入保護密碼僅限制修改，並不加密內容。

**我可以在不載入所有投影片的情況下驗證開啟密碼嗎？**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，然後在建立完整簡報實例之前驗證密碼。

**應用程式可以在沒有開啟密碼的情況下讀取中繼資料嗎？**

可以，但僅限於簡報在停用文件屬性加密的情況下。此時應用程式必須使用在[Manage Presentation Properties](/slides/zh-hant/nodejs-java/presentation-properties/)中描述的僅文件屬性載入模式。

**密碼檢查工作流程同時支援 PPT 與 PPTX 嗎？**

是的。檔案路徑與串流式的密碼偵測與驗證對 PPT 與 PPTX 簡報的行為相同。