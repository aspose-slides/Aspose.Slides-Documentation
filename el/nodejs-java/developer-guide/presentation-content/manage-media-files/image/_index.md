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
- προσθήκη EMF
- προσθήκη WMF
- προσθήκη TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Απλοποιήστε τη διαχείριση εικόνων σε PowerPoint και OpenDocument με JavaScript και Aspose.Slides για Node.js, βελτιώνοντας την απόδοση και αυτοματοποιώντας τη ροή εργασίας σας."
---
## **Εισαγωγή**

Οι εικόνες καθιστούν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες. Στο Microsoft PowerPoint, μπορείτε να εισάγετε εικόνες από αρχείο, το Διαδίκτυο ή άλλες τοποθεσίες στις διαφάνειες. Παρομοίως, το Aspose.Slides επιτρέπει την προσθήκη εικόνων στις διαφάνειες των παρουσιάσεών σας μέσω διαφορετικών διαδικασιών. 

{{% alert  title="Tip" color="primary" %}} 

Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG to PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG to PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Αν θέλετε να προσθέσετε μια εικόνα ως αντικείμενο πλαισίου—ιδιαίτερα αν σκοπεύετε να χρησιμοποιήσετε τις τυπικές επιλογές μορφοποίησης για να αλλάξετε το μέγεθός της, να προσθέσετε εφέ κ.λπ.—δείτε το [Picture Frame](https://docs.aspose.com/slides/el/nodejs-java/picture-frame/). 

{{% /alert %}} 

Το Aspose.Slides υποστηρίζει λειτουργίες με εικόνες σε αυτές τις δημοφιλείς μορφές: JPEG, PNG, GIF και άλλες. 

## **Προσθήκη Εικόνων που Αποθηκεύονται Τοπικά στις Διαφάνειες**

Μπορείτε να προσθέσετε μία ή περισσότερες εικόνες από τον υπολογιστή σας σε μια διαφάνεια μιας παρουσίασης. Αυτό το παράδειγμα κώδικα σε JavaScript δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη Εικόνων από Ροή στις Διαφάνειες**

Αν η εικόνα που θέλετε να προσθέσετε σε μια διαφάνεια δεν είναι διαθέσιμη στον υπολογιστή σας, μπορείτε να την προσθέσετε απευθείας από το διαδίκτυο.

Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε μια εικόνα από το διαδίκτυο σε μια διαφάνεια σε JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Φορτώνει ένα αρχείο Excel σε ροή
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Δημιουργεί ένα αντικείμενο δεδομένων για ενσωμάτωση
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Προσθέτει σχήμα Ole Object Frame
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη Εικόνων σε Κύριες Διαφάνειες**

Ένας master slide είναι η κορυφαία διαφάνεια που αποθηκεύει και ελέγχει πληροφορίες (θέμα, διάταξη κ.λπ.) για όλες τις διαφάνειες που βρίσκονται κάτω από αυτήν. Έτσι, όταν προσθέτετε μια εικόνα σε έναν master slide, η εικόνα αυτή εμφανίζεται σε κάθε διαφάνεια κάτω από αυτόν τον master slide.

Αυτό το παράδειγμα κώδικα JavaScript δείχνει πώς να προσθέσετε μια εικόνα σε έναν master slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη Εικόνων ως Φόντο Διαφάνειας**

Μπορείτε να αποφασίσετε να χρησιμοποιήσετε μια εικόνα ως φόντο για μια συγκεκριμένη διαφάνεια ή για πολλές διαφάνειες. Σε αυτήν την περίπτωση, πρέπει να δείτε το *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/el/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG σε Παρουσιάσεις**

Μπορείτε να προσθέσετε ή να εισάγετε οποιαδήποτε εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [addPictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) που ανήκει στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection).

Για να δημιουργήσετε ένα αντικείμενο εικόνας βασισμένο σε εικόνα SVG, μπορείτε να το κάνετε με αυτόν τον τρόπο:

1. Δημιουργήστε αντικείμενο SvgImage για να το εισάγετε στο ImageShapeCollection
2. Δημιουργήστε αντικείμενο PPImage από το ISvgImage
3. Δημιουργήστε αντικείμενο PictureFrame χρησιμοποιώντας την κλάση PPImage

