---
title: Διαχείριση Συμπληρωτών Παρουσίασης σε JavaScript
linktitle: Διαχείριση Συμπληρωτών
type: docs
weight: 10
url: /el/nodejs-java/manage-placeholder/
keywords:
- συμπλήρωμα
- συμπλήρωμα κειμένου
- συμπλήρωμα εικόνας
- συμπλήρωμα διαγράμματος
- συμπλήρωμα περιεχομένου
- κείμενο υπόδειξης
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να επιθεωρείτε και να επεξεργάζεστε τα συμπληρωτές κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοείτε την κληρονομιά των συμπληρωτών με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Ένας συμπληρωτής είναι ένα σχήμα που κρατά μια θέση για έναν συγκεκριμένο τύπο περιεχομένου σε ένα πρότυπο παρουσίασης. Συνήθη παραδείγματα είναι οι συμπληρωτές τίτλου, κυρίως κειμένου, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένας συμπληρωτής μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή κύρια διαφάνεια.

Το Aspose.Slides εκθέτει τις πληροφορίες συμπληρωτών μέσω της μεθόδου [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder). Η μέθοδος επιστρέφει ένα αντικείμενο [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) ή `null` για ένα κανονικό σχήμα. Χρησιμοποιήστε [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) για να καθορίσετε τι προορίζεται να περιέχει ο συμπληρωτής.

Η κλάση του σχήματος εξακολουθεί να είναι σημαντική μετά τον καθορισμό του τύπου του συμπληρωτή:

- Ένας κενός κειμένου, εικόνας, διαγράμματος ή περιεχομένου συμπληρωτής συνήθως αντιπροσωπεύεται από ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- Ένας συμπληρωτής εικόνας που έχει πληρωθεί μπορεί να αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- Ένας συμπληρωτής διαγράμματος που έχει πληρωθεί μπορεί να αντιπροσωπεύεται από ένα [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- Ένας συμπληρωτής περιεχομένου μπορεί να περιέχει πολλούς τύπους περιεχομένου. Ελέγξτε τόσο το [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) όσο και την κλάση σχήματος χρόνου εκτέλεσης, αντί να υποθέτετε ότι κάθε συμπληρωτής είναι ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) περιγράφει τον ρόλο ενός συμπληρωτή· δεν εγγυάται τον τύπο του σχήματος χρόνου εκτέλεσης. Πάντα να κάνετε έλεγχο τύπου πριν προσπελάσετε τα μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή πολυμέσων.
{{% /alert %}}

## **Κατανόηση Κληρονόμησης Συμπληρωτή**

Οι συμπληρωτές σχηματίζουν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, συμπληρωτές σε επίπεδο κύριου.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από την κύρια.
3. Μια κανονική διαφάνεια περιέχει τους συμπληρωτές για αυτή τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε τη μέθοδο [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) για να μετακινηθείτε ένα επίπεδο ψηλότερα στην ιεραρχία. Ένας συμπληρωτής διαφάνειας συνήθως επιστρέφει τον συμπληρωτή της διάταξης· ένας συμπληρωτής διάταξης μπορεί να επιστρέψει τον κύριο συμπληρωτή. Η μέθοδος επιστρέφει `null` όταν το σχήμα δεν έχει βασικό συμπληρωτή.

Το παρακάτω παράδειγμα απαριθμεί τους συμπληρωτές στην πρώτη διαφάνεια και αναφέρει τους βασικούς τους συμπληρωτές:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Η επεξεργασία ενός συμπληρωτή σε μια κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική υπέρθεση για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή κύριας διαφάνειας μπορεί να επηρεάσει όλες τις διαφάνειες που ακόμη κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό συνηθισμένο σχήμα δεν έχει βασικό συμπληρωτή και δεν αρχίζει να κληρονομεί μόνο επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αφαίρεση Κατάστασης Συμπληρωτή**

Κατά την προσαρμογή ενός προτύπου, χρησιμοποιήστε τη μέθοδο [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) για να διατηρήσετε ένα υπάρχον αντικείμενο ως συνηθισμένο σχήμα. Η μέθοδος [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) του επιστρέφει `null`, αλλά το σχήμα παραμένει στη συλλογή της διαφάνειας. Αντίθετα, η μέθοδος [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) διαγράφει το σχήμα από αυτή τη συλλογή.

Το παρακάτω παράδειγμα απαιτεί το `template.pptx` με τουλάχιστον μία διαφάνεια και έναν μη κενό συμπληρωτή κειμένου στην πρώτη διαφάνεια. Χρησιμοποιήστε έναν συμπληρωτή με μορφοποίηση κληρονομική από τη διάταξη ή την κύρια διαφάνεια για να δείτε το αποτέλεσμα της αφαίρεσης της σχέσης. Το παράδειγμα ελέγχει ότι το ίδιο σχήμα παραμένει, καλεί ξανά τη μέθοδο στο πλέον συνηθισμένο σχήμα και αποθηκεύει το αποτέλεσμα.

