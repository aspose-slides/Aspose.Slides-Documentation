---
title: Séquence de sélection des polices dans Aspose.Slides pour Android via Java
linktitle: Sélection de police
type: docs
weight: 80
url: /fr/androidjava/font-selection-sequence/
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
- Android
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour Android via Java sélectionne les polices, garantissant une présentation claire et cohérente des fichiers PPT, PPTX et ODP — améliorez vos diapositives dès maintenant."
---
## **Vue d'ensemble**

Lorsque une présentation est chargée, rendue ou convertie dans un autre format, Aspose.Slides vérifie si les polices utilisées dans la présentation sont disponibles dans le système d'exploitation. Si une police requise est manquante, Aspose.Slides sélectionne une police de remplacement aussi proche que possible de celle que PowerPoint utiliserait.

Aspose.Slides recherche d'abord la police sélectionnée dans le système d'exploitation. Si la police est trouvée, elle est utilisée. Sinon, un remplacement approprié est appliqué. Lorsque des règles de substitution de police sont définies via `FontSubstRule`, ces règles sont également prises en compte.

Vous pouvez également ajouter des polices au moment de l'exécution de l'application, utiliser des polices incorporées à partir d'une présentation, ou charger des polices externes pour les documents de sortie tels que les fichiers PDF.

## **Sélection de police**

Certaines règles s'appliquent aux polices d'une présentation lorsqu'elle est chargée, rendue ou convertie dans un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées pour s'assurer que les polices choisies sont disponibles dans le système d'exploitation. Si les polices sont confirmées comme manquantes, elles sont remplacées — voir [**Remplacement de police**](https://docs.aspose.com/slides/fr/androidjava/font-replacement/) et [**Substitution de police**](https://docs.aspose.com/slides/fr/androidjava/font-substitution/).

Voici le processus qu'Aspose.Slides suit pour gérer les polices :

1. Aspose.Slides recherche des polices dans le système d'exploitation afin de trouver la police qui correspond à celle choisie dans la présentation. 
2. Si la police choisie est trouvée, Aspose.Slides l'utilise. Sinon, Aspose.Slides utilise une police de remplacement aussi proche que possible de celle que PowerPoint utiliserait.
3. Si des règles de remplacement de police ont été définies via [FontSubstRule](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsubstrule/), elles sont appliquées.

Aspose.Slides vous permet d'ajouter des polices pendant l'exécution de l'application, puis d'utiliser ces polices. Voir [**Polices personnalisées**](https://docs.aspose.com/slides/fr/androidjava/custom-font/).

Lorsque des polices supplémentaires sont placées dans une présentation, elles sont appelées [**Polices incorporées**](https://docs.aspose.com/slides/fr/androidjava/embedded-font/).

Aspose.Slides vous permet d'ajouter des polices qui sont appliquées *uniquement* aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et des polices incorporées, vous pouvez ajouter ou charger les polices nécessaires en tant que **polices externes**. 

{{% alert title="Note" color="info" %}} 
Nous ne distribuons aucune police, qu'elle soit payante ou gratuite. Notre API vous permet de charger des polices externes et de les incorporer dans les documents, mais vous le faites avec les polices à votre discrétion et sous votre responsabilité.
{{% /alert %}}

## **FAQ**

### Comment déterminer quelles polices sont réellement utilisées dans une présentation avant la conversion ?

Aspose.Slides vous permet d'inspecter les polices utilisées via le [gestionnaire de polices](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsmanager/), afin de décider s'il faut [incorporer](/slides/fr/androidjava/embedded-font/), [remplacer](/slides/fr/androidjava/font-replacement/) ou ajouter des [sources externes](/slides/fr/androidjava/custom-font/). Cela vous aide à éviter les substitutions indésirables lors du rendu et de l'exportation.

### Puis-je ajouter des répertoires de polices supplémentaires sans les installer sur le système d'exploitation ?

Oui. Vous pouvez enregistrer des [sources de polices externes](/slides/fr/androidjava/custom-font/) telles que des dossiers ou des flux en mémoire pour le rendu et l'exportation. Cela supprime la dépendance aux polices du système hôte et rend la mise en page prévisible.

### Comment empêcher un basculement silencieux vers une police inappropriée lorsqu'un glyphe est manquant ?

Définissez explicitement le [remplacement de police](/slides/fr/androidjava/font-replacement/) et les [règles de secours de police](/slides/fr/androidjava/fallback-font/) à l'avance. En analysant les polices utilisées et en définissant une priorité contrôlée pour les substituts, vous garantissez une typographie cohérente et évitez des résultats inattendus.