---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε Java
linktitle: Δημιουργία ή Ενημέρωση Διαγραμμάτων
type: docs
weight: 10
url: /el/java/create-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- scatter διάγραμμα
- διάγραμμα πίτας
- γραμμικό διάγραμμα
- διάγραμμα χάρτη δέντρου
- διάγραμμα μετοχών
- διάγραμμα box and whisker
- διάγραμμα χωνιού
- διάγραμμα ηλιακής έκρηξης
- ιστόγραμμα
- διάγραμμα ραδάρ
- πολυκατηγορικό διάγραμμα
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργία και προσαρμογή διαγραμμάτων σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Java. Προσθήκη, μορφοποίηση και επεξεργασία διαγραμμάτων με πρακτικά παραδείγματα κώδικα σε Java."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε διαγράμματα χρησιμοποιώντας το Aspose.Slides. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει με τις συγκεκριμένες απαιτήσεις σχεδίασής σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα εικονογραφούν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος έως τη διαμόρφωση σειρών, αξόνων και υπομνημάτων. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε μια σταθερή κατανόηση του πώς να ενσωματώσετε δυναμική δημιουργία διαγραμμάτων στις εφαρμογές σας, διευκολύνοντας τη διαδικασία δημιουργίας παρουσιάσεων με δεδομένα.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα τα δεδομένα και να αποκομίζουν γνώσεις, που μπορεί να μην είναι άμεσα εμφανείς από έναν πίνακα ή ένα υπολογιστικό φύλλο. 


**Γιατί να δημιουργήσετε διαγράμματα;**

Χρησιμοποιώντας διαγράμματα, μπορείτε να

* συγκεντρώνετε, συμπτυπώνετε ή συνοψίζετε μεγάλες ποσότητες δεδομένων σε μία μοναδική διαφάνεια σε μια παρουσίαση
* αποκαλύπτετε πρότυπα και τάσεις στα δεδομένα
* συμπεραίνετε την κατεύθυνση και την ορμή των δεδομένων με την πάροδο του χρόνου ή σε σχέση με συγκεκριμένη μονάδα μέτρησης 
* εντοπίζετε εκτός ορίων τιμές, αποκλίσεις, σφάλματα, ανούσια δεδομένα κ.λπ. 
* επικοινωνείτε ή παρουσιάζετε σύνθετα δεδομένα

Στο PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας εισαγωγής, η οποία παρέχει πρότυπα για το σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε κανονικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους διαγραμμάτων) και προσαρμοσμένα διαγράμματα. 

{{% alert color="primary" %}} 

Για να δημιουργήσετε διαγράμματα, το Aspose.Slides παρέχει την κλάση [ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartType). Τα πεδία αυτής της κλάσης αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων. 

{{% /alert %}} 

### **Δημιουργία Κανονικών Διαγραμμάτων**

_Βήματα: Δημιουργία Διαγράμματος_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Διαγράμματος σε Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Βήματα:</em> Δημιουργία Παρουσίασης Διαγράμματος σε Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Διαγράμματος σε Java</strong></a>

_Βήματα Κώδικα:_

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον προτιμώμενο τύπο διαγράμματος. 
4. Προσθέστε έναν τίτλο για το διάγραμμα. 
5. Πρόσβαση στο φύλλο εργασίας δεδομένων του διαγράμματος.
6. Καθαρίστε όλες τις προεπιλεγμένες σειρές και κατηγορίες.
7. Προσθέστε νέες σειρές και κατηγορίες.
8. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
9. Προσθέστε χρώμα γεμίσματος για τις σειρές του διαγράμματος.
10. Προσθέστε ετικέτες για τις σειρές του διαγράμματος. 
11. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα κανονικό διάγραμμα:

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Προσθήκη διαγράμματος με τα προεπιλεγμένα δεδομένα του
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Ορίζει τον τίτλο του διαγράμματος
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Ορίζει την πρώτη σειρά να εμφανίζει τιμές
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Ορίζει τον δείκτη για το φύλλο δεδομένων του διαγράμματος
    int defaultWorksheetIndex = 0;
    
    // Παίρνει το φύλλο εργασίας δεδομένων του διαγράμματος
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
    
    // Ανοίγει την πρώτη σειρά του διαγράμματος
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Τώρα γεμίζει τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Ορίζει το χρώμα γεμίσματος για τη σειρά
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Ανοίγει τη δεύτερη σειρά του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Γεμίζει τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ορίζει το χρώμα γεμίσματος για τη σειρά
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Δημιουργεί προσαρμοσμένες ετικέτες για κάθε κατηγορία της νέας σειράς
    // Ορίζει την πρώτη ετικέτα να εμφανίζει το όνομα της κατηγορίας
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Εμφανίζει τιμή στην τρίτη ετικέτα
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Αποθηκεύει την παρουσίαση με το διάγραμμα
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία Διαγραμμάτων Scatter**

