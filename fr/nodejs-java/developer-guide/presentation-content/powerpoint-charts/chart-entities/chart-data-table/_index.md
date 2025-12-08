---
title: Tableau de données du graphique
type: docs
url: /fr/nodejs-java/chart-data-table/
---

## **Définir les propriétés de police pour le tableau de données du graphique**

Aspose.Slides pour Node.js via Java prend en charge la modification de la couleur des catégories dans une couleur de série.

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

Un exemple d'échantillon est donné ci‑dessous.
```javascript
// Création d'une présentation vide
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je afficher de petites clés de légende à côté des valeurs dans le tableau de données du graphique?**

Oui. Le tableau de données prend en charge les [clés de légende](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datatable/setshowlegendkey/), et vous pouvez les activer ou les désactiver.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation vers PDF, HTML ou images?**

Oui. Aspose.Slides rend le graphique comme partie de la diapositive, de sorte que le [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/fr/nodejs-java/convert-powerpoint-to-png/) exporté inclut le graphique avec son tableau de données.

**Les tableaux de données sont-ils pris en charge pour les graphiques provenant d'un fichier modèle?**

Oui. Pour tout graphique chargé depuis une présentation ou un modèle existant, vous pouvez vérifier et modifier si le tableau de données est affiché en utilisant la propriété du graphique via la méthode [is shown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/).

**Comment puis-je rapidement identifier quels graphiques d'un fichier ont le tableau de données activé?**

Inspectez la propriété de chaque graphique qui indique si le tableau de données est affiché et parcourez les diapositives pour identifier les graphiques où il est activé.