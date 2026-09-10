---
title: Δημιουργία ή ενημέρωση διαγραμμάτων παρουσίασης PowerPoint σε Android
linktitle: Δημιουργία ή ενημέρωση διαγραμμάτων
type: docs
weight: 10
url: /el/androidjava/create-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- διάσπαρτο διάγραμμα
- κυκλικό διάγραμμα
- διάγραμμα γραμμής
- διάγραμμα δέντρου χάρτη
- διάγραμμα μετοχών
- διάγραμμα κουτιού και γκατσαρόματος
- διάγραμμα χωνίου
- διάγραμμα ηλιακού άνθους
- ιστόγραμμα
- διάγραμμα ραντάρ
- διάγραμμα πολλαπλών κατηγοριών
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργία και προσαρμογή διαγραμμάτων σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Android. Προσθήκη, μορφοποίηση και επεξεργασία διαγραμμάτων με πρακτικά παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα χρησιμοποιώντας το Aspose.Slides. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει με τις συγκεκριμένες απαιτήσεις σχεδίασής σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα απεικονίζουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος μέχρι τη διαμόρφωση σειρών, αξόνων και υπομνήματος. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε σταθερή κατανόηση του πώς να ενσωματώνετε δυναμική δημιουργία διαγραμμάτων στις εφαρμογές σας, βελτιώνοντας τη διαδικασία δημιουργίας παρουσιάσεων βάσει δεδομένων.

## **Δημιουργία γραφήματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα δεδομένα και να εξάγουν διορατικές πληροφορίες που ενδέχεται να μην είναι άμεσα εμφανείς από έναν πίνακα ή ένα λογιστικό φύλλο.

**Γιατί να δημιουργήσετε γραφήματα;**

Με τη χρήση διαγραμμάτων, μπορείτε:

* να συγκεντρώσετε, συμπιέσετε ή συνοψίσετε μεγάλες ποσότητες δεδομένων σε μία μόνο διαφάνεια μιας παρουσίασης
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα
* να προβλέψετε την κατεύθυνση και την ορμή των δεδομένων σε βάθος χρόνου ή σε σχέση με συγκεκριμένη μονάδα μέτρησης
* να εντοπίσετε εκτός τάσης τιμές, ανωμαλίες, αποκλίσεις, σφάλματα, ασυνάρτητα δεδομένα κ.λπ.
* να επικοινωνήσετε ή να παρουσιάσετε σύνθετα δεδομένα

Στο PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας *Insert*, η οποία παρέχει πρότυπα για το σχεδιασμό πολλών τύπων διαγραμμάτων. Με το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά διαγράμματα (βάσει δημοφιλών τύπων) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="info" title="Note" %}}
Για τη δημιουργία διαγραμμάτων, χρησιμοποιήστε την κλάση [ChartType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/). Τα πεδία σε αυτήν την κλάση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.
{{% /alert %}}

### **Δημιουργία στηλών με συστάδες**

Αυτή η ενότητα εξηγεί πώς να δημιουργήσετε διαγράμματα στηλών με συστάδες χρησιμοποιώντας το Aspose.Slides. Θα μάθετε πώς να αρχικοποιείτε μια παρουσίαση, να προσθέτετε ένα διάγραμμα και να προσαρμόζετε τα στοιχεία του, όπως τίτλο, δεδομένα, σειρές, κατηγορίες και στυλ. Ακολουθήστε τα παρακάτω βήματα για να δείτε πώς δημιουργείται ένα τυπικό διάγραμμα στηλών με συστάδες:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) .
1. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον τύπο `ChartType.ClusteredColumn` .
1. Προσθέστε έναν τίτλο στο διάγραμμα.
1. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
1. Καθαρίστε όλες τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθήκη νέων σειρών και κατηγοριών.
1. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές.
1. Εφαρμογή χρώματος γέμισης στις σειρές του διαγράμματος.
1. Προσθήκη ετικετών στις σειρές του διαγράμματος.
1. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα στηλών με συστάδες:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Προσθέτει ένα διάγραμμα με τα προεπιλεγμένα δεδομένα του
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Ορίζει τον τίτλο του διαγράμματος
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Ορίζει το δείκτη για το φύλλο δεδομένων του διαγράμματος
    int defaultWorksheetIndex = 0;
    
    // Λαμβάνει το φύλλο εργασίας δεδομένων του διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Διαγράφει τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Προσθέτει νέες σειρές
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Προσθέτει νέες κατηγορίες
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Παίρνει την πρώτη σειρά του διαγράμματος
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Τώρα γεμίζει τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Ορίζει το χρώμα γεμίσματος για τη σειρά
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Παίρνει τη δεύτερη σειρά του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Γεμίζει τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ορίζει το χρώμα γεμίσματος για τη σειρά
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Δημιουργία προσαρμοσμένων ετικετών για κάθε κατηγορία για τη νέα σειρά
    // Ορίζει την πρώτη ετικέτα να εμφανίζει το όνομα της κατηγορίας
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Εμφανίζει την τιμή για την τρίτη ετικέτα
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Saves the presentation with chart
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία διάσπαρτων διαγραμμάτων**

