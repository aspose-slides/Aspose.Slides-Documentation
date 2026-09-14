---
title: 在 Python 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/python-java/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "了解如何使用 PFX 憑證簽署現有的 PPTX 簡報，並透過 Java 為 Python 使用 Aspose.Slides 來驗證或移除數位簽章。"
---
## **概觀**

數位簽章協助接收者判斷是誰簽署了簡報，以及已簽署的內容是否已變更。在此有三個相關的安全概念需要注意：

- **數位憑證** 是一種將身分與公鑰關聯的電子憑證。受信任的憑證授權中心 (CA) 可以頒發憑證，或是組織可在內部工作流程中使用自簽憑證。
- **數位簽章** 由簡報內容與憑證持有者的私鑰所產生。之後可使用憑證的公鑰驗證簽章。簽章提供來源與完整性的證據；但不會加密簡報。
- **密碼保護** 控制使用者是否能開啟或修改簡報。它與數位簽章是分開的，相關說明請參考 [Password-Protected Presentations](/slides/zh-hant/python-java/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 中提供 **新增數位簽章** 指令。

![PowerPoint 保護簡報功能表，突出顯示「新增數位簽章」](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 可以顯示簽章狀態通知。

![PowerPoint 通知指出簡報包含有效簽章](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getDigitalSignatures) 取得簽章，該方法會回傳 [DigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/digitalsignaturecollection/)，其項目為 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/digitalsignature/) 的實例。簡報可以包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案（亦稱為 PKCS#12 檔案，常見副檔名為 `.pfx` 或 `.p12`）可包含 X.509 憑證、其私鑰以及憑證鏈。私鑰使持有人能產生簽章。若憑證未包含可取得的私鑰，則無法用來簽署簡報。

PFX 密碼保護憑證套件與私鑰。它 **不是** 用於開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至原始碼管理系統。於正式環境中，應限制對憑證檔案的存取，並從祕密儲存或其他受保護的組態來源取得密碼。以下範例僅使用環境變數，以避免在程式碼中嵌入密碼。

## **將數位簽章加入簡報**

要在真實的簡報工作流程中簽署，請載入現有的 PPTX 檔案，從 PFX 憑證與其密碼建立 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/digitalsignature/)，將簽章加入簡報的集合，然後儲存為 PPTX 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

將結果另存為新檔名可保留未簽署的來源檔案。透過 [DigitalSignature.setComments](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/digitalsignature/#setComments) 設定的值說明簽章的目的；它不是安全控制措施。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，請檢查由 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getDigitalSignatures) 回傳的每個項目。[DigitalSignature.isValid](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/digitalsignature/#isValid) 方法會指出嵌入的簽章對目前的簡報內容是否有效。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

驗證失敗通常表示簽署後，簡報內容或簽章資料已被變更，或檔案受損。移除所有簽章會產生未簽署的簡報，因此僅檢查項目是否有效不足以保證安全；安全敏感的工作流程必須同時驗證簽章的預期數量與預期簽署者身分是否存在。

此有效性結果不應被視為完整的憑證信任判斷。依照您的安全政策，應用程式可能還需要建構與驗證 X.509 憑證鏈、檢查憑證有效日期與撤銷狀態、確認預期的主體或指紋、驗證金鑰用途，並評估可信時間戳記。[DigitalSignature.getSignTime](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/digitalsignature/#getSignTime) 本身並非來自可信時間戳記機構的證明。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。下列範例載入已簽署的 PPTX 檔案，使用 [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/digitalsignaturecollection/#clear) 移除所有簽章，並儲存為未簽署的副本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若僅移除單一簽章，請以其從零開始的索引呼叫 [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/digitalsignaturecollection/#removeAt)。除非工作流程明確規定要覆寫已簽署的原檔，否則請儲存為新檔案。

## **編輯與格式考量**

- 簽章不會使簡報變為唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 請在簽署前完成所有預期的編輯。若必須變更簡報，請先儲存修訂後的簡報，然後再次簽署該修訂版。
- 請將最終輸出保持為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 簽章轉移為該轉換檔案的有效簽章。
- 請將憑證的私鑰視為敏感資訊。任何取得私鑰與其密碼的人，都可能偽造看似來自該憑證持有者的簽章。
- 當文件保存政策要求時，保留未簽署的來源或其他受控副本。

## **常見問題**

**數位簽章會加密簡報嗎？**

不會。數位簽章提供關於來源與完整性的證據，但除非另行加密，簡報內容仍可讀取。若必須限制對內容的存取，請使用 [password protection](/slides/zh-hant/python-java/password-protected-presentation/)。

**PFX 密碼與簡報密碼相同嗎？**

不是。PFX 密碼用於解鎖憑證套件中儲存的私鑰。它不會控制誰能開啟或編輯 PPTX 檔案。

**我可以使用自簽憑證嗎？**

在技術上，只要自簽憑證包含可取得的私鑰就能使用。然而，收件人不會自動信任該憑證，除非已明確將其加入受信任環境。公開或跨組織的工作流程通常會使用受信任 CA 頒發的憑證。

**什麼情況會使簽章無效？**

在簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀也會導致驗證失敗。如果移除所有簽章，簡報將變成未簽署，而非包含無效簽章的檔案。

**有效的簽章是否代表我應該信任簽署者？**

僅憑此並不足以。簽章完整性與簽署者信任是兩個獨立的判斷。正式環境的驗證政策還應檢查憑證鏈、有效期限、撤銷狀態、預期身分、金鑰用途，以及任何可信時間戳記需求。

**憑證過期時會發生什麼情況？**

憑證過期不會改變簡報的位元組，但會影響憑證信任的評估。簽章是否仍被接受取決於您的政策，以及是否有有效的可信時間戳記證明簽署發生時憑證仍在有效期內。不要僅依賴顯示的簽署時間作為可信時間戳記。

**已簽署的簡報仍能編輯嗎？**

可以。簽署不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請先完成簡報，然後簽署最終修訂版。

**簡報可以包含多個簽章嗎？**

可以。在儲存之前，將每個簽章加入由 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getDigitalSignatures) 回傳的集合中。驗證時，檢查每個簽章並確認所有必要的簽署者皆在。

**哪些簡報格式支援這些操作？**

Aspose.Slides 僅在 PPTX 格式中支援此處描述的數位簽章操作。PPT 與 OpenDocument 簡報格式不支援此 API 工作流程。

**我可以在不影響投影片的情況下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍保留，但已儲存的檔案不再包含已移除的簽章證據。