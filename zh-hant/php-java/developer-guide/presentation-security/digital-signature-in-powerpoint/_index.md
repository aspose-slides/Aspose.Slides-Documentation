---
title: 在 PHP 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/php-java/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證授權中心
- PFX 憑證
- PKCS#12
- 驗證簽章
- PowerPoint
- PPTX
- 簡報安全
- PHP
- Aspose.Slides
description: "了解如何使用 PFX 憑證簽署現有的 PPTX 簡報，並透過 Java 使用 Aspose.Slides for PHP 來驗證或移除數位簽章。"
---
## **概觀**

數位簽章協助接收者判斷是誰簽署了簡報以及簽署的內容是否已更改。此處有三個相關的安全概念：

- **數位憑證** 是將身分與公開金鑰關聯的電子憑證。受信任的憑證授權單位 (CA) 可以簽發憑證，或組織可使用自簽憑證於內部工作流程。
- **數位簽章** 由簡報內容與憑證持有者的私鑰產生。之後可使用憑證的公開金鑰驗證簽章。簽章提供來源與完整性的證據；它不會加密簡報。
- **密碼保護** 控制使用者是否能開啟或修改簡報。它與數位簽章分開，請參考[密碼保護的簡報](/slides/zh-hant/php-java/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **新增數位簽章** 指令。

![PowerPoint「保護簡報」功能表，已突出顯示「新增數位簽章」](add-digital-signature-in-powerpoint.png)

開啟簽署過的簡報後，PowerPoint 可以顯示簽章狀態通知。

![PowerPoint 通知，指出簡報包含有效的簽章](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過[Presentation::getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDigitalSignatures)公開簽章，該方法傳回一個[DigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignaturecollection/)，其項目以[DigitalSignature](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignature/)物件表示。簡報可以包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案（亦稱 PKCS#12 檔案，常見副檔名為 `.pfx` 或 `.p12`）可以包含 X.509 憑證、其私鑰以及憑證鏈。私鑰是持有者建立簽章的關鍵。沒有可存取私鑰的憑證無法用於簽署簡報。

PFX 密碼保護憑證封裝與私鑰。它**不是**開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至原始碼管理系統。在正式環境中，應限制對憑證檔案的存取，並從祕密儲存或其他受保護的組態來源取得密碼。以下範例僅使用環境變數，以避免將密碼硬編碼在程式碼中。

## **將數位簽章加入簡報**

要在真實的簡報工作流程中簽署，請載入現有的 PPTX 檔案，從 PFX 憑證與其密碼建立[DigitalSignature](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignature/)，將簽章加入簡報的集合，然後儲存為 PPTX 檔案。

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

將結果儲存為新檔名可保留未簽署的來源檔案。透過[DigitalSignature::setComments](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignature/setcomments/)設定的值說明簽章的用途；它不是安全控制項。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，請檢查[Presentation::getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDigitalSignatures)傳回的每個項目。[DigitalSignature::isValid](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignature/isvalid/) 方法會指出嵌入的簽章對目前的簡報內容是否有效。

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

無效結果通常意味著簽署後簡報內容或簽章資料已變更，或檔案受損。移除所有簽章會產生未簽署的簡報，因此僅檢查項目的有效性不足；安全敏感的工作流程還必須驗證預期的簽章數量與預期的簽署者身分是否存在。

此有效性結果不應被視為完整的憑證信任決策。根據您的安全政策，應用程式可能還需要建構並驗證 X.509 憑證鏈、檢查憑證有效日期與撤銷狀態、確認預期的主體或指紋、驗證金鑰用途，並評估受信任的時間戳記。[DigitalSignature::getSignTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignature/getsigntime/) 本身並非受信任時間戳記授權機構的證明。

## **移除數位簽章**

移除簽章會變更簡報的安全狀態。以下範例載入已簽署的 PPTX 檔案，使用[DigitalSignatureCollection::clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignaturecollection/clear/)移除所有簽章，並儲存未簽署的副本。

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

若只要移除單一簽章，請以零基索引呼叫[DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignaturecollection/removeat/)。除非工作流程明確要求覆寫已簽署的原始檔，否則請儲存為新檔案。

## **編輯與格式考量**

- 簽章不會使簡報變為唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。  
- 在簽署之前完成所有預期的編輯。若必須變更簡報，請先儲存修訂後的簡報，然後再次簽署該修訂。  
- 請保持最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 簽章轉移為轉換後檔案的有效簽章。  
- 將憑證的私鑰視為敏感資訊。取得私鑰與其密碼的任何人都可能建立看似來自該憑證持有者的簽章。  
- 當文件保存政策要求時，保留未簽署的來源或其他受控副本。

## **FAQ**

**數位簽章會加密簡報嗎？**

不會。數位簽章提供關於來源與完整性的證據，但簡報內容仍可閱讀，除非另行套用加密。若需限制對內容的存取，請使用[密碼保護的簡報](/slides/zh-hant/php-java/password-protected-presentation/)。

**PFX 密碼與簡報密碼相同嗎？**

不相同。PFX 密碼用來解鎖憑證封裝中的私鑰，並不控制誰可以開啟或編輯 PPTX 檔案。

**可以使用自簽憑證嗎？**

技術上，只要自簽憑證包含可存取的私鑰即可使用。但接收者不會自動信任它，除非該憑證已明確加入其受信任環境。公共或跨組織的工作流程通常使用受信任 CA 簽發的憑證。

**什麼會導致簽章無效？**

在簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀也會導致驗證失敗。若全部簽章被移除，簡報將成為未簽署的檔案，而非包含無效簽章的檔案。

**有效的簽章代表我應該信任簽署者嗎？**

僅憑簽章本身不能判斷可信度。簽章完整性與簽署者的信任是分開的決策。正式的驗證政策應同時檢查憑證鏈、有效期間、撤銷狀態、預期身分、金鑰用途以及任何受信任的時間戳記需求。

**憑證過期會發生什麼事？**

憑證過期不會改變簡報的位元組，但會影響憑證信任評估。簽章是否仍被接受取決於您的政策，以及是否有有效的受信任時間戳記證明簽署發生於憑證有效期間。不要僅依賴顯示的簽署時間作為受信任的時間戳記。

**已簽署的簡報仍能編輯嗎？**

可以。簽署不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，請先完成簡報內容，然後簽署最終修訂版。

**簡報可以包含多個簽章嗎？**

可以。在儲存之前，將每個簽章加入由[Presentation::getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDigitalSignatures)傳回的集合中。驗證時，請檢查每個簽章並確認所有必要的簽署者皆在。

**哪些簡報格式支援這些操作？**

Aspose.Slides 只在 PPTX 格式上支援此處描述的數位簽章操作。PPT 與 OpenDocument 簡報格式不受此 API 工作流程支援。

**我可以在不影響投影片的情況下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍然保留，但儲存的檔案不再包含已移除的簽章證據。