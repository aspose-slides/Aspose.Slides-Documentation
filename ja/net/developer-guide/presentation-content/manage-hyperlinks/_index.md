---
title: .NET でプレゼンテーション ハイパーリンクを管理
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/net/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクを書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキスト ハイパーリンク
- スライド ハイパーリンク
- 図形 ハイパーリンク
- 画像 ハイパーリンク
- 動画 ハイパーリンク
- 変更可能なハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用し、C# のサンプルで、PowerPoint と OpenDocument のプレゼンテーションにおけるハイパーリンクの追加、書式設定、更新、削除を行います。"
---
## **導入**

ハイパーリンクはプレゼンテーションのコンテンツを Web サイトまたはプレゼンテーション内の場所に結び付けます。PowerPoint では、ハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、図形、またはメディア フレームから Web サイトを開く。
* 例えば目次から別のスライドへ移動する。

Aspose.Slides for .NET を使用すると、これらのリンクを追加したり、外観やサウンドを制御したり、プロパティを更新したり、削除したりできます。以下の例では、個々の要素でハイパーリンクを操作する方法と、プレゼンテーション、スライド、テキスト フレームレベルでハイパーリンクにアクセスする方法を示します。

{{% alert color="info" title="Note" %}}
プレゼンテーションは、[無料のオンライン Aspose PowerPoint エディター](https://products.aspose.app/slides/editor)でも編集できます。
{{% /alert %}} 

## **URL ハイパーリンクの追加**

Web サイトの URL をテキスト、図形、またはメディア フレームに割り当てることができます。ハイパーリンクを割り当てる要素がクリック可能領域を決定します。テキストの一部にハイパーリンクを設定すると選択したテキストがリンクされ、図形やフレームに設定するとスライドオブジェクト全体がリンクになります。

相対ハイパーリンクを含むプレゼンテーションについては、[ハイパーリンク ベースの管理](/slides/ja/net/presentation-properties/#manage-the-hyperlink-base)を参照し、ドキュメントレベルのベースを読み取り、変更、またはクリアしてください。

### **テキストへの URL ハイパーリンクの追加**

テキストを Web サイトにリンクするには、以下のようにテキスト部分の [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) プロパティに [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) を割り当てます。該当のテキスト部分だけがクリック可能になります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **図形とメディア フレームへの URL ハイパーリンクの追加**

図形やフレームをクリック可能にするには、その [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) プロパティを設定します。ハイパーリンクはテキスト部分ではなく、オブジェクト自体に属します。

画像、音声、動画フレームにも同様に適用できます。フレームにハイパーリンクを割り当て、必要に応じてリンクの [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) を設定してください。

以下の例は四角形をクリック可能にします：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **ハイパーリンクを使用した目次の作成**

内部ハイパーリンクを使用すると、目次から特定のスライドへジャンプできます。以下の例では、[SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) を使用して、1枚目のスライド上の「Page 2」テキストを2枚目のスライドにリンクしています。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **ハイパーリンクの書式設定**

### **カラー**

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) の [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) プロパティは、ハイパーリンクがプレゼンテーションのハイパーリンクカラーを使用するか、テキスト部分の書式設定を使用するかを決定します。カスタムのテキストカラーを適用するには、[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶしカラーを設定します。この機能は PowerPoint 2019 で導入され、古いバージョンではこの設定は適用されません。

以下の例は同じスライドに 2 つのテキストハイパーリンクを追加します。1 つ目は赤いテキスト塗りつぶしを使用し、2 つ目はデフォルトのハイパーリンクカラーを保持します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **サウンド**

ハイパーリンクはアクティブ化されたときにサウンドを再生したり、既に再生中のサウンドを停止したりできます。これらの動作を設定するには、以下のプロパティを使用します。

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) はハイパーリンクに関連付けられたオーディオを指定します。
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) はハイパーリンクのアクティブ化時に前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンク サウンドの追加**

以下の例は `sampleaudio.wav` を読み込み、1枚目のスライド上のボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライド上の別の図形はクリック時に前のサウンドを停止し、ナビゲーションは行いません。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **ハイパーリンク サウンドの抽出**

