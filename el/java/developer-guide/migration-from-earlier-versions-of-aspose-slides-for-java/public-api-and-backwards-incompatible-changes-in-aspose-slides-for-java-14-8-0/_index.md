---
title: Δημόσιο API και Μη Συμβατές Αλλαγές στο Aspose.Slides για Java 14.8.0
linktitle: Aspose.Slides για Java 14.8.0
type: docs
weight: 70
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- μεταφορά
- κληρονομημένος κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των διασπαστικών αλλαγών στο Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα απαριθμεί όλες τις [added](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) κλάσεις, μεθόδους, ιδιότητες κλπ., τυχόν νέους περιορισμούς και άλλες [changes](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) που εισήχθησαν στο API του Aspose.Slides for Java 14.8.0.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Προστέθηκαν οι Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() και setOverlap(byte) Μέθοδοι**
Η μέθοδος Aspose.Slides.Charts.IChartSeries.getOverlap() επιστρέφει το πόσο πρέπει να επικαλύπτονται οι ράβδοι και οι στήλες σε 2Δ διαγράμματα (σε εύρος από -100 έως 100).  
Αυτή η μέθοδος δεν ισχύει μόνο για συγκεκριμένες σειρές, αλλά για όλες τις σειρές της γονικής ομάδας σειρών – πρόκειται για προβολή της αντίστοιχης ιδιότητας της ομάδας.

- Χρησιμοποιήστε τη μέθοδο IChartSeries.getParentSeriesGroup() για πρόσβαση στην γονική ομάδα σειρών.  
- Χρησιμοποιήστε τις μεθόδους IChartSeriesGroup.getOverlap() και setOverlap(byte) για τη διαχείριση της τιμής.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Προστέθηκε η τιμή του Enum ShapeThumbnailBounds.Appearance**
Αυτή η μέθοδος δημιουργίας μικρογραφιών σχήματος επιτρέπει στους προγραμματιστές να δημιουργούν μια μικρογραφία σχήματος εντός των ορίων της εμφάνισής του. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η παραγόμενη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Προστέθηκαν η κλάση VbaProject και το interface IVbaProject, τροποποιήθηκαν οι μέθοδοι Presentation.getVbaProject() και setVbaProject(VbaProject)**
Μια νέα δυνατότητα επιτρέπει στους προγραμματιστές να δημιουργούν και να επεξεργάζονται έργα VBA σε μια παρουσίαση.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Δημιουργία νέου έργου VBA

pres.setVbaProject(new VbaProject());

// Προσθήκη κενής μονάδας στο έργο VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Ορισμός κώδικα πηγής της μονάδας

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Δημιουργία αναφοράς στο <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Δημιουργία αναφοράς στο Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Προσθήκη αναφορών στο έργο VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```