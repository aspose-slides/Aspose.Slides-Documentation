---
title: Δημιουργία Διαγραμμάτων Excel και Ενσωμάτωση τους σε Παρουσιάσεις ως Αντικείμενα OLE
type: docs
weight: 30
url: /el/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Διάγραμμα Excel
- ενσωμάτωση διαγράμματος
- αντικείμενο OLE
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε ένα διάγραμμα Excel με Aspose.Cells για Node.js μέσω Java και ενσωματώστε το βιβλίο εργασίας σε μια παρουσίαση PowerPoint με Aspose.Slides, συμπεριλαμβανομένης μιας προεπισκόπησης διαγράμματος."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε ένα διάγραμμα στήλης Excel με Aspose.Cells για Node.js μέσω Java και να ενσωματώσετε το βιβλίο εργασίας του σε παρουσίαση PowerPoint με Aspose.Slides για Node.js μέσω Java. Το ενσωματωμένο βιβλίο εργασίας περιέχει τόσο τα δεδομένα προέλευσης όσο και το διάγραμμα. Μια ξεχωριστή προεπισκόπηση PNG εμφανίζει το διάγραμμα στη διαφάνεια πριν ενεργοποιηθεί το αντικείμενο OLE.

Το αποτέλεσμα είναι ένα ενσωματωμένο αντικείμενο Excel, όχι ενσωματωμένο διάγραμμα PowerPoint. Η επεξεργασία του βιβλίου εργασίας μέσω OLE απαιτεί μια εφαρμογή επιφάνειας εργασίας που υποστηρίζει ενεργοποίηση OLE και μια συμβατή εγκατάσταση Excel.

## **Προαπαιτούμενα**

Εγκαταστήστε τα πακέτα Node.js `aspose.cells`, `aspose.slides.via.java` και `java`. Εκτελέστε τα παραδείγματα ως δύο σενάρια CommonJS σε ξεχωριστές διαδικασίες Node.js: πρώτα `create-chart.js`, έπειτα `embed-chart.js`, χρησιμοποιώντας τον ίδιο φάκελο εργασίας. Και τα δύο πακέτα Aspose αρχικοποιούν τη γέφυρα Java κατά τη φόρτωση, επομένως αυτά τα παραδείγματα τα διατηρούν σε ξεχωριστές διαδικασίες. Δεν απαιτείται το Microsoft Office για τη δημιουργία της παρουσίασης με αυτές τις βιβλιοθήκες.

Δεν απαιτείται υπάρχον βιβλίο εργασίας ή εικόνα. Το πρώτο σενάριο δημιουργεί τα αρχεία `ChartWorkbook.xlsx` και `ChartPreview.png`; το δεύτερο διαβάζει αυτά τα αρχεία και γράφει το `OutputChart.pptx` στον τρέχοντα φάκελο εργασίας. Εφαρμόστε άδειες και για τα δύο προϊόντα όταν τρέχετε εκτός λειτουργίας αξιολόγησης.

## **Πώς Λειτουργεί η Ενσωμάτωση**

1. Δημιουργήστε ένα βιβλίο εργασίας με φύλλο δεδομένων και φύλλο διαγράμματος.  
2. Κάντε το φύλλο διαγράμματος ενεργό ώστε το βιβλίο εργασίας να ανοίγει στο διάγραμμα.  
3. Ορίστε το εύρος εμφάνισης OLE του βιβλίου εργασίας και αποδώστε το διάγραμμα σε PNG.  
4. Αποθηκεύστε το βιβλίο εργασίας ως XLSX και ενσωματώστε τα bytes του σε μια διαφάνεια σε ξεχωριστή διαδικασία Node.js.  
5. Ορίστε το PNG ως προεπισκόπηση του αντικειμένου OLE και αποθηκεύστε την παρουσίαση ως PPTX.

Το εύρος εμφάνισης του βιβλίου εργασίας και το πλαίσιο στη διαφάνεια έχουν διαφορετικούς ρόλους. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) δέχεται μηδενικής βάσης δείκτες αρχής/τέλους γραμμής και στήλης. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) αντίθετα δέχεται την άνω γραμμή, την αριστερή στήλη, την κάτω γραμμή και τη δεξιά στήλη. Το παράδειγμα χρησιμοποιεί δείκτη γραμμής 55 και δείκτη στήλης 25 ως τα κάτω‑δεξιά όρια· αυτές οι τιμές είναι επιλογές διάταξης, όχι ο αριθμός των γραμμών ή στηλών δεδομένων.

Το πλαίσιο της διαφάνειας χρησιμοποιεί μονάδες σημείων. Το παράδειγμα το τοποθετεί εντός της διαφάνειας και το κεντράρει διατηρώντας την αναλογία διαστάσεων του PNG, αντί να τεντώνει την προεπισκόπηση ώστε να γεμίσει τη διαφάνεια.

## **Δημιουργία και Ενσωμάτωση του Διαγράμματος**

