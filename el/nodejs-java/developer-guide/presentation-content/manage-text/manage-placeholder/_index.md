---
title: Διαχείριση Συμβόλων Κράτησης Παρουσίασης σε JavaScript
linktitle: Διαχείριση Συμβόλων Κράτησης
type: docs
weight: 10
url: /el/nodejs-java/manage-placeholder/
keywords:
- σύμβολο κράτησης
- σύμβολο κράτησης κειμένου
- σύμβολο κράτησης εικόνας
- σύμβολο κράτησης διαγράμματος
- σύμβολο κράτησης περιεχομένου
- κείμενο πρόσκλησης
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να επεξεργάζεστε και να ελέγχετε τα σύμβολα κράτησης κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοήσετε την κληρονομικότητα των συμβόλων κράτησης με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Ένα σύμβολο κράτησης είναι ένα σχήμα που δεσμεύει θέση για ένα συγκεκριμένο τύπο περιεχομένου σε ένα πρότυπο παρουσίασης. Συνηθισμένα παραδείγματα είναι τα σύμβολα κράτησης τίτλου, σώματος, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένα σύμβολο κράτησης μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή την κύρια διαφάνεια.

Το Aspose.Slides αποκαλύπτει πληροφορίες για τα σύμβολα κράτησης μέσω της μεθόδου [Shape.getPlaceholder](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getPlaceholder). Η μέθοδος επιστρέφει ένα αντικείμενο [Placeholder](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholder/) ή `null` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [Placeholder.getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholder/#getType) για να καθορίσετε τι προορίζεται να περιέχει το σύμβολο κράτησης.

Η κλάση του σχήματος εξακολουθεί να είναι σημαντική αφότου γνωρίζετε τον τύπο του συμβόλου κράτησης:

- Ένα κενό σύμβολο κράτησης κειμένου, εικόνας, διαγράμματος ή περιεχομένου συνήθως αντιπροσωπεύεται από ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).
- Ένα γεμάτο σύμβολο κράτησης εικόνας μπορεί να αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/).
- Ένα γεμάτο σύμβολο κράτησης διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [Chart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/).
- Ένα σύμβολο κράτησης περιεχομένου μπορεί να περιέχει διάφορους τύπους περιεχομένου. Ελέγξτε τόσο το [Placeholder.getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholder/#getType) όσο και την κλάση σχήματος σε χρόνο εκτέλεσης αντί να υποθέετε ότι κάθε σύμβολο κράτησης είναι ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholder/#getType) περιγράφει το ρόλο ενός συμβόλου κράτησης· δεν εγγυάται τον τύπο σχήματος σε χρόνο εκτέλεσης. Πάντα χρησιμοποιήστε έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή πολυμέσων.
{{% /alert %}}

## **Κατανόηση Κληρονομικότητας Συμβόλων Κράτησης**

Τα σύμβολα κράτησης σχηματίζουν μια ιεραρχία:

1. Μία κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, σύμβολα κράτησης επιπέδου κύριας διαφάνειας.
2. Μία διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από την κύρια διαφάνεια.
3. Μία κανονική διαφάνεια περιέχει τα σύμβολα κράτησης για αυτή τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλείτε το [Shape.getBasePlaceholder](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getBasePlaceholder) για να μετακινηθείτε ένα επίπεδο πάνω σε αυτή την ιεραρχία. Ένα σύμβολο κράτησης διαφάνειας συνήθως επιστρέφει το σύμβολο κράτησης της διάταξης· ένα σύμβολο κράτησης διάταξης μπορεί να επιστρέψει το σύμβολο κράτησης της κύριας διαφάνειας. Η μέθοδος επιστρέφει `null` όταν το σχήμα δεν έχει βασικό σύμβολο κράτησης.

Το παρακάτω παράδειγμα παραθέτει τα σύμβολα κράτησης στην πρώτη διαφάνεια και αναφέρει τα βασικά τους σύμβολα κράτησης:

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

Η επεξεργασία ενός συμβόλου κράτησης σε κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική παράκαμψη για αυτή τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή κύριας διαφάνειας μπορεί να επηρεάσει όλες τις διαφάνειες που εξακολουθούν να κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό συνηθισμένο σχήμα δεν έχει βασικό σύμβολο κράτησης και δεν αρχίζει να κληρονομεί απλώς επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αλλαγή Κειμένου σε Σύμβολο Κράτησης**

Τα σύμβολα κράτησης τίτλου, κεντρικού τίτλου, υπότιτλου, σώματος και κειμένου συνήθως υποστηρίζουν κείμενο. Ελέγξτε για [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) πριν χρησιμοποιήσετε τη μέθοδο [getTextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/#getTextFrame).

Αυτό το παράδειγμα ενημερώνει το πρώτο σύμβολο κράτησης τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

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

Αυτό το μοτίβο αποφεύγει τη μεταχείριση των συμβόλων κράτησης εικόνας, διαγράμματος, πίνακα ή πολυμέσων ως αντικείμενα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/). Επίσης, προσδιορίζει το σύμβολο κράτησης βάσει σκοπού αντί να βασίζεται σε ευαίσθητο δείκτη σχήματος.

## **Ορισμός Κειμένου Πρόσκλησης σε Διάταξη**

Το κείμενο πρόσκλησης είναι η οδηγία κατά το σχεδιασμό που εμφανίζεται σε ένα κενό σύμβολο κράτησης, όπως *Click to add title*. Ορίστε προσαρμοσμένο κείμενο πρόσκλησης στο σύμβολο κράτησης διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σχημάτων μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [Slide.getLayoutSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#getLayoutSlide) και επαναλάβετε τη συλλογή που επιστρέφεται από το [BaseSlide.getShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/#getShapes).

Το παρακάτω παράδειγμα αλλάζει τις πρόσκληση τίτλου και υποτίτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

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

Το κείμενο πρόσκλησης δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά σύμβολα κράτησης σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, η πρόσκληση δεν εμφανίζεται πλέον. Η αλλαγή μιας πρόσκλησης επίσης δεν αντικαθιστά το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Συμβόλου Κράτησης Εικόνας**

Υπάρχουν δύο περιπτώσεις προς διαχείριση:

- Αν το σύμβολο κράτησης εικόνας είναι ήδη γεμάτο και αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/), αντικαταστήστε την εικόνα μέσω του [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), του [PictureFillFormat.getPicture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#getPicture), και του [Picture.setImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/#setImage).
- Αν παραμένει κενό σύμβολο κράτησης, προσθέστε ένα πλαίσιο εικόνας στις συντεταγμένες του συμβόλου κράτησης με το [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) και αφαιρέστε το κενό σύμβολο κράτησης.

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

Η αντικατάσταση που δημιουργείται για ένα κενό σύμβολο κράτησης είναι ένα τοπικό πλαίσιο εικόνας, όχι ένα νέο σύμβολο κράτησης, επειδή το [Shape.getPlaceholder](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getPlaceholder) δεν παρέχει setter. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά ειδική για σύμβολα κράτησης. Αν η διατήρηση της σχέσης του συμβόλου κράτησης είναι κρίσιμη, ετοιμάστε και γεμίστε το σύμβολο κράτησης στο PowerPoint πρώτα, μετά ενημερώστε το προκύπτον [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλες εφέ ειδικά για εικόνες, δείτε το [Manage Picture Frames](/slides/el/nodejs-java/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο πλαίσιο εικόνας ή στο γέμισμα εικόνας, όχι στα μεταδεδομένα του συμβόλου κράτησης.

## **Εργασία με Σύμβολα Κράτησης Διαγράμματος και Περιεχομένου**

Ένα γεμάτο σύμβολο κράτησης διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [Chart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/). Αυτό το παράδειγμα εντοπίζει τέτοιο διάγραμμα τόσο με βάση τον τύπο του συμβόλου κράτησης όσο και την κλάση χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

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

Ένα γενικό σύμβολο κράτησης περιεχομένου συνήθως έχει το [PlaceholderType.Object](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholdertype/#Object). Στο PowerPoint λειτουργεί ως εκκινητής για πολλούς τύπους περιεχομένου, όπως διαγράμματα, πίνακες, διαγράμματα ροής, εικόνες και πολυμέσα. Αφού γεμίσει, εξετάστε την πραγματική κλάση σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εκθέτουν τα [PlaceholderType.Chart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholdertype/#Media), ή [PlaceholderType.Diagram](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Το Aspose.Slides δεν μετατρέπει ένα κενό σύμβολο κράτησης [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) σε ένα [Chart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/) απλώς αλλάζοντας το [Placeholder.getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholder/#getType); ο τύπος δεν μπορεί να αλλάξει μέσω του αντικειμένου. Για να γεμίσετε προγραμματιστικά ένα κενό διάγραμμα ή περιοχή περιεχομένου, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του συμβόλου κράτησης και στη συνέχεια αφαιρέστε το κενό σύμβολο κράτησης. Το παρακάτω παράδειγμα το κάνει αυτό για ένα διάγραμμα:

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

Το προστιθέμενο διάγραμμα είναι ένα συνηθισμένο τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του συμβόλου κράτησης αλλά δεν κληρονομεί από το σύμβολο κράτησης της διάταξης. Χρησιμοποιήστε τα αφιερωμένα [chart management articles](/slides/el/nodejs-java/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω ολοκληρωμένο παράδειγμα ανοίγει ένα πρότυπο, αναζητά στην πρώτη διαφάνεια είτε σύμβολο κράτησης τίτλου είτε εικόνας, ελέγχει τους τύπους του συμβόλου κράτησης και του σχήματος, ενημερώνει το κατάλληλο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα σκόπιμα αποφεύγει την υπόθεση ότι υπάρχει δείκτης σχήματος ή τη μεταχείριση κάθε συμβόλου κράτησης ως της ίδιας κλάσης.

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

## **FAQ**

**Τι είναι ένα βασικό σύμβολο κράτησης;**

Ένα βασικό σύμβολο κράτησης είναι το αντίστοιχο σχήμα στη διάταξη ή στην κύρια διαφάνεια από το οποίο κληρονομεί ένα άλλο σύμβολο κράτησης. Χρησιμοποιήστε το [Shape.getBasePlaceholder](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getBasePlaceholder) για να το ανακτήσετε. Ένα συνηθισμένο τοπικό σχήμα επιστρέφει `null` επειδή δεν αποτελεί μέρος της ιεραρχίας των συμβόλων κράτησης.

**Μπορείτε να αλλάξετε όλες τις επικεφαλίδες διαφάνειας επεξεργάζοντας ένα σύμβολο κράτησης διάταξης;**

Μπορείτε να αλλάξετε τη κληρονομημένη μορφοποίηση ή το κείμενο πρόσκλησης μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε το πραγματικό κείμενο τίτλου σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε σύμβολο κράτησης τίτλου.

**Πώς διαχειρίζομαι σύμβολα κράτησης ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο αντίστοιχο επίπεδο διαφάνειας, διάταξης, κύριας διαφάνειας, σημειώσεων ή φυλλαδίου. Δείτε το [Manage Presentation Header and Footer](/slides/el/nodejs-java/presentation-header-and-footer/) για πλήρη παραδείγματα.