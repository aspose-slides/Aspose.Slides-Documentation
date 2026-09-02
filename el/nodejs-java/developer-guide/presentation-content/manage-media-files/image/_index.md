---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/nodejs-java/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- αντικατάσταση εικόνας
- συλλογή εικόνων
- κάδρο εικόνας
- συνδεδεμένη εικόνα
- φόντο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- SVG σε σχήματα
- εξωτερικοί πόροι SVG
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να επαναχρησιμοποιείτε, να συνδέετε, να αντικαθιστάτε και να διαχειρίζεστε raster και SVG εικόνες σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Node.js μέσω Java."
---
## **Εισαγωγή**

Το Aspose.Slides για Node.js μέσω Java παρέχει αρκετούς τρόπους εργασίας με εικόνες, και κάθε ένας εξυπηρετεί διαφορετικό σκοπό. Μπορείτε να αποθηκεύσετε μια εικόνα σε μια παρουσίαση, να την εμφανίσετε σε ένα καρέ εικόνας, να τη χρησιμοποιήσετε ως φόντο διαφάνειας, να συνδέσετε σε εξωτερική εικόνα, να αντικαταστήσετε έναν κοινόχρηστο πόρο εικόνας ή να μετατρέψετε περιεχόμενο SVG σε επεξεργάσιμα σχήματα.

Αυτό το άρθρο εστιάζει στους πόρους εικόνας και στο πώς χρησιμοποιούνται σε μια παρουσίαση. Για περικοπή, διαφάνεια, εφέ, επέκταση και άλλες μορφοποιήσεις που εφαρμόζονται σε ένα μεμονωμένο καρέ εικόνας, δείτε [Καρέ εικόνας](/slides/el/nodejs-java/picture-frame/).

## **Κατανόηση του Μοντέλου Εικόνας**

Οι ακόλουθες έννοιες API σχετίζονται στενά αλλά δεν είναι εναλλάξιμες:

- Η [συλλογή εικόνων παρουσίασης](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagecollection/) αποθηκεύει τους πόρους εικόνας που χρησιμοποιεί η παρουσίαση. Χρησιμοποιήστε το [ImageCollection.addImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagecollection/) για να προσθέσετε δεδομένα εικόνας και να λάβετε έναν πόρο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/).
- Ένα [καρέ εικόνας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) είναι ένα σχήμα που εμφανίζει μια εικόνα σε μια διαφάνεια, διάταξη ή master. Χρησιμοποιήστε το [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/) για να τοποθετήσετε έναν πόρο εικόνας σε μια διαφάνεια.
- Το φόντο μιας διαφάνειας χρησιμοποιεί μια εικόνα ως μέρος της γέμισης της διαφάνειας αντί για σχήμα. Επομένως δεν συμπεριφέρεται όπως ένα καρέ εικόνας.
- Το [PPImage.replaceImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) αντικαθιστά έναν πόρο εικόνας. Εάν αρκετά στοιχεία παρουσίασης χρησιμοποιούν αυτόν τον πόρο, όλα χρησιμοποιούν την αντικατάσταση.
- Η μετατροπή ενός SVG σε σχήματα δημιουργεί επεξεργάσιμα σχήματα διαφάνειας. Μετά τη μετατροπή, το περιεχόμενο δεν διαχειρίζεται πλέον ως ένας ενιαίος πόρος εικόνας.

Έτσι, μια τυπική ροή εργασίας είναι: προσθέστε δεδομένα εικόνας στη συλλογή εικόνων, λάβετε ένα [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/), και στη συνέχεια χρησιμοποιήστε αυτόν τον πόρο σε ένα ή περισσότερα καρέ εικόνας ή γέμιση.

## **Προσθήκη ενσωματωμένης εικόνας**

Για να εισαγάγετε μια τοπική εικόνα, φορτώστε το αρχείο, προσθέστε το στη συλλογή εικόνων και δημιουργήστε ένα καρέ εικόνας που χρησιμοποιεί τον επιστρεφθέν πόρο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η εικόνα που προστέθηκε με αυτόν τον τρόπο είναι ενσωματωμένη στην παρουσίαση, έτσι το παραγόμενο αρχείο δεν εξαρτάται από τη διαθεσιμότητα του αρχικού αρχείου εικόνας.

### **Προσθήκη εικόνας από το Διαδίκτυο**

Όταν μια εικόνα είναι διαθέσιμη μέσω HTTP ή HTTPS, κατεβάστε τα byte της, προσθέστε τα στη συλλογή εικόνων της παρουσίασης και χρησιμοποιήστε τον επιστρεφθέν πόρο εικόνας με τον ίδιο τρόπο όπως μια τοπική εικόνα.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

