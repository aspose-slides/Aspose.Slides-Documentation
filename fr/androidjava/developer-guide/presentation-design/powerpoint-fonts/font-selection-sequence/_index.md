---
title: Séquence de sélection de police en Java
linktitle: Séquence de sélection de police en Java
type: docs
weight: 80
url: /fr/androidjava/font-selection-sequence/
keywords:
- police
- sélection de police
- remplacement de police
- substitution de police
- présentation PowerPoint
- Java
- Aspose.Slides pour Android via Java
description: Séquence de sélection de police PowerPoint en Java
---

## Sélection de police

Certaines règles s'appliquent aux polices dans une présentation lorsque celle-ci est chargée, rendue ou convertie dans un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées pour confirmer que les polices choisies sont disponibles dans le système d'exploitation. Si les polices sont confirmées comme manquantes, elles sont remplacées — voir [**Remplacement de police**](https://docs.aspose.com/slides/androidjava/font-replacement/) et [**Substitution de police**](https://docs.aspose.com/slides/androidjava/font-substitution/).

Voici le processus suivi par Aspose.Slides lorsqu'il s'agit de polices :

1. Aspose.Slides recherche des polices dans le système d'exploitation pour trouver la police qui correspond à la police choisie dans la présentation.
2. Si la police choisie est trouvée, Aspose.Slides l'utilise. Sinon, Aspose.Slides utilise une police de remplacement qui est la plus proche possible de celle que PowerPoint utiliserait.
3. Si des règles de remplacement de police ont été définies via [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/), elles sont appliquées.

Aspose.Slides vous permet d'ajouter des polices à l'exécution de l'application et de les utiliser ensuite. Voir [**Polices personnalisées**](https://docs.aspose.com/slides/androidjava/custom-font/).

Lorsque des polices supplémentaires sont intégrées à une présentation, elles sont appelées [**Polices incorporées**](https://docs.aspose.com/slides/androidjava/embedded-font/).

Aspose.Slides vous permet d'ajouter des polices qui ne sont appliquées qu'aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes dans votre système et des polices incorporées, vous pouvez ajouter ou charger les polices nécessaires en tant que **polices externes**.

{{% alert title="Note" color="primary" %}} 
Nous ne distribuons aucune police, qu'elle soit payante ou gratuite. Notre API vous permet de charger des polices externes et de les intégrer dans des documents, mais vous le faites à votre discrétion et sous votre responsabilité.
{{% /alert %}}