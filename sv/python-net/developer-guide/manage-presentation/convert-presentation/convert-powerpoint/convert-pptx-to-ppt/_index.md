---
title: "Konvertera PPTX till PPT i Python"
linktitle: "PPTX till PPT"
type: docs
weight: 21
url: /sv/python-net/convert-pptx-to-ppt/
keywords:
- "PPTX till PPT"
- "konvertera PPTX till PPT"
- "konvertera PowerPoint"
- "konvertera presentation"
- "Python"
- "Aspose.Slides"
description: "Konvertera enkelt PPTX till PPT med Aspose.Slides för Python via .NET—säkerställ sömlös kompatibilitet med PowerPoint-format samtidigt som du bevarar presentationens layout och kvalitet."
---
## **Översikt**

Aspose.Slides för Python låter dig konvertera moderna PPTX-presentationer till det äldre PPT-formatet helt i kod. Öppna en PPTX och exportera den som PPT samtidigt som presentationens innehåll och layout bevaras, vilket gör resultatet kompatibelt med äldre versioner av PowerPoint. Samma arbetsflöde kan producera andra utdata—såsom PDF, XPS, ODP, HTML eller bilder—så det passar smidigt in i skript, CI-pipelines och batchbehandling.

## **Konvertera PPTX till PPT**

För att konvertera en PPTX till PPT, skicka helt enkelt filnamnet och sparformatet till [save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/)-metoden i [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-klassen. Python‑exemplet nedan konverterar en presentation från PPTX till PPT med standardalternativen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en PPTX-fil.
presentation = slides.Presentation("presentation.pptx")

# Spara presentationen som en PPT-fil.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **Vanliga frågor**

**Behåller alla PPTX‑effekter och -funktioner sin funktion när man sparar till det äldre PPT‑formatet (97–2003)?**

Inte alltid. PPT‑formatet saknar vissa nyare funktioner (t.ex. vissa effekter, objekt och beteenden), så funktioner kan förenklas eller rasteriseras vid konvertering.

**Kan jag konvertera endast utvalda bilder till PPT istället för hela presentationen?**

Direkt sparande riktar sig mot hela presentationen. För att konvertera specifika bilder, skapa en ny presentation med bara dessa bilder och spara den som PPT; alternativt, använd en tjänst/API som stödjer per‑bild‑konverteringsparametrar.

**Stöds lösenordsskyddade presentationer?**

Ja. Du kan upptäcka om en fil är skyddad, öppna den med ett lösenord, och även [configure protection/encryption settings](/slides/sv/python-net/password-protected-presentation/) för den sparade PPT‑filen.

**Se även:**
- [Konvertera PPT & PPTX till PDF i Python | Avancerade alternativ](/slides/sv/python-net/convert-powerpoint-to-pdf/)
- [Konvertera PowerPoint-presentationer till XPS i Python](/slides/sv/python-net/convert-powerpoint-to-xps/)
- [Konvertera PowerPoint-presentationer till HTML i Python](/slides/sv/python-net/convert-powerpoint-to-html/)
- [Konvertera PowerPoint‑bilder till PNG i Python](/slides/sv/python-net/convert-powerpoint-to-png/)