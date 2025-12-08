---
title: Rendu des diapositives de présentation en images SVG en Python
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
description: "Apprenez à rendre les diapositives PowerPoint et OpenDocument en images SVG en utilisant Aspose.Slides pour Python via .NET. Des visuels de haute qualité avec des exemples de code simples."
---

## **Convertir les diapositives en SVG**

SVG — un acronyme pour Scalable Vector Graphics — est un type ou format graphique standard utilisé pour restituer des images bidimensionnelles. SVG stocke les images sous forme de vecteurs dans du XML avec des détails qui définissent leur comportement ou leur apparence.  

SVG est l'un des rares formats d'images qui répond à des exigences très élevées dans ces domaines : évolutivité, interactivité, performances, accessibilité, programmabilité, etc. Pour ces raisons, il est couramment utilisé dans le développement web.  

Vous pouvez souhaiter utiliser des fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n'importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.  
- **utiliser les graphiques et diagrammes de vos diapositives sur *différents supports ou plateformes*.** La plupart des lecteurs peuvent interpréter les fichiers SVG.  
- **utiliser les *tailles les plus petites possibles d'images***. Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d'autres formats, en particulier les formats basés sur le bitmap (JPEG ou PNG).  

Aspose.Slides for Python via .NET vous permet d'exporter les diapositives de vos présentations sous forme d'images SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.  
2. Parcourez toutes les diapositives de la présentation.  
3. Écrivez chaque diapositive dans son propre fichier SVG via FileStream.  

{{% alert color="primary" %}} 
Vous pouvez essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT en SVG d'Aspose.Slides for Python via .NET. 
{{% /alert %}} 

Ce code d'exemple en Python montre comment convertir un PPT en SVG en utilisant Aspose.Slides :  
```py
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation 
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```


## **FAQ**

**Pourquoi le SVG résultant peut-il apparaître différemment selon les navigateurs ?**  
La prise en charge de certaines fonctionnalités SVG est implémentée différemment selon les moteurs de navigateur. Les paramètres [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) permettent d'atténuer les incompatibilités.  

**Est-il possible d'exporter non seulement les diapositives mais aussi des formes individuelles au format SVG ?**  
Oui. Toute [forme peut être enregistrée comme un SVG séparé](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.  

**Peut-on combiner plusieurs diapositives en un seul SVG (bande/document) ?**  
Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives en un seul canevas SVG est une étape de post‑traitement effectuée au niveau de l'application.