---
title: C++ でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/cpp/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明書発行機関
- PFX 証明書
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint および OpenDocument ファイルにデジタル署名を行う方法を学びましょう。明確なコード例で数秒でスライドを保護できます。"
---

**デジタル証明書**は、パスワードで保護された PowerPoint プレゼンテーションを作成するために使用され、特定の組織または個人が作成したことがマークされます。デジタル証明書は、認可された組織（証明書発行機関）に連絡することで取得できます。システムにデジタル証明書をインストールした後、File -> Info -> Protect Presentation からプレゼンテーションにデジタル署名を追加できます:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションは複数のデジタル署名を含むことができます。デジタル署名がプレゼンテーションに追加されると、PowerPoint に特別なメッセージが表示されます:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名したり、署名の真正性を確認したりするには、**Aspose.Slides API** が [**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature) インターフェイス、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection) インターフェイス、および [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) メソッドを提供します。現在、デジタル署名は PPTX 形式のみでサポートされています。

## **PFX 証明書からデジタル署名を追加する**
以下のコードサンプルは、PFX 証明書からデジタル署名を追加する方法を示しています。

1. PFX ファイルを開き、PFX パスワードを [**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature) オブジェクトに渡します。
1. 作成した署名をプレゼンテーションオブジェクトに追加します。
``` cpp
auto pres = System::MakeObject<Presentation>();

// PFX ファイルと PFX パスワードで DigitalSignature オブジェクトを作成
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// 新しいデジタル署名にコメントを付ける
signature->set_Comments(u"Aspose.Slides digital signing test.");

// プレゼンテーションにデジタル署名を追加
pres->get_DigitalSignatures()->Add(signature);

// プレゼンテーションを保存
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```


これで、プレゼンテーションがデジタル署名され、変更されていないかどうかを確認できるようになりました。
``` cpp
// プレゼンテーションを開く
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // すべてのデジタル署名が有効か確認
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```


## **FAQ**

**ファイルから既存の署名を削除できますか？**

はい。デジタル署名コレクションは [個々の項目の削除](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/removeat/) と [全体のクリア](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/clear/) をサポートしています。ファイルを保存した後、プレゼンテーションには署名が残りません。

**署名後にファイルは「読み取り専用」になりますか？**

いいえ。署名は完全性と作成者情報を保持しますが、編集をブロックするわけではありません。編集を制限したい場合は、["Read-only" またはパスワード](/slides/ja/cpp/password-protected-presentation/) と組み合わせて使用してください。

**異なるバージョンの PowerPoint でも署名は正しく表示されますか？**

署名は OOXML (PPTX) コンテナ用に作成されています。OOXML 署名に対応した最新の PowerPoint バージョンでは、署名のステータスが正しく表示されます。