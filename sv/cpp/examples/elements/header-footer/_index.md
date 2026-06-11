---
title: Sidhuvud och sidfot
type: docs
weight: 220
url: /sv/cpp/examples/elements/header-footer/
keywords:
- kodexempel
- sidhuvud
- sidfot
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Kontrollera bildhuvuden och bildfötter med Aspose.Slides för C++: lägg till datum, bildnummer och anpassad text i PPT, PPTX och ODP med C++-exempel."
---
Den här artikeln visar hur man lägger till sidfötter och uppdaterar datum- och tidsplatshållare med **Aspose.Slides for C++**.

## **Lägg till en sidfot**

Lägg till text i sidfotområdet på en bild och gör den synlig.

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

## **Uppdatera datum och tid**

Ändra datum- och tidsplatshållaren på en bild.

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