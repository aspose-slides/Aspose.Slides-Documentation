---
title: Διαχείριση δεικτών δεδομένων διαγράμματος σε παρουσιάσεις στο Android
linktitle: Δείκτης δεδομένων
type: docs
url: /el/androidjava/chart-data-marker/
keywords:
- διάγραμμα
- σημείο δεδομένων
- δείκτης
- επιλογές δείκτη
- μέγεθος δείκτη
- τύπος γεμίσματος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσαρμόστε τους δείκτες δεδομένων διαγράμματος στο Aspose.Slides για Android, ενισχύοντας την επίδραση της παρουσίασης σε μορφές PPT και PPTX με σαφή παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με δείκτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να αποκτήσετε πρόσβαση σε μια σειρά και στα σημεία δεδομένων της, να εφαρμόσετε γεμίσματα εικόνας σε δείκτες σε επίπεδο σημείου δεδομένων, να προσαρμόσετε το μέγεθος του δείκτη και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης σημειώνει ότι διαθέσιμες είναι οι προεπιλεγμένες μορφές δεικτών μέσω της απαρίθμησης `MarkerStyleType` και ότι η εμφάνιση των δεικτών διατηρείται κατά την εξαγωγή διαγραμμάτων σε μορφές raster ή SVG.

## **Ορισμός επιλογών δεικτών διαγράμματος**
Οι δείκτες μπορούν να οριστούν σε σημεία δεδομένων του διαγράμματος μέσα σε συγκεκριμένες σειρές. Για να ορίσετε επιλογές δεικτών διαγράμματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
- Δημιουργία του προεπιλεγμένου διαγράμματος.
- Ορίστε την εικόνα.
- Αποκτήστε την πρώτη σειρά του διαγράμματος.
- Προσθέστε νέο σημείο δεδομένων.
- Γράψτε την παρουσίαση στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει τις επιλογές δεικτών του διαγράμματος σε επίπεδο σημείων δεδομένων.

```java
// Δημιουργία κενής παρουσίασης
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Δημιουργία προεπιλεγμένου διαγράμματος
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Λήψη του προεπιλεγμένου ευρετηρίου φύλλου εργασίας δεδομένων διαγράμματος
    int defaultWorksheetIndex = 0;
    
    // Λήψη του φύλλου εργασίας δεδομένων διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Διαγραφή σειράς demo
    chart.getChartData().getSeries().clear();
    
    // Προσθήκη νέας σειράς
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Φόρτωση εικόνας 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Φόρτωση εικόνας 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Λήψη της πρώτης σειράς διαγράμματος
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

## **Συχνές ερωτήσεις**

**Ποιες μορφές δεικτών είναι διαθέσιμες από προεπιλογή;**

Διαθέσιμες είναι οι προεπιλεγμένες μορφές (κύκλος, τετράγωνο, ρόμβος, τρίγωνο κ.λπ.); η λίστα ορίζεται από την κλάση [MarkerStyleType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markerstyletype/). Εάν χρειάζεστε μη προεπιλεγμένη μορφή, χρησιμοποιήστε έναν δείκτη με γεμιστό εικόνας για να προσομοιώσετε προσαρμοστικά γραφικά.

**Διατηρούνται οι δείκτες κατά την εξαγωγή ενός διαγράμματος σε εικόνα ή SVG;**

Ναι. Κατά την απόδοση διαγραμμάτων σε [raster formats](/slides/el/androidjava/convert-powerpoint-to-png/) ή την αποθήκευση [shapes as SVG](/slides/el/androidjava/render-a-slide-as-an-svg-image/), οι δείκτες διατηρούν την εμφάνιση και τις ρυθμίσεις τους, συμπεριλαμβανομένων του μεγέθους, του γεμίσματος και του περιγράμματος.