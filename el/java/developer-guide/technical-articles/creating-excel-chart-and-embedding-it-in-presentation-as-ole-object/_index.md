---
title: Δημιουργία Γραφημάτων Excel και Ενσωμάτωση τους σε Παρουσιάσεις ως Αντικείμενα OLE
type: docs
weight: 30
url: /el/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Γράφημα Excel
- ενσωμάτωση γραφήματος
- αντικείμενο OLE
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε ένα γράφημα Excel με το Aspose.Cells for Java και ενσωματώστε το βιβλίο εργασίας σε μια παρουσίαση PowerPoint με το Aspose.Slides, περιλαμβάνοντας προεπισκόπηση γραφήματος."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε ένα γράφημα στήλης Excel με το Aspose.Cells for Java και να ενσωματώσετε το βιβλίο εργασίας του σε μια παρουσίαση PowerPoint με το Aspose.Slides for Java. Το ενσωματωμένο βιβλίο εργασίας περιέχει τόσο τα δεδομένα προέλευσης όσο και το γράφημα. Μια ξεχωριστή προεπισκόπηση PNG εμφανίζει το γράφημα στη διαφάνεια πριν ενεργοποιηθεί το αντικείμενο OLE.

Το αποτέλεσμα είναι ένα ενσωματωμένο αντικείμενο Excel, όχι ένα ενσωματωμένο γράφημα PowerPoint. Η επεξεργασία του βιβλίου εργασίας μέσω OLE απαιτεί μια εφαρμογή επιφάνειας εργασίας που υποστηρίζει ενεργοποίηση OLE και μια συμβατή εγκατάσταση του Excel.

## **Προαπαιτούμενα**

Προσθέστε τα Aspose.Cells for Java και Aspose.Slides for Java στις εξαρτήσεις του έργου σας. Εκτελέστε το παράδειγμα μέσα σε μια μέθοδο Java. Το Microsoft Office δεν απαιτείται για τη δημιουργία της παρουσίασης με αυτές τις βιβλιοθήκες.

Δεν απαιτούνται αρχεία εισόδου: το παράδειγμα δημιουργεί τα δεδομένα και το γράφημα στη μνήμη, στη συνέχεια γράφει `OutputChart.pptx` στον τρέχοντα φάκελο εργασίας. Εφαρμόστε τις άδειες και για τα δύο προϊόντα όταν τρέχετε εκτός λειτουργίας αξιολόγησης.

## **Πώς Λειτουργεί η Ενσωμάτωση**

1. Δημιουργήστε ένα βιβλίο εργασίας με ένα φύλλο δεδομένων και ένα φύλλο γραφήματος.  
1. Κάντε το φύλλο γραφήματος ενεργό ώστε το βιβλίο εργασίας να ανοίγει στο γράφημα.  
1. Ορίστε το εύρος εμφάνισης OLE του βιβλίου εργασίας και αποδώστε το γράφημα σε PNG.  
1. Αποθηκεύστε το βιβλίο εργασίας ως XLSX στη μνήμη και ενσωματώστε αυτά τα byte σε μια διαφάνεια.  
1. Ορίστε το PNG ως προεπισκόπηση του αντικειμένου OLE και αποθηκεύστε την παρουσίαση ως PPTX.

Το εύρος εμφάνισης του βιβλίου εργασίας και το πλαίσιο στη διαφάνεια έχουν διαφορετικούς ρόλους. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) δέχεται δείκτες γραμμής/στήλης με βάση το μηδέν για αρχή/τέλος. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) αντίθετα δέχεται την επάνω γραμμή, αριστερή στήλη, κάτω γραμμή και δεξιά στήλη. Το παράδειγμα χρησιμοποιεί δείκτη γραμμής 55 και δείκτη στήλης 25 ως τα κάτω‑δεξιά όρια· αυτές οι τιμές είναι επιλογές διάταξης, όχι ο αριθμός των γραμμών ή στηλών δεδομένων.

Το πλαίσιο της διαφάνειας χρησιμοποιεί μονάδες σημείου. Το παράδειγμα το προσαρμόζει μέσα στη διαφάνεια και το κεντράρει διατηρώντας την αναλογία διαστάσεων του PNG, αντί να τεντώσει την προεπισκόπηση ώστε να καλύψει ολόκληρη τη διαφάνεια.

## **Δημιουργία και Ενσωμάτωση του Γραφήματος**

