---
title: PHPでPowerPointプレゼンテーションをXMLに変換
linktitle: PowerPointからXMLへ
type: docs
weight: 145
url: /ja/php-java/convert-powerpoint-to-xml/
keywords:
- PowerPointをXMLに変換
- プレゼンテーションをXMLに変換
- PPTをXMLに変換
- PPTXをXMLに変換
- ODPをXMLに変換
- PowerPoint XMLプレゼンテーション
- SaveFormat.Xml
- プレゼンテーションをXMLとして保存
- プレゼンテーションをXMLにエクスポート
- XMLストリーム
- PHP
- Aspose.Slides
description: "PowerPointおよびOpenDocumentプレゼンテーションを、PHP用Aspose.Slides for Javaを使用してPowerPoint XMLファイルまたはストリームに変換します。"
---
## **概要**

Aspose.Slides for PHP via Java は PowerPoint プレゼンテーションを PowerPoint XML プレゼンテーション形式に変換できます。XML 出力は、プレゼンテーションの構造を確認したり、生成されたドキュメントのトラブルシューティングを行ったり、テストの自動化で出力を比較したり、プレゼンテーション パッケージではなく XML を利用するワークフローと統合したりする際に、テキストベースの表現が必要な場合に便利です。

[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) メソッドに、[SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) 列挙体の `Xml` 値を使用します。結果をファイルやストリームに直接書き込むことができます。

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` は PowerPoint XML プレゼンテーションを作成します。PPTX パッケージ内に格納された個々の Office Open XML パーツは抽出しません。`ppt/presentation.xml` や個々のスライド XML ファイルなど、正確な PPTX パッケージのパーツが必要な場合は、PPTX パッケージ自体を確認してください。
{{% /alert %}}

## **プレゼンテーションを XML ファイルに変換する**

[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスでソース プレゼンテーションを読み込み、出力パスと `SaveFormat::Xml` を [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) に渡します。ソースは PPT、PPTX、ODP など、読み込みがサポートされている任意のプレゼンテーション形式にできます。

以下の例は PPTX プレゼンテーションを XML ファイルに変換します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **XML 出力をストリームに書き込む**

XML をメモリ内に保持したまま、または Web サービスやストレージ プロバイダー、XML 処理パイプラインなどの別コンポーネントに渡す必要がある場合は、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) のストリーム オーバーロードを使用します。以下の例は結果を [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) に書き込み、生成された XML をバイト配列として取得します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // ワークフロー内の次のコンポーネントに $xmlBytes を渡します。
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

`ByteArrayOutputStream` は生成されたデータをすべてメモリに保持するため、`toByteArray` を呼び出す前に位置のリセットは必要ありません。

## **XML とプレゼンテーション・エクスポート形式の比較**

結果の使用方法に応じて出力形式を選択してください：

| フォーマット | 出力 | 主な使用例 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML プレゼンテーション | 構造の確認、トラブルシューティング、生成出力の比較、XML ベースの統合 |
| PPT (`.ppt`) | 従来のバイナリ プレゼンテーション ファイル | 旧バージョンの PowerPoint ワークフローとの互換性 |
| PPTX (`.pptx`) | 複数のパーツを含む Office Open XML パッケージ | 通常の PowerPoint 編集およびプレゼンテーションのやり取り |
| PDF または TIFF | 固定レイアウトのページまたはマルチページ画像 | 表示、印刷、アーカイブ |
| PNG、JPEG、または SVG | 個々のスライドのレンダリング 表現 | サムネイル、プレビュー、画像資産 |
| HTML または HTML5 | Web 向けプレゼンテーション出力 | ブラウザーでの表示やウェブ公開 |

PPT や PPTX とは異なり、XML 出力は主に検査やデータ指向のワークフローを目的としています。PDF、TIFF、HTML、スライド画像形式とは異なり、スライドをページや視覚的資産としてレンダリングするのではなく、プレゼンテーション データを表現します。[サポートされているファイル形式](/slides/ja/php-java/supported-file-formats/) の表では PowerPoint XML プレゼンテーションが保存専用形式として示されているため、エクスポートしたファイルを再度 Aspose.Slides に読み込んで編集を続行する必要があるワークフローでは使用しないでください。

## **FAQ**

**`SaveFormat::Xml` は PPTX ファイルを保存するのと同じですか？**

いいえ。PPTX は複数の Office Open XML パーツを含むパッケージですが、`SaveFormat::Xml` は PowerPoint XML プレゼンテーション ファイルを作成します。

**XML 出力をディスクにファイルを作成せずに保存できますか？**

はい。書き込み可能なストリームを [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) に渡します。例えば、インメモリ処理のために [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) を使用します。

**Aspose.Slides はエクスポートされた XML ファイルを再度読み込めますか？**

いいえ。PowerPoint XML プレゼンテーションは現在保存はサポートされていますが、読み込みはサポートされていません。往復編集が必要な場合は、PPTX などのサポートされているプレゼンテーション形式を使用してください。

**XML 変換は各スライドをページや画像としてレンダリングしますか？**

いいえ。XML 変換は構造化されたプレゼンテーション データを書き出します。ページ指向の出力が必要な場合は PDF や TIFF を、個々のスライド画像が必要な場合は PNG、JPEG、SVG を使用してください。