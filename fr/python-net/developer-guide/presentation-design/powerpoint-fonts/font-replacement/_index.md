---
title: Simplifier le remplacement de police dans les présentations en Python
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

Si vous changez d’avis concernant l’utilisation d’une police, vous pouvez la remplacer par une autre police. Toutes les occurrences de l’ancienne police seront remplacées par la nouvelle police. 

Aspose.Slides vous permet de remplacer une police de cette façon :

1. Charger la présentation concernée. 
2. Charger la police qui sera remplacée. 
3. Charger la nouvelle police. 
4. Remplacer la police. 
5. Enregistrer la présentation modifiée au format PPTX. 

Ce code Python montre le remplacement de police :
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

**Quelle est la différence entre « remplacement de police », « substitution de police » et « polices de secours » ?**

Le remplacement est un basculement intentionnel d’une famille à une autre sur l’ensemble du document. [Substitution](/slides/fr/python-net/font-substitution/) est une règle du type « si la police n’est pas disponible, utiliser X ». [Fallback](/slides/fr/python-net/fallback-font/) s’applique de façon chirurgicale aux glyphes manquants individuels lorsque la police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s’applique‑t‑il aux masques de diapositives, aux mises en page, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation qui utilisent la police d’origine, y compris les masques de diapositives et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de police.

**La police sera‑t‑elle modifiée à l’intérieur des objets OLE incorporés (par exemple Excel) ?**

Non. Le [contenu OLE](/slides/fr/python-net/manage-ole/) est contrôlé par son application propre. Le remplacement dans la présentation ne reformate pas les données OLE internes ; elles peuvent être affichées sous forme d’image ou de contenu éditable à l’extérieur.

**Puis‑je remplacer une police uniquement dans une partie de la présentation (par diapositive ou région) ?**

Un remplacement ciblé est possible si vous changez la police au niveau des objets/plages requis plutôt que d’appliquer un remplacement global à l’ensemble du document. La logique de sélection de police globale lors du rendu reste la même.

**Comment déterminer à l’avance quelles polices la présentation utilise réellement ?**

Utilisez le [gestionnaire de polices]**(https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)** de la présentation : il fournit une liste des [familles utilisées]**(https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/)** et des informations sur les [substitutions / « polices inconnues »]**(https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/)**, ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne‑t‑il lors de la conversion en PDF/images ?**

Oui. Lors de l’exportation, Aspose.Slides applique la même [séquence de sélection/substitution de police](/slides/fr/python-net/font-selection-sequence/), de sorte qu’un remplacement effectué au préalable sera respecté pendant la conversion.

**Dois‑je installer la police cible sur le système ou puis‑je simplement joindre un dossier de polices ?**

L’installation n’est pas obligatoire : la bibliothèque permet le [chargement de polices externes](/slides/fr/python-net/custom-font/) depuis des dossiers utilisateur pour une utilisation lors du [rendu et de l’export](/slides/fr/python-net/convert-powerpoint/).

**Le remplacement éliminera‑t‑il les « tofu » (carrés) à la place des caractères ?**

Uniquement si la police cible contient réellement les glyphes requis. Dans le cas contraire, [configurez une police de secours](/slides/fr/python-net/fallback-font/) pour couvrir les caractères manquants.