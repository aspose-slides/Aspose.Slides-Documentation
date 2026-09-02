---
title: 在 Python 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/python-net/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "了解如何使用 PFX 憑證為現有 PPTX 簡報簽章，並透過 .NET 使用 Aspose.Slides for Python 來驗證或移除數位簽章。"
---
## **概觀**

數位簽章協助接收者判斷誰簽署了簡報，以及已簽署的內容是否已變更。此處有三個相關的安全概念：

- **數位憑證** 是將身分與公鑰關聯的電子憑證。受信任的憑證授權單位（CA）可以簽發憑證，或組織可以使用自簽憑證於內部工作流程。
- **數位簽章** 由簡報內容與憑證持有者的私鑰產生。之後可使用憑證的公鑰驗證簽章。簽章提供來源與完整性證據；它不會加密簡報。
- **密碼保護** 控制使用者是否可以開啟或修改簡報。它與數位簽章分開，請參閱[受密碼保護的簡報](/python-net/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **新增數位簽章** 命令。

![PowerPoint「保護簡報」功能表，已標示「新增數位簽章」](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 會顯示簽章狀態通知。

![PowerPoint 通知指出簡報包含有效的簽章](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過 [Presentation.digital_signatures](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/digital_signatures/) 這個 [DigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignaturecollection/)（其項目為 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/) 物件）公開簽章。簡報可以包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案（又稱 PKCS#12 檔案，通常副檔名為 `.pfx` 或 `.p12`）可以包含 X.509 憑證、其私鑰以及憑證鏈。私鑰使持有者能建立簽章。沒有可取得私鑰的憑證無法用來簽署簡報。

PFX 密碼保護憑證套件與私鑰。它 **不是** 開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至原始碼管理系統。於正式環境中，應限制對憑證檔案的存取，並從機密儲存或其他受保護的設定來源取得其密碼。以下示例僅使用環境變數以避免在程式碼中嵌入密碼。

## **將數位簽章新增至簡報**

要在真實簡報工作流程中簽章，請載入現有 PPTX 檔案，從 PFX 憑證與其密碼建立 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/)，將簽章加入簡報的集合，最後儲存為 PPTX 檔案。

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

將結果儲存為新檔名可保留未簽署的來源檔案。[DigitalSignature.comments](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/comments/) 用於說明簽章目的，並非安全控制。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，檢查 [Presentation.digital_signatures](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/digital_signatures/) 中的每一項。[DigitalSignature.is_valid](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/is_valid/) 屬性指出嵌入的簽章對目前的簡報內容是否有效。

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

無效的結果通常表示簽署後簡報內容或簽章資料已變更，或檔案受損。移除所有簽章會產生未簽署的簡報，所以僅檢查項目有效性不足：安全敏感的工作流程必須同時驗證預期的簽章數量與預期的簽署者身分是否存在。

[DigitalSignature.certificate](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/certificate/) 屬性以位元組陣列提供憑證資料。範例會計算其 SHA‑256 指紋，以便應用程式將其與預期簽署者憑證的指紋進行比對。

此有效性結果不應被視為完整的憑證信任判斷。依據您的安全政策，應用程式可能還需要建構與驗證 X.509 憑證鏈、檢查憑證有效日期與撤銷狀態、確認預期的主旨或指紋、驗證金鑰用途，並評估受信任的時間戳記。[DigitalSignature.sign_time](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/sign_time/) 本身並非來自受信任時間戳記機構的證明。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。以下範例載入已簽署的 PPTX 檔案，使用 [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignaturecollection/clear/) 移除所有簽章，並儲存為未簽署的副本。

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

若只要移除單一簽章，請以零為基礎的索引呼叫 [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignaturecollection/remove_at/)。除非工作流程明確需要覆寫已簽署的原始檔，否則請儲存為新檔案。

## **編輯與格式考量**

- 簽章不會使簡報變為唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 請在簽署前完成所有預期的編輯。若必須變更簡報，請先儲存修訂後的簡報，再重新簽署該修訂版。
- 請保留最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 簽章轉移為轉換後檔案的有效簽章。
- 將憑證的私鑰視為敏感資訊。取得私鑰及其密碼的任何人都可能偽造看似來自該憑證持有者的簽章。
- 當文件保存政策需要時，請保留未簽署的來源或其他受控副本。

## **常見問題**

**數位簽章會加密簡報嗎？**

不會。數位簽章提供關於來源與完整性的證據，但簡報內容仍可讀取，除非另行使用加密。若需要限制內容存取，請使用[受密碼保護的簡報](/python-net/password-protected-presentation/)。

**PFX 密碼與簡報密碼相同嗎？**

不相同。PFX 密碼用於解鎖憑證套件中儲存的私鑰，並不控制誰可以開啟或編輯 PPTX 檔案。

**我可以使用自簽憑證嗎？**

技術上，只要自簽憑證包含可存取的私鑰即可使用。然而收件人不會自動信任該憑證，除非其已被明確加入其受信任環境。公開或跨組織的工作流程通常使用受信任 CA 簽發的憑證。

**什麼情況會使簽章無效？**

在簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀也會導致驗證失敗。若全部簽章被移除，簡報則為未簽署，而非包含無效簽章的檔案。

**有效的簽章是否代表我應該信任簽署者？**

僅憑簽章本身並不能保證簽署者可信。簽章完整性與簽署者信任是分開的判斷。正式的驗證政策應同時檢查憑證鏈、有效期間、撤銷狀態、預期身分、金鑰用途以及任何受信任的時間戳記需求。

**憑證過期會發生什麼事？**

憑證過期不會改變簡報的位元組，但會影響憑證信任的評估。簽章是否仍可接受取決於您的政策，以及是否有有效的受信任時間戳記證明簽署發生於憑證仍有效期間。不要僅依賴顯示的簽署時間作為受信任的時間戳記。

**已簽署的簡報仍能編輯嗎？**

可以。簽署不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請先完成簡報並簽署最終版本。

**簡報可以包含多個簽章嗎？**

可以。請在儲存前將每個簽章新增至 [Presentation.digital_signatures]，驗證時檢查所有簽章並確認所有必要的簽署者皆已存在。

**哪些簡報格式支援這些操作？**

Aspose.Slides 於此僅於 PPTX 格式支援上述數位簽章操作。PPT 與 OpenDocument 簡報格式不受此 API 工作流程支援。

**我可以在不影響投影片的前提下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍然保留，但儲存的檔案不再包含已移除的簽章證據。