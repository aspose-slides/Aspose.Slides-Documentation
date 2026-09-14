---
title: "Cloner les diapositives d'une présentation en Python"
linktitle: "Cloner les diapositives"
type: docs
weight: 35
url: /fr/python-java/clone-slides/
keywords:
- "cloner diapositive"
- "copier diapositive"
- "enregistrer diapositive"
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Dupliquez rapidement les diapositives PowerPoint avec Aspose.Slides pour Python via Java. Suivez nos exemples de code clairs pour automatiser la création de PPT en quelques secondes et éliminer le travail manuel."
---
## **Introduction**

Le clonage est le processus de création d’une copie exacte ou d’un double de quelque chose. Aspose.Slides for Python via Java permet également de créer une copie ou un clone de n’importe quelle diapositive, puis d’insérer cette diapositive clonée dans la présentation en cours ou dans toute autre présentation ouverte. Le processus de clonage de diapositive crée une nouvelle diapositive qui peut être modifiée par les développeurs sans changer la diapositive originale. Plusieurs façons possibles de cloner une diapositive existent :

- Cloner à la fin d’une présentation.
- Cloner à une autre position dans une présentation.
- Cloner à la fin dans une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner avec sa diapositive maître dans une autre présentation.

Dans Aspose.Slides for Python via Java, la collection de diapositives (une collection d’objets [Slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/) ) exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) fournit les méthodes [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) et [insertClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertClone) pour réaliser les types de clonage de diapositives décrits ci‑dessus.

## **Cloner une diapositive à la fin d’une présentation**

Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) selon les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Récupérez l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) en référant la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
3. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) et transmettez la diapositive à cloner en tant que paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) .
4. Enregistrez le fichier de présentation modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – indice zéro – de la présentation) à la fin de la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancier la classe Presentation qui représente un fichier de présentation
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Enregistrer la présentation modifiée sur le disque
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cloner une diapositive à une autre position dans une présentation**

Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais à une autre position, utilisez la méthode [insertClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertClone) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Obtenez une référence à la collection de diapositives renvoyée par [getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlides) sur l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
3. Appelez la méthode [insertClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertClone) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) et transmettez la diapositive à cloner ainsi que l’indice de la nouvelle position en tant que paramètres de la méthode [insertClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertClone) .
4. Enregistrez la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (située à l’indice 1 – position 2 – de la présentation) à l’indice 2 – position 3 – de la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancier la classe Presentation qui représente un fichier de présentation
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Obtenir la collection de diapositives dans la présentation
    slides = presentation.getSlides()

    # Cloner la diapositive souhaitée à l'index spécifié dans la même présentation
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Enregistrer la présentation modifiée sur le disque
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cloner une diapositive à la fin d’une autre présentation**

Si vous devez cloner une diapositive d’une présentation et l’utiliser dans un autre fichier de présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) contenant la présentation à partir de laquelle la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
3. Récupérez l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) en référant la collection de diapositives renvoyée par [getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlides) sur l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) de la présentation de destination.
4. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) et transmettez la diapositive de la présentation source en tant que paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) .
5. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (à partir de l’indice 0 de la présentation source) à la fin de la présentation de destination.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancier la classe Presentation pour charger le fichier de présentation source
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instancier la classe Presentation pour le PPTX de destination (où la diapositive sera clonée)
    destination_presentation = Presentation()
    try:
        # Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Enregistrer la présentation de destination sur le disque
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Cloner une diapositive à une autre position dans une autre présentation**

Si vous devez cloner une diapositive d’une présentation et l’utiliser dans un autre fichier de présentation, à une position précise :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) contenant la présentation source à partir de laquelle la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
3. Récupérez l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) en référant la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) de la présentation de destination.
4. Appelez la méthode [insertClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertClone) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) et transmettez la diapositive de la présentation source ainsi que la position souhaitée en tant que paramètres de la méthode [insertClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertClone) .
5. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (à partir de l’indice zéro de la présentation source) à l’indice 1 (position 2) de la présentation de destination.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancier la classe Presentation pour charger le fichier de présentation source
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instancier la classe Presentation pour le PPTX de destination (où la diapositive sera clonée)
    destination_presentation = Presentation()
    try:
        # Cloner la diapositive souhaitée de la présentation source à l'index spécifié dans la présentation de destination
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Enregistrer la présentation de destination sur le disque
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Cloner une diapositive avec sa diapositive maître dans une autre présentation**

Si vous devez cloner une diapositive avec sa diapositive maître d’une présentation et l’utiliser dans une autre présentation, vous devez d’abord cloner la diapositive maître souhaitée de la présentation source vers la présentation de destination. Ensuite, utilisez la diapositive maître clonée lors du clonage de la diapositive. La méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) attend une diapositive maître de la présentation de destination plutôt que de la source. Pour cloner la diapositive avec son maître, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) contenant la présentation source à partir de laquelle la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) contenant la présentation de destination où la diapositive sera clonée.
3. Accédez à la diapositive à cloner ainsi qu’à sa diapositive maître.
4. Récupérez l’objet [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslidecollection/) en référant la collection Masters exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) de la présentation de destination.
5. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslidecollection/#addClone) exposée par l’objet [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslidecollection/) et transmettez le maître du PPTX source à cloner en tant que paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslidecollection/#addClone) .
6. Récupérez l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) en référant la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) de la présentation de destination.
7. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) et transmettez la diapositive de la présentation source à cloner ainsi que la diapositive maître en tant que paramètres de la méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) .
8. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive avec son maître (située à l’indice zéro de la présentation source) à la fin de la présentation de destination en utilisant le maître de la diapositive source.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancier la classe Presentation pour charger le fichier de présentation source
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Instancier la classe Presentation pour la présentation de destination (où la diapositive sera clonée)
    destination_presentation = Presentation()
    try:
        # Instancier la diapositive depuis la collection de diapositives de la présentation source ainsi que
        # la diapositive maître
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans la
        # présentation de destination
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Cloner la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la
        # collection de diapositives dans la présentation de destination
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Enregistrer la présentation de destination sur le disque
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Cloner une diapositive à la fin d’une section spécifiée**

Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais dans une section différente, utilisez la méthode [**addClone**](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) exposée par la classe [**SlideCollection**](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/). Aspose.Slides for Python via Java permet de cloner une diapositive de la première section puis d’insérer cette diapositive clonée dans la deuxième section de la même présentation.

Le fragment de code suivant montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Enregistrer la présentation de destination sur le disque
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Assurer la correspondance de la taille des diapositives**

Lors du clonage de diapositives dans une autre présentation, assurez‑vous que la présentation de destination a la même taille de diapositive que la source. Si les tailles diffèrent, Aspose.Slides ne redimensionne pas automatiquement les formes clonées : leurs coordonnées et dimensions d’origine sont conservées, ce qui peut entraîner un mauvais alignement du contenu ou son dépassement des limites de la diapositive.

Vous pouvez définir la taille de diapositive de la présentation de destination pour qu’elle corresponde à celle de la source avant de cloner le maître et la diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Faites‑le avant de cloner le maître et la diapositive.

## **FAQ**

**Les notes du présentateur et les commentaires des relecteurs sont‑ils clonés ?**

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez‑les](/slides/fr/python-java/presentation-notes/) après l’insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L’objet graphique, son formatage et les données incorporées sont copiés. Si le graphique était lié à une source externe (par ex., un classeur incorporé OLE), ce lien est conservé sous forme d’[objet OLE](/slides/fr/python-java/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive précis et le placer dans une [section](/slides/fr/python-java/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dedans.