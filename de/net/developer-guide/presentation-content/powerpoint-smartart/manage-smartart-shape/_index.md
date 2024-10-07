---
title: SmartArt-Form verwalten
type: docs
weight: 20
url: /net/manage-smartart-shape/
keywords: "SmartArt-Form, SmartArt-Formstil, SmartArt-Formfarbstil, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Verwalten Sie SmartArt in PowerPoint-Präsentationen in C# oder .NET"
---

## **SmartArt-Form erstellen**
Aspose.Slides für .NET erleichtert nun das Hinzufügen benutzerdefinierter SmartArt-Formen in ihren Folien von Grund auf. Aspose.Slides für .NET hat die einfachste API bereitgestellt, um SmartArt-Formen auf die einfachste Weise zu erstellen. Um eine SmartArt-Form in einer Folie zu erstellen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
- Erhalten Sie die Referenz auf eine Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine SmartArt-Form hinzu, indem Sie den LayoutType festlegen.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

```c#
// Stellen Sie die Präsentation bereit
using (Presentation pres = new Presentation())
{

    // Greifen Sie auf die Präsentationsfolie zu
    ISlide slide = pres.Slides[0];

    // Fügen Sie eine Smart Art Form hinzu
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Präsentation speichern
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Zugriff auf SmartArt-Form in der Folie**
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt-Formen zuzugreifen. Im Beispielcode durchlaufen wir jede Form innerhalb der Folie und prüfen, ob es sich um eine SmartArt-Form handelt. Wenn die Form vom Typ SmartArt ist, casten wir sie in eine SmartArt-Instanz.

```c#
// Laden Sie die gewünschte Präsentation
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Durchlaufen Sie jede Form innerhalb der ersten Folie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Form in SmartArtEx casten
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Formname:" + smart.Name);

        }
    }
}
```



## **Zugriff auf SmartArt-Form mit bestimmtem Layout-Typ**
Der folgende Beispielcode hilft dabei, auf die SmartArt-Form mit einem bestimmten LayoutType zuzugreifen. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt-Form festgelegt wird.

- Erstellen Sie eine Instanz der `Presentation`-Klasse und laden Sie die Präsentation mit SmartArt-Form.
- Erhalten Sie die Referenz auf die erste Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form innerhalb der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn es sich um SmartArt handelt.
- Überprüfen Sie die SmartArt-Form mit dem bestimmten LayoutType und führen Sie aus, was anschließend erforderlich ist.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen Sie jede Form innerhalb der ersten Folie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Form in SmartArtEx casten
            ISmartArt smart = (ISmartArt) shape;

            // Überprüfen des SmartArt-Layouts
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Führen Sie hier etwas aus....");
            }
        }
    }
}
```



## **SmartArt-Formstil ändern**
Der folgende Beispielcode hilft, auf die SmartArt-Form mit einem bestimmten LayoutType zuzugreifen.

- Erstellen Sie eine Instanz der `Presentation`-Klasse und laden Sie die Präsentation mit SmartArt-Form.
- Erhalten Sie die Referenz auf die erste Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form innerhalb der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn es sich um SmartArt handelt.
- Finden Sie die SmartArt-Form mit einem bestimmten Stil.
- Legen Sie den neuen Stil für die SmartArt-Form fest.
- Speichern Sie die Präsentation.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen Sie jede Form innerhalb der ersten Folie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Form in SmartArtEx casten
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



## **SmartArt-Formfarbstil ändern**
In diesem Beispiel lernen wir, den Farbstil für eine beliebige SmartArt-Form zu ändern. Im folgenden Beispielcode greifen wir auf die SmartArt-Form mit einem bestimmten Farbstil zu und ändern ihren Stil.

- Erstellen Sie eine Instanz der `Presentation`-Klasse und laden Sie die Präsentation mit SmartArt-Form.
- Erhalten Sie die Referenz auf die erste Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form innerhalb der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn es sich um SmartArt handelt.
- Finden Sie die SmartArt-Form mit einem bestimmten Farbstil.
- Legen Sie den neuen Farbstil für die SmartArt-Form fest.
- Speichern Sie die Präsentation.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Durchlaufen Sie jede Form innerhalb der ersten Folie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Form in SmartArtEx casten
            ISmartArt smart = (ISmartArt)shape;

            // Überprüfen des SmartArt-Farbstils
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Ändern des SmartArt-Farbstils
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Präsentation speichern
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```