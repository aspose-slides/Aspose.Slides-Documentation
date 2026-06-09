---
title: "Αλλαγή Μεγέθους Σχημάτων σε Διαφάνειες Παρουσίασης"
type: docs
weight: 110
url: /el/java/re-sizing-shapes-on-slide/
keywords:
- "αλλαγή μεγέθους σχήματος"
- "αλλαγή μεγέθους σχήματος"
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εύκολη αλλαγή μεγέθους σχημάτων σε διαφάνειες PowerPoint και OpenDocument με Aspose.Slides for Java—αυτοματοποιήστε τις προσαρμογές διάταξης διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Μία από τις πιο συχνές ερωτήσεις από τους πελάτες του Aspose.Slides for Java είναι πώς να αλλάξουν το μέγεθος των σχημάτων έτσι ώστε, όταν αλλάξει το μέγεθος της διαφάνειας, τα δεδομένα να μην περικοπούν. Αυτό το σύντομο τεχνικό άρθρο δείχνει πώς να το κάνετε.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να αποτραπεί η μετατόπιση των σχημάτων όταν αλλάζει το μέγεθος της διαφάνειας, ενημερώστε τη θέση και τις διαστάσεις κάθε σχήματος ώστε να ταιριάζουν με τη νέα διάταξη της διαφάνειας.

```java
// Φορτώστε το αρχείο παρουσίασης.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Λάβετε το αρχικό μέγεθος της διαφάνειας.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Αλλάξτε το μέγεθος της διαφάνειας χωρίς κλιμάκωση των υπαρχόντων σχημάτων.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Λάβετε το νέο μέγεθος της διαφάνειας.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Αλλάξτε το μέγεθος και την θέση των σχημάτων σε κάθε διαφάνεια.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Κλιμακώστε το μέγεθος του σχήματος.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Κλιμακώστε τη θέση του σχήματος.
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

{{% alert color="primary" %}} 
Αν μια διαφάνεια περιέχει πίνακα, ο παραπάνω κώδικας δεν θα λειτουργήσει σωστά. Σε αυτήν την περίπτωση, κάθε κελί του πίνακα πρέπει να αλλάξει το μέγεθός του.
{{% /alert %}} 

Χρησιμοποιήστε τον παρακάτω κώδικα για να αλλάξετε το μέγεθος των διαφανειών που περιέχουν πίνακες. Για πίνακες, η ρύθμιση του πλάτους ή του ύψους είναι ειδική περίπτωση: πρέπει να προσαρμόσετε τα ύψη των ξεχωριστών σειρών και τα πλάτη των στηλών για να αλλάξετε το συνολικό μέγεθος του πίνακα.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Λάβετε το αρχικό μέγεθος της διαφάνειας.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Αλλάξτε το μέγεθος της διαφάνειας χωρίς κλιμάκωση των υπαρχόντων σχημάτων.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Λάβετε το νέο μέγεθος της διαφάνειας.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Κλιμακώστε το μέγεθος του σχήματος.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Κλιμακώστε τη θέση του σχήματος.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Κλιμακώστε το μέγεθος του σχήματος.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Κλιμακώστε τη θέση του σχήματος.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Κλιμακώστε το μέγεθος του σχήματος.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Κλιμακώστε τη θέση του σχήματος.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή περικόπτονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Κατά την αλλαγή μεγέθους μιας διαφάνειας, τα σχήματα διατηρούν την αρχική τους θέση και μέγεθος εκτός εάν η κλίμακα αλλάξει ρητά. Αυτό μπορεί να οδηγήσει σε περικοπή του περιεχομένου ή σε μη ευθυγραμμισμένα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το βασικό παράδειγμα λειτουργεί για τους περισσότερους τύπους σχημάτων (πλαίσια κειμένου, εικόνες, διαγράμματα κ.λπ.). Ωστόσο, για πίνακες, πρέπει να διαχειριστείτε τις σειρές και τις στήλες ξεχωριστά, καθώς το ύψος και το πλάτος ενός πίνακα καθορίζονται από τις διαστάσεις των μεμονωμένων κελιών.

**Πώς αλλάζω το μέγεθος των πινάκων όταν αλλάζει το μέγεθος μιας διαφάνειας;**

Πρέπει να επαναλάβετε για όλες τις σειρές και στήλες του πίνακα και να αλλάξετε το ύψος και το πλάτος τους αναλογικά, όπως φαίνεται στο δεύτερο παράδειγμα κώδικα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους για τις Κύριες διαφάνειες και τις Διαφάνειες διάταξης;**

Ναι, αλλά θα πρέπει επίσης να επαναλάβετε για τις [Κύριες διαφάνειες](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getMasters--) και τις [Διαφάνειες διάταξης](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getLayoutSlides--) και να εφαρμόσετε την ίδια λογική κλιμάκωσης στα σχήματά τους για να εξασφαλίσετε συνέπεια σε όλη την παρουσίαση.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κάτοπτρο/τοπίο) μαζί με την αλλαγή μεγέθους;**

Ναι. Μπορείτε να χρησιμοποιήσετε το [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidesize/#setOrientation-int-) για να αλλάξετε τον προσανατολισμό. Βεβαιωθείτε ότι ορίσατε τη λογική κλιμάκωσης αναλόγως ώστε να διατηρηθεί η διάταξη.

**Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να ορίσω;**

Το Aspose.Slides υποστηρίζει προσαρμοσμένα μεγέθη, αλλά πολύ μεγάλα μεγέθη μπορεί να επηρεάσουν την απόδοση ή τη συμβατότητα με ορισμένες εκδόσεις του PowerPoint.

**Πώς μπορώ να αποτρέψω τα σχήματα σταθερής αναλογίας διαστάσεων από το να παραμορφώνονται;**

Μπορείτε να ελέγξετε τη μέθοδο `getAspectRatioLocked` του σχήματος πριν από την κλιμάκωση. Εάν είναι κλειδωμένη, προσαρμόστε το πλάτος ή το ύψος αναλογικά αντί να τα κλιμακώσετε χωριστά.