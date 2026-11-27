---
title: Μορφοποίηση Διαγραμμάτων Παρουσίασης σε Java
linktitle: Μορφοποίηση Διαγράμματος
type: docs
weight: 60
url: /el/java/chart-formatting/
keywords:
- μορφοποίηση γραφήματος
- μορφοποίηση διαγράμματος
- στοιχείο διαγράμματος
- ιδιότητες διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές διαγράμματος
- ιδιότητες γραμματοσειράς
- στρογγυλεμένα περιγράμματα
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε τη μορφοποίηση διαγραμμάτων στο Aspose.Slides για Java και βελτιώστε την παρουσίαση PowerPoint σας με προσαρμοσμένους άξονες, γραμματοσειρές, αριθμητικές μορφές και στρογγυλεμένα περιγράμματα διαγράμματος."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσαρμόσετε βασικά στοιχεία του διαγράμματος όπως άξονες, γραμμές πλέγματος, τίτλους, υπομνήματα, την περιοχή σχεδίασης και τις γεμίσες τοίχου για να βελτιώσετε την εμφάνιση και την αναγνωσιμότητα των δεδομένων του διαγράμματος.

Επίσης, παρουσιάζει πώς να ορίσετε ιδιότητες γραμματοσειράς για το κείμενο του διαγράμματος, να εφαρμόσετε προκαθορισμένες αριθμητικές μορφές στα δεδομένα του διαγράμματος και να ενεργοποιήσετε στρογγυλεμένες γωνίες για την περιοχή του διαγράμματος. Μαζί, αυτά τα παραδείγματα δείχνουν πώς να ελέγχετε τόσο το οπτικό στυλ όσο και την παρουσίαση των δεδομένων σε ένα διάγραμμα.

