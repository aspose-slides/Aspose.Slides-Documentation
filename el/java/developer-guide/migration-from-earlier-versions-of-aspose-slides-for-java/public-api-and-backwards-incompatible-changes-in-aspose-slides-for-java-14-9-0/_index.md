---
title: Δημόσιο API και Ασυμβίβαστες Αλλαγές σε Aspose.Slides για Java 14.9.0
linktitle: Aspose.Slides για Java 14.9.0
type: docs
weight: 80
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των ασυμβίβαστων αλλαγών στο Aspose.Slides για Java για ομαλή μετανάστευση των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλα τα [προστέθηκαν](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) που εισήχθησαν με το Aspose.Slides for Java 14.9.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Προστέθηκαν Μέθοδοι για Αντικατάσταση Εικόνας σε PPImage, IPPImage**
Νέες μέθοδοι προστέθηκαν:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//Ο πρώτος τρόπος

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//Ο δεύτερος τρόπος

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);
```
### **Προστέθηκαν Μέθοδοι για Αποθήκευση Διαφανειών Διατηρώντας Αριθμούς Σελίδας**
Οι ακόλουθες μέθοδοι έχουν προστεθεί:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Αυτές οι μέθοδοι επιτρέπουν την αποθήκευση συγκεκριμένων διαφανειών παρουσίασης σε μορφές PDF, XPS, TIFF, HTML. Ο πίνακας 'slides' επιτρέπει τον ορισμό αριθμών σελίδας, ξεκινώντας από το 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Διάταξη θέσεων διαφανειών

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Προστέθηκε η Τιμή Enum SmartArtLayoutType.Custom**
Αυτός ο τύπος διάταξης SmartArt αντιπροσωπεύει ένα διάγραμμα με προσαρμοσμένο πρότυπο. Τα προσαρμοσμένα διαγράμματα μπορούν να φορτωθούν μόνο από αρχείο παρουσίασης και δεν μπορούν να δημιουργηθούν μέσω της μεθόδου ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Προστέθηκε η Κλάση SmartArtShape και η Διεπαφή ISmartArtShape**
Η κλάση Aspose.Slides.SmartArt.SmartArtShape (και η διεπαφή της Aspose.Slides.SmartArt.ISmartArtShape) παρέχει πρόσβαση σε μεμονωμένα σχήματα μέσα σε διάγραμμα SmartArt. Το SmartArtShape μπορεί να χρησιμοποιηθεί για αλλαγή του FillFormat, LineFormat, προσθήκη υπερσυνδέσεων κ.λπ.

{{% alert color="primary" %}} 

Το SmartArtShape δεν υποστηρίζει τις ιδιότητες IShape RawFrame, Frame, Rotation, X, Y, Width, Height και ρίχνει System.NotSupportedException όταν γίνεται προσπάθεια πρόσβασης σε αυτές.

{{% /alert %}} 

Παράδειγμα χρήσης:

``` java

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
### **Προστέθηκαν η κλάση SmartArtShapeCollection, η διεπαφή ISmartArtShapeCollection και η μέθοδος ISmartArtNode.getShapes()**
Η κλάση Aspose.Slides.SmartArt.SmartArtShapeCollection (και η διεπαφή της Aspose.Slides.SmartArt.ISmartArtShapeCollection) παρέχει πρόσβαση σε μεμονωμένα σχήματα μέσα σε διάγραμμα SmartArt. Η συλλογή περιέχει σχήματα που σχετίζονται με το SmartArtNode. Η ιδιότητα SmartArtNode.Shapes επιστρέφει συλλογές όλων των σχημάτων που σχετίζονται με τον κόμβο.

{{% alert color="primary" %}} 

Ανάλογα με το SmartArtLayoutType, ένα SmartArtShape μπορεί να μοιράζεται μεταξύ πολλών κόμβων.

{{% /alert %}} 




``` java

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