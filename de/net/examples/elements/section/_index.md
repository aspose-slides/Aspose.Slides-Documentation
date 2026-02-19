---
title: Abschnitt
type: docs
weight: 90
url: /de/net/examples/elements/section/
keywords:
- Abschnitt
- Folienabschnitt
- Abschnitt hinzufügen
- Zugriff auf Abschnitt
- Abschnitt entfernen
- Abschnitt umbenennen
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte in Aspose.Slides für .NET: erstellen, umbenennen, neu anordnen und Folien gruppieren mit C#‑Beispielen für PPT, PPTX und ODP."
---
Beispiele für die Verwaltung von Präsentationsabschnitten — hinzufügen, darauf zugreifen, entfernen und umbenennen, programmgesteuert mit **Aspose.Slides for .NET**.

## **Abschnitt hinzufügen**

Erstellen Sie einen Abschnitt, der bei einer bestimmten Folie beginnt.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Geben Sie die Folie an, die den Beginn des Abschnitts markiert.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Zugriff auf einen Abschnitt**

Lesen Sie Abschnittsinformationen aus einer Präsentation.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Zugriff auf einen Abschnitt nach Index.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Abschnitt entfernen**

Löschen Sie einen zuvor hinzugefügten Abschnitt.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Entfernen Sie den ersten Abschnitt.
    presentation.Sections.RemoveSection(section);
}
```

## **Abschnitt umbenennen**

Ändern Sie den Namen eines vorhandenen Abschnitts.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```