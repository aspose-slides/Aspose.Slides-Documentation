---
title: Εξαγωγή Παρουσιάσεων σε HTML με Εξωτερικά Συνδεδεμένες Εικόνες
type: docs
weight: 100
url: /el/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- εξαγωγή PowerPoint
- εξαγωγή OpenDocument
- εξαγωγή παρουσίασης
- εξαγωγή διαφάνειας
- εξαγωγή PPT
- εξαγωγή PPTX
- εξαγωγή ODP
- PowerPoint σε HTML
- OpenDocument σε HTML
- παρουσίαση σε HTML
- διαφάνεια σε HTML
- PPT σε HTML
- PPTX σε HTML
- ODP σε HTML
- συνδεδεμένη εικόνα
- εξωτερικά συνδεδεμένη εικόνα
- συνδεδεμένος πόρος
- εξωτερικός πόρος
- JavaScript
- Node.js
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint και OpenDocument σε HTML με JavaScript χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java, με εικόνες και άλλους πόρους αποθηκευμένους ως εξωτερικά συνδεδεμένα αρχεία."
---
## **Επισκόπηση**

Από προεπιλογή, το Aspose.Slides εξάγει μια παρουσίαση σε ένα αυτόνομο αρχείο HTML. Οι εικόνες και άλλοι πόροι εγγράφονται απευθείας στο HTML, συνήθως ως δεδομένα Base64. Αυτό είναι βολικό όταν χρειάζεστε ένα φορητό αρχείο, αλλά δεν είναι πάντα η καλύτερη μορφή για ιστοσελίδα, CMS ή διασωλήνωση μετατροπών διακομιστή.

Χρησιμοποιήστε εξωτερικά συνδεδεμένους πόρους όταν θέλετε να:

- μειώσετε το μέγεθος του εγγράφου HTML·
- αποθηκεύσετε στην προσωρινή μνήμη εικόνες, γραμματοσειρές, ήχο ή βίντεο ξεχωριστά σε πρόγραμμα περιήγησης ή CDN·
- ελέγξετε, αντικαταστήσετε, συμπιέσετε ή επεξεργαστείτε μετά την εξαγωγή τους παραγόμενους πόρους·
- διατηρήσετε τη δομή εξόδου πιο κοντά σε αυτή που περιμένει μια web εφαρμογή.

Για τη γενική ροή εργασίας μετατροπής σε HTML, δείτε [Μετατροπή παρουσιάσεων PowerPoint σε HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/). Αυτό το άρθρο εστιάζει στο τμήμα σύνδεσης πόρων της εξαγωγής.

## **Πώς Λειτουργεί η Εξαγωγή Με Συνδεδεμένους Πόρους**

Ένα Java proxy για [ILinkEmbedController](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) επιτρέπει στην εφαρμογή σας να αποφασίζει, πόρος ανά πόρο, εάν ο εξαγωγέας ενσωματώνει τα δεδομένα στο HTML ή τα αποθηκεύει εξωτερικά και γράφει ένα σύνδεσμο.

Ο ελεγκτής διαθέτει τρεις μεθόδους:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) καθορίζει εάν ένας πόρος πρέπει να συνδεθεί ή να ενσωματωθεί·
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) επιστρέφει το URL που θα γραφτεί στο παραγόμενο HTML ή σε άλλο συνδεδεμένο πόρο·
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) γράφει τα δεδομένα του συνδεδεμένου πόρου σε δίσκο ή σε άλλο προορισμό αποθήκευσης.

Η διαδρομή του συστήματος αρχείων και το URL του προγράμματος περιήγησης είναι ξεχωριστά ζητήματα. Για παράδειγμα, το παρακάτω δείγμα γράφει αρχεία πόρων στο `html-output/assets` στο δίσκο, ενώ το HTML περιέχει σχετικές διευθύνσεις όπως `assets/resource-1.svg`. Ένας browser επιλύει αυτές τις διευθύνσεις σε σχέση με το αρχείο που περιέχει το σύνδεσμο. Συνεπώς, ένας σύνδεσμος από το `presentation.html` προς ένα αρχείο SVG χρησιμοποιεί `assets/resource-1.svg`, ενώ ένας σύνδεσμος από εκείνο το SVG προς μια εικόνα αποθηκευμένη στον ίδιο φάκελο `assets` χρησιμοποιεί `resource-4.jpg`.

## **Εξαγωγή HTML με Συνδεδεμένους Πόρους**

Το παρακάτω παράδειγμα JavaScript δημιουργεί έναν φάκελο εξόδου, αποθηκεύει το αρχείο HTML εκεί και αποθηκεύει τους συνδεδεμένους πόρους σε υποφάκελο `assets`. Ο ελεγκτής συνδέει κοινά εικόνα, γραμματοσειρά, ήχο, βίντεο και CSS πόρους όταν το Aspose.Slides παρέχει ή μπορεί να προβλέψει ασφαλή επέκταση αρχείου. Οι πόροι που δεν αναγνωρίζονται παραμένουν ενσωματωμένοι.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Μετά την εξαγωγή, ο φάκελος εξόδου έχει την εξής δομή:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Τα ακριβή αρχεία εξαρτώνται από το περιεχόμενο της παρουσίασης και τις επιλογές εξαγωγής. Για παράδειγμα, οι ραστερ εικόνες εξάγονται συνήθως ως JPEG ή PNG. Το Aspose.Slides μπορεί να επιλέξει διαφορετικό κωδικοποιητή εικόνας από αυτόν που χρησιμοποιείται στην πηγή όταν αυτό παράγει μικρότερο ή πιο κατάλληλο αρχείο. Εικόνες με διαφάνεια εξάγονται ως PNG.

