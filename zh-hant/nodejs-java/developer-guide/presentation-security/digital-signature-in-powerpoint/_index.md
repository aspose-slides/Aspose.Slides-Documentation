---
title: 在 JavaScript 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/nodejs-java/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證授權機構
- PFX 憑證
- PKCS#12
- 驗證簽章
- PowerPoint
- PPTX
- 簡報安全
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 PFX 憑證為既有 PPTX 簡報簽章，並透過 Java 使用 Aspose.Slides for Node.js 來驗證或移除數位簽章。"
---
## **概觀**

數位簽章協助收件者判斷是誰簽署簡報以及簽署內容是否已變更。此處有三個相關的安全概念十分重要：

- **數位憑證** 為將身分與公開金鑰關聯的電子憑證。受信任的憑證授權機構（CA）可以簽發憑證，或是組織使用自行簽發的憑證於內部工作流程中。
- **數位簽章** 由簡報內容與憑證持有者的私密金鑰產生。之後可使用憑證的公開金鑰驗證簽章。簽章提供來源與完整性的證據；它不會加密簡報。
- **密碼保護** 控制使用者是否能開啟或修改簡報。它與數位簽章分開，相關說明請見[Password-Protected Presentations](/nodejs-java/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **Add a Digital Signature** 命令。

![PowerPoint 「保護簡報」功能表，突出顯示「Add a Digital Signature」](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 會顯示簽章狀態通知。

![PowerPoint 通知，指出簡報包含有效簽章](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過[Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 取回 [DigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignaturecollection/)，其中包含 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignature/) 物件。簡報可包含多個簽章。

## **了解 PFX 憑證和密碼**

PFX 檔案（亦稱 PKCS#12 檔案，副檔名常為 `.pfx` 或 `.p12`）可包含 X.509 憑證、其私密金鑰以及憑證鏈。私密金鑰允許持有者建立簽章。若憑證未提供可存取的私密金鑰，則無法用來簽署簡報。

PFX 密碼用於保護憑證套件與私密金鑰，它 **不是** 用於開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至原始碼管理系統。於正式環境中，應限制對憑證檔案的存取，並從祕密儲存或其他受保護的設定來源取得密碼。以下範例僅使用環境變數，以避免在程式碼中嵌入密碼。

## **將數位簽章加入簡報**

要對真實的簡報工作流程簽章，請載入現有 PPTX 檔案，從 PFX 憑證與其密碼建立 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignature/)，將簽章加入簡報的集合，最後存為 PPTX 檔案。

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

將結果另存新檔可以保留未簽署的原始檔。透過 [DigitalSignature.setComments](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignature/) 設定的值僅說明簽章的目的，並非安全控制項。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，請檢查 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 所回傳的每一個項目。使用 [DigitalSignature.isValid](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignature/) 方法即可判斷嵌入的簽章對於目前的簡報內容是否有效。

以下範例同時使用 Node.js `X509Certificate` 類別讀取每張嵌入憑證的主旨名稱。

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

無效的結果通常表示簽署後簡報內容或簽章資料已變更，或檔案受損。移除所有簽章會產生未簽署的簡報，因此僅檢查項目是否有效並不足以滿足安全需求；工作流程還必須驗證簽章數量與預期的簽署者身分皆正確。

此有效性結果不應被視為完整的憑證信任判斷。依照您的安全政策，應用程式可能還需要建構並驗證 X.509 憑證鏈、檢查憑證有效期限與撤銷狀態、確認預期的主旨或指紋、驗證金鑰用途，並評估受信任的時間戳記。僅靠 [DigitalSignature.getSignTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignature/) 的值並不足以證明來自可信的時間戳記授權中心。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。以下範例載入已簽署的 PPTX，使用 [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) 移除全部簽章，並儲存為未簽署的副本。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若只想移除單一簽章，請以零起始索引呼叫 [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/)。除非工作流程明確要求覆寫已簽署的原始檔，否則請另存新檔。

## **編輯與格式考量**

- 簽章不會使簡報變為唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 請在簽署前完成所有預期的編輯。若需要變更簡報，請先儲存修訂後的版本，再對該修訂簽章。
- 請保留最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 簽章轉為該轉換檔的有效簽章。
- 將憑證的私密金鑰視為敏感資訊。取得私密金鑰與其密碼的人，可能能製作看似來自該憑證持有者的簽章。
- 當文件保存政策要求時，請保留未簽署的原始檔或其他受控副本。

## **常見問題**

**數位簽章會加密簡報嗎？**

不會。數位簽章僅提供來源與完整性的證明，簡報內容仍然可讀，除非另行加密。若需限制內容存取，請使用[password protection](/nodejs-java/password-protected-presentation/)。

**PFX 密碼與簡報密碼相同嗎？**

不相同。PFX 密碼用於解鎖憑證套件中的私密金鑰，並不控制誰可以開啟或編輯 PPTX 檔案。

**可以使用自行簽發的憑證嗎？**

技術上，只要自行簽發的憑證包含可存取的私密金鑰，即可使用。但收件人不會自動信任它，除非該憑證已明確加入其受信任環境。公開或跨組織的工作流程通常會使用受信任 CA 簽發的憑證。

**什麼情況會使簽章無效？**

在簽署後更改已簽署的簡報內容或簽章資料會使簽章失效。檔案損壞亦會導致驗證失敗。若全部簽章被移除，簡報會變成未簽署，而非含有無效簽章的檔案。

**有效的簽章是否代表應該信任簽署者？**

僅憑簽章本身並不足以判斷信任。簽章的完整性與簽署者的可信度是兩個獨立決策。正式的驗證政策應同時檢查憑證鏈、有效期限、撤銷狀態、預期身分、金鑰用途以及任何受信任的時間戳記需求。

**憑證過期會怎樣？**

憑證過期不會改變簡報的位元組，但會影響憑證信任的評估。簽章是否仍被接受取決於您的政策，以及是否有有效的受信任時間戳記證明簽署發生於憑證仍有效的時段。不要僅依賴顯示的簽署時間作為受信任的時間戳記。

**已簽署的簡報仍能編輯嗎？**

可以。簽署不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請先完成簡報內容，最後再簽署最終版本。

**簡報可以包含多個簽章嗎？**

可以。在存檔前，先將每個簽章加入由 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 回傳的集合。驗證時，請檢查每個簽章，並確認所有必要的簽署者皆已在列。

**哪些簡報格式支援這些操作？**

Aspose.Slides 只在 PPTX 格式上支援本文件所述的數位簽章操作。PPT 與 OpenDocument 簡報格式不支援此 API 工作流程。

**我可以在不影響投影片的情況下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍會保留，只是儲存的檔案不再包含已移除的簽章證據。