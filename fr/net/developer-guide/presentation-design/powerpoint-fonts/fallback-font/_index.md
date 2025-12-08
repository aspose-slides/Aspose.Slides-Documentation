---
title: Police de secours - API PowerPoint C#
linktitle: Police de secours
type: docs
weight: 50
url: /fr/net/fallback-font/
keywords: "Police de secours, police, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: Lorsque la police ne contient pas le glyphe nécessaire, l'API PowerPoint C# vous permet d'utiliser l'une des polices de secours spécifiées pour le remplacement du glyphe.
---

## **Police de secours**
La police de secours est utilisée lorsque la police spécifiée pour le texte est disponible dans le système, mais que cette police ne contient pas le glyphe nécessaire. Dans ce cas, il est possible d’utiliser l’une des polices de secours spécifiées pour le remplacement du glyphe.

Aspose.Slides permet de créer des polices de secours, de les ajouter à la collection de polices de secours, de définir la collection de polices de secours pour une présentation donnée, de supprimer des polices de secours d’une présentation, de spécifier les règles d’application des polices de secours, etc.

Pour se familiariser avec ces fonctionnalités, utilisez les liens suivants :
- [Créer une police de secours](/slides/fr/net/create-fallback-font)
- [Créer une collection de polices de secours](/slides/fr/net/create-fallback-fonts-collection)
- [Rendre une présentation avec une police de secours](/slides/fr/net/render-presentation-with-fallback-font)

## **FAQ**

**Comment les polices de secours diffèrent‑elles de la substitution de police ?**
La police de secours s’applique caractère par caractère ou par plage Unicode lorsque la police principale ne possède pas de glyphes spécifiques ; elle ne comble que les caractères manquants. [Substitution](/slides/fr/net/font-substitution/) remplace une police manquante ou indisponible pour l’ensemble d’une séquence ou d’une portion de texte par une autre police. Elles peuvent être combinées, mais leur portée et leur logique de sélection sont différentes.

**Les paramètres de secours sont‑ils enregistrés dans le fichier de présentation ?**
Non. La configuration de secours vit au moment du traitement/du rendu dans la bibliothèque et n’est pas sérialisée dans le PPTX. La présentation ne stocke pas vos règles de secours.

**La police de secours affecte‑t‑elle les éléments créés par les objets PowerPoint (SmartArt, graphiques, WordArt) ?**
Oui. Le texte à l’intérieur de ces objets passe par le même pipeline de rendu, de sorte que les mêmes règles de secours s’appliquent à celui‑ci comme au texte standard.