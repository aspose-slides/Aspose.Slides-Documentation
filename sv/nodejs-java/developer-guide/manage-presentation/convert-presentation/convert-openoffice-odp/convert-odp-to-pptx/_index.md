---
title: Konvertera ODP till PPTX i JavaScript
linktitle: ODP till PPTX
type: docs
weight: 10
url: /sv/nodejs-java/convert-odp-to-pptx/
keywords:
- konvertera OpenDocument
- konvertera presentation
- konvertera bild
- konvertera ODP
- OpenDocument till PPTX
- ODP till PPTX
- spara ODP som PPTX
- exportera ODP till PPTX
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera ODP till PPTX med Aspose.Slides för Node.js. Ren JavaScript-kodexempel, batch-tips och högkvalitativa resultat—ingen PowerPoint behövs."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar en ODP‑presentation till PPTX‑format med Aspose.Slides.

## **Konvertera ODP till PPTX/PPT-presentation**
Aspose.Slides för Node.js via Java erbjuder klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som representerar en presentationsfil. Klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) kan nu även komma åt ODP via [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-)-konstruktorn när objektet instanseras. Följande exempel visar hur man konverterar en ODP‑presentation till en PPTX‑presentation.

```javascript
// Öppna ODP-filen
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// Sparar ODP-presentationen i PPTX-format
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Live‑exempel**
Du kan besöka [**Aspose.Slides Conversion**](https://products.aspose.app/slides/sv/conversion/) webapp, som är byggd med **Aspose.Slides API.** Appen visar hur ODP‑till‑PPTX‑konvertering kan implementeras med Aspose.Slides API.

## **FAQ**

**Behöver jag installera Microsoft PowerPoint eller LibreOffice för att konvertera ODP till PPTX?**

Nej. Aspose.Slides fungerar fristående och kräver inga tredjepartsprogram för att läsa eller skriva ODP/PPTX.

**Bevaras masterbilder, layouter och teman under konverteringen?**

Ja. Biblioteket använder en fullständig presentationsobjektmodell och behåller strukturen, inklusive masterbilder och layouter, så designen förblir korrekt efter konverteringen.

**Kan jag konvertera lösenordsskyddade ODP‑filer?**

Ja. Aspose.Slides stödjer att upptäcka skydd, öppna och arbeta med [protected presentations](/slides/sv/nodejs-java/password-protected-presentation/) (inklusive ODP) när du anger lösenordet, samt att konfigurera kryptering och åtkomst till dokumentegenskaper.

**Är Aspose.Slides lämplig för moln‑ eller REST‑baserade konverteringstjänster?**

Ja. Du kan använda det lokala biblioteket i din egen backend eller [Aspose.Slides Cloud](https://products.aspose.cloud/slides/sv/family/) (REST‑API); båda alternativen stödjer ODP → PPTX‑konvertering.