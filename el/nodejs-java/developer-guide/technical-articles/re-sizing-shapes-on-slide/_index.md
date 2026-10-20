---
title: Αλλαγή μεγέθους σχημάτων σε διαφάνειες παρουσίασης στο Node.js
type: docs
weight: 130
url: /el/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- αλλαγή μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Απλά αλλάξτε το μέγεθος των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για Node.js μέσω Java—αυτοματοποιήστε τις προσαρμογές διάταξης διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Όταν αλλάζετε το μέγεθος της διαφάνειας μιας παρουσίασης, ίσως χρειαστεί επίσης να αλλάξετε το μέγεθος και τη θέση των σχημάτων της ώστε να ταιριάζουν με τις νέες διαστάσεις. Αυτό το άρθρο δείχνει πώς να κλιμακώσετε τα σχήματα χειροκίνητα και πώς να διαχειριστείτε τους πίνακες στις διαφάνειες, στα master και στις διατάξεις.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να διατηρήσετε τη σχετική θέση και το μέγεθος κάθε σχήματος, πολλαπλασιάστε τις οριζόντιες συντεταγμένες και το πλάτος του με τον λόγο του νέου πλάτους της διαφάνειας προς το αρχικό πλάτος. Εφαρμόστε τον αντίστοιχο λόγο ύψους στις κάθετες συντεταγμένες και το ύψος του.

Το πρώτο παράδειγμα φορτώνει μια παρουσίαση των οποίων οι διαφάνειες δεν περιέχουν πίνακες, αλλάζει το μέγεθος της διαφάνειας σε A4 και αποθηκεύει το αποτέλεσμα. Χρησιμοποιεί [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) με [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) ώστε ο επακόλουθος βρόχος να ελέγχει την κλιμάκωση. Οι λόγοι είναι χωρίς μονάδα· οι θέσεις και οι διαστάσεις των σχημάτων μετρώνται σε σημεία. Διαφορετικοί λόγοι πλάτους και ύψους μπορούν να παραμορφώσουν τα σχήματα, και η αλλαγή των διαστάσεων ενός σχήματος δεν κλιμακώνει τα μεγέθη γραμματοσειράς.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Υπολογίστε ανεξάρτητους οριζόντιους και κατακόρυφους συντελεστές κλίμακας.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Οι πίνακες απαιτούν ξεχωριστό χειρισμό: κλιμακώστε τα πλάτη των στηλών και τα ύψη των γραμμών αντί να ορίσετε το συνολικό πλάτος και ύψος του πίνακα. Τα ύψη των γραμμών ενδέχεται να παραμείνουν μεγαλύτερα από το ζητούμενο εάν το περιεχόμενο των κελιών απαιτεί περισσότερο χώρο.
{{% /alert %}}

Το δεύτερο παράδειγμα υποστηρίζει πίνακες και επεξεργάζεται σχήματα στα master και στις διατάξεις, καθώς και σε μεμονωμένες διαφάνειες, πριν αποθηκεύσει την αλλαγμένη παρουσίαση. Ο βοηθός του διαχειρίζεται κάθε [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) κλιμακώνοντας τα πλάτη των στηλών με [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) και τα ελάχιστα ύψη των γραμμών με [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Στη συνέχεια κλιμακώνει τη θέση του πίνακα χωρίς να κλιμακώνει ξεχωριστά τις συνολικές του διαστάσεις.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Οι διαστάσεις του πίνακα ελέγχονται από τα πλάτη των στηλών και τα ύψη των γραμμών.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Υπολογίστε ανεξάρτητους οριζόντιους και κατακόρυφους συντελεστές κλίμακας.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Αλλάξτε το μέγεθος των σχημάτων που ορίζονται σε master και διατάξεις, καθώς και σε μεμονωμένες διαφάνειες.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή περικόπτονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**
Αν αλλάξετε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα σχήματα, αυτά διατηρούν τις αρχικές τους θέσεις και διαστάσεις και ενδέχεται να υπερβαίνουν τη διαφάνεια. Η κλιμάκωση του πλάτους και του ύψους με διαφορετικούς λόγους μπορεί επίσης να παραμορφώσει τα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**
Το πρώτο παράδειγμα αλλάζει τα όρια των σχημάτων απευθείας και προορίζεται για διαφάνειες χωρίς πίνακες. Το δεύτερο παράδειγμα διαχειρίζεται τους πίνακες ξεχωριστά. Ελέγξτε τη διαρρύθμιση που προκύπτει, ιδιαίτερα το κείμενο και τους πίνακες, επειδή αυτά τα παραδείγματα δεν κλιμακώνουν τα μεγέθη των γραμματοσειρών και το περιεχόμενο των πινάκων μπορεί να περιορίσει τα ύψη των γραμμών.

**Πώς να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**
Κλιμακώστε τα πλάτη των στηλών με τον λόγο του πλάτους και τα ελάχιστα ύψη των γραμμών με τον λόγο του ύψους, έπειτα κλιμακώστε τη θέση του πίνακα, όπως φαίνεται στο δεύτερο παράδειγμα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους για master διαφάνειες και διαφάνειες διάταξης;**
Ναι. Το δεύτερο παράδειγμα διατρέχει τις [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) και για κάθε master τις [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) και εφαρμόζει την ίδια λογική αλλαγής μεγέθους στα σχήματα τους.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κάθετο/οριζόντιο) μαζί με την αλλαγή μεγέθους;**
Ναι. Καλέστε τη [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) μετά την αλλαγή του μεγέθους της διαφάνειας και πριν διαβάσετε τις στοχευμένες διαστάσεις, ώστε οι συντελεστές κλιμάκωσης να αντανακλούν τον τελικό προσανατολισμό.

**Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να ορίσω;**
Μπορείτε να ορίσετε προσαρμοσμένες διαστάσεις διαφάνειας με τη [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). Οι υποστηριζόμενες διαστάσεις εξαρτώνται επίσης από τη μορφή της παρουσίασης και την εφαρμογή που χρησιμοποιείται για το άνοιγμα του αρχείου.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερή αναλογία διαστάσεων να παραμορφώνονται;**
Χρησιμοποιήστε τον ίδιο συντελεστή κλιμάκωσης για το πλάτος και το ύψος. Για να προσαρμόσετε την αρχική διάταξη στις νέες διαστάσεις της διαφάνειας, χρησιμοποιήστε τον μικρότερο από τους λόγους πλάτους και ύψους για και τις δύο διαστάσεις και θέσεις. Αυτό διατηρεί τις αναλογίες αλλά μπορεί να αφήσει ανεχό χώρο κατά μήκος μιας άκρης.