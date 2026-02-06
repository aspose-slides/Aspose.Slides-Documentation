---
title: Diapositive de mise en page
type: docs
weight: 20
url: /fr/python-net/examples/elements/layout-slide/
keywords:
- diapositive de mise en page
- ajouter diapositive de mise en page
- accéder à la diapositive de mise en page
- supprimer diapositive de mise en page
- diapositive de mise en page inutilisée
- dupliquer diapositive de mise en page
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Utilisez Python pour gérer les diapositives de mise en page avec Aspose.Slides : créez, appliquez, dupliquez, renommez et personnalisez les espaces réservés et les thèmes dans les présentations au format PPT, PPTX et ODP."
---
Cet article montre comment travailler avec **Layout Slides** dans Aspose.Slides for Python via .NET. Une diapositive de mise en page définit la conception et le formatage hérités par les diapositives normales. Vous pouvez ajouter, accéder, dupliquer et supprimer des diapositives de mise en page, ainsi que nettoyer celles qui ne sont pas utilisées pour réduire la taille de la présentation.

## **Ajouter une diapositive de mise en page**

Vous pouvez créer une diapositive de mise en page personnalisée pour définir un formatage réutilisable.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Créez une diapositive de mise en page avec le type et le nom spécifiés.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Conseil 1 :** Les diapositives de mise en page servent de modèles pour les diapositives individuelles. Vous pouvez définir des éléments communs une fois et les réutiliser sur de nombreuses diapositives.

> 💡 **Conseil 2 :** Lorsque vous ajoutez des formes ou du texte à une diapositive de mise en page, toutes les diapositives basées sur cette mise en page afficheront automatiquement ce contenu partagé.
> La capture d'écran ci-dessous montre deux diapositives, chacune héritant d'une zone de texte de la même diapositive de mise en page.

![Slides Inheriting Layout Content](layout-slide-result.png)


## **Accéder à une diapositive de mise en page**

Les diapositives de mise en page peuvent être accessibles par index ou par type de mise en page (par exemple, `Blank`, `Title`, `SectionHeader`, etc.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Accéder par indice.
        first_layout_slide = presentation.layout_slides[0]

        # Accéder par type de mise en page.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Supprimer une diapositive de mise en page**

Vous pouvez supprimer une diapositive de mise en page spécifique si elle n'est plus nécessaire.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Obtenez une diapositive de mise en page par type et supprimez‑la.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer les diapositives de mise en page inutilisées**

Pour réduire la taille de la présentation, vous pouvez souhaiter supprimer les diapositives de mise en page qui ne sont utilisées par aucune diapositive normale.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Supprime automatiquement toutes les diapositives de mise en page qui ne sont référencées par aucune diapositive.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Dupliquer une diapositive de mise en page**

Vous pouvez dupliquer une diapositive de mise en page en utilisant la méthode `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Obtenez une diapositive de mise en page existante par type.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Dupliquez la diapositive de mise en page à la fin de la collection de diapositives de mise en page.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Résumé :** Les diapositives de mise en page sont des outils puissants pour gérer un formatage cohérent sur les diapositives. Aspose.Slides offre un contrôle complet sur la création, la gestion et l'optimisation des diapositives de mise en page.