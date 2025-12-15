---
title: Configurer la substitution de police dans les présentations sur Android
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "Activez une substitution de police optimale dans Aspose.Slides pour Android via Java lors de la conversion de présentations PowerPoint et OpenDocument vers d'autres formats de fichier."
---

## **Définir les règles de substitution de police**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu'une police n'est pas accessible) de cette manière :

1. Charger la présentation concernée.
2. Charger la police qui sera remplacée.
3. Charger la nouvelle police.
4. Ajouter une règle pour le remplacement.
5. Ajouter la règle à la collection de règles de remplacement de police de la présentation.
6. Générer l'image de la diapositive pour observer l'effet.

Ce code Java illustre le processus de substitution de police :
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
    
    // Ajoute la règle à la collection des règles de substitution de police
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

Vous voudrez peut-être consulter [**Font Replacement**](/slides/fr/androidjava/font-replacement/).

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Replacement](/slides/fr/androidjava/font-replacement/) est un remplacement forcé d'une police par une autre sur l'ensemble de la présentation. La substitution est une règle qui se déclenche dans une condition spécifique, par exemple lorsque la police d'origine n'est pas disponible, et alors une police de secours désignée est utilisée.

**Quand les règles de substitution sont‑elles appliquées exactement ?**

Les règles participent à la séquence standard [font selection](/slides/fr/androidjava/font-selection-sequence/) qui est évaluée lors du chargement, du rendu et de la conversion ; si la police choisie n'est pas disponible, le remplacement ou la substitution est appliqué.

**Quel est le comportement par défaut si aucun remplacement ni aucune substitution n'est configuré et que la police est absente du système ?**

La bibliothèque tentera de choisir la police système la plus proche disponible, similaire à ce que ferait PowerPoint.

**Puis‑je joindre des polices externes personnalisées au moment de l'exécution pour éviter la substitution ?**

Oui. Vous pouvez [add external fonts](/slides/fr/androidjava/custom-font/) au moment de l'exécution afin que la bibliothèque les prenne en compte pour la sélection et le rendu, y compris pour les conversions ultérieures.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Aspose ne distribue pas de polices payantes ou gratuites ; vous ajoutez et utilisez les polices à votre propre discrétion et responsabilité.

**Existe‑t‑il des différences de comportement de substitution sous Windows, Linux et macOS ?**

Oui. La découverte des polices commence à partir des répertoires de polices du système d'exploitation. L'ensemble des polices disponibles par défaut et les chemins de recherche diffèrent selon les plateformes, ce qui affecte la disponibilité et le besoin de substitution.

**Comment préparer l'environnement pour minimiser les substitutions inattendues lors de conversions par lots ?**

Synchronisez l'ensemble de polices entre les machines ou les conteneurs, [add the external fonts](/slides/fr/androidjava/custom-font/) nécessaires pour les documents de sortie, et [embed fonts](/slides/fr/androidjava/embedded-font/) dans les présentations lorsque cela est possible afin que les polices choisies soient disponibles pendant le rendu.