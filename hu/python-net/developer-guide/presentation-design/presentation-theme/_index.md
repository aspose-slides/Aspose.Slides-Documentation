---
title: PowerPoint prezentációs témák kezelése Pythonban
linktitle: Prezentáció témája
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
- téma betűtípusa
- téma stílusa
- téma effektus
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Mester prezentációs témák az Aspose.Slides for Python-ban .NET-en keresztül, a PowerPoint fájlok egységes márkajelzésű létrehozásához, testreszabásához és konvertálásához."
---
## **Bevezetés**

A prezentációs téma egy egységes szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektkészletet határoz meg. A témaérzékeny objektumok ezekre a megosztott definíciókra hivatkoznak az egyes vizuális tulajdonságok rögzített értéke helyett, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ben a prezentáció szintű témát a [Presentation.master_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/master_theme/) tulajdonságon keresztül érhetjük el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy master felülírhatja a prezentáció témáját a [MasterThemeManager.override_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/masterthememanager/override_theme/) segítségével, egy elrendezés felülírhatja a neki örökölt témát a [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) segítségével, és egy egyedi dia is megteheti ugyanezt. Gyakorlatban egy dia hatékony témája ezen öröklődési láncon keresztül kerül feloldásra: prezentációs téma, master felülírás, elrendezés felülírás és dia felülírás.

![Téma összetevők: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma vizsgálata, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effekt‑stílusok frissítése, valamint az öröklődés és felülírások után kapott hatékony értékek kiolvasása.

## **Téma vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/) objektum elérhetővé teszi a téma [color_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/font_scheme/) és [format_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/format_scheme/) tulajdonságait. Ezeknek a gyűjteményeknek a vizsgálata különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hány háttér, kitöltés, vonal és effekt stílus van tárolva a témában:

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

Ha egy fájl több master‑t használ, ne tételezzük fel, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Vizsgálja meg a diával társított master‑t, és használja a később bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülírások lehetnek jelen.

## **Téma színeinek módosítása**

A témaérzékeny kitöltések, vonalak és szöveg egy logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) enumerációból. Amikor módosítja a megfelelő bejegyzést a téma [ColorScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/colorscheme/) gyűjteményében, minden, az adott téma‑színre mutató objektum az új értékre lesz feloldva. Azok az objektumok, amelyek közvetlen RGB‑színnel vannak definiálva, nem változnak a téma‑szín frissítésekor.

Az alábbi végponttól végpontig tartó példa egy alakzatot hoz létre, amely az `ACCENT4`‑et használja, a téma `accent4` színét pirosra állítja, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is az `ACCENT4`‑re hivatkozik, a színe piros lesz a téma módosítása után. Ha a sémaszínt közvetlen színre cseréli az alakzaton, a későbbi `accent4` módosítások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettából**

A PowerPoint a téma színéből világosabb és sötétebb változatokat színtranszformációk alkalmazásával származtat. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/colortransformoperation/) enumeráción keresztül teszi elérhetővé.

![Fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.

**2** – A fő téma színekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre az `ACCENT4`‑ből, ötön lumineszcencia‑transzformációt alkalmaz, és elmenti az eredményt:

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

Ezek a változatok továbbra is a téma színén alapulnak. Ha később megváltozik az `accent4`, a transzformált színek az új `accent4` értékéből kerülnek újraszámításra.

### **`SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) enumeráció a `TEXT1`, `BACKGROUND1`, `TEXT2` és `BACKGROUND2` bejegyzéseket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/colorscheme/) a témapontokat `dark1`, `light1`, `dark2` és `light2` néven jeleníti meg. A leképezés fix:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Ezek ugyanazokra a témahelyekre mutató alternatív nevek; nem dinamikusan átalakított értékek.

## **Téma betűtípusaival kapcsolatos módosítások**

A téma betűtípus‑sémája egy fő (major) betűkészletet tartalmaz a címsorokhoz, valamint egy mellék (minor) betűkészletet a törzsszöveghez. A [FontScheme.major](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.minor](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/minor/) tulajdonságok teszik ezeket elérhetővé.

A PowerPoint‑kompatibilis téma betűtípus‑azonosítók a szövegformázás során használhatók:

* `+mn-lt` – Törzsszöveg Latin (Minor Latin Font)
* `+mj-lt` – Címsor Latin (Major Latin Font)
* `+mn-ea` – Törzsszöveg Kelet‑Ázsiai (Minor East Asian Font)
* `+mj-ea` – Címsor Kelet‑Ázsiai (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő Latin téma‑betűtípust használja, valamint egy törzssor­t, amely a mellék Latin téma‑betűtípust használja. Ezután módosítja a téma betűtípusait és menti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a mellék betűtípust követi. Azok a szövegek, amelyek explicit betűtárgy nevet tartalmaznak a témaazonosító helyett, nem váltanak automatikusan, ha a téma betűtípus‑sémája megváltozik.

A fő és mellék betűkészletek tartalmazhatnak egyéni írásrendszer‑leképezéseket is, például cirill, arab, japán, grúz és thaana. Ezek vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/python-net/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentációs betűtípusokról: [PowerPoint Fonts](/slides/hu/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolódó problémákat oldanak meg.

### **Külső téma alkalmazása egy masterhez tartozó diákra**

Használja a [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) metódust, ha egy PowerPoint‑témafájl (.thmx) áll rendelkezésére, és minden, egy adott masterhez tartozó diát újra szeretne stílusozni. Válassza ki a master‑t a [Presentation.masters](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/masters/) gyűjteményből, amely a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/) implementációja, majd adja át a témafájl útvonalát a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új master‑diát a kiválasztott master alapján.
1. Alkalmazza a külső témát az új masterre.
1. Az új master‑t hozzárendeli minden diához, amely korábban az eredeti masterhez kapcsolódott.
1. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterslide/) objektumot.

Az alábbi példa egy külső témát alkalmaz az első masterhez tartozó diákra, majd elmenti a prezentációt:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Érvénytelen, sérült vagy nem támogatott téma [PptxException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxexception/) vagy annak formátum‑specifikus leszármazottját okozhatja. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentse a prezentációt.

Csak azok a diák kerülnek újra hozzárendelésre, amelyek a kiválasztott masterhez tartoztak. Más master‑hez kapcsolódó diák megtartják meglévő master‑eiket és témáikat. A témaérzékeny színek, betűtípusok, kitöltések, vonalak, háttér‑ és effekt‑stílusok az új külső téma alapján kerülnek feloldásra. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑ és dia‑szintű felülírások szintén felülbírálhatják az új master‑től örökölt értékeket.

A téma hivatkozhat olyan betűtípusokra, amelyek nincsenek telepítve a futtatási környezetben. A következetes megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket a [custom font sources](/slides/hu/python-net/custom-font/) segítségével, vagy konfigurálja a [font substitution](/slides/hu/python-net/font-substitution/) opciót.

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy .thmx fájl útvonalát fogadja, és nem igényel kézi slide‑ vagy layout‑szintű téma‑felülírások létrehozását.

### **Különböző külső témák alkalmazása több‑masteres prezentációban**

Ha a megfelelő master előre nem ismert, szerezze be azt egy reprezentatív diáról a [Slide.layout_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/layout_slide/) és a [LayoutSlide.master_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/master_slide/) segítségével. A témák alkalmazása előtt mentse el az eredeti master hivatkozásokat, mert minden hívás egy új master‑t hoz létre a prezentációban.

Az alábbi példa két szakaszból származó diák master‑jeit keresi meg, majd mindegyik csoportra külön külső témát alkalmaz:

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

Az első hívás csak az `first_group_master`‑hez tartozó diákra hat, a második hívás csak a `second_group_master`‑hez tartozó diákra. Más master‑hez tartozó diákok nincsenek újraformázva.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni az eredeti megjelenését, klónozza a forrás‑master‑t a cél‑presentációba a [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/add_clone/) segítségével, majd a diát a [SlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_clone/) és a klónozott masterrel együtt klónozza. Így a master, az elrendezései és a hozzá tartozó téma is átvitelre kerül.

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

Ez a leginkább ajánlott megoldás, ha a forrás‑dia megjelenését a cél‑presentációban is ugyanúgy kell megőrizni. Ha csak a tartalmat klónozza egy nem kapcsolódó cél‑masterre, a téma‑alapú színek, betűtípusok, háttér‑ és effekt‑stílusok megváltozhatnak.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél‑dia a jelenlegi master‑én és elrendezésén marad, inicializáljon egy dia‑szintű felülírást a forrás‑téma alapján. A [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), a [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) és a [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) metódusok a három fő téma‑komponenst másolják a felülírásba.

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

Ez a dia által használt témát módosítja anélkül, hogy a többi dia által örökölt témát érintené. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja meg a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma‑felülírás alkalmazása elrendezésre**

Az elrendezés‑szintű felülírás azon diákra vonatkozik, amelyek az adott elrendezést használják, hacsak egy adott dia saját felülírást nem tartalmaz. Ugyanazokat a inicializáló metódusokat a layout‑hoz tartozó [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/layoutslidethememanager/) segítségével is használhatja:

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

Használjon master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alap‑designra van szüksége; elrendezés‑felülírást alkalmazzon, ha egy elrendezés‑család más stílust igényel; és dia‑felülírást csak valós kivételek esetén. A túlzott dia‑szintű felülírások nehezítik a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttér‑kitöltései a [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) gyűjteményben vannak tárolva. A PowerPoint a felhasználói felületen gyakrabban kínál háttérválasztási lehetőségeket, mint amennyi kitöltés‑definíció fizikailag tárolva van a gyűjteményben, mert a UI kombinálhatja a téma‑kitöltéseket téma‑színekkel és más stílus‑hivatkozásokkal.

![PowerPoint háttérstílus‑galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttérstílust használna, vizsgálja meg a tárolt gyűjteményt és a jelenlegi [Background.style_index](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/style_index/) értéket. A `style_index` a `0`‑t jelöli, ha nincs téma‑kitöltés; a pozitív értékek téma‑háttér‑stílus‑hivatkozások. Ez eltér a Python gyűjtemény közvetlen indexelésétől, ahol a `[0]` az első elem. Ne tételezzük fel, hogy minden prezentáció ugyanannyi háttér‑kitöltési stílussal rendelkezik.

Az alábbi példa kiírja a rendelkezésre álló háttér‑kitöltési számot, egy téma‑háttér‑hivatkozást rendel az első master‑hez, és elmenti a prezentációt:

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

A látható eredmény a master‑által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a master háttér módosítása egyedül nem feltétlenül változtatja meg azt a diát. Használja a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/) metódust, ha a végleges, öröklődött háttérértékre van szüksége.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a `style_index`‑et nullától induló gyűjtemény‑indexként. Kerülje a stílusszám kódba építését egy fájlból, és annak automatikus átvitelét egy másik fájlba, mivel a téma‑stílusdefiníciók prezentációnként eltérnek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttér‑formázásért és háttér‑öröklődésért lásd a [Presentation Background](/slides/hu/python-net/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátumsémája külön [FormatScheme.fill_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/line_styles/) és [FormatScheme.effect_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/effect_styles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázást jelölik, de a kódnak minden gyűjteményt vizsgálnia kell, a fix szám feltételezése nélkül.

![Finom, közepes és intenzív témaeffektek alkalmazva ugyanazon alakzatra](presentation-design_10.png)

Pythonban ezekhez a gyűjteményekhez a indexelés nullától indul: a `[0]` az első tárolt stílus, a `[2]` a harmadik. Egy alakzat stílushivatkozási indexei egy külön koncepciót jelentenek, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapestyle/) szolgáltat. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effekt‑stílusban, és elmenti az eredményt:

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

Az olyan alakzatok számára, amelyek ezeket a slot‑okat referálják, az első téma‑vonal‑stílus pirosra változik, a harmadik téma‑kitöltés‑stílus szilárd erdőzöldre, a harmadik effekt‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik slot‑ra hivatkozik az adott alakzat, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok módosítás után: vonal, kitöltés és árnyék beállításai](presentation-design_11.png)

## **Hatékony témaértékek kiolvasása**

A nyers témaobjektumok csak azt mutatják, ami egy adott szinten definiálva van. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Diára a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) hívható. Háttérre a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/), kitöltésre pedig a [FillFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/get_effective/) használható.