以下の例は上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンクオーディオを [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) と [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) を使用してメモリに読み込みます。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **ツールチップとインタラクション設定**

テキストまたは図形にハイパーリンクを割り当てた後、以下の [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) プロパティを更新できます。

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) は、リンクのヒントとして表示できるテキストを設定します。
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) は、該当する場合に親 HTML フレームセット内のターゲットフレームを指定します。
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) は、リンクをアクティブ化した際にその行き先を閲覧済みハイパーリンクのリストに追加するかを制御します。
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) は、クリック時にハイパーリンクをハイライト表示するかを制御します。

## **プレゼンテーションからハイパーリンクを削除**

[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) を使用して、変更前にテキスト部分リンクを含むハイパーリンク コンテナを収集します。以下の例は最初のスライドから両方のアクティベーション タイプを削除します。1 つだけ削除したい場合は、[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) または [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) のみを呼び出してください。クリック アクションを削除してもマウスオーバー側は削除されません。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

無条件に削除するには、[RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) が選択したスコープ内の両方のアクティベーション タイプを一度に削除します。マスター、レイアウト、ノートを対象とした選択的なクリーンアップについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **ハイパーリンクの完全なインベントリを構築**

プレゼンテーションを配布する前に、インタラクティブなアクションと Web リンクのインベントリを作成してください。[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) は URL 文字列の単純なリストではなく、[IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) オブジェクトを返します。各コンテナで [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) と [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) の両方を確認します。これらは独立しており、同じコンテナが両方のアクションを持つことがあるため、完全なレポートではコンテナごとに最大 2 行が必要です。

形状レベルのハイパーリンクだけをスキャンすると、テキスト部分に付随したリンクが見逃されることがあります。代わりに適切なスコープをクエリし、返されたコンテナを保持して後でアクションの更新または削除ができるようにします。

### **プレゼンテーション、スライド、テキスト フレーム スコープのクエリ**

[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) インターフェイスは、[IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/)、[IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/)、[ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) で利用できます。各スコープは同じクエリをサポートします：

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) はクリック アクションを持つコンテナを返します。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) はマウスオーバー アクションを持つコンテナを返します。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) はいずれか、または両方のアクションを持つコンテナを返します。

