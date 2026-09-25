---
title: 3D hatások létrehozása prezentációkban Python használatával
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrudálás
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Alkalmazzon és rendereljen 3D hatásokat PowerPoint alakzatokra és szövegre Pythonban az Aspose.Slides segítségével. Állítsa be a kamerát, megvilágítást, anyagot, extrudálást, kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET létrehozhat, szerkeszthet, megőrizhet és renderelhet PowerPoint‑szerű 3D formázást alakzatokra és szövegre. Ez a cikk a 3D hatásokat, például forgatást, extrudálást, rézseket, megvilágítást, anyagot, színátmenetes vagy képes kitöltéseket, valamint 3D szöveget tárgyalja.

{{% alert color="info" title="Megjegyzés" %}}
Ez a cikk a PowerPoint alakzatokon és szövegen alkalmazott 3D formázási hatásokról szól. Nem a önálló 3D modellfájlok beillesztéséről vagy szerkesztéséről szól. Amikor egy diát képre, PDF‑re vagy HTML‑re exportálsz, az Aspose.Slides ezeket a 3D hatásokat az exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használd a [Shape.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/three_d_format/) tulajdonságot a 3D formázás alkalmazásához egy alakzatra. A tulajdonság hozzáférést biztosít a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/)‑hez, amely az adott alakzat 3D jelenetét vezérli.

Szöveghez használd a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/three_d_format/) tulajdonságot. Ez a 3D formázást a szövegkeretre alkalmazza az alakzat testének helyett.

A legfontosabb tulajdonságok:

| Tulajdonság | Mit vezérel | Mikor kell használni |
|---|---|---|
| [camera](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/camera/) | Nézőpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Az objektum forgatása 3D térben vagy a PowerPoint 3D forgatás előre beállított értékének egyezése. |
| [light_rig](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/light_rig/) | Világítás előbeállítás, irány és fény forgatás. | Megváltoztatja, hogy a csillogások és árnyékok hogyan jelennek meg a 3D felületen. |
| [material](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/material/) | Felületi anyag, például lapos, matt, műanyag vagy fém. | Ugyanazt a geometriát laposabbá, lágyabbá, fényesebbé vagy fémessé teszi. |
| [extrusion_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/extrusion_height/) | Mennyire nyúlik ki az alakzat hátrafelé az előoldalától. | Lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [extrusion_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/extrusion_color/) | Az extrudált oldalak színe. | A mélység láthatóvá tétele vagy az oldal színének összehangolása az előoldali kitöltéssel. |
| [depth](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/depth/) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatok vagy szövegek esetén, különösen rézsút és anyag beállításokkal együtt. |
| [bevel_top](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/bevel_bottom/) | Felpontozott vagy lekerekített élek az elő- és hátoldalon. | Puhább vagy formázott él hozzáadása egy éles, lapos felület helyett. |
| [contour_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/contour_width/) | Kontúr színe és szélessége a 3D objektum körül. | Kiemeli az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzathoz általában négyféle beállításra van szükség, mielőtt meggyőzően 3D‑snek tűnik:

- Kamera beállítások, mivel az alapértelmezett előnézet elrejtheti az extrudálást.
- Világítás beállítások, mivel a fények teszik olvashatóvá az felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja a fény ábrázolását.
- Extrudálás vagy mélység beállítások, mivel egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad hozzá az előoldalához, és alkalmaz 3D formázást. A kamera forgatási értékek fokban vannak megadva, az extrudálási magasság 100 pont. A példa a diát PNG képre rendereli a kétszeres alapméretben, és a prezentációt PPTX formátumban menti.

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

