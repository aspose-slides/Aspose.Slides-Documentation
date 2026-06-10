---
title: Fejléc és lábléc
type: docs
weight: 220
url: /hu/net/examples/elements/header-footer/
keywords:
- fejléc és lábléc
- fejléc és lábléc hozzáadása
- fejléc és lábléc frissítése
- kód példa
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "A diák fejléceinek és láblécinek vezérlése az Aspose.Slides for .NET használatával: dátumok, dia számok és egyéni szöveg hozzáadása PPT, PPTX és ODP formátumokban C# példákkal."
---
Ez a cikk bemutatja, hogyan adhat hozzá láblécet, és frissítheti a dátum- és időhelyettesítőket az **Aspose.Slides for .NET** használatával.

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

Módosítsa a dia dátum- és időhelyettesítőjét.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```