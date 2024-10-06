---
title: PowerPointにおけるデジタル署名
type: docs
weight: 10
url: /ja/java/digital-signature-in-powerpoint/
keywords: "デジタル署名証明書, 証明書発行機関"
description: "Aspose.Slidesを使用してPowerPointプレゼンテーションにデジタル署名証明書と証明書発行機関を追加します。"
---

**デジタル証明書**は、特定の組織または個人が作成したものとしてマークされたパスワード保護されたPowerPointプレゼンテーションを作成するために使用されます。デジタル証明書は、認可された組織である証明書発行機関に連絡することで取得できます。システムにデジタル証明書をインストールした後、ファイル -> 情報 -> プレゼンテーションを保護経由でプレゼンテーションにデジタル署名を追加するために使用できます：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには、複数のデジタル署名が含まれる場合があります。デジタル署名がプレゼンテーションに追加されると、PowerPointに特別なメッセージが表示されます：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名したり、プレゼンテーションの署名の真偽を確認するために、**Aspose.Slides API**は[**IDigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignature)インターフェース、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignatureCollection)インターフェース、および[**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getDigitalSignatures--)メソッドを提供します。現在、デジタル署名はPPTX形式のみがサポートされています。
## **PFX証明書からデジタル署名を追加する**
以下のコードサンプルは、PFX証明書からデジタル署名を追加する方法を示しています：

1. PFXファイルを開き、PFXパスワードを[**DigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/DigitalSignature)オブジェクトに渡します。
1. 作成した署名をプレゼンテーションオブジェクトに追加します。

```java
// プレゼンテーションファイルを開く
Presentation pres = new Presentation();
try {
    // PFXファイルとPFXパスワードでDigitalSignatureオブジェクトを作成
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // 新しいデジタル署名にコメントを追加
    signature.setComments("Aspose.Slidesデジタル署名テスト。");

    // プレゼンテーションにデジタル署名を追加
    pres.getDigitalSignatures().add(signature);

    // プレゼンテーションを保存
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

これで、プレゼンテーションがデジタル署名されており、変更されていないかどうかを確認することが可能です：

```java
// プレゼンテーションを開く
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("プレゼンテーションに署名するために使われた署名: ");

        // すべてのデジタル署名が有効か確認
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "有効" : "無効"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("プレゼンテーションは本物であり、すべての署名は有効です。");
        else
            System.out.println("署名以来、プレゼンテーションが変更されています。");
    }
} finally {
    if (pres != null) pres.dispose();
}
```