A renderelt diakép a téglalapot vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel az előoldalon](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a 3‑D Forgatás panelen állítható be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑val beállított forgatásnak.

![PowerPoint 3‑D Forgatás panel, X, Y és Z forgatási értékek kiemelve](img_02_01.png)

In Aspose.Slides‑ban a kamerát a [ThreeDFormat.camera](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/camera/) segítségével érheted el. Ez a példa egy téglalapot hoz létre, ortográfiai elölnézetet választ, és az X, Y, Z forgatásait 20, 30 és 40 fokra állítja. A shape-et a memóriában konfigurálja fájl mentése nélkül:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Használd a kamerát, amikor meg kell változtatni, hogy a néző hogyan látja az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot módosítja.

## **Extrudálás és mélység hozzáadása**

Az extrudálás egy alakzatot vastagabbá tesz, ha kinyújtja azt az előoldal mögé. PowerPointban a mélység vezérlés beállítja ezt a látható vastagságot, a szín vezérlés pedig az oldal felületek színét.

![PowerPoint mélység beállítások leképezve az extrudálás szín és magasság tulajdonságokra](img_02_02.png)

Állítsd be a [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/extrusion_height/) a vastagsághoz és a [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/extrusion_color/) az oldal színéhez. Ez a példa egy 100 pontos extrudálással és bíbor oldalakkal ellátott téglalapot ad, és a kamerát forgatja, hogy látható legyen a vastagság. A shape-et memóriában konfigurálja fájl mentése nélkül:

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

A [ThreeDFormat.depth](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/depth/) tulajdonság állítja be egy 3D alakzat mélységét. Az [extrusion_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/extrusion_height/) tulajdonság szabályozza az extrudálás magasságát, ahogy a példában látható.

## **Színátmenetes vagy képes kitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhatsz egy egyenletes színt, színátmenetet, mintát vagy képes kitöltést az előoldalon, és ugyanazt a kamera, fény, anyag és extrudálás beállításokat használhatod.

Ez a példa kék‑narancssárga színátmenetet alkalmaz az előoldalon és sötét narancssárga színt a 150 pontos extrudáláshoz. A színátmenet állomásai 0‑nál és 100‑nál jelölik a kezdetet és a végét. A kamera forgatási értékek fokban vannak. A dia PNG képre renderelődik a kétszeres alapméretben:

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

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

A képes kitöltés használatához add hozzá a képet a prezentációhoz, és rendeld hozzá az alakzat kitöltéséhez. Ez a példa feltételezi, hogy a munkakönyvtárban létezik egy „image.jpg” nevű fájl. A képet kinyújtja a téglalap kitöltéséhez, 150 pont extrudálást alkalmaz, és a kamera forgatását fokokban állítja. A shape-et memóriában konfigurálja mentés vagy renderelés nélkül:

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

![Renderelt 3D téglalap fotó kitöltéssel az előoldalon és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testét érinti. A szöveg 3D formázása a szövegkeretet. Ez hasznos WordArt‑szerű hatásokhoz, ahol maguk a betűk is extrudálásra, anyagra, megvilágításra és kamera beállításokra van szükségük.

A következő példa szöveget hoz létre narancs‑fehér rácsmintával, felfelé ívelt ívet alkalmaz, és 3D beállításokat konfigurál a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/three_d_format/) segítségével. Az extrudálási magasság és mélység pontban van megadva, a fény forgatás fokban. A shape kitöltése és kontúrja el van rejtve, hogy csak a szöveg látszódjon. A példa egy PNG képet renderel a diák alapméretének kétszeresére, és a prezentációt PPTX formátumban menti:

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

![Renderelt 3D szöveg ívelt WordArt transzformációval, narancs mintás kitöltéssel és sötét extrudálással](img_02_05.png)

## **Szöveg lapos tartása 3D alakzaton**

Ahhoz, hogy a szöveg olvasható maradjon, miközben az alakzat 3D megjelenése megmarad, állítsd be a [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/keep_text_flat/) a [TextFrame.text_frame_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/text_frame_format/) segítségével. Amikor az érték `True`, a szöveg kívül marad a 3D színen. Amikor `False`, a szöveg részt vesz a színen és követi annak 3D orientációját.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, megvilágítás, anyag és extrudálás továbbra is a [Shape.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/three_d_format/) segítségével van beállítva. Emellett különbözik a szokásos forgatástól. A [Shape.rotation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/rotation/) az alakzatot a diasíkban forgatja, míg a [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/rotation_angle/) a szöveg egyéni forgatását vezérli a saját keretében. A szöveg 3D színből való kizárása nem állítja vissza ezen szögek egyikét sem.

A következő önálló példa egy kék téglalapot hoz szöveggel, és klónozza azt az eredeti mellé. Mindkét alakzat ugyanazt a 3D formázást kapja; csak a szöveg beállítása különbözik: `False` balra és `True` jobbra. A kamera szöge fokban, az extrudálási magasság 40 pont. A példa a prezentációt PPTX formátumban menti, és a összehasonlító diát PNG képre rendereli a kétszeres alapméretben.

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

Bal oldalon a szöveg a 3D orientációt követi. Jobb oldalon lapos marad, így könnyebben olvasható. Mindkét téglalap a ugyanazt az extrudálást és 3D orientációt mutatja.

![Egymás mellé helyezett 3D téglalapok: keep_text_flat hamis bal oldalon és igaz jobb oldalon](keep_text_flat.png)

## **Exportálás és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be ment. Renderelés vagy exportálás rögzített elrendezésű formátumokba esetén a 3D jelenet rasterizálódik vagy a kimenetbe 2D eredményként rajzolódik. Ez akkor is érvényes, ha a diákat a [PNG](/slides/hu/python-net/convert-powerpoint-to-png/), exportálod a [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/), exportálod a [HTML](/slides/hu/python-net/convert-powerpoint-to-html/), vagy [videó konverzió](/slides/hu/python-net/convert-powerpoint-to-video/) képkockáira konvertálod.

Vedd figyelembe a következő pontokat:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja forgatni az export után.
- A végső megjelenés a kamera, fényrig, anyag, extrudálás, kitöltés és dia méretezés kombinációjától függ.
- Ha örökölt vagy témán alapuló formázási értékeket kell ellenőrizned, olvasd el a [hatékony alakzat tulajdonságok](/slides/hu/python-net/shape-effective-properties/).
- Néhány kimeneti formátum nem képes tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelt, nem szerkeszthető 3D beállításként megőrzött.

## **GYIK**

**Készíthet‑e az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásokat alakzatokra és szövegre. Nem teszi az exportált képeket, PDF‑eket vagy HTML oldalakat interaktív 3D jelenetté, amelyet a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

Egy 3D modell egy különálló 3D objektum, amely a prezentációba van beillesztve. Egy 3D hatás egy normál PowerPoint alakzatra vagy szövegre alkalmazott formázás, mint például forgatás, extrudálás, rézsút, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Minimum egy kamera forgatás és akár extrudálás vagy mélység beállítása. Gyakorlatban egy fényrig és anyag beállítása is ajánlott, hogy a renderelt felületeknek tiszta fény‑ és árnyékhatása legyen.

**Alkalmazhatok‑e 3D hatásokat alakzatokra és szövegre egyaránt?**

Igen. Használd a [Shape.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/three_d_format/) az alakzat testére és a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/three_d_format/) a szövegre.

**Megjelennek‑e a 3D hatások exportáláskor képekre, PDF‑re, HTML‑re vagy videó képkockákra?**

Igen. Az Aspose.Slides rendereli a 3D hatásokat a diaképek, PDF, HTML kimenetek és videó konverzióhoz használt képkockák létrehozásakor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Ki tudom olvasni a végső 3D értékeket az öröklődés és a téma beállítások alkalmazása után?**

Igen. Használd a hatékony formázási API‑kat, amelyeket az [Alakzat hatékony tulajdonságai](/slides/hu/python-net/shape-effective-properties/) leírásában találsz a végleges kamera, fényrig, rézsút és kapcsolódó 3D értékek olvasásához.