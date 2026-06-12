---
title: Koptekst en voettekst
type: docs
weight: 220
url: /nl/cpp/examples/elements/header-footer/
keywords:
- codevoorbeeld
- koptekst
- voettekst
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer slide-kopteksten en -voetteksten met Aspose.Slides for C++: voeg datums, slide-nummers en aangepaste tekst toe in PPT, PPTX en ODP met C++-voorbeelden."
---
Dit artikel toont hoe u voetteksten kunt toevoegen en placeholders voor datum en tijd kunt bijwerken met **Aspose.Slides for C++**.

## **Voettekst toevoegen**

Voeg tekst toe aan het voettekstgebied van een dia en maak deze zichtbaar.

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

## **Datum en tijd bijwerken**

Wijzig de placeholder voor datum en tijd op een dia.

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