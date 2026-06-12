---
title: Inchiostro
type: docs
weight: 180
url: /it/net/examples/elements/ink/
keywords:
- inchiostro
- accedere all'inchiostro
- rimuovere inchiostro
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Lavora con l'inchiostro in Aspose.Slides per .NET: disegna, importa e modifica i tratti, regola colore e larghezza e esporta in PPT, PPTX e ODP usando esempi C#."
---
Questo articolo fornisce esempi di accesso alle forme di inchiostro esistenti e della loro rimozione utilizzando **Aspose.Slides for .NET**.

> ❗ **Nota:** Le forme di inchiostro rappresentano l'input dell'utente da dispositivi specializzati. Aspose.Slides non può creare nuovi tratti di inchiostro programmaticamente, ma è possibile leggere e modificare l'inchiostro esistente.

## **Accedi all'inchiostro**

Leggi i tag dalla prima forma di inchiostro in una diapositiva.

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
            // Utilizza tagName secondo necessità.
        }
    }
}
```

## **Rimuovi l'inchiostro**

Elimina una forma di inchiostro dalla diapositiva se ne esiste una.

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