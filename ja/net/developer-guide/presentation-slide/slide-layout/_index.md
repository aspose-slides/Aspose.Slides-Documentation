---
title: "C# でスライドレイアウトを適用または変更する"
linktitle: "スライドレイアウト"
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
- フッターの表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2つのコンテンツ
- 比較
- タイトルのみ
- 空白レイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦テキスト
- 縦タイトルとテキスト
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET でスライドレイアウトの管理とカスタマイズ方法を学びます。レイアウトタイプ、プレースホルダーの制御、フッターの表示、そして C# のコード例を通じたレイアウト操作について紹介します。"
---

## **概要**

スライドレイアウトは、プレースホルダーボックスの配置とスライド上のコンテンツの書式設定を定義します。利用できるプレースホルダーとその表示位置を制御します。スライドレイアウトを使用すると、シンプルなものから複雑なものまで、プレゼンテーションを迅速かつ一貫してデザインできます。PowerPoint の最も一般的なスライドレイアウトは次のとおりです。

**タイトル スライド レイアウト** – タイトル用とサブタイトル用の 2 つのテキストプレースホルダーが含まれます。

**タイトルとコンテンツ レイアウト** – 上部に小さなタイトルプレースホルダー、下部にテキスト、箇条書き、チャート、画像などのメインコンテンツ用の大きなプレースホルダーがあります。

**空白 レイアウト** – プレースホルダーがなく、スライドをゼロからデザインできます。

スライドレイアウトはスライドマスターの一部であり、プレゼンテーション全体のレイアウトスタイルを定義する最上位スライドです。スライドマスター経由でレイアウトスライドにアクセスし、タイプ、名前、または固有 ID で取得・変更できます。また、プレゼンテーション内で特定のレイアウトスライドを直接編集することも可能です。

Aspose.Slides for .NET でスライドレイアウトを操作するには、次を使用します。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) および [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) プロパティ
- [ILayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/)、[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/)、[ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/)、[ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslideheaderfootermanager/) などの型

{{% alert title="Info" color="info" %}}
マスタースライドの操作について詳しくは、[Slide Master](/slides/ja/net/slide-master/) 記事をご覧ください。
{{% /alert %}}

## **プレゼンテーションへのスライドレイアウトの追加**

スライドの外観や構造をカスタマイズするために、プレゼンテーションに新しいレイアウトスライドを追加する必要があります。Aspose.Slides for .NET では、特定のレイアウトが既に存在するかどうかを確認し、必要に応じて新規作成し、そのレイアウトに基づいてスライドを挿入できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/) にアクセスします。
1. コレクション内に目的のレイアウトスライドが既に存在するか確認します。存在しない場合は必要なレイアウトスライドを追加します。
1. 新しいレイアウトスライドを基に空のスライドを追加します。
1. プレゼンテーションを保存します。

以下の C# コードは、PowerPoint プレゼンテーションにスライドレイアウトを追加する方法を示しています。
```cs
// PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // レイアウトスライドのタイプを順に調べて、レイアウトスライドを選択します。
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        //     プレゼンテーションにすべてのレイアウトタイプが含まれていない状況です。
        //     プレゼンテーションファイルには Blank と Custom のレイアウトタイプのみが含まれています。
        //     ただし、カスタムタイプのレイアウトスライドは認識可能な名前を持つ場合があります、
        //     例えば "Title"、"Title and Content" などで、レイアウトスライドの選択に使用できます。
        //     プレースホルダーシェイプのタイプ集合に依存することもできます。
        //     例として、Title スライドは Title プレースホルダータイプだけを持つべきです。
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 追加したレイアウトスライドを使用して空のスライドを追加します。
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // プレゼンテーションをディスクに保存します。  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **未使用レイアウトスライドの削除**

Aspose.Slides は、[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラスの [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) メソッドを提供し、不要または未使用のレイアウトスライドを削除できます。

以下の C# コードは、PowerPoint プレゼンテーションからレイアウトスライドを削除する方法を示しています。
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **スライドレイアウトへのプレースホルダーの追加**

Aspose.Slides は、[ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/placeholdermanager/) プロパティを提供し、レイアウトスライドに新しいプレースホルダーを追加できます。

このマネージャーは、以下のプレースホルダータイプに対応したメソッドを含みます。

| PowerPoint プレースホルダー          | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/) メソッド |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

以下の C# コードは、空白レイアウトスライドに新しいプレースホルダー シェイプを追加する方法を示しています。
```cs
using (var presentation = new Presentation())
{
    // Blank レイアウトスライドを取得します。
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // レイアウトスライドのプレースホルダーマネージャーを取得します。
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Blank レイアウトスライドにさまざまなプレースホルダーを追加します。
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Blank レイアウトを使用して新しいスライドを追加します。
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```


結果:

![The placeholders on the layout slide](add_placeholders.png)

## **レイアウトスライドのフッター表示設定**

PowerPoint プレゼンテーションでは、フッター要素（日付、スライド番号、カスタムテキスト）をレイアウトに応じて表示・非表示にできます。Aspose.Slides for .NET は、これらフッタープレースホルダーの表示状態を制御でき、特定のレイアウトだけフッター情報を表示し、他のレイアウトはシンプルに保つことが可能です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでレイアウトスライドの参照を取得します。
1. スライドフッター プレースホルダーを表示に設定します。
1. スライド番号 プレースホルダーを表示に設定します。
1. 日付/時刻 プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

以下の C# コードは、スライドフッターの表示状態を設定する方法を示しています。
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```


## **スライドの子フッター表示設定**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタムテキストといったフッター要素をマスタースライドレベルで制御し、すべてのレイアウトスライドに一貫したフッター情報を提供できます。Aspose.Slides for .NET は、マスタースライド上でこれらフッタープレースホルダーの表示と内容を設定し、子レイアウトスライドへ自動的に反映させることができます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでマスタースライドの参照を取得します。
1. マスターとすべての子フッタープレースホルダーを表示に設定します。
1. マスターとすべての子スライド番号プレースホルダーを表示に設定します。
1. マスターとすべての子日付/時刻プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

以下の C# コードは、この操作を示しています。
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドは全体的なテーマと既定の書式設定を定義し、レイアウトスライドはコンテンツの種類ごとにプレースホルダーの具体的な配置を定義します。

**レイアウトスライドを別のプレゼンテーションにコピーできますか？**

はい。1 つのプレゼンテーションの [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) コレクションからレイアウトスライドをクローンし、`AddClone` メソッドを使って別のプレゼンテーションに挿入できます。

**使用中のスライドが参照しているレイアウトスライドを削除しようとするとどうなりますか？**

プレゼンテーション内で少なくとも 1 枚のスライドが参照しているレイアウトスライドを削除しようとすると、Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception/) をスローします。未使用のレイアウトスライドだけを安全に削除するには、[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) を使用してください。