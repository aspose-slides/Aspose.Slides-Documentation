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

// プレゼンテーションオブジェクトを取得し、次の DeleteSlide メソッドに渡す。
public static void DeleteSlide(string presentationFile, int slideIndex)
{
    // ソースドキュメントを読み書きモードで開く。
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))
    {
        // ソースドキュメントと削除対象スライドのインデックスを次の DeleteSlide メソッドに渡す。
        DeleteSlide(presentationDocument, slideIndex);
    }
}

// 指定されたスライドをプレゼンテーションから削除する。
public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)
{
    if (presentationDocument == null)
    {
        throw new ArgumentNullException("presentationDocument");
    }
    // CountSlides サンプルを使用してプレゼンテーション内のスライド数を取得する。
    int slidesCount = CountSlides(presentationDocument);
    if (slideIndex < 0 || slideIndex >= slidesCount)
    {
        throw new ArgumentOutOfRangeException("slideIndex");
    }
    // プレゼンテーションドキュメントからプレゼンテーションパートを取得する。
    PresentationPart presentationPart = presentationDocument.PresentationPart;
    // プレゼンテーションパートからプレゼンテーションを取得する。
    Presentation presentation = presentationPart.Presentation;
    // プレゼンテーション内のスライド ID のリストを取得する。
    SlideIdList slideIdList = presentation.SlideIdList;
    // 指定されたスライドのスライド ID を取得
    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;
    // スライドのリレーションシップ ID を取得する。
    string slideRelId = slideId.RelationshipId;
    // スライドリストからスライドを削除する。
    slideIdList.RemoveChild(slideId);
    //
    // すべてのカスタムショーからスライドへの参照を削除する。
    if (presentation.CustomShowList != null)
    {
        // カスタムショーのリストを走査する。
        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())
        {
            if (customShow.SlideList != null)
            {
                // スライドリストエントリのリンクリストを作成する。
                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();
                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())
                {
                    // カスタムショーから削除するスライド参照を探す。
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
    // 変更されたプレゼンテーションを保存する。
    presentation.Save();
    // 指定されたスライドのスライドパートを取得する。
    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;
    // スライドパートを削除する。
    presentationPart.DeletePart(slidePart);
}

// プレゼンテーションオブジェクトを取得し、次の CountSlides メソッドに渡す。
public static int CountSlides(string presentationFile)
{
    // 読み取り専用でプレゼンテーションを開く。
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))
    {
        // 次の CountSlides メソッドにプレゼンテーションを渡し、スライド数を返す。
        return CountSlides(presentationDocument);
    }
}

// プレゼンテーション内のスライド数をカウントする。
public static int CountSlides(PresentationDocument presentationDocument)
{
    // null ドキュメントオブジェクトをチェックする。
    if (presentationDocument == null)
    {
        throw new ArgumentNullException("presentationDocument");
    }
    int slidesCount = 0;
    // ドキュメントのプレゼンテーションパートを取得する。
    PresentationPart presentationPart = presentationDocument.PresentationPart;
    // SlideParts からスライド数を取得する。
    if (presentationPart != null)
    {
        slidesCount = presentationPart.SlideParts.Count();
    }
    // 前のメソッドにスライド数を返す。
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
    // PPTX ファイルを表す PresentationEx オブジェクトをインスタンス化する
    using (Presentation pres = new Presentation(presentationFile))
    {
        // スライドコレクション内のインデックスでスライドにアクセスする
        ISlide slide = pres.Slides[slideIndex];
        // 参照を使用してスライドを削除する
        pres.Slides.Remove(slide);
        // プレゼンテーションを PPTX ファイルとして書き込む
        pres.Save(presentationFile, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
``` 
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)