---
title: PowerPoint prezentáció témák kezelése Pythonban
linktitle: Prezentációs téma
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
description: "Az Aspose.Slides for Python .NET-en keresztül a prezentáció fő témáit kezeli, lehetővé téve PowerPoint fájlok létrehozását, testreszabását és konvertálását egységes arculattal."
---
## **Bevezetés**

A prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témára érzékeny objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ben a prezentáció szintű téma a [Presentation.master_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/master_theme/) tulajdonságon keresztül érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy master felülírhatja a prezentáció témáját a [MasterThemeManager.override_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/masterthememanager/override_theme/) segítségével, egy elrendezés felülírhatja a saját örökölt témáját a [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) segítségével, és egy egyedi dia is megteheti ugyanezt. Gyakorlatban egy dia hatékony témáját ez az öröklődési lánc oldja fel: prezentáció téma, master felülírás, elrendezés felülírás, és dia felülírás.

![A téma összetevői: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektustílusok frissítése, valamint a hatékony értékek olvasása az öröklődés és felülírások feloldása után.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/) objektum a téma [color_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/font_scheme/) és [format_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/format_scheme/) tulajdonságait teszi elérhetővé. Ezeknek a gyűjteményeknek az ellenőrzése a módosításuk előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stíluselemek száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hány háttér, kitöltés, vonal és effektus stílus van tárolva a témában:

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

Ha egy fájl több master‑t használ, ne feltételezze, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizze a diához tartozó master‑t, és használja a később ebben a cikkben bemutatott hatékony‑téma munkafolyamatot, amikor elrendezés‑ vagy dia‑felülírások lehetnek jelen.

## **Téma színeinek módosítása**

A témára érzékeny kitöltések, vonalak és szövegek a [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) felsorolás logikai színére hivatkozhatnak. Ha a téma [ColorScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/colorscheme/) megfelelő bejegyzését módosítja, minden olyan objektum, amely még mindig arra a téma‑színre hivatkozik, az új érték felé kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak a téma‑szín frissítésekor.

