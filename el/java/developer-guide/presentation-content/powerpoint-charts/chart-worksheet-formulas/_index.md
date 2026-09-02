---
title: Εφαρμογή Τύπων Φύλλου Εργασίας Διαγράμματος σε Παρουσιάσεις σε Java
linktitle: Τύποι Φύλλου Εργασίας
type: docs
weight: 70
url: /el/java/chart-worksheet-formulas/
keywords:
- λογιστικό φύλλο διαγράμματος
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
- Java
- Aspose.Slides
description: "Εφαρμόστε τύπους σε στυλ Excel σε φύλλα εργασίας διαγραμμάτων Aspose.Slides για Java, επανυπολογίστε τις τιμές και χρησιμοποιήστε τα αποτελέσματα σε διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα PowerPoint συνήθως αποθηκεύουν τα δεδομένα προέλευσης σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides for Java, μπορείτε να έχετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του workbook δεδομένων διαγράμματος, να γράψετε τιμές εισόδου, να αναθέσετε τύπους σε κελία, να υπολογίσετε υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Αυτό το άρθρο εξηγεί τη πλήρη ροή εργασίας τύπων: δημιουργία διαγράμματος, πλήρωση του φύλλου εργασίας, ανάθεση τύπων στυλ A1 ή R1C1, επανυπολογισμός, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών σε σειρά διαγράμματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη υποστηριζόμενων τύπων, το υποσύνολο ενσωματωμένων συναρτήσεων, τις τιμές σε cache, τους μη υποστηριζόμενους τύπους και τα σφάλματα που σχετίζονται με λογιστικά φύλλα.

## **Φύλλα Εργασίας Διαγραμμάτων και Τύποι**

