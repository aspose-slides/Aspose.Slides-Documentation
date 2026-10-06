---
title: "Διαχείριση SmartArt σε παρουσιάσεις PowerPoint σε Android"
linktitle: "Διαχείριση SmartArt"
type: docs
weight: 10
url: /el/androidjava/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- Τύπος διάταξης
- Κρυφή ιδιότητα
- Διάγραμμα οργάνωσης
- Διάγραμμα οργανωτικής εικόνας
- PowerPoint
- Παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να επεξεργάζεστε SmartArt του PowerPoint με το Aspose.Slides για Android χρησιμοποιώντας σαφή παραδείγματα κώδικα Java που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση των διαφανειών."
---
## **Επισκόπηση**

SmartArt είναι ένα διάγραμμα PowerPoint που δημιουργείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides για Android μέσω Java, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να ελέγξετε κρυμμένους κόμβους, να διαμορφώσετε διατάξεις οργανωτικών διαγραμμάτων και να δημιουργήσετε εικόνες οργανωτικών διαγραμμάτων.

## **Λήψη κειμένου από αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το κείμενο από τα σχήματα του κόμβου, επαναλάβετε μέσω του [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), μετά διαβάστε το [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) που επιστρέφεται από το [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

Το παράδειγμα απαιτεί μια παρουσίαση με τουλάχιστον μία διαφάνεια και ένα αντικείμενο SmartArt ως το πρώτο σχήμα σε αυτή τη διαφάνεια. Εκτυπώνει κάθε διαθέσιμο πλαίσιο κειμένου στην κονσόλα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Αλλαγή τύπου διάταξης αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς διατάσσονται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή `BasicBlockList` του [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) , το αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση. Η θέση και το μέγεθος που περνούν στο [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) μετρώνται σε πόντους. Χρησιμοποιήστε το [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) για να αλλάξετε τη διάταξη.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος αν ένας κόμβος SmartArt είναι κρυμμένος**

Το [ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) υποδεικνύει αν ο κόμβος είναι κρυμμένος στο μοντέλο δεδομένων SmartArt. Οι κρυμμένοι κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή `RadialCycle` του [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) , και ελέγχει την κρυφή κατάσταση του προσαρτηθέντος κόμβου. Εκτυπώνει ένα μήνυμα αν ο κόμβος είναι κρυμμένος και αποθηκεύει το διάγραμμα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη ή ορισμός της διάταξης οργανωτικού διαγράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανωτικού διαγράμματος, τα [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) και [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) ορίζουν πώς διατάσσονται οι θυγατρικοί κόμβοι κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ρυθμίσετε τους θυγατρικούς κόμβους να κρεμιούνται από αριστερά, δεξιά ή και από τις δύο πλευρές, ανάλογα με το επιλεγμένο [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα οργανωτικό διάγραμμα και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή `LeftHanging` του [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/). Ο μηδενικός δείκτης `0` επιλέγει τον πρώτο κορυφαίο κόμβο· οι θυγατρικοί του κόμβοι χρησιμοποιούν τη επιλεγμένη διάταξη. Η τροποποιημένη παρουσίαση αποθηκεύεται στη συνέχεια.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Δημιουργία εικόνας οργανωτικού διαγράμματος**

Ένα εικόνα οργανωτικού διαγράμματος είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιέχουν δεσμευτικά θέσεων εικόνας. Χρησιμοποιήστε την τιμή `PictureOrganizationChart` του [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια. Αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα με δεσμευτικά θέσεων εικόνας· δεν γεμίζει τα δεσμευτικά θέσεων με εικόνες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή παλαιών διαγραμμάτων σε ομάδες σχημάτων**

Κατά τη σύγχρονη αναβάθμιση μιας υπάρχουσας παρουσίασης, ίσως χρειαστεί να ενημερώσετε ένα οργανωτικό διάγραμμα που δημιουργήθηκε αρχικά στο PowerPoint 97–2003. Το Aspose.Slides αντιπροσωπεύει αυτά τα παλαιά διαγράμματα ως αντικείμενα [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/) . Χρησιμοποιήστε το [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) για να μετατρέψετε ένα διάγραμμα σε ομάδα σχημάτων ώστε να μπορείτε να επεξεργαστείτε μεμονωμένα οπτικά στοιχεία. Δείτε την [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) για λεπτομέρειες.

Η μετατροπή προσθέτει μια νέα ομάδα στη συλλογή σχημάτων χωρίς να αφαιρεί το αρχικό διάγραμμα. Μετά από επιτυχή μετατροπή, αφαιρέστε το αρχικό με το [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) για να αποφύγετε διπλό περιεχόμενο. Συλλέξτε τα παλαιά διαγράμματα σε λίστα πριν τα μετατρέψετε, ώστε η προσθήκη και αφαίρεση σχημάτων να μην διακόπτει την επανάληψη.

Το παρακάτω παράδειγμα ανοίγει μια παρουσίαση, ψάχνει σε κάθε διαφάνεια, μετατρέπει τα διαγράμματα σε ομάδες σχημάτων και αποθηκεύει την ενημερωμένη παρουσίαση ως PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αποθηκευμένη παρουσίαση περιλαμβάνει επεξεργάσιμες ομάδες σχημάτων στη θέση των μετατρεπόμενων παλαιών διαγραμμάτων, χωρίς να παραμείνουν τα αρχικά διαγράμματα. Ανοίξτε το PPTX στο PowerPoint για να επεξεργαστείτε μεμονωμένα στοιχεία μέσα σε κάθε ομάδα, όπως το κείμενο, το γέμισμα ή τη θέση τους.

## **FAQ**

**Υποστηρίζει το SmartArt την κατοπτριζόμενη ή αντιστροφή για γλώσσες RTL;**

Ναι. Η μέθοδος [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά-προς-δεξιά σε δεξιά-προς-αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/androidjava/shape-manipulations/) με το [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/androidjava/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς κάνω απόδοση του SmartArt σε ραστερ εικόνας για προεπισκόπηση ή εξαγωμή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/androidjava/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια αν υπάρχουν πολλά;**

Χρησιμοποιήστε το [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) ή το [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) για να προσδώσετε ένα διακριτικό εναλλακτικό κείμενο ή όνομα στο σχήμα SmartArt, αναζητήστε αυτήν την τιμή στο [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) και στη συνέχεια ελέγξτε ότι το αντιστοιχούν σχήμα είναι ένα [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).