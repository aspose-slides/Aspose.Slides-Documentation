---
title: JavaScript で PowerPoint プレゼンテーションを XML に変換する
linktitle: PowerPoint を XML に変換
type: docs
weight: 145
url: /ja/nodejs-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint を XML に変換
- プレゼンテーションを XML に変換
- PPT を XML に変換
- PPTX を XML に変換
- ODP を XML に変換
- PowerPoint XML プレゼンテーション
- SaveFormat.Xml
- プレゼンテーションを XML として保存
- プレゼンテーションを XML にエクスポート
- XML ストリーム
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument プレゼンテーションを JavaScript で PowerPoint XML ファイルまたはストリームに変換します。"
---
## **概要**

Aspose.Slides for Node.js via Java は PowerPoint プレゼンテーションを PowerPoint XML プレゼンテーション形式に変換できます。XML 出力は、プレゼンテーションの構造を検査したり、生成されたドキュメントのトラブルシューティングを行ったり、Automated テストで出力を比較したり、プレゼンテーション パッケージの代わりに XML を使用するワークフローと統合したりする際に、テキストベースの表現が必要な場合に便利です。

[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) メソッドを使用し、[SaveFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) 列挙体の `Xml` 値を指定します。結果をファイルに直接書き込むことも、ストリームに書き込むこともできます。

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` は PowerPoint XML プレゼンテーションを作成します。PPTX パッケージ内に格納されている個々の Office Open XML パーツは抽出しません。`ppt/presentation.xml` や個別のスライド XML ファイルなど、正確な PPTX パッケージのパーツが必要な場合は、PPTX パッケージ自体を確認してください。
{{% /alert %}}

## **プレゼンテーションを XML ファイルに変換する**

ソースのプレゼンテーションは [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスでロードし、出力パスと `SaveFormat.Xml` を [Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) に渡します。ソースは PPT、PPTX、ODP など、ロードがサポートされている任意のプレゼンテーション形式にできます。

以下の例は PPTX プレゼンテーションを XML ファイルに変換します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML 出力をストリームに書き込む**

XML をメモリ内に保持したまま、または Web サービス、ストレージプロバイダー、XML 処理パイプラインなどの別コンポーネントに渡す必要がある場合は、[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) のストリーム オーバーロードを使用します。以下の例は結果を書き込み、Java の `ByteArrayOutputStream` に保存し、生成されたデータを Node.js の `Buffer` にコピーします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // xmlBuffer をワークフロー内の次のコンポーネントに渡す。
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML とプレゼンテーションおよびエクスポート形式の比較**

結果の使用方法に応じて出力形式を選択します。

| 形式 | 出力 | 典型的な使用例 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML プレゼンテーション | 構造の検査、トラブルシューティング、生成された出力の比較、XML ベースの統合 |
| PPT (`.ppt`) | 従来のバイナリ プレゼンテーション ファイル | 古い PowerPoint ワークフローとの互換性 |
| PPTX (`.pptx`) | 複数のパーツを含む Office Open XML パッケージ | 通常の PowerPoint 編集およびプレゼンテーションのやり取り |
| PDF or TIFF | 固定レイアウトページまたはマルチページ画像 | 閲覧、印刷、アーカイブ |
| PNG, JPEG, or SVG | 個別スライドのレンダリング表現 | サムネイル、プレビュー、画像資産 |
| HTML or HTML5 | Web 向けプレゼンテーション出力 | ブラウザ表示と Web 公開 |

PPT や PPTX とは異なり、XML 出力は主に検査やデータ指向のワークフロー向けです。PDF、TIFF、HTML、スライド画像形式とは異なり、スライドをページやビジュアル資産としてレンダリングするのではなく、プレゼンテーション データを表します。[サポートされているファイル形式](/slides/ja/nodejs-java/supported-file-formats/) テーブルでは PowerPoint XML プレゼンテーションが保存専用形式としてリストされているため、エクスポートしたファイルを Aspose.Slides に再度読み込んで編集を続行する必要があるワークフローでは使用しないでください。

## **よくある質問**

**`SaveFormat.Xml` は PPTX ファイルを保存するのと同じですか？**

いいえ。PPTX は複数の Office Open XML パーツを含むパッケージであり、`SaveFormat.Xml` は PowerPoint XML プレゼンテーション ファイルを作成します。

**XML 出力をディスク上にファイルを作成せずに保存できますか？**

はい。書き込み可能なストリームを [Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) に渡します。たとえば、Java の `ByteArrayOutputStream` を使用し、そのデータを Node.js の `Buffer` にコピーしてメモリ内で処理できます。

**Aspose.Slides はエクスポートした XML ファイルを再度ロードできますか？**

いいえ。PowerPoint XML プレゼンテーションは現在保存はサポートされていますが、ロードはサポートされていません。ラウンドトリップ編集が必要な場合は PPTX もしくは他のサポートされているプレゼンテーション形式を使用してください。

**XML 変換は各スライドをページや画像としてレンダリングしますか？**

いいえ。XML 変換は構造化されたプレゼンテーション データを書き込みます。ページ指向の出力が必要な場合は PDF や TIFF を、個別スライドの画像が必要な場合は PNG、JPEG、SVG を使用してください。