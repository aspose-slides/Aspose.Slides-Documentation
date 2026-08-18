---
title: Gérer les en-têtes et pieds de page d'une présentation avec Python
linktitle: En-tête et pied de page
type: docs
weight: 140
url: /fr/python-net/presentation-header-and-footer/
keywords:
- "en-tête"
- "texte d'en-tête"
- "pied de page"
- "texte du pied de page"
- "définir l'en-tête"
- "définir le pied de page"
- livret
- notes
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à gérer les espaces réservés de pied de page, de date-heure, de numéro de diapositive et d'en-tête sur les diapositives, les pages de notes et les livrets avec Aspose.Slides pour Python via .NET."
---
## **Aperçu**

PowerPoint utilise différents espaces réservés d'en‑tête et de pied de page selon le type de page. Aspose.Slides for Python via .NET vous permet de contrôler le texte et la visibilité de ces espaces réservés à l'aide des classes de gestionnaire d'en‑tête/pied de page.

Les espaces réservés disponibles dépendent de la portée :

| Portée | En‑tête | Pied de page | Date/heure | Numéro de diapositive/page |
|---|---|---|---|---|
| Diapositive normale | Non | Oui | Oui | Oui |
| Maître des notes | Oui | Oui | Oui | Oui |
| Diapositive de notes | Oui | Oui | Oui | Oui |
| Maître du livret | Oui | Oui | Oui | Oui |

Une diapositive de présentation normale ne possède pas d'espace réservé d'en‑tête. Les en‑têtes sont disponibles sur les pages de notes et les livrets. Pour les diapositives normales, utilisez les espaces réservés de pied de page, de date/heure et de numéro de diapositive à la place.

La portée d'une modification dépend du gestionnaire que vous utilisez. La classe [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slideheaderfootermanager/) contrôle une diapositive normale. La classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/notesslideheaderfootermanager/) contrôle une diapositive de notes. Les gestionnaires de maître et de disposition peuvent également propager les paramètres aux diapositives dépendantes, tandis que la classe [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) contrôle le maître du livret.

## **Définir le pied de page, la date/heure et les numéros de diapositive sur les diapositives normales**

Pour les diapositives normales, le flux de travail de base consiste à accéder au gestionnaire d'en‑tête/pied de page de chaque diapositive, définir le texte du pied de page et de la date/heure, activer les espaces réservés requis, puis enregistrer la présentation. Les numéros de diapositive sont générés par la présentation, vous n’avez donc besoin que de contrôler leur visibilité.

Utilisez [`set_footer_text`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) et [`set_date_time_text`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) pour définir le texte, et utilisez [`set_footer_visibility`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/) et [`set_slide_number_visibility`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) pour afficher les espaces réservés correspondants.

L'exemple complet suivant applique le même pied de page, le même texte de date/heure et la même visibilité du numéro de diapositive à toutes les diapositives normales :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Si vous devez mettre à jour une seule diapositive, accédez directement à cette diapositive via la collection [`slides`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slides/fr/) au lieu de parcourir toute la collection.

## **Définir les en‑têtes et pieds de page sur le maître des notes**

Le maître des notes définit la mise en forme commune et le comportement des espaces réservés pour les pages de notes. Utilisez la classe [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslideheaderfootermanager/) lorsque vous souhaitez modifier uniquement le maître des notes lui‑même.

L'exemple suivant définit l'en‑tête, le pied de page et le texte de date/heure sur le maître des notes et rend tous les espaces réservés pris en charge visibles sur ce maître :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Une présentation peut ne pas contenir de maître des notes, il faut donc vérifier la valeur renvoyée pour `None` avant de la modifier.

## **Appliquer les paramètres du maître des notes aux diapositives de notes enfants**

Un maître des notes peut appliquer les paramètres d'en‑tête et de pied de page à lui‑même et à toutes les diapositives de notes dépendantes. Utilisez les méthodes de propagation dédiées sur [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslideheaderfootermanager/) lorsque les mêmes paramètres doivent être appliqués à toute la hiérarchie des notes.

