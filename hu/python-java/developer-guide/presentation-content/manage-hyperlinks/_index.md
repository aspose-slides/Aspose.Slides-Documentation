---
title: Prezentációs hiperhivatkozások kezelése Pythonban Java segítségével
linktitle: Hiperhivatkozás kezelése
type: docs
weight: 20
url: /hu/python-java/manage-hyperlinks/
keywords:
- URL hozzáadása
- hiperhivatkozás hozzáadása
- hiperhivatkozás létrehozása
- hiperhivatkozás formázása
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- szöveges hiperhivatkozás
- dia hiperhivatkozás
- alakzat hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Könnyedén kezelheti a hiperhivatkozásokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java segítségével – fokozza az interaktivitást és a munkafolyamatot percek alatt."
---
## **Bevezetés**

A hiperhivatkozás egy objektumra, adatra vagy egy helyre való hivatkozás. Ezek gyakori hiperhivatkozások a PowerPoint‑prezentációkban:

* Weboldalakra mutató hivatkozások szövegekben, alakzatokban vagy médiában
* Dia hivatkozások

Az Aspose.Slides for Python via Java lehetővé teszi, hogy számos, hiperhivatkozásokkal kapcsolatos feladatot hajtson végre a prezentációkban. 

{{% alert color="info" title="Note" %}} 

Érdemes megnézni az egyszerű, [ingyenes online PowerPoint szerkesztőt.](https://products.aspose.app/slides/hu/editor)

{{% /alert %}} 

## **URL‑hiperhivatkozások hozzáadása**

### **URL‑hiperhivatkozások hozzáadása szöveghez**

Ez a Python‑kód bemutatja, hogyan lehet weboldal‑hiperhivatkozást hozzáadni egy szöveghez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **URL‑hiperhivatkozások hozzáadása alakzatokhoz vagy keretekhez**

Ez a példa Python via Java nyelven megmutatja, hogyan lehet weboldal‑hiperhivatkozást hozzáadni egy alakzathoz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **URL‑hiperhivatkozások hozzáadása médiához**

Az Aspose.Slides lehetővé teszi hiperhivatkozások hozzáadását képekhez, hang‑ és videofájlokhoz. 

Ez a példa bemutatja, hogyan lehet hiperhivatkozást hozzáadni egy **képhez**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
        # Képet ad hozzá a prezentációhoz
        image = Images.fromFile("image.png")
        try:
            picture = presentation.getImages().addImage(image)
        finally:
            image.dispose()
        # Képkockát hoz létre az 1. dián az előzőleg hozzáadott kép alapján
        picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

        picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
        picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

        presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ez a példa bemutatja, hogyan lehet hiperhivatkozást hozzáadni egy **hangfájlhoz**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ez a példa bemutatja, hogyan lehet hiperhivatkozást hozzáadni egy **videóhoz**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}} 

Érdemes megnézni a *[OLE kezelés](/slides/hu/python-java/manage-ole/)*.

{{% /alert %}}

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik objektumokra vagy helyekre való hivatkozás hozzáadását, ezeket felhasználhatja tartalomjegyzék létrehozásához. 

Ez a példa bemutatja, hogyan hozhat létre tartalomjegyzéket hiperhivatkozásokkal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hiperhivatkozások formázása**

### **Szín**

A [Hyperlink.setColorSource](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setColorSource) tulajdonsággal a [Hyperlink](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/) osztályban beállíthatja a hiperhivatkozások színét, illetve lekérdezheti a színinformációkat a hiperhivatkozásokból. Ez a funkció először a PowerPoint 2019‑ben került bevezetésre, így a tulajdonságra vonatkozó változások nem érvényesek a régebbi PowerPoint‑verziókra.

Ez a példa kód bemutat egy olyan műveletet, ahol különböző színű hiperhivatkozásokat adtak hozzá ugyanahhoz a diához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hiperhivatkozások eltávolítása a prezentációkból**

### **Hiperhivatkozások eltávolítása szövegből**

Ez a Python‑kód megmutatja, hogyan lehet eltávolítani a hiperhivatkozást egy szövegből egy prezentációs dián:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Hiperhivatkozások eltávolítása alakzatokból vagy keretekből**

Ez a Python‑kód megmutatja, hogyan lehet eltávolítani a hiperhivatkozást egy alakzatról egy prezentációs dián: 

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Módosítható hiperhivatkozás**

A [Hyperlink](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/) osztály módosítható. Ezzel az osztállyal megváltoztathatja az alábbi tulajdonságok értékeit:

- [setTargetFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

A kódrészlet bemutatja, hogyan adhat hiperhivatkozást egy diához, és később szerkesztheti annak eszköztippjét:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # Módosítja a már hozzáadott hiperhivatkozás eszköztippjét
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A HyperlinkQueries támogatott tulajdonságai**

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/) osztályt elérheti egy prezentációból, diámból vagy szövegből, amelyhez a hiperhivatkozás definiálva van. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getHyperlinkQueries)

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/) osztály támogatja a következő metódusokat és tulajdonságokat: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **GYIK**

**Hogyan hozhatok létre belső navigációt nem csak egy diára, hanem egy „szekcióra” vagy egy szekció első diájára?**

A PowerPoint szekciók a diák csoportosításai; a navigáció technikailag egy adott diára irányul. A „szekcióra navigáláshoz” általában annak első diájára kell hivatkozni.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és az elrendezés elemei támogatják a hiperhivatkozásokat. Az ilyen hivatkozások megjelennek a gyerekdiákon, és a vetítés során kattinthatók.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó formátumba exportáláskor?**

A [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/python-java/convert-powerpoint-to-html/) esetén igen – a hivatkozások általában megmaradnak. Képek ([képek](/slides/hu/python-java/convert-powerpoint-to-png/)) és videó ([videó](/slides/hu/python-java/convert-powerpoint-to-video/)) exportálásakor a kattinthatóság nem marad meg az adott formátumok (raszteres keretek/videó) természetéből adódóan, mivel nem támogatják a hiperhivatkozásokat.