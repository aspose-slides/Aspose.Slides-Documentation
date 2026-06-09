---
title: Βελτιστοποίηση Υπολογισμών Διαγράμματος για Παρουσιάσεις σε Java
linktitle: Υπολογισμοί Διαγράμματος
type: docs
weight: 50
url: /el/java/chart-calculations/
keywords:
- υπολογισμοί διαγράμματος
- στοιχεία διαγράμματος
- θέση στοιχείου
- πραγματική θέση
- παιδικό στοιχείο
- γονικό στοιχείο
- τιμές διαγράμματος
- πραγματική τιμή
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Κατανοήστε τους υπολογισμούς διαγράμματος, τις ενημερώσεις δεδομένων και τον έλεγχο ακρίβειας στο Aspose.Slides for Java για PPT και PPTX, με πρακτικά παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει API για εργασία με υπολογισμούς διαγραμμάτων και δεδομένα διάταξης σε παρουσιάσεις. Αυτό το άρθρο δείχνει πώς να ανακτήσετε τις πραγματικές τιμές των στοιχείων του διαγράμματος, συμπεριλαμβανομένης της πραγματικής θέσης και του μεγέθους των στοιχείων που εφαρμόζουν το `IActualLayout` και των πραγματικών τιμών των αξόνων του διαγράμματος. Επίσης εξηγεί ότι αυτές οι τιμές γεμίζουν μετά την επαλήθευση της διάταξης του διαγράμματος.

Επιπλέον, το άρθρο παρουσιάζει πώς να λάβετε τη πραγματική θέση των γονικών στοιχείων του διαγράμματος και πώς να αποκρύψετε στοιχεία του διαγράμματος όπως ο τίτλος, οι άξονες, η υπόμνηση και οι γραμμές πλέγματος. Μαζί, αυτά τα παραδείγματα σας βοηθούν να επιθεωρήσετε τις πληροφορίες διάταξης του διαγράμματος και να ελέγξετε την ορατότητα των στοιχείων του διαγράμματος σε παρουσιάσεις PowerPoint προγραμματιστικά.

## **Υπολογίστε τις Πραγματικές Τιμές των Στοιχείων του Διαγράμματος**
Το Aspose.Slides for Java παρέχει ένα απλό API για τη λήψη αυτών των ιδιοτήτων. Οι ιδιότητες της διεπαφής [IAxis](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAxis) παρέχουν πληροφορίες για τη πραγματική θέση του στοιχείου άξονα του διαγράμματος ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Είναι απαραίτητο να καλέσετε τη μέθοδο [IChart.validateChartLayout()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChart#validateChartLayout--) προηγούμενα για να γεμίσετε τις ιδιότητες με τις πραγματικές τιμές.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Υπολογίστε την Πραγματική Θέση των Γονικών Στοιχείων του Διαγράμματος**
Το Aspose.Slides for Java παρέχει ένα απλό API για τη λήψη αυτών των ιδιοτήτων. Οι ιδιότητες της διεπαφής [IActualLayout](https://reference.aspose.com/slides/el/java/com.aspose.slides/IActualLayout) παρέχουν πληροφορίες για τη πραγματική θέση του γονικού στοιχείου του διαγράμματος ([IActualLayout.getActualX](https://reference.aspose.com/slides/el/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/el/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/IActualLayout#getActualHeight--)). Είναι απαραίτητο να καλέσετε τη μέθοδο [IChart.validateChartLayout()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChart#validateChartLayout--) προηγούμενα για να γεμίσετε τις ιδιότητες με τις πραγματικές τιμές.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Απόκρυψη Στοιχείων Διαγράμματος**
Αυτό το θέμα σας βοηθά να κατανοήσετε πώς να αποκρύψετε πληροφορίες από το διάγραμμα. Χρησιμοποιώντας το Aspose.Slides for Java μπορείτε να αποκρύψετε **Τίτλος, Κάθετος Άξονας, Οριζόντιος Άξονας** και **Γραμμές Πλέγματος** από το διάγραμμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να χρησιμοποιήσετε αυτές τις ιδιότητες.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Απόκρυψη τίτλου διαγράμματος
    chart.setTitle(false);

    ///Απόκρυψη άξονα τιμών
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Ορατότητα άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Απόκρυψη υπομνήματος
    chart.setLegend(false);

    //Απόκρυψη κύριων γραμμών πλέγματος
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Ορισμός χρώματος γραμμής σειράς
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Μπορούν τα εξωτερικά βιβλία εργασίας Excel να λειτουργήσουν ως πηγή δεδομένων, και πώς αυτό επηρεάζει τον επαναϋπολογισμό;**

Ναι. Ένα διάγραμμα μπορεί να αναφέρεται σε εξωτερικό βιβλίο εργασίας: όταν συνδέετε ή ανανεώνετε την εξωτερική πηγή, οι τύποι και οι τιμές λαμβάνονται από εκείνο το βιβλίο, και το διάγραμμα αντικατοπτρίζει τις ενημερώσεις κατά τις λειτουργίες ανοίγματος/επεξεργασίας. Το API σας επιτρέπει να [καθορίσετε το εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) διαδρομή και να διαχειριστείτε τα συνδεδεμένα δεδομένα.

**Μπορώ να υπολογίσω και να εμφανίσω γραμμές τάσης χωρίς να εφαρμόσω εγώ την παλινδρόμηση;**

Ναι. [Trendlines](/slides/el/java/trend-line/) (γραμμικές, εκθετικές και άλλες) προστίθενται και ενημερώνονται από το Aspose.Slides· οι παράμετροι τους επαναϋπολογίζονται αυτόματα από τα δεδομένα της σειράς, ώστε δεν χρειάζεται να υλοποιήσετε δικούς σας υπολογισμούς.

**Αν μια παρουσίαση έχει πολλά διαγράμματα με εξωτερικές συνδέσεις, μπορώ να ελέγξω ποιο βιβλίο εργασίας χρησιμοποιεί κάθε διάγραμμα για τις υπολογισμένες τιμές;**

Ναι. Κάθε διάγραμμα μπορεί να δείχνει στο δικό του [εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), ή μπορείτε να δημιουργήσετε/αντικαταστήσετε ένα εξωτερικό βιβλίο εργασίας ανά διάγραμμα ανεξάρτητα από τα άλλα.