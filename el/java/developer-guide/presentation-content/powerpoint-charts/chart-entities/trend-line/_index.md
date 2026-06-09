---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης σε Java
linktitle: Γραμμή Τάσης
type: docs
url: /el/java/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμική γραμμή τάσης
- λογαριθμική γραμμή τάσης
- γραμμή τάσης κινητού μέσου όρου
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Προσθέστε γρήγορα και προσαρμόστε τις γραμμές τάσης σε διαγράμματα PowerPoint με το Aspose.Slides for Java — έναν πρακτικό οδηγό για να εμπλέκετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης σε σειρές διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, συμπεριλαμβανομένων των εκθετικών, γραμμικών, λογαριθμικών, κινητού μέσου όρου, πολυωνυμικών και δύναμης.

Επίσης περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας ένα σχήμα γραμμής και περιλαμβάνει μια σύντομη FAQ σχετικά με τις τιμές προβολής της γραμμής τάσης προς τα μπροστά και προς τα πίσω, καθώς και το αν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά τη δημιουργία διαγραμμάτων ως εικόνες.

## **Προσθήκη Γραμμής Τάσης**
Aspose.Slides for Java παρέχει ένα απλό API για τη διαχείριση διαφορετικών γραμμών τάσης σε διαγράμματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας με το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και τον επιθυμητό τύπο (σε αυτό το παράδειγμα χρησιμοποιείται ChartType.ClusteredColumn).
1. Προσθήκη εκθετικής γραμμής τάσης για τη σειρά διαγράμματος 1.
1. Προσθήκη γραμμικής γραμμής τάσης για τη σειρά διαγράμματος 1.
1. Προσθήκη λογαριθμικής γραμμής τάσης για τη σειρά διαγράμματος 2.
1. Προσθήκη γραμμής τάσης κινητού μέσου όρου για τη σειρά διαγράμματος 2.
1. Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά διαγράμματος 3.
1. Προσθήκη γραμμής τάσης δύναμης για τη σειρά διαγράμματος 3.
1. Γράψτε την τροποποιημένη παρουσίαση σε ένα αρχείο PPTX.

Ο παρακάτω κώδικας χρησιμοποιείται για τη δημιουργία ενός διαγράμματος με γραμμές τάσης.

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Δημιουργία διαγράμματος ομαδοποιημένων στηλών
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Προσθήκη εκθετικής γραμμής τάσης για τη σειρά διαγράμματος 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Προσθήκη γραμμικής γραμμής τάσης για τη σειρά διαγράμματος 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Προσθήκη λογαριθμικής γραμμής τάσης για τη σειρά διαγράμματος 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Προσθήκη γραμμής τάσης κινητού μέσου όρου για τη σειρά διαγράματος 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά διαγράματος 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Προσθήκη γραμμής τάσης δύναμης για τη σειρά διαγράματος 3
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
Aspose.Slides for Java παρέχει ένα απλό API για την προσθήκη προσαρμοσμένων γραμμών σε ένα διάγραμμα. Για να προσθέσετε μια απλή επίπεδη γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation)
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της
- Δημιουργήστε ένα νέο διάγραμμα χρησιμοποιώντας τη μέθοδο AddChart που εκτίθεται από το αντικείμενο Shapes
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο AddAutoShape που εκτίθεται από το αντικείμενο Shapes
- Ορίστε το Color των γραμμών του σχήματος.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX

Ο παρακάτω κώδικας χρησιμοποιείται για τη δημιουργία ενός διαγράμματος με προσαρμοσμένες γραμμές.

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
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

## **FAQ**

**Τι σημαίνουν τα 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που προβλέπεται προς τα μπροστά/πίσω: για διαγράμματα scatter (XY) — σε μονάδες άξονα· για μη scatter διαγράμματα — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά τη δημιουργία μιας διαφάνειας ως εικόνας;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/java/convert-powerpoint-to-pdf/)/[SVG](/slides/el/java/render-a-slide-as-an-svg-image/) και αποδίδει διαγράμματα σε εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά την εκτέλεση αυτών των λειτουργιών. Υπάρχει επίσης μέθοδος για [εξαγωγή εικόνας του διαγράμματος](/slides/el/java/create-shape-thumbnails/).