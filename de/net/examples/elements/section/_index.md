---
title: Abschnitt
type: docs
weight: 90
url: /de/net/examples/elements/section/
keywords:
- Abschnitt Beispiel
- Folienabschnitt
- Abschnitt hinzufügen
- Abschnitt abrufen
- Abschnitt entfernen
- Abschnitt umbenennen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte in C# mit Aspose.Slides: einfach erstellen, umbenennen, neu anordnen, Folien zwischen Abschnitten verschieben und die Sichtbarkeit für PPT, PPTX und ODP steuern."
---

Beispiele für die Verwaltung von Präsentationsabschnitten—Hinzufügen, Zugreifen, Entfernen und Umbenennen programmatisch mit **Aspose.Slides for .NET**.

## Abschnitt hinzufügen

Erstellen Sie einen Abschnitt, der bei einer bestimmten Folie beginnt.
```csharp
static void Add_Section()
{
    using var pres = new Presentation();

    // Geben Sie die Folie an, die den Beginn des Abschnitts markiert
    pres.Sections.AddSection("New Section", pres.Slides[0]);
}
```


## Abschnitt abrufen

Lesen Sie Abschnittsinformationen aus einer Präsentation.
```csharp
static void Access_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("My Section", pres.Slides[0]);

    // Abschnitt über Index zugreifen
    var section = pres.Sections[0];
    var sectionName = section.Name;
}
```


## Abschnitt entfernen

Löschen Sie einen zuvor hinzugefügten Abschnitt.
```csharp
static void Remove_Section()
{
    using var pres = new Presentation();
    var section = pres.Sections.AddSection("Temporary Section", pres.Slides[0]);

    // Entferne den ersten Abschnitt
    pres.Sections.RemoveSection(section);
}
```


## Abschnitt umbenennen

Ändern Sie den Namen eines bestehenden Abschnitts.
```csharp
static void Rename_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("Old Name", pres.Slides[0]);

    var section = pres.Sections[0];
    section.Name = "New Name";
}
```
