---
title: Convertir ODP en PPTX en C#
linktitle: Convertir ODP en PPTX
type: docs
weight: 10
url: /fr/net/convert-odp-to-pptx/
keywords: "Convertir OpenOffice Presentation, ODP, ODP en PPTX, C#, Csharp, .NET"
description: "Convertir OpenOffice ODP en présentation PowerPoint PPTX en C# ou .NET"
---

## Aperçu

Cet article explique les sujets suivants.

- [C# Convertir ODP en PPTX](#csharp-odp-to-pptx)
- [C# Convertir ODP en PowerPoint](#csharp-odp-to-powerpoint)

## Conversion C# ODP en PPTX

Aspose.Slides pour .NET propose la classe Presentation qui représente un fichier de présentation. [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) peut maintenant également accéder à ODP via le constructeur Presentation lorsque l'objet est instancié. L'exemple suivant montre comment convertir une présentation ODP en présentation PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Étapes : Convertir ODP en PPTX en C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Étapes : Convertir ODP en PowerPoint en C#</strong></a>

```c#
// Ouvrir le fichier ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Sauvegarder la présentation ODP au format PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Exemple en direct**
Vous pouvez visiter [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) application web, qui est construite avec **Aspose.Slides API.** L'application démontre comment la conversion ODP en PPTX peut être implémentée avec l'API Aspose.Slides.