{{% alert color="warning" title="Warning" %}}
Η αφαίρεση της κατάστασης συμπληρωτή δεν διατηρεί αυτόματα τις κληρονομημένες ρυθμίσεις εμφάνισης. Το παρακάτω παράδειγμα αφήνει σκόπιμα αυτές τις ρυθμίσεις αμετάβλητες, οπότε η έξοδος μπορεί να φαίνεται διαφορετική. Ένα σχήμα του οποίου η θέση και το μέγεθος είναι εντελώς κληρονομημένα μπορεί να έχει μηδενικές συντεταγμένες και διαστάσεις μετά την κλήση και να γίνει αόρατο παρόλο που παραμένει στη συλλογή.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // Η κλήση της μεθόδου σε ένα συνηθισμένο σχήμα δεν έχει καμία επίδραση.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Για έναν ταιριαστό συμπληρωτή, όλοι οι τρεις έλεγχοι εκτυπώνουν `true`. Το κείμενο παραμένει, αλλά η κληρονομημένη θέση, το μέγεθος, η περιστροφή, η γραμματοσειρά, η στοίχιση παραγράφου, τα περιθώρια πλαισίου κειμένου, η κάθετη αγκύρωση, η γεμίσμα και οι ρυθμίσεις γραμμής μπορούν να αλλάξουν όταν αφαιρεθεί η σχέση του συμπληρωτή. Για παράδειγμα, η κληρονομημένη μορφοποίηση τίτλου μπορεί να επιστρέψει στην απλή μορφοποίηση κειμένου. Δείτε το [Slide Layout](/slides/el/nodejs-java/slide-layout/) για περισσότερα σχετικά με τις διαμορφώσεις.

Για να διατηρήσετε την επιθυμητή εμφάνιση, καταγράψτε τη λύση θέση, μέγεθος και περιστροφή πριν την κλήση και αντιγράψτε τις απαιτούμενες αποτελεσματικές τιμές μορφοποίησης σε ξεχωριστές μεταβλητές. Ανακτήστε αυτές τις τιμές μέσω των [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) και [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective). Μην βασίζεστε μόνο στα αντικείμενα αποτελεσματικής μορφοποίησης, επειδή οι τιμές μορφοποίησης κειμένου τους μπορεί να αλλάξουν μετά την αφαίρεση της σχέσης. Εφαρμόστε ρητά τις καταγραφείσες τιμές στο συνηθισμένο σχήμα μετά, συμπεριλαμβανομένων της οικογένειας γραμματοσειράς, μεγέθους, στυλ, χρώματος, ρυθμίσεων παραγράφου, ρυθμίσεων πλαισίου κειμένου, γεμίσματος και γραμμής που χρησιμοποιεί το πρότυπό σας.

Η κληρονομημένη γεωμετρία του σχήματος μπορεί επίσης να χρειάζεται να οριστεί ρητά μέσω της [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType). Για έναν ορθογώνιο συμπληρωτή κειμένου, αυτό σημαίνει την ανάθεση του [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle); η αποκατάσταση μόνο του γεμίσματος και της γραμμής ενδέχεται να μην αποκαταστήσει το ορατό ορθογώνιο. Τα πρότυπα με επιπλέον εφέ ή πιο σύνθετη μορφοποίηση απαιτούν επίσης τη διαχείριση αυτών των ρυθμίσεων.

## **Αλλαγή Κειμένου σε Συμπληρωτή**

Οι συμπληρωτές τίτλου, κεντραρισμένου τίτλου, υπότιτλου, σώματος και κειμένου υποστηρίζουν συνήθως κείμενο. Ελέγξτε για [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) πριν χρησιμοποιήσετε τη μέθοδό του [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame).

Αυτό το παράδειγμα ενημερώνει τον πρώτο συμπληρωτή τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτό το μοτίβο αποφεύγει την αντιμετώπιση των συμπληρωτών εικόνας, διαγράμματος, πίνακα ή πολυμέσων ως αντικείμενα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/). Επίσης, προσδιορίζει τον συμπληρωτή με βάση τον σκοπό του αντί να βασίζεται σε ευαίσθητο ευρετήριο σχήματος.

## **Ορισμός Κειμένου Υποδείξεων σε Διάταξη**

Το κείμενο υπόδειξης είναι η οδηγία κατά τον χρόνο σχεδίασης που εμφανίζεται σε έναν κενό συμπληρωτή, όπως *Κάντε κλικ για να προσθέσετε τίτλο*. Ορίστε προσαρμοσμένο κείμενο υπόδειξης στον συμπληρωτή διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σχημάτων μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) και επαναλάβετε τη συλλογή που επιστρέφει το [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes).

Το παρακάτω παράδειγμα αλλάζει τις υποδείξεις τίτλου και υπότιτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το κείμενο υπόδειξης δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά συμπληρωτές σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παράσχει πραγματικό περιεχόμενο, η υπόδειξη δεν εμφανίζεται πλέον. Η αλλαγή μιας υπόδειξης επίσης δεν αντικαθιστά το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Συμπληρωτή Εικόνας**

