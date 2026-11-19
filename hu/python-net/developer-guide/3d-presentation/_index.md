---
title: 3D hatások létrehozása prezentációkban Python segítségével
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrúzió
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Alkalmazzon és rendereljen 3D hatásokat PowerPoint alakzatokhoz és szöveghez Pythonban az Aspose.Slides segítségével. Állítsa be a kamerát, megvilágítást, anyagot, extrúziót, kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET képes létrehozni, szerkeszteni, megőrizni és megjeleníteni PowerPoint‑stílusú 3D formázást alakzatokhoz és szöveghez. Ez a cikk olyan 3D hatásokat fed le, mint a forgatás, extrúzió, peremek, megvilágítás, anyag, színátmenetes vagy képes kitöltések, valamint a 3D szöveg.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatokon és szövegen alkalmazott 3D formázási hatásokról szól. Nem a különálló 3D modellfájlok beillesztéséről vagy szerkesztéséről van szó. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides ezeket a 3D hatásokat a kiexportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használja a [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) tulajdonságot a 3D formázás alkalmazásához egy alakzaton. A tulajdonság a [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)‑t teszi elérhetővé, amely az adott alakzat 3D jelenetét szabályozza.

Szöveghez használja a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) tulajdonságot. Ez a szövegdobozra alkalmaz 3D formázást az alakzat testének helyett.

A legfontosabb tulajdonságok vannak:

| Property | Mit szabályoz | Mikor használjuk |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Nézőpont, előre beállított kamera típus, forgatás, zoom és perspektíva. | Az objektum forgatása 3D térben vagy egy PowerPoint 3D forgatási előbeállítás egyezése. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Fény előbeállítás, irány és fényforgatás. | Megváltoztatja, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Felületi anyag, például sima, matt, műanyag vagy fém. | Ugyanazt a geometriát laposabbá, lágyabbá, fényesebbé vagy fémesebbé teszi. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Milyen messze nyúlik az alakzat vissza a frontális felületétől. | Egy lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Az extrudált oldalak színe. | Láthatóvá teszi a mélységet vagy az oldal színét a frontális kitöltéssel egyezteti. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D formázás által használt további 3D mélység. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a perem és anyag beállításokkal együtt. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Emelt vagy lekerekített szélek az első és hátulsó felületeken. | Lábnyú vagy formázott szél ad egy éles, lapos felület helyett. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | Kontúr színe és szélessége a 3D objektum körül. | Kiemeli az objektum határát a megjelenített kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D‑nek tűnik:

- Kamera beállítások, mert az alapértelmezett frontális nézet elrejtheti az extrudálást.
- Világítás beállítások, mert a megvilágítás a felületeket és oldalakat olvashatóvá teszi.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mert egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad a frontális felületéhez, és alkalmaz 3D formázást. A kamera forgatás értékei fokban vannak megadva, az extrúzió magassága 100 pont. A példa a diát PNG képre rendereli kétszeresére az alapértelmezett méretben, és a prezentációt PPTX‑ként menti.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

A renderelt dia kép a téglalapot egy vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel a frontális felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPoint‑ban a 3D forgatás a 3‑D forgatás panelen állítható be. Az X, Y és Z forgatási értékek megfelelnek annak a forgatásnak, amelyet a kamera API-n keresztül állít be.

