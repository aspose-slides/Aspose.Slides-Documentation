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
- dölj form
- ändra formordning
- hämta interop form-ID
- form alternativ text
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- vänd form
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du identifierar, klonar, tar bort, döljer, omordnar, exporterar, justerar och vänder presentationsformer med Aspose.Slides för Python via .NET."
---
## **Översikt**

Aspose.Slides för Python via .NET representerar formerna på en bild som en ordnad [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/). Samlingen är både platsen där du hittar och ändrar former samt källan till deras staplingsordning: index `0` är den bakre formen, medan det sista indexet är den främsta formen.

Denna artikel följer den modellen. Den förklarar först hur man identifierar en form på ett tillförlitligt sätt, sedan visar hur man klonar, tar bort, döljer och omordnar former. De sista avsnitten täcker layoutnivåformatering, SVG-export, justering och vändningsinställningar. Varje exempel är oberoende, så du kan bara använda de operationer ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Samlingens index är praktiska när man bearbetar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller omordna en form kan ändra dess index. Välj en identifierare beroende på hur presentationen är skapad och underhållen:

- [Shape.name](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/name/) är användbar för utvecklarkontrollerade mallar och är lätt att inspektera i PowerPoints urvals‑fönster. Namn kan redigeras och garanteras inte unika, så upprätta en namngivningskonvention om kod beror på dem.
- [Shape.alternative_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/alternative_text/) är användbar när en tillgänglighetsbeskrivning eller en författarspecificerad tagg redan identifierar formen. Den är synlig för användare, kan lokaleras eller skrivas om för tillgänglighet, och garanteras inte unik. Använd inte tyst meningsfull tillgänglighetstext som en databassnyckel.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/office_interop_shape_id/) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den form‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en forms livstid. En klonad eller återskapad form är en annan form och får eget ID.

Den relaterade [Shape.unique_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/unique_id/) egenskap har presentationsomfattning, men är avsedd för tillägg och kan omassigneras. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är viktig, håll kartläggningen i programdata och validera att den förväntade formen fortfarande finns.

Ett följande exempel söker efter `name` med en exakt jämförelse och rapporterar den bild‑specifika interop‑ID:n. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet istället för att fortsätta med fel objekt.

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

När en operation är specifik för en formtyp, kontrollera typen innan typ‑specifika medlemmar används. Detta exempel uppdaterar text och alternativ text endast om det namngivna objektet är en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/).

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

## **Ändra form‑samlingen**

Metoderna add, clone, remove och reorder verkar på samlingen omedelbart. Om en operation ändrar antalet eller ordningen av former, fortsätt inte att förlita dig på index som togs innan den operationen.

### **Klona en form**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_clone/) skapar en oberoende kopia och lägger till den i mål‑samlingen. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/insert_clone/) skapar också en kopia men placerar den på ett specificerat z‑ordningsindex. Överlagringarna som tar emot koordinater flyttar klonen utan att ändra dess storlek; överlagringar med bredd och höjd kan även ändra storlek.

Exemplet skapar en destinations‑bild, klonar en märkt rektangel till fronten och infogar en andra klon längst bak. Ändringar i någon av klonerna modifierar inte källformen.

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

Klonning kopierar formens innehåll och formatering, inklusive namn och alternativ text. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med en ny formidentitet.

### **Ta bort former**

[ShapeCollection.remove](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/remove/) tar bort ett specifikt formobjekt från dess samling. När du tar bort flera matchningar under indexerad iteration, gå bakifrån så att varje återstående index förblir giltigt.

Detta exempel tar bort varje form med ett bestämt namn. Det läser `slide.shapes[index]`, inte ett fast samlingsobjekt, och kastar inte formen onödigt.

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

Efter borttagning förändras antalet former och indexen för senare former. Referenser till opåverkade former förblir mer pålitliga än sparade index. Tänk även på anslutningar, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan förändra mer än bildens utseende.

### **Dölj en form**

Att sätta [Shape.hidden](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/hidden/) till `True` behåller formen i samlingen men förhindrar att den visas i den vanliga bildspelsvisningen. Dess index, formatering och innehåll förblir tillgängliga för kod, så dölja är lämpligt för valfria element som kan återställas senare.

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

Dölja är inte borttagning eller säkerhet. Objektet kan fortfarande upptäckas och avdöljas av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑ordning**

Överlappande former målas i samlingsordning. [ShapeCollection.reorder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/reorder/) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är längst bak; `len(slide.shapes) - 1` är längst fram.

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

Rektangeln skapas först och sitter initialt bakom ellipsen. Att flytta den till det sista indexet placerar den framför. Slutför z‑ordning efter att du lagt till eller klonat alla relaterade former, eftersom dessa operationer lägger till eller infogar nya samlingsobjekt och kan ändra den avsedda stapeln.

## **Inspektera former på layoutbilder**

Normala bilder, layoutbilder och masternbilder har separata form‑samlingar. En form i en layoutsamling är inte samma objekt som en liknande positionerad form på en normal bild. Inspektera layoutformer när du behöver förstå eller ändra formatering som levereras av en layout.

Följande exempel läser varje layoutforms [Shape.fill_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/fill_format/) och [Shape.line_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/line_format/) utan att anta att varje form är en `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layoutform, avgör om en normal bild ärver objektet eller innehåller en lokal överskrivning, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/write_as_svg/) skriver en forms renderade innehåll till en ström. Resultatet innehåller formen, inte hela bildbakgrunden eller grannformer.

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

Behåll presentationen öppen under rendering. Utdata beror på formens formatering samt resurser som teckensnitt och bilder. Om du behöver hela sammansättningen, exportera bilden snarare än en enskild form. Anroparen äger strömmen och måste stänga den.

## **Justera former**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/align_shapes/) överlagringarna justerar antingen alla former eller valda samlingsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapesalignmenttype/) specificerar kanten, mittlinjen eller fördelningsläget. Sätt `align_to_slide` till `True` för att använda bildens kanter; sätt den till `False` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former till bildens överkant. Deras aktuella index löses upp omedelbart före justering.

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

Justering ändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning kräver tillräckligt många former för att definiera avstånd. Räkna om indexen om du ändrar samlingen innan du anropar metoden.

## **Vänd en form**

[ShapeFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapeframe/)‑klassen lagrar position, storlek, horisontella och vertikala vändinställningar samt rotation. Dess `flip_h` och `flip_v` värden använder [NullableBool](https://reference.aspose.com/slides/sv/python-net/aspose.slides/nullablebool/): `TRUE` aktiverar vändning, `FALSE` inaktiverar den, och `NOT_DEFINED` bevarar det ospecificerade eller standardtillståndet.

Den inmatade presentationen nedan innehåller en ovänd form.

![Formen före vändning](shape_to_be_flipped.png)

Exemplet bevarar alla andra ramvärden och ersätter endast de två vändinställningarna. Detta är viktigt eftersom tilldelning av en ny [Shape.frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/frame/) ersätter hela ramen.

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

![Formen efter vändning](flipped_shape.png)

## **Vanliga frågor**

**Bör jag använda ett samlings‑index som form‑identifierare?**

Endast för kortlivad bearbetning när samlingen inte kommer att förändras innan indexet används. Föredra en validerad `name`‑ eller `alternative_text`‑konvention för skapade mallar, eller `office_interop_shape_id` för bild‑specifikt interop‑arbete.

**Tar dölja av en form bort den från z‑ordningen?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Varför visades en klonad form framför en annan form?**

`add_clone` lägger till klonen i slutet av samlingen, vilket är fronten av z‑ordningen. Använd `insert_clone` för att välja initialt index eller `reorder` efter att alla former har lagts till.