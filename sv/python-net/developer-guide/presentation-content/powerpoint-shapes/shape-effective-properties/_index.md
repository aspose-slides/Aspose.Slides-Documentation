---
title: Hämta effektiva formsegenskaper från presentationer med Python
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/python-net/shape-effective-properties/
keywords:
- formsegenskaper
- kamerasegenskaper
- ljusanordning
- fasettform
- textram
- textstil
- teckenhöjd
- fyllningsformat
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Python via .NET beräknar och tillämpar effektiva formsegenskaper för exakt rendering i PowerPoint."
---
## **Översikt**

Det här ämnet förklarar skillnaden mellan **lokala** och **effektiva** egenskaper. Lokala värden är värden som sätts direkt på en specifik formateringsnivå, till exempel:

1. Delsegenskaper på en bild.
1. Prototypformens textstilar på en layout‑ eller masternivå, när delens textramhållande form har en.
1. Globala textinställningar i en presentation.

Lokala värden kan definieras eller utelämnas på vilken nivå som helst. När Aspose.Slides behöver den slutgiltiga ”som renderad” formateringen löser den arvskedjan och returnerar **effektiva** värden. Du kan hämta dem genom att anropa metoden `get_effective` på det lokala formatobjektet.

Följande exempel visar hur du får effektiva värden. Det förutsätter att den första formen på den första bilden är en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) med en textram och minst en del.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Effektiv formateringsdata representerar den aktuella beräknade formateringen efter att arv har tillämpats. I den nuvarande implementeringen kan vissa effektiva dataobjekt, såsom [IPortionFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iportionformateffectivedata/), cachelagras internt. Att anropa `get_effective` igen efter att ha ändrat föräldra‑ eller ärvd formatering kan uppdatera den cachelagrade datan, och ett tidigare erhållet objekt kanske inte längre representerar det tidigare tillståndet. Om du behöver bevara effektiva värden för senare återanvändning, kopiera de nödvändiga egenskaperna, såsom teckenhöjd, fyllningsfärg, teckensnittsstil eller justering, till ditt eget dataobjekt.
{{% /alert %}}

## **Hämta effektiva egenskaper för en kamera**

