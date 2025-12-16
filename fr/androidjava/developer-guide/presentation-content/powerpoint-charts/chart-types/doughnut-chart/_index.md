---
title: Personnaliser les graphiques en anneau dans les présentations sur Android
linktitle: Graphique en anneau
type: docs
weight: 30
url: /fr/androidjava/doughnut-chart/
keywords:
- graphique en anneau
- espace central
- taille du trou
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des graphiques en anneau dans Aspose.Slides for Android via Java, prenant en charge les formats PowerPoint pour des présentations dynamiques."
---

## **Spécifier l'espace central dans un graphique en anneau**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java prend désormais en charge la spécification de la taille du trou dans un graphique en anneau. Dans ce sujet, nous verrons avec un exemple comment spécifier la taille du trou dans un graphique en anneau.

{{% /alert %}} 

Pour spécifier la taille du trou dans un graphique en anneau, veuillez suivre les étapes ci-dessous :

1. Instancier l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Ajouter un graphique en anneau sur la diapositive.
1. Spécifier la taille du trou dans un graphique en anneau.
1. Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini la taille du trou dans un graphique en anneau.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Enregistrer la présentation sur le disque
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis-je créer un anneau à plusieurs niveaux avec plusieurs cercles ?**

Oui. Ajoutez plusieurs séries à un même graphique en anneau — chaque série devient un cercle séparé. L'ordre des cercles est déterminé par l'ordre des séries dans la collection.

**Un anneau « explosé » (tranches séparées) est-il pris en charge ?**

Oui. Il existe un type de graphique [Exploded Doughnut](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) et une propriété d'explosion sur les points de données ; vous pouvez séparer des tranches individuelles.

**Comment obtenir une image d'un graphique en anneau (PNG/SVG) pour un rapport ?**

Un graphique est une forme ; vous pouvez le rendre en une [image raster](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) ou exporter le graphique en une [image SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).