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
## **Vue d'ensemble**

Lorsque une présentation est chargée, rendue ou convertie dans un autre format, Aspose.Slides vérifie si les polices utilisées dans la présentation sont disponibles dans le système d'exploitation. Si une police requise est manquante, Aspose.Slides sélectionne une police de remplacement aussi proche que possible de celle que PowerPoint utiliserait.

Aspose.Slides recherche d'abord la police sélectionnée dans le système d'exploitation. Si la police est trouvée, elle est utilisée. Sinon, un remplacement approprié est appliqué. Lorsque des règles de substitution de police sont définies via `FontSubstRule`, ces règles sont également prises en compte.

Vous pouvez également ajouter des polices à l'exécution de l'application, utiliser des polices incorporées à partir d'une présentation, ou charger des polices externes pour les documents de sortie tels que les fichiers PDF.

## **Sélection de police**

Certaines règles s'appliquent aux polices d'une présentation lorsque celle‑ci est chargée, rendue ou convertie dans un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées pour s'assurer que les polices choisies sont disponibles dans le système d'exploitation. Si les polices sont confirmées comme manquantes, elles sont remplacées — voir [**Font Replacement**](https://docs.aspose.com/slides/fr/net/font-replacement/) et [**Font Substitution**](https://docs.aspose.com/slides/fr/net/font-substitution/).

Voici le processus qu'Aspose.Slides suit lorsqu'il traite les polices :

1. Aspose.Slides recherche les polices dans le système d'exploitation afin de trouver celle qui correspond à la police choisie dans la présentation. 
2. Si la police choisie est trouvée, Aspose.Slides l'utilise. Sinon, Aspose.Slides utilise une police de remplacement aussi proche que possible de celle que PowerPoint utiliserait.
3. Si des règles de remplacement de police ont été définies via [FontSubstRule](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsubstrule/), elles sont appliquées. 

Aspose.Slides vous permet d'ajouter des polices à l'exécution de l'application, puis d'utiliser ces polices. Voir [**Custom fonts**](https://docs.aspose.com/slides/fr/net/custom-font/). 

Lorsque des polices supplémentaires sont placées dans une présentation, elles sont appelées [**Embedded fonts**](https://docs.aspose.com/slides/fr/net/embedded-font/).

Aspose.Slides vous permet d'ajouter des polices qui sont appliquées uniquement aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et des polices incorporées, vous pouvez ajouter ou charger les polices nécessaires en tant que **polices externes**. 

{{% alert title="Note" color="info" %}} 
Nous ne distribuons aucune police, qu'elle soit payante ou gratuite. Notre API vous permet de charger des polices externes et de les incorporer dans les documents, mais vous le faites à votre discrétion et sous votre responsabilité.
{{% /alert %}}

## **FAQ**

### Comment déterminer quelles polices sont réellement utilisées dans une présentation avant la conversion ?

Aspose.Slides vous permet d'inspecter les polices utilisées via le [font manager](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/fontsmanager/), afin que vous puissiez décider d'[intégrer](/slides/fr/net/embedded-font/), de [remplacer](/slides/fr/net/font-replacement/) ou d'ajouter des [sources externes](/slides/fr/net/custom-font/). Cela vous aide à éviter les substitutions indésirables lors du rendu et de l'exportation.

### Puis-je ajouter des répertoires de polices supplémentaires sans les installer sur le système d'exploitation ?

Oui. Vous pouvez enregistrer des [sources de polices externes](/slides/fr/net/custom-font/) telles que des dossiers ou des flux en mémoire pour le rendu et l'exportation. Cela élimine la dépendance aux polices du système hôte et maintient la mise en page prévisible.

### Comment empêcher un basculement silencieux vers une police inappropriée lorsqu'un glyphe est manquant ?

Définissez à l'avance le [remplacement de police](/slides/fr/net/font-replacement/) et les [règles de repli de police](/slides/fr/net/fallback-font/). En analysant les polices utilisées et en établissant une priorité contrôlée pour les substituts, vous assurez une typographie cohérente et évitez des résultats inattendus.