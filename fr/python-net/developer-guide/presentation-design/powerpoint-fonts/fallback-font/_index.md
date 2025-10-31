---
title: Gérer les polices de secours pour les présentations en Python
linktitle: Police de secours
type: docs
weight: 50
url: /fr/python-net/fallback-font/
keywords:
- police de secours
- police disponible
- remplacement de glyphe
- spécifier une police
- spécifier une règle
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour Python via .NET utilise les polices de secours pour maintenir la lisibilité du texte dans les présentations PowerPoint et OpenDocument lorsque les polices d'origine ne sont pas disponibles."
---

## **Police de secours**
La police de secours est utilisée lorsque la police spécifiée pour le texte est disponible dans le système, mais que cette police ne contient pas le glyphe nécessaire. Dans ce cas, il est possible d’utiliser l’une des polices de secours spécifiées pour le remplacement du glyphe.

Aspose.Slides permet de créer des polices de secours, de les ajouter à la collection de polices de secours, de définir la collection de polices de secours pour une présentation donnée, de supprimer des polices de secours d’une présentation, de spécifier les règles d’application des polices de secours, entre autres.

Pour vous familiariser avec ces fonctionnalités, utilisez les liens suivants :

- [Créer une police de secours](/slides/fr/python-net/create-fallback-font)
- [Créer une collection de polices de secours](/slides/fr/python-net/create-fallback-fonts-collection)
- [Rendre une présentation avec une police de secours](/slides/fr/python-net/render-presentation-with-fallback-font)

## **FAQ**

**Comment les polices de secours diffèrent‑elles de la substitution de police ?**

La police de secours s’applique caractère par caractère ou par plage Unicode lorsque la police principale ne possède pas certains glyphes ; elle ne remplace que les caractères manquants. La [substitution](/slides/fr/python-net/font-substitution/) remplace une police absente ou indisponible pour l’ensemble d’un segment de texte ou d’une zone de texte par une autre police. Elles peuvent être combinées, mais leur portée et leur logique de sélection diffèrent.

**Les paramètres de secours sont‑ils enregistrés dans le fichier de présentation ?**

Non. La configuration de secours vit uniquement pendant le traitement/le rendu dans la bibliothèque et n’est pas sérialisée dans le fichier PPTX. La présentation ne conserve pas vos règles de secours.

**La police de secours affecte‑t‑elle les éléments créés par les objets PowerPoint (SmartArt, graphiques, WordArt) ?**

Oui. Le texte à l’intérieur de ces objets passe par le même pipeline de rendu, de sorte que les mêmes règles de secours s’appliquent à ce texte qu’au texte ordinaire.