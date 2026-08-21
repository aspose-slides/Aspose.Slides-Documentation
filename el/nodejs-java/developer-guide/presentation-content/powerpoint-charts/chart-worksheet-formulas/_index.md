---
title: Εφαρμογή Τύπων Φύλλου Εργασίας Διαγράμματος σε Παρουσιάσεις Χρησιμοποιώντας JavaScript
linktitle: Τύποι Φύλλου Εργασίας
type: docs
weight: 70
url: /el/nodejs-java/chart-worksheet-formulas/
keywords:
- λογιστικό φύλλο διαγράμματος
- φύλλο εργασίας διαγράμματος
- τύπος διαγράμματος
- τύπος φύλλου εργασίας
- τύπος λογιστικού φύλλου
- βιβλίο δεδομένων διαγράμματος
- υπολογισμός τύπου
- προτιμώμενος πολιτισμός
- τύπος ειδικός για πολιτισμό
- DBCS
- λογική σταθερά
- αριθμητική σταθερά
- σταθερά συμβολοσειράς
- σταθερά σφάλματος
- αριθμητικός τελεστής
- τελεστής σύγκρισης
- μορφή A1
- μορφή R1C1
- προκαθορισμένη συνάρτηση
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εφαρμόστε τύπους σε στυλ Excel στο Aspose.Slides για Node.js μέσω φύλλων εργασίας διαγράμματος Java, επαναϋπολογίστε τις τιμές και χρησιμοποιήστε τα αποτελέσματα σε διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα PowerPoint συνήθως αποθηκεύουν τα δεδομένα προέλευσης σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για Node.js μέσω Java, μπορείτε να αποκτήσετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του βιβλίου εργασίας δεδομένων διαγράμματος, να γράψετε τιμές εισόδου, να αντιστοιχίσετε τύπους σε κελιά, να υπολογίσετε τους υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Αυτό το άρθρο εξηγεί τη πλήρη ροή εργασίας των τύπων: δημιουργία διαγράμματος, γέμισμα του φύλλου εργασίας του, ανάθεση τύπων σε μορφή A1 ή R1C1, επαναυπολογισμό τους, ανάγνωση των υπολογιζόμενων τιμών, σύνδεση αυτών των κελιών με μια σειρά διαγράμματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη των υποστηριζόμενων τύπων, το ενσωματωμένο υποσύνολο λειτουργιών, τις αποθηκευμένες τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα ειδικά για λογιστικά φύλλα.

## **Φύλλα Εργασίας Διαγράμματος και Τύποι**

