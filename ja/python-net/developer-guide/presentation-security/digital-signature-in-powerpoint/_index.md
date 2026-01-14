---
title: Pythonでプレゼンテーションにデジタル署名を追加
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/python-net/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明書機関
- PFX証明書
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument ファイルにデジタル署名する方法を学びます。コード例が明確で、数秒でスライドを保護できます。"
---

**デジタル証明書**は、特定の組織や個人が作成したことを示すパスワード保護されたPowerPointプレゼンテーションを作成するために使用されます。デジタル証明書は、認可された組織（証明書発行機関）に連絡して取得できます。システムにデジタル証明書をインストールした後、ファイル → 情報 → プレゼンテーションの保護 の順にデジタル署名を追加できます。

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには複数のデジタル署名を含めることができます。デジタル署名がプレゼンテーションに追加されると、PowerPointに特別なメッセージが表示されます。

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名したり、署名の真正性を確認したりするために、**Aspose.Slides API**は[**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/) クラス、[**DigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/DigitalSignatureCollection/) クラス、そして[**Presentation.digital_signatures**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/digital_signatures/) プロパティを提供します。現在、デジタル署名はPPTX形式のみでサポートされています。

## **PFX証明書からデジタル署名を追加**

以下のコードサンプルは、PFX証明書からデジタル署名を追加する方法を示しています。

1. PFXファイルを開き、PFXパスワードを[**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/) オブジェクトに渡します。  
1. 作成した署名をプレゼンテーションオブジェクトに追加します。  
```py

#[TODO:Exception] RuntimeError: プロキシエラー(FileNotFoundException): ファイルまたはアセンブリ 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' を読み込めませんでした。 ファイルが見つかりませんでした。

import aspose.slides as slides

with slides.Presentation() as pres:
    # PFXファイルとPFXパスワードでDigitalSignatureオブジェクトを作成する
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # 新しいデジタル署名にコメントを付ける
    signature.comments = "Aspose.Slides digital signing test."

    # デジタル署名をプレゼンテーションに追加する
    pres.digital_signatures.add(signature)

    # プレゼンテーションを保存する
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```


これで、プレゼンテーションがデジタル署名されているか、改ざんされていないかを確認できるようになります。  
```py
# プレゼンテーションを開く
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # すべてのデジタル署名が有効か確認する
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```


## **FAQ**

**ファイルから既存の署名を削除できますか？**

はい。デジタル署名コレクションは[個々の項目の削除](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/)と[全体のクリア](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/)をサポートしています。ファイルを保存すると、プレゼンテーションには署名が残りません。

**署名後にファイルは「読み取り専用」になりますか？**

いいえ。署名は完全性と作成者情報を保持しますが、編集をブロックしません。編集を制限するには、["読み取り専用" またはパスワード](/slides/ja/python-net/password-protected-presentation/) と組み合わせて使用してください。

**異なるバージョンのPowerPointで署名は正しく表示されますか？**

署名は OOXML（PPTX）コンテナ用に作成されています。OOXML 署名をサポートする最新バージョンの PowerPoint は、署名のステータスを正しく表示します。