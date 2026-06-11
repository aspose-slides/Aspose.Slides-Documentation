---
title: Konvertera PPTX till PPT i PHP
linktitle: PPTX till PPT
type: docs
weight: 21
url: /sv/php-java/convert-pptx-to-ppt/
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
- PHP
- Aspose.Slides
description: "Konvertera enkelt PPTX till PPT med Aspose.Slides — säkerställ sömlös kompatibilitet med PowerPoint-format samtidigt som du bevarar presentationens layout och kvalitet."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar en PowerPoint-presentation i PPTX-format till PPT-format med PHP. Följande ämne behandlas.

- Konvertera PPTX till PPT

## **Konvertera PPTX till PPT i PHP**

För Java‑exempelkod för att konvertera PPTX till PPT, se avsnittet nedan, dvs. [Konvertera PPTX till PPT](#convert-pptx-to-ppt). Det laddar bara PPTX‑filen och sparar i PPT‑format. Genom att ange olika sparformat kan du också spara PPTX‑filen i många andra format som PDF, XPS, ODP, HTML etc. som diskuteras i dessa artiklar.

- [Konvertera PPTX till PDF i PHP](/slides/sv/php-java/convert-powerpoint-to-pdf/)
- [Konvertera PPTX till XPS i PHP](/slides/sv/php-java/convert-powerpoint-to-xps/)
- [Konvertera PPTX till HTML i PHP](/slides/sv/php-java/convert-powerpoint-to-html/)
- [Konvertera PPTX till ODP i PHP](/slides/sv/php-java/save-presentation/)
- [Konvertera PPTX till PNG i PHP](/slides/sv/php-java/convert-powerpoint-to-png/)

## **Konvertera PPTX till PPT**
För att konvertera en PPTX till PPT, skicka helt enkelt filnamnet och sparformatet till **Save**‑metoden i klassen [**Presentation**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation). PHP‑kodexemplet nedan konverterar en Presentation från PPTX till PPT med standardalternativ.

```php
  # instansiera ett Presentation-objekt som representerar en PPTX-fil
  $presentation = new Presentation("template.pptx");
  # spara presentationen som PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **Vanliga frågor**

**Behåller alla PPTX‑effekter och funktioner sig när du sparar till det äldre PPT‑formatet (97–2003)?**

Inte alltid. PPT‑formatet saknar vissa nyare funktioner (t.ex. vissa effekter, objekt och beteenden), så funktioner kan förenklas eller rasteriseras vid konvertering.

**Kan jag konvertera endast utvalda bilder till PPT istället för hela presentationen?**

Direkt sparande riktar sig mot hela presentationen. För att konvertera specifika bilder, skapa en ny presentation med bara dessa bilder och spara den som PPT; alternativt, använd en tjänst/API som stöder konverteringsparametrar per bild.

**Stöds lösenordsskyddade presentationer?**

Ja. Du kan upptäcka om en fil är skyddad, öppna den med ett lösenord och också [konfigurera skydds-/krypteringsinställningar](/slides/sv/php-java/password-protected-presentation/) för den sparade PPT‑filen.