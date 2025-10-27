**デジタル証明書** は、パスワードで保護された PowerPoint プレゼンテーションを作成し、特定の組織や個人が作成したことを示すために使用されます。デジタル証明書は、認証局（Certificate Authority）と呼ばれる認可された組織に問い合わせることで取得できます。システムにデジタル証明書をインストールした後、**ファイル → 情報 → プレゼンテーションの保護** を介してプレゼンテーションにデジタル署名を追加できます。

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには複数のデジタル署名を含めることができます。デジタル署名がプレゼンテーションに追加されると、PowerPoint に特別なメッセージが表示されます。

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名したり、署名の真正性を確認したりするために、**Aspose.Slides API** は [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/) インターフェイス、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) インターフェイス、そして [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) プロパティを提供します。現在、デジタル署名は PPTX 形式のみでサポートされています。

## **PFX 証明書からデジタル署名を追加**

以下のコード例は、PFX 証明書からデジタル署名を追加する方法を示しています。

1. PFX ファイルを開き、PFX パスワードを [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/) オブジェクトに渡します。  
1. 作成した署名をプレゼンテーションオブジェクトに追加します。

```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): Could not load file or assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. File was not found.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Create DigitalSignature object with PFX file and PFX password 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Comment new digital signature
    signature.comments = "Aspose.Slides digital signing test."

    # Add digital signature to presentation
    pres.digital_signatures.add(signature)

    # save presentation
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```



これで、プレゼンテーションがデジタル署名されているか、改ざんされていないかを確認できるようになりました。

```py
# Open presentation
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Check if all digital signatures are valid
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **よくある質問**

**既存の署名をファイルから削除できますか？**

はい。デジタル署名コレクションは、[個別の項目を削除](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) でき、[すべてクリア](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/) することもできます。ファイルを保存すれば、プレゼンテーションに署名は残りません。

**署名後にファイルは「読み取り専用」になりますか？**

いいえ。署名は完全性と作者情報を保持しますが、編集をブロックしません。編集を制限したい場合は、[「読み取り専用」またはパスワード](/slides/ja/python-net/password-protected-presentation/) と組み合わせて使用してください。

**異なるバージョンの PowerPoint で署名は正しく表示されますか？**

署名は OOXML (PPTX) コンテナ向けに作成されています。OOXML 署名に対応した最新バージョンの PowerPoint では、署名のステータスが正しく表示されます。