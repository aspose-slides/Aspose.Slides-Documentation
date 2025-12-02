---
title: Séquence de sélection des polices dans Aspose.Slides pour Python
linktitle: Sélection des polices
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
description: "Découvrez comment Aspose.Slides pour Python via .NET sélectionne les polices, garantissant une présentation nette et cohérente des fichiers PPT, PPTX et ODP — améliorez vos diapositives dès maintenant."
---

## **Sélection des polices**

Certaines règles s’appliquent aux polices d’une présentation lorsqu’elle est chargée, rendue ou convertie dans un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées pour s’assurer que les polices choisies sont disponibles dans le système d’exploitation. Si les polices sont confirmées comme manquantes, elles sont remplacées — voir [**Font Replacement**](https://docs.aspose.com/slides/python-net/font-replacement/) et [**Font Substitution**](https://docs.aspose.com/slides/python-net/font-substitution/).

Voici le processus suivi par Aspose.Slides lors du traitement des polices :

1. Aspose.Slides recherche les polices dans le système d’exploitation pour trouver celle qui correspond à la police choisie dans la présentation.  
2. Si la police choisie est trouvée, Aspose.Slides l’utilise. Sinon, Aspose.Slides utilise une police de remplacement aussi proche que possible de celle que PowerPoint utiliserait.  
3. Si des règles de remplacement de police ont été définies via [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/), elles sont appliquées.  

Aspose.Slides vous permet d’ajouter des polices au moment de l’exécution de l’application, puis de les utiliser. Voir [**Custom fonts**](https://docs.aspose.com/slides/python-net/custom-font/).  

Lorsque des polices supplémentaires sont intégrées à une présentation, elles sont appelées [**Embedded fonts**](https://docs.aspose.com/slides/python-net/embedded-font/).  

Aspose.Slides vous permet d’ajouter des polices qui ne s’appliquent qu’aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et des polices intégrées, vous pouvez ajouter ou charger les polices nécessaires en tant que **external fonts**.  

{{% alert title="Note" color="primary" %}} 
Nous ne distribuerons aucune police, qu’elle soit payante ou gratuite. Notre API vous permet de charger des polices externes et de les intégrer aux documents, mais vous le faites à votre discrétion et sous votre responsabilité. 
{{% /alert %}}

## **FAQ**

**Comment puis‑je déterminer quelles polices sont réellement utilisées dans une présentation avant la conversion ?**

Aspose.Slides vous permet d’inspecter les polices utilisées via le [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/), afin que vous puissiez décider d’[embed](/slides/fr/python-net/embedded-font/), de [replace](/slides/fr/python-net/font-replacement/) ou d’ajouter des [external sources](/slides/fr/python-net/custom-font/). Cela vous aide à éviter les substitutions indésirables lors du rendu et de l’exportation.  

**Puis‑je ajouter des répertoires de polices supplémentaires sans les installer sur le système d’exploitation ?**

Oui. Vous pouvez enregistrer des [external font sources](/slides/fr/python-net/custom-font/) telles que des dossiers ou des flux en mémoire pour le rendu et l’exportation. Cela élimine la dépendance aux polices du système hôte et maintient une mise en page prévisible.  

**Comment empêcher un repli silencieux vers une police inappropriée lorsqu’un glyphe est manquant ?**

Définissez à l’avance des [font replacement](/slides/fr/python-net/font-replacement/) et des [fallBack rules](/slides/fr/python-net/fallback-font/) explicites. En analysant les polices utilisées et en définissant une priorité contrôlée pour les substituts, vous assurez une typographie cohérente et évitez des résultats inattendus.