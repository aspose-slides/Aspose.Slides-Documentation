---
title: Mover una diapositiva a una nueva posición
type: docs
weight: 140
url: /net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Mover una diapositiva a una nueva posición.pptx";

MoveSlide(FileName, 1, 2);

// Contando las diapositivas en la presentación.

public static int CountSlides(string presentationFile)

{

    // Abrir la presentación en modo de solo lectura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Pasar la presentación al siguiente método CountSlides

        // y devolver el conteo de diapositivas.

        return CountSlides(presentationDocument);

    }

}

// Contar las diapositivas en la presentación.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Verificar si el objeto de documento es nulo.

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

// Mover una diapositiva a una posición diferente en el orden de las diapositivas en la presentación.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Mover una diapositiva a una posición diferente en el orden de las diapositivas en la presentación.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Llamar al método CountSlides para obtener el número de diapositivas en la presentación.

    int slidesCount = CountSlides(presentationDocument);

    // Verificar que ambas posiciones from y to estén dentro del rango y sean diferentes.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Obtener la parte de presentación del documento de presentación.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // El conteo de diapositivas no es cero, así que la presentación debe contener diapositivas.

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Obtener el ID de la diapositiva fuente.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Identificar la posición de la diapositiva objetivo después de la cual mover la diapositiva fuente.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // Eliminar la diapositiva fuente de su posición actual.

    sourceSlide.Remove();

    // Insertar la diapositiva fuente en su nueva posición después de la diapositiva objetivo.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Guardar la presentación modificada.

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Mover una diapositiva a una nueva posición.pptx";

MoveSlide(FileName, 1, 2);

// Mover una diapositiva a una posición diferente en el orden de las diapositivas en la presentación.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Instanciar la clase PresentationEx para cargar el archivo PPTX fuente

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Obtener la diapositiva cuya posición debe ser cambiada

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        //Establecer la nueva posición para la diapositiva

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        //Guardar el PPTX en disco

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Descargar Código de Muestra**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Mover%20una%20diapositiva%20a%20una%20nueva%20posición%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Mover%20una%20diapositiva%20a%20una%20nueva%20posición%20\(Aspose.Slides\).zip)