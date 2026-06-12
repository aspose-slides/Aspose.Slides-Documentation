---
title: Ottieni tutti i collegamenti ipertestuali esterni in una presentazione
type: docs
weight: 90
url: /it/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **Presentazione OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Restituisce tutti i collegamenti ipertestuali esterni nelle diapositive di una presentazione.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Dichiarare una lista di stringhe.

List<string> ret = new List<string>();

// Apri il file della presentazione in sola lettura.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Scorri tutte le parti delle diapositive nella parte della presentazione.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Scorri tutti i collegamenti nella parte della diapositiva.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Scorri tutte le relazioni esterne nella parte della diapositiva. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Se l'ID della relazione corrisponde all'ID del collegamento...

                if (relation.Id.Equals(link.Id))

                {

                    // Aggiungi l'URI della relazione esterna alla lista di stringhe.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Restituisci la lista di stringhe.

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides per .NET consente agli sviluppatori di gestire i collegamenti ipertestuali nella presentazione a livello di presentazione, diapositiva e riquadro di testo. La classe **IHyperlinkQueries** aiuta a gestire i collegamenti ipertestuali in una presentazione.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Istanzia un oggetto Presentation che rappresenta un file PPTX

Presentation pres = new Presentation(FileName);

//Ottieni i collegamenti ipertestuali dalla presentazione

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Scarica esempio di codice in esecuzione**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Esempio di codice**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)