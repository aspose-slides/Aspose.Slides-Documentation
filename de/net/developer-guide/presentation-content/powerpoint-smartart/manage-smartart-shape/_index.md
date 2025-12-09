---
title: SmartArt-Grafiken in Präsentationen mit .NET verwalten
linktitle: SmartArt-Grafiken
type: docs
weight: 20
url: /de/net/manage-smartart-shape/
keywords:
- SmartArt-Objekt
- SmartArt-Grafik
- SmartArt-Stil
- SmartArt-Farbe
- SmartArt erstellen
- SmartArt hinzufügen
- SmartArt bearbeiten
- SmartArt ändern
- SmartArt zugreifen
- SmartArt-Layouttyp
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Automatisieren Sie die Erstellung, Bearbeitung und Gestaltung von PowerPoint SmartArt in .NET mit Aspose.Slides, inklusive kurzer Codebeispiele und leistungsorientierter Anleitung."
---

## **SmartArt-Form erstellen**
Aspose.Slides für .NET ermöglicht jetzt das Hinzufügen benutzerdefinierter SmartArt-Formen zu Folien von Grund auf. Aspose.Slides für .NET bietet die einfachste API, um SmartArt-Formen auf leichteste Weise zu erstellen. Um eine SmartArt-Form in einer Folie zu erstellen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie eine SmartArt-Form hinzu, indem Sie deren LayoutType festlegen.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.
```c#
// Präsentation instanziieren
using (Presentation pres = new Presentation())
{

    // Auf die Präsentationsfolie zugreifen
    ISlide slide = pres.Slides[0];

    // SmartArt-Form hinzufügen
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Präsentation speichern
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **SmartArt-Form in Folie zugreifen**
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt-Formen zuzugreifen. Im Beispielcode durchlaufen wir jede Form innerhalb der Folie und prüfen, ob es sich um eine SmartArt-Form handelt. Ist die Form vom Typ SmartArt, casten wir sie zu einer SmartArt-Instanz.
```c#
 // Die gewünschte Präsentation laden
 using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
 {
 
     // Durchlaufen Sie jede Form in der ersten Folie
     foreach (IShape shape in pres.Slides[0].Shapes)
     {
         // Prüfen, ob die Form vom Typ SmartArt ist
         if (shape is ISmartArt)
         {
             // Typumwandlung der Form zu SmartArtEx
             ISmartArt smart = (ISmartArt)shape;
             System.Console.WriteLine("Shape Name:" + smart.Name);
 
         }
     }
 }
```




## **SmartArt-Form mit bestimmtem Layouttyp zugreifen**
Der folgende Beispielcode hilft dabei, die SmartArt-Form mit einem bestimmten LayoutType zu finden. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt-Form festgelegt wird.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit SmartArt-Form.
- Holen Sie sich die Referenz der ersten Folie, indem Sie deren Index verwenden.
- Durchlaufen Sie jede Form innerhalb der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Prüfen Sie die SmartArt-Form mit dem gewünschten LayoutType und führen Sie die anschließend erforderlichen Aktionen aus.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen Sie jede Form in der ersten Folie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Überprüfen des SmartArt-Layouts
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```




## **SmartArt-Form-Stil ändern**
Der folgende Beispielcode hilft dabei, die SmartArt-Form mit einem bestimmten LayoutType zu finden.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit SmartArt-Form.
- Holen Sie sich die Referenz der ersten Folie, indem Sie deren Index verwenden.
- Durchlaufen Sie jede Form innerhalb der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Finden Sie die SmartArt-Form mit einem bestimmten Stil.
- Setzen Sie den neuen Stil für die SmartArt-Form.
- Speichern Sie die Präsentation.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen Sie jede Form in der ersten Folie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Überprüfen des SmartArt-Stils
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // SmartArt-Stil ändern
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Präsentation speichern
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```




## **SmartArt-Form-Farbstil ändern**
In diesem Beispiel lernen wir, den Farbstil einer beliebigen SmartArt-Form zu ändern. Im folgenden Beispielcode wird die SmartArt-Form mit einem bestimmten Farbstil aufgerufen und ihr Stil geändert.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit SmartArt-Form.
- Holen Sie sich die Referenz der ersten Folie, indem Sie deren Index verwenden.
- Durchlaufen Sie jede Form innerhalb der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Finden Sie die SmartArt-Form mit einem bestimmten Farbstil.
- Setzen Sie den neuen Farbstil für die SmartArt-Form.
- Speichern Sie die Präsentation.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen Sie jede Form in der ersten Folie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Überprüfen des SmartArt-Farbtyps
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // SmartArt-Farbtyp ändern
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Präsentation speichern
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich SmartArt als einzelnes Objekt animieren?**

Ja. SmartArt ist eine Form, sodass Sie über die Animations‑API [Standardanimationen](/slides/de/net/powerpoint-animation/) (Eingang, Ausgang, Betonung, Bewegungspfade) genauso wie bei anderen Formen anwenden können.

**Wie finde ich ein bestimmtes SmartArt auf einer Folie, wenn ich dessen interne ID nicht kenne?**

Legen Sie den Alternativtext (AltText) fest und suchen Sie die Form nach diesem Wert – das ist ein empfohlener Weg, um die Ziel‑Form zu locate.

**Kann ich SmartArt mit anderen Formen gruppieren?**

Ja. Sie können SmartArt mit anderen Formen (Bildern, Tabellen usw.) gruppieren und dann die [Gruppe manipulieren](/slides/de/net/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt (z. B. für eine Vorschau oder einen Bericht)?**

Exportieren Sie ein Miniatur‑/Bild der Form; die Bibliothek kann [einzelne Formen](/slides/de/net/create-shape-thumbnails/) in Rasterdateien (PNG/JPG/TIFF) rendern.

**Wird das Aussehen von SmartArt beim Konvertieren der gesamten Präsentation in PDF erhalten bleiben?**

Ja. Die Render‑Engine zielt auf hohe Treue beim [PDF‑Export](/slides/de/net/convert-powerpoint-to-pdf/) ab, mit einer Reihe von Qualitäts‑ und Kompatibilitätsoptionen.