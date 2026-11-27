---
title: Formater les graphiques de présentation sur Android
linktitle: Formatage des graphiques
type: docs
weight: 60
url: /fr/androidjava/chart-formatting/
keywords:
- format de graphique
- formatage de graphique
- entité de graphique
- propriétés du graphique
- paramètres du graphique
- options du graphique
- propriétés de police
- bord arrondi
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez le formatage des graphiques dans Aspose.Slides pour Android via Java et améliorez votre présentation PowerPoint avec des axes personnalisés, des polices, des formats numériques et des bordures de graphique arrondies."
---
## **Vue d'ensemble**

Cet article explique comment mettre en forme les graphiques dans les présentations PowerPoint en utilisant Aspose.Slides. Il montre comment personnaliser les éléments clés d’un graphique tels que les axes, les lignes de quadrillage, les titres, les légendes, la zone de tracé et les remplissages des murs afin d’améliorer l’apparence et la lisibilité des données du graphique.

Il montre également comment définir les propriétés de police pour le texte du graphique, appliquer des formats numériques prédéfinis aux données du graphique et activer les coins arrondis de la zone du graphique. Ensemble, ces exemples montrent comment contrôler à la fois le style visuel et la présentation des données des graphiques dans une présentation.

Pour des remplissages et des contours séparés sur les intervalles haussiers et baissiers, voir l'[exemple de graphique boursier](/slides/fr/androidjava/create-chart/#create-stock-charts).

## **Formater les entités du graphique**

Utilisez [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) pour mettre en forme les titres de graphique, les axes, les lignes de quadrillage, les légendes et la zone de tracé. Cet exemple crée un graphique en courbes avec des marqueurs et des données par défaut, puis applique des styles de texte et de ligne distincts à ses axes de valeurs et de catégories. Les tailles de police et les largeurs de ligne sont spécifiées en points ; les libellés de catégorie sont pivotés de 45 degrés.

L’axe des valeurs utilise [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) de manière indépendante des cellules source. Son intervalle va de -2 à 15, avec des intervalles majeurs de 2 et des intervalles mineurs de 0,5. L’exemple combine également le formatage en pourcentage avec [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) définissant des milliers, adaptez donc ces paramètres à la signification et à l’envergure de vos données. La légende reste à l’extérieur de la zone de tracé parce que [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) est appelé avec `false`. Les remplissages du mur arrière et du plancher sont configurés via [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) et [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--), mais ces surfaces ne sont visibles que dans les graphiques 3D.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir les propriétés de police pour un graphique**

