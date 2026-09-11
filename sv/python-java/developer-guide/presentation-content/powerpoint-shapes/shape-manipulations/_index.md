---
title: Hantera presentationsformer i Python via Java
linktitle: Formhantering
type: docs
weight: 40
url: /sv/python-java/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölj form
- ändra formordning
- hämta interop-form-ID
- formens alternativa text
- justeringspunkt för form
- förinställd formjustering
- formgeometri
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- vänd form
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du identifierar, justerar, klonar, tar bort, döljer, ändrar ordning, exporterar, justerar och vänder presentationsformer med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides för Python via Java representerar formerna på en bild som en ordnad [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/). Samlingen är både platsen där du hittar och ändrar former samt källan till deras staplingsordning: index `0` är den längst bak, medan det sista indexet är den längst fram.

Denna artikel följer den modellen. Den förklarar först hur du på ett pålitligt sätt identifierar en form och ändrar förinställda justeringspunkter, och visar sedan hur du klonar, tar bort, döljer och ändrar ordningen på former. De sista avsnitten behandlar layout‑nivå formatering, SVG‑export, justering och speglingsinställningar. Varje exempel är fristående, så du kan använda bara de operationer ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Samlingens index är praktiska när du bearbetar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller ändra ordningen på en form kan förändra dess index. Välj en identifierare utifrån hur presentationen författas och underhålls:

- [Name](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getName) är användbart för utvecklarkontrollerade mallar och är enkelt att inspektera i PowerPoints urvalspanel. Namn kan redigeras och är inte garanterat unika, så etablera en namngivningskonvention om kod beror på dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getAlternativeText) är användbart när en tillgänglighetsbeskrivning eller en författar‑tillagd tagg redan identifierar formen. Den är synlig för användare, kan lokalanpassas eller skrivas om för tillgänglighet, och är inte garanterat unik. Använd inte tyst meningsfull tillgänglighetstext som en databassöknyckel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getOfficeInteropShapeId) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den form‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en forms livstid. En klonad eller om‑skapad form är en annan form och får sitt eget ID.

Den relaterade metoden [getUniqueId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getUniqueId) returnerar en identifierare med presentationsomfång, men den är avsedd för tillägg och kan återtilldelas. Den bör inte ses som en permanent extern nyckel. Om långsiktig identitet är väsentlig, håll mappningen i applikationsdata och validera att den förväntade formen fortfarande finns.

Följande exempel söker efter namn med en exakt jämförelse och rapporterar den bild‑specifika interop‑ID:n. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet i stället för att fortsätta med fel objekt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

När en operation är specifik för en formtyp, kontrollera typen innan du använder typ‑specifika medlemmar. Detta exempel uppdaterar text och alternativ text endast om det namngivna objektet är en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Identifiera och ändra förinställda formjusteringar**