以下の例は、外部クリックリンク、ファイルマウスオーバーリンク、内部スライド ナビゲーション、テキストマウスオーバーリンク、マクロ アクションを含む `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。同じ 3 つのクエリはすべてのスコープで機能し、カウントはアクション総数ではなくコンテナ数を示します。テキスト フレーム スコープは、囲む形状自身のリンクを除外します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

この例では、プレゼンテーションとスライドのクエリはそれぞれ 3 つのクリック コンテナ、2 つのマウスオーバー コンテナ、いずれかのアクションを持つ 3 つのコンテナを報告します。テキスト フレームのクエリは各カテゴリで 1 つのコンテナを報告します。

### **アクションと行き先の分類**

[IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) を使用して、行き先を判断する前にアクションの種類を解釈します。[HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) の値は Web ナビゲーション以外もカバーします：

| 値 | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク。URL とスキームを確認する。 |
| `JumpSpecificSlide` | 特定のスライドへの内部ナビゲーション。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | スライドショー コンテキストで解決される組み込みのスライドショー ナビゲーション。 |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了するか、カスタムショーを開始する。 |
| `StartMacro` | マクロを実行する。 |
| `StartProgram` | プログラムを起動する。 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別のプレゼンテーションを開く。Web URL とは別に確認する。 |
| `StartStopMedia` | メディアの再生を開始または停止する。 |
| `NoAction`, `Unknown` | ナビゲーション アクションがない、または未確認のアクションでレビューが必要。 |

外部行き先は [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) から、特定の内部行き先は [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/) から取得します。内部アクションや組み込みコマンドは外部 URL を持たないことがありますが、URL が空でもコンテナにアクションがないという意味ではありません。正規化された URL と異なる場合は [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) を保持し、利用可能な場合は [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) を含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

以下の .NET 6+ の例は、既存のプレゼンテーションを読み込み（上記で作成したファイルを使用）、`hyperlink-audit.json` に書き出し、ポリシーを適用し、`hyperlink-sanitized.pptx` として保存し、再度開いて両方のアクティベーション タイプをチェックします。変更前にコンテナを収集し、参照等価性を使用して同じコンテナが二度処理されるのを防ぎます。プレゼンテーションのクエリは通常のスライドを対象とし、パッケージ全体のインベントリの場合は、マスター、レイアウト、ノート、および存在する場合はノートと配布資料のマスターも明示的にクエリします。

レポートは、利用可能な場合に 1 から始まるスライドインデックスと [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) を記録します。[ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) はサポート対象コンテナの所有スライドを提供します。マスター、レイアウト、ノートは通常のスライドインデックスを持たず、スコープで識別されます。形状コンテナとテキスト部分書式コンテナは別々にラベル付けされ、他のコンテナタイプは実行時の型名を保持します。各コンテナにはレポート内でのローカル ID が付与され、2 つのアクションを相関させることができます。

この意図的に制限的なアプリケーション ポリシーは、絶対パスの HTTPS URL と有効な内部スライド ターゲットのみを許可します。マクロ、プログラム、ファイル アクション、その他のスライドショー アクション、未知のアクション、その他の URL スキームは拒否されます。これらの拒否はポリシー上の判断であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼性は確立できないため、ホスト許可リストやその他のチェックをアプリに追加してください。元の URL と正規化された外部 URL の両方がチェックされます。この例はリンクをたどったりアクションを実行したりせずにメタデータを監査します。

是正のために、コンテナの [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) は [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)、[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) をサポートします。この例では、禁止された外部クリックリンクは固定の HTTPS ランディングページに置き換えられ、他の禁止クリックおよび禁止マウスオーバー アクションは個別に削除されます。すべてのポリシー違反を削除したい場合は、`replaceExternalClicks` を `false` に設定してください。デプロイ前にアプリケーション所有の置換ページを選択してください。

レポートのエクスポートフラグは、保守的な PDF レビュー ポリシーを使用します。マウスオーバー アクションや外部リンクや特定スライドジャンプ以外のすべてを、潜在的にサポートされていないものとしてフラグ付けします。これはレビューのヒントであり、機能テストやフラグが付いていないリンクがエクスポートで保持される保証ではありません。サポートされている [PDF](/slides/ja/net/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/net/convert-powerpoint-to-html/) のエクスポートは、アクションやエクスポートオプション、ビューアに応じてハイパーリンクを保持できる場合があります。ラスタ画像 [images](/slides/ja/net/convert-powerpoint-to-png/) と [video](/slides/ja/net/convert-powerpoint-to-video/) はインタラクティブなハイパーリンクを保持できないため、これらの出力を監査する際はすべてのアクションにフラグを付けてください。

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

上記で作成した入力に対し、レポートには 5 行のアクションが含まれます。ファイルのマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライド ナビゲーションは残ります。検証では禁止アクションが 0 件と表示されます。禁止された外部クリック URL を含む入力は置換ブランチも実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリックアクションを保持します。

この選択的クリーンアップは、ポリシーに関係なく選択されたスコープ内の両方のアクティベーション タイプを削除する [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) とは異なります。ここでの検証はハイパーリンク アクションのみをチェックし、埋め込まれた VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツは削除せず、エクスポートされた PDF や HTML ファイルの検証も行いません。

## **FAQ**

**セクションまたはその最初のスライドへリンクするには？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象とします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクしてください。

**マスタースライド要素にハイパーリンクを付けて、すべてのスライドで機能させることはできますか？**

はい。マスタースライドおよびレイアウト要素はハイパーリンクをサポートします。これらの要素に付けたリンクは、対応するマスターまたはレイアウトを使用するスライドショー中に利用可能です。

**PDF、HTML、画像、または動画にエクスポートした場合、ハイパーリンクは保持されますか？**

サポートされている PDF および HTML エクスポートはハイパーリンクを保持できる可能性がありますが、ラスタ画像や動画は保持できません。エクスポートに関する考慮事項は、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。