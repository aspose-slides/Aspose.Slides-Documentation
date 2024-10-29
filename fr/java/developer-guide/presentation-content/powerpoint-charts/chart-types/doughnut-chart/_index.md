---
title: Graphique en anneau
type: docs
weight: 30
url: /fr/java/doughnut-chart/
---

## **Modifier l'espace central dans un graphique en anneau**
{{% alert color="primary" %}} 

Aspose.Slides pour Java prend maintenant en charge la spécification de la taille du trou dans un graphique en anneau. Dans ce sujet, nous allons voir avec un exemple comment spécifier la taille du trou dans un graphique en anneau.

{{% /alert %}} 

Pour spécifier la taille du trou dans un graphique en anneau, veuillez suivre les étapes ci-dessous :

1. Instancier l'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Ajouter un graphique en anneau à la diapositive.
1. Spécifier la taille du trou dans un graphique en anneau.
1. Écrire la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini la taille du trou dans un graphique en anneau.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Écrire la présentation sur le disque
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```