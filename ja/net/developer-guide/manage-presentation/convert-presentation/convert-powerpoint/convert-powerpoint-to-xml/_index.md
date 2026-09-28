---
title: .NET で PowerPoint プレゼンテーションを XML に変換
linktitle: PowerPoint を XML に変換
type: docs
weight: 145
url: /ja/net/convert-powerpoint-to-xml/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、C# で PowerPoint および OpenDocument プレゼンテーションを PowerPoint XML ファイルまたはストリームに変換します。"
---
## **概要**

Aspose.Slides for .NET は PowerPoint プレゼンテーションを PowerPoint XML プレゼンテーション形式に変換できます。XML 出力は、プレゼンテーション構造のテキストベース表現が必要なとき、生成されたドキュメントのトラブルシューティング、自動テストでの出力比較、またはプレゼンテーション パッケージではなく XML を消費するワークフローとの統合に便利です。

[Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドに、[SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) 列挙体の `Xml` 値を指定して使用します。結果はファイルに直接書き込むことも、ストリームに書き込むこともできます。

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` は PowerPoint XML プレゼンテーションを作成します。PPTX パッケージ内に格納された個々の Office Open XML パーツを抽出するものではありません。`ppt/presentation.xml` や個々のスライド XML ファイルなど、正確な PPTX パッケージ パーツが必要な場合は、PPTX パッケージ自体を調べてください。
{{% /alert %}}

## **プレゼンテーションをXMLファイルに変換**

[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスでソース プレゼンテーションを読み込み、出力パスと `SaveFormat.Xml` を [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) に渡します。ソースは PPT、PPTX、ODP など、読み込みがサポートされている任意のプレゼンテーション形式にできます。

以下の例は PPTX プレゼンテーションを XML ファイルに変換します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **XML出力をストリームに書き込む**

XML をメモリ内に保持したり、Web サービス、ストレージ プロバイダー、XML 処理パイプラインなどの別コンポーネントに渡す必要がある場合は、[Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) のストリーム オーバーロードを使用します。以下の例は結果を [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) に書き込み、後続の読み取りのためにシーク位置を戻しています。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// xmlStream をワークフローの次のコンポーネントに渡します。
```

## **XML とプレゼンテーション・エクスポート形式の比較**

使用目的に応じて出力形式を選択してください。

| 形式 | 出力 | 主な使用例 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML プレゼンテーション | 構造の検査、トラブルシューティング、生成出力の比較、XML ベースの統合 |
| PPT (`.ppt`) | 従来のバイナリ プレゼンテーション ファイル | 古い PowerPoint ワークフローとの互換性 |
| PPTX (`.pptx`) | 複数パーツを含む Office Open XML パッケージ | 通常の PowerPoint 編集およびプレゼンテーションのやり取り |
| PDF または TIFF | 固定レイアウト ページまたは TIFF 画像 | 表示、印刷、アーカイブ |
| PNG、JPEG、または SVG | 個々のスライドのレンダリング表現 | サムネイル、プレビュー、画像アセット |
| HTML または HTML5 | Web 向けプレゼンテーション出力 | ブラウザ表示およびウェブ公開 |

PPT や PPTX とは異なり、XML 出力は主に検査やデータ指向のワークフローを対象としています。PDF、TIFF、HTML、スライド画像形式とは異なり、スライドをページやビジュアル アセットとしてレンダリングするのではなく、プレゼンテーション データを表現します。利用可能なすべての形式は、[サポートされているファイル形式](/slides/ja/net/supported-file-formats/) テーブルで確認できます。

## **FAQ**

**`SaveFormat.Xml` は PPTX ファイルの保存と同じですか？**

いいえ。PPTX は複数の Office Open XML パーツを含むパッケージですが、`SaveFormat.Xml` は PowerPoint XML プレゼンテーション ファイルを作成します。

**XML 出力をディスクにファイルを作成せずに保存できますか？**

可能です。書き込み可能なストリームを [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) に渡してください。例として、インメモリ処理用に [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) を使用できます。

**Aspose.Slides はエクスポートした XML ファイルを再度読み込めますか？**

はい。XML ファイルまたはストリームを [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/presentation/) コンストラクタに渡します。`Presentation.SourceFormat` は `SourceFormat.Xml` を返します。`PresentationFactory.GetPresentationInfo` はこの形式に対して `LoadFormat.Unknown` を報告するため、XML ファイルが開けるかどうかの判定に使用しないでください。

**XML 変換は各スライドをページまたは画像としてレンダーしますか？**

いいえ。XML 変換は構造化されたプレゼンテーション データを書き出します。ページ指向の出力が必要な場合は PDF や TIFF を、個別スライド画像が必要な場合は PNG、JPEG、SVG を使用してください。