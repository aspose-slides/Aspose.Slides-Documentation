---
title: Konvertera ODP till PPTX i PHP
linktitle: ODP till PPTX
type: docs
weight: 10
url: /sv/php-java/convert-odp-to-pptx/
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
- PHP
- Aspose.Slides
description: "Konvertera ODP till PPTX med Aspose.Slides för PHP via Java. Rena kodexempel, batchtips och högkvalitativa resultat—ingen PowerPoint behövs."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar en ODP-presentation till PPTX-format med Aspose.Slides.

## **Konvertera ODP till PPTX/PPT-presentation**
Aspose.Slides för PHP via Java erbjuder klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som representerar en presentationsfil. Klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) kan nu även komma åt ODP via [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation#Presentation-java.lang.String-)‑konstruktorn när objektet skapas. Följande exempel visar hur du konverterar en ODP-presentation till en PPTX-presentation.

```php
// Öppna ODP-filen
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Sparar ODP-presentationen till PPTX-format
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Live-exempel**
Du kan besöka [**Aspose.Slides Conversion**](https://products.aspose.app/slides/sv/conversion/) webbapp, som är byggd med **Aspose.Slides API.** Appen demonstrerar hur ODP‑till‑PPTX‑konvertering kan implementeras med Aspose.Slides API.

## **Vanliga frågor**

**Behöver jag installera Microsoft PowerPoint eller LibreOffice för att konvertera ODP till PPTX?**

Nej. Aspose.Slides fungerar fristående och kräver inga tredjepartsprogram för att läsa eller skriva ODP/PPTX.

**Behålls masterbilder, layouter och teman under konverteringen?**

Ja. Biblioteket använder en komplett presentationsobjektmodell och behåller strukturen, inklusive masterbilder och layouter, så designen förblir korrekt efter konverteringen.

**Kan jag konvertera lösenordsskyddade ODP‑filer?**

Ja. Aspose.Slides stöder detektering av skydd, öppning och arbete med [protected presentations](/slides/sv/php-java/password-protected-presentation/) (inklusive ODP) när du anger lösenordet, samt konfiguration av kryptering och åtkomst till dokumentegenskaper.

**Är Aspose.Slides lämplig för moln‑ eller REST‑baserade konverteringstjänster?**

Ja. Du kan använda det lokala biblioteket i din egen backend eller [Aspose.Slides Cloud](https://products.aspose.cloud/slides/sv/family/) (REST API); båda alternativen stödjer ODP → PPTX‑konvertering.