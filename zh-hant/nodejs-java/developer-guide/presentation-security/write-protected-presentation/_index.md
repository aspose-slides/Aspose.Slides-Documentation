---
title: 在 JavaScript 中寫入保護簡報
linktitle: 寫入保護
type: docs
weight: 25
url: /zh-hant/nodejs-java/write-protected-presentation/
keywords:
- 寫入保護
- 寫入保護 PowerPoint
- 修改密碼
- 限制簡報編輯
- 移除寫入保護
- 驗證修改密碼
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js（透過 Java）在 PowerPoint PPT 與 PPTX 簡報中設定、偵測、驗證及移除寫入保護密碼。"
---
## **簡介**

寫入保護密碼會限制簡報的修改，但不會加密其內容。使用者可以在不輸入密碼的情況下載入並檢視寫入受保護的簡報。視應用程式而定，他們也可能編輯內容並另存為不同的檔名，因此寫入保護不應被視為機密機制。

開啟密碼的目的不同：它會加密簡報，且在載入內容時必須提供。若要加密簡報或驗證開啟密碼，請參閱[密碼保護簡報](/slides/zh-hant/nodejs-java/password-protected-presentation/)。

本文的工作流程同時適用於 PPT 與 PPTX 簡報。範例使用 PPTX 檔案；若儲存為 PPT，請使用 `.ppt` 副檔名以及相對應的 PPT 儲存格式。

## **設定簡報的寫入保護**

使用[ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) 為簡報指定修改密碼。儲存簡報時會保留此保護設定。

以下範例在 PPTX 簡報上設定寫入保護：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **載入寫入受保護的簡報**

由於寫入保護不會加密簡報內容，載入簡報時不需要密碼。此密碼僅在驗證對受保護簡報的修改授權時才相關。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

請勿將寫入保護密碼傳遞給[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setPassword)。該方法接受用於加密內容的開啟密碼。若簡報同時具備兩種保護，請先提供開啟密碼以載入，然後另行處理寫入保護密碼。

## **移除簡報的寫入保護**

使用[ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) 移除修改限制，然後儲存簡報。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **檢查簡報是否受寫入保護**

若要在不建立完整 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例的情況下檢視檔案，請呼叫[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) 並檢查[PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected)。此方法使用[NullableBool](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/nullablebool/)，在偵測到寫入保護時返回 `NullableBool.True`。

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

基於串流的[PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) 方法可針對以 Node.js 可讀串流提供的簡報取得相同資訊。

## **驗證寫入保護密碼**

使用[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) 在不載入完整簡報的情況下驗證修改密碼。先檢查[PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected)，確保僅在寫入保護存在時才要求或驗證密碼。

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) 僅驗證寫入保護密碼，並不驗證開啟密碼或判斷是否能載入加密內容。相對地，[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#checkPassword) 僅驗證開啟密碼。如果已載入完整簡報，則可透過[ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) 以其保護管理器執行相同的寫入保護檢查。

在正式環境的應用程式中，請勿記錄密碼或將其寫入診斷訊息。避免不必要的重複驗證，且僅在需要時才在記憶體中保留密碼。

{{% alert color="info" title="另見" %}}
- [密碼保護簡報](/slides/zh-hant/nodejs-java/password-protected-presentation/)
- [唯讀簡報](/slides/zh-hant/nodejs-java/read-only-presentation/)
- [PowerPoint 中的數位簽章](/slides/zh-hant/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**寫入保護會加密簡報嗎？**

不會。它只限制修改，並未加密簡報內容，仍可載入與檢視。

**開啟簡報是否必須提供寫入保護密碼？**

不需要。只有開啟密碼是載入加密簡報內容時所必需的。

**簡報可以同時具有開啟密碼與寫入保護密碼嗎？**

可以。請透過載入選項提供開啟密碼以開啟加密的簡報，並在需要修改授權時另行驗證寫入保護密碼。