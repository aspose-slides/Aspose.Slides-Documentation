---
title: スライドを新しい位置に移動する
type: docs
weight: 140
url: /net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// プレゼンテーション内のスライド数をカウントする。

public static int CountSlides(string presentationFile)

{

    // プレゼンテーションを読み取り専用で開く。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // プレゼンテーションを次のCountSlidesメソッドに渡し、

        // スライド数を返します。

        return CountSlides(presentationDocument);

    }

}

// プレゼンテーション内のスライドをカウントする。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // ドキュメントオブジェクトがnullでないかを確認します。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // ドキュメントのプレゼンテーション部分を取得します。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlidePartsからスライド数を取得します。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // スライド数を前のメソッドに返します。

    return slidesCount;

}

// プレゼンテーション内のスライドの順序でスライドを別の位置に移動します。

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// プレゼンテーション内のスライドの順序でスライドを別の位置に移動します。

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // CountSlidesメソッドを呼び出してプレゼンテーション内のスライド数を取得します。

    int slidesCount = CountSlides(presentationDocument);

    // fromとtoの両方の位置が範囲内であり、異なっていることを確認します。

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // プレゼンテーションドキュメントからプレゼンテーション部分を取得します。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // スライド数はゼロではないため、プレゼンテーションにはスライドが含まれている必要があります。            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // ソーススライドのスライドIDを取得します。

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // ソーススライドを移動するターゲットスライドの位置を特定します。

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // ソーススライドを現在の位置から削除します。

    sourceSlide.Remove();

    // ソーススライドをターゲットスライドの後の新しい位置に挿入します。

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // 修正したプレゼンテーションを保存します。

    presentation.Save();

} 

```
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// プレゼンテーション内のスライドの順序でスライドを別の位置に移動します。

public static void MoveSlide(string presentationFile, int from, int to)

{

    // プレゼンテーションExクラスをインスタンス化してソースPPTXファイルをロードします。

    using (Presentation pres = new Presentation(presentationFile))

    {

        // 位置を変更するスライドを取得します。

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // スライドの新しい位置を設定します。

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // PPTXをディスクに書き込みます。

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **サンプルコードをダウンロード**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Move%20a%20slide%20to%20a%20new%20position%20\(Aspose.Slides\).zip)