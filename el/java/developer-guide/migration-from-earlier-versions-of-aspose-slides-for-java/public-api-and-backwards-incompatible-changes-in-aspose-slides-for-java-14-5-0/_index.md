---
title: Δημόσιο API και Ασυμβατές Αλλαγές Πίσω στο Aspose.Slides για Java 14.5.0
linktitle: Aspose.Slides για Java 14.5.0
type: docs
weight: 40
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- μετάβαση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των κρίσιμων αλλαγών στο Aspose.Slides για Java, ώστε να μετακινήσετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα παραθέτει όλες τις [added](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) κλάσεις, μεθόδους, ιδιότητες κλπ., τυχόν νέους [restrictions](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) και άλλες [changes](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) που εισήχθησαν με το API Aspose.Slides για Java 14.5.0.

{{% /alert %}} 
## **Δημόσιο API και Ασυμβατές Αλλαγές Πίσω**
### **Πρόσθετες Κλάσεις και Μέθοδοι**
#### **Προστέθηκε η διεπαφή Aspose.Slides.IPresentationInfo και οι κλάσεις PresentationInfo**
Αναπαριστά πληροφορίες σχετικά με την παρουσίαση.

Method Boolean isEncrypted() gets True if a presentation is encrypted, otherwise gets False.

Method LoadFormat getLoadFormat() gets the presentation type.
#### **Προστέθηκε η μέθοδος Aspose.Slides.IShape.isGrouped()**
Η μέθοδος Aspose.Slides.IShape.isGrouped() καθορίζει εάν το σχήμα είναι ομαδοποιημένο.
#### **Προστέθηκε η μέθοδος Aspose.Slides.IShape.getParentGroup()**
Η μέθοδος Aspose.Slides.IShape.getParentGroup() επιστρέφει το γονικό αντικείμενο GroupShape εάν το σχήμα είναι ομαδοποιημένο. Διαφορετικά επιστρέφει null.
#### **Προστέθηκε η μέθοδος Aspose.Slides.IShapeCollection.addGroupShape()**
Η μέθοδος Aspose.Slides.IShapeCollection.addGroupShape() δημιουργεί ένα νέο GroupShape και το προσθέτει στο τέλος της συλλογής.

Το μέγεθος και η θέση του πλαισίου GroupShape θα προσαρμοστούν στο περιεχόμενο όταν προστεθεί νέο σχήμα στο GroupShape.
#### **Προστέθηκε η μέθοδος Aspose.Slides.IShapeCollection.clear()**
Η μέθοδος Aspose.Slides.IShapeCollection.clear() αφαιρεί όλα τα σχήματα από τη συλλογή.
#### **Προστέθηκε η μέθοδος Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Η μέθοδος Aspose.Slides.IShapeCollection.insertGroupShape(int) δημιουργεί ένα νέο GroupShape και το εισάγει στη συλλογή στη συγκεκριμένη θέση.
Το μέγεθος και η θέση του πλαισίου GroupShape θα προσαρμοστούν στο περιεχόμενο όταν προστεθεί νέο σχήμα στο GroupShape.
#### **Προστέθηκαν οι μέθοδοι IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
Αυτές οι μέθοδοι επιτρέπουν στους προγραμματιστές να λαμβάνουν πληροφορίες για ένα αρχείο/ροή παρουσίασης χωρίς πλήρη φόρτωση της παρουσίασης.
#### **Προστέθηκε η μέθοδος IPresentationFactory PresentationFactory.getInstance()**
Επιτρέπει τη χρήση της λειτουργικότητας του εργοστασίου χωρίς δημιουργία αντικειμένου.
### **Περιορισμοί**
#### **Περιορισμοί που προστέθηκαν για τη χρήση ακαθόριστων τιμών στην IShape.getFrame()**
Ο κώδικας που προσπαθεί να εκχωρήσει ένα ακαθόριστο πλαίσιο στην IShape.setFrame(IShapeFrame) δεν έχει νόημα σε γενικές περιπτώσεις (ιδιαίτερα όταν το γονικό GroupShape είναι πολλαπλά ενσωματωμένο σε άλλα {{GroupShape}}s). Για παράδειγμα:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Εκκινεί μια ArgumentException: οι τιμές του πλαισίου πρέπει να είναι καθορισμένες.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

