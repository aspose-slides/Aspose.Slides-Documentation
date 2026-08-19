---
title: Εφαρμογή τύπων φύλλου εργασίας διαγράμματος σε παρουσιάσεις σε PHP
linktitle: Τύποι φύλλου εργασίας
type: docs
weight: 70
url: /el/php-java/chart-worksheet-formulas/
keywords:
- διάγραμμα λογιστικού φύλλου
- φύλλο εργασίας διαγράμματος
- τύπος διαγράμματος
- τύπος φύλλου εργασίας
- τύπος λογιστικού φύλλου
- βιβλίο δεδομένων διαγράμματος
- υπολογισμός τύπου
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
description: "Εφαρμόστε τύπους τύπου Excel σε φύλλα εργασίας διαγράμματος Aspose.Slides για PHP μέσω Java, επαναϋπολογίστε τις τιμές και χρησιμοποιήστε τα αποτελέσματα σε διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα του PowerPoint αποθηκεύουν συνήθως τα δεδομένα πηγής τους σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για PHP μέσω Java, μπορείτε να έχετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του βιβλίου εργασίας δεδομένων διαγράμματος, να γράψετε τιμές εισόδου, να αναθέσετε τύπους σε κελιά, να υπολογίσετε υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Αυτό το άρθρο εξηγεί τη πλήρη ροή εργασίας τύπων: δημιουργήστε ένα διάγραμμα, γεμίστε το φύλλο εργασίας του, αναθέστε τύπους A1‑style ή R1C1‑style, επαναϋπολογίστε τα, διαβάστε τις υπολογισμένες τιμές, συνδέστε αυτά τα κελιά με μια σειρά διαγράμματος και αποθηκεύστε την παρουσίαση. Περιγράφει επίσης τη σύνταξη των υποστηριζόμενων τύπων, το υποσύνολο ενσωματωμένων συναρτήσεων, τις αποθηκευμένες τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα που σχετίζονται με τα λογιστικά φύλλα.

## **Φύλλα Εργασίας Διαγράμματος και Τύποι**

Ένα φύλλο εργασίας διαγράμματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί ένα διάγραμμα. Στο PowerPoint, μπορείτε να εξετάσετε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![Διάγραμμα PowerPoint με ανοιχτό το ενσωματωμένο φύλλο εργασίας, εμφανίζοντας δεδομένα κατηγοριών και σειρών](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω της κλάσης [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/). Χρησιμοποιήστε [ChartDataCell::setFormula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setFormula) για τύπους A1‑style και [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setR1C1Formula) για τύπους R1C1‑style. Μετά την αλλαγή των κελιών εισόδου ή των τύπων, καλέστε [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) για να επαναϋπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω του [ChartDataCell::getValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#getValue). Αυτό είναι σημαντικό όταν χρειάζεται να εξετάσετε το αποτέλεσμα ενός τύπου στον κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων διαγράμματος.

## **Δημιουργία Διαγράμματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα δείχνει μια ολοκληρωμένη ροή εργασίας. Δημιουργεί ένα συγκεντρωτικό διάγραμμα στηλών, καθαρίζει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

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

Τα σημεία δεδομένων του διαγράμματος αναφέρονται στο `D2:D4`, ώστε το διάγραμμα να χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης διαγράμματος σε αυτή τη ροή: επανυπολογίστε πρώτα το βιβλίο εργασίας, έπειτα χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων A1‑Style**

Η σημειογραφία A1 ταυτοποιεί τις στήλες με γράμματα και τις γραμμές με αριθμούς. Αναθέστε εκφράσεις A1‑style μέσω του [ChartDataCell::setFormula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setFormula).

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

Κοινές μορφές αναφοράς A1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `A2` | `$A$2` | `A$2`, `$A2` |
| Γραμμή | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Περιοχή | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινείται ή αντιγράφεται από μια εφαρμογή λογιστικού φύλλου. Οι απόλυτες αναφορές κρατούν αμετάβλητους και τις δύο συντεταγμένες, ενώ οι μικτές αναφορές σταθεροποιούν μόνο μια γραμμή ή μια στήλη.

## **Χρήση Τύπων R1C1‑Style**

Η σημειογραφία R1C1 ταυτοποιεί τόσο τις γραμμές όσο και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε αγκύλες. Αναθέστε αυτή τη σύνταξη μέσω του [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

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

Κοινές μορφές αναφοράς R1C1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Γραμμή | `R[2]` | `R2` | — |
| Στήλη | `C[3]` | `C3` | — |
| Περιοχή | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες αριστερά (`B2`).

## **Σταθερές Τύπου και Τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικά λήμματα, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Λήμματα**

| Τύπος | Παραδείγματα | Σχόλια |
|---|---|---|
| Λογική | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί απευθείας σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητική | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται η κοινή και η επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Τα λήμματα κειμένου περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί ως τιμή σφάλματος λογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί πολλούς τύπους σταθερών:

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

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Αριθμητικοί Τελεστές**

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μοναδικό θετικό | `2+3` |
| `-` | Αφαίρεση ή άρνηση | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εξαίρεση (υψωση σε δύναμη) | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να καθορίσετε ρητά τη σειρά αξιολόγησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ισότητα | `A2=3` |
| `<>` | Ασυμφωνία | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας διαγράμματος, αλλά δεν είναι πλήρης μηχανή υπολογισμού Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέτετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επαναυπολογισθεί από το [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση ενός αριθμού προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με βάση δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγκόλληση κειμενικών τιμών | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγκόλληση κειμενικών τιμών | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας χρησιμοποιώντας το σύστημα ημερομηνίας 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ δύο ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εύρεση μιας κειμενικής τιμής μέσα σε άλλη | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου βάσει byte | `FINDB("a",A2)` |
| `IF` | Υπολογιστικό αποτέλεσμα υπό συνθήκη | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Διανυσματική μορφή | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Διανυσματική μορφή | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροισμα τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί που εμφανίζονται στον πίνακα είναι ουσιώδεις: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ το `LOOKUP` και το `MATCH` σε διανυσματικές μορφές. Το `DATE` χρησιμοποιεί το σύστημα ημερομηνίας 1900. Χαρακτηριστικά και συναρτήσεις που δεν αναφέρονται εδώ θεωρούνται μη υποστηριζόμενα από τον αξιολογητή τύπων Aspose.Slides, εκτός εάν τεκμηριωθούν ξεχωριστά.

## **Επανάυπολογισμός και Αποθηκευμένες Τιμές**

Τα αρχεία λογιστικών φύλλων συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία του υπολογισμένη τιμή. Το Aspose.Slides μπορεί έτσι να διαβάσει μια αποθηκευμένη τιμή από το [ChartDataCell::getValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#getValue) όταν μια παρουσίαση φορτώνεται και τα σχετικά δεδομένα διαγράμματος δεν έχουν αλλάξει.

Μετά την αλλαγή των κελιών εισόδου ή των τύπων, μην βασίζεστε σε παλαιά αποθηκευμένα αποτελέσματα. Καλέστε το [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτά.

Για τύπους που βρίσκονται εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides ενδέχεται να μην μπορεί να αναλύσει τον τύπο ή να εντοπίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη αποθηκευμένη τιμή δεν θεωρείται πλέον αξιόπιστη. Σε αυτήν την περίπτωση, η ανάγνωση της τιμής κελιού με μη υποστηριζόμενο δεδομένο μπορεί να προκαλέσει [CellUnsupportedDataException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellunsupporteddataexception/).

Εάν το διάγραμμά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε εκείνους τους τύπους με μια μηχανή λογιστικού φύλλου που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας του διαγράμματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εκτιμώμενες τιμές.

## **Διαχείριση Σφαλμάτων Τύπου**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να ξεχωριστούν.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει ένα αποτέλεσμα σφάλματος λογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτήν την περίπτωση, το token σφάλματος είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [ChartDataCell::getValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#getValue).

Ένας τύπος μπορεί επίσης να αποτύχει σε επίπεδο ανάλυσης, αναφοράς, εξάρτησης ή υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις λογιστικού φύλλου για αυτές τις περιπτώσεις: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellunsupporteddataexception/).

Στο PHP μέσω Java, οι εξαιρέσεις Java εκτίθενται μέσω του `JavaException`. Όταν οι τύποι προέρχονται από πρότυπα ή εισροές χρήστη, χειριστείτε τα γύρω από τον επαναϋπολογισμό και την πρόσβαση στην τιμή. Η εξαίρεση Java που αναφέρεται στο stack trace εντοπίζει το συγκεκριμένο σφάλμα λογιστικού φύλλου:

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

Η υποστήριξη τύπων σε φύλλα εργασίας διαγράμματος προορίζεται για ένα ορισμένο υποσύνολο υπολογισμών λογιστικού φύλλου, όχι για πλήρη συμβατότητα με το Excel. Κρατήστε αυτούς τους περιορισμούς στο μυαλό σας όταν σχεδιάζετε μια ροή εργασίας αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεται το Aspose.Slides να επαναϋπολογίσει τύπους.
- Επαναϋπολογίστε μετά την αλλαγή των κελιών από τα οποία εξαρτώνται τα αποτελέσματα των τύπων.
- Θεωρήστε τις αποθηκευμένες τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως υποκατάστατο του επαναϋπολογισμού μετά από επεξεργασίες.
- Δοκιμάστε τους τύπους από υπάρχοντα πρότυπα πριν εμπιστευτείτε τις υπολογισμένες τιμές τους, ιδιαίτερα όταν χρησιμοποιούν συναρτήσεις εκτός της τεκμηριωμένης λίστας.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και, στη συνέχεια, ενημερώστε το βιβλίο εργασίας διαγράμματος με τις προκύπτουσες τιμές.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ [ChartDataCell::setFormula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setFormula) και [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setR1C1Formula);**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setFormula) αποθηκεύει μια έκφραση A1‑style όπως `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#setR1C1Formula) αποθηκεύει μια έκφραση R1C1‑style όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα στον τρόπο που δημιουργείτε ή αντιγράφετε τύπους.

**Πρέπει να διαβάσω το ίδιο το κελί ή την τιμή του μετά τον υπολογισμό;**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#getCell) επιστρέφει ένα [ChartDataCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/). Για να λάβετε το υπολογισμένο αποτέλεσμα, καλέστε τη μέθοδο [ChartDataCell::getValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/#getValue) του κελιού μετά τον επαναϋπολογισμό.

**Πότε πρέπει να καλέσω το [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas);**

Καλέστε το [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) μετά την αλλαγή των τιμών εισόδου ή των τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζει ο ενσωματωμένος αξιολογητής.

**Υποστηρίζει το Aspose.Slides κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι θα επαναϋπολογιστούν σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, πραγματοποιήστε τον υπολογισμό με μια κατάλληλη μηχανή λογιστικού φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας διαγράμματος.

**Τι συμβαίνει αν μια φορτωμένη παρουσίαση περιέχει μη υποστηριζόμενο τύπο;**

Εάν τα δεδομένα διαγράμματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί να περιέχει ακόμη μια προηγουμένως υπολογισμένη αποθηκευμένη τιμή. Αφού τροποποιηθούν τα σχετικά δεδομένα, αυτή η αποθηκευμένη τιμή ενδέχεται να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να αντιμετωπιστεί μπορεί να προκαλέσει [CellUnsupportedDataException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellunsupporteddataexception/).

**Οι τιμές σφάλματος τύπου είναι το ίδιο με τις εξαιρέσεις PHP;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι τιμή λογιστικού φύλλου που παράγεται από έναν έγκυρο υπολογισμό. Αποτυχίες επεξεργασίας λογιστικού φύλλου όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellcircularreferenceexception/) είναι εξαιρέσεις Java που εκτίθενται στο PHP μέσω του `JavaException`.

**Το διάγραμμα ενημερώνεται αυτόματα όταν αλλάζει ένα κελί τύπου;**

Μια σειρά διαγράμματος μπορεί να αναφέρεται σε κελιά του βιβλίου εργασίας. Επαναϋπολογίστε πρώτα το βιβλίο εργασίας, έπειτα αποθηκεύστε ή αποδώστε την παρουσίαση. Εάν τα σημεία δεδομένων του διαγράμματος αναφέρονται στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί αυτές τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης διαγράμματος για αυτή τη ροή.

**Μπορούν τα διαγράμματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα διαγράμματος μπορούν να διαμορφωθούν ώστε να χρησιμοποιούν εξωτερικό βιβλίο εργασίας μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή εργασίας υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο εργασίας δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογείται από το Aspose.Slides. Μην υποθέτετε ότι το [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) παρέχει πλήρη επαναϋπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο εργασίας ή βιβλίο εργασίας;**

Οι αναφορές στυλ Excel μπορεί να υπάρξουν σε βιβλία εργασίας διαγράμματος, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο συναρτήσεων. Εάν μια διασταυρούμενη αναφορά ή εξωτερική αναφορά είναι απαραίτητη, επαληθεύστε τον ακριβή τύπο με την έκδοση Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εργασίας εξωτερικά και γράψτε τις επίλυτες τιμές πίσω στα δεδομένα διαγράμματος.

**Πρέπει οι συμβολοσειρές τύπων να ξεκινούν με `=`;**

Τα παραδείγματα του API Aspose.Slides αναθέτουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς προδιαγεγραμμένο `=`. Η χρήση αυτής της μορφής διατηρεί τους δημιουργημένους τύπους συνεπείς με τα τεκμηριωμένα παραδείγματα API.