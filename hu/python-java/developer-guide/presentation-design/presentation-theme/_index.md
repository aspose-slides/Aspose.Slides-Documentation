---
title: Prezentációs témák kezelése Pythonban Java-val
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/python-java/presentation-theme/
keywords:
- PowerPoint téma
- prezentációs téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- külső téma
- THMX
- téma szín
- kiegészítő paletta
- téma betűtípus
- téma stílus
- téma effektus
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Az Aspose.Slides Python-Java verziójában a mester prezentációs témák kezelése, a PowerPoint fájlok egységes márkázással történő létrehozása, testreszabása és konvertálása."
---
## **Bevezetés**

A bemutató téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témára érzékeny objektumok ezekre a közös definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides‑ban a prezentáció‑szintű téma a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getMasterTheme) metóduson keresztül érhető el. Egy prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülbírálásokat. Egy mester a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterthememanager/#getOverrideTheme) metódussal felülbírálhatja a prezentáció témáját, míg egy elrendezés vagy egy önálló dia a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) metódussal felülbírálhatja a örökölt témát. Gyakorlatban egy dia hatékony témája ezen öröklődési lánc mentén kerül feloldásra: prezentációs téma, mester‑felülbírálás, elrendezés‑felülbírálás és dia‑felülbírálás.

![Téma összetevők: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma vizsgálata, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektus‑stílusok frissítése, valamint a hatékony értékek olvasása az öröklődés és a felülbírálások feloldása után.

## **Téma vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátumsémáját a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/mastertheme/#getFontScheme) és [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/mastertheme/#getFormatScheme) metódusokon keresztül teszi hozzáférhetővé. Ezeknek a gyűjteményeknek a vizsgálata a módosítás előtt különösen hasznos, ha egy prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma‑tulajdonságokat, és jelentést készít arról, hogy hány háttér, kitöltés, vonal és effektus‑stílus van tárolva a témában:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

Ha egy fájl több mestert használ, ne tételezzük fel, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Vizsgáljuk meg a diával kapcsolatos mestert, és használjuk a cikk későbbre nyújtott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülbírálások is előfordulhatnak.

## **Téma színeinek módosítása**

A témára érzékeny kitöltések, vonalak és szöveg logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/schemecolor/) felsorolásból. Amikor a megfelelő bejegyzést módosítjuk a [ColorScheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/colorscheme/) gyűjtményben, minden olyan objektum, amely még mindig erre a téma‑színre hivatkozik, az új érték szerint kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak meg téma‑szín frissítésekor.

Az alábbi vég‑végi példa létrehoz egy alakzatot, amely az `Accent4`‑et használja, megváltoztatja a téma `Accent4` színét pirosra, menti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

Mivel a téglalap továbbra is az `Accent4`‑hez van kapcsolva, látható színe a téma módosítása után piros lesz. Ha a sémaszínt közvetlen színre cseréljük az alakzaton, a későbbi `Accent4` módosítások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint világosabb és sötétebb változatokat származtat egy téma‑színből színátalakítások alkalmazásával. Az Aspose.Slides ezeket az átalakításokat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/colortransformoperation/) felsorolásban teszi elérhetővé.

![Fő téma‑színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – A fő téma színek.

**2** – A fő téma színeiből származó világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre az `Accent4`‑ alapján, ötön luminancia‑átalakítást alkalmaz, és elmenti az eredményt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ezek a változatok továbbra is a téma‑színen alapulnak. Ha később az `Accent4` változik, a transzformált színek az új `Accent4` értékből lesznek újraszámolva.

### **`SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/colorscheme/) ugyanazokat a témahelyeket a `Dark1`, `Light1`, `Dark2` és `Light2` név alatt teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazoknak a témahelyeknek alternatív elnevezései; nem olyan értékek, amelyeket dinamikusan konvertálnak az egyik formából a másikba.

## **Téma betűtípusainak módosítása**

Egy téma‑betűtípus‑séma nagy betűtípus‑készletet tartalmaz a címsorokhoz és kisebb betűtípus‑készletet a törzsszöveghez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontscheme/#getMajor) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontscheme/#getMinor) metódusok teszik ezeket a készleteket elérhetővé.

PowerPoint‑kompatibilis téma‑betűtípus‑azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Szövegtörzs betűtípusa Latin (Minor Latin Font)
* `+mj-lt` – Címsor betűtípusa Latin (Major Latin Font)
* `+mn-ea` – Szövegtörzs betűtípusa Kelet‑ázsiai (Minor East Asian Font)
* `+mj-ea` – Címsor betűtípusa Kelet‑ázsiai (Major East Asian Font)

Az alábbi példa egy olyan címsort hoz létre, amely a fő Latin téma‑betűtípust használja, valamint egy törzssorot, amely a kisebb Latin téma‑betűtípust használja. Ezután módosítja a téma‑betűtípusokat, és elmenti az eredményt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A címsor a fő betűtípust, a törzsszöveg a kisebb betűtípust követi. A szöveg, amelynek explicit betűtípus‑neve van a témaazonosító helyett, nem vált automatikusan át, ha a téma‑betűtípus‑séma megváltozik.

A fő és kisebb betűtípus‑gyűjtemények tartalmazhatnak betűtípus‑leképezéseket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek a vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/python-java/script-specific-font-mappings/) oldalt.

