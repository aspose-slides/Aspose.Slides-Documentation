---
title: Beheer presentatie-vormen in Python via Java
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/python-java/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatievorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- volgorde van vormen wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- aanpassingspunt van vorm
- preset-vormaanpassing
- vormgeometrie
- vorm-lay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u presentatie-vormen kunt identificeren, aanpassen, klonen, verwijderen, verbergen, ordenen, exporteren, uitlijnen en spiegelen met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides for Python via Java vertegenwoordigt de vormen op een dia als een geordende [ShapeCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/). De collectie is zowel de plaats waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de meest achterste vorm, terwijl de laatste index de meest voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren en preset‑aanpassingspunten kunt wijzigen, daarna laat het zien hoe je vormen kunt klonen, verwijderen, verbergen en opnieuw ordenen. De laatste secties behandelen lay‑outniveau‑opmaak, SVG‑export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat je alleen de bewerkingen kunt gebruiken die jouw werkstroom vereist.

## **Identificeren en vinden van vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identificatoren. Toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identificator op basis van hoe de presentatie is opgesteld en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getName) is handig voor door ontwikkelaars gecontroleerde sjablonen en is eenvoudig te inspecteren in het selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie op als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getAlternativeText) is nuttig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik geen betekenisvolle toegankelijkheidstekst stilletjes als databasietoets.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getOfficeInteropShapeId) is een alleen‑lezen identificator die uniek is binnen een dia en overeenkomt met de vorm‑ID die PowerPoint‑interop gebruikt. Gebruik deze bij integratie met PowerPoint of wanneer je een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of gerecreëerde vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde [getUniqueId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getUniqueId)‑methode retourneert een identificator met presentatiescope, maar die identificator is bedoeld voor add‑ins en kan opnieuw worden toegewezen. Beschouw het niet als een permanente externe sleutel. Wanneer langdurige identiteit essentieel is, bewaar je de mapping in toepassingsdata en controleer je of de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op naam met een exacte vergelijking en rapporteert de slide‑scoped interop‑ID. Wanneer de sjabloon de verwachte vorm niet bevat, rapporteert de code dat resultaat in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een type vorm, controleer dan het type voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het benoemde object een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) is.

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

## **Identificeren en wijzigen van preset‑vormaanpassingen**

