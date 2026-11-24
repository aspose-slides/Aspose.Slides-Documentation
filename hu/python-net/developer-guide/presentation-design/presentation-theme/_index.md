---
title: PowerPoint prezentációs témák kezelése Pythonban
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/python-net/presentation-theme/
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
- Aspose.Slides
description: "Mester prezentációs témák az Aspose.Slides for Python .NET-en keresztül, PowerPoint fájlok létrehozásához, testreszabásához és átalakításához konzisztens márkázással."
---
## **Bevezetés**

Egy prezentációs sablon koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A sablonra érzékeny objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy sablonváltoztatás egyszerre több objektumot is frissíthet.

Az Aspose.Slides-ban a prezentáció szintű sablon a [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) tulajdonságnál érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat sablon felülírásokat. Egy master felülírhatja a prezentáció sablonját a [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/) segítségével, egy elrendezés felülírhatja az örökölt sablont a [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) segítségével, és egy egyedi dia is ugyanígy tehet. Gyakorlatban a dia hatékony sablonja ezen öröklődési lánc mentén kerül feloldásra: prezentációs sablon, master felülírás, elrendezés felülírás és dia felülírás.

![A sablon összetevői: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb sablon-munkafolyamatokat mutatják be: sablon ellenőrzése, színek és betűtípusok módosítása, sablon másolása vagy alkalmazása, háttér- és effektusstílusok frissítése, valamint az öröklődés és felülírások feloldása után a hatékony értékek olvasása.

## **Sablon ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) objektum a sablon [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) és [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) tulajdonságait teszi elérhetővé. Ezeknek a gyűjteményeknek az ellenőrzése a módosítás előtt különösen hasznos, amikor a prezentáció külső forrásból származik, mivel a stíluselemek száma és tartalma változhat.

Az alábbi példa beolvassa a fő sablon tulajdonságait, és beszámol arról, hány háttér-, kitöltés-, vonal- és effektusstílus van a sablonban tárolva:

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

Ha egy fájl több masterrel dolgozik, ne feltételezze, hogy minden dia ugyanazzal a hatékony sablonnal rendelkezik. Ellenőrizze a diával társított mastert, és használja a később ebben a cikkben bemutatott hatékony-sablon munkafolyamatot, ha elrendezés- vagy diafelülírások lehetnek jelen.

## **Sablon színeinek módosítása**

A sablonra érzékeny kitöltések, vonalak és szöveg logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) felsorolásból. Ha módosítja a megfelelő bejegyzést a sablon [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) gyűjteményében, minden, még a sablon színére hivatkozó objektum az új értékre kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB-színt használnak, nem változnak meg a sablonszín frissítésekor.

Az alábbi teljes körű példa egy `ACCENT4` színű alakzatot hoz létre, megváltoztatja a sablon `accent4` színét vörösre, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is az `ACCENT4` színhez van kapcsolva, a látható szín vörösre változik a sablon módosítása után. Ha a sémaszínt közvetlen színre cseréli az alakzaton, a későbbi `accent4` változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint világosabb és sötétebb változatokat hoz létre egy sablonszínből színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/) felsorolásban teszi elérhetővé.

![A fő sablon színei és a kiegészítő palettáról generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – A fő sablon színei.

**2** – A fő sablon színeiből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre `ACCENT4` alapján, ötön luminancia-transzformációkat alkalmaz, és elmenti az eredményt:

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

Ezek a változatok továbbra is a sablonszínen alapulnak. Ha később megváltozik az `accent4`, a transzformált színek újraszámításra kerülnek az új `accent4` értékből.

### **A `SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) felsorolás a `TEXT1`, `BACKGROUND1`, `TEXT2` és `BACKGROUND2` elemeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) ugyanezeket a sablonhelyeket `dark1`, `light1`, `dark2` és `light2` néven teszi elérhetővé. A leképezés rögzített:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Ezek ugyanazoknak a sablonhelyeknek a különböző nevei; nem dinamikusan konvertált értékek.

## **Sablon betűtípusaiban való módosítás**

A sablon betűtípus-sémája egy fő betűtípus-készletet tartalmaz a címsorokhoz és egy kisebb betűtípus-készletet a törzsszöveghez. A [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) tulajdonságok ezeket a készleteket teszik elérhetővé.

PowerPoint‑kompatibilis sablon betűtípus-azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)
* `+mn-cs` – Body Font Complex Script (Minor Complex Script Font)
* `+mj-cs` – Heading Font Complex Script (Major Complex Script Font)

