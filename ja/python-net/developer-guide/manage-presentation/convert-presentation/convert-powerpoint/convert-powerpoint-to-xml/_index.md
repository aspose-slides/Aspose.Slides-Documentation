---
title: Python で PowerPoint プレゼンテーションを XML に変換
linktitle: PowerPoint から XML へ
type: docs
weight: 145
url: /ja/python-net/convert-powerpoint-to-xml/
keywords:
- PowerPoint を XML に変換
- プレゼンテーションを XML に変換
- PPT を XML に変換
- PPTX を XML に変換
- ODP を XML に変換
- PowerPoint XML プレゼンテーション
- SaveFormat.XML
- プレゼンテーションを XML として保存
- プレゼンテーションを XML にエクスポート
- XML ストリーム
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、PowerPoint および OpenDocument のプレゼンテーションを Python で PowerPoint XML ファイルまたはストリームに変換します。"
---
## **概要**

Aspose.Slides for Python via .NET は PowerPoint プレゼンテーションを PowerPoint XML Presentation 形式に変換できます。XML 出力は、プレゼンテーションの構造を検査したり、生成されたドキュメントのトラブルシューティングを行ったり、自動テストで出力を比較したり、プレゼンテーション パッケージではなく XML を使用するワークフローに統合したりする際に、テキストベースの表現が必要な場合に便利です。

[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) メソッドに、[SaveFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) 列挙体の `XML` 値を指定して使用します。結果はファイルに直接書き込むことも、ストリームに書き込むこともできます。

{{% alert color="info" title="Note" %}}
`SaveFormat.XML` は PowerPoint XML Presentation を作成します。PPTX パッケージ内に保存されている個々の Office Open XML パーツは抽出しません。`ppt/presentation.xml` や個々のスライド XML ファイルなど、正確な PPTX パッケージのパーツが必要な場合は、PPTX パッケージ自体を調べてください。
{{% /alert %}}

## **プレゼンテーションを XML ファイルに変換する**

[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスでソースのプレゼンテーションを読み込み、出力パスと `SaveFormat.XML` を [Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) に渡します。ソースは PPT、PPTX、ODP など、読み込みがサポートされている任意のプレゼンテーション形式にできます。

次の例は PPTX プレゼンテーションを XML ファイルに変換します。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **XML 出力をストリームに書き込む**

XML をメモリ内に保持したままにしたり、Web サービス、ストレージ プロバイダー、XML 処理パイプラインなどの別コンポーネントに渡す必要がある場合は、[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) のストリーム オーバーロードを使用します。次の例は結果を [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) ストリームに書き込み、後続の読み取りのためにシークバックします。

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # 次のコンポーネントに xml_stream を渡す。
```

## **XML とプレゼンテーションおよびエクスポート形式の比較**

結果の利用目的に応じて出力形式を選択してください:

| Format | Output | Typical use |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML プレゼンテーション | 構造の検査、トラブルシューティング、生成された出力の比較、XML ベースの統合 |
| PPT (`.ppt`) | レガシーバイナリ プレゼンテーション ファイル | 古い PowerPoint ワークフローとの互換性 |
| PPTX (`.pptx`) | 複数のパーツを含む Office Open XML パッケージ | 通常の PowerPoint 編集とプレゼンテーションのやり取り |
| PDF or TIFF | 固定レイアウトのページまたは複数ページの画像 | 閲覧、印刷、アーカイブ |
| PNG, JPEG, or SVG | 個々のスライドのレンダリング表現 | サムネイル、プレビュー、画像アセット |
| HTML or HTML5 | Web 向けのプレゼンテーション出力 | ブラウザでの閲覧と Web 公開 |

PPT や PPTX とは異なり、XML 出力は主に検査やデータ指向のワークフロー向けです。PDF、TIFF、HTML、スライド画像形式とは異なり、スライドをページやビジュアル資産としてレンダリングするのではなく、プレゼンテーション データを表します。[サポートされているファイル形式](/slides/ja/python-net/supported-file-formats/) 表では PowerPoint XML Presentation が保存専用形式として一覧示されているため、エクスポートされたファイルを再度 Aspose.Slides に読み込んで編集を続行する必要があるワークフローでは使用しないでください。

## **FAQ**

**`SaveFormat.XML` は PPTX ファイルを保存するのと同じですか？**

いいえ。PPTX は複数の Office Open XML パーツを含むパッケージですが、`SaveFormat.XML` は PowerPoint XML Presentation ファイルを作成します。

**XML 出力をディスクにファイルを作成せずに保存できますか？**

はい。[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) に書き込み可能なストリームを渡すだけです。例えば、インメモリ処理のために [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) ストリームを使用します。

**Aspose.Slides はエクスポートした XML ファイルを再度読み込めますか？**

いいえ。PowerPoint XML Presentation は現在保存はサポートされていますが、読み込みはサポートされていません。往復編集が必要な場合は、PPTX や他のサポートされているプレゼンテーション形式を使用してください。

**XML 変換は各スライドをページまたは画像としてレンダリングしますか？**

いいえ。XML 変換は構造化されたプレゼンテーション データを書き込みます。ページ指向の出力が必要な場合は PDF や TIFF を、個別スライド画像が必要な場合は PNG、JPEG、SVG を使用してください。