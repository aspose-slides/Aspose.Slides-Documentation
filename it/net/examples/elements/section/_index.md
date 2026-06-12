---
title: Sezione
type: docs
weight: 90
url: /it/net/examples/elements/section/
keywords:
- sezione
- sezione diapositiva
- aggiungi sezione
- accedi sezione
- rimuovi sezione
- rinomina sezione
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive in Aspose.Slides per .NET: crea, rinomina, riordina e raggruppa le diapositive con esempi C# per PPT, PPTX e ODP."
---
Esempi per gestire le sezioni di una presentazione—aggiungere, accedere, rimuovere e rinominare programmaticamente utilizzando **Aspose.Slides per .NET**.

## **Aggiungi una sezione**

Crea una sezione che inizia a una diapositiva specifica.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Specificare la diapositiva che segna l'inizio della sezione.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Accedi a una sezione**

Leggi le informazioni sulla sezione da una presentazione.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Accedi a una sezione per indice.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Rimuovi una sezione**

Elimina una sezione precedentemente aggiunta.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Rimuovi la prima sezione.
    presentation.Sections.RemoveSection(section);
}
```

## **Rinomina una sezione**

Modifica il nome di una sezione esistente.

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