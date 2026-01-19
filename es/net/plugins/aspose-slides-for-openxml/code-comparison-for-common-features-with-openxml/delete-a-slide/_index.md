---
title: Eliminar una diapositiva
type: docs
weight: 80
url: /es/net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Obtiene el objeto de presentación y lo pasa al siguiente método DeleteSlide.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Abre el documento fuente en modo lectura/escritura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Pasa el documento fuente y el índice de la diapositiva a eliminar al siguiente método DeleteSlide.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Elimina la diapositiva especificada de la presentación.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Utiliza el ejemplo CountSlides para obtener el número de diapositivas en la presentación.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Obtiene la parte de presentación del documento de presentación. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtiene la presentación de la parte de presentación.

    Presentation presentation = presentationPart.Presentation;

    // Obtiene la lista de IDs de diapositivas en la presentación.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Obtiene el ID de la diapositiva especificada

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Obtiene el ID de relación de la diapositiva.

    string slideRelId = slideId.RelationshipId;

    // Elimina la diapositiva de la lista de diapositivas.

    slideIdList.RemoveChild(slideId);

    //

    // Elimina las referencias a la diapositiva de todas las presentaciones personalizadas.

    if (presentation.CustomShowList != null)

    {

        // Recorre la lista de presentaciones personalizadas.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Declara una lista enlazada de entradas de lista de diapositivas.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Busca la referencia a la diapositiva que se eliminará de la presentación personalizada.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Elimina todas las referencias a la diapositiva de la presentación personalizada.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Guarda la presentación modificada.

    presentation.Save();

    // Obtiene la parte de diapositiva para la diapositiva especificada.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Elimina la parte de diapositiva.

    presentationPart.DeletePart(slidePart);

}

// Obtiene el objeto de presentación y lo pasa al siguiente método CountSlides.

public static int CountSlides(string presentationFile)

{

    // Abre la presentación en modo solo lectura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Pasa la presentación al siguiente método CountSlide

        // y devuelve el número de diapositivas.

        return CountSlides(presentationDocument);

    }

}

// Cuenta las diapositivas en la presentación.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Comprueba si el objeto documento es nulo.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtiene la parte de presentación del documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtiene el número de diapositivas a partir de los SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Devuelve el número de diapositivas al método anterior.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Instancia un objeto PresentationEx que representa un archivo PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        // Accede a una diapositiva mediante su índice en la colección de diapositivas

        ISlide slide = pres.Slides[slideIndex];


        // Elimina una diapositiva mediante su referencia

        pres.Slides.Remove(slide);


        // Guarda la presentación como archivo PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Descargar código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)