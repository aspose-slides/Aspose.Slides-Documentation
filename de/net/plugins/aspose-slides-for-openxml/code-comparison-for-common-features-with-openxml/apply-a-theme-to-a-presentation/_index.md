---
title: Ein Design auf eine Präsentation anwenden
type: docs
weight: 30
url: /de/net/apply-a-theme-to-a-presentation/
---

## **OpenXML-Präsentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Wendet ein neues Design auf die Präsentation an. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Wendet ein neues Design auf die Präsentation an. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Ruft den Präsentationsteil des Präsentationsdokuments ab.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ruft den bestehenden Folienmasterteil ab.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Ruft den neuen Folienmasterteil ab.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Entfernt den bestehenden Designteil.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Entfernt den alten Folienmasterteil.

    presentationPart.DeletePart(slideMasterPart);

    // Importiert den neuen Folienmasterteil und verwendet die alte Beziehungs-ID erneut.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Wechselt zum neuen Designteil.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Fügt den Code für das Layout dieses Beispiels ein.

    string defaultLayoutType = "Title and Content";

    // Entfernt die Folienlayout-Beziehung auf allen Folien. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Bestimmt den Folienlayouttyp für jede Folie.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Löscht den alten Layoutteil.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Wendet den neuen Layoutteil an.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Wendet den neuen Standard-Layoutteil an.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Ruft den Folienlayouttyp ab.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Hinweis: Wenn dies im Produktionscode verwendet wird, überprüfen Sie auf eine Nullreferenz.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Um ein Design anzuwenden, müssen wir die Folie mit dem Master duplizieren. Bitte folgen Sie den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Presentation-Klasse, die die Quellpräsentation enthält, von der die Folie geklont werden soll.
- Erstellen Sie eine Instanz der Presentation-Klasse, die die Zielpräsentation enthält, in die die Folie geklont werden soll.
- Greifen Sie auf die zu klonende Folie zusammen mit der Masterfolie zu.
- Instanziieren Sie die IMasterSlideCollection-Klasse, indem Sie auf die Masters-Sammlung zugreifen, die vom Presentation-Objekt der Zielpräsentation bereitgestellt wird.
- Rufen Sie die AddClone-Methode des IMasterSlideCollection-Objekts auf und übergeben Sie den Master aus der Quell-PPTX, der geklont werden soll, als Parameter.
- Instanziieren Sie die ISlideCollection-Klasse, indem Sie die Referenz auf die Slides-Sammlung setzen, die vom Presentation-Objekt der Zielpräsentation bereitgestellt wird.
- Rufen Sie die AddClone-Methode des ISlideCollection-Objekts auf und übergeben Sie die Folie aus der Quellpräsentation, die geklont werden soll, sowie die Masterfolie als Parameter.
- Schreiben Sie die modifizierte Zieldatei der Präsentation.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Instanziiert die Presentation-Klasse, um die Quellpräsentationsdatei zu laden

    Presentation srcPres = new Presentation(presentationFile);

    //Instanziiert die Presentation-Klasse für die Zielpräsentation (wo die Folie geklont werden soll)

    Presentation destPres = new Presentation(outputFile);

    //Instanziert ISlide aus der Sammlung von Folien in der Quellpräsentation zusammen mit

    //der Masterfolie

    ISlide SourceSlide = srcPres.Slides[0];

    //Klonet den gewünschten Master aus der Quellpräsentation in die Sammlung von Mastern in der

    //Zielpräsentation

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Klonet den gewünschten Master aus der Quellpräsentation in die Sammlung von Mastern in der

    //Zielpräsentation

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Klonet die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master zum Ende der

    //Sammlung von Folien in der Zielpräsentation

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Klonet den gewünschten Master aus der Quellpräsentation in die Sammlung von Mastern in der//Zielpräsentation

    //Speichert die Zielpräsentation auf dem Datenträger

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Beispielcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)