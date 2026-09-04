---
title: Diapositive maître
type: docs
weight: 30
url: /fr/python-java/examples/elements/master-slide/
keywords:
- exemple de code
- diapositive maître
- ajouter une diapositive maître
- accéder à une diapositive maître
- supprimer une diapositive maître
- diapositive maître inutilisée
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Gérer les diapositives maîtres avec Aspose.Slides for Python via Java : créer, accéder, supprimer et nettoyer les maîtresses dans les présentations PowerPoint et OpenDocument."
---
Les diapositives maîtres constituent le niveau supérieur de la hiérarchie d’héritage des diapositives dans PowerPoint. Une **diapositive maître** définit des éléments de conception communs tels que les arrière‑plans, les logos et le formatage du texte. Les **diapositives de mise en page** héritent des diapositives maîtres, et les **diapositives normales** héritent des diapositives de mise en page.

Cet article montre comment créer, modifier et gérer les diapositives maîtres à l’aide de **Aspose.Slides for Python via Java**.

Installez le package comme indiqué dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l’API après le démarrage de la JVM.

## **Ajouter une diapositive maître**

Cet exemple montre comment créer une nouvelle diapositive maître en clonant celle par défaut. Il ajoute ensuite une bannière de nom d’entreprise à toutes les diapositives via l’héritage de mise en page.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Cloner la diapositive maître par défaut.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Ajouter une bannière avec le nom de l'entreprise en haut de la diapositive maître.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Affecter la nouvelle diapositive maître à une diapositive de mise en page.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Affecter la diapositive de mise en page à la première diapositive de la présentation.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Les diapositives maîtres offrent un moyen d’appliquer une identité visuelle ou des éléments de conception partagés de façon cohérente sur toutes les diapositives. Les modifications apportées à une maîtresse sont automatiquement répercutées sur les diapositives de mise en page et les diapositives normales dépendantes.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Les formes et le formatage ajoutés à une diapositive maître sont hérités par les diapositives de mise en page et, à leur tour, par toutes les diapositives normales qui utilisent ces mises en page. L’image ci‑dessous illustre comment une zone de texte ajoutée à une diapositive maître est automatiquement rendue sur la diapositive finale.
{{% /alert %}}

![Exemple d'héritage de maître](master-slide-banner.png)

## **Accéder à une diapositive maître**

Vous pouvez accéder aux diapositives maîtres via la collection maîtresse de la présentation. Cet exemple récupère la première diapositive maître et change son type d’arrière‑plan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Supprimer une diapositive maître**

Une diapositive maître peut être supprimée par indice ou par référence lorsqu’elle n’est plus utilisée. Cet exemple affecte une diapositive maître clonée à la présentation, puis supprime la maîtresse originale par indice.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Supprimer la diapositive maître originale inutilisée par indice.
    # Sinon, supprimer une diapositive maître inutilisée par référence :
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Supprimer les diapositives maîtres inutilisées**

Certaines présentations contiennent des diapositives maîtres qui ne sont pas utilisées. Supprimer ces diapositives peut aider à réduire la taille du fichier.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Supprimer toutes les diapositives maîtres inutilisées, y compris celles marquées comme Conserver.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```