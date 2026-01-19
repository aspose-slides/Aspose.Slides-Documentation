---
title: Anzahl der Folien zählen
type: docs
weight: 50
url: /de/net/count-the-number-of-slides/
---

## **OpenXML SDK**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Anzahl der Folien = {0}",

CountSlides(FileName));

Console.ReadKey();

// Holt das Präsentationsobjekt und übergibt es an die nächste CountSlides-Methode.

public static int CountSlides(string presentationFile)

{

    // Öffnet die Präsentation schreibgeschützt.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Gibt die Präsentation an die nächste CountSlide‑Methode weiter

        // und gibt die Folienzahl zurück.

        return CountSlides(presentationDocument);

    }

}

// Zählt die Folien in der Präsentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Prüft, ob das Dokumentobjekt null ist.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Holt den Präsentationsteil des Dokuments.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ermittelt die Folienzahl aus den SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Gibt die Folienzahl an die vorherige Methode zurück.

    return slidesCount;

} 
```
## **Aspose.Slides**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Anzahl der Folien = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  // Instanziiert ein PresentationEx-Objekt, das eine PPTX-Datei darstellt

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  
```
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)