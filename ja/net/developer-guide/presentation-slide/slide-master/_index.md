---
title: ".NET でプレゼンテーション スライドマスターを管理"
linktitle: "スライドマスター"
type: docs
weight: 80
url: /ja/net/slide-master/
keywords:
- "スライドマスター"
- "マスタースライド"
- "PPT マスタースライド"
- "複数のマスタースライド"
- "マスタースライドの比較"
- "背景"
- "プレースホルダー"
- "マスタースライドのクローン"
- "マスタースライドのコピー"
- "マスタースライドの複製"
- "未使用のマスタースライド"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET でスライドマスターを管理します：PowerPoint および OpenDocument プレゼンテーションのマスタースライドにアクセス、編集、クローン、比較、削除が可能です。"
---
## **概要**

**スライドマスター**は、スライド グループに対する共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキスト スタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスターを編集することが、すべてのスライドで同じ書式を繰り返さずにプレゼンテーションの一貫性を保つ一般的な方法です。

Aspose.Slides for .NET でも同様のモデルをサポートしています。プレゼンテーションは 1 つ以上のマスタースライドを含むことができ、各マスタースライドは複数のレイアウトスライドを保持できます。通常のスライドはマスタースライドを直接参照しません。代わりに、通常のスライドはレイアウトスライドを使用し、そのレイアウトスライドがマスタースライドに属しています。

階層は次のとおりです。

1. **スライドマスター** – 共有デザインとテーマを定義します。  
1. **レイアウトスライド** – プレースホルダーの配置やレイアウトレベルの書式設定を定義します。  
1. **通常スライド** – 実際のプレゼンテーション コンテンツを保持し、1 つのレイアウトスライドを使用します。

![マスタースライド、レイアウトスライド、通常スライドの階層構造](slide-master_2.jpg)

Aspose.Slides では、スライドマスターは [IMasterSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/) インターフェイスで表されます。プレゼンテーション内のすべてのマスタースライドは、[Presentation.Masters](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/masters/) コレクションから取得でき、これは [IMasterSlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/) を実装しています。

