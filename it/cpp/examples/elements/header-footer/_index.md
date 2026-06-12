---
title: Intestazione Piè di pagina
type: docs
weight: 220
url: /it/cpp/examples/elements/header-footer/
keywords:
- esempio di codice
- intestazione
- piè di pagina
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Controlla le intestazioni e i piè di pagina delle diapositive con Aspose.Slides per C++: aggiungi date, numeri di diapositiva e testo personalizzato in PPT, PPTX e ODP con esempi C++."
---
Questo articolo dimostra come aggiungere i piè di pagina e aggiornare i segnaposti di data e ora usando **Aspose.Slides for C++**.

## **Aggiungi un piè di pagina**

Aggiungi del testo all'area del piè di pagina di una diapositiva e rendilo visibile.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Aggiorna data e ora**

Modifica il segnaposto di data e ora su una diapositiva.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```