Υπάρχουν δύο περιπτώσεις που πρέπει να αντιμετωπιστούν:

- Εάν ο συμπληρωτής εικόνας είναι ήδη γεμάτος και αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), αντικαταστήστε την εικόνα μέσω των [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) και [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage).
- Εάν παραμένει κενός συμπληρωτής, προσθέστε ένα πλαίσιο εικόνας στις συντεταγμένες του συμπληρωτή με το [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) και αφαιρέστε τον κενό συμπληρωτή.

Το επόμενο παράδειγμα υποστηρίζει και τις δύο περιπτώσεις και αποθηκεύει την παρουσίαση:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αντικατάσταση που δημιουργείται για έναν κενό συμπληρωτή είναι ένα τοπικό πλαίσιο εικόνας, όχι ένας νέος συμπληρωτής, επειδή το [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) δεν παρέχει setter. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά ειδική για συμπληρωτές. Εάν η διατήρηση της σχέσης συμπληρωτή είναι ουσιώδης, ετοιμάστε και γεμίστε τον συμπληρωτή στο PowerPoint πρώτα, έπειτα ενημερώστε το προκύπτων [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλα εφέ ειδικά για εικόνες, δείτε το [Manage Picture Frames](/slides/el/nodejs-java/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο πλαίσιο εικόνας ή στη γεμίσμα εικόνας, όχι στα μεταδεδομένα του συμπληρωτή.

## **Εργασία με Συμπληρωτές Διαγράμματος και Περιεχομένου**

Ένας γεμάτος συμπληρωτής διαγράμματος μπορεί να αντιπροσωπευθεί από ένα [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/). Αυτό το παράδειγμα βρίσκει ένα τέτοιο διάγραμμα τόσο κατά τύπο συμπληρωτή όσο και κατά κλάση χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ένας γενικός συμπληρωτής περιεχομένου συνήθως έχει [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object). Στο PowerPoint λειτουργεί ως εκκινητής για πολλούς τύπους περιεχομένου, όπως διαγράμματα, πίνακες, διαγράμματα ροής, εικόνες και πολυμέσα. Αφού γεμίσει, εξετάστε την πραγματική κλάση σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διαμορφώσεις μπορούν επίσης να εκθέτουν [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) ή [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Το Aspose.Slides δεν μετατρέπει έναν κενό συμπληρωτή [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) σε ένα [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) απλώς αλλάζοντας το [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType); ο τύπος δεν μπορεί να αλλάξει μέσω του αντικειμένου. Για να γεμίσετε προγραμματιστικά ένα κενό διάγραμμα ή περιοχή περιεχομένου, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του συμπληρωτή και στη συνέχεια αφαιρέστε τον κενό συμπληρωτή. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το προστιθέμενο διάγραμμα είναι ένα συνηθισμένο τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του συμπληρωτή αλλά δεν κληρονομεί από τον συμπληρωτή της διάταξης. Χρησιμοποιήστε τα ειδικά άρθρα [chart management articles](/slides/el/nodejs-java/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω ολοκληρωμένο παράδειγμα ανοίγει ένα πρότυπο, ψάχνει την πρώτη διαφάνεια για έναν συμπληρωτή τίτλου ή εικόνας, ελέγχει τους τύπους του συμπληρωτή και του σχήματος, ενημερώνει το κατάλληλο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα αποφεύγει σκόπιμα την υπόθεση ενός ευρετηρίου σχήματος ή την αντιμετώπιση κάθε συμπληρωτή ως της ίδιας κλάσης.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Τι είναι ένας βασικός συμπληρωτής;**

Ένας βασικός συμπληρωτής είναι το αντίστοιχο σχήμα στη διάταξη ή τον κύριο από το οποίο κληρονομεί ένας άλλος συμπληρωτής. Χρησιμοποιήστε το [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) για να το ανακτήσετε. Ένα συνηθισμένο τοπικό σχήμα επιστρέφει `null` επειδή δεν είναι μέρος της ιεραρχίας των συμπληρωτών.

**Μπορώ να αλλάξω όλους τους τίτλους διαφάνειας επεξεργάζοντας έναν συμπληρωτή διάταξης;**

Μπορείτε να αλλάξετε τη κληρονομημένη μορφοποίηση ή το κείμενο υπόδειξης μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο του τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε το πραγματικό κείμενο τίτλου σε ολόκληρη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε συμπληρωτή τίτλου.

**Πώς διαχειρίζομαι τους συμπληρωτές ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο αντίστοιχο επίπεδο διαφάνειας, διάταξης, κύριου, σημειώσεων ή φυλλαδίου. Δείτε το [Διαχείριση Κεφαλίδας και Υποσέλιδου Παρουσίασης](/slides/el/nodejs-java/presentation-header-and-footer/) για πλήρη παραδείγματα.