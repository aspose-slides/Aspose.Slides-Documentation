---
title: Hämta och uppdatera presentationsinformation i Python via Java
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/python-java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Utforska bildspel, struktur och metadata i PowerPoint- och OpenDocument-presentationer med Python via Java för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Aspose.Slides kan identifiera ett presentationsformat och läsa dess dokumentmetadata utan att skapa en komplett presentationsobjektmodell. Detta är användbart när du behöver klassificera filer, bygga ett inventarium eller inspektera egenskaper innan du bestämmer dig för om du ska läsa in och bearbeta presentationsinnehållet.

Exemplen kräver Aspose.Slides för Python via Java och en kompatibel Java-runtime. Varje exempel startar JVM:n om den inte redan körs. Tillhandahåll befintliga presentationsfiler på de sökvägar som används i exemplen.

Denna artikel demonstrerar lättviktig inspektion via [PresentationFactory](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/) och [PresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/), samt riktade uppdateringar via [DocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/).

## **Kontrollera ett presentationsformat**

Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/#getPresentationInfo) för att inspektera en fil utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-instans. Metoden [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#getLoadFormat) rapporterar det upptäckta formatet, till exempel PPTX, PPT eller ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Bygg ett lättviktigt presentationsinventarium**

När du bearbetar många presentationsfiler kan du behöva ett kompakt inventarium för validering, indexering eller ett dokumenthanteringssystem. I detta scenario, använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/#getPresentationInfo) för att erhålla ett [PresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/)-objekt, och anropa sedan [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#readDocumentProperties) för att läsa dokumentmetadata. Detta tillvägagångssätt skapar inte en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-instans eller kräver att du traverserar den fullständiga presentationsobjektmodellen.

De utökade egenskaper som exponeras av [DocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/) ger följande inventarievärden:

| Metod | Inventarievärde |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getSlides) | Totalt antal bilder. |
| [getHiddenSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Antal dolda bilder. |
| [getNotes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getNotes) | Antal bilder som innehåller anteckningar. |
| [getParagraphs](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getParagraphs) | Totalt antal stycken, när tillgängligt. |
| [getWords](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getWords) | Totalt antal ord. |
| [getMultimediaClips](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Totalt antal ljud- och videoklipp. |

Följande exempel läser dessa värden utan att skapa ett [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-objekt och skriver ut ett kompakt inventarium. Det kombinerar också [getHeadingPairs](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getHeadingPairs) med [getTitlesOfParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getTitlesOfParts) för att visa innehållsgrupper såsom teckensnitt, teman och bildrubriker.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
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

Varje [HeadingPair](https://reference.aspose.com/slides/sv/python-java/aspose.slides/headingpair/) tillhandahåller ett gruppnamn och antalet objekt i den gruppen. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getTitlesOfParts) returnerar en platt, ordnad array, så konsumera antalet på varandra följande titlar som specificeras av varje rubrikpar.

### **Lagrad metadata och formatbegränsningar**

Inventarieegenskaperna som returneras av [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#readDocumentProperties) speglar metadata som finns i källdokumentet. Aspose.Slides laddar inte och traverserar presentationsobjektmodellen för att omberäkna dessa värden för detta anrop. Saknade egenskaper representeras av standardvärden, och lagrade värden kan vara föråldrade om programmet som senast sparade filen inte uppdaterade dess dokumentegenskaper.

- **PPTX:** Formatet tillhandahåller utökade dokumentegenskaper för bild-, antecknings-, dold‑bild-, stycke-, ord- och multimediekount, samt rubrikpar och deltitlar. Tillgängligheten beror på vilka egenskaper som skrevs av dokumentproducenten.
- **PPT:** Det binära formatet kan lagra motsvarande dokument‑sammanfattningsegenskaper. Om en egenskap saknas eller inte uppdaterades av dokumentproducenten, returnerar Aspose.Slides dess lagrade eller standardvärde istället för att beräkna det från bilderna.
- **ODP:** OpenDocument‑metadata ger allmänna dokumentstatistik, såsom sid-, stycke- och ordantal, men dessa värden motsvarar inte varje PowerPoint‑specifik utökad egenskap. Metadata för dolda bilder, anteckningsbilder, multimedia, rubrikpar och deltitlar kan vara otillgänglig, och inventarieegenskaperna kan returnera standardvärden. Betrakta inte ett nollvärde eller en tom array som bevis på att motsvarande innehåll saknas.

Använd den lättviktiga metadata‑metoden för inventarier och preliminära kontroller. Ladda presentationen och inspektera dess levande objektmodell när resultatet måste återspegla förändringar i minnet eller när du behöver verifiera det faktiska presentationsinnehållet.

## **Uppdatera presentationsegenskaper**

Egenskaperna som returneras av [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#readDocumentProperties) kan också ändras utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-instans. Applicera ändringarna med [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) och skriv sedan den bundna presentationen med [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Följande bild visar de ursprungliga dokumentegenskaperna för PowerPoint-presentationen.
![Ursprungliga dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Följande exempel ändrar titeln och senast sparade tid och skriver resultatet till en ny fil:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

Följande bild visar de uppdaterade dokumentegenskaperna för PowerPoint-presentationen.
![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För relaterade säkerhetskontroller och skyddsinställningar, se följande artiklar:

- [Lösenordsskydda presentationer](/slides/sv/python-java/password-protected-presentation/)
- [Skrivskydda presentationer](/slides/sv/python-java/write-protected-presentation/)

## **FAQ**

**Hur kan jag kontrollera om teckensnitt är inbäddade och vilka de är?**

Läs in presentationen och använd [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getFontsManager). Anropa [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) för att hämta de inbäddade teckensnitten och [FontsManager.getFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getFonts) för att hämta teckensnitten som används av presentationen. Jämför de två resultaten för att hitta teckensnitt som krävs för rendering men som inte är inbäddade.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

När lagrad dokumentmetadata är tillräcklig, läs [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getHiddenSlides) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/#getPresentationInfo) och [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Detta är lämpligt för ett lättviktigt inventarium. Om presentationen har ändrats i minnet kan den lagrade metadata saknas eller vara föråldrad, eller så behöver du verifiera live‑värden, iterera genom [Presentation.getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlides) och inspektera varje bilds [Slide.getHidden](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getHidden)-metod istället.

**Kan jag upptäcka om en anpassad bildstorlek och orientering används, och om de skiljer sig från standardvärdena?**

Ja. Läs in presentationen och anropa [Presentation.getSlideSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlideSize). Använd [SlideSize.getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesize/#getSize) och [SlideSize.getOrientation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesize/#getOrientation) för att jämföra de aktuella inställningarna med det förväntade förinställningen och dimensionerna.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Lokalisera varje [Chart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/) och anropa [ChartData.getDataSourceType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#getDataSourceType). För en extern arbetsbok, anropa [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Datakälltyp och sökväg identifierar en extern referens, men verifiering av om målet är tillgängligt kräver en separat resurskontroll.

**Hur kan jag bedöma 'tunga' bilder som kan sakta ner rendering eller PDF‑export?**

Det finns ingen enskild komplexitetsegenskap. Traversera [Presentation.getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlides) och varje bilds [BaseSlide.getShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getShapes)-samling. Använd antalet former och förekomsten av stora bilder, effekter, animationer eller multimedia som screeningsindikatorer, och mät en representativ rendering eller export innan du betraktar en bild som en bekräftad flaskhals i prestanda.