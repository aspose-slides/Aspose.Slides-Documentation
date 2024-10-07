---
title: Zähle die Anzahl der Folien
type: docs
weight: 50
url: /net/count-the-number-of-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Zähle die Anzahl der Folien.pptx";

Console.WriteLine("Anzahl der Folien = {0}",

CountSlides(FileName));

Console.ReadKey();

// Hole das Präsentationsobjekt und übergebe es an die nächste CountSlides-Methode.

public static int CountSlides(string presentationFile)

{

    // Öffne die Präsentation im Nur-Lesen-Modus.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Übergebe die Präsentation an die nächste CountSlide-Methode

        // und gebe die Folienanzahl zurück.

        return CountSlides(presentationDocument);

    }

}

// Zähle die Folien in der Präsentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Überprüfe auf ein null-Dokumentobjekt.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Hole den Präsentationsteil des Dokuments.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Hole die Folienanzahl von den SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Gebe die Folienanzahl an die vorherige Methode zurück.

    return slidesCount;

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Zähle die Anzahl der Folien.pptx";

Console.WriteLine("Anzahl der Folien = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //Erstelle ein PresentationEx-Objekt, das eine PPTX-Datei repräsentiert

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **Beispielcode herunterladen**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Zähle%20die%20Anzahl%20der%20Folien%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Zähle%20die%20Anzahl%20der%20Folien%20\(Aspose.Slides\).zip)