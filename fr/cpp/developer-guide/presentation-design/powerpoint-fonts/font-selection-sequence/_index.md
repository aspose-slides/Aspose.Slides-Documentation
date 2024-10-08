---
title: Séquence de sélection de police en C++
linktitle: Séquence de sélection de police en C++
type: docs
weight: 80
url: /fr/cpp/font-selection-sequence/
keywords:
- police
- sélection de police
- substitution de police
- remplacement de police
- présentation PowerPoint
- C++
- Aspose.Slides pour C++
description: "Séquence de sélection de police PowerPoint en C++"
---

## Sélection de police

Certaines règles s'appliquent aux polices dans une présentation lorsque celle-ci est chargée, rendue ou convertie dans un autre format. Par exemple, lorsque vous essayez de convertir une présentation (ses diapositives) en images, les polices de la présentation sont vérifiées pour s'assurer que les polices choisies sont disponibles dans le système d'exploitation. Si les polices sont confirmées comme manquantes, elles sont remplacées — voir [**Remplacement de police**](https://docs.aspose.com/slides/cpp/font-replacement/) et [**Substitution de police**](https://docs.aspose.com/slides/cpp/font-substitution/).

Voici le processus suivi par Aspose.Slides lors du traitement des polices :

1. Aspose.Slides recherche des polices dans le système d'exploitation pour trouver la police qui correspond à la police choisie dans la présentation. 
2. Si la police choisie est trouvée, Aspose.Slides l'utilise. Sinon, Aspose.Slides utilise une police de remplacement qui est aussi proche que possible de ce que PowerPoint utiliserait.
3. Si des règles de remplacement de police ont été définies par le biais de [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/), elles sont appliquées.

Aspose.Slides vous permet d'ajouter des polices à l'exécution de l'application, puis d'utiliser ces polices. Voir [**Polices personnalisées**](https://docs.aspose.com/slides/cpp/custom-font/). 

Lorsque des polices supplémentaires sont intégrées dans une présentation, elles sont appelées [**Polices intégrées**](https://docs.aspose.com/slides/cpp/embedded-font/).

Aspose.Slides vous permet d'ajouter des polices qui ne s'appliquent qu'aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et des polices intégrées, vous pouvez ajouter ou charger les polices nécessaires en tant que **polices externes**.

{{% alert title="Remarque" color="primary" %}} 
Nous ne distribuons aucune police, qu'elle soit payante ou gratuite. Notre API vous permet de charger des polices externes et de les intégrer dans des documents, mais vous le faites à votre discrétion et votre responsabilité.
{{% /alert %}}