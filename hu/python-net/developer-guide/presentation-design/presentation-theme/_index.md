---
title: PowerPoint prezentáció témák kezelése Pythonban
linktitle: Prezentáció téma
type: docs
weight: 10
url: /hu/python-net/presentation-theme/
keywords:
- PowerPoint téma
- prezentáció téma
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
- Aspose.Slides
description: "Kezelje a prezentáció témákat az Aspose.Slides for Python segítségével .NET-en keresztül, hogy egységes márkaelemekkel hozhasson létre, testre szabjon és konvertáljon PowerPoint fájlokat."
---
## **Bevezetés**

A bemutató téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet definiál. A témaérzékeny objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, ezért egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ben a bemutató‑szintű téma a [Presentation.master_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/master_theme/) tulajdonságon keresztül érhető el. A bemutató alacsonyabb szinteken is felülírható témákat tartalmazhat. Egy mester a [MasterThemeManager.override_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/masterthememanager/override_theme/) segítségével felülírhatja a bemutató témát, egy elrendezés a [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) segítségével felülírhatja az örökölt témát, és egy egyedi dia is megteheti ugyanezt. Gyakorlatban egy dia tényleges témája ezen öröklődési láncon keresztül kerül meghatározásra: bemutató téma, mester felülírás, elrendezés felülírás és dia felülírás.

![A téma összetevői: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma vizsgálata, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint a öröklődés és felülírások után kapott tényleges értékek olvasása.

## **Téma vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/) objektum a téma [color_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/font_scheme/) és [format_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/format_scheme/) tulajdonságait teszi elérhetővé. Ezeknek a gyűjteményeknek a vizsgálata a módosítás előtt különösen hasznos, ha a bemutató külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hány háttér‑, kitöltés‑, vonal‑ és effektus‑stílus van tárolva a témában:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Ha egy fájl több mestert használ, ne feltételezzük, hogy minden dia ugyanazzal a tényleges témával rendelkezik. Vizsgálja meg a diával kapcsolatos mestert, és használja a később ebben a cikkben bemutatott tényleges‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülírások lehetnek jelen.

## **Téma színeinek módosítása**

A témaérzékeny kitöltések, vonalak és szöveg egy logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) felsorolásból. Ha a téma [ColorScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/colorscheme/) megfelelő bejegyzését módosítja, minden objektum, amely még mindig arra a téma‑színre hivatkozik, az új értékkel lesz feloldva. A közvetlen RGB‑színt használó objektumok nem változnak meg egy téma‑szín frissítésekor.

Az alábbi vég‑á‑vég példája egy `ACCENT4` színt használó alakzatot hoz létre, a téma `accent4` színét pirosra állítja, elmenti a bemutatót, újra megnyitja, és kiírja a tényleges kitöltőszínt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Mivel a téglalap továbbra is a `ACCENT4`-hez van kapcsolva, a látható színe piros lesz a téma módosítása után. Ha a séma‑színt közvetlen színre cseréli az alakzaton, a későbbi `accent4` változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma­színből világosabb és sötétebb változatokat hoz létre színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/colortransformoperation/) felsoroláson keresztül teszi elérhetővé.

