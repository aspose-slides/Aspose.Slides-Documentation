---
title: Vytvoření 3D efektů v prezentacích pomocí Pythonu
linktitle: 3D Prezentace
type: docs
weight: 232
url: /cs/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D rotace
- 3D hloubka
- 3D extruze
- 3D přechod
- 3D text
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použijte a vykreslete 3D efekty pro tvary a text v PowerPointu v Pythonu prostřednictvím Javy s Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro Python prostřednictvím Javy může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek se zabývá 3D efekty jako rotace, extruze, zkosení, osvětlení, materiál, gradientní nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se zabývá 3D formátovacími efekty na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných 3D modelových souborů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

Balíček nainstalujte podle pokynů v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides`, spustí JVM, pokud je to potřeba, a poté importuje API. Příklad s výplní obrázkem vyžaduje soubor `image.jpg` v pracovním adresáři.

## **Koncepty 3D formátování**

Použijte [Shape.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getThreeDFormat) k použití 3D formátování na tvar. Vrácený objekt formátu řídí 3D scénu pro tento tvar.

Pro text použijte [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#getThreeDFormat). Tím se použije 3D formátování na textový rámec místo těla tvaru.

Nejdůležitějšími členy API jsou:

| Člen API | Co ovládá | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getCamera) | Pohled, přednastavený typ kamery, rotace, zoom a perspektiva. | Rotujte objekt ve 3D prostoru nebo použijte přednastavený 3D rotaci PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getLightRig) | Přednastavení světla, směr a rotace světla. | Změňte, jak se na 3D povrchu zobrazují zvýraznění a stíny. |
| [getMaterial](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getMaterial) a [setMaterial](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setMaterial) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Nechte stejnou geometrii vypadat plošší, měkčí, lesklejší nebo kovově. |
| [getExtrusionHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getExtrusionHeight) a [setExtrusionHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko tvar zasahuje dozadu od své přední plochy. | Přeměňte plochý tvar na viditelně tlustý 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getExtrusionColor) | Barva extrudovaných stran. | Zobrazte hloubku nebo sladíte barvu stran s výplní přední plochy. |
| [getDepth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getDepth) a [setDepth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setDepth) | Další 3D hloubka používaná PowerPoint 3D formátováním. | Jemně doladíte hloubku pro tvary nebo text, zejména spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getBevelTop) a [getBevelBottom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getBevelBottom) | Vyvýšené nebo zaoblené hrany na předních a zadních plochách. | Přidejte změkčený nebo formovaný okraj místo ostré ploché plochy. |
| [getContourColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getContourWidth) a [setContourWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setContourWidth) | Obrys kolem 3D objektu. | Zdůrazněte hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení světla, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak je světlo vykresleno.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu, použije 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vykreslený obrázek snímku zobrazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední ploše](img_01_01.png)

## **Rotace tvaru pomocí kamery**

V PowerPointu se 3‑D rotace nastavuje v panelu 3‑D rotace. Hodnoty rotace X, Y a Z odpovídají rotaci, kterou nastavíte přes API kamery.

![Panel 3‑D rotace v PowerPointu se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides nastavte typ kamery a rotaci přes 3D formát vrácený metodou [Shape.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getThreeDFormat):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Použijte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění geometrii 2D tvaru na snímku. Mění 3D pohled, který používá PowerPoint i Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě tím, že ho prodlouží za přední plochu. V PowerPointu řídí ovládání hloubky tuto viditelnou tloušťku a ovládání barvy nastavuje barvu bočních ploch.

![Ovládání hloubky v PowerPointu přiřazené k vlastnostem barvy extruze a výšky extruze](img_02_02.png)

Nastavte výšku extruze pro tloušťku a barvu extruze pro barvu stran:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Použijte nastavení hloubky, když potřebujete pracovat přímo s hodnotou hloubky v PowerPointu nebo kombinovat hloubku se zkosením, materiálem a textovými efekty. V mnoha scénářích tvaru je výška extruze srozumitelnější nastavení, protože přímo vyjadřuje viditelnou extruzi.

## **Použití gradientních nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít plnou barvu, gradient, vzor nebo obrázkovou výplň na přední plochu a přitom stále použít stejné nastavení kamery, světla, materiálu a extruze.

Tento příklad použije gradientní výplň na tvar a tmavší barvu extruze na strany:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

Vykreslený výstup zachovává gradient na přední ploše a samostatně vykresluje extruzi:

![Vykreslený 3D obdélník s modro‑oranžovým gradientní výplní a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej jako výplň tvaru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Obrázek se vykreslí na přední plochu, zatímco extruze se vykreslí jako 3D bočná plocha:

![Vykreslený 3D obdélník s fotografickou výplní na přední ploše a oranžovou extruzí](img_02_04.png)

## **Použití 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s výplní vzoru, použije transformaci WordArt a nakonfiguruje 3D nastavení na [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Text se vykreslí jako zakřivené, extrudované 3D písmo:

![Vykreslený 3D text s obloukovou transformací WordArt, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Chování při exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevným rozložením je 3D scéna rasterizována nebo nakreslena do výstupu jako 2D výsledek. Toto platí, když vykreslujete snímky do PNG, exportujete do PDF, exportujete do HTML nebo generujete snímky pro konverzi videa.

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zkontrolovat děděné nebo na motivu založené hodnoty formátování, použijte API efektivního formátování.
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslen místo uložen jako editovatelné 3D nastavení.

## **FAQ**

**Může Aspose.Slides vytvářet interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by mohl divák otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje editaci.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je rotace, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou vyžadována pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi nebo hloubku. V praxi také nastavte osvětlení a materiál, aby vykreslené plochy měly jasná zvýraznění a stíny.

**Mohu použít 3D efekty na tvary i na text?**

Ano. Použijte [Shape.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getThreeDFormat) pro tělo tvaru a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#getThreeDFormat) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykresluje 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímcích používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení motivu?**

Ano. Použijte [ThreeDFormat.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getEffective) ke čtení konečných hodnot kamery, osvětlení, zkosení a souvisejících 3D hodnot.