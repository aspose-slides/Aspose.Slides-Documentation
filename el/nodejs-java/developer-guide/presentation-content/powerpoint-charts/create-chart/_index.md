---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε JavaScript
linktitle: Δημιουργία ή Ενημέρωση Διαγραμμάτων
type: docs
weight: 10
url: /el/nodejs-java/create-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- διασκορπιστικό διάγραμμα
- διάγραμμα πίτας
- γραμμικό διάγραμμα
- διάγραμμα χάρτη δένδρου
- διάγραμμα μετοχών
- διάγραμμα box‑and‑whisker
- διάγραμμα χωνιού
- διάγραμμα ηλιακού ακτίνου
- ιστόγραμμα
- διάγραμμα ραδιογραφίας
- πολυκατηγορικό διάγραμμα
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για Node.js. Προσθέστε, μορφοποιήστε και επεξεργαστείτε διαγράμματα με πρακτικά παραδείγματα κώδικα σε JavaScript."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε διαγράμματα χρησιμοποιώντας το Aspose.Slides. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει με τις συγκεκριμένες απαιτήσεις σχεδίασής σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα απεικονίζουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος έως τη διαμόρφωση σειρών, αξόνων και υπομνήματος. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε σταθερή κατανόηση του πώς να ενσωματώσετε δυναμική δημιουργία διαγραμμάτων στις εφαρμογές σας, βελτιώνοντας τη διαδικασία δημιουργίας παρουσιάσεων βασισμένων σε δεδομένα.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα τα δεδομένα και να εξάγουν συμπεράσματα που μπορεί να μην είναι άμεσα εμφανή από έναν πίνακα ή λογιστικό φύλλο.

**Γιατί να Δημιουργείτε Διαγράμματα;**

Με τη χρήση διαγραμμάτων, μπορείτε:

* να συγκεντρώσετε, συμπτύξετε ή συνοψίσετε μεγάλα σύνολα δεδομένων σε μία μόνο διαφάνεια παρουσίασης
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα
* να ανιχνεύσετε την κατεύθυνση και την ορμή των δεδομένων στο χρόνο ή σε σχέση με μια συγκεκριμένη μονάδα μέτρησης
* να εντοπίσετε ακραίες τιμές, αποκλίσεις, σφάλματα, ακατανόητα δεδομένα κ.λπ.
* να επικοινωνήσετε ή να παρουσιάσετε σύνθετα δεδομένα

Στο PowerPoint, μπορείτε να δημιουργείτε διαγράμματα μέσω της λειτουργίας *Insert*, η οποία παρέχει πρότυπα για το σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά διαγράμματα (βάσει δημοφιλών τύπων) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="info" title="Σημείωση" %}}

Για τη δημιουργία διαγραμμάτων, χρησιμοποιήστε την κλάση [ChartType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/). Τα πεδία σε αυτήν την κλάση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.

{{% /alert %}}

### **Δημιουργία Συσσώρευτων Στηλοειδών Διαγραμμάτων**

