---
title: Police de secours - API JavaScript PowerPoint
linktitle: Police de secours
type: docs
weight: 50
url: /fr/nodejs-java/fallback-font/
description: La police de secours est utilisée lorsque la police spécifiée pour le texte est disponible dans le système, mais que cette police ne contient pas le glyphe nécessaire. Dans ce cas, l'API Java PowerPoint peut utiliser l'une des polices de secours spécifiées pour le remplacement du glyphe.
---

## **Police de secours**
La police de secours est utilisée lorsque la police spécifiée pour le texte est disponible dans le système, mais que cette police ne contient pas le glyphe nécessaire. Dans ce cas, il est possible d’utiliser l’une des polices de secours spécifiées pour le remplacement du glyphe.

Aspose.Slides permet de créer des polices de secours, de les ajouter à la collection de polices de secours, de définir la collection de polices de secours pour une présentation donnée, de supprimer des polices de secours d’une présentation, de spécifier les règles d’application des polices de secours, etc.

Pour vous familiariser avec ces fonctionnalités, utilisez les liens suivants :
- [Créer une police de secours](/slides/fr/nodejs-java/create-fallback-font)
- [Créer une collection de polices de secours](/slides/fr/nodejs-java/create-fallback-fonts-collection)
- [Rendre la présentation avec une police de secours](/slides/fr/nodejs-java/render-presentation-with-fallback-font)

## **FAQ**

**En quoi les polices de secours diffèrent‑elles de la substitution de police ?**
La police de secours s’applique caractère par caractère ou par plage Unicode lorsque la police principale ne possède pas de glyphes spécifiques ; elle ne remplit que les caractères manquants. [Substitution](/slides/fr/nodejs-java/font-substitution/) remplace une police manquante ou indisponible pour l’ensemble d’une séquence ou d’une partie de texte par une autre police. Elles peuvent être combinées, mais leur portée et leur logique de sélection sont différentes.

**Les paramètres de secours sont‑ils enregistrés dans le fichier de présentation ?**
Non. La configuration de secours vit au moment du traitement/de la génération dans la bibliothèque et n’est pas sérialisée dans le PPTX. La présentation ne conserve pas vos règles de secours.

**La police de secours affecte‑t‑elle les éléments créés par les objets PowerPoint (SmartArt, graphiques, WordArt) ?**
Oui. Le texte à l’intérieur de ces objets passe par le même pipeline de rendu, de sorte que les mêmes règles de secours s’appliquent comme pour le texte ordinaire.