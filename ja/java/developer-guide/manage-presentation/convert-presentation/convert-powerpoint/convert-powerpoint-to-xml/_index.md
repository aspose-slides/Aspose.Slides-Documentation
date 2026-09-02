---
title: JavaでPowerPointプレゼンテーションをXMLに変換する
linktitle: PowerPointをXMLへ
type: docs
weight: 145
url: /ja/java/convert-powerpoint-to-xml/
keywords:
- PowerPointをXMLに変換
- プレゼンテーションをXMLに変換
- PPTをXMLに変換
- PPTXをXMLに変換
- ODPをXMLに変換
- PowerPoint XML プレゼンテーション
- SaveFormat.Xml
- プレゼンテーションをXMLとして保存
- プレゼンテーションをXMLにエクスポート
- XMLストリーム
- Java
- Aspose.Slides
description: "Java の Aspose.Slides for Java を使用して、PowerPoint および OpenDocument プレゼンテーションを PowerPoint XML ファイルまたはストリームに変換します。"
---
## **概要**

Aspose.Slides for Java は PowerPoint プレゼンテーションを PowerPoint XML プレゼンテーション形式に変換できます。XML 出力は、プレゼンテーションの構造をテキストベースで確認したり、生成されたドキュメントのトラブルシューティングを行ったり、 자동テストで出力を比較したり、プレゼンテーション パッケージではなく XML を消費するワークフローと統合したりする場合に便利です。

[Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドに、[SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) クラスの `Xml` 値を指定します。結果はファイルに直接書き込むことも、ストリームに書き込むこともできます。

{{% alert color="info" title="注意" %}}

`SaveFormat.Xml` は PowerPoint XML プレゼンテーションを作成します。PPTX パッケージ内に格納されている個々の Office Open XML パーツを抽出するわけではありません。`ppt/presentation.xml` や個別のスライド XML ファイルなど、正確な PPTX パッケージのパーツが必要な場合は、PPTX パッケージ自体を調べてください。

{{% /alert %}}

## **プレゼンテーションを XML ファイルに変換する**

[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスでソース プレゼンテーションを読み込み、出力パスと `SaveFormat.Xml` を [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) に渡します。ソースは PPT、PPTX、ODP など、読み込みがサポートされている任意の形式にできます。

以下の例は PPTX プレゼンテーションを XML ファイルに変換します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML 出力をストリームに書き込む**

XML をメモリ上に保持したり、Web サービスやストレージ プロバイダー、XML 処理パイプラインなど別のコンポーネントに渡す必要がある場合は、[Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) のストリーム オーバーロードを使用します。次の例は結果を [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) に書き込み、バイト配列として XML を取得します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // ワークフローの次のコンポーネントに xmlData を渡す。
} finally {
    presentation.dispose();
}
```

## **XML とプレゼンテーションおよびエクスポート形式の比較**

使用シーンに応じて出力形式を選択してください。

| 形式 | 出力 | 主な利用シーン |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML プレゼンテーション | 構造の検査、トラブルシューティング、生成結果の比較、XML ベースの統合 |
| PPT (`.ppt`) | 従来のバイナリ プレゼンテーション ファイル | 古い PowerPoint ワークフローとの互換性 |
| PPTX (`.pptx`) | 複数パーツを含む Office Open XML パッケージ | 通常の PowerPoint 編集およびプレゼンテーションのやり取り |
| PDF または TIFF | 固定レイアウトのページまたは複数ページ画像 | 表示、印刷、アーカイブ |
| PNG、JPEG、または SVG | 個々のスライドのレンダリング結果 | サムネイル、プレビュー、画像資産 |
| HTML または HTML5 | Web 向けプレゼンテーション出力 | ブラウザ表示や Web 公開 |

PPT や PPTX とは異なり、XML 出力は主に検査やデータ指向のワークフロー向けです。PDF、TIFF、HTML、スライド画像形式とは異なり、スライドをページやビジュアル資産としてレンダリングするのではなく、プレゼンテーション データを表現します。[対応ファイル形式](/slides/ja/java/supported-file-formats/) テーブルでは PowerPoint XML プレゼンテーションは保存専用形式として一覧にあるため、エクスポートしたファイルを再度 Aspose.Slides で読み込んで編集する必要があるワークフローでは使用しないでください。

## **FAQ**

**`SaveFormat.Xml` は PPTX ファイルを保存するのと同じですか？**

いいえ。PPTX は複数の Office Open XML パーツを含むパッケージですが、`SaveFormat.Xml` は PowerPoint XML プレゼンテーション ファイルを作成します。

**XML 出力をディスクにファイルを作成せずに保存できますか？**

はい。[Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) に書き込み可能なストリームを渡します。たとえば、インメモリ処理用に [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) を使用します。

**Aspose.Slides はエクスポートした XML ファイルを再度読み込めますか？**

いいえ。PowerPoint XML プレゼンテーションは現在保存のみがサポートされており、読み込みはサポートされていません。ラウンドトリップでの編集が必要な場合は PPTX などの対応プレゼンテーション形式を使用してください。

**XML 変換は各スライドをページや画像としてレンダリングしますか？**

いいえ。XML 変換は構造化されたプレゼンテーション データを書き出します。ページ指向の出力が必要な場合は PDF や TIFF を、個々のスライド画像が必要な場合は PNG、JPEG、SVG を使用してください。