Förinställda geometriformer kan exponera justeringspunkter som styr egenskaper som hörnstorlek, pilförhållanden eller båg‑vinklar. Åtkomst till dem sker via den skrivskyddade samlingen [GeometryShape.getAdjustments](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/#getAdjustments). Själva samlingen tillhandahålls av formen, men varje [AdjustValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/) innehåller ett värde som kan ändras.

Förlita dig inte enbart på ett fast samlings‑index. Iterera genom justeringarna och inspektera den skrivskyddade metoden [getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getType), vars värde av typen [ShapeAdjustmentType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/) beskriver vad justeringen styr. Den skrivskyddade metoden [getName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getName) ger ytterligare identifieringsinformation och är särskilt användbar när en förinställning innehåller mer än en justering med samma semantiska typ.

Använd den värdemetod som matchar justeringens innebörd:

| Justeringstyp | Syfte | Värde att ändra |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Storlek på rundade hörn | [setRawValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Tjocklek på en pilsvans | [setRawValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Längd på en pilspets | [setRawValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Bredd på en pilspets | [setRawValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Startvinkel för en paj eller båge | [setAngleValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Slutvinkel för en paj eller båge | [setAngleValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getType) och [getName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getName) returnerar skrivskyddad information. [getRawValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getRawValue) och [setRawValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setRawValue) arbetar med ett heltal i förinställningens ursprungliga geometrienheter, medan [getAngleValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getAngleValue) och [setAngleValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setAngleValue) arbetar med en vinkel i grader. Antalet, ordningen, betydelsen och det giltiga intervallet för justeringar beror på förinställningens [ShapeType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/#getShapeType). Ett värde som är giltigt för en förinställning kan vara ogiltigt eller ha en annan effekt för en annan.

När [getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getType) returnerar [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#Custom) känner API‑et inte igen en standardsemantisk betydelse. Inspektera [getName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getName), förinställningstypen och det befintliga värdet, och lämna justeringen oförändrad om den förväntade betydelsen och intervallet inte är känt. Även för erkända typer, kontrollera om samma typ förekommer mer än en gång innan du väljer ett värde. Artikeln [Connector](/slides/sv/python-java/connector/) visar detta scenario med böj‑justeringar för anslutningar.

Följande kompletta exempel skapar standard‑ och modifierade versioner av tre förinställda former. Det itererar genom varje justering, rapporterar dess namn och typ, ändrar storleksrelaterade värden via [setRawValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setRawValue), ändrar vinklar via [setAngleValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setAngleValue) och sparar resultatet. Den vänstra kolumnen behåller standardgeometrin; den högra kolumnen visar den justerade rundade rektangeln, fyrvägs‑pilen och pajen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Lägger till rubriker för standard- och justerade formkolumner.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Att kontrollera den semantiska typen innan ett värde ändras gör koden explicit i sitt syfte och undviker antagandet att ett särskilt samlings‑index har samma betydelse över olika förinställda former.

## **Ändra formsamlingen**

Metoderna för att lägga till, klona, ta bort och ändra ordning opererar på samlingen omedelbart. Om en operation förändrar antalet eller ordningen på former, fortsätt inte att förlita dig på index som samlats in före den operationen.

### **Klona en form**

[addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addClone) skapar en oberoende kopia och lägger till den i mål‑samlingen. [insertClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#insertClone) skapar också en kopia men placerar den på ett angivet z‑order‑index. Överlagringarna som accepterar koordinater flyttar klonen utan att ändra dess storlek; överlagringar med bredd och höjd kan även ändra storleken.

Exemplet skapar en målbild, klonar en märkt rektangel till framsidan och infogar en andra klon längst bak. Ändringar i någon av klonerna påverkar inte källformen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Klonning kopierar formens innehåll och formatering, inklusive dess namn och alternativa text. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med ny form‑identitet.

### **Ta bort former**

[remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#remove) raderar ett specifikt formobjekt från dess samling. När du tar bort flera matchningar under index‑iteration, gå från slutet så att varje återstående index förblir giltigt.

Detta exempel tar bort varje form med ett angivet namn. Det läser formen vid det aktuella indexet, inte ett fast samlings‑objekt, och castar inte formen i onödan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Efter borttagning ändras antalet former och indexen för senare former. Referenser till opåverkade former förblir mer tillförlitliga än sparade index. Tänk också på anslutningar, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan ändra mer än bara bildens utseende.

### **Dölja en form**

Att sätta [Hidden](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setHidden) till `True` behåller formen i samlingen men förhindrar att den visas i det normala bildspelet. Dess index, formatering och innehåll förblir tillgängliga för kod, så doldhet är lämplig för valfria element som kan återställas senare.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Döljning är inte radering eller säkerhet. Objektet kan fortfarande upptäckas och göras synligt igen av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑ordning**

Överlappande former målas i samlingsordning. [reorder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#reorder) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är längst bak; samlingens [size](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#size) minus ett är längst fram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rektangeln skapas först och sitter initialt bakom ellipsen. Att flytta den till det sista indexet placerar den i främre delen. Slutför z‑ordningen efter att alla relaterade former har lagts till eller klonats, eftersom dessa operationer lägger till eller infogar nya samlingsobjekt och kan ändra den avsedda staplingen.

## **Inspektera former på layout‑bilder**

Normala bilder, layout‑bilder och master‑bilder har separata form‑samlingar. En form i en layout‑samling är inte samma objekt som en likadant placerad form på en normal bild. Inspektera layout‑former när du behöver förstå eller ändra formatering som levereras av en layout.

Följande exempel läser varje layout‑forms [FillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getFillFormat) och [LineFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getLineFormat) utan att anta att varje form är en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layout‑form, avgör om en normal bild ärver objektet eller innehåller ett lokalt överskri­vning, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

Metoden `writeAsSvg` på [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/) skriver en enstaka forms renderade innehåll till en ström. Resultatet innehåller bara formen, inte hela bildbakgrunden eller grannformer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Håll presentationen öppen under rendering. Utdata beror på formens formatering samt resurser såsom typsnitt och bilder. Om du behöver hela kompositionen, exportera bilden istället för en enskild form. Anroparen äger strömmen och måste stänga den.

## **Justera former**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideutil/#alignShapes) har överlagringar som antingen justerar alla former eller valda samlings‑index. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapesalignmenttype/) specificerar kant, mittlinje eller fördelningsläge. Sätt `align_to_slide` till `True` för att använda bildens kanter; sätt den till `False` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former mot bildens överkant. De returnerade formreferenserna konverteras till sina aktuella index omedelbart före justeringen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Justering ändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning kräver tillräckligt många former för att definiera avstånd. Räkna om index om du ändrar samlingen innan du anropar metoden.

## **Spegelvänd en form**

Klassen [ShapeFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeframe/) lagrar position, storlek, horisontell och vertikal spegelinställning samt rotation. Dess värden [getFlipH](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeframe/#getFlipH) och [getFlipV](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeframe/#getFlipV) använder [NullableBool](https://reference.aspose.com/slides/sv/python-java/aspose.slides/nullablebool/): `True` aktiverar spegling, `False` inaktiverar den, och `NotDefined` bevarar det odefinierade/default‑tillståndet.

Den underliggande presentationen nedan innehåller en ospeglad form.

![The shape before flipping](shape_to_be_flipped.png)

Exemplet bevarar alla andra ramvärden och ersätter endast de två spegelinställningarna. Detta är viktigt eftersom en ny [Frame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setFrame) ersätter hela ramen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Den sparade formen är speglad horisontellt och vertikalt samtidigt som dess position, storlek och rotation behålls.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Ska jag använda ett samlings‑index som en formidentifierare?**

Endast för kortlivad bearbetning när samlingen inte kommer att förändras innan indexet används. Föredra ett validerat [Name](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getName)- eller [AlternativeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getAlternativeText)-konvention för författade mallar, eller [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getOfficeInteropShapeId) för interop‑arbete på bild‑nivå.

**Tar dölja en form bort den från z‑ordningen?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, om‑ordnas, redigeras eller göras synlig igen.

**Varför hamnade en klonad form framför en annan form?**

[addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addClone) lägger till klonen i slutet av samlingen, vilket är fronten i z‑ordningen. Använd [insertClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#insertClone) för att välja start‑index eller [reorder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#reorder) efter att alla former har lagts till.

**Kan jag använda ett fast index för att identifiera en förinställd formjustering?**

Endast efter att du har validerat den exakta förinställningen och samlingslayouten. Föredra att iterera genom [GeometryShape.getAdjustments](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/#getAdjustments) och kontrollera [AdjustValue.getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getType); använd [AdjustValue.getName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getName) som ytterligare information när samma semantiska typ förekommer mer än en gång.