Preset‑geometrievormen kunnen aanpassingspunten blootleggen die kenmerken zoals hoekgrootte, pijlverhoudingen of booghoeken regelen. Toegang krijg je via de alleen‑lezen collectie [GeometryShape.getAdjustments](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/#getAdjustments). De collectie zelf wordt door de vorm geleverd, maar elke [AdjustValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/) bevat een waarde die kan worden aangepast.

Vertrouw niet alleen op een vaste collectie‑index. Loop door de aanpassingen en inspecteer de alleen‑lezen [getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getType)‑methode, waarvan de [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/)‑waarde beschrijft wat de aanpassing regelt. De alleen‑lezen [getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getName)‑methode geeft extra identificatie‑informatie en is vooral nuttig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de waardemethode die overeenkomt met de betekenis van de aanpassing:

| Adjustment type | Doel | Waarde om te wijzigen |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Grootte van afgeronde hoeken | [setRawValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Dikte van een pijlpoot | [setRawValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Lengte van een pijlpunt | [setRawValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Breedte van een pijlpunt | [setRawValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Starthoek van een taart‑ of boogsegment | [setAngleValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Eindhoek van een taart‑ of boogsegment | [setAngleValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getType) en [getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getName) geven alleen‑lezen informatie terug. [getRawValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getRawValue) en [setRawValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setRawValue) werken met een integer in de native eenheden van de preset, terwijl [getAngleValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getAngleValue) en [setAngleValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setAngleValue) werken met een hoek in graden. Het aantal, de volgorde, de betekenis en het geldige bereik van aanpassingen hangen af van het preset‑[ShapeType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/#getShapeType). Een waarde die geldig is voor de ene preset kan ongeldig of met een ander effect zijn voor een andere.

Wanneer [getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getType) [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#Custom) retourneert, herkent de API geen standaard semantische betekenis. Inspecteer [getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getName), het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd tenzij de verwachte betekenis en reikwijdte bekend zijn. Zelfs voor herkende types moet je controleren of hetzelfde type meer dan eens voorkomt voordat je een waarde selecteert. Het artikel over [Connector](/slides/nl/python-java/connector/) toont deze situatie met connector‑boogaanpassingen.

Het volgende volledige voorbeeld maakt standaard‑ en gewijzigde versies van drie preset‑vormen. Het doorloopt elke aanpassing, rapporteert de naam en het type, wijzigt grootte‑gerelateerde waarden via [setRawValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setRawValue), wijzigt hoeken via [setAngleValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setAngleValue) en slaat het resultaat op. De linker kolom behoudt de standaardgeometrie; de rechter kolom toont de aangepaste afgeronde rechthoek, vierweg‑pijl en part.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Voegt kopteksten toe voor de kolommen met standaard- en aangepaste vormen.
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

Het controleren van het semantische type vóór het wijzigen van een waarde maakt de code expliciet over de intentie en voorkomt de veronderstelling dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑vormen.

## **De vormverzameling wijzigen**

De methoden add, clone, remove en reorder werken direct op de verzameling. Als een bewerking het aantal of de volgorde van vormen verandert, vertrouw dan niet langer op indexen die vóór die bewerking zijn vastgelegd.

### **Een vorm klonen**

[addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addClone) maakt een onafhankelijk kopie en voegt deze toe aan de doelsverzameling. [insertClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#insertClone) maakt ook een kopie maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een bestemmingsdia, kloont een gelabelde rechthoek naar de voorkant en voegt een tweede kloon toe aan de achterkant. Wijzigingen aan een van de klonen hebben geen invloed op de bronvorm.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Ken nieuwe logische identificatoren toe aan de kloon wanneer deze waarden uniek moeten zijn. Resources die door complexe vormen worden gebruikt, worden door de presentatie afgehandeld, maar een kloon blijft een nieuw collectievelement met een nieuwe vormidentiteit.

### **Vormen verwijderen**

[remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#remove) verwijdert een specifiek vormobject uit zijn verzameling. Wanneer je meerdere overeenkomsten verwijdert tijdens een geïndexeerde iteratie, loop dan van het einde zodat elke resterende index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een bepaalde naam. Het leest de vorm op de huidige index, niet een vaste collectie‑item, en cast de vorm niet onnodig.

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

Na verwijdering wijzigen het aantal vormen en de indexen van latere vormen. Verwijzingen naar niet‑aangedane vormen blijven betrouwbaarder dan opgeslagen indexen. Denk ook aan connectoren, animaties en andere presentatiefuncties die naar het verwijderde object kunnen refereren; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen het uiterlijk van de dia.

### **Een vorm verbergen**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setHidden) op `True` houdt de vorm in de verzameling maar voorkomt dat deze verschijnt tijdens de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, zodat verbergen geschikt is voor optionele elementen die later eventueel opnieuw zichtbaar moeten worden.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden ontdekt en zichtbaar gemaakt door een gebruiker of door code, en blijft deel uitmaken van het presentatie‑bestand.

### **De Z‑order wijzigen**

Overlapende vormen worden getekend volgens de volgorde in de verzameling. [reorder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#reorder) verplaatst een bestaande vorm naar een doelindex zonder deze te klonen. Index `0` is de achterkant; de collectie‑[size](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#size) min één is de voorkant.

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

De rechthoek wordt eerst aangemaakt en zit aanvankelijk achter de ellips. Verplaatsen naar de laatste index plaatst deze voorop. Finaliseer de z‑order nadat alle gerelateerde vormen zijn toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe en kunnen de beoogde stapelvolgorde wijzigen.

## **Vormen op layout‑dia’s inspecteren**

Normale dia’s, layout‑dia’s en master‑dia’s hebben afzonderlijke vormverzamelingen. Een vorm in een layout‑verzameling is niet hetzelfde object als een gelijk gepositioneerde vorm op een normale dia. Inspecteer layout‑vormen wanneer je de door een layout geleverde opmaak wilt begrijpen of wijzigen.

Het volgende voorbeeld leest de [FillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getFillFormat) en [LineFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getLineFormat) van elke layout‑vorm zonder aan te nemen dat elke vorm een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) is.

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

Het bewerken van een layout kan meerdere dia’s die er gebruik van maken beïnvloeden. Controleer vóór het wijzigen van een layout‑vorm of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die layout gebruikt.

## **Een vorm exporteren naar SVG**

De `writeAsSvg`‑methode van [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat alleen de vorm, niet de volledige dia‑achtergrond of naburige vormen.

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

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van bronnen zoals lettertypen en afbeeldingen. Als je de volledige compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten.

## **Vormen uitlijnen**

De [SlideUtil.alignShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideutil/#alignShapes)‑overloads lijnen ofwel alle vormen of geselecteerde collectie‑indexen uit. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapesalignmenttype/) specificeert de rand, de middenlijn of de distributiemodus. Zet `align_to_slide` op `True` om de dia‑randen te gebruiken; zet het op `False` om de geselecteerde vormen relatief op elkaar uit te lijnen.

Dit voorbeeld uitlijnt drie vormen langs de bovenrand van de dia. De geretourneerde vorm‑referenties worden direct vóór het uitlijnen omgezet naar hun huidige indexen.

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

Uitlijnen wijzigt posities, niet de z‑order. Relatieve uitlijning vereist doorgaans minstens twee vormen, terwijl horizontale of verticale distributie voldoende vormen nodig heeft om de afstand te bepalen. Herbereken indexen als je de verzameling wijzigt vóór het aanroepen van de methode.

## **Een vorm spiegelen**

De klasse [ShapeFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeframe/) slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. De waarden [getFlipH](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeframe/#getFlipH) en [getFlipV](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeframe/#getFlipV) gebruiken [NullableBool](https://reference.aspose.com/slides/nl/python-java/aspose.slides/nullablebool/): `True` schakelt de spiegel in, `False` schakelt uit, en `NotDefined` behoudt de onbepaalde/standaardstatus.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![The shape before flipping](shape_to_be_flipped.png)

Het voorbeeld behoudt alle andere frame‑waarden en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setFrame) het volledige frame vervangt.

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

De opgeslagen vorm wordt zowel horizontaal als verticaal gespiegeld terwijl positie, grootte en rotatie behouden blijven.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vorm‑identificator?**

Alleen voor kort‑levende verwerking wanneer de collectie niet verandert vóórdat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde [Name](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getName)‑ of [AlternativeText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getAlternativeText)‑conventie voor door auteurs gemaakte sjablonen, of [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getOfficeInteropShapeId) voor slide‑scoped interop‑werk.

**Verwijdert het verbergen van een vorm deze uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, herschikt, bewerkt of opnieuw zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

[addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addClone) voegt de kloon toe aan het einde van de collectie, wat de voorkant van de z‑order is. Gebruik [insertClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#insertClone) om de initiële index te kiezen of [reorder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#reorder) nadat alle vormen zijn toegevoegd.

**Kan ik een vaste index gebruiken om een preset‑vormaanpassing te identificeren?**

Alleen na validatie van de exacte preset en collectie‑indeling. Geef de voorkeur aan itereren door [GeometryShape.getAdjustments](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/#getAdjustments) en het controleren van [AdjustValue.getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getType); gebruik [AdjustValue.getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getName) als extra informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.