---
title: .NET でプレゼンテーション ハイパーリンクを管理
linktitle: ハイパーリンクを管理
type: docs
weight: 20
url: /ja/net/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
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
description: "Aspose.Slides for .NET を使用し、C# の例で PowerPoint と OpenDocument のプレゼンテーションにおけるハイパーリンクの追加、書式設定、更新、削除を行います。"
---
## **はじめに**

ハイパーリンクは、プレゼンテーションのコンテンツと Web サイト、またはプレゼンテーション内の位置を結び付けます。PowerPoint では、ハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、図形、またはメディア フレームから Web サイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for .NET を使用すると、これらのリンクを追加し、外観やサウンドを制御し、プロパティを更新、削除できます。以下のサンプルは、個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキスト フレームレベルでハイパーリンクにアクセスする方法を示しています。

{{% alert color="info" title="Note" %}}
[無料のオンライン Aspose PowerPoint エディター](https://products.aspose.app/slides/editor)でもプレゼンテーションを編集できます。
{{% /alert %}}

## **URL ハイパーリンクの追加**

テキスト、図形、またはメディア フレームに Web サイトの URL を割り当てることができます。ハイパーリンクを割り当てた要素がクリック領域を決定します。テキスト部分に割り当てた場合は選択したテキストが、図形やフレームに割り当てた場合はスライド オブジェクト全体がクリック可能になります。

相対ハイパーリンクを含むプレゼンテーションについては、[ハイパーリンク ベースの管理](/slides/ja/net/presentation-properties/#manage-the-hyperlink-base) を参照して、ドキュメントレベルのベースを読み取り、変更、またはクリアしてください。

### **テキストへの URL ハイパーリンクの追加**

テキストを Web サイトにリンクするには、以下のようにテキスト部分の [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) プロパティに [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) を割り当てます。該当部分だけがクリック可能になります。

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

### **図形およびメディア フレームへの URL ハイパーリンクの追加**

矩形の [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) プロパティに URL を割り当てると、矩形全体がクリック可能になります。[Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) は、ユーザーが矩形上にカーソルを合わせたときにリンク先のヒントを表示します。同様のプロパティは画像、音声、動画フレームにも適用できます。

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

内部ハイパーリンクを使用すると、目次から特定のスライドへジャンプできます。次の例は、[SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) を使用して、1 枚目のスライドの「Page 2」テキストを 2 枚目のスライドにリンクしています。

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

リンクされたテキストの色を変更したり、リンクが有効化されたときにサウンドを再生／停止したり、ホバー時に表示されるツールチップを設定したりできます。

### **色**

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) の [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) プロパティは、ハイパーリンクがプレゼンテーション全体のハイパーリンク色を使用するか、テキスト部分の書式設定を使用するかを決定します。カスタム テキスト色を適用するには、[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入され、以前のバージョンでは適用されません。

この例では、最初のリンクの [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) を設定するとテキストが赤く表示されます。2 番目のリンクはプレゼンテーションのハイパーリンク色のままです。

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

ハイパーリンクは、有効化されたときにサウンドを再生したり、既に再生中のサウンドを停止したりできます。以下のプロパティで動作を構成します。

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) はハイパーリンクに関連付けられた音声を指定します。
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) は、ハイパーリンクがクリックされたときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンク サウンドの追加**

1 枚目のスライドのボタンは、[Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) を使用して、読者が次へ進むクリック時に WAV ファイルから音声を再生します。2 枚目のスライドでは、別のボタンが [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) を使用して再生を停止し、読者をそのスライドにとどめます。

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

以下の例は、上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンク音声を [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) と [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) を介してメモリに読み取ります。

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

テキストまたは図形にハイパーリンクを割り当てた後で、次の [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) プロパティを更新できます。

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) は、リンクのヒントとして表示できるテキストを設定します。
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) は、該当する場合に親 HTML フレームセット内のターゲット フレームを指定します。
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) は、リンクを有効化したときに対象が閲覧済みハイパーリンク一覧に追加されるかどうかを制御します。
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) は、クリック時にハイパーリンクがハイライトされるかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除する**

