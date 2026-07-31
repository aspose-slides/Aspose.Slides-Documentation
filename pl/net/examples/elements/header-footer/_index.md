---
title: Nagłówek i stopka
type: docs
weight: 220
url: /pl/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- nagłówek stopka
- dodaj nagłówek i stopkę
- zaktualizuj nagłówek stopka
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Steruj nagłówkami i stopkami slajdów przy użyciu Aspose.Slides dla .NET: dodawaj daty, numery slajdów i własny tekst w formatach PPT, PPTX i ODP z przykładami w C#."
---
Ten artykuł demonstruje, jak dodać stopki i zaktualizować znaczniki daty i godziny przy użyciu **Aspose.Slides for .NET**.

## **Dodaj stopkę**

Dodaj tekst do obszaru stopki w slajdzie i spraw, aby był widoczny.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Zaktualizuj datę i godzinę**

Zmodyfikuj znacznik daty i godziny na slajdzie.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```