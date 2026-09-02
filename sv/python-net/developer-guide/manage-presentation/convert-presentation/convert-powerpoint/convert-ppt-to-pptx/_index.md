---
title: Konvertera PPT till PPTX i Python
linktitle: PPT till PPTX
type: docs
weight: 20
url: /sv/python-net/convert-ppt-to-pptx/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- PPT till PPTX
- spara PPT som PPTX
- exportera PPT till PPTX
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Konvertera äldre PPT-filer till PPTX i Python med Aspose.Slides. Inkluderar exempel för enskild fil- och batchkonvertering, felhantering och noteringar om fidelitet."
---
## **Översikt**

PPT är det äldre binära PowerPoint-formatet, medan PPTX är det nyare Open XML-formatet. Aspose.Slides för Python via .NET kan läsa in en PPT‑fil och spara den som PPTX utan Microsoft PowerPoint. Den här artikeln visar hur du konverterar en fil eller en katalog med filer och förklarar vad du bör kontrollera efter konverteringen.

## **Konvertera en PPT‑fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/), anropa sedan [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) med [SaveFormat.PPTX](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/). `with`‑satsen disponerar presentationen och frigör dess resurser när blocket avslutas.

```python
import aspose.slides as slides

# Läs in den äldre PPT-presentationen.
with slides.Presentation("presentation.ppt") as presentation:
    # Spara presentationen i PPTX-format.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Filändelsen väljer inte utdataformatet av sig själv; argumentet [SaveFormat.PPTX](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/) gör det. Håll in- och utmatningssökvägarna olika om du behöver behålla den ursprungliga PPT‑filen.

## **Konvertera flera PPT‑filer**

Följande exempel konverterar varje `.ppt`‑fil i en katalog. Varje fil behandlas oberoende, så en misslyckad konvertering stoppar inte resten av batchen.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

För produktionsarbetsbelastningar, logga hela undantaget, avgör om en befintlig utdatfil får skrivas över, och skriv namn på misslyckade filer till en återförsök‑ eller granskningskö. Korrupta filer, lösenordsskyddade filer som öppnas utan rätt lösenord, otillgängliga sökvägar och innehåll som inte stöds kan alla leda till att en konvertering misslyckas. Se [Password-Protected Presentations](/python-net/password-protected-presentation/) för att läsa in krypterade filer.

## **Fidelitet och äldre funktioner**

Konvertering bevarar normalt bilder, master‑bilder, layouter, text, former, bilder, tabeller och diagram. Men PPT och PPTX representerar dock inte varje funktion på exakt samma sätt. En äldre funktion som saknar motsvarande i PPTX, eller som inte stöds av biblioteket, kan normaliseras, utelämnas eller visas annorlunda.

Kontrollera den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE‑objekt, ActiveX‑kontroller, inbäddade media, ovanliga teckensnitt eller VBA‑makron. En vanlig PPTX‑fil är inte ett makro‑aktiverat format, så använd ett lämpligt makro‑aktiverat arbetsflöde när VBA måste vara tillgängligt. Verifiera också att nödvändiga teckensnitt och externa resurser finns i den miljö där den konverterade presentationen kommer att öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX‑filen programatiskt och inspektera viktiga bildantal och innehåll, jämför sedan dess utseende och bildspelsbeteende i den avsedda visaren. Betrakta inte ett lyckat anrop till [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) som bevis på att varje äldre funktion har en exakt PPTX‑representation.

## **När man ska använda PPTX**

Använd PPTX när presentationen ska redigeras i aktuella PowerPoint‑versioner, utbytas med system som arbetar med Open XML‑paket, eller lagras i ett format som är enklare att inspektera och återställa än det äldre binära PPT‑formatet. Behåll den ursprungliga PPT‑filen som ett arkiv‑ eller återställningskopi tills den konverterade presentationen har klarat dina fidelitetskontroller.

Om du istället behöver PDF, HTML, bilder, XPS eller någon annan utmatningstyp, använd format‑specifik vägledning i [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) istället för att anta att alla mål bevarar redigerbara PowerPoint‑funktioner.

## **Online‑konverterare**

För enstaka filer eller en snabb jämförelse kan du använda [online PPT‑till‑PPTX‑konverterare](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För upprepade konverteringar, batch‑behandling eller felhantering på applikationsnivå, använd Python‑API‑et.

## **Relaterade artiklar**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Spara presentationer i Python](/python-net/save-presentation/)
- [Stödda filformat](/python-net/supported-file-formats/)
- [Öppna presentationer i Python](/python-net/open-presentation/)

## **FAQ**

**Kan jag konvertera PPT till PPTX utan Microsoft PowerPoint installerat?**

Ja. Aspose.Slides för Python via .NET läser in och sparar presentationsfiler utan att kräva Microsoft PowerPoint.

**Kommer PPT‑till‑PPTX‑konvertering att bevara allt innehåll exakt?**

Den bevarar vanligt presentationsinnehåll, men exakt fidelitet garanteras inte för varje äldre eller ej‑stödd funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialiserade animationer eller ovanliga teckensnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord när filen laddas. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Ska jag radera PPT‑filen efter konvertering?**

Behåll originalfilen tills du har verifierat PPTX‑filen i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopia om en äldre funktion konverteras annorlunda.