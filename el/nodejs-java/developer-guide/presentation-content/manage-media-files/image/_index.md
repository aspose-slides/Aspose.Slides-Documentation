---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις Χρησιμοποιώντας JavaScript
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/nodejs-java/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- προσθήκη bitmap
- αντικατάσταση εικόνας
- αντικατάσταση φωτογραφίας
- από το διαδίκτυο
- φόντο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- εξωτερικοί πόροι SVG
- επιλυτής SVG
- συνδεδεμένες εικόνες SVG
- γραμματοσειρές SVG
- προσθήκη EMF
- προσθήκη WMF
- προσθήκη TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Απλοποιήστε τη διαχείριση εικόνων σε PowerPoint και OpenDocument με το Aspose.Slides για Node.js μέσω Java, βελτιώνοντας την απόδοση και αυτοματοποιώντας τη ροή εργασίας σας."
---
## **Εισαγωγή**

Οι εικόνες κάνουν τις παρουσιάσεις πιο ελκυστικές και οπτικά εντυπωσιακές. Στο Microsoft PowerPoint, μπορείτε να εισάγετε εικόνες στις διαφάνειες από αρχεία, το διαδίκτυο ή άλλες πηγές. Παρομοίως, το Aspose.Slides επιτρέπει την προσθήκη εικόνων στις διαφάνειες παρουσίασης με διάφορους τρόπους.

{{% alert  title="Tip" color="primary" %}} 

