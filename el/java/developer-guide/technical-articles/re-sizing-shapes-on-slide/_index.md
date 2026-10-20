---
title: Αλλαγή Μεγέθους Σχημάτων σε Διαφάνειες Παρουσιάσεων με Java
type: docs
weight: 130
url: /el/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /el/java/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- αλλαγή μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Απλή αλλαγή μεγέθους σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για Java — αυτοματοποιήστε τις προσαρμογές διάταξης διαφάνειας και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Όταν αλλάζετε το μέγεθος της διαφάνειας μιας παρουσίασης, ίσως χρειαστεί επίσης να αλλάξετε το μέγεθος και τη θέση των σχημάτων της ώστε να ταιριάζουν με τις νέες διαστάσεις. Αυτό το άρθρο δείχνει πώς να κλιμακώσετε τα σχήματα χειροκίνητα και πώς να χειριστείτε τους πίνακες στις διαφάνειες, στα master και στις διατάξεις.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να διατηρήσετε τη σχετική θέση και το μέγεθος κάθε σχήματος, πολλαπλασιάστε τις οριζόντιες συντεταγμένες και το πλάτος του με το λόγο του νέου πλάτους της διαφάνειας προς το αρχικό πλάτος. Εφαρμόστε τον αντίστοιχο λόγο ύψους στις κάθετες συντεταγμένες και το ύψος του.

Το πρώτο παράδειγμα φορτώνει μια παρουσίαση των οποίων οι διαφάνειες δεν περιέχουν πίνακες, αλλάζει το μέγεθος της διαφάνειας σε A4 και αποθηκεύει το αποτέλεσμα. Χρησιμοποιεί [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) με [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) ώστε η επακόλουθη δομή βρόχου να ελέγχει την κλιμάκωση. Οι λόγοι είναι χωρίς μονάδα μέτρησης· οι θέσεις και οι διαστάσεις των σχημάτων μετρώνται σε points. Διαφορετικοί λόγοι πλάτους και ύψους μπορούν να παραμορφώσουν τα σχήματα, και η αλλαγή των διαστάσεων ενός σχήματος δεν κλιμακώνει τα μεγέθη γραμματοσειράς.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλιμάκωσης.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Οι πίνακες απαιτούν ξεχωριστό χειρισμό: κλιμακώστε τα πλάτη των στηλών και τα ύψη των γραμμών αντί να ορίσετε το συνολικό πλάτος και ύψος του πίνακα. Τα ύψη των γραμμών μπορεί να παραμείνουν μεγαλύτερα από το ζητούμενο εάν το περιεχόμενο των κελιών απαιτεί περισσότερο χώρο.
{{% /alert %}}

Το δεύτερο παράδειγμα υποστηρίζει πίνακες και επεξεργάζεται σχήματα στα master και στις διατάξεις, καθώς και σε μεμονωμένες διαφάνειες, πριν αποθηκεύσει την αλλαγμένη παρουσίαση. Ο βοηθός του αντιμετωπίζει κάθε [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) κλιμακώνοντας το πλάτος των στηλών με [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) και τα ελάχιστα ύψη των γραμμών με [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Στη συνέχεια κλιμακώνει τη θέση του πίνακα χωρίς να κλιμακώσει ξεχωριστά τις συνολικές του διαστάσεις.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Οι διαστάσεις του πίνακα ελέγχονται από τα πλάτη των στηλών και τα ύψη των γραμμών.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλιμάκωσης.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Αλλάξτε το μέγεθος των σχημάτων που ορίζονται στα master και στις διατάξεις, καθώς και στις μεμονωμένες διαφάνειες.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή αποκόπτονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Εάν αλλάξετε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα σχήματα, αυτά διατηρούν τις αρχικές τους θέσεις και διαστάσεις και μπορεί να υπερβαίνουν το όριο της διαφάνειας. Η κλιμάκωση του πλάτους και του ύψους με διαφορετικούς λόγους μπορεί επίσης να παραμορφώσει τα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλα τα είδη σχημάτων;**

Το πρώτο παράδειγμα αλλάζει απευθείας τα όρια των σχημάτων και προορίζεται για διαφάνειες χωρίς πίνακες. Το δεύτερο παράδειγμα διαχειρίζεται τους πίνακες ξεχωριστά. Ελέγξτε τη διαρρύθμιση του αποτελέσματος, ιδιαίτερα το κείμενο και τους πίνακες, επειδή αυτά τα παραδείγματα δεν κλιμακώνουν τα μεγέθη γραμματοσειρών και το περιεχόμενο του πίνακα μπορεί να περιορίσει τα ύψη των γραμμών.

**Πώς να αλλάξω το μέγεθος των πινάκων κατά την αλλαγή μεγέθους μιας διαφάνειας;**

Κλιμακώστε το πλάτος των στηλών με τον λόγο πλάτους και τα ελάχιστα ύψη των γραμμών με τον λόγο ύψους, στη συνέχεια κλιμακώστε τη θέση του πίνακα, όπως φαίνεται στο δεύτερο παράδειγμα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους για master διαφάνειες και διαφάνειες διάταξης;**

Ναι. Το δεύτερο παράδειγμα επαναλαμβάνει μέσω του [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) και των [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) κάθε master και εφαρμόζει την ίδια λογική αλλαγής μεγέθους στα σχήματά τους.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κόκφο/τοπίο) μαζί με την αλλαγή μεγέθους;**

Ναι. Καλέστε τη [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) μετά την αλλαγή του μεγέθους της διαφάνειας και πριν από την ανάγνωση των στοχευμένων διαστάσεων, ώστε οι συντελεστές κλίμακας να αντανακλούν τον τελικό προσανατολισμό.

**Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να θέσω;**

Μπορείτε να καθορίσετε προσαρμοσμένες διαστάσεις διαφάνειας με τη [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). Οι υποστηριζόμενες διαστάσεις εξαρτώνται επίσης από τη μορφή της παρουσίασης και την εφαρμογή που χρησιμοποιείται για το άνοιγμα του αρχείου.

**Πώς μπορώ να αποτρέψω την παραμόρφωση σχημάτων με σταθερό λόγο διαστάσεων;**

Χρησιμοποιήστε τον ίδιο συντελεστή κλίμακας για το πλάτος και το ύψος. Για να προσαρμόσετε την αρχική διάταξη στις νέες διαστάσεις της διαφάνειας, χρησιμοποιήστε τον μικρότερο από τους λόγους πλάτους και ύψους και για τις δύο διαστάσεις και τις θέσεις. Αυτό διατηρεί τις αναλογίες αλλά μπορεί να αφήσει αχρησιμοποίητο χώρο κατά μήκος μιας πλευράς.