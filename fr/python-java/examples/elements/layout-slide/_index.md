---
title: Diapositive de mise en page
type: docs
weight: 20
url: /fr/python-java/examples/elements/layout-slide/
keywords:
- exemple de code
- diapositive de mise en page
- ajouter une diapositive de mise en page
- accéder à une diapositive de mise en page
- supprimer une diapositive de mise en page
- diapositive de mise en page inutilisée
- cloner une diapositive de mise en page
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Gérez les diapositives de mise en page avec Aspose.Slides pour Python via Java : ajoutez, accédez, supprimez, nettoyez et clonez les mises en page dans les présentations PowerPoint et OpenDocument."
---
Cet article montre comment travailler avec les **diapositives de mise en page** à l'aide d'Aspose.Slides pour Python via Java. Une diapositive de mise en page définit la conception et le formatage hérités par les diapositives normales. Vous pouvez ajouter, accéder, cloner et supprimer des diapositives de mise en page, ainsi que nettoyer celles qui ne sont pas utilisées pour réduire la taille de la présentation.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API une fois la JVM en cours d'exécution.

## **Ajouter une diapositive de mise en page**

Créez une diapositive de mise en page personnalisée pour définir un formatage réutilisable. L'exemple suivant ajoute une zone de texte à une nouvelle mise en page, puis crée deux diapositives qui l'utilisent.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Créez une diapositive de mise en page avec un type de mise en page vierge et un nom personnalisé.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Ajoutez une zone de texte à la diapositive de mise en page.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Ajoutez deux diapositives qui héritent du texte de la mise en page.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Note 1 :** Les diapositives de mise en page servent de modèles pour les diapositives individuelles. Vous pouvez définir des éléments communs une fois et les réutiliser sur de nombreuses diapositives.

> 💡 **Note 2 :** Lorsque vous ajoutez des formes ou du texte à une diapositive de mise en page, toutes les diapositives basées sur cette mise en page affichent automatiquement le contenu partagé.
> La capture d'écran ci-dessous montre deux diapositives qui héritent d'une zone de texte de la même diapositive de mise en page.

![Diapositives héritant du contenu de mise en page](layout-slide-result.png)

## **Accéder à une diapositive de mise en page**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Accédez à une diapositive de mise en page par index.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Accédez à une diapositive de mise en page par type.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Supprimer une diapositive de mise en page**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Supprimer les diapositives de mise en page inutilisées**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Cloner une diapositive de mise en page**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Résumé :** Les diapositives de mise en page aident à maintenir un formatage cohérent à travers une présentation. Aspose.Slides vous permet de créer, gérer, réutiliser et nettoyer les mises en page selon les besoins.