---
title: Εφαρμογή τύπων φύλλου εργασίας γραφήματος σε παρουσιάσεις σε Java
linktitle: Τύποι φύλλου εργασίας
type: docs
weight: 70
url: /el/java/chart-worksheet-formulas/
keywords:
- γράφημα λογιστικό φύλλο
- φύλλο εργασίας γραφήματος
- τύπος γραφήματος
- τύπος φύλλου εργασίας
- τύπος λογιστικού φύλλου
- βιβλίο δεδομένων γραφήματος
- υπολογισμός τύπου
- προτιμώμενος πολιτισμός
- τύπος ειδικού πολιτισμού
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
- Java
- Aspose.Slides
description: "Εφαρμόστε τύπους σε στυλ Excel σε φύλλα εργασίας γραφήματος Aspose.Slides για Java, επανυπολογίστε τις τιμές και χρησιμοποιήστε τα αποτελέσματα σε γραφήματα PowerPoint."
---
## **Επισκόπηση**

Οι γραφήματα PowerPoint συνήθως αποθηκεύουν τα δεδομένα προέλευσής τους σε ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides for Java, μπορείτε να έχετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του βιβλίου εργασίας δεδομένων γραφήματος, να γράψετε τιμές εισόδου, να αντιστοιχίσετε τύπους σε κελιά, να υπολογίσετε υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα γραφήματος.

Αυτό το άρθρο εξηγεί τη διαδικασία τύπου πλήρους: δημιουργία γραφήματος, πληρότητα του φύλλου εργασίας, αντιστοίχιση τύπων στυλ A1 ή R1C1, επανυπολογισμός τους, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών σε σειρά γραφήματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη τύπων που υποστηρίζονται, το ενσωματωμένο υποσύνολο συναρτήσεων, τις τιμές στην προσωρινή μνήμη, τους μη υποστηριζόμενους τύπους και τα σφάλματα ειδικά για φύλλα εργασίας.

## **Φύλλα Εργασίας Γραφήματος και Τύποι**

Ένα φύλλο εργασίας γραφήματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιούνται από ένα γράφημα. Στο PowerPoint, μπορείτε να επιθεωρήσετε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων γραφήματος:

