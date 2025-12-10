---
title: Configurer la substitution de police dans les présentations en Java
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Activer une substitution de police optimale dans Aspose.Slides pour Java lors de la conversion de présentations PowerPoint et OpenDocument vers d'autres formats de fichier."
---

## **Définir les règles de substitution de polices**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu'une police n'est pas accessible) de la manière suivante :

1. Chargez la présentation concernée.
2. Chargez la police qui sera remplacée.
3. Chargez la nouvelle police.
4. Ajoutez une règle pour le remplacement.
5. Ajoutez la règle à la collection de règles de remplacement de police de la présentation.
6. Générez l'image de la diapositive pour observer l'effet.

Ce code Java démontre le processus de substitution de police :
```java
// Charge une présentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Charge la police source qui sera remplacée
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Charge la nouvelle police
    IFontData destFont = new FontData("Arial");
    
    // Ajoute une règle de police pour le remplacement de police
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Ajoute la règle à la collection de règles de substitution de police
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Ajoute une collection de règles de police à la liste des règles
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // La police Arial sera utilisée à la place de SomeRareFont lorsque cette dernière est inaccessible
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Enregistre l'image sur le disque au format JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Vous voudrez peut‑être consulter [**Font Replacement**](/slides/fr/java/font-replacement/). 

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Replacement](/slides/fr/java/font-replacement/) est une substitution forcée d’une police par une autre sur l’ensemble de la présentation. La substitution est une règle qui se déclenche sous une condition spécifique, par exemple lorsque la police d’origine n’est pas disponible, et alors une police de secours désignée est utilisée.

**Quand exactement les règles de substitution sont‑elles appliquées ?**

Les règles participent à la séquence standard de [font selection](/slides/fr/java/font-selection-sequence/) qui est évaluée lors du chargement, du rendu et de la conversion ; si la police choisie n’est pas disponible, le remplacement ou la substitution est appliqué.

**Quel est le comportement par défaut si ni le remplacement ni la substitution ne sont configurés et que la police est absente du système ?**

La bibliothèque essaiera de choisir la police système la plus proche disponible, de manière similaire à PowerPoint.

**Puis‑je attacher des polices externes personnalisées à l’exécution pour éviter la substitution ?**

Oui. Vous pouvez [add external fonts](/slides/fr/java/custom-font/) à l’exécution afin que la bibliothèque les prenne en compte pour la sélection et le rendu, y compris pour les conversions ultérieures.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Aspose ne distribue aucune police, payante ou gratuite ; vous ajoutez et utilisez les polices à votre propre discrétion et responsabilité.

**Existe‑t‑il des différences de comportement de substitution sous Windows, Linux et macOS ?**

Oui. La découverte des polices commence à partir des répertoires de polices du système d’exploitation. L’ensemble des polices disponibles par défaut et les chemins de recherche diffèrent selon les plateformes, ce qui influence la disponibilité et le besoin de substitution.

**Comment préparer l’environnement pour minimiser les substitutions inattendues lors de conversions par lot ?**

Synchronisez l’ensemble de polices entre les machines ou les conteneurs, [add the external fonts](/slides/fr/java/custom-font/) requis pour les documents de sortie, et [embed fonts](/slides/fr/java/embedded-font/) dans les présentations lorsque cela est possible afin que les polices choisies soient disponibles pendant le rendu.