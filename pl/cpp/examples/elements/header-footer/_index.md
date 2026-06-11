---
title: Nagłówek i stopka
type: docs
weight: 220
url: /pl/cpp/examples/elements/header-footer/
keywords:
- przykład kodu
- nagłówek
- stopka
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Kontroluj nagłówki i stopki slajdów przy użyciu Aspose.Slides for C++: dodawaj daty, numery slajdów i własny tekst w formatach PPT, PPTX i ODP w przykładach C++."
---
Ten artykuł demonstruje, jak dodać stopki i zaktualizować znaczniki daty i godziny przy użyciu **Aspose.Slides for C++**.

## **Dodaj stopkę**

Dodaj tekst do obszaru stopki slajdu i spraw, aby był widoczny.

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

## **Zaktualizuj datę i godzinę**

Zmień znacznik daty i godziny na slajdzie.

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