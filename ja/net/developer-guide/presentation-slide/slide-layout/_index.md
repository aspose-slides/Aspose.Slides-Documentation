---
title: .NET でスライドレイアウトを適用または変更
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/net/slide-layout/
keywords:
- スライドレイアウト
- コンテンツレイアウト
- プレースホルダー
- プレゼンテーションデザイン
- スライドデザイン
- 未使用レイアウト
- フッター表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2 コンテンツ
- 比較
- タイトルのみ
- 空白レイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦テキスト
- 縦タイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET でスライドレイアウトを適用、作成、変更し、プレースホルダーを追加、未使用レイアウトを削除、フッター表示を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用することで、スライドは一貫した構造を持ちつつ、各スライドが独自のコンテンツを含むことができます。

最も一般的なレイアウトは以下です：

- **Title Slide**: タイトルとサブタイトルのプレースホルダーが含まれます。
- **Title and Content**: タイトルのプレースホルダーと汎用コンテンツプレースホルダーが含まれます。
- **Blank**: コンテンツプレースホルダーがなく、すべての図形を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには、以下の3つの関連レベルがあります：

1. A [マスタスライド](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/) はテーマ、共有書式、背景、共通オブジェクトを定義します。
2. A [レイアウトスライド](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/) はマスタに属し、特定のプレースホルダー配置を定義します。
3. A [ノーマルスライド](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/) は1つのレイアウトを使用し、そのスライドに入力されたコンテンツを保存します。

ノーマルスライドはレイアウトからテーマと書式を継承し、レイアウトはマスタから継承します。ノーマルスライドに直接設定された値は、そのレベルで継承された値を上書きします。ノーマルスライドが作成されると、プレースホルダー形状は選択されたレイアウトから生成され、プレースホルダーに入力されたコンテンツはノーマルスライドに属します。

スライドを作成する前に、レイアウトに必要なプレースホルダーを追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存のノーマルスライドに自動的に対応するプレースホルダー形状が追加されることはありません。

この関係には2つの重要な結果があります：

- レイアウト上の継承された書式や既存プレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新される可能性があります。既に使用中のレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- スライドで使用中のレイアウトは削除できません。まずその依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトのみを削除してください。

この階層の最上位に関する詳細は、[スライドマスター](/slides/ja/net/slide-master/) を参照してください。

## **スライドレイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズできるため、ソーステンプレートを管理していない限り、名前ベースの選択は信頼性が低くなります。

次の例は、最初のマスタ上で **Title and Content** を探します。そのレイアウトが利用できない場合は、意図的に **Blank** にフォールバックします。2 番目の null チェックは、プレゼンテーションにカスタムレイアウトしか含まれない可能性があるために必要です。選択されたレイアウトは、[ISlide.LayoutSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/layoutslide/) プロパティを介して最初のノーマルスライドに適用されます。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

スライドのレイアウトを変更しても、スライドに直接追加された通常の図形は削除されません。ただし、プレースホルダーの位置、継承された書式、および既存プレースホルダーと新しいレイアウト間の対応関係が変わり得るため、レイアウトが大きく異なる場合は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存のレイアウトを選択しただけで、作成はしていません。レイアウトを作成するには、対象マスタのレイアウトコレクション上で [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/ja/net/aspose.slides/masterlayoutslidecollection/add/) メソッドを呼び出します。

次の例は常に `Report Title and Content` という名前の新しい **Title and Content** レイアウトを追加し、そのレイアウトに基づくノーマルスライドを追加します。レイアウト名はコレクション内で一意である必要があります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

テンプレートが本当に別の再利用可能構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトがすでに存在する場合は、重複作成せずに選択して再利用してください。

## **レイアウトスライドへのプレースホルダーの追加**

[ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/placeholdermanager/) プロパティは、レイアウトにプレースホルダー形状を追加するための [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutplaceholdermanager/) を提供します。

| PowerPoint Placeholder | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![コンテンツ](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![コンテンツ (縦)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![テキスト](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![テキスト (縦)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![画像](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![チャート](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![テーブル](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![メディア](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![オンライン画像](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

次の例は **Blank** レイアウトが存在することを確認し、4 つのプレースホルダーを追加してから、変更されたレイアウトを使用するノーマルスライドを作成します。順序は意図的で、プレースホルダーはノーマルスライドが作成される前に追加されるため、Aspose.Slides がそのスライド上に対応するプレースホルダー形状を生成できます。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

結果：

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="警告" %}}
継承された書式や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは既存のノーマルスライドに自動的に補填されません。レイアウトの変更はプレゼンテーションのコピーでテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) メソッドを使用して、ノーマルスライドが参照していないレイアウトを削除します。このメソッドは、まだ使用中のレイアウトはそのまま残します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

特定のレイアウトを削除するには、まずその [HasDependingSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/hasdependingslides/) プロパティまたは [GetDependingSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/getdependingslides/) メソッドを使用します。削除する前に依存スライドを別のレイアウトに再割り当てし、[ILayoutSlide.Remove](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/remove/) を呼び出してください。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptxeditexception/) が発生します。

## **レイアウトスライドでフッター表示を制御する**

レイアウトには独自のフッター、スライド番号、日付時刻プレースホルダーがあります。これらのプレースホルダーをレイアウト単位で制御するには、[ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/headerfootermanager/) プロパティを使用します。たとえば、コンテンツレイアウトはフッターを表示し、タイトルレイアウトは表示しないようにしたい場合に便利です。

次の例はレイアウトを安全に選択し、フッター要素を表示可能にします：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **マスターと子レイアウトでフッター表示を制御する**

マスタ階層全体で一貫したフッター設定を適用するには、[IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/headerfootermanager/) プロパティを使用します。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslideheaderfootermanager/) の伝搬メソッドは、マスタとその依存レイアウトスライドおよびノーマルスライドに対して動作し、単一のノーマルスライドだけを対象にすることはできません。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**マスタスライドとレイアウトスライドの違いは何ですか？**

マスタスライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスタに属し、プレースホルダーの再利用可能な配置を1つ定義します。ノーマルスライドはそれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウトスライドをあるプレゼンテーションから別のプレゼンテーションへコピーできますか？**

はい。目的のコレクションに対して [AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/globallayoutslidecollection/addclone/) メソッドを使用してコピーを追加します。プレゼンテーション間でコピーする場合は、フォント、テーマ、画像、その他のリソースがソースレイアウトで使用されているかも確認してください。

**既に使用中のレイアウトを変更するとどうなりますか？**

依存スライドはレイアウトの変更を継承しますが、ローカルで書式やオブジェクトを上書きしていない限り影響を受けます。そのため、プレースホルダーのジオメトリや継承スタイルが多数のスライドで同時に変わる可能性があります。編集前に [GetDependingSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/getdependingslides/) を使って影響を受けるスライドを特定してください。

**使用中のレイアウトを削除するとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptxeditexception/) をスローします。まず依存スライドを別のレイアウトに再割り当てするか、[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) を使用して参照されていないレイアウトのみを削除してください。