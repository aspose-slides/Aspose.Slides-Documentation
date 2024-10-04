---
title: Contar el número de diapositivas
type: docs
weight: 50
url: /es/net/count-the-number-of-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Contar el número de diapositivas.pptx";

Console.WriteLine("Número de diapositivas = {0}",

CountSlides(FileName));

Console.ReadKey();

// Obtener el objeto de presentación y pasarlo al siguiente método CountSlides.

public static int CountSlides(string presentationFile)

{

    // Abrir la presentación en modo solo lectura.

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

    // Comprobar si el objeto del documento es nulo.

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

string FileName = FilePath + "Contar el número de diapositivas.pptx";

Console.WriteLine("Número de diapositivas = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //Instanciar un objeto PresentationEx que representa un archivo PPTX

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **Descargar código de muestras**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip)