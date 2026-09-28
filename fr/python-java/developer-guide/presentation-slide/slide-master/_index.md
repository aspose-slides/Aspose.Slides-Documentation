---
title: Gérer les masters de diapositives de présentation en Python via Java
linktitle: Master de diapositive
type: docs
weight: 70
url: /fr/python-java/slide-master/
keywords:
- master de diapositive
- diapositive master
- diapositive master PPT
- plusieurs masters de diapositives
- comparer les masters de diapositives
- arrière-plan
- espace réservé
- cloner la diapositive master
- copier la diapositive master
- dupliquer la diapositive master
- master de diapositive inutilisé
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Gérer les masters de diapositives dans Aspose.Slides pour Python via Java : accéder, modifier, cloner, comparer et supprimer les masters de diapositives dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Un **slide master** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière-plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, modifier un slide master est la méthode habituelle pour garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for Python via Java prend en charge le même modèle. Une présentation peut contenir un ou plusieurs slide masters, et chaque slide master peut contenir plusieurs layout slides. Les diapositives normales ne font généralement pas référence directement à un slide master. À la place, une diapositive normale utilise un layout slide, et ce layout slide appartient à un slide master.

La hiérarchie est :

1. **Slide master** - définit la conception et le thème partagés.  
1. **Layout slide** - définit une disposition spécifique d'espace réservés et de formatage au niveau de la disposition.  
1. **Normal slide** - contient le contenu réel de la présentation et utilise une disposition de diapositive.

![La hiérarchie des slide masters, layout slides et normal slides](slide-master_2.jpg)

