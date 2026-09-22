---
title: Spara presentationer i Python
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/python-net/save-presentation/
keywords:
- spara PowerPoint
- spara OpenDocument
- spara presentation
- spara bild
- spara PPT
- spara PPTX
- spara ODP
- presentation till fil
- presentation till ström
- fördefinierad vytyp
- Strikt Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- sparningsframsteg
- Python
- Aspose.Slides
description: "Spara PowerPoint- och OpenDocument-presentationer till filer eller strömmar i Python med Aspose.Slides och konfigurera PPTX-utdataalternativ."
---
## **Översikt**

Efter att du har skapat en presentation eller [öppnat en befintlig](/slides/sv/python-net/open-presentation/), använder du metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ipresentation/save/) för att skriva resultatet. Aspose.Slides för Python via .NET kan spara en presentation till en fil eller ström i PowerPoint, OpenDocument, PDF och andra format. Följande avsnitt täcker de standardlagringsoperationer som finns och alternativen för PPTX‑utdata.

## **Spara presentationer till filer**

För att spara en presentation till en fil, skicka utdata‑sökvägen och ett [SaveFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/)‑värde till metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ipresentation/save/). Formatvärdet bestämmer vilken filtyp som Aspose.Slides skapar.

Följande exempel skapar en presentation och sparar den som en PPTX‑fil:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Lägg till eller ändra presentationsinnehåll här.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Spara presentationer i deras ursprungliga format**

För exempel på fil‑ och strömdetektering, beteendet för nyskapade presentationer och skillnaden mellan käll‑ och utdataformat, se [Determine the Original Presentation Format](/slides/sv/python-net/detect-presentation-source-format/).

I ett batch‑bearbetningsprogram kan indataformatet vara okänt i förväg. Efter att en fil har lästs in, läs dess ursprungliga format från egenskapen [Presentation.source_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/source_format/). Skicka det resulterande [SourceFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sourceformat/)-värdet till [SlideUtil.to_save_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/to_save_format/) för att få motsvarande [SaveFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/)-värde, och använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ipresentation/save/) för att skriva den modifierade presentationen.

Följande kompletta exempel bearbetar varje fil i en inmatningskatalog, uppdaterar dess titel och sparar den till en utmatningskatalog i det format som den lästes in i:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/to_save_format/) mappar PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP och PowerPoint XML till deras motsvarande presentationssparformat. Den mappar endast presentationskällformat; den är inte avsedd att välja exportformat som PDF, HTML, TIFF eller bilder. Att skicka ett ej‑stött eller ogiltigt [SourceFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sourceformat/)-värde kastar ett undantag.

Äldre PPT‑, PPS‑ och POT‑filer använder samma binära behållare. När en sådan presentation läses in från en ström utan filändelse kan en PPS‑ eller POT‑fil därför identifieras som PPT. Om bevarande av dessa äldre undergrupper krävs, behåll det ursprungliga filnamnet eller formatmetadata separat och använd dem när du väljer utdatafilnamn och -format.

## **Spara presentationer till strömmar**

För att skriva en presentation utan att förlita sig på en slutlig filsökväg, skicka en skrivbar [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO)-ström och ett [SaveFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/)-värde till metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ipresentation/save/). Detta tillvägagångssätt är användbart när utdata måste returneras från en webbtjänst, lagras i en databas eller bearbetas i minnet.

Följande exempel sparar en ny presentation till en filström:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Spara presentationer med en fördefinierad vystyper**

Du kan ange den vy som PowerPoint initialt öppnar en sparad presentation i. Ställ in egenskapen [ViewProperties.last_view](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/last_view/) till ett [ViewType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewtype/)-värde innan du sparar.

Följande exempel konfigurerar Slide Master‑vyn som den initiala vyn:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Spara presentationer i det strikt Office Open XML‑formatet**