Αυτή η ενότητα εξηγεί πώς να δημιουργήσετε συσσωρευτικά στηλοειδή διαγράμματα χρησιμοποιώντας το Aspose.Slides. Θα μάθετε να αρχικοποιείτε μια παρουσίαση, να προσθέτετε ένα διάγραμμα και να προσαρμόζετε τα στοιχεία του όπως ο τίτλος, τα δεδομένα, οι σειρές, οι κατηγορίες και η μορφοποίηση. Ακολουθήστε τα παρακάτω βήματα για να δείτε πώς δημιουργείται ένα τυπικό συσσωρευτικό στήλοειδο διάγραμμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.ClusteredColumn` .
4. Προσθέστε έναν τίτλο στο διάγραμμα.
5. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
6. Καθαρίστε όλες τις προεπιλεγμένες σειρές και κατηγορίες.
7. Προσθέστε νέες σειρές και κατηγορίες.
8. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
9. Εφαρμόστε χρώμα γεμίσματος στις σειρές του διαγράμματος.
10. Προσθέστε ετικέτες στις σειρές του διαγράμματος.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα συσσωρευτικό στήλοειδο διάγραμμα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί ένα αντικείμενο παρουσίασης που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Προσπελάζει την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Προσθέτει ένα διάγραμμα με τα προεπιλεγμένα δεδομένα του
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Ορίζει τον τίτλο του διαγράμματος
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // Ορίζει την πρώτη σειρά να εμφανίζει τιμές
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Ορίζει το δείκτη για το φύλλο δεδομένων του διαγράμματος
    var defaultWorksheetIndex = 0;
    // Αποκτά το φύλλο εργασίας δεδομένων του διαγράμματος
    var fact = chart.getChartData().getChartDataWorkbook();
    // Διαγράφει τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Προσθέτει νέες σειρές
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Προσθέτει νέες κατηγορίες
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Παίρνει την πρώτη σειρά του διαγράμματος
    var series = chart.getChartData().getSeries().get_Item(0);
    // Τώρα γεμίζει τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Ορίζει το χρώμα γεμίσματος για τη σειρά
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Παίρνει τη δεύτερη σειρά του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1);
    // Γεμίζει τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Ορίζει το χρώμα γεμίσματος για τη σειρά
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Δημιουργεί προσαρμοσμένες ετικέτες για κάθε κατηγορία της νέας σειράς
    // Ορίζει την πρώτη ετικέτα να εμφανίζει το όνομα της κατηγορίας
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Εμφανίζει τιμή για την τρίτη ετικέτα
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Αποθηκεύει την παρουσίαση με το διάγραμμα
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Διασκορπιστικών Διαγραμμάτων**

Διασκορπιστικά διαγράμματα (επίσης γνωστά ως scatter plots ή διαγράμματα x‑y) χρησιμοποιούνται συχνά για να ελέγχουν μοτίβα ή να αποδεικνύουν συσχετισμούς μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε διασκορπιστικό διάγραμμα όταν:

* έχετε ζευγαρωμένα αριθμητικά δεδομένα
* έχετε δύο μεταβλητές που ταιριάζουν καλά μεταξύ τους
* θέλετε να καθορίσετε αν δύο μεταβλητές σχετίζονται
* έχετε μια ανεξάρτητη μεταβλητή με πολλαπλές τιμές για μια εξαρτημένη μεταβλητή

1. Ακολουθήστε τα βήματα στην ενότητα [Create Clustered Column Charts](#create-clustered-column-charts) .
2. Στο τρίτο βήμα, προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο του διαγράμματος ως ένα από τα παρακάτω:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Αντιπροσωπεύει ένα διασκορπιστικό διάγραμμα με δείκτες._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Αντιπροσωπεύει ένα διασκορπιστικό διάγραμμα συνδεδεμένο με καμπύλες, με δείκτες δεδομένων._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Αντιπροσωπεύει ένα διασκορπιστικό διάγραμμα συνδεδεμένο με καμπύλες, χωρίς δείκτες δεδομένων._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Αντιπροσωπεύει ένα διασκορπιστικό διάγραμμα συνδεδεμένο με ευθείες γραμμές, με δείκτες δεδομένων._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Αντιπροσωπεύει ένα διασκορπιστικό διάγραμμα συνδεδεμένο με ευθείες γραμμές, χωρίς δείκτες δεδομένων._

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα διασκορπιστικό διάγραμμα με διαφορετικούς δείκτες για κάθε σειρά:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργεί ένα αντικείμενο παρουσίασης που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Προσπελάζει την πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Δημιουργεί το προεπιλεγμένο διάγραμμα
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Λαμβάνει το δείκτη του προεπιλεγμένου φύλλου δεδομένων του διαγράμματος
    var defaultWorksheetIndex = 0;
    // Λαμβάνει το φύλλο δεδομένων του διαγράμματος
    var fact = chart.getChartData().getChartDataWorkbook();
    // Διαγράφει τις δοκιμαστικές σειρές
    chart.getChartData().getSeries().clear();
    // Προσθέτει νέες σειρές
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Παίρνει την πρώτη σειρά του διαγράμματος
    var series = chart.getChartData().getSeries().get_Item(0);
    // Προσθέτει νέο σημείο (1:3) στη σειρά
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Προσθέτει νέο σημείο (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Αλλάζει τον τύπο της σειράς
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Αλλάζει το δείκτη (marker) της σειράς διαγράμματος
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Παίρνει τη δεύτερη σειρά του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1);
    // Προσθέτει νέο σημείο (5:2) εκεί
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Προσθέτει νέο σημείο (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Προσθέτει νέο σημείο (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Προσθέτει νέο σημείο (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Αλλάζει το δείκτη (marker) της σειράς διαγράμματος
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Πίτας Διαγραμμάτων**

Διαγράμματα πίτας χρησιμοποιούνται καλύτερα για να δείξουν τη σχέση μέρος‑συνολο στα δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγορηματικές ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιλαμβάνουν πολλά τμήματα ή ετικέτες, ίσως θελήσετε να εξετάσετε τη χρήση ράβδου διαγράμματος αντί αυτού.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Pie](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#Pie) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
8. Προσθέστε νέα σημεία στο διάγραμμα και εφαρμόστε προσαρμοσμένα χρώματα για τους τομείς της πίτας.
9. Ορίστε ετικέτες για τις σειρές.
10. Ενεργοποιήστε τις γραμμές οδηγούς για τις ετικέτες των σειρών.
11. Ορίστε τη γωνία περιστροφής για τους τομείς της πίτας.
12. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα διάγραμμα πίτας:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί ένα αντικείμενο παρουσίασης που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Προσπελάζει την πρώτη διαφάνεια
    var slides = pres.getSlides().get_Item(0);
    // Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Ορίζει τον τίτλο του διαγράμματος
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Ορίζει την πρώτη σειρά να εμφανίζει τιμές
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Ορίζει το δείκτη για το φύλλο δεδομένων του διαγράμματος
    var defaultWorksheetIndex = 0;
    // Λαμβάνει το φύλλο δεδομένων του διαγράμματος
    var fact = chart.getChartData().getChartDataWorkbook();
    // Διαγράφει τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Προσθέτει νέες κατηγορίες
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Προσθέτει νέες σειρές
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Γεμίζει τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Δεν λειτουργεί στη νέα έκδοση
    // Προσθήκη νέων σημείων και ορισμός χρώματος τομέα
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Ορίζει το περίγραμμα του τομέα
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Ορίζει το περίγραμμα του τομέα
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Ορίζει το περίγραμμα του τομέα
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // Δημιουργεί προσαρμοσμένες ετικέτες για κάθε κατηγορία της νέας σειράς
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Εμφανίζει γραμμές οδηγούς για το διάγραμμα
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Ορίζει τη γωνία περιστροφής για τους τομείς του διαγράμματος πίτας
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Αποθηκεύει την παρουσίαση με διάγραμμα
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Γραμμικών Διαγραμμάτων**

Γραμμικά διαγράμματα (επίσης γνωστά ως line graphs) χρησιμοποιούνται καλύτερα σε καταστάσεις όπου θέλετε να παρουσιάσετε αλλαγές στην τιμή με την πάροδο του χρόνου. Με ένα γραμμικό διάγραμμα, μπορείτε να συγκρίνετε μεγάλο όγκο δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις στο χρόνο, να επισημαίνετε ανωμαλίες σε σειρές δεδομένων και πολλά άλλα.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Line](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#Line) .
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/)) .
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα γραμμικό διάγραμμα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Από προεπιλογή, τα σημεία ενός γραμμικού διαγράμματος ενώνουν συνεχείς ευθείες γραμμές. Εάν θέλετε τα σημεία να ενώνονται με παύλες, μπορείτε να ορίσετε τον επιθυμητό τύπο παύλας όπως παρακάτω:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Διαγραμμάτων Δέντρου**

Διαγράμματα δέντρου (tree map) χρησιμοποιούνται καλύτερα για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος κατηγοριών δεδομένων και να τραβήξετε γρήγορα την προσοχή σε στοιχεία που είναι μεγάλοι συνεισφέροντες εντός κάθε κατηγορίας.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Treemap](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#Treemap) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα διάγραμμα δέντρου:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // κλαδί 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // κλαδί 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Διαγραμμάτων Αποθεμάτων**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#OpenHighLowClose) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
8. Ορίστε τη μορφή των γραμμών υψηλής‑χαμηλής τιμής.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα διάγραμμα αποθεμάτων:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Διαγραμμάτων Box και Whisker**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#BoxAndWhisker) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα διάγραμμα Box και Whisker:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Διάγραμμα Σκούρας (Funnel)**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Funnel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#Funnel) .
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα διάγραμμα σκούρας:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Διάγραμμα Ηλιακού Ακτίνων (Sunburst)**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Sunburst](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#Sunburst) .
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα διάγραμμα ηλιακού ακτίνου:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // κλαδί 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // κλαδί 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Ιστόγραμμα (Histogram)**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Histogram](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#Histogram) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα ιστόγραμμα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Δημιουργία Διαγραμμάτων Ραδιογραφίας (Radar)**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον επιθυμητό τύπο διαγράμματος ([ChartType.Radar](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#Radar) σε αυτήν την περίπτωση).
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα διάγραμμα ραδιογραφίας:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Πολυκατηγορικών Διαγραμμάτων**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.ClusteredColumn](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/#ClusteredColumn) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα πολυκατηγορικό διάγραμμα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Προσθήκη Σειρών
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Αποθήκευση παρουσίασης με διάγραμμα
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Διαγραμμάτων Χάρτη**

Τα διαγράμματα χάρτη απεικονίζουν γεωγραφικά δεδομένα και βοηθούν στη σύγκριση τιμών ανά περιοχές.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα διάγραμμα χάρτη:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Συνδυαστικών Διαγραμμάτων**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα γράφημα. Αυτό το διάγραμμα σας επιτρέπει να επισημάνετε, συγκρίνετε ή εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![The combination chart](combination_chart.png)

Ο παρακάτω κώδικας JavaScript δείχνει πώς να δημιουργήσετε το συνδυαστικό διάγραμμα που εμφανίζεται παραπάνω σε μια παρουσίαση PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Ορισμός τίτλου διαγράμματος.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Ορισμός υπομνήματος διαγράμματος.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Διαγραφή των προεπιλεγμένων δημιουργημένων σειρών και κατηγοριών.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Προσθήκη νέων κατηγοριών.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Προσθήκη της πρώτης σειράς.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Ορισμός οριζόντιου άξονα.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Ορισμός κάθετου άξονα.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Ορισμός χρώματος των κύριων κατακόρυφων γραμμών πλέγματος.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Ορισμός δευτερεύοντος οριζόντιου άξονα.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Ορισμός δευτερεύοντος κάθετου άξονα.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Ενημέρωση Διαγραμμάτων**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα που θέλετε να ενημερώσετε.
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Περπατήστε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
5. Τροποποιήστε τις σειρές δεδομένων του διαγράμματος αλλάζοντας τις τιμές των σειρών.
6. Προσθέστε μια νέα σειρά και συμπληρώστε τα δεδομένα της.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να ενημερώσετε ένα διάγραμμα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Λήψη διαγράμματος με προεπιλεγμένα δεδομένα
    var chart = sld.getShapes().get_Item(0);
    // Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος
    var defaultWorksheetIndex = 0;
    // Λήψη του φύλλου δεδομένων του διαγράμματος
    var fact = chart.getChartData().getChartDataWorkbook();
    // Αλλαγή του ονόματος κατηγορίας του διαγράμματος
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Λήψη της πρώτης σειράς του διαγράμματος
    var series = chart.getChartData().getSeries().get_Item(0);
    // Τώρα ενημέρωση δεδομένων σειράς
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Τροποποίηση ονόματος σειράς
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Λήψη της δεύτερης σειράς του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1);
    // Τώρα ενημέρωση δεδομένων σειράς
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Τροποποίηση ονόματος σειράς
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Τώρα, προσθήκη νέας σειράς
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Λήψη της 3ης σειράς του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(2);
    // Τώρα γεμίζοντας δεδομένα σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Αποθήκευση παρουσίασης με το διάγραμμα
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Περιοχής Δεδομένων για Διάγραμμα**

Για να ορίσετε την περιοχή δεδομένων ενός διαγράμματος, κάντε τα εξής:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα.
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Περπατήστε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Πρόσβαση στα δεδομένα του διαγράμματος και ορίστε την περιοχή.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε την περιοχή δεδομένων για ένα διάγραμμα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Χρήση Προεπιλεγμένων Δεικτών σε Διαγράμματα**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό σύμβολο δείκτη.

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε αυτόματα έναν δείκτη σειράς διαγράμματος:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Λάβε τη δεύτερη σειρά του διαγράμματος
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Τώρα γεμίζοντας τα δεδομένα της σειράς
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζονται από το Aspose.Slides;**

Το Aspose.Slides υποστηρίζει ένα ευρύ φάσμα [chart types](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/), συμπεριλαμβανομένων bar, line, pie, area, scatter, histogram, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διαγράμματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε διάγραμμα, πρώτα δημιουργείτε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) , ανακτάτε τη διαφάνεια που θέλετε χρησιμοποιώντας το δείκτη της και, στη συνέχεια, καλείτε τη μέθοδο προσθήκης διαγράμματος, προσδιορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Η διαδικασία αυτή ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος προσπελαύνοντας το βιβλίο εργασίας δεδομένων του ([ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/)), καθαρίζοντας τις προεπιλεγμένες σειρές και κατηγορίες, και προσθέτοντας τα δικά σας προσαρμοσμένα δεδομένα. Αυτό σας επιτρέπει να ανανεώνετε προγραμματιστικά το διάγραμμα ώστε να αντανακλά τα πιο πρόσφατα δεδομένα.

**Μπορεί να προσαρμοστεί η εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα [formatting elements](/slides/el/nodejs-java/chart-entities/) ώστε να ταιριάζουν με τις συγκεκριμένες απαιτήσεις σχεδίασής σας.