---
title: 在 .NET 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/net/digital-signature-in-powerpoint/
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 PFX 憑證對現有 PPTX 簡報簽章，並使用 Aspose.Slides for .NET 來驗證或移除數位簽章。"
---
## **概觀**

數位簽章可協助接收者判斷是誰簽署了簡報，以及已簽署的內容是否已更改。以下三個相關的安全概念在此很重要：

- **數位憑證** 是將身分與公鑰關聯的電子憑據。可信任的憑證機構 (CA) 可頒發憑證，或組織可在內部工作流程中使用自行簽署的憑證。
- **數位簽章** 由簡報內容與憑證持有者的私鑰所產生。之後可使用憑證的公鑰驗證簽章。簽章提供來源與完整性的證據；它不會加密簡報。
- **密碼保護** 控制使用者是否可以開啟或修改簡報。它與數位簽章分開，相關說明請參考 [受密碼保護的簡報](/net/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **新增數位簽章** 指令。

![PowerPoint「保護簡報」選單，突顯「新增數位簽章」](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 可顯示簽章狀態通知。

![PowerPoint 通知，指出簡報包含有效的簽章](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過 [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/digitalsignatures/)、[IDigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignaturecollection/)（其項目實作 [IDigitalSignature](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignature/)）公開簽章。簡報可以包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案（亦稱為 PKCS#12 檔案，常見副檔名為 `.pfx` 或 `.p12`）可包含 X.509 憑證、其私鑰以及憑證鏈。私鑰是讓持有者生成簽章的依據。沒有可存取私鑰的憑證無法用於簽署簡報。

PFX 密碼保護憑證包與私鑰。它 **不是** 用於開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至原始碼管理系統。在正式環境中，應限制對憑證檔案的存取，並從機密儲存或其他受保護的設定來源取得密碼。以下範例僅使用環境變數，以避免在程式碼中嵌入密碼。

## **將數位簽章加入簡報**

要在實際簡報工作流程中簽署，先載入既有 PPTX 檔案，使用 PFX 憑證及其密碼建立 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/digitalsignature/)，將簽章加入簡報的集合，最後儲存為 PPTX 檔案。

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

將結果另存新檔可保留未簽署的來源檔案。[DigitalSignature.Comments](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/digitalsignature/comments/) 的值說明簽章的目的；它並非安全控制。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，檢查 [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/digitalsignatures/) 中的每個項目。[IDigitalSignature.IsValid](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignature/isvalid/) 屬性指示嵌入的簽章是否對目前的簡報內容有效。

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

無效結果通常表示簽署後簡報內容或簽章資料已變更，或檔案已損毀。移除所有簽章會產生未簽署的簡報，因此僅檢查項目的有效性不足；安全敏感的工作流程還必須驗證是否存在預期的簽章數量與預期的簽署者身分。

此有效性結果不應被視為完整的憑證信任判斷。根據您的安全政策，應用程式可能還需建構並驗證 X.509 憑證鏈、檢查憑證有效期限與撤銷狀態、確認預期的主體或指紋、驗證金鑰使用以及評估可信時間戳記。[IDigitalSignature.SignTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignature/signtime/) 本身並非來自可信時間戳記授權機構的證明。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。以下範例載入已簽署的 PPTX 檔案，使用 [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignaturecollection/clear/) 移除所有簽章，並儲存未簽署的副本。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

若僅移除單一簽章，可使用其零基索引呼叫 [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignaturecollection/removeat/)。除非工作流程明確要求覆寫已簽署的原始檔案，否則請儲存為新檔案。

## **編輯與格式考量**

- 簽章不會使簡報變為唯讀。使用者和應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 在簽署前完成所有預期的編輯。若必須更改簡報，請先儲存修訂後的簡報，再重新簽署該版本。
- 請保留最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 的簽章轉移為轉換後檔案的有效簽章。
- 將憑證的私鑰視為敏感資訊。任何取得私鑰及其密碼的人，都可能製作看似來自該憑證持有者的簽章。
- 當文件保留政策要求時，保留未簽署的來源檔或其他受控副本。

## **常見問題**

**數位簽章會加密簡報嗎？**

不會。數位簽章提供關於來源與完整性的證據，但簡報內容仍可閱讀，除非另行加密。如需限制內容存取，請使用 [密碼保護](/net/password-protected-presentation/)。

**PFX 密碼與簡報密碼相同嗎？**

不會。PFX 密碼用於解鎖憑證套件中儲存的私鑰，並不控制誰能開啟或編輯 PPTX 檔案。

**我可以使用自行簽署的憑證嗎？**

技術上，只要自行簽署的憑證包含可存取的私鑰即可使用。然而，收件人不會自動信任它，除非已明確將該憑證加入其可信環境。公共或跨組織的工作流程通常使用受信任 CA 頒發的憑證。

**什麼情況會使簽章無效？**

在簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀也會導致驗證失敗。若移除所有簽章，簡報將變成未簽署，而不是包含無效簽章的檔案。

**有效的簽章是否代表我應該信任簽署者？**

僅此並不足以。簽章完整性與簽署者的信任屬於不同的判斷。生產環境的驗證政策還應檢查憑證鏈、有效期限、撤銷狀態、預期身分、金鑰使用以及任何可信時間戳記需求。

**當憑證過期時會發生什麼？**

憑證過期不會改變簡報的位元組，但會影響憑證信任評估。簽章是否仍被接受取決於您的政策以及是否有有效的可信時間戳記證明簽署發生於憑證有效期間。不要僅依賴顯示的簽署時間作為可信時間戳記。

**已簽署的簡報仍可編輯嗎？**

可以。簽署不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請先完成簡報並簽署最終版本。

**簡報可以包含多個簽章嗎？**

可以。在儲存前，將每個簽章加入 [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/digitalsignatures/)。驗證時，檢查每個簽章並確認所有必要的簽署者皆在。

**哪些簡報格式支援這些操作？**

Aspose.Slides 僅在 PPTX 上支援此處描述的數位簽章操作。PPT 與 OpenDocument 簡報格式不受此 API 工作流程支援。

**我可以移除簽章而不影響投影片嗎？**

可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍然保留，但儲存的檔案不再包含已移除的簽章證據。