Par exemple, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) et [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) mettent à jour l'en‑tête du maître des notes et tous les en‑têtes enfants. Des méthodes équivalentes existent pour les pieds de page, la date/heure et les numéros de diapositive.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Les méthodes de propagation utilisées ci‑dessus sont [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), et [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Définir les en‑têtes et pieds de page sur une diapositive de notes individuelle**

Une diapositive de notes appartient à une diapositive normale spécifique. Utilisez son gestionnaire [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/notesslideheaderfootermanager/) lorsque vous souhaitez personnaliser uniquement cette page de notes.

La méthode [`add_notes_slide`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/notesslidemanager/add_notes_slide/) renvoie la diapositive de notes pour la diapositive actuelle et en crée une si elle n'existe pas déjà. L'exemple suivant configure la page de notes associée à la première diapositive de la présentation :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Si vous propaguez d'abord les paramètres depuis le maître des notes, puis modifiez une diapositive de notes individuelle, les paramètres spécifiques à chaque diapositive vous permettent de personnaliser cette page de notes de façon indépendante.

## **Définir les en‑têtes et pieds de page sur le maître du livret**

Les pages du livret utilisent le maître du livret pour leurs espaces réservés d'en‑tête, de pied de page, de date/heure et de numéro de page. Contrairement aux pages de notes, les paramètres du livret sont gérés via le maître du livret plutôt que via les livrets individuels.

Utilisez la propriété [`master_handout_slide`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) pour accéder au maître du livret. S'il n'est pas présent, appelez [`set_default_master_handout_slide`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) pour créer le maître du livret par défaut.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprendre la portée et l'héritage**

Choisissez le gestionnaire d'en‑tête/pied de page qui correspond à la portée que vous souhaitez modifier :

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slideheaderfootermanager/) modifie les paramètres de pied de page, de date/heure et de numéro de diapositive pour une diapositive normale.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslideheaderfootermanager/) contrôle une diapositive de disposition et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslideheaderfootermanager/) contrôle un maître de diapositive normale et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslideheaderfootermanager/) contrôle le maître des notes et peut propager les paramètres à toutes les diapositives de notes dépendantes.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/notesslideheaderfootermanager/) modifie une diapositive de notes et prend en charge un espace réservé d'en‑tête en plus du pied de page, de la date/heure et du numéro de diapositive.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) modifie le maître du livret et prend en charge les quatre types d'espaces réservés.

Utilisez la propagation depuis un maître ou une disposition lorsque le même paramètre doit s'appliquer à toute sa hiérarchie. Utilisez un gestionnaire de diapositive individuelle ou de diapositive de notes lorsque vous avez besoin d'un paramètre local pour une seule page.

## **FAQ**

**Puis‑je ajouter un en‑tête à une diapositive normale ?**

Non. PowerPoint ne définit pas d'espace réservé d'en‑tête pour les diapositives normales. Sur les diapositives normales, utilisez les espaces réservés de pied de page, de date/heure et de numéro de diapositive. Les espaces réservés d'en‑tête sont disponibles sur les pages de notes et les livrets.

**Que faire si un espace réservé de pied de page, de date/heure ou de numéro de diapositive n'est pas visible ?**

Utilisez le gestionnaire d'en‑tête/pied de page correspondant pour vérifier sa visibilité et l’activer si nécessaire. Par exemple, [`is_footer_visible`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) indique si un espace réservé de pied de page est présent, et [`set_footer_visibility`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) modifie sa visibilité.

**Comment démarrer la numérotation des diapositives à partir d'une valeur autre que 1 ?**

Définissez la propriété [`first_slide_number`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/first_slide_number/) de la présentation. Les espaces réservés de numéro de diapositive utilisent alors la séquence de numérotation mise à jour.

**Que se passe‑t‑il aux en‑têtes et pieds de page lors de l’exportation vers PDF, images ou HTML ?**

Les éléments d'en‑tête et de pied de page visibles sont rendus avec le reste du contenu de la présentation dans le format de sortie. Leur apparence dépend du type de page exporté et des paramètres de visibilité des espaces réservés correspondants.