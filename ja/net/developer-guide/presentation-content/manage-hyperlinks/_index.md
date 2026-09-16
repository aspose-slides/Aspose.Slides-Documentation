---
title: .NET でプレゼンテーションのハイパーリンクを管理する
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
- テキストハイパーリンク
- スライドハイパーリンク
- 図形ハイパーリンク
- 画像ハイパーリンク
- 動画ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用し、C# のサンプルで PowerPoint および OpenDocument のプレゼンテーションにハイパーリンクを追加、書式設定、更新、削除します。"
---
## **はじめに**

ハイパーリンクはプレゼンテーションのコンテンツを Web サイトやプレゼンテーション内の場所に接続します。PowerPoint ではハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、図形、またはメディア フレームから Web サイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for .NET を使用すると、これらのリンクを追加し、外観やサウンドを制御し、プロパティを更新し、削除できます。以下の例では、個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキスト フレーム レベルでハイパーリンクにアクセスする方法を示します。

{{% alert color="info" title="Note" %}}

You can also edit presentations with the [free online Aspose PowerPoint editor](https://products.aspose.app/slides/ja/editor).

{{% /alert %}} 

## **URL ハイパーリンクの追加**

テキスト、図形、またはメディア フレームに Web サイトの URL を割り当てることができます。ハイパーリンクを割り当てた要素がクリック可能領域を決定します。テキスト部分に割り当てると選択したテキストがリンクになり、図形やフレームに割り当てるとスライド オブジェクト全体がリンクになります。

### **テキストへの URL ハイパーリンクの追加**

テキストを Web サイトにリンクするには、以下のようにテキスト部分の [HyperlinkClick](https://reference.aspose.com/slides/ja/net/aspose.slides/portionformat/hyperlinkclick/) プロパティに [Hyperlink](https://reference.aspose.com/slides/ja/net/aspose.slides/hyperlink/) を割り当てます。クリック可能になるのはそのテキスト部分だけです。

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

図形またはフレームをクリック可能にするには、その [HyperlinkClick](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/hyperlinkclick/) プロパティを設定します。ハイパーリンクはテキスト部分ではなくオブジェクト自体に属します。

同じ手順は画像、音声、動画フレームにも適用できます。フレームにハイパーリンクを割り当て、必要に応じてリンクの [Tooltip](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/tooltip/) を設定してください。

以下の例は四角形をクリック可能にします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **ハイパーリンクで目次を作成する**

内部ハイパーリンクを使用すると、目次から特定のスライドへジャンプできます。次の例は [SetInternalHyperlinkClick](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) を使用して、1 枚目のスライドの “Page 2” テキストを 2 枚目のスライドにリンクしています。

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

### **色**

[IHyperlink](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/) の [ColorSource](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/colorsource/) プロパティは、ハイパーリンクがプレゼンテーション全体のハイパーリンク色を使用するか、テキスト部分の書式設定を使用するかを決定します。カスタム テキスト色を適用するには、[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入され、旧バージョンでは設定が適用されません。

以下の例は同じスライドに 2 つのテキスト ハイパーリンクを追加します。1 つ目は赤いテキスト塗りつぶし、2 つ目はデフォルトのハイパーリンク色を使用します。

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

ハイパーリンクは有効化時にサウンドを再生したり、既に再生中のサウンドを停止したりできます。以下のプロパティで動作を設定します。

- [IHyperlink.Sound](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/sound/) はハイパーリンクに関連付けるオーディオを指定します。
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/stopsoundonclick/) はハイパーリンクを有効化したときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンク サウンドの追加**

以下の例は `sampleaudio.wav` を読み込み、1 枚目のスライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライド上の別の図形はクリック時に前のサウンドを停止し、ナビゲーションは行いません。

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

以下の例は上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンク オーディオを [Sound](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/sound/) と [BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/iaudio/binarydata/) を通じてメモリに読み取ります。

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

テキストまたは図形にハイパーリンクを割り当てた後、次の [IHyperlink](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/) プロパティを更新できます。

- [Tooltip](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/tooltip/) はビューアがリンクのヒントとして表示できるテキストを設定します。
- [TargetFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/targetframe/) は HTML フレームセット内の対象フレームを指定します（該当する場合）。
- [History](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/history/) はリンクを有効化したときに閲覧履歴に目的地を追加するかを制御します。
- [HighlightClick](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/highlightclick/) はクリック時にハイパーリンクをハイライト表示するかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除する**

[GetAnyHyperlinks](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) を使用して、テキスト部分リンクを含むハイパーリンク コンテナを収集し、変更前に取得します。以下の例は 1 枚目のスライドから両方の有効化タイプ（クリックとマウスオーバー）を削除します。片方だけを削除したい場合は、[RemoveHyperlinkClick](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) または [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) のみを呼び出してください。クリック アクションを削除してもマウスオーバーは残ります。

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

条件なしで削除する場合は、[RemoveAllHyperlinks](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) が選択したスコープ内の両方の有効化タイプを一度に削除します。マスタ、レイアウト、ノートのクリーンアップとカバレッジについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **完全なハイパーリンク インベントリの作成**

プレゼンテーションを配布する前に、インタラクティブ アクションと Web リンクのインベントリを作成します。[GetAnyHyperlinks](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) はフラットな URL 文字列のリストではなく、[IHyperlinkContainer](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkcontainer/) オブジェクトを返します。各コンテナの [HyperlinkClick](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) と [HyperlinkMouseOver](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) の両方を調べます。これらは独立しており、同じコンテナが両方のアクションを持つことがあるため、完全なレポートではコンテナごとに最大 2 行が必要です。

形状レベルのハイパーリンクだけをスキャンすると、テキスト部分に付随したリンクを見逃す可能性があります。適切なスコープでクエリを実行し、返されたコンテナを保持して後で更新または削除できるようにしてください。

### **プレゼンテーション、スライド、テキスト フレーム スコープのクエリ**

[IHyperlinkQueries](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/) インターフェイスは [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/hyperlinkqueries/)、[IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/hyperlinkqueries/)、[ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/hyperlinkqueries/) から利用できます。各スコープは同じクエリをサポートします。

- [GetHyperlinkClicks](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) はクリック アクションを持つコンテナを返します。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) はマウスオーバー アクションを持つコンテナを返します。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) はいずれか、または両方のアクションを持つコンテナを返します。

