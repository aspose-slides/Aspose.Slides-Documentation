---
title: Zarządzanie hiperłączami prezentacji w Pythonie via Java
linktitle: Zarządzaj hiperłączem
type: docs
weight: 20
url: /pl/python-java/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperłącze
- utwórz hiperłącze
- formatowanie hiperłącza
- usuń hiperłącze
- aktualizuj hiperłącze
- hiperłącze tekstowe
- hiperłącze slajdu
- hiperłącze kształtu
- hiperłącze obrazu
- hiperłącze wideo
- modyfikowalne hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Bez wysiłku zarządzaj hiperłączami w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona via Java — zwiększ interaktywność i efektywność pracy w kilka minut."
---
## **Wprowadzenie**

Hiperłącze jest odwołaniem do obiektu, danych lub lokalizacji. Typowe hiperłącza w prezentacjach PowerPoint obejmują:

* Linki do stron internetowych w tekście, kształtach lub mediach
* Linki do slajdów

Aspose.Slides for Python via Java umożliwia wykonywanie wielu zadań związanych z hiperłączami w prezentacjach. 

{{% alert color="info" title="Uwaga" %}} 
Możesz sprawdzić prosty, [bezpłatny edytor PowerPoint online](https://products.aspose.app/slides/pl/editor).
{{% /alert %}} 

## **Dodawanie hiperłączy URL**

### **Dodawanie hiperłączy URL do tekstu**

Ten kod w Pythonie pokazuje, jak dodać hiperłącze do witryny w tekście:

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

### **Dodawanie hiperłączy URL do kształtów lub ramek**

Ten przykładowy kod w Pythonie za pośrednictwem Javy pokazuje, jak dodać hiperłącze do witryny w kształcie:

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

### **Dodawanie hiperłączy URL do multimediów**

Aspose.Slides pozwala dodawać hiperłącza do obrazów, plików audio i wideo.

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **obrazu**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Dodaje obraz do prezentacji
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Tworzy ramkę obrazu na slajdzie 1 na podstawie wcześniej dodanego obrazu
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **pliku audio**:

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

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **wideo**:

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

{{% alert color="success" title="Wskazówka" %}} 
Możesz chcieć zobaczyć *[Zarządzanie OLE](/slides/pl/python-java/manage-ole/)*
{{% /alert %}}

## **Używanie hiperłączy do tworzenia spisu treści**

Ponieważ hiperłącza umożliwiają dodawanie odwołań do obiektów lub miejsc, możesz je używać do tworzenia spisu treści.

Ten przykładowy kod pokazuje, jak utworzyć spis treści z hiperłączami:

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

## **Formatowanie hiperłączy**

### **Kolor**

Za pomocą właściwości [Hyperlink.setColorSource](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setColorSource) w klasie [Hyperlink](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/) możesz ustawić kolor dla hiperłączy oraz pobrać informację o kolorze z hiperłączy. Funkcja została po raz pierwszy wprowadzona w programie PowerPoint 2019, więc zmiany związane z tą właściwością nie dotyczą starszych wersji PowerPoint.

Ten przykładowy kod demonstruje operację, w której do tego samego slajdu dodawane są hiperłącza o różnych kolorach:

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

## **Usuwanie hiperłączy z prezentacji**

### **Usuwanie hiperłączy z tekstu**

Ten kod w Pythonie pokazuje, jak usunąć hiperłącze z tekstu na slajdzie prezentacji:

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

### **Usuwanie hiperłączy z kształtów lub ramek**

Ten kod w Pythonie pokazuje, jak usunąć hiperłącze z kształtu na slajdzie prezentacji:

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

## **Modyfikowalny hiperłącze**

Klasa [Hyperlink](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/) jest modyfikowalna. Dzięki tej klasie możesz zmieniać wartości następujących właściwości:

- [setTargetFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

Fragment kodu pokazuje, jak dodać hiperłącze do slajdu i później edytować jego podpowiedź (tooltip):

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

    # Zmienia podpowiedź hiperłącza, które już zostało dodane
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obsługiwane właściwości w HyperlinkQueries**

Możesz uzyskać dostęp do [HyperlinkQueries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/) z prezentacji, slajdu lub tekstu, dla którego zdefiniowano hiperłącze. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getHyperlinkQueries)

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/) obsługuje następujące metody i właściwości: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **FAQ**

**Jak mogę stworzyć wewnętrzną nawigację nie tylko do slajdu, ale do „sekcji” lub pierwszego slajdu sekcji?**

Sekcje w PowerPoint są grupami slajdów; nawigacja technicznie skierowana jest do konkretnego slajdu. Aby „nawigować do sekcji”, zazwyczaj linkujesz do jej pierwszego slajdu.

**Czy mogę dołączyć hiperłącze do elementów slajdu wzorcowego, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu wzorcowego i układu obsługują hiperłącza. Takie linki pojawiają się na slajdach potomnych i są klikalne podczas pokazu slajdów.

**Czy hiperłącza będą zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

W [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/python-java/convert-powerpoint-to-html/) tak — linki są zazwyczaj zachowywane. Przy eksporcie do [obrazów](/slides/pl/python-java/convert-powerpoint-to-png/) i [wideo](/slides/pl/python-java/convert-powerpoint-to-video/) klikalność nie zostanie przeniesiona ze względu na charakter tych formatów (ramki rastrowe/wideo nie obsługują hiperłączy).