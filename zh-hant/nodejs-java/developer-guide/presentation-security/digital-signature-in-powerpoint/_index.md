---
title: 在 JavaScript 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/nodejs-java/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證授權單位
- PFX 憑證
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js (透過 Java) 為 PowerPoint 與 OpenDocument 檔案加上數位簽章。只需幾秒，即可透過清晰的程式範例保護您的簡報。"
---
## **簡介**

**Digital certificate** 用於建立受密碼保護的 PowerPoint 簡報，標示由特定組織或個人建立。可透過聯繫授權機構（證書授權中心）取得數位憑證。將數位憑證安裝至系統後，即可於「檔案 -> 資訊 -> 保護簡報」為簡報加入數位簽章：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

簡報可能包含多個數位簽章。加入數位簽章後，PowerPoint 會顯示一條特殊訊息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

要簽署簡報或檢查簡報簽章的真偽，**Aspose.Slides API** 提供[**DigitalSignature**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/DigitalSignature)類別、[**DigitalSignatureCollection**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/DigitalSignatureCollection)類別和[**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--)方法。目前僅支援 PPTX 格式的數位簽章。

## **從 PFX 憑證新增數位簽章**
以下程式碼示範如何從 PFX 憑證新增數位簽章：

1. 開啟 PFX 檔案並將 PFX 密碼傳遞給[**DigitalSignature**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/DigitalSignature)物件。
2. 將建立的簽章加入簡報物件。

```javascript
// 開啟簡報檔案
var pres = new aspose.slides.Presentation();
try {
    // 使用 PFX 檔案及密碼建立 DigitalSignature 物件
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // 為新數位簽章加入說明
    signature.setComments("Aspose.Slides digital signing test.");
    // 將數位簽章加入簡報
    pres.getDigitalSignatures().add(signature);
    // 儲存簡報
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

現在可以檢查簡報是否已經數位簽章且未被修改：

```javascript
// 開啟簡報
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // 檢查所有數位簽章是否有效
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以從檔案中移除現有的簽章嗎？**

是的。數位簽章集合支援[移除個別項目](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/)和[全部清除](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignaturecollection/clear/)；在儲存檔案後，簡報將不再有任何簽章。

**簽署後檔案會變成「唯讀」嗎？**

不會。簽章能維持完整性與作者身份，但不會阻止編輯。如需限制編輯，請結合[「唯讀」或密碼](/slides/zh-hant/nodejs-java/password-protected-presentation/)。

**簽章會在不同版本的 PowerPoint 中正確顯示嗎？**

簽章是為 OOXML（PPTX）容器建立的。支援 OOXML 簽章的現代 PowerPoint 版本會正確顯示此類簽章的狀態。