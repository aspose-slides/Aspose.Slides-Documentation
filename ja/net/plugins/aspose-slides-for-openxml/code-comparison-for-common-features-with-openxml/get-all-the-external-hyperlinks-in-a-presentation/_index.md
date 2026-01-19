---
title: プレゼンテーション内のすべての外部ハイパーリンクを取得
type: docs
weight: 90
url: /ja/net/get-all-the-external-hyperlinks-in-a-presentation/
---

## **OpenXML プレゼンテーション**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Returns all the external hyperlinks in the slides of a presentation.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Declare a list of strings.

List<string> ret = new List<string>();

// Open the presentation file as read-only.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Iterate through all the slide parts in the presentation part.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Iterate through all the links in the slide part.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Iterate through all the external relationships in the slide part. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // If the relationship ID matches the link ID...

                if (relation.Id.Equals(link.Id))

                {

                    // Add the URI of the external relationship to the list of strings.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Return the list of strings.

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides for .NET は、プレゼンテーション、スライド、テキスト フレーム レベルでハイパーリンクを管理できるように開発者に提供します。**IHyperlinkQueries** クラスは、プレゼンテーション内のハイパーリンクを管理するのに役立ちます。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Instantiate a Presentation object that represents a PPTX file

Presentation pres = new Presentation(FileName);

//Get the hyperlinks from presentation

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **コード例のダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **サンプルコード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)