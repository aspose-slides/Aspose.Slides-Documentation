---
title: Δημιουργία Παρουσιάσεων σε Java
linktitle: Δημιουργία Παρουσίασης
type: docs
weight: 10
url: /el/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Δημιουργήστε παρουσιάσεις σε Java με Aspose.Slides—παράγουμε αρχεία PPT, PPTX και ODP, επωφεληθείτε από την υποστήριξη OpenDocument και αποθηκεύστε τα προγραμματιστικά για αξιόπιστα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια παρουσίαση στο Aspose.Slides, να προσθέσετε ένα σχήμα με κείμενο στην πρώτη διαφάνειά της και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX. Για να ανοίξετε μια υπάρχουσα παρουσίαση και να την αποθηκεύσετε σε άλλη μορφή, δείτε [Open Presentations](/slides/el/java/open-presentation/) και [Save Presentations](/slides/el/java/save-presentation/). Μία σύντομη ενότητα FAQ στο τέλος καλύπτει συνήθεις ερωτήσεις σχετικά με μορφές, πρότυπα, μέγεθος διαφάνειας, μονάδες, χρήση μνήμης, πολυνηματισμό, αδειοδότηση, ψηφιακές υπογραφές και υποστήριξη VBA.

Πριν ξεκινήσετε, προσθέστε το Aspose.Slides for Java στο έργο σας από το αποθετήριο Maven της Aspose. Δείτε το [Installation](/slides/el/java/installation/) για τη ρύθμιση του Maven και για το τι χρειάζεται επιπλέον το Linux.

## **Δημιουργία Παρουσίασης**

Η δημιουργία ενός αρχείου PowerPoint από το μηδέν στο Aspose.Slides for Java ξεκινά με μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Ο κατασκευαστής παρέχει μια κενή παρουσίαση με μία διαφάνεια, έτοιμη για σχήματα, κείμενο, γραφήματα ή οποιοδήποτε άλλο περιεχόμενο χρειάζεται η εφαρμογή σας. Μόλις τροποποιήσετε αυτή τη διαφάνεια ή προσθέσετε νέες, μπορείτε να αποθηκεύσετε το αποτέλεσμα σε μορφές PPTX, παλιά PPT ή OpenDocument.

Για να δημιουργήσετε μια παρουσίαση και να τοποθετήσετε ένα σχήμα με κείμενο στην πρώτη της διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Μια νέα παρουσίαση περιέχει ήδη μία κενή διαφάνεια.  
2. Αποκτήστε αυτή τη διαφάνεια με το ευρετήριο της, 0, από τη συλλογή που επιστρέφει η μέθοδος [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--).  
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) του τύπου `Cloud` με τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-), και ορίστε το κείμενό του με τη μέθοδο [setText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX με τη μέθοδο [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

Το παρακάτω παράδειγμα είναι ένα πλήρες πρόγραμμα. Στο έργο Maven από το [Installation](/slides/el/java/installation/), αποθηκεύστε το ως *src/main/java/HelloSlides.java* και εκτελέστε `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Δημιουργήστε μια παρουσίαση. Περιέχει ήδη μία κενή διαφάνεια.
        Presentation presentation = new Presentation();
        try {
            // Αποκτήστε την πρώτη διαφάνεια.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Προσθέστε ένα σχήμα σύννεφο και τοποθετήστε κείμενο σε αυτό.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Η πάνω αριστερή γωνία του σύννεφου βρίσκεται 20 σημεία από την αριστερή άκρη και 20 σημεία από την πάνω άκρη της διαφάνειας, ενώ το σχήμα είναι 200 σημεία πλάτος και 80 σημεία ύψος. Το πρόγραμμα αποθηκεύει *new_presentation.pptx* με μία διαφάνεια που περιλαμβάνει το σύννεφο και το κείμενό του. Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε [Licensing](/slides/el/java/licensing/).

Το αποτέλεσμα:

![Η νέα παρουσίαση](new_presentation.png)

## **Συχνές Ερωτήσεις**

### Ποιες μορφές μπορώ να αποθηκεύσω μια νέα παρουσίαση;

Μπορείτε να αποθηκεύσετε σε [PPTX, PPT, and ODP](/slides/el/java/save-presentation/), και να εξάγετε σε [PDF](/slides/el/java/convert-powerpoint-to-pdf/), [XPS](/slides/el/java/convert-powerpoint-to-xps/), [HTML](/slides/el/java/convert-powerpoint-to-html/), [SVG](/slides/el/java/render-a-slide-as-an-svg-image/), και [images](/slides/el/java/convert-powerpoint-to-png/), μεταξύ άλλων.

### Μπορώ να ξεκινήσω από ένα πρότυπο (POTX/POTM) και να το αποθηκεύσω ως κανονικό PPTX;

Ναι. Φορτώστε το πρότυπο και αποθηκεύστε το στην επιθυμητή μορφή· τα POTX/POTM/PPTM και παρόμοιες μορφές [are supported](/slides/el/java/supported-file-formats/).

### Πώς ελέγχω το μέγεθος/αναλογία διαφάνειας κατά τη δημιουργία παρουσίασης;

Ορίστε το [slide size](/slides/el/java/slide-size/) (συμπεριλαμβανομένων προεπιλογών όπως 4:3 και 16:9 ή προσαρμοσμένων διαστάσεων) και επιλέξτε πώς θα κλιμακωθεί το περιεχόμενο.

### Σε ποιες μονάδες μετρώνται τα μεγέθη και οι συντεταγμένες;

Σε σημεία: 1 ίντσα ισούται με 72 μονάδες.

### Πώς διαχειρίζομαι πολύ μεγάλες παρουσιάσεις (με πολλά αρχεία πολυμέσων) ώστε να μειώσω τη χρήση μνήμης;

Χρησιμοποιήστε [BLOB management strategies](/slides/el/java/manage-blob/), περιορίστε την αποθήκευση στη μνήμη αξιοποιώντας προσωρινά αρχεία και προτιμήστε ροές επεξεργασίας αρχείων αντί για καθαρά ρεύματα μνήμης.

### Μπορώ να δημιουργήσω/αποθηκεύσω παρουσιάσεις παράλληλα;

Δεν μπορείτε να λειτουργήσετε στην ίδια παρουσίαση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) από [multiple threads](/slides/el/java/multithreading/). Εκτελέστε ξεχωριστές, απομονωμένες παρουσιαστικές επιπλοκές ανά νήμα ή διεργασία.

### Πώς αφαιρώ το υδατογράφημα αξιολόγησης και τους περιορισμούς;

[Apply a license](/slides/el/java/licensing/) μία φορά ανά διεργασία. Το XML της άδειας πρέπει να παραμείνει αμετάβλητο, και η ρύθμιση της άδειας πρέπει να συγχρονίζεται εάν εμπλέκονται πολλά νήματα.

### Μπορώ να υπογράψω ψηφιακά το PPTX που δημιουργώ;

Ναι. Οι [digital signatures](/slides/el/java/digital-signature-in-powerpoint/) (προσθήκη και επαλήθευση) υποστηρίζονται για παρουσιάσεις.

### Υποστηρίζονται μακροεντολές (VBA) σε δημιουργημένες παρουσιάσεις;

Ναι. Μπορείτε να [create/edit VBA projects](/slides/el/java/presentation-via-vba/) και να αποθηκεύσετε αρχεία με ενεργοποιημένες μακροεντολές όπως PPTM/PPSM.