Τα διαγράμματα scatter (επίσης γνωστά ως scatter plots ή γραφήματα x‑y) χρησιμοποιούνται συχνά για τον εντοπισμό προτύπων ή την απεικόνιση συσχετισμών μεταξύ δύο μεταβλητών. 

Μπορείτε να θέλετε να χρησιμοποιήσετε ένα διάγραμμα scatter όταν 

* έχετε αριθμητικά δεδομένα σε ζεύγη
* έχετε 2 μεταβλητές που συνδυάζονται καλά
* θέλετε να προσδιορίσετε αν 2 μεταβλητές σχετίζονται
* έχετε μια ανεξάρτητη μεταβλητή που έχει πολλαπλές τιμές για μια εξαρτημένη μεταβλητή

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Βήματα:</em> Δημιουργία Scatter Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Scatter Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Scatter Διαγράμματος σε Java</strong></a>

1. Ακολουθήστε τα βήματα που αναφέρονται παραπάνω στα [Δημιουργία Κανονικών Διαγραμμάτων](#creating-normal-charts)
2. Στο τρίτο βήμα, Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον τύπο διαγράμματος ως ένα από τα ακόλουθα
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Αντιπροσωπεύει διάγραμμα Scatter με δείκτες._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Αντιπροσωπεύει διάγραμμα Scatter συνδεδεμένο με καμπύλες, με δείκτες δεδομένων._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Αντιπροσωπεύει διάγραμμα Scatter συνδεδεμένο με καμπύλες, χωρίς δείκτες δεδομένων._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Αντιπροσωπεύει διάγραμμα Scatter συνδεδεμένο με ευθείες γραμμές, με δείκτες δεδομένων._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Αντιπροσωπεύει διάγραμμα Scatter συνδεδεμένο με ευθείες γραμμές, χωρίς δείκτες δεδομένων._

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε διαγράμματα scatter με διαφορετικές σειρές δεικτών: 

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);

    // Δημιουργεί το προεπιλεγμένο διάγραμμα
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Παίρνει το ευρετήριο του προεπιλεγμένου φύλλου δεδομένων διαγράμματος
    int defaultWorksheetIndex = 0;
    
    // Παίρνει το φύλλο εργασίας δεδομένων του διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Διαγράφει τις δοκιμαστικές σειρές
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
    
    // Αλλάζει τον δείκτη της σειράς του διαγράμματος
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
    
    // Αλλάζει τον δείκτη της σειράς του διαγράμματος
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Δημιουργία Δικτυωτών Διαγραμμάτων (Pie)**

Τα δικτυωτά διαγράμματα είναι η καλύτερη επιλογή για την εμφάνιση της σχέσης μέρος‑προς‑ολό σε δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγορηματικές ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά μέρη ή ετικέτες, ίσως θελήσετε να χρησιμοποιήσετε ένα ράβδο διαγράφημα αντίγ.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Βήματα:</em> Δημιουργία Pie Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Pie Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Pie Διαγράμματος σε Java</strong></a>

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο (σε αυτήν την περίπτωση, [ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartType).Pie).
4. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του [IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataWorkbook).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
8. Προσθέστε νέες τιμές για τα τμήματα του διαγράμματος και προσαρμόστε χρώματα για τους τομείς του pie.
9. Ορίστε ετικέτες για τις σειρές.
10. Ορίστε γραμμές οδηγού για τις ετικέτες των σειρών.
11. Ορίστε τη γωνία περιστροφής για τις διαφάνειες του pie διαγράμματος.
12. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα pie διάγραμμα:

