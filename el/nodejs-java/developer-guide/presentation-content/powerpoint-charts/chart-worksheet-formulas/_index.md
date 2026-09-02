---
title: Εφαρμογή τύπων φύλλου εργασίας γραφήματος σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Τύποι φύλλου εργασίας
type: docs
weight: 70
url: /el/nodejs-java/chart-worksheet-formulas/
keywords:
- πίνακας λογιστικού φύλλου
- φύλλο εργασίας γραφήματος
- τύπος γραφήματος
- τύπος φύλλου εργασίας
- τύπος λογιστικού φύλλου
- βιβλίο δεδομένων γραφήματος
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Εφαρμογή τύπων σε στυλ Excel στο Aspose.Slides για Node.js μέσω φύλλων εργασίας γραφήματος Java, επανυπολογισμός τιμών και χρήση των αποτελεσμάτων σε γραφήματα PowerPoint."
---
## **Επισκόπηση**

Οι πίνακες του PowerPoint αποθηκεύουν συνήθως τα δεδομένα πηγής τους σε ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides for Node.js via Java, μπορείτε να έχετε πρόσβαση σε αυτό το φύλλο μέσω του [ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/), να γράψετε τιμές εισόδου, να αναθέσετε τύπους σε κελιά, να υπολογίσετε υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα γραφήματος.

Αυτό το άρθρο εξηγεί τη συνολική ροή εργασίας τύπων: δημιουργία γραφήματος, πληρότητα του φύλλου εργασίας, ανάθεση τύπων στυλ A1 ή R1C1, επανυπολογισμός, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών σε σειρά γραφήματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη των υποστηριζόμενων τύπων, το ενσωματωμένο σύνολο συναρτήσεων, τις αποθηκευμένες τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα συγκεκριμένα για λογιστικά φύλλα.

## **Φύλλα Εργασίας Γραφημάτων και Τύποι**

