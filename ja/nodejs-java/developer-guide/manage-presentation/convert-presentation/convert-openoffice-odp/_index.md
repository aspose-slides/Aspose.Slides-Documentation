---
title: JavaScriptでOpenDocumentプレゼンテーションを変換
linktitle: OpenDocumentを変換
type: docs
weight: 10
url: /ja/nodejs-java/convert-openoffice-odp/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用すると、ODP を PDF、HTML、画像形式に簡単に変換できます。高速かつ正確なプレゼンテーション変換でアプリケーションを強化しましょう。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) は、OpenDocument (ODP) プレゼンテーションを多数の形式 (HTML、PDF、TIFF、SWF、XPS など) に変換できます。ODP ファイルを他のドキュメント形式に変換するために使用される API は、PowerPoint (PPT と PPTX) の変換操作で使用されるものと同じです。

たとえば、ODP プレゼンテーションを PDF に変換する必要がある場合、次のように実行できます。
```js
let presentation = null;
try {
  presentation = new aspose.slides.Presentation("presentation.odp");
  presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **よくある質問**

**変換後に ODP ファイルの書式設定が変わってしまった場合はどうすればよいですか？**

ODP と PowerPoint は異なるプレゼンテーションモデルを使用しており、テーブルやカスタムフォント、塗りつぶしスタイルなどの一部の要素は完全に同じように表示されない場合があります。必要に応じて出力を確認し、コード内でレイアウトや書式設定を調整することを推奨します。

**ODP 変換を使用するために OpenOffice または LibreOffice をインストールする必要がありますか？**

いいえ、Aspose.Slides はスタンドアロンのライブラリであり、システムに OpenOffice や LibreOffice をインストールする必要はありません。

**ODP 変換中に出力形式をカスタマイズできますか (例: PDF オプションを設定するなど)？**

はい、Aspose.Slides は出力をカスタマイズするための豊富なオプションを提供しています。例えば、PDF に保存する際には、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) クラスを使用して圧縮、画像品質、テキストレンダリングなどを制御できます。

**Aspose.Slides はサーバーサイドまたはクラウドベースの ODP 処理に適していますか？**

はい、Aspose.Slides はデスクトップとサーバーの両環境で動作するよう設計されており、Azure、AWS、Docker コンテナなどのクラウドプラットフォームでも UI 依存なしで利用できます。