Az alábbi példa egy címsort hoz létre, amely a fő Latin sablon betűtípust használ, és egy törzssort, amely a kisebb Latin sablon betűtípust használja. Ezután módosítja a sablon betűtípusait és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg pedig a kisebb betűtípust követi. Azok a szövegek, amelyek explicit betűtárgy nevet tartalmaznak a sablonazonosító helyett, nem váltanak automatikusan, ha a sablon betűtípus-sémája megváltozik.

A fő és a kisebb betűtípus-gyűjtemények tartalmazhatnak betűtípus-leképezéseket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezek ellenőrzéséhez, hozzáadásához, cseréjéhez vagy eltávolításához tekintse meg a [Script‑Specific Theme Fonts](/slides/hu/python-net/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentációs betűtípusokról a [PowerPoint betűtípusok](/slides/hu/python-net/powerpoint-fonts/) oldalon.
{{% /alert %}}

### **Sablon betűtípus hivatkozások feloldása**

Szöveg ellenőrzésekor a [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) tartalmazhat sablonhivatkozást, például `+mn-lt`, ahelyett, hogy betűcsaládnevet tartalmazna. Hívja meg a [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) metódust a megfelelő [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) objektummal a hivatkozás feloldásához. A `+mj` és `+mn` előtagok a fő és a kisebb betűtípus-készleteket választják; a `-lt`, `-ea` és `-cs` utótagok a Latin, East Asian és Complex Script betűtípusokat jelölik.

A hatékony sablont a [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) metódussal szerezheti meg azon objektumon, amelyiknek a sablonja a vizsgált szövegre vonatkozik. Általános diaszöveghez használja a `slide.create_theme_effective` metódust, így a kontextus tartalmazza a dia örökölt sablonját és a helyi felülírásokat. Elrendezés vagy master ellenőrzésekor használja annak saját hatékony sablonját. Ne feltételezze, hogy az első master sablonja minden diára vonatkozik.

Az alábbi példa egy szövegrészt hoz létre, amely explicit módon a kisebb Latin betűtípust hivatkozza. Egy diabetűtípus-sémát inicializál a [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) metódussal, és a fő és kisebb Latin családokat `Arial`‑ra és `Calibri`‑ra állítja, így az eredmény reprodukálható bemeneti fájl nélkül.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

A kimenet `+mn-lt -> Calibri`, majd `Verdana -> Verdana`. A tárolt hivatkozás változatlan marad, míg az explicit családnév változatlanul visszatér. Ha a rész `+mj-lt`‑t használna, ebben a sablonban `Arial`‑ra oldódna fel.

A sablonhivatkozás feloldása meghatározza a sablon által megadott betűcsaládot. Nem ellenőrzi a betűtípus elérhetőségét vagy a renderelés során végrehajtott betűcserét vagy glif helyettesítést. Erről olvashat a [Font Selection Sequence](/slides/hu/python-net/font-selection-sequence/) és a [Font Substitution](/slides/hu/python-net/font-substitution/) oldalakon.

## **Sablon másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző sablon‑kapcsolt problémákat oldanak meg.

### **Külső sablon alkalmazása egy mesterhez tartozó diákra**

Használja a [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) metódust, ha van egy PowerPoint sablonfájlja (`.thmx`), és minden, egy adott masterhez tartozó diát újra szeretne stilizálni. Válassza ki a mastert a [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) gyűjteményből ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)), és adja át a sablonfájl elérési útját a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új masterdiát a kiválasztott master alapján.
2. Alkalmazza a külső sablont az új masterre.
3. Az új mastert hozzárendeli minden diához, amely korábban a kiválasztott masterhez tartozott.
4. Visszaadja a frissen létrehozott [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)-t.

Az alábbi példa egy külső sablont alkalmaz az első masterhez tartozó diákra, majd elmenti a prezentációt:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Egy érvénytelen, sérült vagy nem támogatott sablon [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) vagy valamelyik formátum‑szerű alosztályát válthatja ki. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak a sablon sikeres alkalmazása után mentse a prezentációt.