Az alábbi végponttól‑végpontig tartó példa létrehoz egy alakzatot, amely az `ACCENT4`‑et használja, megváltoztatja a téma `accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is az `ACCENT4`‑hez van kapcsolva, látható színe pirosra változik a téma módosítása után. Ha a séma‑színt közvetlen színre cseréli az alakzaton, a későbbi `accent4` változások már nem befolyásolják azt a kitöltést.

### **A kiegészítő palettáról származó színek használata**

A PowerPoint a téma‑színből világosabb és sötétebb variánsokat színtranszformációk alkalmazásával származtat. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/colortransformoperation/) felsorolásán keresztül teszi elérhetővé.

![A fő téma színei és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – A fő téma színei.

**2** – A fő téma színeiből előállított világosabb és sötétebb változatok.

Az alábbi példában hat téglalapot hozunk létre `ACCENT4` alapján, ötötön luminancia‑transzformációt alkalmazunk, és elmentjük az eredményt:

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

Ezek a variánsok továbbra is a téma‑színen alapulnak. Ha később megváltozik az `accent4`, a transzformált színek újra lesznek számítva az új `accent4` értékből.

### **A `SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) felsorolás a `TEXT1`, `BACKGROUND1`, `TEXT2` és `BACKGROUND2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/colorscheme/) ugyanazokat a téma‑helyeket `dark1`, `light1`, `dark2` és `light2` néven teszi közzé. A leképezés fix:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan konvertált értékek.

## **Téma betűtípusainak módosítása**

Egy téma‑betűtípus‑séma egy fő betűkészletet tartalmaz a címsorokhoz és egy kisebb betűkészletet a törzsszöveghez. A [FontScheme.major](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.minor](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/minor/) tulajdonságok ezeket a készleteket exponálják.

PowerPoint‑kompatibilis téma‑betűtípus azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő Latin téma‑betűtípust használja, és egy törzssort, amely a kisebb Latin téma‑betűtípust használja. Ezután módosítja a téma betűtípusait és elmenti az eredményt:

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

A címsor a fő betűtípust követi, a törzsszöveg a kisebb betűtípust. Azok a szövegek, amelyekben kifejezett betűtípus‑név van a témaazonosító helyett, nem váltanak automatikusan, ha a téma betűtípus‑sémája megváltozik.

A fő és kisebb betűkészletek tartalmazhatnak betűtár‑leképezéseket az egyes írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek az ellenőrzéséhez, hozzáadásához, helyettesítéséhez vagy eltávolításához lásd a [Script-Specific Theme Fonts](/slides/hu/python-net/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentációs betűtípusokról a [PowerPoint Fonts](/slides/hu/python-net/powerpoint-fonts/) oldalon találhatók.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, és különböző problémákat oldanak meg.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba akar átvinni, és meg szeretné őrizni az eredeti megjelenését, klónozza a forrás‑master‑t a célprezentációba a [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/add_clone/) segítségével, majd klónozza a diát a [SlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_clone/) és a klónozott master segítségével. Így a master, az elrendezései és a kapcsolódó téma együtt kerülnek át.

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

Ez a preferált munkafolyamat, amikor a forrás‑diának ugyanúgy kell kinéznie a célhelyen. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑master‑re megváltoztathatja a téma‑alapú színeket, betűtípusokat, háttereket és effektusokat.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél‑dia a jelenlegi master‑en és elrendezésen kell maradjon, inicializáljon egy dia‑szintű felülírást a forrástémából. A [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) és [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) metódusok a három fő téma‑komponenst másolják bele a felülírásba.

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

Ez megváltoztatja a diára alkalmazott témát anélkül, hogy a többi dia örökölt témáját módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja meg az [OverrideTheme.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma felülírás alkalmazása egy elrendezésre**

Egy elrendezés‑szintű felülírás az arra épülő diákra vonatkozik, kivéve, ha egy adott diához saját felülírás tartozik. Ugyanezeket az inicializálási metódusokat a layout `[LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/layoutslidethememanager/)` segítségével lehet használni:

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

Használjon master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alap‑dizájnra van szüksége, elrendezés‑felülírást, ha egy elrendezés‑családnak más stílusra van szüksége, és dia‑felülírást csak valódi kivételek esetén. A túl sok dia‑szintű felülírás megnehezíti a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttér‑kitöltései a [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) gyűjteményben tárolódnak. A PowerPoint a felhasználói felületen több háttérválasztási lehetőséget jeleníthet meg, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mert a felület kombinálhat téma‑kitöltéseket téma‑színekkel és egyéb stílus‑hivatkozásokkal.

![PowerPoint háttérstílus‑galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttérstílust használná, ellenőrizze a tárolt gyűjteményt és az aktuális [Background.style_index](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/style_index/) értéket. A `style_index` a `0`‑t használja „nincs téma‑kitöltés” esetén; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér a Python gyűjtemények közvetlen indexelésétől, ahol a `[0]` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa jelenti a rendelkezésre álló háttér‑kitöltések számát, egy téma‑háttér‑referenciát rendeli az első masterhez, és elmenti a prezentációt:

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

A látható eredmény a master által hivatkozott téma‑bejegyzéstől és az esetleges elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a master háttér módosítása nem biztos, hogy megváltoztatja azt a diát. Használja a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/) metódust, ha a végső, öröklődött háttérre van szüksége.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a `style_index`‑et nullától induló gyűjtemény‑indexként. Kerülje a stílusszám hard‑kódolását egy fájlból, és annak feltételezését, hogy egy másik fájlban ugyanúgy fog kinézni; a téma‑stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttér‑formázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/python-net/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

Egy téma‑formátumséma különálló [FormatScheme.fill_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/line_styles/) és [FormatScheme.effect_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/effect_styles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stíluselemet tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell ahelyett, hogy rögzített számra támaszkodna.

![Finom, közepes és intenzív téma‑effektusok ugyanarra az alakzatra alkalmazva](presentation-design_10.png)

Python‑ban ezekhez a gyűjteményekhez való hozzáféréskor a gyűjtemény‑index nullától indul: a `[0]` az első tárolt stílus, a `[2]` a harmadik. Egy alakzat stílus‑referencia‑indexe egy külön koncepció, amely a [IShapeStyle](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapestyle/) által van kiexponálva. Egy téma‑stílus módosítása azoknak az alakzatoknak a megjelenését változtatja meg, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázású alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stíluselemek léteznek, módosítja az első vonal‑stílust, a harmadik kitöltő‑stílust, engedélyezi egy külső árnyékot a harmadik effektus‑stílusban, és elmenti az eredményt:

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

Azokra az alakzatokra, amelyek ezeket a helyeket használják, az első téma‑vonal‑stílus pirosra változik, a harmadik téma‑kitöltő‑stílus szilárd erdei zöldre, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílus‑helyet referálja az egyes alakzat, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok a vonal, kitöltés és árnyék beállítások módosítása után](presentation-design_11.png)

## **Hatékony témaértékek olvasása**

A nyers témaobjektumok megmutatják, mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, mit használ valójában egy dia vagy alakzat az öröklődés és a helyi felülírások feloldása után. Egy diához hívja meg a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) metódust. Háttérhez használja a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/)‑t, kitöltéshez pedig a [FillFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/get_effective/)‑t.

Az alábbi példa beolvassa a hatékony témát, a háttért és az első alakzat kitöltését egy diáról:

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

Használja a hatékony adatokat renderelési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.master_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/master_theme/)‑t ellenőrzi, előfordulhat, hogy egy master, elrendezés, dia vagy alakzat felülírását figyelmen kívül hagyja, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok témát egyetlen diára anélkül, hogy a master‑t módosítanám?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/slidethememanager/)‑t, és inicializálja annak felülírási témáját. A változtatás csak arra a diára korlátozódik; a többi dia a meglévő témáját örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének az egyik prezentációból a másikba?**

Amikor egy diát áthelyez és meg akarja őrizni a forrás‑megjelenést, klónozza a forrás‑master‑t a célba, majd a diát a klónozott masterrel a [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/add_clone/) és a [SlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_clone/) segítségével. Így a master, az elrendezések és a téma együtt maradnak.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használja a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)‑t egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat‑metódusokat formátumobjektumokhoz, például a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/) és a [FillFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/get_effective/) esetén. Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és felülírások alkalmazása után.