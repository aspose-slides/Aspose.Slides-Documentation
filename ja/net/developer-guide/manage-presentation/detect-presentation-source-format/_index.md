---
title: .NET で元のプレゼンテーション形式を判定する
linktitle: ソース形式
type: docs
weight: 35
url: /ja/net/detect-presentation-source-format/
keywords:
- ソース形式
- プレゼンテーション形式の検出
- PowerPoint
- OpenDocument
- プレゼンテーション
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET を使用した C# で読み込まれたプレゼンテーションの元の形式を取得し、検出 API を比較し、ファイル、ストリーム、レガシーフォーマットを処理します。"
---
## **概要**

プレゼンテーションを読み込んだ後、読み取り専用の [Presentation.SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sourceformat/) プロパティを取得して、元の形式を判定します。このプロパティは [IPresentation.SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/sourceformat/) でも利用可能です。現在のインスタンスがどの形式から読み込まれたかに依存する後続処理が必要な場合に使用します。

ソース形式は、出力ファイルに対して選択する [SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) とは別物です。別の形式で保存しても、既存インスタンスのソース形式は変わりません。

## **ファイルのソース形式を取得する**

この例は既存の `sample.pptx` ファイルが必要です。ファイルを読み込み、ファイル名ではなく [Presentation.SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sourceformat/) を使ってアプリケーションの処理ポリシーを選択します。入力パスを変更すれば他の形式でも試せます。例は選択されたポリシーを出力しますので、メッセージはご自身のロジックに置き換えてください。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **サポートされている値を認識する**

[SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/sourceformat/) 列挙体は以下のプレゼンテーション形式を区別します。下記の拡張子は慣例的なものであり、元のファイル名を再構成したものではありません。

| SourceFormat 値 | 拡張子 | フォーマット |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 プレゼンテーション |
| `Pptx` | `.pptx` | Office Open XML プレゼンテーション |
| `Pptm` | `.pptm` | マクロ有効 Office Open XML プレゼンテーション |
| `Pps` | `.pps` | PowerPoint 97–2003 スライドショー |
| `Ppsx` | `.ppsx` | Office Open XML スライドショー |
| `Ppsm` | `.ppsm` | マクロ有効 Office Open XML スライドショー |
| `Pot` | `.pot` | PowerPoint 97–2003 テンプレート |
| `Potx` | `.potx` | Office Open XML テンプレート |
| `Potm` | `.potm` | マクロ有効 Office Open XML テンプレート |
| `Odp` | `.odp` | OpenDocument プレゼンテーション |
| `Otp` | `.otp` | OpenDocument プレゼンテーションテンプレート |
| `Fodp` | `.fodp` | Flat XML ODF プレゼンテーション |
| `Xml` | `.xml` | PowerPoint XML プレゼンテーション |

## **ストリームのソース形式を取得する**

この例は既存の `sample.pps` ファイルが必要です。バイト列をメモリストリームに読み込むことで、データベースの値やアップロードされたバイト配列など、ファイル名なしで受け取った入力をシミュレートします。[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) コンストラクタはストリームのみを受け取ります。

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT、PPS、POT は同じ基礎バイナリ形式を使用します。ファイルパスで読み込む場合は拡張子でスライドショーやテンプレートを区別できますが、ファイル名が無い場合はレガシーな PPS や POT のコンテンツが `SourceFormat.Ppt` と報告されることがあります（上記の PPS の例は `Ppt` を報告します）。

アプリケーションでこの区別を保持する必要がある場合は、元のファイル名またはサブタイプメタデータを別途保存してください。拡張子はレガシーサブタイプの有用なヒントになりますが、任意のプレゼンテーションコンテンツを判別する唯一の根拠にすべきではありません。

## **読み込み前後の検出を比較する**

