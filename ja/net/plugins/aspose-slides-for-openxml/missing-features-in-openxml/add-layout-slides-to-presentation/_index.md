---
title: プレゼンテーションにレイアウトスライドを追加
type: docs
weight: 20
url: /ja/net/add-layout-slides-to-presentation/
---

Aspose.Slides for .NETは、開発者がプレゼンテーションに新しいレイアウトスライドを追加することを可能にします。レイアウトスライドを追加するには、以下の手順に従ってください：

- Presentationクラスのインスタンスを作成します
- マスタースライドコレクションにアクセスします
- 既存のレイアウトスライドを見つけ、必要なものがレイアウトスライドコレクションにすでに存在するか確認します
- 希望のレイアウトが利用できない場合は、新しいレイアウトスライドを追加します
- 新しく追加したレイアウトスライドで空のスライドを追加します
- 最後に、Presentationオブジェクトを使用してプレゼンテーションファイルを書き込みます
## **例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//プレゼンテーションファイルを表すPresentationクラスをインスタンス化します

using (Presentation p = new Presentation(FileName))

{

    // レイアウトスライドタイプで検索を試みる

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // プレゼンテーションに特定のタイプのレイアウトが含まれていない状況です。

        // Technographics.pptxプレゼンテーションは、空白とカスタムレイアウトタイプのみを含みます。

        // しかし、カスタムタイプのレイアウトスライドには異なるスライド名があります。

        // 例えば、「タイトル」、「タイトルとコンテンツ」などです。そして、これらを使って

        // レイアウトスライドを選択できます。

        // また、プレースホルダーシェイプタイプのセットを使用することもできます。例えば、

        // タイトルスライドはタイトルプレースホルダータイプのみを持つ必要があります。

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

    //追加したレイアウトスライドで空のスライドを追加する 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //プレゼンテーションを保存する    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **サンプルコードをダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **実行例をダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

詳細については、[プレゼンテーションにレイアウトスライドを追加](/slides/ja/net/adding-and-editing-slides/#working-with-slide-size-and-layout)を訪れてください。

{{% /alert %}}