Αποθηκεύστε το πρώτο παράδειγμα ως `create-chart.js`. Γεμίζει το `DataSheet` με τέσσερις γραμμές και πέντε στήλες τιμών. Κάθε γραμμή γίνεται σειρά διαγράμματος. Το `ChartSheet` επιλέγεται ως ενεργό φύλλο πριν αποθηκευτεί το βιβλίο εργασίας.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Αποδώστε την προεπισκόπηση του διαγράμματος και σειριοποιήστε το επεξεργάσιμο βιβλίο εργασίας ξεχωριστά.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Όλη η συγχρονισμένη εργασία ολοκληρώθηκε· σταματήστε τη διεργασία γέφυρας Java.
process.exit(0);
```

Αποθηκεύστε το παρακάτω παράδειγμα ως `embed-chart.js`. Εκτελέστε το αφού το `create-chart.js` έχει δημιουργήσει και τα δύο αρχεία εισόδου. Κεντράρει το πλαίσιο OLE και διατηρεί την αναλογία διαστάσεων της εικόνας προεπισκόπησης.

Το δεύτερο σενάριο ενσωματώνει το αποθηκευμένο βιβλίο εργασίας και χρησιμοποιεί το PNG ως προεπισκόπηση. Το βιβλίο εργασίας αποθηκεύεται ρητά ως XLSX, ταιριάζοντας με την επέκταση `xlsx` που περνά στο [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). Το PNG φορτώνεται απευθείας από τα byte του χωρίς ενδιάμεση μετατροπή bitmap. Η γέφυρα Java απαιτεί ρητά Java byte arrays για την εικόνα και τα δεδομένα του βιβλίου εργασίας, και τιμές float Java για τις συντεταγμένες του πλαισίου διαφάνειας. Το ανάθεση μέσω του [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) αντικαθιστά την προεπιλεγμένη θέση κράτησης OLE.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Προσαρμόστε την προεπισκόπηση μέσα στη διαφάνεια χωρίς να αλλάξετε την αναλογία της.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Όλη η συγχρονισμένη εργασία ολοκληρώθηκε· σταματήστε τη διεργασία γέφυρας Java.
process.exit(0);
```

## **Αναμενόμενο Αποτέλεσμα**

`OutputChart.pptx` περιέχει μία διαφάνεια με ενσωματωμένο βιβλίο εργασίας Excel και προεπισκόπηση διαγράμματος. Το βιβλίο εργασίας περιέχει τα αρχικά δεδομένα και ένα διάγραμμα στήλης με τέσσερις σειρές. Η προεπισκόπηση είναι κεντραρισμένη στη διαφάνεια και διατηρεί τις αναλογίες της.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

Σε περιβάλλον PowerPoint επιφάνειας εργασίας με διαθέσιμο Excel, κάντε διπλό κλικ στο αντικείμενο για να ενεργοποιήσετε και να επεξεργαστείτε το ενσωματωμένο βιβλίο εργασίας. Η ενεργοποίηση και η επεξεργασία εξαρτώνται από την υποστήριξη OLE της εφαρμογής-φορέα και τις ρυθμίσεις ασφαλείας.

## **Συχνές Ερωτήσεις**

**Γιατί χρειάζεται εικόνα προεπισκόπησης;**

Το ενσωματωμένο βιβλίο εργασίας και η προεπισκόπηση στη διαφάνεια είναι ξεχωριστό περιεχόμενο. Παρέχετε μια εικόνα διαγράμματος ώστε η διαφάνεια να εμφανίζει το διάγραμμα αντί του προεπιλεγμένου υποκαταστήματος «EMBEDDED OLE OBJECT». Δείτε το [Πρόβλημα Προεπισκόπησης Αντικειμένου κατά την Προσθήκη OleObjectFrame](/slides/el/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Ενημερώνεται αυτόματα η προεπισκόπηση όταν αλλάζω το βιβλίο εργασίας με κώδικα;**

Η προεπισκόπηση θεωρείται στιγμιότυπο. Κατά την ενημέρωση των δεδομένων του βιβλίου εργασίας προγραμματικά, πρέπει να δημιουργήσετε ξανά την εικόνα διαγράμματος και να αντικαταστήσετε τόσο την προεπισκόπηση όσο και τα ενσωματωμένα δεδομένα του βιβλίου εργασίας.

**Μπορώ να χρησιμοποιήσω XLS αντί για XLSX;**

Ναι. Αποθηκεύστε το βιβλίο εργασίας σε μορφή XLS και χρησιμοποιήστε `xls` ως την επέκταση των ενσωματωμένων δεδομένων. Η επέκταση πρέπει να ταιριάζει με την πραγματική μορφή του βιβλίου εργασίας· η αλλαγή μόνο της επέκτασης δεν μετατρέπει τα δεδομένα.

**Γιατί μπορεί το αντικείμενο να αλλάξει μέγεθος μετά την ενεργοποίηση;**

Η εφαρμογή-φορέας μπορεί να ενημερώσει την παρουσίαση του αντικειμένου OLE όταν ενεργοποιεί το βιβλίο εργασίας. Το εύρος εμφάνισης OLE του βιβλίου εργασίας και οι διαστάσεις του πλαισίου διαφάνειας παίζουν και τα δύο ρόλο. Δείτε τη [Λύση Εργασίας για την Αλλαγή Μεγέθους Διαγράμματος σε PPTX](/slides/el/java/working-solution-for-chart-resizing-in-pptx/).

## **Σχετικές Ενότητες**

- [Λύση Εργασίας για την Αλλαγή Μεγέθους Διαγράμματος σε PPTX](/slides/el/java/working-solution-for-chart-resizing-in-pptx/)
- [Πρόβλημα Προεπισκόπησης Αντικειμένου κατά την Προσθήκη OleObjectFrame](/slides/el/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)