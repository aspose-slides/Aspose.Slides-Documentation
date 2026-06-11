---
title: Hämta all text i en bild
type: docs
weight: 110
url: /sv/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Hämta all text i en bild.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Öppna presentationen som skrivskyddad.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Skicka presentationen och bildindexet

        // till nästa GetAllTextInSlide‑metod, och

        // returnera sedan arrayen med strängar som den returnerar. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Verifiera att presentationsdokumentet finns.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Verifiera att bildindexet inte är utanför intervallet.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Hämta presentationsdelen av presentationsdokumentet.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Verifiera att presentationsdelen och presentationen finns.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Hämta Presentation‑objektet från presentationsdelen.

        Presentation presentation = presentationPart.Presentation;

        // Verifiera att listan med bild‑ID:n finns.

        if (presentation.SlideIdList != null)

        {

            // Hämta samlingen av bild‑ID:n från bild‑ID‑listan.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Om bild‑ID:n är inom intervallet...

            if (slideIndex < slideIds.Count)

            {

                // Hämta relations‑ID för bilden.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Hämta den angivna bilddelen från relations‑ID:n.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Skicka bilddelen till nästa metod, och

                // returnera sedan arrayen med strängar som den metoden

                // returnerar till föregående metod.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Annars, returnera null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Verifiera att bilddelen finns.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Skapa en ny länkad lista med strängar.

    LinkedList<string> texts = new LinkedList<string>();

    // Om bilden finns...

    if (slidePart.Slide != null)

    {

        // Iterera genom alla stycken i bilden.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Skapa en ny StringBuilder.                    

            StringBuilder paragraphText = new StringBuilder();

            // Iterera genom raderna i stycket.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Lägg till varje rad till de tidigare raderna.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Lägg till varje stycke i den länkade listan.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Returnera en array med strängar.

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

// Hämta all text i en bild.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Skapa en ny länkad lista med strängar.

List<string> texts = new List<string>();

//Instansiera PresentationEx‑klassen som representerar PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    //Åtkomst till bilden

    ISlide sld = pres.Slides[slideIndex];

    //Iterera genom former för att hitta platshållaren

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //hämta texten för varje platshållare

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Returnera en array med strängar.

return texts;

}

``` 
## **Ladda ner exempel på kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)