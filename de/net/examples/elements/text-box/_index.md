---
title: Textfeld
type: docs
weight: 40
url: /de/net/examples/elements/text-box/
keywords:
- Textfeld
- Textfeld hinzufügen
- Zugriff auf Textfeld
- Textfeld entfernen
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit Textfeldern in Aspose.Slides für .NET: Text hinzufügen, formatieren, ausrichten, umbrechen, automatisch anpassen und stilisieren mit C# für PPT-, PPTX- und ODP-Präsentationen."
---
In Aspose.Slides wird ein **Textfeld** durch ein `AutoShape` dargestellt. Fast jede Form kann Text enthalten, aber ein typisches Textfeld hat keine Füllung oder Kontur und zeigt nur Text an.

Dieser Leitfaden erklärt, wie man Textfelder programmgesteuert hinzufügt, darauf zugreift und sie entfernt.

## **Textfeld hinzufügen**

Ein Textfeld ist einfach ein `AutoShape` ohne Füllung oder Kontur und mit etwas formatiertem Text. So erstellen Sie eines:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Erstelle ein Rechteck-Shape (standardmäßig gefüllt mit Rand und ohne Text).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Entferne Füllung und Rahmen, damit es wie ein typisches Textfeld aussieht.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Textformatierung festlegen.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Den eigentlichen Textinhalt zuweisen.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Hinweis:** Jedes `AutoShape`, das ein nicht leeres `TextFrame` enthält, kann als Textfeld fungieren.

## **Zugriff auf Textfelder nach Inhalt**

Um alle Textfelder zu finden, die ein bestimmtes Schlüsselwort enthalten (z. B. "Slide"), iterieren Sie über die Formen und prüfen deren Text:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Nur AutoShapes können editierbaren Text enthalten.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Etwas mit dem passenden Textfeld machen.
            }
        }
    }
}
```

## **Textfelder nach Inhalt entfernen**

Dieses Beispiel findet und löscht alle Textfelder auf der ersten Folie, die ein bestimmtes Schlüsselwort enthalten:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Tipp:** Erstellen Sie stets eine Kopie der Formensammlung, bevor Sie sie während einer Iteration ändern, um Fehler bei der Modifikation der Sammlung zu vermeiden.