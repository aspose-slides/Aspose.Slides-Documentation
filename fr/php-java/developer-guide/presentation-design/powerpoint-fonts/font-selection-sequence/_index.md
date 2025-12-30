---
title: Séquence de sélection des polices dans Aspose.Slides pour PHP
linktitle: Sélection de police
type: docs
weight: 80
url: /fr/php-java/font-selection-sequence/
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
- PHP
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour PHP via Java sélectionne les polices, garantissant une présentation nette et cohérente des fichiers PPT, PPTX et ODP — améliorez vos diapositives dès maintenant."
---

## **Sélection de la police**

Certaines règles s'appliquent aux polices d'une présentation lorsqu'elle est chargée, rendue ou convertie dans un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées pour s'assurer que les polices choisies sont disponibles dans le système d'exploitation. Si les polices sont effectivement manquantes, elles sont remplacées — voir [**Font Replacement**](https://docs.aspose.com/slides/php-java/font-replacement/) et [**Font Substitution**](https://docs.aspose.com/slides/php-java/font-substitution/).

Voici le processus qu'Aspose.Slides suit lors du traitement des polices :

1. Aspose.Slides recherche les polices dans le système d'exploitation afin de trouver la police qui correspond à celle choisie dans la présentation. 
2. Si la police choisie est trouvée, Aspose.Slides l'utilise. Sinon, Aspose.Slides utilise une police de remplacement aussi proche que possible de celle que PowerPoint utiliserait. 
3. Si des règles de remplacement de police ont été définies via [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/), elles sont appliquées.

Aspose.Slides vous permet d'ajouter des polices au runtime Aspose, puis d'utiliser ces polices. Voir [**Custom fonts**](https://docs.aspose.com/slides/php-java/custom-font/).

Lorsque des polices supplémentaires sont intégrées dans une présentation, elles sont appelées [**Embedded fonts**](https://docs.aspose.com/slides/php-java/embedded-font/).

Aspose.Slides vous permet d'ajouter des polices qui sont appliquées *uniquement* aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et des polices incorporées, vous pouvez ajouter ou charger les polices nécessaires en tant que **External fonts**. 

## **FAQ**

**Comment puis‑je déterminer quelles polices sont réellement utilisées dans une présentation avant la conversion ?**

Aspose.Slides vous permet d'inspecter les polices utilisées via le [font manager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/), ainsi vous pouvez décider d'[embed](/slides/fr/php-java/embedded-font/), [replace](/slides/fr/php-java/font-replacement/), ou d'ajouter [external sources](/slides/fr/php-java/custom-font/). Cela vous aide à éviter les substitutions indésirables lors du rendu et de l'exportation.

**Puis‑je ajouter des répertoires de polices supplémentaires sans les installer sur le système d'exploitation ?**

Oui. Vous pouvez enregistrer des [external font sources](/slides/fr/php-java/custom-font/) tels que des dossiers ou des flux en mémoire pour le rendu et l'exportation. Cela supprime la dépendance aux polices du système hôte et maintient une mise en page prévisible.

**Comment éviter un basculement silencieux vers une police inappropriée lorsqu'un glyphe est manquant ?**

Définissez explicitement le [font replacement](/slides/fr/php-java/font-replacement/) et les [fallback rules](/slides/fr/php-java/fallback-font/) à l'avance. En analysant les polices utilisées et en définissant une priorité contrôlée pour les substituts, vous assurez une typographie cohérente et évitez des résultats inattendus.