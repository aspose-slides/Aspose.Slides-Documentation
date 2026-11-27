---
title: Μορφοποίηση διαγραμμάτων παρουσίασης σε JavaScript
linktitle: Μορφοποίηση διαγράμματος
type: docs
weight: 60
url: /el/nodejs-java/chart-formatting/
keywords:
- μορφοποίηση διαγράμματος
- μορφοποίηση διαγράμματος
- οντότητα διαγράμματος
- ιδιότητες διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές διαγράμματος
- ιδιότητες γραμματοσειράς
- στρογγυλεμένο περίγραμμα
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε τη μορφοποίηση διαγραμμάτων στο Aspose.Slides για Node.js μέσω Java και ενισχύστε την παρουσίαση PowerPoint σας με προσαρμοσμένους άξονες, γραμματοσειρές, αριθμητικές μορφές και στρογγυλεμένα περιγράμματα διαγράμματος."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσαρμόζετε βασικά στοιχεία διαγράμματος όπως άξονες, γραμμές πλέγματος, τίτλους, υπομνήματα, την περιοχή σχεδίασης και τα γεμίσματα τοίχου για να βελτιώσετε την εμφάνιση και την αναγνωσιμότητα των δεδομένων του διαγράμματος.

Επίσης, παρουσιάζει πώς να ορίσετε ιδιότητες γραμματοσειράς για το κείμενο του διαγράμματος, να εφαρμόσετε προκαθορισμένες αριθμητικές μορφές στα δεδομένα του διαγράμματος και να ενεργοποιήσετε στρογγυλεμένες γωνίες για την περιοχή του διαγράμματος. Μαζί, αυτά τα παραδείγματα δείχνουν πώς να ελέγχετε τόσο το οπτικό στυλ όσο και την παρουσίαση των δεδομένων των διαγραμμάτων σε μια παρουσίαση.

