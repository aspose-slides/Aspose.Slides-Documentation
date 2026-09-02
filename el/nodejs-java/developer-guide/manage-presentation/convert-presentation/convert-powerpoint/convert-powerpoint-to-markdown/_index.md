---
title: Μετατροπή παρουσιάσεων PowerPoint σε Markdown με JavaScript
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε MD
- παρουσίαση σε MD
- διαφάνεια σε MD
- PPT σε MD
- PPTX σε MD
- αποθήκευση PowerPoint ως Markdown
- αποθήκευση παρουσίασης ως Markdown
- αποθήκευση διαφάνειας ως Markdown
- αποθήκευση PPT ως MD
- αποθήκευση PPTX ως MD
- εξαγωγή PPT σε MD
- εξαγωγή PPTX σε MD
- εξαγωγή εικόνων Markdown
- σύνδεσμοι εικόνων CDN
- PowerPoint
- παρουσίαση
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PPT και PPTX σε Markdown με JavaScript και ελέγξτε πού αποθηκεύονται και παραπέμπονται οι εξαγόμενες εικόνες bitmap, metafile και SVG."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω Java μπορεί να μετατρέπει παρουσιάσεις PPT και PPTX σε Markdown για τεκμηρίωση, στατικές ιστοσελίδες, μετεγκατάσταση περιεχομένου και εργασίες ελέγχου έκδοσης. Μπορείτε να επιλέξετε μια παραλλαγή του Markdown, να ελέγξετε πώς αποδίδεται το περιεχόμενο των διαφανειών και να αποφασίσετε πού αποθηκεύονται οι εξαγώμενες εικόνες και πώς οι δημιουργημένες αναφορές Markdown τις παραπέμπουν.

Από προεπιλογή, η εξαγωγή Markdown χρησιμοποιεί έξοδο μόνο κειμένου. Για να εξάγετε οπτικό περιεχόμενο, ορίστε τον τύπο εξαγωγής με τη μέθοδο [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) στο `Sequential` ή `Visual` τιμή από την απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownexporttype/). Το `Sequential` αποδίδει τα στοιχεία της διαφάνειας ξεχωριστά και με τη σειρά, ενώ το `Visual` διατηρεί τις ομαδοποιημένες ιδιότητες μαζί για να διατηρήσει την οπτική σχέση τους. Η τιμή `TextOnly` δεν παράγει πόρους εικόνας, έτσι οι κλήσεις επιστροφής αποθήκευσης εικόνας δεν καλούνται σε αυτή τη λειτουργία.

## **Μετατροπή Παρουσίασης σε Markdown**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και, στη συνέχεια, καλέστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) με την τιμή `Md` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Επιλογή Παραλλαγής Markdown**

Η μέθοδος [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) ελέγχει την προδιαγραφή Markdown που χρησιμοποιείται για το αποτέλεσμα. Η απαρίθμηση [Flavor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/flavor/) περιλαμβάνει CommonMark, GitHub Flavored Markdown και άλλες υποστηριζόμενες παραλλαγές.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση ως CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή Εικόνων με την Προεπιλεγμένη Συμπεριφορά Τοπικής Αποθήκευσης**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) παρέχει δύο μεθόδους για τη ρύθμιση τοπικά αποθηκευμένων εικόνων:

- [setBasePath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) καθορίζει τον βασικό κατάλογο για το έγγραφο Markdown και τους πόρους του.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) καθορίζει το υποκατάλογο εικόνας. Η προεπιλεγμένη τιμή του είναι `Images`.

Το παρακάτω παράδειγμα αποδίδει οπτικό περιεχόμενο, γράφει εικόνες στο `output/assets` και δημιουργεί σχετικές αναφορές εικόνας στο έγγραφο Markdown:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Αυτή η συμπεριφορά λειτουργεί επίσης ως εναλλακτική λύση όταν ένας προσαρμοσμένος επεξεργαστής αποθήκευσης εικόνας επιστρέφει `false`.

## **Προσαρμογή Αποθήκευσης Εικόνων και Συνδέσμων Markdown**

