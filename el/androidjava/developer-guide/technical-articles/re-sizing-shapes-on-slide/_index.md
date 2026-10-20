---
title: Αλλαγή μεγέθους σχημάτων σε διαφάνειες παρουσίασης στο Android
type: docs
weight: 130
url: /el/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
  - /el/androidjava/re-sizing-shapes-on-slide/
keywords:
  - αλλαγή μεγέθους σχήματος
  - αλλαγή μεγέθους σχήματος
  - PowerPoint
  - OpenDocument
  - παρουσίαση
  - Android
  - Aspose.Slides
description: "Απλοποιήστε την αλλαγή μεγέθους των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για Android μέσω Java—αυτοματοποιήστε τις προσαρμογές διάταξης διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Όταν αλλάζετε το μέγεθος της διαφάνειας μιας παρουσίασης, ίσως χρειαστεί επίσης να αλλάξετε το μέγεθος και τη θέση των σχημάτων της ώστε να ταιριάζουν με τις νέες διαστάσεις. Αυτό το άρθρο δείχνει πώς να κλιμακώσετε τα σχήματα με μη αυτόματο τρόπο και πώς να διαχειριστείτε πίνακες στις διαφάνειες, στα master και στα layout.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να διατηρήσετε τη σχετική θέση και το μέγεθος κάθε σχήματος, πολλαπλασιάστε τις οριζόντιες συντεταγμένες και το πλάτος του με το λόγο του νέου πλάτους της διαφάνειας προς το αρχικό πλάτος. Εφαρμόστε τον αντίστοιχο λόγο ύψους στις κάθετες συντεταγμένες και το ύψος του.

Το πρώτο παράδειγμα φορτώνει μια παρουσίαση της οποίας οι διαφάνειες δεν περιέχουν πίνακες, αλλάζει το μέγεθος της διαφάνειας σε A4 και αποθηκεύει το αποτέλεσμα. Χρησιμοποιεί [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) με [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) ώστε το επακόλουθο βρόχο να ελέγχει την κλιμάκωση. Οι λόγοι είναι χωρίς μονάδα· οι θέσεις και οι διαστάσεις των σχημάτων μετρώνται σε σημεία. Διαφορετικοί λόγοι πλάτους και ύψους μπορούν να παραμορφώσουν τα σχήματα, και η αλλαγή των διαστάσεων ενός σχήματος δεν κλιμακώνει το μέγεθος των γραμματοσειρών του.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Υπολογίστε ανεξάρτητους οριζόντιους και κατακόρυφους συντελεστές κλιμάκωσης.
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

{{% alert color="info" title="Σημείωση" %}}
Οι πίνακες απαιτούν ξεχωριστή διαχείριση: κλιμακώνετε το πλάτος των στηλών και το ύψος των γραμμών αντί να ορίζετε το συνολικό πλάτος και ύψος του πίνακα. Τα ύψη των γραμμών ενδέχεται να παραμείνουν μεγαλύτερα από το ζητούμενο εάν το περιεχόμενο των κελιών απαιτεί περισσότερο χώρο.
{{% /alert %}}

Το δεύτερο παράδειγμα υποστηρίζει πίνακες και επεξεργάζεται σχήματα στα master και στα layout, καθώς και σε μεμονωμένες διαφάνειες, πριν αποθηκεύσει την αλλαγμένη παρουσίαση. Η βοηθητική του λειτουργία διαχειρίζεται κάθε [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) κλιμακώνοντας το πλάτος των στηλών με [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) και το ελάχιστο ύψος των γραμμών με [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Στη συνέχεια κλιμακώνει τη θέση του πίνακα χωρίς να κλιμακώνει ξεχωριστά τις συνολικές του διαστάσεις.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Οι διαστάσεις του πίνακα ελέγχονται από το πλάτος των στηλών και το ύψος των γραμμών.
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
    // Υπολογίστε ανεξάρτητους οριζόντιους και κατακόρυφους συντελεστές κλιμάκωσης.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Αλλάξτε το μέγεθος των σχημάτων που ορίζονται στα master και στα layout, καθώς και σε μεμονωμένες διαφάνειες.
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

**Γιατί τα σχήματα παραμορφώνονται ή περικοπώνται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Εάν αλλάξετε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα σχήματα, αυτά διατηρούν τις αρχικές τους θέσεις και διαστάσεις και ενδέχεται να υπερβαίνουν τη διαφάνεια. Η κλιμάκωση του πλάτους και του ύψους με διαφορετικούς λόγους μπορεί επίσης να παραμορφώσει τα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το πρώτο παράδειγμα αλλάζει απευθείας τα όρια των σχημάτων και προορίζεται για διαφάνειες χωρίς πίνακες. Το δεύτερο παράδειγμα διαχειρίζεται ξεχωριστά τους πίνακες. Ελέγξτε τη διαρρύθμιση που προκύπτει, ιδιαίτερα το κείμενο και τους πίνακες, επειδή αυτά τα παραδείγματα δεν κλιμακώνουν το μέγεθος των γραμματοσειρών και το περιεχόμενο των πινάκων μπορεί να περιορίσει το ύψος των γραμμών.

**Πώς να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Κλιμακώστε το πλάτος των στηλών με τον λόγο πλάτους και το ελάχιστο ύψος των γραμμών με τον λόγο ύψους, στη συνέχεια κλιμακώστε τη θέση του πίνακα, όπως φαίνεται στο δεύτερο παράδειγμα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους για master διαφάνειες και layout διαφάνειες;**

Ναι. Το δεύτερο παράδειγμα διασχίζει τις [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) και τις [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) κάθε master και εφαρμόζει την ίδια λογική αλλαγής μεγέθους στα σχήματά τους.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κατακόρυφα/οριζόντια) μαζί με την αλλαγή μεγέθους;**

Ναι. Καλέστε την [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) μετά την αλλαγή του μεγέθους της διαφάνειας και πριν διαβάσετε τις τελικές διαστάσεις, ώστε οι παράγοντες κλιμάκωσης να αντικατοπτρίζουν τον τελικό προσανατολισμό.

**Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να ορίσω;**

Μπορείτε να ορίσετε προσαρμοσμένες διαστάσεις διαφάνειας με την [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Οι υποστηριζόμενες διαστάσεις εξαρτώνται επίσης από τη μορφή της παρουσίασης και την εφαρμογή που χρησιμοποιείται για το άνοιγμα του αρχείου.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερή αναλογία διαστάσεων από το να παραμορφωθούν;**

Χρησιμοποιήστε τον ίδιο παράγοντα κλιμάκωσης για το πλάτος και το ύψος. Για να ταιριάξετε την αρχική διαρρύθμιση μέσα στις νέες διαστάσεις της διαφάνειας, χρησιμοποιήστε τον μικρότερο από τους λόγους πλάτους και ύψους για και τις δύο διαστάσεις και θέσεις. Αυτό διατηρεί τις αναλογίες, αλλά μπορεί να αφήσει ανεξόριστο χώρο σε μία πλευρά.