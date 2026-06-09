---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης με JavaScript
linktitle: Γραμμή Τάσης
type: docs
url: /el/nodejs-java/trend-line/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσθέστε και προσαρμόστε γρήγορα τις γραμμές τάσης σε διαγράμματα PowerPoint με JavaScript και Aspose.Slides για Node.js μέσω Java — ένας πρακτικός οδηγός για να εντυπωσιάσετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης σε σειρές διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, συμπεριλαμβανομένων των εκθετικών, γραμμικών, λογαριθμικών, κινητών μέσων, πολυωνυμικών και δύναμης.

Παράλληλα περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε διάγραμμα εισάγοντας ένα σχήμα γραμμής, και περιλαμβάνει μια σύντομη FAQ σχετικά με τις τιμές προώθησης και οπισθοδρόμησης των γραμμών τάσης και το αν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά την απόδοση των διαγραμμάτων ως εικόνες.

## **Προσθήκη Γραμμής Τάσης**

Aspose.Slides for Node.js via Java παρέχει ένα απλό API για τη διαχείριση διαφορετικών γραμμών τάσης σε διαγράμματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας με βάση το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και οποιουσδήποτε επιθυμητούς τύπους (σε αυτό το παράδειγμα χρησιμοποιείται ChartType.ClusteredColumn).
1. Προσθήκη εκθετικής γραμμής τάσης για τη σειρά διαγράμματος 1.
1. Προσθήκη γραμμής τάσης γραμμικού τύπου για τη σειρά διαγράμματος 1.
1. Προσθήκη λογαριθμικής γραμμής τάσης για τη σειρά διαγράμματος 2.
1. Προσθήκη γραμμής τάσης κινητού μέσου για τη σειρά διαγράμματος 2.
1. Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά διαγράμματος 3.
1. Προσθήκη γραμμής τάσης δύναμης για τη σειρά διαγράμματος 3.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Ο παρακάτω κώδικας χρησιμοποιείται για τη δημιουργία διαγράμματος με γραμμές τάσης.

```javascript
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Δημιουργία συγκεντρωτικού διαγράμματος στηλών
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Προσθήκη εκθετικής γραμμής τάσης για τη σειρά διαγράμματος 1
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Προσθήκη γραμμικής γραμμής τάσης για τη σειρά διαγράμματος 1
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Προσθήκη λογαριθμικής γραμμής τάσης για τη σειρά διαγράμματος 2
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Προσθήκη γραμμής τάσης κινητού μέσου για τη σειρά διαγράμματος 2
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά διαγράμματος 3
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Προσθήκη γραμμής τάσης δύναμης για τη σειρά διαγράμματος 3
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Αποθήκευση παρουσίασης
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη Προσαρμοσμένης Γραμμής**

Aspose.Slides for Node.js via Java παρέχει ένα απλό API για την προσθήκη προσαρμοσμένων γραμμών σε διάγραμμα. Για να προσθέσετε μια απλή επίπεδη γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation)
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της
- Δημιουργήστε ένα νέο διάγραμμα χρησιμοποιώντας τη μέθοδο AddChart που εκτίθεται από το αντικείμενο Shapes
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο AddAutoShape που εκτίθεται από το αντικείμενο Shapes
- Ορίστε το χρώμα (Color) των γραμμών του σχήματος.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX

```javascript
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Τι σημαίνουν οι όροι 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που προβάλλονται προς τα εμπρός/πίσω: για διαγράμματα διασποράς (XY) — σε μονάδες άξονα· για μη διασποράς διαγράμματα — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά την απόδοση μιας διαφάνειας ως εικόνα;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/el/nodejs-java/render-a-slide-as-an-svg-image/) και αποδίδει τα διαγράμματα ως εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά τη διάρκεια αυτών των διαδικασιών. Διατίθεται επίσης μια μέθοδος για [εξαγωγή εικόνας του διαγράμματος](/slides/el/nodejs-java/create-shape-thumbnails/) καθεαυτού.