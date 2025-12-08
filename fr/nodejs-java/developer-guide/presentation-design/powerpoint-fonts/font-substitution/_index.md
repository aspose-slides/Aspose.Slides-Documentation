---
title: Substitution de police - API JavaScript PowerPoint
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/nodejs-java/font-substitution/
keywords: "Police, substitution de police, présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Substitution de police dans PowerPoint en JavaScript"
---

## **Définir les règles de substitution de police**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu’une police n’est pas accessible) de la manière suivante :

1. Charger la présentation concernée.
2. Charger la police qui sera remplacée.
3. Charger la nouvelle police.
4. Ajouter une règle pour le remplacement.
5. Ajouter la règle à la collection des règles de remplacement de police de la présentation.
6. Générer l’image de la diapositive pour observer l’effet.

Ce code JavaScript illustre le processus de substitution de police :
```javascript
// Charge une présentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Charge la police source qui sera remplacée
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Charge la nouvelle police
    var destFont = new aspose.slides.FontData("Arial");
    // Ajoute une règle de police pour le remplacement
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Ajoute la règle à la collection des règles de substitution de police
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Ajoute une collection de règles de police à la liste des règles
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // La police Arial sera utilisée à la place de SomeRareFont lorsque cette dernière est inaccessible
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Enregistre l'image sur le disque au format JPEG
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Vous pouvez consulter [**Remplacement de police**](/slides/fr/nodejs-java/font-replacement/).

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Replacement](/slides/fr/nodejs-java/font-replacement/) est un remplacement forcé d’une police par une autre sur l’ensemble de la présentation. La substitution est une règle qui s’active sous une condition spécifique, par exemple lorsque la police d’origine est indisponible, et une police de secours désignée est alors utilisée.

**Quand exactement les règles de substitution sont‑elles appliquées ?**

Les règles participent à la séquence standard de [sélection de police](/slides/fr/nodejs-java/font-selection-sequence/) qui est évaluée lors du chargement, du rendu et de la conversion ; si la police choisie est indisponible, le remplacement ou la substitution est appliqué.

**Quel est le comportement par défaut si ni remplacement ni substitution n’est configuré et que la police est manquante sur le système ?**

La bibliothèque essaiera de choisir la police système disponible la plus proche, similaire à ce que ferait PowerPoint.

**Puis‑je attacher des polices externes personnalisées au moment de l’exécution pour éviter la substitution ?**

Oui. Vous pouvez [ajouter des polices externes](/slides/fr/nodejs-java/custom-font/) au moment de l’exécution afin que la bibliothèque les prenne en compte pour la sélection et le rendu, y compris pour les conversions ultérieures.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Aspose ne distribue ni polices payantes ni gratuites ; vous ajoutez et utilisez les polices à votre propre discrétion et responsabilité.

**Existe‑t‑il des différences de comportement de substitution sous Windows, Linux et macOS ?**

Oui. La découverte des polices commence à partir des répertoires de polices du système d’exploitation. L’ensemble des polices disponibles par défaut et les chemins de recherche diffèrent selon les plateformes, ce qui affecte la disponibilité et le besoin de substitution.

**Comment préparer l’environnement pour minimiser les substitutions inattendues lors de conversions par lots ?**

Synchronisez l’ensemble des polices entre les machines ou les conteneurs, [ajouter les polices externes](/slides/fr/nodejs-java/custom-font/) requises pour les documents de sortie, et [intégrer les polices](/slides/fr/nodejs-java/embedded-font/) dans les présentations lorsque cela est possible afin que les polices choisies soient disponibles lors du rendu.