---
title: PowerPoint におけるデジタル署名
type: docs
weight: 10
url: /ja/nodejs-java/digital-signature-in-powerpoint/
keywords: "デジタル署名証明書、証明機関"
description: "Aspose.Slides を使用して PowerPoint プレゼンテーションにデジタル署名証明書と証明機関を追加します。"
---

**デジタル証明書**は、パスワードで保護されたPowerPointプレゼンテーションを作成し、特定の組織または個人が作成したことを示すために使用されます。デジタル証明書は、認可された組織（証明書発行機関）に連絡することで取得できます。システムにデジタル証明書をインストールした後、File → Info → Protect Presentation を使ってプレゼンテーションにデジタル署名を追加できます。

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには複数のデジタル署名を含めることができます。デジタル署名がプレゼンテーションに追加されると、PowerPoint に特別なメッセージが表示されます。

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名したり、署名の真正性を確認したりするために、**Aspose.Slides API** は [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature) クラス、[**DigitalSignatureCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignatureCollection) クラス、および [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) メソッドを提供します。現在、デジタル署名は PPTX 形式のみでサポートされています。

## **PFX 証明書からデジタル署名を追加**

以下のコードサンプルは、PFX 証明書からデジタル署名を追加する方法を示しています。

1. PFX ファイルを開き、PFX パスワードを **DigitalSignature** オブジェクトに渡します。
2. 作成した署名をプレゼンテーション オブジェクトに追加します。
```javascript
// プレゼンテーション ファイルを開く
var pres = new aspose.slides.Presentation();
try {
    // PFX ファイルと PFX パスワードで DigitalSignature オブジェクトを作成
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // 新しいデジタル署名にコメントを付ける
    signature.setComments("Aspose.Slides digital signing test.");
    // デジタル署名をプレゼンテーションに追加
    pres.getDigitalSignatures().add(signature);
    // プレゼンテーションを保存
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


これで、プレゼンテーションがデジタル署名されているか、変更されていないかを確認できるようになります。
```javascript
// プレゼンテーションを開く
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // すべてのデジタル署名が有効かどうかを確認
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**ファイルから既存の署名を削除できますか？**

はい。デジタル署名コレクションは [個々の項目の削除](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) と [コレクション全体のクリア](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) をサポートしています。ファイルを保存すれば、プレゼンテーションに署名は残りません。

**署名後にファイルは「読み取り専用」になりますか？**

いいえ。署名は完全性と作者情報を保持しますが、編集をブロックしません。編集を制限したい場合は、["読み取り専用" またはパスワード](/slides/ja/nodejs-java/password-protected-presentation/) と組み合わせて使用してください。

**異なるバージョンの PowerPoint で署名は正しく表示されますか？**

この署名は OOXML (PPTX) コンテナ用に作成されています。OOXML 署名に対応した最新の PowerPoint バージョンでは、署名の状態が正しく表示されます。