---
title: SmartArt-Form verwalten
type: docs
weight: 20
url: /de/net/manage-smartart-shape/
keywords: "SmartArt-Form, SmartArt-Formstil, SmartArt-Formfarbstil, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "SmartArt in PowerPoint-Präsentationen in C# oder .NET verwalten"
---

## **SmartArt-Form erstellen**
Aspose.Slides for .NET ermöglicht nun das Hinzufügen benutzerdefinierter SmartArt‑Formen zu Folien von Grund auf. Aspose.Slides for .NET stellt die einfachste API bereit, um SmartArt‑Formen auf einfachste Weise zu erstellen. Um eine SmartArt‑Form in einer Folie zu erstellen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- Rufen Sie die Referenz einer Folie über deren Index ab.
- Fügen Sie eine SmartArt‑Form hinzu, indem Sie deren LayoutType festlegen.
- Speichern Sie die geänderte Präsentation als PPTX‑Datei.
```c#
 // Präsentation instanziieren
 using (Presentation pres = new Presentation())
 {
 
     // Auf die Folie der Präsentation zugreifen
     ISlide slide = pres.Slides[0];
 
     // SmartArt-Form hinzufügen
     ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
 
     // Präsentation speichern
     pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```




## **Zugriff auf SmartArt-Form in Folie**
Der folgende Code wird verwendet, um auf die in einer Präsentationsfolie hinzugefügten SmartArt‑Formen zuzugreifen. Im Beispielcode traversieren wir jede Form auf der Folie und prüfen, ob es sich um eine SmartArt‑Form handelt. Ist die Form vom Typ SmartArt, casting wir sie in eine SmartArt‑Instanz.
```c#
 // Laden der gewünschten Präsentation
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen aller Formen in der ersten Folie
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




## **Zugriff auf SmartArt-Form mit bestimmtem Layouttyp**
Der folgende Beispielcode hilft beim Zugriff auf die SmartArt‑Form mit einem bestimmten LayoutType. Bitte beachten Sie, dass Sie den LayoutType von SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt‑Form festgelegt wird.

- Erstellen Sie eine Instanz der Klasse `Presentation` und laden Sie die Präsentation mit SmartArt Shape.
- Rufen Sie die Referenz der ersten Folie über deren Index ab.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Prüfen Sie die SmartArt‑Form mit dem bestimmten LayoutType und führen Sie anschließend das erforderliche Vorgehen aus.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen aller Formen in der ersten Folie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Prüfen des SmartArt-Layouts
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```




## **SmartArt-Formstil ändern**
Der folgende Beispielcode hilft beim Zugriff auf die SmartArt‑Form mit einem bestimmten LayoutType.

- Erstellen Sie eine Instanz der Klasse `Presentation` und laden Sie die Präsentation mit SmartArt Shape.
- Rufen Sie die Referenz der ersten Folie über deren Index ab.
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
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Prüfen des SmartArt-Stils
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




## **SmartArt-Formfarbstil ändern**
In diesem Beispiel lernen wir, den Farbstil einer beliebigen SmartArt‑Form zu ändern. Im folgenden Beispielcode wird auf die SmartArt‑Form mit einem bestimmten Farbstil zugegriffen und ihr Stil geändert.

- Erstellen Sie eine Instanz der Klasse `Presentation` und laden Sie die Präsentation mit SmartArt Shape.
- Rufen Sie die Referenz der ersten Folie über deren Index ab.
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
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Prüfen des SmartArt-Farbtyps
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

**Kann ich SmartArt als einzelnes Objekt animieren?**

Ja. SmartArt ist eine Form, sodass Sie über die Animations‑API [Standardanimationen](/slides/de/net/powerpoint-animation/) (Eingang, Ausgang, Hervorhebung, Bewegungspfade) wie bei anderen Formen anwenden können.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie finden, wenn ich seine interne ID nicht kenne?**

Setzen und verwenden Sie den Alternativtext (AltText) und suchen Sie die Form nach diesem Wert – dies ist ein empfohlener Weg, um die Ziel‑Form zu finden.

**Kann ich SmartArt mit anderen Formen gruppieren?**

Ja. Sie können SmartArt mit anderen Formen (Bildern, Tabellen usw.) gruppieren und dann die [Gruppe manipulieren](/slides/de/net/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt (z. B. für eine Vorschau oder einen Bericht)?**

Exportieren Sie ein Miniatur‑/Bild der Form; die Bibliothek kann [einzelne Formen rendern](/slides/de/net/create-shape-thumbnails/) zu Rasterdateien (PNG/JPG/TIFF).

**Wird das Aussehen von SmartArt beim Konvertieren der gesamten Präsentation nach PDF erhalten bleiben?**

Ja. Die Rendering‑Engine strebt hohe Treue beim [PDF‑Export](/slides/de/net/convert-powerpoint-to-pdf/) an, mit einer Reihe von Qualitäts‑ und Kompatibilitäts‑Optionen.