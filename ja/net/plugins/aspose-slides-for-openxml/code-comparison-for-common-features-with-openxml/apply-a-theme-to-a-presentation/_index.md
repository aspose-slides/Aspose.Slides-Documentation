---
title: プレゼンテーションにテーマを適用する
type: docs
weight: 30
url: /net/apply-a-theme-to-a-presentation/
---

## **OpenXML プレゼンテーション:**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// プレゼンテーションに新しいテーマを適用します。

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// プレゼンテーションに新しいテーマを適用します。

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // プレゼンテーション ドキュメントのプレゼンテーション パートを取得します。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 既存のスライドマスターパートを取得します。

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // 新しいスライドマスターパートを取得します。

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // 既存のテーマパートを削除します。

    presentationPart.DeletePart(presentationPart.ThemePart);

    // 古いスライドマスターパートを削除します。

    presentationPart.DeletePart(slideMasterPart);

    // 新しいスライドマスターパートをインポートし、古いリレーションシップ ID を再利用します。

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // 新しいテーマパートに変更します。

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // この例のレイアウト用のコードを挿入します。

    string defaultLayoutType = "タイトルとコンテンツ";

    // すべてのスライドのスライドレイアウトリレーションシップを削除します。

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // 各スライドのスライドレイアウトタイプを決定します。

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // 古いレイアウトパートを削除します。

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // 新しいレイアウトパートを適用します。

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // 新しいデフォルトレイアウトパートを適用します。

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// スライドレイアウトタイプを取得します。

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // 備考: これが製品コードで使用される場合、null参照を確認してください。

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
テーマを適用するには、マスタースライドとともにスライドをクローンする必要があります。以下の手順に従ってください。

- スライドをクローンする元のプレゼンテーションを含むプレゼンテーションクラスのインスタンスを作成します。
- スライドがクローンされる先のプレゼンテーションを含むプレゼンテーションクラスのインスタンスを作成します。
- クローンするスライドとマスタースライドにアクセスします。
- 目的のプレゼンテーションオブジェクトが公開するMastersコレクションを参照してIMasterSlideCollectionクラスをインスタンス化します。
- IMasterSlideCollectionオブジェクトで公開されているAddCloneメソッドを呼び出し、ソースPPTXからクローンされるマスタースライドをAddCloneメソッドのパラメーターとして渡します。
- 目的のプレゼンテーションオブジェクトが公開するSlidesコレクションへの参照を設定してISlideCollectionクラスをインスタンス化します。
- ISlideCollectionオブジェクトで公開されているAddCloneメソッドを呼び出し、クローンする元のプレゼンテーションのスライドとマスタースライドをAddCloneメソッドのパラメーターとして渡します。
- 修正された宛先プレゼンテーションファイルを書き込みます。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //ソース プレゼンテーションファイルを読み込むためにプレゼンテーションクラスをインスタンス化します

    Presentation srcPres = new Presentation(presentationFile);

    //スライドがクローンされる宛先プレゼンテーション用のプレゼンテーションクラスをインスタンス化します

    Presentation destPres = new Presentation(outputFile);

    //ソース プレゼンテーションのスライドのコレクションからISlideをインスタンス化し、

    //マスタースライドとともに

    ISlide SourceSlide = srcPres.Slides[0];

    //宛先プレゼンテーションのマスターコレクションに、ソースプレゼンテーションから目的のマスタースライドをクローンします

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //宛先プレゼンテーションのマスターコレクションに、ソースプレゼンテーションから目的のマスタースライドをクローンします

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //宛先プレゼンテーションのスライドコレクションの最後に、目的のマスタースライドでソースプレゼンテーションから目的のスライドをクローンします

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //宛先プレゼンテーションのマスターコレクションに、ソースプレゼンテーションから目的のマスタースライドをクローンします

    //宛先プレゼンテーションをディスクに保存します

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **コードサンプルのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **サンプルコード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)