ή

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Δημιουργεί μια ArgumentException: οι τιμές x, y, width και height πρέπει να είναι καθορισμένες.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Τέτοιος κώδικας μπορεί να οδηγήσει σε ασαφείς καταστάσεις. Έτσι προστέθηκαν περιορισμοί για τη χρήση ακαθόριστων τιμών στο IShape.Frame. Οι τιμές των x, y, width, height, flipH, flipV και rotationAngle πρέπει να είναι καθορισμένες (όχι Float.NaN ή NullableBool.NotDefined). Ο παραπάνω κώδικας τώρα προκαλεί εξαίρεση ArgumentException.
Αυτό ισχύει για τις ακόλουθες περιπτώσεις χρήσης:

``` java
// Το πλαίσιο που περνιέται στην IShape.setFrame(IShapeFrame) δεν μπορεί να περιέχει ακαθόριστες τιμές.

// Οι παράμετροι x, y, width και height των παρακάτω μεθόδων IShapeCollection
// δεν μπορούν επίσης να είναι Float.NaN:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Αλλά το πλαίσιο IShape.getRawFrame() μπορεί να είναι ακαθόριστο. Αυτό έχει λογική όταν ένα σχήμα είναι συνδεδεμένο με ένα placeholder. Τότε οι ακαθόριστες τιμές του πλαισίου του σχήματος αντικαθίστανται από το γονικό placeholder. Εάν δεν υπάρχει γονικό placeholder για το σχήμα, τότε χρησιμοποιούνται οι προεπιλεγμένες τιμές όταν υπολογίζεται το αποτελεσματικό πλαίσιο βάσει του IShape.getRawFrame(). Οι προεπιλεγμένες τιμές είναι 0 και NullableBool.False για x, y, width, height, flipH, flipV και rotationAngle. Για παράδειγμα:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // Το σ shape είναι συνδεδεμένο με ένα placeholder.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Τώρα το σ shape κληρονομεί τις τιμές x, y, height, flipH και flipV από το placeholder
    // και αντικαθιστά το width = 100 και το rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Αλλαγμένες Ιδιότητες**
#### **Αλλαγή του Τύπου και του Ονόματος της μεθόδου Aspose.Slides.IShapeCollection.getParent()**
Ο τύπος της ιδιότητας Aspose.Slides.IShapeCollection.Parent άλλαξε από ISlideComponent στον νέο τύπο διεπαφής IGroupShape. Η διεπαφή IGroupShape είναι απόγονος του ISlideComponent, έτσι ο υπάρχων κώδικας δεν απαιτεί προσαρμογή.

Το όνομα της μεθόδου Aspose.Slides.IShapeCollection.getParent() άλλαξε από getParent σε getParentGroup().
#### **Αλλαγή του Τύπου των μεθόδων Aspose.Slides.IShapeFrame.getFlipH() και .getFlipV()**
Ο τύπος της μεθόδου Aspose.Slides.IShapeFrame.getFlipH() άλλαξε από bool σε NullableBool.

Η μέθοδος IShape.getFrame() επιστρέφει το αποτελεσματικό αντίτυπο του IShapeFrame (όλες οι ιδιότητές του έχουν ορισμένες αποτελεσματικές τιμές).

Η μέθοδος IShape.getRawFrame() επιστρέφει ένα αντίτυπο IShapeFrame του οποίου κάθε ιδιότητα μπορεί να έχει ακαθόρισμένη τιμή (ιδιαίτερα οι FlipH ή FlipV μπορούν να έχουν τιμή NullableBool.NotDefined).