---
title: Hochgestellt und Tiefgestellt
type: docs
weight: 80
url: /de/net/superscript-and-subscript/
keywords: "Hochgestellt, Tiefgestellt, Hochgestellten Text hinzufügen, Tiefgestellten Text hinzufügen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Hochgestellten und tiefgestellten Text zu PowerPoint-Präsentationen in C# oder .NET hinzufügen"
---

## **Hochgestellten und Tiefgestellten Text verwalten**
Sie können hochgestellten und tiefgestellten Text in jedem Absatz hinzufügen. Um hochgestellten oder tiefgestellten Text im Aspose.Slides-Textfeld hinzuzufügen, müssen die **Escapement**-Eigenschaften der PortionFormat-Klasse verwendet werden.

Diese Eigenschaft gibt den hochgestellten oder tiefgestellten Text zurück oder legt ihn fest (Wert von -100% (tiefgestellt) bis 100% (hochgestellt). Zum Beispiel:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz auf eine Folie, indem Sie ihren Index verwenden.
- Fügen Sie der Folie eine IAutoShape vom Typ Rechteck hinzu.
- Greifen Sie auf das ITextFrame zu, das mit der IAutoShape verknüpft ist.
- Löschen Sie vorhandene Absätze.
- Erstellen Sie ein neues Absatzobjekt zur Aufnahme von hochgestelltem Text und fügen Sie es der IParagraphs-Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portionsobjekt.
- Setzen Sie die Escapement-Eigenschaft für die Portion zwischen 0 und 100, um hochgestellten Text hinzuzufügen. (0 bedeutet keinen Hochgestellt)
- Setzen Sie einen Text für die Portion und fügen Sie ihn dann der Portion-Sammlung des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt zur Aufnahme von tiefgestelltem Text und fügen Sie es der IParagraphs-Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portionsobjekt.
- Setzen Sie die Escapement-Eigenschaft für die Portion zwischen 0 und -100, um tiefgestellten Text hinzuzufügen. (0 bedeutet keinen Tiefgestellt)
- Setzen Sie einen Text für die Portion und fügen Sie ihn dann der Portion-Sammlung des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte ist unten angegeben.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    // Folie abrufen
    ISlide slide = presentation.Slides[0];

    // Textfeld erstellen
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Absatz für hochgestellten Text erstellen
    IParagraph superPar = new Paragraph();

    // Portion mit gewöhnlichem Text erstellen
    IPortion portion1 = new Portion();
    portion1.Text = "Foliens Titel";
    superPar.Portions.Add(portion1);

    // Portion mit hochgestelltem Text erstellen
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Absatz für tiefgestellten Text erstellen
    IParagraph paragraph2 = new Paragraph();

    // Portion mit gewöhnlichem Text erstellen
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Portion mit tiefgestelltem Text erstellen
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Absätze zum Textfeld hinzufügen
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("TestOut.pptx", SaveFormat.Pptx);
    System.Diagnostics.Process.Start("TestOut.pptx");
 } 
```