---
title: Wenden Sie ein Thema auf eine Präsentation an
type: docs
weight: 30
url: /net/apply-a-theme-to-a-presentation/
---

## **OpenXML-Präsentation:**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Wende Thema auf Präsentation an.pptx";

string ThemeFileName = FilePath + "Thema.pptx";

WendeThemaAufPräsentation(FileName, ThemeFileName);

// Wenden Sie ein neues Thema auf die Präsentation an.

public static void WendeThemaAufPräsentation(string präsentationsDatei, string temaPräsentation)

{

    using (PresentationDocument themaDokument = PresentationDocument.Open(temaPräsentation, false))

    using (PresentationDocument präsentationsDokument = PresentationDocument.Open(präsentationsDatei, true))

    {

        WendeThemaAufPräsentation(präsentationsDokument, themaDokument);

    }

}

// Wenden Sie ein neues Thema auf die Präsentation an.

public static void WendeThemaAufPräsentation(PresentationDocument präsentationsDokument, PresentationDocument themaDokument)

{

    if (präsentationsDokument == null)

    {

        throw new ArgumentNullException("präsentationsDokument");

    }

    if (themaDokument == null)

    {

        throw new ArgumentNullException("themaDokument");

    }

    // Holen Sie sich den Präsentationsteil des Präsentationsdokuments.

    PresentationPart präsentationsTeil = präsentationsDokument.PresentationPart;

    // Holen Sie sich den bestehenden Folienmasterteil.

    SlideMasterPart folienMasterTeil = präsentationsTeil.SlideMasterParts.ElementAt(0);

    string beziehungsId = präsentationsTeil.GetIdOfPart(folienMasterTeil);

    // Holen Sie sich den neuen Folienmasterteil.

    SlideMasterPart neuerFolienMasterTeil = themaDokument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Entfernen Sie den bestehenden Thementeil.

    präsentationsTeil.DeletePart(präsentationsTeil.ThemePart);

    // Entfernen Sie den alten Folienmasterteil.

    präsentationsTeil.DeletePart(folienMasterTeil);

    // Importieren Sie den neuen Folienmasterteil und verwenden Sie die alte Beziehungs-ID.

    neuerFolienMasterTeil = präsentationsTeil.AddPart(neuerFolienMasterTeil, beziehungsId);

    // Wechseln Sie zum neuen Thementeil.

    präsentationsTeil.AddPart(neuerFolienMasterTeil.ThemePart);

    Dictionary<string, SlideLayoutPart> neueFolienLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var folienLayoutTeil in neuerFolienMasterTeil.SlideLayoutParts)

    {

        neueFolienLayouts.Add(GetSlideLayoutType(folienLayoutTeil), folienLayoutTeil);

    }

    string layoutTyp = null;

    SlideLayoutPart neuerLayoutTeil = null;

    // Fügen Sie den Code für das Layout für dieses Beispiel ein.

    string standardLayoutTyp = "Titel und Inhalt";

    // Entfernen Sie die Folienlayoutbeziehung auf allen Folien.

    foreach (var folienTeil in präsentationsTeil.SlideParts)

    {

        layoutTyp = null;

        if (folienTeil.SlideLayoutPart != null)

        {

            // Bestimmen Sie den Folienlayouttyp für jede Folie.

            layoutTyp = GetSlideLayoutType(folienTeil.SlideLayoutPart);

            // Löschen Sie den alten Layoutteil.

            folienTeil.DeletePart(folienTeil.SlideLayoutPart);

        }

        if (layoutTyp != null && neueFolienLayouts.TryGetValue(layoutTyp, out neuerLayoutTeil))

        {

            // Wenden Sie den neuen Layoutteil an.

            folienTeil.AddPart(neuerLayoutTeil);

        }

        else

        {

            neuerLayoutTeil = neueFolienLayouts[standardLayoutTyp];

            // Wenden Sie den neuen Standardlayoutteil an.

            folienTeil.AddPart(neuerLayoutTeil);

        }

    }

}

// Holen Sie sich den Folienlayouttyp.

public static string GetSlideLayoutType(SlideLayoutPart folienLayoutTeil)

{

    CommonSlideData folienDaten = folienLayoutTeil.SlideLayout.CommonSlideData;

    // Bemerkungen: Wenn dies in Produktionscode verwendet wird, überprüfen Sie auf eine Nullreferenz.

    return folienDaten.Name;

}   

``` 
## **Aspose.Slides**
Um ein Thema anzuwenden, müssen wir die Folie mit dem Master klonen. Bitte befolgen Sie die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse Presentation, die die Quellpräsentation enthält, von der die Folie kopiert wird.
- Erstellen Sie eine Instanz der Klasse Presentation, die die Zielpräsentation enthält, in die die Folie kopiert wird.
- Greifen Sie auf die Folie zu, die kopiert werden soll, zusammen mit der Masterfolie.
- Instanziieren Sie die Klasse IMasterSlideCollection, indem Sie die Masters-Sammlung referenzieren, die vom Präsentationsobjekt der Zielpräsentation bereitgestellt wird.
- Rufen Sie die Methode AddClone des IMasterSlideCollection-Objekts auf und übergeben Sie die Masterfolie aus der Quell-PPTX als Parameter an die Methode AddClone.
- Instanziieren Sie die Klasse ISlideCollection, indem Sie die Referenz auf die Slides-Sammlung setzen, die vom Präsentationsobjekt der Zielpräsentation bereitgestellt wird.
- Rufen Sie die Methode AddClone des ISlideCollection-Objekts auf und übergeben Sie die Folie aus der Quellpräsentation, die kopiert werden soll, und die Masterfolie als Parameter an die Methode AddClone.
- Schreiben Sie die modifizierte Zielpräsentationsdatei.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Wende Thema auf Präsentation an.pptx";

string ThemeFileName = FilePath + "Thema.pptx";

WendeThemaAufPräsentation(ThemeFileName, FileName);

public static void WendeThemaAufPräsentation(string präsentationsDatei, string ausgabeDatei)

{

    // Instanziieren Sie die Präsentationsklasse, um die Quellpräsentationsdatei zu laden

    Presentation srcPres = new Presentation(präsentationsDatei);

    // Instanziieren Sie die Präsentationsklasse für die Zielpräsentation (wo die Folie geklont werden soll)

    Presentation destPres = new Presentation(ausgabeDatei);

    // Instanziieren Sie ISlide aus der Sammlung von Folien in der Quellpräsentation zusammen mit

    // Masterfolie

    ISlide QuelleFolie = srcPres.Slides[0];

    // Klonen Sie die gewünschte Masterfolie von der Quellpräsentation in die Sammlung der Master in der

    // Zielpräsentation

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide QuelleMaster = QuelleFolie.LayoutSlide.MasterSlide;

    // Klonen Sie die gewünschte Masterfolie von der Quellpräsentation in die Sammlung der Master in der

    // Zielpräsentation

    IMasterSlide iSlide = masters.AddClone(QuelleMaster);

    // Klonen Sie die gewünschte Folie von der Quellpräsentation mit dem gewünschten Master ans Ende der

    // Sammlung der Folien in der Zielpräsentation

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(QuelleFolie, iSlide, true);

    // Klonen Sie die gewünschte Masterfolie von der Quellpräsentation in die Sammlung der Master in der Zielpräsentation

    // Speichern Sie die Zielpräsentation auf der Festplatte

    destPres.Save(ausgabeDatei, SaveFormat.Pptx);

}

``` 
## **Herunterladen des laufenden Codebeispiels**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Beispielcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)