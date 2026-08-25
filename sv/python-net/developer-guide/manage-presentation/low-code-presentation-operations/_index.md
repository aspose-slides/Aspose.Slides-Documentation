---
title: Low-Code-presentationoperationer i Python
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/python-net/low-code-presentation-operations/
keywords:
- low-code presentations-API
- konvertera presentation
- sammanfoga presentationer
- samla former
- komprimera presentation
- ta bort oanvända masterbilder
- ta bort oanvända layoutbilder
- komprimera inbäddade typsnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Använd Aspose.Slides low-code-API i Python för att konvertera och slå samman presentationer, samla former och minska presentationsstorlek."
---
## **Översikt**

Modulen [aspose.slides.lowcode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/) tillhandahåller hjälparklasser för vanliga presentationsoperationer. Dessa hjälpar omsluter ofta använda objektmodellarbetsflöden i fokuserade metoder, så att du kan konvertera eller sammanslå filer, samla former och ta bort oanvänd innehåll med mindre kod.

Low-code‑hjälparna är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet matchar dina krav. Använd hela [Aspose.Slides object model](https://reference.aspose.com/slides/sv/python-net/aspose.slides/) när du behöver finkontrollerad kontroll över enskilda bilder, masterbilder, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälparna:

| Hjälpare | Använd för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/merger/) | Kombinera kompletta presentationsfiler av samma format. |
| [Collect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/collect/) | Hämta former från hela presentationen för upprepad bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/) | Ta bort oanvända masterbilder och layouter samt minska inbäddade teckensnittsdata. |

## **Konvertera en presentation**

Använd [Convert.auto_by_extension](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/convert/auto_by_extension/) när filändelsen för utdata är tillräcklig för att välja exportformatet. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från utdatavägen och skriver resultatet.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Klassen [Convert](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/convert/) tillhandahåller också dedikerade metoder för PDF-, SVG-, JPEG-, PNG- och TIFF‑utdata. Använd hela objektmodellen när du behöver inspektera eller ändra presentationen före export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälparen. Se [Convert Presentation](/slides/sv/python-net/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Slå samman presentationer**

Använd [Merger.process](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/merger/process/) för att kombinera kompletta presentationsfiler med ett anrop. Inmatningspresentationerna måste ha samma filformat.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Hjälparen är lämplig när alla bilder ska läggas till i ett resultat utan att välja eller omkartlägga dem individuellt. Använd hela objektmodellen när du behöver slå samman valda bilder, tillämpa en mål‑master eller layout, bevara sektioner explicit, eller anpassa olika bildstorlekar. Se [Merge Presentations](/slides/sv/python-net/merge-presentation/) för dessa scenarier.

## **Samla former**

Använd [Collect.shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/collect/shapes/) när du behöver en samling av alla former i en presentation. Detta är användbart när samma uppsättning ska filtreras, räknas eller bearbetas mer än en gång.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Använd direkta samlingsloopar när traverseringsordning, tidig avbrytning, filtrering före bearbetning eller detaljerad förälder‑barn‑kontroll är viktig.

## **Komprimera presentationsinnehåll**

Klassen [Compress](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/) kan ta bort oanvända strukturella element och minska inbäddade teckensnittsdata:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) tar bort layoutbilder som ingen normal bild refererar till.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) tar bort masterbilder som inte längre används.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) tar bort oanvända tecken från inbäddade typsnitt.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Ta bort oanvända layouter innan oanvända masterbilder så att en master som blir orefererad efter layoutrensning också kan tas bort. Spara den optimerade presentationen till en ny fil om du kan behöva de ursprungliga masterbilderna, layouterna eller fullständig inbäddad teckensnittsinformation senare. För mer detaljer, se [Slide Master](/slides/sv/python-net/slide-master/) och [Embedded Font](/slides/sv/python-net/embedded-font/).

## **Vanliga frågor**

**När bör jag använda low-code‑API:et i stället för hela objektmodellen?**

Använd low-code‑hjälparna när en standardoperation gäller en komplett fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd hela objektmodellen när du behöver välja specifika bilder, kontrollera master‑ och layout‑relationer, inspektera mellansteg eller konfigurera beteende som hjälparen inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger.process](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/merger/process/) kräver att inmatningspresentationerna har samma format. Konvertera indatafilerna till ett gemensamt format först, till exempel med [Convert.auto_by_extension](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/convert/auto_by_extension/), och slå sedan samman de konverterade filerna.

**Vad inkluderar Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/collect/shapes/) hämtar former från presentationen så att de kan behållas, filtreras, räknas eller traverseras flera gånger. Använd direkta samlingsloopar när du behöver precis kontroll över vilka bildtyper eller nästlade objekt som besöks.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända masterbilder eller inbäddade typsnitt med oanvända tecken. Om ingen av dessa finns, kan de motsvarande [Compress](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/)-operationerna kanske inte minska filstorleken.

**Sparas ändringar gjorda av Compress automatiskt?**

Nej. Dessa hjälparbeten arbetar på det laddade [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-objektet i minnet. Efter att ha kört [Compress](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/) ska du anropa [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/slides/sv/python-net/convert-presentation/)
- [Slå samman presentationer](/slides/sv/python-net/merge-presentation/)
- [Slide Master](/slides/sv/python-net/slide-master/)
- [Hantera textruta](/slides/sv/python-net/manage-textbox/)
- [Embedded Font](/slides/sv/python-net/embedded-font/)