![A fő téma színei és a kiegészítő palettáról generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.  
**2** – A fő téma színekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat `ACCENT4` színű téglalapot hoz létre, ötön luminancia‑transzformációt alkalmaz, és elmenti az eredményt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Ezek a változatok a téma­színen maradnak alapul. Ha később megváltozik az `accent4`, a transzformált színek az új `accent4` értékből kerülnek újraszámításra.

### **A `SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) felsorolás a `TEXT1`, `BACKGROUND1`, `TEXT2` és `BACKGROUND2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/colorscheme/) ugyanazokat a témahelyeket `dark1`, `light1`, `dark2` és `light2` néven teszi közzé. A leképezés rögzített:

* `TEXT1` = `dark1`  
* `BACKGROUND1` = `light1`  
* `TEXT2` = `dark2`  
* `BACKGROUND2` = `light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan konvertált értékek.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy fő betűtípus‑készletet tartalmaz a címsorokhoz és egy mellék‑betűtípus‑készletet a törzsszöveghez. A [FontScheme.major](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.minor](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/minor/) tulajdonságok teszik ezeket elérhetővé.

PowerPoint‑kompatibilis téma betűtípus azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Body Font Latin (Minor Latin Font)  
* `+mj-lt` – Heading Font Latin (Major Latin Font)  
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)  
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő latin téma‑betűtípust használja, valamint egy törzssort, amely a mellék latin téma‑betűtípust használja. Ezután módosítja a téma betűtípusait és elmenti az eredményt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

A cím a fő betűtípust, a törzsszöveg a mellék betűtípust követi. Egy explicit betűtárgy‑névvel ellátott szöveg nem vált automatikusan, ha a téma‑betűtípus‑séma változik.

A fő és mellék betűtípus‑gyűjtemények tartalmazhatnak betűtípus‑leképezéseket egyes írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek a megtekintéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/python-net/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tipp" %}}
További információk a bemutató‑betűtípusokról a [PowerPoint Fonts](/slides/hu/python-net/powerpoint-fonts/) oldalon találhatók.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolt problémákat oldanak meg.

### **Külső téma alkalmazása egy mesterhez tartozó diákra**

Használja a [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) metódust, ha rendelkezik egy PowerPoint témafájllal (`.thmx`), és minden azon a mesteren alapuló diát újra szeretne stílusozni. Válassza ki a mestert a [Presentation.masters](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/masters/) gyűjteményből, amely a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/) implementációját használja, és adja át a témafájl útvonalát a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új mesterdiát a kiválasztott mester alapján.  
2. Alkalmazza a külső témát az új mesterre.  
3. Hozzárendeli az új mestert minden olyan diához, amely korábban a kiválasztott mesterre támaszkodott.  
4. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterslide/) objektumot.

Az alábbi példa külső témát alkalmaz az első mesterhez tartozó diákra, majd elmenti a bemutatót:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Érvénytelen, sérült vagy nem támogatott téma [PptxException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxexception/) vagy annak formátum‑specifikus alosztályát válthatja ki. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentse a bemutatót.

Csak azok a diák kerülnek átállításra, amelyek a kiválasztott mesterhez tartoznak. Más mesterekhez tartozó diák megőrzik meglévő mestereiket és témáikat. A témaérzékeny színek, betűtípusok, kitöltések, vonalak, háttér‑ és effektus‑elemek a külső témára lesznek feloldva. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑ és diaszintű felülírások szintén felülbírálhatják az új mesterből örökölt értékeket.

A téma hivatkozhat olyan betűtípusokra, amelyek nem állnak rendelkezésre a futtatókörnyezetben. A következetes megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket [egyéni betűtípus‑források](/slides/hu/python-net/custom-font/) útján, vagy konfigurálja a [betűtípus‑helyettesítést](/slides/hu/python-net/font-substitution/).

Ez egy közvetlen mester‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális diaszintű vagy elrendezés‑szintű téma‑felülírások létrehozását.

### **Különböző külső témák alkalmazása több‑mesteres bemutatóban**

Ha a releváns mester előre nem ismert, szerezze be azt egy reprezentatív diától a [Slide.layout_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/layout_slide/) és a [LayoutSlide.master_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/master_slide/) segítségével. Tárolja el az eredeti mester‑referenciákat, mielőtt bármilyen témát alkalmazna, mivel minden hívás egy új mestert hoz létre a bemutatóban.

Az alábbi példa két szakaszból származó diák segítségével megkeresi a mestereket, és mindkét csoporthoz külön külső témát alkalmaz:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

Az első hívás csak a `first_group_master`-hez tartozó diákra hat, a második csak a `second_group_master`-hez tartozó diákra. A másik mesterekhez tartozó diákok nem kapnak új stílust.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik bemutatóba szeretne áthelyezni, és meg kívánja őrizni az eredeti megjelenését, klónozza a forrásmestert a célbemutatóba a [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/add_clone/) segítségével, majd klónozza a diát a [SlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_clone/) és a klónozott mester használatával. Ezzel a mester, annak elrendezései és a kapcsolódó téma együtt kerülnek átvitelre.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Ez a preferált munkafolyamat, ha a forrásdia meg kell, hogy maradjon azonos a célhelyen. Egyszerűen csak a tartalmat klónozni egy nem kapcsolódó célmesterre megváltoztathatja a téma‑vezérelt színeket, betűtípusokat, háttér‑ és effektus‑elemeket.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél dia a jelenlegi mesterén és elrendezésén marad, inicializáljon egy diaszintű felülírást a forrástémából. A [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) és [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) metódusok másolják a három fő téma‑komponenst a felülírásba.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Ez megváltoztatja a dia által használt témát anélkül, hogy a többi diára öröklődő témát módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma felülírás alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülírás az azt használó diákra érvényes, kivéve ha egy adott diának saját felülírása van. Ugyanazokat a inicializáló metódusokat használhatja az elrendezés [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/layoutslidethememanager/) objektumán keresztül:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Használjon mester‑ vagy bemutató‑szintű témát, ha sok elrendezésnek és diáknak kell ugyanazt az alap‑design‑t megosztania, egy elrendezés‑felülírást, ha egy elrendezés‑családnak eltérő stílusra van szüksége, és csak diafelülírást a valódi kivételekhez. A túlzott diaszintű felülírások nehezebbé teszik a későbbi globális téma‑változások előrejelzését.

## **Téma háttérstílusainak frissítése**

A téma háttérkitöltései a [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) gyűjteményben vannak tárolva. A PowerPoint a felhasználói felületen több háttérválasztást jeleníthet meg, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mivel a felület kombinálhat téma‑kitöltéseket téma‑színekkel és egyéb stílus‑referenciákkal.

![PowerPoint háttérstílus galéria egy bemutató‑témához](presentation-design_8.png)

A háttérstílus használata előtt vizsgálja meg a tárolt gyűjteményt és az aktuális [Background.style_index](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/style_index/) értéket. A `style_index` a `0`‑t használja nincs téma‑kitöltés esetén; a pozitív értékek téma‑háttér‑stílus referenciák. Ez különbözik attól, amikor egy Python gyűjteményt közvetlenül indexelünk, ahol a `[0]` az első tárolt elemet jelenti. Ne feltételezze, hogy minden bemutató ugyanannyi háttérkitöltési stílussal rendelkezik.

Az alábbi példa kiírja a rendelkezésre álló háttérkitöltések számát, egy téma‑háttér‑referenciát rendel az első mesterhez, és elmenti a bemutatót:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

A látható eredmény a mester által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy diaszintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a csak a mester háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/) metódust, ha a végső háttérre van szüksége az öröklődés után.

{{% alert color="warning" title="Figyelmeztetés" %}}
Ne kezelje a `style_index`‑et nullaalapú gyűjtemény‑indexként. Kerülje a stílusszámok egy fájlból történő kemény kódolását, és annak feltételezését, hogy egy másik fájlban ugyanazt az megjelenést biztosítja; a téma‑stílusdefiníciók bemutató‑specifikusak.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Közvetlen háttér‑formázás és háttér‑öröklődés esetén lásd a [Presentation Background](/slides/hu/python-net/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusainak frissítése**

A téma formátumsémája különálló [FormatScheme.fill_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/line_styles/) és [FormatScheme.effect_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/effect_styles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell a rögzített szám feltételezése helyett.

![Finom, közepes és intenzív téma‑effektek ugyanazon alakzaton alkalmazva](presentation-design_10.png)

Python‑ban a gyűjtemény indexelése nullaalapú: a `[0]` az első tárolt stílus, a `[2]` a harmadik. Egy alakzat stílushivatkozási indexei egy külön fogalom, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapestyle/) exponál. Egy téma‑stílus módosítása olyan alakzatokat érint, amelyek erre a téma‑stílusra hivatkoznak; a közvetlen formázású alakzatok változatlanok lehetnek.

Az alábbi példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek-e, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, és elmenti az eredményt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Az ezen helyekre hivatkozó alakzatok esetén az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus szilaj erdei zöldre, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékra változik. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílushelyet hivatkozza minden alakzat, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok a vonal, kitöltés és árnyék beállítások módosítása után](presentation-design_11.png)

## **Annak meghatározása, hogy a tényleges szilárd kitöltés téma‑színt használ‑e**

Egy kitöltés tárolhatja magát közvetlenül egy objektumon, vagy örökölheti egy bekezdésből, elrendezésből, mestertől, téma‑stílusból vagy egy másik formázási szintről. Hívja a [FillFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/get_effective/) metódust, hogy ezt a hierarchiát átalakítsa egy immutábilis [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ifillformateffectivedata/) objektummá. Először ellenőrizze az [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ifillformateffectivedata/fill_type/) értékét. Csak akkor olvassa a szilárd‑kitöltés tulajdonságait, ha az `FillType.SOLID`.

Szilárd kitöltés esetén az [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) visszaadja az öröklődés, a téma‑keresés és a színtranszformációk alkalmazása után megjelenő végső RGB‑értéket. Az [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) visszaadja a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) slotot, például `TEXT1` vagy `ACCENT6`. A `SchemeColor.NOT_DEFINED` érték azt jelenti, hogy a tényleges szilárd kitöltés nem séma‑színen alapul. Egy olyan munkafolyamatban, ahol a kitöltések vagy téma‑színek vagy közvetlen RGB‑színek, ez az érték egy közvetlen RGB‑kitöltést azonosít.

Ne használja csak a helyi [IColorFormat.scheme_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/icolorformat/scheme_color/) értéket a kitöltés osztályozásához. Például egy szövegrésznek lehet nincs helyileg definiált séma‑színe, így a helyi értéke `NOT_DEFINED`, míg a tényleges kitöltés egy téma‑színt örököl, és `TEXT1` vagy `ACCENT6` értékre oldódik. Ezzel szemben a `solid_fill_scheme_color` megmutatja, mely logikai téma‑slot hozta létre a tényleges színt, de nem mondja meg, hogy ez a slot az objektumból, bekezdésből, elrendezésből, mesterből vagy a formázási hierarchia más szintjéről származik-e.

Az alábbi példa betölti a bemutatót, ellenőrzi mind az alakzat‑kitöltéseket, mind a szövegrész‑kitöltéseket, kiírja minden végső RGB‑értéket és a kapcsolódó séma‑színt, valamint megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín‑változásokat:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

A `NOT_DEFINED` ága egy auditlistát biztosít a szilárd kitöltésekről, amelyek nem reagálnak a téma‑szín‑slotok változására. Tekintse át ezeket az objektumokat, amikor egy bemutatónak új márkaszínpalettát kell követnie. A jelentett RGB‑érték még mindig a jelenlegi megjelenést mutatja, a séma‑érték pedig magyarázza, hogy ez a megjelenés kapcsolódik‑e a témához.

A hatékony‑formátum objektumok pillanatfelvételek. A bemutató téma, egy téma‑felülírás vagy bármely örökölt formázás módosítása után hívja újra a `get_effective`‑et, és olvassa ki az új `IFillFormatEffectiveData` objektumot, mielőtt összehasonlítaná vagy jelentéseket kérne a színekről.

## **Tényleges témaértékek olvasása**

A nyers témaobjektumok azt mutatják, mi van definiálva egy adott szinten. A tényleges értékek azt mutatják, mit használ egy dia vagy alakzat az öröklődés és a helyi felülírások feloldása után. Egy dia esetén hívja a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Háttérhez használja a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/), kitöltéshez pedig a [FillFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/get_effective/) metódust.

Az alábbi példa beolvassa a tényleges témát, a háttér‑stílust és az első alakzat‑kitöltést egy diáról:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Használja a tényleges adatokat megjelenítési diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation.master_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/master_theme/)‑t ellenőrzi, lemaradhat egy mester, elrendezés, dia vagy alakzat felülírásáról, amely megváltoztatja a végső megjelenést.

## **GYIK**

**A külső téma alkalmazása minden diára hat a bemutatóban?**  
Nem. A [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) csak azoknak a diáknak a mesterét változtatja, amelyek a kiválasztott mesterre támaszkodnak. Más mestereket használó diák megtartják meglévő témájukat.

**Alkalmazhatok témát egyetlen diára anélkül, hogy a mestert módosítanám?**  
Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/slidethememanager/) objektumát, és inicializálja annak felülírás‑témáját. A változtatás csak arra a diára van korlátozva; a többi dia továbbra is a meglévő témáikat örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy bemutatóból a másikba?**  
Ha egy diát mozgat és meg akarja őrizni az eredeti megjelenését, klónozza a forrásmestert a célhelyre, majd a [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/add_clone/) és a [SlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_clone/) segítségével klónozza a diát azzal a mesterrel. Ez a mester, elrendezései és a téma együtt marad.

**Hogyan tekinthetem meg a tényleges értékeket az öröklődés és a felülírások után?**  
Használja a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) metódust egy dia vagy elrendezés témához, valamint a megfelelő effektív‑adat metódusokat a formátumobjektumokhoz, mint a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/) és a [FillFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/get_effective/). Ezek az API‑k a származtatás és a felülírások alkalmazása után visszaadják a feloldott értékeket.