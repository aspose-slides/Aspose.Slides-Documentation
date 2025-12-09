---
title: Séquence de sélection de police en JavaScript
linktitle: Séquence de sélection de police
type: docs
weight: 80
url: /fr/nodejs-java/font-selection-sequence/
keywords:
- police
- sélection de police
- substitution de police
- remplacement de police
- présentation PowerPoint
- Java
- Aspose.Slides pour Node.js via Java
description: Séquence de sélection de police PowerPoint en JavaScript
---

## **Sélection de la police**

Certaines règles s'appliquent aux polices d'une présentation lorsque celle‑ci est chargée, rendue ou convertie dans un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées afin de s'assurer que les polices choisies sont disponibles dans le système d'exploitation. Si les polices sont confirmées comme manquantes, elles sont remplacées — voir [**Remplacement de police**](https://docs.aspose.com/slides/nodejs-java/font-replacement/) et [**Substitution de police**](https://docs.aspose.com/slides/nodejs-java/font-substitution/).

Voici le processus qu'Aspose.Slides suit lorsqu'il gère les polices :

1. Aspose.Slides recherche les polices dans le système d'exploitation afin de trouver la police qui correspond à celle choisie par la présentation.  
2. Si la police choisie est trouvée, Aspose.Slides l'utilise. Sinon, Aspose.Slides utilise une police de remplacement aussi proche que possible de celle que PowerPoint utiliserait.  
3. Si des règles de remplacement de police ont été définies via [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/), elles sont appliquées.

Aspose.Slides vous permet d'ajouter des polices au runtime de l'application, puis d'utiliser ces polices. Voir [**Polices personnalisées**](https://docs.aspose.com/slides/nodejs-java/custom-font/).

Lorsque des polices supplémentaires sont intégrées dans une présentation, elles sont appelées [**Polices incorporées**](https://docs.aspose.com/slides/nodejs-java/embedded-font/).

Aspose.Slides vous permet d'ajouter des polices qui sont appliquées *uniquement* aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et des polices incorporées, vous pouvez ajouter ou charger les polices nécessaires en tant que **polices externes**.

{{% alert title="Note" color="primary" %}} 
Nous ne distribuons aucune police, qu'elle soit payante ou gratuite. Notre API vous permet de charger des polices externes et de les incorporer dans les documents, mais vous le faites à votre discrétion et sous votre responsabilité.
{{% /alert %}}

## **FAQ**

**Comment déterminer quelles polices sont réellement utilisées dans une présentation avant la conversion ?**

Aspose.Slides vous permet d'inspecter les polices utilisées via le [font manager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/), afin que vous puissiez décider d'[incorporer](/slides/fr/nodejs-java/embedded-font/), de [remplacer](/slides/fr/nodejs-java/font-replacement/) ou d'ajouter des [sources externes](/slides/fr/nodejs-java/custom-font/). Cela vous aide à prévenir les substitutions indésirables lors du rendu et de l'exportation.

**Puis-je ajouter des répertoires de polices supplémentaires sans les installer sur le système d'exploitation ?**

Oui. Vous pouvez enregistrer des [sources de polices externes](/slides/fr/nodejs-java/custom-font/) telles que des dossiers ou des flux en mémoire pour le rendu et l'exportation. Cela élimine la dépendance aux polices du système hôte et maintient une mise en page prévisible.

**Comment empêcher un repli silencieux vers une police inappropriée lorsqu'un glyphe est manquant ?**

Définissez explicitement le [remplacement de police](/slides/fr/nodejs-java/font-replacement/) et les [règles de repli](/slides/fr/nodejs-java/fallback-font/) à l'avance. En analysant les polices utilisées et en définissant une priorité contrôlée pour les substituts, vous assurez une typographie cohérente et évitez les résultats inattendus.