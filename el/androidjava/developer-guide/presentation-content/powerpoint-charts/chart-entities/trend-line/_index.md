---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης σε Android
linktitle: Γραμμή Τάσης
type: docs
url: /el/androidjava/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμική γραμμή τάσης
- λογαριθμική γραμμή τάσης
- γραμμή τάσης κινητού μέσου
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσθέστε γρήγορα και προσαρμόστε γραμμές τάσης σε διαγράμματα PowerPoint με Aspose.Slides for Android via Java — ένας πρακτικός οδηγός για να εμπλέξετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης στις σειρές του διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, συμπεριλαμβανομένων των εκθετικών, γραμμικών, λογαριθμικών, κινητού μέσου, πολυωνυμικών και δύναμης.

Επίσης περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας ένα σχήμα γραμμής, και περιλαμβάνει μια σύντομη Συχνές Ερωτήσεις σχετικά με τις τιμές προώθησης και ανάστροφης προβολής της γραμμής τάσης και εάν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά την απόδοση των διαγραμμάτων ως εικόνες.

## **Προσθήκη Γραμμής Τάσης**
Aspose.Slides for Android via Java provides a simple API for managing different chart Trend Lines:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας με βάση το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα καθώς και τον επιθυμητό τύπο (αυτό το παράδειγμα χρησιμοποιεί ChartType.ClusteredColumn).
4. Προσθήκη εκθετικής γραμμής τάσης για τη σειρά 1 του διαγράμματος.
5. Προσθήκη γραμμικής γραμμής τάσης για τη σειρά 1 του διαγράμματος.
6. Προσθήκη λογαριθμικής γραμμής τάσης για τη σειρά 2 του διαγράμματος.
7. Προσθήκη γραμμής τάσης κινητού μέσου για τη σειρά 2 του διαγράμματος.
8. Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά 3 του διαγράμματος.
9. Προσθήκη γραμμής τάσης δύναμης για τη σειρά 3 του διαγράμματος.
10. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

The following code is used to create a chart with Trend Lines.

```java
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation class
Presentation pres = new Presentation();
try {
    // Δημιουργία διαγράμματος ομαδοποιημένων στηλών
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Προσθήκη εκθετικής γραμμής τάσης για τη σειρά 1 του διαγράμματος
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Προσθήκη γραμμικής γραμμής τάσης για τη σειρά 1 του διαγράμματος
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Προσθήκη λογαριθμικής γραμμής τάσης για τη σειρά 2 του διαγράμματος
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Προσθήκη γραμμής τάσης κινητού μέσου για τη σειρά 2 του διαγράμματος
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά 3 του διαγράμματος
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Προσθήκη γραμμής τάσης δύναμης για τη σειρά 3 του διαγράμματος
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Αποθήκευση παρουσίασης
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη Προσαρμοσμένης Γραμμής**
Aspose.Slides for Android via Java provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation)
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της
- Δημιουργήστε ένα νέο διάγραμμα χρησιμοποιώντας τη μέθοδο AddChart που εκτίθεται από το αντικείμενο Shapes
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο AddAutoShape που εκτίθεται από το αντικείμενο Shapes
- Ορίστε το χρώμα (Color) των γραμμών του σχήματος.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX

The following code is used to create a chart with Custom Lines.

```java
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Τι σημαίνουν οι όροι 'forward' και 'backward' για μια γραμμή τάσης;**

Αναφέρονται στο μήκος της γραμμής τάσης που προβλέπεται προς τα μπροστά/πίσω: για διαγράμματα διασποράς (XY) — σε μονάδες άξονα· για μη διαγράμματα διασποράς — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά την απόδοση μιας διαφάνειας ως εικόνα;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/el/androidjava/render-a-slide-as-an-svg-image/) και αποδίδει τα διαγράμματα ως εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά τις ενέργειες αυτές. Διατίθεται επίσης μια μέθοδος για [εξαγωγή εικόνας του διαγράμματος](/slides/el/androidjava/create-shape-thumbnails/) ιδίου.