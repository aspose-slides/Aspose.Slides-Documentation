---
title: Βελτιστοποίηση Υπολογισμών Διαγραμμάτων για Παρουσιάσεις σε Android
linktitle: Υπολογισμοί Διαγράμματος
type: docs
weight: 50
url: /el/androidjava/chart-calculations/
keywords:
- υπολογισμοί διαγραμμάτων
- στοιχεία διαγράμματος
- θέση στοιχείου
- πραγματική θέση
- παιδικό στοιχείο
- γονικό στοιχείο
- τιμές διαγράμματος
- πραγματική τιμή
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Κατανοήστε τους υπολογισμούς διαγράμματος, τις ενημερώσεις δεδομένων και τον έλεγχο ακρίβειας στην Aspose.Slides για Android για PPT και PPTX, με πρακτικά παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Η Aspose.Slides παρέχει API για εργασία με υπολογισμούς διαγραμμάτων και δεδομένα διάταξης σε παρουσιάσεις. Αυτό το άρθρο δείχνει πώς να ανακτήσετε τις πραγματικές τιμές των στοιχείων του διαγράμματος, συμπεριλαμβανομένης της πραγματικής θέσης και μεγέθους των στοιχείων που υλοποιούν `IActualLayout` και των πραγματικών τιμών των αξόνων του διαγράμματος. Εξηγεί επίσης ότι αυτές οι τιμές γίνονται διαθέσιμες μετά την επικύρωση της διάταξης του διαγράμματος.

Επιπλέον, το άρθρο επιδεικνύει πώς να αποκτήσετε την πραγματική θέση των γονικών στοιχείων του διαγράμματος και πώς να κρύψετε στοιχεία του διαγράμματος όπως ο τίτλος, οι άξονες, η υπόμνηση και οι γραμμές πλέγματος. Μαζί, αυτά τα παραδείγματα σας βοηθούν να ελέγξετε τις πληροφορίες διάταξης του διαγράμματος και να ελέγξετε την ορατότητα των στοιχείων του διαγράμματος σε παρουσιάσεις PowerPoint προγραμματιστικά.

## **Υπολογισμός Πραγματικών Τιμών Στοιχείων του Διαγράμματος**
Η Aspose.Slides for Android μέσω Java παρέχει ένα απλό API για την απόκτηση αυτών των ιδιοτήτων. Οι ιδιότητες της διεπαφής [IAxis](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAxis) παρέχουν πληροφορίες για την πραγματική θέση του στοιχείου άξονα του διαγράμματος ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Είναι απαραίτητο να καλέσετε τη μέθοδο [IChart.validateChartLayout()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChart#validateChartLayout--) προηγουμένως ώστε να γεμίσουν οι ιδιότητες με τις πραγματικές τιμές.

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

## **Υπολογισμός Πραγματικής Θέσης Γονικών Στοιχείων Διαγράμματος**
Η Aspose.Slides for Android μέσω Java παρέχει ένα απλό API για την απόκτηση αυτών των ιδιοτήτων. Ιδιότητες της διεπαφής [IActualLayout](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IActualLayout) παρέχουν πληροφορίες για την πραγματική θέση του γονικού στοιχείου του διαγράμματος ([IActualLayout.getActualX](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). Είναι απαραίτητο να καλέσετε τη μέθοδο [IChart.validateChartLayout()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChart#validateChartLayout--) προηγουμένως ώστε να γεμίσουν οι ιδιότητες με τις πραγματικές τιμές.

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
Αυτό το θέμα σας βοηθά να κατανοήσετε πώς να κρύψετε πληροφορίες από το διάγραμμα. Χρησιμοποιώντας την Aspose.Slides για Android μέσω Java μπορείτε να κρύψετε **Τίτλο, Κατακόρυφο Άξονα, Οριζόντιο Άξονα** και **Γραμμές Πλέγματος** από το διάγραμμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να χρησιμοποιήσετε αυτές τις ιδιότητες.

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

## **Συχνές Ερωτήσεις**

**Μπορούν τα εξωτερικά βιβλία εργασίας Excel να λειτουργούν ως πηγή δεδομένων και πώς επηρεάζει αυτό τον επανυπολογισμό;**

Ναι. Ένα διάγραμμα μπορεί να αναφέρει ένα εξωτερικό βιβλίο εργασίας: όταν συνδέεστε ή ανανεώνετε την εξωτερική πηγή, οι τύποι και οι τιμές λαμβάνονται από εκείνο το βιβλίο εργασίας, και το διάγραμμα αντικατοπτρίζει τις ενημερώσεις κατά τις λειτουργίες ανοιχτής/επεξεργασίας. Το API σας επιτρέπει να [καθορίσετε το εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) διαδρομή και να διαχειριστείτε τα συνδεδεμένα δεδομένα.

**Μπορώ να υπολογίσω και να εμφανίσω τις γραμμές τάσης χωρίς να υλοποιήσω εγώ την παλινδρόμηση;**

Ναι. Οι [Γραμμές Τάσης](/slides/el/androidjava/trend-line/) (γραμμικές, εκθετικές και άλλες) προστίθενται και ενημερώνονται από την Aspose.Slides· οι παράμετροί τους επανυπολογίζονται αυτόματα από τα δεδομένα της σειράς, έτσι δεν χρειάζεται να υλοποιήσετε δικούς σας υπολογισμούς.

**Εάν μια παρουσίαση έχει πολλαπλά διαγράμματα με εξωτερικούς συνδέσμους, μπορώ να ελέγξω ποιο βιβλίο εργασίας χρησιμοποιεί κάθε διάγραμμα για τις υπολογισμένες τιμές;**

Ναι. Κάθε διάγραμμα μπορεί να δείχνει στο δικό του [εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), ή μπορείτε να δημιουργήσετε/αντικαταστήσετε ένα εξωτερικό βιβλίο εργασίας ανά διάγραμμα ανεξάρτητα από τα άλλα.