---
title: Rationaliser le remplacement des polices dans les présentations avec C++
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/cpp/font-replacement/
keywords:
- police
- remplacer police
- remplacement de police
- modifier police
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Remplacez les polices de façon transparente dans Aspose.Slides pour C++ afin d’assurer une typographie cohérente dans les présentations PowerPoint et OpenDocument."
---

## **Remplacer les polices**

Si vous changez d'avis concernant l'utilisation d'une police, vous pouvez remplacer cette police par une autre police. Toutes les occurrences de l'ancienne police seront remplacées par la nouvelle police. 

Aspose.Slides vous permet de remplacer une police de cette façon :

1. Chargez la présentation concernée. 
2. Chargez la police qui sera remplacée. 
3. Chargez la nouvelle police. 
4. Remplacez la police. 
5. Enregistrez la présentation modifiée au format PPTX. 

Ce code C++ montre le remplacement de police :
``` cpp
// Charge une présentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Charge la police source qui sera remplacée
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Charge la nouvelle police
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Remplace les polices
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Enregistre la présentation
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

Pour définir des règles qui déterminent ce qui se produit dans certaines conditions (par exemple si une police n'est pas accessible), consultez [**Font Substitution**](/slides/fr/cpp/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre "remplacement de police", "substitution de police" et "polices de secours" ?**

Le remplacement est un changement intentionnel d'une famille à une autre sur l'ensemble du document. [Substitution](/slides/fr/cpp/font-substitution/) est une règle du type « si la police est indisponible, utilisez X. ». [Fallback](/slides/fr/cpp/fallback-font/) est appliqué de façon ciblée pour les glyphes manquants individuels lorsque la police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s'applique-t-il aux diapositives maîtres, aux mises en page, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation qui utilisent la police originale, y compris les diapositives maîtres et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de police.

**La police sera-t-elle modifiée à l'intérieur des objets OLE intégrés (par exemple, Excel) ?**

Non. Le [OLE content](/slides/fr/cpp/manage-ole/) est contrôlé par son propre application. Le remplacement dans la présentation ne reformate pas les données OLE internes ; elles peuvent être affichées sous forme d'image ou de contenu éditable externément.

**Puis-je remplacer une police uniquement dans une partie de la présentation (par diapositives ou zones) ?**

Un remplacement ciblé est possible si vous changez la police au niveau des objets/plages requis plutôt que d'appliquer un remplacement global à l'ensemble du document. La logique globale de sélection de police lors du rendu reste la même.

**Comment puis‑je déterminer à l'avance quelles polices la présentation utilise réellement ?**

Utilisez le [font manager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) de la présentation : il fournit une liste des [families in use](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/) et des informations sur les [substitutions/"unknown" fonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getsubstitutions/), ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne‑t‑il lors de la conversion en PDF/images ?**

Oui. Lors de l'exportation, Aspose.Slides applique la même [font selection/substitution sequence](/slides/fr/cpp/font-selection-sequence/), de sorte qu'un remplacement effectué à l'avance sera respecté lors de la conversion.

**Dois‑je installer la police cible sur le système, ou puis‑je joindre un dossier de polices ?**

L'installation n'est pas requise : la bibliothèque permet le [loading external fonts](/slides/fr/cpp/custom-font/) depuis des dossiers d'utilisateur pour une utilisation lors du [rendering and export](/slides/fr/cpp/convert-powerpoint/).

**Le remplacement corrigera‑t‑il les « tofu » (carrés) au lieu des caractères ?**

Seulement si la police cible contient réellement les glyphes requis. Sinon, [configure fallback](/slides/fr/cpp/fallback-font/) pour couvrir les caractères manquants.