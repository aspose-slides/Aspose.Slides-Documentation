---
title: Δημόσιο API και Ασυμβατές Αλλαγές Προς Πίσω στο Aspose.Slides για Java 14.5.0
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των breaking changes στο Aspose.Slides για Java, ώστε να μεταβιβάσετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}}

Αυτή η σελίδα καταγράφει όλες τις [προσθήκες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) κλάσεων, μεθόδων, ιδιοτήτων κ.λπ., τυχόν νέους [περιορισμούς](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) που εισήχθησαν με το Aspose.Slides for Java 14.5.0 API.

{{% /alert %}} 
## **Δημόσιο API και Ασυμβατές Αλλαγές Προς Πίσω**
### **Προστιθέμενες Κλάσεις και Μέθοδοι**
#### **Προστέθηκε η διεπαφή Aspose.Slides.IPresentationInfo και οι κλάσεις PresentationInfo**
Αναπαριστά πληροφορίες σχετικά με την παρουσίαση.

Η μέθοδος Boolean isEncrypted() επιστρέφει True εάν η παρουσίαση είναι κρυπτογραφημένη, διαφορετικά επιστρέφει False.

Η μέθοδος LoadFormat getLoadFormat() επιστρέφει τον τύπο της παρουσίασης.
#### **Προστέθηκε η μέθοδος Aspose.Slides.IShape.isGrouped()**
Η μέθοδος Aspose.Slides.IShape.isGrouped() καθορίζει αν το σχήμα είναι ομαδοποιημένο.
#### **Προστέθηκε η μέθοδος Aspose.Slides.IShape.getParentGroup()**
Η μέθοδος Aspose.Slides.IShape.getParentGroup() επιστρέφει το αντικείμενο GroupShape γονέα εάν το σχήμα είναι ομαδοποιημένο. Διαφορετικά επιστρέφει null.
#### **Προστέθηκε η μέθοδος Aspose.Slides.IShapeCollection.addGroupShape()**
Η μέθοδος Aspose.Slides.IShapeCollection.addGroupShape() δημιουργεί ένα νέο GroupShape και το προσθέτει στο τέλος της συλλογής.

Το μέγεθος και η θέση του πλαισίου του GroupShape θα προσαρμόζονται στο περιεχόμενο όταν προστεθεί νέο σχήμα στο GroupShape.
#### **Προστέθηκε η μέθοδος Aspose.Slides.IShapeCollection.clear()**
Η μέθοδος Aspose.Slides.IShapeCollection.clear() αφαιρεί όλα τα σχήματα από τη συλλογή.
#### **Προστέθηκε η μέθοδος Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Η μέθοδος Aspose.Slides.IShapeCollection.insertGroupShape(int) δημιουργεί ένα νέο GroupShape και το εισάγει στη συλλογή στο καθορισμένο δείκτη.
Το μέγεθος και η θέση του πλαισίου του GroupShape θα προσαρμόζονται στο περιεχόμενο όταν προστεθεί νέο σχήμα στο GroupShape.
#### **Προστέθηκαν οι μέθοδοι IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Αυτές οι μέθοδοι επιτρέπουν στους προγραμματιστές να λαμβάνουν πληροφορίες για ένα αρχείο/ροή παρουσίασης χωρίς πλήρη φόρτωση της παρουσίασης.
#### **Προστέθηκε η μέθοδος IPresentationFactory PresentationFactory.getInstance()**
Επιτρέπει τη χρήση της λειτουργικότητας του εργοστασίου χωρίς δημιουργία αντικειμένου.
### **Περιορισμοί**
#### **Προστέθηκαν περιορισμοί για τη χρήση αόριστων τιμών στο IShape.getFrame()**
Ο κώδικας που προσπαθεί να εκχωρήσει ένα αόριστο πλαίσιο στο IShape.setFrame(IShapeFrame) δεν έχει νόημα σε γενικές περιπτώσεις (ιδιαίτερα όταν το γονικό GroupShape είναι πολλαπλά ενσωματωμένο σε άλλα {{GroupShape}}). Για παράδειγμα:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

ή

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Τέτοιος κώδικας μπορεί να οδηγήσει σε ασαφείς καταστάσεις. Συνεπώς προστέθηκαν περιορισμοί για τη χρήση αόριστων τιμών στο IShape.Frame. Οι τιμές των x, y, width, height, flipH, flipV και rotationAngle πρέπει να είναι ορισμένες (δεν Float.NaN ή NullableBool.NotDefined). Ο παραπάνω κώδικας παραδείγματος τώρα ρίχνει μια εξαίρεση ArgumentException.
Αυτό εφαρμόζεται σε αυτές τις περιπτώσεις χρήσης:

``` java

 IShape shape = ...;

shape.setFrame(...); // δεν μπορεί να είναι αόριστο

IShapeCollection shapes = ...;

// οι παράμετροι x, y, width, height δεν μπορούν να είναι Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}
```

Ωστόσο, το πλαίσιο IShape.getRawFrame() μπορεί να είναι αόριστο. Αυτό έχει νόημα όταν ένα σχήμα είναι συνδεδεμένο με ένα placeholder. Τότε οι αόριστες τιμές πλαισίου του σχήματος αντικαθίστανται από το γονικό placeholder σχήμα. Εάν δεν υπάρχει γονικό placeholder σχήμα για εκείνο το σχήμα, τότε χρησιμοποιούνται προεπιλεγμένες τιμές όταν αξιολογείται το αποτελεσματικό πλαίσιο βάσει του IShape.getRawFrame(). Οι προεπιλεγμένες τιμές είναι 0 και NullableBool.False για x, y, width, height, flipH, flipV και rotationAngle. Για παράδειγμα:

``` java

 IShape shape = ...; // το σχήμα είναι συνδεδεμένο με placeholder

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// τώρα το σχήμα κληρονομεί τις τιμές x, y, height, flipH, flipV από το placeholder και αντικαθιστά το width=100 και το rotationAngle=0.

```
### **Αλλαγές Ιδιοτήτων**
#### **Αλλάχτηκε ο Τύπος και το Όνομα της μεθόδου Aspose.Slides.IShapeCollection.getParent()**
Ο τύπος της ιδιότητας Aspose.Slides.IShapeCollection.Parent άλλαξε από ISlideComponent σε νέο interface IGroupShape. Το interface IGroupShape είναι απόγονος του ISlideComponent, έτσι ο υπάρχων κώδικας δεν απαιτεί προσαρμογή.

Το όνομα της μεθόδου Aspose.Slides.IShapeCollection.getParent() άλλαξε από getParent σε getParentGroup().
#### **Αλλαγή του Τύπου των Μεθόδων Aspose.Slides.IShapeFrame.getFlipH() και .getFlipV()**
Ο τύπος της μεθόδου Aspose.Slides.IShapeFrame.getFlipH() άλλαξε από bool σε NullableBool.

Η μέθοδος IShape.getFrame() επιστρέφει το αποτελεσματικό αντικείμενο IShapeFrame (όλες οι ιδιότητές του έχουν ορισμένες αποτελεσματικές τιμές).

Η μέθοδος IShape.getRawFrame() επιστρέφει ένα αντικείμενο IShapeFrame του οποίου κάθε ιδιότητα μπορεί να έχει αόριστη τιμή (ιδιαίτερα το FlipH ή FlipV μπορεί να έχει την τιμή NullableBool.NotDefined).