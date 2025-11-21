---
title: Tinte
type: docs
weight: 180
url: /de/net/examples/elements/ink/
keywords:
- Tintenbeispiel
- Tinte zugreifen
- Tinte entfernen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie digitale Tinte auf Folien in C# mit Aspose.Slides: Fügen Sie Pen‑Striche hinzu, bearbeiten Sie Pfade, setzen Sie Farbe und Breite und exportieren Sie die Ergebnisse für PowerPoint und OpenDocument."
---

Bietet Beispiele zum Zugriff auf vorhandene Ink-Formen und deren Entfernung mithilfe von **Aspose.Slides for .NET**.

> ❗ **Hinweis:** Ink-Formen stellen Benutzereingaben von speziellen Geräten dar. Aspose.Slides kann keine neuen Ink-Striche programmgesteuert erstellen, aber Sie können vorhandene Ink-Daten lesen und ändern.

## Ink zugreifen

Lese die Tags der ersten Ink-Form auf einer Folie.
```csharp
static void Access_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Verwenden Sie tagName nach Bedarf
        }
    }
}
```


## Ink entfernen

Lösche eine Ink-Form von der Folie, falls sie existiert.
```csharp
static void Remove_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```
