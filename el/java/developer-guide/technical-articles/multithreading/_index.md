---
title: Πολυνηματισμός στο Aspose.Slides για Java
linktitle: Πολυνηματισμός
type: docs
weight: 310
url: /el/java/multithreading/
keywords:
- πολυνηματισμός
- πολλαπλά νήματα
- παράλληλη εργασία
- μετατροπή διαφανειών
- διαφάνειες σε εικόνες
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ο πολυνηματισμός του Aspose.Slides για Java ενισχύει την επεξεργασία PowerPoint και OpenDocument. Ανακαλύψτε τις βέλτιστες πρακτικές για αποδοτικές ροές εργασίας παρουσίασης."
---
## **Εισαγωγή**

Ενώ η παράλληλη εργασία με παρουσιάσεις είναι δυνατή (εκτός από την ανάλυση/φόρτωση/κλωνοποίηση) και τα πάντα εξελίσσονται σωστά (τη περισσότερη ώρα), υπάρχει μια μικρή πιθανότητα να λάβετε λανθασμένα αποτελέσματα όταν χρησιμοποιείτε τη βιβλιοθήκη σε πολλαπλά νήματα.

Σας συνιστούμε θερμά να **μην** χρησιμοποιείτε μια μοναδική [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) παρουσία σε περιβάλλον πολλαπλών νημάτων, επειδή μπορεί να οδηγήσει σε απρόβλεπτα σφάλματα ή αποτυχίες που δεν εντοπίζονται εύκολα. 

Δεν είναι **ασφαλές** να φορτώνετε, αποθηκεύετε ή/και να κλωνοποιείτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) σε πολλαπλά νήματα. Τέτοιες λειτουργίες **δεν** υποστηρίζονται.  Εάν χρειάζεται να εκτελέσετε τέτοιες εργασίες, πρέπει να παραλληλοποιήσετε τις λειτουργίες χρησιμοποιώντας αρκετές διεργασίες μονόνημα, και κάθε μία από αυτές πρέπει να χρησιμοποιεί τη δική της παρουσία παρουσίασης. 

## **Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες Παράλληλα**

Ας υποθέσουμε ότι θέλουμε να μετατρέψουμε όλες τις διαφάνειες από μια παρουσία PowerPoint σε εικόνες PNG παράλληλα. Δεδομένου ότι δεν είναι ασφαλές να χρησιμοποιούμε μια μοναδική παρουσία `Presentation` σε πολλαπλά νήματα, χωρίζουμε τις διαφάνειες παρουσίας σε ξεχωριστές παρουσιάσεις και μετατρέπουμε τις διαφάνειες σε εικόνες παράλληλα, χρησιμοποιώντας κάθε παρουσία σε ξεχωριστό νήμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς γίνεται αυτό.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Εξάγετε τη διαφάνεια i σε ξεχωριστή παρουσίαση.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Μετατρέψτε τη διαφάνεια σε εικόνα σε ξεχωριστή εργασία.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Περιμένετε να ολοκληρωθούν όλες οι εργασίες.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **Συχνές Ερωτήσεις**

**Χρειάζεται να καλέσω την παραμετροποίηση άδειας σε κάθε νήμα;**

Όχι. Αρκεί να το κάνετε μία φορά ανά διεργασία/περιβάλλον εφαρμογής πριν ξεκινήσουν τα νήματα. Εάν [license setup](/slides/el/java/licensing/) μπορεί να κληθεί ταυτόχρονα (για παράδειγμα, κατά την λάσι αρχικοποίηση), συγχρονίστε αυτήν την κλήση επειδή η μέθοδος παραμετροποίησης άδειας δεν είναι ασφαλής για νήματα.

**Μπορώ να περάσω αντικείμενα `Presentation` ή `Slide` μεταξύ νημάτων;**

Η μεταφορά «ζωντανών» αντικειμένων παρουσίασης μεταξύ νημάτων δεν συνιστάται: χρησιμοποιήστε ανεξάρτητες παρουσίες ανά νήμα ή δημιουργήστε εκ των προτέρων ξεχωριστές παρουσιάσεις/περιέκτες διαφανειών για κάθε νήμα. Αυτή η προσέγγιση ακολουθεί τη γενική σύσταση να μην μοιράζεστε μία μοναδική παρουσία παρουσίασης μεταξύ νημάτων.

**Είναι ασφαλές να παραλληλοποιηθεί η εξαγωγή σε διαφορετικές μορφές (PDF, HTML, εικόνες) εφόσον κάθε νήμα έχει τη δική του παρουσία `Presentation`;**

Ναι. Με ανεξάρτητες παρουσίες και ξεχωριστές διαδρομές εξόδου, τέτοιες εργασίες συνήθως παραλληλοποιούνται σωστά· αποφύγετε την κοινή χρήση αντικειμένων παρουσίασης και κοινών ροών I/O.

**Τι πρέπει να κάνω με τις καθολικές ρυθμίσεις γραμματοσειρών (φακέλους, υποκαταστάσεις) σε πολυνηματική λειτουργία;**

Αρχικοποιήστε όλες τις καθολικές [font settings](/slides/el/java/powerpoint-fonts/) πριν ξεκινήσετε τα νήματα και μην τις αλλάξετε κατά τη διάρκεια του παραλληλικού έργου. Αυτό εξαλείφει τους ανταγωνισμούς κατά την πρόσβαση σε κοινόχρηστους πόρους γραμματοσειρών.