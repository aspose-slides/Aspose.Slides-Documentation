---
title: Konvertera ODP till PPTX i .NET
linktitle: ODP till PPTX
type: docs
weight: 10
url: /sv/net/convert-odp-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertera ODP till PPTX med Aspose.Slides för .NET. Ren C#-kodexempel, batch‑tips och högkvalitativa resultat—ingen PowerPoint behövs."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar en ODP‑presentation till PPTX‑format med Aspose.Slides.

## **ODP till PPTX‑konvertering**

Aspose.Slides för .NET erbjuder Presentation‑klassen som representerar en presentationsfil. [**Presentation**](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen kan nu även öppna ODP via Presentation‑konstruktorn när objektet skapas. Följande exempel visar hur man konverterar en ODP‑presentation till en PPTX‑presentation.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Steg: Konvertera ODP till PPTX i C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Steg: Konvertera ODP till PowerPoint i C#</strong></a>

```c#
// Öppna ODP-filen
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Sparar ODP-presentationen till PPTX-format
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Live‑exempel**

Du kan besöka webbappen [**Aspose.Slides‑konvertering**](https://products.aspose.app/slides/sv/conversion/) som är byggd med **Aspose.Slides API.** Appen demonstrerar hur ODP‑till‑PPTX‑konvertering kan implementeras med Aspose.Slides API.

## **Vanliga frågor**

**Behöver jag installera Microsoft PowerPoint eller LibreOffice för att konvertera ODP till PPTX?**

Nej. Aspose.Slides fungerar fristående och kräver inga tredjepartsapplikationer för att läsa eller skriva ODP/PPTX.

**Behålls huvudbilder, layouter och teman vid konverteringen?**

Ja. Biblioteket använder en komplett presentationsobjektmodell och behåller strukturen, inklusive huvudbilder och layouter, så designen förblir korrekt efter konverteringen.

**Kan jag konvertera lösenordsskyddade ODP‑filer?**

Ja. Aspose.Slides stöder att upptäcka skydd, öppna och arbeta med [skyddade presentationer](/slides/sv/net/password-protected-presentation/) (inklusive ODP) när du anger lösenordet, samt att konfigurera kryptering och åtkomst till dokumentegenskaper.

**Är Aspose.Slides lämplig för moln- eller REST‑baserade konverteringstjänster?**

Ja. Du kan använda det lokala biblioteket i ditt eget backend eller [Aspose.Slides Cloud](https://products.aspose.cloud/slides/sv/family/) (REST‑API); båda alternativen stöder ODP → PPTX‑konvertering.