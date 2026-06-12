---
title: Vytvoření 3D efektů v prezentacích pomocí Pythonu
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D rotace
- 3D hloubka
- 3D extruze
- 3D gradient
- 3D text
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Aplikujte a renderujte 3D efekty pro tvary a text v PowerPointu v Pythonu pomocí Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides for Python via .NET může vytvářet, upravovat, zachovávat a renderovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek popisuje 3D efekty jako rotaci, extruzi, zkosení, osvětlení, materiál, gradientní nebo obrázkové výplně a 3D text.

{{% alert color="primary" %}}
Tento článek se zabývá 3D formátovacími efekty na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte vlastnost [Shape.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/three_d_format/) k aplikaci 3D formátování na tvar. Tato vlastnost poskytuje [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/), která řídí 3D scénu pro tento tvar.

Pro text použijte vlastnost [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/three_d_format/). Tím se aplikuje 3D formátování na textový rámeček místo těla tvaru.

Nejdůležitější vlastnosti jsou:

| Vlastnost | Co řídí | Kdy použít |
|---|---|---|
| [camera](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/camera/) | Pohled, přednastavený typ kamery, rotace, zoom a perspektiva. | Otočte objekt ve 3D prostoru nebo použijte přednastavený 3D rotaci PowerPointu. |
| [light_rig](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/light_rig/) | Přednastavení světla, směr a rotace světla. | Změňte, jak se odlesky a stíny objevují na 3D povrchu. |
| [material](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/material/) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Nechte stejnou geometrii vypadat plochěji, měkčeji, leskleji nebo kovově. |
| [extrusion_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/extrusion_height/) | Jak daleko tvar zasahuje dozadu od své přední plochy. | Přeměňte plochý tvar na viditelně tlustý 3D objekt. |
| [extrusion_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/extrusion_color/) | Barva extrudovaných stran. | Zobrazte hloubku nebo sladěte barvu stran s výplní přední plochy. |
| [depth](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/depth/) | Další 3D hloubka používaná v PowerPoint 3D formátování. | Jemně doladit hloubku pro tvary nebo text, zejména ve spojení s nastavením zkosení a materiálu. |
| [bevel_top](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/bevel_top/) a [bevel_bottom](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/bevel_bottom/) | Vyvýšené nebo zaoblené hrany na přední a zadní ploše. | Přidejte zjemněný nebo tvarovaný okraj místo ostré ploché stěny. |
| [contour_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/contour_color/) a [contour_width](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/contour_width/) | Obrys kolem 3D objektu. | Zdůrazněte hranici objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení osvětlení, protože osvětlení zpřehlední plochy a strany.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu, aplikuje 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

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

Vykreslený obrázek snímku ukazuje obdélník jako tlustý 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední ploše](img_01_01.png)

## **Otočení tvaru pomocí kamery**

V PowerPointu se 3D rotace nastavuje v podokně 3‑D Rotace. Hodnoty rotace X, Y a Z odpovídají rotaci nastavené pomocí API kamery.

![Podokno 3‑D rotace v PowerPointu se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides nastavte typ kamery a rotaci pomocí [ThreeDFormat.camera](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Použijte kameru, když potřebujete změnit, jak divák objekt vidí. Nemění 2D geometrii tvaru na snímku. Mění 3D úhel pohledu, který používá PowerPoint i Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě tím, že se rozšíří za přední plochu. V PowerPointu ovládací prvek hloubky nastavuje tuto viditelnou tloušťku a ovládací prvek barvy nastavuje barvu bočních ploch.

![Ovládací prvky hloubky v PowerPointu mapované na vlastnosti barvy extruze a výšky extruze](img_02_02.png)

Nastavte [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/extrusion_height/) pro tloušťku a [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/extrusion_color/) pro barvu stran:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Použijte [ThreeDFormat.depth](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/depth/), když potřebujete pracovat přímo s hodnotou hloubky v PowerPointu nebo kombinovat hloubku s zkosením, materiálem a textovými efekty. V mnoha scénářích tvarů je [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/extrusion_height/) přehlednější nastavení, protože přímo vyjadřuje viditelnou extruzi.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Na přední plochu můžete aplikovat plnou barvu, gradient, vzor nebo obrázkovou výplň a přitom používat stejná nastavení kamery, světla, materiálu a extruze.

Tento příklad aplikuje gradientní výplň na tvar a tmavší barvu extruze na strany:

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

Vykreslený výstup zachová gradient na přední ploše a extruzi vykreslí zvlášť:

![Vykreslený 3D obdélník s modro‑oranžovým gradientem výplně a oranžovou extruzí](img_02_03.png)

Chcete‑li místo toho použít obrázkovou výplň, přidejte obrázek do prezentace a přiřaďte jej jako výplň tvaru:

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

Obrázek je vykreslen na přední ploše, zatímco extruze je vykreslena jako 3D boční povrch:

![Vykreslený 3D obdélník s fotografickou výplní na přední ploše a oranžovou extruzí](img_02_04.png)

## **Aplikace 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámeček. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s výplní vzorem, aplikuje WordArt transformaci a nastaví 3D parametry na [TextFrameFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/):

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

![Vykreslený 3D text s obloukovou WordArt transformací, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Chování exportu a renderování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při renderování nebo exportu do formátů s pevnou rozvržením se 3D scéna rasterizuje nebo nakreslí do výstupu jako 2D výsledek. To platí, když renderujete snímky do [PNG](/slides/cs/python-net/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/python-net/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/python-net/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a škálování snímku.
- Pokud potřebujete zkontrolovat zděděné nebo tématem podmíněné hodnoty formátování, přečtěte [effective shape properties](/slides/cs/python-net/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné PowerPoint 3D formátování. V těchto formátech je vizuální výsledek renderován místo toho, aby byl zachován jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvářet interaktivní 3D prezentace?**

Aspose.Slides vytváří a renderuje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát tuto možnost podporuje.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, například rotace, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou potřeba pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi nebo hloubku. V praxi také nastavte osvětlení a materiál, aby vykreslené plochy měly zřetelné odlesky a stíny.

**Mohu použít 3D efekty jak na tvary, tak na text?**

Ano. Použijte [Shape.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/three_d_format/) pro tělo tvaru a [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/three_d_format/) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides renderuje 3D efekty při vytváření obrázků snímků, výstupu PDF, HTML a snímků použitého pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení motivu?**

Ano. Použijte API efektivního formátování popsané v [Shape Effective Properties](/slides/cs/python-net/shape-effective-properties/) pro získání konečných hodnot kamery, osvětlení, zkosení a souvisejících 3D hodnot.