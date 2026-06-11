---
title: Atrament
type: docs
weight: 180
url: /pl/net/examples/elements/ink/
keywords:
- atrament
- dostęp do atramentu
- usuwanie atramentu
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Praca z atramentem w Aspose.Slides dla .NET: rysowanie, importowanie i edytowanie pociągnięć, dostosowywanie koloru i szerokości oraz eksport do PPT, PPTX i ODP przy użyciu przykładów w C#."
---
Ten artykuł zawiera przykłady dostępu do istniejących kształtów atramentu oraz ich usuwania przy użyciu **Aspose.Slides for .NET**.

> ❗ **Uwaga:** Kształty atramentu reprezentują dane wprowadzane przez użytkownika za pomocą specjalistycznych urządzeń. Aspose.Slides nie może programowo tworzyć nowych pociągnięć atramentu, ale możesz odczytywać i modyfikować istniejący atrament.

## **Dostęp do atramentu**

Odczytaj tagi z pierwszego kształtu atramentu na slajdzie.

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
            // Użyj tagName w razie potrzeby.
        }
    }
}
```

## **Usuwanie atramentu**

Usuń kształt atramentu ze slajdu, jeśli istnieje.

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