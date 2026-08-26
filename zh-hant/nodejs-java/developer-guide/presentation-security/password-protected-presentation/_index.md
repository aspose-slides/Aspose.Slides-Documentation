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
- 開啟已加密簡報
- 移除加密
- PowerPoint
- PPT
- PPTX
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中加密、偵測、驗證、開啟及解密受密碼保護的 PowerPoint PPT 和 PPTX 簡報。"
---
## **概觀**

開啟密碼會加密簡報。必須提供正確的密碼才能載入並檢視簡報內容，因而提供機密性保護。

開啟密碼與寫入保護密碼不同。寫入保護限制修改，但不會加密內容或阻止載入簡報。若要管理修改簡報的密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/nodejs-java/write-protected-presentation/)。

以下工作流程適用於 PPT 和 PPTX 簡報。示例在需要檔案與串流行為差異的情況下同時使用兩種格式。

## **使用開啟密碼加密簡報**

使用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#encrypt)指派開啟密碼。然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save)將加密的簡報保存。

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

## **載入加密的簡報**

將[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setPassword)設定為開啟密碼，並在載入檔案時將該選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)。如果需要開啟密碼但提供的密碼缺失或不正確，載入將失敗。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 使用已解密的簡報。
} finally {
    presentation.dispose();
}
```

## **移除簡報的加密**

使用其開啟密碼載入簡報，呼叫[ProtectionManager.removeEncryption](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#removeEncryption)，並將結果保存。保存後的簡報即可在不需密碼的情況下載入。

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

使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo)取得[PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/)，而不必建立完整的簡報實例。在請求或驗證密碼之前，先檢查[PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected)。若存在保護，請使用[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#checkPassword)驗證所提供的值。

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

使用[PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream)檢查 Node.js 可讀串流。檢查串流被消耗後，於使用[Presentation.createPresentationFromStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#createPresentationFromStream)載入完整簡報之前，建立新的串流。

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

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#checkPassword)僅在簡報具有開啟密碼且提供的密碼正確時回傳 `true`。在以下情況皆回傳 `false`：

- 密碼不正確。
- 簡報沒有開啟密碼。
- 提供的密碼為 `null` 或空值。

PPT 與 PPTX 簡報的行為相同。

## **檢查已載入的簡報是否已加密**

使用正確密碼載入簡報後，檢查[ProtectionManager.isEncrypted](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#isEncrypted)以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，請如前所示使用[PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected)。

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

{{% alert color="warning" title="安全性" %}}
不要記錄開啟密碼或將其寫入診斷訊息。避免不必要的重複驗證嘗試，僅在需要時於記憶體中保留密碼，且在立即載入簡報時重複使用成功的驗證結果。
{{% /alert %}}

## **線上為簡報設定密碼保護**

1. 開啟[Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock)應用程式。
2. 選取或上傳簡報。
3. 輸入用於檢視保護的密碼。
4. （可選）為編輯保護另外輸入密碼。
5. 套用保護並下載產生的檔案。

{{% alert color="info" title="另請參閱" %}}
- [Write-Protect Presentations](/slides/zh-hant/nodejs-java/write-protected-presentation/)
- [PowerPoint 中的數位簽章](/slides/zh-hant/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**What is the difference between an opening password and a write-protection password?**

開啟密碼會加密簡報，且必須在載入內容時提供。寫入保護密碼僅限制修改，不會加密內容。

**Can I validate an opening password without loading all slides?**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，並在建立完整簡報實例之前驗證密碼。

**Do the password-checking workflows support both PPT and PPTX?**

支援。檔案路徑與串流的密碼偵測與驗證在 PPT 與 PPTX 簡報中皆相同。