---
title: Remplacement de police - PowerPoint C# API
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/net/font-replacement/
keywords: "Police, remplacer police, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: Avec l'API PowerPoint C#, vous pouvez remplacer explicitement une police par une autre police dans la présentation.
---

## **Remplacer les polices**

Si vous changez d'avis concernant l'utilisation d'une police, vous pouvez remplacer cette police par une autre police. Toutes les occurrences de l'ancienne police seront remplacées par la nouvelle police.

Aspose.Slides vous permet de remplacer une police de cette manière:

1. Chargez la présentation concernée. 
2. Chargez la police qui sera remplacée. 
3. Chargez la nouvelle police. 
4. Remplacez la police. 
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# illustre le remplacement de police:
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

Pour définir des règles déterminant ce qui se passe dans certaines conditions (par exemple si une police est inaccessible), consultez [**Substitution de police**](/slides/fr/net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre "remplacement de police", "substitution de police" et les polices de secours ?**

Le remplacement est un changement intentionnel d’une famille à une autre sur l’ensemble du document. [Substitution](/slides/fr/net/font-substitution/) est une règle du type « si la police est indisponible, utilisez X ». [Fallback](/slides/fr/net/fallback-font/) est appliqué de manière ciblée pour les glyphes manquants individuels lorsque la police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s’applique-t-il aux diapositives maîtres, aux mises en page, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation qui utilisent la police d’origine, y compris les diapositives maîtres et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de police.

**La police sera-t-elle modifiée dans les objets OLE intégrés (par exemple, Excel) ?**

Non. Le [contenu OLE](/slides/fr/net/manage-ole/) est géré par son propre application. Le remplacement dans la présentation ne reformatte pas les données OLE internes ; elles peuvent être affichées sous forme d’image ou de contenu éditable à l’extérieur.

**Puis-je remplacer une police uniquement dans une partie de la présentation (par diapositives ou régions) ?**

Un remplacement ciblé est possible si vous changez la police au niveau des objets/plages requis plutôt que d’appliquer un remplacement global à l’ensemble du document. La logique globale de sélection de police lors du rendu reste la même.

**Comment déterminer à l’avance quelles polices la présentation utilise réellement ?**

Utilisez le [gestionnaire de polices](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) de la présentation : il fournit une liste des [familles utilisées](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) et des informations sur les [substitutions/"polices inconnues"] (https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/), ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne-t-il lors de la conversion en PDF/images ?**

Oui. Lors de l’exportation, Aspose.Slides applique la même [séquence de sélection/substitution de police](/slides/fr/net/font-selection-sequence/), de sorte qu’un remplacement effectué à l’avance sera respecté lors de la conversion.

**Dois-je installer la police cible sur le système, ou puis‑je joindre un dossier de polices ?**

L’installation n’est pas requise : la bibliothèque permet le [chargement de polices externes](/slides/fr/net/custom-font/) depuis les dossiers utilisateur pour une utilisation lors du [rendu et de l’exportation](/slides/fr/net/convert-powerpoint/).

**Le remplacement corrigera-t-il le « tofu » (carrés) à la place des caractères ?**

Seulement si la police cible contient réellement les glyphes requis. Sinon, [configurez le fallback](/slides/fr/net/fallback-font/) pour couvrir les caractères manquants.