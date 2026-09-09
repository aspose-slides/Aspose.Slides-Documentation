---
title: Gérer les hyperliens de présentation en Python via Java
linktitle: Gérer le lien hypertexte
type: docs
weight: 20
url: /fr/python-java/manage-hyperlinks/
keywords:
- ajouter URL
- ajouter hyperlien
- créer hyperlien
- formater hyperlien
- supprimer hyperlien
- mettre à jour hyperlien
- hyperlien texte
- hyperlien diapositive
- hyperlien forme
- hyperlien image
- hyperlien vidéo
- hyperlien mutable
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Gérez facilement les hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via Java—améliorez l'interactivité et le flux de travail en quelques minutes."
---
## **Introduction**

Un hyperlien est une référence à un objet, des données ou un emplacement. Les hyperliens courants dans les présentations PowerPoint comprennent :

* Liens vers des sites Web dans le texte, les formes ou les médias
* Liens vers des diapositives

Aspose.Slides pour Python via Java vous permet d'effectuer de nombreuses tâches liées aux hyperliens dans les présentations. 

{{% alert color="info" title="Note" %}} 
Vous voudrez peut-être essayer l'éditeur PowerPoint en ligne gratuit d'Aspose, [éditeur PowerPoint en ligne gratuit d'Aspose.](https://products.aspose.app/slides/fr/editor)
{{% /alert %}} 

## **Add URL Hyperlinks**

### **Add URL Hyperlinks to Text**

Ce code Python montre comment ajouter un hyperlien vers un site Web au texte :

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

### **Add URL Hyperlinks to Shapes or Frames**

Ce code d'exemple en Python via Java montre comment ajouter un hyperlien vers un site Web à une forme :

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

### **Add URL Hyperlinks to Media**

Aspose.Slides vous permet d'ajouter des hyperliens aux images, aux fichiers audio et vidéo. 

Ce code d'exemple montre comment ajouter un hyperlien à une **image** :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Ajoute une image à la présentation
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Crée un cadre d'image sur la diapositive 1 basé sur l'image précédemment ajoutée
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ce code d'exemple montre comment ajouter un hyperlien à un **fichier audio** :

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

Ce code d'exemple montre comment ajouter un hyperlien à une **vidéo** :

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
Vous voudrez peut-être voir *[Gérer OLE](/slides/fr/python-java/manage-ole/)*.
{{% /alert %}}

## **Use Hyperlinks to Create a Table of Contents**

Puisque les hyperliens vous permettent d'ajouter des références à des objets ou des emplacements, vous pouvez les utiliser pour créer une table des matières. 

Ce code d'exemple montre comment créer une table des matières avec des hyperliens :

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

## **Format Hyperlinks**

### **Color**

Avec la propriété [Hyperlink.setColorSource](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setColorSource) dans la classe [Hyperlink](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/), vous pouvez définir la couleur des hyperliens et également obtenir les informations de couleur à partir des hyperliens. Cette fonctionnalité a été introduite pour la première fois dans PowerPoint 2019, de sorte que les modifications impliquant cette propriété ne s'appliquent pas aux versions plus anciennes de PowerPoint.

Ce code d'exemple montre une opération où des hyperliens de différentes couleurs sont ajoutés à la même diapositive :

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

## **Remove Hyperlinks from Presentations**

### **Remove Hyperlinks from Text**

Ce code Python montre comment supprimer l'hyperlien du texte sur une diapositive de présentation :

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

### **Remove Hyperlinks from Shapes or Frames**

Ce code Python montre comment supprimer l'hyperlien d'une forme sur une diapositive de présentation :

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

## **Mutable Hyperlink**

La classe [Hyperlink](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/) est mutable. Avec cette classe, vous pouvez modifier les valeurs de ces propriétés :

- [setTargetFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

L'extrait de code montre comment ajouter un hyperlien à une diapositive et modifier son infobulle ultérieurement :

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

    # Modifie l'infobulle du lien hypertexte déjà ajouté
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Supported Properties in HyperlinkQueries**

Vous pouvez accéder à [HyperlinkQueries](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/) depuis une présentation, une diapositive ou un texte pour lequel l'hyperlien est défini. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getHyperlinkQueries)

La classe [HyperlinkQueries](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/) prend en charge ces méthodes et propriétés : 

- [getHyperlinkClicks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **FAQ**

**Comment créer une navigation interne non seulement vers une diapositive, mais vers une « section » ou la première diapositive d’une section ?**

Les sections dans PowerPoint sont des regroupements de diapositives ; la navigation cible techniquement une diapositive spécifique. Pour « naviguer vers une section », vous liez généralement à sa première diapositive.

**Puis-je attacher un hyperlien aux éléments de la diapositive maîtresse afin qu’il fonctionne sur toutes les diapositives ?**

Oui. Les éléments de la diapositive maîtresse et des dispositions prennent en charge les hyperliens. Ces liens apparaissent sur les diapositives enfants et sont cliquables pendant le diaporama.

**Les hyperliens seront-ils conservés lors de l’exportation vers PDF, HTML, images ou vidéo ?**

Dans [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/) et [HTML](/slides/fr/python-java/convert-powerpoint-to-html/), oui — les liens sont généralement conservés. Lors de l’exportation vers [images](/slides/fr/python-java/convert-powerpoint-to-png/) et [vidéo](/slides/fr/python-java/convert-powerpoint-to-video/), la possibilité de cliquer ne sera pas conservée en raison de la nature de ces formats (les trames raster/vidéo ne prennent pas en charge les hyperliens).