ファイル全体のプレゼンテーションオブジェクトモデルをロードする前にファイルを検査したい場合は、[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/getpresentationinfo/) と [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/loadformat/) を使用します。インスタンスがすでに存在する場合は、[Presentation.SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sourceformat/) を使用してください。

この例は `sample.pptx` が必要で、両方のチェックで `Pptx` を出力します。実運用では処理段階に応じた API を選択してください。すでにロード済みのプレゼンテーションに対してソース形式を取得するために再度検査する必要はありません。

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

結果の列挙型は異なります: [LoadFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/loadformat/) と [SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/sourceformat/)。数値をキャストして比較したり、すべての形式が同一の検出結果を持つと想定したりしないでください。下記の「保存して再オープン」チェックでは、PowerPoint XML がロード前は `LoadFormat.Unknown`、ロード後は `SourceFormat.Xml` と報告されました。

## **ソース形式と出力形式を分離して保持する**

この例は `sample.pptx` を入力に取り、`converted.odp` に書き込みます。保存前後で `Pptx` が出力され、ODP に変換した新しいインスタンスだけが `Odp` を報告します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

`new Presentation()` で最初から作成したプレゼンテーションは `SourceFormat.Pptx` を報告します。入力ファイルがないため、これは新規インスタンスのデフォルト値であり、PPTX ファイルがロードされたことを示すものではありません。作成か読み込みかを区別したい場合は、別途追跡してください。

## **ソース形式を拡張子にマッピングする**

この例は `sample.pptx` が必要です。現在サポートされているすべての [SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/sourceformat/) の値を、入力ファイル名を解析せずに慣例的な拡張子へマッピングします。未対応の値に対しては拡張子が自動的に付与されることを防ぐフォールバックが含まれます。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

このマッピングはファイルを変換したり、ストリーム読み込み時に失われたレガシー PPS/POT サブタイプを復元したりするものではありません。実際に保存する場合は、[SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) を明示的に指定するか、[Save Presentations in Their Original Format](/slides/ja/net/save-presentation/#save-presentations-in-their-original-format) に示す変換方法を使用してください。

## **保存して再オープンで形式を検証する**

この自己完結型サンプルはプレゼンテーションを作成し、作業ディレクトリに 3 つのファイルを書き込みます（同名ファイルは上書き）。各出力ファイルをパスとメモリストリームの両方で再オープンします。PPTX と ODP は両ルートで保存形式を報告しますが、PPS はパスで読み込むと `Pps`、ファイル名なしで同じバイト列を読み込むと `Ppt` を報告します。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

上記のすべての形式で同様のチェックを行った結果は以下の通りです（拡張子が一致する生成プレゼンテーション）:

| 保存形式 | ファイルパスからの SourceFormat | 名前なしストリームからの SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` それぞれ | ファイルパスと同じ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` それぞれ | ファイルパスと同じ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` それぞれ | ファイルパスと同じ |
| ODP, OTP | `Odp`, `Otp` それぞれ | ファイルパスと同じ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

このチェックでは、名前なしストリームに対する唯一のソース形式正規化は PPS/POT を `Ppt` に変換することだけです。表は形式の識別結果を示しており、変換時にすべてのプレゼンテーション機能が保持されることを保証するものではありません。

## **FAQ**

**ODP に保存すると、PPTX から読み込んだプレゼンテーションのソース形式は変わりますか？**

いいえ。既存インスタンスは依然として `Pptx` を報告します。保存後に ODP ファイルからロードしたインスタンスは `Odp` を報告します。

**ストリームだけでレガシーなプレゼンテーション、スライドショー、テンプレートを区別できますか？**

できません。PPT、PPS、POT は同じバイナリ形式を共有します。区別が必要な場合は、ファイル名またはサブタイプメタデータを別途保持してください。

**プレゼンテーションがすでにロードされている場合、どの API を使うべきですか？**

[Presentation.SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sourceformat/) を使用してください。ロード前の検査が必要な場合は、[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/getpresentationinfo/) を利用します。