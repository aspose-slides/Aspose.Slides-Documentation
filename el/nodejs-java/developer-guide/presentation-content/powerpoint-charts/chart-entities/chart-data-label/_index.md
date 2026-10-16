---
title: Διαχείριση ετικετών δεδομένων διαγράμματος σε παρουσιάσεις με JavaScript
linktitle: Ετικέτα δεδομένων
type: docs
url: /el/nodejs-java/chart-data-label/
keywords:
- διάγραμμα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- θέση ετικέτας
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας JavaScript και Aspose.Slides για Node.js μέσω Java για πιο ελκυστικές διαφάνειες."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων εμφανίζουν πληροφορίες σχετικά με τις σειρές διαγραμμάτων και τα μεμονωμένα σημεία δεδομένων, βοηθώντας τους αναγνώστες να εντοπίζουν τιμές και να κατανοούν το διάγραμμα. Αυτό το άρθρο εξηγεί πώς να μορφοποιείτε τιμές, να εμφανίζετε ποσοστά, να διαβάζετε το κείμενο ετικέτας, να ελέγχετε ετικέτες πέρα από το μέγιστο του άξονα, να προσαρμόζετε το διάστημα ετικετών του άξονα κατηγορίας και να τοποθετείτε ετικέτες σε κυκλικό διάγραμμα.

## **Ορισμός ακρίβειας δεδομένων στις ετικέτες δεδομένων διαγράμματος**

Χρησιμοποιήστε [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) για να μορφοποιήσετε τις τιμές των σειρών. Αυτό το παράδειγμα δημιουργεί ένα γράφημα γραμμής με προεπιλεγμένα δεδομένα, εμφανίζει τον πίνακα δεδομένων του και ενεργοποιεί τις ετικέτες τιμών για την πρώτη σειρά. Η μορφή `#,##0.00` εμφανίζει διαχωριστικό χιλιάδων και δύο δεκαδικά ψηφία χωρίς να αλλάζει τις υποκείμενες τιμές.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εμφάνιση ποσοστού ως ετικέτες**

Για ένα στοίβαγμα στήλης, υπολογίστε κάθε τιμή ως ποσοστό του συνόλου της κατηγορίας της και αντιστοιχίστε το κείμενο στο πλαίσιο κειμένου που επιστρέφει η [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). Αυτό το παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος και εμφανίζει ποσοστά με δύο δεκαδικά ψηφία σε γραμματοσειρά 8 σημείου. Κατηγορίες με συνολικό μηδέν παραλείπονται για να αποφευχθεί η διαίρεση δια του μηδενός. Επαναϋπολογίστε το προσαρμοσμένο κείμενο ετικέτας εάν τα δεδομένα του διαγράμματος αλλάξουν.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός συμβόλου ποσοστού με τις ετικέτες δεδομένων του διαγράμματος**

Όταν οι τιμές αποθηκεύονται ως κλάσματα, χρησιμοποιήστε το [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) για να εμφανίσετε ποσοστά. Περνάτε το `false` στο [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) για να εφαρμόσετε τη μορφή ετικέτας ανεξάρτητα από τα κελιά προέλευσης.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στοίβαξης στήλης 100% με κόκκινες και μπλε σειρές σε τέσσερις κατηγορίες. Κάθε ζεύγος τιμών αθροίζεται σε 1. Η μορφή ετικέτας `0.0%` εμφανίζει το 0.30 ως 30.0%, ενώ ο κάθετος άξονας χρησιμοποιεί δύο δεκαδικά ψηφία. Και οι δύο σειρές χρησιμοποιούν λευκό κείμενο ετικέτας 10 σημείου.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ανάγνωση πραγματικού κειμένου ετικετών δεδομένων**