![PowerPoint 3‑D forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides‑ban a kamerát a [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) révén érheti el. Ez a példa egy téglalapot hoz létre, ortográfiai frontális nézetet választ, és az X, Y, Z forgatásait 20, 30 és 40 fokra állítja. A példában az alakzatot memóriában konfigurálja fájl mentése nélkül:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Használja a kamerát, ha meg kell változtatni, hogyan látja a néző az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a rendereléskor használt 3D nézőpontot módosítja.

### **Kameraorientáció másolása egy sablon alakzatról**

A sablon alakzat orientációjának egyeztetéséhez másolja a [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) előbeállítást, és olvassa ki a forgatását a [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/)‑val. A példa megnyitja a `template.pptx`‑et, és a első dián az első alakzatból a második alakzatra másolja a kameraorientációt. Mindkét alakzat már rendelkezik 3D világítással, a második alakzatnak pedig nincs kifejezett kamera forgatása.

A szögek fokban vannak. Az `0`, `1`, `2` indexek a szélességet, hosszúságot és körforgást tárolják, ebben a sorrendben. Adja át őket a [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/)‑nek ebben a sorrendben. Ha a forrásnak nincs kifejezett forgatása, a `get_rotation` `None`‑t ad vissza, ezért hagyja a cél szögeket beállítatlanul. Ha a forrás kifejezetten mindhárom szöget nullára állítja, másolja ezeket a nullákat.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

Amikor újra megnyitja a `camera-copy.pptx`‑et PowerPointban, mindkét alakzat ugyanazzal a kamera előbeállítással és forgatással rendelkezik. A jobb oldali nyíl a bal oldali téglalapból másolt orientációt használja. Mindkét alakzat ugyanazt a világítást és extrúzió mélységet alkalmazza.

![Egy kék 3D téglalap és egy jobbra mutató nyíl, egyező kameraorientációval, felülről és jobbról nézve](camera-orientation.png)

## **Extrúzió és mélység hozzáadása**

Az extrúzió egy alakzatot vastagnak látszik, ha a frontális felület mögé nyújtja. PowerPoint‑ban a mélység szabályzó ezt a látható vastagságot állítja be, a szín szabályzó pedig az oldalfelületek színét határozza meg.

![PowerPoint mélység szabályzók leképezve az extrúzió színére és magasságára vonatkozó tulajdonságokra](img_02_02.png)

Állítsa be a [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/)‑t a vastagságra, és a [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/)‑t az oldalszínre. Ez a példa egy 100 pontos extrúziót ad egy téglalapnak lila oldalakkal, és a kamerát forgatja, hogy látható legyen a vastagsága. A példában az alakzatot memóriában konfigurálja fájl mentése nélkül:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

A [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) tulajdonság beállítja egy 3D alakzat mélységét. Az [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) tulajdonság szabályozza az extrúzió hatás magasságát, ahogy ez a példában látható.

## **Színátmenetes vagy képes kitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egységes színt, színátmenetet, mintát vagy képes kitöltést a frontális felületre, miközben ugyanazokat a kamera, fény, anyag és extrúzió beállításokat használja.

Ez a példa egy kék‑narancssárga színátmenetet alkalmaz a frontális felületre, és egy sötét narancssárga színt a 150 pontos extrúzióra. A színátmenet 0‑nál és 100‑nál áll le, ami a színátmenet kezdete és vége. A kamera forgatás értékei fokban vannak. A dia PNG képre renderelődik kétszeresére az alapértelmezett méretben:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

Képes kitöltéshez adja hozzá a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez. Ez a példa egy meglévő, "image.jpg" nevű fájlt igényel a munkakönyvtárban. A képet nyújtja, hogy kitöltse a téglalapot, 150 pontos extrúziót alkalmaz, és fokban állítja a kamera forgatását. A példában az alakzatot memóriában konfigurálja fájl mentése vagy renderelése nélkül:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![Renderelt 3D téglalap fotó kitöltéssel a frontális felületen és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testére hat. A szöveg 3D formázása a szövegdobozra hat. Ez hasznos WordArt‑szerű hatásoknál, amikor a betűknek maguknak kell extrúziót, anyagot, megvilágítást és kamera beállításokat.

A következő példa egy narancssárga‑fehér rácsmintával ellátott szöveget hoz létre, felfelé ívelt ívet alkalmaz, és 3D beállításokat konfigurál a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) segítségével. Az extrúzió magassága és mélysége pontban van megadva, a fény forgatása fokban. Az alakzat kitöltés és körvonal rejtve van, hogy csak a szöveg legyen látható. A példa egy PNG képet renderel a diák alapértelmezett méretének kétszeresén, és a prezentációt PPTX‑ként menti:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrúzióval](img_02_05.png)

