---
title: Spara presentationer i Python
linktitle: Spara presentationer
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
- uppdatera miniatyrbild
- sparandeprocess
- Python
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i Python med Aspose.Slides—exportera till PowerPoint eller OpenDocument medan du behåller layouter, teckensnitt och effekter."
---
## **Översikt**

[Open a Presentation in Python](/slides/sv/python-net/open-presentation/) beskriver hur man använder klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för att öppna en presentation. Den här artikeln förklarar hur man skapar och sparar presentationer. Klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller ändrar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för Python kan du spara till en **fil** eller **ström**. Den här artikeln förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa klassens `save`‑metod på [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/). Skicka filnamnet och sparformatet till metoden. Följande exempel visar hur du sparar en presentation med Aspose.Slides för Python.

```py
import aspose.slides as slides

# Skapa en instans av Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:
    
    # Gör lite arbete här...

    # Spara presentationen till en fil.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till enström genom att skicka en utström till `save`‑metoden på [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/). En presentation kan skrivas till många strömmar. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```py
import aspose.slides as slides

# Skapa en instans av Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Spara presentationen till strömmen.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Spara presentationer med en fördefinierad vytyp**

Aspose.Slides för Python låter dig ställa in den inledande vy som PowerPoint använder när den genererade presentationen öppnas via klassen [ViewProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/). Sätt `last_view`‑egenskapen till ett värde från uppräkningen [ViewType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Spara presentationer i strikt Office Open XML‑format**

Aspose.Slides låter dig spara en presentation i strikt Office Open XML‑format. Använd klassen [PptxOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/) och sätt dess `conformance`‑egenskap när du sparar. Om du sätter `Conformance.ISO_29500_2008_STRICT` sparas utfilen i strikt Office Open XML‑format.

Exemplet nedan skapar en presentation och sparar den i strikt Office Open XML‑format.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Skapa en instans av Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:
    # Spara presentationen i strikt Office Open XML‑format.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

En Office Open XML‑fil är ett ZIP‑arkiv som har en gräns på 4 GB (2^32 byte) för den okomprimerade storleken på varje fil, den komprimerade storleken på varje fil och totalstorleken på arkivet, samt en gräns på 65 535 (2^16‑1) filer. ZIP64‑formatförlängningar höjer dessa gränser till 2^64.

Egenskapen [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) låter dig välja när ZIP64‑formatförlängningar ska användas vid sparande av en Office Open XML‑fil.

Denna egenskap erbjuder följande lägen:

- `IF_NECESSARY` använder ZIP64‑formatförlängningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- `NEVER` använder aldrig ZIP64‑formatförlängningar.
- `ALWAYS` använder alltid ZIP64‑formatförlängningar.

Följande kod demonstrerar hur du sparar en presentation som en PPTX‑fil med ZIP64‑formatförlängningar aktiverade:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
När du sparar med `Zip64Mode.NEVER` kastas ett [PptxException](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer i Office Open XML‑format med komprimeringsnivåer**

När du arbetar med stora presentationer kan du justera komprimeringsnivån för att balansera filstorlek och bearbetningstid. Beroende på dina krav kan du föredra snabbare bearbetning eller mindre utdatafiler.

Aspose.Slides tillhandahåller egenskapen [PptxOptions.compression_level](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/compression_level/) som låter dig ange komprimeringsnivån som används när du sparar en presentation i Office Open XML‑format.

Följande komprimeringsnivåer finns tillgängliga:

- [**NONE**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/): Ingen komprimering appliceras. Filer lagras som de är.
- [**LEVEL1**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/): Snabbast komprimering med lägst komprimeringsförhållande.
- [**LEVEL2**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/): Snabbare komprimering med något bättre komprimeringsförhållande än **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/): Ger bättre komprimering än **LEVEL2** med måttlig inverkan på bearbetningstiden.
- [**LEVEL4**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/): Ger bättre komprimering än **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/): Ger förbättrad komprimering jämfört med **LEVEL4** med extra bearbetningstid.
- [**LEVEL6**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/): Standardkomprimering som erbjuder en bra balans mellan hastighet och filstorlek. Detta är *standardkomprimeringsnivån*.
- [**LEVEL7**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/): Ger bättre komprimering än **LEVEL6** men med långsammare bearbetning.
- [**LEVEL8**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/): Ger bättre komprimering än **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/compressionlevel/): Maximal komprimering. Ger den minsta filstorleken men med längst bearbetningstid.

Följande exempel demonstrerar hur du sparar en presentation som en PPTX‑fil *utan komprimering*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Detta exempel visar hur du sparar en presentation som en PPTX‑fil med *maximal komprimering*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Spara presentationer utan att uppdatera miniatyrbilden**

Egenskapen [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) styr miniatyrbildsgenerering när en presentation sparas till PPTX:

- Om den är `True` uppdateras miniatyrbilden under sparande. Detta är standard.
- Om den är `False` bevaras den befintliga miniatyrbilden. Om presentationen inte har någon miniatyrbild genereras ingen.

I koden nedan sparas presentationen till PPTX utan att uppdatera dess miniatyrbild.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Detta alternativ hjälper till att minska tiden som krävs för att spara en presentation i PPTX‑format.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en [free PowerPoint Splitter app](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela en presentation i flera filer genom att spara utvalda bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **Vanliga frågor**

**Stöds "snabb sparning" (inkrementell sparning) så att bara förändringar skrivs?**

Nej. Sparande skapar hela målfilen varje gång; inkrementell "snabb sparning" stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans [är inte trådsäker](/slides/sv/python-net/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparande?**

[Hyperlänkar](/slides/sv/python-net/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt – se till att de refererade sökvägarna förblir åtkomliga.

**Kan jag ange/spara dokumentmetadata (Författare, Titel, Företag, Datum)?**

Ja. Standard [dokumentegenskaper](/slides/sv/python-net/presentation-properties/) stöds och skrivs till filen vid sparande.