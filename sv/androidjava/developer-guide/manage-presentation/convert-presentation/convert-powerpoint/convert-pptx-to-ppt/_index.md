---
title: Konvertera PPTX till PPT på Android
linktitle: PPTX till PPT
type: docs
weight: 21
url: /sv/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Konvertera enkelt PPTX till PPT med Aspose.Slides för Android via Java—säkra sömlös kompatibilitet med PowerPoint-format samtidigt som du bevarar presentationens layout och kvalitet."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar PowerPoint-presentation i PPTX-format till PPT-format med Java. Följande ämne behandlas.

- Konvertera PPTX till PPT i Java

## **Konvertera PPTX till PPT på Android**

För Java-exempelkod för att konvertera PPTX till PPT, se avsnittet nedan, dvs. [Convert PPTX to PPT](#convert-pptx-to-ppt). Den laddar bara PPTX-filen och sparar i PPT-format. Genom att ange olika sparformat kan du också spara PPTX-filen i många andra format som PDF, XPS, ODP, HTML osv. som diskuteras i dessa artiklar. 

- [Konvertera PPTX till PDF på Android](/slides/sv/androidjava/convert-powerpoint-to-pdf/)
- [Konvertera PPTX till XPS på Android](/slides/sv/androidjava/convert-powerpoint-to-xps/)
- [Konvertera PPTX till HTML på Android](/slides/sv/androidjava/convert-powerpoint-to-html/)
- [Konvertera PPTX till ODP på Android](/slides/sv/androidjava/save-presentation/)
- [Konvertera PPTX till PNG på Android](/slides/sv/androidjava/convert-powerpoint-to-png/)

## **Konvertera PPTX till PPT**
För att konvertera en PPTX till PPT, skicka bara filnamnet och sparformatet till **Save**‑metoden i klassen [**Presentation**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation). Java‑kodexemplet nedan konverterar en Presentation från PPTX till PPT med standardalternativ.

```java
// instansiera ett Presentation-objekt som representerar en PPTX-fil
Presentation presentation = new Presentation("template.pptx");

// spara presentationen som PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Behåller alla PPTX‑effekter och funktioner sig när de sparas i det äldre PPT‑formatet (97–2003)?**

Inte alltid. PPT‑formatet saknar vissa nyare funktioner (t.ex. vissa effekter, objekt och beteenden), så funktioner kan förenklas eller rasteriseras vid konvertering.

**Kan jag bara konvertera utvalda bilder till PPT istället för hela presentationen?**

Direkt sparning gäller hela presentationen. För att konvertera specifika bilder, skapa en ny presentation med endast dessa bilder och spara den som PPT; alternativt kan du använda en tjänst/API som stödjer konverteringsparametrar per bild.

**Stöds lösenordsskyddade presentationer?**

Ja. Du kan upptäcka om en fil är skyddad, öppna den med ett lösenord, och även [konfigurera skydds‑/krypteringsinställningar](/slides/sv/androidjava/password-protected-presentation/) för den sparade PPT‑filen.