変更前にテキスト部分リンクを含むハイパーリンク コンテナを収集するには、[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) を使用します。次の例は、1 枚目のスライドから両方の有効化タイプを削除します。片方だけを削除したい場合は、[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) または [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) のみを呼び出します。クリック アクションを削除してもマウスオーバー側は残ります。

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

条件なしで削除する場合、[RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) は選択されたスコープ内の両方の有効化タイプを一度の呼び出しで削除します。マスター、レイアウト、ノートを対象にした選択的クリーンアップについては、[ハイパーリンクのレポート、サニタイズ、検証](#report-sanitize-and-verify-hyperlinks) を参照してください。

### **SmartArt テキスト置換前にハイパーリンクをクリアする**

既存の SmartArt ノードの段落を置換する際に、テキスト部分をクリアすると古いハイパーリンクが残ることがあります。段落は [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/) から取得します。部分をクリアする前に、ノード形状のテキスト フレーム上の [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) を通じて [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) を呼び出します。これにより、そのフレーム内のすべてのハイパーリンク（他の段落にあるものも含む）が削除されます。

この例では、1 枚目のスライドの 3 番目の図形が SmartArt グラフィックであると想定し、4 番目のノードの最初の段落を置換します。このプレゼンテーションでは、ノードの最初の形状がその段落を表示しています。

両方の部分を追加した後、例は [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) を使用して有効書式を取得します。有効な [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) プロパティは最初の部分に新しいハイパーリンクを返し、2 番目には `null` を返します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **完全なハイパーリンク インベントリの作成**

プレゼンテーションを配布する前に、インタラクティブなアクションと Web リンクのインベントリを作成します。[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) は URL 文字列の平坦なリストではなく、[IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) オブジェクトを返します。各コンテナの [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) と [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) の両方を調べます。これらは独立しており、同じコンテナが両方のアクションを持つことがあるため、完全なレポートにはコンテナごとに最大 2 行が必要です。

形状レベルのハイパーリンクだけをスキャンすると、テキスト部分に付随したリンクを見逃す可能性があります。適切なスコープでクエリを実行し、返されたコンテナを保持して後で更新または削除できるようにしてください。

### **プレゼンテーション、スライド、テキスト フレーム スコープのクエリ**

[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) インターフェイスは、[IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/)、[IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) および [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) から利用できます。各スコープは同じクエリをサポートします。

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) はクリック アクションを持つコンテナを返します。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) はマウスオーバー アクションを持つコンテナを返します。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) はいずれか、または両方のアクションを持つコンテナを返します。

この例は、図形とそのテキストにクリックとマウスオーバー アクションを割り当て、別のボタンにマクロ アクションを割り当てます。[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) が返すコンテナ数を各有効化タイプのカウントと比較します。テキスト フレーム クエリはテキスト内のリンクのみをカウントし、囲む図形の独自アクションはスライドおよびプレゼンテーションのクエリに現れます。

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

この例では、プレゼンテーションとスライドのクエリはそれぞれクリック コンテナが 3 件、マウスオーバー コンテナが 2 件、いずれかのアクションを持つコンテナが 3 件と報告します。テキスト フレーム クエリは各カテゴリで 1 件ずつ報告します。

### **アクションと宛先の分類**

[IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) を使用して、宛先を解釈する前にアクションの種類を判断します。[HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) の値は Web ナビゲーション以外にも広範です。

| Values | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク。URL とスキームを確認してください。 |
| `JumpSpecificSlide` | 特定のスライドへの内部ナビゲーション。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | スライドショー用組み込みナビゲーション。スライドショー コンテキストで解決されます。 |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了、またはカスタムショーを開始。 |
| `StartMacro` | マクロを実行。 |
| `StartProgram` | プログラムを起動。 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別のプレゼンテーションを開く。Web URL とは別にレビューしてください。 |
| `StartStopMedia` | メディアの再生/停止。 |
| `NoAction`, `Unknown` | ナビゲーション アクションがない、または認識できないアクション。レビューが必要です。 |

外部宛先は [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) から取得し、内部の特定スライドは [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/) から取得します。内部アクションや組み込みコマンドには外部 URL が存在しない場合があります。空の URL がアクションが無いことを意味するわけではありません。正規化された URL と異なる場合は [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) を保持し、利用可能な場合は [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) も含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