Χρησιμοποιήστε τη μέθοδο [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) για να καταγράψετε μια κλήση επιστροφής για μη‑SVG bitmap και metafile πόρους που δημιουργούνται κατά την εξαγωγή Markdown. Η κλήση επιστροφής `MarkdownImageSavingHandler` λαμβάνει το αντικείμενο [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/), την τιμή του [ImageFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imageformat/) και το παραγόμενο σύνδεσμο Markdown ως έναν μονο-στοιχεικό πίνακα συμβολοσειράς. Αποθηκεύστε ή ανεβάστε την εικόνα με τη δοθείσα μορφή και αντικαταστήστε το `link[0]` με την αναφορά που πρέπει να εμφανιστεί στην έξοδο Markdown.

Οι πόροι που εκπονούνται σε μορφή SVG διαχειρίζονται ξεχωριστά. Καταγράψτε μια κλήση επιστροφής με τη μέθοδο [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/). Η κλήση επιστροφής `MarkdownSvgImageSavingHandler` λαμβάνει ένα αντικείμενο `ISvgImage` και τον μονο‑στοιχεικό πίνακα `link`. Ένα SVG δεν έχει όρισμα `ImageFormat`; γράψτε ή ανεβάστε τα XML δεδομένα του από τη μέθοδο `ISvgImage.getSvgData`. Ανάλογα με τη λειτουργία εξαγωγής και την οπτική ομαδοποίηση, ένα SVG στην πηγή παρουσίασης μπορεί να ραστεροποιηθεί ή να συνδυαστεί με άλλο περιεχόμενο· ο resulting μη‑SVG πόρος τότε περνά στη κλήση αποθήκευσης εικόνας. Καταγράψτε και τις δύο κλήσεις όταν κάθε εξαγόμενος οπτικός πόρος απαιτεί προσαρμοσμένη επεξεργασία.

Στο Node.js, δημιουργήστε υλοποιήσεις αυτών των διεπαφών κλήσεων επιστροφής με `java.newProxy`.

Η τιμή επιστροφής του χειριστή καθορίζει ποιος επεξεργάζεται την εικόνα:

- Επιστρέψτε `true` αφού ο χειριστής έχει αποθηκεύσει, ανεβάσει, μετασχηματίσει ή με οποιοδήποτε τρόπο επεξεργαστεί την εικόνα και έχει αναθέσει έγκυρη τιμή στο `link[0]`. Το Aspose.Slides γράφει αυτήν την τιμή στο έγγραφο Markdown και δεν εκτελεί την προεπιλεγμένη τοπική αποθήκευση.
- Επιστρέψτε `false` για να αφήσετε το Aspose.Slides να αποθηκεύσει την εικόνα τοπικά και να δημιουργήσει το σύνδεσμο σύμφωνα με τις τιμές που έχουν οριστεί από [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) και [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Ένας χειριστής που επιστρέφει `true` αναλαμβάνει την ευθύνη για την εικόνα. Αν επιστρέψει `true` χωρίς να αντιστοιχίσει έγκυρο, μη κενό σύνδεσμο, η εξαγωγή αποτυγχάνει με `InvalidOperationException`.
{{% /alert %}}

### **Αποθήκευση Εικόνων σε Κατάλογο Προέλευσης CDN και Χρήση Εξωτερικών URLs**

Το παρακάτω παράδειγμα θεωρεί το `cdn-origin/presentations/quarterly-report` ως συνδεδεμένο ή συγχρονισμένο κατάλογο προέλευσης CDN. Κάθε χειριστής εξάγει το όνομα του δημιουργημένου αρχείου, αποθηκεύει την εικόνα σε αυτόν τον προσαρμοσμένο κατάλογο και αντικαθιστά την τοπική αναφορά με δημόσιο URL CDN. Το ίδιο το δείγμα δεν πραγματοποιεί καμία δικτυακή μεταφόρτωση: το URL γίνεται έγκυρο μόνο αφού ο κατάλογος προσαρμοστεί ως προέλευση CDN ή τα αρχεία του δημοσιευτούν στο CDN. Για αποθήκευση αντικειμένων, αντικαταστήστε τη γραφή στο σύστημα αρχείων με την ενέργεια ανεβάσματος του SDK αποθήκευσης και αναθέστε `link[0]` μόνο μετά την επιτυχή μεταφόρτωση.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Ο χειριστής bitmap επιστρέφει σκόπιμα `false` για εικόνες μικρότερες από 128 × 128 pixel, ώστε το Aspose.Slides να αποθηκεύει αυτές τις εικόνες στο `output/fallback-images` χρησιμοποιώντας τη προεπιλεγμένη συμπεριφορά. Μεγαλύτεροι bitmap και metafile πόροι, καθώς και πόροι SVG, διαχειρίζονται από τον προσαρμοσμένο κώδικα. Για παράδειγμα, μια δημιουργημένη τοπική αναφορά όπως `fallback-images/image1.png` γίνεται `https://cdn.example.com/presentations/quarterly-report/image1.png`. Οι χειριστές χρησιμοποιούν διαδρομές λειτουργικού συστήματος μόνο όταν γράφουν αρχεία· τα συνδεδεμένα URLs στο Markdown χρησιμοποιούν μπροστιές κάθετες διαγωνίους και ονόματα αρχείων κωδικοποιημένα για URL. Εφαρμόστε τον ίδιο κανόνα κατά τη δημιουργία σχετικών συνδέσμων: χρησιμοποιήστε `/`, όχι το διαχωριστικό καταλόγου της πλατφόρμας.

## **Συχνές Ερωτήσεις**

**Μπορεί ένας χειριστής να επεξεργαστεί τόσο εικόνες raster όσο και SVG;**

Όχι. Χρησιμοποιήστε [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) για bitmap και metafile πόρους και [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) για πόρους που εκπονούνται ως SVG. Το πρώτο παρέχει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) και τιμή [ImageFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imageformat/). Το δεύτερο παρέχει ένα αντικείμενο `ISvgImage` του οποίου τα δεδομένα SVG μπορούν να διαβαστούν με `ISvgImage.getSvgData`. Ένα SVG πηγής που ραστεροποιείται κατά την εξαγωγή επεξεργάζεται από την κλήση αποθήκευσης εικόνας.

