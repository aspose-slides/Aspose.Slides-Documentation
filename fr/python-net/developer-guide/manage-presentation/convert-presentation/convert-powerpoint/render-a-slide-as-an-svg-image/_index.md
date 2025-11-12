---
title: Rendre les diapositives de présentation en images SVG avec Python
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/python-net/render-a-slide-as-an-svg-image/
keywords:
- diapositive en SVG
- présentation en SVG
- PowerPoint en SVG
- OpenDocument en SVG
- PPT en SVG
- PPTX en SVG
- ODP en SVG
- rendre diapositive
- convertir diapositive
- exporter diapositive
- image vectorielle
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à rendre les diapositives PowerPoint et OpenDocument en images SVG à l'aide d'Aspose.Slides pour Python via .NET. Des visuels de haute qualité avec des exemples de code simples."
---

## **Convertir les diapositives en SVG**

SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou apparence.

SVG est l’un des rares formats d’image qui répond à des exigences très élevées en matière de scalabilité, d’interactivité, de performance, d’accessibilité, de programmabilité, etc. Pour ces raisons, il est couramment utilisé dans le développement web.

Vous pourriez vouloir utiliser des fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *très grand format*.** Les images SVG peuvent être agrandies à n’importe quelle résolution ou taille. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.  
- **utiliser les graphiques et diagrammes de vos diapositives sur *différents supports ou plateformes*.** La plupart des lecteurs peuvent interpréter les fichiers SVG.  
- **utiliser les *tailles d'images les plus petites possibles*.** Les fichiers SVG sont généralement plus légers que leurs équivalents haute résolution dans d’autres formats, en particulier ceux basés sur des images bitmap (JPEG ou PNG).

Aspose.Slides for Python via .NET vous permet d’exporter les diapositives de vos présentations en images SVG. Suivez ces étapes pour générer des images SVG :

1. Créer une instance de la classe Presentation.  
2. Parcourir toutes les diapositives de la présentation.  
3. Écrire chaque diapositive dans son propre fichier SVG via FileStream.

{{% alert color="primary" %}} 
Vous souhaiterez peut‑être essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT en SVG d'Aspose.Slides pour Python via .NET. 
{{% /alert %}} 

Ce code d’exemple en Python montre comment convertir un PPT en SVG à l’aide d’Aspose.Slides :

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation 
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```

## **FAQ**

**Pourquoi le SVG résultant peut-il apparaître différemment selon les navigateurs ?**

La prise en charge de certaines fonctionnalités SVG est implémentée différemment par les moteurs de navigateurs. Les paramètres [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) aident à atténuer les incompatibilités.

**Est-il possible d'exporter non seulement les diapositives mais également les formes individuelles en SVG ?**

Oui. Toute [forme peut être enregistrée en tant que SVG séparé](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), ce qui est pratique pour les icônes, pictogrammes et la réutilisation des graphiques.

**Peut-on combiner plusieurs diapositives en un seul SVG (bande/document) ?**

Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives en un seul canevas SVG est une étape de post‑traitement effectuée au niveau de l'application.