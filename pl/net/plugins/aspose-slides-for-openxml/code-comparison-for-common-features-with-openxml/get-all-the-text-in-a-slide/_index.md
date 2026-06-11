---
title: Pobierz cały tekst ze slajdu
type: docs
weight: 110
url: /pl/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Pobierz cały tekst ze slajdu.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Otwórz prezentację w trybie tylko do odczytu.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Przekaż prezentację i indeks slajdu

        // do następnej metody GetAllTextInSlide, i

        // a następnie zwróć tablicę łańcuchów, którą ona zwraca. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Sprawdź, czy dokument prezentacji istnieje.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Sprawdź, czy indeks slajdu nie jest poza zakresem.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Pobierz część prezentacji z dokumentu prezentacji.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Sprawdź, czy część prezentacji i prezentacja istnieją.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Pobierz obiekt Presentation z części prezentacji.

        Presentation presentation = presentationPart.Presentation;

        // Sprawdź, czy lista identyfikatorów slajdów istnieje.

        if (presentation.SlideIdList != null)

        {

            // Pobierz kolekcję identyfikatorów slajdów z listy identyfikatorów slajdów.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Jeśli identyfikator slajdu jest w zakresie...

            if (slideIndex < slideIds.Count)

            {

                // Pobierz identyfikator relacji slajdu.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Pobierz określoną część slajdu za pomocą identyfikatora relacji.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Przekaż część slajdu do następnej metody, i

                // a następnie zwróć tablicę łańcuchów, którą metoda

                // zwraca poprzedniej metodzie.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Inaczej zwróć null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Sprawdź, czy część slajdu istnieje.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Utwórz nową listę powiązaną łańcuchów.

    LinkedList<string> texts = new LinkedList<string>();

    // Jeśli slajd istnieje...

    if (slidePart.Slide != null)

    {

        // Iteruj przez wszystkie akapity w slajdzie.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Utwórz nowy StringBuilder.                    

            StringBuilder paragraphText = new StringBuilder();

            // Iteruj przez wiersze akapitu.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Dołącz każdy wiersz do poprzednich.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Dodaj każdy akapit do listy powiązanej.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Zwróć tablicę łańcuchów.

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

// Pobierz cały tekst ze slajdu.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Utwórz nową listę powiązaną łańcuchów.

List<string> texts = new List<string>();

//Zainstancjuj klasę PresentationEx reprezentującą PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    //Uzyskaj dostęp do slajdu

    ISlide sld = pres.Slides[slideIndex];

    //Iteruj przez kształty, aby znaleźć placeholder

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //pobierz tekst każdego placeholdera

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Zwróć tablicę łańcuchów.

return texts;

}

``` 
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)