Aspose.Slides låter dig hämta effektiva egenskaper för en kamera. Typen [ICameraEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/icameraeffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva kameregenskaper. En [ICameraEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/icameraeffectivedata/)‑instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [ThreeDFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/).

Följande kodexempel visar hur du får effektiva egenskaper för kameran. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Hämta effektiva egenskaper för en ljusanordning**

Aspose.Slides låter dig hämta effektiva egenskaper för en ljusanordning. Typen [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ilightrigeffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva egenskaper för ljusanordningen. En [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ilightrigeffectivedata/)‑instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [ThreeDFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/).

Följande kodexempel visar hur du får effektiva egenskaper för ljusanordningen. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Hämta effektiva egenskaper för en fasettform**

Aspose.Slides låter dig hämta effektiva egenskaper för en fasett på en form. Typen [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ishapebeveleffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva ansiktsreliefegenskaper för en form. En [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ishapebeveleffectivedata/)‑instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [ThreeDFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/).

Följande kodexempel visar hur du får effektiva egenskaper för den övre fasetten på en form. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Hämta effektiva egenskaper för en textram**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textram. Typen [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/itextframeformateffectivedata/) innehåller effektiva formateringsegenskaper för textram.

Följande kodexempel visar hur du får effektiva formateringsegenskaper för en textram. Det förutsätter att den första formen på den första bilden är en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) med en textram.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Hämta effektiva egenskaper för en textstil**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textstil. Typen [ITextStyleEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/itextstyleeffectivedata/) innehåller effektiva egenskaper för textstil.

Följande kodexempel visar hur du får effektiva egenskaper för en textstil. Det förutsätter att den första formen på den första bilden är en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) med en textram.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Hämta det effektiva teckenhöjdsvärdet**

Med Aspose.Slides kan du hämta den effektiva teckenhöjden. Följande kod visar hur en portions effektiva teckenhöjd förändras efter att lokala teckenhöjdsvärden har satts på olika nivåer i presentationsstrukturen.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Hämta den effektiva fyllningsformatet för en tabell**

Med Aspose.Slides kan du hämta effektiv fyllningsformatering för olika tabelldelar. Typen [IFillFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ifillformateffectivedata/) innehåller effektiva fyllningsformateringsegenskaper. Cellformatering har högre prioritet än radformatering, radformatering har högre prioritet än kolumnformatering, och kolumnformatering har högre prioritet än tabell‑formatering för hela tabellen.

Som en följd av detta används egenskaper från [ICellFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/icellformateffectivedata/) för att rita tabellcellen. Följande kodexempel visar hur du får effektiv fyllningsformatering för olika tabelldelar. Det förutsätter att den första formen på den första bilden är en [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**Returnerar `get_effective` ett ögonblicksavbild?**

Ej alltid. Effektiva data representerar den beräknade formateringen efter att arv har tillämpats, men vissa effektiva dataobjekt kan cachelagras internt. Ett efterföljande anrop av `get_effective` kan omberäkna formateringen och uppdatera den cachelagrade datan, så ett tidigare erhållet objekt bör inte betraktas som en beständig ögonblicksavbild.

**När bör jag läsa de effektiva egenskaperna igen?**

Anropa `get_effective` igen efter att ha ändrat lokal formatering, föräldra‑stilar, layout‑formatering, master‑formatering eller standardinställningar på presentationsnivå. Nästa anrop utvärderar formateringshierarkin på nytt och returnerar det aktuella effektiva resultatet.

**Påverkar ändring eller borttagning av en layout‑/masternivå de redan hämtade effektiva egenskaperna?**

Ja, men förändringen visas vid nästa anrop av `get_effective`. Om en föräldra‑formateringskälla ändras eller tas bort kan tidigare erhållen effektiv data vara föråldrad. När `get_effective` anropas igen utvärderar Aspose.Slides formateringsträdet på nytt och de resulterande typsnitten, färgerna, storlekarna eller andra värden kan förändras.

**Kan jag ändra värden via effektiva dataobjekt?**

Nej. Effektiva dataobjekt visar beräknade värden. Gör förändringar i de lokala formateringsobjekten och hämta sedan de effektiva värdena igen.

**Vad händer om en egenskap inte är satt på formnivå, varken i layout/master eller i globala inställningar?**

Det effektiva värdet bestäms av standardmekanismen, som inkluderar PowerPoint‑ och Aspose.Slides‑standardvärden. Det lösta värdet blir en del av den aktuella effektiva datan.

**Kan jag utifrån ett effektivt teckenvärde avgöra vilken nivå som tillhandahöll storleken eller teckensnittet?**

Inte direkt. Effektiva data returnerar det slutgiltiga värdet. För att hitta källan, kontrollera de lokala värdena på del, stycke, textram och textstilar på layout‑, master‑ och presentationsnivå för att se var den första explicita definitionen förekommer.

**Varför ser effektiva värden ibland identiska ut som de lokala?**

Eftersom det lokala värdet visade sig vara det slutgiltiga (ingen högre nivå behövde ärvas). I sådana fall matchar det effektiva värdet det lokala.

**När bör jag använda effektiva egenskaper och när bör jag bara arbeta med lokala?**

Använd effektiva data när du behöver resultatet ”som renderas” efter att all arv har tillämpats, t.ex. för att justera färger, indrag eller storlekar. Om du behöver bevara dessa värden oavsett framtida formateringsändringar, kopiera de nödvändiga egenskaperna till ditt eget objekt. Om du behöver ändra formatering på en specifik nivå, modifiera lokala egenskaper och läs sedan, om det behövs, de effektiva data igen för att verifiera resultatet.