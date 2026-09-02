---
title: 在 Java 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/java/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證機構
- PFX 憑證
- PKCS#12
- 驗證簽章
- PowerPoint
- PPTX
- 簡報安全
- Java
- Aspose.Slides
description: "了解如何使用 PFX 憑證簽署現有的 PPTX 簡報，並使用 Aspose.Slides for Java 來驗證或移除數位簽章。"
---
## **概觀**

數位簽章可協助接收者辨識是誰簽署了簡報，以及已簽署的內容是否已變更。此處有三個相關的安全概念很重要：

- **數位憑證** 是一種將身分與公鑰關聯的電子證書。可信任的憑證機構（CA）可以頒發憑證，或組織可使用自簽憑證來執行內部工作流程。
- **數位簽章** 由簡報內容與憑證持有者的私鑰產生。之後可使用憑證的公鑰驗證簽章。簽章提供來源與完整性的證據；它不會對簡報進行加密。
- **密碼保護** 控制使用者是否能開啟或修改簡報。它與數位簽章是分開的，相關說明請參見[Password-Protected Presentations](/slides/zh-hant/java/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **Add a Digital Signature** 功能。

![PowerPoint 保護簡報選單，突出顯示「Add a Digital Signature」](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 會顯示簽章狀態通知。

![PowerPoint 通知指出簡報包含有效的簽章](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getDigitalSignatures--)取得簽章，該方法傳回一個[IDigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idigitalsignaturecollection/)，其項目實作[IDigitalSignature](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idigitalsignature/)。一個簡報可以包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案（亦稱 PKCS#12 檔案，常見副檔名為 `.pfx` 或 `.p12`）可包含 X.509 憑證、其私鑰以及憑證鏈。私鑰是持有人建立簽章的關鍵。沒有可取得私鑰的憑證無法用來簽署簡報。

PFX 密碼保護憑證封裝與私鑰。它**不是**開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至原始碼控制。正式環境中，應限制對憑證檔案的存取，並從機密儲存或其他受保護的設定來源取得密碼。以下範例僅使用環境變數以避免在程式碼中內嵌密碼。

## **將數位簽章加入簡報**

要對實際簡報工作流程進行簽署，請載入現有 PPTX 檔案，從 PFX 憑證與其密碼建立[DigitalSignature](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/digitalsignature/)，將簽章加入簡報的集合，然後儲存為 PPTX 檔案。

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

將結果另存新檔可保留未簽署的來源檔案。[IDigitalSignature.setComments](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) 設定的值說明簽章的用途；它不是安全控制項。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，請檢查[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getDigitalSignatures--)傳回的每個項目。[IDigitalSignature.isValid](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idigitalsignature/#isValid--) 方法會指示嵌入的簽章對目前的簡報內容是否有效。

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

無效結果通常表示簽署後簡報內容或簽章資料已變更，或檔案已損毀。移除所有簽章會產生未簽署的簡報，因此僅檢查項目的有效性不足：安全敏感的工作流程必須同時驗證預期的簽章數量與預期的簽署者身分是否存在。

此有效性結果不應被視為完整的憑證信任判斷。根據您的安全政策，應用程式可能還需要建構並驗證 X.509 憑證鏈、檢查憑證有效日期與撤銷狀態、確認預期的主體或指紋、驗證金鑰使用情形，並評估受信任的時間戳記。[IDigitalSignature.getSignTime](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idigitalsignature/#getSignTime--) 的值本身並非受信任時間戳記機構的證明。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。以下範例載入已簽署的 PPTX 檔案，使用[IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idigitalsignaturecollection/#clear--) 移除全部簽章，然後儲存未簽署的副本。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若只想移除單一簽章，請以零基索引呼叫[IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-)。除非工作流程明確要求覆寫已簽署的原始檔，否則請另存新檔。

## **編輯與格式考量**

- 簽章不會使簡報變成唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 在簽署之前完成所有預期的編輯。如果必須變更簡報，請先儲存修訂後的簡報，然後再次簽署該版本。
- 保持最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 簽章轉移為該轉換檔案的有效簽章。
- 將憑證的私鑰視為敏感資訊。任何取得私鑰及其密碼的人，都可能偽造看似由該憑證持有人簽署的簽章。
- 當文件保存政策要求時，保留未簽署的原始檔或其他受控制的副本。

## **常見問題**

**數位簽章會加密簡報嗎？**

不會。數位簽章提供關於來源與完整性的證據，但簡報內容仍可讀取，除非另行加密。若需限制內容存取，請使用[password protection](/slides/zh-hant/java/password-protected-presentation/)。

**PFX 密碼與簡報密碼相同嗎？**

不同。PFX 密碼用來解鎖憑證封裝內的私鑰，並不控制誰可以開啟或編輯 PPTX 檔案。

**可以使用自簽憑證嗎？**

技術上，只要自簽憑證包含可取得的私鑰即可使用。然而除非已明確將該憑證加入受信任環境，收件者不會自動信任它。公共或跨組織的工作流程通常使用受信任 CA 頒發的憑證。

**什麼會使簽章失效？**

簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀也會導致驗證失敗。若全部簽章被移除，簡報會變成未簽署，而非包含無效簽章的檔案。

**有效的簽章是否代表我應該信任簽署者？**

僅憑簽章本身不足以決定信任。簽章完整性與簽署者信任是分開的判斷。正式的驗證政策應同時檢查憑證鏈、有效期間、撤銷狀態、預期身分、金鑰使用情形，以及任何受信任的時間戳記需求。

**憑證過期會怎樣？**

憑證過期不會改變簡報的位元組，但會影響憑證信任的評估。簽章是否仍被接受取決於您的政策以及是否有有效的受信任時間戳記證明簽署發生於憑證有效期間。切勿僅依賴顯示的簽署時間作為受信任的時間戳記。

**已簽署的簡報仍能編輯嗎？**

可以。簽署不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，請先完成簡報後再簽署最終版本。

**簡報可以包含多個簽章嗎？**

可以。在儲存之前，將每個簽章加入由[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getDigitalSignatures--)傳回的集合中。驗證時，請檢查每個簽章並確認所有必需的簽署者皆已出現。

**哪些簡報格式支援這些操作？**

Aspose.Slides 目前僅在 PPTX 格式中支援本文所述的數位簽章操作。PPT 與 OpenDocument 簡報格式不支援此 API 工作流程。

**我可以在不影響投影片的情況下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍然保留，但已儲存的檔案不再包含被移除的簽章證據。