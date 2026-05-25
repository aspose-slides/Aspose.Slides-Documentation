---
title: .NET でプレゼンテーション スライドマスターを管理する
linktitle: スライドマスター
type: docs
weight: 80
url: /ja/net/slide-master/
keywords:
- スライドマスター
- マスタースライド
- PPT マスタースライド
- 複数のマスタースライド
- マスタースライドの比較
- 背景
- プレースホルダー
- マスタースライドのクローン
- マスタースライドのコピー
- マスタースライドの複製
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でスライドマスターを管理します：PowerPoint および OpenDocument プレゼンテーションのマスタースライドにアクセス、編集、クローン、比較、削除が可能です。"
---
## **概要**

**スライドマスター** は、スライドのグループに対して共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキストスタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスターを編集することが、各スライドで同じ書式を繰り返さずにプレゼンテーションの一貫性を保つ一般的な方法です。

Aspose.Slides for .NET は同じモデルをサポートします。プレゼンテーションは 1 つまたは複数のマスタースライドを含めることができ、各マスタースライドは複数のレイアウトスライドを保持できます。通常、ノーマルスライドはマスタースライドを直接参照しません。代わりに、ノーマルスライドはレイアウトスライドを使用し、そのレイアウトスライドがマスタースライドに属します。

階層構造は次のとおりです。

1. **スライドマスター** - 共有デザインとテーマを定義します。  
1. **レイアウトスライド** - プレースホルダーの配置とレイアウトレベルの書式設定を定義します。  
1. **ノーマルスライド** - 実際のプレゼンテーション コンテンツを保持し、1 つのレイアウトスライドを使用します。

![マスタースライド、レイアウトスライド、ノーマルスライドの階層構造](slide-master_2.jpg)

Aspose.Slides では、スライドマスターは [IMasterSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/) インターフェイスで表されます。プレゼンテーション内のすべてのマスタースライドは、[Presentation.Masters](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/masters/) コレクションから取得でき、これは [IMasterSlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/) を実装しています。

{{% alert color="info" title="Inheritance" %}}
同じプロパティが複数のレベルで定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方で背景が定義されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[レイアウトスライドの適用または変更](/slides/ja/net/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**表示** > **スライドマスター** からスライドマスタービューを開くことができます。

![PowerPoint の表示タブにあるスライドマスターコマンド](slide-master_3.jpg)

Aspose.Slides では、`Masters` コレクションを使用してマスタースライドにアクセスします:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

また、ノーマルスライドのレイアウトから使用されているマスタースライドを取得することもできます:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **スライドマスターに含まれるもの**

マスタースライドはスライドに類似したオブジェクトです。`IBaseSlide` を実装しているため、ノーマルスライドやレイアウトスライドと同様の多数のスライドプロパティにアクセスできます。マスター固有のメンバーは [IMasterSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/) API ページに記載されています。

一般的に使用されるマスタースライド メンバーは次のとおりです:

| メンバー | 目的 |
| --- | --- |
| `Background` | マスターレベルのスライド背景を設定します。 |
| `Shapes` | ロゴ、画像フレーム、共有テキストなど、マスター上に配置された図形を格納します。 |
| `LayoutSlides` | マスターに属するレイアウトスライドを格納します。 |
| `ThemeManager` | マスターのテーマ API へのアクセスを提供します。 |
| `HeaderFooterManager` | マスターとその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `GetDependingSlides` | レイアウトを介してマスターに依存しているノーマルスライドを返します。 |

## **スライドマスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドすべてに画像が表示されます。ロゴ、透かし、装飾帯、その他の繰り返し使用されるビジュアル要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します:

```csharp
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

画像フレームの詳細については、[画像フレーム](/slides/ja/net/picture-frame/) を参照してください。

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウトスライド上で定義されます。マスタースライドはそれらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーと配置場所を決定します。

PowerPoint では、スライドマスタービューでプレースホルダーコマンドが利用できます。

![PowerPoint スライドマスター表示でのプレースホルダー挿入コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウトスライドを操作します:

```csharp
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

既存のプレースホルダー形状の書式設定も可能です。以下の例はタイトルプレースホルダーを検索し、線形グラデーション塗りを適用します:

```csharp
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

![ノーマルスライドに継承された書式設定済みタイトルプレースホルダー](slide-master_8.png)

プレースホルダーやテキストの書式設定オプションの詳細については、[プレースホルダーにプロンプト テキストを設定](/slides/ja/net/manage-placeholder/) と [テキストの書式設定](/slides/ja/net/text-formatting/) を参照してください。

## **スライドマスターの背景を変更する**

マスターベースの背景は、レイアウトとその背景を上書きしないスライドに継承されます。次の例は、最初のマスタースライドに単色背景色を設定します:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

関連トピックについては、[プレゼンテーションの背景](/slides/ja/net/presentation-background/) と [プレゼンテーションのテーマ](/slides/ja/net/presentation-theme/) を参照してください。

## **スライドマスターを別のプレゼンテーションにクローンする**

[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/addclone/) を使用して、マスタースライドを別のプレゼンテーションにコピーできます。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

ノーマルスライドとそのマスターを一緒にクローンする必要がある場合は、[スライドのクローン](/slides/ja/net/clone-slides/) を参照してください。

## **複数のスライドマスターを追加する**

プレゼンテーションは複数のマスタースライドを含めることができます。これは、セクションごとに異なるブランディング、ページ構造、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入と管理のための PowerPoint コマンド](slide-master_9.jpg)

次の例はデフォルトのマスターをクローンし、クローンに別の背景を設定し、そのクローンマスターの下にレイアウトを作成し、最後にそのレイアウトに基づく新しいスライドを追加します:

```csharp
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

マスタースライドは、[IBaseSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/) が継承する `Equals` メソッドで比較できます。比較は構造と静的コンテンツ（図形、テキスト、書式設定、アニメーション、その他のスライド設定）をチェックします。スライド ID のような一意の識別子や、現在の日付などの動的プレースホルダー値は比較対象に含まれません。

```csharp
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

詳細については、[プレゼンテーションスライドの比較](/slides/ja/net/compare-slides/) を参照してください。

## **スライドマスター表示をデフォルトビューに設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/) の `LastView` プロパティを使用して、PowerPoint が最初に開くビューを制御できます。次の例はプレゼンテーションをスライドマスタービューで開きます:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

その他のビュー設定については、[プレゼンテーションの保存](/slides/ja/net/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはやノーマルスライドで使用されていないマスタースライドが含まれることがあります。未使用のマスターを削除すると、ファイルサイズが削減され、テンプレートの保守が簡素化されます。

`Masters` コレクションの [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/ja/net/aspose.slides/masterslidecollection/removeunused/) メソッドを使用して未使用のマスターを削除します:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

低コードの [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) メソッドも利用可能です:

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**スライドマスターとレイアウトスライドの違いは何ですか？**

スライドマスターはテーマ、背景、共通図形、テキストスタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの具体的な配置を定義します。ノーマルスライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から設定を継承します。

**1つのプレゼンテーションに複数のスライドマスターを含めることはできますか？**

はい。プレゼンテーションは複数のスライドマスターを含めることができます。セクションごとに異なるビジュアルシステムやブランディングが必要な場合は、複数のマスターを使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共通のビジュアル要素や書式設定はマスタースライドに配置し、実際のコンテンツ用プレースホルダーはノーマルスライドが使用するレイアウトに配置します。

**まだ使用されているマスタースライドを削除できますか？**

いいえ。依存スライドがあるマスタースライドは直接安全に削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、使用されていないマスターだけを削除するクリーンアップ手法を使用してください。