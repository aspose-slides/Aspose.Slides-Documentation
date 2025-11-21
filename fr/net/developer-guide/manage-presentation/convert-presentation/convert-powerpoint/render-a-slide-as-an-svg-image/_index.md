---
title: Rendu des diapositives de présentation au format SVG dans .NET
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint en SVG
- présentation en SVG
- diapositive en SVG
- PPT en SVG
- PPTX en SVG
- enregistrer PPT en SVG
- enregistrer PPTX en SVG
- exporter PPT en SVG
- exporter PPTX en SVG
- rendre diapositive
- convertir diapositive
- exporter diapositive
- image vectorielle
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à rendre des diapositives PowerPoint au format SVG à l’aide d’Aspose.Slides pour .NET. Des visuels de haute qualité avec des exemples de code C# simples."
---

## **Vue d'ensemble**

Cet article explique comment **convertir une présentation PowerPoint au format SVG en utilisant C#**. Il couvre les sujets suivants.

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

_Format_: **Slide**
- [C# Convertir la diapositive PowerPoint en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir la diapositive PPT en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir la diapositive PPTX en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir la diapositive ODP en SVG](#render-a-slide-as-an-svg-image)

Autres sujets abordés dans cet article.
- [Voir aussi](#see-also)

## **Format SVG**
SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs dans du XML avec des détails qui définissent leur comportement ou leur apparence.

SVG est l’un des rares formats d’image qui répond à des exigences très élevées en matière de évolutivité, d’interactivité, de performances, d’accessibilité, de programmabilité, etc. Pour ces raisons, il est couramment utilisé dans le développement Web.

Vous pouvez vouloir utiliser des fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n’importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser les graphiques et diagrammes de vos diapositives dans *différents supports ou plateformes*.** La plupart des lecteurs peuvent interpréter les fichiers SVG. 
- **utiliser les *tailles les plus petites possibles d’images*.** Les fichiers SVG sont généralement plus légers que leurs équivalents haute résolution dans d’autres formats, en particulier les formats basés sur le bitmap (JPEG ou PNG).

## **Rendre une diapositive en image SVG**

Aspose.Slides for .NET vous permet d’exporter les diapositives de vos présentations au format SVG. Suivez ces étapes pour générer des images SVG :

*_Étapes : Conversions PowerPoint en SVG en C#_*

Le code d’exemple suivant explique ces conversions avec .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Étapes : Convertir PowerPoint en SVG en C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Étapes : Convertir PPT en SVG en C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Étapes : Convertir PPTX en SVG en C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Étapes : Convertir ODP en SVG en C#</strong></a>

_Étapes du code :_

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * _.ppt_ extension pour charger le fichier **PPT** dans la classe _Presentation_.
   * _.pptx_ extension pour charger le fichier **PPTX** dans la classe _Presentation_.
   * _.odp_ extension pour charger le fichier **ODP** dans la classe _Presentation_.
   * _.pps_ extension pour charger le fichier **PPS** dans la classe _Presentation_.
2. Parcourez toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG via FileStream.

{{% alert color="primary" %}} 

Vous pouvez essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT vers SVG d’Aspose.Slides for .NET. 

{{% /alert %}} 

Ce code d’exemple en C# montre comment convertir PowerPoint en SVG avec Aspose.Slides :
``` csharp
// L'objet Presentation peut charger les formats PowerPoint tels que PPT, PPTX, ODP, etc.
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


## **FAQ**

**Pourquoi le SVG généré peut-il apparaître différemment selon les navigateurs ?**

La prise en charge de certaines fonctionnalités SVG varie selon les moteurs de navigation. Les paramètres [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) aident à atténuer les incompatibilités.

**Est-il possible d’exporter non seulement les diapositives mais aussi des formes individuelles en SVG ?**

Oui. Toute [forme peut être enregistrée en tant que SVG séparé](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.

**Peut-on combiner plusieurs diapositives en un seul SVG (bande/document) ?**

Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives dans un même canevas SVG est une opération de post‑traitement effectuée au niveau de l’application.

## **Voir aussi** 

Cet article couvre également ces sujets. Les codes sont les mêmes que ci‑dessus.

_Format_: **PowerPoint**
- [C# PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint API SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint programme SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint bibliothèque SVG](#csharp-powerpoint-to-svg)
- [C# Enregistrer PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# Générer SVG depuis PowerPoint](#csharp-powerpoint-to-svg)
- [C# Créer SVG depuis PowerPoint](#csharp-powerpoint-to-svg)
- [C# Convertisseur PowerPoint en SVG](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT en SVG](#csharp-ppt-to-svg)
- [C# PPT API SVG](#csharp-ppt-to-svg)
- [C# PPT programme SVG](#csharp-ppt-to-svg)
- [C# PPT bibliothèque SVG](#csharp-ppt-to-svg)
- [C# Enregistrer PPT en SVG](#csharp-ppt-to-svg)
- [C# Générer SVG depuis PPT](#csharp-ppt-to-svg)
- [C# Créer SVG depuis PPT](#csharp-ppt-to-svg)
- [C# Convertisseur PPT en SVG](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX en SVG](#csharp-pptx-to-svg)
- [C# PPTX API SVG](#csharp-pptx-to-svg)
- [C# PPTX programme SVG](#csharp-pptx-to-svg)
- [C# PPTX bibliothèque SVG](#csharp-pptx-to-svg)
- [C# Enregistrer PPTX en SVG](#csharp-pptx-to-svg)
- [C# Générer SVG depuis PPTX](#csharp-pptx-to-svg)
- [C# Créer SVG depuis PPTX](#csharp-pptx-to-svg)
- [C# Convertisseur PPTX en SVG](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP en SVG](#csharp-odp-to-svg)
- [C# ODP API SVG](#csharp-odp-to-svg)
- [C# ODP programme SVG](#csharp-odp-to-svg)
- [C# ODP bibliothèque SVG](#csharp-odp-to-svg)
- [C# Enregistrer ODP en SVG](#csharp-odp-to-svg)
- [C# Générer SVG depuis ODP](#csharp-odp-to-svg)
- [C# Créer SVG depuis ODP](#csharp-odp-to-svg)
- [C# Convertisseur ODP en SVG](#csharp-odp-to-svg)