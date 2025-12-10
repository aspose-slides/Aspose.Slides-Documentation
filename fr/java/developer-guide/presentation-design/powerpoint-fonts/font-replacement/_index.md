---
title: Optimiser le remplacement de police dans les présentations en Java
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/java/font-replacement/
keywords:
- police
- remplacer police
- remplacement de police
- changer police
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Remplacez facilement les polices dans Aspose.Slides pour Java afin d'assurer une typographie cohérente dans les présentations PowerPoint et OpenDocument."
---

## **Remplacer les polices**

Si vous changez d'avis concernant l'utilisation d'une police, vous pouvez la remplacer par une autre police. Toutes les occurrences de l'ancienne police seront remplacées par la nouvelle.

Aspose.Slides vous permet de remplacer une police de cette manière :

1. Chargez la présentation concernée. 
2. Chargez la police qui sera remplacée. 
3. Chargez la nouvelle police. 
4. Remplacez la police. 
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre le remplacement de police :
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
Pour définir des règles déterminant ce qui se passe dans certaines conditions (par exemple si une police n'est pas accessible), consultez [**Substitution de police**](/slides/fr/java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre "remplacement de police", "substitution de police" et "polices de repli" ?**

Le remplacement est un basculement intentionnel d'une famille à une autre sur l'ensemble du document. La [Substitution](/slides/fr/java/font-substitution/) est une règle du type "si la police n'est pas disponible, utilisez X." Le [repli](/slides/fr/java/fallback-font/) est appliqué de façon ciblée pour les glyphes manquants individuels lorsque la police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s'applique-t-il aux diapositives maîtres, aux dispositions, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation qui utilisent la police d'origine, y compris les diapositives maîtres et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de police.

**La police sera-t-elle modifiée à l'intérieur des objets OLE intégrés (par exemple, Excel) ?**

Non. Le [contenu OLE](/slides/fr/java/manage-ole/) est contrôlé par son application propre. Le remplacement dans la présentation ne reformate pas les données OLE internes ; elles peuvent être affichées sous forme d'image ou de contenu éditable à l'extérieur.

**Puis-je remplacer une police uniquement dans une partie de la présentation (par diapositive ou région) ?**

Un remplacement ciblé est possible si vous changez la police au niveau des objets ou plages requis plutôt que d'appliquer un remplacement global à l'ensemble du document. La logique globale de sélection des polices lors du rendu reste la même.

**Comment déterminer à l'avance quelles polices la présentation utilise réellement ?**

Utilisez le [gestionnaire de polices]((https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/)) de la présentation : il fournit une liste des [familles utilisées]((https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getFonts--)) et des informations sur les [substitutions/"polices inconnues"]((https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getSubstitutions--)), ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne-t-il lors de la conversion en PDF/images ?**

Oui. Lors de l'exportation, Aspose.Slides applique la même [séquence de sélection/substitution de police](/slides/fr/java/font-selection-sequence/), de sorte qu'un remplacement effectué au préalable sera respecté pendant la conversion.

**Dois-je installer la police cible sur le système, ou puis-je joindre un dossier de polices ?**

L'installation n'est pas requise : la bibliothèque permet le [chargement de polices externes](/slides/fr/java/custom-font/) depuis des dossiers utilisateurs pour une utilisation lors du [rendu et de l'export](/slides/fr/java/convert-powerpoint/).

**Le remplacement corrigera-t-il les "tofu" (carrés) à la place des caractères ?**

Oui, uniquement si la police cible contient réellement les glyphes requis. Sinon, [configurez le repli](/slides/fr/java/fallback-font/) pour couvrir les caractères manquants.