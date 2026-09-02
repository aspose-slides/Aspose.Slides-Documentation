---
title: 為 PHP 簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "了解如何使用 PFX 憑證簽署現有的 PPTX 簡報，並透過 Java 在 PHP 中使用 Aspose.Slides 進行數位簽章的驗證或移除。"
---
## **概述**

數位簽章可協助收件人判斷是誰簽署了簡報，以及簽署的內容是否已變更。以下三個相關的安全概念在此尤為重要：

- **數位憑證** 是將身份與公鑰關聯的電子認證。可信任的憑證機構（CA）可以頒發憑證，或組織可使用自簽憑證於內部工作流程。
- **數位簽章** 由簡報內容與憑證持有者的私鑰產生。之後可使用憑證的公鑰驗證簽章。簽章提供來源與完整性的證據；它不會加密簡報。
- **密碼保護** 控制使用者是否能開啟或修改簡報。它與數位簽章分離，相關說明請參見[Password-Protected Presentations](/php-java/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **Add a Digital Signature** 指令。

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 可顯示簽章狀態通知。

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過 [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDigitalSignatures) 取得簽章，該方法會傳回一個 [DigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignaturecollection/)，其項目以 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignature/) 物件表示。簡報可以包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案（亦稱 PKCS#12 檔案），通常以 `.pfx` 或 `.p12` 為副檔名，可包含 X.509 憑證、其私鑰以及憑證鏈。私鑰允許持有人建立簽章。沒有可存取私鑰的憑證無法用於簽署簡報。

PFX 密碼用於保護憑證套件與私鑰。它 **不是** 用於開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至原始碼管理系統。在正式環境中，應限制對憑證檔案的存取，並從機密儲存或其他受保護的組態來源取得密碼。以下範例僅使用環境變數，以避免在程式碼中嵌入密碼。

## **將數位簽章加入簡報**

若要對實際簡報工作流程簽章，請載入現有 PPTX 檔案，從 PFX 憑證及其密碼建立 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignature/)，將簽章加入簡報的集合，然後儲存為 PPTX 檔案。

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

將結果儲存為新名稱可保留未簽署的原始檔案。透過 [DigitalSignature::setComments](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignature/setcomments/) 設定的值描述簽章的目的；它並非安全控制。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，檢查 [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDigitalSignatures) 回傳的每一項目。 [DigitalSignature::isValid](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignature/isvalid/) 方法會指出嵌入的簽章對於目前簡報內容是否有效。

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

驗證結果為無效，通常表示簽署後簡報內容或簽章資料已變更，或檔案已受損。移除所有簽章會產生未簽署的簡報，因此僅檢查項目的有效性並不足夠：安全性敏感的工作流程還必須驗證預期的簽章數量與預期的簽署者身分是否存在。

此有效性結果不應被視為完整的憑證可信度判斷。根據您的安全政策，應用程式可能還需建立並驗證 X.509 憑證鏈、檢查憑證有效日期與撤銷狀態、確認預期的主體或指紋、驗證金鑰用途，以及評估可信時間戳記。[DigitalSignature::getSignTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignature/getsigntime/) 本身並非來自可信時間戳記機構的證明。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。以下範例載入已簽署的 PPTX 檔案，使用 [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignaturecollection/clear/) 移除所有簽章，並儲存為未簽署的副本。

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

若僅需移除單一簽章，請以其零基索引呼叫 [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignaturecollection/removeat/)。除非您的工作流程明確要求覆寫已簽署的原始檔，否則請儲存為新檔案。

## **編輯與格式考量**

- 簽章不會使簡報變為唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 請在簽署前完成所有預定的編輯。若需變更簡報，請先儲存修訂後的簡報，然後重新對該修訂簽章。
- 保持最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 簽章作為有效簽章轉移到轉換後的檔案。
- 將憑證的私鑰視為機密。取得私鑰及其密碼的人可能能夠產生看似來自該憑證持有者的簽章。
- 當文件保留政策要求時，請保留未簽署的原始檔或其他受控副本。

## **常見問題**

**數位簽章會加密簡報嗎？**

否。數位簽章提供關於來源與完整性的證據，但簡報內容仍然可讀，除非另行加密。當必須限制對內容的存取時，請使用[密碼保護](/php-java/password-protected-presentation/)。

**PFX 密碼與簡報密碼相同嗎？**

否。PFX 密碼用於解鎖儲存在憑證套件中的私鑰，並不控制誰可以開啟或編輯 PPTX 檔案。

**我可以使用自簽憑證嗎？**

技術上，只要自簽憑證包含可存取的私鑰，即可使用。然而，收件人不會自動信任該憑證，除非該憑證已明確加入其可信環境。公開或跨組織工作流程通常使用受信任 CA 頒發的憑證。

**什麼情況會使簽章無效？**

在簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀也會導致驗證失敗。如果移除所有簽章，簡報將變為未簽署，而非包含無效簽章的檔案。

**有效的簽章表示我應該信任簽署者嗎？**

僅憑此並不足以。簽章完整性與簽署者的信任屬於不同的判斷。正式環境的驗證政策還應檢查憑證鏈、有效期限、撤銷狀態、預期身分、金鑰用途，以及任何可信時間戳記需求。

**憑證過期會發生什麼？**

憑證過期不會改變簡報的位元組，但會影響憑證可信度的評估。簽章是否仍被接受取決於您的政策，以及是否有有效的可信時間戳記證明簽署發生於憑證有效期間。請勿僅依賴顯示的簽署時間作為可信時間戳記。

**已簽署的簡報仍可編輯嗎？**

是的。簽章不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請先完成簡報並對最終修訂簽章。

**一個簡報可以包含多個簽章嗎？**

是的。在儲存之前，將每個簽章加入由 [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDigitalSignatures) 回傳的集合。驗證時，檢查每個簽章並確認所有必要的簽署者均存在。

**哪些簡報格式支援這些操作？**

Aspose.Slides 只在 PPTX 格式支援此處描述的數位簽章操作。PPT 與 OpenDocument 簡報格式不支援此 API 工作流程。

**我可以在不影響投影片的情況下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍然保留，但儲存的檔案不再包含已移除的簽章證據。