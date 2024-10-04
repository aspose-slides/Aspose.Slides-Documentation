---
title: Obtener los títulos de todas las diapositivas
type: docs
weight: 120
url: /es/net/get-the-titles-of-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtener los títulos de todas las diapositivas.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Obtener una lista de los títulos de todas las diapositivas en la presentación.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Abrir la presentación en modo solo lectura.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Obtener una lista de los títulos de todas las diapositivas en la presentación.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Obtener un objeto PresentationPart del objeto PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Obtener un objeto Presentation del objeto PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Obtener el título de cada diapositiva en el orden de las diapositivas.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Obtener el título de la diapositiva.

                string title = GetSlideTitle(slidePart);

                // También se puede añadir un título vacío.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Obtener el texto del título de la diapositiva.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Declarar un separador de párrafos.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Encontrar todas las formas de título.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Obtener el texto en cada párrafo en esta forma.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Añadir un salto de línea.

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// Determina si la forma es una forma de título.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Cualquier forma de título.

            case PlaceholderValues.Title:

            // Un título centrado.

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtener todo el texto en una diapositiva.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Número de diapositivas = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Diapositiva #{0} contiene: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Abrir la presentación en modo solo lectura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Pasar la presentación al siguiente método CountSlides

        // y devolver el recuento de diapositivas.

        return CountSlides(presentationDocument);

    }

}

// Contar las diapositivas en la presentación.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Comprobar si el objeto documento es nulo.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtener la parte de presentación del documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtener el recuento de diapositivas de los SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Devolver el recuento de diapositivas al método anterior.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Obtener el ID de relación de la primera diapositiva.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Obtener la parte de diapositiva del ID de relación.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Construir un objeto StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Obtener el texto interno de la diapositiva:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Descargar Código de Ejemplo**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Obtener%20los%20títulos%20de%20todas%20las%20diapositivas%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Obtener%20los%20títulos%20de%20todas%20las%20diapositivas%20\(Aspose.Slides\).zip)