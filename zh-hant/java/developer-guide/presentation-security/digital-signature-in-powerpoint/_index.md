---
title: 在 Java 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/java/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證授權機構
- PFX 憑證
- PKCS#12
- 驗證簽章
- PowerPoint
- PPTX
- 簡報安全性
- Java
- Aspose.Slides
description: "了解如何使用 PFX 憑證簽署現有的 PPTX 簡報，並利用 Aspose.Slides for Java 來驗證或移除數位簽章。"
---
## **概述**

數位簽章可協助收件者判斷是誰簽署了簡報以及已簽署的內容是否有變更。此處有三個相關的安全概念：

- **數位憑證** 是將身分與公開金鑰關聯的電子憑證。受信任的憑證授權中心 (CA) 可以簽發憑證，或組織可使用自簽憑證作為內部工作流程。
- **數位簽章** 由簡報內容與憑證持有者的私密金鑰產生。之後可使用憑證的公開金鑰驗證簽章。簽章提供來源與完整性證據；它不會加密簡報。
- **密碼保護** 控制使用者是否能開啟或修改簡報。它與數位簽章分離，請參閱[受密碼保護的簡報](/java/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **新增數位簽章** 指令。

![PowerPoint 保護簡報功能表，已突顯「新增數位簽章」](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 會顯示簽章狀態通知。

![PowerPoint 通知指出簡報包含有效的簽章](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ipresentation/#getDigitalSignatures--)公開簽章，該方法會回傳一個[IDigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.idigitalsignaturecollection/)，其項目實作[IDigitalSignature](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.idigitalsignature/)。簡報可以包含多個簽章。

## **了解 PFX 憑證和密碼**

PFX 檔案（亦稱 PKCS#12 檔案，通常副檔名為 `.pfx` 或 `.p12`）可以包含 X.509 憑證、其私密金鑰與憑證鏈。私密金鑰允許持有人建立簽章。沒有可存取私密金鑰的憑證無法用來簽署簡報。

PFX 密碼保護憑證套件與私密金鑰。它**不是**開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至來源控制。在正式環境中，應限制對憑證檔案的存取，並從祕密儲存或其他受保護的設定來源取得密碼。以下範例僅使用環境變數，以避免在程式碼中嵌入密碼。

## **將數位簽章新增至簡報**

要在實際簡報工作流程中簽署，請載入現有 PPTX 檔案，使用 PFX 憑證及其密碼建立[DigitalSignature](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.digitalsignature/)，將簽章加入簡報的集合，然後存為 PPTX 檔案。

```java
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

以新名稱儲存結果可保留未簽署的來源檔案。使用[IDigitalSignature.setComments](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.idigitalsignature/#setComments-java.lang.String-)設定的值說明簽章用途；它不是安全控制項。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，檢查[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ipresentation/#getDigitalSignatures--)回傳的每個項目。[IDigitalSignature.isValid](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.idigitalsignature/#isValid--) 方法指出嵌入的簽章是否對目前的簡報內容有效。

```java
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

無效結果通常表示簽署後簡報內容或簽章資料已變更，或檔案受損。移除所有簽章會產生未簽署的簡報，因此僅檢查項目有效性不足：安全敏感的工作流程還必須確認預期的簽章數量與簽署者身分是否齊全。

此有效性結果不應視為完整的憑證信任判斷。依照您的安全政策，應用程式可能還需建構並驗證 X.509 憑證鏈、檢查憑證有效日期與撤銷狀態、確認預期的主體或指紋、驗證金鑰用途，並評估可信時間戳記。[IDigitalSignature.getSignTime](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.idigitalsignature/#getSignTime--) 本身並非可信時間戳記機構的證明。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。以下範例載入已簽署的 PPTX 檔案，使用[IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.idigitalsignaturecollection/#clear--)移除所有簽章，並儲存未簽署的副本。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若只要移除單一簽章，請以零基索引呼叫[IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.idigitalsignaturecollection/#removeAt-int-)。除非工作流程明確要求覆寫已簽署的原始檔，否則請儲存為新檔案。

## **編輯與格式考量**

- 簽章不會將簡報設為唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 在簽署前完成所有預期的編輯。如果必須變更簡報，請先儲存修訂版，再對該修訂版重新簽章。
- 請保留最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 簽章作為有效簽章轉移至轉換後的檔案。
- 將憑證的私密金鑰視為敏感資訊。取得私密金鑰及其密碼的任何人，都可能偽造看似來自該憑證持有者的簽章。
- 若文件保存政策要求，請保留未簽署的來源或其他受控副本。

## **常見問題**

**數位簽章會加密簡報嗎？**

不會。數位簽章提供關於來源與完整性的證據，但簡報內容仍可閱讀，除非另行加密。若需要限制內容存取，請使用[密碼保護](/java/password-protected-presentation/)。

**PFX 密碼與簡報密碼是否相同？**

不相同。PFX 密碼用於解鎖憑證套件內的私密金鑰，並不控制誰能開啟或編輯 PPTX 檔案。

**可以使用自簽憑證嗎？**

技術上，只要自簽憑證包含可存取的私密金鑰就能使用。但收件者不會自動信任，除非該憑證已明確加入其信任環境。公開或跨組織工作流程通常使用受信任 CA 簽發的憑證。

**什麼情況會使簽章失效？**

簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀也會導致驗證失敗。若全部簽章被移除，簡報將變為未簽署，而非包含無效簽章的檔案。

**有效的簽章是否代表我應該信任簽署者？**

僅憑簽章本身不足以決定信任。生產環境的驗證政策應同時檢查憑證鏈、有效期限、撤銷狀態、預期身分、金鑰用途以及任何可信時間戳記需求。

**憑證過期會發生什麼事？**

憑證過期不會改變簡報的位元組，但會影響憑證信任的評估。簽章是否仍被接受取決於您的政策以及是否有可信時間戳記證明簽署發生於憑證有效期間。請勿僅依賴顯示的簽署時間作為可信時間戳記。

**已簽署的簡報仍然可以編輯嗎？**

可以。簽署不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請先完成簡報，然後對最終版本簽章。

**簡報可以包含多個簽章嗎？**

可以。在儲存前，將每個簽章加入[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ipresentation/#getDigitalSignatures--)回傳的集合。驗證時，請檢查每個簽章並確認所有必要的簽署者皆在。

**哪些簡報格式支援這些操作？**

Aspose.Slides 只在 PPTX 格式上支援此處描述的數位簽章操作。PPT 與 OpenDocument 簡報格式不受此 API 工作流程支援。

**我可以在不影響投影片內容的情況下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍然保留，但已儲存的檔案不再包含被移除的簽章證據。