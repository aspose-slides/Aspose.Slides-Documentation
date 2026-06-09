---
title: Διαχείριση Δεικτών Δεδομένων Διαγράμματος σε Παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Δείκτης Δεδομένων
type: docs
url: /el/nodejs-java/chart-data-marker/
keywords:
- διάγραμμα
- σημείο δεδομένων
- δείκτης
- επιλογές δεικτη
- μέγεθος δείκτη
- τύπος γεμίσματος
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσαρμόζετε τους δείκτες δεδομένων διαγράμματος στο Aspose.Slides για Node.js, ενισχύοντας την επίδραση της παρουσίασης σε μορφές PPT και PPTX με σαφή παραδείγματα κώδικα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με δείκτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσπελάσετε μια σειρά και τα σημεία δεδομένων της, να εφαρμόσετε γεμίσματα εικόνας σε δείκτες σε επίπεδο σημείου δεδομένων, να προσαρμόσετε το μέγεθος του δείκτη και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης σημειώνει ότι τα τυπικά σχήματα δεικτών είναι διαθέσιμα μέσω της απαρίθμησης `MarkerStyleType` και ότι η εμφάνιση του δείκτη διατηρείται κατά την εξαγωγή διαγραμμάτων σε μορφές raster ή SVG.

## **Ορισμός Επιλογών Δεικτών Διαγράμματος**

Οι δείκτες μπορούν να οριστούν σε σημεία δεδομένων διαγράμματος μέσα σε συγκεκριμένες σειρές. Για να ορίσετε τις επιλογές δεικτών διαγράμματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
- Δημιουργία του προεπιλεγμένου διαγράμματος.
- Ορίστε την εικόνα.
- Αποκτήστε την πρώτη σειρά διαγράμματος.
- Προσθέστε νέο σημείο δεδομένων.
- Γράψτε την παρουσίαση στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει τις επιλογές δεικτών διαγράμματος σε επίπεδο σημείων δεδομένων.

```javascript
    // Δημιουργία κενής παρουσίασης
    var pres = new aspose.slides.Presentation();
    try {
        // Πρόσβαση στην πρώτη διαφάνεια
        var slide = pres.getSlides().get_Item(0);
        // Δημιουργία προεπιλεγμένου διαγράμματος
        var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
        // Λήψη του προεπιλεγμένου ευρετηρίου φύλλου εργασίας δεδομένων διαγράμματος
        var defaultWorksheetIndex = 0;
        // Λήψη του φύλλου εργασίας δεδομένων διαγράμματος
        var fact = chart.getChartData().getChartDataWorkbook();
        // Διαγραφή σειράς demo
        chart.getChartData().getSeries().clear();
        // Προσθήκη νέας σειράς
        chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
        // Φόρτωση εικόνας 1
        var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
        // Φόρτωση εικόνας 2
        var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
        // Λήψη της πρώτης σειράς διαγράμματος
        var series = chart.getChartData().getSeries().get_Item(0);
        // Προσθήκη νέου σημείου (1:3) εκεί.
        var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
        point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
        point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
        point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
        point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
        point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
        point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
        point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
        point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
        point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
        point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
        point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
        // Αλλαγή δείκτη σειράς διαγράμματος
        series.getMarker().setSize(15);
        // Αποθήκευση παρουσίασης με διάγραμμα
        pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Συχνές ερωτήσεις**

**Ποια σχήματα δεικτών είναι διαθέσιμα από προεπιλογή;**

Διατίθενται τυπικά σχήματα (κύκλος, τετράγωνο, διαμάντι, τρίγωνο κ.λπ.); η λίστα καθορίζεται από την απαρίθμηση [MarkerStyleType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markerstyletype/). Εάν χρειάζεστε μη τυπικό σχήμα, χρησιμοποιήστε έναν δείκτη με γέμισμα εικόνας για να προσομοιώσετε προσαρμοστικά γραφικά.

**Διατηρούνται οι δείκτες κατά την εξαγωγή ενός διαγράμματος σε εικόνα ή SVG;**

Ναι. Κατά τη δημιουργία διαγραμμάτων σε [raster formats](/slides/el/nodejs-java/convert-powerpoint-to-png/) ή κατά την αποθήκευση [shapes as SVG](/slides/el/nodejs-java/render-a-slide-as-an-svg-image/), οι δείκτες διατηρούν την εμφάνιση και τις ρυθμίσεις τους, συμπεριλαμβανομένου του μεγέθους, του γεμίσματος και του περιγράμματος.