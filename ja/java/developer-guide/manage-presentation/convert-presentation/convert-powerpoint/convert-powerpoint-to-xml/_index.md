---
title: JavaでPowerPointプレゼンテーションをXMLに変換
linktitle: PowerPoint を XML に変換
type: docs
weight: 145
url: /ja/java/convert-powerpoint-to-xml/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーションを Java で PowerPoint XML ファイルまたはストリームに変換します。"
---
## **概要**

Aspose.Slides for Java は PowerPoint プレゼンテーションを PowerPoint XML プレゼンテーション形式に変換できます。XML 出力は、プレゼンテーションの構造をテキストベースで確認したり、生成されたドキュメントのトラブルシューティングを行ったり、テストで出力を比較したり、プレゼンテーション パッケージではなく XML を使用するワークフローに統合したりする場合に便利です。

[Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドを、[SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) クラスの `Xml` 値とともに使用します。結果はファイルに直接書き込むことも、ストリームに書き込むこともできます。

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` は PowerPoint XML プレゼンテーションを作成します。PPTX パッケージ内に格納されている個々の Office Open XML パーツは抽出しません。`ppt/presentation.xml` や個別のスライド XML ファイルなど、正確な PPTX パッケージ パーツが必要な場合は、PPTX パッケージ自体を確認してください。
{{% /alert %}}

## **プレゼンテーションを XML ファイルに変換する**

[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスでソース プレゼンテーションを読み込み、出力パスと `SaveFormat.Xml` を [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) に渡します。ソースは PPT、PPTX、ODP など、読み込みに対応している任意の形式にできます。

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

XML をメモリ内に保持したり、Web サービスやストレージ プロバイダー、XML 処理パイプラインなど別コンポーネントに渡す必要がある場合は、[Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) のストリーム オーバーロードを使用します。以下の例は結果を [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) に書き込み、バイト配列として XML を取得します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // xmlData をワークフローの次のコンポーネントに渡す。
} finally {
    presentation.dispose();
}
```

## **XML とプレゼンテーションおよびエクスポート形式の比較**

使用目的に応じて出力形式を選択してください。

| 形式 | 出力 | 主な使用例 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML プレゼンテーション | 構造の検査、トラブルシューティング、生成結果の比較、XML ベースの統合 |
| PPT (`.ppt`) | レガシー バイナリ プレゼンテーション ファイル | 従来の PowerPoint ワークフローとの互換性 |
| PPTX (`.pptx`) | 複数パーツを含む Office Open XML パッケージ | 通常の PowerPoint 編集とプレゼンテーションのやり取り |
| PDF または TIFF | 固定レイアウト ページまたは複数ページ画像 | 表示、印刷、アーカイブ |
| PNG、JPEG、または SVG | 個々のスライドのレンダリング表現 | サムネイル、プレビュー、画像アセット |
| HTML または HTML5 | Web 向けプレゼンテーション出力 | ブラウザ表示と Web 公開 |

PPT や PPTX とは異なり、XML 出力は主に検査やデータ指向のワークフロー向けです。PDF、TIFF、HTML、スライド画像形式とは異なり、スライドをページやビジュアル資産としてレンダリングするのではなく、プレゼンテーション データを表現します。[supported file formats](/slides/ja/java/supported-file-formats/) テーブルには、Aspose.Slides がロード、インポート、保存、またはレンダリングできるすべての形式が一覧されています。

## **FAQ**

**`SaveFormat.Xml` は PPTX ファイルを保存するのと同じですか？**

いいえ。PPTX は複数の Office Open XML パーツを含むパッケージですが、`SaveFormat.Xml` は PowerPoint XML プレゼンテーション ファイルを作成します。

**XML 出力をディスク上にファイルを作成せずに保存できますか？**

はい。書き込み可能なストリームを [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) に渡します。たとえば、インメモリ処理のために [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) を使用します。

**Aspose.Slides はエクスポートした XML ファイルを再度読み込めますか？**

はい。XML ファイルまたはストリームを [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) コンストラクターに渡します。[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSourceFormat--) は `SourceFormat.Xml` を返します。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) はこの形式に対して `LoadFormat.Unknown` を報告するため、XML ファイルが開けるかどうかの判定に使用しないでください。

**XML 変換は各スライドをページまたは画像としてレンダリングしますか？**

いいえ。XML 変換は構造化されたプレゼンテーション データを書き出します。ページ指向の出力が必要な場合は PDF や TIFF を、個別スライド画像が必要な場合は PNG、JPEG、SVG を使用してください。