Αυτό το παράδειγμα κώδικα δείχνει πώς να υλοποιήσετε τα παραπάνω βήματα για να προσθέσετε μια εικόνα SVG σε μια παρουσίαση:
```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Μετατροπή SVG σε Σύνολο Σχημάτων**

Η μετατροπή SVG σε σύνολο σχημάτων του Aspose.Slides είναι παρόμοια με τη λειτουργικότητα του PowerPoint που χρησιμοποιείται για την εργασία με εικόνες SVG:

![PowerPoint Popup Menu](img_01_01.png)

Η λειτουργία παρέχεται από μία από τις υπερφορτώσεις της μεθόδου [addGroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) της κλάσης [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection) που δέχεται ως πρώτο όρισμα ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SvgImage).

Αυτό το παράδειγμα κώδικα δείχνει πώς να χρησιμοποιήσετε τη περιγραφόμενη μέθοδο για να μετατρέψετε ένα αρχείο SVG σε σύνολο σχημάτων:

```javascript
// Δημιουργία νέας παρουσίασης
var presentation = new aspose.slides.Presentation();
try {
    // Ανάγνωση περιεχομένου αρχείου SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Δημιουργία αντικειμένου SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Λήψη μεγέθους διαφάνειας
    var slideSize = presentation.getSlideSize().getSize();
    // Μετατροπή εικόνας SVG σε ομάδα σχημάτων κλιμακώνοντάς τη στο μέγεθος της διαφάνειας
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Αποθήκευση παρουσίασης σε μορφή PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Προσθήκη Εικόνων ως EMF στις Διαφάνειες**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να δημιουργήσετε εικόνες EMF από φύλλα Excel και να προσθέσετε τις εικόνες ως EMF στις διαφάνειες με το Aspose.Cells. 

Αυτό το παράδειγμα κώδικα δείχνει πώς να εκτελέσετε την περιγραφόμενη εργασία:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αντικατάσταση Εικόνων στη Συλλογή Εικόνων**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε εικόνες που είναι αποθηκευμένες στη συλλογή εικόνων μιας παρουσίασης (συμπεριλαμβανομένων αυτών που χρησιμοποιούνται από σχήματα διαφανειών). Αυτή η ενότητα παρουσιάζει αρκετές προσεγγίσεις για την ενημέρωση των εικόνων στη συλλογή. Το API παρέχει απλές μεθόδους για την αντικατάσταση μιας εικόνας χρησιμοποιώντας ακατέργαστα δεδομένα byte, ένα στιγμιότυπο [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/), ή άλλη εικόνα που υπάρχει ήδη στη συλλογή.

Ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Φορτώστε μια νέα εικόνα από αρχείο σε έναν πίνακα byte.
3. Αντικαταστήστε την εικόνα-στόχο με τη νέα εικόνα χρησιμοποιώντας τον πίνακα byte.
4. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) και αντικαταστήστε την εικόνα-στόχο με αυτό το αντικείμενο.
5. Στην τρίτη προσέγγιση, αντικαταστήστε την εικόνα-στόχο με μια εικόνα που υπάρχει ήδη στη συλλογή εικόνων της παρουσίασης.
6. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```js
// Δημιουργία του αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Ο πρώτος τρόπος.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Ο δεύτερος τρόπος.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
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

Χρησιμοποιώντας το ΔΩΡΕΑΝ μετατροπέα Aspose [Text to GIF](https://products.aspose.app/slides/el/text-to-gif), μπορείτε εύκολα να δημιουργήσετε κείμενα σε κίνηση, να φτιάξετε GIF από κείμενα κ.λπ. 

{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Παραμένει η αρχική ανάλυση της εικόνας αμετάβλητη μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς η [picture](/slides/el/nodejs-java/picture-frame/) κλιμακώνεται στη διαφάνεια και από τυχόν συμπίεση που εφαρμόζεται κατά την αποθήκευση.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσετε το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στον master slide ή σε μια διάταξη και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης—οι ενημερώσεις θα διαδοθούν σε όλα τα στοιχεία που χρησιμοποιούν αυτόν τον πόρο.

**Μπορεί μια εισαχθείσα SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετά τα οποία τα επιμέρους μέρη γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως φόντο για πολλαπλές διαφάνειες ταυτόχρονα;**

[Ορίστε την εικόνα ως φόντο](/slides/el/nodejs-java/presentation-background/) στον master slide ή στην αντίστοιχη διάταξη—όλες οι διαφάνειες που χρησιμοποιούν αυτόν τον master/διάταξη θα κληρονομήσουν το φόντο.

**Πώς μπορώ να αποτρέψω την παρουσίαση να «φουσκώνει» σε μέγεθος λόγω πολλών εικόνων;**

Ξαναχρησιμοποιήστε έναν μόνο πόρο εικόνας αντί για διπλότυπα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και διατηρήστε τα επαναλαμβανόμενα γραφικά στον master όπου είναι κατάλληλο.