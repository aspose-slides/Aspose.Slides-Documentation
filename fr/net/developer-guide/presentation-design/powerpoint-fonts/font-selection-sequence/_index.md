---
title: Séquence de sélection de police dans Aspose.Slides pour .NET
linktitle: Sélection de police
type: docs
weight: 80
url: /fr/net/font-selection-sequence/
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
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour .NET sélectionne les polices, garantissant une présentation nette et cohérente des fichiers PPT, PPTX et ODP — améliorez vos diapositives dès maintenant."
---

## **Sélection de police**

Certaines règles s'appliquent aux polices d'une présentation lorsqu'elle est chargée, rendue ou convertie dans un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées pour s'assurer que les polices choisies sont disponibles dans le système d'exploitation. Si les polices sont constatées comme manquantes, elles sont remplacées — voir [**Font Replacement**](https://docs.aspose.com/slides/net/font-replacement/) et [**Font Substitution**](https://docs.aspose.com/slides/net/font-substitution/).

Voici le processus qu'Aspose.Slides suit lors du traitement des polices :

1. Aspose.Slides recherche les polices dans le système d'exploitation afin de trouver la police qui correspond à la police choisie dans la présentation. 
2. Si la police choisie est trouvée, Aspose.Slides l'utilise. Sinon, Aspose.Slides utilise une police de remplacement aussi proche que possible de celle que PowerPoint emploierait.
3. Si des règles de remplacement de police ont été définies via [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/), elles sont appliquées. 

Aspose.Slides vous permet d'ajouter des polices au moment de l'exécution de l'application, puis d'utiliser ces polices. Voir [**Custom fonts**](https://docs.aspose.com/slides/net/custom-font/). 

Lorsque des polices supplémentaires sont intégrées dans une présentation, elles sont appelées [**Embedded fonts**](https://docs.aspose.com/slides/net/embedded-font/).

Aspose.Slides vous permet d'ajouter des polices qui sont appliquées *uniquement* aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et des polices incorporées, vous pouvez ajouter ou charger les polices nécessaires en tant que **external fonts**. 

{{% alert title="Note" color="primary" %}} 
Nous ne distribuons aucune police, qu'elle soit payante ou gratuite. Notre API vous permet de charger des polices externes et de les incorporer dans les documents, mais vous le faites à votre discrétion et responsabilité.
{{% /alert %}}

## **FAQ**

**Comment puis‑je déterminer quelles polices sont réellement utilisées dans une présentation avant la conversion ?**

Aspose.Slides vous permet d'inspecter les polices utilisées via le [font manager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), afin que vous puissiez décider d'[embed](/slides/fr/net/embedded-font/), de [replace](/slides/fr/net/font-replacement/) ou d'ajouter des [external sources](/slides/fr/net/custom-font/). Cela vous aide à éviter les substitutions indésirables lors du rendu et de l'exportation.

**Puis‑je ajouter des répertoires de polices supplémentaires sans les installer sur le système d'exploitation ?**

Oui. Vous pouvez enregistrer des [external font sources](/slides/fr/net/custom-font/) tels que des dossiers ou des flux en mémoire pour le rendu et l'exportation. Cela supprime la dépendance aux polices du système hôte et maintient une mise en page prévisible.

**Comment empêcher un basculement silencieux vers une police inappropriée lorsqu'un glyphe est manquant ?**

Définissez à l'avance des [font replacement](/slides/fr/net/font-replacement/) explicites et des règles de [fallBack](/slides/fr/net/fallback-font/) des polices. En analysant les polices utilisées et en définissant une priorité contrôlée pour les substituts, vous garantissez une typographie cohérente et évitez des résultats inattendus.