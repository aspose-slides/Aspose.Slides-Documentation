---
title: Convertir PPTX en PPT en C#
linktitle: Convertir PPTX en PPT
type: docs
weight: 21
url: /fr/net/convert-pptx-to-ppt/
keywords: "C# Convertir PPTX en PPT, Convertir une présentation PowerPoint, PPTX en PPT, C#, Aspose.Slides"
description: "Convertir PowerPoint PPTX en PPT en C#"
---

## **Vue d'ensemble**

Cet article décrit comment convertir une présentation PowerPoint au format PPTX en format PPT à l'aide de C#. Le sujet suivant est couvert.

- Convertir PPTX en PPT en C#

## **C# Convertir PPTX en PPT**

Pour le code d'exemple C# permettant de convertir PPTX en PPT, veuillez consulter la section ci-dessous, à savoir [Convertir PPTX en PPT](#convert-pptx-to-ppt). Il charge simplement le fichier PPTX et l'enregistre au format PPT. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles.

- [C# Convertir PPTX en PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convertir PPTX en XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convertir PPTX en HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convertir PPTX en ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convertir PPTX en Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, il suffit de transmettre le nom du fichier et le format d'enregistrement à la méthode [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). L'exemple de code C# ci-dessous convertit une présentation de PPTX en PPT en utilisant les options par défaut.
```c#
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("presentation.pptx");

// Enregistrer la présentation PPTX au format PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**Toutes les effets et fonctionnalités PPTX sont‑ils conservés lors de l'enregistrement au format PPT hérité (97-2003) ?**

Pas toujours. Le format PPT ne possède pas certaines capacités plus récentes (par exemple, certains effets, objets et comportements), de sorte que des fonctionnalités peuvent être simplifiées ou rasterisées lors de la conversion.

**Puis‑je convertir uniquement des diapositives sélectionnées en PPT au lieu de toute la présentation ?**

L'enregistrement direct cible l'ensemble de la présentation. Pour convertir des diapositives spécifiques, créez une nouvelle présentation contenant uniquement ces diapositives et enregistrez‑la au format PPT ; alternativement, utilisez un service/API qui prend en charge des paramètres de conversion par diapositive.

**Les présentations protégées par mot de passe sont‑elles prises en charge ?**

Oui. Vous pouvez détecter si un fichier est protégé, l'ouvrir avec un mot de passe, et également [configurer les paramètres de protection/encryption](/slides/fr/net/password-protected-presentation/) pour le PPT enregistré.