---
title: Séquence de sélection de police dans Aspose.Slides pour Python
linktitle: Sélection de police
type: docs
weight: 80
url: /fr/python-net/font-selection-sequence/
keywords:
- sélection de police
- substitution de police
- remplacement de police
- règle de substitution
- police disponible
- police manquante
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour Python via .NET sélectionne les polices, assurant une présentation nette et cohérente des fichiers PPT, PPTX et ODP — améliorez vos diapositives dès maintenant."
---

## **Sélection de police**

Certaines règles s'appliquent aux polices dans une présentation lorsque celle-ci est chargée, rendue ou convertie vers un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées pour s’assurer que les polices choisies sont disponibles dans le système d’exploitation. Si les polices sont confirmées comme manquantes, elles sont remplacées — voir [**Remplacement de police**](https://docs.aspose.com/slides/python-net/font-replacement/) et [**Substitution de police**](https://docs.aspose.com/slides/python-net/font-substitution/).

Voici le processus qu'Aspose.Slides suit lorsqu'il manipule les polices :

1. Aspose.Slides recherche les polices dans le système d’exploitation afin de trouver la police qui correspond à la police choisie dans la présentation.  
2. Si la police choisie est trouvée, Aspose.Slides l’utilise. Sinon, Aspose.Slides utilise une police de remplacement aussi proche que possible de celle que PowerPoint utiliserait.  
3. Si des règles de remplacement de police ont été définies via [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/), elles sont appliquées.  

Aspose.Slides vous permet d’ajouter des polices au runtime de l’application, puis d’utiliser ces polices. Voir [**Polices personnalisées**](https://docs.aspose.com/slides/python-net/custom-font/).  

Lorsque des polices supplémentaires sont intégrées dans une présentation, on les appelle [**Polices incorporées**](https://docs.aspose.com/slides/python-net/embedded-font/).  

Aspose.Slides vous permet d’ajouter des polices qui sont appliquées *uniquement* aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et des polices incorporées, vous pouvez ajouter ou charger les polices nécessaires en tant que **polices externes**.  

{{% alert title="Note" color="primary" %}} 
Nous ne distribuons aucune police, qu’elle soit payante ou gratuite. Notre API vous permet de charger des polices externes et de les incorporer dans les documents, mais vous le faites avec les polices à votre discrétion et sous votre responsabilité.
{{% /alert %}}

## **FAQ**

**Comment puis‑je déterminer quelles polices sont réellement utilisées dans une présentation avant la conversion ?**

Aspose.Slides vous permet d’inspecter les polices utilisées via le [gestionnaire de polices](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/), afin de décider d’[incorporer](/slides/fr/python-net/embedded-font/), de [remplacer](/slides/fr/python-net/font-replacement/) ou d’ajouter des [sources externes](/slides/fr/python-net/custom-font/). Cela vous aide à éviter les substitutions indésirables lors du rendu et de l’exportation.

**Puis‑je ajouter des répertoires de polices supplémentaires sans les installer sur le système d’exploitation ?**

Oui. Vous pouvez enregistrer des [sources de polices externes](/slides/fr/python-net/custom-font/) telles que des dossiers ou des flux en mémoire pour le rendu et l’exportation. Cela supprime la dépendance aux polices du système hôte et maintient la mise en page prévisible.

**Comment empêcher un basculement silencieux vers une police inappropriée lorsqu’un glyphe est manquant ?**

Définissez à l’avance des [remplacements de police](/slides/fr/python-net/font-replacement/) et des [règles de secours](/slides/fr/python-net/fallback-font/) explicites. En analysant les polices utilisées et en définissant une priorité contrôlée pour les substituts, vous assurez une typographie cohérente et évitez des résultats inattendus.