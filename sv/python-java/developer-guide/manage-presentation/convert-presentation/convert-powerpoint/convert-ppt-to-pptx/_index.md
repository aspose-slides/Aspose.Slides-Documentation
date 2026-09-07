---
title: Konvertera PPT till PPTX i Python
linktitle: PPT till PPTX
type: docs
weight: 20
url: /sv/python-java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Konvertera äldre PPT-filer till PPTX i Python med Aspose.Slides. Inkluderar Python-exempel för konvertering av enskild fil och batch, felhantering samt noggrannhetsnoteringar."
---
## **Översikt**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det nyare Open XML‑formatet. Aspose.Slides for Python via Java kan läsa in en PPT‑fil och spara den som PPTX utan Microsoft PowerPoint. Denna artikel visar hur man konverterar en fil eller en katalog med filer och förklarar vad som bör verifieras efter konverteringen.

Varje exempel startar Java‑virtuellmaskinen vid behov och frigör presentationen efter användning. Ersätt exempelsökvägarna med dina egna fil‑ eller katalogsökvägar.

## **Konvertera en PPT‑fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/), anropa sedan [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Pptx). `finally`‑blocket frigör presentationen och dess resurser.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Läs in den äldre PPT-presentationen.
presentation = Presentation("presentation.ppt")
try:
    # Spara presentationen i PPTX-format.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Filändelsen väljer inte utdataformatet av sig själv; argumentet [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Pptx) gör det. Håll in‑ och utdata‑sökvägarna olika om du behöver behålla den ursprungliga PPT‑filen.

## **Konvertera flera PPT‑filer**

Följande exempel konverterar varje `.ppt`‑fil i en katalog. Varje fil bearbetas oberoende, så en misslyckad konvertering stoppar inte resten av batchen.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

För produktionsbelastningar, logga hela undantaget, avgör om en befintlig utdatafil får skrivas över, och skriv misslyckade filnamn till en återförsöks‑ eller granskningskö. Skadade filer, lösenordsskyddade filer som öppnas utan det erforderliga lösenordet, otillgängliga sökvägar och innehåll som inte stöds kan alla orsaka att en konvertering misslyckas. Se [Lösenordsskyddade presentationer](/slides/sv/python-java/password-protected-presentation/) för inläsning av krypterade filer.

## **Noggrannhet och äldre funktioner**

Konverteringen bevarar normalt bilder, master‑bilder, layouter, text, former, bilder, tabeller och diagram. Dock representerar inte PPT och PPTX varje funktion på exakt samma sätt. En äldre funktion som saknar motsvarande PPTX‑element, eller som inte stöds av biblioteket, kan normaliseras, utelämnas eller visas annorlunda.

Granska den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE‑objekt, ActiveX‑kontroller, inbäddade medier, ovanliga teckensnitt eller VBA‑makron. En vanlig PPTX‑fil är inte ett makro‑aktiverat format, så använd ett lämpligt makro‑aktiverat arbetsflöde när VBA måste vara tillgängligt. Verifiera också att nödvändiga teckensnitt och externa resurser finns i den miljö där den konverterade presentationen ska öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX‑filen programmässigt igen och kontrollera viktiga bildantal och innehåll, jämför sedan dess utseende och bildspelsbeteende i den avsedda visaren. Betrakta inte ett lyckat anrop till [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) som bevis på att varje äldre funktion har en exakt PPTX‑representation.

## **När man ska använda PPTX**

Använd PPTX när presentationen ska redigeras i aktuella PowerPoint‑versioner, utbytas med system som arbetar med Open XML‑paket, eller lagras i ett format som är enklare att granska och återställa än det äldre binära PPT‑formatet. Behåll den ursprungliga PPT‑filen som ett arkiv‑ eller återställningskopi tills den konverterade presentationen har klarat dina noggrannhetskontroller.

Om du istället behöver PDF, HTML, bilder, XPS eller en annan utmatningstyp, använd den format‑specifika vägledningen i [Konvertera presentationer till flera format](/slides/sv/python-java/convert-presentation/) snarare än att anta att alla mål bevarar redigerbara PowerPoint‑funktioner.

## **Online‑konverterare**

För enstaka filer eller en snabb jämförelse kan du använda [online PPT‑till‑PPTX‑konverterare](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För återkommande konverteringar, batch‑bearbetning eller felhantering på applikationsnivå, använd Python via Java‑API:t.

## **Relaterade artiklar**

- [PPT vs PPTX](/slides/sv/python-java/ppt-vs-pptx/)
- [Spara presentationer i Python](/slides/sv/python-java/save-presentation/)
- [Stödda filformat](/slides/sv/python-java/supported-file-formats/)
- [Öppna presentationer i Python](/slides/sv/python-java/open-presentation/)

## **Vanliga frågor**

**Kan jag konvertera PPT till PPTX utan att Microsoft PowerPoint är installerat?**

Ja. Aspose.Slides for Python via Java läser in och sparar presentationsfiler utan att Microsoft PowerPoint krävs.

**Kommer PPT‑till‑PPTX‑konverteringen att bevara allt innehåll exakt?**

Den bevarar vanligt presentationsinnehåll, men exakt noggrannhet garanteras inte för varje äldre eller ej stödd funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialiserade animationer eller ovanliga teckensnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord vid inläsning av filen. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Ska jag radera PPT‑filen efter konverteringen?**

Behåll originalfilen tills du har verifierat PPTX i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopia om en äldre funktion konverteras annorlunda.