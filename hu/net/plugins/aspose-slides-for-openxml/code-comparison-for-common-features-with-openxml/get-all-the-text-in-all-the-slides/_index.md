---
title: Az összes szöveg lekérése az összes diából
type: docs
weight: 100
url: /hu/net/get-all-the-text-in-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // A bemutató megnyitása csak olvasásra.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // A bemutatót átadjuk a következő CountSlides metódusnak

        // és visszaadjuk a diák számát.

        return CountSlides(presentationDocument);

    }

}

// Számolja meg a diák számát a bemutatóban.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Ellenőrzi, hogy a dokumentumobjektum null-e.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Megkapja a dokumentum bemutató részét.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // A diák számát a SlideParts-ből szerzi meg.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Visszaadja a diák számát az előző metódusnak.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Lekéri az első dia kapcsolati azonosítóját.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // A kapcsolat azonosítóból lekéri a dia részt.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Létrehozza a StringBuilder objektumot.

        StringBuilder paragraphText = new StringBuilder();

        // Lekéri a dia belső szövegét:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // PPTX-et képviselő PresentationEx osztály példányosítása
    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    // PPTX-et képviselő PresentationEx osztály példányosítása
    using (Presentation pres = new Presentation(docName))

    {

        // A dia elérése
        ISlide sld = pres.Slides[index];

        // A helyőrző megtalálásához végigiterál a formákon
        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                // minden helyőrző szövegének lekérése
                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)