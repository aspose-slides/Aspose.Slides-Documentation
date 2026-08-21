---
title: Εφαρμογή Τύπων Φύλλου Εργασίας Διαγράμματος σε Παρουσιάσεις στο Android
linktitle: Τύποι Φύλλου Εργασίας
type: docs
weight: 70
url: /el/androidjava/chart-worksheet-formulas/
keywords:
- τύπος διαγράμματος υπολογιστικού φύλλου
- φύλλο εργασίας διαγράμματος
- τύπος διαγράμματος
- τύπος φύλλου εργασίας
- τύπος υπολογιστικού φύλλου
- βιβλίο δεδομένων διαγράμματος
- υπολογισμός τύπου
- προτιμώμενη πολιτισμική ρύθμιση
- τύπος εξειδικευμένο πολιτισμικά
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
- Android
- Java
- Aspose.Slides
description: "Εφαρμόστε τύπους τύπου Excel σε φύλλα εργασίας διαγράμματος στο Aspose.Slides για Android μέσω Java, επαναϋπολογίστε τις τιμές και χρησιμοποιήστε τα αποτελέσματα σε διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα PowerPoint αποθηκεύουν συνήθως τα δεδομένα προέλευσής τους σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για Android μέσω Java, μπορείτε να έχετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του βιβλίου εργασίας δεδομένων διαγράμματος, να γράψετε τιμές εισόδου, να ορίσετε τύπους σε κελιά, να υπολογίσετε τους υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Αυτό το άρθρο εξηγεί τη πλήρη ροή εργασίας τύπων: δημιουργία διαγράμματος, γέμισμα του φύλλου εργασίας του, ανάθεση τύπων στυλ A1 ή R1C1, επαναϋπολογισμό τους, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών με μια σειρά διαγράμματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη των υποστηριζόμενων τύπων, το ενσωματωμένο υποσύνολο συναρτήσεων, τις αποθηκευμένες τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα ειδικά για υπολογιστικά φύλλα.

## **Φύλλα Εργασίας Διαγράμματος και Τύποι**

