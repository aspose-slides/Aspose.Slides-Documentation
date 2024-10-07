---
title: Alle Texte in einer Folie abrufen
type: docs
weight: 110
url: /net/get-all-the-text-in-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Alle Texte in einer Folie abrufen.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Alle Texte in einer Folie abrufen.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Öffne die Präsentation im Nur-Lesen-Modus.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Übergebe die Präsentation und den Folienindex

        // an die nächste GetAllTextInSlide-Methode und

        // gebe dann das Array von Zeichenfolgen zurück, das sie zurückgibt. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Überprüfe, ob das Präsentationsdokument existiert.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Überprüfe, ob der Folienindex im gültigen Bereich ist.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Hole den Präsentationsteil des Präsentationsdokuments.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Überprüfe, ob der Präsentationsteil und die Präsentation existieren.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Hole das Präsentationsobjekt aus dem Präsentationsteil.

        Presentation presentation = presentationPart.Presentation;

        // Überprüfe, ob die Folien-ID-Liste existiert.

        if (presentation.SlideIdList != null)

        {

            // Hole die Sammlung von Folien-IDs aus der Folien-ID-Liste.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Wenn die Folien-ID im gültigen Bereich ist...

            if (slideIndex < slideIds.Count)

            {

                // Hole die Beziehungs-ID der Folie.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Hole den angegebenen Folienteil aus der Beziehungs-ID.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Übergebe den Folienteil an die nächste Methode und

                // gebe dann das Array von Zeichenfolgen zurück, das diese Methode

                // an die vorherige Methode zurückgibt.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Andernfalls null zurückgeben.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Überprüfe, ob der Folienteil existiert.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Erstelle eine neue verkettete Liste von Zeichenfolgen.

    LinkedList<string> texts = new LinkedList<string>();

    // Wenn die Folie existiert...

    if (slidePart.Slide != null)

    {

        // Iteriere durch alle Absätze in der Folie.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Erstelle einen neuen StringBuilder.                    

            StringBuilder paragraphText = new StringBuilder();

            // Iteriere durch die Zeilen des Absatzes.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Füge jede Zeile zu den vorherigen Zeilen hinzu.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Füge jeden Absatz zur verketteten Liste hinzu.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Gebe ein Array von Zeichenfolgen zurück.

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

string FileName = FilePath + "Alle Texte in einer Folie abrufen.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Alle Texte in einer Folie abrufen.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Erstelle eine neue verkettete Liste von Zeichenfolgen.

List<string> texts = new List<string>();

//Instanziiere die PresentationEx-Klasse, die PPTX darstellt.

using (Presentation pres = new Presentation(presentationFile))

{

    //Greife auf die Folie zu.

    ISlide sld = pres.Slides[slideIndex];

    //Iteriere durch die Formen, um den Platzhalter zu finden.

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //hole den Text von jedem Platzhalter.

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Gebe ein Array von Zeichenfolgen zurück.

return texts;

}

``` 
## **Download Beispielcode**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Alle%20Texte%20in%20einer%20Folie%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Alle%20Texte%20in%20einer%20Folie%20\(Aspose.Slides\).zip)