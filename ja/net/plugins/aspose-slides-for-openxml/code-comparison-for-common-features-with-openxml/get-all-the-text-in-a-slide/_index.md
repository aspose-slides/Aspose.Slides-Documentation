---
title: スライド内のすべてのテキストを取得する
type: docs
weight: 110
url: /net/get-all-the-text-in-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "スライド内のすべてのテキストを取得する.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// スライド内のすべてのテキストを取得する。

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // プレゼンテーションを読み取り専用で開く。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // プレゼンテーションとスライドインデックスを

        // 次のGetAllTextInSlideメソッドに渡し、

        // それが返す文字列の配列を返す。

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // プレゼンテーションドキュメントが存在することを確認する。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // スライドインデックスが範囲外でないことを確認する。

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // プレゼンテーションドキュメントのプレゼンテーションパートを取得する。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // プレゼンテーションパートとプレゼンテーションが存在することを確認する。

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // プレゼンテーションパートからプレゼンテーションオブジェクトを取得する。

        Presentation presentation = presentationPart.Presentation;

        // スライドIDリストが存在することを確認する。

        if (presentation.SlideIdList != null)

        {

            // スライドIDリストからスライドIDのコレクションを取得する。

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // スライドIDが範囲内の場合...

            if (slideIndex < slideIds.Count)

            {

                // スライドのリレーションシップIDを取得する。

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // 指定されたスライドパートをリレーションシップIDから取得する。

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // スライドパートを次のメソッドに渡し、

                // そのメソッドが返す文字列の配列を

                // 前のメソッドに返す。

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // それ以外の場合は、nullを返す。

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // スライドパートが存在することを確認する。

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // 新しい文字列のリンクリストを作成する。

    LinkedList<string> texts = new LinkedList<string>();

    // スライドが存在する場合...

    if (slidePart.Slide != null)

    {

        // スライド内のすべての段落を繰り返す。

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // 新しいStringBuilderを作成する。                    

            StringBuilder paragraphText = new StringBuilder();

            // 段落の行を繰り返す。

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // 各行を前の行に追加する。

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // 各段落をリンクリストに追加する。

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // 文字列の配列を返す。

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "スライド内のすべてのテキストを取得する.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// スライド内のすべてのテキストを取得する。

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// 新しい文字列のリンクリストを作成する。

List<string> texts = new List<string>();

//PresentationExクラスをインスタンス化し、PPTXを表現する

using (Presentation pres = new Presentation(presentationFile))

{

    // スライドにアクセスする

    ISlide sld = pres.Slides[slideIndex];

    // プレースホルダを見つけるためにシェイプを繰り返す

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // 各プレースホルダのテキストを取得する

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// 文字列の配列を返す。

return texts;

}

``` 
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20all%20the%20text%20in%20a%20slide%20\(Aspose.Slides\).zip)