**Τι συμβαίνει όταν ένας χειριστής αποθήκευσης εικόνας επιστρέφει `false`;**

Το Aspose.Slides χρησιμοποιεί την προεπιλεγμένη τοπική αποθήκευση. Η θέση της εικόνας και η δημιουργημένη αναφορά ελέγχονται από τις τιμές που έχουν οριστεί με [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) και [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/).

**Μπορεί ένας χειριστής να παρέχει URL χωρίς να αποθηκεύει την εικόνα τοπικά;**

Ναι. Ο χειριστής μπορεί να ανεβάσει την εικόνα σε αποθήκη αντικειμένων ή να τη μεταβιβάσει σε άλλη υπηρεσία, να αναθέσει το προκύπτον URL στο `link[0]` και να επιστρέψει `true`. Ο χειριστής πρέπει να ολοκληρώσει την επεξεργασία μόνος του· η επιστροφή `true` εμποδίζει την προεπιλεγμένη τοπική αποθήκευση.

**Γιατί η εξαγωγή Markdown προκαλεί `InvalidOperationException` από έναν χειριστή;**

Αυτή η εξαίρεση εμφανίζεται όταν ο χειριστής επιστρέφει `true` αλλά δεν παρέχει έγκυρο σύνδεσμο. Αναθέστε το σχετικό μονοπάτι ή εξωτερικό URL που πρέπει να γραφτεί στο Markdown πριν επιστρέψετε `true`.

**Ποιος διαχωριστής διαδρομής πρέπει να χρησιμοποιούν οι σύνδεσμοι εικόνων;**

Χρησιμοποιήστε μπροστιές διαγωνίους (`/`) σε συνδέσμους Markdown και URLs. Χρησιμοποιήστε `path.join` μόνο για διαδρομές συστήματος αρχείων, έπειτα δημιουργήστε ή κανονικοποιήστε την αναφορά Markdown ξεχωριστά.

**Διατηρούνται οι υπερσυνδέσεις κατά την εξαγωγή Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/nodejs-java/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/nodejs-java/slide-transition/) και [animations](/slides/el/nodejs-java/powerpoint-animation/) των διαφανειών δεν μετατρέπονται.

**Μπορούν οι παρουσιάσεις να μετατραπούν σε Markdown παράλληλα;**

Μπορείτε να επεξεργαστείτε διαφορετικά αρχεία παρουσίασης παράλληλα, αλλά μην μοιράζεστε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) μεταξύ νημάτων. Ακολουθήστε τις [multithreading guidelines](/slides/el/nodejs-java/multithreading/) και χρησιμοποιήστε ξεχωριστό αντίγραφο για κάθε αρχείο.