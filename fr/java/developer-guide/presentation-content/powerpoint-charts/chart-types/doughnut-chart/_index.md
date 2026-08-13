---
title: Personnaliser les diagrammes en anneau dans les présentations avec Java
linktitle: Diagramme en anneau
type: docs
weight: 30
url: /fr/java/doughnut-chart/
keywords:
- diagramme en anneau
- écart central
- taille du trou
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des diagrammes en anneau dans Aspose.Slides pour Java, en prenant en charge les formats PowerPoint pour des présentations dynamiques."
---
## **Vue d'ensemble**

Cet article montre comment travailler avec un diagramme en anneau dans Aspose.Slides en ajoutant le diagramme à une diapositive, en réglant la taille du trou central et en enregistrant la présentation. Il se concentre sur la méthode `setDoughnutHoleSize` et démontre les étapes de base nécessaires pour personnaliser ce type de diagramme dans le code.

Il comprend également une courte FAQ couvrant les scénarios liés aux diagrammes en anneau, tels que l'utilisation de plusieurs séries pour créer plusieurs anneaux, le travail avec des diagrammes en anneau explosés, et l'exportation d'un diagramme sous forme d'image raster ou SVG.

## **Spécifier l'écart central dans un diagramme en anneau**
{{% alert color="info" %}} 
Aspose.Slides for Java prend désormais en charge la spécification de la taille du trou dans un diagramme en anneau. Dans ce sujet, nous verrons avec un exemple comment spécifier la taille du trou dans un diagramme en anneau.
{{% /alert %}} 

Afin de spécifier la taille du trou dans un diagramme en anneau, veuillez suivre les étapes ci‑dessous :

1. Instancier l'objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation).
1. Ajouter un diagramme en anneau sur la diapositive.
1. Spécifier la taille du trou dans un diagramme en anneau.
1. Enregistrer la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini la taille du trou dans un diagramme en anneau.

```java
import com.aspose.slides.*;

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

### Puis-je créer un diagramme en anneau à plusieurs niveaux avec plusieurs anneaux ?

Oui. Ajoutez plusieurs séries à un même diagramme en anneau — chaque série devient un anneau distinct. L'ordre des anneaux est déterminé par l'ordre des séries dans la collection.

### Un diagramme en anneau « explosé » (tranches séparées) est‑il pris en charge ?

Oui. Il existe un type de diagramme Exploded Doughnut [chart type](https://reference.aspose.com/slides/fr/java/com.aspose.slides/charttype/) et une propriété d'explosion sur les points de données ; vous pouvez séparer les tranches individuelles.

### Comment obtenir une image d'un diagramme en anneau (PNG/SVG) pour un rapport ?

Un diagramme est une forme ; vous pouvez le rendre sous forme d'[image raster](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getImage-int-float-float-) ou exporter le diagramme en tant qu'[image SVG](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).