---
title: Tinte
type: docs
weight: 180
url: /de/net/examples/elements/ink/
keywords:
- Tintenbeispiel
- Zugriff auf Tinte
- Tinte entfernen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie digitale Tinte auf Folien in C# mit Aspose.Slides: Fügen Sie Stiftstriche hinzu, bearbeiten Sie Pfade, setzen Sie Farbe und Breite und exportieren Sie die Ergebnisse für PowerPoint und OpenDocument."
---

Bietet Beispiele für den Zugriff auf vorhandene Ink-Formen und deren Entfernung mit **Aspose.Slides for .NET**.

> ❗ **Hinweis:** Ink-Formen stellen Benutzereingaben von spezialisierten Geräten dar. Aspose.Slides kann keine neuen Ink-Striche programmgesteuert erzeugen, aber Sie können vorhandene Ink lesen und ändern.

## **Access Ink**
Liest die Tags der ersten Ink-Form auf einer Folie.
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


## **Remove Ink**
Löscht eine Ink-Form von der Folie, falls eine vorhanden ist.
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
