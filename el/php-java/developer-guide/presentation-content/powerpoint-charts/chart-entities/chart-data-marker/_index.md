---
title: Διαχειριστείτε τους Δείκτες Δεδομένων Διαγράμματος σε Παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Δείκτης Δεδομένων
type: docs
url: /el/php-java/chart-data-marker/
keywords:
- διάγραμμα
- σημείο δεδομένων
- δείκτης
- επιλογές δείκτη
- μέγεθος δείκτη
- τύπος γεμίσματος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσαρμόζετε τους δείκτες δεδομένων διαγράμματος στο Aspose.Slides για PHP, ενισχύοντας την επιρροή της παρουσίασης σε μορφές PPT και PPTX με σαφή παραδείγματα κώδικα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με δείκτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα γράφημα, να αποκτήσετε πρόσβαση σε μια σειρά και στα σημεία δεδομένων της, να εφαρμόσετε γεμίσματα εικόνας στους δείκτες σε επίπεδο σημείου δεδομένων, να προσαρμόσετε το μέγεθος του δείκτη και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Αναφέρει επίσης ότι τα τυπικά σχήματα δεικτών είναι διαθέσιμα μέσω της απαρίθμησης `MarkerStyleType` και ότι η εμφάνιση του δείκτη διατηρείται κατά την εξαγωγή των διαγραμμάτων σε μορφές raster ή SVG.

## **Ορισμός επιλογών δεικτών διαγράμματος**
Οι δείκτες μπορούν να οριστούν σε σημεία δεδομένων του διαγράμματος μέσα σε συγκεκριμένες σειρές. Για να ορίσετε τις επιλογές δεικτών του διαγράμματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
- Δημιουργία του προεπιλεγμένου διαγράμματος.
- Ορίστε την εικόνα.
- Αποκτήστε την πρώτη σειρά του διαγράμματος.
- Προσθέστε νέο σημείο δεδομένων.
- Γράψτε την παρουσίαση στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει τις επιλογές δεικτών του διαγράμματος σε επίπεδο σημείων δεδομένων.

```php
  # Δημιουργία κενής παρουσίασης
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Δημιουργία του προεπιλεγμένου διαγράμματος
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Λήψη του δείκτη προεπιλεγμένου φύλλου δεδομένων διαγράμματος
    $defaultWorksheetIndex = 0;
    # Λήψη του φύλλου δεδομένων του διαγράμματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Διαγραφή σειράς επίδειξης
    $chart->getChartData()->getSeries()->clear();
    # Προσθήκη νέας σειράς
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Φόρτωση της εικόνας 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Φόρτωση της εικόνας 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Λήψη της πρώτης σειράς του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Προσθήκη νέου σημείου (1:3) εκεί.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Αλλαγή του δείκτη σειράς διαγράμματος
    $series->getMarker()->setSize(15);
    # Αποθήκευση παρουσίασης με διάγραμμα
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές ερωτήσεις**

**Ποια σχήματα δεικτών είναι διαθέσιμα εξ' αρχής;**

Τα τυπικά σχήματα είναι διαθέσιμα (κύκλος, τετράγωνο, ρόμβος, τρίγωνο κ.λπ.), η λίστα ορίζεται από την κλάση [MarkerStyleType](https://reference.aspose.com/slides/el/php-java/aspose.slides/markerstyletype/). Εάν χρειάζεστε ένα μη τυπικό σχήμα, χρησιμοποιήστε έναν δείκτη με γεμισμό εικόνας για να προσομοιώσετε προσαρμοστικά οπτικά στοιχεία.

**Διατηρούνται οι δείκτες κατά την εξαγωγή ενός διαγράμματος σε εικόνα ή SVG;**

Ναι. Όταν αποδίδονται τα διαγράμματα σε [raster formats](/slides/el/php-java/convert-powerpoint-to-png/) ή αποθηκεύονται [shapes as SVG](/slides/el/php-java/render-a-slide-as-an-svg-image/), οι δείκτες διατηρούν την εμφάνιση και τις ρυθμίσεις τους, συμπεριλαμβανομένου του μεγέθους, του γεμίσματος και του περιγράμματος.