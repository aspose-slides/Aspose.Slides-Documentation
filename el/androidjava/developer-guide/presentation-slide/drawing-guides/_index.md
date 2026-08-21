---
title: Διαχείριση Οδηγών Σχεδίασης σε Παρουσιάσεις στο Android
linktitle: Οδηγίες Σχεδίασης
type: docs
weight: 85
url: /el/androidjava/drawing-guides/
keywords:
- οδηγός σχεδίασης
- οριζόντιος οδηγός
- κάθετος οδηγός
- οδηγός ευθυγράμμισης
- προβολή διαφάνειας
- κύρια διαφάνεια
- διαφάνεια διάταξης
- master σημειώσεων
- master εγχειριδίου
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσθήκη, πρόσβαση και διαγραφή οριζόντιων και κάθετων οδηγών σχεδίασης σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Οι οδηγίες σχεδίασης είναι ρυθμιζόμενες οριζόντιες και κάθετες γραμμές που βοηθούν τους χρήστες να ευθυγραμμίζουν τα σχήματα σταθερά κατά την επεξεργασία μιας παρουσίασης στο PowerPoint. Είναι ιδιαίτερα χρήσιμες όταν μια εφαρμογή δημιουργεί μια παρουσίαση που θα βελτιωθεί αργότερα χειροκίνητα: η εφαρμογή μπορεί να αποθηκεύσει τις ίδιες βοηθητικές ευθυγραμμίσεις που πρέπει να ακολουθούν οι συγγραφείς όταν προσθέτουν ή μετακινούν περιεχόμενο.

Οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας, όχι περιεχόμενο διαφάνειας. Δεν εμφανίζονται σε παρουσίαση ή στην παραγόμενη έξοδο. Το Aspose.Slides for Android μέσω Java τις εκθέτει μέσω της διεπαφής [IDrawingGuidesCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idrawingguidescollection/) . Μια οδηγία αντιπροσωπεύεται από το [IDrawingGuide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idrawingguide/) και διαθέτει προσανατολισμό, θέση και χρώμα.

Η θέση μετριέται σε πόντους από την πάνω αριστερή γωνία της σχετικής διαφάνειας ή του master. Μία κάθετη οδηγία χρησιμοποιεί μια οριζόντια συντεταγμένη, συνήθως μεταξύ μηδενός και του πλάτους της διαφάνειας. Μία οριζόντια οδηγία χρησιμοποιεί μια κατακόρυφη συντεταγμένη, συνήθως μεταξύ μηδενός και του ύψους της διαφάνειας.

## **Προσθήκη Οδηγών στην Προβολή Διαφάνειας**

Χρησιμοποιήστε το [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) για να διαχειρίζεστε τις οδηγίες που εμφανίζονται κατά την επεξεργασία κανονικών διαφανειών. Κλήστε το [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) με μια τιμή [Orientation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/orientation/) και μια θέση σε πόντους.

Το παρακάτω παράδειγμα προσθέτει μία κάθετη οδηγία δεξιά από το κέντρο της διαφάνειας και μία οριζόντια οδηγία κάτω από αυτήν:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Πρόσβαση στις Οδηγίες Σχεδίασης**

Οι μέθοδοι [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) και [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) παρέχουν πρόσβαση σε υπάρχουσες οδηγίες. Οι μέθοδοι [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idrawingguide/#getPosition--), και [IDrawingGuide.getColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idrawingguide/#getColor--) επιστρέφουν τιμές που μπορούν επίσης να αλλάξουν μέσω των αντίστοιχων μεθόδων setter.

Το παρακάτω παράδειγμα διαβάζει τις οδηγίες προβολής διαφάνειας από την παρουσίαση που δημιουργήθηκε παραπάνω:

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

## **Προσθήκη Οδηγών σε Master και Διαφάνειες Διάταξης**

Ένα master διαφάνειας και καθεμία από τις διαφάνειες διάταξης του μπορούν να έχουν τις δικές τους συλλογές οδηγών σχεδίασης. Χρησιμοποιήστε το [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) για μια master διαφάνειας και το [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) για μια διαφάνεια διάταξης.

Το παρακάτω παράδειγμα προσθέτει μία κάθετη οδηγία στην πρώτη master διαφάνειας και μία οριζόντια οδηγία στην πρώτη διαφάνεια διάταξης:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Οδηγών σε Master Σημειώσεων και Εγχειριδίων**

Τα master σημειώσεων και τα master εγχειριδίων επίσης υποστηρίζουν οδηγίες σχεδίασης. Χρησιμοποιήστε τα [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) και [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) για να αποκτήσετε πρόσβαση στις συλλογές τους. Εάν μια παρουσίαση δεν περιέχει κάποιο από αυτά τα master, το [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) ή το [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) δημιουργεί το προεπιλεγμένο master και το επιστρέφει.

Το παρακάτω παράδειγμα προσθέτει μία οριζόντια οδηγία σε ένα master σημειώσεων και μία κάθετη οδηγία σε ένα master εγχειριδίων:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Καθαρισμός Οδηγών Σχεδίασης**

Καλέστε το [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) για να αφαιρέσετε κάθε οδηγία από μια συγκεκριμένη συλλογή. Ο καθαρισμός μιας συλλογής δεν επηρεάζει τις οδηγίες που αποθηκεύονται σε άλλη περιοχή.

Το παρακάτω παράδειγμα καθαρίζει τις οδηγίες προβολής διαφάνειας και όλες τις οδηγίες στα master διαφάνειας, τις διαφάνειες διάταξης, το master σημειώσεων και το master εγχειριδίων χωρίς να δημιουργήσει τα χαμένα master:

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

## **Συχνές Ερωτήσεις**

**Εμφανίζονται οι οδηγίες σχεδίασης σε παρουσίαση ή εξαγόμενες εικόνες;**

Όχι. Οι οδηγίες σχεδίασης είναι βοηθήματα ευθυγράμμισης για την επεξεργασία και δεν αποδίδονται ως περιεχόμενο παρουσίασης.

**Μπορεί μια οδηγία σχεδίασης να προστεθεί απευθείας σε μια μεμονωμένη κανονική διαφάνεια;**

Οι οδηγίες επεξεργασίας κανονικής διαφάνειας αποθηκεύονται στις ιδιότητες προβολής διαφάνειας της παρουσίασης. Ξεχωριστές συλλογές οδηγών είναι διαθέσιμες για τα master διαφάνειας, τις διαφάνειες διάταξης, τα master σημειώσεων και τα master εγχειριδίων.

**Ποια μονάδες χρησιμοποιούνται για τις θέσεις των οδηγών;**

Οι θέσεις καθορίζονται σε πόντους, όπου 72 πόντοι ισοδυναμούν με ένα ίντσα. Οι κατακόρυφες θέσεις μετρώνται από την αριστερή άκρη, ενώ οι οριζόντιες θέσεις μετρώνται από την πάνω άκρη.

**Ο καθαρισμός των οδηγών σχεδίασης αφαιρεί σχήματα ή αλλάζει το περιεχόμενο της διαφάνειας;**

Όχι. Η μέθοδος [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) αφαιρεί μόνο τις οδηγίες στην επιλεγμένη συλλογή. Τα σχήματα και το άλλο περιεχόμενο της διαφάνειας παραμένουν αμετάβλητα.