Définissez la taille de police par défaut pour le texte du graphique via [Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--). L’exemple crée un graphique à colonnes groupées avec une police de 20 points et active les étiquettes de valeurs pour la première série via [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Les éléments texte avec leurs propres paramètres de police explicites peuvent remplacer le paramètre par défaut du graphique.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Réutiliser le formatage du cadre de texte pour la légende d’un graphique**

Pour faire correspondre une légende à un titre de diapositive, définissez la police du titre via [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) sur le premier paragraphe. Appelez [copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) sur le format renvoyé par le [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) de la légende. Cela copie les paramètres du cadre de texte, le formatage du premier paragraphe et les propriétés de police par défaut de ce paragraphe. Le formatage appliqué directement aux portions individuelles ou aux paragraphes ultérieurs reste local à la source.

L’exemple utilise un titre Calibri en gras, 26 points, de couleur marine comme modèle. Après avoir stylisé la légende, il appelle [copyTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) pour appliquer le même formatage à une légende distincte.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(Color.rgb(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dans la présentation enregistrée, la légende et la légende secondaire correspondent au titre en taille, épaisseur et couleur. La légende continue d’afficher les noms des séries, et la légende secondaire conserve son propre texte. Si une portion de la légende secondaire possède déjà une taille de police explicite, cette taille prévaut sur le paragraphe par défaut copié.

| Avant la copie | Après la copie |
| --- | --- |
| ![Graphique des ventes trimestrielles avec des libellés de légende noirs normaux et une légende secondaire noire](legend-formatting-before.png) | ![Le même graphique avec des libellés de légende plus grands, en gras, couleur marine et une légende secondaire assortie](legend-formatting.png) |

## **Définir le format numérique**

Utilisez [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) pour appliquer un format numérique intégré aux cellules du classeur du graphique. Cet exemple crée un graphique à colonnes groupées avec des données par défaut, stockées dans les cellules, et applique l’indice de format 10 (`0.00%`) à chaque cellule de valeur de série. Cela modifie la façon dont les valeurs sont affichées dans le classeur sans changer les nombres sous‑jacent ; par exemple, 0,25 s’affiche sous forme de 25,00 %. Les formats des axes et des étiquettes de données peuvent être configurés séparément.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0,00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le tableau suivant répertorie les indices de formats numériques intégrés avec des formats Excel représentatifs pour la locale English (United States). Les chaînes de format exactes et leur affichage peuvent varier selon l’application et la locale, notamment pour les devises et les dates. Certains formats Excel diffèrent également des valeurs par défaut de la norme OOXML, comme indiqué dans les [notes d’implémentation du format numérique de Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Définir les bords arrondis de la zone du graphique**

Appelez [IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) avec `true` pour arrondir les coins de la zone du graphique. L’exemple crée un graphique à colonnes groupées et utilise [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) pour donner à son contour une couleur grise unie et un style de ligne simple avant d’enregistrer la présentation.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modifier les annotations existantes du graphique**

Un graphique peut contenir des formes personnalisées, comme une annotation texte expliquant l’état d’un rapport. Accédez à ces formes via [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--), également répertoriées sous [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) dans la référence API du graphique. La collection renvoyée par [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) contient les formes appartenant au graphique.

Une zone de texte ordinaire placée au-dessus d’un graphique appartient à la diapositive, même si elle semble faire partie du graphique. Parcourir [Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) trouve le graphique et les formes ordinaires de la diapositive, mais n’énumère pas les formes individuelles à l’intérieur du graphique. Les titres de graphique et les étiquettes de données sont des éléments de graphique distincts, pas des annotations personnalisées dans cette collection.

Téléchargez [chart-annotations.pptx](chart-annotations.pptx) et placez‑le dans le répertoire de travail de l’application. Sa première diapositive contient un graphique avec une annotation non groupée affichant « Preliminary results », une ligne appartenant au graphique et une zone de texte ordinaire affichant « Slide overlay ». L’exemple trouve le premier graphique sur cette diapositive et modifie l’annotation en « Final results » lorsque le rapport est prêt à être publié. Il vérifie si la collection est vide et n’édite qu’une [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) dont le cadre texte non nul est renvoyé par [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) et le texte attendu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

La ligne et la zone de texte de la diapositive restent inchangées. Les images suivantes montrent l’entrée et le résultat enregistré, réouvert :

| Avant la modification | Après la modification |
| --- | --- |
| ![Annotation du graphique affichant « Résultats préliminaires »](chart-annotations-before.png) | ![Annotation du graphique affichant « Résultats finaux »](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
L’exemple examine uniquement les formes appartenant au graphique au niveau supérieur. Si une annotation se trouve à l’intérieur d’un [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), inspectez également la collection [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) de ce groupe. Répétez cela de façon récursive pour les groupes imbriqués, en appliquant les mêmes vérifications de texte à leurs formes enfants. Un groupe est lui‑même un conteneur ; ne le traitez pas comme une zone de texte.
{{% /alert %}}

## **FAQ**

**Puis-je définir des remplissages semi‑transparents pour les colonnes/zones tout en conservant le contour opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment gérer les étiquettes de données lorsqu’elles se chevauchent ?**

Réduisez la taille de la police, désactivez les composants d’étiquette non essentiels (par exemple, les catégories), ajustez la position de l’étiquette, affichez les étiquettes uniquement pour les points sélectionnés si nécessaire, ou changez le format en « valeur + légende ».

**Puis-je appliquer des remplissages en dégradé ou en motif aux séries ?**

Oui. Les séries prennent en charge les remplissages unis, en dégradé et en motif. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.