Az alábbi példa kiolvassa egy dia hatékony témáját, háttérét és az első alakzat kitöltését:

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

Használja a hatékony adatokat a renderelési diagnosztikához, ellenőrzéshez és összehasonlításhoz. Ha csak a [Presentation.master_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/master_theme/) objektumot vizsgálja, könnyen kihagyhat egy master‑, layout‑, dia‑ vagy alakzat‑felülírást, amely a végső megjelenést módosítja.

## **GYIK**

**Az externális téma alkalmazása minden diára vonatkozik a prezentációban?**

Nem. A [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) csak azoknak a diáknak a master‑ét változtatja meg, amelyek az adott masterhez tartoztak. A más master‑eket használó diák megtartják a meglévő témájukat.

**Alkalmazhatok-e témát egyetlen dia‑ra a master megváltoztatása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/slidethememanager/) objektumát, és inicializálja a felülírási témát. A módosítás csak arra a diára vonatkozik; a többi dia a korábbi témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Amikor egy diát áthelyez és meg akarja őrizni az eredeti megjelenését, klónozza a forrás‑master‑t a cél‑presentációba a [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/add_clone/) segítségével, majd a diát a [SlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_clone/) és a klónozott masterrel együtt. Így a master, az elrendezések és a téma együttesen kerülnek átvitelre.

**Hogyan tekinthetők meg a hatékony értékek az öröklődés és felülírások után?**

Használja a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) metódust dia‑ vagy layout‑téma esetén, valamint a megfelelő hatékony‑adat metódusokat a formátumobjektumoknál, mint a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/) és a [FillFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/get_effective/). Ezek az API‑k a öröklődés és felülírások alkalmazása után feloldott értékeket adják vissza.