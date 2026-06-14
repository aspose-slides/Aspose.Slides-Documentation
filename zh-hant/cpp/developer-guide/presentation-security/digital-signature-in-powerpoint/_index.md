---
title: 在 C++ 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/cpp/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證授權中心
- PFX 憑證
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "瞭解如何使用 Aspose.Slides for C++ 為 PowerPoint 與 OpenDocument 檔案簽署數位簽章。只需幾秒，即可以清晰的程式碼範例保護您的投影片。"
---
## **簡介**

**數位憑證** 用於建立受密碼保護的 PowerPoint 簡報，並標註由特定組織或個人建立。可以透過聯絡授權的機構（憑證授權中心）取得數位憑證。將數位憑證安裝至系統後，可透過「檔案」->「資訊」->「保護簡報」為簡報加入數位簽章：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

簡報可能包含多個數位簽章。加入數位簽章後，PowerPoint 會顯示特別訊息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

若要對簡報簽章或檢查簽章的真偽，**Aspose.Slides API** 提供[**IDigitalSignature**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_digital_signature)介面、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_digital_signature_collection)介面以及[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1)方法。目前，僅支援 PPTX 格式的數位簽章。

## **從 PFX 憑證新增數位簽章**

以下程式碼範例示範如何從 PFX 憑證新增數位簽章：

1. 開啟 PFX 檔案並將 PFX 密碼傳遞給[**DigitalSignature**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.digital_signature)物件。  
1. 將建立的簽章加入簡報物件。

``` cpp
auto pres = System::MakeObject<Presentation>();

// 使用 PFX 檔案和 PFX 密碼建立 DigitalSignature 物件
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// 為新的數位簽章加入說明
signature->set_Comments(u"Aspose.Slides digital signing test.");

// 將數位簽章加入簡報
pres->get_DigitalSignatures()->Add(signature);

// 儲存簡報
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

現在可以檢查簡報是否已被數位簽章且未被修改：

``` cpp
// 開啟簡報
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // 檢查所有數位簽章是否有效
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **FAQ**

**我可以從檔案中移除現有的簽章嗎？**

是的。數位簽章集合支援[移除個別項目](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/digitalsignaturecollection/removeat/)以及[全部清除](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/digitalsignaturecollection/clear/)；在您儲存檔案後，簡報將不再有任何簽章。

**簽署後檔案會變成「唯讀」嗎？**

不會。簽章僅保護完整性與作者身份，並不阻止編輯。若需限制編輯，請與[「唯讀」或密碼](/slides/zh-hant/cpp/password-protected-presentation/)結合使用。

**簽章會在不同版本的 PowerPoint 中正確顯示嗎？**

簽章是針對 OOXML（PPTX）容器建立的。支援 OOXML 簽章的現代 PowerPoint 版本會正確顯示此類簽章的狀態。