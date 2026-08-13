---
title: Δημόσιο API και Αλλαγές Ασυμβατότητας προς Πίσω στο Aspose.Slides για Java 14.9.0
linktitle: Aspose.Slides για Java 14.9.0
type: docs
weight: 80
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- μετάβαση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των αλλαγών που διακόπτουν τη λειτουργία στο Aspose.Slides για Java, ώστε να μεταναστεύσετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα παραθέτει όλες τις [προστεθείσες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) κλάσεις, μεθόδους, ιδιότητες κλπ, τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) που εισήχθησαν με το Aspose.Slides for Java 14.9.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Προστεθειμένες Μέθοδοι για Αντικατάσταση Εικόνας με PPImage, IPPImage**
Νέες μέθοδοι που προστέθηκαν:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // Ο πρώτος τρόπος
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // Ο δεύτερος τρόπος
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Προστεθειμένες Μέθοδοι για Αποθήκευση Διαφανειών Διατηρώντας Αριθμούς Σελίδων**
Οι παρακάτω μέθοδοι έχουν προστεθεί:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Αυτές οι μέθοδοι επιτρέπουν την αποθήκευση συγκεκριμένων διαφανειών παρουσίασης σε μορφές PDF, XPS, TIFF, HTML. Ο πίνακας 'slides' επιτρέπει τον καθορισμό αριθμών σελίδων, ξεκινώντας από το 1.

``` java
// Προστέθηκαν υπερφορτώσεις στην IPresentation (οι τιμές του SaveFormat είναι ακέραιοι σταθερές στην Java):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // Πίνακας θέσεων διαφανειών

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Προστέθηκε η Τιμή Enum SmartArtLayoutType.Custom**
Αυτό το είδος διάταξης SmartArt αντιπροσωπεύει διάγραμμα με προσαρμοσμένο πρότυπο. Τα προσαρμοσμένα διαγράμματα μπορούν μόνο να φορτωθούν από αρχείο παρουσίασης και δεν μπορούν να δημιουργηθούν μέσω της μεθόδου ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Προστέθηκε η Κλάση SmartArtShape και το Interface ISmartArtShape**
Η κλάση Aspose.Slides.SmartArt.SmartArtShape (και το interface της Aspose.Slides.SmartArt.ISmartArtShape) προσθέτουν πρόσβαση σε μεμονωμένα σχήματα μέσα σε διάγραμμα SmartArt. Το SmartArtShape μπορεί να χρησιμοποιηθεί για την αλλαγή του FillFormat, LineFormat, την προσθήκη υπερσυνδέσμων κλπ.

{{% alert color="info" %}} 

Το SmartArtShape δεν υποστηρίζει τις ιδιότητες IShape RawFrame, Frame, Rotation, X, Y, Width, Height και ρίχνει System.NotSupportedException όταν γίνεται προσπάθεια πρόσβασης σε αυτές.

{{% /alert %}} 

Example of usage:

``` java
import com.aspose.slides.*;
import java.awt.Color;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Προστέθηκε η κλάση SmartArtShapeCollection, το interface ISmartArtShapeCollection και η μέθοδος ISmartArtNode.getShapes()**
Η κλάση Aspose.Slides.SmartArt.SmartArtShapeCollection (και το interface της Aspose.Slides.SmartArt.ISSmartArtShapeCollection) προσθέτουν πρόσβαση σε μεμονωμένα σχήματα μέσα σε διάγραμμα SmartArt. Η συλλογή περιέχει σχήματα που σχετίζονται με SmartArtNode. Η ιδιότητα SmartArtNode.Shapes επιστρέφει συλλογές όλων των σχημάτων που συνδέονται με τον κόμβο.

{{% alert color="info" %}} 

Ανάλογα με το SmartArtLayoutType, ένα SmartArtShape μπορεί να μοιράζεται μεταξύ πολλών κόμβων.

{{% /alert %}} 

 

``` java
import com.aspose.slides.*;
import java.awt.Color;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```