---
title: Λύση Εργασίας για Την Αλλαγή Μεγέθους Διαγράμματος σε PPTX
type: docs
weight: 40
url: /el/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- αλλαγή μεγέθους διαγράμματος
- διάγραμμα Excel
- αντικείμενο OLE
- ενσωμάτωση διαγράμματος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διορθώστε την απροσδόκητη αλλαγή μεγέθους διαγράμματος σε PPTX όταν χρησιμοποιούνται ενσωματωμένα αντικείμενα Excel OLE με Aspose.Slides for Android via Java. Ορίστε σταθερές διαστάσεις διαγράμματος ώστε τα μεγέθη του διαγράμματος και του πλαισίου OLE να παραμένουν συνεπή."
---
## **Επισκόπηση**

Διαγράμματα Excel ενσωματωμένα ως αντικείμενα OLE σε παρουσιάσεις PowerPoint με χρήση των συστατικών Aspose μπορούν να αλλάξουν μέγεθος μετά την πρώτη ενεργοποίησή τους. Αυτό μπορεί να προκαλέσει αισθητή διαφορά στην εμφάνιση του διαγράμματος πριν και μετά την ενεργοποίηση. Αυτό το άρθρο εξηγεί γιατί συμβαίνει η αλλαγή μεγέθους και δείχνει πώς να το αποτρέψετε ταιριάζοντας τις σταθερές διαστάσεις του διαγράμματος με το πλαίσιο OLE.

Στο [Δημιουργία Διαγραμμάτων Excel και Ενσωμάτωση τους ως Αντικείμενα OLE σε Παρουσιάσεις](/slides/el/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), εξηγήσαμε πώς να δημιουργήσετε ένα διάγραμμα Excel με Aspose.Cells for Android μέσω Java και να το ενσωματώσετε σε παρουσίαση PowerPoint χρησιμοποιώντας Aspose.Slides for Android μέσω Java. Για να αντιμετωπίσουμε το [πρόβλημα προεπισκόπησης αντικειμένου](/slides/el/androidjava/object-preview-issue-when-adding-oleobjectframe/), ορίσαμε την εικόνα του διαγράμματος στο πλαίσιο αντικειμένου OLE του διαγράμματος. Στην παρουσίαση εξόδου, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του διαγράμματος, το διάγραμμα Excel ενεργοποιείται. Οι χρήστες μπορούν να επεξεργαστούν το ενσωματωμένο βιβλίο εργασίας Excel και στη συνέχεια να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας. Το μέγεθος του πλαισίου αντικειμένου OLE αλλάζει όταν ο χρήστης επιστρέφει στη διαφάνεια, και ο παράγοντας επανακλιμάκωσης διαφέρει ανάλογα με τα αρχικά μεγέθη τόσο του πλαισίου OLE όσο και του ενσωματωμένου βιβλίου εργασίας Excel.

## **Αιτία της Αλλαγής Μεγέθους**

Το ενσωματωμένο βιβλίο εργασίας Excel έχει τις δικές του διαστάσεις παραθύρου, τις οποίες το Excel προσπαθεί να διατηρήσει όταν το αντικείμενο ενεργοποιείται για πρώτη φορά. Το πλαίσιο OLE στη διαφάνεια έχει ανεξάρτητα ορισμένες διαστάσεις. Όταν το βιβλίο εργασίας Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος του αντικειμένου για να διατηρήσουν τις αναλογίες του ως μέρος της διαδικασίας ενσωμάτωσης. Οι διαφορές μεταξύ του παραθύρου του βιβλίου εργασίας και του πλαισίου OLE μπορούν επομένως να προκαλέσουν αλλαγή μεγέθους του αντικειμένου.

## **Λειτουργική Λύση**

Ταιριάξτε το μέγεθος του διαγράμματος με το πλαίσιο OLE στη διαφάνεια και διατηρήστε τις διαστάσεις του διαγράμματος ανεξάρτητες από το παράθυρο του βιβλίου εργασίας. Η λύση αυτή λειτουργεί με μια νέα παρουσίαση ή με υπάρχον πρότυπο.

Το παράδειγμα απαιτεί Aspose.Cells for Android μέσω Java και Aspose.Slides for Android μέσω Java. Δημιουργεί ένα απλό στήλης διάγραμμα σε ενεργό φύλλο διαγράμματος και ενσωματώνει το βιβλίο εργασίας σε μορφή XLS. Καλέστε `FixedChartSize.createPresentation(getFilesDir())` από μια δραστηριότητα Android για να αποθηκεύσετε το αποτέλεσμα στον εσωτερικό φάκελο αρχείων της εφαρμογής. Η ενεργοποίηση OLE απαιτεί την έκδοση PowerPoint για επιτραπέζιους υπολογιστές και μια συμβατή εγκατάσταση Excel. Δεν ορίζεται εικόνα προεπισκόπησης του διαγράμματος· το διάγραμμα γίνεται ορατό όταν το αντικείμενο OLE ενεργοποιείται στο PowerPoint.

