---
title: PowerPointにおけるデジタル署名
type: docs
weight: 10
url: /net/digital-signature-in-powerpoint/
keywords: "デジタル署名証明書, 証明書機関, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPointにデジタル署名または証明書を追加します。C#または.NETにおける証明書機関"
---


**デジタル証明書**は、特定の組織または個人によって作成されたものとしてマークされたパスワード保護されたPowerPointプレゼンテーションを作成するために使用されます。デジタル証明書は、認可された組織、すなわち証明書機関に連絡することで取得できます。システムにデジタル証明書をインストールした後、ファイル -> 情報 -> プレゼンテーションの保護経由でプレゼンテーションにデジタル署名を追加するために使用できます:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



プレゼンテーションは、複数のデジタル署名を含むことができます。デジタル署名がプレゼンテーションに追加されると、PowerPointに特別なメッセージが表示されます:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



プレゼンテーションに署名するか、プレゼンテーションの署名の真正性を確認するために、**Aspose.Slides API**は [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature)インターフェイス、 [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection)インターフェイス、および[ **IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures)プロパティを提供します。現在、デジタル署名はPPTX形式のみサポートされています。
## **PFX証明書からデジタル署名を追加する**
以下のコードサンプルは、PFX証明書からデジタル署名を追加する方法を示しています:

1. PFXファイルを開き、[**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature)オブジェクトにPFXパスワードを渡します。
1. 作成した署名をプレゼンテーションオブジェクトに追加します。

```c#
using (Presentation pres = new Presentation())
{
    // PFXファイルとPFXパスワードを使ってDigitalSignatureオブジェクトを作成
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // 新しいデジタル署名にコメントを追加
    signature.Comments = "Aspose.Slidesデジタル署名テスト。";

    // プレゼンテーションにデジタル署名を追加
    pres.DigitalSignatures.Add(signature);

    // プレゼンテーションを保存
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```



プレゼンテーションがデジタル署名されたかどうか、また修正されていないかを確認することができます:



```c#
// プレゼンテーションを開く
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("プレゼンテーションに署名された署名: ");

        // すべてのデジタル署名が有効か確認
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "有効" : "無効"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("プレゼンテーションは正真正銘であり、すべての署名が有効です。");
        else
            Console.WriteLine("プレゼンテーションは署名以降に修正されました。");
    }
}
```