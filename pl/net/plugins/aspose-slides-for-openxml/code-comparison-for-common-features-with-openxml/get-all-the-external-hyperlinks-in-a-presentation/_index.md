---
title: Pobierz wszystkie zewnętrzne hiperłącza w prezentacji
type: docs
weight: 90
url: /pl/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **Prezentacja OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Zwraca wszystkie zewnętrzne hiperłącza w slajdach prezentacji.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Deklaruj listę łańcuchów znaków.

List<string> ret = new List<string>();

// Otwórz plik prezentacji w trybie tylko do odczytu.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Iteruj po wszystkich częściach slajdów w części prezentacji.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Iteruj po wszystkich linkach w części slajdu.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Iteruj po wszystkich zewnętrznych relacjach w części slajdu. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Jeśli identyfikator relacji jest zgodny z identyfikatorem linku...

                if (relation.Id.Equals(link.Id))

                {

                    // Dodaj URI zewnętrznej relacji do listy łańcuchów znaków.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Zwróć listę łańcuchów znaków.

return ret;

}
``` 
## **Aspose.Slides**
Aspose.Slides dla .NET umożliwia programistom zarządzanie hiperłączami w prezentacji na poziomie prezentacji, slajdu i ramki tekstowej. Klasa **IHyperlinkQueries** pomaga zarządzać hiperłączami w prezentacji.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Utwórz obiekt Presentation, który reprezentuje plik PPTX

Presentation pres = new Presentation(FileName);

//Pobierz hiperłącza z prezentacji

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Pobierz działający przykład kodu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)