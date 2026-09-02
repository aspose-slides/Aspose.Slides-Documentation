---
title: .NET でプレゼンテーション情報の取得と更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/net/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET を使用して PowerPoint と OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、迅速なインサイトと賢いコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの形式を識別し、完全なプレゼンテーション オブジェクト モデルを作成せずにドキュメント メタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを作成したり、プレゼンテーションの内容を読み込んで処理するかどうかを決定する前にプロパティを検査したりする際に便利です。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/) と [IPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/) を使用した軽量検査、および [IDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/) を使用した対象更新を示します。

## **プレゼンテーション形式の確認**

[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/getpresentationinfo/) を使用して、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを作成せずにファイルを検査します。[IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/loadformat/) プロパティは、PPTX、PPT、ODP など検出された形式を報告します。

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **軽量プレゼンテーションインベントリの構築**

多数のプレゼンテーション ファイルを処理する場合、検証、インデックス作成、または文書管理システム用のコンパクトなインベントリが必要になることがあります。このシナリオでは、[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/getpresentationinfo/) を使用して [IPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/) オブジェクトを取得し、次に [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/readdocumentproperties/) を呼び出してドキュメント メタデータを読み取ります。このアプローチは、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを作成したり、完全なプレゼンテーション オブジェクト モデルを走査したりする必要がありません。

[IDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/) が提供する拡張プロパティは、以下のインベントリ値を示します。

| プロパティ | インベントリ値 |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/slides/ja/) | スライドの総数。 |
| [HiddenSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/hiddenslides/) | 非表示スライドの数。 |
| [Notes](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/notes/) | ノートが含まれるスライドの数。 |
| [Paragraphs](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/paragraphs/) | 利用可能な場合の段落総数。 |
| [Words](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/words/) | 単語の総数。 |
| [MultimediaClips](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/multimediaclips/) | オーディオおよびビデオクリップの総数。 |

以下の例は、これらの値を [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) オブジェクトを作成せずに読み取り、コンパクトなインベントリを出力します。また、[HeadingPairs](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/headingpairs/) と [TitlesOfParts](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/titlesofparts/) を組み合わせて、フォント、テーマ、スライド タイトルなどのコンテンツ グループを表示します。

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

各 [IHeadingPair](https://reference.aspose.com/slides/ja/net/aspose.slides/iheadingpair/) はグループ名とそのグループ内の項目数を提供します。[IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/titlesofparts/) はフラットで順序付けられた配列であるため、各ヘッディング ペアで指定された連続タイトル数だけ消費します。

### **保存されたメタデータと形式の制限**

[IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/readdocumentproperties/) が返すインベントリ プロパティは、ソース ドキュメントで利用可能なメタデータを反映します。Aspose.Slides はこの呼び出しのためにプレゼンテーション オブジェクト モデルをロードおよび走査してこれらの値を再計算しません。欠落しているプロパティはデフォルト値で表され、最後にファイルを保存したアプリケーションがドキュメント プロパティを更新していない場合、保存された値は古くなる可能性があります。

- **PPTX:** この形式は、スライド、ノート、非表示スライド、段落、単語、マルチメディアのカウント、およびヘッディング ペアとパート タイトルの拡張ドキュメントプロパティを提供します。利用可能性は、ドキュメント作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は、対応するドキュメント要約プロパティを保存できます。プロパティが存在しない、または作成者によって更新されていない場合、Aspose.Slides はスライドから計算するのではなく、保存されている値またはデフォルト値を返します。
- **ODP:** OpenDocument のメタデータは、ページ、段落、単語数などの一般的なドキュメント統計情報を提供しますが、これらの値はすべての PowerPoint 固有の拡張プロパティに対応しているわけではありません。非表示スライド、ノートスライド、マルチメディア、ヘッディング ペア、パート タイトルのメタデータが利用できない場合があり、インベントリ プロパティはデフォルト値を返すことがあります。ゼロ値や空配列を、該当コンテンツが存在しないことの権威ある証拠とみなさないでください。

インベントリや予備チェックには軽量メタデータ アプローチを使用してください。結果がメモリ内の変更を反映する必要がある場合や、実際のプレゼンテーション コンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブ オブジェクト モデルを検査してください。

## **プレゼンテーションプロパティの更新**

[IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/readdocumentproperties/) が返すプロパティは、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを作成せずに変更することもできます。変更は [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) で適用し、その後 [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/writebindedpresentation/) でバインドされたプレゼンテーションを書き出します。

以下の画像は元のドキュメント プロパティを示しています。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

以下の例はタイトルと最終保存時刻を変更し、結果を新しいファイルに書き出します。

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

以下の画像は更新されたドキュメント プロパティを示しています。

![PowerPoint プレゼンテーションの変更されたドキュメントプロパティ](output_properties.png)

## **便利なリンク**

関連するセキュリティチェックと保護設定については、次の記事をご参照ください。

- [プレゼンテーションのパスワード保護](/slides/ja/net/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/net/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認する方法は？**

プレゼンテーションをロードし、[Presentation.FontsManager](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/fontsmanager/) を使用します。[FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/getembeddedfonts/) で埋め込まれたフォントを取得し、[FontsManager.GetFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/getfonts/) でプレゼンテーションで使用されているフォントを取得します。両者を比較して、レンダリングに必要だが埋め込まれていないフォントを特定します。

**ファイルに非表示スライドがあるかどうか、そしてその数をすばやく確認する方法は？**

保存されたドキュメント メタデータが十分である場合、[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/getpresentationinfo/) と [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/readdocumentproperties/) を通じて [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/hiddenslides/) を読み取ります。これは軽量インベントリに適しています。メモリ上でプレゼンテーションが変更されている場合や、ライブ 値を確認する必要がある場合は、[Presentation.Slides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slides/ja/) を走査し、各スライドの [Slide.Hidden](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/hidden/) プロパティをチェックしてください。

**カスタム スライド サイズや向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation.SlideSize](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slidesize/) を読み取ります。[ISlideSize.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/islidesize/type/)、[ISlideSize.Size](https://reference.aspose.com/slides/ja/net/aspose.slides/islidesize/size/)、[ISlideSize.Orientation](https://reference.aspose.com/slides/ja/net/aspose.slides/islidesize/orientation/) を調べて、現在の設定が期待されるプリセットや寸法と一致しているか比較します。

**チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法は？**

はい。各 [Chart](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chart/) を特定し、[ChartData.DataSourceType](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/datasourcetype/) をチェックします。外部ブックの場合は、[ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/externalworkbookpath/) を読み取ります。データ ソース タイプとパスが外部参照を示しますが、対象の利用可能性は別途リソース チェックが必要です。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価する方法は？**

単一の複雑度プロパティはありません。[Presentation.Slides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slides/ja/) と各スライドの [IBaseSlide.Shapes](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/shapes/) コレクションを走査します。形状の数や大きな画像、エフェクト、アニメーション、マルチメディアの有無を指標として使用し、代表的なレンダリングまたはエクスポート時間を測定して、スライドを実際のパフォーマンス ボトルネックとして確認してください。