## **Szöveg sík tartása 3D alakzaton**

A szöveg olvashatóságának megőrzéséhez a 3D megjelenés megtartása mellett, állítsa be a [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/)‑t a [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/)‑en keresztül. Ha az érték `True`, a szöveg kívülmarad a 3D jelenetből. Ha `False`, a szöveg részt vesz a jelenetben és követi annak 3D orientációját.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, megvilágítás, anyag és extrúzió továbbra is a [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) segítségével van beállítva. Emellett különbözik a hagyományos forgatástól. A [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) a alakzatot a dia síkjában forgatja, míg a [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) a szöveg egyedi forgatásának irányát szabályozza a keretén belül. A szöveg 3D jelenetből való kizárása semelyik szöget sem állítja vissza.

A következő önmagában álló példa egy kék téglalapot hoz létre szöveggel, és az eredeti mellett klónozza. Mindkét alakzat ugyanazt a 3D formázást kapja; csak a szöveg beállítása különbözik: `False` a bal oldalon és `True` a jobb oldalon. A kamera szögek fokban vannak, az extrúzió magassága 40 pont. A példa a prezentációt PPTX‑ként menti, és a összehasonlító diát PNG‑re rendereli kétszeres méretben.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

![Egymás melletti 3D téglalapok: a keep_text_flat `False` a bal oldalon, `True` a jobb oldalon](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be ment. Rendereléskor vagy rögzített elrendezésű formátumokba exportáláskor a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetre. Ez akkor is érvényes, amikor diákat [PNG](/slides/hu/python-net/convert-powerpoint-to-png/)-re renderel, [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/)-re exportál, [HTML](/slides/hu/python-net/convert-powerpoint-to-html/)-re exportál, vagy [videó konverzió](/slides/hu/python-net/convert-powerpoint-to-video/) kereteket generál.

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja elforgatni az export után.
- A végső megjelenés a kamera, a fényrig, az anyag, az extrúzió, a kitöltés és a dia méretezés kombinációjától függ.
- Ha örökölt vagy sablonalapú formázási értékeket kell megvizsgálnia, olvassa el a [effective shape properties](/slides/hu/python-net/shape-effective-properties/).
- Egyes kimeneti formátumok nem tudják tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelődik, nem marad szerkeszthető 3D beállításként.

## **FAQ**

**Készíthet az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásait alakzatokra és szövegre. Nem készíti el az exportált képeket, PDF‑eket vagy HTML‑oldalakat interaktív 3D jelenetekként, amelyeket a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

A 3D modell egy különálló, a prezentációba beillesztett 3D objektum. A 3D hatás egy reguláris PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrúzió, perem, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább egy kamera forgatást és vagy extrúziót, vagy mélységet kell beállítani. Gyakorlatilag a fényriget és az anyagot is meg kell adni, hogy a renderelt felületeken tiszta kiemelések és árnyékok legyenek.

**Alkalmazhatok 3D hatásokat alakzatokra és szövegre egyaránt?**

Igen. Használja a [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/)‑t az alakzat testére és a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/)‑t a szövegre.

**Megjelennek a 3D hatások képekre, PDF‑re, HTML‑re vagy videó keretekre exportáláskor?**

Igen. Az Aspose.Slides a 3D hatásokat rendereli, amikor diákat képpé, PDF‑vé, HTML‑vé alakít, vagy videó konvertáláshoz kereteket generál. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Ki tudom olvasni a végső 3D értékeket öröklődés és sablonbeállítások alkalmazása után?**

Igen. Használja az effektív formázási API‑kat, amelyeket a [Shape Effective Properties](/slides/hu/python-net/shape-effective-properties/) leír, a végső kamera, fényrig, perem és egyéb 3D értékek olvasásához.