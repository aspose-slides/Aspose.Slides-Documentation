---
title: Διαχείριση SmartArt σε Παρουσιάσεις PowerPoint με χρήση Java
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/java/manage-smartart/
keywords:
- SmartArt
- SmartArt κείμενο
- τύπος διάταξης
- ιδιότητα κρυφού
- οργανωτικό διάγραμμα
- διάγραμμα οργανωτικού με εικόνα
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε να δημιουργείτε και να επεξεργάζεστε SmartArt του PowerPoint με το Aspose.Slides για Java, χρησιμοποιώντας σαφή παραδείγματα κώδικα που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση των διαφανειών."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που αποτελείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides for Java, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να ελέγξετε κρυμμένους κόμβους, να διαμορφώσετε διατάξεις διαγράμματος οργανωτικού δομικού και να δημιουργήσετε διαγράμματα οργανωτικού τύπου εικόνας.

## **Λήψη Κειμένου από Ένα Αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το ορατό κείμενο, επαναλάβετε μέσω του [ISmartArt.getAllNodes](https://reference.aspose.com/slides/el/java/com.aspose.slides/ismartart/#getAllNodes--), έπειτα διαβάστε το [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) που επιστρέφεται από το [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Αλλαγή Τύπου Διάταξης ενός Αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς διατάσσονται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, την αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Αν Ένας Κόμβος SmartArt Είναι Κρυμμένος**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/el/java/com.aspose.slides/ismartartnode/#isHidden--) υποδεικνύει αν ο κόμβος είναι κρυμμένος στο μοντέλο δεδομένων SmartArt. Οι κρυμμένοι κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle` και ελέγχει την κατάσταση κρυψίματος του κόμβου.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη ή Ορισμός της Διάταξης Οργανωτικού Διαγράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανωτικού διαγράμματος, τα [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) και [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) καθορίζουν πώς διατάσσονται οι θυγατρικοί κόμβοι κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ορίσετε τους θυγατρικούς κόμβους να κρεμιούνται από αριστερά, δεξιά ή και από τις δύο πλευρές, ανάλογα με την επιλεγμένη [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/java/com.aspose.slides/OrganizationChartLayoutType).

Το παρακάτω παράδειγμα δημιουργεί ένα οργανωτικό διάγραμμα και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Δημιουργία Διαγράμματος Οργανωτικού με Εικόνα**

Ένα διάγραμμα οργανωτικού τύπου εικόνας είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν δείκτες εικόνων. Χρησιμοποιήστε την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το SmartArt καθρεπτισμό ή αντιστροφή για γλώσσες RTL;**

Ναι. Η μέθοδος [ISmartArt.setReversed](https://reference.aspose.com/slides/el/java/com.aspose.slides/ismartart/#setReversed-boolean-) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή το αντίστροφο, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/java/shape-manipulations/) με [ShapeCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/java/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς αποδίδω το SmartArt σε ράστερ εικόνα για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/java/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια αν υπάρχουν πολλά;**

Ορίστε μια χαρακτηριστική τιμή στο [Shape.getAlternativeText](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getAlternativeText--) ή στο [Shape.getName](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getName--) του σχήματος SmartArt, αναζητήστε αυτήν την τιμή στο [BaseSlide.getShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslide/#getShapes--) και, στη συνέχεια, ελέγξτε ότι το ταιριαστό σχήμα είναι ένα [ISmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ismartart/).