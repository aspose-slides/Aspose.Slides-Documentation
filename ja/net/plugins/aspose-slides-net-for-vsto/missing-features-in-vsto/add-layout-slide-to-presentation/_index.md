---
title: プレゼンテーションにレイアウトスライドを追加する
type: docs
weight: 10
url: /ja/net/add-layout-slide-to-presentation/
---

Aspose.Slides for .NETを使用すると、開発者はプレゼンテーションに新しいレイアウトスライドを追加できます。レイアウトスライドを追加するには、以下の手順に従ってください。

- Presentationクラスのインスタンスを作成します。
- マスタースライドコレクションにアクセスします。
- 既存のレイアウトスライドを検索して、必要なレイアウトがすでにレイアウトスライドコレクションにあるかどうかを確認します。
- 希望するレイアウトが利用できない場合は、新しいレイアウトスライドを追加します。
- 新しく追加したレイアウトスライドで空のスライドを追加します。
- 最後に、Presentationオブジェクトを使用してプレゼンテーションファイルを書き込みます。
## **例**
``` csharp

 //プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成します

using (Presentation p = new Presentation("Test.pptx"))

{

   // レイアウトスライドタイプで検索しようとします

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // プレゼンテーションが特定のレイアウトタイプを含まない場合の状況です。

     // Technographics.pptxプレゼンテーションにはBlankとCustomレイアウトタイプのみが含まれています。

     // ただし、Customタイプのレイアウトスライドには異なるスライド名があり、

     // 「Title」、「Title and Content」などがあります。これらの

     // 名前をレイアウトスライドの選択に使用することができます。

     // また、プレースホルダーシェイプタイプのセットを使用することもできます。たとえば、

     // タイトルスライドには、タイトルプレースホルダータイプのみが必要です。

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

  //追加されたレイアウトスライドで空のスライドを追加します

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //プレゼンテーションを保存します

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **実行例のダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Adding Layout Slides/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode#content)
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

詳細については、[プレゼンテーションにレイアウトスライドを追加する](/slides/ja/net/adding-and-editing-slides/#working-with-slide-size-and-layout)を訪問してください。

{{% /alert %}}