Για ξεχωριστά γεμίσματα και περιγράμματα στις αυξανόμενες και φθίνουσες εσοχές, δείτε το [παράδειγμα διαγράμματος μετοχών](/slides/el/nodejs-java/create-chart/#create-stock-charts).

## **Μορφοποίηση Στοιχείων Διαγράμματος**

Χρησιμοποιήστε το [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) για να μορφοποιήσετε τίτλους διαγράμματος, άξονες, γραμμές πλέγματος, υπομνήματα και την περιοχή σχεδίασης. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με δείκτες και προεπιλεγμένα δεδομένα, στη συνέχεια εφαρμόζει ξεχωριστά στυλ κειμένου και γραμμής στους άξονες τιμής και κατηγορίας. Τα μεγέθη γραμματοσειράς και τα πλάτη γραμμής ορίζονται σε σημεία· οι ετικέτες κατηγορίας περιστρέφονται κατά 45 μοίρες.

Ο άξονας τιμής χρησιμοποιεί τη μέθοδο [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setNumberFormat) ανεξάρτητα από τα πηγαία κελιά. Η κλίμακά του εκτείνεται από -2 έως 15, με κύρια διαστήματα των 2 και δευτερεύοντα διαστήματα των 0,5. Το παράδειγμα επίσης συνδυάζει τη μορφοποίηση ποσοστών με τη μέθοδο [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setDisplayUnit) ορισμένη σε χιλιάδες, έτσι προσαρμόστε αυτές τις ρυθμίσεις στο νόημα και το μέγεθος των δεδομένων σας. Το υπόμνημα παραμένει έξω από την περιοχή σχεδίασης επειδή η μέθοδος [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#setOverlay) καλείται με `false`. Τα γεμίσματα του πίσω τοίχου και του δέσιματος ρυθμίζονται μέσω των [getBackWall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getBackWall) και [getFloor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getFloor), αλλά αυτές οι επιφάνειες είναι ορατές μόνο σε 3Δ διαγράμματα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    let chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    chartTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15);
    chart.getAxes().getVerticalAxis().setMinValue(-2);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);

    let valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkGreen));
    valueAxisText.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    let valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    let categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    categoryAxisText.setLatinFont(new aspose.slides.FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    let categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    let legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    legendText.setFontHeight(16);
    legendText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    legendText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    legendText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkRed));

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.LightCyan));

    presentation.save("FormattedChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορίστε Ιδιότητες Γραμματοσειράς για ένα Διάγραμμα**

Ορίστε το προεπιλεγμένο μέγεθος γραμματοσειράς για το κείμενο του διαγράμματος μέσω του [Chart.getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getTextFormat). Το παράδειγμα δημιουργεί ένα συγκεντρωτικό διάγραμμα στήλης με γραμματοσειρά 20 σημείων και ενεργοποιεί τις ετικέτες τιμής για την πρώτη σειρά μέσω της [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue). Τα στοιχεία κειμένου με τις δικές τους ρητές ρυθμίσεις γραμματοσειράς μπορούν να παρακάμψουν το προεπιλεγμένο του διαγράμματος.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Επαναχρησιμοποίηση Μορφοποίησης Πλαισίου Κειμένου για το Υπόμνημα του Διαγράμματος**

Για να ταιριάξετε ένα υπόμνημα με έναν τίτλο διαφάνειας, ορίστε τη γραμματοσειρά του τίτλου μέσω του [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) στην πρώτη παράγραφο. Καλέστε τη [copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyFrom) στη μορφή που επιστρέφεται από το [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#getTextFormat) του υπομνήματος. Αντιγράφει τις ρυθμίσεις του πλαισίου κειμένου, τη μορφοποίηση της πρώτης παραγράφου και τις προεπιλεγμένες ιδιότητες γραμματοσειράς εκείνης της παραγράφου. Η μορφοποίηση που εφαρμόζεται άμεσα σε μεμονωμένα τμήματα ή σε μεταγενέστερες παραγράφους παραμένει τοπική στην πηγή.

Το παράδειγμα χρησιμοποιεί έναν έντονο, 26‑σημείων τίτλο Calibri σε ναυτικό χρώμα ως πρότυπο. Μετά το στιλ του υπομνήματος, καλεί τη [copyTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyTo) για να εφαρμόσει την ίδια μορφοποίηση σε μια ξεχωριστή λεζάντα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const heading = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 20, 640, 40, false);
    const sourceTextFrame = heading.addTextFrame("Quarterly sales");
    const font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new aspose.slides.FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    font.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    font.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 32, 64, 96));

    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(java.newByte(aspose.slides.StyleType.Style3));
    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (let quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(java.newByte(aspose.slides.LegendPositionType.Bottom));
    const legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    const caption = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 460, 640, 40, false);
    const captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Στην αποθηκευμένη παρουσίαση, το υπόμνημα και η λεζάντα ταιριάζουν με τον τίτλο σε μέγεθος, πάχος και χρώμα. Το υπόμνημα εξακολουθεί να εμφανίζει τα ονόματα των σειρών, και η λεζάντα διατηρεί το δικό της κείμενο. Εάν ένα τμήμα στη λεζάντα έχει ήδη ρητό μέγεθος γραμματοσειράς, αυτό το μέγεθος έχει προτεραιότητα έναντι του αντιγραμμένου προεπιλεγμένου μεγέθους παραγράφου.

| Πριν την αντιγραφή | Μετά την αντιγραφή |
| --- | --- |
| ![Διάγραμμα τριμηνιαίων πωλήσεων με κανονικές μαύρες ετικέτες υπομνήματος και μαύρη λεζάντα](legend-formatting-before.png) | ![Το ίδιο διάγραμμα με μεγαλύτερες, έντονες ναυτικού χρώματος ετικέτες υπομνήματος και αντίστοιχη λεζάντα](legend-formatting.png) |

## **Ορίστε τη Αριθμητική Μορφή**

