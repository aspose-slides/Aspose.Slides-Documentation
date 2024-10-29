---
title: すべてのスライドのすべてのテキストを取得する
type: docs
weight: 100
url: /ja/net/get-all-the-text-in-all-the-slides/
---

## **OpenXML SDK**
```csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

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

        // プレゼンテーションを次の CountSlides メソッドに渡し

        // スライドの数を返します。

        return CountSlides(presentationDocument);

    }

}

// プレゼンテーション内のスライドをカウントします。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // null ドキュメントオブジェクトをチェックします。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // ドキュメントのプレゼンテーションパートを取得します。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts からスライドの数を取得します。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // スライドの数を前のメソッドに戻します。

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

        // StringBuilder オブジェクトを構築します。

        StringBuilder paragraphText = new StringBuilder();

        // スライドの内部テキストを取得します：

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Aspose.Slides**
```csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("スライドの数 = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("スライド #{0} には次が含まれます: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //PresentationEx クラスのインスタンスを生成し、PPTX を表します

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //PresentationEx クラスのインスタンスを生成し、PPTX を表します

    using (Presentation pres = new Presentation(docName))

    {

        // スライドにアクセスします

        ISlide sld = pres.Slides[index];

        // プレースホルダーを見つけるために形状を反復します

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                // 各プレースホルダーのテキストを取得します

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20all%20the%20text%20in%20all%20slides%20\(Aspose.Slides\).zip)