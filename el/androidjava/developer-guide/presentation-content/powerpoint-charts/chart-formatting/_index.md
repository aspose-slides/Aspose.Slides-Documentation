---
title: Διαμόρφωση Διαγραμμάτων Παρουσίασης σε Android
linktitle: Διαμόρφωση Διαγράμματος
type: docs
weight: 60
url: /el/androidjava/chart-formatting/
keywords:
- διαμόρφωση διαγράμματος
- διαμόρφωση διαγράμματος
- οντότητα διαγράμματος
- ιδιότητες διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές διαγράμματος
- ιδιότητες γραμματοσειράς
- στρογγυλεμένο περίγραμμα
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε τη διαμόρφωση διαγραμμάτων στο Aspose.Slides για Android μέσω Java και βελτιώστε την παρουσίαση PowerPoint σας με επαγγελματικό, εντυπωσιακό στυλ."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσαρμόσετε βασικά στοιχεία του διαγράμματος όπως άξονες, γραμμές πλέγματος, τίτλους, υπομνήματα, την περιοχή σχεδίασης και τις γεμίσεις τοίχου για να βελτιώσετε την εμφάνιση και την αναγνωσιμότητα των δεδομένων του διαγράμματος.

Επίσης, παρουσιάζει πώς να ορίσετε τις ιδιότητες γραμματοσειράς για το κείμενο του διαγράμματος, να εφαρμόσετε προκαθορισμένες και προσαρμοσμένες αριθμητικές μορφές στα δεδομένα του διαγράμματος και να ενεργοποιήσετε στρογγυλεμένες γωνίες για την περιοχή του διαγράμματος. Μαζί, αυτά τα παραδείγματα δείχνουν πώς να ελέγξετε τόσο το οπτικό στυλ όσο και την παρουσίαση των δεδομένων ενός διαγράμματος σε μια παρουσίαση.

## **Διαμόρφωση Στοιχείων Γραφήματος**
Το Aspose.Slides for Android via Java επιτρέπει στους προγραμματιστές να προσθέτουν προσαρμοσμένα διαγράμματα στις διαφάνειές τους από το μηδέν. Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε διαφορετικά στοιχεία γραφήματος, συμπεριλαμβανομένου του άξονα κατηγορίας και του άξονα τιμών.

Το Aspose.Slides for Android via Java παρέχει ένα απλό API για τη διαχείριση διαφορετικών στοιχείων γραφήματος και τη μορφοποίησή τους χρησιμοποιώντας προσαρμοσμένες τιμές:

