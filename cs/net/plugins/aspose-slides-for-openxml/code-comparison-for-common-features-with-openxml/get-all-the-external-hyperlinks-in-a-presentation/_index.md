---
title: Získat všechny externí hypertextové odkazy v prezentaci
type: docs
weight: 90
url: /cs/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **OpenXML prezentace**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Vrátí všechny externí hypertextové odkazy na snímcích prezentace.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Deklaruje seznam řetězců.

List<string> ret = new List<string>();

// Otevře soubor prezentace jen pro čtení.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Prochází všechny části snímků v části prezentace.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Prochází všechny odkazy v části snímku.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Prochází všechny externí vztahy v části snímku. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Pokud se ID vztahu shoduje s ID odkazu...

                if (relation.Id.Equals(link.Id))

                {

                    // Přidá URI externího vztahu do seznamu řetězců.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Vrátí seznam řetězců.

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides pro .NET umožňuje vývojářům spravovat hypertextové odkazy v prezentaci na úrovni celé prezentace, snímku a textového rámce. Třída **IHyperlinkQueries** pomáhá spravovat hypertextové odkazy v prezentaci.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Vytvořte objekt Presentation, který představuje soubor PPTX

Presentation pres = new Presentation(FileName);

//Získá hypertextové odkazy z prezentace

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Stáhnout spuštěný příklad kódu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)