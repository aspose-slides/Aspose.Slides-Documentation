---
title: Az összes szöveg lekérése egy dián
type: docs
weight: 110
url: /hu/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Az összes szöveg lekérése egy dián.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // A bemutatót csak olvasásra nyitja meg.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Átadja a bemutatót és a dia indexet
        // a következő GetAllTextInSlide metódusnak, és
        // majd visszaadja a visszakapott karakterlánc tömböt. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Ellenőrzi, hogy a bemutató dokumentum létezik-e.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Ellenőrzi, hogy a dia index nem esik-e a tartományon kívül.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Lekéri a bemutató részét a bemutató dokumentumból.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ellenőrzi, hogy a bemutató rész és a bemutató léteznek-e.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Lekéri a Presentation objektumot a bemutató részből.

        Presentation presentation = presentationPart.Presentation;

        // Ellenőrzi, hogy a dia ID lista létezik-e.

        if (presentation.SlideIdList != null)

        {

            // Lekéri a dia ID-k gyűjteményét a dia ID listából.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Ha a dia ID a tartományon belül van...

            if (slideIndex < slideIds.Count)

            {

                // Lekéri a dia kapcsolati azonosítóját.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Lekéri a megadott dia részt a kapcsolati azonosítóból.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Átadja a dia részt a következő metódusnak, és

                // majd visszaadja a karakterláncok tömbjét, amely metódus

                // visszatér az előző metódushoz.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Egyébként, null-t ad vissza.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Ellenőrzi, hogy a dia rész létezik-e.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Létrehoz egy új láncolt listát karakterláncokból.

    LinkedList<string> texts = new LinkedList<string>();

    // Ha a dia létezik...

    if (slidePart.Slide != null)

    {

        // Végigiterál az összes bekezdésen a dián.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Létrehoz egy új StringBuilder-t.                    

            StringBuilder paragraphText = new StringBuilder();

            // Végigiterál a bekezdés sorain.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Hozzáfűzi minden sort az előző sorokhoz.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Hozzáadja minden bekezdést a láncolt listához.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Visszaad egy karakterlánc tömböt.

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

// Az összes szöveg lekérése egy dián.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Új karakterláncok láncolt listájának létrehozása.

List<string> texts = new List<string>();

//PPTX-et képviselő PresentationEx osztály példányosítása.

using (Presentation pres = new Presentation(presentationFile))

{

    //A dia elérése.

    ISlide sld = pres.Slides[slideIndex];

    //Iterál a formákon a helyfoglaló megtalálásához.

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //A helyfoglaló szövegének lekérése.

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Visszaad egy karakterlánc tömböt.

return texts;

}

``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)