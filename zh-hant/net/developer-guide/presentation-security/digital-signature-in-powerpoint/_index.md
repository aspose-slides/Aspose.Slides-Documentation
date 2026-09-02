---
title: 在 .NET 中為簡報加入數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/net/digital-signature-in-powerpoint/
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 PFX 憑證對現有 PPTX 簡報簽名，並使用 Aspose.Slides for .NET 來驗證或移除數位簽章。"
---
## **概覽**

數位簽章可協助收件者判斷是誰簽署了簡報以及已簽署的內容是否已被變更。以下三個相關的安全概念是此處的重點：

- **數位憑證** 是將身分與公開金鑰關聯的電子憑證。受信任的憑證授權中心 (CA) 可頒發憑證，或組織可使用自行簽署的憑證於內部工作流程中。
- **數位簽章** 由簡報內容與憑證持有者的私密金鑰產生。之後可使用憑證的公開金鑰驗證簽章。簽章提供來源與完整性的證據；它不會加密簡報本身。
- **密碼保護** 控制使用者是否能開啟或修改簡報。它與數位簽章分開，請參閱[Password-Protected Presentations](/slides/zh-hant/net/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **Add a Digital Signature** 指令。

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 會顯示簽章狀態通知。

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過[IPresentation.DigitalSignatures](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/digitalsignatures/)，一個[IDigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignaturecollection/)（其項目實作[IDigitalSignature](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignature/)）公開簽章。簡報可包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案（亦稱 PKCS#12 檔案，常見副檔名為 `.pfx` 或 `.p12`）可包含 X.509 憑證、其私密金鑰以及憑證鏈。私密金鑰讓持有者能建立簽章。沒有可取得的私密金鑰的憑證無法用來簽署簡報。

PFX 密碼保護憑證套件與私密金鑰。它 **不是** 用來開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至原始碼管理。於正式環境中，應限制對憑證檔案的存取，並從密碼管理庫或其他受保護的設定來源取得密碼。以下範例僅使用環境變數以避免在程式碼中嵌入密碼。

## **將數位簽章加入簡報**

要在真實簡報工作流程中簽章，請載入既有 PPTX 檔案，從 PFX 憑證與其密碼建立[DigitalSignature](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/digitalsignature/)，將簽章加入簡報的集合，然後儲存為 PPTX 檔案。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

將結果另存新檔可保留未簽署的來源檔案。[DigitalSignature.Comments](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/digitalsignature/comments/) 的值說明簽章的目的；它不是安全控制項。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，請檢查[IPresentation.DigitalSignatures](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/digitalsignatures/)中的每個項目。[IDigitalSignature.IsValid](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignature/isvalid/) 屬性表示嵌入的簽章對目前簡報內容是否有效。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

無效結果通常意味著簽署後簡報內容或簽章資料已變更，或是檔案受損。移除所有簽章會產生未簽署的簡報，因此僅檢查項目是否有效不足以保證安全：敏感工作流程必須同時驗證簽章的數量與預期的簽署者身分是否存在。

此有效性結果不應被視為完整的憑證信任判斷。依照您的安全政策，應用程式可能還需要建構並驗證 X.509 憑證鏈、檢查憑證有效日期與撤銷狀態、確認預期的主體或指紋、驗證金鑰用途，並評估可信時間戳記。[IDigitalSignature.SignTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignature/signtime/) 的值本身並非來自可信時間戳記機構的證明。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。以下範例載入已簽署的 PPTX 檔案，使用[IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignaturecollection/clear/) 移除全部簽章，並儲存未簽署的副本。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

若只想移除單一簽章，請以零基索引呼叫[IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignaturecollection/removeat/)。除非工作流程明確要求覆寫已簽署的原始檔，否則請儲存為新檔。

## **編輯與格式考量**

- 簽章不會使簡報變成唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 在簽署前完成所有預期的編輯。若簡報需要變更，請先儲存修訂版，再對該修訂版重新簽章。
- 保持最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 簽章轉移為轉換後檔案的有效簽章。
- 將憑證的私密金鑰視為敏感資訊。取得私密金鑰與其密碼的任何人，都可能建立看似來自該憑證持有者的簽章。
- 當文件保存政策要求時，保留未簽署的來源或其他受控副本。

## **常見問題集**

**數位簽章會加密簡報嗎？**

不會。數位簽章提供關於來源與完整性的證據，但簡報內容仍可讀取，除非另行加密。若需限制內容存取，請使用[password protection](/slides/zh-hant/net/password-protected-presentation/)。

**PFX 密碼與簡報密碼是同一個嗎？**

不是。PFX 密碼用於解鎖憑證套件中儲存的私密金鑰，並不控制誰可以開啟或編輯 PPTX 檔案。

**我可以使用自行簽署的憑證嗎？**

技術上，只要自行簽署的憑證包含可取得的私密金鑰，即可使用。然而收件者不會自動信任它，除非該憑證已明確加入他們的受信任環境。公開或跨組織工作流程通常使用受信任 CA 頒發的憑證。

**什麼情況會使簽章無效？**

在簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀也會導致驗證失敗。如果全部簽章被移除，簡報就是未簽署的，而不是包含無效簽章的檔案。

**有效的簽章是否意味著我應該信任簽署者？**

僅憑此並不足以。簽章完整性與簽署者的信任是分開的判斷。正式的驗證政策還應檢查憑證鏈、有效期限、撤銷狀態、預期身分、金鑰用途以及任何可信時間戳記要求。

**憑證過期後會發生什麼事？**

憑證過期不會改變簡報位元組，但會影響憑證信任的評估。簽章是否仍然可接受取決於您的政策，以及是否有有效的可信時間戳記能證明簽署發生於憑證有效期間。僅依顯示的簽署時間並非可信時間戳記。

**已簽署的簡報仍然可以編輯嗎？**

可以。簽署不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請先完成簡報編輯，然後再簽署最終版本。

**簡報可以包含多個簽章嗎？**

可以。在儲存之前，將每個簽章加入[IPresentation.DigitalSignatures]，驗證時檢查每一個簽章，並確認所有必需的簽署者皆已出現。

**哪些簡報格式支援這些操作？**

Aspose.Slides 僅在 PPTX 格式下支援此處描述的數位簽章操作。PPT 與 OpenDocument 簡報格式不受此 API 工作流程支援。

**我可以在不影響投影片的情況下移除簽章嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍然保留，但儲存的檔案將不再包含被移除的簽章證據。