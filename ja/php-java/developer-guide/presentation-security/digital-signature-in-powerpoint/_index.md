---
title: PHPでプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/php-java/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明機関
- PFX証明書
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint と OpenDocument ファイルにデジタル署名する方法を学びましょう。明確なコード例で数秒でスライドを保護できます。"
---

**デジタル証明書** は、パスワードで保護されたPowerPointプレゼンテーションを作成するために使用され、特定の組織または個人が作成したことが示されます。デジタル証明書は、認可された組織（証明書発行機関）に連絡することで取得できます。システムにデジタル証明書をインストールした後、File -> Info -> Protect Presentation からプレゼンテーションにデジタル署名を追加できます:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

プレゼンテーションには複数のデジタル署名を含めることができます。デジタル署名がプレゼンテーションに追加されると、PowerPoint に特別なメッセージが表示されます:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

プレゼンテーションに署名したり、署名の真正性を確認したりするには、**Aspose.Slides API** が [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature) クラス、[**DigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignatureCollection) クラス、および [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getDigitalSignatures) メソッドを提供します。現在、デジタル署名は PPTX 形式のみでサポートされています。
## **PFX 証明書からデジタル署名を追加する**
以下のコードサンプルは、PFX 証明書からデジタル署名を追加する方法を示しています:

1. PFX ファイルを開き、PFX パスワードを [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature) オブジェクトに渡します。
2. 作成した署名をプレゼンテーション オブジェクトに追加します。
```php
  # プレゼンテーションファイルを開く
  $pres = new Presentation();
  try {
    # PFXファイルとPFXパスワードでDigitalSignatureオブジェクトを作成
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # 新しいデジタル署名にコメントを設定
    $signature->setComments("Aspose.Slides digital signing test.");
    # デジタル署名をプレゼンテーションに追加
    $pres->getDigitalSignatures()->add($signature);
    # プレゼンテーションを保存
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


これで、プレゼンテーションがデジタル署名されており、変更されていないかどうかを確認できるようになりました:
```php
  # プレゼンテーションを開く
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # すべてのデジタル署名が有効かチェック
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


## **FAQ**

**既存の署名をファイルから削除できますか？**

はい。デジタル署名コレクションは、[個々の項目を削除](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/removeat/) できることと、[全体をクリア](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/clear/) できることをサポートしています。ファイルを保存すると、プレゼンテーションに署名は残りません。

**署名後にファイルは「読み取り専用」になりますか？**

いいえ。署名は完全性と作者情報を保持しますが、編集をブロックしません。編集を制限するには、["Read-only" またはパスワード](/slides/ja/php-java/password-protected-presentation/) と組み合わせてください。

**異なるバージョンの PowerPoint でも署名は正しく表示されますか？**

署名は OOXML (PPTX) コンテナ用に作成されています。OOXML 署名に対応した最新の PowerPoint バージョンでは、署名のステータスが正しく表示されます。