## **Επιλογή URL για Ανάπτυξη**

Το δείγμα χρησιμοποιεί ένα σχετικό πρόθεμα URL: `assets/`. Εάν το `presentation.html` ανοίγει από το `html-output/presentation.html`, ο browser φορτώνει το `html-output/assets/resource-1.svg`.

Όταν ένας συνδεδεμένος πόρος παραπέμπει σε άλλο συνδεδεμένο πόρο, το δείγμα χρησιμοποιεί την παράμετρο `referrer` στη [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) και επιστρέφει μόνο το όνομα του αρχείου. Για παράδειγμα, εάν τα `resource-1.svg` και `resource-4.jpg` βρίσκονται και τα δύο στον φάκελο `assets`, το αρχείο SVG πρέπει να παραπέμπει σε `resource-4.jpg`, όχι σε `assets/resource-4.jpg`.

Χρησιμοποιήστε διαφορετικό πρόθεμα URL όταν τα αρχεία αναπτύσσονται αλλού:

- Χρησιμοποιήστε `assets/` όταν ο φάκελος πόρων βρίσκεται δίπλα στο αρχείο HTML·
- Χρησιμοποιήστε `../assets/` όταν ο φάκελος πόρων είναι ένα επίπεδο πάνω από το αρχείο HTML·
- Χρησιμοποιήστε `https://cdn.example.com/presentations/job-123/assets/` όταν τα αρχεία ανεβαίνουν σε CDN ή στατικό διακομιστή αρχείων.

Το URL που επιστρέφει η [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) πρέπει να ταιριάζει με την τελική θέση του αρχείου που γράφει η [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/). Σε εφαρμογές διακομιστή, χρησιμοποιήστε έναν μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης αντικειμένων για κάθε εργασία μετατροπής ώστε να αποτρέψετε την αντικατάσταση αρχείων από άλλη εξαγωγή.

## **Πότε Να Ενσωματώσετε Αντί Για Σύνδεση**

Το ενσωματωμένο Base64 HTML παραμένει χρήσιμο όταν η έξοδος πρέπει να είναι ένα ενιαίο αρχείο, όπως συνημμένο email, προεπισκόπηση εκτός σύνδεσης ή έγγραφο που θα μεταφερθεί χωρίς φάκελο υποστηρικτικών πόρων. Οι συνδεδεμένοι πόροι ταιριάζουν καλύτερα όταν το HTML θα σερβιριστεί από web εφαρμογή, θα αποθηκευθεί σε CMS, θα βελτιστοποιηθεί από αλυσίδα δημιουργίας ή θα κρυπτογραφηθεί από browsers ανεξάρτητα από το HTML.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να εξωτερικεύσω μόνο τις εικόνες και να αφήσω τους άλλους πόρους ενσωματωμένους;**

Ναι. Στη [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/), επιστρέψτε `LinkEmbedDecision.Link` μόνο για τους τύπους περιεχομένου που θέλετε να αποθηκεύσετε ως ξεχωριστά αρχεία και επιστρέψτε `LinkEmbedDecision.Embed` για όλα τα άλλα.

**Γιατί η επέκταση της εξαγόμενης εικόνας διαφέρει από αυτή της πηγαίας παρουσίασης;**

Το Aspose.Slides μπορεί να ξανακωδικοποιήσει τις ραστερ εικόνες κατά την εξαγωγή σε HTML ώστε να βελτιώσει το μέγεθος ή τη συμβατότητα με τον browser. Για παράδειγμα, μια εικόνα από το πηγαίο αρχείο μπορεί να γραφτεί ως JPEG ή PNG ανάλογα με το αποτέλεσμα της απόδοσης.

**Λειτουργούν τα σχετικά URL μετά τη μετακίνηση του αρχείου HTML;**

Τα σχετικά URL λειτουργούν μόνο όταν διατηρείται η ίδια σχετική δομή φακέλων. Εάν το HTML παραπέμπει σε `assets/resource-1.png`, ο φάκελος `assets` πρέπει να παραμείνει δίπλα στο αρχείο HTML εκτός αν δημιουργήσετε διαφορετικό πρόθεμα URL.

**Πρέπει οι εφαρμογές διακομιστή να επαναχρησιμοποιούν τον ίδιο φάκελο εξόδου;**

Όχι. Χρησιμοποιήστε έναν μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης για κάθε εργασία μετατροπής. Αυτό αποτρέπει συγκρούσεις ονομάτων αρχείων και αποτρέπει μια εξαγωγή από το να αντικαταστήσει πόρους που δημιουργήθηκαν από άλλη εξαγωγή.