Σε εφαρμογές μακράς διάρκειας, επαναχρησιμοποιήστε έναν πελάτη HTTP ή μια στρατηγική διαχείρισης συνδέσεων κατάλληλη για την εφαρμογή αντί να δημιουργείτε επανειλημμένα περιττές δικτυακές υποδομές. Επίσης, επαληθεύστε απομακρυσμένα URLs, τα μεγέθη των αποκρίσεων και τους τύπους περιεχομένου όταν η πηγή δεν είναι αξιόπιστη.

## **Επαναχρησιμοποίηση εικόνων σε πολλές διαφάνειες**

Αν η ίδια εικόνα απαιτείται περισσότερες από μία φορές, προσθέστε την στην παρουσίαση μία φορά και επαναχρησιμοποιήστε το επιστρεφθέν [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) κατά τη δημιουργία πρόσθετων καρέ εικόνας. Αυτό αποτρέπει τη συνεχή φόρτωση των ίδιων πηγαίων δεδομένων και κάνει τη σχέση μεταξύ του κοινόχρηστου πόρου εικόνας και των χρήσεων του σαφώς ορατή.

Για γραφικά που πρέπει να εμφανίζονται αυτόματα σε πολλές διαφάνειες, όπως το λογότυπο της εταιρείας, σκεφτείτε να τοποθετήσετε το καρέ εικόνας σε ένα [master διαφάνειας](/slides/el/nodejs-java/slide-master/) ή διάταξη αντί να προσθέτετε ένα ισοδύναμο σχήμα σε κάθε διαφάνεια.

## **Χρήση εικόνας ως φόντο διαφάνειας**

Μια εικόνα φόντου εκχωρείται στη γέμιση της διαφάνειας· δεν προστίθεται ως σχήμα καρέ εικόνας. Αυτό είναι χρήσιμο όταν η εικόνα πρέπει να καλύπτει το φόντο της διαφάνειας και δεν πρέπει να επεξεργάζεται ως κανονικό αντικείμενο διαφάνειας.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για πρόσθετες επιλογές φόντου, συμπεριλαμβανομένων φόντων master και διάταξης, δείτε [Φόντο Παρουσίασης](/slides/el/nodejs-java/presentation-background/).

## **Ενσωματωμένες και Συνδεδεμένες Εικόνες**

Οι ενσωματωμένες και οι συνδεδεμένες εικόνες έχουν διαφορετικές ανταλλαγές φορητότητας και μεγέθους αρχείου:

- **Ενσωματωμένη εικόνα:** τα δεδομένα της εικόνας αποθηκεύονται μέσα στην παρουσίαση. Η παρουσίαση είναι αυτόνομη, αλλά το μέγεθος του αρχείου περιλαμβάνει τα δεδομένα της εικόνας.
- **Συνδεδεμένη εικόνα:** η παρουσίαση αποθηκεύει μια διαδρομή ή URL σε εξωτερική εικόνα. Αυτό μπορεί να μειώσει το μέγεθος της παρουσίασης, αλλά ο εξωτερικός πόρος πρέπει να παραμένει προσβάσιμος όταν η παρουσίαση ανοίγεται ή αποδίδεται.

Μια συνδεδεμένη εικόνα μπορεί να δημιουργηθεί αναθέτοντας τη εξωτερική διαδρομή ή URL μέσω του [Picture.setLinkPathLong](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/) αντί να ενσωματώνετε τα δεδομένα της εικόνας.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε συνδεδεμένες εικόνες μόνο όταν το περιβάλλον ανάπτυξης μπορεί αξιόπιστα να έχει πρόσβαση στον εξωτερικό πόρο. Για παρουσιάσεις που πρέπει να λειτουργούν εκτός σύνδεσης ή να μετακινούνται μεταξύ συστημάτων, οι ενσωματωμένες εικόνες είναι συνήθως πιο ασφαλείς.

## **Εργασία με SVG Εικόνες**

Το SVG είναι μορφή διανυσματικού τύπου, επομένως μπορεί να είναι χρήσιμο για εικονίδια, διαγράμματα και άλλα γραφικά που πρέπει να κλιμακώνονται χωρίς την ίδια απώλεια λεπτομέρειας όπως οι raster εικόνες. Το Aspose.Slides υποστηρίζει το SVG τόσο ως πόρο εικόνας όσο και ως πηγή για επεξεργάσιμα σχήματα διαφάνειας.

### **Προσθήκη SVG ως εικόνα**

Δημιουργήστε ένα [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/), προσθέστε το στη συλλογή εικόνων και τοποθετήστε τον προκύπτων πόρο εικόνας σε ένα καρέ εικόνας.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Αρχεία SVG με εξωτερικούς πόρους**

