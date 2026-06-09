---
title: Δημόσιο API και Ασυμβίβαστες Αντίστροφες Αλλαγές στο Aspose.Slides για Java 14.8.0
linktitle: Aspose.Slides για Java 14.8.0
type: docs
weight: 70
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- μετανάστευση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των σημαντικών αλλαγών στο Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα παραθέτει όλες τις προστιθέμενες κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους περιορισμούς και άλλες αλλαγές που εισήχθησαν με το API Aspose.Slides for Java 14.8.0.

{{% /alert %}} 
## **Αλλαγές δημόσιου API**
### **Προστέθηκαν οι μέθοδοι Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() και setOverlap(byte)**
Η μέθοδος Aspose.Slides.Charts.IChartSeries.getOverlap() επιστρέφει το πόσο πρέπει να επικαλύπτονται οι ράβδοι και οι στήλες σε 2D γραφήματα (σε εύρος από -100 έως 100).  
Αυτή η μέθοδος δεν ισχύει μόνο για συγκεκριμένες σειρές, αλλά για όλες τις σειρές της γονικής ομάδας σειρών – πρόκειται για προβολή της αντίστοιχης ιδιότητας της ομάδας.

- Χρησιμοποιήστε τη μέθοδο IChartSeries.getParentSeriesGroup() για πρόσβαση στη γονική ομάδα σειρών.  
- Χρησιμοποιήστε τις μεθόδους IChartSeriesGroup.getOverlap() και setOverlap(byte) για τη διαχείριση της τιμής.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Προστέθηκε η τιμή Enum ShapeThumbnailBounds.Appearance**
Αυτή η μέθοδος δημιουργίας μικρογραφιών σχήματος επιτρέπει στους προγραμματιστές να δημιουργούν μια μικρογραφία σχήματος εντός των ορίων της εμφάνισής του. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η δημιουργημένη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Προστέθηκαν οι κλάσεις VbaProject και η διεπαφή IVbaProject, Άλλαξαν οι μέθοδοι Presentation.getVbaProject() και setVbaProject(VbaProject)**
Μια νέα λειτουργία επιτρέπει στους προγραμματιστές να δημιουργούν και να επεξεργάζονται έργα VBA σε μια παρουσίαση.

``` java

 Presentation pres = new Presentation();

// Δημιουργία νέου έργου VBA

pres.setVbaProject(new VbaProject());

// Προσθήκη κενού μοντέλου στο έργο VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Ορισμός κώδικα πηγής του μοντέλου

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

pres.save("data\\test.pptm", SaveFormat.Pptm);
```