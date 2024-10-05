---
title: スライドレイアウト
type: docs
weight: 60
url: /net/slide-layout/
keyword: "スライドサイズを設定する、スライドオプションを設定する、スライドサイズを指定する、フッターの可視性、子フッター、コンテンツのスケーリング、ページサイズ、C#、Csharp、.NET、Aspose.Slides"
description: "C#または.NETでPowerPointスライドのサイズとオプションを設定する"
---

スライドレイアウトには、スライドに表示されるすべてのコンテンツのプレースホルダーと書式設定情報が含まれています。レイアウトは、利用可能なコンテンツプレースホルダーとその配置場所を決定します。

スライドレイアウトを使用すると、プレゼンテーションを迅速に作成およびデザインできます（簡単なものでも複雑なものでも）。これらは、PowerPointプレゼンテーションで使用される最も人気のあるスライドレイアウトの一部です：

* **タイトルスライドレイアウト**。このレイアウトは、2つのテキストプレースホルダーで構成されています。一つのプレースホルダーはタイトル用で、もう一つはサブタイトル用です。
* **タイトルとコンテンツのレイアウト**。このレイアウトには、上部にタイトル用の比較的小さなプレースホルダーと、コアコンテンツ用の大きなプレースホルダー（グラフ、段落、箇条書き、番号付きリスト、画像など）が含まれています。
* **空白のレイアウト**。このレイアウトにはプレースホルダーがなく、ゼロから要素を作成することができます。

スライドマスターは、スライドレイアウトに関する情報を保存する最上位の階層スライドであるため、マスタースライドを使用してスライドレイアウトにアクセスし、それらに変更を加えることができます。レイアウトスライドは、タイプまたは名前でアクセスできます。同様に、すべてのスライドには一意のIDがあり、それを使用してアクセスできます。

また、特定のプレゼンテーション内の特定のスライドレイアウトに直接変更を加えることもできます。

* スライドレイアウト（マスタースライドのものを含む）を操作できるように、Aspose.Slidesは、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスの下で[LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/)や[Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/)のようなプロパティを提供します。
* 関連作業を実行するために、Aspose.Slidesは[MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterlayoutslidecollection/)、[SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/)、[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/)など、さまざまなタイプを提供します。

{{% alert title="情報" color="info" %}}

特にマスタースライドを操作する方法についての詳細は、[Slide Master](https://docs.aspose.com/slides/net/slide-master/)の記事を参照してください。

{{% /alert %}}

## **プレゼンテーションにスライドレイアウトを追加する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [MasterSlideコレクション](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/)にアクセスします。
1. 既存のレイアウトスライドを調べ、必要なレイアウトスライドがすでにLayout Slideコレクションに存在しているか確認します。そうでなければ、追加したいレイアウトスライドを追加します。
1. 新しいレイアウトスライドに基づいて空のスライドを追加します。
1. プレゼンテーションを保存します。

このC#コードは、PowerPointプレゼンテーションにスライドレイアウトを追加する方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化します
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // レイアウトスライドタイプを調べます
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // プレゼンテーションに一部のレイアウトタイプが含まれていない状況。
        // プレゼンテーションファイルには空白とカスタムレイアウトタイプのみが含まれています。
        // ただし、カスタムタイプのレイアウトスライドは異なるスライド名を持ち、
        // "Title"、"Title and Content"などの名前をレイアウトスライド選択に使用できます。
        // プレースホルダー形状タイプのセットも使用できます。例えば、
        // タイトルスライドにはタイトルプレースホルダータイプのみが必要です。
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

    // 追加されたレイアウトスライドで空のスライドを追加します
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // プレゼンテーションをディスクに保存します  
    presentation.Save("AddLayoutSlides_out.pptx", SaveFormat.Pptx);
}
```

## **未使用のレイアウトスライドを削除する**

Aspose.Slidesは、不要な未使用のレイアウトスライドを削除するために、[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)メソッドを[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)クラスから提供します。このC#コードは、PowerPointプレゼンテーションからレイアウトスライドを削除する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **スライドレイアウトにサイズとタイプを設定する**

特定のレイアウトスライドのサイズとタイプを設定できるように、Aspose.Slidesは、[Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/type)および[Size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/size)プロパティを提供します（[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスから）。このC#は、その操作を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// 生成されたプレゼンテーションのスライドサイズをソースに設定します
auxPresentation.SlideSize.SetSize(presentation.SlideSize.Type, SlideSizeScaleType.EnsureFit);

auxPresentation.Slides.InsertClone(0, slide);
auxPresentation.Slides.RemoveAt(0);
// プレゼンテーションをディスクに保存します
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **スライド内のフッターの可視性を設定する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドフッタープレースホルダーを表示可能に設定します。
1. 日時プレースホルダーを表示可能に設定します。
1. プレゼンテーションを保存します。

このC#コードは、スライドのフッターの可視性を設定する方法を示しています（および関連タスクを実行します）：

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.Slides[0].HeaderFooterManager;
    if (!headerFooterManager.IsFooterVisible) // プロパティIsFooterVisibleは、スライドのフッタープレースホルダーが欠如していることを示すために使用されます
    {
        headerFooterManager.SetFooterVisibility(true); // メソッドSetFooterVisibilityはスライドフッタープレースホルダーを表示可能に設定するために使用されます
    }
    if (!headerFooterManager.IsSlideNumberVisible) // プロパティIsSlideNumberVisibleは、スライドページ番号プレースホルダーが欠如していることを示すために使用されます
    {
        headerFooterManager.SetSlideNumberVisibility(true); // メソッドSetSlideNumberVisibilityはスライドページ番号プレースホルダーを表示可能に設定するために使用されます
    }
    if (!headerFooterManager.IsDateTimeVisible) // プロパティIsDateTimeVisibleは、スライドの日時プレースホルダーが欠如していることを示すために使用されます
    {
        headerFooterManager.SetDateTimeVisibility(true); // メソッドSetFooterVisibilityは、スライドの日時プレースホルダーを表示可能に設定するために使用されます
    }
    headerFooterManager.SetFooterText("フッターのテキスト"); // メソッドSetFooterTextはスライドフッタープレースホルダーにテキストを設定するために使用されます
    headerFooterManager.SetDateTimeText("日時のテキスト"); // メソッドSetDateTimeTextはスライドの日時プレースホルダーにテキストを設定するために使用されます。

	presentation.Save("Presentation.ppt", SaveFormat.ppt);
}
```

