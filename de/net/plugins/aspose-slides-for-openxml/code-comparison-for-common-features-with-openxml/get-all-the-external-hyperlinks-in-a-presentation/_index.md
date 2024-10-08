---
title: Alle externen Hyperlinks in einer Präsentation abrufen
type: docs
weight: 90
url: /de/net/get-all-the-external-hyperlinks-in-a-presentation/
---

## **OpenXML-Präsentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Alle externen Hyperlinks abrufen.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Gibt alle externen Hyperlinks in den Folien einer Präsentation zurück.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Eine Liste von Zeichenfolgen deklarieren.

List<string> ret = new List<string>();

// Die Präsentationsdatei schreibgeschützt öffnen.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Durch alle Folienteile im Präsentationsteil iterieren.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Durch alle Links im Folienteil iterieren.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Durch alle externen Beziehungen im Folienteil iterieren. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Wenn die Beziehungs-ID mit der Link-ID übereinstimmt...

                if (relation.Id.Equals(link.Id))

                {

                    // Füge die URI der externen Beziehung zur Liste der Zeichenfolgen hinzu.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Die Liste der Zeichenfolgen zurückgeben.

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides für .NET ermöglicht Entwicklern, die Hyperlinks in der Präsentation auf der Ebene von Präsentation, Folie und Textfeld zu verwalten. Die **IHyperlinkQueries**-Klasse hilft bei der Verwaltung von Hyperlinks in einer Präsentation.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Alle externen Hyperlinks abrufen.pptx";

//Ein Präsentationsobjekt instanziieren, das eine PPTX-Datei darstellt

Presentation pres = new Presentation(FileName);

//Die Hyperlinks aus der Präsentation abrufen

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Laden Sie das laufende Codebeispiel herunter**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Beispielcode**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Alle externen Hyperlinks abrufen/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Alle%20externen%20Hyperlinks%20abrufen)