Το παρακάτω πλήρες παράδειγμα γεμίζει το `DataSheet` με τέσσερις γραμμές και πέντε στήλες τιμών. Κάθε γραμμή γίνεται σειρά γραφήματος. Το `ChartSheet` επιλέγεται ως το ενεργό φύλλο πριν αποθηκευτεί το βιβλίο εργασίας.

Το βιβλίο εργασίας αποθηκεύεται ρητά ως XLSX, ταιριάζοντας με την επέκταση `xlsx` που περνάει στο [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). Το PNG φορτώνεται απευθείας από τα byte του χωρίς ενδιάμεσου μετασχηματισμού bitmap. Η ανάθεσή του μέσω του [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) αντικαθιστά το προεπιλεγμένο σύμβολο κράτησης θέσης OLE.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // Δημιουργία προεπισκόπησης γραφήματος και σειριοποίηση του επεξεργάσιμου βιβλίου εργασίας ξεχωριστά.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // Προσαρμογή της προεπισκόπησης εντός της διαφάνειας χωρίς αλλαγή της αναλογίας διαστάσεων.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **Αναμενόμενο Αποτέλεσμα**

Το `OutputChart.pptx` περιέχει μία διαφάνεια με ενσωματωμένο βιβλίο εργασίας Excel και προεπισκόπηση γραφήματος. Το βιβλίο εργασίας περιέχει τα αρχικά δεδομένα και ένα γράφημα στήλης με τέσσερις σειρές. Η προεπισκόπηση είναι κεντραρισμένη στη διαφάνεια και διατηρεί τις αναλογίες της.

![Γράφημα στήλης Excel εμφανιζόμενο ως προεπισκόπηση ενσωματωμένου βιβλίου εργασίας](excel-chart-ole-preview.png)

Σε ένα συμβατό περιβάλλον PowerPoint στην επιφάνεια εργασίας με διαθέσιμο Excel, κάντε διπλό κλικ στο αντικείμενο για να ενεργοποιήσετε και να επεξεργαστείτε το ενσωματωμένο βιβλίο εργασίας. Η ενεργοποίηση και η επεξεργασία εξαρτώνται από την υποστήριξη OLE της εφαρμογής-ξενιστή και τις ρυθμίσεις ασφαλείας.

## **Συχνές Ερωτήσεις**

**Γιατί χρειάζεται μια εικόνα προεπισκόπησης;**

Το ενσωματωμένο βιβλίο εργασίας και η προεπισκόπηση στη διαφάνεια είναι ξεχωριστό περιεχόμενο. Παρέχετε μια εικόνα γραφήματος ώστε η διαφάνεια να δείχνει το γράφημα αντί του προεπιλεγμένου συμβόλου “EMBEDDED OLE OBJECT”. Δείτε το [Object Preview Issue when Adding OleObjectFrame](/slides/el/java/object-preview-issue-when-adding-oleobjectframe/).

**Η προεπισκόπηση ενημερώνεται αυτόματα όταν αλλάζω το βιβλίο εργασίας με κώδικα;**

 Θεωρήστε την προεπισκόπηση ως στιγμιότυπο. Όταν ενημερώνετε τα δεδομένα του βιβλίου εργασίας προγραμματιστικά, πρέπει να δημιουργήσετε ξανά την εικόνα του γραφήματος και να αντικαταστήσετε την προεπισκόπηση, καθώς και τα ενσωματωμένα δεδομένα του βιβλίου εργασίας.

**Μπορώ να χρησιμοποιήσω XLS αντί για XLSX;**

Ναι. Αποθηκεύστε το βιβλίο εργασίας σε μορφή XLS και χρησιμοποιήστε `xls` ως την επέκταση των ενσωματωμένων δεδομένων. Η επέκταση πρέπει να ταιριάζει με την πραγματική μορφή του βιβλίου εργασίας· η αλλαγή μόνο της επέκτασης δεν μετατρέπει τα δεδομένα.

**Γιατί το αντικείμενο μπορεί να αλλάξει μέγεθος μετά την ενεργοποίηση;**

Η εφαρμογή-ξενιστής μπορεί να ενημερώσει την παρουσίαση του αντικειμένου OLE όταν ενεργοποιήσει το βιβλίο εργασίας. Το εύρος εμφάνισης OLE του βιβλίου εργασίας και οι διαστάσεις του πλαισίου της διαφάνειας επηρεάζουν και τα δύο. Δείτε το [Working Solution for Chart Resizing in PPTX](/slides/el/java/working-solution-for-chart-resizing-in-pptx/).

## **Σχετικές Ενότητες**

- [Working Solution for Chart Resizing in PPTX](/slides/el/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/el/java/object-preview-issue-when-adding-oleobjectframe/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/el/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)