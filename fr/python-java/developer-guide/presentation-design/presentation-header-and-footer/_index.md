---
title: Gérer les en-têtes et pieds de page de la présentation en Python via Java
linktitle: En-tête et pied de page
type: docs
weight: 140
url: /fr/python-java/presentation-header-and-footer/
keywords:
- en-tête
- texte d'en-tête
- pied de page
- texte de pied de page
- définir en-tête
- définir pied de page
- prospectus
- notes
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à gérer les espaces réservés de pied de page, de date-heure, de numéro de diapositive et d'en-tête sur les diapositives, les pages de notes et les prospectus avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

PowerPoint utilise différents espaces réservés d’en‑tête et de pied de page selon le type de page. Aspose.Slides for Python via Java vous permet de contrôler le texte et la visibilité de ces espaces réservés grâce aux classes de gestion d’en‑tête/pied de page.

Les espaces réservés disponibles dépendent de la portée :

| Portée | En‑tête | Pied de page | Date/heure | Numéro de diapositive/page |
|---|---|---|---|---|
| Diapositive normale | Non | Oui | Oui | Oui |
| Masque des notes | Oui | Oui | Oui | Oui |
| Diapositive de notes | Oui | Oui | Oui | Oui |
| Masque des prospectus | Oui | Oui | Oui | Oui |

Une diapositive normale de présentation n’a pas d’espace réservé d’en‑tête. Les en‑têtes sont disponibles sur les pages de notes et les prospectus. Pour les diapositives normales, utilisez les espaces réservés pied de page, date/heure et numéro de diapositive.

La portée d’une modification dépend du gestionnaire utilisé. La classe [SlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideheaderfootermanager/) contrôle une diapositive normale. La classe [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notesslideheaderfootermanager/) contrôle une diapositive de notes. Les gestionnaires de masque et de mise en page peuvent également propager les paramètres aux diapositives dépendantes, tandis que la classe [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) contrôle le masque des prospectus.

## **Définir le pied de page, la date/heure et les numéros de diapositive sur les diapositives normales**

Pour les diapositives normales, le flux de travail de base consiste à accéder au gestionnaire d’en‑tête/pied de page de chaque diapositive, définir le texte du pied de page et de la date/heure, activer les espaces réservés requis, puis enregistrer la présentation. Les numéros de diapositive sont générés par la présentation, vous n’avez donc besoin que de contrôler leur visibilité.

Utilisez [setFooterText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) et [setDateTimeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) pour définir le texte, et utilisez [setFooterVisibility](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) et [setSlideNumberVisibility](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) pour afficher les espaces réservés correspondants.

L’exemple complet suivant applique le même pied de page, le même texte date/heure et la même visibilité du numéro de diapositive à toutes les diapositives normales :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si vous devez mettre à jour une seule diapositive, accédez directement à cette diapositive via la méthode [getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlides) au lieu d’itérer sur toute la collection.

## **Définir les en‑têtes et pieds de page sur le masque des notes**

Le masque des notes définit le format commun et le comportement des espaces réservés pour les pages de notes. Utilisez la classe [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslideheaderfootermanager/) lorsque vous ne souhaitez modifier que le masque des notes lui‑-même.

L’exemple suivant définit l’en‑tête, le pied de page et le texte date/heure sur le masque des notes et rend tous les espaces réservés pris en charge visibles sur ce masque :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La méthode `getMasterNotesSlide` renvoie `None` lorsque la présentation ne contient pas de masque des notes.

## **Appliquer les paramètres du masque des notes aux diapositives de notes enfants**

Un masque des notes peut appliquer les paramètres d’en‑tête et de pied de page à lui‑même et à toutes les diapositives de notes dépendantes. Utilisez les méthodes de propagation dédiées sur [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslideheaderfootermanager/) lorsque les mêmes paramètres doivent être appliqués dans toute la hiérarchie des notes.

