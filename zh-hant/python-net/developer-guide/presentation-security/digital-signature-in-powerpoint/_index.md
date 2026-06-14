---
title: 使用 Python 為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/python-net/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證授權機構
- PFX 憑證
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python 於 .NET 環境對 PowerPoint 與 OpenDocument 檔案進行數位簽章。只需簡潔的程式碼範例，即可在數秒內保護您的簡報。"
---
## **介紹**

**數位憑證** 用於建立受密碼保護的 PowerPoint 簡報，並標示為由特定組織或個人建立。可透過聯絡授權機構（憑證授權單位）取得數位憑證。將數位憑證安裝到系統後，可透過「檔案」->「資訊」->「保護簡報」為簡報加入數位簽章：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

簡報可能包含多個數位簽章。當數位簽章加入簡報後，PowerPoint 會顯示一則特殊訊息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

要簽署簡報或檢查簡報簽章的真偽，**Aspose.Slides API** 提供了[**DigitalSignature**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/) 類別、[**DigitalSignatureCollection**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/DigitalSignatureCollection/) 類別以及[**Presentation.digital_signatures**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/digital_signatures/) 屬性。目前，數位簽章僅支援 PPTX 格式。

## **從 PFX 憑證新增數位簽章**

以下程式碼範例示範如何從 PFX 憑證新增數位簽章：

1. 開啟 PFX 檔案並將 PFX 密碼傳遞給[**DigitalSignature**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignature/) 物件。
1. 將建立的簽章加入簡報物件。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # 建立 DigitalSignature 物件，使用 PFX 檔案與 PFX 密碼 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # 註解新數位簽章
    signature.comments = "Aspose.Slides digital signing test."

    # 將數位簽章加入簡報
    pres.digital_signatures.add(signature)

    # 儲存簡報
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

現在可以檢查簡報是否已數位簽署且未被修改：

```py
# 開啟簡報
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # 檢查所有數位簽章是否有效
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **常見問題**

**我可以從檔案中移除已有的簽章嗎？**

可以。數位簽章集合支援[移除個別項目](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignaturecollection/remove_at/)和[全部清除](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/digitalsignaturecollection/clear/)；儲存檔案後，簡報將不再有任何簽章。

**檔案在簽署後會變成「唯讀」嗎？**

不會。簽章可以確保完整性與作者身份，但不會阻止編輯。若要限制編輯，可與[「唯讀」或密碼](/slides/zh-hant/python-net/password-protected-presentation/)結合使用。

**簽章會在不同版本的 PowerPoint 中正確顯示嗎？**

此簽章是針對 OOXML（PPTX）容器建立的。支援 OOXML 簽章的現代 PowerPoint 版本會正確顯示此類簽章的狀態。