---
title: Supprimer des diapositives des présentations en Python
linktitle: Supprimer la diapositive
type: docs
weight: 30
url: /fr/python-net/remove-slide-from-presentation/
keywords:
- supprimer diapositive
- effacer diapositive
- supprimer diapositive inutilisée
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Supprimez facilement des diapositives des présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Obtenez des exemples de code clairs et améliorez votre flux de travail."
---

## **Vue d'ensemble**

Si une diapositive (ou son contenu) n’est plus nécessaire, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui encapsule [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), le dépôt de toutes les diapositives d’une présentation. En utilisant une référence ou un indice vers un objet [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) connu, vous pouvez supprimer la diapositive cible.

## **Supprimer une diapositive par référence**

Lorsque vous avez déjà une référence à la diapositive cible, vous pouvez la supprimer directement. Cela évite les recherches d’indices et rend le code plus court et plus clair.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive que vous souhaitez supprimer par son ID ou son indice.
1. Supprimez la diapositive référencée de la présentation.
1. Enregistrez la présentation modifiée.

L’exemple Python suivant supprime une diapositive par référence :
```python
import aspose.slides as slides

# Instanciez la classe Presentation pour ouvrir un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Accédez à une diapositive par son indice dans la collection de diapositives.
    slide = presentation.slides[0]

    # Supprimez la diapositive par référence.
    presentation.slides.remove(slide)

    # Enregistrez la présentation modifiée.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer une diapositive par indice**

Si vous connaissez la position de la diapositive dans le jeu, supprimez‑la par son indice. Ceci est particulièrement pratique dans les boucles ou les opérations en masse où les positions sont connues à l’avance.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Supprimez la diapositive par son indice.
1. Enregistrez la présentation modifiée.

Cet exemple Python montre comment supprimer une diapositive par indice :
```python
import aspose.slides as slides

# Instanciez la classe Presentation pour ouvrir un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Supprimez la diapositive par son indice.
    presentation.slides.remove_at(0)

    # Enregistrez la présentation modifiée.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer une diapositive de mise en page inutilisée**

Aspose.Slides fournit la méthode `remove_unused_layout_slides` dans la classe [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) pour supprimer les diapositives de mise en page indésirables et inutilisées. L’exemple Python suivant montre comment supprimer les mises en page inutilisées d’une présentation PowerPoint :
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer une diapositive maître inutilisée**

Aspose.Slides fournit la méthode `remove_unused_master_slides` dans la classe [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) pour supprimer les diapositives maîtres indésirables et inutilisées. L’exemple Python suivant montre comment supprimer les maîtres inutilisés d’une présentation PowerPoint :
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Que se passe-t-il avec les indices de diapositives après la suppression d’une diapositive ?**

Après la suppression, la [collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) se ré‑indexe : chaque diapositive suivante décale d’une position vers la gauche, les numéros d’indices précédents deviennent obsolètes. Si vous avez besoin d’une référence stable, utilisez l’ID persistant de chaque diapositive plutôt que son indice.

**L’ID d’une diapositive diffère‑t‑il de son indice, et change‑t‑il lorsque les diapositives voisines sont supprimées ?**

Oui. L’indice correspond à la position de la diapositive et change lorsque des diapositives sont ajoutées ou supprimées. L’ID de la diapositive est un identifiant persistant qui ne change pas lorsque d’autres diapositives sont supprimées.

**Comment la suppression d’une diapositive affecte‑t‑elle les sections de diapositives ?**

Si la diapositive appartenait à une section, cette section contiendra simplement une diapositive de moins. La structure de la section reste ; si une section devient vide, vous pouvez [supprimer ou réorganiser les sections](/slides/fr/python-net/slide-section/) selon les besoins.

**Que se passe‑t‑il aux notes et aux commentaires attachés à une diapositive lorsqu’elle est supprimée ?**

[Notes](/slides/fr/python-net/presentation-notes/) et [commentaires](/slides/fr/python-net/presentation-comments/) sont liés à cette diapositive spécifique et sont supprimés avec elle. Le contenu des autres diapositives n’est pas affecté.

**En quoi la suppression de diapositives diffère‑t‑elle du nettoyage des mises en page/maîtres inutilisés ?**

Supprimer enlève des diapositives normales spécifiques du jeu. Nettoyer les mises en page/maîtres inutilisés supprime les diapositives de mise en page ou maîtres qui ne sont référencées par aucune diapositive, réduisant la taille du fichier sans modifier le contenu des diapositives restantes. Ces actions sont complémentaires : généralement supprimer d’abord, puis nettoyer.