Dans Aspose.Slides, un slide master est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/). Tous les slide masters d’une présentation sont accessibles via la collection [Presentation.getMasters](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getMasters), qui est représentée par [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si un slide master et un layout slide définissent tous deux un arrière‑plan, les diapositives basées sur ce layout utilisent l’arrière‑plan du layout. Pour plus d’informations sur les layout slides, voir [Apply or Change Slide Layouts](/slides/fr/python-java/slide-layout/).
{{% /alert %}}

## **Accéder aux slide masters**

Dans PowerPoint, vous pouvez ouvrir la vue Slide Master depuis **View** > **Slide Master**.

![La commande Slide Master dans l’onglet View de PowerPoint](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection [Presentation.getMasters](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getMasters) pour accéder aux slide masters :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Vous pouvez également obtenir le slide master utilisé par une diapositive normale via son layout :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Contenu d’un slide master**

Un slide master est un objet semblable à une diapositive. Il hérite de [BaseSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/), il expose donc de nombreuses propriétés de diapositive également utilisées par les diapositives normales et les layouts. Les membres spécifiques au master sont répertoriés sur la page API [MasterSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/).

Les membres les plus couramment utilisés sont :

| Membre | Objectif |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getBackground) | Définit l’arrière‑plan de la diapositive au niveau du master. |
| [getShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getShapes) | Contient les formes placées sur le master, comme les logos, les cadres d’image et le texte partagé. |
| [getLayoutSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/#getLayoutSlides) | Contient les layout slides qui appartiennent au master. |
| [getThemeManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/#getThemeManager) | Fournit l’accès aux API du thème du master. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le master et ses dispositions enfants. |
| [getDependingSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/#getDependingSlides) | Renvoie les diapositives normales qui dépendent du master via leurs dispositions. |

## **Ajouter une image à un slide master**

Lorsque vous ajoutez une image à un slide master, elle apparaît sur les diapositives qui utilisent les layouts de ce master. C’est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L’exemple suivant ajoute un logo au premier slide master :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour plus d’informations sur les cadres d’image, voir [Picture Frame](/slides/fr/python-java/picture-frame/).

## **Contrôler la visibilité des graphiques du master**

Utilisez [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#setShowMasterShapes) pour masquer les graphiques hérités du master, tels que les logos ou formes décoratives, sans les supprimer du master. Passez `False` à [Slide.setShowMasterShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#setShowMasterShapes) sur la diapositive qui doit omettre ces graphiques et conservez `True` sur les diapositives qui doivent les afficher.

L’exemple autonome suivant crée une bande décorative bleue sur un master et deux diapositives qui utilisent le même layout vierge. La bande est visible sur la première diapositive et masquée sur la seconde. Aucun fichier de présentation ou image d’entrée n’est requis.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L’exemple utilise le layout **Blank** fourni avec une nouvelle présentation et supprime les espaces réservés propres à la diapositive initiale.

### **Choisir la portée du réglage**

Une diapositive normale utilise son master via [Slide.getLayoutSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getLayoutSlide) et [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/#getMasterSlide). Le réglage de la propriété sur une diapositive individuelle n’affecte que cette diapositive. Passer `False` à [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/#setShowMasterShapes) masque les graphiques du master pour toutes les diapositives qui utilisent ce layout partagé, même si leur propre réglage est `True`. Pour masquer les graphiques sur une seule diapositive, modifiez la propriété de la diapositive et laissez le layout partagé inchangé.

Le réglage n’est pas supporté comme contrôle de visibilité sur le slide master lui‑même. Sur un master, [getShowMasterShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/#getShowMasterShapes) renvoie toujours `False`, et passer `True` à [setShowMasterShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/#setShowMasterShapes) lève une exception. Appliquez‑le à une diapositive normale ou à un layout à la place.

### **Différencier les graphiques de l’arrière‑plan**

| Opération | Effet |
| --- | --- |
| Masquer les graphiques du master | Contrôle la visibilité des formes héritées du master sans les supprimer ni modifier les propres formes de la diapositive. |
| Modifier le remplissage d’arrière‑plan de la diapositive | Modifie la couleur, le dégradé ou l’image d’arrière‑plan. Les graphiques du master sont des formes séparées et peuvent rester visibles au‑dessus de cet arrière‑plan. Voir [Presentation Background](/slides/fr/python-java/presentation-background/). |
| Supprimer une forme du master | Supprime la forme source partagée, de sorte qu’elle ne soit plus disponible pour aucune diapositive utilisant ce master. |

## **Travailler avec les espaces réservés**

Les espaces réservés sont généralement définis sur les layout slides. Le slide master fournit le style et le thème partagés que ces layouts héritent, tandis que chaque layout décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espace réservé sont disponibles en vue Slide Master.

![La commande Insert Placeholder dans la vue Slide Master de PowerPoint](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur le layout slide qui appartient au master :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vous pouvez également formater les formes d’espace réservé déjà présentes sur un slide master. L’exemple suivant trouve l’espace réservé titre et applique un remplissage en dégradé linéaire :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Espace réservé titre formaté hérité par les diapositives normales](slide-master_8.png)

Pour plus d’options de formatage des espaces réservés et du texte, voir [Set Prompt Text in Placeholder](/slides/fr/python-java/manage-placeholder/) et [Text Formatting](/slides/fr/python-java/text-formatting/).

## **Modifier l’arrière‑plan d’un slide master**

Un arrière‑plan de master est hérité par les layouts et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour le premier slide master :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour les sujets associés, voir [Presentation Background](/slides/fr/python-java/presentation-background/) et [Presentation Theme](/slides/fr/python-java/presentation-theme/).

## **Cloner un slide master vers une autre présentation**

Utilisez [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslidecollection/#addClone) pour copier un slide master dans une autre présentation. Le master copié peut alors être utilisé par les layouts et les diapositives de la présentation cible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Si vous devez cloner des diapositives normales avec leur master, voir [Clone Slides](/slides/fr/python-java/clone-slides/).

## **Ajouter plusieurs slide masters**

Une présentation peut contenir plusieurs slide masters. Cela est utile lorsque différentes sections nécessitent une identité visuelle, une structure de page ou des paramètres de thème différents.

![Commandes PowerPoint pour insérer et gérer les slide masters](slide-master_9.jpg)

L’exemple suivant clone le master par défaut, donne au clone un arrière‑plan différent, crée un layout sous ce master cloné, puis ajoute une nouvelle diapositive basée sur ce layout :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comparer des slide masters**

Les slide masters peuvent être comparés avec la méthode [equals](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#equals) héritée de [BaseSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les IDs de diapositives, ni les valeurs dynamiques des espaces réservés, comme la date actuelle.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Pour plus d’informations, voir [Compare Presentation Slides](/slides/fr/python-java/compare-slides/).

## **Définir la vue Slide Master comme vue par défaut**

Utilisez la méthode [setLastView](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#setLastView) sur [ViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Slide Master :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour d’autres paramètres de vue, voir [Save Presentation](/slides/fr/python-java/save-presentation/).

## **Supprimer les slide masters inutilisés**

Les présentations contiennent parfois des slide masters qui ne sont plus utilisés par aucune diapositive normale. Supprimer les masters inutilisés peut réduire la taille du fichier et simplifier la maintenance des modèles.

Utilisez [removeUnused](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslidecollection/#removeUnused) pour retirer les masters inutilisés de la collection [Presentation.getMasters](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getMasters) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vous pouvez également employer la méthode low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/#removeUnusedMasterSlides) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quelle est la différence entre un slide master et un layout slide ?**

Un slide master définit des paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Un layout slide appartient à un slide master et définit une disposition spécifique d’espaces réservés. Une diapositive normale utilise un layout slide, elle hérite donc à la fois du layout et du master.

**Une présentation peut‑elle contenir plusieurs slide masters ?**

Oui. Une présentation peut contenir plusieurs slide masters. Utilisez plusieurs masters lorsque différentes sections requièrent des systèmes visuels ou une identité de marque différents.

**Dois‑je ajouter les espaces réservés à un slide master ou à un layout slide ?**

Dans la plupart des cas, ajoutez les espaces réservés aux layout slides. Placez les éléments visuels partagés et le formatage commun sur le slide master, puis mettez les espaces réservés de contenu sur les layouts que les diapositives normales utiliseront.

**Puis‑je supprimer un slide master qui est encore utilisé ?**

Non. Un slide master qui possède des diapositives dépendantes ne peut pas être supprimé directement en toute sécurité. Déplacez d’abord ces diapositives vers des layouts sous un autre master, ou utilisez une méthode de nettoyage des masters inutilisés qui ne supprime que les masters qui ne sont pas utilisés.