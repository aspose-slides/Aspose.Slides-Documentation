---
title: Vytvořte 3D efekty v prezentacích pomocí Pythonu
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D otáčení
- 3D hloubka
- 3D extruze
- 3D přechod
- 3D text
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Použijte a vykreslete 3D efekty pro tvary a text v PowerPointu v Pythonu s Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro Python pomocí .NET může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek se zabývá 3D efekty, jako jsou otáčení, extruze, zkosení, osvětlení, materiál, gradientové nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se zabývá 3D formátovacími efekty na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných 3D modelových souborů. Při exportu snímku do obrázku, PDF nebo HTML Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte vlastnost [Shape.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/three_d_format/) k aplikaci 3D formátování na tvar. Vlastnost poskytuje [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/), který řídí 3D scénu pro tento tvar.

Pro text použijte vlastnost [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/three_d_format/). Tím se aplikuje 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější vlastnosti jsou:

| Property | Co řídí | Kdy použít |
|---|---|---|
| [camera](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/camera/) | Pohled, přednastavený typ kamery, otáčení, přiblížení a perspektiva. | Otáčejte objekt ve 3D prostoru nebo použijte přednastavený 3D otáčení PowerPointu. |
| [light_rig](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/light_rig/) | Přednastavení světla, směr a otáčení světla. | Změňte, jak se zvýraznění a stíny zobrazují na 3D povrchu. |
| [material](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/material/) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Nechte stejnou geometrii vypadat plošší, měkčí, lesklejší nebo kovově. |
| [extrusion_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/extrusion_height/) | Jak daleko se tvar rozšiřuje dozadu od přední plochy. | Proměňte plochý tvar na viditelně silný 3D objekt. |
| [extrusion_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/extrusion_color/) | Barva extrudovaných stran. | Udělejte hloubku viditelnou nebo sladte barvu stran s výplní přední strany. |
| [depth](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/depth/) | Další 3D hloubka používaná formátováním 3D v PowerPointu. | Jemně doladěte hloubku pro tvary nebo text, zejména v kombinaci se zkosením a nastavením materiálu. |
| [bevel_top](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/bevel_top/) a [bevel_bottom](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/bevel_bottom/) | Vyzvednuté nebo zaoblené hrany na přední a zadní straně. | Přidejte změkčený nebo tvarovaný okraj místo ostré ploché strany. |
| [contour_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/contour_color/) a [contour_width](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/contour_width/) | Obrys kolem 3D objektu. | Zvýrazněte hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí pohled zepředu může skrýt extruzi.
- Nastavení osvětlení, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na přední stranu a použije 3D formátování. Hodnoty otáčení kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku při dvojnásobné výchozí velikosti a uloží prezentaci jako PPTX.

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

Vykreslený snímek ukazuje obdélník jako silný 3D blok:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Otočení tvaru pomocí kamery**

V PowerPointu se 3D otáčení konfiguruje v panelu 3‑D Rotation. Hodnoty otáčení X, Y a Z odpovídají otáčení nastavenému přes API kamery.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

V Aspose.Slides získáte kameru přes [ThreeDFormat.camera](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/camera/). Tento příklad vytvoří obdélník, vybere ortografický pohled zepředu a nastaví otáčení X, Y a Z na 20, 30 a 40 stupňů. Konfiguruje tvar v paměti bez uložení souboru:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Použijte kameru, když potřebujete změnit, jak divák objekt vidí. Nemění 2D geometrii tvaru na snímku. Mění 3D pohled, který používá PowerPoint i Aspose.Slides při renderování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá silně, protože se prodlouží za přední stranu. V PowerPointu kontrola hloubky nastavuje tuto viditelnou tloušťku a kontrola barvy určuje barvu bočních ploch.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Nastavte [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/extrusion_height/) pro tloušťku a [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/extrusion_color/) pro barvu stran. Tento příklad dává obdélníku extruzi 100 bodů s fialovými stranami a otáčí kameru, aby odhalila jeho tloušťku. Konfiguruje tvar v paměti bez uložení souboru:

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

Vlastnost [ThreeDFormat.depth](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/depth/) určuje hloubku 3D tvaru. Vlastnost [extrusion_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/extrusion_height/) řídí výšku efektu extruze, jak ukazuje tento příklad.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít jednobarevnou výplň, gradient, vzor nebo obrázkovou výplň na přední stranu a stále použít stejná nastavení kamery, osvětlení, materiálu a extruze.

