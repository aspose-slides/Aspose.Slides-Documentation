---
title: Remplacement de police - PowerPoint API JavaScript
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/nodejs-java/font-replacement/
description: Apprenez comment remplacer les polices en utilisant la méthode de remplacement explicite dans PowerPoint avec l'API JavaScript.
---

## **Remplacer les polices**

Si vous changez d'avis concernant l'utilisation d'une police, vous pouvez remplacer cette police par une autre. Toutes les instances de l'ancienne police seront remplacées par la nouvelle police. 

Aspose.Slides vous permet de remplacer une police de cette manière :

1. Chargez la présentation concernée. 
2. Chargez la police qui sera remplacée.
3. Chargez la nouvelle police. 
4. Remplacez la police. 
5. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript illustre le remplacement de police :
```javascript
// Charge une présentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Charge la police source qui sera remplacée
    var sourceFont = new aspose.slides.FontData("Arial");
    // Charge la nouvelle police
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Remplace les polices
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Enregistre la présentation
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 

Pour définir des règles qui déterminent ce qui se passe dans certaines conditions (par exemple si une police est inaccessible), consultez [**Substitution de police**](/slides/fr/nodejs-java/font-substitution/).

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre « remplacement de police », « substitution de police » et « polices de secours » ?**

Le remplacement consiste en un changement intentionnel d’une famille à une autre sur l’ensemble du document. [Substitution](/slides/fr/nodejs-java/font-substitution/) est une règle du type « si la police est indisponible, utilisez X ». [Fallback](/slides/fr/nodejs-java/fallback-font/) est appliqué de façon ciblée pour des glyphes manquants individuels lorsque la police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s'applique-t-il aux diapositives maîtres, aux modèles, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation qui utilisent la police d'origine, y compris les diapositives maîtres et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de police.

**La police sera-t-elle modifiée dans les objets OLE intégrés (par exemple, Excel) ?**

Non. Le [contenu OLE](/slides/fr/nodejs-java/manage-ole/) est contrôlé par son application propre. Le remplacement dans la présentation ne reformate pas les données internes OLE ; il peut être affiché sous forme d’image ou de contenu éditable à l’extérieur.

**Puis-je remplacer une police uniquement dans une partie de la présentation (par diapositives ou zones) ?**

Un remplacement ciblé est possible si vous modifiez la police au niveau des objets/plages requis plutôt que d’appliquer un remplacement global à l’ensemble du document. La logique globale de sélection de la police lors du rendu reste la même.

**Comment puis‑je déterminer à l'avance quelles polices sont utilisées dans la présentation ?**

Utilisez le [gestionnaire de polices](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) : il fournit une liste des [familles utilisées](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/) et des informations sur les [substitutions/« polices inconnues »](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne-t-il lors de la conversion en PDF/images ?**

Oui. Lors de l’exportation, Aspose.Slides applique la même [séquence de sélection/substitution de police](/slides/fr/nodejs-java/font-selection-sequence/), de sorte qu’un remplacement effectué à l’avance sera respecté lors de la conversion.

**Dois‑je installer la police cible dans le système, ou puis‑je joindre un dossier de polices ?**

L’installation n’est pas requise : la bibliothèque permet le [chargement de polices externes](/slides/fr/nodejs-java/custom-font/) depuis des dossiers utilisateur pour une utilisation lors du [rendu et de l’exportation](/slides/fr/nodejs-java/convert-powerpoint/).

**Le remplacement corrigera-t-il les « tofu » (carrés) à la place des caractères ?**

Oui, uniquement si la police cible contient réellement les glyphes requis. Sinon, [configurez le fallback](/slides/fr/nodejs-java/fallback-font/) pour couvrir les caractères manquants.