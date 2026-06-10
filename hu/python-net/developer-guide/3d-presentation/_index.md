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
- 3D extrúzió
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D hatásokat a PowerPoint alakzatokra és szövegre Pythonban az Aspose.Slides segítségével. Állítsa be a kamerát, megvilágítást, anyagot, extrúziót, kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Aspose.Slides for Python via .NET képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint-szerű 3D formázást alakzatok és szöveg esetén. Ez a cikk olyan 3D hatásokat tárgyal, mint a forgatás, extrúzió, élezés, megvilágítás, anyag, színátmenet vagy kép kitöltés, valamint a 3D szöveg.

{{% alert color="primary" %}}

Ez a cikk a PowerPoint alakzatokon és szövegen alkalmazott 3D formázási hatásokról szól. Nem a önálló 3D modellfájlok beszúrásáról vagy szerkesztéséről van szó. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides a 3D hatásokat az exportált 2D kimenetbe rendereli.

{{% /alert %}}

## **3D formázási koncepciók**

Használja a [Shape.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/three_d_format/) tulajdonságot 3D formázás alkalmazásához egy alakzatra. A tulajdonság a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) objektumot adja vissza, amely a forma 3D jelenetét szabályozza.

Szöveghez használja a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/three_d_format/) tulajdonságot. Ez a szövegdobozra alkalmaz 3D formázást a forma testének helyett.

A legfontosabb tulajdonságok:

| Tulajdonság | Mit szabályoz | Mikor használjuk |
|---|---|---|
| [camera](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/camera/) | Nézőpont, előre definiált kamera típus, forgatás, zoom és perspektíva. | Forgassa a tárgyat 3D térben vagy egyeztesse a PowerPoint 3D forgatás előre definiált beállításával. |
| [light_rig](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/light_rig/) | Fény előre definiált, irány és fény forgatás. | Módosítsa, hogyan jelennek meg a fények és árnyékok a 3D felületen. |
| [material](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/material/) | Felületi anyag, például lapos, matt, műanyag vagy fém. | Tegye a geometriai alakzatot laposabbá, puhábbá, fényesebbé vagy fémesebbé. |
| [extrusion_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/extrusion_height/) | Mennyire nyúlik ki a forma hátra az előlapjától. | Alakítson egy lapos formát láthatóan vastag 3D objektummá. |
| [extrusion_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/extrusion_color/) | Az extrudált oldalak színe. | Tegye a mélységet láthatóvá vagy illessze az oldal színét a front kitöltéshez. |
| [depth](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/depth/) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a rézsút és anyag beállításokkal együtt. |
| [bevel_top](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/bevel_top/) és [bevel_bottom](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/bevel_bottom/) | Felső vagy alsó él emelkedett vagy lekerekített a front és hát felületeken. | Adj egy puhított vagy formázott élt a szúrós, lapos felület helyett. |
| [contour_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/contour_color/) és [contour_width](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/contour_width/) | Körvonal színe a 3D objektum körül. | Emelje ki az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, hogy hihetően 3D-snek tűnjön:

- Kamera beállítások, mert az alapértelmezett előnézet elrejtheti az extrúziót.
- Fény beállítások, mert a megvilágítás teszi olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mert egy lapos alakzatnak vastagságra van szüksége.

Az alábbi példa egy téglalapot hoz létre, szöveget ad hozzá az előlapjához, alkalmaz 3D formázást, PPTX‑ként menti a prezentációt, és a diát PNG képként rendereli.

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

