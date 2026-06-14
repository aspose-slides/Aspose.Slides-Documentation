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
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 為 PowerPoint 與 OpenDocument 檔案添加數位簽章。只需數秒，即可透過清晰的程式碼範例保護您的投影片。"
---
## **簡介**

**數位憑證** 用於建立受密碼保護的 PowerPoint 簡報，並標示為由特定組織或個人建立。可透過聯絡授權的組織─憑證授權單位取得數位憑證。將數位憑證安裝到系統後，即可透過 File -> Info -> Protect Presentation 為簡報加入數位簽章：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

簡報可能包含多個數位簽章。加入數位簽章後，PowerPoint 會顯示一則特殊訊息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

若要簽署簡報或檢查簡報簽章的真偽，**Aspose.Slides API** 提供 [**IDigitalSignature**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idigitalsignature) 介面、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/IDigitalSignatureCollection) 介面以及 [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/properties/digitalsignatures) 屬性。目前僅支援 PPTX 格式的數位簽章。

## **從 PFX 憑證新增數位簽章**

以下程式碼示範如何從 PFX 憑證新增數位簽章：

1. 開啟 PFX 檔案，並將 PFX 密碼傳遞給 [**DigitalSignature**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/digitalsignature) 物件。
2. 將建立的簽章加入簡報物件。

```c#
using (Presentation pres = new Presentation())
{
    // 使用 PFX 檔案與 PFX 密碼建立 DigitalSignature 物件 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // 為新數位簽章設定註解
    signature.Comments = "Aspose.Slides digital signing test.";

    // 將數位簽章加入簡報
    pres.DigitalSignatures.Add(signature);

    // 儲存簡報
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

現在可以檢查簡報是否已數位簽署且未被修改：

```c#
 // 開啟簡報
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // 檢查所有數位簽章是否有效
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **常見問題**

**我可以從檔案中移除現有的簽章嗎？**

可以。數位簽章集合支援[移除個別項目](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/digitalsignaturecollection/removeat/)以及[全部清除](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/digitalsignaturecollection/clear/)；儲存檔案後，簡報將不再有簽章。

**簽署後檔案會變成「唯讀」嗎？**

不會。簽章保護完整性與作者身份，但不會阻止編輯。如需限制編輯，可結合[「唯讀」或密碼](/slides/zh-hant/net/password-protected-presentation/)。

**簽章會在不同版本的 PowerPoint 中正確顯示嗎？**

簽章是為 OOXML (PPTX) 容器建立的。支援 OOXML 簽章的現代 PowerPoint 版本會正確顯示此類簽章的狀態。