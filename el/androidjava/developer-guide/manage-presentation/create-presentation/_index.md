---
title: Δημιουργία Παρουσιάσεων σε Android
linktitle: Δημιουργία Παρουσίασης
type: docs
weight: 10
url: /el/androidjava/create-presentation/
keywords:
- δημιουργία παρουσίασης
- νέα παρουσίαση
- δημιουργία PPT
- νέο PPT
- δημιουργία PPTX
- νέο PPTX
- δημιουργία ODP
- νέο ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε παρουσιάσεις σε Java με Aspose.Slides για Android—παράγετε αρχεία PPT, PPTX και ODP, επωφεληθείτε από την υποστήριξη OpenDocument και αποθηκεύστε τα προγραμματιστικά για αξιόπιστα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια παρουσίαση στο Aspose.Slides για Android μέσω Java, να προσθέσετε ένα πλαίσιο κειμένου στην πρώτη της διαφάνεια και να αποθηκεύσετε το αποτέλεσμα ως αρχείο στην αποθήκευση της εφαρμογής σας. Για άνοιγμα υπάρχουσας παρουσίασης ή αποθήκευση σε άλλη μορφή, δείτε [Άνοιγμα Παρουσίασης](/slides/el/androidjava/open-presentation/) και [Αποθήκευση Παρουσίασης](/slides/el/androidjava/save-presentation/). Ένα σύντομο FAQ στο τέλος καλύπτει κοινές ερωτήσεις σχετικά με μορφές, πρότυπα, μέγεθος διαφάνειας, μονάδες, χρήση μνήμης, πολυνηματισμό, αδειοδότηση, ψηφιακές υπογραφές και υποστήριξη VBA.

Πριν αρχίσετε, προσθέστε το Aspose.Slides στο Android project σας από το Maven αποθετήριο της Aspose. Δείτε [Εγκατάσταση](/slides/el/androidjava/install-aspose-slides-for-android-via-java/).

## **Δημιουργία Παρουσίασης PowerPoint**

Για να δημιουργήσετε μια παρουσίαση και να τοποθετήσετε ένα πλαίσιο κειμένου στην πρώτη της διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Μια νέα παρουσία ήδη περιέχει μία κενή διαφάνεια.  
2. Αποκτήστε αυτή τη διαφάνεια από τη [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) με το ευρετήριο 0.  
3. Προσθέστε ένα ορθογώνιο σχήμα με τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) της [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) και ορίστε το κείμενο του [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) με τη μέθοδο [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX με τη μέθοδο [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) με μορφή [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/).

Ο κώδικας εκτελείται μέσα σε μια `Activity`, π.χ. στη μέθοδο `onCreate`. Αποθηκεύει το αρχείο στον κατάλογο που επιστρέφει η μέθοδος [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()), δηλαδή στην ιδιωτική αποθήκευση της εφαρμογής σας, στην οποία μπορεί να γράψει χωρίς να ζητήσει άδεια.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η επάνω αριστερή γωνία του ορθογωνίου βρίσκεται 50 points από το αριστερό άκρο και 50 points από το πάνω άκρο της διαφάνειας, και το ορθογώνιο έχει πλάτος 400 points και ύψος 100 points. Το αποθηκευμένο αρχείο περιέχει μία διαφάνεια με αυτό το ορθογώνιο και το κείμενό του. Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε [Αδειοδότηση](/slides/el/androidjava/licensing/).

Για να δείτε το αρχείο, ανοίξτε το [Device Explorer] του Android Studio και βρείτε το *hello.pptx* στο *data/data/*, στον φάκελο *files* της εφαρμογής σας. Σε πραγματική εφαρμογή, επεξεργαστείτε τις παρουσιάσεις σε παρασκήνιο ώστε η διεπαφή χρήστη να παραμένει ανταποκριτική.

## **Συχνές Ερωτήσεις**

### Σε ποιες μορφές μπορώ να αποθηκεύσω μια νέα παρουσίαση;

Μπορείτε να αποθηκεύσετε σε [PPTX, PPT και ODP](/slides/el/androidjava/save-presentation/), και να εξάγετε σε [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/el/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/el/androidjava/convert-powerpoint-to-html/), [SVG](/slides/el/androidjava/render-a-slide-as-an-svg-image/) και [εικόνες](/slides/el/androidjava/convert-powerpoint-to-png/), μεταξύ άλλων.

### Μπορώ να ξεκινήσω από ένα πρότυπο (POTX/POTM) και να το αποθηκεύσω ως κανονικό PPTX;

Ναι. Φορτώστε το πρότυπο και αποθηκεύστε στο επιθυμητό format· τα POTX/POTM/PPTM και παρόμοια μορφές [υποστηρίζονται](/slides/el/androidjava/supported-file-formats/).

### Πώς ελέγχω το μέγεθος/αναλογία διαφάνειας όταν δημιουργώ μια παρουσίαση;

Ορίστε το [slide size](/slides/el/androidjava/slide-size/) (συμπεριλαμβανομένων προεπιλογών όπως 4:3 και 16:9 ή προσαρμοσμένων διαστάσεων) και επιλέξτε πώς θα κλιμακωθεί το περιεχόμενο.

### Σε ποιες μονάδες μετρώνται τα μεγέθη και οι συντεταγμένες;

Σε points: 1 ίντσα ισούται με 72 μονάδες.

### Πώς να χειριστώ πολύ μεγάλες παρουσιάσεις (με πολλά αρχεία πολυμέσων) για μείωση χρήσης μνήμης;

Χρησιμοποιήστε [BLOB management strategies](/slides/el/androidjava/manage-blob/), περιορίστε την αποθήκευση στη μνήμη χρησιμοποιώντας προσωρινά αρχεία, και προτιμήστε ροές εργασίας βασισμένες σε αρχεία αντί για καθαρά in‑memory streams.

### Μπορώ να δημιουργήσω/αποθηκεύσω παρουσιάσεις παράλληλα;

Δεν μπορείτε να εργαστείτε πάνω στην ίδια [Presentation] από [multiple threads](/slides/el/androidjava/multithreading/). Εκτελέστε ξεχωριστές, απομονωμένες παρουσιαστικές στιγμιότυπα ανά νήμα ή διεργασία.

### Πώς αφαιρώ το υδατογράφημα δοκιμής και τους περιορισμούς;

[Apply a license](/slides/el/androidjava/licensing/) μία φορά ανά διεργασία. Το XML της άδειας πρέπει να παραμείνει αμετάβλητο και η ρύθμιση της άδειας πρέπει να συγχρονίζεται αν εμπλέκονται πολλά νήματα.

### Μπορώ να ψηφιακά υπογράψω το PPTX που δημιουργώ;

Ναι. Οι [Digital signatures](/slides/el/androidjava/digital-signature-in-powerpoint/) (προσθήκη και επαλήθευση) υποστηρίζονται για παρουσιάσεις.

### Υποστηρίζονται μακροεντολές (VBA) σε δημιουργημένες παρουσιάσεις;

Ναι. Μπορείτε να [create/edit VBA projects](/slides/el/androidjava/presentation-via-vba/) και να αποθηκεύσετε αρχεία ενεργοποιημένων μακροεντολών όπως PPTM/PPSM.