![Renderelt kék 3D téglalap fehér 3D szöveggel az előlapon](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a „3‑D Rotation” panelről állítható be. Az X, Y és Z forgatási értékek a kamera API‑n keresztül beállított forgatásnak felelnek meg.

![PowerPoint 3D forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides‑ben a kamera típusát és forgatását a [ThreeDFormat.camera](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/camera/) segítségével állíthatja be:

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Használja a kamerát, ha meg szeretné változtatni, hogy a néző hogyan látja az objektumot. Ez nem változtatja meg a 2D alakzatterület geometriáját a dián, csak a PowerPoint és az Aspose.Slides által a rendereléskor használt 3D nézőpontot.

## **Extrúzió és mélység hozzáadása**

Az extrúzió egy alakzatot vastagnak mutat azáltal, hogy kinyújtja azt a front felület mögé. PowerPointban a mélység vezérlő határozza meg ezt a látható vastagságot, a szín vezérlő pedig az oldalfelületek színét.

![PowerPoint mélység beállítások leképezve az extrúzió színre és extrúzió magasság tulajdonságokra](img_02_02.png)

Állítsa be a [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/extrusion_height/) értékét a vastagságra, és a [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/extrusion_color/) értékét az oldal színére:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Használja a [ThreeDFormat.depth](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/depth/) tulajdonságot, ha közvetlenül a PowerPoint mélységértékével szeretne dolgozni, vagy a mélységet rézsúttal, anyaggal és szöveghatásokkal kombinálni. Sok alakzatszituációban a [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/extrusion_height/) egyértelműbb beállítás, mert közvetlenül a látható extrúziót fejezi ki.

## **Gradiens vagy képi kitöltések használata 3D hatásokkal**

A 3D formázás független a forma kitöltésétől. Alkalmazhat szilárd színt, színátmenetet, mintát vagy kép kitöltést az előlapra, miközben ugyanazokat a kamera-, fény-, anyag- és extrúzióbeállításokat használja.

Ez a példa színátmenet kitöltést alkalmaz a formára, és sötétebb extrúziószínt az oldalakon:

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

A renderelt kimenet megőrzi a színátmenetet az előlapon, és az extrúziót külön rendereli:

![Renderelt 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

Ha kép kitöltést szeretne használni, adja hozzá a képet a prezentációhoz, és rendelje hozzá a forma kitöltéséhez:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

A kép az előlapon jelenik meg, míg az extrúzió a 3D oldalfelületként renderelődik:

![Renderelt 3D téglalap fotó kitöltéssel az előlapon és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása a forma testére vonatkozik. A szöveg 3D formázása a szövegdobozra. Ez hasznos WordArt‑szerű hatásokhoz, ahol a betűknek maguknak is szükségük van extrúzióra, anyagra, megvilágításra és kamera beállításokra.

Az alábbi példa szöveget hoz létre minta kitöltéssel, alkalmaz WordArt transzformációt, és beállítja a 3D paramétereket a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/) számára:

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

A szöveg ívelt, extrudált 3D betűként jelenik meg:

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga minta kitöltéssel és sötét extrúzióval](img_02_05.png)

## **Exportálás és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba (például PPTX) ment. Fix elrendezésű formátumokba történő renderelés vagy exportálás során a 3D jelenet raszteres vagy 2D eredményként kerül be a kimenetbe. Ez akkor érvényes, amikor a diákat [PNG](/slides/hu/python-net/convert-powerpoint-to-png/)-re rendereli, [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/)-re exportál, [HTML](/slides/hu/python-net/convert-powerpoint-to-html/)-re exportál, vagy [videó konverzió](/slides/hu/python-net/convert-powerpoint-to-video/) kereteket generál.

Tartsa szem előtt a következőket:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a felhasználó az export után nem tudja forgatni.
- A végső megjelenés a kamera, fényrendszer, anyag, extrúzió, kitöltés és dia méretezés kombinációjától függ.
- Ha örökölt vagy sablon‑alapú formázási értékeket kell ellenőriznie, olvassa el a [Alakzat hatékony tulajdonságait](/slides/hu/python-net/shape-effective-properties/).
- Egyes kimeneti formátumok nem tárolhatják szerkeszthető PowerPoint 3D formázásukat. Ezekben a formátumokban a vizuális eredmény renderelt, nem szerkeszthető 3D beállításként.

## **GYIK**

**Létrehozhat-e az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides PowerPoint 3D hatásokat hoz létre és renderel alakzatok és szöveg számára. Nem teszi az exportált képeket, PDF‑eket vagy HTML‑lapokat interaktív 3D jelenetekké, amelyeket a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPoint‑ban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

A 3D modell egy különálló, a prezentációba beszúrt 3D objektum. A 3D hatás egy szabványos PowerPoint alakzaton vagy szövegen alkalmazott formázás, például forgatás, extrúzió, rézsút, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Minimum egy kamera forgatás és vagy extrúzió vagy mélység beállítása szükséges. Gyakorlatilag érdemes fényrendszert és anyagot is beállítani, hogy a renderelt felületeknek legyenek tiszta kiemelések és árnyékok.

**Alkalmazhatok‑e 3D hatásokat egyaránt alakzatokra és szövegre?**

Igen. Használja a [Shape.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/three_d_format/)‑t az alakzat testére és a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/three_d_format/)‑t a szövegre.

**Megjelennek‑e a 3D hatások exportáláskor képekre, PDF‑re, HTML‑re vagy videó keretekre?**

Igen. Az Aspose.Slides a 3D hatásokat rendereli, amikor diaképeket, PDF‑kimenetet, HTML‑kimenetet vagy videó konverzióhoz használt kereteket állít elő. Az exportált kimenet a renderelt megjelenést tartalmazza, nem egy szerkeszthető 3D objektumot.

**Ki tudom‑e olvasni a végleges 3D értékeket az öröklődés és a sablon beállítások alkalmazása után?**

Igen. Használja a hatékony formázási API‑kat, amelyeket a [Alakzat hatékony tulajdonságai](/slides/hu/python-net/shape-effective-properties/) leír, a végső kamera, fényrendszer, rézsút és kapcsolódó 3D értékek olvasásához.