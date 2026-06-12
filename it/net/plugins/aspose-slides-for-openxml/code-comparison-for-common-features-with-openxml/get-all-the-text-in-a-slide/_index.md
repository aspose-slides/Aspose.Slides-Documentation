---
title: Recupera tutto il testo in una diapositiva
type: docs
weight: 110
url: /it/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Ottieni tutto il testo in una diapositiva.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Apri la presentazione in modalità sola lettura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passa la presentazione e l'indice della diapositiva

        // al prossimo metodo GetAllTextInSlide, e

        // quindi restituisce l'array di stringhe restituito. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Verifica che il documento della presentazione esista.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Verifica che l'indice della diapositiva non sia fuori intervallo.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Ottieni la parte di presentazione del documento della presentazione.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Verifica che la parte di presentazione e la presentazione esistano.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Ottieni l'oggetto Presentation dalla parte di presentazione.

        Presentation presentation = presentationPart.Presentation;

        // Verifica che l'elenco degli ID delle diapositive esista.

        if (presentation.SlideIdList != null)

        {

            // Ottieni la collezione di ID delle diapositive dall'elenco degli ID.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Se l'ID della diapositiva è nell'intervallo...

            if (slideIndex < slideIds.Count)

            {

                // Ottieni l'ID di relazione della diapositiva.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Ottieni la parte della diapositiva specificata dall'ID di relazione.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Passa la parte della diapositiva al metodo successivo, e

                // quindi restituisce l'array di stringhe di quel metodo

                // restituito al metodo precedente.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Altrimenti, restituisci null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Verifica che la parte della diapositiva esista.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Crea una nuova lista collegata di stringhe.

    LinkedList<string> texts = new LinkedList<string>();

    // Se la diapositiva esiste...

    if (slidePart.Slide != null)

    {

        // Scorri tutti i paragrafi nella diapositiva.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Crea un nuovo StringBuilder.                    

            StringBuilder paragraphText = new StringBuilder();

            // Scorri le righe del paragrafo.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Aggiungi ogni riga alle righe precedenti.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Aggiungi ogni paragrafo alla lista collegata.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Restituisci un array di stringhe.

        return texts.ToArray();

    }

    else

    {

        // Restituisci null.

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

// Ottieni tutto il testo in una diapositiva.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Crea una nuova lista collegata di stringhe.

List<string> texts = new List<string>();

//Instanzia la classe PresentationEx che rappresenta PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    // Accedi alla diapositiva

    ISlide sld = pres.Slides[slideIndex];

    //Itera attraverso le forme per trovare il segnaposto

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //ottieni il testo di ogni segnaposto

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Restituisci un array di stringhe.

return texts;

}

``` 
## **Scarica il codice di esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)