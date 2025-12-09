---
title: Rendre les diapositives de présentation en images SVG dans .NET
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint vers SVG
- présentation vers SVG
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
description: "Apprenez comment rendre les diapositives PowerPoint en images SVG à l'aide d'Aspose.Slides pour .NET. Des visuels de haute qualité avec des exemples de code C# simples."
---

## **Vue d'ensemble**

Cet article explique comment **convertir une présentation PowerPoint au format SVG à l'aide de C#**. Il couvre les sujets suivants.

_Format_: **PowerPoint**
- [C# PowerPoint vers SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint vers SVG](#csharp-powerpoint-to-svg)
- [C# Comment convertir un fichier PowerPoint en SVG](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT vers SVG](#csharp-ppt-to-svg)
- [C# PPT vers SVG](#csharp-ppt-to-svg)
- [C# Comment convertir un fichier PPT en SVG](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX vers SVG](#csharp-pptx-to-svg)
- [C# PPTX vers SVG](#csharp-pptx-to-svg)
- [C# Comment convertir un fichier PPTX en SVG](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP vers SVG](#csharp-odp-to-svg)
- [C# ODP vers SVG](#csharp-odp-to-svg)
- [C# Comment convertir un fichier ODP en SVG](#csharp-odp-to-svg)

_Format_: **Slide**
- [C# Convertir une diapositive PowerPoint en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir une diapositive PPT en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir une diapositive PPTX en SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir une diapositive ODP en SVG](#render-a-slide-as-an-svg-image)

Autres sujets couverts par cet article.
- [Voir aussi](#see-also)

## **Format SVG**
SVG — acronyme de Scalable Vector Graphics — est un type ou un format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs dans du XML contenant des détails qui définissent leur comportement ou leur apparence.

SVG est l'un des rares formats d'images qui répond à des exigences très élevées en matière de : évolutivité, interactivité, performances, accessibilité, programmabilité, etc. Pour ces raisons, il est couramment utilisé dans le développement web.

Vous pouvez souhaiter utiliser des fichiers SVG lorsque vous avez besoin de
- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n'importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans perdre en qualité.
- **utiliser les graphiques et diagrammes de vos diapositives sur *différents supports ou plateformes*.** La plupart des lecteurs peuvent interpréter les fichiers SVG.
- **utiliser les *tailles d'images les plus petites possibles*.** Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d'autres formats, en particulier les formats basés sur des images matricielles (JPEG ou PNG).

## **Rendre une diapositive en tant qu'image SVG**

Aspose.Slides pour .NET vous permet d'exporter les diapositives de vos présentations en images SVG. Suivez ces étapes pour générer des images SVG :

*_Étapes : conversions PowerPoint vers SVG en C#_*

Le code d'exemple suivant explique ces conversions à l'aide de .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Étapes : convertir PowerPoint en SVG en C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Étapes : convertir PPT en SVG en C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Étapes : convertir PPTX en SVG en C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Étapes : convertir ODP en SVG en C#</strong></a>

*_Étapes du code :_*

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * Extension _.ppt_ pour charger un fichier **PPT** dans la classe _Presentation_.
   * Extension _.pptx_ pour charger un fichier **PPTX** dans la classe _Presentation_.
   * Extension _.odp_ pour charger un fichier **ODP** dans la classe _Presentation_.
   * Extension _.pps_ pour charger un fichier **PPS** dans la classe _Presentation_.
2. Parcourez toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG via FileStream.

{{% alert color="primary" %}} 

Vous pouvez essayer notre [application Web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT vers SVG d'Aspose.Slides pour .NET.

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

**Pourquoi le SVG généré peut-il apparaître différemment selon les navigateurs ?**

La prise en charge de certaines fonctionnalités SVG est implémentée différemment selon les moteurs de navigation. Les paramètres [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) aident à lisser les incompatibilités.

**Est-il possible d'exporter non seulement les diapositives mais aussi des formes individuelles en SVG ?**

Oui. Toute [forme peut être enregistrée en tant que SVG distinct](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.

**Peut-on combiner plusieurs diapositives en un seul SVG (bande/document) ?**

Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives en un seul canevas SVG est une étape de post‑traitement effectuée au niveau de l'application.

## **Voir aussi** 

Cet article couvre également ces sujets. Les codes sont les mêmes que ci‑dessus.

_Format_: **PowerPoint**
- [C# Code PowerPoint vers SVG](#csharp-powerpoint-to-svg)
- [C# API PowerPoint vers SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint vers SVG programmatique](#csharp-powerpoint-to-svg)
- [C# Bibliothèque PowerPoint vers SVG](#csharp-powerpoint-to-svg)
- [C# Enregistrer PowerPoint en SVG](#csharp-powerpoint-to-svg)
- [C# Générer SVG à partir de PowerPoint](#csharp-powerpoint-to-svg)
- [C# Créer SVG à partir de PowerPoint](#csharp-powerpoint-to-svg)
- [C# Convertisseur PowerPoint vers SVG](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# Code PPT vers SVG](#csharp-ppt-to-svg)
- [C# API PPT vers SVG](#csharp-ppt-to-svg)
- [C# PPT vers SVG programmatique](#csharp-ppt-to-svg)
- [C# Bibliothèque PPT vers SVG](#csharp-ppt-to-svg)
- [C# Enregistrer PPT en SVG](#csharp-ppt-to-svg)
- [C# Générer SVG à partir de PPT](#csharp-ppt-to-svg)
- [C# Créer SVG à partir de PPT](#csharp-ppt-to-svg)
- [C# Convertisseur PPT vers SVG](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# Code PPTX vers SVG](#csharp-pptx-to-svg)
- [C# API PPTX vers SVG](#csharp-pptx-to-svg)
- [C# PPTX vers SVG programmatique](#csharp-pptx-to-svg)
- [C# Bibliothèque PPTX vers SVG](#csharp-pptx-to-svg)
- [C# Enregistrer PPTX en SVG](#csharp-pptx-to-svg)
- [C# Générer SVG à partir de PPTX](#csharp-pptx-to-svg)
- [C# Créer SVG à partir de PPTX](#csharp-pptx-to-svg)
- [C# Convertisseur PPTX vers SVG](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# Code ODP vers SVG](#csharp-odp-to-svg)
- [C# API ODP vers SVG](#csharp-odp-to-svg)
- [C# ODP vers SVG programmatique](#csharp-odp-to-svg)
- [C# Bibliothèque ODP vers SVG](#csharp-odp-to-svg)
- [C# Enregistrer ODP en SVG](#csharp-odp-to-svg)
- [C# Générer SVG à partir de ODP](#csharp-odp-to-svg)
- [C# Créer SVG à partir de ODP](#csharp-odp-to-svg)
- [C# Convertisseur ODP vers SVG](#csharp-odp-to-svg)