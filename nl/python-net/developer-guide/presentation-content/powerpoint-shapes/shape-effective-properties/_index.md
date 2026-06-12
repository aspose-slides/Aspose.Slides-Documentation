---
title: Haal effectieve vormeigenschappen op uit presentaties met Python
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/python-net/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtinstallatie
- bevelvorm
- tekstkader
- tekststijl
- letterhoogte
- opvulopmaak
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Python via .NET effectieve vormeigenschappen berekent en toepast voor nauwkeurige weergave in PowerPoint."
---
## **Overzicht**

Dit onderwerp legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die rechtstreeks op een specifiek opmaakniveau worden ingesteld, bijvoorbeeld:

1. Portie‑eigenschappen op een dia.
1. Tekststijlen van prototype‑vormen op een lay‑out‑ of master‑dia, wanneer het tekstkadervorm van de portie er een heeft.
1. Globale tekstopmaak in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de uiteindelijke “as rendered” opmaak nodig heeft, lost het de overervingsketen op en retourneert **effectieve** waarden. Je kunt ze verkrijgen door de `get_effective`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld toont hoe je effectieve waarden kunt verkrijgen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) is met een tekstkader en minstens één portie.

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
Effectieve opmaakgegevens vertegenwoordigen de momenteel berekende opmaak nadat overerving is toegepast. In de huidige implementatie kunnen sommige effectieve gegevensobjecten, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iportionformateffectivedata/), intern worden gecached. Een tweede aanroep van `get_effective` na het wijzigen van ouder‑ of geërfde opmaak kan de cache verversen, en een eerder verkregen object vertegenwoordigt mogelijk niet meer de eerdere staat. Als je effectieve waarden later opnieuw wilt gebruiken, kopieer dan de benodigde eigenschappen (bijvoorbeeld letterhoogte, vulkleur, lettertype‑stijl of uitlijning) naar je eigen gegevensobject.
{{% /alert %}}

## **Effectieve eigenschappen van een camera**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een camera op te halen. Het type [ICameraEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/icameraeffectivedata/) vertegenwoordigt een onveranderlijk object dat effectieve camera‑eigenschappen bevat. Een [ICameraEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/icameraeffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ithreedformateffectivedata/), dat effectieve waarden levert voor [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/).

De volgende codevoorbeeld laat zien hoe je de effectieve eigenschappen van de camera kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

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

## **Effectieve eigenschappen van een lichtinstallatie**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een lichtinstallatie op te halen. Het type [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ilightrigeffectivedata/) vertegenwoordigt een onveranderlijk object dat effectieve lichtinstallatie‑eigenschappen bevat. Een [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ilightrigeffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ithreedformateffectivedata/), dat effectieve waarden levert voor [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/).

De volgende codevoorbeeld toont hoe je de effectieve eigenschappen van de lichtinstallatie kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

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

## **Effectieve eigenschappen van een bevelvorm**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een vorm‑bevel op te halen. Het type [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishapebeveleffectivedata/) vertegenwoordigt een onveranderlijk object dat effectieve front‑reliëf‑eigenschappen voor een vorm bevat. Een [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishapebeveleffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ithreedformateffectivedata/), dat effectieve waarden levert voor [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/).

De volgende codevoorbeeld toont hoe je de effectieve eigenschappen van het boven‑bevel van een vorm kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

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

## **Effectieve eigenschappen van een tekstkader**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekstkader ophalen. Het type [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/itextframeformateffectivedata/) bevat effectieve opmaak‑eigenschappen voor een tekstkader.

De volgende codevoorbeeld toont hoe je de effectieve opmaak‑eigenschappen van een tekstkader kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) is met een tekstkader.

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

## **Effectieve eigenschappen van een tekststijl**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekststijl ophalen. Het type [ITextStyleEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/itextstyleeffectivedata/) bevat effectieve tekststijl‑eigenschappen.

De volgende codevoorbeeld toont hoe je de effectieve tekststijl‑eigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) is met een tekstkader.

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

## **Effectieve letterhoogte‑waarde ophalen**

Met Aspose.Slides kun je de effectieve letterhoogte ophalen. De volgende code demonstreert hoe de effectieve letterhoogte van een portie verandert nadat lokale letterhoogte‑waarden op verschillende niveaus van de presentatie‑structuur zijn ingesteld.

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

