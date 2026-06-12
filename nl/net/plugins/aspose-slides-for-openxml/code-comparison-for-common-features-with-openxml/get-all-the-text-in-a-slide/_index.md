---
title: Alle tekst uit een dia halen
type: docs
weight: 110
url: /nl/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Haal alle tekst uit een dia.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Open de presentatie in alleen-lezen modus.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Geef de presentatie en de dia‑index door

        // naar de volgende GetAllTextInSlide‑methode, en

        // en retourneer vervolgens de door die methode geretourneerde array van strings.

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Controleer of het presentatiedocument bestaat.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Controleer of de dia‑index niet buiten het bereik ligt.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Haal het presentatiedeel van het presentatiedocument op.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Controleer of het presentatiedeel en de presentatie bestaan.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Haal het Presentation‑object op uit het presentatiedeel.

        Presentation presentation = presentationPart.Presentation;

        // Controleer of de lijst met dia‑ID’s bestaat.

        if (presentation.SlideIdList != null)

        {

            // Haal de collectie van dia‑ID’s op uit de lijst met dia‑ID’s.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Als de dia‑ID binnen bereik is...

            if (slideIndex < slideIds.Count)

            {

                // Haal de relatie‑ID van de dia op.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Haal het opgegeven diadeel op via de relatie‑ID.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Geef het diadeel door aan de volgende methode, en

                // retourneer vervolgens de array van strings die die methode

                // teruggeeft aan de vorige methode.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Anders, retourneer null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Controleer of het diadeel bestaat.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Maak een nieuwe gekoppelde lijst van strings aan.

    LinkedList<string> texts = new LinkedList<string>();

    // Als de dia bestaat...

    if (slidePart.Slide != null)

    {

        // Doorloop alle alinea’s in de dia.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Maak een nieuwe StringBuilder aan.                    

            StringBuilder paragraphText = new StringBuilder();

            // Doorloop de regels van de alinea.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Voeg elke regel toe aan de voorgaande regels.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Voeg elke alinea toe aan de gekoppelde lijst.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Retourneer een array van strings.

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Haal alle tekst uit een dia.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Maak een nieuwe gekoppelde lijst van strings aan.

List<string> texts = new List<string>();

//Instantieer PresentationEx class that represents PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    //Toegang tot de dia

    ISlide sld = pres.Slides[slideIndex];

    //Doorloop de vormen om de placeholder te vinden

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //Haal de tekst van elke placeholder op

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Retourneer een array van strings.

return texts;

}

``` 
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)