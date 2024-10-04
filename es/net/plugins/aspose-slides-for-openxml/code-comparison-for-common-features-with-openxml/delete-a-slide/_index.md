---
title: Eliminar una Diapositiva
type: docs
weight: 80
url: /net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Eliminar una diapositiva.pptx";

DeleteSlide(FileName, 1);

// Obtener el objeto de presentación y pasarlo al siguiente método DeleteSlide.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Abrir el documento fuente en modo lectura/escritura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Pasar el documento fuente y el índice de la diapositiva a eliminar al siguiente método DeleteSlide.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Eliminar la diapositiva especificada de la presentación.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Usar el ejemplo CountSlides para obtener el número de diapositivas en la presentación.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Obtener la parte de presentación del documento de presentación. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtener la presentación de la parte de presentación.

    Presentation presentation = presentationPart.Presentation;

    // Obtener la lista de IDs de diapositivas en la presentación.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Obtener el ID de la diapositiva especificada

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Obtener el ID de relación de la diapositiva.

    string slideRelId = slideId.RelationshipId;

    // Eliminar la diapositiva de la lista de diapositivas.

    slideIdList.RemoveChild(slideId);

    //

    // Eliminar referencias a la diapositiva de todas las presentaciones personalizadas.

    if (presentation.CustomShowList != null)

    {

        // Iterar a través de la lista de presentaciones personalizadas.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Declarar una lista enlazada de entradas de lista de diapositivas.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Encontrar la referencia de la diapositiva a eliminar de la presentación personalizada.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Eliminar todas las referencias a la diapositiva de la presentación personalizada.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Guardar la presentación modificada.

    presentation.Save();

    // Obtener la parte de la diapositiva para la diapositiva especificada.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Eliminar la parte de la diapositiva.

    presentationPart.DeletePart(slidePart);

}

// Obtener el objeto de presentación y pasarlo al siguiente método CountSlides.

public static int CountSlides(string presentationFile)

{

    // Abrir la presentación en solo lectura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Pasar la presentación al siguiente método CountSlide

        // y devolver el conteo de diapositivas.

        return CountSlides(presentationDocument);

    }

}

// Contar las diapositivas en la presentación.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Verificar si el objeto documento es nulo.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtener la parte de presentación del documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtener el conteo de diapositivas de las SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Devolver el conteo de diapositivas al método anterior.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Eliminar una diapositiva.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Instanciar un objeto PresentationEx que representa un archivo PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Accediendo a una diapositiva usando su índice en la colección de diapositivas

        ISlide slide = pres.Slides[slideIndex];


        //Eliminando una diapositiva usando su referencia

        pres.Slides.Remove(slide);


        //Escribiendo la presentación como un archivo PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Descargar Código de Ejemplo**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Eliminar%20una%20diapositiva%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Eliminar%20una%20diapositiva%20\(Aspose.Slides\).zip)