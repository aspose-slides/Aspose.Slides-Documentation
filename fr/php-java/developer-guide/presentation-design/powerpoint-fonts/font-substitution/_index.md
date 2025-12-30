---
title: Configurer la substitution de police dans les présentations avec PHP
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/php-java/font-substitution/
keywords:
- police
- police de substitution
- substitution de police
- remplacement de police
- remplacement de police
- règle de substitution
- règle de remplacement
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Activez la substitution de police optimale dans Aspose.Slides pour PHP via Java lors de la conversion de présentations PowerPoint et OpenDocument vers d'autres formats de fichier."
---

## **Définir les règles de substitution de police**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu'une police ne peut pas être accédée) de la manière suivante :

1. Charger la présentation concernée.
2. Charger la police qui sera remplacée.
3. Charger la nouvelle police.
4. Ajouter une règle pour le remplacement.
5. Ajouter la règle à la collection de règles de remplacement de police de la présentation.
6. Générer l'image de la diapositive pour observer l'effet.

Ce code PHP illustre le processus de substitution de police :
```php
  # Charge une présentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Charge la police source qui sera remplacée
    $sourceFont = new FontData("SomeRareFont");
    # Charge la nouvelle police
    $destFont = new FontData("Arial");
    # Ajoute une règle de police pour le remplacement de police
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Ajoute la règle à la collection de règles de substitution de police
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Ajoute une collection de règles de police à la liste des règles
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # La police Arial sera utilisée à la place de SomeRareFont lorsque celle-ci est inaccessible
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Sauvegarde l'image sur le disque au format JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert title="NOTE"  color="warning"   %}} 
Vous pouvez consulter [**Remplacement de police**](/slides/fr/php-java/font-replacement/).
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Remplacement](/slides/fr/php-java/font-replacement/) est un remplacement forcé d'une police par une autre sur l'ensemble de la présentation. La substitution est une règle qui se déclenche sous une condition spécifique, par exemple lorsque la police d'origine n'est pas disponible, et alors une police de secours désignée est utilisée.

**Quand exactement les règles de substitution sont‑elles appliquées ?**

Les règles participent à la séquence standard de [sélection de police](/slides/fr/php-java/font-selection-sequence/) qui est évaluée lors du chargement, du rendu et de la conversion ; si la police choisie n'est pas disponible, le remplacement ou la substitution est appliqué.

**Quel est le comportement par défaut si aucun remplacement ni substitution n'est configuré et que la police est manquante sur le système ?**

La bibliothèque essaiera de choisir la police système disponible la plus proche, de manière similaire à PowerPoint.

**Puis‑je joindre des polices externes personnalisées à l'exécution pour éviter la substitution ?**

Oui. Vous pouvez [ajouter des polices externes](/slides/fr/php-java/custom-font/) à l'exécution afin que la bibliothèque les prenne en compte pour la sélection et le rendu, y compris pour les conversions ultérieures.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Aspose ne distribue ni polices payantes ni gratuites ; vous ajoutez et utilisez les polices à votre propre discrétion et responsabilité.

**Existe‑t‑il des différences de comportement de substitution sous Windows, Linux et macOS ?**

Oui. La découverte des polices commence à partir des répertoires de polices du système d'exploitation. L'ensemble des polices disponibles par défaut et les chemins de recherche diffèrent selon les plates‑formes, ce qui affecte la disponibilité et le besoin de substitution.

**Comment préparer l'environnement pour minimiser les substitutions inattendues lors de conversions par lots ?**

Synchronisez l'ensemble des polices entre les machines ou les conteneurs, [ajoutez les polices externes](/slides/fr/php-java/custom-font/) requises pour les documents de sortie, et [intégrez les polices](/slides/fr/php-java/embedded-font/) dans les présentations lorsque cela est possible afin que les polices choisies soient disponibles lors du rendu.