Csak a kiválasztott masterhez tartozó diákok kerülnek átállításra. Más masterhez tartozó diákok megtartják meglévő masterüket és sablonjaikat. A sablonra érzékeny színek, betűtípusok, kitöltések, vonalak, háttér‑ és effektek a külső sablonra kerülnek feloldásra. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑ és dia‑szintű felülírások is felülbírálhatják az új master‑öröklődött értékeket.

A sablon hivatkozhat olyan betűtípusokra, amelyek nincsenek telepítve a futásidő‑környezetben. A következetes megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket a [custom font sources](/slides/hu/python-net/custom-font/) segítségével, vagy konfigurálja a [font substitution](/slides/hu/python-net/font-substitution/) beállítást.

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális diaszintű vagy elrendezés‑szintű sablonfelülírások létrehozását.

### **Különböző külső sablonok alkalmazása több‑masteres prezentációban**

Ha a releváns master előre nem ismert, szerezze be azt egy reprezentatív dia segítségével a [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) és a [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/) metódusokkal. Tárolja el az eredeti master hivatkozásokat a sablonok alkalmazása előtt, mivel minden hívás egy új mastert hoz létre a prezentációban.

Az alábbi példa két szekcióból származó diák mastereinek meghatározásával külön külső sablont alkalmaz az egyes csoportokra:

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

Az első hívás csak a `first_group_master`‑hez tartozó diákokra hat, a második hívás csak a `second_group_master`‑hez tartozó diákokra. Más masterhez tartozó diákok nem kapnak új stílust.

### **Forrás sablon megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba kíván áthelyezni, miközben meg akarja őrizni az eredeti megjelenését, klónozza a forrás mastert a célprezentációba a [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) segítségével, majd klónozza a diát a [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) és a klónozott master használatával. Így a master, annak elrendezései és a kapcsolódó sablon együtt kerül átvitelre.

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

Ez az ajánlott munkafolyamat, ha a forrásdia megjelenésének azonosnak kell maradnia a célhelyen. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑masterre megváltoztathatja a sablon‑vezérelt színeket, betűtípusokat, háttereket és effekteket.

### **Sablon értékek alkalmazása egy meglévő diára**

Ha a céldia a saját masterén és elrendezésén marad, inicializáljon egy diaszintű felülírást a forrás sablonból. A [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), a [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) és a [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) metódusok a három fő sablonkomponenst másolják a felülírásba.

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

Ez megváltoztatja az adott dia által használt sablont anélkül, hogy más diák örökölt sablonját módosítaná. A helyi felülírás eltávolításához, és az örökölt értékek visszaállításához hívja a [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/) metódust.

### **Sablon felülírás alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülírás azokat a diákot érinti, amelyek az adott elrendezést használják, kivéve, ha egy konkrét dia saját felülírást tartalmaz. Ugyanezeket az inicializálási metódusokat a layout [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) segítségével is használhatja:

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

Használjon master‑ vagy prezentáció‑szintű sablont, ha sok elrendezésnek és diának közös alap‑designra van szüksége; alkalmazzon elrendezésfelülírást, ha egy elrendezéscsoportnak eltérő stílusra van szüksége; és csak diafelülírást használjon valódi kivételek esetén. A túl sok diaszintű felülírás megnehezíti a későbbi globális sablonváltozások előrejelzését.

## **Sablon háttérstílusok frissítése**

A sablon háttér‑kitöltései a [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) gyűjteményben tárolódnak. A PowerPoint a felhasználói felületen több háttér‑választási lehetőséget mutathat, mint a ténylegesen tárolt kitöltés‑definíciók száma, mivel a felület a sablon‑kitöltéseket sablon‑színekkel és egyéb stílus‑hivatkozásokkal kombinálhatja.

![PowerPoint háttérstílus galéria egy prezentációs sablonhoz](presentation-design_8.png)

Mielőtt háttérstílust használna, ellenőrizze a tárolt gyűjteményt és az aktuális [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/) értéket. A `style_index` `0`‑t használ, ha nincs sablon‑kitöltés; pozitív értékek a sablon‑háttér‑stílus‑hivatkozásokat jelentik. Ez eltér a Python‑gyűjtemények közvetlen indexelésétől, ahol a `[0]` az első elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa bejelenti a rendelkezésre álló háttér‑kitöltések számát, egy sablon‑háttér‑hivatkozást rendel az első masterhez, és elmenti a prezentációt:

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

