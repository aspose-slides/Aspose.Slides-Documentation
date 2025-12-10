---
title: SmartArt-Grafiken in Präsentationen in .NET verwalten
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
description: "Automatisieren Sie die Erstellung, Bearbeitung und Gestaltung von PowerPoint SmartArt in .NET mit Aspose.Slides, inklusive kompakter Codebeispiele und leistungsorientierter Anleitungen."
---

## **SmartArt‑Form erstellen**
Aspose.Slides for .NET ermöglicht nun das Hinzufügen benutzerdefinierter SmartArt‑Formen von Grund auf zu Folien. Aspose.Slides for .NET stellt die einfachste API zur Erstellung von SmartArt‑Formen auf einfachste Weise bereit. Um eine SmartArt‑Form in einer Folie zu erstellen, folgen Sie bitte den nachstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
- Holen Sie die Referenz einer Folie anhand ihres Index.
- Fügen Sie eine SmartArt‑Form hinzu, indem Sie deren LayoutType festlegen.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.
```c#
 // Instanziere die Präsentation
 using (Presentation pres = new Presentation())
 {
 
     // Zugriff auf die Präsentationsfolie
     ISlide slide = pres.Slides[0];
 
     // SmartArt-Form hinzufügen
     ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
 
     // Präsentation speichern
     pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **Zugriff auf eine SmartArt‑Form in einer Folie**
Der folgende Code wird verwendet, um auf die in einer Präsentationsfolie hinzugefügten SmartArt‑Formen zuzugreifen. Im Beispielcode traversieren wir jede Form innerhalb der Folie und prüfen, ob es sich um eine SmartArt‑Form handelt. Ist die Form vom Typ SmartArt, casten wir sie in eine SmartArt‑Instanz.
```c#
// Laden der gewünschten Präsentation
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Durchlaufen aller Formen in der ersten Folie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **Zugriff auf eine SmartArt‑Form mit einem bestimmten LayoutTyp**
Der folgende Beispielcode hilft beim Zugriff auf die SmartArt‑Form mit einem bestimmten LayoutType. Bitte beachten Sie, dass Sie den LayoutType von SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt‑Form festgelegt wird.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie anhand ihres Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Prüfen Sie die SmartArt‑Form mit dem gewünschten LayoutType und führen Sie anschließend die erforderlichen Aktionen aus.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen aller Formen in der ersten Folie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
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


## **Stil einer SmartArt‑Form ändern**
Der folgende Beispielcode hilft beim Zugriff auf die SmartArt‑Form mit einem bestimmten LayoutType.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie anhand ihres Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Finden Sie die SmartArt‑Form mit einem bestimmten Stil.
- Setzen Sie den neuen Stil für die SmartArt‑Form.
- Speichern Sie die Präsentation.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen aller Formen in der ersten Folie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Überprüfen des SmartArt-Stils
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Ändern des SmartArt-Stils
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Präsentation speichern
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```


## **Farbstil einer SmartArt‑Form ändern**
In diesem Beispiel lernen wir, den Farbstil einer beliebigen SmartArt‑Form zu ändern. Im folgenden Beispielcode wird auf die SmartArt‑Form mit einem bestimmten Farbstil zugegriffen und ihr Stil geändert.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie anhand ihres Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Finden Sie die SmartArt‑Form mit einem bestimmten Farbstil.
- Setzen Sie den neuen Farbstil für die SmartArt‑Form.
- Speichern Sie die Präsentation.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen aller Formen in der ersten Folie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Überprüfen des SmartArt-Farbtyps
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Ändern des SmartArt-Farbtyps
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Präsentation speichern
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich SmartArt als ein einzelnes Objekt animieren?**  
Ja. SmartArt ist eine Form, sodass Sie über die Animations‑API [Standardanimationen](/slides/de/net/powerpoint-animation/) (Eintritt, Austritt, Betonung, Bewegungspfade) wie bei anderen Formen anwenden können.

**Wie finde ich ein bestimmtes SmartArt in einer Folie, wenn ich seine interne ID nicht kenne?**  
Legen Sie den Alternativtext (AltText) fest und verwenden Sie ihn, um nach der Form zu suchen – dies ist ein empfohlener Weg, die Ziel‑Form zu finden.

**Kann ich SmartArt mit anderen Formen gruppieren?**  
Ja. Sie können SmartArt mit anderen Formen (Bildern, Tabellen usw.) gruppieren und anschließend die Gruppe [manipulieren](/slides/de/net/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt (z. B. für eine Vorschau oder einen Bericht)?**  
Exportieren Sie ein Miniaturbild/Bild der Form; die Bibliothek kann einzelne Formen [rendern](/slides/de/net/create-shape-thumbnails/) in Rasterdateien (PNG/JPG/TIFF).

**Wird das Aussehen von SmartArt beim Konvertieren der gesamten Präsentation in PDF beibehalten?**  
Ja. Die Rendering‑Engine zielt auf hohe Treue beim [PDF‑Export](/slides/de/net/convert-powerpoint-to-pdf/) ab und bietet eine Reihe von Qualitäts‑ und Kompatibilitätsoptionen.