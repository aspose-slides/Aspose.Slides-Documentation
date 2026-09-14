---
title: Supprimer des diapositives des présentations en Python
linktitle: Supprimer une diapositive
type: docs
weight: 30
url: /fr/python-java/remove-slide-from-presentation/
keywords:
- supprimer diapositive
- effacer diapositive
- supprimer diapositive inutilisée
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Supprimez facilement des diapositives des présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via Java. Obtenez des exemples de code clairs et améliorez votre flux de travail."
---
## **Introduction**

Si une diapositive (ou son contenu) devient redondante, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) qui encapsule [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/), un dépôt pour toutes les diapositives d’une présentation. En utilisant une référence ou un index d’un objet [Slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/) connu, vous pouvez spécifier la diapositive que vous souhaitez retirer. 

## **Supprimer une diapositive par référence**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive que vous souhaitez supprimer à l’aide de son ID ou de son index.
1. Supprimez la diapositive référencée de la présentation.
1. Enregistrez la présentation modifiée. 

Ce code Python montre comment supprimer une diapositive via sa référence :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancier un objet Presentation qui représente un fichier de présentation.
presentation = Presentation("demo.pptx")
try:
    # Accéder à une diapositive via son index dans la collection de diapositives.
    slide = presentation.getSlides().get_Item(0)

    # Supprimer la diapositive via sa référence.
    presentation.getSlides().remove(slide)

    # Enregistrer la présentation modifiée.
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Supprimer une diapositive par index**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Supprimez la diapositive de la présentation en utilisant sa position d’index.
1. Enregistrez la présentation modifiée. 

Ce code Python montre comment supprimer une diapositive via son index :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancier un objet Presentation qui représente un fichier de présentation.
presentation = Presentation("demo.pptx")
try:
    # Supprimer une diapositive via son index.
    presentation.getSlides().removeAt(0)

    # Enregistrer la présentation modifiée.
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Supprimer les diapositives de mise en page inutilisées**

Aspose.Slides fournit la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) (de la classe [Compress](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/)) permettant de supprimer les diapositives de mise en page indésirables et inutilisées. Ce code Python montre comment supprimer une diapositive de mise en page d’une présentation PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Supprimer les diapositives maîtres inutilisées**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/#removeUnusedMasterSlides) (de la classe [Compress](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/)) permettant de supprimer les diapositives maîtres indésirables et inutilisées. Ce code Python montre comment supprimer une diapositive maître d’une présentation PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Que se passe-t-il avec les index des diapositives après avoir supprimé une diapositive ?**

Après la suppression, la [collection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) se réindexe : chaque diapositive suivante se décale d’une position vers la gauche, de sorte que les numéros d’index précédents deviennent obsolètes. Si vous avez besoin d’une référence stable, utilisez l’ID persistant de chaque diapositive plutôt que son index.

**L'ID d’une diapositive est‑il différent de son index, et change‑t‑il lorsqu’une diapositive voisine est supprimée ?**

Oui. L’index correspond à la position de la diapositive et change lorsqu’on ajoute ou supprime des diapositives. L’ID de la diapositive est un identifiant persistant qui ne change pas lorsque d’autres diapositives sont supprimées.

**Comment la suppression d’une diapositive affecte‑t‑elle les sections de diapositives ?**

Si la diapositive appartenait à une section, cette section contiendra simplement une diapositive de moins. La structure de la section reste intacte ; si une section devient vide, vous pouvez [supprimer ou réorganiser les sections](/slides/fr/python-java/slide-section/) selon vos besoins.

**Que se passe‑t‑il avec les notes et les commentaires associés à une diapositive lorsqu’elle est supprimée ?**

[Les notes](/slides/fr/python-java/presentation-notes/) et [les commentaires](/slides/fr/python-java/presentation-comments/) sont liés à cette diapositive spécifique et sont supprimés avec elle. Le contenu des autres diapositives n’est pas affecté.

**En quoi la suppression de diapositives diffère‑t‑elle du nettoyage des mises en page/maîtres inutilisés ?**

La suppression retire des diapositives normales spécifiques du jeu. Le nettoyage des mises en page/maîtres inutilisés supprime les diapositives de mise en page ou maîtres qui ne sont référencées par aucune diapositive, réduisant la taille du fichier sans modifier le contenu des diapositives restantes. Ces actions sont complémentaires : généralement, on supprime d’abord, puis on nettoie.