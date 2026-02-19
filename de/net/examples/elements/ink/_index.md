---
title: Tinte
type: docs
weight: 180
url: /de/net/examples/elements/ink/
keywords:
- Tinte
- Zugriff auf Tinte
- Tinte entfernen
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit Tinte in Aspose.Slides für .NET: Zeichnen, Importieren und Bearbeiten von Strichen, Anpassen von Farbe und Breite sowie Exportieren nach PPT, PPTX und ODP mit C#‑Beispielen."
---
Dieser Artikel enthält Beispiele zum Zugriff auf vorhandene Tintenformen und deren Entfernung mit **Aspose.Slides for .NET**.

> ❗ **Hinweis:** Tintenformen repräsentieren Benutzereingaben von spezialisierten Geräten. Aspose.Slides kann keine neuen Tintenstriche programmgesteuert erstellen, aber Sie können vorhandene Tinte lesen und ändern.

## **Access Ink**
Lesen Sie die Tags der ersten Tintenform auf einer Folie.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Verwenden Sie tagName nach Bedarf.
        }
    }
}
```

## **Remove Ink**
Löschen Sie eine Tintenform von der Folie, falls vorhanden.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```