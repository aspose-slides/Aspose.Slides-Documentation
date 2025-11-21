---
title: Simplifier le remplacement des polices dans les présentations en .NET
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/net/font-replacement/
keywords:
- police
- remplacer police
- remplacement de police
- modifier police
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Remplacez parfaitement les polices dans Aspose.Slides pour .NET afin d'assurer une typographie cohérente dans les présentations PowerPoint et OpenDocument."
---

## **Remplacer les polices**

Si vous changez d’avis concernant l’utilisation d’une police, vous pouvez la remplacer par une autre police. Toutes les occurrences de l’ancienne police seront remplacées par la nouvelle police. 

Aspose.Slides vous permet de remplacer une police de cette manière :

1. Chargez la présentation concernée. 
2. Chargez la police qui sera remplacée. 
3. Chargez la nouvelle police. 
4. Remplacez la police. 
5. Enregistrez la présentation modifiée au format PPTX.

Ce code C# illustre le remplacement de police :
```c#
// Charge une présentation
Presentation presentation = new Presentation("Fonts.pptx");

// Charge la police source qui sera remplacée
IFontData sourceFont = new FontData("Arial");

// Charge la nouvelle police
IFontData destFont = new FontData("Times New Roman");

// Remplace les polices
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Enregistre la présentation
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```


{{% alert title="Note" color="warning" %}} 

Pour définir des règles qui déterminent ce qui se passe dans certaines conditions (par exemple si une police est inaccessible), consultez [**Font Substitution**](/slides/fr/net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre « remplacement de police », « substitution de police » et « polices de secours » ?**

Le remplacement est un changement intentionnel d’une famille à une autre sur l’ensemble du document. [Substitution](/slides/fr/net/font-substitution/) est une règle du type « si la police est indisponible, utilisez X ». [Fallback](/slides/fr/net/fallback-font/) est appliqué de façon ciblée pour des glyphes manquants individuels lorsque la police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s’applique-t-il aux diapositives maîtres, aux mises en page, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation qui utilisent la police d’origine, y compris les diapositives maîtres et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de polices.

**La police change-t-elle à l’intérieur des objets OLE intégrés (par exemple Excel) ?**

Non. Le [contenu OLE](/slides/fr/net/manage-ole/) est contrôlé par son propre logiciel. Le remplacement dans la présentation ne re‑formate pas les données OLE internes ; elles peuvent être affichées sous forme d’image ou de contenu modifiable à l’extérieur.

**Puis‑je remplacer une police uniquement dans une partie de la présentation (par diapositives ou zones) ?**

Un remplacement ciblé est possible si vous changez la police au niveau des objets ou plages concernés plutôt que d’appliquer un remplacement global à l’ensemble du document. La logique de sélection de police globale lors du rendu reste la même.

**Comment déterminer à l’avance quelles polices sont utilisées par la présentation ?**

Utilisez le [gestionnaire de polices] (https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) de la présentation : il fournit une liste des [familles utilisées] (https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) et des informations sur les [substitutions/« polices inconnues »] (https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/), ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne‑t‑il lors de la conversion en PDF ou en images ?**

Oui. Lors de l’exportation, Aspose.Slides applique la même [séquence de sélection/substitution de police](/slides/fr/net/font-selection-sequence/), de sorte qu’un remplacement effectué au préalable sera respecté pendant la conversion.

**Dois‑je installer la police cible sur le système ou puis‑je simplement ajouter un dossier de polices ?**

L’installation n’est pas requise : la bibliothèque permet le [chargement de polices externes](/slides/fr/net/custom-font/) depuis des dossiers utilisateurs pour une utilisation lors du [rendu et de l’exportation](/slides/fr/net/convert-powerpoint/).

**Le remplacement corrigera‑t‑il les « tofu » (carrés) à la place des caractères ?**

Oui, mais uniquement si la police cible contient réellement les glyphes requis. Sinon, [configurez une police de secours](/slides/fr/net/fallback-font/) pour couvrir les caractères manquants.