Ένα φύλλο εργασίας διαγράμματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί ένα διάγραμμα. Στο PowerPoint, μπορείτε να επιθεωρήσετε το φύλλο ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εκτίθεται μέσω της διεπαφής [IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/). Χρησιμοποιήστε [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) για τύπους στυλ A1 και [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) για τύπους στυλ R1C1. Μετά την αλλαγή των κελιών εισόδου ή των τύπων, καλέστε [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) για να επανυπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω του [IChartDataCell.getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#getValue--). Αυτό είναι σημαντικό όταν χρειάζεται να επιθεωρήσετε το αποτέλεσμα ενός τύπου στον κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων διαγράμματος.

## **Δημιουργία Διαγράμματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα παρουσιάζει μια ολοκληρωμένη ροή εργασίας. Δημιουργεί ένα συγκεντρωτικό γράφημα στήλης, διαγράφει τα δείγματα δεδομένων, γράφει τιμές εσόδων και εξόδων ανά τρίμηνο, υπολογίζει κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Τα σημεία δεδομένων του διαγράμματος παραπέμπουν στο `D2:D4`, έτσι το διάγραμμα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης διαγράμματος σε αυτή τη ροή: επανυπολογίστε πρώτα το workbook, έπειτα χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειογραφία A1 αναγνωρίζει τις στήλες με γράμματα και τις σειρές με αριθμούς. Αναθέστε εκφράσεις στυλ A1 μέσω του [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Κοινές μορφές αναφοράς A1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινηθεί ή αντιγραφεί από μια εφαρμογή λογιστικού φύλλου. Οι απόλυτες αναφορές διατηρούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές διόρθωσαν μόνο μια σειρά ή μια στήλη.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειογραφία R1C1 αναγνωρίζει τόσο τις σειρές όσο και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε αγκύλες. Αναθέστε αυτή τη σύνταξη μέσω του [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Κοινές μορφές αναφοράς R1C1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια σειρά δύο στήλες αριστερά (`B2`).

## **Σταθερές Τύπων και Τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικά λυτρά, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Κυριολεκτικά**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Logical | `TRUE`, `FALSE` | Μπορούν να χρησιμοποιηθούν άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται κοινή και επιστημονική σημειογραφία. |
| String | `"abc"`, `"2/3/2020 12:00"` | Τα λυτρά κειμένου περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος λογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί διάφορους τύπους σταθερών:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Αριθμητικοί Τελεστές**

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μονοπρόσημο συν | `2+3` |
| `-` | Αφαίρεση ή αρνητικό πρόσημο | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εξουσία | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε ρητό τη σειρά εκτίμησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ισότητα | `A2=3` |
| `<>` | Διάφορο από | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο με | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο με | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας διαγραμμάτων, αλλά δεν αποτελεί πλήρη μηχανή υπολογισμού Excel. Το τεκμηριωμένο σετ συναρτήσεων περιορίζεται στις παρακάτω συναρτήσεις. Μη υποθέτετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επανυπολογιστεί από το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση αριθμού προς τα πάνω στο πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με βάση δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγκέντρωση κειμένου | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγκέντρωση κειμένου | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας χρησιμοποιώντας το σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εντοπίζει μια συμβολοσειρά μέσα σε άλλη | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου σε επίπεδο byte | `FINDB("a",A2)` |
| `IF` | Υπό συνθήκη αποτέλεσμα | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Διάνυσμα μορφή | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Διάνυσμα μορφή | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροισμα τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κάθετη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί στον πίνακα είναι ουσιαστικοί: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ τα `LOOKUP` και `MATCH` τεκμηριώνονται σε μορφή διανύσματος. Η `DATE` χρησιμοποιεί το σύστημα ημερομηνίας 1900. Λειτουργίες και συναρτήσεις που δεν αναφέρονται εδώ θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Επανυπολογισμός και Τιμές σε Cache**

Τα αρχεία λογιστικού φύλλου συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία του υπολογισμένη τιμή. Το Aspose.Slides μπορεί έτσι να διαβάσει μια τιμή σε cache από το [IChartDataCell.getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#getValue--) όταν μια παρουσίαση φορτωθεί και τα σχετικά δεδομένα διαγράμματος δεν έχουν αλλάξει.

Μετά την αλλαγή των κελιών εισόδου ή των τύπων, μην βασίζεστε σε ένα παλιό αποτέλεσμα σε cache. Καλέστε το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποσυνόλου, το Aspose.Slides ενδέχεται να μην μπορεί να αναλύσει τον τύπο ή να καθορίσει τις εξαρτήσεις του. Εάν το workbook έχει τροποποιηθεί, η προηγούμενη τιμή σε cache δεν μπορεί πια να θεωρηθεί αξιόπιστη. Σε αυτή την περίπτωση, η ανάγνωση της τιμής κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει [CellUnsupportedDataException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellunsupporteddataexception/).

Εάν το διάγραμμά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή λογιστικού φύλλου που τα υποστηρίζει και γράψτε τις τελικές τιμές πίσω στο workbook του διαγράμματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εικαστικές τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικές κατηγορίες προβλημάτων που πρέπει να διακρίνετε.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος λογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτή την περίπτωση, το σφάλμα αποτελεί αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [IChartDataCell.getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#getValue--).

Ένας τύπος μπορεί επίσης να αποτύχει στο στάδιο ανάλυσης, αναφοράς, εξαρτήσεων ή δεδομένων που υποστηρίζονται. Το Aspose.Slides παρέχει εξαιρέσεις ειδικές για λογιστικά φύλλα: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellcircularreferenceexception/) και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή εισαγωγή χρήστη, χειριστείτε αυτές τις εξαιρέσεις γύρω από τον επανυπολογισμό και την πρόσβαση στις τιμές:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Πρακτικοί Περιορισμοί**

Η υποστήριξη τύπων σε φύλλα εργασίας διαγράμματος προορίζεται για ένα ορισμένο υποσύνολο υπολογισμών λογιστικού φύλλου, όχι για πλήρη συμβατότητα με Excel. Διατηρήστε αυτούς τους περιορισμούς στο μυαλό σας κατά το σχεδιασμό μιας ροής εργασίας αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεται το Aspose.Slides να επανυπολογίσει τύπους.
- Επανυπολογίστε μετά την αλλαγή των κελιών από τα οποία εξαρτώνται τα αποτελέσματα των τύπων.
- Θεωρήστε τις τιμές σε cache από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επανυπολογισμού μετά από επεξεργασία.
- Δοκιμάστε τους τύπους από υπάρχοντα πρότυπα πριν εμπιστευθείτε τις υπολογισμένες τιμές, ειδικά όταν χρησιμοποιούν συναρτήσεις εκτός του τεκμηριωμένου καταλόγου.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και στη συνέχεια ενημερώστε το workbook του διαγράμματος με τις προκύπτουσες τιμές.

## **ΣΥΝΗΘΕΣΜΕΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**What is the difference between [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) and [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα στον τρόπο που δημιουργείτε ή αντιγράφετε τύπους.

**Do I need to read the cell itself or its value after calculation?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) επιστρέφει ένα [IChartDataCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/). Για να αποκτήσετε το υπολογισμένο αποτέλεσμα, καλέστε τη μέθοδο [IChartDataCell.getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#getValue--) του κελιού μετά τον επανυπολογισμό.

**When should I call [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Καλέστε το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζει ο ενσωματωμένος αξιολογητής.

**Does Aspose.Slides support every Excel function?**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Οι συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι επανυπολογίζονται σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, εκτελέστε τον υπολογισμό με κατάλληλη μηχανή λογιστικού φύλλου και γράψτε τις τελικές τιμές στο workbook του διαγράμματος.

**What happens if a loaded presentation contains an unsupported formula?**

Εάν τα δεδομένα διαγράμματος δεν έχουν αλλάξει, το workbook ενδέχεται να περιέχει μια προηγούμενη υπολογισμένη τιμή σε cache. Αφού τροποποιηθούν τα σχετικά δεδομένα, αυτή η τιμή σε cache μπορεί να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να χειριστεί μπορεί να προκαλέσει [CellUnsupportedDataException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellunsupporteddataexception/).

**Are formula error values the same as Java exceptions?**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι μια τιμή λογιστικού φύλλου που παράγεται από έναν έγκυρο υπολογισμό. Εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellcircularreferenceexception/) υποδεικνύουν ότι ο τύπος δεν μπορεί να επεξεργαστεί κανονικά.

**Does a chart update automatically when a formula cell changes?**

Μία σειρά διαγράμματος μπορεί να παραπέμπει σε κελιά του workbook. Επανυπολογίστε πρώτα το workbook, κατόπιν αποθηκεύστε ή αποδώστε την παρουσίαση. Εάν τα σημεία δεδομένων του διαγράμματος παραπέμπουν στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης διαγράμματος για αυτή τη ροή.

**Can charts use an external Excel workbook?**

Ναι, τα δεδομένα διαγράμματος μπορούν να ρυθμιστούν για χρήση εξωτερικού workbook μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το workbook δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογεί το Aspose.Slides. Μην υποθέτετε ότι το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) παρέχει πλήρη επανυπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Can I use formulas that reference another worksheet or workbook?**

Οι αναφορές τύπου Excel μπορεί να υπάρχουν σε workbooks διαγραμμάτων, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο συναρτήσεων. Εάν μια αναφορά σε διαφορετικό φύλλο ή εξωτερικό αρχείο είναι απαραίτητη, ελέγξτε τον ακριβή τύπο με την έκδοση του Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το workbook εξωτερικά και γράψτε τις επιλυμένες τιμές πίσω στα δεδομένα διαγράμματος.

**Should formula strings start with `=`?**

Τα παραδείγματα API του Aspose.Slides αναθέτουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς προπομπή `=`. Η χρήση αυτής της μορφής διατηρεί τις δημιουργημένες εξισώσεις σύμφωνες με τα τεκμηριωμένα παραδείγματα API.