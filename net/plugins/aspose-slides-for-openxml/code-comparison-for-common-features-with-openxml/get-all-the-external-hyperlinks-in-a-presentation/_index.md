---
title: Get all the external hyperlinks in a presentation
type: docs
weight: 90
url: /net/get-all-the-external-hyperlinks-in-a-presentation/
---

## **OpenXML Presentation**
{{< highlight csharp >}}

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


{{< /highlight >}}
## **Aspose.Slides**
Aspose.Slides for .NET allows developers to manage the hyperlinks in presentation on the presentation, slide and text frame level.The **IHyperlinkQueries** class helps to manage hyperlinks in a presentation.

{{< highlight csharp >}}

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Instantiate a Presentation object that represents a PPTX file

Presentation pres = new Presentation(FileName);

//Get the hyperlinks from presentation

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

{{< /highlight >}}
## **Download Running Code Example**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Sample Code**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Get all the External Hyperlinks/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)
