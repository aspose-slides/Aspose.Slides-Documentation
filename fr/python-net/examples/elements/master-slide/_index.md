---
title: Diapositive maître
type: docs
weight: 30
url: /fr/python-net/examples/elements/master-slide/
keywords:
- diapositive maître
- ajouter une diapositive maître
- accéder à une diapositive maître
- supprimer une diapositive maître
- diapositive maître inutilisée
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Gérez les diapositives maîtres en Python avec Aspose.Slides : créez, modifiez, clonez et formatez les thèmes, arrière-plans, espaces réservés pour unifier les diapositives dans PowerPoint et OpenDocument."
---
Les diapositives maîtres constituent le niveau supérieur de la hiérarchie d'héritage des diapositives dans PowerPoint. Une **diapositive maître** définit des éléments de conception communs tels que les arrière-plans, les logos et la mise en forme du texte. Les **diapositives de mise en page** héritent des diapositives maîtres, et les **diapositives normales** héritent des diapositives de mise en page.

Cet article montre comment créer, modifier et gérer les diapositives maîtres à l'aide d'Aspose.Slides for Python via .NET.

## **Ajouter une diapositive maître**

Cet exemple montre comment créer une nouvelle diapositive maître en clonant celle par défaut.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Clone la diapositive maître par défaut.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Les diapositives maîtres offrent un moyen d'appliquer une identité visuelle cohérente ou des éléments de conception partagés sur toutes les diapositives. Toute modification apportée à la maître se reflétera automatiquement sur les mises en page et les diapositives normales dépendantes.

> 💡 **Tip 2:** Toutes les formes ou la mise en forme ajoutées à une diapositive maître sont héritées par les diapositives de mise en page et, à leur tour, par toutes les diapositives normales utilisant ces mises en page. L'image ci‑dessous illustre comment une zone de texte ajoutée sur une diapositive maître est automatiquement rendue sur la diapositive finale.

![Exemple d'héritage de diapositive maître](master-slide-banner.png)

## **Accéder à une diapositive maître**

Vous pouvez accéder aux diapositives maîtres à l'aide de la collection `Presentation.masters`. Voici comment les récupérer et travailler avec elles :

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Accédez à la première diapositive maître.
        first_master_slide = presentation.masters[0]
```

## **Supprimer une diapositive maître**

Les diapositives maîtres peuvent être supprimées soit par indice, soit par référence.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Supprimer par indice.
        presentation.masters.remove_at(0)

        # Ou supprimer par référence.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer les diapositives maîtres inutilisées**

Certaines présentations contiennent des diapositives maîtres qui ne sont pas utilisées. Supprimer ces diapositives peut aider à réduire la taille du fichier.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Supprimer toutes les diapositives maîtres inutilisées (même celles marquées comme Préserver).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** Utilisez `remove_unused(True)` pour nettoyer les diapositives maîtres inutilisées et minimiser la taille de la présentation.