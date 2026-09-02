---
title: Android で PowerPoint プレゼンテーションを XML に変換
linktitle: PowerPoint を XML に変換
type: docs
weight: 145
url: /ja/androidjava/convert-powerpoint-to-xml/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Android 上で PowerPoint および OpenDocument のプレゼンテーションを PowerPoint XML ファイルまたはストリームに変換します。"
---
## **概要**

Aspose.Slides for Android via Java は PowerPoint プレゼンテーションを PowerPoint XML Presentation 形式に変換できます。XML 出力は、プレゼンテーション構造の検査、生成された文書のトラブルシューティング、テストでの自動比較、プレゼンテーション パッケージではなく XML を消費するワークフローとの統合が必要な場合に便利です。

[Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドを [SaveFormat.Xml](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/#Xml) と共に使用します。結果をファイルまたはストリームに直接書き込むことができます。

{{% alert color="info" title="注" %}}
`SaveFormat.Xml` は PowerPoint XML Presentation を作成します。PPTX パッケージ内に格納されている個々の Office Open XML パーツは抽出しません。`ppt/presentation.xml` や個別のスライド XML ファイルなど、正確な PPTX パッケージ パーツが必要な場合は PPTX パッケージ自体を確認してください。
{{% /alert %}}

## **プレゼンテーションをXMLファイルに変換**

[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスでソース プレゼンテーションを読み込み、出力パスと [SaveFormat.Xml](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/#Xml) を [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) に渡します。ソースは PPT、PPTX、ODP など、読み込みに対応した任意の形式にできます。

次の例は PPTX プレゼンテーションを XML ファイルに変換します。

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

XML をメモリ上に保持したり、Web サービス、ストレージ プロバイダー、XML 処理パイプラインなど別コンポーネントに渡す必要がある場合は、[Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) のストリーム オーバーロードを使用します。次の例は結果を [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) に書き込み、生成された XML をバイト配列として取得します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // ワークフローの次のコンポーネントに xmlData を渡す。
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML とプレゼンテーション/エクスポート形式の比較**

結果の使用方法に応じて出力形式を選択してください。

| 形式 | 出力 | 典型的な使用例 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML プレゼンテーション | 構造の検査、トラブルシューティング、生成出力の比較、XML ベースの統合 |
| PPT (`.ppt`) | レガシーのバイナリプレゼンテーションファイル | 旧バージョン PowerPoint ワークフローとの互換性 |
| PPTX (`.pptx`) | 複数のパーツを含む Office Open XML パッケージ | 通常の PowerPoint 編集およびプレゼンテーションのやり取り |
| PDF または TIFF | 固定レイアウトのページまたは複数ページ画像 | 表示、印刷、アーカイブ |
| PNG、JPEG、または SVG | 個々のスライドのレンダリング表現 | サムネイル、プレビュー、画像アセット |
| HTML または HTML5 | Web 向けプレゼンテーション出力 | ブラウザ表示と Web 公開 |

PPT や PPTX とは異なり、XML 出力は主に検査やデータ指向のワークフロー向けです。PDF、TIFF、HTML、スライド画像形式とは異なり、スライドをページやビジュアル資産としてレンダリングするのではなく、プレゼンテーション データを表現します。[サポートされているファイル形式](/slides/ja/androidjava/supported-file-formats/) テーブルでは PowerPoint XML Presentation が保存専用形式として一覧に掲載されているため、エクスポートしたファイルを再度 Aspose.Slides に読み込んで編集を続行する必要があるワークフローでは使用しないでください。

## **FAQ**

**`SaveFormat.Xml` は PPTX ファイルの保存と同じですか？**

いいえ。PPTX は複数の Office Open XML パーツを含むパッケージですが、`SaveFormat.Xml` は PowerPoint XML Presentation ファイルを作成します。

**XML 出力をディスクにファイルを作成せずに保存できますか？**

はい。[Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) に書き込み可能なストリームを渡してください。例として、インメモリ処理用に [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) を使用できます。

**Aspose.Slides はエクスポートした XML ファイルを再度読み込めますか？**

いいえ。PowerPoint XML Presentation は現在保存のみがサポートされており、読み込みはサポートされていません。往復編集が必要な場合は PPTX もしくは他のサポート対象プレゼンテーション形式を使用してください。

**XML 変換は各スライドをページや画像としてレンダリングしますか？**

いいえ。XML 変換は構造化されたプレゼンテーション データを書き出します。ページ指向の出力が必要な場合は PDF や TIFF を、個別スライド画像が必要な場合は PNG、JPEG、SVG を使用してください。