---
title: Pobierz cały tekst ze wszystkich slajdów
type: docs
weight: 100
url: /pl/net/get-all-the-text-in-all-the-slides/
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

    // Otwórz prezentację w trybie tylko do odczytu.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Przekaż prezentację do kolejnej metody CountSlides

        // i zwróć liczbę slajdów.

        return CountSlides(presentationDocument);

    }

}

// Policz slajdy w prezentacji.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Sprawdź, czy obiekt dokumentu jest null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Pobierz część prezentacji dokumentu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Pobierz liczbę slajdów z SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Zwróć liczbę slajdów do poprzedniej metody.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Pobierz identyfikator relacji pierwszego slajdu.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Pobierz część slajdu na podstawie identyfikatora relacji.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Zbuduj obiekt StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Pobierz wewnętrzny tekst slajdu:

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

    //Utwórz instancję klasy PresentationEx, która reprezentuje PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //Utwórz instancję klasy PresentationEx, która reprezentuje PPTX

    using (Presentation pres = new Presentation(docName))

    {

        //Uzyskaj dostęp do slajdu

        ISlide sld = pres.Slides[index];

        //Iteruj po kształtach, aby znaleźć placeholder

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //pobierz tekst każdego placeholdera

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)