{{% alert color="info" title="Inheritance" %}}
複数のレベルで同じプロパティが定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方が背景を定義している場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[Apply or Change Slide Layouts](/slides/ja/net/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**表示** > **スライドマスター** からスライドマスタービューを開くことができます。

![PowerPoint の「表示」タブにあるスライドマスター コマンド](slide-master_3.jpg)

Aspose.Slides では、`Masters` コレクションを使用してマスタースライドにアクセスします：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

通常のスライドが使用しているレイアウトから、マスタースライドを取得することもできます：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **スライドマスターに含まれるもの**

マスタースライドはスライドに似たオブジェクトです。`IBaseSlide` を実装しているため、通常のスライドやレイアウトスライドと同じ多くのスライド プロパティを公開します。マスター固有のメンバーは [IMasterSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/) API ページに記載されています。

一般的に使用されるマスタースライド メンバーは次のとおりです。

| メンバー | 用途 |
| --- | --- |
| `Background` | マスターレベルのスライド背景を設定します。 |
| `Shapes` | ロゴ、画像フレーム、共有テキストなど、マスター上に配置された図形を格納します。 |
| `LayoutSlides` | マスターに属するレイアウトスライドを格納します。 |
| `ThemeManager` | マスターのテーマ API へのアクセスを提供します。 |
| `HeaderFooterManager` | マスターとその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `GetDependingSlides` | レイアウトを介してマスターに依存している通常スライドを返します。 |

## **スライドマスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドすべてに画像が表示されます。ロゴ、透かし、装飾バンド、その他繰り返し表示したいビジュアル要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

画像フレームの詳細については、[Picture Frame](/slides/ja/net/picture-frame/) を参照してください。

## **マスター グラフィックの表示/非表示を制御する**

[IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/showmastershapes/) を使用して、ロゴや装飾形状などの継承されたマスター グラフィックを削除せずに非表示にできます。対象スライドで [Slide.ShowMasterShapes](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/showmastershapes/) を `false` に設定し、表示させたいスライドでは `true` のままにします。

次の自己完結型サンプルは、マスター上に青色の装飾バンドを作成し、同じ空白レイアウトを使用する 2 つのスライドを生成します。最初のスライドではバンドが表示され、2 番目のスライドでは非表示になります。入力プレゼンテーションや画像は不要です。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

このサンプルは新規プレゼンテーションに同梱されている **Blank** レイアウトを使用し、最初のスライドのプレースホルダーを削除しています。

### **設定の適用範囲を選択する**

通常のスライドは `[ISlide.LayoutSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/layoutslide/)` と `[ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/masterslide/)` を介してマスターにアクセスします。個々のスライドにプロパティを設定すると、そのスライドだけに影響します。`[LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutslide/showmastershapes/)` を `false` にすると、その共有レイアウトを使用するすべてのスライドでマスター グラフィックが非表示になります（各スライドの設定が `true` でも同様）。1 枚のスライドだけでグラフィックを非表示にしたい場合は、スライド プロパティを変更し、共有レイアウトはそのままにしてください。

マスタースライド自体ではこの設定は可視性制御としてサポートされていません。マスターでは常に `false` が返り、`true` を代入すると `NotSupportedException` がスローされます。代わりに通常スライドまたはレイアウトに適用してください。

### **グラフィックと背景を区別する**

| 操作 | 効果 |
| --- | --- |
| マスターボーダー（グラフィック）を非表示にする | 継承されたマスター図形を削除したりスライド独自の図形を変更したりせずに、表示/非表示を制御します。 |
| スライドの背景塗りを変更する | 背景色、グラデーション、画像を変更します。マスター グラフィックは別個の形状なので、背景の上に表示されたままです。詳細は [Presentation Background](/slides/ja/net/presentation-background/) を参照してください。 |
| マスターから図形を削除する | 共有元の図形が削除され、マスターを使用するすべてのスライドからその図形が利用できなくなります。 |

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウトスライド上で定義されます。マスタースライドは、レイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーとその配置を決定します。

PowerPoint では、スライドマスタービューでプレースホルダー コマンドが利用できます。

![PowerPoint のスライドマスタービューにある「プレースホルダーの挿入」コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウトスライドを操作します：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

既にマスタースライド上に存在するプレースホルダー図形の書式設定も可能です。次の例はタイトル プレースホルダーを検索し、線形グラデーション塗りを適用します：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![通常スライドが継承した書式設定済みタイトル プレースホルダー](slide-master_8.png)

プレースホルダーやテキスト書式設定の詳細オプションについては、[Set Prompt Text in Placeholder](/slides/ja/net/manage-placeholder/) と [Text Formatting](/slides/ja/net/text-formatting/) を参照してください。

## **スライドマスターの背景を変更する**

マスターベースの背景は、レイアウトやスライドが上書きしない限り継承されます。次の例は、最初のマスタースライドに単色の背景色を設定します：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

関連トピックは、[Presentation Background](/slides/ja/net/presentation-background/) と [Presentation Theme](/slides/ja/net/presentation-theme/) を参照してください。

## **スライドマスターを別のプレゼンテーションにクローンする**

[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/addclone/) を使用して、マスタースライドを別のプレゼンテーションにコピーできます。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

通常スライドとそのマスターをまとめてクローンしたい場合は、[Clone Slides](/slides/ja/net/clone-slides/) を参照してください。

## **複数のスライドマスターを追加する**

プレゼンテーションは複数のマスタースライドを保持できます。これは、異なるセクションで異なるブランディング、ページ構成、テーマ設定が必要な場合に便利です。

![PowerPoint のマスタースライド挿入および管理コマンド](slide-master_9.jpg)

次の例は、デフォルトマスターをクローンし、クローンに別の背景を設定し、そのクローンマスター配下にレイアウトを作成し、最後にそのレイアウトに基づく新規スライドを追加します：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **スライドマスターの比較**

マスタースライドは、[IBaseSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/) から継承された `Equals` メソッドで比較できます。比較は構造と静的コンテンツ（図形、テキスト、書式設定、アニメーション、その他スライド設定）を対象とします。スライド ID などの一意識別子や、現在の日付などの動的プレースホルダー値は比較対象に含まれません。

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

詳細は [Compare Presentation Slides](/slides/ja/net/compare-slides/) を参照してください。

## **スライドマスタービューをデフォルト表示に設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/) の `LastView` プロパティを使用して、PowerPoint が最初に開くビューを制御できます。次の例は、プレゼンテーションをスライドマスタービューで開きます：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

その他のビュー設定については、[Save Presentation](/slides/ja/net/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはや通常スライドで使用されていないマスタースライドが含まれていることがあります。未使用のマスターを削除すると、ファイル サイズが削減され、テンプレートの管理が簡素化されます。

[MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/ja/net/aspose.slides/masterslidecollection/removeunused/) を使用して、`Masters` コレクションから未使用マスターを削除します：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

低コード API の [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) メソッドも利用できます：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**スライドマスターとレイアウトスライドの違いは何ですか？**

スライドマスターはテーマ、背景、共通図形、テキスト スタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの具体的な配置を定義します。通常スライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライドマスターを含めることはできますか？**

はい。プレゼンテーションは複数のスライドマスターを保持できます。異なるセクションで異なるビジュアル体系やブランディングが必要な場合に、複数マスターを使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共有のビジュアル要素や共通書式はマスタースライドに置き、実際のコンテンツ用プレースホルダーは通常スライドが使用するレイアウトに配置します。

**使用中のマスタースライドを削除できますか？**

できません。依存スライドがあるマスタースライドは直接削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、未使用マスターのみを削除するクリーンアップ手順を使用してください。