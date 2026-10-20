---
title: Λύση Εργασίας για Αλλαγή Μεγέθους Διαγράμματος σε PPTX
type: docs
weight: 40
url: /el/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- αλλαγή μεγέθους διαγράμματος
- διάγραμμα Excel
- αντικείμενο OLE
- ενσωμάτωση διαγράμματος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διορθώστε την απρόσμενη αλλαγή μεγέθους διαγράμματος σε PPTX όταν χρησιμοποιούνται ενσωματωμένα αντικείμενα Excel OLE με Aspose.Slides for PHP via Java. Ορίστε σταθερές διαστάσεις διαγράμματος ώστε τα μεγέθη του διαγράμματος και του πλαισίου OLE να παραμένουν συνεπή."
---
## **Επισκόπηση**

Τα διαγράμματα Excel που ενσωματώνονται ως αντικείμενα OLE σε παρουσιάσεις PowerPoint χρησιμοποιώντας τα στοιχεία Aspose μπορούν να αλλάξουν μέγεθος μετά την πρώτη ενεργοποίησή τους. Αυτό μπορεί να δημιουργήσει εμφανή διαφορά στην εμφάνιση του διαγράμματος πριν και μετά την ενεργοποίηση. Το άρθρο αυτό εξηγεί γιατί συμβαίνει η αλλαγή μεγέθους και παρουσιάζει πώς να την αποτρέψετε ταιριάζοντας το σταθερό μέγεθος του διαγράμματος με το πλαίσιο OLE.

Στο [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/el/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), εξηγήσαμε πώς να δημιουργήσετε ένα διάγραμμα Excel με Aspose.Cells for PHP via Java και να το ενσωματώσετε σε μια παρουσίαση PowerPoint χρησιμοποιώντας Aspose.Slides for PHP via Java. Για να αντιμετωπίσουμε το [object preview issue](/slides/el/php-java/object-preview-issue-when-adding-oleobjectframe/), ορίσαμε την εικόνα του διαγράμματος στο πλαίσιο αντικειμένου OLE του διαγράμματος. Στην έξοδο της παρουσίασης, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του διαγράμματος, το διάγραμμα Excel ενεργοποιείται. Οι χρήστες μπορούν να επεξεργαστούν το ενσωματωμένο βιβλίο εργασίας Excel και, στη συνέχεια, να επιστρέψουν στη διαφάνεια κάνοντας κλικ έξω από το ενεργό βιβλίο εργασίας. Το μέγεθος του πλαισίου αντικειμένου OLE αλλάζει όταν ο χρήστης επιστρέφει στη διαφάνεια, και ο παράγοντας αλλαγής μεγέθους διαφέρει ανάλογα με τα αρχικά μεγέθη τόσο του πλαισίου αντικειμένου OLE όσο και του ενσωματωμένου βιβλίου εργασίας Excel.

## **Αιτία αλλαγής μεγέθους**

Το ενσωματωμένο βιβλίο εργασίας Excel έχει τις δικές του διαστάσεις παραθύρου, τις οποίες το Excel προσπαθεί να διατηρήσει όταν το αντικείμενο ενεργοποιείται για πρώτη φορά. Το πλαίσιο OLE στη διαφάνεια έχει ανεξάρτητα καθορισμένες διαστάσεις. Όταν το βιβλίο εργασίας Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος του αντικειμένου για να διατηρήσουν τις αναλογίες του ως μέρος της διαδικασίας ενσωμάτωσης. Οι διαφορές μεταξύ του παραθύρου του βιβλίου εργασίας και του πλαισίου OLE μπορούν επομένως να προκαλέσουν αλλαγή μεγέθους του αντικειμένου.

## **Λύση**

Ταιριάξτε το μέγεθος του διαγράμματος με το πλαίσιο OLE στη διαφάνεια και διατηρήστε τις διαστάσεις του διαγράμματος ανεξάρτητες από το παράθυρο του βιβλίου εργασίας. Αυτή η λύση λειτουργεί με νέα παρουσίαση ή με υπάρχον πρότυπο.

Το παράδειγμα απαιτεί Aspose.Cells for PHP via Java και Aspose.Slides for PHP via Java. Διαμορφώστε και τα δύο προϊόντα με το ίδιο στιγμιότυπο PHP/Java Bridge, φορτώστε και τα δύο PHP wrappers και κάντε και τις δύο βιβλιοθήκες Java διαθέσιμες στη γέφυρα. Δεν απαιτούνται αρχεία εισόδου. Δημιουργεί ένα απλό διάγραμμα στήλης σε ενεργό φύλλο διαγράμματος και ενσωματώνει το βιβλίο εργασίας σε μορφή XLS. Δεν ορίζεται εικόνα προεπισκόπησης διαγράμματος· το διάγραμμα γίνεται ορατό όταν το αντικείμενο OLE ενεργοποιείται στο PowerPoint.