Ένα SVG μπορεί να αναφέρει εξωτερικές εικόνες, φύλλα στιλ ή γραμματοσειρές. Για αυτές τις περιπτώσεις, το [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/) παρέχει κατασκευαστές που δέχονται έναν [ExternalResourceResolver](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/externalresourceresolver/) και μια βασική URI. Ο resolver μπορεί να χαρτογραφήσει μια σχετική URI σε μια επιτρεπόμενη απόλυτη URI και να επιστρέψει ένα ρεύμα για τον ζητούμενο πόρο.

Ο resolver καθιστά τους εξωτερικούς πόρους διαθέσιμους ενώ το Aspose.Slides επεξεργάζεται το SVG, αλλά δεν ξαναγράφει το SVG σε ένα αυτόνομα έγγραφο. Εάν το SVG πρέπει να παραμείνει φορητό, ενσωματώστε τους απαιτούμενους πόρους μέσα στο ίδιο το SVG, για παράδειγμα χρησιμοποιώντας URIs `data:` για συνδεδεμένες εικόνες.

Όταν τα αρχεία SVG προέρχονται από μη αξιόπιστες πηγές, περιορίστε τα σχήματα, τις θέσεις αρχείων και τους κεντρικούς υπολογιστές που μπορεί να προσπελάσει ο resolver. Οι resolver δικτύου θα πρέπει επίσης να εφαρμόζουν χρονικά όρια, όρια μεγέθους απάντησης και επαλήθευση περιεχομένου.

### **Μετατροπή SVG σε επεξεργάσιμα σχήματα**

Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε μια ομάδα επεξεργάσιμων σχημάτων διαφάνειας, παρόμοια με την αντίστοιχη εντολή του PowerPoint.

![Μενού αναδυόμενου παραθύρου PowerPoint](img_01_01.png)

Χρησιμοποιήστε την υπερφόρτωση του [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/) που δέχεται μια SVG εικόνα για να εκτελέσετε τη μετατροπή.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε τη μετατροπή SVG-σε-σχήματα όταν μεμονωμένα διάνυσμα στοιχεία χρειάζεται να επεξεργαστούν ως σχήματα PowerPoint. Εάν το SVG χρειάζεται μόνο να εμφανιστεί, η διατήρησή του ως εικόνα είναι πιο απλή και αποφεύγει τη δημιουργία πολλών ξεχωριστών σχημάτων.

## **Αντικατάσταση υπάρχοντος πόρου εικόνας**

Χρησιμοποιήστε το [PPImage.replaceImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) όταν θέλετε να αντικαταστήσετε έναν υπάρχοντα πόρο εικόνας. Αυτό είναι ιδιαίτερα χρήσιμο για κοινόχρηστα γραφικά όπως λογότυπα.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αν πολλά καρέ εικόνας, φόντα, master ή διατάξεις χρησιμοποιούν τον ίδιο πόρο εικόνας, η αντικατάσταση του πόρου ενημερώνει όλες αυτές τις χρήσεις. Εάν πρέπει να αλλάξει μόνο ένα καρέ εικόνας, αντιστοιχίστε μια διαφορετική εικόνα σε εκείνο το καρέ αντί να αντικαταστήσετε τον κοινόχρηστο πόρο.

Το [PPImage.replaceImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) παρέχει επίσης υπερφορτώσεις που δέχονται έναν πίνακα byte ή ένα άλλο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/).

## **Πρακτικές Συμβουλές Διαχείρισης Εικόνων**

### **Έλεγχος μεγέθους παρουσίασης**

Μεγάλες raster εικόνες μπορούν να κάνουν μια παρουσίαση περιττά μεγάλη. Χρησιμοποιήστε πηγαίες εικόνες με διαστάσεις κατάλληλες για το προοριζόμενο μέγεθος προβολής, επαναχρησιμοποιήστε κοινόχρηστους πόρους εικόνας όπου είναι δυνατόν και αποφύγετε την ενσωμάτωση επαναλαμβανόμενων αντιγράφων του ίδιου γραφικού σε πλήρη ανάλυση.

Για raster εικόνες που έχουν ήδη τοποθετηθεί σε καρέ εικόνας, το [PictureFillFormat.compressImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/) μπορεί να μειώσει τα δεδομένα εικόνας σύμφωνα με την επιλεγμένη ανάλυση και τις ρυθμίσεις περικοπής. Αυτό είναι επεξεργασία καρέ εικόνας και όχι διαχείριση συλλογής εικόνων, επομένως δείτε το [Καρέ εικόνας](/slides/el/nodejs-java/picture-frame/) για σχετιζόμενες λειτουργίες μορφοποίησης.

### **Επιλογή μεταξύ ενσωματωμένου και συνδεδεμένου περιεχομένου**

Η ενσωμάτωση κάνει την παρουσίαση φορητή επειδή όλα τα απαιτούμενα δεδομένα εικόνας μεταφέρονται με το αρχείο. Η σύνδεση μπορεί να μειώσει το μέγεθος του αρχείου, αλλά εισάγει μια εξωτερική εξάρτηση. Χρησιμοποιήστε συνδέσμους μόνο όταν αυτή η εξάρτηση είναι αποδεκτή και σταθερή.

