---
title: Διαχείριση Δεικτών Δεδομένων Διαγράμματος σε Παρουσιάσεις με Java
linktitle: Δείκτης Δεδομένων
type: docs
url: /el/java/chart-data-marker/
keywords:
- διάγραμμα
- σημείο δεδομένων
- δείκτης
- επιλογές δείκτη
- μέγεθος δείκτη
- τύπος γεμίσματος
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσαρμόζετε τους δείκτες δεδομένων διαγράμματος στο Aspose.Slides για Java, ενισχύοντας την επίδραση των παρουσιάσεων σε μορφές PPT και PPTX με σαφή παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με τους δείκτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να έχετε πρόσβαση σε μια σειρά και στα σημεία δεδομένων της, να εφαρμόσετε γεμίσματα εικόνας στους δείκτες σε επίπεδο σημείου δεδομένων, να προσαρμόσετε το μέγεθος του δείκτη και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης σημειώνει ότι τα τυπικά σχήματα δεικτών διατίθενται μέσω της απαρίθμησης `MarkerStyleType` και ότι η εμφάνιση του δείκτη διατηρείται κατά την εξαγωγή διαγραμμάτων σε μορφές raster ή SVG.

## **Ορισμός Επιλογών Δείκτη Διαγράμματος**
Οι δείκτες μπορούν να οριστούν σε σημεία δεδομένων διαγράμματος μέσα σε συγκεκριμένες σειρές. Για να ορίσετε επιλογές δείκτη διαγράμματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
- Δημιουργήστε το προεπιλεγμένο διάγραμμα.
- Ορίστε την εικόνα.
- Πάρτε την πρώτη σειρά διαγράμματος.
- Προσθέστε νέο σημείο δεδομένων.
- Γράψτε την παρουσίαση στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει τις επιλογές δείκτη διαγράμματος σε επίπεδο σημείων δεδομένων.

```java
// Δημιουργία κενής παρουσίασης
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Δημιουργία προεπιλεγμένου διαγράμματος
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Λήψη του ευρετηρίου του προεπιλεγμένου φύλλου εργασίας δεδομένων διαγράμματος
    int defaultWorksheetIndex = 0;
    
    // Λήψη του φύλλου εργασίας δεδομένων διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Διαγραφή σειράς επίδειξης
    chart.getChartData().getSeries().clear();
    
    // Προσθήκη νέας σειράς
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Φόρτωση εικόνας 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Φόρτωση εικόνας 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Πάρτε την πρώτη σειρά διαγράμματος
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Προσθήκη νέου σημείου (1:3) εκεί.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Αλλαγή δείκτη σειράς διαγράμματος
    series.getMarker().setSize(15);
    
    // Αποθήκευση παρουσίασης με διάγραμμα
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Ποια σχήματα δεικτών είναι διαθέσιμα εκτός κουτιού;**

Τα τυπικά σχήματα είναι διαθέσιμα (κύκλος, τετράγωνο, διαμάντι, τρίγωνο κ.λπ.); η λίστα ορίζεται από την κλάση [MarkerStyleType](https://reference.aspose.com/slides/el/java/com.aspose.slides/markerstyletype/). Εάν χρειάζεστε ένα μη τυπικό σχήμα, χρησιμοποιήστε έναν δείκτη με γέμισμα εικόνας για την προσομοίωση προσαρμοστικών οπτικών στοιχείων.

**Διατηρούνται οι δείκτες όταν εξάγετε ένα διάγραμμα σε εικόνα ή SVG;**

Ναι. Κατά την απόδοση διαγραμμάτων σε [raster formats](/slides/el/java/convert-powerpoint-to-png/) ή αποθηκεύοντας [shapes as SVG](/slides/el/java/render-a-slide-as-an-svg-image/), οι δείκτες διατηρούν την εμφάνισή τους και τις ρυθμίσεις, συμπεριλαμβανομένου του μεγέθους, του γεμίσματος και του περιγράμματος.