A látható eredmény a master‑sablon által hivatkozott sablonbejegyzéstől, valamint az elrendezés‑ vagy diaszintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a master‑háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) metódust, ha a végleges háttérre van szüksége az öröklődés után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a `style_index`‑et nulláral kezdődő gyűjteményindexként. Kerülje továbbá egy fájlból származó stílus számának kódba írását, és feltételezést, hogy ugyanazzal a megjelenéssel rendelkezik egy másik fájlban; a sablon‑stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttérformázás és háttér‑öröklődés részletei a [Presentation Background](/slides/hu/python-net/presentation-background/) oldalon találhatók.
{{% /alert %}}

## **Sablon effektusok frissítése**

A sablon formátum‑sémája különálló [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) és [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/) gyűjteményeket tartalmaz. A tipikus Office‑sablonok gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy egy rögzített számot feltételezne.

![Finom, közepes és intenzív sablon‑effektek ugyanazon alakzaton](presentation-design_10.png)

Python‑ban a gyűjteményindexek nullával kezdődnek: a `[0]` az első tárolt stílus, a `[2]` a harmadik. Az alakzat‑stílus‑hivatkozási indexek külön fogalom, amely a [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/)‑ben jelenik meg. Egy sablon‑stílus módosítása olyan alakzatokat érint, amelyek arra a sablon‑stílusra hivatkoznak; a közvetlen formázású alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek-e, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi egy külső árnyékot a harmadik effektus‑stílusban, és elmenti az eredményt:

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

A megfelelő slotokra hivatkozó alakzatok esetén az első sablon‑vonal‑stílus piros lesz, a harmadik sablon‑kitöltés‑stílus szilárd erdei zöld, a harmadik effektus‑stílus pedig külső árnyékot kap 10 pont távolsággal. A pontos vizuális eredmény továbbra is attól függ, hogy mely slotra hivatkozik az adott alakzat, és hogy a közvetlen formázás felülírja-e a sablont.

![Sablon‑effektus‑stílusok módosítása után: vonal, kitöltés és árnyék beállítások](presentation-design_11.png)

## **Kitöltés‑ és vonal‑stílusok kiválasztása egy alakzatra**

Egy alakzat a [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) és a [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/) tulajdonságok segítségével függetlenül választhatja ki a kitöltést és a körvonalat. Mindkét tulajdonságnál az `1` index a sablon megfelelő gyűjteményének első elemét (`fill_styles[0]` vagy `line_styles[0]`) jelöli, a `2` index a második elemet.

Az alábbi példa két kitöltést (arany és égkék) és két körvonalat (sötétkék 6 pt‑ben és sötétvörös 12 pt‑ben) definiál egy új prezentáció alapértelmezett sablonjában. A diát három szakaszban menti, hogy PowerPoint‑ban össze tudja hasonlítani az eredményeket.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| Kezdeti stílusok | Jobb körvonal módosítása | Első sablon‑kitöltés szerkesztése |
|:---:|:---:|:---:|
| ![Arany és égkék téglalapok, melyekhez vékony sötétkék körvonal tartozik](theme-style-initial.png) | ![Az égkék téglalap most vastag sötétvörös körvonallal rendelkezik](theme-style-line-changed.png) | ![A bal téglalap most zöld, a körvonalak változatlanok](theme-style-fill-changed.png) |

Egy másik vonal‑stílus kiválasztása csak a jobb téglalap körvonalát változtatja. Az első sablon‑kitöltés szerkesztése minden, azt használó alakzatot frissít. Itt csak a bal téglalap válik zöldre.

Egy meglévő alakzatnál egy helyi kitöltő‑szín, vonal‑szín vagy vonal‑szélesség felülírhatja a sablon‑stílus azon részét. Ha egy stílus‑index módosítása nem hoz látható változást, ellenőrizze az alakzat [direct formatting](/slides/hu/python-net/shape-formatting/) beállításait.

## **Annak meghatározása, hogy egy hatékony szilárd kitöltés sablon‑színt használ‑e**

