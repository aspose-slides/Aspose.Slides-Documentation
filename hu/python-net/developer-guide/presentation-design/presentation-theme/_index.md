---
title: PowerPoint prezentációs sablonok kezelése Pythonban
linktitle: Prezentációs sablon
type: docs
weight: 10
url: /hu/python-net/presentation-theme/
keywords:
- PowerPoint sablon
- prezentációs sablon
- dia sablon
- sablon beállítása
- sablon módosítása
- sablon kezelése
- sablon szín
- kiegészítő paletta
- sablon betűtípus
- sablon stílus
- sablon effektus
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Mester prezentációs sablonok az Aspose.Slides Python verzióban .NET segítségével, a PowerPoint fájlok konzisztens márkázás szerinti létrehozásához, testreszabásához és konvertálásához."
---
## **Bevezetés**

A prezentációs sablon meghatározza a tervezési elemei tulajdonságait. Amikor egy sablont választ, egy koordinált vizuális elemek és azok tulajdonságainak halmazát választja.

A PowerPointban egy sablon tartalmaz színeket, [betűtípusok](/slides/hu/python-net/powerpoint-fonts/), [háttérstílusokat](/slides/hu/python-net/presentation-background/), és effektusokat.

![theme-constituents](theme-constituents.png)

## **A sablon színének módosítása**

A PowerPoint sablon egy meghatározott színkészletet használ a dián lévő különböző elemekhez. Ha a alapértelmezettek nem tetszenek, új sablonszínek alkalmazásával módosíthatja őket. Ahhoz, hogy új sablonszínt válasszon, az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) felsorolásban értékeket biztosít.

Ez a Python kód megmutatja, hogyan változtatható meg egy sablon hangsúlyszíne:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

