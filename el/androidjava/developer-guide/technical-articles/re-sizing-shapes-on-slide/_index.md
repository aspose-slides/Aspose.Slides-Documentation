---
title: Αλλαγή μεγέθους σχημάτων σε διαφάνειες παρουσίασης σε Android
type: docs
weight: 130
url: /el/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- τροποποίηση μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Aspose.Slides
description: "Απλώς αλλάξτε το μέγεθος των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για Android μέσω Java — αυτοματοποιήστε τις προσαρμογές διάταξης διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Όταν αλλάζετε το μέγεθος των διαφανειών μιας παρουσίασης, μπορεί επίσης να χρειαστεί να αλλάξετε το μέγεθος και να επανατοποθετήσετε τα σχήματά της ώστε να ταιριάζουν στις νέες διαστάσεις. Αυτό το άρθρο δείχνει πώς να κλιμακώσετε τα σχήματα χειροκίνητα και πώς να διαχειριστείτε πίνακες σε διαφάνειες, κύριες διαφάνειες και προσαρμογές.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να διατηρήσετε τη σχετική θέση και το μέγεθος κάθε σχήματος, πολλαπλασιάστε τις οριζόντιες συντεταγμένες και το πλάτος του με το λόγο του νέου πλάτους της διαφάνειας προς το αρχικό πλάτος. Εφαρμόστε τον αντίστοιχο λόγο ύψους στις κάθετες συντεταγμένες και στο ύψος.

Το πρώτο παράδειγμα φορτώνει μια παρουσίαση της οποίας οι διαφάνειες δεν περιέχουν πίνακες, αλλάζει το μέγεθος της διαφάνειας σε Α4 και αποθηκεύει το αποτέλεσμα. Χρησιμοποιεί [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) με [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) ώστε ο επακόλουθος βρόχος να ελέγχει την κλίμακα. Οι λόγοι είναι χωρίς μονάδα· οι θέσεις και οι διαστάσεις των σχημάτων μετρώνται σε σημεία. Διαφορετικοί λόγοι πλάτους και ύψους μπορούν να παραμορφώσουν τα σχήματα, και η αλλαγή των διαστάσεων ενός σχήματος δεν κλιμακώνει τα μεγέθη γραμματοσειράς.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλίμακας.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
Οι πίνακες απαιτούν ξεχωριστή διαχείρηση: κλιμακώστε τα πλάτη των στηλών και τα ύψη των γραμμών αντί να ορίσετε το συνολικό πλάτος και ύψος του πίνακα. Τα ύψη των γραμμών μπορεί να παραμείνουν μεγαλύτερα από το ζητούμενο εάν το περιεχόμενο των κελιών απαιτεί περισσότερο χώρο.
{{% /alert %}}

Το δεύτερο παράδειγμα υποστηρίζει πίνακες και επεξεργάζεται σχήματα σε κύριες διαφάνειες και προσαρμογές καθώς και σε μεμονωμένες διαφάνειες πριν αποθηκεύσει την επαναδιαμορφωμένη παρουσίαση. Ο βοηθός του διαχειρίζεται κάθε [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) κλιμακώνοντας τα πλάτη των στηλών με [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) και τα ελάχιστα ύψη των γραμμών με [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Στη συνέχεια κλιμακώνει τη θέση του πίνακα χωρίς να κλιμακώνει ξεχωριστά τις συνολικές του διαστάσεις.

```java
import com.aspose.slides.*;

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
    // Υπολογίστε ανεξάρτητα οριζόντιους και κάθετους συντελεστές κλίμακας.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Αλλάξτε το μέγεθος των σχημάτων που ορίζονται σε κύριες διαφάνειες και προσαρμογές, καθώς και σε μεμονωμένες διαφάνειες.
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

**Γιατί τα σχήματα παραμορφώνονται ή κόβονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Αν αλλάξετε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα σχήματα, αυτά διατηρούν τις αρχικές τους θέσεις και διαστάσεις και μπορεί να υπερβαίνουν τη διαφάνεια. Η κλίμακα του πλάτους και του ύψους με διαφορετικούς λόγους μπορεί επίσης να παραμορφώσει τα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το πρώτο παράδειγμα αλλάζει απευθείας τα όρια των σχημάτων και προορίζεται για διαφάνειες χωρίς πίνακες. Το δεύτερο παράδειγμα διαχειρίζεται τους πίνακες ξεχωριστά. Ελέγξτε τη διαρρύθμιση που προκύπτει, ειδικά το κείμενο και τους πίνακες, επειδή αυτά τα παραδείγματα δεν κλιμακώνουν τα μεγέθη γραμματοσειράς και το περιεχόμενο των πινάκων μπορεί να περιορίσει τα ύψη των γραμμών.

**Πώς να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Κλιμακώστε το πλάτος των στηλών με τον λόγο πλάτους και τα ελάχιστα ύψη των γραμμών με τον λόγο ύψους, στη συνέχεια κλιμακώστε τη θέση του πίνακα, όπως φαίνεται στο δεύτερο παράδειγμα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους και για κύριες διαφάνειες και διαφάνειες προσαρμογής;**

Ναι. Το δεύτερο παράδειγμα διατρέχει τις [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) και τις [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) κάθε κύριας διαφάνειας και εφαρμόζει την ίδια λογική αλλαγής μεγέθους στα σχήματά τους.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κάθετο/οριζόντιο) μαζί με την αλλαγή μεγέθους;**

Ναι. Καλέστε το [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) μετά την αλλαγή του μεγέθους της διαφάνειας και πριν την ανάγνωση των διαστάσεων-στόχου, ώστε οι συντελεστές κλίμακας να αντικατοπτρίζουν τον τελικό προσανατολισμό.

**Υπάρχει όριο στο μέγεθος διαφάνειας που μπορώ να ορίσω;**

Μπορείτε να καθορίσετε προσαρμοσμένες διαστάσεις διαφάνειας με το [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Οι υποστηριζόμενες διαστάσεις εξαρτώνται επίσης από τη μορφή της παρουσίασης και την εφαρμογή που χρησιμοποιείται για το άνοιγμα του αρχείου.

**Πώς μπορώ να αποτρέψω την παραμόρφωση σχημάτων με σταθερή αναλογία διαστάσεων;**

Χρησιμοποιήστε τον ίδιο συντελεστή κλίμακας για πλάτος και ύψος. Για να προσαρμόσετε την αρχική διάταξη στις νέες διαστάσεις της διαφάνειας, χρησιμοποιήστε το μικρότερο από τους λόγους πλάτους και ύψους και για τις δύο διαστάσεις και τις θέσεις. Αυτό διατηρεί τις αναλογίες αλλά μπορεί να αφήσει άχρηστο χώρο κατά μήκος μιας άκρης.