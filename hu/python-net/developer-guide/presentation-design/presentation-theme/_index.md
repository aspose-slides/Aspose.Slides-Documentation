---
title: PowerPoint bemutató témák kezelése Pythonban
linktitle: Bemutató téma
type: docs
weight: 10
url: /hu/python-net/presentation-theme/
keywords:
- PowerPoint téma
- bemutató téma
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
- bemutató
- Python
- Aspose.Slides
description: "Az Aspose.Slides for Python via .NET segítségével a bemutató témák mesterkezelése a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához, egységes márkázás mellett."
---
## **Bevezetés**

A bemutató téma koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet definiál. A téma‑tudatos objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékkel tárolnának, így egy téma‑csere egyszerre sok objektumot frissíthet.

Az Aspose.Slides esetében a bemutató‑szintű témát a [Presentation.master_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/master_theme/) tulajdonság biztosítja. A bemutató alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy mester felülírhatja a bemutató témáját a [MasterThemeManager.override_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/masterthememanager/override_theme/) segítségével, egy elrendezés felülírhatja a neki örökölt témát a [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) segítségével, és egy egyedi dia is megteheti ugyanezt. Gyakorlatban a dia hatékony témája ezen öröklődési lánc mentén kerül feloldásra: bemutató téma, mester felülírás, elrendezés felülírás, dia felülírás.

![Téma összetevők: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűk módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint a hatékony értékek olvasása az öröklődés és a felülírások feloldása után.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/) objektum a téma [color_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/font_scheme/) és [format_scheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/mastertheme/format_scheme/) tulajdonságait teszi elérhetővé. Ezeknek a gyűjteményeknek az ellenőrzése a módosításuk előtt különösen hasznos, ha a bemutató külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma‑tulajdonságokat, és jelentést készít arról, hogy hány háttér-, kitöltés-, vonal‑ és effektusstílus tárolódik a témában:

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

Ha egy fájl több mestert használ, ne feltételezzük, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizze a diával kapcsolatos mestert, és használja a később ebben a cikkben bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülírások vannak jelen.

## **Téma színeinek módosítása**

A téma‑tudatos kitöltések, vonalak és szöveg logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) felsorolásból. Ha a téma [ColorScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/colorscheme/) megfelelő bejegyzését módosítja, minden olyan objektum, amely még mindig arra a téma‑színre hivatkozik, az új értékkel lesz feloldva. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak meg a témaszín‑frissítés hatására.

Az alábbi vég‑vég példakódrészlet létrehoz egy alakzatot, amely az `ACCENT4`‑et használja, megváltoztatja a téma `accent4` színét pirosra, elmenti a bemutatót, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is az `ACCENT4`‑hez van kapcsolva, a látható színe pirosra változik a téma módosítása után. Ha a sémaszínt közvetlen színre cseréli az alakzaton, a későbbi `accent4` változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a témaszínből könnyebb és sötétebb változatokat színtranszformációk alkalmazásával származtat. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/colortransformoperation/) felsorolásán keresztül teszi elérhetővé.

