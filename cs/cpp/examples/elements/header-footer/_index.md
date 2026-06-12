---
title: Záhlaví a zápatí
type: docs
weight: 220
url: /cs/cpp/examples/elements/header-footer/
keywords:
- příklad kódu
- záhlaví
- zápatí
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Ovládejte záhlaví a zápatí snímků pomocí Aspose.Slides pro C++: přidejte data, čísla snímků a vlastní text v PPT, PPTX a ODP s ukázkami v C++."
---
Tento článek demonstruje, jak přidat zápatí a aktualizovat zástupce data a času pomocí **Aspose.Slides for C++**.

## **Přidat zápatí**

Přidejte text do oblasti zápatí snímku a udělejte jej viditelným.

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

## **Aktualizovat datum a čas**

Upravte zástupce data a času na snímku.

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