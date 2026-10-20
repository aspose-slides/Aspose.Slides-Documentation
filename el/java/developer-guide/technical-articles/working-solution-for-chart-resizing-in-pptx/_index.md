---
title: Λειτουργική Λύση για την Αλλαγή Μεγέθους Διαγράμματος σε PPTX
type: docs
weight: 40
url: /el/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- αλλαγή μεγέθους διαγράμματος
- διάγραμμα Excel
- αντικείμενο OLE
- ενσωμάτωση διαγράμματος
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Διορθώστε την απρόσμενη αλλαγή μεγέθους του διαγράμματος σε PPTX όταν χρησιμοποιούνται ενσωματωμένα αντικείμενα Excel OLE με το Aspose.Slides για Java. Ορίστε σταθερές διαστάσεις διαγράμματος ώστε να διατηρούνται σταθερές οι διαφορές μεταξύ του διαγράμματος και του πλαισίου OLE."
---
## **Ιστορικό**

Διαγράμματα Excel που έχουν ενσωματωθεί ως αντικείμενα OLE σε παρουσιάσεις PowerPoint χρησιμοποιώντας τα στοιχεία Aspose μπορούν να αλλάξουν μέγεθος μετά την πρώτη ενεργοποίησή τους. Αυτό μπορεί να προκαλέσει εμφανές διαφορικό στην εμφάνιση του διαγράμματος πριν και μετά την ενεργοποίηση. Το άρθρο αυτό εξηγεί γιατί συμβαίνει η αλλαγή μεγέθους και δείχνει πώς να την αποτρέψετε ταιριάζοντας τις σταθερές διαστάσεις του διαγράμματος με το πλαίσιο OLE.

