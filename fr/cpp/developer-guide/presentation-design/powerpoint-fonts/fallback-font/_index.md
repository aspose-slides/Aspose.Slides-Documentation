---
title: Gestion des polices de secours pour les présentations en C++
linktitle: Police de secours
type: docs
weight: 50
url: /fr/cpp/fallback-font/
keywords:
- police de secours
- police disponible
- remplacement de glyphe
- spécifier la police
- spécifier la règle
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour C++ utilise les polices de secours pour rendre le texte lisible dans les présentations PowerPoint et OpenDocument lorsque les polices d'origine ne sont pas disponibles."
---

## **Police de secours**
La police de secours est utilisée lorsque la police spécifiée pour le texte est disponible dans le système, mais que cette police ne contient pas le glyphe nécessaire. Dans ce cas, il est possible d’utiliser l’une des polices de secours spécifiées pour le remplacement du glyphe.

Aspose.Slides permet de créer des polices de secours, de les ajouter à la collection de polices de secours, de définir une collection de polices de secours pour une présentation donnée, de supprimer des polices de secours d’une présentation, de spécifier les règles d’application des polices de secours et d’autres opérations.

Pour vous familiariser avec ces fonctionnalités, utilisez les liens suivants :

- [Créer une police de secours](/slides/fr/cpp/create-fallback-font)
- [Créer une collection de polices de secours](/slides/fr/cpp/create-fallback-fonts-collection)
- [Rendu d’une présentation avec police de secours](/slides/fr/cpp/render-presentation-with-fallback-font)

## **FAQ**

**En quoi les polices de secours diffèrent-elles de la substitution de police ?**

La police de secours est appliquée caractère par caractère ou par plage Unicode lorsque la police principale ne possède pas de glyphes spécifiques ; elle ne remplit que les caractères manquants. [Substitution](/slides/fr/cpp/font-substitution/) remplace une police manquante ou indisponible pour l’ensemble d’un segment ou d’une portion de texte par une autre police. Elles peuvent être combinées, mais leur portée et leur logique de sélection sont différentes.

**Les paramètres de secours sont-ils enregistrés dans le fichier de présentation ?**

Non. La configuration de secours vit au moment du traitement/rendu dans la bibliothèque et n’est pas sérialisée dans le PPTX. La présentation ne conserve pas vos règles de secours.

**La police de secours affecte-t-elle les éléments créés par les objets PowerPoint (SmartArt, graphiques, WordArt) ?**

Oui. Le texte à l’intérieur de ces objets passe par le même pipeline de rendu, de sorte que les mêmes règles de secours s’appliquent à celui‑ci comme au texte ordinaire.