Τα διάσπαρτα διαγράμματα (γνωστά επίσης ως scatter plots ή διαγράμματα x‑y) χρησιμοποιούνται συχνά για την αναζήτηση μοτίβων ή την απόδειξη συσχετίσεων μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε διάσπαρτο διάγραμμα όταν:

* έχετε ζεύγος αριθμητικών δεδομένων
* έχετε δύο μεταβλητές που ταιριάζουν καλά μεταξύ τους
* θέλετε να καθορίσετε εάν δύο μεταβλητές είναι σχετικές
* έχετε μια ανεξάρτητη μεταβλητή που έχει πολλαπλές τιμές για μια εξαρτημένη μεταβλητή

1. Ακολουθήστε τα βήματα στην ενότητα [Create Clustered Column Charts](#create-clustered-column-charts) .
2. Στο τρίτο βήμα, προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον τύπο διαγράμματος ως έναν από τους εξής:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Αντιπροσωπεύει ένα διάσπαρτο διάγραμμα._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Αντιπροσωπεύει ένα διάσπαρτο διάγραμμα συνδεδεμένο με καμπύλες, με δείκτες δεδομένων._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Αντιπροσωπεύει ένα διάσπαρτο διάγραμμα συνδεδεμένο με καμπύλες, χωρίς δείκτες δεδομένων._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Αντιπροσωπεύει ένα διάσπαρτο διάγραμμα συνδεδεμένο με ευθείες γραμμές, με δείκτες δεδομένων._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Αντιπροσωπεύει ένα διάσπαρτο διάγραμμα συνδεδεμένο με ευθείες γραμμές, χωρίς δείκτες δεδομένων._

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα διάσπαρτο διάγραμμα με διαφορετικούς δείκτες για κάθε σειρά:

```java
import com.aspose.slides.*;

// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);

    // Δημιουργεί το προεπιλεγμένο διάγραμμα
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Λαμβάνει το δείκτη του προεπιλεγμένου φύλλου δεδομένων του διαγράμματος
    int defaultWorksheetIndex = 0;
    
    // Λαμβάνει το φύλλο δεδομένων του διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Διαγράφει τις σειρές επίδειξης
    chart.getChartData().getSeries().clear();
    
    // Προσθέτει νέες σειρές
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Παίρνει την πρώτη σειρά του διαγράμματος
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Προσθέτει ένα νέο σημείο (1:3) στη σειρά
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Προσθέτει ένα νέο σημείο (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Αλλάζει τον τύπο της σειράς
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Αλλάζει το δείκτη (marker) της σειράς του διαγράμματος
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Παίρνει τη δεύτερη σειρά του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Προσθέτει ένα νέο σημείο (5:2) εκεί
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Προσθέτει ένα νέο σημείο (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Προσθέτει ένα νέο σημείο (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Προσθέτει ένα νέο σημείο (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Αλλάζει το δείκτη (marker) της σειράς του διαγράμματος
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία κυκλικών διαγραμμάτων**

Τα κυκλικά διαγράμματα είναι ιδανικά για την παρουσίαση της σχέσης μέρος‑σε‑συνολικό σε δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγορικές ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιλαμβάνουν πολλά τμήματα ή ετικέτες, ίσως θελήσετε να χρησιμοποιήσετε ένα ραβδόγραμμα αντί αυτού.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType.Pie](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#Pie) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος [IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές.
8. Προσθήκη νέων σημείων στο διάγραμμα και εφαρμογή προσαρμοσμένων χρωμάτων για τους τομείς του κυκλικού διαγράμματος.
9. Ορισμός ετικετών για τις σειρές.
10. Ενεργοποίηση γραμμών οδηγών για τις ετικέτες των σειρών.
11. Ορισμός γωνίας περιστροφής για τους τομείς του κυκλικού διαγράμματος.
12. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα κυκλικό διάγραμμα:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Ορίζει τον τίτλο του διαγράμματος
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Ορίζει το δείκτη για το φύλλο δεδομένων του διαγράμματος
    int defaultWorksheetIndex = 0;
    
    // Λαμβάνει το φύλλο εργασίας δεδομένων του διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Διαγράφει τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Προσθέτει νέες κατηγορίες
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Προσθέτει νέες σειρές
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Γεμίζει τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Δεν λειτουργεί στη νέα έκδοση
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Ορίζει το περίγραμμα του τομέα
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Ορίζει το περίγραμμα του τομέα
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Ορίζει το περίγραμμα του τομέα
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Δημιουργεί προσαρμοσμένες ετικέτες για κάθε κατηγορία της νέας σειράς
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Εμφανίζει γραμμές οδηγού για το διάγραμμα
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Ορίζει τη γωνία περιστροφής για τους τομείς του κυκλικού διαγράμματος
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Αποθηκεύει την παρουσίαση με ένα διάγραμμα
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία διαγραμμάτων γραμμής**

Τα διαγράμματα γραμμής (γνωστά επίσης ως γραφήματα) είναι ιδανικά σε καταστάσεις όπου θέλετε να δείξετε αλλαγές σε τιμές με το χρόνο. Χρησιμοποιώντας ένα διάγραμμα γραμμής, μπορείτε να συγκρίνετε μεγάλο όγκο δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις με την πάροδο του χρόνου, να επισημάνετε ανωμαλίες σε σειρές δεδομένων και πολλά άλλα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType.Line](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#Line) .
1. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα διάγραμμα γραμμής:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Από προεπιλογή, τα σημεία σε ένα διάγραμμα γραμμής ενώνονται με συνεχή ευθείες γραμμές. Εάν θέλετε τα σημεία να συνδέονται με παύλες, μπορείτε να καθορίσετε τον προτιμώμενο τύπο παύλας ως εξής:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία διαγραμμάτων δέντρου χάρτη**

Τα διαγράμματα δέντρου χάρτη είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να εμφανίσετε το σχετικό μέγεθος των κατηγοριών δεδομένων και να τραβήξετε γρήγορα την προσοχή σε στοιχεία που είναι μεγάλοι συντελεστές εντός κάθε κατηγορίας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType.Treemap](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#Treemap) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος [IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές.
8. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα διάγραμμα δέντρου χάρτη:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //κλάδος 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //κλάδος 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία διαγραμμάτων μετοχών**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#OpenHighLowClose) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος [IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές.
8. Καθορίστε τη μορφή των γραμμών υψηλού‑χαμηλού.
9. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα διάγραμμα μετοχών:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία διαγραμμάτων box‑and‑whisker**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#BoxAndWhisker) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος [IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές.
8. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα διάγραμμα box‑and‑whisker:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία διαγραμμάτων χωνί**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType.Funnel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#Funnel) .
4. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα διάγραμμα χωνί:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία διαγραμμάτων ηλιακού άνθους**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType.Sunburst](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#Sunburst) .
4. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα διάγραμμα ηλιακού άνθους:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //κλάδος 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //κλάδος 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία ιστογραμμάτων**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType.Histogram](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#Histogram) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος [IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα ιστόγραμμα:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία διαγραμμάτων ραντάρ**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον προτιμώμενο τύπο διαγράμματος ([ChartType.Radar](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#Radar) σε αυτήν την περίπτωση).
4. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα διάγραμμα ραντάρ:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία διαγραμμάτων πολλαπλών κατηγοριών**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType.ClusteredColumn](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/#ClusteredColumn) .
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος [IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές.
8. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα διάγραμμα πολλαπλών κατηγοριών:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Αποθήκευση παρουσίασης με διάγραμμα
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία διαγραμμάτων χάρτη**

Τα διαγράμματα χάρτη οπτικοποιούν γεωγραφικά δεδομένα και βοηθούν στη σύγκριση τιμών ανά περιοχή.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα διάγραμμα χάρτη:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία συνδυαστικών διαγραμμάτων**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγράμματος σε ένα μόνο γράφημα. Αυτό το διάγραμμα σας επιτρέπει να τονίσετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![Το συνδυαστικό διάγραμμα](combination_chart.png)

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε το παραπάνω συνδυαστικό διάγραμμα σε μια παρουσίαση PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Ορίζει τον τίτλο του διαγράμματος.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Ορίζει το υπόμνημα του διαγράμματος.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Διαγράφει τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Προσθέτει νέες κατηγορίες.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Προσθέτει την πρώτη σειρά.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Ορίζει τον οριζόντιο άξονα.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Ορίζει τον κατακόρυφο άξονα.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Ορίζει το χρώμα των κύριων γραμμών πλέγματος του κατακόρυφου άξονα.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Ορίζει τον δευτερεύοντα οριζόντιο άξονα.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Ορίζει τον δευτερεύοντα κατακόρυφο άξονα.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **Ενημέρωση διαγραμμάτων**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα που θέλετε να ενημερώσετε.
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
5. Τροποποιήστε τις σειρές δεδομένων του διαγράμματος αλλάζοντας τις τιμές των σειρών.
6. Προσθέστε μια νέα σειρά και συμπληρώστε τα δεδομένα της.
7. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να ενημερώσετε ένα διάγραμμα:

```java
import com.aspose.slides.*;

// Ανοίγει την παρουσίαση που περιέχει το διάγραμμα προς ενημέρωση
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Λήψη του διαγράμματος από τη διαφάνεια
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος
    int defaultWorksheetIndex = 0;

    // Λήψη του φύλλου εργασίας δεδομένων του διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Αλλαγή του ονόματος κατηγορίας του διαγράμματος
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Λήψη της πρώτης σειράς του διαγράμματος
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Τώρα ενημέρωση δεδομένων σειράς
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Τροποποίηση του ονόματος σειράς
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Λήψη της δεύτερης σειράς του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1);

    // Τώρα ενημέρωση δεδομένων σειράς
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Τροποποίηση του ονόματος σειράς
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Προσθήκη νέας σειράς
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Λήψη της τρίης σειράς του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(2);

    // Τώρα πλήρωση δεδομένων σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Αποθήκευση της παρουσίασης με το διάγραμμα
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός περιοχής δεδομένων για διάγραμμα**

