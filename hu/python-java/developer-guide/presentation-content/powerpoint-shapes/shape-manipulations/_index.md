---
title: Prezentációs alakzatok kezelése Pythonon keresztül Java-val
linktitle: Alakzatmanipuláció
type: docs
weight: 40
url: /hu/python-java/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szövege
- alakzat beállítási pont
- előre beállított alakzat állítás
- alakzat geometriája
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthat, módosíthat, klónozhat, eltávolíthat, elrejthet, átrendezhet, exportálhat, igazíthat és tükrözhet prezentációs alakzatokat az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Python via Java a dián lévő alakzatokat egy rendezett [ShapeCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/) segítségével ábrázolja. A gyűjtemény egyaránt a hely, ahol megtalálhatóak és módosíthatóak az alakzatok, valamint az egymásra helyezés sorrendje: a `0` indexű alakzat a leghátrább, míg az utolsó indexű a legelülső alakzat.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan lehet megbízhatóan azonosítani egy alakzatot és módosítani az előre meghatározott alakzat-beállítási pontokat, majd megmutatja, hogyan lehet klónozni, eltávolítani, elrejteni és átrendezni az alakzatokat. Az utolsó szakaszok a diatervezeti formázást, az SVG exportot, a igazítást és a tükrözési beállításokat fedik le. Minden példa független, ezért csak azokat a műveleteket használhatja, amelyekre a munkafolyamatnak szüksége van.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a prezentáció szerkesztési és karbantartási módja szerint:

- [Name](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getName) hasznos fejlesztői vezérelt sablonok esetén, és könnyen megtekinthető a PowerPoint **Selection Pane**-jében. A neveket szerkeszthető, de nem garantált, hogy egyediek, ezért szükség esetén alakítson ki egy elnevezési konvenciót, ha a kód rájuk támaszkodik.
- [AlternativeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getAlternativeText) akkor hasznos, ha egy akadálymentességi leírás vagy a szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy újraírható a hozzáférhetőség érdekében, és nem garantált, hogy egyedi. Ne használja rejtett módon az értelmes akadálymentesítő szöveget adatbáziskulcsként.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getOfficeInteropShapeId) csak olvasható azonosító, amely egy dián belül egyedi, és a PowerPoint interop által használt alakzat‑azonosítónak felel meg. Használja, ha PowerPoint‑tel integrál, vagy ha egyértelmű hivatkozásra van szüksége egy alakzat teljes élettartama alatt. Egy klónozott vagy újra létrehozott alakzat másik alakzat, és kap egy saját azonosítót.

A kapcsolódó [getUniqueId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getUniqueId) metódus prezentáció‑szintű azonosítót ad vissza, de ez a kulcs kiegészítőkhöz van szánva, és újra kiosztható. Nem tekinthető állandó külső kulcsnak. Ha hosszú távú azonosításra van szükség, tartsa a leképezést az alkalmazás‑adatokban, és ellenőrizze, hogy a várt alakzat még létezik‑e.

Az alábbi példa név szerint keres pontos összehasonlítással, és a diára vonatkozó interop‑azonosítót adja vissza. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt a eredményt jelzi, ahelyett, hogy a rossz objektummal folytatná.

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

Amikor egy művelet egy adott alakzattípusra vonatkozik, ellenőrizze a típust, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a megnevezett objektum egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/).

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

## **Előre meghatározott alakzat‑állítások azonosítása és módosítása**

