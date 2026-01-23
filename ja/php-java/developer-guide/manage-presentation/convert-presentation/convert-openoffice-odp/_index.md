---
title: PHPでOpenDocumentプレゼンテーションを変換
linktitle: OpenDocumentを変換
type: docs
weight: 10
url: /ja/php-java/convert-openoffice-odp/
keywords:
- ODPを変換
- ODPから画像へ
- ODPからGIFへ
- ODPからHTMLへ
- ODPからJPGへ
- ODPからMDへ
- ODPからPDFへ
- ODPからPNGへ
- ODPからPPTへ
- ODPからPPTXへ
- ODPからTIFFへ
- ODPから動画へ
- ODPからWordへ
- ODPからXPSへ
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用すると、ODP を PDF、HTML、画像形式に簡単に変換できます。高速かつ正確なプレゼンテーション変換で PHP アプリを強化しましょう。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) は、OpenDocument（ODP）プレゼンテーションを多くの形式（HTML、PDF、TIFF、SWF、XPSなど）に変換できます。ODP ファイルを他のドキュメント形式に変換するために使用される API は、PowerPoint（PPT および PPTX）変換操作に使用されるものと同じです。

たとえば、ODP プレゼンテーションを PDF に変換する必要がある場合、以下のように実行できます。
```php
$presentation = null;
try {
    $presentation = new Presentation("pres.odp");
    $presentation->save("pres.pdf", SaveFormat::Pdf);
    
} finally {
    if ($presentation != null) {
        $presentation->dispose();
    }
}
```


## **FAQ**

**変換後にODPファイルの書式設定が変更された場合はどうなりますか？**

ODP と PowerPoint は異なるプレゼンテーションモデルを使用しており、テーブル、カスタムフォント、塗りつぶしスタイルなどの一部の要素はまったく同じように表示されない場合があります。必要に応じて出力を確認し、コード内でレイアウトや書式設定を調整することをお勧めします。

**ODP変換を使用するためにOpenOfficeまたはLibreOfficeをインストールする必要がありますか？**

いいえ、Aspose.Slides はスタンドアロンのライブラリであり、システムに OpenOffice または LibreOffice をインストールする必要はありません。

**ODP変換中に出力形式をカスタマイズできますか（例：PDFオプションの設定）？**

はい、Aspose.Slides は出力をカスタマイズするための豊富なオプションを提供します。たとえば、PDF に保存する際には、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスを使用して圧縮、画像品質、テキスト描画などを制御できます。

**Aspose.Slides はサーバーサイドまたはクラウドベースのODP処理に適していますか？**

その通りです。Aspose.Slides はデスクトップとサーバー環境の両方で動作するよう設計されており、Azure、AWS、Docker コンテナなどのクラウドベースプラットフォームでも UI 依存なしで使用できます。