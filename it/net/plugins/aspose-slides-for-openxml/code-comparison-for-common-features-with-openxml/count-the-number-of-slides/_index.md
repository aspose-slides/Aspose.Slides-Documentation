---
title: Conta il numero di diapositive
type: docs
weight: 50
url: /it/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// Ottieni l'oggetto della presentazione e passalo al successivo metodo CountSlides.

public static int CountSlides(string presentationFile)

{

    // Apri la presentazione in sola lettura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passa la presentazione al prossimo metodo CountSlides

        // e restituisci il conteggio delle diapositive.

        return CountSlides(presentationDocument);

    }

}

// Conta le diapositive nella presentazione.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Verifica se l'oggetto documento è nullo.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Ottieni la parte della presentazione del documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ottieni il conteggio delle diapositive dalle SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Restituisci il conteggio delle diapositive al metodo precedente.

    return slidesCount;

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //Istanzia un oggetto PresentationEx che rappresenta un file PPTX

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **Scarica il codice di esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)