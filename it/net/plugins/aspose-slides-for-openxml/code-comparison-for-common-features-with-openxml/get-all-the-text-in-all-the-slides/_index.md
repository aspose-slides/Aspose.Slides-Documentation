---
title: Ottieni tutto il testo in tutte le diapositive
type: docs
weight: 100
url: /it/net/get-all-the-text-in-all-the-slides/
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

    // Apri la presentazione in sola lettura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passa la presentazione al successivo metodo CountSlides

        // e restituisce il conteggio delle diapositive.

        return CountSlides(presentationDocument);

    }

}

// Conta le diapositive nella presentazione.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Verifica se l'oggetto documento è nullo.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Ottieni la parte di presentazione del documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ottieni il conteggio delle diapositive dai SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Restituisci il conteggio delle diapositive al metodo precedente.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Ottieni l'ID di relazione della prima diapositiva.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Ottieni la parte della diapositiva dall'ID di relazione.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Crea un oggetto StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Ottieni il testo interno della diapositiva:

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

    //Instanzia la classe PresentationEx che rappresenta PPTX
    using (Presentation pres = new Presentation(presentationFile))
    {
        return pres.Slides.Count;
    }

}

public static string GetSlideText(string docName, int index)

{
    string sldText = "";
    //Instanzia la classe PresentationEx che rappresenta PPTX
    using (Presentation pres = new Presentation(docName))
    {
        //Accedi alla diapositiva
        ISlide sld = pres.Slides[index];
        //Itera attraverso le forme per trovare il segnaposto
        foreach (Shape shp in sld.Shapes)
            if (shp.Placeholder != null)
            {
                //ottieni il testo di ogni segnaposto
                sldText += ((AutoShape)shp).TextFrame.Text;
            }
    }
    return sldText;
}

``` 
## **Scarica Codice Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)