Az előre meghatározott geometriai alakzatok exponálhatnak állítási pontokat, amelyek például a sarkok méretét, a nyíl arányait vagy az ív szögeit szabályozzák. Ezeket a csak‑olvasható [GeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/python-java/aspose.slides/geometryshape/#getAdjustments) gyűjteményen keresztül érheti el. A gyűjteményt maga az alakzat biztosítja, de minden [AdjustValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/) egy módosítható értéket tartalmaz.

Ne csak egy fix gyűjtemény‑indexre támaszkodjon. Iteráljon a állításokon, és vizsgálja meg a csak‑olvasható [getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getType) metódust, amelynek [ShapeAdjustmentType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/) értéke leírja, mit szabályoz az állítás. A csak‑olvasható [getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getName) metódus további azonosító információt ad, és különösen hasznos, ha egy előre meghatározott alakzat több azonos szemantikai típussal rendelkező állítást tartalmaz.

Használja a jelentésnek megfelelő érték‑metódust:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Lekerekített sarkok mérete | [setRawValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Nyílfarok vastagsága | [setRawValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Nyílhegy hossza | [setRawValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Nyílhegy szélessége | [setRawValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Körív vagy ív kezdő szöge | [setAngleValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Körív vagy ív záró szöge | [setAngleValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getType) és [getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getName) csak‑olvasható információt adnak vissza. [getRawValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getRawValue) és [setRawValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setRawValue) egész számot használ a előre meghatározott geometriai egységekben, míg [getAngleValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getAngleValue) és [setAngleValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setAngleValue) fokban megadott szöget kezel. Az állítások száma, sorrendje, jelentése és érvényes tartománya a [ShapeType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/geometryshape/#getShapeType) előre meghatározástól függ. Egy preset‑hez érvényes érték másik preset‑nél érvénytelen lehet vagy más hatást eredményezhet.

Ha a [getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getType) a [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#Custom) értéket adja vissza, az API nem ismer fel szabványos szemantikai jelentést. Vizsgálja meg a [getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getName)‑t, a preset típusát és a jelenlegi értéket, és csak akkor módosítsa az állítást, ha a várható jelentés és tartomány ismert. Még a felismert típusok esetén ellenőrizze, hogy ugyanaz a típus többször is előfordul-e, mielőtt értéket választana. A [Connector](/slides/hu/python-java/connector/) cikk bemutatja a csatlakozó‑görbület‑állítások ilyen helyzetét.

Az alábbi teljes példa három előre meghatározott alakzat alap‑ és módosított verzióját hozza létre. Minden állításon végigiterál, kiírja a nevét és típusát, a méret‑kapcsolt értékeket a [setRawValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setRawValue)‑vel, a szögeket a [setAngleValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setAngleValue)‑vel módosítja, majd elmenti az eredményt. A bal oszlop az alap geometriai alakzatot mutatja; a jobb oszlop a módosított lekerekített téglalapot, a négyirányú nyilat és a körívet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Hozzáadja a fejlécet az alap és a módosított alakzat oszlopokhoz.
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

A szemantikai típus ellenőrzése érték módosítása előtt egyértelművé teszi a kód szándékát, és elkerüli, hogy egy adott gyűjtemény‑indexnek különböző jelentése legyen a különböző előre meghatározott alakzatoknál.

## **Alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és átrendezés metódusai azonnal a gyűjteményen dolgoznak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon tovább az előzőleg rögzített indexekre.

### **Alakzat klónozása**

[addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addClone) független másolatot hoz létre, és a célgyűjtemény végére fűzi. [insertClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#insertClone) szintén másolatot készít, de egy meghatározott z‑order indexen helyezi el. Azokat a túlterheléseket, amelyek koordinátákat fogadnak, a másolat méretét nem változtatják; a szélesség‑ és magasság‑paraméteres változatok átméretezhetik is.

A példa létrehoz egy céldiát, klónoz egy feliratos téglalapot a frontra, és egy másik klónt szúr be a háttérbe. Bármelyik klón módosítása nem érinti a forrás‑alakzatot.

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

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Ha ezeknek az értékeknek egyedinek kell lenniük, adjon új logikai azonosítókat a klónnak. A komplex alakzatok által használt erőforrások kezelése a prezentáció feladata, de a klón új gyűjtemény‑elemként és új alakzat‑azonosítóval jelenik meg.

### **Alakzatok eltávolítása**

[remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#remove) egy adott alakzat‑objektumot töröl a gyűjteményéből. Több egyezés eltávolításakor indexelt iteráció során járjon végig a végéről, hogy a maradék indexek érvényben maradjanak.

Ez a példa minden olyan alakzatot eltávolít, amelynek a neve a megadott névre egyezik. A jelenlegi indexnél lévő alakzatot olvassa, nem egy fix gyűjtemény‑elemet, és nem kényszeríti feleslegesen a típusú átkonvertálást.

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

Eltávolítás után az alakzatszám és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a mentett indexek. Vegye figyelembe a csatlakozókat, animációkat és egyéb prezentációs elemeket, amelyek a törölt objektumra hivatkozhatnak; egy látható alakzat eltávolítása több mint a dia megjelenését változtathatja meg.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#setHidden) beállítása `True`‑ra a alakzatot a gyűjteményben hagyja, de megakadályozza, hogy a normál diavetítés során megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kód számára, így az elrejtés alkalmas opcionális elemekre, amelyeket később vissza lehet állítani.

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

Az elrejtés nem törlés vagy biztonsági intézkedés. Az objektum továbbra is felfedezhető és újra láthatóvá tehető felhasználó vagy kód által, és része marad a prezentációs fájlnak.

### **Z‑order módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében kerülnek kirajzolásra. [reorder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#reorder) egy meglévő alakzatot egy cél indexre mozgat anélkül, hogy klónozná. A `0` index a hátul, a gyűjtemény [size](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#size) mínusz egy a front.

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

A téglalap először jön létre, és eleve a kör mögött helyezkedik el. A végső indexre mozgatása a frontra helyezi. Z‑order‑t csak akkor véglegesítsen, miután minden kapcsolódó alakzatot hozzáadta vagy klónozta, mivel ezek a műveletek új gyűjtemény‑elemeket illesztenek be és módosíthatják a kívánt rétegezést.

## **Alakzatok vizsgálata elrendezési diáknál**

A normál diák, elrendezési diák és mester‑diák különálló alakzatgyűjteménnyel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan elhelyezett alakzat egy normál dián. Vizsgálja meg az elrendezési alakzatokat, ha meg kell értenie vagy módosítania kell egy elrendezés által biztosított formázást.

A következő példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getFillFormat) és [LineFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getLineFormat) értékét olvassa anélkül, hogy feltételezné, hogy minden alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/).

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

Egy elrendezés szerkesztése több diára is hatással lehet, amely az adott elrendezést használja. Mielőtt módosítana egy elrendezési alakzatot, határozza meg, hogy egy normál dia örökli‑e az objektumot vagy helyi felülírással rendelkezik, és tesztelje az összes olyan diát, amely az elrendezést használja.

## **Alakzat exportálása SVG‑ként**

A [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) `writeAsSvg` metódusa egy alakzat renderelt tartalmát egy folyamra írja. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia hátterét vagy a szomszédos alakzatokat.

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

Tartsa nyitva a prezentációt a renderelés közben. A kimenet az alakzat formázásától, valamint a betűkészletek és képekhez használt erőforrásoktól függ. Ha a teljes összeállításra van szüksége, exportálja a diát, ne egyedi alakzatot. A hívó felel a folyam tulajdonjogáért, és le kell zárnia azt.

## **Alakzatok igazítása**

A [SlideUtil.alignShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/#alignShapes) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjtemény‑indexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapesalignmenttype/) megadja az él, a középvonal vagy a eloszlási mód típusát. Az `align_to_slide` értéket `True`‑ra állítva a dia széleit használja; `False`‑ra állítva a kiválasztott alakzatok egymáshoz viszonyított igazítását.

Ez a példa három alakzatot a dia felső széléhez igazít. A visszaadott alakzat‑referenciákat az igazítás előtt az aktuális indexeikre konvertálja.

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

Az igazítás a pozíciókat módosítja, nem a z‑order‑t. Relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő számú alakzat kell, hogy meghatározza a távolságot. Ha a gyűjteményt módosítja az eljárás előtt, számolja újra az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, vízszintes és függőleges tükrözési beállításokat, valamint a forgatást. A [getFlipH](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeframe/#getFlipH) és a [getFlipV](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeframe/#getFlipV) értékek a [NullableBool](https://reference.aspose.com/slides/hu/python-java/aspose.slides/nullablebool/) típusúak: `True` engedélyezi a tükrözést, `False` tiltja, a `NotDefined` az alapértelmezett/nem definiált állapotot őrzi.

Az alábbi bemutató prezentáció egy nem tükrözött alakzatot tartalmaz.

![Az alakzat a tükrözés előtt](shape_to_be_flipped.png)

A példa minden egyéb frame‑értéket meghagy, és csak a két tükrözési beállítást cseréli le. Ez azért fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#setFrame) hozzárendelése teljesen felülírja a keretet.

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

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megtartja a pozícióját, méretét és forgását.

![Az alakzat a tükrözés után](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény‑indexet alakzat‑azonosítóként?**

Csak rövid életű feldolgozásnál, amikor a gyűjmenteny nem változik az index használata előtt. A szerkesztett sablonokhoz ellenőrzött [Name](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getName) vagy [AlternativeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getAlternativeText) konvenció, illetve diára vonatkozó interop munkához a [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getOfficeInteropShapeId) használata javasolt.

**Eltávolításkor az elrejtett alakzat eltűnik‑e a z‑order‑ból?**

Nem. Egy rejtett alakzat ugyanazon az indexen marad a gyűjteményben. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addClone) a klónt a gyűjtemény végére fűzi, ami a z‑order frontja. Használja az [insertClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#insertClone)‑t a kezdeti index megadásához, vagy a [reorder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#reorder)‑t, miután minden alakzatot hozzáadta.

**Használhatok fix indexet egy előre meghatározott alakzat‑állítás azonosításához?**

Csak akkor, ha pontosan ellenőrizte az előre meghatározott alakzatot és a gyűjtemény elrendezését. Inkább iteráljon a [GeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/python-java/aspose.slides/geometryshape/#getAdjustments)‑en, és ellenőrizze a [AdjustValue.getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getType)‑t; ha ugyanaz a szemantikai típus többször is előfordul, használja a [AdjustValue.getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getName)‑t további információként.