---
title: Simplifier le remplacement de polices dans les présentations en utilisant Python via Java
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/python-java/font-replacement/
keywords:
- police
- remplacer police
- remplacement de police
- modifier police
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Remplacez les polices de manière fluide dans Aspose.Slides pour Python via Java afin d’assurer une typographie cohérente dans les présentations PowerPoint et OpenDocument."
---
## **Aperçu**

Aspose.Slides vous permet de remplacer une police par une autre dans l’ensemble d’une présentation. Lorsqu’une police est remplacée, toutes les instances de la police d’origine sont remplacées par la nouvelle police.

Pour effectuer le remplacement de police, chargez la présentation, définissez la police source et la police de remplacement, appelez la méthode de remplacement de police et enregistrez la présentation modifiée au format PPTX. Cette approche est utile lorsque vous souhaitez intentionnellement passer d’une famille de polices à une autre dans toute la présentation.

## **Remplacer des polices**

Si vous changez d’avis concernant l’utilisation d’une police, vous pouvez remplacer cette police par une autre. Toutes les instances de l’ancienne police seront remplacées par la nouvelle police.

Aspose.Slides vous permet de remplacer une police de cette manière :

1. Chargez la présentation concernée. 
2. Chargez la police qui sera remplacée. 
3. Chargez la nouvelle police. 
4. Remplacez la police. 
5. Enregistrez la présentation modifiée au format PPTX. 

Ce code Python démontre le remplacement de police :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Charger une présentation.
presentation = Presentation("Fonts.pptx")
try:
    # Charger la police source qui sera remplacée.
    source_font = FontData("Arial")

    # Charger la nouvelle police.
    destination_font = FontData("Times New Roman")

    # Remplacer la police.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Enregistrer la présentation.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}} 
Pour définir des règles qui déterminent ce qui se passe dans certaines conditions (par exemple si une police n’est pas accessible), consultez [Substitution de police](/slides/fr/python-java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre "remplacement de police", "substitution de police" et "polices de secours"?**

Le remplacement est un passage intentionnel d’une famille à une autre sur l’ensemble du document. [Substitution](/slides/fr/python-java/font-substitution/) est une règle du type « si la police n’est pas disponible, utilisez X ». [Fallback](/slides/fr/python-java/fallback-font/) s’applique aux glyphes manquants individuels lorsque la police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s’applique-t-il aux diapositives maîtres, aux mises en page, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation qui utilisent la police d’origine, y compris les diapositives maîtres et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de police.

**La police sera-t-elle modifiée dans les objets OLE intégrés (par exemple, Excel) ?**

Non. [Contenu OLE](/slides/fr/python-java/manage-ole/) est contrôlé par son propre logiciel. Le remplacement dans la présentation ne reformate pas les données OLE internes ; elles peuvent être affichées sous forme d’image ou de contenu modifiable à l’extérieur.

**Puis-je remplacer une police uniquement dans une partie de la présentation (par diapositives ou régions) ?**

Un remplacement ciblé est possible si vous changez la police au niveau des objets ou plages requis plutôt que d’appliquer un remplacement global à l’ensemble du document. La logique de sélection des polices globale lors du rendu reste la même.

**Comment puis-je déterminer à l’avance quelles polices la présentation utilise ?**

Utilisez le [font manager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/) de la présentation : il fournit une liste des [families in use](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getFonts) et des informations sur les [substitutions/"unknown" fonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getSubstitutions), ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne-t-il lors de la conversion en PDF/images ?**

Oui. Lors de l’exportation, Aspose.Slides applique la même [séquence de sélection/substitution de police](/slides/fr/python-java/font-selection-sequence/), de sorte qu’un remplacement effectué à l’avance sera respecté lors de la conversion.

**Dois‑je installer la police cible dans le système, ou puis‑je joindre un dossier de polices ?**

L’installation n’est pas requise : la bibliothèque permet le [chargement de polices externes](/slides/fr/python-java/custom-font/) depuis les dossiers utilisateur pour une utilisation lors du [rendu et de l’exportation](/slides/fr/python-java/convert-powerpoint/).

**Le remplacement corrigera-t-il le « tofu » (carrés) au lieu des caractères ?**

Seulement si la police cible contient réellement les glyphes requis. Sinon, [configurez la police de secours](/slides/fr/python-java/fallback-font/) pour couvrir les caractères manquants.