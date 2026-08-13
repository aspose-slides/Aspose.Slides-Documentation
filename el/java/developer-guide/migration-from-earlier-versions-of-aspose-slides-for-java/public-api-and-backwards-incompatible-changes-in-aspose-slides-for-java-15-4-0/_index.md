---
title: Δημόσιο API και Αντισυμβατές Προς Πίσω Αλλαγές στο Aspose.Slides για Java 15.4.0
linktitle: Aspose.Slides για Java 15.4.0
type: docs
weight: 120
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των δραστικών αλλαγών στο Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστέθειες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) που εισήχθησαν με το API του Aspose.Slides για Java 15.4.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Έγινε προσθήκη του enum OrganizationChartLayoutType**
Το enum com.aspose.slides.OrganizationChartLayoutType αντιπροσωπεύει τον τύπο μορφοποίησης των παιδικών κόμβων σε ένα οργανωτικό γράφημα.
### **Έγινε προσθήκη της μεθόδου IBulletFormat.applyDefaultParagraphIndentsShifts()**
Η μέθοδος com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ορίζει προεπιλεγμένες μη‑μηδενικές μετατοπίσεις για το ενεργό εσοχή παραγράφου (Indent) και το αριστερό περιθώριο (MarginLeft) όταν είναι ενεργά τα κουκίδες (όπως κάνει το PowerPoint όταν ενεργοποιείτε τις κουκίδες/αρίθμηση παραγράφου). Εάν οι κουκίδες είναι απενεργοποιημένες, επαναφέρει απλώς την εσοχή και το αριστερό περιθώριο της παραγράφου (όπως κάνει το PowerPoint όταν απενεργοποιείτε τις κουκίδες/αρίθμηση).
### **Έγινε προσθήκη της μεθόδου IConnector.reroute()**
Η μέθοδος com.aspose.slides.IConnector.reroute() αναπροσαρμόζει τον σύνδεσμο ώστε να ακολουθεί τη δυνατόν πιο σύντομη διαδρομή μεταξύ των σχημάτων που συνδέει. Για να το πετύχει, η μέθοδος reroute() μπορεί να αλλάξει τα πεδία StartShapeConnectionSiteIndex και EndShapeConnectionSiteIndex.

``` java
import com.aspose.slides.*;


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
### **Έγινε προσθήκη της μεθόδου IPresentation.getSlideById(long)**
Η μέθοδος Aspose.Slides.IPresentation.getSlideById(long) επιστρέφει ένα Slide, MasterSlide ή LayoutSlide βάσει του αναγνωριστικού της διαφάνειας (slide Id).

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Έγινε προσθήκη της μεθόδου ISmartArt.getNodes()**
Η μέθοδος com.aspose.slides.ISmartArt.getNodes() επιστρέφει μια συλλογή από κόμβους ρίζας στο αντικείμενο SmartArt.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // επιλέξτε τον δεύτερο κόμβο ρίζας

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Έγινε προσθήκη της μεθόδου ISmartArt.setLayout(int)**
Η μέθοδος για την ιδιότητα com.aspose.slides.ISmartArt.setLayout(int) προστέθηκε. Επιτρέπει την αλλαγή του τύπου διάταξης ενός υπάρχοντος διαγράμματος.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Έγινε προσθήκη της μεθόδου ISmartArtNode.isHidden()**
Η μέθοδος com.aspose.slides.ISmartArtNode.isHidden() επιστρέφει true εάν αυτός ο κόμβος είναι κρυφός στο μοντέλο δεδομένων.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //επιστρέφει true

if(hidden) {

    //κάντε κάποιες ενέργειες ή ειδοποιήσεις

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Έγινε προσθήκη των μεθόδων ISmartArt.isReversed(), setReversed()**
Η ιδιότητα com.aspose.slides.ISmartArt.IsReversed επιτρέπει την ανάγνωση ή ορισμό της κατάστασης του διαγράμματος SmartArt ως (αριστερά‑προς‑δεξιά) LTR ή (δεξιά‑προς‑αριστερά) RTL, εφόσον το διάγραμμα υποστηρίζει αντιστροφή.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Έγινε προσθήκη των μεθόδων ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
Οι μέθοδοι com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() και setOrganizationChartLayout(int) επιτρέπουν την ανάγνωση ή ορισμό του τύπου οργανωτικού διαγράμματος που σχετίζεται με τον τρέχοντα κόμβο.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Έγινε προσθήκη της ιδιότητας IShape.getConnectionSiteCount()**
Η ιδιότητα com.aspose.slides.getConnectionSiteCount() επιστρέφει τον αριθμό των σημείων σύνδεσης στο σχήμα.

``` java
import com.aspose.slides.*;


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
### **Μικρές Αλλαγές**
Αυτή είναι η λίστα των μικρών αλλαγών του API:

|Enum com.aspose.slides.BevelColorMode |διαγραμμένο, αχρησιμοποίητο enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |διαγραμμένο, αχρησιμοποίητο property |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |προστέθηκε |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |διαγράφηκε |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |διαγράφηκε ως παρωχημένο |