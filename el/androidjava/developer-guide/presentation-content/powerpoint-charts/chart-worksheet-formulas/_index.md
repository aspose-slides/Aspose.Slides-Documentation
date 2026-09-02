---
title: Εφαρμογή τύπων φύλλου εργασίας διαγράμματος σε παρουσιάσεις σε Android
linktitle: Τύποι φύλλου εργασίας
type: docs
weight: 70
url: /el/androidjava/chart-worksheet-formulas/
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
- Android
- Java
- Aspose.Slides
description: "Εφαρμογή τύπων τύπου Excel στο Aspose.Slides για Android μέσω φύλλων εργασίας διαγράμματος Java, επανυπολογισμός τιμών και χρήση των αποτελεσμάτων σε διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα του PowerPoint συνήθως αποθηκεύουν τα αρχικά δεδομένα τους σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για Android μέσω Java, μπορείτε να προσπελάσετε το φύλλο εργασίας αυτό μέσω του βιβλίου εργασίας δεδομένων διαγράμματος, να γράψετε τιμές εισόδου, να ορίσετε τύπους σε κελιά, να υπολογίσετε υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Αυτό το άρθρο εξηγεί τη διαδικασία των τύπων από την αρχή έως το τέλος: δημιουργία ενός διαγράμματος, πλήρωση του φύλλου εργασίας του, ανάθεση τύπων στυλ A1 ή R1C1, επανυπολογισμός τους, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών με μια σειρά διαγράμματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη υποστηριζόμενων τύπων, το υποσύνολο ενσωματωμένων συναρτήσεων, τις τιμές σε cache, τους μη υποστηριζόμενους τύπους και τα σφάλματα που προέρχονται από το λογιστικό φύλλο.

## **Φύλλα εργασίας διαγραμμάτων και τύποι**

