---
title: Low-Code-presentationoperationer i Python
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/python-net/low-code-presentation-operations/
keywords:
- low-code-presentation API
- konvertera presentation
- slå samman presentationer
- samla former
- komprimera presentation
- ta bort oanvända masterbilder
- ta bort oanvända layoutbilder
- komprimera inbäddade teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Använd Aspose.Slides low-code API i Python för att konvertera och slå samman presentationer, samla former och minska presentationsstorleken."
---
## **Översikt**

Modulen [aspose.slides.lowcode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/) tillhandahåller hjälpklasser för vanliga presentationsoperationer. Dessa hjälpklasser kapslar in ofta använda arbetsflöden i objektmodellen i fokuserade metoder, så att du kan konvertera eller slå samman filer, samla former och ta bort oanvänt innehåll med mindre kod.

Low-code-hjälpmedel är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet matchar dina krav. Använd hela [Aspose.Slides object model](https://reference.aspose.com/slides/sv/python-net/aspose.slides/) när du behöver finjusterad kontroll över enskilda bilder, masterbilder, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälpmedlen:

| Hjälpmedel | Använd den för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/merger/) | Kombinera kompletta presentationsfiler av samma format. |
| [Collect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/collect/) | Hämta former från hela presentationen för upprepad bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/) | Ta bort oanvända masterbilder och layouter samt minska inbäddad teckensnittsdatan. |

## **Konvertera en presentation**

Använd [Convert.auto_by_extension](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/convert/auto_by_extension/) när filändelsen på utdata är tillräcklig för att välja exportformatet. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från utdatavägen och skriver resultatet.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/convert/)‑klassen erbjuder också dedikerade metoder för PDF, SVG, JPEG, PNG och TIFF‑utdata. Använd hela objektmodellen när du behöver inspektera eller ändra presentationen innan export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälpen. Se [Konvertera presentation](/python-net/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Sammanfoga presentationer**

Använd [Merger.process](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/merger/process/) för att kombinera kompletta presentationsfiler med ett anrop. Inmatningspresentationerna måste ha samma filformat.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Hjälpen är lämplig när alla bilder ska läggas till i ett resultat utan att välja eller ommappa dem individuellt. Använd hela objektmodellen när du behöver slå samman valda bilder, tillämpa en destinations‑master eller layout, bevara sektioner explicit eller anpassa olika bildstorlekar. Se [Slå samman presentationer](/python-net/merge-presentation/) för de scenarierna.

## **Samla former**

Använd [Collect.shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/collect/shapes/) när du behöver en samling av alla former i en presentation. Detta är användbart när samma uppsättning kommer att filtreras, räknas eller bearbetas flera gånger.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Använd direkta samlingsloopar när traverseringsordning, tidig avbrott, filtrering före bearbetning eller detaljerad förälder‑barn‑kontroll är viktig.

## **Komprimera presentationsinnehåll**

[Compress](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/)‑klassen kan ta bort oanvända strukturella element och minska inbäddad teckensnittsdatan:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) tar bort layoutbilder som ingen vanlig bild refererar till.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) tar bort masterbilder som inte längre används.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) tar bort oanvända tecken från inbäddade teckensnitt.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Ta bort oanvända layouter innan oanvända masterbilder så att en master som blir orefererad efter layout‑rengöring också kan tas bort. Spara den optimerade presentationen i en ny fil om du kan behöva de ursprungliga masterbilderna, layouterna eller komplett inbäddad teckensnittsdatan senare. För mer detalj, se [Bildmaster](/python-net/slide-master/) och [Inbäddat teckensnitt](/python-net/embedded-font/).

## **Vanliga frågor**

**När bör jag använda low-code API:t istället för hela objektmodellen?**

Använd low-code‑hjälpmedel när en standardoperation gäller en hel fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd hela objektmodellen när du behöver välja specifika bilder, kontrollera master‑ och layout‑relationer, inspektera mellanliggande tillstånd eller konfigurera beteende som hjälpmedlet inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. Merger.process kräver att inmatningspresentationerna har samma format. Konvertera inmatningsfilerna till ett gemensamt format först, till exempel med [Convert.auto_by_extension](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/convert/auto_by_extension/), och slå sedan samman de konverterade filerna.

**Vad inkluderar Collect.shapes?**

Collect.shapes hämtar former från presentationen så att de kan behållas, filtreras, räknas eller traverseras flera gånger. Använd direkta samlingsloopar när du behöver exakt kontroll över vilka bildtyper eller nästlade objekt som besöks.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända masterbilder eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns kan de motsvarande Compress‑operationerna kanske inte minska filens storlek.

**Sparas ändringar som gjorts av Compress automatiskt?**

Nej. Dessa hjälpmedel arbetar på det inlästa Presentation‑objektet i minnet. Efter att ha kört Compress, anropa [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/python-net/convert-presentation/)
- [Slå samman presentationer](/python-net/merge-presentation/)
- [Bildmaster](/python-net/slide-master/)
- [Hantera textruta](/python-net/manage-textbox/)
- [Inbäddat teckensnitt](/python-net/embedded-font/)