Tento příklad aplikuje modro‑oranžový gradient na přední stranu a tmavě oranžovou barvu na extruzi 150 bodů. Gradientové zastavení při 0 % a 100 % označují začátek a konec gradientu. Hodnoty otáčení kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku při dvojnásobné výchozí velikosti:

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

Vykreslený výstup zachovává gradient na přední straně a extruzi vykresluje odděleně:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Chcete‑li místo toho použít obrázkovou výplň, přidejte obrázek do prezentace a přiřaďte jej výplni tvaru. Tento příklad vyžaduje existující soubor s názvem "image.jpg" v pracovní složce. Obrázek roztáhne tak, aby vyplnil obdélník, aplikuje extruzi 150 bodů a nastaví otáčení kamery ve stupních. Konfiguruje tvar v paměti bez uložení nebo renderování souboru:

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

Obrázek je vykreslen na přední straně, zatímco extruze je vykreslena jako 3D boční povrch:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Aplikace 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým mřížkovým vzorem, aplikuje zakřivený oblouk a nastaví 3D parametry přes [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/three_d_format/). Výška extruze a hloubka jsou v bodech, otáčení světla ve stupních. Výplň a obrys tvaru jsou skryty, aby byl viditelný pouze text. Příklad vykreslí PNG obrázek při dvojnásobné výchozí velikosti snímku a uloží prezentaci jako PPTX:

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

Text je vykreslen jako zakřivené, extrudované 3D písmo:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Udržení textu plochého na 3D tvaru**

Chcete‑li, aby byl text čitelný při zachování 3D vzhledu tvaru, nastavte [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/keep_text_flat/) přes [TextFrame.text_frame_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/text_frame_format/). Když je hodnota `True`, text zůstane mimo 3D scénu. Když je `False`, text se zapojí do scény a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: jeho kamera, osvětlení, materiál a extruze zůstávají nastaveny přes [Shape.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/three_d_format/). Je to také odlišné od běžného otáčení. [Shape.rotation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/rotation/) otáčí tvar v rovině snímku, zatímco [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/rotation_angle/) řídí vlastní otáčení textu v jeho ohraničujícím rámečku. Udržení textu mimo 3D scénu nerese žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zkopíruje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se jen nastavením textu: `False` vlevo a `True` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG při dvojnásobné výchozí velikosti.

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

Vlevo text následuje 3D orientaci. Vpravo zůstává plochý a snadněji čitelný. Oba obdélníky si zachovávají stejnou viditelnou extruzi a 3D orientaci.

![Side-by-side 3D rectangles: keep_text_flat is False on the left and True on the right](keep_text_flat.png)

## **Chování exportu a renderování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při renderování nebo exportu do formátů s pevnou stránkou se 3D scéna rasterizuje nebo nakreslí do výstupu jako 2D výsledek. Toto platí při renderování snímků do [PNG](/slides/cs/python-net/convert-powerpoint-to-png/), exportu do [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), exportu do [HTML](/slides/cs/python-net/convert-powerpoint-to-html/), nebo generování snímků pro [video conversion](/slides/cs/python-net/convert-powerpoint-to-video/).

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zkontrolovat zděděné nebo tematické hodnoty formátování, přečtěte si [effective shape properties](/slides/cs/python-net/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslený místo toho, aby byl zachován jako editovatelné 3D nastavení.

## **Časté dotazy**

**Může Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML, které by uživatel mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje tuto funkci.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako jsou otáčení, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá právě 3D efekty.

**Jaké nastavení je vyžadováno pro viditelný 3D tvar?**

Minimálně nastavte otáčení kamery a buď extruzi, nebo hloubku. V praxi je také vhodné nastavit osvětlení a materiál, aby byly vykreslené plochy dobře osvětlené a měly jasné zvýraznění a stíny.

**Mohu aplikovat 3D efekty na tvary i text?**

Ano. Použijte [Shape.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/three_d_format/) pro tělo tvaru a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/three_d_format/) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykreslí 3D efekty při vytváření obrázků snímků, PDF, HTML a snímků používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, ne editovatelný 3D objekt.

**Mohu si přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení motivu?**

Ano. Použijte API pro efektivní formátování popsané v [Shape Effective Properties](/slides/cs/python-net/shape-effective-properties/), abyste získali konečnou hodnotu kamery, osvětlení, zkosení a souvisejících 3D parametrů.