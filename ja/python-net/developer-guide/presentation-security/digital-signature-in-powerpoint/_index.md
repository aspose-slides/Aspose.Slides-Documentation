---
title: Pythonでプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/python-net/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明書発行機関
- PFX証明書
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint および OpenDocument ファイルにデジタル署名を付与する方法を学びます。数秒でスライドを保護できる、わかりやすいコード例を掲載しています。"
---

**デジタル証明書**は、パスワードで保護された PowerPoint プレゼンテーションを作成し、特定の組織または個人が作成したことを示すために使用されます。デジタル証明書は、認可された組織（証明書発行機関）に問い合わせることで取得できます。システムにデジタル証明書をインストールした後、**ファイル → 情報 → プレゼンテーションの保護**からデジタル署名を追加できます。

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには複数のデジタル署名を含めることができます。デジタル署名を追加すると、PowerPoint に特別なメッセージが表示されます。

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名を付与したり、署名の真正性を確認したりするために、**Aspose.Slides API** は[**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/)インターフェイス、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/)インターフェイス、そして[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)プロパティを提供します。現在、デジタル署名は PPTX フォーマットでのみサポートされています。

## **PFX 証明書からデジタル署名を追加する**

以下のコードサンプルは、PFX 証明書からデジタル署名を追加する方法を示しています。

1. PFX ファイルを開き、PFX パスワードを[**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/)オブジェクトに渡します。  
2. 作成した署名をプレゼンテーションオブジェクトに追加します。

```py
#[TODO:Exception] RuntimeError: プロキシエラー(FileNotFoundException): 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' のファイルまたはアセンブリを読み込めませんでした。ファイルが見つかりません。

import aspose.slides as slides

with slides.Presentation() as pres:
    # PFX ファイルと PFX パスワードで DigitalSignature オブジェクトを作成
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # 新しいデジタル署名のコメントを設定
    signature.comments = "Aspose.Slides デジタル署名テスト。"

    # デジタル署名をプレゼンテーションに追加
    pres.digital_signatures.add(signature)

    # プレゼンテーションを保存
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

これで、プレゼンテーションがデジタル署名されているか、改ざんされていないかを確認できるようになりました。

```py
# プレゼンテーションを開く
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("プレゼンテーションに使用された署名: ")
        # すべてのデジタル署名が有効か確認
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("プレゼンテーションは正当です。すべての署名が有効です。")
        else:
            print("署名後にプレゼンテーションが変更されました。")
```

## **FAQ**

**既存の署名をファイルから削除できますか？**

はい。デジタル署名コレクションは[個々の項目の削除](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/)と[全体のクリア](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/)をサポートしています。ファイルを保存すれば、プレゼンテーションに署名は残りません。

**署名後にファイルは「読み取り専用」になりますか？**

いいえ。署名は整合性と作者情報を保持しますが、編集をブロックしません。編集を制限したい場合は、["読み取り専用" またはパスワード](/slides/ja/python-net/password-protected-presentation/)と組み合わせて使用してください。

**異なるバージョンの PowerPoint で署名は正しく表示されますか？**

署名は OOXML (PPTX) コンテナ用に作成されています。OOXML 署名に対応した最新バージョンの PowerPoint では、署名の状態が正しく表示されます。