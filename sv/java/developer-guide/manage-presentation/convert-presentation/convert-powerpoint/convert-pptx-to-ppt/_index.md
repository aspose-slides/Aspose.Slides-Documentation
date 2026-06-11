---
title: Konvertera PPTX till PPT i Java
linktitle: PPTX till PPT
type: docs
weight: 21
url: /sv/java/convert-pptx-to-ppt/
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
- Java
- Aspose.Slides
description: "Konvertera enkelt PPTX till PPT med Aspose.Slides för Java—säkerställ sömlös kompatibilitet med PowerPoint-format samtidigt som du bevarar din presentations layout och kvalitet."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar PowerPoint-presentation i PPTX-format till PPT-format med Java. Följande ämne behandlas.

- Konvertera PPTX till PPT i Java

## **Konvertera PPTX till PPT i Java**

För Java-exempelkod för att konvertera PPTX till PPT, se avsnittet nedan, dvs. [Convert PPTX to PPT](#convert-pptx-to-ppt). Den laddar bara PPTX-filen och sparar i PPT-format. Genom att ange olika sparformat kan du också spara PPTX-filen i många andra format som PDF, XPS, ODP, HTML osv., som diskuteras i dessa artiklar. 

- [Konvertera PPTX till PDF i Java](/slides/sv/java/convert-powerpoint-to-pdf/)
- [Konvertera PPTX till XPS i Java](/slides/sv/java/convert-powerpoint-to-xps/)
- [Konvertera PPTX till HTML i Java](/slides/sv/java/convert-powerpoint-to-html/)
- [Konvertera PPTX till ODP i Java](/slides/sv/java/save-presentation/)
- [Konvertera PPTX till PNG i Java](/slides/sv/java/convert-powerpoint-to-png/)

## **Konvertera PPTX till PPT**
För att konvertera en PPTX till PPT, skicka bara filnamnet och sparformatet till **Save**-metoden i klassen [**Presentation**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation). Java-kodexemplet nedan konverterar en Presentation från PPTX till PPT med standardalternativ.

```java
// skapa ett Presentation-objekt som representerar en PPTX-fil
Presentation presentation = new Presentation("template.pptx");

// spara presentationen som PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **Vanliga frågor**

**Blir alla PPTX-effekter och funktioner bevarade när man sparar till det äldre PPT-formatet (97–2003)?**

Inte alltid. PPT-formatet saknar vissa nyare funktioner (t.ex. vissa effekter, objekt och beteenden), så funktionerna kan förenklas eller rasteriseras vid konverteringen.

**Kan jag konvertera endast utvalda bilder till PPT istället för hela presentationen?**

Direkt sparning gäller hela presentationen. För att konvertera specifika bilder, skapa en ny presentation som bara innehåller dessa bilder och spara den som PPT; alternativt, använd en tjänst/API som stöder konverteringsparametrar per bild.

**Stöds lösenordsskyddade presentationer?**

Ja. Du kan upptäcka om en fil är skyddad, öppna den med ett lösenord, och även [konfigurera skydds-/krypteringsinställningar](/slides/sv/java/password-protected-presentation/) för den sparade PPT-filen.