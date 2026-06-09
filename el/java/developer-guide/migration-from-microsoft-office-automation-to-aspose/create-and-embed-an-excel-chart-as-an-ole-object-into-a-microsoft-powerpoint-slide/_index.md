---
title: Δημιουργία και Ενσωμάτωση Γραφημάτων Excel ως Αντικείμενα OLE χρησιμοποιώντας VSTO και Aspose.Slides για Java
linktitle: Δημιουργία και Ενσωμάτωση Γραφημάτων Excel ως Αντικείμενα OLE
type: docs
weight: 60
url: /el/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- δημιουργία γραφήματος
- ενσωμάτωση γραφήματος Excel
- αντικείμενο OLE
- μετανάστευση
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μεταφορά από αυτοματοποίηση Microsoft Office σε Aspose.Slides για Java και ενσωμάτωση γραφημάτων Excel ως αντικείμενα OLE σε διαφάνειες PowerPoint (PPT, PPTX) σε Java."
---
{{% alert color="primary" %}} 

 Τα γραφήματα είναι οπτικές αναπαραστάσεις των δεδομένων σας και χρησιμοποιούνται εκτενώς σε διαφάνειες παρουσίασης. Αυτό το άρθρο θα σας δείξει τον κώδικα για τη δημιουργία και ενσωμάτωση ενός γραφήματος Excel ως αντικείμενο OLE σε διαφάνεια PowerPoint προγραμματιστικά χρησιμοποιώντας [VSTO](/slides/el/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) και [Aspose.Slides for Java](/slides/el/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Δημιουργία και Ενσωμάτωση ενός Γραφήματος Excel**
Τα δύο παραδείγματα κώδικα παρακάτω είναι μακριά και λεπτομερή επειδή η εργασία που περιγράφουν είναι πολύπλοκη. Δημιουργείτε ένα βιβλίο εργασίας Microsoft Excel, δημιουργείτε ένα γράφημα και στη συνέχεια δημιουργείτε την παρουσίαση Microsoft PowerPoint στην οποία θα ενσωματώσετε το γράφημα. Τα αντικείμενα OLE περιέχουν συνδέσμους προς το αρχικό έγγραφο, έτσι ένας χρήστης που κάνει διπλό κλικ στο ενσωματωμένο αρχείο θα εκκινήσει το αρχείο και την εφαρμογή του.
### **VSTO Example**
Χρησιμοποιώντας VSTO, εκτελούνται τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του αντικειμένου Microsoft Excel ApplicationClass.
1. Δημιουργήστε ένα νέο βιβλίο εργασίας με ένα φύλλο.
1. Προσθέστε γράφημα στο φύλλο.
1. Αποθηκεύστε το βιβλίο εργασίας.
1. Ανοίξτε το βιβλίο εργασίας Excel που περιέχει το φύλλο εργασίας με τα δεδομένα του γραφήματος.
1. Λάβετε τη συλλογή ChartObjects για το φύλλο.
1. Λάβετε το γράφημα για αντιγραφή.
1. Δημιουργήστε μια παρουσία παρουσίασης Microsoft PowerPoint.
1. Προσθέστε μια κενή διαφάνεια στην παρουσίαση.
1. Αντιγράψτε το γράφημα από το φύλλο εργασίας Excel στο πρόχειρο.
1. Επικολλήστε το γράφημα στην παρουσίαση PowerPoint.
1. Τοποθετήστε το γράφημα στη διαφάνεια.
1. Αποθηκεύστε την παρουσίαση.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java Example**
Χρησιμοποιώντας Aspose.Slides για .NET, εκτελούνται τα παρακάτω βήματα:

1. Δημιουργήστε ένα βιβλίο εργασίας χρησιμοποιώντας Aspose.Cells for Java.
1. Δημιουργήστε ένα γράφημα Microsoft Excel.
1. Ορίστε το μέγεθος OLE του γραφήματος Excel.
1. Λάβετε μια εικόνα του γραφήματος.
1. Ενσωματώστε το γράφημα Excel ως αντικείμενο OLE μέσα σε παρουσίαση PPTX χρησιμοποιώντας το Aspose.Slides for Java.
1. Αντικαταστήστε την εικόνα αντικειμένου που άλλαξε με την εικόνα που αποκτήθηκε στο βήμα 3 για να αντιμετωπίσετε το πρόβλημα αλλαγής αντικειμένου.
1. Γράψτε την τελική παρουσίαση στο δίσκο σε μορφή PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}