Χρησιμοποιήστε το [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) για να ανακτήσετε το κείμενο που παράγεται από τις ρυθμίσεις μιας ετικέτας δεδομένων. Αυτό είναι χρήσιμο όταν εξάγετε ετικέτες για αναφορές, αναζητάτε περιεχόμενο παρουσίασης ή επαληθεύετε δημιουργημένα διαγράμματα. Στο παρακάτω παράδειγμα, η προεπιλεγμένη [μορφή ετικέτας δεδομένων](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) συνδυάζει το όνομα κάθε κατηγορίας, το όνομα σειράς και την τιμή. Ένα σημείο μορφοποιεί την τιμή του ως ποσοστό, και ένα άλλο χρησιμοποιεί προσαρμοσμένο κείμενο από τη [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Ο αριθμός που αποθηκεύεται σε ένα σημείο δεδομένων παραμένει `0.75`, ακόμα και όταν η ετικέτα του εμφανίζει `75%` μαζί με τα ονόματα κατηγορίας και σειράς. Το προσαρμοσμένο κείμενο αντικαθιστά το παραγόμενο κείμενο ετικέτας. Το [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) επιστρέφει το αποτέλεσμα της ετικέτας και στις δύο περιπτώσεις. Ελέγξτε το [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) ξεχωριστά, όπως φαίνεται παραπάνω, όταν θέλετε να εξάγετε μόνο τις ορατές ετικέτες.

## **Έλεγχος ετικετών δεδομένων πέρα από το μέγιστο του άξονα**

Όταν περιορίζετε το εύρος ενός άξονα χειροκίνητα, ορισμένα σημεία δεδομένων μπορεί να ξεπεράσουν το μέγιστό του. Χρησιμοποιήστε το [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) για να ελέγξετε εάν οι ετικέτες τους εμφανίζονται. Αυτή η ρύθμιση αλλάζει την ορατότητα της ετικέτας· δεν αλλάζει το εύρος του άξονα ή τις υποκείμενες τιμές δεδομένων.

Το παρακάτω παράδειγμα δημιουργεί ένα 2Δ ομαδοποιημένο διάγραμμα στήλης με τιμές 60 και 120. Περνά το `false` στο [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) και ορίζει το μέγιστο σε 100 με το [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) στον κάθετο άξονα. Η πρώτη διαφάνεια επιτρέπει ετικέτες πέρα από το μέγιστο· μια αντίγραφο αυτής της διαφάνειας τις απενεργοποιεί. Και οι δύο διαφάνειες αποθηκεύονται στο `DataLabelsOverMaximum.pptx`.

Ενεργοποιήστε τις ετικέτες τιμών με το [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). Η ρύθμιση σε επίπεδο διαγράμματος δεν ενεργοποιεί την εμφάνιση τιμών από μόνη της ή δεν παρακάμπτει την απενεργοποίηση εμφάνισης τιμής μιας επιμέρους ετικέτας. Αυτό το παράδειγμα ενεργοποιεί τις τιμές για ολόκληρη τη σειρά και χρησιμοποιεί το [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) για να τοποθετήσει τις ετικέτες στο εξωτερικό άκρο κάθε στήλης.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Οι παρακάτω εικόνες δείχνουν τις αποθηκευμένες διαφάνειες που αποδόθηκαν από το Microsoft PowerPoint. Με `true`, η ετικέτα **120** είναι ορατή στο άνω όριο· με `false`, είναι κρυφή. Η ετικέτα **60** παραμένει ορατή, το μέγιστο του άξονα παραμένει **100**, και το δεύτερο σημείο δεδομένων παραμένει **120** και στις δύο περιπτώσεις.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Αυτό το παράδειγμα χρησιμοποιεί ένα 2Δ διάγραμμα στήλης με άξονα τιμών. Διαγράμματα χωρίς άξονα τιμών, όπως τα κυκλικά και τα δακτυλιοειδή διαγράμματα, δεν διαθέτουν μέγιστο άξονα που να περιορίζεται με αυτόν τον τρόπο.
{{% /alert %}}

## **Ορισμός απόστασης ετικέτας από άξονα**

Χρησιμοποιήστε το [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) για να ελέγξετε την απόσταση μεταξύ των ετικετών του άξονα κατηγορίας και του άξονα. Η τιμή είναι ποσοστό του μέγιστου μεγέθους γραμματοσειράς των ετικετών του άξονα. Αυτό το παράδειγμα δημιουργεί ένα ομαδοποιημένο διάγραμμα στήλης και ορίζει την απόσταση ετικέτας του οριζόντιου άξονα σε 500. Αυτή η ρύθμιση επηρεάζει τις ετικέτες του άξονα κατηγορίας αντί για τις ετικέτες που συνδέονται με μεμονωμένα σημεία δεδομένων.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ρύθμιση θέσης ετικέτας**

Σε ένα κυκλικό διάγραμμα, ρυθμίστε τις θέσεις των ετικετών δεδομένων για να βελτιώσετε το κενό και να δημιουργήσετε χώρο για γραμμές οδηγούς.

Αυτό το παράδειγμα εμφανίζει την τιμή του πρώτου σημείου δεδομένων, τοποθετεί την ετικέτα του έξω από το τμήμα και ρυθμίζει τις οριζόντιες και κάθετες μετατοπίσεις του χρησιμοποιώντας τα [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) και [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/). Αυτές οι μετατοπίσεις είναι σχετικές με το πλάτος και το ύψος του διαγράμματος, αντίστοιχα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Μορφοποίηση γραμμών οδηγού**

Όταν οι ετικέτες ενός κυκλικού διαγράμματος βρίσκονται έξω από τα τμήματά τους, οι γραμμές οδηγού βοηθούν τους αναγνώστες να αντιστοιχίσουν κάθε τιμή στο σωστό τμήμα. Ένα αντίθετο χρώμα και μια ελαφρώς πιο παχιά γραμμή μπορούν να κάνουν αυτές τις συνδέσεις πιο εύκολες στην παρακολούθηση, ενώ η διαφάνεια και το διακεκομμένο στυλ διατηρούν τις γραμμές οπτικά μη ενοχλητικές.

Χρησιμοποιήστε το [getLeaderLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getleaderlinesformat/) για να μορφοποιήσετε τις γραμμές οδηγού στο επίπεδο συλλογής ετικετών δεδομένων της σειράς. Οι ρυθμίσεις στο `series.getLabels().getLeaderLinesFormat().getLine()` εφαρμόζονται στη συλλογή, όχι σε μεμονωμένη ετικέτα.

Αυτό το παράδειγμα δημιουργεί ένα κυκλικό διάγραμμα με προεπιλεγμένα δεδομένα, εμφανίζει τιμές έξω από τα τμήματα και ενεργοποιεί το [setShowLeaderLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowleaderlines/). Μετακινεί δύο ετικέτες πιο μακριά από τα τμήματά τους χρησιμοποιώντας μετατοπίσεις [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) και [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/), εκφρασμένες ως κλάσματα του πλάτους και του ύψους του διαγράμματος. Δεν απαιτείται παρουσίαση εισόδου.

Η [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) της γραμμής ορίζει ένα συμπαγές μπλε χρώμα με τιμή άλφα 191 από 255, δίνοντας περίπου 25% διαφάνεια. Το [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) ορίζει το πάχος στα 2 σημεία, και το [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) κάνει τη γραμμή διακεκομμένη.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    const series = chart.getChartData().getSeries().get_Item(0);

    const labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // Μετακινήστε δύο ετικέτες πιο μακριά από τα τμήματά τους.
    series.getLabels().get_Item(0).setX(java.newFloat(0.10));
    series.getLabels().get_Item(0).setY(java.newFloat(-0.05));
    series.getLabels().get_Item(1).setX(java.newFloat(-0.10));
    series.getLabels().get_Item(1).setY(java.newFloat(0.05));

    const line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 30, 90, 160, 191);
    line.getFillFormat().getSolidFillColor().setColor(lineColor);
    line.setWidth(2);
    line.setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    presentation.save("FormattedLeaderLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η ενεργοποίηση των γραμμών οδηγού δεν εγγυάται ότι θα εμφανιστεί γραμμή για κάθε ετικέτα. Η ορατότητα εξαρτάται από τη θέση της ετικέτας και τη συμπεριφορά διάταξης του διαγράμματος. Σε αυτό το παράδειγμα, οι δύο μετατοπισμένες ετικέτες έχουν ορατές γραμμές οδηγού· οι ετικέτες που παραμένουν κοντά στα τμήματά τους δεν τις χρειάζονται.

Η παρακάτω εικόνα δείχνει το αποθηκευμένο `FormattedLeaderLines.pptx` αποδομένο με το Aspose.Slides:

![Κυκλικό διάγραμμα με μπλε, ημιδιαφανείς, διακεκομμένες γραμμές οδηγού που συνδέουν δύο εξωτερικές ετικέτες με τα τμήματά τους](formatted-leader-lines.png)

## **Προσθήκη πολλαπλών σειρών ετικετών δεδομένων πάνω από ένα διάγραμμα στήλης**

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στήλης με δύο σειρές ετικετών δεδομένων πάνω από την περιοχή σχεδίασης. Η Σειρά A εμφανίζει τις ορατές στήλες, ενώ οι Σειρές B και C παρέχουν τις πρόσθετες ετικέτες. Οι στήλες τους είναι κρυμμένες αφαιρώντας τη γέμιση και το περίγραμμα. Η μέθοδος [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) ευθυγραμμίζει και τις τρεις σειρές στο ίδιο κέντρο κατηγορίας.

Οι ρυθμίσεις του [ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) διατηρούν χώρο για τις σειρές ετικετών. Μετά το [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) που υπολογίζει τις προεπιλεγμένες θέσεις, τα [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) και [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) διατηρούν την οριζόντια στοίχιση και εφαρμόζουν κάθετες μετατοπίσεις για τη διάταξη των ετικετών σε δύο σειρές. Οι αριθμοί παραμένουν ετικέτες δεδομένων συνδεδεμένες με τις τιμές των σειρών· μόνο οι επικεφαλίδες των σειρών είναι ξεχωριστά σχήματα κειμένου.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // Απόκρυψη των στηλών B και C, αλλά διατήρηση των ετικετών δεδομένων.
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // Στοίχιση και των τριών σειρών στα ίδια κέντρα κατηγορίας.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // Χρήση λιγότερων γραμμών πλέγματος για αυτό το συνοπτικό παράδειγμα.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Δέσμευση χώρου πάνω από την περιοχή σχεδίασης για δύο σειρές ετικετών δεδομένων.
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Διατήρηση της προεπιλεγμένης οριζόντιας θέσης. Το Y είναι μετατόπιση από
            // τη θέση ετικέτας προεπιλογής, εκφρασμένη ως κλάσμα του ύψους του διαγράμματος.
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // Μόνο η επικεφαλίδα της σειράς είναι ξεχωριστό σχήμα κειμένου.
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αποτρέψω τις ετικέτες δεδομένων από την επικάλυψη σε πυκνά διαγράμματα;**

Συνδυάστε την αυτόματη τοποθέτηση ετικετών, τις γραμμές οδηγού και τη μείωση του μεγέθους γραμματοσειράς· εφόσον χρειαστεί, κρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραίες τιμές ή βασικά σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για μηδενικές, αρνητικές ή κενές τιμές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν καθορισμένο κανόνα.

**Πώς μπορώ να εγγυηθώ συνεπές στυλ ετικέτας κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά την οικογένεια γραμματοσειράς και το μέγεθος και επαληθεύστε ότι η γραμματοσειρά είναι διαθέσιμη στο περιβάλλον απόδοσης για να αποφύγετε την εναλλακτική.