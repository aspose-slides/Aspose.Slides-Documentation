---
title: Légende du graphique
type: docs
url: /fr/nodejs-java/chart-legend/
---

## **Positionnement de la légende**

Pour définir les propriétés de la légende, suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenez la référence de la diapositive.
- Ajoutez un graphique sur la diapositive.
- Définissez les propriétés de la légende.
- Enregistrez la présentation au format PPTX.

Dans l'exemple ci-dessous, nous avons défini la position et la taille de la légende du graphique.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la référence de la diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter un graphique à colonnes groupées sur la diapositive
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Définir les propriétés de la légende
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Enregistrer la présentation sur le disque
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la taille de police de la légende**

Aspose.Slides pour Node.js via Java permet aux développeurs de définir la taille de police de la légende. Veuillez suivre les étapes ci-dessous :

- Instanciez la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Créez le graphique par défaut.
- Définissez la taille de la police.
- Définissez la valeur minimale de l'axe.
- Définissez la valeur maximale de l'axe.
- Enregistrez la présentation sur le disque.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la taille de police de la légende individuelle**

Aspose.Slides pour Node.js via Java permet aux développeurs de définir la taille de police des entrées individuelles de la légende. Veuillez suivre les étapes ci-dessous :

- Instanciez la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Créez le graphique par défaut.
- Accédez à l'entrée de légende.
- Définissez la taille de la police.
- Définissez la valeur minimale de l'axe.
- Définissez la valeur maximale de l'axe.
- Enregistrez la présentation sur le disque.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je activer la légende afin que le graphique réserve automatiquement de l'espace pour elle au lieu de la superposer ?**  
Oui. Utilisez le mode non superposé ([setOverlay(false)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/)) ; dans ce cas, la zone du tracé se rétrécira pour accueillir la légende.

**Puis-je créer des étiquettes de légende multi-lignes ?**  
Oui. Les longues étiquettes se renvoient automatiquement lorsqu'il n'y a pas assez d'espace ; les sauts de ligne forcés sont pris en charge via les caractères de nouvelle ligne dans le nom de la série.

**Comment faire en sorte que la légende suive le schéma de couleurs du thème de la présentation ?**  
N'appliquez pas de couleurs, remplissages ou polices explicites à la légende ou à son texte. Elle héritera alors du thème et se mettra à jour correctement lorsque le design changera.