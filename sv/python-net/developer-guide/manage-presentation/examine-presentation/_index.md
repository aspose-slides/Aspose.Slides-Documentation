---
title: Hämta och uppdatera presentationsinformation i Python
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/python-net/examine-presentation/
keywords:
- presentationsformat
- presentationsegenskaper
- dokumentegenskaper
- hämta egenskaper
- läsa egenskaper
- ändra egenskaper
- modifiera egenskaper
- uppdatera egenskaper
- granska PPTX
- granska PPT
- granska ODP
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Utforska bildspel, struktur och metadata i PowerPoint- och OpenDocument-presentationer med Python för snabbare insikter och smartare innehållsgranskning."
---
## **Översikt**

Aspose.Slides kan identifiera ett presentationsformat och läsa dokumentmetadata utan att skapa ett komplett presentationsobjekt‑modell. Detta är användbart när du behöver klassificera filer, bygga ett inventarium eller inspektera egenskaper innan du bestämmer dig för att ladda och bearbeta presentationsinnehållet.

Denna artikel demonstrerar lättviktig inspektion via [PresentationFactory](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/) och [PresentationInfo](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/), samt riktade uppdateringar via [DocumentProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/).

## **Kontrollera ett presentationsformat**

Om du redan har en laddad presentation, se [Determine the Original Presentation Format](/slides/sv/python-net/detect-presentation-source-format/) för detektering efter inläsning och begränsningarna för äldre PPT‑, PPS‑ och POT‑strömmar.

Använd [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) för att inspektera en fil utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans. Egenskapen [PresentationInfo.load_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/load_format/) rapporterar det upptäckta formatet, t.ex. PPTX, PPT eller ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Bygg ett lättviktigt presentationsinventarium**

När du bearbetar många presentationsfiler kan du behöva ett kompakt inventarium för validering, indexering eller ett dokumenthanteringssystem. I detta scenario, använd [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) för att erhålla ett [PresentationInfo](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/)‑objekt, och anropa sedan [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/read_document_properties/) för att läsa dokumentmetadata. Detta tillvägagångssätt skapar ingen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans och kräver inte att du traverserar hela presentationsobjekt‑modellen.

De utökade egenskaper som exponeras av [DocumentProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/) ger följande inventarievärden:

| Property | Inventarievärde |
| --- | --- |
| [slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/slides/sv/) | Totalt antal bilder. |
| [hidden_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/hidden_slides/) | Antal dolda bilder. |
| [notes](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/notes/) | Antal bilder som innehåller anteckningar. |
| [paragraphs](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/paragraphs/) | Totalt antal stycken, när det finns tillgängligt. |
| [words](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/words/) | Totalt antal ord. |
| [multimedia_clips](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/multimedia_clips/) | Totalt antal ljud‑ och videoklipp. |

