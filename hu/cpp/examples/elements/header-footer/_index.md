---
title: Fejléc és lábléc
type: docs
weight: 220
url: /hu/cpp/examples/elements/header-footer/
keywords:
- kódpélda
- fejléc
- lábléc
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "A slide fejléc és lábléc vezérlése az Aspose.Slides for C++ segítségével: dátumok, dia számok, és egyéni szöveg hozzáadása PPT, PPTX és ODP fájlokhoz C++ példákkal."
---
Ez a cikk bemutatja, hogyan lehet láblécet hozzáadni és a dátum és idő helyőrzőket frissíteni az **Aspose.Slides for C++** használatával.

## **Lábléc hozzáadása**

Adjon szöveget a dia lábléc területéhez, és tegye láthatóvá.

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

## **Dátum és idő frissítése**

Módosítsa a dia dátum és idő helyőrzőjét.

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