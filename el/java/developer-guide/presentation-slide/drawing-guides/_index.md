---
title: Διαχείριση των γραμμών οδηγού σε παρουσιάσεις σε Java
linktitle: Γραμμές οδηγού
type: docs
weight: 85
url: /el/java/drawing-guides/
keywords:
- γραμμή οδηγού
- οριζόντια γραμμή
- κατακόρυφη γραμμή
- οδηγός ευθυγράμμισης
- προβολή διαφάνειας
- κύρια διαφάνεια
- διαφάνεια διάταξης
- κύρια σημειώσεων
- κύρια εκδότη
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Προσθήκη, πρόσβαση και εκκαθάριση οριζόντιων και κατακόρυφων γραμμών οδηγού σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Java."
---
## **Επισκόπηση**

Οι γραμμές οδηγού είναι ρυθμιζόμενες οριζόντιες και κατακόρυφες γραμμές που βοηθούν τους χρήστες να ευθυγραμμίζουν τα σχήματα σταθερά κατά την επεξεργασία μιας παρουσίασης στο PowerPoint. Είναι ιδιαίτερα χρήσιμες όταν μια εφαρμογή δημιουργεί μια παρουσίαση που θα βελτιωθεί αργότερα χειροκίνητα: η εφαρμογή μπορεί να αποθηκεύσει τα ίδια βοηθήματα ευθυγράμμισης που πρέπει να ακολουθούν οι συγγραφείς κατά την προσθήκη ή τη μετακίνηση του περιεχομένου.

