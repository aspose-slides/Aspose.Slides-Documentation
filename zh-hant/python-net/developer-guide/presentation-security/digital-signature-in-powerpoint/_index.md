---
title: 在 Python 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/python-net/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "了解如何使用 PFX 憑證簽署現有的 PPTX 簡報，並透過 .NET 使用 Aspose.Slides for Python 來驗證或移除數位簽章。"
---
## **概觀**

數位簽章協助接收者確定是誰簽署了簡報，以及簽署的內容是否已變更。此處有三個相關的安全概念十分重要：

- **數位憑證** 是將身份與公鑰關聯的電子憑證。受信任的憑證機構 (CA) 可以發行憑證，或組織可於內部工作流程使用自簽憑證。
- **數位簽章** 由簡報內容與憑證持有者的私鑰產生。然後可使用憑證的公鑰驗證簽章。簽章提供來源與完整性的證據；它不會加密簡報。
- **密碼保護** 控制使用者是否能開啟或修改簡報。它與數位簽章分開，相關說明請參閱[受密碼保護的簡報](/slides/zh-hant/python-net/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **新增數位簽章** 指令。

![PowerPoint「保護簡報」功能表，突顯「新增數位簽章」](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 會顯示簽章狀態通知。

![PowerPoint 通知：簡報包含有效的簽章](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過 [Presentation.digital_signatures](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/digital_signatures/) 讓使用者存取簽章，這是一個 [DigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignaturecollection/)，其項目為 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/) 物件。簡報可以包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案，也稱為 PKCS#12 檔案，通常使用 `.pfx` 或 `.p12` 副檔名，能包含 X.509 憑證、其私鑰與憑證鏈。私鑰允許持有人建立簽章。若憑證沒有可取得的私鑰，則無法用於簽署簡報。

PFX 密碼用於保護憑證包與私鑰。它 **不是** 用於開啟或編輯簡報的密碼。不要將 PFX 檔案或其密碼提交至來源控制系統。於正式環境中，應限制對憑證檔案的存取，並從機密儲存或其他受保護的設定來源取得密碼。以下範例僅使用環境變數，以避免在程式碼中嵌入密碼。

## **將數位簽章加入簡報**

要對真實的簡報工作流程簽章，請載入既有 PPTX 檔案，使用 PFX 憑證與其密碼建立 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/)，將簽章加入簡報的集合，最後保存為 PPTX 檔案。

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

將結果另存為新檔名可保留未簽署的原始檔案。[DigitalSignature.comments](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/comments/) 值描述簽章的目的；它不是安全控制項。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，檢查 [Presentation.digital_signatures](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/digital_signatures/) 中的每個項目。[DigitalSignature.is_valid](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/is_valid/) 屬性表示嵌入的簽章對於目前簡報內容是否有效。

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

無效結果通常表示簽署後簡報內容或簽章資料已變更，或檔案受損。移除所有簽章會產生未簽署的簡報，因此僅檢查項目的有效性不足；安全敏感的工作流程還必須驗證是否存在預期數量的簽章以及預期的簽署者身分。

[DigitalSignature.certificate](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/certificate/) 屬性以位元組陣列提供憑證資料。範例計算其 SHA-256 指紋，以便應用程式能將其與預期簽署者憑證的指紋進行比對。

此有效性結果不應視為完整的憑證信任判斷。根據您的安全原則，應用程式可能還需要建構與驗證 X.509 憑證鏈、檢查憑證有效日期與撤銷狀態、確認預期的主體或指紋、驗證金鑰用途，並評估受信任的時間戳記。[DigitalSignature.sign_time](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/sign_time/) 本身不足以作為受信任時間戳記授權機構的證明。

## **移除數位簽章**

移除簽章會變更簡報的安全狀態。以下範例載入已簽署的 PPTX 檔案，使用 [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignaturecollection/clear/) 移除所有簽章，並保存未簽署的副本。

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

若僅移除一個簽章，請以零起始索引呼叫 [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignaturecollection/remove_at/)。除非工作流程明確需要覆寫已簽署的原始檔，否則應保存為新檔案。

## **編輯與格式考量**

- 簽章不會使簡報變成唯讀。使用者和應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 在簽章前完成所有預期的編輯。若需變更簡報，請先保存修訂後的簡報，並再次簽署該修訂版。
- 保持最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式時，原始 PPTX 簽章不會作為有效簽章轉移至轉換後的檔案。
- 將憑證的私鑰視為敏感資訊。取得私鑰及其密碼的任何人，都可能製作看似來自該憑證持有者的簽章。
- 當文件保留政策要求時，保留未簽署的來源或其他受控副本。

## **常見問題**

**數位簽章會加密簡報嗎？**

不會。數位簽章提供有關來源與完整性的證據，但簡報內容仍保持可讀，除非另行加密。若需限制內容存取，請使用[密碼保護](/slides/zh-hant/python-net/password-protected-presentation/)。

**PFX 密碼與簡報密碼相同嗎？**

不相同。PFX 密碼用於解鎖憑證包中儲存的私鑰。它不會控制誰能開啟或編輯 PPTX 檔案。

**我可以使用自簽憑證嗎？**

技術上，只要自簽憑證包含可取得的私鑰即可使用。然而，除非收件者明確將該憑證加入受信任環境，否則不會自動獲得信任。公共或跨組織的工作流程通常使用受信任 CA 發行的憑證。

**什麼情況會使簽章無效？**

在簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀也會導致驗證失敗。若移除所有簽章，簡報即為未簽署，而非包含無效簽章的檔案。

**有效的簽章是否表示我應該信任簽署者？**

僅憑此並不足以。簽章完整性與簽署者的信任屬於不同的判斷。正式環境的驗證政策應同時檢查憑證鏈、有效期間、撤銷狀態、預期身分、金鑰用途以及任何受信任的時間戳記需求。

**憑證過期會發生什麼事？**

憑證過期不會更改簡報的位元組，但會影響憑證信任的評估。簽章是否仍被接受取決於您的政策以及是否有有效的受信任時間戳記證明簽署發生於憑證有效期間。請勿僅依賴顯示的簽署時間作為受信任的時間戳記。

**已簽署的簡報仍可編輯嗎？**

可以。簽署不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請先完成簡報，然後簽署最終版本。

**簡報可以包含多個簽章嗎？**

可以。在保存之前將每個簽章加入 [Presentation.digital_signatures](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/digital_signatures/)。驗證時，檢查每個簽章並確認所有必要的簽署者皆已出現。

**哪些簡報格式支援這些操作？**

Aspose.Slides 僅在 PPTX 格式支援此處描述的數位簽章操作。PPT 與 OpenDocument 簡報格式不受此 API 工作流程支援。

**我可以在不影響投影片的情況下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後保存簡報。投影片內容仍然保留，但儲存的檔案將不再包含已移除簽章的證據。