{{% alert color="success" title="Tip" %}}
További információk a bemutató betűtípusairól a [PowerPoint Fonts](/slides/hu/python-java/powerpoint-fonts/) oldalon találhatók.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolódó problémákat oldanak meg.

### **Külső téma alkalmazása egy mesterhez kapcsolódó diákra**

Használja a [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) metódust, ha rendelkezik egy PowerPoint téma‑fájllal (`.thmx`), és minden, egy adott mesterhez kapcsolódó diát új stílussal szeretne ellátni. Válassza ki a mestert a [Presentation.getMasters](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getMasters) gyűjteményből, amelyet a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslidecollection/) képvisel, majd adja át a téma‑fájl útvonalát a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehozza az új mester diát a kiválasztott mester alapján.
1. Alkalmazza a külső témát az új mesterre.
1. Az új mestert hozzárendeli minden diához, amely korábban a kiválasztott mesterhez tartozott.
1. Visszaadja a frissen létrehozott [MasterSlide] objektumot.

Az alábbi példa alkalmaz egy külső témát az első mesterhez kapcsolódó diákra, majd elmenti a prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Egy érvénytelen, sérült vagy nem támogatott téma [PptxReadException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxreadexception/) kivételt okozhat. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférés hibáit, és csak akkor mentse a prezentációt, ha a téma sikeresen alkalmazva lett.

Csak a kiválasztott mesterhez tartozó diák kerülnek átirányításra. Az más mesterekhez tartozó diák megtartják meglévő mestereiket és témáikat. A témára érzékeny színek, betűtípusok, kitöltések, vonalak, háttér‑ és effektus‑elemek a külső témához viszonyítva kerülnek feloldásra. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑szintű és dia‑szintű felülbírálások szintén felülírhatják az új mesterből örökölt értékeket.

A téma olyan betűtípusokra hivatkozhat, amelyek nincsenek jelen a futási környezetben. A következetes megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket a [custom font sources](/slides/hu/python-java/custom-font/) segítségével, vagy konfigurálja a [font substitution](/slides/hu/python-java/font-substitution/) beállításokat.

Ez egy közvetlen mester‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útvonalát várja, és nem igényel manuális dia‑ vagy elrendezés‑szintű téma‑felülbírálások létrehozását.

### **Különböző külső témák alkalmazása egy több‑mesteres prezentációban**

Ha a releváns mester nincs előre ismert, szerezze be egy reprezentatív dia segítségével a [Slide.getLayoutSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getLayoutSlide) és a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#getMasterSlide) metódusokkal. Tárolja az eredeti mester‑referenciákat a témák alkalmazása előtt, mivel minden hívás egy új mestert hoz létre a prezentációban.

Az alábbi példa két szakasz diáit használja a mesterek megtalálásához, majd minden csoporthoz egy különböző külső témát alkalmaz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az első hívás csak az `first_group_master`‑hez tartozó diákra hat, a második hívás csak a `second_group_master`‑hez tartozó diákra. Más mesterekhez tartozó diákok nincsenek újraformázva.

