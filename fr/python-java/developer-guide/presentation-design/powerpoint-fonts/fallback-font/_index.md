---
title: Gérer les polices de secours pour les présentations en Python via Java
linktitle: Police de secours
type: docs
weight: 50
url: /fr/python-java/fallback-font/
keywords:
- police de secours
- police disponible
- remplacement de glyphe
- spécifier la police
- spécifier la règle
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour Python via Java utilise les polices de secours pour garder le texte lisible dans les présentations PowerPoint et OpenDocument lorsque les polices d'origine ne sont pas disponibles."
---
## **Introduction**

Les polices de secours sont utilisées lorsque la police spécifiée pour le texte est présente sur le système mais ne contient pas le glyphe requis. Dans ce cas, Aspose.Slides peut utiliser l’une des polices de secours spécifiées pour remplacer le glyphe manquant.

## **Police de secours**

Aspose.Slides vous permet de créer des polices de secours, de les ajouter à une collection de polices de secours, de définir la collection de polices de secours pour une présentation donnée, de supprimer des polices de secours de la présentation, de spécifier les règles d’application des polices de secours et d’effectuer d’autres opérations connexes.

Pour vous familiariser avec ces fonctionnalités, utilisez les liens suivants :

- [Créer une police de secours](/slides/fr/python-java/create-fallback-font/)
- [Créer une collection de polices de secours](/slides/fr/python-java/create-fallback-fonts-collection/)
- [Rendre une présentation avec une police de secours](/slides/fr/python-java/render-presentation-with-fallback-font/)

## **FAQ**

**Comment les polices de secours diffèrent-elles de la substitution de police ?**

La police de secours s’applique caractère par caractère ou par plage Unicode lorsque la police principale ne possède pas de glyphes spécifiques ; elle ne remplit que les caractères manquants. [Substitution](/slides/fr/python-java/font-substitution/) remplace une police manquante ou indisponible pour l’ensemble d’une séquence ou d’une portion de texte par une autre police. Elles peuvent être combinées, mais leur portée et leur logique de sélection diffèrent.

**Les paramètres de secours sont‑ils enregistrés dans le fichier de présentation ?**

Non. La configuration de secours vit au moment du traitement/du rendu dans la bibliothèque et n’est pas sérialisée dans le PPTX. La présentation ne stocke pas vos règles de secours.

**La police de secours affecte‑t‑elle les éléments créés par les objets PowerPoint (SmartArt, graphiques, WordArt) ?**

Oui. Le texte à l’intérieur de ces objets passe par le même pipeline de rendu, de sorte que les mêmes règles de secours s’appliquent à celui‑ci qu’au texte ordinaire.