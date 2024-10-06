---
title: スライドの数をカウントする
type: docs
weight: 50
url: /ja/net/count-the-number-of-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "スライドの数をカウントする.pptx";

Console.WriteLine("スライドの数 = {0}",

CountSlides(FileName));

Console.ReadKey();

// プレゼンテーションオブジェクトを取得し、次のCountSlidesメソッドに渡す。

public static int CountSlides(string presentationFile)

{

    // プレゼンテーションを読み取り専用として開く。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // プレゼンテーションを次のCountSlideメソッドに渡し

        // スライドの数を返す。

        return CountSlides(presentationDocument);

    }

}

// プレゼンテーション内のスライドをカウントする。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // nullのドキュメントオブジェクトをチェックする。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // ドキュメントのプレゼンテーションパートを取得する。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlidePartsからスライドの数を取得。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 前のメソッドにスライドの数を返す。

    return slidesCount;

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "スライドの数をカウントする.pptx";

Console.WriteLine("スライドの数 = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  // PPTXファイルを表すPresentationExオブジェクトをインスタンス化する

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **サンプルコードをダウンロード**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip)