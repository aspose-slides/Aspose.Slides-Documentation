---
title: Δημόσιο API και Αλλαγές που Δεν Είναι Συμβατές με Παλαιότερες Εκδόσεις στο Aspose.Slides για Java 15.4.0
linktitle: Aspose.Slides για Java 15.4.0
type: docs
weight: 120
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- μεταφορά
- παραδοσιακός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των breaking changes στο Aspose.Slides για Java ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP σας."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα παραθέτει όλες τις [προστεθειμένες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) που εισήχθηκαν με το API Aspose.Slides for Java 15.4.0.

{{% /alert %}} 
## **Public API Changes**
### **Enum OrganizationChartLayoutType has been added**
Το enum com.aspose.slides.OrganizationChartLayoutType αντιπροσωπεύει τον τύπο μορφοποίησης των υπο‑κόμβων σε ένα διάγραμμα οργανωτικού πίνακα.
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() has been added**
Η μέθοδος com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ορίζει προεπιλεγμένες μη μηδενικές μετατοπίσεις για το αποτελεσματικό κλείσιμο παραγράφου (Indent) και το αριστερό περιθώριο (MarginLeft) όταν είναι ενεργά τα κουκκίδες (όπως κάνει το PowerPoint αν ενεργοποιηθούν τα κουκκίδες/αρίθμηση παραγράφου). Αν οι κουκκίδες είναι απενεργοποιημένες, επαναφέρει απλώς το Indent και το MarginLeft (όπως κάνει το PowerPoint αν απενεργοποιηθούν).
### **Method IConnector.reroute() has been added**
Η μέθοδος com.aspose.slides.IConnector.reroute() επαναδρομολογεί τον σύνδεσμο ώστε να ακολουθεί τη συντομότερη δυνατή διαδρομή μεταξύ των σχημάτων που συνδέει. Για να το πετύχει, η μέθοδος reroute() μπορεί να αλλάξει τις τιμές StartShapeConnectionSiteIndex και EndShapeConnectionSiteIndex.

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **Method IPresentation.getSlideById(long) has been added**
Η μέθοδος Aspose.Slides.IPresentation.getSlideById(int) επιστρέφει ένα Slide, MasterSlide ή LayoutSlide με βάση το αναγνωριστικό (Id) της διαφάνειας.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() has been added**
Η μέθοδος com.aspose.slides.ISmartArt.getNodes() επιστρέφει τη συλλογή των ριζικών κόμβων στο αντικείμενο SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // επιλογή δεύτερου ριζικού κόμβου

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) has been added**
Η μέθοδος για την ιδιότητα com.aspose.slides.ISmartArt.setLayout(int) προστέθηκε. Επιτρέπει την αλλαγή του τύπου διάταξης ενός υπάρχοντος διαγράμματος.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() has been added**
Η μέθοδος com.aspose.slides.ISmartArtNode.isHidden() επιστρέφει true εάν ο κόμβος είναι κρυφός στο μοντέλο δεδομένων.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //επιστρέφει true

if(hidden) {

    //κάντε κάποιες ενέργειες ή ειδοποιήσεις

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArt.isReversed(), setReserved() have been added**
Η ιδιότητα com.aspose.slides.ISmartArt.IsReversed επιτρέπει την ανάγνωση ή τον ορισμό της κατάστασης του διαγράμματος SmartArt ως αριστερά‑προς‑δεξιά (LTR) ή δεξιά‑προς‑αριστερά (RTL), εάν το διάγραμμα υποστηρίζει την αντιστροφή.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) have been added**
Οι μέθοδοι com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() και setOrganizationChartLayout(int) επιτρέπουν την ανάγνωση ή τον ορισμό του τύπου διάγραμμα οργανωτικού πίνακα που σχετίζεται με τον τρέχοντα κόμβο.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount() has been added**
Η ιδιότητα com.aspose.slides.getConnectionSiteCount() επιστρέφει τον αριθμό των σημείων σύνδεσης στο σχήμα.

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **Minor Changes**
Αυτή είναι η λίστα με τις μικρές αλλαγές API:

|Enum com.aspose.slides.BevelColorMode |διαγραμμένο, αχρησιμοποίητο enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |διαγραμμένο, αχρησιμοποίητο property |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |προστέθηκε |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |διαγραμμένο |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |διαγραμμένο ως παλαιό |