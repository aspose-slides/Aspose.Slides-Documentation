---
title: Hämta alla externa hyperlänkar i en presentation
type: docs
weight: 90
url: /sv/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **OpenXML-presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Returnerar alla externa hyperlänkar i bildspelens bilder.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Deklarera en lista med strängar.

List<string> ret = new List<string>();

// Öppna presentationsfilen som skrivskyddad.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Iterera genom alla bilddelar i presentationsdelen.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Iterera genom alla länkar i bilddelen.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Iterera genom alla externa relationer i bilddelen. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Om relations-ID matchar länkens ID...

                if (relation.Id.Equals(link.Id))

                {

                    // Lägg till URI:n för den externa relationen i listan med strängar.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Returnera listan med strängar.

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides för .NET låter utvecklare hantera hyperlänkar i en presentation på presentations-, bild- och textram-nivå. Klassen **IHyperlinkQueries** hjälper till att hantera hyperlänkar i en presentation.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Skapa ett Presentation-objekt som representerar en PPTX-fil

Presentation pres = new Presentation(FileName);

//Hämta hyperlänkarna från presentationen

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Ladda ner körande kodexempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)