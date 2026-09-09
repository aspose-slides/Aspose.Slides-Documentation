---
title: Prezentációs hiperhivatkozások kezelése Pythonon keresztül Java‑val
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
description: "Könnyedén kezelje a hiperhivatkozásokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java segítségével — fokozza az interaktivitást és a munkafolyamatot percek alatt."
---
## **Bevezetés**

A hiperhivatkozás egy objektumra, adatra vagy helyre mutató hivatkozás. A PowerPoint‑prezentációkban gyakori hiperhivatkozások a következők:

* Weboldalakra mutató hivatkozások szövegben, alakzatokban vagy médiában
* Hivatkozások diákra

Az Aspose.Slides for Python via Java lehetővé teszi, hogy számos, a hiperhivatkozásokkal kapcsolatos feladatot hajtson végre prezentációkban. 

{{% alert color="info" title="Megjegyzés" %}} 

Érdemes megnézni az Aspose egyszerű, [ingyenes online PowerPoint szerkesztőt.](https://products.aspose.app/slides/hu/editor)

{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

### **URL hiperhivatkozások hozzáadása szöveghez**

Ez a Python kód megmutatja, hogyan adjon hozzá egy weboldal hiperhivatkozást a szöveghez:

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz vagy keretekhez**

Ez a minta kód Python via Java nyelven megmutatja, hogyan adjon hozzá egy weboldal hiperhivatkozást egy alakzathoz:

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

### **URL hiperhivatkozások hozzáadása médiához**

Aspose.Slides lehetővé teszi, hogy hiperhivatkozásokat adjon hozzá képekhez, hangokhoz és videó fájlokhoz.

Ez a minta kód megmutatja, hogyan adjon hozzá hiperhivatkozást egy **képre**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Képet ad a prezentációhoz
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Képkeret létrehozása az 1. dián a korábban hozzáadott kép alapján
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ez a minta kód megmutatja, hogyan adjon hozzá hiperhivatkozást egy **hangfájlhoz**:

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

Ez a minta kód megmutatja, hogyan adjon hozzá hiperhivatkozást egy **videóhoz**:

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

{{% alert color="success" title="Tipp" %}} 

Érdemes lehet megnézni a *[OLE kezelése](/slides/hu/python-java/manage-ole/)*.

{{% /alert %}}

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik, hogy hivatkozásokat adjunk objektumokra vagy helyekre, használhatók tartalomjegyzék létrehozására. 

Ez a minta kód megmutatja, hogyan hozzon létre tartalomjegyzéket hiperhivatkozásokkal:

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

Az [Hyperlink.setColorSource](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setColorSource) tulajdonságával a [Hyperlink](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/) osztályban beállíthatja a hiperhivatkozások színét, valamint lekérdezheti a színinformációt a hiperhivatkozásokból. A funkció először a PowerPoint 2019‑ben jelent meg, így a tulajdonságra vonatkozó változások nem érvényesek a régebbi PowerPoint verziókra.

Ez a minta kód bemutat egy műveletet, ahol különböző színű hiperhivatkozásokat adnak hozzá ugyanahhoz a diára:

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

## **Hiperhivatkozások eltávolítása prezentációkból**

### **Hiperhivatkozások eltávolítása szövegből**

Ez a Python kód megmutatja, hogyan távolítható el a hiperhivatkozás a prezentációs dia szövegéből:

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

Ez a Python kód megmutatja, hogyan távolítható el a hiperhivatkozás egy alakzatról a prezentációs dián:

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

A [Hyperlink](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/) osztály módosítható. Ezzel az osztállyal módosíthatja az alábbi tulajdonságok értékeit:

- [setTargetFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

A kódrészlet megmutatja, hogyan adjon hozzá egy hiperhivatkozást egy diára, majd később módosítsa annak tooltipjét:

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

    # Módosítja a már hozzáadott hiperhivatkozás tooltipjét
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Támogatott tulajdonságok a HyperlinkQueries‑ben**

Elérheti a [HyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/)‑t egy prezentációból, diából vagy szövegből, amelyhez a hiperhivatkozás definiálva van. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getHyperlinkQueries)

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/) osztály támogatja ezeket a metódusokat és tulajdonságokat: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **FAQ**

**Hogyan hozhatok létre belső navigációt nem csak egy diára, hanem egy „szakaszra” vagy egy szakasz első diájára?**

A PowerPoint‑szakaszok a diák csoportosításai; a navigáció technikailag egy meghatározott diára mutat. Egy „szakaszra” történő navigáláshoz általában az első diára mutató hivatkozást kell létrehozni.

**Csatolhatok hiperhivatkozást a mesterdiák elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezési elemek támogatják a hiperhivatkozásokat. Az ilyen hivatkozások megjelennek a gyermek diáknál, és a vetítés során kattinthatók.

**Megmaradnak a hiperhivatkozások PDF‑re, HTML‑re, képekre vagy videóra exportáláskor?**

A [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/python-java/convert-powerpoint-to-html/) esetén igen — a hivatkozások általában megmaradnak. A [képek](/slides/hu/python-java/convert-powerpoint-to-png/) és [videó](/slides/hu/python-java/convert-powerpoint-to-video/) exportálásakor a kattinthatóság nem kerül át, mivel ezek a formátumok (raszteres képkockák/videó) nem támogatják a hiperhivatkozásokat.