Για να ορίσετε την περιοχή δεδομένων ενός διαγράμματος, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα.
2. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
3. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Πρόσβαση στα δεδομένα του διαγράμματος και ορισμός της περιοχής.
5. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε την περιοχή δεδομένων για ένα διάγραμμα:

```java
import com.aspose.slides.*;

// Ανοίγει την παρουσίαση που περιέχει το διάγραμμα
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Χρήση προεπιλεγμένων δεικτών σε διαγράμματα**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό σύμβολο δείκτη.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε αυτόματα τον δείκτη σειράς διαγράμματος:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Λήψη της δεύτερης σειράς του διαγράμματος
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Τώρα γεμίζει τα δεδομένα της σειράς
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζονται από το Aspose.Slides;**

Το Aspose.Slides υποστηρίζει ένα ευρύ φάσμα [chart types](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/), συμπεριλαμβανομένων των ραβδογράμμων, γραμμών, κυκλικών, περιοχικών, διάσπαρτων, ιστογραμμάτων, ραντάρ και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διαγράμματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω ένα νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε ένα διάγραμμα, πρώτα δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) , ανακτήστε τη ζητούμενη διαφάνεια χρησιμοποιώντας το δείκτη της και, στη συνέχεια, καλέστε τη μέθοδο για προσθήκη διαγράμματος, καθορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος αποκτώντας πρόσβαση στο βιβλίο εργασίας δεδομένων του ([IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες και, έπειτα, προσθέτοντας τα προσαρμοσμένα δεδομένα σας. Αυτό σας επιτρέπει να ανανεώσετε το διάγραμμα ώστε να αντικατοπτρίζει τα πιο πρόσφατα δεδομένα.

**Μπορεί να προσαρμοστεί η εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα [formatting elements](/slides/el/androidjava/chart-entities/) ώστε να προσαρμόσετε την εμφάνιση του διαγράμματος στις συγκεκριμένες απαιτήσεις σχεδίασής σας.