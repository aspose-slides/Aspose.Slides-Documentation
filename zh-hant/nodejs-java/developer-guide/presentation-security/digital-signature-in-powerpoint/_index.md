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
- PKCS#12
- 驗證簽章
- PowerPoint
- PPTX
- 簡報安全性
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 PFX 憑證為現有 PPTX 簡報簽章，並透過 Java 使用 Aspose.Slides for Node.js 進行驗證或移除數位簽章。"
---
## **概觀**

數位簽章協助收件者判斷是誰簽署了簡報，以及已簽署的內容是否已變更。此處有三個相關的安全概念很重要：

- **數位憑證** 是將身分與公鑰關聯的電子憑證。受信任的憑證授權單位 (CA) 可以頒發憑證，或是組織使用自行簽發的憑證作為內部工作流程。
- **數位簽章** 由簡報內容與憑證持有者的私鑰產生。之後可使用憑證的公鑰驗證簽章。簽章提供來源與完整性的證據；它不會加密簡報。
- **密碼保護** 控制使用者是否能開啟或修改簡報。它與數位簽章分開，請參考[受密碼保護的簡報](/slides/zh-hant/nodejs-java/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **新增數位簽章** 命令。

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 會顯示簽章狀態通知。

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 取得 [DigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignaturecollection/)，其中包含 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignature/) 物件。簡報可以包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案（亦稱 PKCS#12 檔案，常見副檔名為 `.pfx` 或 `.p12`）可以包含 X.509 憑證、其私鑰，以及憑證鏈。私鑰是持有者建立簽章的關鍵。沒有可存取私鑰的憑證無法用來簽署簡報。

PFX 密碼保護憑證套件與私鑰。它**不是**用來開啟或編輯簡報的密碼。不要將 PFX 檔案或其密碼提交至原始碼管理系統。於正式環境中，應限制對憑證檔案的存取，並從祕密儲存庫或其他受保護的設定來源取得密碼。下列範例僅使用環境變數，以免將密碼寫入程式碼。

## **向簡報新增數位簽章**

要在真實的簡報工作流程中簽章，請載入現有的 PPTX 檔案，從 PFX 憑證及其密碼建立 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignature/)，將簽章加入簡報的集合，然後儲存為 PPTX 檔。

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

將結果儲存為新檔名可保留未簽署的來源檔。透過 [DigitalSignature.setComments](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignature/) 設定的值描述簽章的用途；它不是安全控制。

## **驗證數位簽章**

載入已簽署的 PPTX 檔時，請檢查 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 回傳的每個項目。使用 [DigitalSignature.isValid](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignature/) 方法判斷嵌入的簽章對目前簡報內容是否有效。

以下範例亦使用 Node.js 的 `X509Certificate` 類別，從每個嵌入的憑證讀取主體名稱。

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

驗證失敗通常表示簽署後簡報內容或簽章資料已變更，或檔案受損。移除所有簽章會得到未簽署的簡報，因此僅檢查項目是否有效不足以保證安全：敏感的工作流程必須同時驗證預期的簽章數量與簽署者身分是否齊全。

此有效性結果不應視為完整的憑證信任判斷。根據您的安全政策，應用程式可能還需要建構並驗證 X.509 憑證鏈、檢查憑證有效日期與撤銷狀態、確認預期的主體或指紋、驗證金鑰用途，並評估受信任的時間戳記。單獨的 [DigitalSignature.getSignTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignature/) 值並非來自可信時間戳記授權機構的證明。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。以下範例載入已簽署的 PPTX 檔，使用 [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) 移除所有簽章，然後儲存未簽署的副本。

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

若只想移除單一簽章，請以零為起點的索引呼叫 [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/)。除非工作流程明確要求覆寫已簽署的原檔，否則請儲存為新檔。

## **編輯與格式考量**

- 簽章不會使簡報成為唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 在簽章前完成所有預期的編輯。若必須變更簡報，請先儲存修訂後的簡報，再對該修訂重新簽章。
- 請保留最終輸出為 PPTX 格式。將已簽署的簡報轉換成其他格式不會將原始 PPTX 簽章轉移為轉換後檔案的有效簽章。
- 將憑證的私鑰視為敏感資訊。取得私鑰及其密碼的任何人，都可能偽造看似由該憑證持有人簽署的簽章。
- 當文件保留政策要求時，保留未簽署的來源檔或其他受控副本。

## **常見問題**

**數位簽章會加密簡報嗎？**

不會。數位簽章提供關於來源與完整性的證據，但簡報內容仍可閱讀，除非另行加密。若需限制內容存取，請使用[密碼保護](/slides/zh-hant/nodejs-java/password-protected-presentation/)。

**PFX 密碼與簡報密碼是否相同？**

不是。PFX 密碼用於解鎖憑證套件中的私鑰，並不控制誰能開啟或編輯 PPTX 檔案。

**可以使用自行簽發的憑證嗎？**

技術上，只要自行簽發的憑證包含可存取的私鑰，即可使用。然而收件者不會自動信任它，除非該憑證已明確加入其受信任環境。公用或跨組織的工作流程通常使用受信任 CA 頒發的憑證。

**什麼情況會使簽章失效？**

在簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀也可能導致驗證失敗。若全部簽章被移除，簡報僅為未簽署，而非包含無效簽章的檔案。

**有效的簽章是否代表應該信任簽署者？**

僅憑此不足以決定信任。簽章完整性與簽署者信任是分開的判斷。正式的驗證政策還應檢查憑證鏈、有效期限、撤銷狀態、預期身份、金鑰用途以及任何受信任的時間戳記需求。

**憑證過期會發生什麼事？**

憑證過期不會改變簡報的位元組，但會影響憑證信任的評估。簽章是否仍被接受取決於您的政策，以及是否有有效的受信任時間戳記證明簽署發生於憑證有效期間。不要僅依賴顯示的簽署時間作為受信任的時間戳記。

**已簽署的簡報仍能編輯嗎？**

可以。簽章不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請先完成簡報，然後簽署最終版本。

**簡報可以包含多個簽章嗎？**

可以。在儲存前，將每個簽章加入由 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 回傳的集合。驗證時，檢查每個簽章並確認所有必須的簽署者均已出現。

**哪些簡報格式支援這些操作？**

Aspose.Slides 只在 PPTX 格式上支援此處描述的數位簽章操作。PPT 與 OpenDocument 簡報格式不支援此 API 工作流程。

**我可以在不影響投影片內容的情況下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍會保留，但儲存的檔案將不再攜帶已移除的簽章證據。