---
title: Alle externe hyperlinks in een presentatie ophalen
type: docs
weight: 90
url: /nl/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **OpenXML-presentatie**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Retourneert alle externe hyperlinks in de dia's van een presentatie.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Declareer een lijst met strings.

List<string> ret = new List<string>();

// Open het presentatiebestand als alleen-lezen.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Itereer door alle slide‑onderdelen in het presentatiedeel.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Itereer door alle koppelingen in het slide‑onderdeel.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Itereer door alle externe relaties in het slide‑onderdeel. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Als de relatie‑ID overeenkomt met de link‑ID...

                if (relation.Id.Equals(link.Id))

                {

                    // Voeg de URI van de externe relatie toe aan de lijst met strings.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Retourneer de lijst met strings.

return ret;

}
``` 
## **Aspose.Slides**
Aspose.Slides voor .NET stelt ontwikkelaars in staat om de hyperlinks in een presentatie te beheren op presentatie-, dia- en tekstkaderniveau. De **IHyperlinkQueries**-klasse helpt bij het beheren van hyperlinks in een presentatie.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Instantieer een Presentation-object dat een PPTX-bestand vertegenwoordigt

Presentation pres = new Presentation(FileName);

//Get the hyperlinks from presentation

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)