Το παράδειγμα δημιουργεί μια νέα παρουσίαση με πλαίσιο OLE 9,5 × 4 ίντσες τοποθετημένο 0,5 ίντσες από την αριστερή άκρη και 1 ίντσα από την κορυφή. Οι συντεταγμένες και οι διαστάσεις της διαφάνειας δίνονται σε points (72 points ανά ίντσα). Για υπάρχουσα παρουσίαση, δείτε [Use a Template](#use-a-template).

## **Ορισμός σταθερού μεγέθους διαγράμματος**

Ορίστε το [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) σε false ώστε οι διαστάσεις του διαγράμματος να είναι ανεξάρτητες από το παράθυρο του βιβλίου εργασίας. Ορίστε τις διαστάσεις του [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) μέσω του [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) και του [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), μετατρέποντας τα points σε pixel με 96 pixel ανά ίντσα: ένα πλαίσιο 684 × 288 points αντιστοιχεί σε διάγραμμα 912 × 384 pixel. Ορίστε το [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) στην προσαρμοσμένη τιμή του [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). Το παράδειγμα ενσωματώνει το βιβλίο εργασίας με το [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) και αποθηκεύει μια παρουσίαση με πλαίσιο OLE 9,5 × 4 ίντσες.

Τα αριθμητικά αποτελέσματα Java μετατρέπονται με `java_values` πριν χρησιμοποιηθούν ως δείκτες PHP. Τα bytes του βιβλίου εργασίας παραμένουν σε έναν πίνακα byte Java όταν μεταβιβάζονται στο [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Συντεταγμένες και διαστάσεις της διαφάνειας είναι σε points (72 points ανά ίντσα).
        $width = 684; // 9.5 ίντσες.
        $height = 288; // 4 ίντσες.

        $chart->setSizeWithWindow(false);
        // Μετατροπή points σε pixel διαγράμματος χρησιμοποιώντας 96 pixel ανά ίντσα.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Χρήση προτύπου**

Η λογική μεγέθους είναι η ίδια για υπάρχουσα παρουσίαση. Για να προσαρμόσετε το παράδειγμα:

1. Φορτώστε την παρουσίαση προτύπου αντί να δημιουργήσετε κενή παρουσίαση.  
2. Ελέγξτε ότι η πρώτη διαφάνεια περιλαμβάνει τουλάχιστον τ three σχήματα, στη συνέχεια χρησιμοποιήστε το σχήμα στη θέση 2 ως θέση κράτησης.  
3. Πάρτε το πλάτος και το ύψος του πλαισίου από αυτό το σχήμα αντί να χρησιμοποιήσετε τις σταθερές τιμές 684 και 288. Διατηρήστε τους υπολογισμούς μεγέθους αμετάβλητους.  
4. Προσθέστε το πλαίσιο OLE στη θέση του placeholder αντί για τις σταθερές συντεταγμένες 36 και 72.  
5. Αφαιρέστε το placeholder πριν αποθηκεύσετε την παρουσίαση.

## **Συχνές Ερωτήσεις**

**Γιατί το ενσωματωμένο διάγραμμα Excel μου αλλάζει μέγεθος μετά την ενεργοποίηση στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να επαναφέρει το αρχικό μέγεθος του παραθύρου κατά την πρώτη ενεργοποίηση, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Πώς μπορώ να διατηρήσω σταθερά τα μεγέθη του διαγράμματος και του πλαισίου OLE;**

Ορίστε σταθερές διαστάσεις διαγράμματος που ταιριάζουν με το πλαίσιο OLE και χρησιμοποιήστε προσαρμοσμένο μέγεθος εκτύπωσης διαγράμματος πριν ενσωματώσετε το βιβλίο εργασίας. Το παραπάνω παράδειγμα δείχνει τις απαιτούμενες ρυθμίσεις και τις μετατροπές μονάδων.

**Είναι η αντιστοίχιση του μεγέθους του παραθύρου του βιβλίου εργασίας αρκετή;**

Η αντιστοίχιση του μεγέθους του παραθύρου του βιβλίου εργασίας από μόνη της δεν αποτρέπει αξιόπιστα την αλλαγή μεγέθους του πλαισίου OLE μετά την ενεργοποίηση. Χρησιμοποιήστε σταθερές διαστάσεις διαγράμματος όπως φαίνεται στο παράδειγμα.

**Λειτουργεί αυτή η λύση τόσο με παρουσιάσεις βασισμένες σε πρότυπο όσο και με νέες παρουσιάσεις;**

Ναι. Για ένα πρότυπο, χρησιμοποιήστε τις διαστάσεις και τη θέση του placeholder. Για νέα παρουσίαση, καθορίστε απευθείας τις διαστάσεις και τη θέση του πλαισίου.

**Μπορώ να χρησιμοποιήσω αυτό το παράδειγμα με διαγράμματα που δημιουργήθηκαν σε άλλα προγράμματα λογιστικών φύλλων;**

Το παράδειγμα χρησιμοποιεί ένα βιβλίο εργασίας Excel που δημιουργήθηκε με Aspose.Cells. Δεν δείχνει τη συμπεριφορά ενεργοποίησης για άλλα προγράμματα λογιστικών φύλλων.

## **Σχετικές Ενότητες**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/el/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)