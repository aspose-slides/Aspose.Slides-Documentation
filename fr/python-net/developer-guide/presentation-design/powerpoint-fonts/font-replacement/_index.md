---
title: Optimiser le remplacement des polices dans les présentations à l'aide de Python
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/python-net/font-replacement/
keywords:
- police
- remplacer police
- remplacement de police
- changer police
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Remplacez sans effort les polices dans Aspose.Slides Python via .NET pour garantir une typographie cohérente dans les présentations PowerPoint et OpenDocument."
---

## **Remplacer les polices**

Si vous changez d'avis concernant l'utilisation d'une police, vous pouvez la remplacer par une autre police. Toutes les occurrences de l'ancienne police seront remplacées par la nouvelle.

Aspose.Slides vous permet de remplacer une police de cette manière :

1. Chargez la présentation concernée.  
2. Chargez la police qui sera remplacée.  
3. Chargez la nouvelle police.  
4. Remplacez la police.  
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python démontre le remplacement de police :

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Loads a presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Loads the source font that will be replaced
    sourceFont = slides.FontData("Arial")

    # Loads the new font
    destFont = slides.FontData("Times New Roman")

    # Replaces the fonts
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Saves the presentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Remarque" color="warning" %}} 

Pour définir des règles déterminant ce qui se passe dans certaines conditions (par exemple si une police n'est pas accessible), consultez [**Substitution de police**](/slides/fr/python-net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre le « remplacement de police », la « substitution de police » et les « polices de secours » ?**

Le remplacement est un basculement intentionnel d’une famille de polices à une autre sur l’ensemble du document. [La substitution](/slides/fr/python-net/font-substitution/) est une règle du type « si la police n’est pas disponible, utiliser X ». [Le secours](/slides/fr/python-net/fallback-font/) est appliqué de façon ciblée pour les glyphes manquants individuellement lorsqu’une police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s’applique-t-il aux diapositives maîtres, aux mises en page, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation utilisant la police d’origine, y compris les diapositives maîtres et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de polices.

**La police sera-t-elle modifiée à l’intérieur des objets OLE intégrés (par exemple, Excel) ?**

Non. [Le contenu OLE](/slides/fr/python-net/manage-ole/) est contrôlé par son application propre. Le remplacement dans la présentation ne reformate pas les données OLE internes ; elles peuvent être affichées sous forme d’image ou de contenu éditable à l’extérieur.

**Puis-je remplacer une police uniquement dans une partie de la présentation (par diapositive ou région) ?**

Le remplacement ciblé est possible si vous modifiez la police au niveau des objets/plages requis plutôt que d’appliquer un remplacement global à l’ensemble du document. La logique globale de sélection des polices lors du rendu reste la même.

**Comment puis‑je déterminer à l’avance quelles polices la présentation utilise ?**

Utilisez le [gestionnaire de polices]https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/ : il fournit une liste des [familles utilisées]https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/ et des informations sur les [substitutions/« polices inconnues »]https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/, ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne‑t‑il lors de la conversion en PDF/images ?**

Oui. Lors de l’exportation, Aspose.Slides applique la même [séquence de sélection/substitution de polices](/slides/fr/python-net/font-selection-sequence/), de sorte qu’un remplacement effectué à l’avance sera respecté lors de la conversion.

**Dois‑je installer la police cible sur le système, ou puis‑je joindre un dossier de polices ?**

L’installation n’est pas obligatoire : la bibliothèque permet le [chargement de polices externes](/slides/fr/python-net/custom-font/) depuis des dossiers utilisateurs pour les utiliser lors du [rendu et de l’exportation](/slides/fr/python-net/convert-powerpoint/).

**Le remplacement corrigera‑t‑il le problème de « tofu » (carrés) à la place des caractères ?**

Uniquement si la police cible contient réellement les glyphes requis. Sinon, [configurez le secours](/slides/fr/python-net/fallback-font/) pour couvrir les caractères manquants.