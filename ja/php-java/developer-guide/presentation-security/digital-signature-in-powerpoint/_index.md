---
title: PHPでプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/php-java/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明書発行機関
- PFX 証明書
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint および OpenDocument ファイルにデジタル署名を行う方法を学びます。明確なコード例で数秒でスライドを保護しましょう。"
---

**デジタル証明書**は、特定の組織または個人が作成したことが示された、パスワードで保護されたPowerPointプレゼンテーションを作成するために使用されます。デジタル証明書は、認可された組織（証明書発行機関）に連絡することで取得できます。システムにデジタル証明書をインストールした後、File->Info->Protect Presentation を使用して、プレゼンテーションにデジタル署名を追加できます:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには複数のデジタル署名を含めることができます。デジタル署名がプレゼンテーションに追加されると、PowerPointに特別なメッセージが表示されます:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名したり、署名の真正性を確認したりするには、**Aspose.Slides API** が **IDigitalSignature** インターフェイス、**IDigitalSignatureCollection** インターフェイス、そして **IPresentation.getDigitalSignatures** メソッドを提供します。現在、デジタル署名は PPTX 形式のみでサポートされています。
## **PFX 証明書からデジタル署名を追加する**
以下のコードサンプルは、PFX 証明書からデジタル署名を追加する方法を示しています:

1. PFX ファイルを開き、PFX パスワードを **DigitalSignature** オブジェクトに渡します。
2. 作成した署名をプレゼンテーションオブジェクトに追加します。
```php
  # プレゼンテーションファイルを開く
  $pres = new Presentation();
  try {
    # PFXファイルとPFXパスワードでDigitalSignatureオブジェクトを作成
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # 新しいデジタル署名にコメントを追加
    $signature->setComments("Aspose.Slides digital signing test.");
    # デジタル署名をプレゼンテーションに追加
    $pres->getDigitalSignatures()->add($signature);
    # プレゼンテーションを保存
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


現在、プレゼンテーションがデジタル署名されており、変更されていないかどうかを確認できます:
```php
  # プレゼンテーションを開く
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # すべてのデジタル署名が有効か確認する
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**ファイルから既存の署名を削除できますか？**

はい。デジタル署名コレクションは、個々の項目の[removing individual items](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/removeat/) とコレクション全体の[clearing it entirely](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/clear/) をサポートしています。ファイルを保存すると、プレゼンテーションに署名が残りません。

**署名後にファイルは「読み取り専用」になりますか？**

いいえ。署名は整合性と作者情報を保持しますが、編集をブロックしません。編集を制限するには、[「Read-only」またはパスワード](/slides/ja/php-java/password-protected-presentation/) と組み合わせてください。

**異なるバージョンの PowerPoint で署名は正しく表示されますか？**

署名は OOXML (PPTX) コンテナ向けに作成されています。OOXML 署名に対応した最新バージョンの PowerPoint は、このような署名のステータスを正しく表示します。