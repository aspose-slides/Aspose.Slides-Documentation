---
title: 在 Android 上為簡報加入數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/androidjava/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證授權單位
- PFX 憑證
- PKCS#12
- 驗證簽章
- PowerPoint
- PPTX
- 簡報安全
- Android
- Java
- Aspose.Slides
description: "了解如何使用 PFX 憑證為現有 PPTX 簡報簽章，以及透過 Java 使用 Aspose.Slides for Android 來驗證或移除數位簽章。"
---
## **概述**

數位簽章可協助接收者判斷是誰簽署了簡報，以及簽署的內容是否已變更。此處有三個相關的安全概念相當重要：

- **數位憑證** 是將身分與公鑰關聯的電子憑證。受信任的憑證授權中心 (CA) 可頒發憑證，或組織可使用自行簽署的憑證於內部工作流程。
- **數位簽章** 由簡報內容與憑證持有者的私鑰產生。之後可使用憑證的公鑰驗證簽章。簽章提供來源與完整性證據；它不會加密簡報。
- **密碼保護** 控制使用者是否能開啟或修改簡報。它與數位簽章分開，請參考 [Password-Protected Presentations](/slides/zh-hant/androidjava/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **Add a Digital Signature** 指令。

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 可顯示簽章狀態通知。

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過 [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) 取得簽章集合，該集合的項目實作 [IDigitalSignature](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idigitalsignature/)。簡報可包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案（亦稱 PKCS#12 檔案，常用 `.pfx` 或 `.p12` 副檔名）可包含 X.509 憑證、其私鑰與憑證鏈。私鑰是讓持有人能建立簽章的關鍵。若憑證沒有可存取的私鑰，則無法用來簽署簡報。

PFX 密碼保護憑證封裝與私鑰。它**不是**開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至原始碼控制系統。於正式環境中，應限制對憑證檔案的存取，並從密碼庫或其他受保護的組態來源取得密碼。以下範例僅使用環境變數，以避免在程式碼中嵌入密碼。

## **將數位簽章加入簡報**

要在實際的簡報工作流程中簽署，請載入既有 PPTX 檔案，使用 PFX 憑證與其密碼建立 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/digitalsignature/)，將簽章加入簡報的集合，最後儲存為 PPTX 檔案。

```java
import com.aspose.slides.*;

String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

將結果儲存為新檔名，可保留未簽署的來源檔案。透過 [IDigitalSignature.setComments](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) 設定的值描述簽章用途；它並非安全控制項。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，請檢查由 [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) 取得的每個項目。[IDigitalSignature.isValid](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idigitalsignature/#isValid--) 方法會指出嵌入的簽章對目前簡報內容是否有效。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

無效的結果通常表示簽署後簡報內容或簽章資料已變更，或檔案受損。移除所有簽章會產生未簽署的簡報，僅檢查項目是否有效不足以保證安全：敏感工作流程必須同時驗證預期的簽章數量與簽署者身分是否完整。

此有效性結果不應被視為完整的憑證信任判斷。依照您的安全政策，應用程式可能還需要建構並驗證 X.509 憑證鏈、檢查憑證有效期與撤銷狀態、確認預期的主旨或指紋、驗證金鑰用途，並評估受信任的時間戳記。僅憑 [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) 回傳的時間，無法證明來自受信任的時間戳記授權機構。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。以下範例載入已簽署的 PPTX 檔案，使用 [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) 移除所有簽章，並儲存為未簽署的副本。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若只想移除單一簽章，請以零起始索引呼叫 [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-)。除非工作流程明確要求覆寫已簽署的原始檔，否則請儲存為新檔案。

## **編輯與格式考量**

- 簽章不會使簡報變成唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 請在簽署前完成所有預期的編輯。若必須變更簡報，請先儲存修訂版，再對該修訂版重新簽署。
- 請保留最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 簽章轉為目標檔案的有效簽章。
- 將憑證私鑰視為機密。任何取得私鑰與其密碼的人，都可能冒充該憑證持有人建立簽章。
- 若文件保存政策要求，請保留未簽署的來源或其他受控副本。

## **常見問題**

**數位簽章會加密簡報嗎？**

不會。數位簽章提供關於來源與完整性的證據，但除非另行加密，簡報內容仍可被讀取。若需限制內容存取，請使用 [password protection](/slides/zh-hant/androidjava/password-protected-presentation/)。

**PFX 密碼與簡報密碼是同一個嗎？**

不是。PFX 密碼用於解鎖憑證套件中的私鑰，並不控制誰能開啟或編輯 PPTX 檔案。

**可以使用自行簽署的憑證嗎？**

技術上，只要自行簽署的憑證包含可存取的私鑰，就能使用。但除非已明確加入收件者的受信任環境，否則收件者不會自動信任該憑證。公用或跨組織的工作流程通常會使用受信任 CA 頒發的憑證。

**什麼情況會使簽章無效？**

在簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀亦可能導致驗證失敗。若全部簽章被移除，簡報將變成未簽署，而不是包含無效簽章的檔案。

**有效的簽章是否代表應信任簽署者？**

僅憑此並不構成信任。簽章完整性與簽署者信任是分開的判斷。正式的驗證政策應同時檢查憑證鏈、有效期間、撤銷狀態、預期身分、金鑰用途以及任何受信任的時間戳記需求。

**憑證過期後會怎樣？**

憑證過期不會改變簡報的位元組，但會影響憑證信任的評估。簽章是否仍被接受取決於您的政策，以及是否有有效的受信任時間戳記證明簽署發生於憑證有效期間。請勿僅依賴顯示的簽署時間作為受信任的時間戳記。

**已簽署的簡報仍能編輯嗎？**

可以。簽署本身不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請在最後階段完成簡報並簽署最終修訂版。

**簡報可以包含多個簽章嗎？**

可以。在儲存前，將每個簽章加入由 [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) 回傳的集合中。驗證時，請檢查每個簽章並確認所有必要的簽署者皆已出現。

**哪些簡報格式支援這些操作？**

Aspose.Slides 僅在 PPTX 格式上支援此處描述的數位簽章操作。PPT 與 OpenDocument 簡報格式不受此 API 工作流程支援。

**可以在不影響投影片的情況下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍然保留，但已儲存的檔案不會再包含被移除的簽章證據。