![Διάγραμμα PowerPoint με ανοιχτό το ενσωματωμένο φύλλο εργασίας, εμφανίζοντας δεδομένα κατηγορίας και σειράς](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω της διεπαφής [IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/). Χρησιμοποιήστε [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) για τύπους στυλ A1 και [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) για τύπους στυλ R1C1. Μετά την αλλαγή των κελιών εισόδου ή των τύπων, καλέστε [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) για να επανυπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω του [IChartDataCell.getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#getValue--). Αυτό είναι σημαντικό όταν χρειάζεται να επιθεωρήσετε το αποτέλεσμα τύπου σε κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων γραφήματος.

## **Δημιουργία Γραφήματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα δείχνει μια ολοκληρωμένη ροή εργασίας. Δημιουργεί ένα γράφημα στήλης με ομαδοποίηση, καθαρίζει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές γραφήματος και αποθηκεύει την παρουσίαση.

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

Τα σημεία δεδομένων του γραφήματος αναφέρονται στο `D2:D4`, έτσι το γράφημα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης γραφήματος σε αυτήν τη ροή: επανυπολογίστε πρώτα το βιβλίο εργασίας, στη συνέχεια χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα γραφήματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειογραφία A1 ταυτοποιεί τις στήλες με γράμματα και τις γραμμές με αριθμούς. Αντιστοιχίστε εκφράσεις στυλ A1 μέσω του [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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
| Κελί | `A2` | `$A$2` | `A$2`, `$A2` |
| Γραμμή | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Περιοχή | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινείται ή αντιγράφεται από μια εφαρμογή λογιστικού φύλλου. Οι απόλυτες αναφορές διατηρούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές διορθώνουν μόνο μια γραμμή ή μια στήλη.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειογραφία R1C1 ταυτοποιεί τόσο τις γραμμές όσο και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε τετράγωνα αγκύλες. Αντιστοιχίστε αυτή τη σύνταξη μέσω του [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες προς τα αριστερά (`B2`).

## **Σταθερά Τύπων και Τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικούς λεκτικούς, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Λεκτικά**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Λογική | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητική | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται κοινές και επιστημονικές σημειώσεις. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Τα λεκτικά κείμενα περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος λογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί πολλαπλούς τύπους σταθερών:

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // ψευδές
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
| `+` | Πρόσθεση ή μονός σύνθετος | `2+3` |
| `-` | Αφαίρεση ή αρνητικός | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εκθέτης | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε ρητό τη σειρά αξιολόγησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ίσο με | `A2=3` |
| `<>` | Διάφορο από | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο με | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο με | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας γραφήματος, αλλά δεν είναι πλήρης μηχανή υπολογισμών Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέτετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επανυπολογιστεί με το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγκόλληση κειμενικών τιμών | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγκόλληση κειμενικών τιμών | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Βρίσκει ένα κείμενο μέσα σε άλλο | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου κατά byte | `FINDB("a",A2)` |
| `IF` | Συνθήκη | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροιση τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί στον παραπάνω πίνακα είναι σημαντικοί: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ το `LOOKUP` και το `MATCH` σε μορφές διανύσματος. Η `DATE` χρησιμοποιεί το σύστημα 1900. Λειτουργίες και συναρτήσεις που δεν αναγράφονται εδώ πρέπει να θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Υπολογισμός Τύπων με Προτιμώμενο Πολιτισμό**

Ορισμένες λειτουργίες βιβλίου εργασίας ερμηνεύουν κείμενο σύμφωνα με κανόνες συγκεκριμένου πολιτισμού. Αυτό είναι ιδιαίτερα σημαντικό για λειτουργίες που προορίζονται για γλώσσες με σύστημα διπλού byte (DBCS). Για σωστό υπολογισμό, δημιουργήστε [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/), ορίστε το προτιμώμενο πολιτισμό με [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/el/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), αντιστοιχίστε τις επιλογές λογιστικού φύλλου μέσω [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), και κατόπιν φορτώστε την παρουσίαση.

Το παρακάτω παράδειγμα επιλέγει τον ιαπωνικό πολιτισμό, ανοίγει μια παρουσίαση με τις ρυθμισμένες επιλογές φόρτωσης και καλεί το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) για κάθε βιβλίο εργασίας γραφήματος:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ο προτιμώμενος πολιτισμός αποτελεί μέρος της διαμόρφωσης φόρτωσης παρουσίασης, οπότε ορίστε τον πριν δημιουργήσετε το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Χρησιμοποιήστε τον πολιτισμό που αναμένεται από τους τύπους του βιβλίου εργασίας· π.χ., `ja-JP` για τύπους που πρέπει να ακολουθούν τους ιαπωνικούς κανόνες DBCS.

## **Επαναϋπολογισμός και Τιμές στην Προσωρινή Μνήμη**

Τα αρχεία λογιστικών φύλλων συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί επομένως να διαβάσει μια τιμή στην προσωρινή μνήμη από το [IChartDataCell.getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#getValue--) όταν η παρουσίαση φορτώνεται και τα σχετικά δεδομένα γραφήματος δεν έχουν αλλάξει.

Αφού αλλάξετε κελιά εισόδου ή τύπους, μην βασίζεστε σε παλιό αποτέλεσμα στην προσωρινή μνήμη. Καλέστε το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) πριν διαβάσετε υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα γραφήματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides μπορεί να μην μπορεί να αναλύσει τον τύπο ή να εντοπίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη τιμή στην προσωρινή μνήμη δεν μπορεί πλέον να θεωρηθεί αξιόπιστη. Σε αυτή την περίπτωση, η ανάγνωση τιμής κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει [CellUnsupportedDataException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellunsupporteddataexception/).

Αν το γράφημά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή λογιστικού φύλλου που τους υποστηρίζει και γράψτε τις τελικές τιμές πίσω στο βιβλίο εργασίας γραφήματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εικαστικές τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να διακρίνετε.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος λογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτήν την περίπτωση, το σήμα σφάλματος είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [IChartDataCell.getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#getValue--).

Ένας τύπος μπορεί επίσης να αποτύχει σε επίπεδο ανάλυσης, αναφοράς, εξάρτησης ή υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις ειδικές για λογιστικά φύλλα: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή είσοδο χρήστη, διαχειριστείτε αυτές τις εξαιρέσεις γύρω από τον επανυπολογισμό και την πρόσβαση στις τιμές:

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

Η υποστήριξη τύπων σε φύλλα εργασίας γραφήματος προορίζεται για ένα καθορισμένο υποσύνολο υπολογισμών λογιστικού φύλλου, όχι για πλήρη συμβατότητα με το Excel. Κρατήστε αυτούς τους περιορισμούς στο μυαλό σας κατά το σχεδιασμό μιας ροής αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεται το Aspose.Slides να επανυπολογίσει τύπους.
- Επαναϋπολογίστε μετά την αλλαγή κελιών από τα οποία εξαρτώνται τα αποτελέσματα τύπων.
- Θεωρήστε τις τιμές στην προσωρινή μνήμη από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επανυπολογισμού μετά τις επεξεργασίες.
- Δοκιμάστε τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τιμές τους, ειδικά όταν χρησιμοποιούν συναρτήσεις εκτός του τεκμηριωμένου καταλόγου.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και έπειτα ενημερώστε το βιβλίο εργασίας γραφήματος με τις προκύπτουσες τιμές.

## **Συχνές Ερωτήσεις**

**Ποια η διαφορά μεταξύ [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) και [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-);**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα στον τρόπο με τον οποίο δημιουργείτε ή αντιγράφετε τύπους.

**Πρέπει να διαβάσω το κελί ή τη τιμή του μετά τον υπολογισμό;**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) επιστρέφει ένα [IChartDataCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/). Για να λάβετε το υπολογισμένο αποτέλεσμα, καλέστε τη μέθοδο [IChartDataCell.getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#getValue--) του κελιού μετά τον επανυπολογισμό.

**Πότε πρέπει να καλέσω το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--);**

Καλέστε το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζει ο ενσωματωμένος αξιολογητής.

**Υποστηρίζει το Aspose.Slides κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Οι συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι επανυπολογίζονται σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, κάντε τον υπολογισμό με κατάλληλη μηχανή λογιστικού φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας γραφήματος.

**Τι συμβαίνει αν μια φορτωμένη παρουσίαση περιέχει έναν μη υποστηριζόμενο τύπο;**

Αν τα δεδομένα του γραφήματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμα να περιέχει μια προηγούμενα υπολογισμένη τιμή στην προσωρινή μνήμη. Αφού τροποποιηθούν τα σχετικά δεδομένα, αυτή η τιμή πιθανόν να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να επεξεργαστεί μπορεί να προκαλέσει [CellUnsupportedDataException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellunsupporteddataexception/).

**Είναι οι τιμές σφάλματος τύπου οι ίδιες με τις εξαιρέσεις Java;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι τιμή λογιστικού φύλλου που παράγεται από έγκυρο υπολογισμό. Οι εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellcircularreferenceexception/) υποδεικνύουν ότι ο τύπος δεν μπορεί να επεξεργασθεί κανονικά.

**Ενημερώνεται αυτόματα το γράφημα όταν αλλάζει το κελί τύπου;**

Μια σειρά γραφήματος μπορεί να αναφέρεται σε κελιά του βιβλίου εργασίας. Επαναϋπολογίστε το βιβλίο εργασίας πρώτα, στη συνέχεια αποθηκεύστε ή αποδώστε την παρουσίαση. Αν τα σημεία δεδομένων του γραφήματος αναφέρονται στα υπολογισμένα κελιά, το γράφημα χρησιμοποιεί τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης γραφήματος για αυτή τη ροή.

**Μπορούν τα γραφήματα να χρησιμοποιήσουν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα γραφήματος μπορούν να ρυθμιστούν ώστε να χρησιμοποιούν εξωτερικό βιβλίο εργασίας μέσω του API δεδομένων γραφήματος. Ωστόσο, η ροή υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο εργασίας δεδομένων γραφήματος και το υποσύνολο τύπων που αξιολογεί το Aspose.Slides. Μην υποθέτετε ότι το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) παρέχει πλήρη επανυπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο ή βιβλίο εργασίας;**

Οι αναφορές τύπων στυλ Excel μπορεί να υπάρχουν στα βιβλία εργασίας γραφήματος, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο συναρτήσεων. Εάν μια αναφορά μεταξύ φύλλων ή εξωτερική είναι απαραίτητη, επαληθεύστε ότι ο ακριβής τύπος λειτουργεί με την έκδοση Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εργασίας εξωτερικά και γράψτε τις επιλυμένες τιμές πίσω στα δεδομένα γραφήματος.

**Πρέπει οι συμβολοσειρές τύπων να ξεκινούν με `=`;**

Τα παραδείγματα του API Aspose.Slides αποδίδουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς αρχικό `=`. Η χρήση αυτής της μορφής διασφαλίζει ότι οι παραγόμενοι τύποι είναι σύμφωνοι με τα τεκμηριωμένα παραδείγματα του API.