Οι γραμμές οδηγού είναι βοηθήματα επεξεργασίας, όχι περιεχόμενο διαφάνειας. Δεν εμφανίζονται σε παρουσίαση ή σε αποδοθέν εξαγόμενο αρχείο. Aspose.Slides for Java τις εκθέτει μέσω της διεπαφής [IDrawingGuidesCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/idrawingguidescollection/) . Μια γραμμή οδηγού αντιπροσωπεύεται από το [IDrawingGuide](https://reference.aspose.com/slides/el/java/com.aspose.slides/idrawingguide/) και έχει προσανατολισμό, θέση και χρώμα.

Η θέση μετριέται σε πόντους από την επάνω‑αριστερή γωνία της σχετικής διαφάνειας ή του κύριου πρότυπου. Μία κατακόρυφη γραμμή οδηγού χρησιμοποιεί οριζόντιο συντεταγμένο, συνήθως μεταξύ του μηδενός και του πλάτους της διαφάνειας. Μία οριζόντια γραμμή οδηγού χρησιμοποιεί κατακόρυφο συντεταγμένο, συνήθως μεταξύ του μηδενός και του ύψους της διαφάνειας.

## **Προσθήκη οδηγών στην προβολή διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/el/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) για να διαχειριστείτε τις οδηγίες που εμφανίζονται κατά την επεξεργασία κανονικών διαφανειών. Καλέστε τη μέθοδο [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/el/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) με μια τιμή [Orientation](https://reference.aspose.com/slides/el/java/com.aspose.slides/orientation/) και μια θέση σε πόντους.

Το ακόλουθο παράδειγμα προσθέτει μία κατακόρυφη οδηγία στα δεξιά του κέντρου της διαφάνειας και μία οριζόντια οδηγία κάτω από αυτήν:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Πρόσβαση στις γραμμές οδηγού**

Οι μέθοδοι [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/el/java/com.aspose.slides/idrawingguidescollection/#getCount--) και [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/el/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) παρέχουν πρόσβαση στις υπάρχουσες οδηγίες. Οι μέθοδοι [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/el/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/el/java/com.aspose.slides/idrawingguide/#getPosition--), και [IDrawingGuide.getColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/idrawingguide/#getColor--) επιστρέφουν τιμές που μπορούν επίσης να αλλάξουν μέσω των αντίστοιχων μεθόδων οριστή.

Το ακόλουθο παράδειγμα διαβάζει τις οδηγίες της προβολής διαφάνειας από την παρουσίαση που δημιουργήθηκε παραπάνω:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Προσθήκη οδηγών σε κύρια διαφάνεια και διαφάνειες διάταξης**

Μια κύρια διαφάνεια και κάθε μία από τις διαφάνειες διάταξης της μπορούν να έχουν τις δικές τους συλλογές γραμμών οδηγού. Χρησιμοποιήστε τη μέθοδο [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/#getDrawingGuides--) για μια κύρια διαφάνεια και τη μέθοδο [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) για μια διαφάνεια διάταξης.

Το ακόλουθο παράδειγμα προσθέτει μία κατακόρυφη οδηγία στην πρώτη κύρια διαφάνεια και μία οριζόντια οδηγία στην πρώτη διαφάνεια διάταξης:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη οδηγών σε σημειώσεις και σε εκδότες χειρογράφων**

Οι κύριες διαφάνειες σημειώσεων και οι κύριες διαφάνειες εκδότη επίσης υποστηρίζουν γραμμές οδηγού. Χρησιμοποιήστε τις μεθόδους [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) και [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) για να αποκτήσετε τις συλλογές τους. Εάν μια παρουσίαση δεν περιέχει κάποιον από αυτούς τους κύριους τύπους, η μέθοδος [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) ή η μέθοδος [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) δημιουργεί τον προεπιλεγμένο κύριο τύπο και τον επιστρέφει.

Το ακόλουθο παράδειγμα προσθέτει μία οριζόντια οδηγία σε μια κύρια διαφάνεια σημειώσεων και μία κατακόρυφη οδηγία σε μια κύρια διαφάνεια εκδότη:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Καθαρισμός γραμμών οδηγού**

Καλέστε τη μέθοδο [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/idrawingguidescollection/#clear--) για να αφαιρέσετε κάθε οδηγία από μια συγκεκριμένη συλλογή. Η εκκαθάριση μιας συλλογής δεν επηρεάζει τις οδηγίες που αποθηκεύονται σε άλλη περιοχή.

Το ακόλουθο παράδειγμα καθαρίζει τις οδηγίες της προβολής διαφάνειας και όλες τις οδηγίες στις κύριες διαφάνειες, στις διαφάνειες διάταξης, στη κύρια διαφάνεια σημειώσεων και στη κύρια διαφάνεια εκδότη, χωρίς να δημιουργήσει ελλείπουσες κύριες διαφάνειες:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Εμφανίζονται οι γραμμές οδηγού σε παρουσίαση ή σε εξαγόμενες εικόνες;**

Όχι. Οι γραμμές οδηγού είναι βοηθήματα ευθυγράμμισης για την επεξεργασία και δεν αποδίδονται ως περιεχόμενο της παρουσίασης.

**Μπορεί να προστεθεί μια γραμμή οδηγού απευθείας σε μία μεμονωμένη κανονική διαφάνεια;**

Οι οδηγίες επεξεργασίας κανονικών διαφανειών αποθηκεύονται στις ιδιότητες προβολής διαφάνειας της παρουσίασης. Ξεχωριστές συλλογές οδηγών είναι διαθέσιμες για κύριες διαφάνειες, διαφάνειες διάταξης, κύριες διαφάνειες σημειώσεων και κύριες διαφάνειες εκδότη.

**Ποιοι μονάδες χρησιμοποιούνται για τις θέσεις των οδηγών;**

Οι θέσεις καθορίζονται σε πόντους, όπου 72 πόντοι ισούνται με ένα ίντς. Οι κατακόρυφες θέσεις μετρώνται από την αριστερή άκρη, ενώ οι οριζόντιες θέσεις μετρώνται από την επάνω άκρη.

**Αφαιρούνται σχήματα ή αλλάζει το περιεχόμενο της διαφάνειας όταν καθαρίζονται οι γραμμές οδηγού;**

Όχι. Η μέθοδος [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/idrawingguidescollection/#clear--) αφαιρεί μόνο τις οδηγίες στη συγκεκριμένη συλλογή. Τα σχήματα και το υπόλοιπο περιεχόμενο της διαφάνειας παραμένουν αμετάβλητα.