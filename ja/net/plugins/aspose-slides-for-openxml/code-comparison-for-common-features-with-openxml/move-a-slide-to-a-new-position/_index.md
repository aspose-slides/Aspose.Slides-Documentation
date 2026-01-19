---
title: スライドを新しい位置に移動する
type: docs
weight: 140
url: /ja/net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// プレゼンテーション内のスライド数をカウントします。

public static int CountSlides(string presentationFile)

{

    // プレゼンテーションを読み取り専用で開きます。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 次の CountSlides メソッドにプレゼンテーションを渡し

        // スライド数を返します。

        return CountSlides(presentationDocument);

    }

}

// プレゼンテーション内のスライド数をカウントします。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // null のドキュメント オブジェクトをチェックします。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // ドキュメントのプレゼンテーション パートを取得します。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts からスライド数を取得します。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 前のメソッドにスライド数を返します。

    return slidesCount;

}

// プレゼンテーション内のスライド順序でスライドを別の位置に移動します。

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// プレゼンテーション内のスライド順序でスライドを別の位置に移動します。

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // CountSlides メソッドを呼び出してプレゼンテーションのスライド数を取得します。

    int slidesCount = CountSlides(presentationDocument);

    // from と to の両方の位置が範囲内であり、互いに異なることを確認します。

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // プレゼンテーション ドキュメントからプレゼンテーション パートを取得します。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // スライド数がゼロでないので、プレゼンテーションにはスライドが含まれています。            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // ソース スライドのスライド ID を取得します。

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // ソース スライドを移動する対象スライドの位置を特定します。

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

    // ソース スライドを現在の位置から削除します。

    sourceSlide.Remove();

    // ターゲット スライドの後にソース スライドを新しい位置に挿入します。

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // 変更されたプレゼンテーションを保存します。

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// プレゼンテーション内のスライド順序でスライドを別の位置に移動します。

public static void MoveSlide(string presentationFile, int from, int to)

{

    // PresentationEx クラスをインスタンス化してソース PPTX ファイルを読み込みます

    using (Presentation pres = new Presentation(presentationFile))

    {

        // 位置を変更するスライドを取得します

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // スライドの新しい位置を設定します

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // PPTX をディスクに書き込みます

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **サンプルコードをダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)