Par exemple, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) et [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) mettent à jour l’en‑tête du masque des notes et tous les en‑têtes enfants. Des méthodes équivalentes existent pour les pieds de page, la date/heure et les numéros de diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les méthodes de propagation utilisées ci‑dessus sont [setFooterAndChildFootersText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) et [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Définir les en‑têtes et pieds de page sur une diapositive de notes individuelle**

Une diapositive de notes appartient à une diapositive normale spécifique. Utilisez sa classe [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notesslideheaderfootermanager/) lorsque vous souhaitez personnaliser uniquement cette page de notes.

La méthode [addNotesSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notesslidemanager/#addNotesSlide) renvoie la diapositive de notes de la diapositive actuelle et en crée une si elle n’existe pas déjà. L’exemple suivant configure la page de notes associée à la première diapositive de la présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si vous propaguez d’abord les paramètres du masque des notes, puis modifiez une diapositive de notes individuelle, les paramètres appliqués ultérieurement à chaque diapositive vous permettent de personnaliser cette page de notes de façon indépendante.

## **Définir les en‑têtes et pieds de page sur le masque des prospectus**

Les pages de prospectus utilisent le masque des prospectus pour leurs espaces réservés d’en‑tête, de pied de page, de date/heure et de numéro de page. Contrairement aux pages de notes, les paramètres des prospectus sont gérés via le masque des prospectus plutôt que via les prospectus individuels.

Utilisez la méthode `getMasterHandoutSlide` pour accéder au masque des prospectus. S’il n’est pas présent, appelez `setDefaultMasterHandoutSlide` pour créer le masque de prospectus par défaut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comprendre la portée et l’héritage**

Choisissez le gestionnaire d’en‑tête/pied de page qui correspond à la portée que vous souhaitez modifier :

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideheaderfootermanager/) modifie les paramètres pied de page, date/heure et numéro de diapositive pour une diapositive normale.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslideheaderfootermanager/) contrôle une diapositive de mise en page et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslideheaderfootermanager/) contrôle un masque de diapositive normal et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslideheaderfootermanager/) contrôle le masque des notes et peut propager les paramètres à toutes les diapositives de notes dépendantes.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notesslideheaderfootermanager/) modifie une diapositive de notes et prend en charge un espace réservé d’en‑tête en plus du pied de page, de la date/heure et du numéro de diapositive.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) modifie le masque des prospectus et prend en charge les quatre types d’espaces réservés.

Utilisez la propagation depuis un masque ou une mise en page lorsque le même paramètre doit s’appliquer à toute sa hiérarchie. Utilisez un gestionnaire de diapositive individuelle ou de diapositive de notes lorsque vous avez besoin d’un paramètre local pour une seule page.

## **FAQ**

**Puis‑je ajouter un en‑tête à une diapositive normale ?**

Non. PowerPoint ne définit pas d’espace réservé d’en‑tête pour les diapositives normales. Sur les diapositives normales, utilisez les espaces réservés pied de page, date/heure et numéro de diapositive. Les espaces réservés d’en‑tête sont disponibles sur les pages de notes et les prospectus.

**Que faire si un espace réservé de pied de page, de date/heure ou de numéro de diapositive n’est pas visible ?**

Utilisez le gestionnaire d’en‑tête/pied de page correspondant pour vérifier sa visibilité et l’activer si nécessaire. Par exemple, [isFooterVisible](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) indique si un espace réservé de pied de page est présent, et [setFooterVisibility](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) modifie sa visibilité.

**Comment démarrer la numérotation des diapositives à partir d’une valeur différente de 1 ?**

Appelez la méthode [setFirstSlideNumber](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#setFirstSlideNumber) de la présentation. Les espaces réservés de numéro de diapositive utilisent alors la séquence de numérotation mise à jour.

**Que se passe‑t‑il avec les en‑têtes et pieds de page lors de l’exportation en PDF, images ou HTML ?**

Les éléments d’en‑tête et de pied de page visibles sont rendus avec le reste du contenu de la présentation dans le format de sortie. Leur apparence dépend du type de page exporté et des paramètres de visibilité des espaces réservés correspondants.