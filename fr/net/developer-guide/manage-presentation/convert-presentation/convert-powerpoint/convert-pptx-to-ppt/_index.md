---
title: Convertir PPTX en PPT en C#
linktitle: Convertir PPTX en PPT
type: docs
weight: 21
url: /net/convert-pptx-to-ppt/
keywords: "C# Convertir PPTX en PPT, Convertir Présentation PowerPoint, PPTX en PPT, C#, Aspose.Slides"
description: "Convertir PowerPoint PPTX en PPT en C#"
---

## **Aperçu**

Cet article explique comment convertir une Présentation PowerPoint au format PPTX en format PPT en utilisant C#. Le sujet suivant est traité.

- Convertir PPTX en PPT en C#

## **C# Convertir PPTX en PPT**

Pour le code d'exemple C# pour convertir PPTX en PPT, veuillez consulter la section ci-dessous i.e. [Convertir PPTX en PPT](#convert-pptx-to-ppt). Il suffit de charger le fichier PPTX et de l'enregistrer au format PPT. En spécifiant différents formats d'enregistrement, vous pouvez également enregistrer le fichier PPTX dans de nombreux autres formats comme PDF, XPS, ODP, HTML, etc. comme discuté dans ces articles.

- [C# Convertir PPTX en PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convertir PPTX en XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convertir PPTX en HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convertir PPTX en ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convertir PPTX en Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Convertir PPTX en PPT**
Pour convertir un PPTX en PPT, il suffit de passer le nom du fichier et le format d'enregistrement à la méthode [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). L'exemple de code C# ci-dessous convertit une Présentation de PPTX en PPT en utilisant les options par défaut.

```c#
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("presentation.pptx");

// Enregistrer la présentation PPTX au format PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```