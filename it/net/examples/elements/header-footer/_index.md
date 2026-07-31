---
title: Intestazione e piè di pagina
type: docs
weight: 220
url: /it/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- intestazione e piè di pagina
- aggiungi intestazione e piè di pagina
- aggiorna intestazione e piè di pagina
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci le intestazioni e i piè di pagina delle slide con Aspose.Slides per .NET: aggiungi date, numeri di slide e testo personalizzato in PPT, PPTX e ODP con esempi in C#."
---
Questo articolo mostra come aggiungere piè di pagina e aggiornare i segnaposto di data e ora utilizzando **Aspose.Slides for .NET**.

## **Aggiungi un piè di pagina**

Aggiungi testo all'area del piè di pagina di una slide e rendilo visibile.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Aggiorna data e ora**

Modifica il segnaposto di data e ora su una slide.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```