1. Δημιουργήστε μια παρουσία της κλάσης [**Παρουσίαση**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
1. Αποκτήστε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα και τον επιθυμητό τύπο (σε αυτό το παράδειγμα θα χρησιμοποιήσουμε ChartType.LineWithMarkers).
1. Πρόσβαση στον Άξονα Τιμών του γραφήματος και ορισμός των εξής ιδιοτήτων:
   1. Καθορισμός **Line format** για τις κύριες γραμμές πλέγματος του άξονα τιμών
   1. Καθορισμός **Line format** για τις δευτερεύουσες (minor) γραμμές πλέγματος του άξονα τιμών
   1. Καθορισμός **Number Format** για τον άξονα τιμών
   1. Καθορισμός **Min, Max, Major and Minor units** για τον άξονα τιμών
   1. Καθορισμός **Text Properties** για τα δεδομένα του άξονα τιμών
   1. Ορισμός **Title** για τον άξονα τιμών
   1. Καθορισμός **Line Format** για τον άξονα τιμών
1. Πρόσβαση στον Άξονα Κατηγορίας του γραφήματος και ορισμός των εξής ιδιοτήτων:
   1. Καθορισμός **Line format** για τις κύριες γραμμές πλέγματος του άξονα κατηγορίας
   1. Καθορισμός **Line format** για τις δευτερεύουσες (minor) γραμμές πλέγματος του άξονα κατηγορίας
   1. Καθορισμός **Text Properties** για τα δεδομένα του άξονα κατηγορίας
   1. Ορισμός **Title** για τον άξονα κατηγορίας
   1. Καθορισμός **Label Positioning** για τον άξονα κατηγορίας
   1. Καθορισμός **Rotation Angle** για τις ετικέτες του άξονα κατηγορίας
1. Πρόσβαση στην Υπόμνηση του γραφήματος και ορισμός των **Text Properties** για αυτήν
1. Ρύθμιση εμφάνισης των υπομνήσεων του γραφήματος ώστε να μην επικαλύπτονται το γράφημα
1. Πρόσβαση στον **Secondary Value Axis** του γραφήματος και ορισμός των εξής ιδιοτήτων:
   1. Ενεργοποίηση του δευτερεύοντος **Value Axis**
   1. Καθορισμός **Line Format** για τον δευτερεύοντα άξονα τιμών
   1. Καθορισμός **Number Format** για τον δευτερεύοντα άξονα τιμών
   1. Καθορισμός **Min, Max, Major and Minor units** για τον δευτερεύοντα άξονα τιμών
1. Τώρα σχεδιάστε τη πρώτη σειρά γραφήματος στον Δευτερεύοντα Άξονα Τιμών
1. Ορίστε το χρώμα γεμίσματος του πίσω τοίχου του γραφήματος
1. Ορίστε το χρώμα γεμίσματος της περιοχής σχεδίασης του γραφήματος
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθήκη του δείγματος γραφήματος
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Ορισμός τίτλου γραφήματος
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Ορισμός μορφής κύριων γραμμών πλέγματος για τον άξονα τιμών
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Ορισμός μορφής δευτερευουσών γραμμών πλέγματος για τον άξονα τιμών
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Ορισμός μορφής αριθμού του άξονα τιμών
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Ορισμός μέγιστων και ελάχιστων τιμών του γραφήματος
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Ορισμός ιδιοτήτων κειμένου του άξονα τιμών
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Ορισμός τίτλου άξονα τιμών
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Ορισμός μορφής κύριων γραμμών πλέγματος για τον άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Ορισμός μορφής δευτερευουσών γραμμών πλέγματος για τον άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Ορισμός ιδιοτήτων κειμένου του άξονα κατηγορίας
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Ορισμός τίτλου κατηγορίας
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Ορισμός θέσης ετικετών άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Ορισμός γωνίας περιστροφής ετικετών άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Ορισμός ιδιοτήτων κειμένου υπομνήματος
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Ορισμός εμφάνισης υπομνήματος γραφήματος χωρίς επικάλυψη του γραφήματος

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Ορισμός δευτερεύοντος άξονα τιμών
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Ορισμός μορφής αριθμού δευτερεύοντος άξονα τιμών
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Ορισμός μέγιστων και ελάχιστων τιμών του γραφήματος
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Ορισμός χρώματος πίσω τοίχου γραφήματος
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Ορισμός χρώματος περιοχής σχεδίασης
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Αποθήκευση παρουσίασης
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Ιδιότητων Γραμματοσειράς για ένα Γράφημα**
Το Aspose.Slides for Android via Java παρέχει υποστήριξη για τον ορισμό ιδιοτήτων σχετικών με τη γραμματοσειρά του γραφήματος. Ακολουθήστε τα παρακάτω βήματα για να ορίσετε τις ιδιότητες γραμματοσειράς για το γράφημα.

- Δημιουργήστε αντικείμενο κλάσης [**Παρουσίαση**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
- Προσθέστε γράφημα στη διαφάνεια.
- Ορίστε το ύψος της γραμματοσειράς.
- Αποθηκεύστε την τροποποιημένη παρουσίαση.

Παρατίθεται παρακάτω ένα παράδειγμα.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Αριθμητικής Μορφής**
Το Aspose.Slides for Android via Java παρέχει ένα απλό API για τη διαχείριση της μορφής δεδομένων του γραφήματος:

1. Δημιουργήστε μια παρουσία της κλάσης [**Παρουσίαση**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
1. Αποκτήστε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα και τον επιθυμητό τύπο (σε αυτό το παράδειγμα χρησιμοποιούμε **ChartType.ClusteredColumn**).
1. Ορίστε τη προεπιλεγμένη μορφή αριθμού από τις διαθέσιμες προεπιλεγμένες τιμές.
1. Περάστε από το κελί δεδομένων του γραφήματος σε κάθε σειρά και ορίστε τη μορφή αριθμού των δεδομένων.
1. Αποθηκεύστε την παρουσίαση.
1. Ορίστε προσαρμοσμένη μορφή αριθμού.
1. Περάστε από τα κελιά δεδομένων του γραφήματος σε κάθε σειρά και ορίστε διαφορετική μορφή αριθμού για τα δεδομένα.
1. Αποθηκεύστε την παρουσίαση.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθήκη προεπιλεγμένου διαγράμματος στήλης με συσσωμάτωση
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Πρόσβαση στη συλλογή σειρών του διαγράμματος
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Διαπέραση κάθε σειράς του διαγράμματος
    for (IChartSeries ser : series) 
    {
        // Διαπέραση κάθε κελιού δεδομένων στη σειρά
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Ορισμός μορφής αριθμού
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Αποθήκευση παρουσίασης
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Οι πιθανές προεπιλεγμένες τιμές μορφής αριθμού μαζί με τον αντίστοιχο δείκτη τους είναι οι εξής:

|**0**|Γενικό|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Ορισμός Στρογγυλεμένων Άκρων Περιοχής Γραφήματος**
Το Aspose.Slides for Android via Java παρέχει υποστήριξη για τη ρύθμιση της περιοχής του γραφήματος. Οι μέθοδοι [**hasRoundedCorners**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) και [**setRoundedCorners**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) προστέθηκαν στη διεπαφή [IChart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChart) και στην κλάση [Chart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Chart).

1. Δημιουργήστε αντικείμενο κλάσης [**Παρουσίαση**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
1. Προσθέστε γράφημα στη διαφάνεια.
1. Ορίστε τύπο και χρώμα γεμίσματος του γραφήματος.
1. Ορίστε την ιδιότητα στρογγυλεμένων γωνιών σε True.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Παρατίθεται παρακάτω ένα παράδειγμα.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω ημιαδιαφανείς γεμίσματα για στήλες/περιοχές διατηρώντας το περίγραμμα αδιαφανές;**

Ναι. Η διαφάνεια του γεμίσματος και το περίγραμμα ρυθμίζονται χωριστά. Αυτό είναι χρήσιμο για τη βελτίωση της αναγνωσιμότητας του πλέγματος και των δεδομένων σε πυκνές οπτικές αναπαραστάσεις.

**Πώς μπορώ να αντιμετωπίσω τις ετικέτες δεδομένων όταν επικαλύπτονται;**

Μειώστε το μέγεθος της γραμματοσειράς, απενεργοποιήστε μη απαραίτητα στοιχεία ετικετών (π.χ. κατηγορίες), ρυθμίστε την απόσταση/θέση της ετικέτας, εμφανίστε ετικέτες μόνο για επιλεγμένα σημεία αν χρειάζεται ή αλλάξτε τη μορφή σε «τιμή + υπόμνημα».

**Μπορώ να εφαρμόσω διαβαθμισμένα ή μοτίβα γεμίσματος στις σειρές;**

Ναι. Συνήθως διατίθενται τόσο γεμίσματα μονής χρώματος όσο και διαβαθμισμένα/μοτίβα. Στην πράξη, χρησιμοποιείτε τα διαβαθμισμένα γεμίσματα με μέτρο και αποφεύγετε συνδυασμούς που μειώνουν την αντίθεση με το πλέγμα και το κείμενο.