```java
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
    
    // Ορίζει την πρώτη σειρά να εμφανίζει τιμές
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Ορίζει το ευρετήριο για το φύλλο δεδομένων του διαγράμματος
    int defaultWorksheetIndex = 0;
    
    // Αποκτά το φύλλο εργασίας δεδομένων του διαγράμματος
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
    
    // Ορίζει την γωνία περιστροφής για τους τομείς του pie διαγράμματος
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Αποθηκεύει την παρουσίαση με διάγραμμα
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία Γραμμικών Διαγραμμάτων**

Τα γραμμικά διαγράμματα (επίσης γνωστά ως γραφικές παραστάσεις) είναι κατάλληλα όταν θέλετε να δείξετε αλλαγές σε τιμές με την πάροδο του χρόνου. Χρησιμοποιώντας ένα γραμμικό διάγραμμα, μπορείτε να συγκρίνετε πολλά δεδομένα ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις στο χρόνο, να επισημαίνετε ανωμαλίες σε σειρές δεδομένων κ.λπ.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο (σε αυτήν την περίπτωση, `ChartType.Line`).
1. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του IChartDataWorkbook.
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα γραμμικό διάγραμμα:

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Από προεπιλογή, τα σημεία σε ένα γραμμικό διάγραμμα ενώνονται με ευθείες συνεχόμενες γραμμές. Εάν θέλετε τα σημεία να ενώνονται με διακεκομμένες γραμμές, μπορείτε να ορίσετε τον προτιμώμενο τύπο διακεκομμένων γραμμών ως εξής:

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **Δημιουργία Διαγραμμάτων Tree Map**

Τα διαγράμματα Tree Map είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών δεδομένων και (ταυτόχρονα) να τραβήξετε την προσοχή σε στοιχεία που συνεισφέρουν σημαντικά σε κάθε κατηγορία. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Βήματα:</em> Δημιουργία Tree Map Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Tree Map Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Tree Map Διαγράμματος σε Java</strong></a>

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο (σε αυτήν την περίπτωση, [ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartType).TreeMap).
4. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του [IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataWorkbook).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα tree map διάγραμμα:

```java
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

### **Δημιουργία Διαγραμμάτων Stock**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Βήματα:</em> Δημιουργία Stock Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Stock Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Stock Διαγράμματος σε Java</strong></a>

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο ([ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartType).OpenHighLowClose).
4. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του [IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataWorkbook).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
8. Καθορίστε τη μορφή HiLowLines.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX

Δείγμα κώδικα Java που χρησιμοποιείται για τη δημιουργία ενός stock διαγράμματος:

```java
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

### **Δημιουργία Διαγραμμάτων Box and Whisker**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Βήματα:</em> Δημιουργία Box and Whisker Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Box and Whisker Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Box and Whisker Διαγράμματος σε Java</strong></a>

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο ([ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartType).BoxAndWhisker).
4. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του [IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataWorkbook).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα box and whisker διάγραμμα:

```java
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

### **Δημιουργία Διαγραμμάτων Funnel**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Βήματα:</em> Δημιουργία Funnel Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Funnel Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Funnel Διαγράμματος σε Java</strong></a>


1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο ([ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartType).Funnel).
4. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX

Ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα funnel διάγραμμα:

```java
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

### **Δημιουργία Διαγραμμάτων Sunburst**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Βήματα:</em> Δημιουργία Sunburst Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Sunburst Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Sunburst Διαγράμματος σε Java</strong></a>

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο (σε αυτήν την περίπτωση, [ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartType).sunburst).
4. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα sunburst διάγραμμα:

```java
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

### **Δημιουργία Διαγραμμάτων Ιστόγραμμα (Histogram)**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Βήματα:</em> Δημιουργία Histogram Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Histogram Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Histogram Διαγράμματος σε Java</strong></a>

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο ([ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartType).Histogram).
4. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του [IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataWorkbook).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα histogram διάγραμμα:

```java
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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία Διαγραμμάτων Radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Βήματα:</em> Δημιουργία Radar Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Radar Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Radar Διαγράμματος σε Java</strong></a>

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον προτιμώμενο τύπο διαγράμματος (`ChartType.Radar` σε αυτήν την περίπτωση).
4. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα radar διάγραμμα:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία Πολυ-Κατηγορικών Διαγραμμάτων**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Βήματα:</em> Δημιουργία Πολυ-Κατηγορικού Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Πολυ-Κατηγορικού Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Πολυ-Κατηγορικού Διαγράμματος σε Java</strong></a>

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο ([ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartType).ClusteredColumn).
4. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του [IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataWorkbook).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα πολυκατηγορικό διάγραμμα:

```java
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

### **Δημιουργία Διαγραμμάτων Χάρτη**

Ένα διάγραμμα χάρτη είναι μια οπτικοποίηση περιοχής που περιέχει δεδομένα. Τα διαγράμματα χάρτη είναι ιδανικά για τη σύγκριση δεδομένων ή τιμών μεταξύ γεωγραφικών περιοχών.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Βήματα:</em> Δημιουργία Map Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Map Διαγράμματος σε Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Βήματα:</em> Δημιουργία PowerPoint Παρουσίασης Map Διαγράμματος σε Java</strong></a>

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα map διάγραμμα:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Δημιουργία Συνδυαστικών Διαγραμμάτων**

