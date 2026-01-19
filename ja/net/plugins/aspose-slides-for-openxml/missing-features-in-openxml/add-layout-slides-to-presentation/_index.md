---
title: プレゼンテーションにレイアウト スライドを追加
type: docs
weight: 20
url: /ja/net/add-layout-slides-to-presentation/
---

Aspose.Slides for .NET を使用すると、開発者はプレゼンテーションに新しいレイアウト スライドを追加できます。レイアウト スライドを追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成する
- マスター スライド コレクションにアクセスする
- 既存のレイアウト スライドを検索し、必要なスライドがレイアウト スライド コレクションに既に存在するかどうか確認する
- 目的のレイアウトが存在しない場合は、新しいレイアウト スライドを追加する
- 新しく追加したレイアウト スライドを使用して空のスライドを追加する
- 最後に、Presentation オブジェクトを使用してプレゼンテーション ファイルを書き出す

## **例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation(FileName))

{

    // Try to search by layout slide type

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // The situation when a presentation doesn't contain some type of layouts.

        // Technographics.pptx presentation only contains Blank and Custom layout types.

        // But layout slides with Custom types has different slide names,

        // like "Title", "Title and Content", etc. And it is possible to use these

        // names for layout slide selection.

        // Also it is possible to use the set of placeholder shape types. For example,

        // Title slide should have only Title pleceholder type, etc.

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

    //Adding empty slide with added layout slide 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Save presentation    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **実行例のダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 
詳細については、[スライドのレイアウトを適用または変更する (.NET)](/slides/ja/net/slide-layout/)をご覧ください。
{{% /alert %}}