Ένα φύλλο εργασίας διαγράμματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί ένα διάγραμμα. Στο PowerPoint, μπορείτε να εξετάσετε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![Διάγραμμα PowerPoint με ανοιχτό το ενσωματωμένο φύλλο εργασίας, εμφανίζει δεδομένα κατηγοριών και σειρών](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω της διεπαφής [IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/). Χρησιμοποιήστε [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) για τύπους στυλ A1 και [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) για τύπους στυλ R1C1. Μετά την αλλαγή των κελιών εισόδου ή των τύπων, καλέστε [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) για να επανυπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω του [IChartDataCell.getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#getValue--). Αυτό είναι σημαντικό όταν χρειάζεται να εξετάσετε το αποτέλεσμα ενός τύπου σε κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων διαγράμματος.

## **Δημιουργία διαγράμματος και υπολογισμός τύπων φύλλου εργασίας**

Το παρακάτω παράδειγμα δείχνει μια ολοκληρωμένη ροή εργασίας. Δημιουργεί ένα διάγραμμα στήλης με ομάδα, καθαρίζει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

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

Τα σημεία δεδομένων του διαγράμματος αναφέρονται στο `D2:D4`, οπότε το διάγραμμα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ενημέρωσης διαγράμματος σε αυτή τη ροή εργασίας: υπολογίστε πρώτα το βιβλίο εργασίας, μετά χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση τύπων στυλ Α1**

Η σημειογραφία Α1 προσδιορίζει στήλες με γράμματα και γραμμές με αριθμούς. Αναθέστε εκφράσεις στυλ Α1 μέσω του [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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

Κοινές μορφές αναφοράς Α1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `A2` | `$A$2` | `A$2`, `$A2` |
| Γραμμή | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Περιοχή | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινηθεί ή αντιγραφεί από ένα λογιστικό φύλλο. Οι απόλυτες αναφορές διατηρούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές αναφορές σταθεροποιούν μόνο μια γραμμή ή μια στήλη.

## **Χρήση τύπων στυλ R1C1**

Η σημειογραφία R1C1 προσδιορίζει και γραμμές και στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε τετράγωνα αγκύλες. Αναθέστε αυτή τη σύνταξη μέσω του [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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
| Κελί | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Γραμμή | `R[2]` | `R2` | — |
| Στήλη | `C[3]` | `C3` | — |
| Περιοχή | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες αριστερά (`B2`).

## **Σταθερές τύπων και τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικά κυριολεξικά, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και κυριολεκτικά**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Λογικός | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητικός | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται κοινή και επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Τα κυριολεκτικά κείμενα περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος λογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί πολλούς τύπους σταθερών:

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

### **Αριθμητικοί τελεστές**

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μονοειδές + | `2+3` |
| `-` | Αφαίρεση ή αρνητικό | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εκθέτης | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε σαφή τη σειρά αξιολόγησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ίσο με | `A2=3` |
| `<>` | Διαφορετικό από | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο με | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο με | `A2<=3` |

## **Υποστηριζόμενες προεγκεκριμένες συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας διαγραμμάτων, αλλά δεν είναι πλήρης μηχανή υπολογισμού του Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέτετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επαναϋπολογιστεί με το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με βάση δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συνένωση κειμενικών τιμών | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συνένωση κειμενικών τιμών | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εύρεση μιας τιμής κειμένου μέσα σε άλλη | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου προσανατολισμένη σε bytes | `FINDB("a",A2)` |
| `IF` | Υπό συνθήκη αποτέλεσμα | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Δομή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Δομή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροισμα τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί που εμφανίζονται στον πίνακα είναι σημαντικοί: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ τα `LOOKUP` και `MATCH` τεκμηριώνονται σε μορφές διανύσματος. Το `DATE` χρησιμοποιεί το σύστημα ημερομηνίας 1900. Λειτουργίες και συναρτήσεις που δεν αναφέρονται εδώ πρέπει να θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων του Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Επανυπολογισμός και τιμές σε cache**

Τα αρχεία λογιστικού φύλλου συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί επομένως να διαβάσει μια τιμή σε cache από το [IChartDataCell.getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#getValue--) όταν μια παρουσίαση φορτώνεται και τα σχετικά δεδομένα διαγράμματος δεν έχουν αλλάξει.

Μετά την αλλαγή των κελιών εισόδου ή των τύπων, μην βασίζεστε σε ένα παλιό αποθηκευμένο αποτέλεσμα. Καλέστε το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides ενδέχεται να μην μπορεί να αναλύσει τον τύπο ή τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη τιμή σε cache δεν μπορεί πλέον να θεωρηθεί αξιόπιστη. Σε αυτή την κατάσταση, η ανάγνωση της τιμής ενός κελιού με μη υποστηριζόμενο δεδομένο μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Εάν το διάγραμμά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε εκείνους τους τύπους με μια μηχανή λογιστικού φύλλου που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας του διαγράμματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εικαστικές τιμές.

## **Διαχείριση σφαλμάτων τύπων**

Υπάρχουν δύο διαφορετικές κατηγορίες προβλημάτων που πρέπει να διακριθούν.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος λογιστικού φύλλου, π.χ. `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, ή `#VALUE!`. Σε αυτή την περίπτωση, το σφάλμα είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [IChartDataCell.getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

Ένας τύπος μπορεί επίσης να αποτύχει σε επίπεδο ανάλυσης, αναφοράς, εξάρτησης ή υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις ειδικές για λογιστικά φύλλα για αυτές τις περιπτώσεις: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή είσοδο χρήστη, χειριστείτε αυτές τις εξαιρέσεις γύρω από τον επανυπολογισμό και την πρόσβαση τιμών:

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

## **Πρακτικοί περιορισμοί**

Η υποστήριξη τύπων σε φύλλα εργασίας διαγράμματος προορίζεται για ένα καθορισμένο υποσύνολο υπολογισμών λογιστικού φύλλου, όχι για πλήρη συμβατότητα με το Excel. Κρατήστε αυτούς τους περιορισμούς στο μυαλό σας όταν σχεδιάζετε μια ροή εργασίας αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεστε τον επανυπολογισμό τύπων από το Aspose.Slides.
- Επανυπολογίστε μετά την αλλαγή των κελιών από τα οποία εξαρτώνται τα αποτελέσματα τύπων.
- Θεωρήστε τις τιμές σε cache από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επανυπολογισμού μετά από επεξεργασίες.
- Ελέγξτε τους τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τιμές τους, ειδικά όταν χρησιμοποιούν συναρτήσεις εκτός της τεκμηριωμένης λίστας.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και στη συνέχεια ενημερώστε το βιβλίο εργασίας του διαγράμματος με τις προκύπτουσες τιμές.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) και [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-);**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα στο πώς δημιουργείτε ή αντιγράψετε τύπους.

**Πρέπει να διαβάσω το ίδιο το κελί ή την τιμή του μετά τον υπολογισμό;**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) επιστρέφει ένα [IChartDataCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/). Για να λάβετε το υπολογισμένο αποτέλεσμα, καλέστε τη μέθοδο [IChartDataCell.getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#getValue--) του κελιού μετά τον επανυπολογισμό.

**Πότε πρέπει να καλέσω το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--);**

Καλέστε το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζει ο ενσωματωμένος αξιολογητής.

**Το Aspose.Slides υποστηρίζει κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Οι συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι θα επαναυπολογιστούν σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, εκτελέστε τον υπολογισμό με μια κατάλληλη μηχανή λογιστικού φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας του διαγράμματος.

**Τι συμβαίνει αν μια φορτωμένη παρουσίαση περιέχει έναν μη υποστηριζόμενο τύπο;**

Εάν τα δεδομένα του διαγράμματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμη να περιέχει μια προηγουμένως υπολογισμένη τιμή σε cache. Μετά την τροποποίηση των σχετικών δεδομένων, αυτή η τιμή σε cache μπορεί να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να διαχειριστεί μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**Οι τιμές σφάλματος τύπων είναι το ίδιο με τις εξαιρέσεις Java;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι μια τιμή λογιστικού φύλλου που παράγεται από έναν έγκυρο υπολογισμό. Εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellcircularreferenceexception/) υποδεικνύουν ότι ο τύπος δεν μπορεί να επεξεργαστεί κανονικά.

**Το διάγραμμα ενημερώνεται αυτόματα όταν αλλάζει το κελί τύπου;**

Μια σειρά διαγράμματος μπορεί να αναφέρεται σε κελιά βιβλίου εργασίας. Επανυπολογίστε πρώτα το βιβλίο εργασίας, μετά αποθηκεύστε ή αποδώστε την παρουσίαση. Εάν τα σημεία δεδομένων του διαγράμματος αναφέρονται στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί αυτές τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ενημέρωσης διαγράμματος για αυτή τη ροή εργασίας.

**Μπορούν τα διαγράμματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα διαγράμματος μπορούν να διαμορφωθούν ώστε να χρησιμοποιούν εξωτερικό βιβλίο εργασίας μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή εργασίας υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογεί το Aspose.Slides. Μην υποθέτετε ότι το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) παρέχει πλήρη επανυπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο ή βιβλίο εργασίας;**

Οι αναφορές τύπων στυλ Excel μπορεί να υπάρχουν σε βιβλία εργασίας διαγράμματος, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο συναρτήσεων. Εάν μια διασταυρούμενη αναφορά φύλλου ή εξωτερική είναι κρίσιμη, επαληθεύστε τον ακριβή τύπο με την έκδοση του Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εργασίας εκτός και γράψτε τις επιλυμένες τιμές πίσω στα δεδομένα διαγράμματος.

**Πρέπει οι συμβολοσειρές τύπων να ξεκινούν με `=`;**

Τα παραδείγματα του API Aspose.Slides αναθέτουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς προπορευόμενο `=`. Η χρήση αυτής της μορφής διατηρεί τους παραγόμενους τύπους συνεπείς με τα τεκμηριωμένα παραδείγματα API.