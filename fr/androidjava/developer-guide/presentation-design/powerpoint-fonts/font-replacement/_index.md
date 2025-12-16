---
title: Simplifier le remplacement de polices dans les présentations sur Android
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/androidjava/font-replacement/
keywords:
- police
- remplacer police
- remplacement de police
- modifier police
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Remplacez parfaitement les polices dans Aspose.Slides pour Android via Java afin d'assurer une typographie cohérente dans les présentations PowerPoint et OpenDocument."
---

## **Remplacer les polices**

Si vous changez d'avis concernant l'utilisation d'une police, vous pouvez remplacer cette police par une autre. Toutes les occurrences de l'ancienne police seront remplacées par la nouvelle police. 

Aspose.Slides vous permet de remplacer une police de cette façon :

1. Chargez la présentation concernée. 
2. Chargez la police qui sera remplacée.
3. Chargez la nouvelle police. 
4. Remplacez la police. 
5. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Java illustre le remplacement de police :
```java
// Charge une présentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Charge la police source qui sera remplacée
    IFontData sourceFont = new FontData("Arial");
    
    // Charge la nouvelle police
    IFontData destFont = new FontData("Times New Roman");
    
    // Remplace les polices
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Enregistre la présentation
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Pour définir des règles déterminant ce qui se passe dans certaines conditions (par exemple, si une police n'est pas accessible), voir [**Substitution de police**](/slides/fr/androidjava/font-substitution/).

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre "remplacement de police", "substitution de police" et "polices de secours" ?**

Le remplacement est un changement intentionnel d’une famille à une autre sur l’ensemble du document. [Substitution](/slides/fr/androidjava/font-substitution/) est une règle du type « si la police n’est pas disponible, utilisez X ». [Fallback](/slides/fr/androidjava/fallback-font/) est appliqué de manière ciblée pour les glyphes manquants individuels lorsque la police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s'applique-t-il aux diapositives maîtres, aux mises en page, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation qui utilisent la police originale, y compris les diapositives maîtres et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de police.

**La police change-t-elle à l'intérieur des objets OLE incorporés (par exemple, Excel) ?**

Non. Le [contenu OLE](/slides/fr/androidjava/manage-ole/) est contrôlé par son application propre. Le remplacement dans la présentation ne reformatte pas les données OLE internes ; elles peuvent être affichées sous forme d’image ou de contenu modifiable à l’extérieur.

**Puis-je remplacer une police seulement dans une partie de la présentation (par diapositives ou régions) ?**

Un remplacement ciblé est possible si vous modifiez la police au niveau des objets ou plages requis plutôt que d’appliquer un remplacement global à l’ensemble du document. La logique globale de sélection des polices lors du rendu reste la même.

**Comment déterminer à l'avance quelles polices la présentation utilise réellement ?**

Utilisez le [gestionnaire de polices](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/) de la présentation : il fournit une liste des [familles utilisées](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--) et des informations sur les [substitutions/"polices inconnues"](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne-t-il lors de la conversion en PDF/images ?**

Oui. Lors de l'exportation, Aspose.Slides applique la même [séquence de sélection/substitution de police](/slides/fr/androidjava/font-selection-sequence/), de sorte qu’un remplacement effectué à l’avance sera respecté lors de la conversion.

**Dois‑je installer la police cible sur le système, ou puis‑je joindre un dossier de polices ?**

L’installation n’est pas nécessaire : la bibliothèque permet le [chargement de polices externes](/slides/fr/androidjava/custom-font/) à partir de dossiers utilisateur pour une utilisation lors du [rendu et de l’exportation](/slides/fr/androidjava/convert-powerpoint/).

**Le remplacement corrigera-t-il les « tofu » (carrés) à la place des caractères ?**

Seulement si la police cible contient réellement les glyphes requis. Sinon, [configurez le fallback](/slides/fr/androidjava/fallback-font/) pour couvrir les caractères manquants.