### **Forrás téma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, miközben megőrzi az eredeti tervezést, klónozza a forrás mestert a célprezentációba a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslidecollection/#addClone) használatával, majd a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) és a klónozott mesterrel klónozza. Ez a mester, az elrendezései és a hozzá kapcsolódó téma együtt kerül át.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Ez a preferált munkafolyamat, ha a forrás dia megjelenésének változatlannak kell maradnia a célhelyen. Egy nem kapcsolódó cél‑mesterre történő egyszerű klónozás megváltoztathatja a téma‑alapú színeket, betűtípusokat, háttereket és effektusokat.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél dia a jelenlegi mesterén és elrendezésén marad, inicializáljon egy dia‑szintű felülbírálást a forrás téma alapján. Az [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) és [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) metódusok másolják a három fő téma‑komponenst a felülbírálásba.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Ez megváltoztatja a dia által használt témát anélkül, hogy a többi diára öröklött témát módosítaná. A helyi felülbírálás eltávolításához és az örökölt értékek visszaállításához hívja meg az [OverrideTheme.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/overridetheme/#clear) metódust.

### **Téma felülbírálás alkalmazása egy elrendezésre**

Egy elrendezés‑szintű felülbírálás a azt használó diákra vonatkozik, hacsak egy adott dia nem rendelkezik saját felülbírálással. Ugyanezeket az inicializációs metódusokat a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslidethememanager/) segítségével is használhatja:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Használjon mester‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alap‑tervre van szüksége, elrendezés‑felülbírálást, ha egy elrendezés‑családnak más stílusra van szüksége, és csak diára alkalmazott felülbírálást valódi kivételekhez. A túlzott dia‑szintű felülbírálások megnehezítik a későbbi globális téma‑módosítások megjósolását.

## **Téma háttérstílusainak frissítése**

A téma háttér‑kitöltései a [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) metódusban vannak tárolva. A PowerPoint az UI‑jában több háttér‑választási lehetőséget jeleníthet meg, mint ahány kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mert az UI a téma‑kitöltéseket kombinálhatja a téma‑színekkel és egyéb stílus‑referenciákkal.

![PowerPoint háttér‑stílus galéria egy prezentáció témához](presentation-design_8.png)

Mielőtt háttér‑stílust használna, vizsgálja meg a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/hu/python-java/aspose.slides/background/#getStyleIndex) értéket. A `0`‑as stílus‑index azt jelenti, hogy nincs témához tartozó kitöltés; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér a gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne tételezzük fel, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa jelzi a rendelkezésre álló háttér‑kitöltés számát, egy témához tartozó háttér‑referenciát rendeli az első mesterhez, és elmenti a prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A látható eredmény a mester által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülbírálásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a mester háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/background/#getEffective) metódust, ha a végső háttérre van szüksége az öröklődés alkalmazása után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílus‑indexet nulláral kezdődő gyűjtemény‑indexként. Kerülje a stílusszámok kemény kódolását egy fájlból, és annak feltételezését, hogy másik fájlban ugyanúgy néz ki; a téma‑stílusdefiníciók prezentációnként eltérnek.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
A közvetlen háttér‑formázáshoz és a háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/python-java/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusainak frissítése**

A téma formátumsémája különálló kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/python-java/aspose.slides/formatscheme/#getLineStyles) és [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/python-java/aspose.slides/formatscheme/#getEffectStyles) metódusok tesznek elérhetővé. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázást képviselik, de a kódnak sajátként kell vizsgálnia minden gyűjteményt, ahelyett, hogy egy rögzített számot feltételezne.

![Finom, közepes és intenzív téma‑effektusok ugyanazon alakzaton alkalmazva](presentation-design_10.png)

Amikor ezeket a gyűjteményeket Python‑on keresztül Java‑val éri el, a gyűjtemény‑index nulla‑alapú: a `get_Item(0)` az első tárolt stílus, a `get_Item(2)` a harmadik. Egy alakzat stílus‑referencia‑indexei egy külön koncepció, amelyet a [ShapeStyle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapestyle/) exponál. Egy téma‑stílus módosítása azokat az alakzatokat érinti, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, és elmenti az eredményt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Azokra az alakzatokra, amelyek ezekre a helyekre hivatkoznak, az első téma‑vonal‑stílus pirosra változik, a harmadik téma‑kitöltés‑stílus szilárd erdőzöld lesz, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílus‑helyet hivatkozzák az egyes alakzatok, és hogy a közvetlen formázás felülbírálja‑e a témát.

![Téma‑effektus‑stílusok a vonal‑, kitöltés‑ és árnyék‑beállítások módosítása után](presentation-design_11.png)

## **Megállapítás, hogy egy hatékony szilárd kitöltés téma színt használ-e**

