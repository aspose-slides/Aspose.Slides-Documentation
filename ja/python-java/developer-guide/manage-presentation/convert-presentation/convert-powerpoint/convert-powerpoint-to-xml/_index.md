---
title: Python via Java で PowerPoint プレゼンテーションを XML に変換
linktitle: PowerPoint を XML に変換
type: docs
weight: 145
url: /ja/python-java/convert-powerpoint-to-xml/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、Python via Java で PowerPoint および OpenDocument プレゼンテーションを PowerPoint XML ファイルまたはストリームに変換します。"
---
## **概要**

Aspose.Slides for Python via Java は PowerPoint プレゼンテーションを PowerPoint XML プレゼンテーション形式に変換できます。XML 出力は、プレゼンテーション構造をテキストベースで確認したり、生成されたドキュメントのトラブルシューティングを行ったり、自動テストで出力を比較したり、XML を消費するワークフローと統合したりする場合に有用です。

[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドに、[SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) クラスの [Xml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Xml) 値を指定して使用します。結果はファイルに直接書き込むことも、ストリームに書き込むこともできます。

{{% alert color="info" title="注" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Xml) は PowerPoint XML プレゼンテーションを作成します。PPTX パッケージ内に格納されている個々の Office Open XML パーツ（例: `ppt/presentation.xml` やスライドごとの XML ファイル）を抽出するものではありません。正確な PPTX パッケージのパーツが必要な場合は、PPTX パッケージ自体を確認してください。

{{% /alert %}}

## **プレゼンテーションを XML ファイルに変換する**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスでソース プレゼンテーションをロードし、出力パスと [SaveFormat.Xml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Xml) を [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) に渡します。ソースは PPT、PPTX、ODP など、ロードがサポートされている任意のプレゼンテーション形式で構いません。

次の例は PPTX プレゼンテーションを XML ファイルに変換します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **XML 出力をストリームに書き込む**

XML をメモリ内に保持したり、Web サービス、ストレージ プロバイダー、XML 処理パイプラインなどの別コンポーネントに渡したりする必要がある場合は、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) のストリーム オーバーロードを使用します。次の例は結果を [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) に書き込み、Python の bytes オブジェクトとして取得します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # xml_data をワークフローの次のコンポーネントに渡す。
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **XML とプレゼンテーションおよびエクスポート形式の比較**

結果の利用方法に応じて出力形式を選択します。

| 形式 | 出力 | 主な使用例 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML プレゼンテーション | 構造の検査、トラブルシューティング、生成出力の比較、XML ベースの統合 |
| PPT (`.ppt`) | 従来のバイナリ プレゼンテーション ファイル | 古い PowerPoint ワークフローとの互換性 |
| PPTX (`.pptx`) | 複数パーツを含む Office Open XML パッケージ | 通常の PowerPoint 編集およびプレゼンテーションの交換 |
| PDF または TIFF | 固定レイアウト ページまたはマルチページ画像 | 表示、印刷、アーカイブ |
| PNG、JPEG、または SVG | 個々のスライドのレンダリング表現 | サムネイル、プレビュー、画像資産 |
| HTML または HTML5 | Web 向けプレゼンテーション出力 | ブラウザでの表示とウェブ公開 |

PPT や PPTX とは異なり、XML 出力は主に検査やデータ指向のワークフロー向けです。PDF、TIFF、HTML、スライド画像形式とは異なり、スライドをページやビジュアル資産としてレンダリングするのではなく、プレゼンテーション データを表現します。サポートされているファイル形式一覧 (/slides/ja/python-java/supported-file-formats/) では PowerPoint XML プレゼンテーションは保存専用形式として示されているため、エクスポートしたファイルを再度 Aspose.Slides に読み込んで編集を続行する必要があるワークフローでは使用しないでください。

## **FAQ**

**XML エクスポートは PPTX ファイルの保存と同じですか？**

いいえ。PPTX は複数の Office Open XML パーツを含むパッケージですが、[SaveFormat.Xml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Xml) は PowerPoint XML プレゼンテーション ファイルを作成します。

**XML 出力をディスクにファイルを作成せずに保存できますか？**

はい。[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) に書き込み可能な Java 出力ストリームを渡します。たとえば、インメモリ処理用に [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) を使用します。

**Aspose.Slides はエクスポートした XML ファイルを再度読み込めますか？**

いいえ。PowerPoint XML プレゼンテーションは現在保存のみがサポートされており、読み込みはサポートされていません。往復編集が必要な場合は PPTX などのサポートされているプレゼンテーション形式を使用してください。

**XML 変換は各スライドをページまたは画像としてレンダリングしますか？**

いいえ。XML 変換は構造化されたプレゼンテーション データを書き出します。ページ指向の出力が必要な場合は PDF や TIFF を、個別スライド画像が必要な場合は PNG、JPEG、SVG を使用してください。