För att skapa en PPTX‑fil som följer den Strikta profilen av Office Open XML, skapa en instans av [PptxOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/) och sätt dess [conformance](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/conformance/)-egenskap till `Conformance.ISO_29500_2008_STRICT`. Skicka sedan alternativen till metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

Ett standard‑ZIP‑arkiv begränsar den komprimerade och okomprimerade storleken för varje post, den totala arkivstorleken och antalet poster. Eftersom en PPTX‑fil är ett ZIP‑arkiv kan en mycket stor presentation överskrida dessa gränser. ZIP64‑tillägg höjer de tillämpliga storleks‑ och postantal‑gränserna.

Använd egenskapen [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) för att styra om Aspose.Slides skriver ZIP64‑tillägg:

- `IF_NECESSARY` använder ZIP64 endast när presentationen överskrider standard‑ZIP‑gränserna. Detta är standardläget.
- `NEVER` inaktiverar ZIP64‑tillägg.
- `ALWAYS` skriver alltid ZIP64‑tillägg.

Följande exempel aktiverar alltid ZIP64‑tillägg för utdata‑presentationen:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Om `Zip64Mode.NEVER` används och presentationen inte får plats inom standard‑ZIP‑gränserna, kastar sparoperationen ett [PptxException](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Spara presentationer i Office Open XML‑format med komprimeringsnivåer**

För PPTX‑utdata kan du balansera sparhastigheten mot filstorleken genom att sätta egenskapen [PptxOptions.compression_level](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/compression_level/). Enumerationen [CompressionLevel](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/) ger följande värden:

- `NONE` lagrar data utan kompression.
- `LEVEL1` ger den snabbaste kompressionen och den största komprimerade utdata.
- `LEVEL2` till `LEVEL5` föredrar successivt mindre utdata framför sparhastigheten.
- `LEVEL6` balanserar sparhastighet och filstorlek. Detta är standardnivån.
- `LEVEL7` och `LEVEL8` föredrar ännu mer mindre utdata framför sparhastigheten.
- `LEVEL9` ger den starkaste kompressionen och kräver mest bearbetningstid.

Följande exempel sparar en presentation utan kompression:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Följande exempel använder den högsta komprimeringsnivån:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Spara presentationer utan att uppdatera miniatyren**

När en presentation sparas som PPTX styr egenskapen [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) dess dokumentminiatyr:

- `True` återskapar miniatyren under sparoperationen. Detta är standardvärdet.
- `False` bevarar den befintliga miniatyren. Om presentationen saknar miniatyr genererar inte Aspose.Slides någon.

Följande exempel sparar en presentation utan att uppdatera dess miniatyr:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Att inaktivera miniatyruppdatering kan minska den tid som krävs för att spara en PPTX‑fil.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose tillhandahåller en gratis [PowerPoint Splitter](https://products.aspose.app/slides/sv/splitter) byggd med Aspose.Slides‑API:et. Den sparar valda bilder från en presentation som separata PPT‑ eller PPTX‑filer.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides inkrementell eller “snabb sparning”?**

Nej. Varje sparoperation skriver en komplett utdatafil istället för att bara uppdatera de ändrade delarna.

**Kan flera trådar spara samma Presentation‑instans?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-instans [är inte trådsäker](/slides/sv/python-net/multithreading/). Åtkomst och sparning av varje instans får endast ske från en tråd åt gången.

**Vad händer med hyperlänkar och externt länkade filer när jag sparar en presentation?**

[Hyperlänkar](/slides/sv/python-net/manage-hyperlinks/) förblir i presentationen. Aspose.Slides kopierar inte externt länkade filer, så den sparade presentationen måste fortfarande kunna nå deras platser.

**Kan jag spara dokumentmetadata såsom författare, titel, företag och skapelsedatum?**

Ja. Ställ in lämpliga [dokumentegenskaper](/slides/sv/python-net/presentation-properties/) innan du sparar, så skriver Aspose.Slides dem till utdatafilen.