Egy kitöltés lehet közvetlenül egy objektumon tárolva, vagy örökölhető egy bekezdésből, elrendezésből, mesterből, téma‑stílusból vagy egyéb formázási szintről. Hívja meg a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#getEffective) metódust, hogy ezt a hierarchiát változtathatatlan hatékony kitöltő‑adatokká alakítsa. Először ellenőrizze a `getFillType`‑ot a hatékony adatokon. Csak akkor olvassa ki a szilárd‑kitöltés tulajdonságait, ha az érték `FillType.Solid`.

Szilárd kitöltés esetén a `getSolidFillColor` visszaadja a végső renderelt RGB‑értéket az öröklődés, téma‑keresés és színátalakítások alkalmazása után. A `getSolidFillSchemeColor` visszaadja a megfelelő logikai [SchemeColor] helyet, például `Text1` vagy `Accent6`. A `SchemeColor.NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem sémaszín alapján lett meghatározva. Egy olyan munkafolyamatban, ahol a kitöltések vagy téma‑színek, vagy közvetlen RGB‑színek, ez az érték egy közvetlen RGB‑kitöltést jelöl.

Ne csak a helyi [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/colorformat/#getSchemeColor) értéket használja a kitöltés osztályozásához. Például egy szövegrésznek lehet, hogy nincs helyi sémaszíne, ezért a helyi érték `NotDefined`, míg a hatékony kitöltés örökölt téma‑színt kap, és `Text1` vagy `Accent6` lesz. Ezzel szemben a `getSolidFillSchemeColor` megmondja, mely logikai téma‑hely állította elő a hatékony színt, de nem jelzi, hogy ez a hely az objektumból, bekezdésből, elrendezésből, mesterből vagy egy másik formázási szintről származik.

Az alábbi példa betölti egy prezentációt, auditálja az alakzat‑kitöltéseket és a szövegrész‑kitöltéseket, kiírja minden végső RGB‑értéket és a hozzá tartozó sémaszínt, és megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín változásait:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

A `NotDefined` ágazat egy auditlistát biztosít a szilárd kitöltésekről, amelyek nem reagálnak a téma‑színhelyek változásaira. Tekintse át ezeket az objektumokat, amikor egy prezentációnak új márka‑palettát kell követnie. A jelentett RGB‑érték továbbra is a jelenlegi megjelenést mutatja, míg a sémával kapcsolatos érték elmagyarázza, hogy ez a megjelenés kapcsolódik‑e a témához.

A hatékony formátum‑objektumok pillanatfelvételek. A prezentáció témájának, egy téma‑felülbírálásnak vagy bármely örökölt formázásnak a módosítása után hívja meg újra a `getEffective`‑et, és olvassa ki az új hatékony kitöltő‑adatot, mielőtt összehasonlítaná vagy jelentést készítene a színekről.

## **Hatékony témaértékek olvasása**

A nyers téma‑objektumok azt mutatják, hogy egy adott szinten mi van definiálva. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülbírálások feloldása után. Egy dia esetén hívja meg a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) metódust. Egy háttérhez használja a [Background.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/background/#getEffective), egy kitöltéshez pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#getEffective) metódust.

Az alábbi példa beolvassa a hatékony témát, a háttért és az első alakzat kitöltését egy diához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

Használja a hatékony adatokat renderelési diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getMasterTheme)‑t vizsgálja, kihagyhat egy mestert, elrendezést, diát vagy alakzatot felülbíráló elemet, amely megváltoztatja a végső megjelenést.

## **FAQ**

**Az external téma alkalmazása hat minden diára a prezentációban?**

Nem. A [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) csak a kiválasztott mesterhez tartozó diákra rendeli újra a témát. Más mestereket használó diák megtartják meglévő témáikat.

**Alkalmazhatok témát egyetlen diára a mester módosítása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidethememanager/)‑ját, és inicializálja a felülbírálás‑témáját. A változás csak arra a diara lesz lokális; a többi dia a meglévő témáját örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének az egyik prezentációból a másikba?**

Ha egy diát áthelyezve meg akarja őrizni a forrás megjelenését, klónozza a forrás mestert a célnál a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslidecollection/#addClone) és a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) segítségével. Így a mester, az elrendezések és a téma együtt kerülnek át.

**Hogyan láthatom a hatékony értékeket az öröklődés és a felülbírálások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) metódust egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat metódusokat formátum‑objektumokhoz, mint a [Background.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/background/#getEffective) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#getEffective). Ezek az API‑k a öröklődés és a felülbírálások alkalmazása utáni feloldott értékeket adják vissza.