Ένα φύλλο εργασίας διαγράμματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί ένα διάγραμμα. Στο PowerPoint, μπορείτε να επιθεωρήσετε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![Διάγραμμα PowerPoint με ανοικτό το ενσωματωμένο φύλλο εργασίας του, που εμφανίζει τα δεδομένα κατηγοριών και σειρών](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω της κλάσης [ChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/) . Χρησιμοποιήστε [ChartDataCell.setFormula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) για τύπους μορφής A1 και [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) για τύπους μορφής R1C1. Αφού αλλάξετε τα κελιά εισόδου ή τους τύπους, καλέστε [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) για να επαναϋπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκτίδει το αποτέλεσμα του μέσω του [ChartDataCell.getValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#getValue--). Αυτό είναι σημαντικό όταν χρειάζεται να εξετάσετε το αποτέλεσμα ενός τύπου στον κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων διαγράμματος.

## **Δημιουργία Διαγράμματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα επιδεικνύει μια πλήρη ροή εργασίας. Δημιουργεί ένα γραμμικό στήλης σύγχρονο διάγραμμα, διαγράφει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

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

Τα σημεία δεδομένων του διαγράμματος αναφέρονται στο `D2:D4`, οπότε το διάγραμμα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης διαγράμματος σε αυτή τη ροή εργασίας: επαναϋπολογίστε πρώτα το βιβλίο εργασίας, μετά χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων σε Μορφή A1**

Η σημειολογία A1 αναγνωρίζει τις στήλες με γράμματα και τις γραμμές με αριθμούς. Αναθέστε εκφράσεις μορφής A1 μέσω του [ChartDataCell.setFormula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

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

Οι συνηθισμένες μορφές αναφοράς A1 είναι:

| Αναφορά | Σχετικό | Απόλυτο | Μικτό |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινείται ή αντιγράφεται από μια εφαρμογή λογιστικού φύλλου. Οι απόλυτες αναφορές διατηρούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές αναφορές σταθεροποιούν μόνο μια γραμμή ή μια στήλη.

## **Χρήση Τύπων σε Μορφή R1C1**

Η σημειολογία R1C1 αναγνωρίζει τόσο τις γραμμές όσο και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν αντιστάσεις σε αγκύλες. Αντιθέστε αυτή τη σύνταξη μέσω του [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

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

Οι συνηθισμένες μορφές αναφοράς R1C1 είναι:

| Αναφορά | Σχετικό | Απόλυτο | Μικτό |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες αριστερά (`B2`).

## **Σταθερές και Τέλεσοι Τύπων**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικούς κυριολεκτικούς, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Κυριολεκτικά**

| Τύπος | Παραδείγματα | Σχόλια |
|---|---|---|
| Λογικό | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί απευθείας σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητικό | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται η κοινή και η επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Τα κυριολεκτικά κείμενα περιβάλλονται με διπλά εισαγωγικά μέσα στον τύπο. |
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

    const logicalValue = workbook.getCell(0, "B2").getValue(); // ψευδές
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Αριθμητικοί Τέλεσοι**

| Τέλεσας | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μοναδικό συν | `2+3` |
| `-` | Αφαίρεση ή άρνηση | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Αναβάθμιση σε δύναμη | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε ρητό τον порядок εκτίμησης, π.χ. `(A2+B2)*C2`.

### **Τέλεσοι Σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέφουν λογικές τιμές.

| Τέλεσας | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ίσο με | `A2=3` |
| `<>` | Διαφορετικό από | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο με | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο με | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας διαγράμματος, αλλά δεν είναι πλήρης μηχανή υπολογισμού Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω συναρτήσεις. Μην υποθέτετε ότι μια αυθαίρετη συνάρτηση Excel μπορεί να επαναϋπολογιστεί από το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση αριθμού προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με βάση δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Σύνδεση τιμών κειμένου | `CONCAT(A2,B2)` |
| `CONCATENATE` | Σύνδεση τιμών κειμένου | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας χρησιμοποιώντας το σύστημα ημερομηνίας 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εντοπίζει μία τιμή κειμένου μέσα σε άλλη | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου με προσανατολισμό σε byte | `FINDB("a",A2)` |
| `IF` | Αποτέλεσμα υπό συνθήκη | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροιση τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί που φαίνονται στον πίνακα είναι σημαντικοί: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ τα `LOOKUP` και `MATCH` τεκμηριώνονται σε μορφές διανύσματος. Το `DATE` χρησιμοποιεί το σύστημα ημερομηνίας 1900. Οι δυνατότητες και οι συναρτήσεις που δεν αναφέρονται εδώ πρέπει να θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Υπολογισμός Τύπων με Προτιμώμενο Πολιτισμό**

Κάποιες λειτουργίες του βιβλίου εργασίας διαγράμματος ερμηνεύουν κείμενο σύμφωνα με κανόνες ειδικούς για τον πολιτισμό. Αυτό είναι ιδιαίτερα σημαντικό για λειτουργίες που προορίζονται για γλώσσες που χρησιμοποιούν σύνολα χαρακτήρων διπλού byte (DBCS). Για να υπολογίσετε σωστά τέτοιους τύπους, δημιουργήστε [LoadOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/), ορίστε τον προτιμώμενο πολιτισμό με [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), αντιστοιχίστε τις επιλογές λογιστικού φύλλου μέσω του [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions), και κατόπιν φορτώστε την παρουσίαση.

Το παρακάτω παράδειγμα επιλέγει τον Ιαπωνικό πολιτισμό, ανοίγει μια παρουσίαση με τις ρυθμισμένες επιλογές φόρτωσης και καλεί το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) για κάθε βιβλίο εργασίας διαγράμματος:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ο προτιμώμενος πολιτισμός αποτελεί μέρος της διαμόρφωσης φόρτωσης παρουσίασης, επομένως ορίστε τον πριν δημιουργήσετε το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Χρησιμοποιήστε τον πολιτισμό που απαιτούν οι τύποι του βιβλίου εργασίας· για παράδειγμα, χρησιμοποιήστε `ja-JP` για τύπους που πρέπει να ακολουθούν τους Ιαπωνικούς κανόνες υπολογισμού DBCS.

## **Επαναϋπολογισμός και Αποθηκευμένες Τιμές**

Τα αρχεία λογιστικού φύλλου συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί έτσι να διαβάσει μια αποθηκευμένη τιμή από το [ChartDataCell.getValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#getValue--) όταν μια παρουσίαση φορτώνεται και τα αντίστοιχα δεδομένα διαγράμματος δεν έχουν αλλάξει.

Μετά την αλλαγή κελιών εισόδου ή τύπων, μην βασίζεστε σε παλιά αποθηκευμένα αποτελέσματα. Καλέστε το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides μπορεί να μην είναι σε θέση να αναλύσει τον τύπο ή να καθορίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη αποθηκευμένη τιμή δεν μπορεί πλέον να θεωρηθεί αξιόπιστη. Σε αυτήν την κατάσταση, η ανάγνωση της τιμής ενός κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Εάν το διάγραμμά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή λογιστικού φύλλου που τις υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας διαγράμματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με τιμές που εικάζετε.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να ξεχωριστούν.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος λογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτήν την περίπτωση, το σφάλμα είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [ChartDataCell.getValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Ένας τύπος μπορεί επίσης να αποτύχει στο στάδιο της ανάλυσης, της αναφοράς, της εξάρτησης ή του επιτρεπόμενου δεδομένου. Το Aspose.Slides παρέχει εξαιρέσεις ειδικές για λογιστικά φύλλα για αυτές τις περιπτώσεις: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή εισροές χρηστών, πιάστε τα σφάλματα γύρω από τον επαναϋπολογισμό και την πρόσβαση στην τιμή. Τα στοιχεία σφάλματος ταυτοποιούν το υποκείμενο πρόβλημα του λογιστικού φύλλου:

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

Η υποστήριξη τύπων σε φύλλα εργασίας διαγράμματος προορίζεται για ένα καθορισμένο υποσύνολο υπολογισμών λογιστικού φύλλου, όχι για πλήρη συμβατότητα με το Excel. Κρατήστε αυτούς τους περιορισμούς στο νου όταν σχεδιάζετε μια ροή εργασίας αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεστε το Aspose.Slides να επαναϋπολογίσει τύπους.
- Επαναϋπολογίστε μετά την αλλαγή κελιών από τα οποία εξαρτώνται τα αποτελέσματα των τύπων.
- Αντιμετωπίζετε τις αποθηκευμένες τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επαναϋπολογισμού μετά από επεξεργασίες.
- Δοκιμάστε τους τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τιμές τους, ειδικά όταν χρησιμοποιούν συναρτήσεις εκτός του τεκμηριωμένου καταλόγου.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και στη συνέχεια ενημερώστε το βιβλίο εργασίας διαγράμματος με τις προκύπτουσες τιμές.

## **FAQ**

**Ποια είναι η διαφορά μεταξύ [ChartDataCell.setFormula] και [ChartDataCell.setR1C1Formula];**

[ChartDataCell.setFormula] αποθηκεύει μια έκφραση σε μορφή A1 όπως `B2-C2`. [ChartDataCell.setR1C1Formula] αποθηκεύει μια έκφραση σε μορφή R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειολογία που ταιριάζει καλύτερα στον τρόπο που δημιουργείτε ή αντιγράφετε τύπους.

**Πρέπει να διαβάσω το ίδιο το κελί ή την τιμή του μετά τον υπολογισμό;**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) επιστρέφει ένα [ChartDataCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/). Για να αποκτήσετε το υπολογισμένο αποτέλεσμα, καλέστε τη μέθοδο [ChartDataCell.getValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatacell/#getValue--) του κελιού μετά τον επαναϋπολογισμό.

**Πότε πρέπει να καλέσω το [ChartDataWorkbook.calculateFormulas];**

Καλέστε το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν βασιστείτε στα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζονται από τον ενσωματωμένο αξιολογητή.

**Υποστηρίζει το Aspose.Slides κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Οι συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι επαναϋπολογίζονται σωστά. Εάν απαιτείται πλήρη συμβατότητα τύπων Excel, εκτελέστε τον υπολογισμό με μια κατάλληλη μηχανή λογιστικού φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας διαγράμματος.

**Τι συμβαίνει αν μια φορτωμένη παρουσίαση περιέχει μη υποστηριζόμενο τύπο;**

Εάν τα δεδομένα διαγράμματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμα να περιέχει μια προηγούμενη υπολογισμένη αποθηκευμένη τιμή. Μετά την τροποποίηση των σχετικών δεδομένων, αυτή η αποθηκευμένη τιμή μπορεί να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να αντιμετωπιστεί μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**Είναι οι τιμές σφάλματος τύπων οι ίδιες με τις εξαιρέσεις;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι τιμή λογιστικού φύλλου που παράγεται από έγκυρο υπολογισμό. Εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellcircularreferenceexception/) υποδεικνύουν ότι ο τύπος δεν μπορεί να επεξεργαστεί κανονικά.

**Ενημερώνεται αυτόματα ένα διάγραμμα όταν αλλάζει ένα κελί τύπου;**

Μια σειρά διαγράμματος μπορεί να αναφέρεται σε κελιά του βιβλίου εργασίας. Επαναϋπολογίστε πρώτα το βιβλίο εργασίας, μετά αποθηκεύστε ή αποδώστε την παρουσίαση. Εάν τα σημεία δεδομένων του διαγράμματος αναφέρονται στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί αυτές τις ενημερωμένες τιμές κελιών· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης διαγράμματος για αυτήν τη ροή εργασίας.

**Μπορούν τα διαγράμματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα διαγράμματος μπορούν να ρυθμιστούν να χρησιμοποιούν εξωτερικό βιβλίο εργασίας μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή εργασίας υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο εργασίας δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογεί το Aspose.Slides. Μην υποθέετε ότι το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) παρέχει πλήρη επαναϋπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο εργασίας ή βιβλίο εργασίας;**

Οι αναφορές τύπου Excel μπορεί να υπάρχουν σε βιβλία εργασίας διαγράμματος, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο συναρτήσεων. Εάν μια αναφορά μεταξύ φύλλων ή εξωτερική αναφορά είναι απαραίτητη, επικυρώστε αυτόν τον ακριβή τύπο με την έκδοση Aspose.Slides που στοχεύετε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εργασίας εξωτερικά και γράψτε τις επιλυμένες τιμές πίσω στα δεδομένα διαγράμματος.

**Πρέπει οι σπυράκτες τύπων να ξεκινούν με `=`;**

Τα παραδείγματα API του Aspose.Slides αντιστοιχούν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς το προαπενόσημα `=`. Η χρήση αυτής της μορφής διατηρεί τους παραγόμενους τύπους σύμφωνους με τα τεκμηριωμένα παραδείγματα API.