Στο [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/el/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), εξηγήσαμε πώς να δημιουργήσετε ένα διάγραμμα Excel με το Aspose.Cells for Java και να το ενσωματώσετε σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for Java. Για την αντιμετώπιση του [object preview issue](/slides/el/java/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε την εικόνα του διαγράμματος στο πλαίσιο αντικειμένου OLE του διαγράμματος. Στην τελική παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του διαγράμματος, το διάγραμμα Excel ενεργοποιείται. Οι χρήστες μπορούν να επεξεργαστούν το ενσωματωμένο βιβλίο εργασίας Excel και μετά να επιστρέψουν στη διαφάνεια κάνοντας κλικ έξω από το ενεργοποιημένο βιβλίο εργασίας. Το μέγεθος του πλαισίου αντικειμένου OLE αλλάζει όταν ο χρήστης επιστρέφει στη διαφάνεια, και ο παράγοντας αλλαγής μεγέθους διαφέρει ανάλογα με τα αρχικά μεγέθη τόσο του πλαισίου OLE όσο και του ενσωματωμένου βιβλίου εργασίας Excel.

## **Αιτία της Αλλαγής Μεγέθους**

Το ενσωματωμένο βιβλίο εργασίας Excel έχει τις δικές του διαστάσεις παραθύρου, τις οποίες το Excel προσπαθεί να διατηρήσει όταν το αντικείμενο ενεργοποιείται για πρώτη φορά. Το πλαίσιο OLE στη διαφάνεια έχει οριστεί ανεξάρτητα. Όταν το βιβλίο εργασίας Excel ενεργοποιηθεί, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος του αντικειμένου για να διατηρήσουν τις αναλογίες του ως μέρος της διαδικασίας ενσωμάτωσης. Οι διαφορές μεταξύ του παραθύρου του βιβλίου εργασίας και του πλαισίου OLE μπορούν έτσι να προκαλέσουν την αλλαγή μεγέθους του αντικειμένου.

## **Λύση**

Ταιριάξτε το μέγεθος του διαγράμματος με το πλαίσιο OLE στη διαφάνεια και κρατήστε τις διαστάσεις του διαγράμματος ανεξάρτητες από το παράθυρο του βιβλίου εργασίας. Αυτή η λύση λειτουργεί με νέα παρουσίαση ή με υπάρχον πρότυπο.

Το παράδειγμα απαιτεί Aspose.Cells for Java και Aspose.Slides for Java. Δημιουργεί ένα απλό διάγραμμα στήλης σε ενεργό φύλλο διαγράμματος και ενσωματώνει το βιβλίο εργασίας σε μορφή XLS. Δεν ορίζεται εικόνα προεπισκόπησης διαγράμματος· το διάγραμμα γίνεται ορατό όταν το αντικείμενο OLE ενεργοποιηθεί στο PowerPoint.

Το παράδειγμα δημιουργεί μια νέα παρουσίαση με πλαίσιο OLE 9,5 × 4 ίντσες τοποθετημένο 0,5 ίντσες από την αριστερή άκρη και 1 ίντσα από το πάνω μέρος. Οι συντεταγμένες και οι διαστάσεις της διαφάνειας είναι σε σημεία (72 σημεία ανά ίντσα). Για υπάρχουσα παρουσίαση, δείτε [Use a Template](#use-a-template).

## **Ορισμός Σταθερού Μεγέθους Διαγράμματος**

Ορίστε το [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) σε false ώστε οι διαστάσεις του διαγράμματος να είναι ανεξάρτητες από το παράθυρο του βιβλίου εργασίας. Ορίστε τις διαστάσεις του [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) μέσω των [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) και [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), μετατρέποντας σημεία σε pixel με 96 pixel ανά ίντσα: ένα πλαίσιο 684 × 288 σημείων αντιστοιχεί σε διάγραμμα 912 × 384 pixel. Ορίστε το [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) στην τιμή CUSTOM του [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Το παράδειγμα ενσωματώνει το βιβλίο εργασίας με την [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) και αποθηκεύει παρουσίαση με πλαίσιο OLE 9,5 × 4 ίντσες.

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

        // Οι συντεταγμένες και οι διαστάσεις της διαφάνειας είναι σε σημεία (72 σημεία ανά ίντσα).
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

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Χρήση Προτύπου**

Η λογική μεγέθους είναι η ίδια για υπάρχουσα παρουσίαση. Για να προσαρμόσετε το παράδειγμα:

1. Φορτώστε την παρουσίαση προτύπου αντί να δημιουργήσετε κενή παρουσίαση.  
2. Ελέγξτε ότι η πρώτη διαφάνεια περιέχει τουλάχιστον τ three σχήματα και στη συνέχεια χρησιμοποιήστε το σχήμα στη θέση 2 ως χώρο κράτησης.  
3. Πάρτε το πλάτος και το ύψος του πλαισίου από το σχήμα αυτό αντί να χρησιμοποιήσετε τις σταθερές τιμές 684 και 288. Κρατήστε αμετάβλητους τους υπολογισμούς μεγέθους.  
4. Προσθέστε το πλαίσιο OLE στη θέση του χώρου κράτησης αντί για τις σταθερές συντεταγμένες 36 και 72.  
5. Αφαιρέστε τον χώρο κράτησης πριν αποθηκεύσετε την παρουσίαση.

## **Συχνές Ερωτήσεις**

**Γιατί το ενσωματωμένο διάγραμμα Excel αλλάζει μέγεθος μετά την ενεργοποίησή του στο PowerPoint;**  
Αυτό συμβαίνει επειδή το Excel προσπαθεί να επαναφέρει το αρχικό μέγεθος του παραθύρου όταν ενεργοποιείται για πρώτη φορά, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, γεγονός που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Πώς μπορώ να διατηρήσω σταθερές τις διαστάσεις του διαγράμματος και του πλαισίου OLE;**  
Ορίστε σταθερές διαστάσεις διαγράμματος που ταιριάζουν με το πλαίσιο OLE και χρησιμοποιήστε προσαρμοσμένο μέγεθος εκτύπωσης διαγράμματος πριν ενσωματώσετε το βιβλίο εργασίας. Το παραπάνω παράδειγμα δείχνει τις απαιτούμενες ρυθμίσεις και τις μετατροπές μονάδων.

**Είναι η αντιστοίχηση του μεγέθους του παραθύρου του βιβλίου εργασίας επαρκής;**  
Η αντιστοίχηση μόνο του μεγέθους του παραθύρου του βιβλίου εργασίας δεν αποτρέπει αξιόπιστα την αλλαγή μεγέθους του πλαισίου OLE μετά την ενεργοποίηση. Χρησιμοποιήστε σταθερές διαστάσεις διαγράμματος όπως φαίνεται στο παράδειγμα.

**Λειτουργεί αυτή η λύση τόσο με παρουσιάσεις βασισμένες σε πρότυπο όσο και με νέες παρουσιάσεις;**  
Ναι. Για πρότυπο, χρησιμοποιήστε τις διαστάσεις και τη θέση του χώρου κράτησης. Για νέα παρουσίαση, καθορίστε απευθείας τις διαστάσεις και τη θέση του πλαισίου.

**Μπορώ να χρησιμοποιήσω αυτό το παράδειγμα με διαγράμματα που δημιουργήθηκαν σε άλλα προγράμματα λογιστικών φύλλων;**  
Το παράδειγμα χρησιμοποιεί ένα βιβλίο εργασίας Excel που δημιουργήθηκε με το Aspose.Cells. Δεν δείχνει τη συμπεριφορά ενεργοποίησης για άλλα προγράμματα λογιστικών φύλλων.

## **Σχετικές Ενότητες**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/el/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)