---
title: Séquence de sélection de police en C#
linktitle: Séquence de sélection de police en C#
type: docs
weight: 80
url: /fr/net/font-selection-sequence/
keywords:
- police
- sélection de police
- substitution de police
- remplacement de police
- présentation PowerPoint
- C#
- Csharp
- Aspose.Slides pour .NET
description: Séquence de sélection de police PowerPoint en C#
---

## **Sélection de police**

Certaines règles s'appliquent aux polices d'une présentation lorsque la présentation est chargée, rendue ou convertie dans un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées pour s'assurer que les polices choisies sont disponibles dans le système d'exploitation. Si les polices sont confirmées comme manquantes, elles sont remplacées — voir [**Remplacement de police**](https://docs.aspose.com/slides/net/font-replacement/) et [**Substitution de police**](https://docs.aspose.com/slides/net/font-substitution/).

Voici le processus suivi par Aspose.Slides lors de la gestion des polices :

1. Aspose.Slides recherche les polices dans le système d'exploitation afin de trouver la police correspondant à celle choisie dans la présentation.  
2. Si la police choisie est trouvée, Aspose.Slides l'utilise. Sinon, Aspose.Slides utilise une police de remplacement aussi proche que possible de celle que PowerPoint utiliserait.  
3. Si des règles de remplacement de police ont été définies via [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/), elles sont appliquées.  

Aspose.Slides vous permet d'ajouter des polices au moment de l'exécution de l'application, puis d'utiliser ces polices. Voir [**Polices personnalisées**](https://docs.aspose.com/slides/net/custom-font/).  

Lorsque des polices supplémentaires sont placées dans une présentation, on les appelle des [**Polices incorporées**](https://docs.aspose.com/slides/net/embedded-font/).

Aspose.Slides vous permet d'ajouter des polices qui ne sont appliquées qu'aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et des polices incorporées, vous pouvez ajouter ou charger les polices nécessaires en tant que **polices externes**.  

{{% alert title="Note" color="primary" %}} 
Nous ne distribuons aucune police, qu'elle soit payante ou gratuite. Notre API vous permet de charger des polices externes et de les incorporer dans les documents, mais vous le faites à votre discrétion et sous votre responsabilité.
{{% /alert %}}

## **FAQ**

**Comment déterminer quelles polices sont réellement utilisées dans une présentation avant la conversion ?**

Aspose.Slides vous permet d'inspecter les polices utilisées via le [gestionnaire de polices](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), afin que vous puissiez décider de [intégrer](/slides/fr/net/embedded-font/), de [remplacer](/slides/fr/net/font-replacement/) ou d'ajouter des [sources externes](/slides/fr/net/custom-font/). Cela vous aide à éviter les substitutions indésirables lors du rendu et de l'exportation.

**Puis‑je ajouter des répertoires de polices supplémentaires sans les installer sur le système d'exploitation ?**

Oui. Vous pouvez enregistrer des [sources de polices externes](/slides/fr/net/custom-font/) telles que des dossiers ou des flux en mémoire pour le rendu et l'exportation. Cela élimine la dépendance aux polices du système hôte et maintient la mise en page prévisible.

**Comment éviter un basculement silencieux vers une police inappropriée lorsqu'un glyphe est manquant ?**

Définissez à l'avance des [règles de remplacement de police](/slides/fr/net/font-replacement/) explicites et des [règles de secours de police](/slides/fr/net/fallback-font/). En analysant les polices utilisées et en définissant une priorité contrôlée pour les substituts, vous assurez une typographie cohérente et évitez des résultats inattendus.