---
title: Rendre une diapositive en tant qu'image SVG en C#
linktitle: Rendre une diapositive en tant qu'image SVG
type: docs
weight: 50
url: /fr/net/render-a-slide-as-an-svg-image/
description: Cet article explique comment convertir une présentation PowerPoint au format SVG à l'aide de C#. Vous pouvez convertir les formats PPT, PPTX, ODP en images SVG.
keywords: C# Convertir PowerPoint en SVG, C# PPT en SVG, C# PPTX en SVG
---

## **Aperçu**

Cet article explique comment **convertir une présentation PowerPoint au format SVG à l'aide de C#**. Il couvre les sujets suivants.

_Format_ : **PowerPoint**
- [C# PowerPoint vers SVG](#csharp-powerpoint-to-svg)
- [C# Convertir PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# Comment convertir un fichier PowerPoint en SVG](#csharp-powerpoint-to-svg)

_Format_ : **PPT**
- [C# PPT vers SVG](#csharp-ppt-to-svg)
- [C# Convertir PPT en SVG](#csharp-ppt-to-svg)
- [C# Comment convertir un fichier PPT en SVG](#csharp-ppt-to-svg)

_Format_ : **PPTX**
- [C# PPTX vers SVG](#csharp-pptx-to-svg)
- [C# Convertir PPTX en SVG](#csharp-pptx-to-svg)
- [C# Comment convertir un fichier PPTX en SVG](#csharp-pptx-to-svg)

_Format_ : **ODP**
- [C# ODP vers SVG](#csharp-odp-to-svg)
- [C# Convertir ODP en SVG](#csharp-odp-to-svg)
- [C# Comment convertir un fichier ODP en SVG](#csharp-odp-to-svg)

_Format_ : **Diapositive**
- [C# Convertir la diapositive PowerPoint en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir la diapositive PPT en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir la diapositive PPTX en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir la diapositive ODP en SVG](#render-a-slide-as-an-svg-image)

Autres sujets abordés dans cet article.
- [Voir aussi](#see-also)

## **Format SVG**

SVG—acronyme de Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs dans du XML avec des détails qui définissent leur comportement ou leur apparence.  

SVG est l'un des rares formats d'images à répondre à des exigences très élevées en matière de scalabilité, d'interactivité, de performance, d'accessibilité, de programmabilité, etc. Pour ces raisons, il est couramment utilisé dans le développement Web.  

Vous pouvez souhaiter utiliser des fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n'importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.  
- **utiliser les graphiques et diagrammes de vos diapositives dans *différents supports ou plates‑formes*.** La plupart des lecteurs peuvent interpréter les fichiers SVG.  
- **utiliser les *tailles les plus petites possibles d'images***. Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d'autres formats, en particulier ceux basés sur le bitmap (JPEG ou PNG).  

## **Rendre une diapositive en tant qu'image SVG**

Aspose.Slides pour .NET vous permet d'exporter les diapositives de vos présentations sous forme d'images SVG. Suivez ces étapes pour générer des images SVG :

_Étapes : conversions PowerPoint vers SVG en C#_

- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Étapes : Convertir PowerPoint en SVG avec C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Étapes : Convertir PPT en SVG avec C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Étapes : Convertir PPTX en SVG avec C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Étapes : Convertir ODP en SVG avec C#</strong></a>

**Étapes du code :**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * extension _.ppt_ pour charger le fichier **PPT** dans la classe _Presentation_.
   * extension _.pptx_ pour charger le fichier **PPTX** dans la classe _Presentation_.
   * extension _.odp_ pour charger le fichier **ODP** dans la classe _Presentation_.
   * extension _.pps_ pour charger le fichier **PPS** dans la classe _Presentation_.
2. Parcourez toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG via FileStream.

{{% alert color="primary" %}} 

Vous pouvez essayer notre [application Web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT en SVG d'Aspose.Slides pour .NET.

{{% /alert %}} 

Ce code d'exemple en C# vous montre comment convertir PowerPoint en SVG à l'aide d'Aspose.Slides :
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

**Pourquoi le SVG résultant peut-il apparaître différemment selon les navigateurs ?**

La prise en charge de certaines fonctionnalités SVG est implémentée différemment par les moteurs des navigateurs. Les paramètres [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) permettent d'atténuer les incompatibilités.

**Est-il possible d'exporter non seulement les diapositives mais aussi des formes individuelles en SVG ?**

Oui. Toute [forme peut être enregistrée en tant que SVG séparé](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.

**Peut-on combiner plusieurs diapositives en un seul SVG (bande/document) ?**

Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives en un seul canevas SVG est une étape de post‑traitement réalisée au niveau de l'application.

## **Voir aussi** 

Cet article couvre également ces sujets. Les codes sont les mêmes que ci‑dessus.

_Format_ : **PowerPoint**
- [C# PowerPoint vers SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint vers SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint vers SVG programmatiquement](#csharp-powerpoint-to-svg)
- [C# PowerPoint vers SVG Bibliothèque](#csharp-powerpoint-to-svg)
- [C# Enregistrer PowerPoint au format SVG](#csharp-powerpoint-to-svg)
- [C# Générer SVG à partir de PowerPoint](#csharp-powerpoint-to-svg)
- [C# Créer SVG à partir de PowerPoint](#csharp-powerpoint-to-svg)
- [C# Convertisseur PowerPoint vers SVG](#csharp-powerpoint-to-svg)

_Format_ : **PPT**
- [C# PPT vers SVG Code](#csharp-ppt-to-svg)
- [C# PPT vers SVG API](#csharp-ppt-to-svg)
- [C# PPT vers SVG programmatiquement](#csharp-ppt-to-svg)
- [C# PPT vers SVG Bibliothèque](#csharp-ppt-to-svg)
- [C# Enregistrer PPT au format SVG](#csharp-ppt-to-svg)
- [C# Générer SVG à partir de PPT](#csharp-ppt-to-svg)
- [C# Créer SVG à partir de PPT](#csharp-ppt-to-svg)
- [C# Convertisseur PPT vers SVG](#csharp-ppt-to-svg)

_Format_ : **PPTX**
- [C# PPTX vers SVG Code](#csharp-pptx-to-svg)
- [C# PPTX vers SVG API](#csharp-pptx-to-svg)
- [C# PPTX vers SVG programmatiquement](#csharp-pptx-to-svg)
- [C# PPTX vers SVG Bibliothèque](#csharp-pptx-to-svg)
- [C# Enregistrer PPTX au format SVG](#csharp-pptx-to-svg)
- [C# Générer SVG à partir de PPTX](#csharp-pptx-to-svg)
- [C# Créer SVG à partir de PPTX](#csharp-pptx-to-svg)
- [C# Convertisseur PPTX vers SVG](#csharp-pptx-to-svg)

_Format_ : **ODP**
- [C# ODP vers SVG Code](#csharp-odp-to-svg)
- [C# ODP vers SVG API](#csharp-odp-to-svg)
- [C# ODP vers SVG programmatiquement](#csharp-odp-to-svg)
- [C# ODP vers SVG Bibliothèque](#csharp-odp-to-svg)
- [C# Enregistrer ODP au format SVG](#csharp-odp-to-svg)
- [C# Générer SVG à partir d'ODP](#csharp-odp-to-svg)
- [C# Créer SVG à partir d'ODP](#csharp-odp-to-svg)
- [C# Convertisseur ODP vers SVG](#csharp-odp-to-svg)