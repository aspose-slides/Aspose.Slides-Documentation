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
description: "Activez la substitution de police optimale dans Aspose.Slides pour Python via .NET lors de la conversion des présentations PowerPoint et OpenDocument en d'autres formats de fichier."
---

## **Définir les règles de substitution**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu’une police est inaccessible) de cette manière :

1. Charger la présentation concernée.  
2. Charger la police qui sera remplacée.  
3. Charger la nouvelle police.  
4. Ajouter une règle pour le remplacement.  
5. Ajouter la règle à la collection de règles de remplacement de police de la présentation.  
6. Générer l’image de la diapositive pour observer l’effet.

Ce code Python montre le processus de substitution de police :
```python
import aspose.slides as slides

# Charge une présentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Charge la police source qui sera remplacée
    sourceFont = slides.FontData("SomeRareFont")

    # Charge la nouvelle police
    destFont = slides.FontData("Arial")

    # Ajoute une règle de police pour le remplacement
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Ajoute la règle à la collection de règles de substitution de police
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Ajoute la collection de règles de police à la liste des règles
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial sera utilisée à la place de SomeRareFont lorsque cette dernière est inaccessible
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Enregistre l'image sur le disque au format JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


{{%  alert title="NOTE"  color="warning"   %}} 

Vous pouvez consulter [**Remplacement de police**](/slides/fr/python-net/font-replacement/). 

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Replacement](/slides/fr/python-net/font-replacement/) est une substitution forcée d’une police par une autre sur l’ensemble de la présentation. La substitution est une règle qui se déclenche sous une condition spécifique, par exemple lorsque la police d’origine n’est pas disponible, et une police de secours désignée est alors utilisée.

**Quand les règles de substitution sont‑elles appliquées exactement ?**

Les règles participent à la séquence standard de [sélection de police](/slides/fr/python-net/font-selection-sequence/) qui est évaluée lors du chargement, du rendu et de la conversion ; si la police choisie n’est pas disponible, le remplacement ou la substitution est appliqué.

**Quel est le comportement par défaut si ni le remplacement ni la substitution ne sont configurés et que la police manque sur le système ?**

La bibliothèque tentera de choisir la police système disponible la plus proche, de la même manière que PowerPoint le ferait.

**Puis‑je ajouter des polices externes personnalisées à l’exécution pour éviter la substitution ?**

Oui. Vous pouvez [ajouter des polices externes](/slides/fr/python-net/custom-font/) à l’exécution afin que la bibliothèque les prenne en compte pour la sélection et le rendu, y compris pour les conversions ultérieures.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Aspose ne distribue aucune police payante ou gratuite ; vous ajoutez et utilisez les polices à votre propre discrétion et responsabilité.

**Existe‑t‑il des différences de comportement de substitution sous Windows, Linux et macOS ?**

Oui. La découverte des polices commence à partir des répertoires de polices du système d’exploitation. L’ensemble des polices disponibles par défaut et les chemins de recherche diffèrent selon les plateformes, ce qui influence la disponibilité et le besoin de substitution.

**Comment préparer l’environnement pour minimiser les substitutions inattendues lors de conversions en lot ?**

Synchronisez l’ensemble de polices entre les machines ou les conteneurs, [ajouter les polices externes](/slides/fr/python-net/custom-font/) requises pour les documents de sortie, et [intégrer les polices](/slides/fr/python-net/embedded-font/) dans les présentations lorsque c’est possible afin que les polices choisies soient disponibles lors du rendu.