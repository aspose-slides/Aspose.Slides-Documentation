---
title: Fejléc lábléc
type: docs
weight: 220
url: /hu/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- fejléc lábléc
- fejléc és lábléc hozzáadása
- fejléc és lábléc frissítése
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Kezelje a diafejléceket és lábléceket az Aspose.Slides for .NET segítségével: adjon hozzá dátumokat, diaszámokat és egyéni szöveget PPT, PPTX és ODP fájlokban C# példákkal."
---
Ez a cikk bemutatja, hogyan adhat hozzá lábléceket, és frissítheti a dátum- és időhelyőrzőket a **Aspose.Slides for .NET** használatával.

## **Lábléc hozzáadása**

Adjon szöveget a dia lábléc területéhez, és tegye láthatóvá.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Dátum és idő frissítése**

Módosítsa a dátum- és időhelyőrzőt egy dián.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```