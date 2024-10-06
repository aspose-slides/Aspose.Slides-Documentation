---
title: Rendre une diapositive en tant qu'image SVG en C#
linktitle: Rendre une diapositive en tant qu'image SVG
type: docs
weight: 50
url: /net/render-a-slide-as-an-svg-image/
description: Cet article explique comment convertir une présentation PowerPoint au format SVG à l'aide de C#. Vous pouvez convertir les formats PPT, PPTX, ODP en images SVG.
keywords: C# Convertir PowerPoint en SVG, C# PPT en SVG, C# PPTX en SVG
---

## Aperçu

Cet article explique comment **convertir une présentation PowerPoint au format SVG à l'aide de C#**. Il couvre les sujets suivants.

_Format_: **PowerPoint**
- [C# PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# Convertir PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# Comment convertir un fichier PowerPoint en SVG](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT en SVG](#csharp-ppt-to-svg)
- [C# Convertir PPT en SVG](#csharp-ppt-to-svg)
- [C# Comment convertir un fichier PPT en SVG](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX en SVG](#csharp-pptx-to-svg)
- [C# Convertir PPTX en SVG](#csharp-pptx-to-svg)
- [C# Comment convertir un fichier PPTX en SVG](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP en SVG](#csharp-odp-to-svg)
- [C# Convertir ODP en SVG](#csharp-odp-to-svg)
- [C# Comment convertir un fichier ODP en SVG](#csharp-odp-to-svg)

_Format_: **Diapositive**
- [C# Convertir une diapositive PowerPoint en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir une diapositive PPT en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir une diapositive PPTX en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir une diapositive ODP en SVG](#render-a-slide-as-an-svg-image)

D'autres sujets abordés par cet article.
- [Voir aussi](#see-also)

## Format SVG
SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images en deux dimensions. SVG stocke des images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou leur apparence.

SVG est l'un des rares formats d'images qui répond à des normes très élevées à cet égard : évolutivité, interactivité, performance, accessibilité, programmabilité, et autres. Pour ces raisons, il est couramment utilisé dans le développement web.

Vous voudrez peut-être utiliser des fichiers SVG lorsque vous avez besoin de

- **imprimer votre présentation dans un *formats très grand*.** Les images SVG peuvent s'adapter à n'importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser des graphiques et tableaux de vos diapositives dans *différents supports ou plateformes**.* La plupart des lecteurs peuvent interpréter des fichiers SVG.
- **utiliser les *tailles d'image les plus petites possibles***. Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d'autres formats, en particulier ceux basés sur des images bitmap (JPEG ou PNG).

## Rendre une Diapositive en tant qu'Image SVG

Aspose.Slides pour .NET vous permet d'exporter des diapositives de vos présentations en tant qu'images SVG. Suivez ces étapes pour générer des images SVG :

_Etapes : Conversions PowerPoint en SVG en C#_

Le code d'exemple suivant explique ces conversions en utilisant .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Étapes : Convertir PowerPoint en SVG en C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Étapes : Convertir PPT en SVG en C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Étapes : Convertir PPTX en SVG en C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Étapes : Convertir ODP en SVG en C#</strong></a>

_Etapes de code :_

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * _.ppt_ extension pour charger un fichier **PPT** dans la classe _Presentation_.
   * _.pptx_ extension pour charger un fichier **PPTX** dans la classe _Presentation_.
   * _.odp_ extension pour charger un fichier **ODP** dans la classe _Presentation_.
   * _.pps_ extension pour charger un fichier **PPS** dans la classe _Presentation_.
2. Parcourir toutes les diapositives de la présentation.
3. Écrire chaque diapositive dans son propre fichier SVG via FileStream.

{{% alert color="primary" %}} 

Vous voudrez peut-être essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT en SVG d'Aspose.Slides pour .NET.

{{% /alert %}} 

Ce code d'exemple en C# vous montre comment convertir PowerPoint en SVG en utilisant Aspose.Slides : 

``` csharp
// L'objet Presentation peut charger des formats PowerPoint comme PPT, PPTX, ODP, etc.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## Voir Aussi 

Cet article couvre également ces sujets. Les codes sont les mêmes que ci-dessus.

_Format_: **PowerPoint**
- [C# Code PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# API PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint en SVG par programmation](#csharp-powerpoint-to-svg)
- [C# Bibliothèque PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# Enregistrer PowerPoint en tant que SVG](#csharp-powerpoint-to-svg)
- [C# Générer SVG à partir de PowerPoint](#csharp-powerpoint-to-svg)
- [C# Créer SVG à partir de PowerPoint](#csharp-powerpoint-to-svg)
- [C# Convertisseur PowerPoint en SVG](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# Code PPT en SVG](#csharp-ppt-to-svg)
- [C# API PPT en SVG](#csharp-ppt-to-svg)
- [C# PPT en SVG par programmation](#csharp-ppt-to-svg)
- [C# Bibliothèque PPT en SVG](#csharp-ppt-to-svg)
- [C# Enregistrer PPT en tant que SVG](#csharp-ppt-to-svg)
- [C# Générer SVG à partir de PPT](#csharp-ppt-to-svg)
- [C# Créer SVG à partir de PPT](#csharp-ppt-to-svg)
- [C# Convertisseur PPT en SVG](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# Code PPTX en SVG](#csharp-pptx-to-svg)
- [C# API PPTX en SVG](#csharp-pptx-to-svg)
- [C# PPTX en SVG par programmation](#csharp-pptx-to-svg)
- [C# Bibliothèque PPTX en SVG](#csharp-pptx-to-svg)
- [C# Enregistrer PPTX en tant que SVG](#csharp-pptx-to-svg)
- [C# Générer SVG à partir de PPTX](#csharp-pptx-to-svg)
- [C# Créer SVG à partir de PPTX](#csharp-pptx-to-svg)
- [C# Convertisseur PPTX en SVG](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# Code ODP en SVG](#csharp-odp-to-svg)
- [C# API ODP en SVG](#csharp-odp-to-svg)
- [C# ODP en SVG par programmation](#csharp-odp-to-svg)
- [C# Bibliothèque ODP en SVG](#csharp-odp-to-svg)
- [C# Enregistrer ODP en tant que SVG](#csharp-odp-to-svg)
- [C# Générer SVG à partir de ODP](#csharp-odp-to-svg)
- [C# Créer SVG à partir de ODP](#csharp-odp-to-svg)
- [C# Convertisseur ODP en SVG](#csharp-odp-to-svg)