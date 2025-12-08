---
title: PowerPoint のデジタル署名
type: docs
weight: 10
url: /ja/net/digital-signature-in-powerpoint/
keywords: "デジタル署名証明書, 証明書発行機関, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint にデジタル署名または証明書を追加します。C# または .NET の証明書発行機関"
---

**デジタル証明書** は、特定の組織または個人が作成したことが示された、パスワードで保護された PowerPoint プレゼンテーションを作成するために使用されます。デジタル証明書は、認定された組織（証明書発行機関）に連絡することで取得できます。システムにデジタル証明書をインストールした後、File -> Info -> Protect Presentation を使用してプレゼンテーションにデジタル署名を追加できます：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには複数のデジタル署名が含まれる場合があります。デジタル署名がプレゼンテーションに追加されると、PowerPoint に特別なメッセージが表示されます：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名したり、プレゼンテーション署名の真正性を確認したりするには、**Aspose.Slides API** が [**IDigitalSignature** ](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature)インターフェイス、[**IDigitalSignatureCollection** ](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection)インターフェイス、そして[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures)プロパティを提供します。現在、デジタル署名は PPTX 形式のみでサポートされています。

## **PFX 証明書からデジタル署名を追加**

以下のコードサンプルは、PFX 証明書からデジタル署名を追加する方法を示しています：

1. PFX ファイルを開き、PFX パスワードを [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature)オブジェクトに渡します。
1. 作成した署名をプレゼンテーションオブジェクトに追加します。
```c#
using (Presentation pres = new Presentation())
{
    // PFX ファイルと PFX パスワードで DigitalSignature オブジェクトを作成 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // 新しいデジタル署名にコメント
    signature.Comments = "Aspose.Slides digital signing test.";

    // プレゼンテーションにデジタル署名を追加
    pres.DigitalSignatures.Add(signature);

    // プレゼンテーションを保存
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


これで、プレゼンテーションがデジタル署名されており、変更されていないかを確認できます：
```c#
 // プレゼンテーションを開く
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // すべてのデジタル署名が有効かどうかを確認
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


## **よくある質問**

**ファイルから既存の署名を削除できますか？**

はい。デジタル署名コレクションは、[個別アイテムの削除](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/) と [全体のクリア](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/) をサポートしています。ファイルを保存すると、プレゼンテーションに署名は残りません。

**署名後にファイルは「読み取り専用」になりますか？**

いいえ。署名は完全性と作者情報を保持しますが、編集をブロックするわけではありません。編集を制限したい場合は、[「読み取り専用」またはパスワード](/slides/ja/net/password-protected-presentation/) と組み合わせてください。

**異なるバージョンの PowerPoint で署名は正しく表示されますか？**

この署名は OOXML（PPTX）コンテナ用に作成されています。OOXML 署名をサポートする最新の PowerPoint バージョンでは、署名のステータスが正しく表示されます。