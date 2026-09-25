---
title: WordArt hatások létrehozása és alkalmazása Pythonban
linktitle: WordArt
type: docs
weight: 110
url: /hu/python-net/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt hatás
- árnyékhatás
- tükröződés hatása
- ragyogás hatása
- WordArt átalakítás
- 3D hatás
- külső árnyék hatás
- belső árnyék hatás
- Python
- Aspose.Slides
description: "WordArt hatások létrehozása és testreszabása az Aspose.Slides for Python via .NET-ben. Ez a lépésről lépésre útmutató segít a fejlesztőknek professzionális szöveggel gazdagítani a prezentációkat Pythonban."
---
## **Áttekintés**

A WordArt hatások lehetővé teszik a szöveg formázását kitöltésekkel, körvonalakkal, árnyékokkal, tükröződésekkel, ragyogással, átalakításokkal és 3D formázással. Ez a cikk bemutatja, hogyan hozhatók létre és testreszabhatók ezek a hatások PowerPoint‑prezentációkban az Aspose.Slides for Python via .NET használatával, Microsoft Office telepítése nélkül.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

A következő példák egyszerű WordArt stílust építenek fel a szöveg, a betűtípus, a mintás kitöltés és a körvonal beállításával.

Minden példa új prezentációt hoz létre és egy téglalapot ad az első diájához; bemeneti fájlra nincs szükség. Az első példában a szöveg "Aspose.Slides" lesz. Az alakzati pozíciót és méreteket pontban mérik:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Állítsa a betűtípust Arial Black-ra 36 pont méretben, hogy a formázás jobban észrevehető legyen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Alkalmazzon egy [SMALL_GRID](https://reference.aspose.com/slides/hu/python-net/aspose.slides/patternstyle/) mintát sötét narancssárga előtérrel és fehér háttérrel, majd adjon hozzá egy fekete szöveg körvonalat 1 pont szélességgel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Az eredményül kapott szöveg:

![Az egyszerű WordArt sablon](WordArt_template.png)

## **Egyéb WordArt hatások alkalmazása**

A következő példák bemutatják, hogyan lehet árnyékokat, tükröződéseket, ragyogást, átalakításokat és 3D hatásokat alkalmazni a szövegre.

### **Külső árnyék hatások alkalmazása**

A külső árnyék mélységet ad a szöveg mögé helyezett árnyékkal. Testreszabhatja annak színét, irányát, távolságát, elmosódási sugarát, méretezését és ferdeségét.

Ez a példa meghívja a [enable_outer_shadow_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) metódust, és egy fekete árnyékot állít be 4 pont elmosódási sugárral, 230 fokos iránnyal és 30 pont távolsággal. A 100 értékű méretezés megőrzi az árnyék méretét, míg a vízszintes ferdeség 20 fokkal dönti el. Az alfa transzformáció 32 % átlátszóságra állítja:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Az eredményül kapott szöveg:

![A külső árnyék hatás](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Ha a külső és az előre beállított árnyékok együtt vannak használva, csak a külső árnyék kerül alkalmazásra.
- Ha a külső és a belső árnyékok egyszerre vannak használva, a kapott hatás a PowerPoint verziójától függ. Például a PowerPoint 2013‑ban a hatás duplázódik, míg a PowerPoint 2007‑ben csak a külső árnyék kerül alkalmazásra.
{{% /alert %}}

### **Tükröződés hatások alkalmazása**

A tükröződés a szöveg tükörképét hozza létre. Állítsa be a pozícióját, méretezését, elmosódását és átlátszóságát a megjelenés szabályozásához.

Ez a példa meghívja a [enable_reflection_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/effectformat/enable_reflection_effect/) metódust, és függőlegesen tükrözi a tükröződést -100 % méretezéssel. 0,5 pont elmosódási sugarat és 4,72 pont távolságot használ. Az átlátszóság 60 %-ról 0,9 %-ra csökken a 0 % és 60 % közötti pozíciók között a tükröződésen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

Az eredményül kapott szöveg:

![A tükröződés hatás](reflection_effect.png)

### **Ragyogás hatások alkalmazása**

A ragyogás puha színes körvonalat ad a szöveg köré. Állítsa be a színét, átlátszóságát és sugarát a hatás szabályozásához.

Ez a példa meghívja a [enable_glow_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/effectformat/enable_glow_effect/) metódust, és 54 % átlátszóságú, 7 pont sugarú piros ragyogást alkalmaz:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Az eredményül kapott szöveg:

![A ragyogás hatás](glow_effect.png)

### **WordArt átalakítások alkalmazása**

A WordArt átalakítások hajlítják, nyújtják vagy torzítják a szövegrészt.

Állítsa a [transform](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/transform/) értékét [ARCH_UP_POUR](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textshapetype/)‑re, hogy az egész szövegkeretet felfelé ívbe hajtsa:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Az eredményül kapott szöveg:

![A WordArt átalakítás](transform_effect.png)

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Python via .NET előre definiált [transformation types](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textshapetype/) halmazt biztosít.
{{% /alert %}}

### **3D hatások alkalmazása alakzatokra és szövegre**

3D hatásokat lehet alkalmazni egy alakzatra vagy annak szövegére. A levágások, kihúzások, megvilágítás és kamera beállítások szabályozzák az eredő megjelenést.

A következő példa a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) használatával körkörös levágásokat, narancssárga kihúzást és sötétvörös körvonalat ad a téglalaphoz. A levágás méretei, a kihúzás magassága, a körvonal szélessége és a mélység pontban van megadva. Műanyag anyag, 40 fokkal Z tengely körül elforgatott kiegyensúlyozott megvilágítás és perspektív kamera határozza meg a megjelenést:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Az eredményül kapott alakzat:

![Az alakzat 3D hatása](shape_3D_effect.png)

Ez a példa hasonló 3D formázást alkalmaz a szövegre a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/three_d_format/) segítségével. A kisebb levágások alakítják a betűk széleit, míg a kihúzás és a megvilágítás mélységet ad a szövegnek:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Az eredményül kapott szöveg:

![A szöveg 3D hatása](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
3D hatások szövegre vagy azok alakzataira – és ezek hatásainak kölcsönhatása – meghatározott szabályok szerint működik. Tekintsünk egy jelenetet, amely magában foglalja a szöveget és a szöveget tartalmazó alakzatot. A 3D hatás tartalmazza az objektum 3D ábrázolását és a benne elhelyezett jelenetet.

- Ha a jelenet mind az alakzatra, mind a szövegre be van állítva, az alakzat jelenete élvez előnyt, a szöveg jelenete mellőzve lesz.
- Ha az alakzatnak nincs saját jelenete, de rendelkezik 3D ábrázolással, a szöveg jelenete lesz használva.
- Ha az alakzat egyáltalán nem rendelkezik 3D hatással, akkor laposnak tekintik, és a 3D hatás csak a szövegre kerül alkalmazásra.

Ezek a viselkedések a [ThreeDFormat.light_rig](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/light_rig/) és a [ThreeDFormat.camera](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/camera/) tulajdonságokra vonatkoznak.
{{% /alert %}}

A szöveg lapos és olvasható tartásához, miközben megtartja az alakzat 3D formázását, tekintse meg a [Keep Text Flat on a 3D Shape](/slides/hu/python-net/3d-presentation/) oldalt, amely összehasonlítja a két beállítást és tartalmaz egy teljes Python példát.

## **GYIK**

**Alkalmazhatok WordArt hatásokat különböző betűtípusokkal vagy írásrendszerekkel (például arab, kínai)?**

Igen, az Aspose.Slides for Python via .NET támogatja az Unicode-ot, és minden főbb betűtípussal és írásrendszerrel működik. A WordArt hatásokat, mint az árnyék, kitöltés és körvonal, a nyelvtől függetlenül alkalmazhatja, bár a betűtípusok elérhetősége és a megjelenítés a rendszer betűtípusaitól függhet.

**Alkalmazhatok WordArt hatásokat a dia mester elemére?**

Igen, WordArt hatásokat alkalmazhat a mesterdiák alakzataira, beleértve a címhelyettesítőket, lábléceket vagy háttérszöveget. A mesterelrendezésben végzett módosítások az összes kapcsolódó diához átkerülnek.

**Növelik-e a WordArt hatások a prezentáció fájlméretét?**

Enyhe mértékben. Az árnyékok, ragyogások és színátmenetes kitöltésekhez hasonló WordArt hatások a formázási metaadatok miatt kissé növelhetik a fájlméretet, de a különbség általában elhanyagolható.

**Előnézhetem a WordArt hatások eredményét a prezentáció mentése nélkül?**

Igen, a WordArt-ot tartalmazó diák képekké (például PNG, JPEG) renderelhetők a [Slide.get_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/) segítségével, vagy az egyes alakzatok a [Shape.get_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/) metódussal. Ez lehetővé teszi az eredmény előnézetét memóriában vagy a képernyőn a teljes prezentáció mentése vagy exportálása előtt.