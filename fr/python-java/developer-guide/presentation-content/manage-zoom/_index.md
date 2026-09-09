---
title: Gérer le zoom de présentation en Python via Java
linktitle: Gérer le zoom
type: docs
weight: 60
url: /fr/python-java/manage-zoom/
keywords:
- zoom
- cadre de zoom
- zoom de diapositive
- zoom de section
- zoom de synthèse
- ajouter un zoom
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Créer et personnaliser le zoom avec Aspose.Slides pour Python via Java — passer d’une section à l’autre, ajouter des miniatures et des transitions dans les présentations PPT, PPTX et ODP."
---
## **Introduction**

Les Zooms dans PowerPoint vous permettent de naviguer vers et depuis des diapositives, des sections et des parties spécifiques d’une présentation. Lorsque vous présentez, cette capacité à naviguer rapidement dans le contenu peut s’avérer très utile.

![overview_image](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Summary Zoom](#summary-zoom).
* Pour afficher uniquement les diapositives sélectionnées, utilisez un [Slide Zoom](#slide-zoom).
* Pour afficher une seule section uniquement, utilisez un [Section Zoom](#section-zoom).

## **Zoom de diapositive**
Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans l’ordre de votre choix sans interrompre le flux de votre présentation. Les zooms de diapositive sont excellents pour les présentations courtes sans de nombreuses sections, mais vous pouvez toujours les utiliser dans différents scénarios de présentation.

Les zooms de diapositive vous aident à approfondir plusieurs informations tout en donnant l’impression de travailler sur une seule toile.

![overview_image](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l’énumération [ZoomImageType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zoomimagetype/), la classe [ZoomFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zoomframe/) et certaines méthodes de la classe [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/).

### **Créer des cadres de zoom**
Vous pouvez ajouter un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Créez de nouvelles diapositives vers lesquelles vous souhaitez lier les cadres de zoom.
3. Ajoutez du texte d’identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment créer un cadre de zoom sur une diapositive :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Ajoute de nouvelles diapositives à la présentation
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Crée un arrière-plan pour la deuxième diapositive
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Crée une zone de texte pour la deuxième diapositive
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Crée un arrière-plan pour la troisième diapositive
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Crée une zone de texte pour la troisième diapositive
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Ajoute des objets ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Enregistre la présentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des cadres de zoom avec des images personnalisées**
Avec Aspose.Slides for Python via Java, vous pouvez créer un cadre de zoom avec une image d’aperçu de diapositive différente de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Créez une nouvelle diapositive vers laquelle vous souhaitez lier le cadre de zoom.
3. Ajoutez du texte d’identification et un arrière-plan à la diapositive.
4. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) en ajoutant une image à la collection d’images associée à l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) qui sera utilisée pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment créer un cadre de zoom avec une image différente :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Crée un arrière-plan pour la deuxième diapositive
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Crée une zone de texte pour la deuxième diapositive
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Crée une nouvelle image pour l'objet Zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Ajoute l'objet ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Enregistre la présentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formater les cadres de zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus complexes, vous devez modifier le formatage d’un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom.

Vous pouvez contrôler le formatage d’un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Créez de nouvelles diapositives vers lesquelles vous souhaitez lier les cadres de zoom.
3. Ajoutez du texte d’identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) en ajoutant une image à la collection d’images associée à l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet cadre de zoom.
7. Modifiez le format de ligne pour le deuxième objet cadre de zoom.
8. Supprimez l’arrière-plan d’une image du deuxième objet cadre de zoom.
9. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment modifier le formatage d’un cadre de zoom sur une diapositive :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Ajoute de nouvelles diapositives à la présentation
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Crée un arrière-plan pour la deuxième diapositive
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Crée une zone de texte pour la deuxième diapositive
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Crée un arrière-plan pour la troisième diapositive
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Crée une zone de texte pour la troisième diapositive
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Ajoute des objets ZoomFrame
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Crée une nouvelle image pour l'objet zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Définit une image personnalisée pour l'objet first_zoom_frame
    first_zoom_frame.setZoomImage(picture)

    #  Définit le format du cadre de zoom pour l'objet second_zoom_frame
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Paramètre pour ne pas afficher l'arrière-plan pour l'objet second_zoom_frame
    second_zoom_frame.setShowBackground(False)

    #  Enregistre la présentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom de section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir aux sections que vous souhaitez vraiment mettre en avant. Vous pouvez également les utiliser pour souligner comment certaines parties de votre présentation sont reliées.

![overview_image](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit la classe [SectionZoomFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectionzoomframe/) et certaines méthodes de la classe [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/).

### **Créer des cadres de zoom de section**
Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan distinctif à la diapositive créée.
4. Créez une nouvelle section vers laquelle vous souhaitez lier le cadre de zoom.
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment créer un cadre de zoom sur une diapositive :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 1", slide)

    #  Ajoute un objet SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Enregistre la présentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des cadres de zoom de section avec des images personnalisées**
En utilisant Aspose.Slides for Python via Java, vous pouvez créer un cadre de zoom de section avec une image d’aperçu de diapositive différente de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan distinctif à la diapositive créée.
4. Créez une nouvelle section vers laquelle vous souhaitez lier le cadre de zoom.
5. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) en ajoutant une image à la collection d’images associée à l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) qui sera utilisée pour remplir le cadre.
6. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment créer un cadre de zoom avec une image différente :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 1", slide)

    #  Crée une nouvelle image pour l'objet zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Ajoute un objet SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Enregistre la présentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formater les cadres de zoom de section**