Η Aspose παρέχει δωρεάν μετατροπείς —[JPEG to PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG to PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που σας επιτρέπουν να δημιουργείτε γρήγορα παρουσιάσεις από εικόνες. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Αν θέλετε να προσθέσετε μια εικόνα ως πλαίσο εικόνας—ειδικά αν σκοπεύετε να την αλλάξετε μέγεθος, να εφαρμόσετε εφέ ή να χρησιμοποιήσετε άλλες τυπικές επιλογές διαμόρφωσης—δείτε το [Picture Frame](/slides/el/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Μπορείτε να μετατρέψετε εικόνες από τη μια μορφή στην άλλη. Δείτε τις παρακάτω σελίδες: convert [image to JPG](https://products.aspose.com/slides/el/nodejs-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/el/nodejs-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/el/nodejs-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/el/nodejs-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/el/nodejs-java/conversion/png-to-svg/), and [SVG to PNG](https://products.aspose.com/slides/el/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Το Aspose.Slides υποστηρίζει εικόνες σε δημοφιλείς μορφές όπως JPEG, PNG, BMP, GIF και άλλες. 

## **Προσθήκη Εικόνων αποθηκευμένων Τοπικά σε Διαφάνειες**

Μπορείτε να προσθέσετε μία ή περισσότερες εικόνες που είναι αποθηκευμένες στον υπολογιστή σας σε μια διαφάνεια παρουσίασης. Ο ακόλουθος κώδικας δείγμα JavaScript δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Προσθήκη Εικόνων από το Διαδίκτυο σε Διαφάνειες**

Αν η εικόνα που θέλετε να προσθέσετε σε μια διαφάνεια δεν είναι αποθηκευμένη στον υπολογιστή σας, μπορείτε να την προσθέσετε απευθείας από το διαδίκτυο. 

Ο ακόλουθος κώδικας δείγμα JavaScript δείχνει πώς να προσθέσετε μια εικόνα από το διαδίκτυο σε μια διαφάνεια:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Προσθήκη Εικόνων σε Slide Masters**

Ένας slide master αποθηκεύει και ελέγχει πληροφορίες όπως το θέμα και η διάταξη για τις διαφάνειες που τον χρησιμοποιούν. Όταν προσθέτετε μια εικόνα σε έναν slide master, η εικόνα εμφανίζεται σε κάθε διαφάνεια που βασίζεται σε αυτόν τον master. 

Ο ακόλουθος κώδικας δείγμα JavaScript δείχνει πώς να προσθέσετε μια εικόνα σε έναν slide master:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Προσθήκη Εικόνων ως Φόντο Διαφάνειας**

Μπορείτε να χρησιμοποιήσετε μια εικόνα ως φόντο για μία ή περισσότερες διαφάνειες. Για λεπτομέρειες, δείτε *[Setting Images as Backgrounds for Slides](/slides/el/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG σε Παρουσιάσεις**

Το περιεχόμενο SVG μπορεί να προστεθεί σε μια παρουσίαση χρησιμοποιώντας την κλάση [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/). Το αντικείμενο SVG εικόνας που προκύπτει μπορεί στη συνέχεια να προστεθεί στη συλλογή εικόνων της παρουσίασης και να χρησιμοποιηθεί για τη δημιουργία ενός πλαισίου εικόνας.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εισαγωγή Περιεχομένου SVG με Εξωτερικούς Πόρους**

Αρχεία SVG που εξάγονται από εργαλεία σχεδίασης, επεξεργαστές διαγραμμάτων, συστήματα εικονιδίων και διαδικτυακές pipelines μπορεί να αναφέρουν πόρους που είναι αποθηκευμένοι εκτός του εγγράφου SVG. Για παράδειγμα, ένα SVG μπορεί να περιέχει σύνδεσμο εικόνας όπως `images/photo.png`, μια τιμή CSS `url(...)` ή ένα URL γραμματοσειράς.

Για την εισαγωγή τέτοιου περιεχομένου SVG, παρέχετε έναν εξωτερικό επιλυτή πόρων και τον περνάτε, μαζί με μια βασική URI, σε έναν κατάλληλο κατασκευαστή [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/). Η βασική URI καθορίζει τη θέση του εγγράφου SVG και χρησιμοποιείται για την επίλυση σχετικών συνδέσμων.

Η κλάση `SvgImage` παρέχει πρόσβαση σε πληροφορίες σχετικά με το εισαγόμενο SVG:

- `getSvgContent()` επιστρέφει το σήμανση SVG ως συμβολοσειρά.
- `getSvgData()` επιστρέφει το περιεχόμενο SVG ως πίνακα bytes.
- `getBaseUri()` επιστρέφει τη βασική URI που χρησιμοποιείται για σχετικούς συνδέσμους.
- `getExternalResourceResolver()` επιστρέφει τον επιλυτή πόρων που έχει εκχωρηθεί στην εικόνα SVG.

### **Υλοποίηση Εξωτερικού Επικουρικού Επικυρωτή Πόρων**

Ο επιλυτής διαθέτει δύο μεθόδους:

- `resolveUri` συνδυάζει τη βασική URI και έναν σχετικό σύνδεσμο πόρου και επιστρέφει μια απόλυτη URI. Επιστρέψτε `null` όταν ο σύνδεσμος δεν μπορεί να επιλυθεί ή δεν επιτρέπεται.
- `getEntity` επιστρέφει ένα ρέον Java που μπορεί να διαβαστεί για μια απόλυτη URI πόρου. Επιστρέψτε `null` όταν ο πόρος λείπει, φράγεται ή δεν είναι διαθέσιμος. Μπορεί επίσης να επιστραφεί εναλλακτικό ρεύμα όταν είναι κατάλληλο.

Ο ακόλουθος βοηθός δημιουργεί έναν επιλυτή που φορτώνει συνδεδεμένους πόρους μόνο από ένα επιτρεπόμενο τοπικό φάκελο. Οι δικτυακοί πόροι και οι διαδρομές εκτός του επιτρεπόμενου φακέλου φράγονται. Μια προαιρετική εναλλακτική εικόνα επιστρέφεται για μη επιλυμένους συνδέσμους εικόνας.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Αυτός ο επιλυτής επιτρέπει σκόπιμα μόνο τοπικά αρχεία.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Χρησιμοποιήστε εναλλακτικό μόνο για πόρους εικόνας. Η επιστροφή ενός ρεύματος εικόνας
                // για μια χαμένη γραμματοσειρά ή φύλλο στυλ δεν θα ήταν έγκυρη.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Επίλυση Συνδεδεμένων Πόρων Κατά τη Διάρκεια Εισαγωγής SVG**

Υποθέστε ότι το `assets/diagram.svg` περιέχει μια σχετική αναφορά όπως:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ο ακόλουθος κώδικας JavaScript περνά τη URI του αρχείου SVG ως τη βασική URI και παρέχει έναν προσαρμοσμένο επιλυτή. Ο επιλυτής μετατρέπει τον σχετικό σύνδεσμο εικόνας σε απόλυτη URI και επιστρέφει ένα ρεύμα που περιέχει τον συνδεδεμένο πόρο ενώ το Aspose.Slides επεξεργάζεται το SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// Η βασική URI αντιπροσωπεύει τη θέση του εγγράφου SVG.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// Το SvgImage εμφανίζει το περιεχόμενο προέλευσης, τα δυαδικά δεδομένα, τη βασική URI και τον επιλυτή.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η κλάση `SvgImage` παρέχει επίσης υπερφορτώσεις που δέχονται δεδομένα SVG ως πίνακα bytes, καθώς και μεθόδους κατασκευής βασισμένες σε ρεύματα, μαζί με έναν εξωτερικό επιλυτή πόρων και μια βασική URI.

{{% alert title="Important" color="warning" %}}

Ο επιλυτής πόρων καθιστά διαθέσιμους εξωτερικούς πόρους ενώ το Aspose.Slides επεξεργάζεται και αποδίδει το SVG. Δεν τροποποιεί την αρχική σήμανση SVG ούτε ενσωματώνει αυτόματα τους επιλυμένους πόρους σε αυτήν.

Όταν μια εικόνα SVG προστίθεται στη συλλογή εικόνων της παρουσίασης, το αρχείο PPTX μπορεί να περιέχει τόσο την αρχική αναπαράσταση SVG όσο και μια ρεαλιστική εναλλακτική εικόνα. Ένας συνδεδεμένος πόρος μπορεί να εμφανιστεί στην παραγόμενη εναλλακτική εικόνα ενώ ένας σχετικός σύνδεσμος όπως `images/photo.png` παραμένει αμετάβλητος στο αποθηκευμένο SVG. Μια εφαρμογή που αποδίδει τη φυσική αναπαράσταση SVG μπορεί επομένως να παραλείψει το συνδεδεμένο περιεχόμενο όταν ο αρχικός εξωτερικός πόρος δεν είναι διαθέσιμος.

{{% /alert %}}

### **Δημιουργία Φορητής Εικόνας SVG**

Για να δημιουργήσετε μια εικόνα SVG που δεν εξαρτάται από εξωτερικά αρχεία, κάντε το SVG αυτόνομο πριν δημιουργήσετε το `SvgImage`. Για παράδειγμα, αντικαταστήστε τις συνδεδεμένες URL εικόνων με URIs `data:` που περιέχουν τα δεδομένα της εικόνας:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Αφού ενσωματωθούν όλοι οι απαιτούμενοι πόροι στο περιεχόμενο SVG, δημιουργήστε το `SvgImage`, προσθέστε το στη συλλογή εικόνων της παρουσίασης και ενσωματώστε το σε ένα πλαίσον εικόνας όπως φαίνεται στο προηγούμενο παράδειγμα.

### **Διαχείριση Ελλιπών ή Φραγμένων Πόρων**

Επιστρέψτε `null` από το `resolveUri` όταν μια URI πόρου είναι άκυρη, απαγορευμένη ή δεν μπορεί να επιλυθεί. Επιστρέψτε `null` από το `getEntity` όταν δεν είναι δυνατή η ανάγνωση του πόρου. Το Aspose.Slides συνεχίζει την επεξεργασία του SVG χωρίς αυτόν τον πόρο όποτε είναι δυνατόν.

Μπορεί να επιστραφεί εναλλακτικό ρεύμα για έναν ελλιπή πόρο, αλλά το περιεχόμενό του πρέπει να είναι συμβατό με τον τύπο του ζητούμενου πόρου. Για παράδειγμα, επιστρέψτε ρεύμα εικόνας μόνο για ελλιπής εικόνα, όχι για γραμματοσειρά ή φύλλο στυλ.

{{% alert title="Security" color="warning" %}}

Μην επιλύετε αυθαίρετες διαδρομές αρχείων ή ανεξέλεγκτες δικτυακές URLs από μη αξιόπιστα αρχεία SVG. Περιορίστε τα επιτρεπόμενα σχήματα, φακέλους και κεντρικούς υπολογιστές. Για δικτυακούς πόρους, εφαρμόστε επίσης χρονικά όρια σύνδεσης, όρια μεγέθους απάντησης και έλεγχο εγκυρότητας περιεχομένου.

{{% /alert %}}

## **Μετατροπή SVG σε Σύνολο Σχημάτων**

Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε σύνολο σχημάτων, παρόμοια με την αντίστοιχη λειτουργικότητα στο PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Αυτή η λειτουργικότητα παρέχεται από μια υπερφόρτωση της μεθόδου [addGroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) της κλάσης [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection) που δέχεται ένα αντικείμενο εικόνας SVG ως πρώτο όρισμα.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Πηγή αρχείου SVG.
const svgFileName = "sample.svg";

// Όνομα αρχείου εξόδου παρουσίασης.
const outPptxPath = "presentation.pptx";

// Δημιουργία νέας παρουσίασης.
const presentation = new aspose.slides.Presentation();
try {
    // Ανάγνωση περιεχομένου αρχείου SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Δημιουργία αντικειμένου SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Λήψη μεγέθους διαφάνειας.
    const slideSize = presentation.getSlideSize().getSize();

    // Μετατροπή εικόνας SVG σε ομάδα σχημάτων και κλιμάκωση στο μέγεθος διαφάνειας.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Αποθήκευση της παρουσίασης σε μορφή PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Εικόνων ως EMF σε Διαφάνειες**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να δημιουργήσετε εικόνες EMF από φύλλα εργασίας Excel με το Aspose.Cells και να τις προσθέσετε σε διαφάνειες παρουσίασης.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Αποθήκευση του βιβλίου εργασίας σε ρεύμα.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Προσθήκη του αρχείου όπως είναι ώστε η εικόνα παραμείνει διανυσματικό EMF αντί να μετατραπεί σε ραστερ.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Αντικατάσταση Εικόνων στη Συλλογή Εικόνων**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε εικόνες που είναι αποθηκευμένες στη συλλογή εικόνων μιας παρουσίασης, συμπεριλαμβανομένων των εικόνων που χρησιμοποιούνται από σχήματα διαφάνειας. Αυτή η ενότητα περιγράφει διάφορους τρόπους ενημέρωσης των εικόνων στη συλλογή. Μπορείτε να αντικαταστήσετε μια εικόνα χρησιμοποιώντας ακατέργαστα δεδομένα bytes, μια παρουσία [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) ή άλλη εικόνα που υπάρχει ήδη στη συλλογή.

Ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Φορτώστε μια νέα εικόνα από αρχείο σε έναν πίνακα bytes.
1. Αντικαταστήστε την εικόνα-στόχο με τη νέα εικόνα χρησιμοποιώντας τον πίνακα bytes.
1. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε αντικείμενο [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) και αντικαταστήστε την εικόνα-στόχο με αυτό το αντικείμενο.
1. Στην τρίτη προσέγγιση, αντικαταστήστε την εικόνα-στόχο με μια εικόνα που υπάρχει ήδη στη συλλογή εικόνων της παρουσίασης.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Ο πρώτος τρόπος.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Ο δεύτερος τρόπος.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // Ο τρίτος τρόπος.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Αποθήκευση της παρουσίασης σε αρχείο.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Με τον δωρεάν μετατροπέα [Text to GIF](https://products.aspose.app/slides/el/text-to-gif) της Aspose, μπορείτε εύκολα να δημιουργήσετε κινούμενο κείμενο και GIF από κείμενο. 

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Διατηρείται η αρχική ανάλυση της εικόνας μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς το [picture](/slides/el/nodejs-java/picture-frame/) κλιμακώνεται στη διαφάνεια και από τυχόν συμπίεση κατά την αποθήκευση.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσετε το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στον master slide ή σε μια διάταξη και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης — οι αλλαγές θα επεκταθούν σε όλα τα στοιχεία που χρησιμοποιούν αυτόν τον πόρο.

**Μπορεί μια εισαχθείσα SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετά από αυτό τα μεμονωμένα μέρη γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως φόντο για πολλές διαφάνειες ταυτόχρονα;**

[Αντιστοιχίστε την εικόνα ως φόντο](/slides/el/nodejs-java/presentation-background/) στον master slide ή στη σχετική διάταξη — όλες οι διαφάνειες που χρησιμοποιούν αυτόν τον master/διάταξη θα κληρονομήσουν το φόντο.

**Πώς μπορώ να αποτρέψω μια παρουσίαση από το να γίνει πολύ μεγάλη λόγω πολλών εικόνων;**

Επαναχρησιμοποιήστε έναν ενιαίο πόρο εικόνας αντί για διπλότυπα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και κρατήστε επαναλαμβανόμενα γραφικά στον master όπου είναι κατάλληλο.