---
title: PowerPoint プレゼンテーションを .NET で XML に変換する
linktitle: PowerPoint から XML へ
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
description: "C# と Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションを PowerPoint XML ファイルまたはストリームに変換します。"
---
## **概要**

Aspose.Slides for .NET は PowerPoint プレゼンテーションを PowerPoint XML Presentation 形式に変換できます。XML 出力は、プレゼンテーションの構造をテキストベースで確認したり、生成されたドキュメントのトラブルシューティングを行ったり、 자동化テストで出力を比較したり、プレゼンテーション パッケージではなく XML を消費するワークフローと統合したりする必要がある場合に便利です。

[Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドを使用し、[SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) 列挙体の `Xml` 値を指定します。結果はファイルに直接書き込むことも、ストリームに書き込むこともできます。

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` は PowerPoint XML Presentation を作成します。PPTX パッケージ内に格納されている個々の Office Open XML パーツは抽出しません。`ppt/presentation.xml` や個別のスライド XML ファイルなど、正確な PPTX パッケージ パーツが必要な場合は、PPTX パッケージ自体を確認してください。
{{% /alert %}}

## **プレゼンテーションを XML ファイルに変換する**

[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスでソース プレゼンテーションを読み込み、出力パスと `SaveFormat.Xml` を [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) に渡します。ソースは PPT、PPTX、ODP など、読み込みがサポートされている任意のプレゼンテーション形式にできます。

以下の例は PPTX プレゼンテーションを XML ファイルに変換します：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **XML 出力をストリームに書き込む**

XML をメモリに保持したまま、または Web サービス、ストレージ プロバイダー、XML 処理パイプラインなどの別コンポーネントに渡す必要がある場合は、[Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) のストリーム オーバーロードを使用します。以下の例は結果を [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) に書き込み、後続の読み取りのためにシーク位置を先頭に戻します：

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// xmlStream をワークフローの次のコンポーネントに渡す。
```

## **XML とプレゼンテーションおよびエクスポート形式の比較**

結果の使用方法に応じて出力形式を選択します。

| 形式 | 出力 | 典型的な使用例 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | 構造の検査、トラブルシューティング、生成出力の比較、XML ベースの統合 |
| PPT (`.ppt`) | 従来のバイナリ プレゼンテーション ファイル | 旧バージョン PowerPoint ワークフローとの互換性 |
| PPTX (`.pptx`) | 複数パーツを含む Office Open XML パッケージ | 通常の PowerPoint 編集とプレゼンテーションのやり取り |
| PDF または TIFF | 固定レイアウト ページまたはマルチページ画像 | 表示、印刷、アーカイブ |
| PNG、JPEG、または SVG | 個々のスライドのレンダリング表現 | サムネイル、プレビュー、画像資産 |
| HTML または HTML5 | Web 向けプレゼンテーション出力 | ブラウザー表示とウェブ公開 |

PPT や PPTX とは異なり、XML 出力は主に検査およびデータ指向のワークフロー向けです。PDF、TIFF、HTML、スライド画像形式とは異なり、スライドをページやビジュアル資産としてレンダリングするのではなく、プレゼンテーション データを表現します。[サポートされているファイル形式](/slides/ja/net/supported-file-formats/) テーブルでは PowerPoint XML Presentation が保存専用形式として掲載されているため、エクスポートしたファイルを再度 Aspose.Slides に読み込んで編集するようなワークフローでは使用しないでください。

## **FAQ**

**`SaveFormat.Xml` は PPTX ファイルの保存と同じですか？**

いいえ。PPTX は複数の Office Open XML パーツを含むパッケージですが、`SaveFormat.Xml` は PowerPoint XML Presentation ファイルを作成します。

**XML 出力をディスクにファイルを作成せずに保存できますか？**

はい。書き込み可能なストリームを [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) に渡します。たとえば、インメモリ処理用に [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) を使用できます。

**Aspose.Slides はエクスポートした XML ファイルを再度読み込めますか？**

いいえ。PowerPoint XML Presentation は現在、保存のみがサポートされており、読み込みはサポートされていません。往復編集が必要な場合は PPTX などのサポートされているプレゼンテーション形式を使用してください。

**XML 変換は各スライドをページや画像としてレンダリングしますか？**

いいえ。XML 変換は構造化されたプレゼンテーション データを書き出します。ページ指向の出力が必要な場合は PDF や TIFF を、個別スライド画像が必要な場合は PNG、JPEG、SVG を使用してください。