Ένα φύλλο εργασίας διαγράμματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιούνται από ένα διάγραμμα. Στο PowerPoint, μπορείτε να ελέγξετε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![Διάγραμμα PowerPoint με το ενσωματωμένο φύλλο εργασίας ανοιχτό, εμφανίζει δεδομένα κατηγοριών και σειρών](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω της διεπαφής [IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/) . Χρησιμοποιήστε το [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) για τύπους στυλ A1 και το [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) για τύπους στυλ R1C1. Μετά την αλλαγή των κελιών εισόδου ή των τύπων, καλέστε το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) για επαναϋπολογισμό των υποστηριζόμενων τύπων και ενημέρωση των αντίστοιχων τιμών κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω του [IChartDataCell.getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#getValue--). Αυτό είναι σημαντικό όταν χρειάζεται να ελέγξετε το αποτέλεσμα ενός τύπου στον κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων διαγράμματος.

## **Δημιουργία Διαγράμματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα παρουσιάζει μια ολοκληρωμένη ροή εργασίας. Δημιουργεί ένα στήλης συγκεντρωτικού τύπου, διαγράφει τα δείγματα δεδομένων, γράφει τιμές τριμηνιαίου εσόδους και εξόδων, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

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

Τα σημεία δεδομένων του διαγράμματος αναφέρονται στο `D2:D4`, επομένως το διάγραμμα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης διαγράμματος σε αυτήν την ροή: υπολογίστε πρώτα το βιβλίο εργασίας, έπειτα χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειογραφία A1 προσδιορίζει τις στήλες με γράμματα και τις σειρές με αριθμούς. Αναθέστε εκφράσεις στυλ A1 μέσω του [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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
| Σειρά | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Περιοχή | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινείται ή αντιγράφεται από την εφαρμογή υπολογιστικού φύλλου. Οι απόλυτες αναφορές διατηρούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές αναφορές σταθεροποιούν μόνο μια σειρά ή μια στήλη.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειογραφία R1C1 προσδιορίζει τόσο τις σειρές όσο και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατόπιση σε τετράγωνα brackets. Αναθέστε αυτή τη σύνταξη μέσω του [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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
| Σειρά | `R[2]` | `R2` | — |
| Στήλη | `C[3]` | `C3` | — |
| Περιοχή | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια σειρά δύο στήλες αριστερά (`B2`).

## **Σταθερές και Τελεστές Τύπων**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικά λήμματα, συμβολοσειρές, τιμές σφάλματος υπολογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Λήμματα**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Λογική | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητική | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται η κοινή και η επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Τα λήμματα κειμένου περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος υπολογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

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
| `+` | Πρόσθεση ή μονάδα θετικού | `2+3` |
| `-` | Αφαίρεση ή αρνητικό | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εκθετική | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε την σειρά εκτίμησης σαφή, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι συγκριτικές εκφράσεις επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ίσο με | `A2=3` |
| `<>` | Διαφορετικό από | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο με | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο με | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας διαγράμματος, αλλά δεν είναι πλήρης μηχανή υπολογισμού Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέτετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επαναϋπολογιστεί από το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγχώνευση κειμενικών τιμών | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγχώνευση κειμενικών τιμών | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα ημερομηνίας 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εντοπίζει ένα κείμενο μέσα σε άλλο | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου με προσανατολισμό byte | `FINDB("a",A2)` |
| `IF` | Συνθήκη | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροιση τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί στον πίνακα είναι ουσιαστικοί: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ το `LOOKUP` και το `MATCH` σε μορφές διανύσματος. Το `DATE` χρησιμοποιεί το σύστημα ημερομηνίας 1900. Τα χαρακτηριστικά και οι συναρτήσεις που δεν εμφανίζονται εδώ πρέπει να θεωρούνται μη υποστηριζόμενα από τον αξιολογητή τύπων Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Υπολογισμός Τύπων με Προτιμώμενη Πολιτισμική Ρυθμίση**

Ορισμένες λειτουργίες του βιβλίου εργασίας διαγράμματος ερμηνεύουν κείμενο σύμφωνα με πολιτισμικούς κανόνες. Αυτό είναι ιδιαίτερα σημαντικό για λειτουργίες που προορίζονται για γλώσσες που χρησιμοποιούν σύνολα διπλού-byte χαρακτήρων (DBCS). Για σωστό υπολογισμό τέτοιων τύπων, δημιουργήστε [LoadOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/), ορίστε την προτιμώμενη πολιτισμική ρύθμιση με το [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), αναθέστε τις επιλογές υπολογιστικού φύλλου μέσω του [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), και, στη συνέχεια, φορτώστε την παρουσίαση.

Το παρακάτω παράδειγμα επιλέγει την Ιαπωνική πολιτισμική ρύθμιση, ανοίγει μια παρουσίαση με τις διαμορφωμένες επιλογές φόρτωσης και καλεί το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) για κάθε βιβλίο εργασίας διαγράμματος:

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

Η προτιμώμενη πολιτισμική ρύθμιση είναι μέρος της παραμετροποίησης φόρτωσης της παρουσίασης, επομένως πρέπει να οριστεί πριν από τη δημιουργία του αντικειμένου [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/). Χρησιμοποιήστε την πολιτισμική που απαιτείται από τους τύπους του βιβλίου εργασίας· για παράδειγμα, `ja-JP` για τύπους που πρέπει να ακολουθούν τους Ιαπωνικούς κανόνες DBCS.

## **Επαναϋπολογισμός και Αποθηκευμένες Τιμές**

Τα αρχεία υπολογιστικών φύλλων συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί επομένως να διαβάσει μια αποθηκευμένη τιμή από το [IChartDataCell.getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#getValue--) όταν μια παρουσίαση φορτώνεται και τα σχετικά δεδομένα διαγράμματος δεν έχουν αλλάξει.

Μετά την αλλαγή των κελιών εισόδου ή των τύπων, μην βασίζεστε σε παλιά αποθηκευμένα αποτελέσματα. Καλέστε το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides μπορεί να μην είναι σε θέση να αναλύσει τον τύπο ή να εντοπίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη αποθηκευμένη τιμή δεν μπορεί πλέον να θεωρηθεί αξιόπιστη. Σε αυτήν την περίπτωση, η ανάγνωση της τιμής ενός κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει [CellUnsupportedDataException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Εάν το διάγραμμα σας εξαρτάται από λειτουργίες Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή υπολογιστικού φύλλου που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας διαγράμματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εκτιμώμενες τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να διακρίνουμε.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος υπολογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτήν την περίπτωση, το σφάλμα είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [IChartDataCell.getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

Ένας τύπος μπορεί επίσης να αποτύχει σε επίπεδο ανάλυσης, αναφοράς, εξάρτησης ή υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει ειδικές εξαιρέσεις υπολογιστικού φύλλου για αυτές τις περιπτώσεις: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή εισροές χρήστη, χειριστείτε αυτές τις εξαιρέσεις γύρω από τον επαναϋπολογισμό και την πρόσβαση στις τιμές:

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

Η υποστήριξη τύπων σε φύλλα εργασίας διαγράμματος προορίζεται για ένα καθορισμένο υποσύνολο υπολογισμών υπολογιστικού φύλλου, όχι για πλήρη συμβατότητα Excel. Λάβετε υπόψη αυτούς τους περιορισμούς κατά το σχεδιασμό μιας ροής αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεστε τον επαναϋπολογισμό τύπων από το Aspose.Slides.
- Επαναϋπολογίστε μετά την αλλαγή των κελιών στα οποία εξαρτώνται τα αποτελέσματα τύπων.
- Θεωρήστε τις αποθηκευμένες τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επαναυπολογισμού μετά τις επεξεργασίες.
- Δοκιμάστε τους τύπους από υπάρχοντα πρότυπα πριν εμπιστευτείτε τις υπολογισμένες τιμές τους, ειδικά όταν χρησιμοποιούν συναρτήσεις εκτός της τεκμηριωμένης λίστας.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού υπολογιστικού φύλλου, υπολογίστε τους εξωτερικά και, στη συνέχεια, ενημερώστε το βιβλίο εργασίας διαγράμματος με τις προκύπτουσες τιμές.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ [IChartDataCell.setFormula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) και [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-);**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα στον τρόπο που δημιουργείτε ή αντιγράφετε τύπους.

**Πρέπει να διαβάζω το κελί ή την τιμή του μετά τον υπολογισμό;**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) επιστρέφει ένα [IChartDataCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/). Για την απόκτηση του υπολογισμένου αποτελέσματος, καλέστε τη μέθοδο [IChartDataCell.getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#getValue--) του κελιού μετά τον επαναϋπολογισμό.

**Πότε πρέπει να καλέσω το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--);**

Καλέστε το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν βασιστείτε στα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζει ο ενσωματωμένος αξιολογητής.

**Υποστηρίζει το Aspose.Slides κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Οι συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι επαναϋπολογίζονται σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, εκτελέστε τον υπολογισμό με κατάλληλη μηχανή υπολογιστικού φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας διαγράμματος.

**Τι συμβαίνει αν μια φορτωμένη παρουσίαση περιέχει έναν μη υποστηριζόμενο τύπο;**

Εάν τα δεδομένα διαγράμματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμη να περιέχει μια προηγουμένως υπολογισμένη αποθηκευμένη τιμή. Αφού τροποποιηθούν τα σχετικά δεδομένα, αυτή η αποθηκευμένη τιμή μπορεί να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να επεξεργαστεί μπορεί να προκαλέσει [CellUnsupportedDataException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**Είναι οι τιμές σφάλματος τύπων το ίδιο με τις εξαιρέσεις Java;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι τιμή υπολογιστικού φύλλου που προκύπτει από έγκυρο υπολογισμό. Εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellcircularreferenceexception/) υποδεικνύουν ότι ο τύπος δεν μπορεί να επεξεργαστεί κανονικά.

**Ενημερώνεται αυτόματα το διάγραμμα όταν αλλάζει ένα κελί τύπου;**

Μια σειρά διαγράμματος μπορεί να αναφέρει κελιά του βιβλίου εργασίας. Επαναϋπολογίστε πρώτα το βιβλίο εργασίας, έπειτα αποθηκεύστε ή αποδώστε την παρουσίαση. Εάν τα σημεία δεδομένων του διαγράμματος αναφέρονται στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ενημέρωσης διαγράμματος για αυτήν τη ροή.

**Μπορούν τα διαγράμματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα διαγράμματος μπορούν να ρυθμιστούν ώστε να χρησιμοποιούν ένα εξωτερικό βιβλίο εργασίας μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο εργασίας δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογεί το Aspose.Slides. Μην υποθέτετε ότι το [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) παρέχει πλήρη επαναϋπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο ή βιβλίο εργασίας;**

Οι αναφορές τύπου Excel μπορεί να υπάρχουν σε βιβλία εργασίας διαγράμματος, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο parser και το σύνολο συναρτήσεων. Εάν μια διασυνοριακή ή εξωτερική αναφορά είναι απαραίτητη, επικυρώστε τον ακριβή τύπο με την έκδοση του Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εργασίας εξωτερικά και γράψτε τις επιλυμένες τιμές πίσω στα δεδομένα διαγράμματος.

**Πρέπει οι συμβολοσειρές τύπων να αρχίζουν με `=`;**

Τα παραδείγματα API του Aspose.Slides αναθέτουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς το αρχικό `=`. Η χρήση αυτής της μορφής κρατά τους δημιουργημένους τύπους σύμφωνους με τα τεκμηριωμένα παραδείγματα API.