---
title: Premiers pas
type: docs
weight: 10
url: /fr/net/getting-started/
keywords:
- premiers pas
- exigences du système
- installation
- première présentation
- NuGet
- traitement PPT
- traitement PPTX
- traitement ODP
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Le chemin d'un nouveau projet .NET à une première présentation enregistrée avec Aspose.Slides : vérifiez les exigences, installez le package, exécutez un premier programme et poursuivez avec les tâches courantes."
---
## **Vue d'ensemble**

Suivez les quatre étapes ci-dessous dans l'ordre. Chaque étape indique quoi faire et lie l'article aux détails. L'évaluation, la licence et le support sont présentés après les étapes.

## **Étape 1: Vérifier les exigences du système**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) s'exécute sur Windows, Linux et macOS. [Exigences du système](/slides/fr/net/system-requirements/) liste les systèmes d'exploitation et les versions .NET que chaque package prend en charge, ainsi que les bibliothèques dont Linux a besoin en supplément.

## **Étape 2: Installer le package**

Aspose.Slides for .NET est distribué via NuGet sous forme de deux packages qui offrent les mêmes classes. Ajoutez l'un d'eux à votre projet :

- Sur Windows : `dotnet add package Aspose.Slides.NET`
- Sur Linux et macOS : `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Sous Linux, installez d'abord la bibliothèque `fontconfig`.
- Sur Alpine Linux, et sur les systèmes Linux dont la glibc est antérieure à 2.23 (x64) ou 2.39 (ARM64) : Aspose.Slides.NET, avec la bibliothèque `libgdiplus` installée.

[Installation](/slides/fr/net/installation/) fournit les commandes Linux, le paramètre de démarrage supplémentaire requis par Aspose.Slides.NET sous Linux, et les étapes pour Visual Studio.

## **Étape 3: Créer votre première présentation**

Le [démarrage rapide sur la page d'accueil d'Aspose.Slides for .NET](/slides/fr/net/#your-first-presentation) est un programme console complet : il ajoute une zone de texte à une diapositive et enregistre la présentation au format PPTX. [Créer des présentations](/slides/fr/net/create-presentation/) explique les mêmes étapes plus en détail et montre comment ouvrir une présentation existante et l'enregistrer dans un autre format.

## **Étape 4: Poursuivre avec les tâches courantes**

- [Ouvrir une présentation](/slides/fr/net/open-presentation/)
- [Enregistrer une présentation](/slides/fr/net/save-presentation/)
- [Convertir une présentation en PDF](/slides/fr/net/convert-powerpoint-to-pdf/)
- [Rendre les diapositives en images](/slides/fr/net/convert-slide/)
- [Modifier le texte d'une présentation](/slides/fr/net/manage-text/)
- [Exemples par élément de diapositive](/slides/fr/net/examples/)

## **Évaluer et licencier**

Sans licence, Aspose.Slides s'exécute en mode d'évaluation : il ajoute un filigrane à chaque diapositive qu'il enregistre et tronque le texte lu à partir des présentations.

[Évaluer Aspose.Slides](/slides/fr/net/evaluate-aspose-slides/) décrit les limitations de l'évaluation et comment demander une licence temporaire. [Licence](/slides/fr/net/licensing/) montre comment appliquer une licence à partir d'un fichier, d'un flux ou d'une ressource intégrée. [Licence mesurée](/slides/fr/net/metered-licensing/) couvre les licences facturées à l'usage. [Formats de fichiers pris en charge](/slides/fr/net/supported-file-formats/) répertorie les formats qu'Aspose.Slides peut charger et enregistrer.

## **Obtenir de l'aide**

[Support produit](/slides/fr/net/product-support/) explique comment poser une question sur le [forum d'assistance gratuit](https://forum.aspose.com/c/slides/11) et ce qu'il faut inclure lorsque vous signalez un problème.

## **FAQ**

**Dois-je installer Microsoft PowerPoint ?**

Non. Aspose.Slides lit et écrit les fichiers de présentation lui-même et n'utilise pas PowerPoint, il s'exécute donc également sur les serveurs et sous Linux.

**Quel package devrais-je utiliser pour une application .NET Framework ?**

Aspose.Slides.NET. Il comprend des builds pour .NET Framework 4.6.2 et versions ultérieures, .NET 6 et versions ultérieures, et .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform requiert .NET 6 ou une version ultérieure.