## **スライド内の子フッターの可視性を設定する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してマスタースライドの参照を取得します。
1. マスタースライドとすべての子フッタープレースホルダーを表示可能に設定します。
1. マスタースライドとすべての子フッタープレースホルダーのテキストを設定します。
1. マスタースライドとすべての子日時プレースホルダーのテキストを設定します。
1. プレゼンテーションを保存します。

このC#コードは、その操作を示しています：

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;
    headerFooterManager.SetFooterAndChildFootersVisibility(true); // メソッドSetFooterAndChildFootersVisibilityはマスタースライドとすべての子フッタープレースホルダーを表示可能に設定するために使用されます
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // メソッドSetSlideNumberAndChildSlideNumbersVisibilityはマスタースライドとすべての子ページ番号プレースホルダーを表示可能に設定するために使用されます
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // メソッドSetDateTimeAndChildDateTimesVisibilityはマスタースライドとすべての子日時プレースホルダーを表示可能に設定するために使用されます

    headerFooterManager.SetFooterAndChildFootersText("フッターのテキスト"); // メソッドSetFooterAndChildFootersTextはマスタースライドとすべての子フッタープレースホルダーのテキストを設定するために使用されます
    headerFooterManager.SetDateTimeAndChildDateTimesText("日時のテキスト"); // メソッドSetDateTimeAndChildDateTimesTextはマスタースライドとすべての子日時プレースホルダーにテキストを設定するために使用されます
}
```

## **コンテンツスケーリングに応じてスライドサイズを設定する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、サイズを設定したいスライドを含むプレゼンテーションを読み込みます。
1. 新しいプレゼンテーションを生成するために、別の[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使ってスライドの参照を取得します（最初のプレゼンテーションから）。
1. スライドフッタープレースホルダーを表示可能に設定します。
1. 日時プレースホルダーを表示可能に設定します。
1. プレゼンテーションを保存します。

このC#はその操作を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// 生成されたプレゼンテーションのスライドサイズをソースに設定します
presentation.SlideSize.SetSize(540, 720, SlideSizeScaleType.EnsureFit); // メソッドSetSizeは、コンテンツが収まるようにスライドサイズを設定するために使用されます
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // メソッドSetSizeは、コンテンツの最大サイズを持つようにスライドサイズを設定するために使用されます
           
// プレゼンテーションをディスクに保存します
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **PDF生成時のページサイズを設定する**

特定のプレゼンテーション（ポスターなど）は、PDFドキュメントにしばしば変換されます。PowerPointをPDFに変換して最良の印刷およびアクセシビリティオプションにアクセスする場合、スライドをPDF文書に適したサイズ（例えばA4）に設定したいでしょう。

Aspose.Slidesは、スライドに対する好みの設定を指定できる[SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/)クラスを提供します。このC#コードは、プレゼンテーション内のスライドに特定の用紙サイズを設定するために、[Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/type/)プロパティ（`SlideSize`クラスから）を使用する方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します 
Presentation presentation = new Presentation();

// SlideSize.Typeプロパティを設定します 
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.EnsureFit);

// PDFオプションの異なるプロパティを設定します
PdfOptions opts = new PdfOptions();
opts.SufficientResolution = 600;

// プレゼンテーションをディスクに保存します
presentation.Save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
```