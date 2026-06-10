---
title: Az összes külső hiperhivatkozás lekérése egy prezentációban
type: docs
weight: 90
url: /hu/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **OpenXML prezentáció**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Visszaadja egy prezentáció diáin lévő összes külső hiperhivatkozást.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Deklarál egy listát karakterláncokból.

List<string> ret = new List<string>();

// A prezentáció fájlt csak olvasásra nyitja meg.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Végigiterál a prezentáció rész összes diarészén.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Végigiterál a diarészben lévő összes hivatkozáson.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Végigiterál a diarészben lévő összes külső kapcsolat elemen. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Ha a kapcsolat azonosítója egyezik a hivatkozás azonosítójával...

                if (relation.Id.Equals(link.Id))

                {

                    // Hozzáadja a külső kapcsolat URI-ját a karakterláncok listájához.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Visszaadja a karakterláncok listáját.

return ret;

}


``` 
## **Aspose.Slides**
Az Aspose.Slides for .NET lehetővé teszi a fejlesztők számára, hogy a hiperhivatkozásokat a prezentációban, dián és szövegdoboz szinten kezeljék. A **IHyperlinkQueries** osztály segít a hiperhivatkozások kezelésében egy prezentációban.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Példányosít egy Presentation objektumot, amely egy PPTX fájlt reprezentál
Presentation pres = new Presentation(FileName);

//A prezentációból lekéri a hiperhivatkozásokat
IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Futtatható kódpélda letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Minta kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)