Ένα φύλλο εργασίας γραφήματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί το γράφημα. Στο PowerPoint, μπορείτε να εξετάσετε το φύλλο ανοίγοντας τον επεξεργαστή δεδομένων γραφήματος:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εκτίθεται μέσω της κλάσης [ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/). Χρησιμοποιήστε [ChartDataCell.setFormula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) για τύπους στυλ A1 και [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) για τύπους στυλ R1C1. Αφού αλλάξετε κελιά εισόδου ή τύπους, καλέστε [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) για να επανυπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω του [ChartDataCell.getValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#getValue--). Αυτό είναι σημαντικό όταν χρειάζεται να ελέγξετε το αποτέλεσμα ενός τύπου στον κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων γραφήματος.

## **Δημιουργία Γραφήματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα παρουσιάζει μια πλήρη ροή εργασίας. Δημιουργεί ένα γράφημα στήλης ομαδοποιημένων, διαγράφει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές γραφήματος και αποθηκεύει την παρουσίαση.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Τα σημεία δεδομένων του γραφήματος αναφέρονται στο `D2:D4`, έτσι το γράφημα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης γραφήματος σε αυτή τη ροή: επανυπολογίστε πρώτα το βιβλίο εργασίας, κατόπιν χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα γραφήματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειογραφία A1 προσδιορίζει στήλες με γράμματα και γραμμές με αριθμούς. Αναθέστε εκφράσεις στυλ A1 μέσω του [ChartDataCell.setFormula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Κοινές μορφές αναφοράς A1:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `A2` | `$A$2` | `A$2`, `$A2` |
| Γραμμή | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Περιοχή | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινείται ή αντιγράφεται από μια εφαρμογή λογιστικού φύλλου. Οι απόλυτες αναφορές διατηρούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές διατηρούν μόνο μια γραμμή ή μια στήλη σταθερή.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειογραφία R1C1 προσδιορίζει τόσο γραμμές όσο και στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε αγκύλες. Αναθέστε αυτή τη σύνταξη μέσω του [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Κοινές μορφές αναφοράς R1C1:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Γραμμή | `R[2]` | `R2` | — |
| Στήλη | `C[3]` | `C3` | — |
| Περιοχή | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες αριστερά (`B2`).

## **Σταθερές Τύπων και Τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικούς λοβούς, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Λοβοί**

| Τύπος | Παραδείγματα | Σχόλια |
|---|---|---|
| Λογική | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητική | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται κοινή και επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Τα λεκτικά κυριολεξία περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος λογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί διάφορους τύπους σταθερών:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // ψευδής
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Αριθμητικοί Τελεστές**

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μονοειδές συν | `2+3` |
| `-` | Αφαίρεση ή αρνητικό | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Υψωση σε δύναμη | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να δηλώσετε ρητά τη σειρά εκτίμησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ισότητα | `A2=3` |
| `<>` | Ασυμφωνία | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο με | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο με | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας γραφημάτων, αλλά δεν αποτελεί πλήρη μηχανή υπολογισμού Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέτετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επανυπολογιστεί από το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με βάση δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγκόλληση κειμένων | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγκόλληση κειμένων | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστροφή αριθμού ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εύρεση κειμένου σε άλλο κείμενο | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου με προσανατολισμό σε byte | `FINDB("a",A2)` |
| `IF` | Συνθήκη | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροισμα τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί που εμφανίζονται στον πίνακα είναι σημαντικοί: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ τα `LOOKUP` και `MATCH` σε μορφές διανύσματος. Η `DATE` χρησιμοποιεί το σύστημα 1900. Λειτουργίες και συναρτήσεις που δεν εμφανίζονται εδώ θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Επαναϋπολογισμός και Αποθηκευμένες Τιμές**

Τα αρχεία λογιστικού φύλλου αποθηκεύουν συχνά τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί επομένως να διαβάσει μια αποθηκευμένη τιμή από το [ChartDataCell.getValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#getValue--) όταν φορτωθεί μια παρουσίαση και τα σχετικά δεδομένα γραφήματος δεν έχουν αλλάξει.

Αφού αλλάξετε κελιά εισόδου ή τύπους, μην βασίζεστε σε παλιά αποθηκευμένα αποτελέσματα. Καλέστε το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα γραφήματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides μπορεί να μην είναι σε θέση να αναλύσει τον τύπο ή να εντοπίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη αποθηκευμένη τιμή δεν μπορεί πλέον να θεωρηθεί αξιόπιστη. Σε αυτήν την κατάσταση, η ανάγνωση τιμής κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Εάν το γράφημά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή λογιστικού φύλλου που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας του γραφήματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εικαστικές τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να διαχωριστούν.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει σφάλμα λογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτή την περίπτωση, το σύμβολο σφάλματος είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [ChartDataCell.getValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Ένας τύπος μπορεί επίσης να αποτύχει σε επίπεδο ανάλυσης, αναφοράς, εξαρτήσεων ή υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις ειδικές για λογιστικά φύλλα για αυτές τις περιπτώσεις: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellcircularreferenceexception/) και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή είσοδο χρήστη, πιάστε τα σφάλματα γύρω από τον επανυπολογισμό και την πρόσβαση τιμής. Τα στοιχεία του σφάλματος εντοπίζουν το υποκείμενο πρόβλημα του λογιστικού φύλλου:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **Πρακτικοί Περιορισμοί**

Η υποστήριξη τύπων σε φύλλα εργασίας γραφημάτων προορίζεται για ένα καθορισμένο υποσύνολο υπολογισμών λογιστικού φύλλου, όχι για πλήρη συμβατότητα με το Excel. Λάβετε υπόψη αυτούς τους περιορισμούς όταν σχεδιάζετε μια ροή εργασίας αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεται το Aspose.Slides να επανυπολογίσει τύπους.
- Επαναϋπολογίστε μετά την αλλαγή κελιών από τα οποία εξαρτώνται τα αποτελέσματα των τύπων.
- Θεωρήστε τις αποθηκευμένες τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επανυπολογισμού μετά τις επεμβάσεις.
- Δοκιμάστε τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τιμές τους, ειδικά όταν χρησιμοποιούν συναρτήσεις εκτός του καταγραμμένου καταλόγου.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και έπειτα ενημερώστε το βιβλίο εργασίας του γραφήματος με τις προκύπτουσες τιμές.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ [ChartDataCell.setFormula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) και [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-);**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα στον τρόπο δημιουργίας ή αντιγραφής των τύπων.

**Πρέπει να διαβάσω το κελί ή την τιμή του μετά τον υπολογισμό;**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) επιστρέφει ένα [ChartDataCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/). Για να λάβετε το υπολογισμένο αποτέλεσμα, καλέστε την μέθοδο [ChartDataCell.getValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#getValue--) του κελιού μετά τον επανυπολογισμό.

**Πότε πρέπει να καλέσω το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--);**

Καλέστε το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζει ο ενσωματωμένος αξιολογητής.

**Υποστηρίζει το Aspose.Slides όλες τις συναρτήσεις του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι επανυπολογίζονται σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, πραγματοποιήστε τον υπολογισμό με κατάλληλη μηχανή λογιστικού φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας του γραφήματος.

**Τι συμβαίνει εάν μια φορτωμένη παρουσίαση περιέχει ανεξακάλυπτο τύπο;**

Εάν τα δεδομένα του γραφήματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμα να περιέχει μια προηγουμένως υπολογισμένη αποθηκευμένη τιμή. Μετά την τροποποίηση των σχετικών δεδομένων, αυτή η αποθηκευμένη τιμή μπορεί να μην είναι έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να αντιμετωπιστεί μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**Είναι οι τιμές σφάλματος τύπου ίδιες με εξαιρέσεις;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι τιμή λογιστικού φύλλου που παράγεται από έναν έγκυρο υπολογισμό. Εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellcircularreferenceexception/) υποδηλώνουν ότι ο τύπος δεν μπορεί να επεξεργαστεί κανονικά.

**Ανανεώνεται αυτόματα το γράφημα όταν αλλάζει ένα κελί τύπου;**

Μια σειρά γραφήματος μπορεί να αναφέρεται σε κελιά του βιβλίου εργασίας. Επαναϋπολογίστε πρώτα το βιβλίο εργασίας, κατόπιν αποθηκεύστε ή αποδώστε την παρουσίαση. Εάν τα σημεία δεδομένων του γραφήματος αναφέρονται στα υπολογισμένα κελιά, το γράφημα χρησιμοποιεί τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης γραφήματος για αυτή τη ροή.

**Μπορούν τα γραφήματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα γραφήματος μπορούν να ρυθμιστούν ώστε να χρησιμοποιούν εξωτερικό βιβλίο εργασίας μέσω του API δεδομένων γραφήματος. Ωστόσο, η ροή εργασίας υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο εργασίας δεδομένων γραφήματος και το υποσύνολο τύπων που αξιολογεί το Aspose.Slides. Μην υποθέτετε ότι το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) παρέχει πλήρη επανυπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο ή βιβλίο εργασίας;**

Οι αναφορές σε στυλ Excel μπορεί να υπάρχουν στα βιβλία εργασίας γραφημάτων, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο αναλυτή και σύνολο συναρτήσεων. Εάν μια αναφορά μεταξύ φύλλων ή εξωτερική αναφορά είναι απαραίτητη, επαληθεύστε ότι ο τύπος είναι ακριβής με την έκδοση Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εργασίας εξωτερικά και γράψτε τις προκύπτουσες τιμές πίσω στα δεδομένα γραφήματος.

**Πρέπει τα κείμενα τύπων να ξεκινούν με `=`;**

Τα παραδείγματα του API Aspose.Slides αναθέτουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς αρχικό `=`. Η χρήση αυτής της μορφής διατηρεί τους τύπους συνεπείς με τα τεκμηριωμένα παραδείγματα API.