Χρησιμοποιήστε το [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setPresetNumberFormat) για να εφαρμόσετε μια ενσωματωμένη αριθμητική μορφή στα κελιά του φύλλου εργασίας του διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα συγκεντρωτικό διάγραμμα στήλης με προεπιλεγμένα, δεδομένα σε κελιά και εφαρμόζει δείκτη μορφής 10 (`0.00%`) σε κάθε κελί τιμής σειράς. Αυτή η αλλαγή επηρεάζει τον τρόπο εμφάνισης των τιμών στο φύλλο εργασίας χωρίς να αλλάζει τους υποκείμενους αριθμούς· για παράδειγμα, το 0,25 εμφανίζεται ως 25,00%. Οι μορφές άξονα και ετικετών δεδομένων μπορούν να ρυθμιστούν ξεχωριστά.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    let series = chart.getChartData().getSeries();

    for (let i = 0; i < series.size(); i++) {
        let chartSeries = series.get_Item(i);
        for (let j = 0; j < chartSeries.getDataPoints().size(); j++) {
            let dataPoint = chartSeries.getDataPoints().get_Item(j);
            dataPoint.getValue().getAsCell().setPresetNumberFormat(java.newByte(10)); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ο παρακάτω πίνακας παραθέτει ενσωματωμένους δείκτες αριθμητικών μορφών με αντιπροσωπευτικές μορφές Excel για την αγγλική (Ηνωμένες Πολιτείες) περιοχή. Οι ακριβείς συμβολοσειρές μορφής και η εμφάνισή τους μπορεί να διαφέρουν ανά εφαρμογή και περιοχή, ιδιαίτερα για νομίσματα και ημερομηνίες. Ορισμένες μορφές Excel διαφέρουν επίσης από τα προεπιλεγμένα στο πρότυπο OOXML, όπως περιγράφεται στις [σημειώσεις υλοποίησης αριθμητικής μορφής της Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Δείκτης | Μορφή |
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

## **Ορίστε Στρογγυλεμένα Όρια Περιοχής Διαγράμματος**

Καλέστε τη [Chart.setRoundedCorners](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setRoundedCorners) με `true` για να στρογγυλοποιήσετε τις γωνίες της περιοχής του διαγράμματος. Το παράδειγμα δημιουργεί ένα συγκεντρωτικό διάγραμμα στήλης και χρησιμοποιεί το [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) για να δώσει στο περίγραμμα του ένα συμπαγές γκρι χρώμα και ένα στυλ μονής γραμμής πριν αποθηκεύσει την παρουσίαση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chart.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Επεξεργασία Υφιστάμενων Σχόλιων Διαγράμματος**

Ένα διάγραμμα μπορεί να περιέχει προσαρμοσμένα σχήματα, όπως μια σημείωση κειμένου που εξηγεί την κατάσταση μιας αναφοράς. Πρόσβαση σε αυτά τα σχήματα μέσω του [Chart.getUserShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getUserShapes). Η συλλογή που επιστρέφεται από το [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) περιέχει τα σχήματα που ανήκουν στο διάγραμμα.

Ένα κανονικό πλαίσιο κειμένου που τοποθετείται πάνω σε ένα διάγραμμα ανήκει στη διαφάνεια, ακόμη και αν μοιάζει με μέρος του διαγράμματος. Η επανάληψη μέσω του [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) βρίσκει το διάγραμμα και τα κανονικά σχήματα της διαφάνειας, αλλά δεν απαριθμεί τα μεμονωμένα σχήματα μέσα στο διάγραμμα. Οι τίτλοι διαγράμματος και οι ετικέτες δεδομένων είναι ξεχωριστά στοιχεία διαγράμματος, όχι προσαρμοσμένες σημειώσεις σε αυτή τη συλλογή.

Κατεβάστε το [chart-annotations.pptx](chart-annotations.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη του διαφάνεια περιέχει ένα διάγραμμα με μια μη ομαδοποιημένη σημείωση που διαβάζει «Preliminary results», μια γραμμή που ανήκει στο διάγραμμα, και ένα κανονικό πλαίσιο κειμένου της διαφάνειας που διαβάζει «Slide overlay». Το παράδειγμα βρίσκει το πρώτο διάγραμμα σε αυτή τη διαφάνεια και αλλάζει τη σημείωση σε «Final results» όταν η αναφορά είναι έτοιμη για δημοσίευση. Ελέγχει για κενή συλλογή και επεξεργάζεται μόνο ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) με μη μηδενικό πλαίσιο κειμένου που επιστρέφεται από το [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) και το αναμενόμενο κείμενο.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("chart-annotations.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = null;
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
            chart = shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        console.log("No chart or chart-owned shapes found.");
    } else {
        let updated = false;
        for (let i = 0; i < chart.getUserShapes().getShapes().size(); i++) {
            let shape = chart.getUserShapes().getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let annotation = shape;
                if (annotation.getTextFrame() != null && annotation.getTextFrame().getText() === "Preliminary results") {
                    annotation.getTextFrame().setText("Final results");
                    updated = true;
                    break;
                }
            }
        }

        if (updated) {
            presentation.save("chart-annotations-updated.pptx", aspose.slides.SaveFormat.Pptx);
        } else {
            console.log("No matching text annotation found.");
        }
    }
} finally {
    presentation.dispose();
}
```

Η γραμμή και το πλαίσιο κειμένου της διαφάνειας παραμένουν αμετάβλητα. Οι παρακάτω εικόνες δείχνουν την είσοδο και το αποθηκευμένο, ανοιγμένο ξανά αποτέλεσμα:

| Πριν την επεξεργασία | Μετά την επεξεργασία |
| --- | --- |
| ![Σημείωση διαγράμματος που διαβάζει «Αρχικά αποτελέσματα»](chart-annotations-before.png) | ![Σημείωση διαγράμματος που διαβάζει «Τελικά αποτελέσματα»](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Το παράδειγμα ελέγχει μόνο τα σχήματα του διαγράμματος στο ανώτερο επίπεδο. Εάν μια σημείωση βρίσκεται μέσα σε ένα [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), ελέγξτε επίσης τη συλλογή [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) του εν λόγω γκρουπ. Επαναλάβετε αυτή τη διαδικασία επαναληπτικά για ενσωματωμένα groups, εφαρμόζοντας τους ίδιους ελέγχους κειμένου στα παιδικά τους σχήματα. Ένα group από μόνο του είναι ένας κοντέινερ· μη το αντιμετωπίζετε ως πλαίσιο κειμένου.
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ορίσω ημιδιαφανή γεμίσματα για στήλες/περιοχές ενώ το περίγραμμα παραμένει αδιαφανές;**

Ναι. Η διαφάνεια του γεμίσματος και το περίγραμμα διαμορφώνονται ξεχωριστά. Αυτό είναι χρήσιμο για τη βελτίωση της αναγνωσιμότητας του πλέγματος και των δεδομένων σε πυκνές απεικονίσεις.

**Πώς μπορώ να αντιμετωπίσω τις ετικέτες δεδομένων όταν επικαλύπτονται;**

Μειώστε το μέγεθος της γραμματοσειράς, απενεργοποιήστε τα μη απαραίτητα στοιχεία ετικετών (π.χ. τις κατηγορίες), ρυθμίστε τη θέση της ετικέτας, εμφανίστε ετικέτες μόνο για επιλεγμένα σημεία αν χρειάζεται, ή αλλάξτε τη μορφή σε "τιμή + υπόμνημα".

**Μπορώ να εφαρμόσω διαβαθμισμένα ή μοτίβο γεμίσματα σε σειρές;**

Ναι. Οι σειρές υποστηρίζουν συμπαγή, διαβαθμισμένα και μοτίβο γεμίσματα. Στην πράξη, χρησιμοποιήστε διαβαθμίσεις με μέτρο και αποφύγετε συνδυασμούς που μειώνουν την αντίθεση με το πλέγμα και το κείμενο.