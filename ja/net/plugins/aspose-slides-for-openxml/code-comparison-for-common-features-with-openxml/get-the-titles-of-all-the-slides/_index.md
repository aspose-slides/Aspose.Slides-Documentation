---
title: すべてのスライドのタイトルを取得する
type: docs
weight: 120
url: /net/get-the-titles-of-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "すべてのスライドのタイトルを取得する.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// プレゼンテーション内のすべてのスライドのタイトルのリストを取得します。

public static IList<string> GetSlideTitles(string presentationFile)

{

    // プレゼンテーションを読み取り専用で開きます。

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// プレゼンテーション内のすべてのスライドのタイトルのリストを取得します。

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // PresentationDocumentオブジェクトからPresentationPartオブジェクトを取得します。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // PresentationPartオブジェクトからPresentationオブジェクトを取得します。

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // スライドの順序で各スライドのタイトルを取得します。

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // スライドのタイトルを取得します。

                string title = GetSlideTitle(slidePart);

                // 空のタイトルも追加できます。

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// スライドのタイトル文字列を取得します。

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 段落の区切りを宣言します。

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // すべてのタイトルシェイプを見つけます。

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // このシェイプの各段落のテキストを取得します。

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // 改行を追加します。

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// シェイプがタイトルシェイプであるかどうかを判定します。

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // いかなるタイトルシェイプ。

            case PlaceholderValues.Title:

            // センター揃えのタイトル。

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "スライド内のすべてのテキストを取得する.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("スライドの数 = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("スライド #{0} には次が含まれます: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // プレゼンテーションを読み取り専用で開きます。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 次のCountSlidesメソッドにプレゼンテーションを渡し

        // スライドの数を返します。

        return CountSlides(presentationDocument);

    }

}

// プレゼンテーション内のスライドをカウントします。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // nullのドキュメントオブジェクトを確認します。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // ドキュメントのプレゼンテーションパートを取得します。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlidePartsからスライドの数を取得します。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // スライドの数を前のメソッドに返します。

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // 最初のスライドのリレーションシップIDを取得します。

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // リレーションシップIDからスライドパートを取得します。

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // StringBuilderオブジェクトを構築します。

        StringBuilder paragraphText = new StringBuilder();

        // スライドの内部テキストを取得します:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20the%20titles%20of%20all%20the%20slides%20\(Aspose.Slides\).zip)