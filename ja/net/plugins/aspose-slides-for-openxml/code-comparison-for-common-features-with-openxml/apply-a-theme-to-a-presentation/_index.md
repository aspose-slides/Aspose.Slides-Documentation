---
title: プレゼンテーションにテーマを適用する
type: docs
weight: 30
url: /ja/net/apply-a-theme-to-a-presentation/
---

## **OpenXML プレゼンテーション**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Apply a new theme to the presentation. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Apply a new theme to the presentation. 

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

    // Get the presentation part of the presentation document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Get the existing slide master part.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Get the new slide master part.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Remove the existing theme part.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Remove the old slide master part.

    presentationPart.DeletePart(slideMasterPart);

    // Import the new slide master part, and reuse the old relationship ID.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Change to the new theme part.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Insert the code for the layout for this example.

    string defaultLayoutType = "Title and Content";

    // Remove the slide layout relationship on all slides. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Determine the slide layout type for each slide.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Delete the old layout part.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Apply the new layout part.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Apply the new default layout part.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Get the slide layout type.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Remarks: If this is used in production code, check for a null reference.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
テーマを適用するには、マスターとともにスライドをクローンする必要があります。以下の手順に従ってください。

- ソースプレゼンテーション（スライドをクローンする元）を含む Presentation クラスのインスタンスを作成します。
- 目的のプレゼンテーション（スライドをクローンする先）を含む Presentation クラスのインスタンスを作成します。
- クローン対象のスライドとマスタースライドにアクセスします。
- 目的のプレゼンテーションの Presentation オブジェクトが公開する Masters コレクションを参照して、IMasterSlideCollection クラスのインスタンスを取得します。
- IMasterSlideCollection オブジェクトが提供する AddClone メソッドを呼び出し、クローン元 PPTX のマスターをパラメータとして渡します。
- 目的のプレゼンテーションの Presentation オブジェクトが公開する Slides コレクションを参照して、ISlideCollection クラスのインスタンスを設定します。
- ISlideCollection オブジェクトが提供する AddClone メソッドを呼び出し、クローン元プレゼンテーションのスライドとマスタースライドをパラメータとして渡します。
- 変更された目的のプレゼンテーションファイルを書き込みます。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Instantiate Presentation class to load the source presentation file

    Presentation srcPres = new Presentation(presentationFile);

    //Instantiate Presentation class for destination presentation (where slide is to be cloned)

    Presentation destPres = new Presentation(outputFile);

    //Instantiate ISlide from the collection of slides in source presentation along with

    //master slide

    ISlide SourceSlide = srcPres.Slides[0];

    //Clone the desired master slide from the source presentation to the collection of masters in the

    //destination presentation

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Clone the desired master slide from the source presentation to the collection of masters in the

    //destination presentation

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Clone the desired slide from the source presentation with the desired master to the end of the

    //collection of slides in the destination presentation

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Clone the desired master slide from the source presentation to the collection of masters in the//destination presentation

    //Save the destination presentation to disk

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **実行コード例のダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **サンプルコード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)