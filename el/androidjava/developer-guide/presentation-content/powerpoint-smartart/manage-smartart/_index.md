---
title: Διαχείριση SmartArt σε παρουσιάσεις PowerPoint σε Android
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/androidjava/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- Τύπος διάταξης
- Κρυφή ιδιότητα
- Οργανωτικό διάγραμμα
- Διάγραμμα οργανωτικής εικόνας
- PowerPoint
- Παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε να δημιουργείτε και να επεξεργάζεστε SmartArt PowerPoint με Aspose.Slides για Android χρησιμοποιώντας σαφή παραδείγματα κώδικα Java που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση των διαφανειών."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που δημιουργείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides για Android μέσω Java, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να εξετάσετε κρυφούς κόμβους, να διαμορφώσετε διατάξεις οργανωτικών διαγραμμάτων και να δημιουργήσετε διαγράμματα οργανωτικής εικόνας.

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

## **Λήψη κειμένου από αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το ορατό κείμενο, επαναλάβετε μέσω του [ISmartArt.getAllNodes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ismartart/#getAllNodes--), στη συνέχεια διαβάστε το [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) που επιστρέφεται από το [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

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

## **Αλλαγή τύπου διάταξης ενός αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς τακτοποιούνται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή `BasicBlockList` του [SmartArtLayoutType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtLayoutType), το αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση.

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

## **Έλεγχος εάν ένας κόμβος SmartArt είναι κρυφός**

Το [ISmartArtNode.isHidden](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ismartartnode/#isHidden--) υποδεικνύει αν ο κόμβος είναι κρυφός στο μοντέλο δεδομένων SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρξουν στη δομή ακόμα και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή `RadialCycle` του [SmartArtLayoutType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtLayoutType), και ελέγχει την κρυφή κατάσταση του κόμβου.

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

## **Λήψη ή ορισμός διάταξης οργανωτικού διαγράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανωτικού διαγράμματος, τα [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) και [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) ορίζουν πώς τα παιδικά κόμβοι τοποθετούνται κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ορίσετε τα παιδικά κόμβοι να κρέμονται από αριστερά, δεξιά ή και από τις δύο πλευρές, ανάλογα με την επιλεγμένη [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/OrganizationChartLayoutType).

Το παρακάτω παράδειγμα δημιουργεί ένα οργανωτικό διάγραμμα και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή `LeftHanging` του [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/OrganizationChartLayoutType).

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

## **Δημιουργία διαγράμματος οργανωτικής εικόνας**

Ένα διάγραμμα οργανωτικής εικόνας είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν δεσμευμένα σημεία εικόνας. Χρησιμοποιήστε την τιμή `PictureOrganizationChart` του [SmartArtLayoutType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtLayoutType) όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια.

{{0213d7ab-0c5f-4a2a-9a2c-6e8b9f2a5c22}}

## **FAQ**

**Υποστηρίζει το SmartArt κατοπτρισμό ή αντιστροφή για γλώσσες RTL;**

Ναι. Η μέθοδος [ISmartArt.setReversed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/androidjava/shape-manipulations/) με τη [ShapeCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/androidjava/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς αποδίδω το SmartArt σε ραστερ εικόνα για προεπισκόπηση ή εξαγωγή στο διαδίκτυο;**

[Αποδώστε τη διαφάνεια](/slides/el/androidjava/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια εάν υπάρχουν πολλά;**

Ορίστε μία διακριτική τιμή στο [Shape.getAlternativeText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getAlternativeText--) ή στο [Shape.getName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getName--) του σχήματος SmartArt, αναζητήστε αυτήν την τιμή στο [BaseSlide.getShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslide/#getShapes--) και στη συνέχεια ελέγξτε ότι το αντιστοιχούν shape είναι ένα [ISmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ismartart/).