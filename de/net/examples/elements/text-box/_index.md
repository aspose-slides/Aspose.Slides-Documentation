---
title: Textfeld
type: docs
weight: 40
url: /de/net/examples/elements/text-box/
keywords:
- Beispiel für Textfeld
- Textfeld hinzufügen
- Zugriff auf Textfeld
- Textfeld entfernen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und formatieren Sie Textfelder in C# mit Aspose.Slides: Schriftarten, Ausrichtung, Zeilenumbruch, automatisches Anpassen und Links festlegen, um Folien für PowerPoint und OpenDocument zu optimieren."
---

In Aspose.Slides wird ein **Textfeld** durch ein `AutoShape` dargestellt. Fast jede Form kann Text enthalten, aber ein typisches Textfeld hat keine Füllung oder keinen Rand und zeigt nur Text an.

Dieser Leitfaden erklärt, wie man Textfelder programmgesteuert hinzufügt, darauf zugreift und sie entfernt.

## Textfeld hinzufügen

Ein Textfeld ist einfach ein `AutoShape` ohne Füllung oder Rand und mit formatiertem Text. So erstellen Sie eines:

```csharp
public static void Add_TextBox()
{
    using var pres = new Presentation();

    // Create a rectangle shape (defaults to filled with border and no text)
    var textBox = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Remove fill and border to make it look like a typical text box
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Set text formatting
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assign the actual text content
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Hinweis:** Jedes `AutoShape`, das ein nicht leeres `TextFrame` enthält, kann als Textfeld fungieren.

## Textfelder nach Inhalt zugreifen

Um alle Textfelder zu finden, die ein bestimmtes Schlüsselwort (z. B. „Slide“) enthalten, iterieren Sie über die Formen und prüfen deren Text:

```csharp
public static void Access_TextBox()
{
    using var pres = new Presentation();

    foreach (var shape in pres.Slides[0].Shapes)
    {
        // Only AutoShapes can contain editable text
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Do something with the matching text box
            }
        }
    }
}
```

## Textfelder nach Inhalt entfernen

Dieses Beispiel findet und löscht alle Textfelder auf der ersten Folie, die ein bestimmtes Schlüsselwort enthalten:

```csharp
public static void Remove_TextBox()
{
    using var pres = new Presentation();

    var shapesToRemove = pres.Slides[0].Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => pres.Slides[0].Shapes.Remove(shape));
}
```

> 💡 **Tipp:** Erstellen Sie stets eine Kopie der Formensammlung, bevor Sie sie während einer Iteration ändern, um Fehler durch Änderungen an der Sammlung zu vermeiden.