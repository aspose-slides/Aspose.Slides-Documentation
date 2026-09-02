---
title: 在 C++ 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "了解如何使用 PFX 憑證簽署現有的 PPTX 簡報，並使用 Aspose.Slides for C++ 來驗證或移除數位簽章。"
---
## **概觀**

數位簽章可協助接收者確定是誰簽署了簡報，以及簽署的內容是否已變更。以下三個相關的安全概念在此尤為重要：

- **數位憑證** 是將身分與公鑰關聯的電子憑證。受信任的憑證授權單位（CA）可以頒發憑證，或組織可在內部工作流程中使用自簽憑證。
- **數位簽章** 由簡報內容與憑證持有者的私鑰產生。之後可使用憑證的公鑰驗證簽章。簽章提供來源與完整性的證據；它不會加密簡報。
- **密碼保護** 控制使用者能否開啟或修改簡報。它與數位簽章分開，相關說明請參閱[Password-Protected Presentations](/slides/zh-hant/cpp/password-protected-presentation/)。

PowerPoint 在 **檔案 > 資訊 > 保護簡報** 下提供 **Add a Digital Signature**（新增數位簽章）指令。

![PowerPoint「保護簡報」功能表，已突出顯示「Add a Digital Signature」](add-digital-signature-in-powerpoint.png)

開啟已簽署的簡報後，PowerPoint 會顯示簽章狀態通知。

![PowerPoint 通知，指出簡報包含有效的簽章](digital-signature-status-in-powerpoint.png)

Aspose.Slides 透過 [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_digitalsignatures/) 取得簽章，該方法回傳一個 [IDigitalSignatureCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idigitalsignaturecollection/)，其項目實作 [IDigitalSignature](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idigitalsignature/)。一個簡報可包含多個簽章。

## **了解 PFX 憑證與密碼**

PFX 檔案（亦稱 PKCS#12 檔案，常見副檔名為 `.pfx` 或 `.p12`）可以包含 X.509 憑證、其私鑰以及憑證鏈。私鑰是持有人用來產生簽章的關鍵。若憑證未包含可存取的私鑰，則無法用於簽署簡報。

PFX 密碼用於保護憑證封裝與私鑰。它 **不是** 用來開啟或編輯簡報的密碼。請勿將 PFX 檔案或其密碼提交至原始碼管理。正式環境中，應限制對憑證檔案的存取，並從機密儲存或其他受保護的設定來源取得密碼。以下範例僅使用環境變數，以避免在程式碼中嵌入密碼。

## **將數位簽章新增至簡報**

若要在實際簡報工作流程中簽署，請載入現有的 PPTX 檔案，使用 PFX 憑證及其密碼建立 [DigitalSignature](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/digitalsignature/)，將簽章加入簡報的集合，最後儲存為 PPTX 檔案。

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

將結果另存新檔可保留未簽署的原始檔。 [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idigitalsignature/set_comments/) 的值用於說明簽章目的；它不具備安全控制的功能。

## **驗證數位簽章**

載入已簽署的 PPTX 檔案時，請檢查 [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_digitalsignatures/) 回傳的每個項目。 [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idigitalsignature/get_isvalid/) 方法可判斷嵌入的簽章對目前簡報內容是否有效。

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

無效的結果通常表示簽署後簡報內容或簽章資料已變更，或檔案已損毀。移除所有簽章會得到未簽署的簡報，因此僅檢查項目的有效性不足以保證安全；敏感的工作流程還必須驗證簽章數量與簽署者身分是否符合預期。

此有效性結果不應被視為完整的憑證信任判斷。依照您的安全策略，應用程式可能還需要建構與驗證 X.509 憑證鏈、檢查憑證有效日期與撤銷狀態、確認預期的主體或指紋、驗證金鑰用法，以及評估可信時間戳章。[IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idigitalsignature/get_signtime/) 的值本身並非來自可信時間戳章機構的證明。

## **移除數位簽章**

移除簽章會改變簡報的安全狀態。以下範例載入已簽署的 PPTX 檔案，使用 [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idigitalsignaturecollection/clear/) 移除所有簽章，並儲存未簽署的副本。

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

若僅移除單一簽章，請使用其零基索引呼叫 [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idigitalsignaturecollection/removeat/)。除非工作流程明確要求覆寫已簽署的原始檔，否則請另存新檔。

## **編輯與格式考量**

- 簽章不會使簡報變為唯讀。使用者與應用程式仍可編輯檔案，但對已簽署內容的變更通常會使現有簽章失效。
- 請在簽署前完成所有預期的編輯。如果需要變更簡報，請先儲存修訂後的簡報，然後再次簽署該版本。
- 保留最終輸出為 PPTX 格式。將已簽署的簡報轉換為其他格式不會將原始 PPTX 簽章作為轉換後檔案的有效簽章。
- 將憑證的私鑰視為機密。取得私鑰及其密碼的任何人，都可能產生看似由該憑證持有人簽署的簽章。
- 當文件保存政策要求時，請保留未簽署的來源或其他受控的副本。

## **常見問題**

**數位簽章會加密簡報嗎？**  
不會。數位簽章僅提供來源與完整性的證據，除非另行加密，否則簡報內容仍可閱讀。若必須限制內容存取，請使用[password protection](/slides/zh-hant/cpp/password-protected-presentation/)。

**PFX 密碼與簡報密碼相同嗎？**  
不是。PFX 密碼用於解鎖憑證封裝中的私鑰，並不控制誰能開啟或編輯 PPTX 檔案。

**我可以使用自簽憑證嗎？**  
技術上，只要自簽憑證包含可存取的私鑰即可使用。但接收者不會自動信任，除非該憑證已明確加入其受信任環境。公共或跨組織的工作流程通常使用受信任 CA 發行的憑證。

**什麼情況會讓簽章無效？**  
在簽署後變更已簽署的簡報內容或簽章資料會使簽章失效。檔案損毀亦會導致驗證失敗。若移除所有簽章，簡報即為未簽署，而非包含無效簽章的檔案。

**有效的簽章就代表我應該信任簽署者嗎？**  
僅憑此並不足以。簽章完整性與簽署者可信度是分開的判斷。正式環境的驗證政策還應檢查憑證鏈、有效期限、撤銷狀態、預期身分、金鑰用法以及任何可信時間戳章的需求。

**憑證過期後會怎樣？**  
憑證過期不會改變簡報的位元組，但會影響憑證信任的評估。簽章是否仍被接受取決於您的政策以及是否有有效的可信時間戳章證明簽署時憑證仍在有效期內。不要僅依賞顯示的簽署時間作為可信時間戳章。

**已簽署的簡報仍能編輯嗎？**  
可以。簽署不會鎖定檔案。編輯已簽署的內容通常會使現有簽章失效，因此請先完成簡報，並對最終版本簽署。

**簡報可以包含多個簽章嗎？**  
可以。於儲存前，將每個簽章加入 [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_digitalsignatures/) 回傳的集合中。驗證時，請檢查每個簽章，並確認所有必要的簽署者皆在。

**哪些簡報格式支援這些操作？**  
Aspose.Slides 僅在 PPTX 格式上支援此處描述的數位簽章操作。PPT 及 OpenDocument 簡報格式不受此 API 工作流程支援。

**我能在不影響投影片的情況下移除簽章嗎？**  
可以。您可以移除單一簽章或清除整個集合，然後儲存簡報。投影片內容仍然保留，但儲存的檔案將不再包含已移除的簽章證據。