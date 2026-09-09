---
title: Správa hypertextových odkazů v prezentacích pomocí Pythonu přes Java
linktitle: Spravovat hypertextový odkaz
type: docs
weight: 20
url: /cs/python-java/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímku
- hypertextový odkaz na tvaru
- hypertextový odkaz na obrázku
- hypertextový odkaz na videu
- mutabilní hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Jednoduše spravujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java — zvyšte interaktivitu a efektivitu práce během minut."
---
## **Úvod**

Hyperlink je odkaz na objekt, data nebo umístění. Běžné hypertextové odkazy v prezentacích PowerPoint zahrnují:

* Odkazy na webové stránky v textu, tvarech nebo médiích
* Odkazy na snímky

Aspose.Slides pro Python přes Java vám umožňuje provádět mnoho úkolů souvisejících s hypertextovými odkazy v prezentacích. 

{{% alert color="info" title="Note" %}} 
Možná budete chtít vyzkoušet jednoduchý, [bezplatný online editor PowerPointu.](https://products.aspose.app/slides/cs/editor)
{{% /alert %}} 

## **Přidat URL hypertextové odkazy**

### **Přidat URL hypertextové odkazy do textu**

Tento kód v Pythonu vám ukazuje, jak přidat hypertextový odkaz na webovou stránku do textu:

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

### **Přidat URL hypertextové odkazy do tvarů nebo rámečků**

Tento ukázkový kód v Pythonu přes Java vám ukazuje, jak přidat hypertextový odkaz na webovou stránku do tvaru:

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

### **Přidat URL hypertextové odkazy k médiím**

Aspose.Slides vám umožňuje přidávat hypertextové odkazy na obrázky, zvukové a video soubory. 

Tento ukázkový kód vám ukazuje, jak přidat hypertextový odkaz k **obrázku**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Přidá obrázek do prezentace
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Vytvoří rámeček s obrázkem na snímku 1 na základě dříve přidaného obrázku
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tento ukázkový kód vám ukazuje, jak přidat hypertextový odkaz k **zvukovému souboru**:

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

Tento ukázkový kód vám ukazuje, jak přidat hypertextový odkaz k **videu**:

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
Možná budete chtít zobrazit *[Spravovat OLE](/slides/cs/python-java/manage-ole/)*.
{{% /alert %}}

## **Použít hypertextové odkazy pro vytvoření obsahu**

Protože hypertextové odkazy vám umožňují přidávat odkazy na objekty nebo místa, můžete je použít k vytvoření obsahu.

Tento ukázkový kód vám ukazuje, jak vytvořit obsah s hypertextovými odkazy:

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

## **Formátovat hypertextové odkazy**

### **Barva**

Pomocí vlastnosti [Hyperlink.setColorSource](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlink/#setColorSource) ve třídě [Hyperlink](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlink/) můžete nastavit barvu hypertextových odkazů a také získat informaci o barvě z odkazů. Tato funkce byla poprvé představena v PowerPointu 2019, takže změny týkající se této vlastnosti se nepoužijí na starší verze PowerPointu.

Tento ukázkový kód demonstruje operaci, při které jsou na stejný snímek přidány hypertextové odkazy s různými barvami:

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

## **Odstranit hypertextové odkazy z prezentací**

### **Odstranit hypertextové odkazy z textu**

Tento kód v Pythonu vám ukazuje, jak odstranit hypertextový odkaz z textu na snímku prezentace:

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

### **Odstranit hypertextové odkazy z tvarů nebo rámců**

Tento kód v Pythonu vám ukazuje, jak odstranit hypertextový odkaz z tvaru na snímku prezentace:

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

## **Mutabilní hypertextový odkaz**

Třída [Hyperlink](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlink/) je mutabilní. Pomocí této třídy můžete měnit hodnoty těchto vlastností:

- [setTargetFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

Ukázkový kód vám ukazuje, jak přidat hypertextový odkaz na snímek a později upravit jeho popisek:

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

    # Změní tooltip hypertextového odkazu, který byl již přidán
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Podporované vlastnosti v HyperlinkQueries**

K [HyperlinkQueries](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlinkqueries/) můžete přistupovat z prezentace, snímku nebo textu, pro který je hypertextový odkaz definován. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getHyperlinkQueries)

Třída [HyperlinkQueries](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlinkqueries/) podporuje tyto metody a vlastnosti: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **FAQ**

**Jak mohu vytvořit vnitřní navigaci nejen na snímek, ale i na „sekci“ nebo první snímek sekce?**

Oddíly v PowerPointu jsou seskupení snímků; navigace technicky cílí na konkrétní snímek. Pro „navigaci k oddílu“ obvykle odkazujete na jeho první snímek.

**Mohu připojit hypertextový odkaz k prvkům hlavního snímku, aby fungoval na všech snímcích?**

Ano. Prvky hlavního snímku a rozložení podporují hypertextové odkazy. Takové odkazy se objeví na podřízených snímcích a jsou klikatelné během prezentace.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

V [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/python-java/convert-powerpoint-to-html/) ano — odkazy jsou obecně zachovány. Při exportu do [obrázků](/slides/cs/python-java/convert-powerpoint-to-png/) a [videí](/slides/cs/python-java/convert-powerpoint-to-video/) nebudou klikatelné, protože tyto formáty (rastrové snímky/video) hypertextové odkazy nepodporují.