以下の例は外部クリックリンク、ファイルマウスオーバーリンク、内部スライド ナビゲーション、テキストマウスオーバーリンク、マクロ アクションを含む `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。同じ 3 つのクエリはすべてのスコープで機能し、カウントはコンテナ数を示します。テキスト フレーム スコープは囲む図形のリンクを除外します。

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

この例では、プレゼンテーションとスライドのクエリはそれぞれクリック コンテナが 3 件、マウスオーバー コンテナが 2 件、いずれかのアクションを持つコンテナが 3 件と報告します。テキスト フレームのクエリは各カテゴリで 1 件を報告します。

### **アクションと宛先の分類**

[IHyperlink.ActionType](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/actiontype/) を使用して、宛先を解釈する前にアクションの種類を判断します。[HyperlinkActionType](https://reference.aspose.com/slides/ja/net/aspose.slides/hyperlinkactiontype/) の値は Web ナビゲーション以外にも次のようなものがあります。

| 値 | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク；URL とスキームを確認します。 |
| `JumpSpecificSlide` | 特定スライドへの内部ナビゲーション。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | スライドショー内の組み込みナビゲーション。 |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了、またはカスタムショーを開始。 |
| `StartMacro` | マクロを実行。 |
| `StartProgram` | プログラムを起動。 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別のプレゼンテーションを開く；Web URL とは別に確認します。 |
| `StartStopMedia` | メディアの再生または停止。 |
| `NoAction`, `Unknown` | ナビゲーション アクションがない、または認識できないアクションでレビューが必要。 |

外部宛先は [ExternalUrl](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/externalurl/) から取得し、特定の内部宛先は [TargetSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/targetslide/) から取得します。内部アクションや組み込みコマンドは外部 URL が無い場合があります。空の URL があるからといってコンテナにアクションが無いわけではありません。[ExternalUrlOriginal](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/externalurloriginal/) が正規化された URL と異なる場合は保存し、利用可能な場合は [Tooltip](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/tooltip/) も含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

以下の .NET 6+ の例は既存のプレゼンテーション（上記で作成したファイル）を読み込み、`hyperlink-audit.json` を出力し、ポリシーを適用して `hyperlink-sanitized.pptx` を保存し、再度開いて両方の有効化タイプをチェックします。変更前にコンテナを収集し、同一コンテナの二重処理を回避するために参照等価性を使用します。プレゼンテーション クエリは通常のスライドを対象とし、パッケージ全体のインベントリを取得するためにマスタ、レイアウト、ノート、ノート＆ハンドアウト マスタも明示的にクエリします。

レポートは 1 基数のスライドインデックスと利用可能な場合は [SlideId](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/slideid/) を記録します。[ISlideComponent.Slide](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecomponent/slide/) はサポート対象コンテナの所有スライドを提供します。マスタ、レイアウト、ノートは通常のスライドインデックスを持たず、スコープで識別されます。形状コンテナとテキスト部分フォーマット コンテナは別々にラベル付けされ、他のコンテナ種別は実行時の型名を保持します。各コンテナにはレポート内でローカル ID が付与され、2 つのアクションを関連付けられます。

この制限的な適用ポリシーは、絶対 HTTPS URL と有効な内部スライド ターゲットのみを許可します。マクロ、プログラム、ファイル アクション、その他のスライドショー アクション、未知のアクション、その他の URL スキームは拒否されます。これは Aspose.Slides の安全性判定ではなく、ポリシー上の決定です。HTTPS だけでは信頼が確立されないため、ホスト許可リストやその他のチェックを追加してください。元の URL と正規化された外部 URL の両方がチェック対象です。例はリンクをたどったりアクションを実行したりせず、メタデータのみを監査します。

修正のために、コンテナの [HyperlinkManager](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) は [SetExternalHyperlinkClick](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)、[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) をサポートします。ここでは、禁止された外部クリックリンクを固定の HTTPS ランディング ページに置き換え、他の禁止クリックと禁止マウスオーバー アクションは個別に削除します。`replaceExternalClicks` を `false` に設定すると、すべてのポリシー違反が削除されます。展開前にアプリケーション所有の置換ページを選択してください。

レポートのエクスポート フラグは保守的な PDF レビュー ポリシーを使用します。マウスオーバー アクションや外部リンク以外、特定スライド ジャンプ以外のすべてを潜在的に未サポートとしてフラグ付けします。これはレビュー用のヒントであり、機能テストやフラグが付いていないリンクがエクスポートで必ず保持される保証ではありません。サポートされる [PDF](/slides/ja/net/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/net/convert-powerpoint-to-html/) エクスポートはアクション、エクスポートオプション、ビューアに依存してハイパーリンクを保持できる場合があります。ラスタ画像 [images](/slides/ja/net/convert-powerpoint-to-png/) と [video](/slides/ja/net/convert-powerpoint-to-video/) はインタラクティブ ハイパーリンクを保持できないため、これらの出力を監査する際はすべてのアクションにフラグを付けてください。

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

上記の入力で作成したレポートは 5 行のアクションを含みます。ファイルマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライド ナビゲーションは残ります。検証は禁止アクションが 0 件であることを出力します。禁止された外部クリック URL を含む入力は置換ブランチもテストします。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリック アクションを保持します。

この選択的クリーンアップは、ポリシーに関係なく選択スコープ全体の両方の有効化タイプを削除する [RemoveAllHyperlinks](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) とは異なります。ここでの検証はハイパーリンク アクションのみをチェックし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツの削除や、エクスポートされた PDF や HTML ファイルの検証は行いません。

## **FAQ**

**セクションまたはその最初のスライドにリンクするにはどうすればよいですか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクしてください。

**マスタ スライド要素にハイパーリンクを付けてすべてのスライドで機能させることはできますか？**

はい。マスタ スライドやレイアウト要素はハイパーリンクをサポートします。これらの要素上のリンクは、対応するマスタまたはレイアウトを使用しているスライドのスライドショー中に利用可能です。

**ハイパーリンクは PDF、HTML、画像、ビデオへのエクスポート時に保持されますか？**

サポートされる PDF および HTML エクスポートはハイパーリンクを保持できる場合がありますが、ラスタ画像やビデオはインタラクティブ ハイパーリンクを保持できません。詳細は [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) のエクスポートに関する考慮事項を参照してください。