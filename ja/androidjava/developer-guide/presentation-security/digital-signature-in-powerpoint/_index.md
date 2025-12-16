---
title: Android でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/androidjava/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 認証局
- PFX 証明書
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PowerPoint と OpenDocument ファイルにデジタル署名を行う方法を学びます。明確な Java コード例で、数秒でスライドを保護できます。"
---

**デジタル証明書** は、パスワードで保護された PowerPoint プレゼンテーションを作成し、特定の組織または個人が作成したことを示すために使用されます。デジタル証明書は、認可された組織（証明書発行機関）に連絡して取得できます。システムにデジタル証明書をインストールした後、File → Info → Protect Presentation からプレゼンテーションにデジタル署名を追加できます。

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには複数のデジタル署名を含めることができます。デジタル署名がプレゼンテーションに追加されると、PowerPoint に特別なメッセージが表示されます。

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名したり、署名の真正性を確認したりするために、**Aspose.Slides API** は[**IDigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignature) インターフェイス、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignatureCollection) インターフェイス、および[**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) メソッドを提供します。現在、デジタル署名は PPTX 形式のみでサポートされています。

## **PFX 証明書からデジタル署名を追加する**
以下のコードサンプルは、PFX 証明書からデジタル署名を追加する方法を示しています。

1. PFX ファイルを開き、PFX パスワードを[**DigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/DigitalSignature) オブジェクトに渡します。
2. 作成した署名をプレゼンテーション オブジェクトに追加します。
```java
// プレゼンテーション ファイルを開く
Presentation pres = new Presentation();
try {
    // PFX ファイルと PFX パスワードで DigitalSignature オブジェクトを作成 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // 新しいデジタル署名にコメントを設定
    signature.setComments("Aspose.Slides digital signing test.");

    // プレゼンテーションにデジタル署名を追加
    pres.getDigitalSignatures().add(signature);

    // プレゼンテーションを保存
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


これで、プレゼンテーションがデジタル署名されているか、変更されていないかを確認できるようになります。
```java
// プレゼンテーションを開く
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // すべてのデジタル署名が有効かどうかチェック
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**既存の署名をファイルから削除できますか？**

はい。デジタル署名コレクションは[個々の項目の削除](https://reference.aspose.com/slides/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-)と[全体のクリア](https://reference.aspose.com/slides/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--)をサポートしています。ファイルを保存すると、プレゼンテーションに署名は残りません。

**署名後にファイルは「読み取り専用」になりますか？**

いいえ。署名は整合性と作者情報を保持しますが、編集をブロックしません。編集を制限したい場合は、["Read-only" or a password](/slides/ja/androidjava/password-protected-presentation/) と組み合わせて使用してください。

**異なるバージョンの PowerPoint でも署名は正しく表示されますか？**

署名は OOXML（PPTX）コンテナ用に作成されています。OOXML 署名をサポートする最新の PowerPoint バージョンは、署名の状態を正しく表示します。