---
title: Μεγέθυνση Σχημάτων σε Διαφάνειες Παρουσίασης
type: docs
weight: 110
url: /el/java/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- αλλαγή μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Απλή αλλαγή μεγέθους σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides for Java—αυτόματη προσαρμογή διάταξης διαφανειών και αύξηση παραγωγικότητας."
---
## **Επισκόπηση**

Μία από τις πιο συχνές ερωτήσεις των πελατών του Aspose.Slides για Java είναι πώς να αλλάξουν το μέγεθος των σχημάτων ώστε, όταν αλλάζει το μέγεθος της διαφάνειας, τα δεδομένα να μην περικοπούν. Αυτό το σύντομο τεχνικό άρθρο δείχνει πώς να το κάνετε.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να αποτρέψετε τα σχήματα από το να μετατοπίζονται όταν αλλάζει το μέγεθος της διαφάνειας, ενημερώστε τη θέση και τις διαστάσεις κάθε σχήματος ώστε να συμμορφώνονται με τη νέα διάταξη της διαφάνειας.

```java
import com.aspose.slides.*;

// Φόρτωση του αρχείου παρουσίασης.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Λήψη του αρχικού μεγέθους της διαφάνειας.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Αλλαγή του μεγέθους της διαφάνειας χωρίς κλιμάκωση των υφιστάμενων σχημάτων.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Λήψη του νέου μεγέθους της διαφάνειας.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Αλλαγή μεγέθους και επανατοποθέτηση των σχημάτων σε κάθε διαφάνεια.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Κλιμάκωση του μεγέθους του σχήματος.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Κλιμάκωση της θέσης του σχήματος.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 
Οι πίνακες δεν απαιτούν ειδική μεταχείριση: ο καθορισμός του πλάτους και του ύψους ενός πίνακα επανακλιμακώνει τις στήλες και τις γραμμές του αναλογικά, επομένως η επαναπροσαρμογή του ύψους των γραμμών και του πλάτους των στηλών ξανά θα εφαρμοστεί ο λόγος δύο φορές.
{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Λήψη του αρχικού μεγέθους της διαφάνειας.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Αλλαγή του μεγέθους της διαφάνειας χωρίς κλιμάκωση των υφιστάμενων σχημάτων.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Λήψη του νέου μεγέθους της διαφάνειας.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Κλιμάκωση του μεγέθους του σχήματος.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Κλιμάκωση της θέσης του σχήματος.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Κλιμάκωση του μεγέθους του σχήματος.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Κλιμάκωση της θέσης του σχήματος.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Κλιμάκωση του μεγέθους του σχήματος.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Κλιμάκωση της θέσης του σχήματος.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

### Γιατί τα σχήματα παραμορφώνονται ή περικόπτονται μετά την αλλαγή μεγέθους μιας διαφάνειας;

Όταν αλλάζετε το μέγεθος μιας διαφάνειας, τα σχήματα διατηρούν την αρχική τους θέση και μέγεθος εκτός εάν η κλίμακα αλλάξει ρητά. Αυτό μπορεί να οδηγήσει σε περικοπή του περιεχομένου ή σε μετατόπιση των σχημάτων.

### Λειτουργεί ο κώδικας που παρέχεται για όλους τους τύπους σχημάτων;

Ναι. Ο ορισμός του ύψους και του πλάτους λειτουργεί για πλαίσια κειμένου, εικόνες, διαγράμματα και πίνακες εξίσου.

### Πώς μπορώ να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;

Κλιμακώστε το ίδιο το σχήμα του πίνακα, ακριβώς όπως οποιοδήποτε άλλο σχήμα. Οι γραμμές και οι στήλες του ακολουθούν αναλογικά, επομένως μην τις κλιμακώσετε ξανά αργότερα.

### Θα λειτουργήσει αυτή η αλλαγή μεγέθους για τις κύριες διαφάνειες και τις διαφάνειες διάταξης;

Ναι, αλλά θα πρέπει επίσης να επαναλάβετε τη διαδικασία για τα [Masters](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getMasters--) και τα [Layout slides](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getLayoutSlides--) και να εφαρμόσετε την ίδια λογική κλιμάκωσης στα σχήματά τους ώστε να διασφαλιστεί η συνέπεια σε ολόκληρη την παρουσίαση.

### Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κάθετη/οριζόντια) μαζί με την αλλαγή μεγέθους;

Ναι. Μπορείτε να χρησιμοποιήστε το [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidesize/#setOrientation-int-) για να αλλάξετε τον προσανατολισμό. Βεβαιωθείτε ότι έχετε ορίσει τη λογική κλιμάκωσης αναλόγως ώστε να διατηρείται η διάταξη.

### Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να ορίσω;

Το Aspose.Slides υποστηρίζει προσαρμοσμένα μεγέθη, αλλά πολύ μεγάλα μεγέθη μπορεί να επηρεάσουν την απόδοση ή τη συμβατότητα με ορισμένες εκδόσεις του PowerPoint.

### Πώς μπορώ να αποτρέψω τα σχήματα με σταθερό λόγο διαστάσεων να παραμορφώνονται;

Μπορείτε να ελέγξετε τη μέθοδο `getAspectRatioLocked` του σχήματος πριν την κλιμάκωση. Εάν είναι κλειδωμένη, ρυθμίστε το πλάτος ή το ύψος αναλογικά αντί να τα κλιμακώσετε ξεχωριστά.