Egy kitöltés tárolható közvetlenül egy objektumon vagy öröklődhet egy bekezdésből, elrendezésből, masterből, sablon‑stílusból vagy más formázási szintből. Hívja meg a [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) metódust, hogy az öröklődési hierarchiát egy változtathatatlan [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) objektummá alakítsa. Először ellenőrizze a [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/) értékét. Csak akkor olvassa a szilárd‑kitöltés tulajdonságait, ha az `FillType.SOLID`.

Szilárd kitöltés esetén a [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) visszaadja a végső RGB‑értéket, miután az öröklődés, a sablon‑keresés és a színtranszformációk alkalmazásra kerültek. A [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) visszaadja a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) slotot, például `TEXT1` vagy `ACCENT6`. A `SchemeColor.NOT_DEFINED` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy sémaszínből származik. Egy olyan munkafolyamatban, ahol a kitöltések csak sablon‑színek vagy közvetlen RGB‑színek, ez az érték egy közvetlen RGB‑kitöltést azonosít.

Ne csak a helyi [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) értéket használja a kitöltés osztályozásához. Például egy szövegrésznek nincs helyi sémaszíne, így a helyi értéke `NOT_DEFINED`, miközben a hatékony kitöltés örökölt sablon‑színt kap, és `TEXT1` vagy `ACCENT6`‑ra oldódik. Ezzel szemben a `solid_fill_scheme_color` megmutatja, mely logikai sablon‑hely hozta létre a hatékony színt, de nem mondja meg, hogy ez a hely a objektumból, bekezdésből, elrendezésből, masterből vagy más szintből származik.

Az alábbi példa betölti egy prezentációt, auditálja a forma‑ és szövegrész‑kitöltéseket, kiírja minden végső RGB‑értéket és a hozzájuk tartozó sémaszínt, és megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a sablon‑szín változását:

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

A `NOT_DEFINED` ág egy auditlistát ad a szilárd kitöltésekről, amelyek nem reagálnak a sablon‑színhelyek változására. Ezeket az objektumokat vizsgálja meg, ha a prezentációnak egy új márka‑palettát kell követnie. A jelentett RGB‑érték továbbra is az aktuális megjelenést mutatja, míg a sémabeli érték magyarázza, hogy a megjelenés kapcsolódik‑e a sablonhoz.

A hatékony‑formátum objektumok egy pillanatfelvétel. A prezentáció sablonjának, egy sablon‑felülírásnak vagy bármely örökölt formázásnak a módosítása után hívja újra a `get_effective`‑et, és olvassa ki az új `IFillFormatEffectiveData` objektumot a színek összehasonlítása vagy jelentése előtt.

## **Hatékony sablonértékek olvasása**

A nyers sablonobjektumok megmutatják, mi van egy adott szinten definiálva. A hatékony értékek megmutatják, mit használ egy dia vagy forma az öröklődés és a helyi felülírások feloldása után. Diára a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) metódust hívja. Háttérhez használja a [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/)‑t, kitöltéshez pedig a [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/)‑t.

Az alábbi példa beolvassa a hatékony sablont, a háttért és az első forma kitöltését egy diárról:

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

Használja a hatékony adatokat megjelenítési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) objektumot ellenőrizze, lemaradhat egy master, elrendezés, dia vagy forma felülírásáról, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Az külső sablon alkalmazása minden diára hat a prezentációban?**

Nem. A [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) csak azoknak a diáknak a masterét változtatja meg, amelyek az adott masterhez tartoznak. A más masterekhez tartozó diák megtartják meglévő sablonjaikat.

**Alkalmazhatok sablont egyetlen diára a master módosítása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/)‑t, és inicializálja a felülírási sablont. A változtatás csak azon a dián marad lokálisan; a többi dia a meglévő sablonját örökli.

**Mi a legbiztonságosabb módja egy sablon átvitelének egy prezentációból a másikba?**

Diák áthelyezésekor és eredeti megjelenésük megőrzésekor klónozza a forrás‑mastert a célba, majd a diát a klónozott masterrel klónozza a [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) és a [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) segítségével. Így a master, az elrendezések és a sablon együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használja a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)‑t egy dia vagy elrendezés sablonjához, valamint a megfelelő hatékony‑adat metódusokat a formátumobjektumokhoz, például a [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) és a [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). Ezek az API‑k a öröklődés és felülírások után feloldott értékeket adják vissza.