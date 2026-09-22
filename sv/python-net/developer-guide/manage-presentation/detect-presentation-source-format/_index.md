---
title: Bestäm det ursprungliga presentationsformatet i Python
linktitle: Källformat
type: docs
weight: 35
url: /sv/python-net/detect-presentation-source-format/
keywords:
- källformat
- identifiera presentationsformat
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Läs det ursprungliga formatet för en inläst presentation i Python med Aspose.Slides för Python via .NET, jämför API:er och hantera filer, strömmar och äldre format."
---
## **Översikt**

Efter att ha laddat en presentation, läs den skrivskyddade [Presentation.source_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/source_format/) egenskapen för att avgöra dess ursprungliga format. Använd den när efterföljande bearbetning beror på formatet som den aktuella instansen laddades från.

Källformatet är avsett från [SaveFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/) som väljs för en utdatafil. Att spara till ett annat format ändrar inte källformatet för den befintliga instansen.

## **Läs källformatet för en fil**

Detta exempel kräver en befintlig `sample.pptx`-fil. Det laddar filen och väljer en applikationsbearbetningspolicy med hjälp av [Presentation.source_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/source_format/), snarare än filnamnet. Ändra inmatningssökvägen för att prova andra format. Exemplet skriver ut den valda policyn; ersätt meddelandena med din applikationslogik.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Känna igen de stödda värdena**

Enumeration [SourceFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sourceformat/) särskiljer följande presentationsformat. Extensionerna nedan är konventionella, inte en återuppbyggnad av det ursprungliga filnamnet.

| SourceFormat‑värde | Filändelse | Format |
| --- | --- | --- |
| `PPT` | `.ppt` | PowerPoint 97–2003 presentation |
| `PPTX` | `.pptx` | Office Open XML presentation |
| `PPTM` | `.pptm` | Macro-enabled Office Open XML presentation |
| `PPS` | `.pps` | PowerPoint 97–2003 slide show |
| `PPSX` | `.ppsx` | Office Open XML slide show |
| `PPSM` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `POT` | `.pot` | PowerPoint 97–2003 template |
| `POTX` | `.potx` | Office Open XML template |
| `POTM` | `.potm` | Macro-enabled Office Open XML template |
| `ODP` | `.odp` | OpenDocument presentation |
| `OTP` | `.otp` | OpenDocument presentation template |
| `FODP` | `.fodp` | Flat XML ODF presentation |
| `XML` | `.xml` | PowerPoint XML presentation |

## **Läs källformatet för en ström**

Detta exempel kräver en befintlig `sample.pps`-fil. Att läsa dess bytes till en minnesström modellerar indata som mottas utan ett filnamn, såsom ett databasvärde eller en uppladdad byte-array. Konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) tar bara emot strömmen.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS och POT använder samma underliggande binära format. Vid laddning via filsökväg kan filändelsen hjälpa till att särskilja ett bildspel eller en mall. Utan ett filnamn kan äldre PPS- och POT-innehåll rapporteras som `SourceFormat.PPT`; PPS‑exemplet ovan rapporterar `PPT`.

Om din applikation måste bevara skillnaden, behåll det ursprungliga filnamnet eller subtypmetadata separat. En filändelse är en användbar ledtråd för dessa äldre subtyper, men bör inte vara den enda grunden för att identifiera godtyckligt presentationsinnehåll.

## **Jämför identifiering före och efter laddning**

Använd [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) och [PresentationInfo.load_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/load_format/) när du behöver inspektera en fil innan du laddar dess kompletta presentationsobjektmodell. Använd [Presentation.source_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/source_format/) när instansen redan finns.

Detta exempel kräver `sample.pptx` och skriver ut `PPTX` för båda kontrollerna. I produktion, välj API:t som passar ditt bearbetningssteg; en redan laddad presentation behöver inte en andra inspektion enbart för att få sitt källformat.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Resultaten har olika enum-typer: [LoadFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadformat/) och [SourceFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sourceformat/). Jämför dem inte genom att kasta deras numeriska värden eller anta att varje format har identiska identifieringsresultat. I testet för spara‑och‑öppna som beskrivs nedan rapporterades PowerPoint XML som `LoadFormat.UNKNOWN` före laddning och `SourceFormat.XML` efter laddning.

## **Behåll käll- och utdataformat separata**

Detta exempel kräver `sample.pptx` och skriver `converted.odp`. Det skriver ut `PPTX` både före och efter sparandet av den ursprungliga instansen. Endast den nya instansen som laddas från ODP‑utdata rapporterar `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

En presentation som skapas från grunden med `slides.Presentation()` rapporterar `SourceFormat.PPTX`. Den har ingen inmatningsfil: detta är standardvärdet för en nyinstans, inte ett bevis på att en PPTX‑fil laddades. Följ om din applikation skapade eller laddade instansen separat om den skillnaden är viktig.

## **Mappa ett källformat till en filändelse**

Följande exempel kräver `sample.pptx`. Det mappar varje för närvarande stödd [SourceFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sourceformat/)‑värde till en konventionell filändelse, utan att analysera inmatningsfilnamnet. Fallback‑metoden undviker att tyst tilldela en filändelse till ett okänt värde.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Denna mappning konverterar inte en fil eller återställer en äldre PPS/POT-subtyp som förlorats under strömladdning. För faktisk sparning, välj ett [SaveFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/) explicit, eller använd konverteringen som visas i [Save Presentations in Their Original Format](/slides/sv/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Verifiera format genom att spara och öppna igen**

Detta fristående exempel skapar en presentation och skriver tre filer i arbetskatalogen, och skriver över filer med samma namn. Det öppnar varje utdata både via sökväg och via en minnesström. För PPTX och ODP rapporterar båda vägarna det sparade formatet. För PPS rapporterar laddning via sökväg `PPS`, medan laddning av samma bytes utan filnamn rapporterar `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Samma kontroll med alla ovanstående format gav dessa resultat för genererade presentationer med matchande filändelser:

| Sparat format | SourceFormat från en filsökväg | SourceFormat från en namnlös ström |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` respektive | Samma som filsökväg |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` respektive | Samma som filsökväg |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` respektive | Samma som filsökväg |
| ODP, OTP | `ODP`, `OTP` respektive | Samma som filsökväg |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

I dessa kontroller var den enda normaliseringen av källformat PPS/POT till `PPT` för namnlösa strömmar. Tabellen beskriver formatidentifiering, inte bevarande av alla presentationsfunktioner under konvertering.

## **FAQ**

**Ändrar sparning till ODP källformatet för en presentation som laddats från PPTX?**

Nej. Den befintliga instansen rapporterar fortfarande `PPTX`. En instans som laddas från den sparade ODP‑filen rapporterar `ODP`.

**Kan en ström alltid särskilja en äldre presentation, ett bildspel och en mall?**

Nej. PPT, PPS och POT delar det binära formatet. Behåll filnamn eller subtypmetadata separat när den skillnaden krävs.

**Vilket API bör jag använda om presentationen redan är laddad?**

Läs [Presentation.source_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/source_format/). Använd [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) för inspektion före laddning.