---
title: Mover un párrafo de una presentación a otra
type: docs
weight: 130
url: /net/move-a-paragraph-from-one-presentation-to-another/
---

## **OpenXML Presentación**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Mover un párrafo de una presentación a otra 1.pptx";

string DestFileName = FilePath + "Mover un párrafo de una presentación a otra 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Mueve un rango de párrafos en una forma TextBody en el documento fuente

// a otra forma TextBody en el documento destino.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Abre el archivo fuente para lectura/escritura.

using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // Abre el archivo destino para lectura/escritura.

    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // Obtiene la primera diapositiva en la presentación fuente.

        SlidePart slide1 = GetFirstSlide(sourceDoc);

        // Obtiene la primera forma TextBody en ella.

        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

        // Obtiene el primer párrafo en la forma TextBody.

        // Nota: "Drawing" es el alias del espacio de nombres DocumentFormat.OpenXml.Drawing

        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // Obtiene la primera diapositiva en la presentación destino.

        SlidePart slide2 = GetFirstSlide(targetDoc);

        // Obtiene la primera forma TextBody en ella.

        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // Clona el párrafo fuente e inserta el párrafo clonado en la forma TextBody destino.

        // Pasar "true" crea un clon profundo, lo que crea una copia del

        // objeto Paragraph y todo lo que directa o indirectamente se referencia por ese objeto.

        textBody2.Append(p1.CloneNode(true));

        // Elimina el párrafo fuente del archivo fuente.

        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // Reemplaza el párrafo eliminado con un marcador de posición.

        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // Guarda la diapositiva en el archivo fuente.

        slide1.Slide.Save();

        // Guarda la diapositiva en el archivo destino.

        slide2.Slide.Save();

    }

}

}

// Obtiene la parte de la diapositiva de la primera diapositiva en el documento de presentación.

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Obtiene el ID de relación de la primera diapositiva

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Obtiene la parte de la diapositiva por el ID de relación.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}

```
## **Aspose.Slides**
No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para hacerlo, necesitas extraer texto de todas las formas en todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones PPTX de Microsoft PowerPoint utilizando Aspose.Slides. Ya sea extrayendo texto de una sola diapositiva o de toda una presentación, Aspose.Slides utiliza la Clase PresentationScanner y los métodos estáticos que expone. Todos están empaquetados bajo el espacio de nombres [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Mover un párrafo de una presentación a otra 1.pptx";

string DestFileName = FilePath + "Mover un párrafo de una presentación a otra 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Mueve un rango de párrafos en una forma TextBody en el documento fuente

// a otra forma TextBody en el documento destino.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Instanciar la clase Presentation que representa PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //Acceder a la primera forma en la primera diapositiva

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Obtener texto del marcador de posición

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Acceder a la primera forma en la primera diapositiva

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Obtener texto del marcador de posición

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   

``` 
## **Descargar Ejemplo de Código en Ejecución**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Código de Ejemplo**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Mover un párrafo/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)