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
- WordArt effektus
- árnyék effektus
- megjelenítési effektus
- ragyogás effektus
- WordArt transzformáció
- 3D effektus
- külső árnyék effektus
- belső árnyék effektus
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat WordArt effektusokat az Aspose.Slides for Python via .NET segítségével. Ez a lépésről lépésre útmutató segít a fejlesztőknek a prezentációk stílusos, professzionális szövegével való gazdagításában Pythonban."
---
## **Áttekintés**

A WordArt hatások lehetővé teszik, hogy vizuálisan vonzó, stílusos szöveget adjunk PowerPoint prezentációihoz. Az Aspose.Slides segítségével a fejlesztők programozottan létrehozhatják, testreszabhatják és kezelhetik a WordArt-ot, mint a Microsoft PowerPointben—az Office telepítése nélkül. Ez a cikk áttekintést nyújt a WordArt használatáról, beleértve, hogyan alkalmazhatók szövegtranszformációk, kitöltési stílusok, körvonalak, árnyékok és egyéb formázási lehetőségek a prezentáció tartalmának kifejezőbbé és vonzóbbá tételéhez. A WordArt lehetővé teszi, hogy a szöveget grafikus objektumként kezeljük. Olyan effektusokból vagy speciális módosításokból áll, amelyeket a szövegre alkalmaznak, hogy az vonzóbb vagy feltűnőbb legyen.

**WordArt a Microsoft PowerPointben**

A WordArt használatához a Microsoft PowerPointben ki kell választani egy előre definiált WordArt sablont. A WordArt sablon olyan effektusok halmaza, amely a szövegre vagy annak alakjára kerül alkalmazásra.

**WordArt az Aspose.Slides‑ban**

Az Aspose.Slides for Python via .NET 20.10 verzióban bevezettük a WordArt támogatását, és a későbbi Aspose.Slides for Python via .NET kiadásokban továbbfejlesztettük ezt a funkciót.  
Az Aspose.Slides for Python via .NET segítségével könnyedén létrehozhat saját WordArt sablont (egy effektust vagy effektusok kombinációját) Pythonban, és alkalmazhatja azt szövegekre.

## Egyszerű WordArt sablon létrehozása és alkalmazása szövegre

**Aspose.Slides használata**  

Először egy egyszerű szöveget hozunk létre a következő Python kóddal:  

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Ezután a szöveg betűméretét nagyobb értékre állítjuk, hogy az effektus jobban észrevehető legyen, a következő kóddal:  

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Microsoft PowerPoint használata**  

Navigáljon a WordArt effektusok menüjéhez a Microsoft PowerPointben:  

![todo:image_alt_text](image-20200930113926-1.png)

A jobb oldali menüből választhat egy előre definiált WordArt effektust. A bal oldali menüből megadhatja egy új WordArt beállításait.  

Az alábbiak a rendelkezésre álló paraméterek vagy lehetőségek egy része:  

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides használata**  

Itt a SmallGrid minta színét alkalmazzuk a szövegre, és egy 1 szélességű fekete szövegkeretet adunk hozzá a következő kóddal:  

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Az eredményül kapott szöveg:  

![todo:image_alt_text](image-20200930114108-4.png)

## Egyéb WordArt effektusok alkalmazása

**Microsoft PowerPoint használata**  

A program felületéről ezeket az effektusokat szövegre, szövegblokkra, alakzatra vagy hasonló elemre alkalmazhatja:  

![todo:image_alt_text](image-20200930114129-5.png)

Például az Árnyék, Tükröződés és Ragyogás effektusok szövegre vonatkozhatnak; a 3D formátum és 3D forgatás effektusok szövegblokkra alkalmazhatók; a Lágy szélek tulajdonság alakzatra (Shape Object) vonatkozik (akkor is hatása van, ha nincs 3D formátum beállítva).

### Árnyék effektusok alkalmazása

