---
title: Εφαρμογή Τύπων Φύλλου Εργασίας Διαγράμματος σε Παρουσιάσεις με PHP
linktitle: Τύποι Φύλλου Εργασίας
type: docs
weight: 70
url: /el/php-java/chart-worksheet-formulas/
keywords:
- υπολογιστικό φύλλο διαγράμματος
- φύλλο εργασίας διαγράμματος
- τύπος διαγράμματος
- τύπος φύλλου εργασίας
- τύπος υπολογιστικού φύλλου
- βιβλίο δεδομένων διαγράμματος
- υπολογισμός τύπου
- προτιμώμενος πολιτισμός
- τύπος προσαρμοσμένος στον πολιτισμό
- DBCS
- λογική σταθερά
- αριθμητική σταθερά
- σταθερά συμβολοσειράς
- σταθερά σφάλματος
- αριθμητικός τελεστής
- τελεστής σύγκρισης
- στυλ A1
- στυλ R1C1
- προκαθορισμένη συνάρτηση
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εφαρμόστε τύπους τύπου Excel στο Aspose.Slides για PHP μέσω φυλλοστηρίων διαγράμματος Java, επανυπολογίστε τιμές και χρησιμοποιήστε τα αποτελέσματα σε διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα PowerPoint συνήθως αποθηκεύουν τα δεδομένα προέλευσης τους σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για PHP μέσω Java, μπορείτε να αποκτήσετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του βιβλίου δεδομένων διαγράμματος, να γράψετε τιμές εισόδου, να αντιστοιχίσετε τύπους σε κελιά, να υπολογίσετε τους υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Αυτό το άρθρο εξηγεί την πλήρη ροή εργασίας τύπων: δημιουργία διαγράμματος, γεμίσμα του φύλλου εργασίας, ανάθεση τύπων στυλ A1 ή R1C1, επανυπολογισμός τους, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών σε σειρά διαγράμματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη των υποστηριζόμενων τύπων, το ενσωματωμένο υποσύνολο συναρτήσεων, τις κρυφές τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα ειδικά για υπολογιστικά φύλλα.

## **Φύλλα Εργασίας Διαγράμματος και Τύποι**

Ένα φύλλο εργασίας διαγράμματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιούνται από ένα διάγραμμα. Στο PowerPoint, μπορείτε να ελέγξετε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![Διάγραμμα PowerPoint με το ενσωματωμένο φύλλο εργασίας ανοιχτό, εμφανίζοντας δεδομένα κατηγοριών και σειρών](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω της κλάσης [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/) . Χρησιμοποιήστε [ChartDataCell::setFormula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setFormula) για τύπους στυλ A1 και [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setR1C1Formula) για τύπους στυλ R1C1. Αφού αλλάξετε τα κελιά εισόδου ή τους τύπους, καλέστε [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) για να επανυπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω του [ChartDataCell::getValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#getValue). Αυτό είναι σημαντικό όταν χρειάζεται να εξετάσετε το αποτέλεσμα ενός τύπου στον κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων διαγράμματος.

## **Δημιουργία Διαγράμματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα δείχνει μια πλήρης ροή εργασίας. Δημιουργεί ένα συγκεντρωτικό διάγραμμα στηλών, καθαρίζει τα δείγματα δεδομένων, γράφει τιμές εσόδων και εξόδων ανά τρίμηνο, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Τα σημεία δεδομένων του διαγράμματος αναφέρονται στο `D2:D4`, επομένως το διάγραμμα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης διαγράμματος σε αυτή τη ροή: επανυπολογίστε πρώτα το βιβλίο εργασίας, μετά χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειογραφία A1 προσδιορίζει στήλες με γράμματα και γραμμές με αριθμούς. Αντιστοιχίστε εκφράσεις στυλ A1 μέσω του [ChartDataCell::setFormula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Κοινοί τύποι αναφοράς A1 είναι:

| Αναφορά | Σχετικό | Απόλυτο | Μικτό |
|---|---|---|---|
| Κελί | `A2` | `$A$2` | `A$2`, `$A2` |
| Γραμμή | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Εύρος | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινηθεί ή αντιγραφεί από μια εφαρμογή υπολογιστικών φύλλων. Οι απόλυτες αναφορές διατηρούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές αναφορές σταθεροποιούν μόνο μια γραμμή ή μια στήλη.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειογραφία R1C1 προσδιορίζει τόσο τις γραμμές όσο και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε αγκύλες. Αντιστοιχίστε αυτή τη σύνταξη μέσω του [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

Κοινοί τύποι αναφοράς R1C1 είναι:

| Αναφορά | Σχετικό | Απόλυτο | Μικτό |
|---|---|---|---|
| Κελί | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Γραμμή | `R[2]` | `R2` | — |
| Στήλη | `C[3]` | `C3` | — |
| Εύρος | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες προς τα αριστερά (`B2`).

## **Σταθερές Τύπων και Τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικά κυριολεκτικά, συμβολοσειρές, τιμές σφάλματος υπολογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Κυριολεκτικά**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Λογικό | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητικό | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται κοινή και επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Τα κυριολεκτικά κείμενα περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος υπολογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί πολλαπλούς τύπους σταθερών:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // ψευδής
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Αριθμητικοί Τελεστές**

| Τελεστής | Σκοπός | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μοναδιαίο πρόσημο | `2+3` |
| `-` | Αφαίρεση ή άρνηση | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Δυνάμωση | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε ρητή τη σειρά αξιολόγησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέφουν λογικές τιμές.

| Τελεστής | Σκοπός | Παράδειγμα |
|---|---|---|
| `=` | Ισότητα | `A2=3` |
| `<>` | Ασυμφωνία | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο | `A2<=3` |

## **Υποστηριζόμενες Προ-ορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας διαγραμμάτων, αλλά δεν είναι πλήρης μηχανή υπολογισμού Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέσετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επανυπολογιστεί με το [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποιεί έναν αριθμό προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλέγει τιμή βάσει δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγχωνεύει τιμές κειμένου | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγχωνεύει τιμές κειμένου | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργεί τιμή ημερομηνίας χρησιμοποιώντας το σύστημα ημερομηνίας 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Βρίσκει ένα κείμενο μέσα σε άλλο | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου ανά byte | `FINDB("a",A2)` |
| `IF` | Συνθήκη | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροισμα τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κάθετη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί στον πίνακα είναι σημαντικοί: το `INDEX` τεκμηριώνεται με μορφή αναφοράς, ενώ το `LOOKUP` και το `MATCH` με μορφές διανύσματος. Το `DATE` χρησιμοποιεί το σύστημα ημερομηνίας 1900. Τα χαρακτηριστικά και οι συναρτήσεις που δεν αναφέρονται εδώ θεωρούνται μη υποστηριζόμενα από τον αξιολογητή τύπων του Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Υπολογισμός Τύπων με Προτιμώμενο Πολιτισμό**

Ορισμένες συναρτήσεις βιβλίου εργασίας διαγράμματος ερμηνεύουν κείμενο σύμφωνα με πολιτισμικούς κανόνες. Αυτό είναι ιδιαίτερα σημαντικό για συναρτήσεις που προορίζονται για γλώσσες που χρησιμοποιούν σύνολα χαρακτήρων διπλού byte (DBCS). Για να υπολογίσετε σωστά τέτοιους τύπους, δημιουργήστε [LoadOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/), ορίστε τον προτιμώμενο πολιτισμό με το [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/el/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), αντιστοιχίστε τις επιλογές φύλλου εργασίας μέσω του [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) και, στη συνέχεια, φορτώστε την παρουσίαση.

Το παρακάτω παράδειγμα επιλέγει τον Ιαπωνικό πολιτισμό, ανοίγει μια παρουσίαση με τις ρυθμισμένες επιλογές φόρτωσης και καλεί το [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) για κάθε βιβλίο εργασίας διαγράμματος:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Ο προτιμώμενος πολιτισμός αποτελεί μέρος της ρύθμισης φόρτωσης της παρουσίασης, επομένως πρέπει να οριστεί πριν δημιουργήσετε το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Χρησιμοποιήστε τον πολιτισμό που απαιτούν οι τύποι του βιβλίου εργασίας· για παράδειγμα, `ja-JP` για τύπους που πρέπει να ακολουθούν τους Ιαπωνικούς κανόνες DBCS.

## **Επανάληψη Υπολογισμού και Τιμές στην Κρυφή Μνήμη**

Τα αρχεία υπολογιστικών φύλλων συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία του υπολογισμένη τιμή. Το Aspose.Slides μπορεί επομένως να διαβάσει μια κρυφή τιμή από το [ChartDataCell::getValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#getValue) όταν η παρουσίαση φορτώνεται και τα σχετικά δεδομένα διαγράμματος δεν έχουν αλλάξει.

Αφού αλλάξετε κελιά εισόδου ή τύπους, μην βασίζεστε σε παλιά κρυφή τιμή. Καλέστε το [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides μπορεί να μην μπορεί να αναλύσει τον τύπο ή να καθορίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη κρυφή τιμή δεν μπορεί πια να θεωρηθεί αξιόπιστη. Σε αυτή την περίπτωση, η ανάγνωση τιμής κελιού με μη υποστηριζόμενο δεδομένο μπορεί να προκαλέσει [CellUnsupportedDataException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellunsupporteddataexception/).

Εάν το διάγραμμά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή υπολογιστικού φύλλου που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας διαγράμματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εικαστικές τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να διαφοροποιηθούν.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος υπολογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτή την περίπτωση, το σφάλμα είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [ChartDataCell::getValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#getValue).

Ένας τύπος μπορεί επίσης να αποτύχει κατά την ανάλυση, την αναφορά, την εξάρτηση ή σε επίπεδο υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις ειδικά για υπολογιστικά φύλλα για αυτές τις περιπτώσεις: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellunsupporteddataexception/).

Στο PHP μέσω Java, οι εξαιρέσεις Java εμφανίζονται μέσω του `JavaException`. Όταν οι τύποι προέρχονται από πρότυπα ή είσοδο χρήστη, χειριστείτε τες γύρω από τον επανυπολογισμό και την πρόσβαση στις τιμές. Η εξαίρεση Java που εμφανίζεται στο stack trace προσδιορίζει την συγκεκριμένη αποτυχία του υπολογιστικού φύλλου:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Πρακτικοί Περιορισμοί**

Η υποστήριξη τύπων σε φύλλα εργασίας διαγράμματος προορίζεται για ένα καθορισμένο υποσύνολο υπολογισμών υπολογιστικών φύλλων, όχι για πλήρη συμβατότητα με το Excel. Κρατήστε αυτούς τους περιορισμούς στο μυαλό σας όταν σχεδιάζετε μια ροή εργασίας αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεστε τον επανυπολογισμό τύπων από το Aspose.Slides.
- Επαναϋπολογίστε μετά την αλλαγή κελιών από τα οποία εξαρτώνται τα αποτελέσματα τύπων.
- Θεωρήστε τις κρυφές τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως υποκατάσταση του επανυπολογισμού μετά από επεξεργασία.
- Δοκιμάστε τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τιμές τους, ειδικά αν χρησιμοποιούν συναρτήσεις εκτός της τεκμηριωμένης λίστας.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού υπολογιστικού φύλλου, υπολογίστε τους εξωτερικά και, στη συνέχεια, ενημερώστε το βιβλίο εργασίας διαγράμματος με τις προκύπτουσες τιμές.

## **FAQ**

**Ποια είναι η διαφορά μεταξύ [ChartDataCell::setFormula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setFormula) και [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setR1C1Formula);**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setFormula) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setR1C1Formula) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα με τον τρόπο που δημιουργείτε ή αντιγράφετε τύπους.

**Πρέπει να διαβάσω το ίδιο το κελί ή την τιμή του μετά τον υπολογισμό;**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#getCell) επιστρέφει ένα [ChartDataCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/). Για να λάβετε το υπολογισμένο αποτέλεσμα, καλέστε τη μέθοδο [ChartDataCell::getValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#getValue) του κελιού μετά τον επανυπολογισμό.

**Πότε πρέπει να καλέσω [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas);**

Καλέστε το [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζονται από τον ενσωματωμένο αξιολογητή.

**Υποστηρίζει το Aspose.Slides κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Οι συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι επανυπολογίζονται σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, εκτελέστε τους υπολογισμούς με κατάλληλη μηχανή υπολογιστικού φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας διαγράμματος.

**Τι συμβαίνει αν μια φορτωμένη παρουσίαση περιέχει μη υποστηριζόμενο τύπο;**

Εάν τα δεδομένα διαγράμματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμα να περιέχει μια προηγουμένως υπολογισμένη κρυφή τιμή. Μετά την τροποποίηση σχετικών δεδομένων, αυτή η κρυφή τιμή μπορεί να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να διαχειριστεί μπορεί να προκαλέσει [CellUnsupportedDataException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellunsupporteddataexception/).

**Οι τιμές σφάλματος τύπου είναι οι ίδιες με τις εξαιρέσεις PHP;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι τιμή υπολογιστικού φύλλου που προκύπτει από έγκυρο υπολογισμό. Αποτυχίες επεξεργασίας υπολογιστικού φύλλου όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellcircularreferenceexception/) είναι εξαιρέσεις Java που εκτίθενται στο PHP μέσω του `JavaException`.

**Μαζεύει το διάγραμμα αυτόματα την ενημέρωση όταν αλλάζει ένα κελί τύπου;**

Μια σειρά διαγράμματος μπορεί να αναφέρει κελιά του βιβλίου εργασίας. Επαναϋπολογίστε πρώτα το βιβλίο εργασίας, στη συνέχεια αποθηκεύστε ή αποδώστε την παρουσίαση. Εάν τα σημεία δεδομένων του διαγράμματος αναφέρονται στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί αυτές τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης διαγράμματος για αυτή τη ροή εργασίας.

**Μπορούν τα διαγράμματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα διαγράμματος μπορούν να ρυθμιστούν για χρήση εξωτερικού βιβλίου εργασίας μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή εργασίας υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο εργασίας δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογείται από το Aspose.Slides. Μην υποθέτετε ότι το [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) παρέχει πλήρη επανυπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο εργασίας ή βιβλίο εργασίας;**

Οι αναφορές τύπου Excel μπορεί να υπάρχουν σε βιβλία εργασίας διαγράμματος, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο συναρτήσεων. Εάν μια διασταυρούμενη αναφορά είναι απαραίτητη, επαληθεύστε ότι ο τύπος λειτουργεί με την έκδοση του Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εργασίας εξωτερικά και γράψτε τις επεξεργασμένες τιμές πίσω στα δεδομένα διαγράμματος.

**Πρέπει οι συμβολοσειρές τύπων να ξεκινούν με `=`;**

Τα παραδείγματα API του Aspose.Slides αναθέτουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς προκάτοχο `=`. Χρησιμοποιώντας αυτή τη μορφή κρατά τις δημιουργημένες εκφράσεις σύμφωνες με τα τεκμηριωμένα παραδείγματα API.