![A fő téma színei és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – A fő téma színei.

**2** – A fő téma színeiből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre az `ACCENT4` alapján, ötön luminancia‑transzformációkat alkalmaz, majd elmenti az eredményt:

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

Ezek a változatok a téma‑színen alapulnak. Ha a `accent4` később változik, a transzformált színek az új `accent4` értékből kerülnek újraszámításra.

### **A `SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) felsorolás a `TEXT1`, `BACKGROUND1`, `TEXT2` és `BACKGROUND2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/colorscheme/) ugyanazokat a témahelyeket `dark1`, `light1`, `dark2` és `light2` néven teszi közzé. A leképezés rögzített:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan átalakított értékek.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy fő betűtípus‑készletet tartalmaz a címsorokhoz és egy kisebb betűtípus‑készletet a törzsszöveghez. A [FontScheme.major](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.minor](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/minor/) tulajdonságok teszik ezeket a készleteket elérhetővé.

PowerPoint‑kompatibilis téma‑betűtípus azonosítókat a szövegformázásban lehet használni:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa létrehoz egy címsort, amely a fő latin téma‑betűtípust használja, és egy törzssort, amely a kisebb latin téma‑betűtípust használja. Ezután módosítja a téma betűtípusait, és elmenti az eredményt:

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

A cím a fő betűtípust, a törzsszöveg a kisebb betűtípust követi. Azok a szövegek, amelyeknek explicit betűtárgya van a témaazonosító helyett, nem váltanak automatikusan, ha a téma betűtípus‑sémája megváltozik.

{{% alert color="info" title="Tip" %}}
További információk a bemutató betűtípusaival kapcsolatban: [PowerPoint Fonts](/slides/hu/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, és különböző problémákat oldanak meg.

### **Eredeti téma megőrzése diák áthelyezésekor**

Ha egy diát egy másik bemutatóba szeretne áthelyezni, miközben megőrzi az eredeti megjelenést, klónozza a forrás‑mestert a cél‑bemutatóba a [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/add_clone/) segítségével, majd klónozza a diát a [SlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_clone/) és a klónozott mesterrel. Így a mester, annak elrendezései és a kapcsolódó téma együtt kerülnek át.

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

Ez a preferált munkafolyamat, ha a forrás‑dia megjelenésének változatlanságát szeretné biztosítani a cél‑helyen. Csak a tartalom klónozása egy nem kapcsolódó cél‑mesterre megváltoztathatja a téma‑alapú színeket, betűtípusokat, háttereket és effektusokat.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél‑diának a jelenlegi mesterén és elrendezésén kell maradnia, inicializáljon dia‑szintű felülírást a forrás‑témából. A [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), a [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) és a [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) metódusok a három fő téma‑komponenst másolják a felülírásba.

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

Ez megváltoztatja a dia által használt témát anélkül, hogy a többi dia által örökölt témát módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja meg a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/overridetheme/clear/) metódust.

### **Témafelülírás alkalmazása elrendezésre**

Az elrendezés‑szintű felülírás az azon elrendezést használó diákra vonatkozik, kivéve ha egy adott diához saját felülírás van rendelve. Ugyanezeket az inicializáló metódusokat a layout [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/layoutslidethememanager/) segítségével lehet használni:

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

Használjon mester‑ vagy bemutató‑szintű témát, ha sok elrendezésnek és diáknak kell ugyanazt az alapszerkezetet megosztania; egy elrendezés‑felülírást akkor, ha egy elrendezés‑családnak másféle stílusra van szüksége; és csak diára vonatkozó felülírást a valódi kivételeknél. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttérstílusainak frissítése**

A téma háttér‑kitöltései a [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) gyűjteményben vannak tárolva. A PowerPoint a felhasználói felületén több háttér‑választékot mutathat, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mivel a felület a téma‑kitöltéseket témaszínnel és más stílushivatkozásokkal kombinálhatja.

![PowerPoint háttérstílus galéria egy bemutató‑témához](presentation-design_8.png)

Mielőtt egy háttérstílust használna, ellenőrizze a tárolt gyűjteményt és a jelenlegi [Background.style_index](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/style_index/) értéket. A `style_index` a `0` értékkel jelöli a témamentes kitöltést; a pozitív értékek téma‑háttérstílus‑hivatkozások. Ez eltér a Python gyűjtemények közvetlen indexelésétől, ahol a `[0]` az első tárolt elem. Ne feltételezze, hogy minden bemutató ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa jelzi a rendelkezésre álló háttér‑kitöltés számát, egy témaszerű háttér‑hivatkozást ad az első mesterhez, majd elmenti a bemutatót:

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

A látható eredmény a mester által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a mester háttér módosítása nem biztos, hogy megváltoztatja azt a diát. Használja a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/) metódust, ha a végleges, öröklődés után alkalmazott háttérre van szüksége.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a `style_index`‑et nulláral kezdődő gyűjtemény‑indexként. Kerülje a stílusszámok egy fájlból történő kemény kódolását, és annak feltételezését, hogy egy másik fájlban ugyanazt a megjelenést eredményezze; a téma‑stílusdefiníciók bemutató‑specifikusak.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttérformázásról és háttér‑öröklődésről lásd: [Presentation Background](/slides/hu/python-net/presentation-background/).
{{% /alert %}}

## **Téma effektusainak frissítése**

Egy téma formátumsémája különálló [FormatScheme.fill_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/line_styles/) és [FormatScheme.effect_styles](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/effect_styles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy rögzített számmal számolna.

![Finom, közepes és intenzív téma‑effektusok ugyanazon alakzaton alkalmazva](presentation-design_10.png)

Pythonban ezekhez a gyűjteményekhez való hozzáféréskor a gyűjteményindex nullával kezdődik: `[0]` az első tárolt stílus, `[2]` a harmadik. Egy alakzat stílushivatkozási indexei egy külön fogalom, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapestyle/) tesz elérhetővé. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek hivatkoznak arra a téma‑stílusra; a közvetlen formázású alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, megváltoztatja az első vonal‑stílust, a harmadik kitöltő‑stílust, engedélyezi egy külső árnyékot a harmadik effektus‑stílusban, majd elmenti az eredményt:

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

Az ezekre a helyekre hivatkozó alakzatok esetében az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltő‑stílus szilárd erdei zöldre, a harmadik effektus‑stílus pedig 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy mely stílushelyeket hivatkozza az egyes alakzat, és hogy a közvetlen formázás felülírja-e a témát.

![Téma‑effektus‑stílusok a vonal, kitöltés és árnyék beállításainak módosítása után](presentation-design_11.png)

## **Hatékony témaértékek olvasása**

A nyers témaobjektumok megmutatják, hogy mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Diára vonatkozóan hívja meg a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) metódust. Háttér esetén használja a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/)‑t, kitöltéshez pedig a [FillFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/get_effective/)‑t.

Az alábbi példa beolvassa a hatékony témát, a háttért és egy dia első alakzatának kitöltését:

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

Használja a hatékony adatokat renderelési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.master_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/master_theme/)‑et ellenőrizze, előfordulhat, hogy egy mester, elrendezés, dia vagy alakzat felülírását mellőzi, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok‑e témát egyetlen diára a mester módosítása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/slidethememanager/)‑jét, és inicializálja annak felülírt témáját. A változtatás csak arra a diára lesz lokális; a többi dia a meglévő témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy bemutatóról a másikra?**

Amikor egy diát áthelyez és meg akarja őrizni a forrás‑megjelenést, klónozza a forrás‑mestert a célnak megfelelően, majd a diát a [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/add_clone/) és a [SlideCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/add_clone/) segítségével klónozza. Így a mester, elrendezések és a téma együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használja a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)‑t egy dia vagy elrendezés témához, valamint a formátumobjektumok megfelelő hatékony‑adat‑metódusait, mint a [Background.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/background/get_effective/) és a [FillFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/get_effective/). Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és felülírások alkalmazása után.