### **Επαναχρησιμοποίηση κοινόχρηστων στοιχείων ταυτότητας**

Για επαναλαμβανόμενα λογότυπα, υδατογραφήματα ή διακοσμητικά γραφικά, χρησιμοποιήστε έναν πόρο εικόνας και επαναχρησιμοποιήστε τον. Εάν το γραφικό ανήκει στο σχεδιασμό της παρουσίασης και όχι στο περιεχόμενο των διαφανειών, τοποθετήστε το σε ένα master ή διάταξη ώστε να κληρονομείται από τις κατάλληλες διαφάνειες.

### **Διατήρηση φορητότητας των πόρων SVG**

Ένα αυτόνομο SVG είναι πιο εύκολο να μεταφερθεί και να αποδοθεί σταθερά από ένα SVG που εξαρτάται από εξωτερικά αρχεία ή δικτυακούς πόρους. Όταν είναι δυνατόν, ενσωματώστε τους απαιτούμενους πόρους πριν εισάγετε το SVG. Μετατρέψτε το SVG σε σχήματα μόνο όταν τα μεμονωμένα διανυσματικά στοιχεία χρειάζεται να επεξεργαστούν.

### **Χρήση του σύγχρονου διασυστηματικού API εικόνας**

Για νέο κώδικα Node.js μέσω Java, χρησιμοποιήστε τα API Aspose.Slides [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) και [Images](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/images/) αντί του παλαιού δημόσιου API που βασίζεται σε `java.awt.image.BufferedImage`. Δείτε το [Σύγχρονο API](/slides/el/nodejs-java/modern-api/) για οδηγίες μετάβασης.

Τα WMF και EMF απαιτούν ειδική προσοχή. Όταν αυτές οι μορφές περνούν μέσω ενός [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/), το [ImageCollection.addImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagecollection/) μετατρέπει το μετααρχείο σε μια raster αναπαράσταση PNG πριν την εισαγωγή. Εάν η διατήρηση των δεδομένων του μετααρχείου είναι σημαντική, χρησιμοποιήστε μια υπερφόρτωση του [ImageCollection.addImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagecollection/) βασισμένη σε ροή (stream). Η δημιουργία περιεχομένου EMF από λογιστικά φύλλα ή άλλα προϊόντα είναι ξεχωριστή διαδικασία ενσωμάτωσης και δεν καλύπτεται από αυτό το άρθρο.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ της συλλογής εικόνων και ενός καρέ εικόνας;**

Η συλλογή εικόνων αποθηκεύει επαναχρησιμοποιήσιμους πόρους εικόνας. Ένα καρέ εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει έναν από αυτούς τους πόρους και παρέχει μορφοποίηση ειδική για εικόνες όπως περικοπή και εφέ.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσετε το ίδιο λογότυπο παντού;**

Εάν το λογότυπο είναι ήδη κοινόχρηστο ως ένας πόρος εικόνας, αντικαταστήστε τον πόρο με το [PPImage.replaceImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/). Για branding σε όλη την παρουσίαση, η τοποθέτηση του λογότυπου σε ένα master ή διάταξη μπορεί επίσης να μειώσει το διπλό περιεχόμενο διαφανειών.

**Γιατί μια συνδεδεμένη εικόνα εξαφανίζεται σε άλλο υπολογιστή;**

Μια συνδεδεμένη εικόνα εξαρτάται από το εξωτερικό της αρχείο ή URL. Εάν αυτός ο πόρος δεν είναι προσβάσιμος από τον άλλο υπολογιστή, η συνδεδεμένη εικόνα μπορεί να μην είναι διαθέσιμη. Ενσωματώστε την εικόνα όταν η παρουσίαση πρέπει να είναι αυτόνομη.

**Μπορεί ένα εισαχθέν SVG να επεξεργαστεί ως σχήματα PowerPoint;**

Ναι. Μετατρέψτε το SVG με το [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/); η προκύπτουσα ομάδα περιέχει επεξεργάσιμα σχήματα διαφάνειας αντί για μία εικόνα SVG.

**Πώς μπορώ να διατηρήσω τις παρουσιάσεις με πολλές εικόνες μικρότερες;**

Επαναχρησιμοποιήστε κοινόχρηστους πόρους εικόνας, αποφύγετε υπερβολικά μεγάλες raster πηγές, συμπιέστε κατάλληλες raster εικόνες όταν είναι σκόπιμο, διατηρήστε επαναλαμβανόμενο branding σε master ή διατάξεις και χρησιμοποιήστε συνδεδεμένες εικόνες μόνο όταν μια εξωτερική εξάρτηση είναι αποδεκτή.