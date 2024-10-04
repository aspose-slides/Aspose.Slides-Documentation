---
title: Cambiar el color de relleno de una forma en una presentación
type: docs
weight: 40
url: /net/change-the-fill-color-of-a-shape-in-a-presentation/
---

## **Presentación OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Archivo de Muestra\";

string FileName = FilePath + "Color de relleno de una forma.pptx";

SetPPTShapeColor(FileName);

// Cambiar el color de relleno de una forma.

// El archivo de prueba debe tener una forma rellena como la primera forma en la primera diapositiva.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Obtener el ID de relación de la primera diapositiva.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Obtener la parte de la diapositiva a partir del ID de relación.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Obtener el árbol de formas que contiene la forma a cambiar.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Obtener la primera forma en el árbol de formas.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Obtener el estilo de la forma.

                ShapeStyle style = shape.ShapeStyle;

                // Obtener la referencia de relleno.

                Drawing.FillReference fillRef = style.FillReference;

                // Establecer el color de relleno en SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Guardar la diapositiva modificada.

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
Necesitamos seguir los siguientes pasos para rellenar las formas en la presentación:

- Crear una instancia de la clase Presentation.
- Obtener la referencia de una diapositiva usando su índice.
- Agregar un IShape a la diapositiva.
- Establecer el tipo de relleno de la forma a Sólido.
- Establecer el color de la forma.
- Escribir la presentación modificada como un archivo PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Archivo de Muestra\";

string FileName = FilePath + "Color de relleno de una forma.pptx";

// Instanciar la clase PresentationEx que representa el PPTX 

using (Presentation pres = new Presentation())

{

    // Obtener la primera diapositiva

    ISlide sld = pres.Slides[0];

    // Agregar una forma automática de tipo rectángulo

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Establecer el tipo de relleno a Sólido

    shp.FillFormat.FillType = FillType.Solid;

    // Establecer el color del rectángulo

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Escribir el archivo PPTX en disco

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Descargar Ejemplo de Código en Ejecución**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Código de Ejemplo**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Apply Theme to Presentation/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)