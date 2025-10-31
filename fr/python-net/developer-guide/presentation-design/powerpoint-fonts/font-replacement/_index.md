---
title: Simplifier le remplacement de police dans les présentations à l'aide de Python
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/python-net/font-replacement/
keywords:
- police
- remplacer police
- remplacement de police
- modifier police
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Remplacez les polices de manière transparente dans Aspose.Slides Python via .NET pour garantir une typographie cohérente dans les présentations PowerPoint et OpenDocument."
---

## **Remplacer les polices**

Si vous changez d'avis concernant l'utilisation d'une police, vous pouvez la remplacer par une autre police. Toutes les occurrences de l'ancienne police seront remplacées par la nouvelle. 

Aspose.Slides permet de remplacer une police de cette façon :

1. Chargez la présentation concernée. 
2. Chargez la police qui sera remplacée. 
3. Chargez la nouvelle police. 
4. Remplacez la police. 
5. Enregistrez la présentation modifiée sous forme de fichier PPTX. 

Ce code Python démontre le remplacement de police :

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Charge une présentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Charge la police source qui sera remplacée
    sourceFont = slides.FontData("Arial")

    # Charge la nouvelle police
    destFont = slides.FontData("Times New Roman")

    # Remplace les polices
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Enregistre la présentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

Pour définir des règles qui déterminent ce qui se passe dans certaines conditions (par exemple si une police est inaccessible), consultez [**Substitution de police**](/slides/fr/python-net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre « remplacement de police », « substitution de police » et les polices de secours ?**

Le remplacement est un changement intentionnel d'une famille à une autre sur l'ensemble du document. La [Substitution](/slides/fr/python-net/font-substitution/) est une règle du type « si la police est indisponible, utilisez X ». Le [fallback](/slides/fr/python-net/fallback-font/) s'applique de manière ciblée aux glyphes manquants individuels lorsque la police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s'applique-t-il aux diapositives maîtres, aux mises en page, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation qui utilisent la police d'origine, y compris les diapositives maîtres et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de police.

**La police sera-t-elle modifiée dans les objets OLE incorporés (par exemple, Excel) ?**

Non. Le [contenu OLE](/slides/fr/python-net/manage-ole/) est contrôlé par son propre application. Le remplacement dans la présentation ne reformate pas les données OLE internes ; elles peuvent être affichées sous forme d’image ou de contenu modifiable à l'extérieur.

**Puis-je remplacer une police uniquement dans une partie de la présentation (par diapositives ou régions) ?**

Un remplacement ciblé est possible si vous changez la police au niveau des objets/plages requis plutôt que d'appliquer un remplacement global à l'ensemble du document. La logique globale de sélection de police lors du rendu reste la même.

**Comment déterminer à l'avance quelles polices la présentation utilise réellement ?**

Utilisez le [gestionnaire de polices](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) de la présentation : il fournit une liste des [familles utilisées](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) et des informations sur les [substitutions/« polices inconnues »](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/), ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne-t-il lors de la conversion en PDF/images ?**

Oui. Lors de l'exportation, Aspose.Slides applique la même [séquence de sélection/substitution de police](/slides/fr/python-net/font-selection-sequence/), de sorte qu'un remplacement effectué au préalable sera respecté pendant la conversion.

**Dois-je installer la police cible dans le système, ou puis-je joindre un dossier de polices ?**

L'installation n'est pas requise : la bibliothèque permet le [chargement de polices externes](/slides/fr/python-net/custom-font/) depuis des dossiers utilisateur pour une utilisation lors du [rendu et de l'exportation](/slides/fr/python-net/convert-powerpoint/).

**Le remplacement corrigera-t-il les « tofu » (carrés) à la place des caractères ?**

Oui, uniquement si la police cible contient réellement les glyphes requis. Sinon, [configurez le fallback](/slides/fr/python-net/fallback-font/) pour couvrir les caractères manquants.