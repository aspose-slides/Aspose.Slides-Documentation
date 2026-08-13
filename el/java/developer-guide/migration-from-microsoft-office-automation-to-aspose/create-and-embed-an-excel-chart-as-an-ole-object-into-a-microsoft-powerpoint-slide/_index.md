---
title: Δημιουργία και Ενσωμάτωση Διαγραμμάτων Excel ως Αντικειμένων OLE χρησιμοποιώντας VSTO και Aspose.Slides για Java
linktitle: Δημιουργία και Ενσωμάτωση Διαγραμμάτων Excel ως Αντικειμένων OLE
type: docs
weight: 60
url: /el/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- δημιουργία διαγράμματος
- ενσωμάτωση διαγράμματος Excel
- αντικείμενο OLE
- μετάβαση
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: Μετάβαση από την αυτοματοποίηση Microsoft Office σε Aspose.Slides για Java και ενσωμάτωση διαγραμμάτων Excel ως αντικείμενα OLE σε διαφάνειες PowerPoint (PPT, PPTX) σε Java.
---
{{% alert color="info" %}} 

 Τα διαγράμματα είναι οπτικές απεικονίσεις των δεδομένων σας και χρησιμοποιούνται ευρέως σε διαφάνειες παρουσιάσεων. Αυτό το άρθρο θα σας δείξει τον κώδικα για τη δημιουργία και ενσωμάτωση ενός διαγράμματος Excel ως αντικειμένου OLE στη διαφάνεια PowerPoint προγραμματιστικά, χρησιμοποιώντας το [VSTO](/slides/el/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) και το [Aspose.Slides for Java](/slides/el/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Δημιουργία και Ενσωμάτωση Διαγράμματος Excel**
Τα δύο παραδείγματα κώδικα παρακάτω είναι μεγάλα και λεπτομερή επειδή η εργασία που περιγράφουν είναι πολύπλοκη. Δημιουργείτε ένα βιβλίο εργασίας Microsoft Excel, δημιουργείτε ένα διάγραμμα και στη συνέχεια δημιουργείτε την παρουσίαση Microsoft PowerPoint στην οποία θα ενσωματώσετε το διάγραμμα. Τα αντικείμενα OLE περιέχουν συνδέσμους στο αρχικό έγγραφο, ώστε ένας χρήστης που κάνει διπλό κλικ στο ενσωματωμένο αρχείο να εκκινήσει το αρχείο και την εφαρμογή του.

### **Παράδειγμα VSTO**
Χρησιμοποιώντας VSTO, εκτελούνται τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του αντικειμένου Microsoft Excel ApplicationClass.
1. Δημιουργήστε ένα νέο βιβλίο εργασίας με ένα φύλλο σε αυτό.
1. Προσθέστε διάγραμμα στο φύλλο.
1. Αποθηκεύστε το βιβλίο εργασίας.
1. Ανοίξτε το βιβλίο εργασίας Excel που περιέχει το φύλλο εργασίας με τα δεδομένα του διαγράμματος.
1. Λάβετε τη συλλογή ChartObjects για το φύλλο.
1. Λάβετε το διάγραμμα για αντιγραφή.
1. Δημιουργήστε μια παρουσία παρουσίασης Microsoft PowerPoint.
1. Προσθέστε μια κενή διαφάνεια στην παρουσίαση.
1. Αντιγράψτε το διάγραμμα από το φύλλο Excel στο πρόχειρο.
1. Επικολλήστε το διάγραμμα στην παρουσίαση PowerPoint.
1. Τοποθετήστε το διάγραμμα στη διαφάνεια.
1. Αποθηκεύστε την παρουσίαση.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Παράδειγμα Aspose.Slides for Java**
Χρησιμοποιώντας Aspose.Slides για .NET, εκτελούνται τα παρακάτω βήματα:

1. Δημιουργήστε ένα βιβλίο εργασίας χρησιμοποιώντας Aspose.Cells για Java.
1. Δημιουργήστε ένα διάγραμμα Microsoft Excel.
1. Ορίστε το μέγεθος OLE του διαγράμματος Excel.
1. Λάβετε μια εικόνα του διαγράμματος.
1. Ενσωματώστε το διάγραμμα Excel ως αντικείμενο OLE μέσα σε παρουσίαση PPTX χρησιμοποιώντας Aspose.Slides για Java.
1. Αντικαταστήστε την εικόνα του αντικειμένου που άλλαξε με την εικόνα που αποκτήθηκε στο βήμα 3 για την αντιμετώπιση του ζητήματος αλλαγής αντικειμένου.
1. Γράψτε την παρουσίαση εξόδου στο δίσκο σε μορφή PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}