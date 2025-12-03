---
title: Personnaliser les graphiques en anneau dans les présentations avec Java
linktitle: Graphique en anneau
type: docs
weight: 30
url: /fr/java/doughnut-chart/
keywords:
- graphique en anneau
- écart central
- taille du trou
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des graphiques en anneau dans Aspose.Slides for Java, prenant en charge les formats PowerPoint pour des présentations dynamiques."
---

## **Modifier l’écart central du graphique en anneau**
{{% alert color="primary" %}} 

Aspose.Slides for Java prend désormais en charge la spécification de la taille du trou d’un graphique en anneau. Dans ce sujet, nous verrons avec un exemple comment spécifier la taille du trou d’un graphique en anneau.

{{% /alert %}} 

Pour spécifier la taille du trou d’un graphique en anneau, veuillez suivre les étapes ci‑dessous :

1. Instancier l’objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Ajouter un graphique en anneau sur la diapositive.
1. Spécifier la taille du trou du graphique en anneau.
1. Enregistrer la présentation sur le disque.

Dans l’exemple ci‑dessous, nous avons défini la taille du trou du graphique en anneau.
```java
// Créez une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Enregistrez la présentation sur le disque
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis‑je créer un graphique en anneau à niveaux multiples avec plusieurs anneaux ?**

Oui. Ajoutez plusieurs séries à un même graphique en anneau—chaque série devient un anneau séparé. L’ordre des anneaux est déterminé par l’ordre des séries dans la collection.

**Un graphique en anneau « explosé » (tranches séparées) est‑il pris en charge ?**

Oui. Il existe un type de graphique [Exploded Doughnut](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) et une propriété d’explosion sur les points de données ; vous pouvez séparer les tranches individuelles.

**Comment obtenir une image d’un graphique en anneau (PNG/SVG) pour un rapport ?**

Un graphique est une forme ; vous pouvez le rendre sous forme d’une [image raster](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) ou exporter le graphique vers une [image SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).