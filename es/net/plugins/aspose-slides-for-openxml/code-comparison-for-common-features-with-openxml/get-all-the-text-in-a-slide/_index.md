---
title: Obtener todo el texto en una diapositiva
type: docs
weight: 110
url: /es/net/get-all-the-text-in-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtener todo el texto en una diapositiva.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Obtener todo el texto en una diapositiva.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Abrir la presentación como solo lectura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Pasar la presentación y el índice de la diapositiva

        // al siguiente método GetAllTextInSlide, y

        // luego devolver el array de cadenas que devuelve. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Verificar que el documento de presentación exista.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Verificar que el índice de la diapositiva no esté fuera de rango.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Obtener la parte de presentación del documento de presentación.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Verificar que la parte de presentación y la presentación existan.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Obtener el objeto Presentation de la parte de presentación.

        Presentation presentation = presentationPart.Presentation;

        // Verificar que la lista de ID de diapositivas exista.

        if (presentation.SlideIdList != null)

        {

            // Obtener la colección de IDs de diapositivas de la lista de ID de diapositivas.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Si el ID de la diapositiva está en rango...

            if (slideIndex < slideIds.Count)

            {

                // Obtener el ID de relación de la diapositiva.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Obtener la parte de diapositiva especificada del ID de relación.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Pasar la parte de la diapositiva al siguiente método, y

                // luego devolver el array de cadenas que ese método

                // devuelve al método anterior.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Si no, devolver null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Verificar que la parte de la diapositiva exista.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Crear una nueva lista enlazada de cadenas.

    LinkedList<string> texts = new LinkedList<string>();

    // Si la diapositiva existe...

    if (slidePart.Slide != null)

    {

        // Iterar a través de todos los párrafos en la diapositiva.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Crear un nuevo StringBuilder.                    

            StringBuilder paragraphText = new StringBuilder();

            // Iterar a través de las líneas del párrafo.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Adjuntar cada línea a las líneas anteriores.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Agregar cada párrafo a la lista enlazada.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Devolver un array de cadenas.

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

string FileName = FilePath + "Obtener todo el texto en una diapositiva.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Obtener todo el texto en una diapositiva.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Crear una nueva lista enlazada de cadenas.

List<string> texts = new List<string>();

//Instanciar la clase PresentationEx que representa PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    //Acceder a la diapositiva

    ISlide sld = pres.Slides[slideIndex];

    //Iterar a través de las formas para encontrar el marcador de posición

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //obtener el texto de cada marcador de posición

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Devolver un array de cadenas.

return texts;

}

``` 
## **Descargar Código de Ejemplo**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Obtener%20todo%20el%20texto%20en%20una%20diapositiva%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Obtener%20todo%20el%20texto%20en%20una%20diapositiva%20\(Aspose.Slides\).zip)