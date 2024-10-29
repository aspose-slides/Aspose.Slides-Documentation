---
title: PowerPointにおけるデジタル署名
type: docs
weight: 10
url: /ja/cpp/digital-signature-in-powerpoint/
keywords: "デジタル署名証明書, 証明書機関"
description: "Aspose.Slidesを使用してPowerPointプレゼンテーションにデジタル署名証明書、証明書機関を追加します。"
---


**デジタル証明書**は、特定の組織または個人によって作成されたことを示すパスワード保護されたPowerPointプレゼンテーションを作成するために使用されます。デジタル証明書は、認可された組織、つまり証明書機関に連絡することで取得できます。システムにデジタル証明書をインストールした後、ファイル -> 情報 -> プレゼンテーションを保護からプレゼンテーションにデジタル署名を追加することができます：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



プレゼンテーションには、複数のデジタル署名を含めることができます。プレゼンテーションにデジタル署名が追加されると、PowerPointに特別なメッセージが表示されます：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



プレゼンテーションに署名したり、プレゼンテーションの署名の真正性を確認するために、**Aspose.Slides API**は[**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature)インターフェース、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection)インターフェース、および[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1)メソッドを提供します。現在、デジタル署名はPPTX形式のみサポートされています。
## **PFX証明書からデジタル署名を追加する**
以下のコードサンプルは、PFX証明書からデジタル署名を追加する方法を示しています：

1. PFXファイルを開き、PFXパスワードを[**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature)オブジェクトに渡します。
1. 作成した署名をプレゼンテーションオブジェクトに追加します。

``` cpp
auto pres = System::MakeObject<Presentation>();

// PFXファイルとPFXパスワードでDigitalSignatureオブジェクトを作成
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// 新しいデジタル署名にコメントを追加
signature->set_Comments(u"Aspose.Slidesデジタル署名テスト。");

// プレゼンテーションにデジタル署名を追加
pres->get_DigitalSignatures()->Add(signature);

// プレゼンテーションを保存
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

プレゼンテーションがデジタル署名されており、変更されていないか確認することができます：

``` cpp
// プレゼンテーションを開く
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"プレゼンテーションに署名するために使用された署名: ");

    // すべてのデジタル署名が有効か確認
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"有効") : System::String(u"無効")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"プレゼンテーションは本物で、すべての署名が有効です。");
    }
    else
    {
        Console::WriteLine(u"署名後、プレゼンテーションが変更されました。");
    }
}
```