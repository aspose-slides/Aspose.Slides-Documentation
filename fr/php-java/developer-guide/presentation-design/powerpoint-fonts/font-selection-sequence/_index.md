---
title: Séquence de sélection de police
linktitle: Séquence de sélection de police
type: docs
weight: 80
url: /fr/php-java/font-selection-sequence/
keywords: "Police, sélection de police, substitution de police, remplacement de police, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: Séquence de sélection de police PowerPoint
---

## Sélection de police

Certaines règles s'appliquent aux polices dans une présentation lorsque celle-ci est chargée, rendue ou convertie dans un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées pour s'assurer que les polices choisies sont disponibles dans le système d'exploitation. Si les polices sont confirmées comme manquantes, elles sont remplacées—voir [**Remplacement de police**](https://docs.aspose.com/slides/php-java/font-replacement/) et [**Substitution de police**](https://docs.aspose.com/slides/php-java/font-substitution/).

Voici le processus suivi par Aspose.Slides lorsqu'il s'agit de polices :

1. Aspose.Slides recherche des polices dans le système d'exploitation pour trouver la police qui correspond à la police choisie dans la présentation.
2. Si la police choisie est trouvée, Aspose.Slides l'utilise. Sinon, Aspose.Slides utilise une police de remplacement qui est aussi proche que possible de ce que PowerPoint utiliserait.
3. Si des règles de remplacement de police ont été définies via [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/), elles sont appliquées.

Aspose.Slides vous permet d'ajouter des polices à l'exécution d'Aspose et de les utiliser ensuite. Voir [**Polices personnalisées**](https://docs.aspose.com/slides/php-java/custom-font/).

Lorsque des polices supplémentaires sont présentes dans une présentation, elles sont appelées [**Polices intégrées**](https://docs.aspose.com/slides/php-java/embedded-font/).

Aspose.Slides vous permet d'ajouter des polices qui sont appliquées *uniquement* aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et des polices intégrées, vous pouvez ajouter ou charger les polices nécessaires en tant que **Polices externes**.