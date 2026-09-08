---
title: Low-Code presentationsoperationer i Python via Java
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/python-java/low-code-presentation-operations/
keywords:
- low-code presentations-API
- konvertera presentation
- sammanfoga presentationer
- iterera bilder
- iterera former
- iterera text
- samla former
- komprimera presentation
- ta bort oanvända master-bilder
- ta bort oanvända layout-bilder
- komprimera inbäddade typsnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Använd Aspose.Slides low-code API i Python via Java för att konvertera och sammanfoga presentationer, iterera genom innehåll, samla former och minska presentationsstorleken."
---
## **Översikt**

API:et [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/sv/python-java/aspose.slides/) tillhandahåller statiska hjälparklasser för vanliga presentationsoperationer. Dessa hjälpare kapslar in ofta använda object‑model‑arbetsflöden i fokuserade metoder, så att du kan konvertera eller sammanslå filer, bearbeta presentationselement, samla former och ta bort oanvänd innehåll med mindre kod.

Low‑code‑hjälpare är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet matchar dina krav. Använd hela [Aspose.Slides object model](https://reference.aspose.com/slides/sv/python-java/aspose.slides/) när du behöver fin‑granulär kontroll över enskilda bilder, master‑bilder, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälparna:

| Hjälpare | Använd för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/python-java/aspose.slides/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/python-java/aspose.slides/merger/) | Kombinera kompletta presentationsfiler av samma format. |
| [ForEach](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/) | Köra en åtgärd för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/collect/) | Hämta former från hela presentationen för upprepad bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/) | Ta bort oanvända master‑bilder och layouter samt minska inbäddade teckensnittsdatan. |

## **Konvertera en presentation**

Använd [Convert.autoByExtension](https://reference.aspose.com/slides/sv/python-java/aspose.slides/convert/#autoByExtension) när filens utökning är tillräcklig för att välja exportformatet. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från utdatavägen och skriver resultatet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

Klassen [Convert](https://reference.aspose.com/slides/sv/python-java/aspose.slides/convert/) erbjuder också dedikerade metoder för PDF-, SVG‑, JPEG‑, PNG‑ och TIFF‑utdata. Använd hela objektmodellen när du behöver granska eller ändra presentationen före export eller konfigurera en exportinställning som inte exponeras av den valda hjälparen. Se [Convert Presentation](/slides/sv/python-java/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Sammanfoga presentationer**

Använd [Merger.process](https://reference.aspose.com/slides/sv/python-java/aspose.slides/merger/#process) för att kombinera kompletta presentationsfiler med ett anrop. Inmatningspresentationerna måste ha samma filformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

Hjälparen är lämplig när alla bilder ska läggas till i ett resultat utan att välja eller omkartlägga dem individuellt. Använd hela objektmodellen när du behöver slå samman valda bilder, tillämpa en destinations‑master eller layout, bevara sektioner explicit, eller anpassa olika bildstorlekar. Se [Merge Presentations](/slides/sv/python-java/merge-presentation/) för dessa scenarier.

## **Iterera genom presentations‑element**

Klassen [ForEach](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/) anropar en återuppringning för varje begärd typ av presentations‑element. Den undviker nästlade samlingsloopar och är praktisk för presentations‑omfattande inspektion eller formateringsändringar.

Följande exempel använder [ForEach.slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/#paragraph) och [ForEach.portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/#portion) för att inspektera motsvarande element:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Som standard inkluderar presentations‑omfattande form‑ och texttraversering normala, master‑ och layout‑bilder. Överlagringar med en `includeNotes`‑parameter kan också bearbeta notes‑bilder. Använd direkta samlingsloopar när traverseringsordning, tidig avbrytning, filtrering före återuppringning eller detaljerad förälder‑barn‑kontroll är viktigt.

## **Samla former**

Använd [Collect.shapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/collect/#shapes) när du behöver en samling av alla former i en presentation snarare än en återuppringning för varje form. Detta är användbart när samma uppsättning ska filtreras, räknas eller bearbetas flera gånger.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Använd istället [ForEach.shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/#shape) när varje form kan hanteras omedelbart och du inte behöver behålla det insamlade resultatet.

## **Komprimera presentationsinnehåll**

Klassen [Compress](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/) kan ta bort oanvända strukturella element och minska inbäddade teckensnittsdatan:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) tar bort layout‑bilder som ingen normal bild refererar till.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/#removeUnusedMasterSlides) tar bort master‑bilder som inte längre används.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/#compressEmbeddedFonts) tar bort oanvända tecken från inbäddade teckensnitt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ta bort oanvända layouter innan oanvända master‑bilder så att en master som blir orefererad efter layout‑rensning också kan tas bort. Spara den optimerade presentationen till en ny fil om du kan behöva de ursprungliga master‑bilderna, layouterna eller hela den inbäddade teckensnittsdatan senare. För mer detaljer, se [Slide Master](/slides/sv/python-java/slide-master/) och [Embedded Font](/slides/sv/python-java/embedded-font/).

## **FAQ**

**När bör jag använda low‑code‑API:t istället för hela objektmodellen?**

Använd low‑code‑hjälpare när en standardoperation gäller en hel fil eller presentation och inte kräver detaljstyrning av enskilda element. Använd hela objektmodellen när du behöver välja specifika bilder, kontrollera master‑ och layout‑relationer, inspektera mellanstadier, eller konfigurera beteende som hjälparen inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger.process](https://reference.aspose.com/slides/sv/python-java/aspose.slides/merger/#process) kräver att inmatningspresentationerna har samma format. Konvertera först indatafilerna till ett gemensamt format, till exempel med [Convert.autoByExtension](https://reference.aspose.com/slides/sv/python-java/aspose.slides/convert/#autoByExtension), och slå sedan samman de konverterade filerna.

**Bearbetar ForEach master‑, layout‑ och notes‑bilder?**

[ForEach.slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/#slide) itererar genom normala presentationsbilder. Presentations‑omfattande [ForEach.shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/#paragraph) och [ForEach.portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/#portion)‑operationer inkluderar normala, master‑ och layout‑bilder som standard. Använd deras överlagringar med `includeNotes` satt till `True` för att inkludera notes‑bilder.

**Vad är skillnaden mellan ForEach.shape och Collect.shapes?**

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/#shape) för att bearbeta varje form omedelbart via en återuppringning. Använd [Collect.shapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/collect/#shapes) när du behöver ett iterator‑resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända master‑bilder eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns, kan de motsvarande [Compress](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/)‑operationerna kanske inte minska filstorleken.

**Sparas ändringar som gjorts av ForEach eller Compress automatiskt?**

Nej. Dessa hjälpare arbetar på det inlästa [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objektet i minnet. Efter att ha ändrat element i en [ForEach](https://reference.aspose.com/slides/sv/python-java/aspose.slides/foreach/)‑återuppringning eller kört [Compress](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/), anropa [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/slides/sv/python-java/convert-presentation/)
- [Sammanfoga presentationer](/slides/sv/python-java/merge-presentation/)
- [Slide master](/slides/sv/python-java/slide-master/)
- [Hantera textruta](/slides/sv/python-java/manage-textbox/)
- [Inbäddat teckensnitt](/slides/sv/python-java/embedded-font/)