A kapott szín tényleges értékét a következőképpen határozhatja meg:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Példa kimenet:
#
# ff8064a2 (Szín [A=255, R=128, G=100, B=162])
```

A színváltás további bemutatásához létrehozunk egy másik elemet, az első lépésben kapott hangsúlyszínt rendeljük hozzá, majd frissítjük a sablonszínt.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

Az új szín automatikusan alkalmazásra kerül mindkét elemre.

### **Sablonszín beállítása a kiegészítő palettáról**

Amikor fényességtranszformációkat alkalmaz a fő sablonszínre (1), a kiegészítő palettáról (2) színek keletkeznek. Ezeket a sablonszíneket ezután beállíthatja és lekérheti.

![additional-palette-colors](additional-palette-colors.png)

**1** — Fő sablonszínek  
**2** — A kiegészítő paletta színei

Ez a Python kód bemutatja, hogyan származtatják a kiegészítő palettaszíneket a fő sablonszínből, és hogyan használják őket alakzatokban:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Akcentus 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Akcentus 4, Világosabb 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Akcentus 4, Világosabb 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Akcentus 4, Világosabb 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Akcentus 4, Sötétebb 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Akcentus 4, Sötétebb 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **`SchemeColor` leképezése a `ColorScheme` színekre**

Amikor a [SchemeColor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/schemecolor/) értékekkel dolgozik, észreveheti, hogy a következő sablonszín-értékek találhatók benne: `BACKGROUND1`, `BACKGROUND2`, `TEXT1` és `TEXT2`.

Ugyanakkor a `Presentation.master_theme.color_scheme` egy [ColorScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/colorscheme/) objektumot ad vissza, amely a megfelelő színeket a következőképpen nevezi:

`dark1`, `dark2`, `light1`, és `light2`.

Ez a különbség csak a megnevezésben van. Ezek az értékek ugyanazokra a sablonszínhelyekre vonatkoznak, és a leképezés rögzített:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Nincs dinamikus konverzió a `TEXT`/`BACKGROUND` és a `dark`/`light` között. Egyszerűen alternatív nevei ugyanannak a sablonszínnek.

Ez a néveltérés a Microsoft Office terminológiájából ered. A régebbi Office verziók a `Dark 1`, `Light 1`, `Dark 2` és `Light 2` megnevezéseket használták, míg az újabb felhasználói felületek ugyanazokat a helyeket a `Text 1`, `Background 1`, `Text 2` és `Background 2` néven jelenítik meg.

## **A sablon betűtípusának módosítása**

Az Aspose.Slides lehetővé teszi a sablonok és egyéb célok betűtípusainak kiválasztását a következő speciális azonosítókkal (a PowerPointban használtakkal megegyezően):

- **+mn-lt** — Szöveg betűtípusa Latin (Kisebb Latin betűtípus)
- **+mj-lt** — Címsor betűtípusa Latin (Nagy Latin betűtípus)
- **+mn-ea** — Szöveg betűtípusa Kelet-Ázsiai (Kisebb Kelet-Ázsiai betűtípus)
- **+mj-ea** — Címsor betűtípusa Kelet-Ázsiai (Nagy Kelet-Ázsiai betűtípus)

Ez a Python kód megmutatja, hogyan rendelhet Latin betűtípust egy sablon elemhez:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Ez a Python példa bemutatja, hogyan változtatható meg a prezentáció sablonbetűtípusa:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Az összes szövegdoboz frissül az új betűtípusra.

{{% alert color="primary" title="TIP" %}}
További információért lásd a [Mester PowerPoint betűtípusok Pythonban](/slides/hu/python-net/powerpoint-fonts/).
{{% /alert %}}

## **A sablon háttérstílusának módosítása**

Alapértelmezés szerint a PowerPoint 12 előre definiált hátteret biztosít, de egy tipikus prezentáció csak 3‑at tárol.

![todo:image_alt_text](presentation-design_8.png)

Például a PowerPointban egy prezentáció mentése után a következő Python kóddal meghatározhatja, hány előre definiált háttere van:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
A [FormatScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/) osztály `background_fill_styles` tulajdonságának használatával hozzáadhat vagy elérhet háttérstílusokat egy PowerPoint sablonban.
{{% /alert %}}

Ez a Python példa megmutatja, hogyan állítható be a prezentáció háttere:

```python
presentation.masters[0].background.style_index = 2  # 0 jelenti a kitöltés hiányát; a indexelés 1‑től kezdődik.
```

{{% alert color="primary" title="TIP" %}}
További információért lásd a [Prezentáció háttér kezelése Pythonban](/slides/hu/python-net/presentation-background/).
{{% /alert %}}

## **A sablon effektusainak módosítása**

Egy PowerPoint sablon általában három értéket tartalmaz minden stílus tömbben. Ezek a tömbök három effektusszintet alkotnak: finom, közepes és intenzív. Például itt látható az eredmény, amikor ezeket az effektusokat egy adott alakzatra alkalmazzák:

![todo:image_alt_text](presentation-design_10.png)

A [FormatScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/formatscheme/) osztály három tulajdonságával – `FillStyles`, `LineStyles` és `EffectStyles` – módosíthatja a sablon elemeit (még rugalmasabban, mint a PowerPointban).

Ez a Python kód megmutatja, hogyan módosítható egy sablon effektus az elemek részeinek változtatásával:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Az eredményül kapott változások magukban foglalják a kitöltő szín, kitöltő típus, árnyékhatás és egyéb tulajdonságok frissítését:

![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

**Alkalmazhatok egy sablont egyetlen diára a master módosítása nélkül?**

Igen. Az Aspose.Slides támogatja a diaszintű sablon felülbírálásokat, így helyi sablont alkalmazhat csak arra a diára, miközben a master sablon érintetlen marad (a [SlideThemeManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/slidethememanager/) segítségével).

**Mi a legbiztonságosabb módja egy sablon átvitelének egy prezentációból a másikba?**

A [Dia másolása](/slides/hu/python-net/clone-slides/) a masterrel együtt a célprezentációba. Ez megőrzi az eredeti mastert, elrendezéseket és a hozzá tartozó sablont, így a megjelenés következetes marad.

**Hogyan tekinthetem meg a "hatékony" értékeket minden öröklődés és felülbíráló után?**

Használja az API ["hatékony"](/slides/hu/python-net/shape-effective-properties/) nézeteit a sablon/szín/betűtípus/effektus esetén. Ezek visszaadják a feloldott, végleges tulajdonságokat a master és bármely helyi felülbírálás alkalmazása után.