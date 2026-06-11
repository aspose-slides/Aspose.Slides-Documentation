---
title: Hantera upphöjd och nedsänkt text i Python
linktitle: Upphöjd och nedsänkt
type: docs
weight: 80
url: /sv/python-net/superscript-and-subscript/
keywords:
- upphöjd
- nedsänkt
- lägg till upphöjd
- lägg till nedsänkt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Behärska upphöjd och nedsänkt text i Aspose.Slides för Python via .NET och lyft dina presentationer med professionell textformatering för maximal effekt."
---
## **Översikt**

Aspose.Slides erbjuder funktioner för att integrera upphöjd och nedsänkt text i dina PowerPoint‑presentationer (PPT, PPTX) och OpenDocument‑presentationer (ODP). Oavsett om du behöver markera kemiska formler, matematiska ekvationer eller annotera innehåll med fotnoter, hjälper dessa specialiserade formateringsalternativ till att behålla tydlighet och precision. I den här artikeln lär du dig hur du sömlöst tillämpar upphöjd‑ och nedsänkt‑stilar och säkerställer professionella resultat i varje bild.

## **Lägg till upphöjd och nedsänkt text**

Du kan lägga till upphöjd och nedsänkt text i vilken som helst avsnittsdel. I Aspose.Slides använder du egenskapen `escapement` i klassen [PortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/) för att styra detta.

`escapement` är en procentandel från **-100% till 100%**:

- **> 0** → upphöjd (t.ex. 25% = lätt höjd; 100% = full upphöjd)
- **0** → baslinje (ingen upphöjd/nedsänkt)
- **< 0** → nedsänkt (t.ex. -25% = lätt sänkt; -100% = full nedsänkt)

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och hämta ett bild.
2. Lägg till en rektangel-[AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) och få åtkomst till dess [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
3. Rensa befintliga stycken.
4. För upphöjd text: skapa ett stycke och en del, sätt `portion.portion_format.escapement` till ett värde mellan **0 och 100**, ange text och lägg till delen.
5. För nedsänkt text: skapa ett annat stycke och en del, sätt `escapement` till ett värde mellan **-100 och 0**, ange text och lägg till delen.
6. Spara presentationen som PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Hämta en bild.
    slide = presentation.slides[0]

    # Skapa en textruta.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Skapa ett stycke för upphöjd text.
    superscript_paragraph = slides.Paragraph()

    # Skapa en textdel med vanlig text.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Skapa en textdel med upphöjd text.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Skapa ett stycke för nedsänkt text.
    subscript_paragraph = slides.Paragraph()

    # Skapa en textdel med vanlig text.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Skapa en textdel med nedsänkt text.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Lägg till styckena i textrutan.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Kan jag använda upphöjd/nedsänkt text i tabeller och andra behållare, inte bara vanliga textrutor?**

Ja. Du kan formatera text som upphöjd eller nedsänkt i vilket objekt som helst som har en [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) (inklusive tabellceller). Formateringen gäller textdelar inom den ramen.

**Kommer upphöjd/nedsänkt text att bevaras vid export till PDF, HTML eller bilder?**

Ja. Aspose.Slides bevarar upphöjd/nedsänkt formatering vid export till vanliga format som [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/sv/python-net/convert-powerpoint-to-html/) och [rasterbilder](/slides/sv/python-net/convert-powerpoint-to-png/) eftersom renderingspipeline respekterar formatering på delnivå.

**Kan jag kombinera upphöjd/nedsänkt text med hyperlänkar i samma textfragment?**

Ja. [Hyperlänkar](/slides/sv/python-net/manage-hyperlinks/) tilldelas på nivå för del (fragment), så en del kan samtidigt ha en hyperlänk och vara formaterad som upphöjd eller nedsänkt.