Pour créer des cadres de zoom de section plus complexes, vous devez modifier le formatage d’un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom de section.

Vous pouvez contrôler le formatage d’un cadre de zoom de section sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan distinctif à la diapositive créée.
4. Créez une nouvelle section vers laquelle vous souhaitez lier le cadre de zoom.
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l’objet de zoom de section créé.
7. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) en ajoutant une image à la collection d’images associée à l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) qui sera utilisée pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet cadre de zoom de section créé.
9. Activez la fonctionnalité *retour à la diapositive d’origine depuis la section liée*.
10. Supprimez l’arrière-plan d’une image de l’objet cadre de zoom de section.
11. Modifiez le format de ligne de l’objet cadre de zoom de section.
12. Modifiez la durée de transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment modifier le formatage d’un cadre de zoom de section :
```python
import jpype
import asposeslides

if not jpade.isJVMStarted():
    jpape.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 1", slide)

    #  Ajoute un objet SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Mise en forme pour SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Enregistre la présentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom de synthèse**

Un zoom de synthèse ressemble à une page d’accueil où toutes les parties de votre présentation sont affichées simultanément. Lors de votre présentation, vous pouvez utiliser le zoom pour passer d’un endroit à un autre de votre présentation dans l’ordre de votre choix. Vous pouvez faire preuve de créativité, avancer rapidement ou revenir à des parties de votre diaporama sans interrompre le flux de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de zoom de synthèse, Aspose.Slides fournit les classes [SummaryZoomFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/summaryzoomsection/), et [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/summaryzoomsectioncollection/) ainsi que certaines méthodes de la classe [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/).

### **Créer un zoom de synthèse**
Vous pouvez ajouter un cadre de zoom de synthèse à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec un arrière-plan distinctif et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de zoom de synthèse à la première diapositive.
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment créer un cadre de zoom de synthèse sur une diapositive :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 1", slide)

    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 2", slide)

    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 3", slide)

    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 4", slide)

    #  Ajoute un objet SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Enregistre la présentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ajouter et supprimer une section de zoom de synthèse**
Toutes les sections d’un cadre de zoom de synthèse sont représentées par des objets [SummaryZoomSection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/summaryzoomsection/), qui sont stockés dans l’objet [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/summaryzoomsectioncollection/). Vous pouvez ajouter ou supprimer un objet de section de zoom de synthèse via la classe [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/summaryzoomsectioncollection/) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec un arrière-plan distinctif et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de synthèse à la première diapositive.
4. Ajoutez une nouvelle diapositive et une nouvelle section à la présentation.
5. Ajoutez la section créée au cadre de zoom de synthèse.
6. Supprimez la première section du cadre de zoom de synthèse.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment ajouter et supprimer des sections dans un cadre de zoom de synthèse :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 1", slide)

    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 2", slide)

    #  Ajoute un objet SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Ajoute une section au Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Supprime la section du Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Enregistre la présentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formater les sections de zoom de synthèse**
Pour créer des objets de section de zoom de synthèse plus complexes, vous devez modifier le formatage d’un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un objet de section de zoom de synthèse.

Vous pouvez contrôler le formatage d’un objet de section de zoom de synthèse dans un cadre de zoom de synthèse de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec un arrière-plan distinctif et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de synthèse à la première diapositive.
4. Récupérez le premier objet de section de zoom de synthèse à partir de la [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/summaryzoomsectioncollection/).
5. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) en ajoutant une image à la collection d’images associée à l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour l’objet de section de zoom de synthèse.
7. Activez la fonctionnalité *retour à la diapositive d’origine depuis la section liée*.
8. Modifiez le format de ligne de l’objet de section de zoom de synthèse.
9. Modifiez la durée de transition.
10. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment modifier le formatage d’un objet de section de zoom de synthèse :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpape.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 1", slide)

    # Ajoute une nouvelle diapositive à la présentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Ajoute une nouvelle section à la présentation
    presentation.getSections().addSection("Section 2", slide)

    #  Ajoute un objet SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Récupère le premier objet SummaryZoomSection
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Mise en forme pour l'objet SummaryZoomSection
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Enregistre la présentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je contrôler le retour à la diapositive « parent » après l’affichage de la cible ?**

Oui. Le [ZoomFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zoomframe/) ou le [SectionZoomFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectionzoomframe/) supporte le retour à la diapositive d’origine via [setReturnToParent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zoomobject/#setReturnToParent), ce qui renvoie les spectateurs une fois qu’ils ont consulté le contenu cible lorsqu’il est activé.

**Puis-je ajuster la « vitesse » ou la durée de la transition du Zoom ?**

Oui. Le zoom prend en charge la définition d’une durée de transition avec [setTransitionDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zoomobject/#setTransitionDuration), ce qui vous permet de contrôler la durée de l’animation de saut.

**Existe-t-il des limites au nombre d’objets Zoom qu’une présentation peut contenir ?**

Il n’existe pas de limite d’API stricte documentée. Les limites pratiques dépendent de la complexité globale de la présentation et des performances du visualiseur. Vous pouvez ajouter de nombreux cadres de Zoom, mais il faut tenir compte de la taille du fichier et du temps de rendu.