Itt csak a szövegre vonatkozó tulajdonságokat állítjuk be. A szövegre a következő Python kóddal alkalmazzuk az árnyék effektust:  

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Az Aspose.Slides API három típusú árnyékot támogat: OuterShadow, InnerShadow és PresetShadow.  
A PresetShadow segítségével előre beállított értékekkel alkalmazhat árnyékot szövegre.

**Microsoft PowerPoint használata**  

A PowerPointban egyetlen árnyéktípust használhat. Íme egy példa:  

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides használata**  

Az Aspose.Slides valójában egyszerre két árnyéktípust engedélyez: InnerShadow és PresetShadow.

**Megjegyzések:**  

- Ha az OuterShadow és a PresetShadow együtt kerülnek felhasználásra, csak az OuterShadow effektus kerül alkalmazásra.  
- Ha az OuterShadow és az InnerShadow egyszerre kerülnek használatra, a keletkezett vagy alkalmazott effektus a PowerPoint verziójától függ. Például PowerPoint 2013 esetén az effektus duplázódik, míg PowerPoint 2007 esetén az OuterShadow effektus kerül alkalmazásra.

### Megjelenítés alkalmazása szövegekre

A szöveghez a következő Python példakóddal adunk hozzá megjelenítést:  

```py 
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

### Ragyogás effektus alkalmazása szövegekre

A szövegre a következő kóddal alkalmazzuk a ragyogás effektust, hogy kiemelkedjen vagy fényesen jelenjen meg:  

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

A művelet eredménye:  

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}}  
Módosíthatja az árnyék, a megjelenítés és a ragyogás paramétereit. Az effektusok tulajdonságai a szöveg egyes részeire külön-külön kerülnek beállításra.  
{{% /alert %}}

### Transzformációk használata WordArt‑ban

A Transform tulajdonságot (amely az egész szövegblokkra vonatkozik) a következő kóddal használjuk:  
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Az eredmény:  

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}}  
A Microsoft PowerPoint és az Aspose.Slides for Python via .NET egy bizonyos számú előre definiált transzformáció típust biztosít.  
{{% /alert %}}

**PowerPoint használata**  

Az előre definiált transzformáció típusok eléréséhez menjen a következő helyre: **Formátum** -> **Szövegeffektus** -> **Transzformáció**

**Aspose.Slides használata**  

Egy transzformáció típus kiválasztásához használja a TextShapeType felsorolt típust (enum).

### 3D effektusok alkalmazása szövegekre és alakzatokra

A következő mintakóddal 3D effektust állítunk be egy szöveg alakzatra:  

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Az eredményül kapott szöveg és alakzata:  

![todo:image_alt_text](image-20200930114816-9.png)

A szövegre a következő Python kóddal alkalmazunk 3D effektust:  

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

A művelet eredménye:  

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}}  
A 3D effektusok szövegekre vagy azok alakzataira való alkalmazása, valamint az effektusok közötti kölcsönhatások bizonyos szabályokon alapulnak.

Tekintsen egy jelenetre (scene) a szöveghez és az azt tartalmazó alakzatra. A 3D effektus tartalmazza a 3D objektum ábrázolását és a jelenetet, amelyre az objektum elhelyezésre kerül.

- Ha a jelenet mind a figura, mind a szöveg esetén be van állítva, a figura jelenete felülbírálja – a szöveg jelenete figyelmen kívül marad.  
- Ha a figurának nincs saját jelenete, de van 3D ábrázolása, a szöveg jelenete használatban van.  
- Egyébként – ha az alakzat eredetileg nem rendelkezik 3D effektussal – az alakzat lapos, és a 3D effektus csak a szövegre kerül alkalmazásra.

A leírások kapcsolódnak a [ThreeDFormat.LightRig](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) és a [ThreeDFormat.Camera](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) tulajdonságokhoz.  
{{% /alert %}}

## **Külső árnyék effektusok alkalmazása szövegekre**

Az Aspose.Slides for Python via .NET biztosítja a [**IOuterShadow**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/ioutershadow/) és a [**IInnerShadow**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/iinnershadow/) osztályokat, amelyek lehetővé teszik, hogy árnyék effektusokat alkalmazzunk a TextFrame által tartott szövegre. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy diának a hivatkozását az index használatával.  
3. Adjon a diára egy Rectangle típusú AutoShape-et.  
4. Szerezze meg az AutoShape-hez tartozó TextFrame-et.  
5. Állítsa be az AutoShape FillType-ját NoFill értékre.  
6. Példányosítsa az OuterShadow osztályt.  
7. Állítsa be az árnyék BlurRadius értékét.  
8. Állítsa be az árnyék Direction értékét.  
9. Állítsa be az árnyék Distance értékét.  
10. Állítsa be a RectanglelAlign értékét TopLeft-re.  
11. Állítsa be az árnyék PresetColor értékét Black-re.  
12. Írja ki a prezentációt PPTX fájlként.  

Ez a Python mintakód – a fenti lépések megvalósítása – megmutatja, hogyan alkalmazzon külső árnyék effektust egy szövegre:  

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # A dia hivatkozásának lekérése
    sld = pres.slides[0]

    # Rectangle típusú AutoShape hozzáadása
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # TextFrame hozzáadása a Rectangle-hez
    ashp.add_text_frame("Aspose TextBox")

    # Alakzat kitöltés letiltása, ha a szöveg árnyékát szeretnénk
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Külső árnyék hozzáadása és az összes szükséges paraméter beállítása
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #A prezentáció írása a lemezre
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Belső árnyék effektus alkalmazása alakzatokra**

Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást a diára.  
3. Adjon hozzá egy Rectangle típusú AutoShape-et.  
4. Engedélyezze az InnerShadowEffect-et.  
5. Állítsa be az összes szükséges paramétert.  
6. Állítsa be a ColorType értékét Scheme-re.  
7. Állítsa be a Scheme színt.  
8. Írja ki a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.  

Ez a mintakód (a fenti lépések alapján) megmutatja, hogyan adjon hozzá egy összekötőt két alakzat között Pythonban:  

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # A dia hivatkozásának lekérése
    slide = presentation.slides[0]

    # Rectangle típusú AutoShape hozzáadása
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # TextFrame hozzáadása a Rectangle-hez
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Belső árnyék effektus engedélyezése    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Az összes szükséges paraméter beállítása
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # ColorType beállítása Scheme-re
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Scheme szín beállítása
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Prezentáció mentése
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Használhatok WordArt effektusokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**  

Igen, az Aspose.Slides támogatja a Unicode‑t, és működik minden főbb betűtípussal és írásrendszerrel. A WordArt effektusok, például az árnyék, kitöltés és keret, nyelvtől függetlenül alkalmazhatók, bár a betűtípus elérhetősége és megjelenítése a rendszer betűtípusaitól függhet.

**Alkalmazhatok WordArt effektusokat a dia mester elemeihez?**  

Igen, a WordArt effektusokat a mester diákon lévő alakzatokra, beleértve a cím helyőrzőket, láblécet vagy háttérszöveget, alkalmazhatja. A mester elrendezésén végzett módosítások minden kapcsolódó dián megjelennek.

**Hat a WordArt effektus a prezentáció fájlméretére?**  

Kis mértékben. A WordArt effektusok, például árnyékok, ragyogás és színátmenetes kitöltések kissé növelhetik a fájlméretet a hozzáadott formázási metaadatok miatt, de a különbség általában elhanyagolható.

**Megtekinthetem a WordArt effektusok eredményét a prezentáció mentése nélkül?**  

Igen, a WordArt‑ot tartalmazó diák képekké (pl. PNG, JPEG) renderelhetők a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) vagy [Slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/) osztályok `get_image` metódusával. Ez lehetővé teszi az eredmény előnézetét memóriában vagy a képernyőn a teljes prezentáció mentése vagy exportálása előtt.