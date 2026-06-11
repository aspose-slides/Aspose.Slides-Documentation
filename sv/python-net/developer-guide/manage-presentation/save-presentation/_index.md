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
- uppdatera miniatyr
- sparningsförlopp
- Python
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i Python med Aspose.Slides—export till PowerPoint eller OpenDocument samtidigt som du behåller layouter, typsnitt och effekter."
---
## **Översikt**

[Open a Presentation in Python](/slides/sv/python-net/open-presentation/) beskriver hur du använder klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för att öppna en presentation. Den här artikeln förklarar hur du skapar och sparar presentationer. Klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller ändrar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för Python kan du spara till en **fil** eller **ström**. Den här artikeln beskriver de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa Presentation‑klassens `save`‑metod. Skicka filnamnet och sparformatet till metoden. Följande exempel visar hur du sparar en presentation med Aspose.Slides för Python.

```py
import aspose.slides as slides

# Skapa ett Presentation-objekt som representerar en presentationsfil.
with slides.Presentation() as presentation:
    
    # Gör något arbete här...

    # Spara presentationen till en fil.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utdatström till Presentation‑klassens `save`‑metod. En presentation kan skrivas till många strömmar. I exemplet nedan skapar vi en ny presentation, lägger till text i en form och sparar den till en ström.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Spara presentationen till strömmen.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Spara presentationer med en fördefinierad vytyp**

Aspose.Slides för Python låter dig ange den initiala visning som PowerPoint använder när den genererade presentationen öppnas via klassen [ViewProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/). Sätt egenskapen `last_view` till ett värde från enumen [ViewType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Spara presentationer i det strikt Office Open XML‑formatet**

Aspose.Slides låter dig spara en presentation i det strikt Office Open XML‑formatet. Använd klassen [PptxOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/) och ange dess `conformance`‑egenskap vid sparning. Om du sätter `Conformance.ISO_29500_2008_STRICT` sparas utdatafilen i det strikt Office Open XML‑formatet.

Exemplet nedan skapar en presentation och sparar den i det strikt Office Open XML‑formatet.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Instansiera Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:
    # Spara presentationen i det Strikta Office Open XML-formatet.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

Ett Office Open XML‑fil är ett ZIP‑arkiv som begränsar den okomprimerade storleken på varje fil, den komprimerade storleken på varje fil och den totala arkivstorleken till 4 GB (2^32 byte) samt begränsar antalet filer till 65 535 (2^16‑1). ZIP64‑formatutökningar höjer dessa gränser till 2^64.

Egenskapen [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) låter dig välja när du ska använda ZIP64‑formatutökningar vid sparning av en Office Open XML‑fil.

Denna egenskap erbjuder följande lägen:

- `IF_NECESSARY` använder ZIP64‑formatutökningar endast om presentationen överskrider ovanstående begränsningar. Detta är standardläget.
- `NEVER` använder aldrig ZIP64‑formatutökningar.
- `ALWAYS` använder alltid ZIP64‑formatutökningar.

Följande kod visar hur du sparar en presentation som PPTX med ZIP64‑formatutökningar aktiverade:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="OBS" color="warning" %}}
När du sparar med `Zip64Mode.NEVER` kastas ett [PptxException](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer utan att uppdatera miniatyrbilden**

Egenskapen [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) styr genereringen av miniatyrbild när en presentation sparas till PPTX:

- Om den är `True` uppdateras miniatyrbilden vid sparning. Detta är standard.
- Om den är `False` bevaras den befintliga miniatyrbilden. Om presentationen saknar miniatyrbild genereras ingen.

I koden nedan sparas presentationen till PPTX utan att uppdatera miniatyrbilden.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Detta alternativ hjälper till att minska den tid som krävs för att spara en presentation i PPTX‑format.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en gratis PowerPoint‑splittar‑app som använder deras eget API. Appen låter dig dela en presentation i flera filer genom att spara valda bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **Vanliga frågor**

**Stöds "snabb sparning" (inkrementell sparning) så att endast ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell “snabb sparning” stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans är inte trådsäker; spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlinks](/slides/sv/python-net/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt – se till att de refererade sökvägarna förblir åtkomliga.

**Kan jag ange/spara dokumentmetadata (författare, titel, företag, datum)?**

Ja. Standard [document properties](/slides/sv/python-net/presentation-properties/) stöds och kommer att skrivas till filen vid sparning.