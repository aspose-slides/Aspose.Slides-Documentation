---
title: Konvertera PPTX till PPT i .NET
linktitle: PPTX till PPT
type: docs
weight: 21
url: /sv/net/convert-pptx-to-ppt/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPTX
- PPTX till PPT
- spara PPTX som PPT
- exportera PPTX till PPT
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Konvertera enkelt PPTX till PPT med Aspose.Slides för .NET—säkerställ sömlös kompatibilitet med PowerPoint-format samtidigt som du bevarar presentationens layout och kvalitet."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar en PowerPoint-presentation i PPTX-format till PPT-format med C#. Följande ämne behandlas.

- Konvertera PPTX till PPT i C#

## **Konvertera PPTX till PPT i .NET**

För C#-exempelkod för att konvertera PPTX till PPT, se avsnittet nedan, dvs.[Convert PPTX to PPT](#convert-pptx-to-ppt). Det laddar bara PPTX-filen och sparar i PPT-format. Genom att ange olika sparformat kan du också spara PPTX-filen i många andra format som PDF, XPS, ODP, HTML osv., som diskuteras i dessa artiklar. 

- [Konvertera PPTX till PDF i .NET](/slides/sv/net/convert-powerpoint-to-pdf/)
- [Konvertera PPTX till XPS i .NET](/slides/sv/net/convert-powerpoint-to-xps/)
- [Konvertera PPTX till HTML i .NET](/slides/sv/net/convert-powerpoint-to-html/)
- [Konvertera PPTX till ODP i .NET](/slides/sv/net/save-presentation/)
- [Konvertera PPTX till PNG i .NET](/slides/sv/net/convert-powerpoint-to-png/)

## **Konvertera PPTX till PPT**
För att konvertera en PPTX till PPT, skicka bara filnamnet och sparformatet till [**Save**](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/)‑metoden i [**Presentation**](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑klassen. C#‑kodexemplet nedan konverterar en Presentation från PPTX till PPT med standardalternativ.

```c#
// Instansiera ett Presentation‑objekt som representerar en PPTX‑fil
Presentation pres = new Presentation("presentation.pptx");

// Sparar PPTX‑presentationen i PPT‑format
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **FAQ**

**Bevaras alla PPTX-effekter och funktioner när de sparas i det äldre PPT (97–2003)-formatet?**

Inte alltid. PPT-formatet saknar vissa nyare funktioner (t.ex. vissa effekter, objekt och beteenden), så funktioner kan förenklas eller rasteriseras under konverteringen.

**Kan jag bara konvertera utvalda bilder till PPT istället för hela presentationen?**

Direkt sparande sparar hela presentationen. För att konvertera specifika bilder, skapa en ny presentation med endast dessa bilder och spara den som PPT; alternativt använd en tjänst/API som stöder konverteringsparametrar per bild.

**Stöds lösenordsskyddade presentationer?**

Ja. Du kan upptäcka om en fil är skyddad, öppna den med ett lösenord, och även [konfigurera skydds-/krypteringsinställningar](/slides/sv/net/password-protected-presentation/) för den sparade PPT.