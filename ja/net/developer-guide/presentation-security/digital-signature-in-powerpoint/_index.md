---
title: .NET でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/net/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明書発行機関
- PFX 証明書
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint と OpenDocument ファイルにデジタル署名を行う方法を学びます。明確なコード例で数秒でスライドを保護できます。"
---

**デジタル証明書** は、特定の組織または個人が作成したことを示す、パスワードで保護された PowerPoint プレゼンテーションを作成するために使用されます。デジタル証明書は、認定機関（証明書発行機関）に連絡することで取得できます。システムにデジタル証明書をインストールした後、[ファイル] -> [情報] -> [プレゼンテーションの保護] を使用してプレゼンテーションにデジタル署名を追加できます:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには複数のデジタル署名を含めることができます。デジタル署名がプレゼンテーションに追加されると、PowerPoint に特別なメッセージが表示されます:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名したり、署名の真正性を確認したりするために、**Aspose.Slides API** は [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature) インターフェイス、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection) インターフェイス、そして [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) プロパティを提供します。現在、デジタル署名は PPTX 形式のみでサポートされています。

## **PFX 証明書からデジタル署名を追加する**
以下のコード例は、PFX 証明書からデジタル署名を追加する方法を示しています。

1. PFX ファイルを開き、PFX パスワードを **DigitalSignature** オブジェクトに渡します。
2. 作成した署名をプレゼンテーションオブジェクトに追加します。
```c#
using (Presentation pres = new Presentation())
{
    // PFX ファイルと PFX パスワードで DigitalSignature オブジェクトを作成します 
    // 新しいデジタル署名にコメントを付けます
    // プレゼンテーションにデジタル署名を追加します
    // プレゼンテーションを保存します
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");
    signature.Comments = "Aspose.Slides digital signing test.";
    pres.DigitalSignatures.Add(signature);
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


これで、プレゼンテーションがデジタル署名され、変更されていないかを確認できるようになります。
```c#
// プレゼンテーションを開く
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // すべてのデジタル署名が有効か確認する
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


## **FAQ**

**ファイルから既存の署名を削除できますか？**

はい。デジタル署名コレクションは、個々の項目の削除とコレクション全体のクリアをサポートしています。ファイルを保存すると、プレゼンテーションに署名は残りません。

**署名後にファイルは「読み取り専用」になりますか？**

いいえ。署名は整合性と作者情報を保持しますが、編集をブロックしません。編集を制限するには、[「読み取り専用」またはパスワード](/slides/ja/net/password-protected-presentation/) と組み合わせて使用してください。

**異なるバージョンの PowerPoint で署名は正しく表示されますか？**

この署名は OOXML（PPTX）コンテナ用に作成されています。OOXML 署名に対応した最新バージョンの PowerPoint では、署名の状態が正しく表示されます。