## **Effectieve opvul­opmaak voor een tabel**

Met Aspose.Slides kun je de effectieve opvul­opmaak voor verschillende tabelonderdelen ophalen. Het type [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ifillformateffectivedata/) bevat effectieve opvul‑opmaak‑eigenschappen. Cel‑opmaak heeft een hogere prioriteit dan rij‑opmaak, rij‑opmaak heeft een hogere prioriteit dan kolom‑opmaak, en kolom‑opmaak heeft een hogere prioriteit dan tabel‑brede opmaak.

Als gevolg daarvan worden de eigenschappen van [ICellFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/icellformateffectivedata/) gebruikt om de tabelcel te tekenen. De volgende codevoorbeeld toont hoe je de effectieve opvul‑opmaak voor verschillende tabelonderdelen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) is.

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

**Retourneert `get_effective` een momentopname?**

Niet altijd. Effectieve gegevens vertegenwoordigen de berekende opmaak nadat overerving is toegepast, maar sommige effectieve gegevensobjecten kunnen intern worden gecached. Een volgende aanroep van `get_effective` kan de opmaak opnieuw berekenen en de cache verversen, zodat een eerder verkregen object niet als een duurzame momentopname moet worden beschouwd.

**Wanneer moet ik de effectieve eigenschappen opnieuw lezen?**

Roep `get_effective` opnieuw aan nadat je de lokale opmaak, ouder‑stijlen, lay‑out‑opmaak, master‑opmaak of presentatieniveau‑standaarden hebt gewijzigd. De volgende aanroep evalueert de opmaak‑hiërarchie opnieuw en retourneert het huidige effectieve resultaat.

**Heeft het wijzigen of verwijderen van een lay‑out/master‑dia invloed op reeds opgehaalde effectieve eigenschappen?**

Ja, maar de wijziging wordt pas zichtbaar bij de volgende `get_effective`‑aanroep. Als een bron van ouder‑opmaak wordt gewijzigd of verwijderd, kan eerder verkregen effectieve data verouderd zijn. Zodra `get_effective` opnieuw wordt aangeroepen, evalueert Aspose.Slides de opmaakboom opnieuw en kunnen de resulterende lettertypen, kleuren, groottes of andere waarden wijzigen.

**Kan ik waarden wijzigen via effectieve gegevensobjecten?**

Nee. Effectieve gegevensobjecten exposeren alleen berekende waarden. Breng wijzigingen aan in de lokale opmaakobjecten en haal vervolgens de effectieve waarden opnieuw op.

**Wat gebeurt er als een eigenschap niet is ingesteld op het vorm‑niveau, noch in de lay‑out/master, noch in de globale instellingen?**

De effectieve waarde wordt bepaald door het standaardmechanisme, dat de PowerPoint‑ en Aspose.Slides‑standaarden omvat. Die afgeleide waarde wordt onderdeel van de huidige effectieve gegevens.

**Kan ik aan de hand van een effectieve lettertype‑waarde zien op welk niveau de grootte of het lettertype is gedefinieerd?**

Niet rechtstreeks. Effectieve gegevens geven alleen de uiteindelijke waarde terug. Om de bron te vinden, controleer je de lokale waarden op portie‑, alinea‑, tekstkader‑ en tekststijl‑niveau in de lay‑out, master en presentatie om te zien waar de eerste expliciete definitie voorkomt.

**Waarom lijken effectieve waarden soms identiek aan de lokale waarden?**

Omdat de lokale waarde uiteindelijk de definitieve is (er was geen hogere‑niveau overerving nodig). In dat geval komt de effectieve waarde overeen met de lokale waarde.

**Wanneer moet ik effectieve eigenschappen gebruiken, en wanneer alleen met lokale werken?**

Gebruik effectieve gegevens wanneer je het “as rendered” resultaat nodig hebt na toepassing van alle overerving, bijvoorbeeld om kleuren, inspringen of groottes op elkaar af te stemmen. Als je die waarden moet behouden ongeacht latere opmaakwijzigingen, kopieer dan de benodigde eigenschappen naar je eigen object. Als je opmaak op een specifiek niveau wilt wijzigen, wijzig dan de lokale eigenschappen en lees vervolgens, indien nodig, de effectieve gegevens opnieuw om het resultaat te verifiëren.