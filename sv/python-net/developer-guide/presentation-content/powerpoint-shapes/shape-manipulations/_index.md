---
title: Hantera presentationsformer i Python
linktitle: Formmanipulation
type: docs
weight: 40
url: /sv/python-net/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölja form
- ändra formordning
- hämta interop-form-ID
- alternativ text för form
- justeringspunkt för form
- förinställd formjustering
- formgeometri
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- vända form
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du identifierar, justerar, klonar, tar bort, gömmer, ändrar ordning, exporterar, justerar och vänder presentationsformer med Aspose.Slides för Python via .NET."
---
## **Översikt**

Aspose.Slides for Python via .NET representerar formerna på en bild som en ordnad [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/). Samlingen är både platsen där du hittar och ändrar former samt källan till deras staplingsordning: index `0` är den längst bak i stapeln, medan det sista indexet är den längst fram.

Denna artikel följer den modellen. Den förklarar först hur du på ett pålitligt sätt identifierar en form och ändrar förinställda justeringspunkter, och visar sedan hur du klonar, tar bort, döljer och ändrar ordning på former. De sista avsnitten täcker layout‑nivåformatering, SVG‑export, justering och speglingsinställningar. Varje exempel är fristående, så du kan använda endast de operationer ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Samlingsindex är praktiska när du bearbetar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller ändra ordning på en form kan ändra dess index. Välj en identifierare enligt hur presentationen skapas och underhålls:

- [Shape.name](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/name/) är användbart för utvecklarkontrollerade mallar och är enkelt att inspektera i PowerPoints urvalspanel. Namn kan redigeras och är inte garanterade att vara unika, så etablera en namngivningskonvention om kod beror på dem.
- [Shape.alternative_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/alternative_text/) är användbart när en tillgänglighetsbeskrivning eller en författarskickad tagg redan identifierar formen. Den är synlig för användare, kan lokaliseras eller skrivas om för tillgänglighet, och är inte garanterad att vara unik. Använd inte tyst meningsfull tillgänglighetstext som en databassöknyckel.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/office_interop_shape_id/) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den shape‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en forms livstid. En klonad eller återupprättad form är en annan form och får sin egen ID.

Den relaterade egenskapen [Shape.unique_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/unique_id/) har presentationsomfång, men är avsedd för tillägg och kan återtilldelas. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är väsentlig, håll mappningen i programdata och validera att den förväntade formen fortfarande finns.

Följande exempel söker efter `name` med exakt jämförelse och rapporterar den bild‑omfattande interop‑ID:n. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet istället för att fortsätta med fel objekt.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

När en operation är specifik för en formtyp, kontrollera typen innan du använder typ‑specifika medlemmar. Detta exempel uppdaterar text och alternativ text endast om det namngivna objektet är en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Identifiera och ändra förinställda formjusteringar**

