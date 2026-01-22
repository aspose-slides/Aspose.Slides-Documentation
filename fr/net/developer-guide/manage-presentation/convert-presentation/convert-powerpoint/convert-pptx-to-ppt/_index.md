---
title: Convertir PPTX en PPT dans .NET
linktitle: PPTX en PPT
type: docs
weight: 21
url: /fr/net/convert-pptx-to-ppt/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPTX
- PPTX en PPT
- enregistrer PPTX en PPT
- exporter PPTX en PPT
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Convertissez facilement PPTX en PPT avec Aspose.Slides pour .NET—garantissez une compatibilité transparente avec les formats PowerPoint tout en préservant la mise en page et la qualité de votre présentation."
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PPTX en format PPT à l'aide de C#. Le sujet suivant est couvert.

- Convertir PPTX en PPT en C#

## **Convertir PPTX en PPT avec .NET**

Pour obtenir un exemple de code C# permettant de convertir PPTX en PPT, veuillez consulter la section ci‑dessous, à savoir [Convert PPTX to PPT](#convert-pptx-to-ppt). Il charge simplement le fichier PPTX et l'enregistre au format PPT. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles. 

- [Convertir PPTX en PDF avec .NET](/slides/fr/net/convert-powerpoint-to-pdf/)
- [Convertir PPTX en XPS avec .NET](/slides/fr/net/convert-powerpoint-to-xps/)
- [Convertir PPTX en HTML avec .NET](/slides/fr/net/convert-powerpoint-to-html/)
- [Convertir PPTX en ODP avec .NET](/slides/fr/net/save-presentation/)
- [Convertir PPTX en PNG avec .NET](/slides/fr/net/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, il suffit de transmettre le nom du fichier et le format d'enregistrement à la méthode [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). L'exemple de code C# ci‑dessous convertit une présentation de PPTX en PPT en utilisant les options par défaut.
```c#
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("presentation.pptx");

// Enregistrement de la présentation PPTX au format PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**Tous les effets et fonctionnalités PPTX sont‑ils conservés lors de l'enregistrement au format PPT hérité (97‑2003) ?**

Pas toujours. Le format PPT ne prend pas en charge certaines fonctionnalités plus récentes (par exemple, certains effets, objets et comportements), de sorte que les fonctionnalités peuvent être simplifiées ou rasterisées lors de la conversion.

**Puis‑je convertir uniquement des diapositives sélectionnées en PPT au lieu de toute la présentation ?**

L'enregistrement direct cible l'intégralité de la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives et enregistrez‑la au format PPT ; sinon, utilisez un service/API qui prend en charge les paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l'ouvrir avec un mot de passe, et également [configurer les paramètres de protection/chiffrement](/slides/fr/net/password-protected-presentation/) pour le PPT enregistré.