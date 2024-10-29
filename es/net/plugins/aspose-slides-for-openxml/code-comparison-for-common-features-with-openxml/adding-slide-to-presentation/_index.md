---
title: Agregar diapositiva a la presentación
type: docs
weight: 20
url: /es/net/adding-slide-to-presentation/
---

## **Presentación OpenXML**
En la funcionalidad a continuación, por defecto se agrega una diapositiva a la presentación. Aquí estamos agregando una nueva diapositiva en el índice 2 que tiene algo de texto.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Agregar diapositiva a la presentación.pptx";

InsertNewSlide(FileName, 1, "Mi nueva diapositiva");

// Insertar una diapositiva en la presentación especificada.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Abrir el documento fuente como lectura/escritura. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Pasar el documento fuente y la posición y título de la diapositiva que se va a insertar al siguiente método.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Insertar la diapositiva especificada en la presentación en la posición especificada.

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Verificar que la presentación no esté vacía.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("El documento de presentación está vacío.");

    }

    // Declarar e instanciar una nueva diapositiva.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Construir el contenido de la diapositiva.            

    // Especificar las propiedades no visuales de la nueva diapositiva.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Especificar las propiedades del grupo de la nueva diapositiva.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Declarar e instanciar la forma del título de la nueva diapositiva.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Especificar las propiedades requeridas de la forma para la forma del título. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Título" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Especificar el texto de la forma del título.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Declarar e instanciar la forma del cuerpo de la nueva diapositiva.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Especificar las propiedades requeridas de la forma para la forma del cuerpo.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Marcador de posición de contenido" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Especificar el texto de la forma del cuerpo.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Crear la parte de la diapositiva para la nueva diapositiva.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Guardar la nueva parte de la diapositiva.

    slide.Save(slidePart);

    // Modificar la lista de ID de diapositivas en la parte de presentación.

    // La lista de ID de diapositivas no debe ser nula.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Encontrar el ID de diapositiva más alto en la lista actual.

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // Obtener el ID de la diapositiva anterior.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Usar el mismo diseño de diapositiva que el de la diapositiva anterior.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Insertar la nueva diapositiva en la lista de diapositivas después de la diapositiva anterior.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Guardar la presentación modificada.

    presentationPart.Presentation.Save();

}

}

``` 
## **Aspose.Slides**
Cada archivo de presentación de PowerPoint contiene una **Diapositiva Maestra Principal** y otras **Diapositivas Normales**. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides para .NET. Cada diapositiva tiene una posición específica y un **Id único**. El **Id de la diapositiva** puede variar de 0 a 255 para las diapositivas maestras y de 256 a 65535 para las diapositivas normales.

Aspose.Slides para .NET permite a los desarrolladores agregar diapositivas vacías a las presentaciones utilizando el método **AddEmptySlide** expuesto por el objeto **Presentation**. Para agregar una diapositiva vacía en la presentación, siga los pasos a continuación:

- Crear una instancia de la clase Presentation
- Llamar al método AddEmptySlide expuesto por el objeto Presentation
- Realizar algún trabajo con la nueva diapositiva vacía añadida
- Agregar otra diapositiva e insertar texto en ella.
- Finalmente, escribir el archivo PPT utilizando el método Write expuesto por el objeto Presentation

``` csharp

 string FileName = FilePath + "Agregar diapositiva a la presentación.pptx";

//Instanciar la clase PresentationEx que representa el archivo PPT

Presentation pres = new Presentation();

//Se añade una diapositiva en blanco por defecto, al crear

//presentación desde el constructor por defecto

//Agregar una diapositiva vacía a la presentación y obtener la referencia de

//esa diapositiva vacía

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Escribir la salida en el disco

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Descargar Código de Ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)