---
title: "Ajouter des filigranes aux présentations en Python"
linktitle: "Filigrane"
type: docs
weight: 40
url: /fr/python-java/watermark/
keywords:
- "filigrane"
- "filigrane texte"
- "filigrane image"
- "ajouter un filigrane"
- "modifier le filigrane"
- "supprimer le filigrane"
- "effacer le filigrane"
- "ajouter un filigrane à PPT"
- "ajouter un filigrane à PPTX"
- "ajouter un filigrane à ODP"
- "supprimer le filigrane de PPT"
- "supprimer le filigrane de PPTX"
- "supprimer le filigrane de ODP"
- "effacer le filigrane de PPT"
- "effacer le filigrane de PPTX"
- "effacer le filigrane de ODP"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "Python"
- "Aspose.Slides"
description: "Gérez les filigranes texte et image dans les présentations PowerPoint et OpenDocument en Python pour indiquer un brouillon, des informations confidentielles, des droits d’auteur, et plus encore."
---
## **Introduction**

**Un filigrane** dans une présentation est un tampon texte ou image utilisé sur une diapositive ou sur l’ensemble des diapositives de la présentation. En général, un filigrane sert à indiquer que la présentation est un brouillon (par ex., un filigrane « Draft »), qu’elle contient des informations confidentielles (par ex., un filigrane « Confidential »), à préciser à quelle société elle appartient (par ex., un filigrane « Company Name »), à identifier l’auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés à la fois dans les formats de présentation PowerPoint et OpenOffice. Avec Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/fr/python-java/), il existe différentes manières de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. L’aspect commun est que pour ajouter des filigranes texte, vous devez utiliser la classe [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. [PictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/) hérite de la classe [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/), ce qui vous permet d’utiliser tous les paramètres flexibles de l’objet forme. Puisque [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) n’est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/).

Il existe deux façons d’appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le masque des diapositives (Slide Master) est utilisé pour appliquer un filigrane à toutes les diapositives — le filigrane est ajouté au Slide Master, entièrement conçu à cet endroit, et appliqué à toutes les diapositives sans affecter la possibilité de modifier le filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d’autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parent du filigrane) d’être modifié, Aspose.Slides fournit une fonctionnalité de verrouillage des formes. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Slide Master. Lorsque la forme du filigrane est verrouillée sur le Slide Master, elle sera verrouillée sur toutes les diapositives de la présentation.

Vous pouvez attribuer un nom au filigrane afin, ultérieurement, de pouvoir le supprimer en le retrouvant parmi les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane de n’importe quelle façon ; toutefois, il existe généralement des caractéristiques communes aux filigranes, comme l’alignement centré, la rotation, la position en avant, etc. Nous verrons comment les utiliser dans les exemples ci‑dessous.

## **Filigrane texte**

### **Ajouter un filigrane texte à une diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d’abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par la classe [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/). Ce type n’hérite pas de [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/), qui possède un large jeu de propriétés pour positionner le filigrane de manière flexible. Ainsi, l’objet [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) est encapsulé dans un objet [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [addTextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/#addTextFrame) comme indiqué ci‑dessous.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Comment utiliser la classe TextFrame](/slides/fr/python-java/text-formatting/)
{{% /alert %}}

### **Ajouter un filigrane texte à une présentation**

Si vous souhaitez ajouter un filigrane texte à l’ensemble de la présentation (c’est‑à‑dire à toutes les diapositives d’un coup), ajoutez‑le au [MasterSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/). Le reste de la logique est identique à celui de l’ajout d’un filigrane à une seule diapositive — créez un objet [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) puis ajoutez le filigrane à l’aide de la méthode [addTextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Comment utiliser le Slide Master](/slides/fr/python-java/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangulaire possède des couleurs de remplissage et de contour. Les lignes de code suivantes rendent la forme transparente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Définir la police d’un filigrane texte**

Vous pouvez modifier la police du texte du filigrane comme indiqué ci‑dessous.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Définir la couleur du texte du filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Centrer un filigrane texte**

Il est possible de centrer le filigrane sur une diapositive, et pour cela vous pouvez faire ce qui suit :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

L’image ci‑dessous montre le résultat final.

![Le filigrane texte](text_watermark.png)

## **Filigrane image**

### **Ajouter un filigrane image à une présentation**

Pour ajouter un filigrane image à une diapositive de présentation, vous pouvez procéder comme suit :

```python
import jpase
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Verrouiller un filigrane contre l’édition**

S’il est nécessaire d’empêcher la modification d’un filigrane, utilisez la méthode [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/#getAutoShapeLock) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le groupement avec d’autres éléments, verrouiller son texte contre l’édition, et bien plus encore :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Verrouiller la forme du filigrane contre la modification.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Amener un filigrane à l’avant**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [ShapeCollection.reorder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#reorder). Pour ce faire, appelez cette méthode depuis la collection de formes de la diapositive en passant la référence de la forme et son numéro d’ordre. Ainsi, il est possible de placer une forme au premier plan ou à l’arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant le contenu de la présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Définir la rotation du filigrane**

Voici un exemple de code montrant comment ajuster la rotation du filigrane afin qu’il soit positionné en diagonale sur la diapositive :

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Attribuer un nom à un filigrane**

Aspose.Slides vous permet de définir le nom d’une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour la modifier ou la supprimer. Pour définir le nom de la forme du filigrane, transmettez‑le à la méthode [Shape.setName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setName) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Supprimer un filigrane**

Pour supprimer la forme du filigrane, utilisez la méthode [Shape.getName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getName) afin de la localiser parmi les formes de la diapositive. Ensuite, transmettez la forme du filigrane à la méthode [ShapeCollection.remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#remove) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **FAQ**

**Qu’est‑ce qu’un filigrane et pourquoi l’utiliser ?**

Un filigrane est une superposition de texte ou d’image appliquée aux diapositives qui aide à protéger la propriété intellectuelle, à renforcer la reconnaissance de la marque ou à empêcher l’utilisation non autorisée des présentations.

**Puis‑je ajouter un filigrane à toutes les diapositives d’une présentation ?**

Oui, Aspose.Slides vous permet d’ajouter programmatiquement un filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres du filigrane individuellement.

**Comment ajuster la transparence du filigrane ?**

Vous pouvez ajuster la transparence du filigrane en modifiant les paramètres de remplissage ([getFillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getFillFormat)) de la forme. Cela garantit que le filigrane reste discret et ne détourne pas l’attention du contenu de la diapositive.

**Quels formats d’image sont pris en charge pour les filigranes ?**

Aspose.Slides prend en charge divers formats d’image tels que PNG, JPEG, GIF, BMP, SVG, et bien d’autres.

**Puis‑je personnaliser la police et le style d’un filigrane texte ?**

Oui, vous pouvez choisir n’importe quelle police, taille et style afin d’adapter le filigrane au design de votre présentation et de conserver la cohérence de la marque.

**Comment modifier la position ou l’orientation d’un filigrane ?**

Vous pouvez ajuster la position et l’orientation du filigrane programmatiquement en modifiant les coordonnées, la taille et les propriétés de rotation de la forme.