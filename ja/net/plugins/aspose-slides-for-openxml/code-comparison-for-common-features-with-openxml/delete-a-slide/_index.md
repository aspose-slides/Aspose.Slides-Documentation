---
title: スライドを削除する
type: docs
weight: 80
url: /ja/net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// プレゼンテーションオブジェクトを取得し、次のDeleteSlideメソッドに渡す。

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // ソースドキュメントを読み書きモードで開く。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // ソースドキュメントと削除するスライドのインデックスを次のDeleteSlideメソッドに渡す。

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// プレゼンテーションから指定されたスライドを削除する。

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // CountSlidesサンプルを使用してプレゼンテーションのスライド数を取得する。

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // プレゼンテーションドキュメントからプレゼンテーションパートを取得する。 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // プレゼンテーションパートからプレゼンテーションを取得する。

    Presentation presentation = presentationPart.Presentation;

    // プレゼンテーション内のスライドIDのリストを取得する。

    SlideIdList slideIdList = presentation.SlideIdList;

    // 指定されたスライドのスライドIDを取得する

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // スライドの関係IDを取得する。

    string slideRelId = slideId.RelationshipId;

    // スライドリストからスライドを削除する。

    slideIdList.RemoveChild(slideId);

    //

    // すべてのカスタムショーからスライドへの参照を削除する。

    if (presentation.CustomShowList != null)

    {

        // カスタムショーのリストを反復処理する。

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // スライドリストエントリのリンクリストを宣言する。

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // カスタムショーから削除するスライド参照を見つける。

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // カスタムショーからスライドへのすべての参照を削除する。

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // 修正されたプレゼンテーションを保存する。

    presentation.Save();

    // 指定されたスライドのスライドパートを取得する。

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // スライドパートを削除する。

    presentationPart.DeletePart(slidePart);

}

// プレゼンテーションオブジェクトを取得し、次のCountSlidesメソッドに渡す。

public static int CountSlides(string presentationFile)

{

    // プレゼンテーションを読み取り専用で開く。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // プレゼンテーションを次のCountSlideメソッドに渡し

        // スライド数を返す。

        return CountSlides(presentationDocument);

    }

}

// プレゼンテーション内のスライドをカウントする。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // nullドキュメントオブジェクトをチェックする。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // ドキュメントのプレゼンテーションパートを取得する。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlidePartsからスライド数を取得する。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // スライド数を前のメソッドに返す。

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //PPTXファイルを表すPresentationExオブジェクトをインスタンス化する

    using (Presentation pres = new Presentation(presentationFile))

    {

        // スライドコレクション内のインデックスを使用してスライドにアクセスする

        ISlide slide = pres.Slides[slideIndex];


        // 参照を使用してスライドを削除する

        pres.Slides.Remove(slide);


        // プレゼンテーションをPPTXファイルとして書き込む

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Delete%20a%20slide%20\(Aspose.Slides\).zip)