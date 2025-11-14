---
title: Python でプレゼンテーションにデジタル署名を追加
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/python-net/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 認証局
- PFX 証明書
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument ファイルにデジタル署名を付与する方法を学びます。わかりやすいコード例で、数秒でスライドを保護できます。"
---

**デジタル証明書**は、特定の組織または個人によって作成されたことを示すパスワード保護されたPowerPointプレゼンテーションを作成するために使用されます。デジタル証明書は、認可された組織である認証局に連絡することで取得できます。システムにデジタル証明書をインストールした後、ファイル -> 情報 -> プレゼンテーションを保護でプレゼンテーションにデジタル署名を追加するために使用できます：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには、複数のデジタル署名を含めることができます。デジタル署名がプレゼンテーションに追加されると、PowerPointに特別なメッセージが表示されます：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名するか、プレゼンテーションの署名の真正性を確認するために、**Aspose.Slides API**は[**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/)インターフェース、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/)インターフェース、[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)プロパティを提供します。現在、デジタル署名はPPTX形式にのみ対応しています。
## **PFX証明書からデジタル署名を追加する**
以下のコードサンプルは、PFX証明書からデジタル署名を追加する方法を示しています：

1. PFXファイルを開き、PFXパスワードを[**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/)オブジェクトに渡します。
1. 作成した署名をプレゼンテーションオブジェクトに追加します。

```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): Could not load file or assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. File was not found.

import aspose.slides as slides

with slides.Presentation() as pres:
    # PFXファイルとPFXパスワードでDigitalSignatureオブジェクトを作成
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # 新しいデジタル署名のコメント
    signature.comments = "Aspose.Slidesデジタル署名テスト。"

    # プレゼンテーションにデジタル署名を追加
    pres.digital_signatures.add(signature)

    # プレゼンテーションを保存
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

プレゼンテーションがデジタル署名され、変更されていないか確認することができます：

```py
# プレゼンテーションを開く
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("プレゼンテーションに署名された署名：")
        # すべてのデジタル署名の有効性を確認
        for signature in pres.digital_signatures:
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "有効" if signature.is_valid else "無効")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid

        if allSignaturesAreValid:
            print("プレゼンテーションは真正であり、すべての署名が有効です。")
        else:
            print("プレゼンテーションは署名後に変更されました。")
```