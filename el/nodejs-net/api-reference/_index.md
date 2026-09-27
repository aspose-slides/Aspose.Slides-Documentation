---
title: Αναφορά API
type: docs
weight: 50
url: /el/nodejs-net/api-reference/
description: "Το Aspose.Slides for Node.js via .NET τεκμηριώνεται από την αναφορά API του Aspose.Slides for .NET. Δείτε πώς τα ονόματα κλάσεων και μελών του .NET αντιστοιχούν σε JavaScript."
---
## **Επισκόπηση**

Το Aspose.Slides for Node.js via .NET δεν διαθέτει δική του αναφορά API. Το πακέτο εκθέτει τις κλάσεις του Aspose.Slides for .NET στο JavaScript με τα ίδια ονόματα, με ονόματα μελών σε camelCase, έτσι η [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/el/net/) τεκμηριώνει τις κλάσεις, τα μέλη και τις απαριθμήσεις.

## **Αντιστοίχηση ονομάτων .NET σε JavaScript**

Για να χρησιμοποιήσετε ένα μέλος που βρείτε στην αναφορά API του .NET, εφαρμόστε τους ακόλουθους κανόνες:

- **Οι κλάσεις και οι απαριθμήσεις διατηρούν τα ονόματα .NET**, όπως και οι τιμές των απαριθμήσεων: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Εισάγετέ τις από το πακέτο: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Οι ιδιότητες και οι μέθοδοι αρχίζουν με πεζό γράμμα.** `Presentation.Slides` γίνεται `presentation.slides`, και `ShapeCollection.AddAutoShape` γίνεται `shapes.addAutoShape`. Οι ιδιότητες παραμένουν ιδιότητες: τις διαβάζετε και τις αναθέτετε χωρίς παρενθέσεις.
- **Τα στοιχεία της συλλογής διαβάζονται με `get(index)`**, και ο αριθμός των στοιχείων με `count`: `presentation.slides.get(0)` αντί για `presentation.Slides[0]`.
- **Κάποιες υπερφορτώσεις παίρνουν ξεκριτικά ονόματα.** Για παράδειγμα, η υπερφόρτωση `Slide.GetImage(Size)` είναι `slide.getImageWithImageSize({ width, height })`. Άλλες μοιράζονται μία μέθοδο με προαιρετικά ορίσματα στο τέλος: `presentation.save(path, format, options, slides)` καλύπτει αρκετές υπερφορτώσεις του `Presentation.Save`, και `new Presentation(null, buffer)` ανοίγει μια παρουσίαση από ένα `Buffer`. Κάθε κλάση είναι ένα αρχείο κάτω από το φάκελο `lib` του πακέτου (για παράδειγμα, `node_modules/aspose.slides.via.net/lib/Slide.js`), όπου μπορείτε να δείτε τα ακριβή ονόματα.
- **Αποδεσμεύετε τις παρουσιάσεις με `dispose`** όταν τελειώσετε με αυτές· η JavaScript δεν διαθέτει δήλωση `using`.

Το πακέτο δεν καλύπτει κάθε μέλος του .NET. Εάν ένα μέλος από την αναφορά API του .NET λείπει από το αρχείο κλάσης, δεν είναι διαθέσιμο στη JavaScript.

## **Παράδειγμα**

Το παρακάτω script χρησιμοποιεί τους παραπάνω κανόνες. Κάθε σχόλιο δείχνει την κλήση .NET που αντιστοιχεί στη γραμμή που ακολουθεί. Προσθέτει ένα ορθογώνιο με κείμενο στην πρώτη διαφάνεια, αποδίδει τη διαφάνεια ως εικόνα PNG με ανάλυση 960 × 540 pixel, και αποθηκεύει την παρουσίαση ως PDF. Εκτελέστε το από φάκελο έργου όπου το πακέτο είναι εγκατεστημένο όπως περιγράφεται στην [Installation](/slides/el/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Το script γράφει τα αρχεία `slide.png` και `slide.pdf` στον τρέχοντα φάκελο. Και τα δύο εμφανίζουν το ορθογώνιο με το κείμενό του. Χωρίς άδεια, εμφανίζουν επίσης υδατογράφημα αξιολόγησης· δείτε την [Licensing](/slides/el/nodejs-net/licensing/).

Για λεπτομέρειες σχετικά με τα μέλη που χρησιμοποιούνται εδώ, δείτε το [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/), το [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/shapecollection/addautoshape/), το [TextFrame.Text](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/text/) και το [Slide.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage/) στην αναφορά API του Aspose.Slides for .NET.