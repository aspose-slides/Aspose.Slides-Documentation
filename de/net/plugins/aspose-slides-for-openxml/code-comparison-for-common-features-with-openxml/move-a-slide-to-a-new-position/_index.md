---
title: Eine Folie an eine neue Position verschieben
type: docs
weight: 140
url: /de/net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Eine Folie an eine neue Position verschieben.pptx";

MoveSlide(FileName, 1, 2);

// Zählen der Folien in der Präsentation.

public static int CountSlides(string presentationFile)

{

    // Öffne die Präsentation schreibgeschützt.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Übergibt die Präsentation an die nächste CountSlides-Methode

        // und gibt die Folienanzahl zurück.

        return CountSlides(presentationDocument);

    }

}

// Zähle die Folien in der Präsentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Überprüfe auf ein Null-Dokumentobjekt.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Hole den Präsentationsteil des Dokuments.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Hole die Folienanzahl aus den SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Gib die Folienanzahl an die vorherige Methode zurück.

    return slidesCount;

}

// Verschiebe eine Folie an eine andere Position in der Folienreihenfolge in der Präsentation.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Verschiebe eine Folie an eine andere Position in der Folienreihenfolge in der Präsentation.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Rufe die CountSlides-Methode auf, um die Anzahl der Folien in der Präsentation zu erhalten.

    int slidesCount = CountSlides(presentationDocument);

    // Überprüfe, ob die Positionen von und zu im gültigen Bereich und unterschiedlich sind.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Hole den Präsentationsteil aus dem Präsentationsdokument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Die Folienanzahl ist nicht null, also muss die Präsentation Folien enthalten.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Hole die Folien-ID der Quellfolie.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Bestimme die Position der Zielfolie, nach der die Quellfolie verschoben werden soll.

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

    // Entferne die Quellfolie aus ihrer aktuellen Position.

    sourceSlide.Remove();

    // Füge die Quellfolie an ihrer neuen Position nach der Zielfolie ein.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Speichere die modifizierte Präsentation.

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Eine Folie an eine neue Position verschieben.pptx";

MoveSlide(FileName, 1, 2);

// Verschiebe eine Folie an eine andere Position in der Folienreihenfolge in der Präsentation.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Instanziiere die PresentationEx-Klasse, um die Quell-PPTX-Datei zu laden

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Hole die Folie, deren Position geändert werden soll

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        //Setze die neue Position für die Folie

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        //Schreibe die PPTX auf die Festplatte

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Download Beispielcode**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Eine%20Folie%20an%20eine%20neue%20Position%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Eine%20Folie%20an%20eine%20neue%20Position%20\(Aspose.Slides\).zip)