Το παράδειγμα δημιουργεί μια νέα παρουσίαση με πλαίσιο OLE 9,5 × 4 ίντσες, τοποθετημένο 0,5 ίντσες από την αριστερή άκρη και 1 ίντσα από την κορυφή. Οι συντεταγμένες και οι διαστάσεις της διαφάνειας δίνονται σε μονάδες σημείου (72 σημείο ανά ίντσα). Για υπάρχουσα παρουσίαση, δείτε [Χρήση Προτύπου](#use-a-template).

## **Ορισμός Σταθερού Μεγέθους Διαγράμματος**

Ορίστε το [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) σε false ώστε οι διαστάσεις του διαγράμματος να είναι ανεξάρτητες από το παράθυρο του βιβλίου εργασίας. Ρυθμίστε τις διαστάσεις του [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) μέσω των [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) και [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), μετατρέποντας τα σημεία σε pixel με 96 pixel ανά ίντσα: ένα πλαίσιο 684 × 288 σημεία αντιστοιχεί σε διάγραμμα 912 × 384 pixel. Ορίστε το [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) στην τιμή CUSTOM του [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Το παράδειγμα ενσωματώνει το βιβλίο εργασίας με [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) και αποθηκεύει μια παρουσίαση με πλαίσιο OLE 9,5 × 4 ίντσες.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("Data");
                dataSheet.getCells().get("A1").putValue(10);
                dataSheet.getCells().get("A2").putValue(20);

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                chart.getNSeries().add("Data!A1:A2", true);
                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

                Presentation presentation = new Presentation();
                try {
                    ISlide slide = presentation.getSlides().get_Item(0);

                    // Οι συντεταγμένες και οι διαστάσεις της διαφάνειας δίνονται σε μονάδες σημείου (72 σημείο ανά ίντσα).
                    float width = 684f; // 9,5 ίντσες.
                    float height = 288f; // 4 ίντσες.

                    chart.setSizeWithWindow(false);
                    // Μετατρέψτε τα σημεία σε pixel διαγράμματος χρησιμοποιώντας 96 pixel ανά ίντσα.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Χρήση Προτύπου**

Η λογική μεγέθους είναι η ίδια για υπάρχουσα παρουσίαση. Για να προσαρμόσετε το παράδειγμα:

1. Φορτώστε την παρουσίαση προτύπου αντί να δημιουργήσετε μια κενή παρουσίαση.
2. Ελέγξτε ότι η πρώτη διαφάνεια περιέχει τουλάχιστον τρία σχήματα, και στη συνέχεια χρησιμοποιήστε το σχήμα με δείκτη 2 ως σύμβολο κράτησης θέσης.
3. Πάρτε το πλάτος και το ύψος του πλαισίου από αυτό το σχήμα αντί να χρησιμοποιήσετε τις σταθερές τιμές 684 και 288. Διατηρήστε τους υπολογισμούς μεγέθους όπως είναι.
4. Προσθέστε το πλαίσιο OLE στη θέση του συμβόλου κράτησης θέσης αντί για τις σταθερές συντεταγμένες 36 και 72.
5. Αφαιρέστε το σύμβολο κράτησης θέσης πριν αποθηκεύσετε την παρουσίαση.

## **Συχνές Ερωτήσεις**

**Γιατί το ενσωματωμένο διάγραμμα Excel μου αλλάζει μέγεθος μετά την ενεργοποίηση του στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να επαναφέρει το αρχικό μέγεθος του παραθύρου κατά την πρώτη ενεργοποίηση, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει αλλαγή μεγέθους.

**Πώς μπορώ να διατηρήσω σταθερά τα μεγέθη του διαγράμματος και του πλαισίου OLE;**

Ορίστε σταθερές διαστάσεις διαγράμματος που ταιριάζουν με το πλαίσιο OLE και χρησιμοποιήστε προσαρμοσμένο μέγεθος εκτύπωσης διαγράμματος πριν ενσωματώσετε το βιβλίο εργασίας. Το παραπάνω παράδειγμα δείχνει τις απαιτούμενες ρυθμίσεις και τους μετασχηματισμούς μονάδων.

**Είναι η αντιστοίχηση του μεγέθους του παραθύρου του βιβλίου εργασίας επαρκής;**

Η μόνο αντιστοίχηση του μεγέθους του παραθύρου του βιβλίου εργασίας δεν αποτρέπει αξιόπιστα την αλλαγή μεγέθους του πλαισίου OLE μετά την ενεργοποίηση. Χρησιμοποιήστε σταθερές διαστάσεις διαγράμματος όπως φαίνεται στο παράδειγμα.

**Λειτουργεί αυτή η λύση τόσο με παρουσιάσεις βασισμένες σε πρότυπο όσο και με νέες παρουσιάσεις;**

Ναι. Για πρότυπο, χρησιμοποιήστε τις διαστάσεις και τη θέση του συμβόλου κράτησης θέσης. Για νέα παρουσίαση, ορίστε απευθείας τις διαστάσεις και τη θέση του πλαισίου.

**Μπορώ να χρησιμοποιήσω αυτό το παράδειγμα με διαγράμματα που δημιουργήθηκαν σε άλλα προγράμματα λογιστικών φύλλων;**

Το παράδειγμα χρησιμοποιεί ένα βιβλίο εργασίας Excel που δημιουργήθηκε με Aspose.Cells. Δεν παρουσιάζει τη συμπεριφορά ενεργοποίησης για άλλα προγράμματα λογιστικών φύλλων.

## **Σχετικές Ενότητες**

- [Δημιουργία Διαγραμμάτων Excel και Ενσωμάτωση τους ως Αντικείμενα OLE σε Παρουσιάσεις](/slides/el/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)