Följande exempel läser dessa värden utan att skapa ett [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objekt och skriver ut ett kompakt inventarium. Det kombinerar också [heading_pairs](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/heading_pairs/) med [titles_of_parts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/titles_of_parts/) för att visa innehållsgrupper såsom typsnitt, teman och bildtitlar.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
            if part_index >= len(titles_of_parts):
                break

            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Varje [HeadingPair](https://reference.aspose.com/slides/sv/python-net/aspose.slides/headingpair/) levererar ett gruppnamn och antalet objekt i den gruppen. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/titles_of_parts/) är en platt, ordnad samling, så konsumera antalet på varandra följande titlar som specificeras av varje rubrikpar.

### **Lagrad metadata och formatbegränsningar**

De inventarieegenskaper som returneras av [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/read_document_properties/) speglar metadata som finns i källdokumentet. Aspose.Slides laddar inte och traverserar presentationsobjekt‑modellen för att omberäkna dessa värden för detta anrop. Saknade egenskaper representeras av standardvärden, och lagrade värden kan vara föråldrade om programmet som senast sparade filen inte uppdaterade dess dokumentegenskaper.

- **PPTX:** Formatet tillhandahåller utökade dokumentegenskaper för bild, anteckning, dold bild, stycke, ord och multimedie‑räkning, samt rubrikpar och deltitlar. Tillgängligheten beror på vilka egenskaper som skrevs av dokumentproducenten.
- **PPT:** Det binära formatet kan lagra motsvarande dokument‑sammanfattningsegenskaper. Om en egenskap saknas eller inte uppdaterades av dokumentproducenten returnerar Aspose.Slides dess lagrade eller standardvärde snarare än att beräkna det från bilderna.
- **ODP:** OpenDocument‑metadata ger allmänna dokumentstatistikvärden, såsom sid‑, stycke‑ och ordantal, men dessa värden motsvarar inte varje specifik PowerPoint‑utökad egenskap. Metadata för dolda bilder, anteckningsbilder, multimedia, rubrikpar och deltitlar kan vara otillgängliga, och inventarieegenskaperna kan returnera standardvärden. Betrakta inte ett nollvärde eller en tom samling som bevis på att motsvarande innehåll saknas.

Använd den lättviktiga metadata‑metoden för inventarier och preliminära kontroller. Ladda presentationen och inspektera dess levande objekt‑modell när resultatet måste återspegla förändringar i minnet eller när du behöver verifiera det faktiska presentationsinnehållet.

## **Uppdatera presentationsegenskaper**

De egenskaper som returneras av [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/read_document_properties/) kan också ändras utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans. Tillämpa ändringarna med [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/update_document_properties/), och skriv sedan den bundna presentationen med [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Följande bild visar de ursprungliga dokumentegenskaperna.

![Ursprungliga dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Följande exempel ändrar titel och senast sparade tid och skriver resultatet till en ny fil:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

Följande bild visar de ändrade dokumentegenskaperna.

![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För relaterade säkerhetskontroller och skyddsinställningar, se följande artiklar:

- [Password-Protect Presentations](/slides/sv/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/sv/python-net/write-protected-presentation/)

## **Vanliga frågor**

**Hur kan jag kontrollera om typsnitt är inbäddade och vilka de är?**

Läs in presentationen och använd [Presentation.fonts_manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/fonts_manager/). Anropa [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) för att erhålla de inbäddade typsnitten och [FontsManager.get_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_fonts/) för att få de typsnitt som används av presentationen. Jämför de två resultaten för att hitta typsnitt som krävs för rendering men som inte är inbäddade.

**Hur kan jag snabbt se om filen har dolda bilder och hur många?**

När lagrad dokumentmetadata är tillräcklig, läs [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/hidden_slides/) via [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) och [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/read_document_properties/). Detta är lämpligt för ett lättviktigt inventarium. Om presentationen har modifierats i minnet kan den lagrade metadata saknas eller vara föråldrad, eller så behöver du verifiera levande värden genom att iterera genom [Presentation.slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/slides/sv/) och inspektera varje bilds [Slide.hidden](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/hidden/)‑egenskap istället.

**Kan jag upptäcka om en anpassad bildstorlek och orientering används, och om de avviker från standardvärdena?**

Ja. Läs in presentationen och läs [Presentation.slide_size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/slide_size/). Inspektera [SlideSize.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidesize/size/) och [SlideSize.orientation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidesize/orientation/) för att jämföra de aktuella inställningarna med den förväntade förinställningen och dimensionerna.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Hitta varje [Chart](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/) och inspektera [ChartData.data_source_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/data_source_type/). För en extern arbetsbok, läs [ChartData.external_workbook_path](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Datakälltyp och sökväg identifierar en extern referens, men att verifiera om målet är tillgängligt kräver en separat resurskontroll.

**Hur kan jag bedöma “tunga” bilder som kan sakta rendering eller PDF‑export?**

Det finns ingen enskild komplexitetsegenskap. Traversera [Presentation.slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/slides/sv/) och varje slides [BaseSlide.shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/shapes/)‑samling. Använd antal former och närvaron av stora bilder, effekter, animationer eller multimedia som screening‑signaler, och mät en representativ rendering eller export innan du behandlar en bild som en bekräftad prestandaflaskhals.