この .NET 6+ の例は、前述の例で作成したプレゼンテーションを開き、アクションごとに 1 件の JSON レコードを書き出します。[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) を使用して、通常スライド、マスター、レイアウト、ノート、そして存在する場合はノート および ハンドアウト マスターのコンテナを収集します。参照等価を用いて各コンテナを 1 回だけカウントし、以下に示すポリシーを適用した後、保存したプレゼンテーションを再度開いてクリックとマウスオーバーの両方のアクションを検証します。

レポートは 1 ベースのスライドインデックスと、利用可能な場合は [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) を記録します。[ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) はサポート対象コンテナの所有スライドを提供します。マスター、レイアウト、ノートは通常スライドインデックスを持たず、スコープで識別されます。図形コンテナとテキスト部分書式コンテナは別々にラベル付けされ、その他のコンテナは実行時の型名を保持します。各コンテナにはレポート内部での ID が付与され、2 つのアクションを相関付けられます。

このポリシーは、絶対 HTTPS URL と有効な内部スライド ターゲットのみを許可し、マクロ、プログラム、ファイル操作、その他のスライドショー アクション、未知のアクション、その他の URL スキームは拒否します。これは Aspose.Slides の安全性判定ではなく、ポリシー上の決定です。HTTPS だけでは信頼を保証できないため、ホスト許可リストや追加チェックを実装してください。元の URL と正規化された外部 URL の両方がチェック対象です。例はリンクをたどったりアクションを実行したりせず、メタデータのみを監査します。

修正時には、コンテナの [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) が [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)、[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) をサポートします。ここでは、禁止された外部クリックリンクを固定の HTTPS ランディング ページに置き換え、他の禁止クリックと禁止マウスオーバーは個別に削除します。`replaceExternalClicks` を `false` に設定すると、すべてのポリシー違反を削除します。導入前にアプリケーション所有の置換ページを決定してください。

レポートのエクスポートフラグは保守的な PDF レビュー ポリシーを使用します。マウスオーバー アクションや外部リンク以外、特定スライドジャンプ以外のアクションは「サポート外の可能性あり」とフラグ付けされます。これはレビューのヒントであり、機能テストやフラグが付いていないリンクがエクスポートで必ず残ることを保証するものではありません。サポート対象の [PDF](/slides/ja/net/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/net/convert-powerpoint-to-html/) エクスポートはアクションやオプション、ビューアに応じてハイパーリンクを保持できる場合があります。ラスター画像 [images](/slides/ja/net/convert-powerpoint-to-png/) や [video](/slides/ja/net/convert-powerpoint-to-video/) はインタラクティブ ハイパーリンクを保持できないため、これらの出力を監査する際はすべてのアクションにフラグを付けてください。

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

上記の入力を使用すると、レポートには 5 行のアクションが含まれます。ファイルのマウスオーバー リンクとマクロクリックは削除され、HTTPS リンクと内部スライド ナビゲーションは残ります。検証は禁止アクションが 0 件であることを出力します。禁止された外部クリック URL を含む入力は、置換ブランチも実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナは、クリック アクションを保持します。

この選択的クリーンアップは、スコープ全体で両方の有効化タイプを削除する [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) とは異なります。ここでの検証はハイパーリンク アクションのみをチェックし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツの削除や、エクスポートされた PDF/HTML ファイルの検証は行いません。

## **FAQ**

**セクションまたはその最初のスライドにリンクするにはどうすればよいですか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクしてください。

**マスター スライドの要素にハイパーリンクを付ければ、すべてのスライドで機能しますか？**

はい。マスター スライドやレイアウトの要素はハイパーリンクをサポートします。これらの要素に付けたリンクは、対応するマスターまたはレイアウトを使用しているスライドのスライドショー中に利用可能です。

**PDF、HTML、画像、または動画へのエクスポート時にハイパーリンクは保持されますか？**

サポート対象の PDF と HTML エクスポートはハイパーリンクを保持できる場合がありますが、ラスター画像や動画はインタラクティブ ハイパーリンクを保持できません。詳細は [ハイパーリンクのレポート、サニタイズ、検証](#report-sanitize-and-verify-hyperlinks) のエクスポート考慮事項をご参照ください。