Förinställda geometriformer kan exponera justeringspunkter som styr funktioner som hörnstorlek, pilförhållanden eller båg­vinklar. Kom åt dem via den skrivskyddade [GeometryShape.adjustments](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/adjustments/)‑samlingen. Samlingen levereras av formen, men varje [AdjustValue](https://reference.aspose.com/slides/sv/python-net/aspose.slides/adjustvalue/) innehåller ett värde som kan ändras.

Lita inte bara på ett fast samlingsindex. Iterera genom justeringarna och inspektera den skrivskyddade egenskapen [AdjustValue.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/adjustvalue/type/), vars [ShapeAdjustmentType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapeadjustmenttype/)‑värde beskriver vad justeringen styr. Den skrivskyddade egenskapen [AdjustValue.name](https://reference.aspose.com/slides/sv/python-net/aspose.slides/adjustvalue/name/) ger ytterligare identifieringsinformation och är särskilt användbar när en förinställning innehåller mer än en justering med samma semantiska typ.

Använd den värdeegenskap som matchar justeringens innebörd:

| Justeringstyp | Syfte | Värde att ändra |
|---|---|---|
| `CORNER_SIZE` | Storlek på avrundade hörn | [raw_value](https://reference.aspose.com/slides/sv/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Tjocklek på en pilspets | `raw_value` |
| `ARROWHEAD_LENGTH` | Längd på en pilspets | `raw_value` |
| `ARROWHEAD_WIDTH` | Bredd på en pilspets | `raw_value` |
| `START_ANGLE` | Startvinkel för en paj eller båge | [angle_value](https://reference.aspose.com/slides/sv/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Slutvinkel för en paj eller båge | `angle_value` |

`type` och `name` kan inte tilldelas. `raw_value` är ett läs‑/skriv‑heltal i förinställningens inhemska geometrienheter, medan `angle_value` är en läs‑/skriv‑vinkel i grader. Antalet, ordningen, betydelsen och giltigt intervall för justeringar beror på den förinställda [GeometryShape.shape_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/shape_type/). Ett värde som är giltigt för en förinställning kan vara ogiltigt eller ha en annan effekt för en annan.

När `type` är `ShapeAdjustmentType.CUSTOM` känner API‑et inte igen någon standardsemantisk betydelse. Inspektera `name`, förinställningstypen och det befintliga värdet, och låt justeringen vara oförändrad såvida inte den förväntade betydelsen och intervallet är känt. Även för igenkända typer, kontrollera om samma typ förekommer mer än en gång innan du väljer ett värde. Artikeln [Connector](/slides/sv/python-net/connector/) visar detta scenario med justeringar av kopplingsböjningar.

Följande kompletta exempel skapar standard‑ och modifierade versioner av tre förinställda former. Det itererar genom varje justering, rapporterar dess `name` och `type`, ändrar storleksrelaterade värden via `raw_value`, ändrar vinklar via `angle_value` och sparar resultatet. Den vänstra kolumnen behåller standardgeometrin; den högra kolumnen visar den justerade avrundade rektangeln, fyrvägs‑pilen och pajen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till rubriker för standard- och justerade formkolumner.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Att kontrollera den semantiska typen innan ett värde ändras gör koden explicit om sin avsikt och undviker antagandet att ett visst samlingsindex har samma betydelse över olika förinställda former.

## **Ändra form‑samlingen**

Metoderna för att lägga till, klona, ta bort och ändra ordning verkar på samlingen omedelbart. Om en operation förändrar antalet eller ordningen på former, fortsätt inte att förlita dig på index som fångades innan den operationen.

### **Klona en form**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_clone/) skapar en oberoende kopia och lägger till den i mål‑samlingen. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/insert_clone/) skapar också en kopia men placerar den på ett angivet z‑order‑index. Överlagringar som accepterar koordinater flyttar klonen utan att ändra dess storlek; överlagringar med bredd och höjd kan också ändra storleken.

Exemplet skapar en målbild, klonar en märkt rektangel till fronten och infogar en andra klon bakifrån. Ändringar i någon av klonerna påverkar inte källformen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Kloning kopierar formens innehåll och formatering, inklusive namn och alternativ text. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med en ny formidentitet.

### **Ta bort former**

[ShapeCollection.remove](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/remove/) tar bort ett specifikt formobjekt från dess samling. När du tar bort flera matchningar under indexerad iteration, gå baklänges så att varje återstående index förblir giltigt.

Detta exempel tar bort varje form med ett angivet namn. Det läser `slide.shapes[index]`, inte ett fast samlingsobjekt, och det kastar inte formen onödigt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Efter borttagning ändras antalet former och indexen för senare former. Referenser till opåverkade former förblir pålitligare än sparade index. Tänk även på kopplingar, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan påverka mer än bara bildens utseende.

### **Dölja en form**

Att sätta [Shape.hidden](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/hidden/) till `True` behåller formen i samlingen men hindrar den från att visas i den normala bildspelsvisningen. Dess index, formatering och innehåll förblir tillgängliga för kod, så dölja är lämpligt för valfria element som kan återställas senare.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Att dölja är ingen radering eller säkerhetsåtgärd. Objektet kan fortfarande upptäckas och visas igen av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑ordning**

Överlappande former målas i samlingsordning. [ShapeCollection.reorder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/reorder/) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är bakdelen; `len(slide.shapes) - 1` är framdelen.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Rektangeln skapas först och ligger initialt bakom ellipsen. Att flytta den till det sista indexet placerar den i front. Slutför z‑ordning efter att ha lagt till eller klonat alla relaterade former, eftersom dessa operationer lägger till eller infogar nya samlingsobjekt och kan förändra den avsedda stapeln.

## **Inspektera former på layout‑bilder**

Normala bilder, layout‑bilder och mastern bilder har separata form‑samlingar. En form i en layout‑samling är inte samma objekt som en liknande placerad form på en normal bild. Inspektera layout‑former när du behöver förstå eller ändra formatering som levereras av en layout.

Följande exempel läser varje layout‑forms [Shape.fill_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/fill_format/) och [Shape.line_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/line_format/) utan att anta att varje form är en `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layout‑form, avgör om en normal bild ärver objektet eller har en lokal överskrivning, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/write_as_svg/) skriver en enskild forms renderade innehåll till en ström. Resultatet innehåller formen, inte hela bildens bakgrund eller grannformer.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Håll presentationen öppen under rendering. Utdata beror på formens formatering samt resurser såsom teckensnitt och bilder. Om du behöver hela sammansättningen, exportera bilden snarare än en enskild form. Anroparen äger strömmen och måste stänga den.

## **Justera former**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/align_shapes/)‑överladdningarna justerar antingen alla former eller valda samlingsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapesalignmenttype/) specificerar kant, mittlinje eller distributionsläge. Sätt `align_to_slide` till `True` för att använda bildens kanter; sätt den till `False` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former till bildens överkant. Deras aktuella index löses upp omedelbart före justeringen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Justering ändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning kräver tillräckligt många former för att definiera avståndet. Räkna om indexen om du ändrar samlingen innan du anropar metoden.

## **Spegelvänd en form**

Klassen [ShapeFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapeframe/) lagrar position, storlek, horisontell och vertikal speglingsinställning samt rotation. Dess värden `flip_h` och `flip_v` använder [NullableBool](https://reference.aspose.com/slides/sv/python-net/aspose.slides/nullablebool/): `TRUE` aktiverar speglingen, `FALSE` inaktiverar den, och `NOT_DEFINED` bevarar det ospecificerade eller standardtillståndet.

Ingångspresentationen nedan innehåller en okopierad form.

![The shape before flipping](shape_to_be_flipped.png)

Exemplet bevarar alla andra ram‑värden och ersätter endast de två speglingsinställningarna. Detta är viktigt eftersom en ny tilldelning till [Shape.frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/frame/) ersätter hela ramen.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

Den sparade formen är speglad horisontellt och vertikalt samtidigt som position, storlek och rotation behålls.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Ska jag använda ett samlingsindex som formidentifierare?**

Endast för kortlivad bearbetning när samlingen inte förändras innan indexet används. Föredra ett validerat `name`‑ eller `alternative_text`‑konvention för skapade mallar, eller `office_interop_shape_id` för slide‑omfattande interop‑arbete.

**Tar dölja en form bort den från z‑ordningen?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Varför hamnade en klonad form framför en annan form?**

`add_clone` lägger till klonen i slutet av samlingen, vilket är fronten i z‑ordningen. Använd `insert_clone` för att välja start‑index eller `reorder` efter att alla former lagts till.

**Kan jag använda ett fast index för att identifiera en förinställd formjustering?**

Endast efter att ha validerat den exakta förinställningen och samlingslayouten. Föredra att iterera genom `GeometryShape.adjustments` och kontrollera `AdjustValue.type`; använd `AdjustValue.name` som extra information när samma semantiska typ förekommer mer än en gång.