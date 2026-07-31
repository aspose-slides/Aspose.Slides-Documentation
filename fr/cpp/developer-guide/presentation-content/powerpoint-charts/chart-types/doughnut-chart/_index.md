---  
title: Personnaliser les graphiques en anneau dans les présentations avec C++  
linktitle: Graphique en anneau  
type: docs  
weight: 30  
url: /fr/cpp/doughnut-chart/  
keywords:  
- graphique en anneau  
- espace central  
- taille du trou  
- PowerPoint  
- présentation  
- C++  
- Aspose.Slides  
description: "Découvrez comment créer et personnaliser des graphiques en anneau dans Aspose.Slides pour C++, prenant en charge les formats PowerPoint pour des présentations dynamiques."  
---
## **Vue d'ensemble**

Cet article montre comment travailler avec un graphique en anneau dans Aspose.Slides en ajoutant le graphique à une diapositive, en définissant la taille du trou central et en enregistrant la présentation. Il se concentre sur la méthode `set_DoughnutHoleSize` et démontre les étapes de base nécessaires pour personnaliser ce type de graphique dans le code.

## **Spécifier l'écart central dans un graphique en anneau**
Pour spécifier la taille du trou dans un graphique en anneau, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
- Ajouter un graphique en anneau sur la diapositive.
- Spécifier la taille du trou dans un graphique en anneau.
- Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini la taille du trou dans un graphique en anneau.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**Puis-je créer un graphique en anneau à plusieurs niveaux avec plusieurs anneaux ?**

Oui. Ajoutez plusieurs séries à un seul graphique en anneau - chaque série devient un anneau distinct. L'ordre des anneaux est déterminé par l'ordre des séries dans la collection.

**L'anneau "explosé" (tranches séparées) est-il pris en charge ?**

Oui. Il existe un type de graphique [chart type](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/charttype/) et une propriété d'explosion sur les points de données - vous pouvez séparer les tranches individuellement.

**Comment obtenir une image d'un graphique en anneau (PNG/SVG) pour un rapport ?**

Un graphique est une forme ; vous pouvez le rendre sous forme d'[image raster](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/getimage/) ou exporter le graphique sous forme d'[image SVG](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/writeassvg/).