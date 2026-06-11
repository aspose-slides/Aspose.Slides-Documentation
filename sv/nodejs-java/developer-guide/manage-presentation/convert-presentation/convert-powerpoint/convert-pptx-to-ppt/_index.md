---
title: Konvertera PPTX till PPT i JavaScript
linktitle: PPTX till PPT
type: docs
weight: 21
url: /sv/nodejs-java/convert-pptx-to-ppt/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera enkelt PPTX till PPT med Aspose.Slides—säkerställ sömlös kompatibilitet med PowerPoint-format samtidigt som du bevarar din presentations layout och kvalitet."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar en PowerPoint-presentation i PPTX-format till PPT-format med JavaScript. Följande ämne behandlas.

- Konvertera PPTX till PPT med JavaScript

## **Java Konvertera PPTX till PPT**

För JavaScript-exempelkod för att konvertera PPTX till PPT, se avsnittet nedan, dvs. [Convert PPTX to PPT](#convert-pptx-to-ppt). Det laddar bara PPTX-filen och sparar i PPT-format. Genom att ange olika sparaformat kan du också spara PPTX-filen i många andra format som PDF, XPS, ODP, HTML etc. som diskuteras i dessa artiklar.

- [Konvertera PPTX till PDF i JavaScript](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/)
- [Konvertera PPTX till XPS i JavaScript](/slides/sv/nodejs-java/convert-powerpoint-to-xps/)
- [Konvertera PPTX till HTML i JavaScript](/slides/sv/nodejs-java/convert-powerpoint-to-html/)
- [Konvertera PPTX till ODP i JavaScript](/slides/sv/nodejs-java/save-presentation/)
- [Konvertera PPTX till PNG i JavaScript](/slides/sv/nodejs-java/convert-powerpoint-to-png/)

## **Konvertera PPTX till PPT**

För att konvertera en PPTX till PPT, ange bara filnamnet och sparaformatet till **Save**-metoden i [**Presentation**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)-klassen. JavaScript-exempelkoden nedan konverterar en Presentation från PPTX till PPT med standardalternativ.

```javascript
// skapa ett Presentation-objekt som representerar en PPTX-fil
var presentation = new aspose.slides.Presentation("template.pptx");
// spara presentationen som PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **FAQ**

**Behåller alla PPTX-effekter och funktioner sig när man sparar till det äldre PPT-formatet (97–2003)?**

Inte alltid. PPT-formatet saknar vissa nyare funktioner (t.ex. vissa effekter, objekt och beteenden), så funktioner kan förenklas eller rasteriseras vid konvertering.

**Kan jag konvertera endast valda bilder till PPT istället för hela presentationen?**

Direkt sparande riktas mot hela presentationen. För att konvertera specifika bilder, skapa en ny presentation med bara de bilderna och spara den som PPT; alternativt, använd en tjänst/API som stödjer konvertering per bild.

**Stöds lösenordsskyddade presentationer?**

Ja. Du kan upptäcka om en fil är skyddad, öppna den med ett lösenord, och även [konfigurera skydds-/krypteringsinställningar](/slides/sv/nodejs-java/password-protected-presentation/) för den sparade PPT.