Για ξεχωριστές γεμιστές και περιγράμματα στα ανοδικά και καθοδικά διαστήματα, δείτε το [παράδειγμα διαγράμματος μετοχών](/slides/el/java/create-chart/#create-stock-charts).

## **Διαμόρφωση Στοιχείων Διαγράμματος**

Χρησιμοποιήστε [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) για να μορφοποιήσετε τίτλους διαγράμματος, άξονες, γραμμές πλέγματος, υπομνήματα και την περιοχή σχεδίασης. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με σημεία σήμανσης και προεπιλεγμένα δεδομένα, στη συνέχεια εφαρμόζει ξεχωριστά στυλ κειμένου και γραμμής στους άξονες τιμής και κατηγορίας. Τα μεγέθη γραμματοσειράς και τα πλάτη γραμμών καθορίζονται σε μονάδες σημείου· οι ετικέτες κατηγορίας περιστρέφονται κατά 45 μοίρες.

Ο άξονας τιμής χρησιμοποιεί [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) ανεξάρτητα από τα κελιά προέλευσης. Η κλίμακά του εκτείνεται από -2 έως 15, με κύρια διαστήματα των 2 και δευτερεύοντα διαστήματα των 0,5. Το παράδειγμα επίσης συνδυάζει μορφοποίηση ποσοστού με το [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) ορισμένο σε χιλιάδες, έτσι προσαρμόστε αυτές τις ρυθμίσεις στο νόημα και το μέγεθος των δεδομένων σας. Το υπόμνημα μένει εκτός της περιοχής σχεδίασης επειδή το [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) καλείται με `false`. Οι γεμίσες του πίσω τοίχου και του δαπέδου ρυθμίζονται μέσω των [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) και [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--), αλλά αυτές οι επιφάνειες είναι ορατές μόνο σε 3D διαγράμματα.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
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
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Ιδιοτήτων Γραμματοσειράς για Διάγραμμα**

Ορίστε το προεπιλεγμένο μέγεθος γραμματοσειράς για το κείμενο του διαγράμματος μέσω του [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). Το παράδειγμα δημιουργεί ένα ομαδοποιημένο διάγραμμα στήλης με γραμματοσειρά 20 σημείων και ενεργοποιεί τις ετικέτες τιμών για την πρώτη σειρά μέσω του [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Τα στοιχεία κειμένου με τις δικές τους ρητές ρυθμίσεις γραμματοσειράς μπορούν να παρακάμψουν την προεπιλογή του διαγράμματος.

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

## **Επανάχρηση Μορφοποίησης Πλαισίου Κειμένου για Υπομνημα Διαγράμματος**

Για να ταιριάξετε το υπόμνημα με την επικεφαλίδα μιας διαφάνειας, ορίστε τη γραμματοσειρά της επικεφαλίδας μέσω του [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) στην πρώτη παράγραφο. Καλέστε το [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) στη μορφή που επιστρέφεται από το [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) του υπομνήματος. Αντιγράφει τις ρυθμίσεις του πλαισίου κειμένου, τη μορφοποίηση της πρώτης παραγράφου και τις προεπιλεγμένες ιδιότητες γραμματοσειράς αυτής. Η μορφοποίηση που εφαρμοστεί απευθείας σε μεμονωμένα τμήματα ή σε μεταγενέστερες παραγράφους παραμένει τοπική στην πηγή.

Το παράδειγμα χρησιμοποιεί μια έντονη, 26‑σημείων Calibri επικεφαλίδα σε ναυτικό χρώμα ως πρότυπο. Μετά το στυλιζάρισμα του υπομνήματος, καλεί το [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) για να εφαρμόσει την ίδια μορφοποίηση σε ξεχωριστή λεζάντα.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

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

Στην αποθηκευμένη παρουσίαση, το υπόμνημα και η λεζάντα ταιριάζουν με την επικεφαλίδα ως προς μέγεθος, βάρος και χρώμα. Το υπόμνημα εξακολουθεί να εμφανίζει τα ονόματα των σειρών, και η λεζάντα διατηρεί το δικό της κείμενο. Εάν ένα τμήμα στη λεζάντα έχει ήδη ρητό μέγεθος γραμματοσειράς, αυτό το μέγεθος υπερισχύει του αντιγραμμένου προεπιλεγμένου μεγέθους παραγράφου.

| Πριν από την αντιγραφή | Μετά την αντιγραφή |
| --- | --- |
| ![Διάγραμμα τριμηνιαίων πωλήσεων με κανονικές μαύρες ετικέτες υπομνήματος και μαύρη λεζάντα](legend-formatting-before.png) | ![Το ίδιο διάγραμμα με μεγαλύτερες, έντονες ναυτικό χρώματος ετικέτες υπομνήματος και αντίστοιχη λεζάντα](legend-formatting.png) |

## **Ορισμός Αριθμητικής Μορφής**

Χρησιμοποιήστε [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) για να εφαρμόσετε ενσωματωμένη μορφή αριθμού στα κελιά του φύλλου εργασίας του διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα ομαδοποιημένο διάγραμμα στήλης με προεπιλεγμένα δεδομένα που αποθηκεύονται σε κελιά και εφαρμόζει τον δείκτη μορφής 10 (`0.00%`) σε κάθε κελί τιμής σειράς. Αυτό αλλάζει τον τρόπο εμφάνισης των τιμών στο βιβλίο εργασίας χωρίς να αλλάζει τους υποκείμενους αριθμούς· για παράδειγμα, το 0,25 εμφανίζεται ως 25,00 %. Οι μορφές των αξόνων και των ετικετών δεδομένων μπορούν να ρυθμιστούν χωριστά.

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
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ο παρακάτω πίνακας παραθέτει ενσωματωμένους δείκτες μορφοποίησης αριθμών με αντιπροσωπευτικές μορφές Excel για το αγγλικό (Ηνωμένες Πολιτείες) τοπικό. Οι ακριβείς συμβολοσειρές μορφής και η εμφάνισή τους μπορεί να διαφέρουν ανάλογα με την εφαρμογή και το τοπικό, ιδιαίτερα για νομίσματα και ημερομηνίες. Ορισμένες μορφές Excel διαφέρουν επίσης από τις προεπιλογές του προτύπου OOXML, όπως περιγράφεται στις [σημειώσεις υλοποίησης μορφών αριθμών της Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

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

## **Ορισμός Στρογγυλοποιημένων Άκρων Περιοχής Διαγράμματος**

Καλέστε το [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) με `true` ώστε να στρογγυλοποιηθούν οι γωνίες της περιοχής του διαγράμματος. Το παράδειγμα δημιουργεί ένα ομαδοποιημένο διάγραμμα στήλης και χρησιμοποιεί το [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) για να δώσει στο περίγραμμά του συμπαγές γκρι χρώμα και ένα στυλ μονής γραμμής πριν αποθηκεύσει την παρουσίαση.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Επεξεργασία Υπάρχουσας Υπομνημάτων Διαγράμματος**

Ένα διάγραμμα μπορεί να περιέχει προσαρμοσμένα σχήματα, όπως ένα κείμενο υπομνήματος που εξηγεί την κατάσταση μιας αναφοράς. Πρόσβαση σε αυτά τα σχήματα γίνεται μέσω του [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--), επίσης καταχωρημένου κάτω από το [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) στην Αναφορά API του Diagram. Η συλλογή που επιστρέφεται από το [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) περιλαμβάνει τα σχήματα που ανήκουν στο διάγραμμα.

Ένα κοινό πλαίσιο κειμένου τοποθετημένο πάνω σε ένα διάγραμμα ανήκει στη διαφάνεια, ακόμη κι αν μοιάζει μέρος του διαγράμματος. Η επανάληψη μέσω του [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) εντοπίζει το διάγραμμα και τα κοινά σχήματα της διαφάνειας, αλλά δεν απαριθμεί τα μεμονωμένα σχήματα εντός του διαγράμματος. Οι τίτλοι διαγράμματος και οι ετικέτες δεδομένων είναι ξεχωριστά στοιχεία του διαγράμματος, όχι προσαρμοσμένα υπομνήματα σε αυτή τη συλλογή.

Κάντε λήψη του [chart-annotations.pptx](chart-annotations.pptx) και τοποθετήστε το στον τρέχοντα φάκελο της εφαρμογής. Η πρώτη διαφάνειά του περιέχει ένα διάγραμμα με ένα μη ομαδοποιημένο υπόμνημα που γράφει «Preliminary results», μια γραμμή ανήκοντα στο διάγραμμα και ένα κοινό πλαίσιο κειμένου διαφάνειας που γράφει «Slide overlay». Το παράδειγμα εντοπίζει το πρώτο διάγραμμα σε αυτή τη διαφάνεια και αλλάζει το υπόμνημα σε «Final results» όταν η αναφορά είναι έτοιμη για δημοσίευση. Ελέγχει για κενή συλλογή και επεξεργάζεται μόνο ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) με μη‑μηδενικό πλαίσιο κειμένου που επιστρέφεται από το [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) και το αναμενόμενο κείμενο.

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

Η γραμμή και το πλαίσιο κειμένου της διαφάνειας παραμένουν αμετάβλητα. Οι παρακάτω εικόνες δείχνουν την είσοδο και το αποθηκευμένο, ξανά ανοιγμένο αποτέλεσμα:

| Πριν από την επεξεργασία | Μετά την επεξεργασία |
| --- | --- |
| ![Υπόμνημα διαγράμματος που διαβάζει Προκαταρκτικά αποτελέσματα](chart-annotations-before.png) | ![Υπόμνημα διαγράμματος που διαβάζει Τελικά αποτελέσματα](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Το παράδειγμα εξετάζει μόνο τα σχήματα κορυφαίου επιπέδου που ανήκουν στο διάγραμμα. Εάν ένα υπόμνημα βρίσκεται μέσα σε ένα [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), εξετάστε επίσης τη συλλογή [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) του συγκεκριμένου γκρουπ. Επαναλάβετε αυτή τη διαδικασία αναδρομικά για εμφωλευμένα γκρουπ, εφαρμόζοντας τους ίδιους ελέγχους κειμένου στα παιδικά τους σχήματα. Ένα γκρουπ από μόνο του είναι ένα δοχείο· μην το θεωρείτε ως πλαίσιο κειμένου.
{{% /alert %}}

## **FAQ**

**Μπορώ να ορίσω ημιδιαφανείς γεμισματώσεις για στήλες/περιοχές ενώ διατηρώ το περίγραμμα αδιαφανές;**

Ναι. Η διαφάνεια της γεμίσματος και το περίγραμμα ρυθμίζονται ξεχωριστά. Αυτό είναι χρήσιμο για την βελτίωση της αναγνωσιμότητας του πλέγματος και των δεδομένων σε πυκνά οπτικά στοιχεία.

**Πώς μπορώ να αντιμετωπίσω τις ετικέτες δεδομένων όταν επικαλύπτονται;**

Μειώστε το μέγεθος της γραμματοσειράς, απενεργοποιήστε μη‑απαραίτητα στοιχεία ετικετών (π.χ., τις κατηγορίες), προσαρμόστε τη θέση της ετικέτας, εμφανίστε ετικέτες μόνο για επιλεγμένα σημεία αν χρειάζεται, ή αλλάξτε τη μορφή σε «τιμή + υπόμνημα».

**Μπορώ να εφαρμόσω διαβάσεις ή μοτίβα γεμισμάτων στις σειρές;**

Ναι. Οι σειρές υποστηρίζουν στερεά, διαβάσεις και μοτίβα γεμισμάτων. Στην πράξη, χρησιμοποιήστε τις διαβάσεις με μέτρο και αποφύγετε συνδυασμούς που μειώνουν την αντίθεση με το πλέγμα και το κείμενο.