---
title: Bestäm det ursprungliga presentationsformatet i Python via Java
linktitle: Källformat
type: docs
weight: 35
url: /sv/python-java/detect-presentation-source-format/
keywords:
- källformat
- detektera presentationsformat
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Läs det ursprungliga formatet för en inläst presentation i Python via Java med Aspose.Slides för Python via Java, jämför detekterings‑API:er och hantera filer, strömmar och äldre format."
---
## **Översikt**

Efter att ha laddat en presentation, anropa metoden [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSourceFormat) för att bestämma dess ursprungliga format. Använd den när efterföljande bearbetning beror på det format som den aktuella instansen laddades från.

Källformatet skiljer sig från den [SaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/) som väljs för en utdatafil. Att spara till ett annat format ändrar inte källformatet för den befintliga instansen.

Exemplen kräver Aspose.Slides för Python via Java och en kompatibel Java‑runtime. Varje exempel startar JVM:n om den ännu inte körs.

## **Läs källformatet för en fil**

Detta exempel kräver en befintlig `sample.pptx`‑fil. Det laddar filen och väljer en applikationsbearbetningspolicy med hjälp av [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSourceFormat), snarare än filnamnet. Ändra inmatningssökvägen för att prova andra format. Exemplet skriver ut den valda politiken; ersätt meddelandena med din applikationslogik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Känn igen de stödjade värdena**

[SourceFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sourceformat/)‑klassen definierar heltalskonstanter som särskiljer följande presentationsformat. Nedanstående filändelser är konventionella, inte en rekonstruktion av det ursprungliga filnamnet.

| SourceFormat‑värde | Filändelse | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑presentation 97–2003 |
| `Pptx` | `.pptx` | Office Open XML‑presentation |
| `Pptm` | `.pptm` | Makron‑aktiverad Office Open XML‑presentation |
| `Pps` | `.pps` | PowerPoint‑bildspel 97–2003 |
| `Ppsx` | `.ppsx` | Office Open XML‑bildspel |
| `Ppsm` | `.ppsm` | Makron‑aktiverat Office Open XML‑bildspel |
| `Pot` | `.pot` | PowerPoint‑mall 97–2003 |
| `Potx` | `.potx` | Office Open XML‑mall |
| `Potm` | `.potm` | Makron‑aktiverad Office Open XML‑mall |
| `Odp` | `.odp` | OpenDocument‑presentation |
| `Otp` | `.otp` | OpenDocument‑presentationsmall |
| `Fodp` | `.fodp` | Flat XML ODF‑presentation |
| `Xml` | `.xml` | PowerPoint XML‑presentation |

## **Läs källformatet för en ström**

Detta exempel kräver en befintlig `sample.pps`‑fil. Att läsa dess byte till en minnesström modellerar indata som tas emot utan filnamn, till exempel ett databasinnehåll eller en uppladdad byte‑array. [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑konstruktorn tar endast emot strömmen. Python läser filens byte, och JPype konverterar dem till en Java‑byte‑array för Java‑minnesströmmen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS och POT använder samma underliggande binära format. Vid inläsning via filsökväg kan filändelsen hjälpa till att särskilja ett bildspel eller en mall. Utan ett filnamn kan äldre PPS‑ och POT‑innehåll rapporteras som `SourceFormat.Ppt`; PPS‑exemplet ovan skriver ut heltalsvärdet för `SourceFormat.Ppt`.

Om din applikation måste bevara skillnaden, behåll det ursprungliga filnamnet eller subtyp‑metadata separat. En filändelse är en användbar ledtråd för dessa äldre subtyper, men bör inte vara det enda underlaget för att identifiera godtyckligt presentationsinnehåll.

## **Jämför detektering före och efter inläsning**

Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/#getPresentationInfo) och [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#getLoadFormat) när du behöver inspektera en fil innan hela presentationsobjektmodellen laddas. Använd [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSourceFormat) när instansen redan finns.

Detta exempel kräver `sample.pptx` och skriver ut heltalsvärdena för `LoadFormat.Pptx` respektive `SourceFormat.Pptx`. I produktion, välj det API som är lämpligt för ditt bearbetningssteg; en redan inläst presentation behöver inte en andra inspektion enbart för att få dess källformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Resultaten använder konstanter från olika klasser: [LoadFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadformat/) och [SourceFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sourceformat/). Jämför inte deras numeriska värden eller anta att varje format har identiska detekteringsresultat. PowerPoint XML kan rapporteras som `LoadFormat.Unknown` före inläsning och `SourceFormat.Xml` efter inläsning.

## **Håll käll- och utdataformat separata**

Detta exempel kräver `sample.pptx` och skriver `converted.odp`. Det skriver ut heltalsvärdet för `SourceFormat.Pptx` både före och efter att den ursprungliga instansen sparats. Endast den nya instansen som lästs in från ODP‑utdata rapporterar `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

En presentation som skapas från grunden med `Presentation()` rapporterar `SourceFormat.Pptx`. Den har ingen indatafil: detta är standardvärdet för en nyinstans, inte ett bevis på att en PPTX‑fil laddats. Spåra om din applikation skapade eller laddade instansen separat om den skillnaden är viktig.

## **Mappa ett källformat till en filändelse**

Följande exempel kräver `sample.pptx`. Det mappar varje för närvarande stödjad [SourceFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sourceformat/)‑värde till en konventionell filändelse, utan att analysera indatafilnamnet. Reservlösningen undviker att tyst tilldela en filändelse till ett okänt värde.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Denna mappning konverterar inte en fil eller återställer en äldre PPS/POT‑subtyp som gått förlorad vid inläsning av ström. För faktiskt sparande, välj ett [SaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/) explicit, eller använd konverteringen som visas i [Save Presentations in Their Original Format](/slides/sv/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifiera format genom att spara och öppna igen**

Detta fristående exempel skapar en presentation och skriver tre filer i arbetskatalogen, överskrivande filer med samma namn. Det öppnar varje utdata både via sökväg och genom en minnesström. För PPTX och ODP rapporterar båda vägarna det sparade formatet. För PPS rapporterar inläsning via sökväg `Pps`, medan inläsning av samma byte utan filnamn rapporterar `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

Följande tabell sammanfattar identifiering av källformat för presentationer med matchande filändelser. Namnen betecknar konstanter; Python‑exemplen skriver ut deras heltalsvärden:

| Sparat format | SourceFormat från en filsökväg | SourceFormat från en namnlös ström |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respektive | Samma som filsökväg |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respektive | Samma som filsökväg |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respektive | Samma som filsökväg |
| ODP, OTP | `Odp`, `Otp` respektive | Samma som filsökväg |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT‑innehåll identifieras som `Ppt` för namnlösa strömmar. Tabellen beskriver formatidentifiering, inte bevarande av varje presentationsfunktion vid konvertering.

## **FAQ**

**Ändrar sparning till ODP källformatet för en presentation som laddats från PPTX?**

Nej. Den befintliga instansen rapporterar fortfarande `Pptx`. En instans som lästs in från den sparade ODP‑filen rapporterar `Odp`.

**Kan en ström alltid särskilja en äldre presentation, ett bildspel och en mall?**

Nej. PPT, PPS och POT delar det binära formatet. Behåll filnamn eller subtyp‑metadata separat när den distinktionen krävs.

**Vilket API ska jag använda om presentationen redan är laddad?**

Läs [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSourceFormat). Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/#getPresentationInfo) för inspektion före inläsning.