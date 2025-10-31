---
title: Configurer la substitution de police dans les présentations avec Python
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/python-net/font-substitution/
keywords:
- police
- police de substitution
- substitution de police
- remplacer la police
- remplacement de police
- règle de substitution
- règle de remplacement
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Activez la substitution de police optimale dans Aspose.Slides pour Python via .NET lors de la conversion de présentations PowerPoint et OpenDocument vers d'autres formats de fichiers."
---

## **Définir les règles de substitution**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu’une police ne peut pas être accédée) de la manière suivante :

1. Chargez la présentation pertinente.  
2. Chargez la police qui sera remplacée.  
3. Chargez la nouvelle police.  
4. Ajoutez une règle pour le remplacement.  
5. Ajoutez la règle à la collection de règles de remplacement de police de la présentation.  
6. Générez l'image de la diapositive pour observer l'effet.

Ce code Python illustre le processus de substitution de police :

```python
import aspose.slides as slides

# Charge une présentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Charge la police source qui sera remplacée
    sourceFont = slides.FontData("SomeRareFont")

    # Charge la nouvelle police
    destFont = slides.FontData("Arial")

    # Ajoute une règle de police pour le remplacement de police
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Ajoute la règle à la collection de règles de substitution de police
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Ajoute la collection de règles de police à la liste des règles
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial font will be used in place of SomeRareFont when the latter is inaccessible
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Enregistre l'image sur le disque au format JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{% alert title="NOTE" color="warning" %}} 

Vous voudrez peut‑être voir [**Remplacement de police**](/slides/fr/python-net/font-replacement/). 

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Remplacement](/slides/fr/python-net/font-replacement/) est une substitution forcée d’une police par une autre sur l’ensemble de la présentation. La substitution est une règle qui se déclenche sous une condition spécifique, par exemple lorsque la police d’origine n’est pas disponible, et une police de secours désignée est alors utilisée.

**Quand les règles de substitution sont‑elles appliquées exactement ?**

Les règles participent à la séquence standard de [sélection de police](/slides/fr/python-net/font-selection-sequence/) qui est évaluée lors du chargement, du rendu et de la conversion ; si la police choisie n’est pas disponible, le remplacement ou la substitution est appliqué.

**Quel est le comportement par défaut si ni le remplacement ni la substitution ne sont configurés et que la police est absente du système ?**

La bibliothèque essayera de choisir la police système la plus proche disponible, de manière similaire à PowerPoint.

**Puis‑je ajouter des polices externes personnalisées à l’exécution pour éviter la substitution ?**

Oui. Vous pouvez [ajouter des polices externes](/slides/fr/python-net/custom-font/) à l’exécution afin que la bibliothèque les prenne en compte pour la sélection et le rendu, y compris pour les conversions ultérieures.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Aspose ne distribue aucune police payante ou gratuite ; vous ajoutez et utilisez les polices à votre propre discrétion et responsabilité.

**Existe‑t‑il des différences de comportement de substitution sous Windows, Linux et macOS ?**

Oui. La découverte des polices commence à partir des répertoires de polices du système d’exploitation. L’ensemble des polices disponibles par défaut et les chemins de recherche diffèrent selon les plateformes, ce qui affecte la disponibilité et le besoin de substitution.

**Comment préparer l’environnement pour minimiser les substitutions inattendues lors de conversions par lots ?**

Synchronisez l’ensemble de polices entre les machines ou les conteneurs, [ajoutez les polices externes](/slides/fr/python-net/custom-font/) requises pour les documents de sortie, et [intégrez les polices](/slides/fr/python-net/embedded-font/) dans les présentations lorsque c’est possible afin que les polices choisies soient disponibles lors du rendu.