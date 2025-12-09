---
title: Rendu des diapositives de présentation en images SVG dans .NET
linktitle: Diapositive vers SVG
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
description: "Apprenez à rendre les diapositives PowerPoint en images SVG à l'aide d'Aspose.Slides pour .NET. Des visuels de haute qualité avec des exemples de code C# simples."
---

## **Aperçu**

Cet article explique comment **convertir une présentation PowerPoint au format SVG en utilisant C#**. Il couvre les sujets suivants.

_Format_: **PowerPoint**
- [C# PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# Convertir PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# Comment convertir le fichier PowerPoint en SVG](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT en SVG](#csharp-ppt-to-svg)
- [C# Convertir PPT en SVG](#csharp-ppt-to-svg)
- [C# Comment convertir le fichier PPT en SVG](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX en SVG](#csharp-pptx-to-svg)
- [C# Convertir PPTX en SVG](#csharp-pptx-to-svg)
- [C# Comment convertir le fichier PPTX en SVG](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP en SVG](#csharp-odp-to-svg)
- [C# Convertir ODP en SVG](#csharp-odp-to-svg)
- [C# Comment convertir le fichier ODP en SVG](#csharp-odp-to-svg)

_Format_: **Slide**
- [C# Convertir la diapositive PowerPoint en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir la diapositive PPT en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir la diapositive PPTX en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir la diapositive ODP en SVG](#render-a-slide-as-an-svg-image)

Autres sujets couverts par cet article.
- [Voir aussi](#see-also)

## **Format SVG**
SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou leur apparence.

SVG est l’un des rares formats d’image qui satisfait des exigences très élevées en matière de : évolutivité, interactivité, performances, accessibilité, programmabilité, etc. Pour ces raisons, il est couramment utilisé dans le développement Web.

Vous pouvez souhaiter utiliser des fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n’importe quelle résolution. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser des graphiques et diagrammes de vos diapositives dans *différents supports ou plates‑formes*.** La plupart des lecteurs peuvent interpréter les fichiers SVG. 
- **utiliser les *tailles les plus petites possibles d’images*.** Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d’autres formats, en particulier ceux basés sur des images bitmap (JPEG ou PNG).

## **Rendre une diapositive en tant qu’image SVG**

Aspose.Slides for .NET vous permet d’exporter les diapositives de vos présentations sous forme d’images SVG. Suivez ces étapes pour générer des images SVG :

_Étapes : conversions PowerPoint vers SVG en C#_

Le code d’exemple suivant explique ces conversions avec .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Étapes : convertir PowerPoint en SVG en C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Étapes : convertir PPT en SVG en C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Étapes : convertir PPTX en SVG en C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Étapes : convertir ODP en SVG en C#</strong></a>

_Code Steps:_

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * _.ppt_ extension pour charger le fichier **PPT** dans la classe _Presentation_.
   * _.pptx_ extension pour charger le fichier **PPTX** dans la classe _Presentation_.
   * _.odp_ extension pour charger le fichier **ODP** dans la classe _Presentation_.
   * _.pps_ extension pour charger le fichier **PPS** dans la classe _Presentation_.
2. Parcourez toutes les diapositives de la présentation.
3. Enregistrez chaque diapositive dans son propre fichier SVG via FileStream.

{{% alert color="primary" %}} 

Vous pouvez essayer notre [application Web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT en SVG d’Aspose.Slides pour .NET.

{{% /alert %}} 

Ce code d’exemple en C# vous montre comment convertir PowerPoint en SVG à l’aide d’Aspose.Slides : 
``` csharp
// L'objet Presentation peut charger des formats PowerPoint tels que PPT, PPTX, ODP etc.
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

**Pourquoi le SVG résultant peut-il apparaître différemment selon les navigateurs ?**

Le support de certaines fonctionnalités SVG est implémenté différemment selon les moteurs de navigateur. Les paramètres [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) aident à lisser ces incompatibilités.

**Est‑il possible d’exporter non seulement les diapositives mais aussi des formes individuelles en SVG ?**

Oui. Toute [shape can be saved as a separate SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.

**Peut‑on combiner plusieurs diapositives en un seul SVG (strip/document) ?**

Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives dans un même canevas SVG est une étape de post‑traitement réalisée au niveau de l’application.

## **Voir aussi** 

Cet article couvre également ces sujets. Les codes sont les mêmes que ci‑dessus.

_Format_: **PowerPoint**
- [C# PowerPoint en SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint en SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint en SVG Programmatically](#csharp-powerpoint-to-svg)
- [C# PowerPoint en SVG Library](#csharp-powerpoint-to-svg)
- [C# Save PowerPoint as SVG](#csharp-powerpoint-to-svg)
- [C# Generate SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# Create SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Converter](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT en SVG Code](#csharp-ppt-to-svg)
- [C# PPT en SVG API](#csharp-ppt-to-svg)
- [C# PPT en SVG Programmatically](#csharp-ppt-to-svg)
- [C# PPT en SVG Library](#csharp-ppt-to-svg)
- [C# Save PPT as SVG](#csharp-ppt-to-svg)
- [C# Generate SVG from PPT](#csharp-ppt-to-svg)
- [C# Create SVG from PPT](#csharp-ppt-to-svg)
- [C# PPT to SVG Converter](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX en SVG Code](#csharp-pptx-to-svg)
- [C# PPTX en SVG API](#csharp-pptx-to-svg)
- [C# PPTX en SVG Programmatically](#csharp-pptx-to-svg)
- [C# PPTX en SVG Library](#csharp-pptx-to-svg)
- [C# Save PPTX as SVG](#csharp-pptx-to-svg)
- [C# Generate SVG from PPTX](#csharp-pptx-to-svg)
- [C# Create SVG from PPTX](#csharp-pptx-to-svg)
- [C# PPTX to SVG Converter](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP en SVG Code](#csharp-odp-to-svg)
- [C# ODP en SVG API](#csharp-odp-to-svg)
- [C# ODP en SVG Programmatically](#csharp-odp-to-svg)
- [C# ODP en SVG Library](#csharp-odp-to-svg)
- [C# Save ODP as SVG](#csharp-odp-to-svg)
- [C# Generate SVG from ODP](#csharp-odp-to-svg)
- [C# Create SVG from ODP](#csharp-odp-to-svg)
- [C# ODP to SVG Converter](#csharp-odp-to-svg)