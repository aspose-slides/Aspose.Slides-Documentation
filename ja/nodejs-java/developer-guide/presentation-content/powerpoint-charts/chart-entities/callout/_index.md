---
title: コールアウト
type: docs
url: /ja/nodejs-java/callout/
---

## **コールアウトの使用**

新しいメソッド [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) と [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) が [DataLabelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat) クラスに追加されました。これらのメソッドは、指定したチャートのデータラベルをデータコールアウトとして表示するか、データラベルとして表示するかを決定します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    pres.save("DisplayCharts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ドーナツチャートのコールアウト設定**

Aspose.Slides for Node.js via Java は、ドーナツチャートのシリーズ データラベル コールアウト シェイプの設定をサポートしています。以下にサンプル例を示します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Doughnut, 10, 10, 500, 500, false);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    var seriesIndex = 0;
    while (seriesIndex < 15) {
        var series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize(20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    var categoryIndex = 0;
    while (categoryIndex < 15) {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        var i = 0;
        while (i < chart.getChartData().getSeries().size()) {
            var iCS = chart.getChartData().getSeries().get_Item(i);
            var dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
            if (i == (chart.getChartData().getSeries().size() - 1)) {
                var lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new aspose.slides.FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX(lbl.getX() + 0.5);
                lbl.setY(lbl.getY() + 0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**プレゼンテーションを PDF、HTML5、SVG、または画像に変換したときに、コールアウトは保持されますか？**

はい。コールアウトはチャートのレンダリングの一部であるため、[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)、[HTML5](/slides/ja/nodejs-java/export-to-html5/)、[SVG](/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/)、または[ラスタ画像](/slides/ja/nodejs-java/convert-powerpoint-to-png/) にエクスポートする際、スライドの書式設定とともに保持されます。

**カスタム フォントはコールアウトで機能し、エクスポート時に外観を保持できますか？**

はい。Aspose.Slides は、プレゼンテーションへの[フォント埋め込み](/slides/ja/nodejs-java/embedded-font/) をサポートしており、[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) などへのエクスポート時にフォント埋め込みを制御します。これにより、異なるシステム間でもコールアウトの外観が同じに保たれます。