Ένα συνδυαστικό διάγραμμα (ή combo διάγραμμα) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα ενιαίο γράφημα. Αυτό το διάγραμμα σάς επιτρέπει να επισημάνετε, συγκρίνετε ή εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![The combination chart](combination_chart.png)

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε το συνδυαστικό διάγραμμα που φαίνεται παραπάνω σε μια παρουσίαση PowerPoint:

```java
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

    // Ορίζει τον κάθετο άξονα.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Ορίζει το χρώμα των κύριων γραμμών πλέγματος του κάθετου άξονα.
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

    // Ορίζει τον δευτερεύοντα κάθετο άξονα.
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

## **Ενημέρωση Διαγραμμάτων**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Βήματα:</em> Ενημέρωση PowerPoint Διαγράμματος σε Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Βήματα:</em> Ενημέρωση Παρουσίασης Διαγράμματος σε Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Βήματα:</em> Ενημέρωση PowerPoint Παρουσίασης Διαγράμματος σε Java</strong></a>

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα που θέλετε να ενημερώσετε. 
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας τον δείκτη της.
3. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Πρόσβαση στο φύλλο εργασίας δεδομένων του διαγράμματος.
5. Τροποποιήστε τα δεδομένα των σειρών του διαγράμματος αλλάζοντας τις τιμές των σειρών.
6. Προσθέστε μια νέα σειρά και συμπληρώστε τα δεδομένα της.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να ενημερώσετε ένα διάγραμμα:

```java
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Λήψη διαγράμματος με προεπιλεγμένα δεδομένα
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Ορισμός του ευρετηρίου του φύλλου δεδομένων του διαγράμματος
    int defaultWorksheetIndex = 0;

    // Λήψη του φύλλου εργασίας δεδομένων του διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Αλλαγή του ονόματος κατηγορίας του διαγράμματος
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Λήψη της πρώτης σειράς του διαγράμματος
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Τώρα ενημέρωση των δεδομένων της σειράς
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Τροποποίηση του ονόματος σειράς
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Λήψη της δεύτερης σειράς του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1);

    // Τώρα ενημέρωση των δεδομένων της σειράς
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Τροποποίηση του ονόματος σειράς
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Τώρα, προσθήκη νέας σειράς
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Λήψη της τρίτης σειράς του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(2);

    // Τώρα γεμίζοντας τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Αποθήκευση παρουσίασης με διάγραμμα
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Εύρους Δεδομένων για Διάγραμμα**

Για να ορίσετε το εύρος δεδομένων για ένα διάγραμμα, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα.
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Πρόσβαση στα δεδομένα του διαγράμματος και ορίστε το εύρος.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε το εύρος δεδομένων για ένα διάγραμμα:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Χρήση Προεπιλεγμένων Δεικτών σε Διαγράμματα**
Όταν χρησιμοποιείτε έναν προεπιλεγμένο δείκτη σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει διαφορετικό προεπιλεγμένο σύμβολο δείκτη αυτόματα.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε αυτόματα έναν δείκτη σειράς διαγράμματος:

```java
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

    // Τώρα γεμίζοντας τα δεδομένα της σειράς
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

## **Συχνές Ερωτήσεις (FAQ)**

**Τι τύποι διαγραμμάτων υποστηρίζει το Aspose.Slides;**

Το Aspose.Slides υποστηρίζει μια ευρεία γκάμα [τύπων διαγραμμάτων](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/), συμπεριλαμβανομένων bar, line, pie, area, scatter, histogram, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διαγράμματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω ένα νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε ένα διάγραμμα, πρώτα δημιουργείτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) , ανακτάτε τη ζητούμενη διαφάνεια χρησιμοποιώντας τον δείκτη της και στη συνέχεια καλείτε τη μέθοδο για προσθήκη διαγράμματος, καθορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος προσπελαύνοντας το βιβλίο εργασίας δεδομένων του ([IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες και στη συνέχεια προσθέτοντας τα δικά σας προσαρμοσμένα δεδομένα. Αυτό σας επιτρέπει να ανανεώσετε το διάγραμμα ώστε να αντανακλά τα πιο πρόσφατα δεδομένα.

**Είναι δυνατόν να προσαρμόσω την εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα [στοιχεία μορφοποίησης](/slides/el/java/chart-entities/) ώστε να προσαρμόσετε την εμφάνιση του διαγράμματος στις συγκεκριμένες απαιτήσεις του σχεδίου σας.