---
title: Konvertera ODP till PPTX i C++
linktitle: ODP till PPTX
type: docs
weight: 10
url: /sv/cpp/convert-odp-to-pptx/
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
- C++
- Aspose.Slides
description: "Konvertera ODP till PPTX med Aspose.Slides för C++. Ren kodexempel, batch-tips och högkvalitativa resultat—ingen PowerPoint behövs."
---
## **Översikt**

Denna artikel förklarar hur man konverterar en ODP‑presentation till PPTX‑format med Aspose.Slides.

## **ODP till PPTX‑konvertering**

Aspose.Slides for .NET erbjuder Presentation‑klassen som representerar en presentationsfil. [**Presentation**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation)‑klassen kan nu också komma åt ODP via Presentation‑konstruktorn när objektet skapas. Följande exempel visar hur man konverterar en ODP‑presentation till en PPTX‑presentation.

``` cpp
// Sökvägen till dokumentkatalogen.
String dataDir = GetDataPath();

// Öppna ODP-filen
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Spara ODP-presentationen i PPTX-format
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Live‑exempel**

Du kan besöka [**Aspose.Slides Conversion**](https://products.aspose.app/slides/sv/conversion/) webapp, som är byggd med **Aspose.Slides API**. Appen demonstrerar hur ODP till PPTX‑konvertering kan implementeras med Aspose.Slides API.

## **FAQ**

**Behöver jag installera Microsoft PowerPoint eller LibreOffice för att konvertera ODP till PPTX?**

Nej. Aspose.Slides fungerar fristående och kräver inga tredjepartsapplikationer för att läsa eller skriva ODP/PPTX.

**Bevaras master‑bilder, layouter och teman vid konvertering?**

Ja. Biblioteket använder en fullständig presentationsobjektmodell och behåller strukturen, inklusive master‑bilder och layouter, så designen förblir korrekt efter konvertering.

**Kan jag konvertera lösenordsskyddade ODP‑filer?**

Ja. Aspose.Slides stödjer detektering av skydd, öppning och arbete med [skyddade presentationer](/slides/sv/cpp/password-protected-presentation/) (inklusive ODP) när du anger lösenordet, samt konfiguration av kryptering och åtkomst till dokumentegenskaper.

**Är Aspose.Slides lämplig för moln‑ eller REST‑baserade konverteringstjänster?**

Ja. Du kan använda det lokala biblioteket i din egen backend eller [Aspose.Slides Cloud](https://products.aspose.cloud/slides/sv/family/) (REST‑API); båda alternativen stödjer ODP → PPTX‑konvertering.