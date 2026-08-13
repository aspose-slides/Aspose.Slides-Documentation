---
title: Βελτιστοποίηση Διαχείρισης Εικόνων στις Παρουσιάσεις με Java
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/java/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- προσθήκη bitmap
- αντικατάσταση εικόνας
- αντικατάσταση φωτογραφίας
- από το web
- φόντο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- εξωτερικοί πόροι SVG
- resolver SVG
- συνδεδεμένες εικόνες SVG
- γραμματοσειρές SVG
- προσθήκη EMF
- προσθήκη WMF
- προσθήκη TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Απλοποιήστε τη διαχείριση εικόνων στο PowerPoint και το OpenDocument με το Aspose.Slides for Java, βελτιώνοντας την απόδοση και αυτοματοποιώντας τη ροή εργασιών σας."
---
## **Εισαγωγή**

Οι εικόνες κάνουν τις παρουσιάσεις πιο ελκυστικές και οπτικά εντυπωσιακές. Στο Microsoft PowerPoint, μπορείτε να εισάγετε εικόνες στις διαφάνειες από αρχεία, το διαδίκτυο ή άλλες πηγές. Παρομοίως, το Aspose.Slides σας επιτρέπει να προσθέτετε εικόνες στις διαφάνειες παρουσίασης με διάφορους τρόπους.

{{% alert  title="Συμβουλή" color="info" %}} 

Το Aspose παρέχει δωρεάν μετατροπείς—[JPEG to PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG to PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που σας επιτρέπουν να δημιουργήσετε γρήγορα παρουσιάσεις από εικόνες. 

{{% /alert %}} 

{{% alert title="Πληροφορίες" color="info" %}}

Αν θέλετε να προσθέσετε μια εικόνα ως πλαίσιο εικόνας—ειδικά αν σκοπεύετε να αλλάξετε το μέγεθός της, να εφαρμόσετε εφέ ή να χρησιμοποιήσετε άλλες τυπικές επιλογές μορφοποίησης—δείτε το [Picture Frame](/slides/el/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Σημείωση" color="warning" %}}

Μπορείτε να μετατρέψετε εικόνες από μια μορφή σε άλλη. Δείτε τις παρακάτω σελίδες: μετατροπή [image to JPG](https://products.aspose.com/slides/el/java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/el/java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/el/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/el/java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/el/java/conversion/png-to-svg/), και [SVG to PNG](https://products.aspose.com/slides/el/java/conversion/svg-to-png/).

{{% /alert %}}

Το Aspose.Slides υποστηρίζει εικόνες σε δημοφιλείς μορφές όπως JPEG, PNG, BMP, GIF και άλλες. 

## **Προσθήκη Εικόνων που Αποθηκεύονται Τοπικά στις Διαφάνειες**

Μπορείτε να προσθέσετε μία ή περισσότερες εικόνες που αποθηκεύονται στον υπολογιστή σας σε μια διαφάνεια παρουσίασης. Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Προσθήκη Εικόνων από το Web στις Διαφάνειες**

Αν η εικόνα που θέλετε να προσθέσετε δεν είναι αποθηκευμένη στον υπολογιστή σας, μπορείτε να την προσθέσετε απευθείας από το web. 

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε μια εικόνα από το web σε μια διαφάνεια:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Προσθήκη Εικόνων σε Slide Masters**

Ένας slide master αποθηκεύει και ελέγχει πληροφορίες όπως το θέμα και η διάταξη για τις διαφάνειες που τον χρησιμοποιούν. Όταν προσθέτετε μια εικόνα σε έναν slide master, η εικόνα εμφανίζεται σε κάθε διαφάνεια που βασίζεται στον master αυτόν. 

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε μια εικόνα σε έναν slide master:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Προσθήκη Εικόνων ως Φόντο Διαφάνειας**

Μπορείτε να χρησιμοποιήσετε μια εικόνα ως φόντο για μία ή περισσότερες διαφάνειες. Για λεπτομέρειες, δείτε *[Setting Images as Backgrounds for Slides](/slides/el/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG σε Παρουσιάσεις**

Το περιεχόμενο SVG μπορεί να προστεθεί σε μια παρουσίαση χρησιμοποιώντας την κλάση [SvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/svgimage/). Το αποτέλεσμα, το αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/), μπορεί στη συνέχεια να προστεθεί στη συλλογή εικόνων της παρουσίασης και να χρησιμοποιηθεί για τη δημιουργία πλαισίου εικόνας.

Ο παρακάτω κώδικας Java εισάγει μια αυτοσυσκευασμένη αλυσίδα SVG. Όλες οι εικόνες, τα στυλ και άλλοι πόροι που χρησιμοποιεί αυτό το SVG είναι ενσωματωμένοι άμεσα στο περιεχόμενο του SVG.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εισαγωγή Περιεχομένου SVG με Εξωτερικούς Πόρους**

Αρχεία SVG που εξάγονται από εργαλεία σχεδίασης, επεξεργαστές διαγραμμάτων, συστήματα εικονιδίων και διαδικτυακές αλυσίδες μπορεί να αναφέρονται σε πόρους που αποθηκεύονται εκτός του εγγράφου SVG. Για παράδειγμα, ένα SVG μπορεί να περιέχει σύνδεσμο εικόνας όπως `images/photo.png`, μια τιμή CSS `url(...)`, ή μια διεύθυνση γραμματοσειράς.

Για να εισάγετε τέτοιο περιεχόμενο SVG, δημιουργήστε μια υλοποίηση του [IExternalResourceResolver](https://reference.aspose.com/slides/el/java/com.aspose.slides/iexternalresourceresolver/) και περάστε την, μαζί με μια base URI, σε κατάλληλο κατασκευαστή του [SvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/svgimage/). Η base URI προσδιορίζει τη θέση του εγγράφου SVG και χρησιμοποιείται για την επίλυση σχετικών συνδέσμων.

Η διεπαφή [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/) παρέχει πρόσβαση σε πληροφορίες σχετικά με το εισαχθέν SVG:

- `getSvgContent()` επιστρέφει το markup του SVG ως συμβολοσειρά.
- `getSvgData()` επιστρέφει το περιεχόμενο του SVG ως πίνακα byte.
- `getBaseUri()` επιστρέφει τη base URI που χρησιμοποιείται για σχετικούς συνδέσμους.
- `getExternalResourceResolver()` επιστρέφει τον resolver που έχει εκχωρηθεί στην εικόνα SVG.

### **Υλοποίηση Εξωτερικού Resolver Πόρων**

Ο resolver διαθέτει δύο μεθόδους:

- `resolveUri` συνδυάζει τη base URI με έναν σχετικό σύνδεσμο πόρου και επιστρέφει μια απόλυτη URI. Επιστρέψτε `null` όταν ο σύνδεσμος δεν μπορεί να επιλυθεί ή δεν επιτρέπεται.
- `getEntity` επιστρέφει ένα ρεύμα ανάγνωσης για μια απόλυτη URI πόρου. Επιστρέψτε `null` όταν ο πόρος λείπει, είναι αποκλεισμένος ή μη διαθέσιμος. Μπορεί επίσης να επιστραφεί εναλλακτικό ρεύμα όταν είναι σκόπιμο.

Ο παρακάτω resolver φορτώνει συνδεδεμένους πόρους μόνο από έναν επιτρεπόμενο τοπικό κατάλογο. Οι πόροι δικτύου και διαδρομές εκτός του επιτρεπόμενου καταλόγου αποκλείονται. Μια προαιρετική εναλλακτική εικόνα επιστρέφεται για αδιάλυτους συνδέσμους εικόνας.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Αυτός ο resolver επιτρέπει σκόπιμα μόνο τοπικά αρχεία.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Χρησιμοποιήστε εναλλακτικό μόνο για πόρους εικόνας. Η επιστροφή ρεύματος εικόνας
            // για μια ελλιπή γραμματοσειρά ή φύλλο στυλ δεν θα ήταν έγκυρη.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Επίλυση Συνδεδεμένων Πόρων Κατά τη Διάρκεια Εισαγωγής SVG**

Υποθέτουμε ότι το `assets/diagram.svg` περιέχει μια σχετική αναφορά όπως:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ο παρακάτω κώδικας Java περνά τη URI του αρχείου SVG ως base URI και παρέχει έναν προσαρμοσμένο resolver. Ο resolver μετατρέπει τον σχετικό σύνδεσμο εικόνας σε απόλυτη URI και επιστρέφει ένα ρεύμα που περιέχει τον συνδεδεμένο πόρο, ενώ το Aspose.Slides επεξεργάζεται το SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Η base URI αντιπροσωπεύει τη θέση του εγγράφου SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// Το ISvgImage εκθέτει το περιεχόμενο πηγής, τα δυαδικά δεδομένα, τη base URI και τον resolver.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η κλάση `SvgImage` παρέχει επίσης υπερφορτώσεις που δέχονται δεδομένα SVG ως πίνακα byte ή ως ρεύμα εισόδου, μαζί με έναν εξωτερικό resolver πόρων και μια base URI.

{{% alert title="Σημαντικό" color="warning" %}}

Ο resolver πόρων καθιστά διαθέσιμους εξωτερικούς πόρους ενώ το Aspose.Slides επεξεργάζεται και αποδίδει το SVG. Δεν τροποποιεί το αρχικό markup του SVG ούτε ενσωματώνει αυτόματα τους επιλυθέντες πόρους σε αυτό.

Όταν ένα `ISvgImage` προστίθεται στη συλλογή εικόνων της παρουσίασης, το αρχείο PPTX μπορεί να περιέχει τόσο τη αρχική αναπαράσταση SVG όσο και μια εναλλακτική raster εικόνα. Ένας συνδεδεμένος πόρος μπορεί να εμφανιστεί στην παραγόμενη εναλλακτική εικόνα, ενώ ένας σχετικός σύνδεσμος όπως `images/photo.png` παραμένει αμετάβλητος στο αποθηκευμένο SVG. Μια εφαρμογή που αποτυπώνει τη φυσική αναπαράσταση SVG μπορεί επομένως να παραλείψει το συνδεδεμένο περιεχόμενο όταν ο αρχικός εξωτερικός πόρος δεν είναι διαθέσιμος.

{{% /alert %}}

### **Δημιουργία Φορητής Εικόνας SVG**

Για να δημιουργήσετε μια εικόνα SVG που δεν εξαρτάται από εξωτερικά αρχεία, κάντε το SVG αυτοσυσκευασμένο πριν δημιουργήσετε το `SvgImage`. Για παράδειγμα, αντικαταστήστε τις συνδέσεις εικόνων με URI τύπου `data:` που περιέχουν τα δεδομένα της εικόνας:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Αφού ενσωματωθούν όλοι οι απαιτούμενοι πόροι στο περιεχόμενο του SVG, δημιουργήστε το `SvgImage`, προσθέστε το στη συλλογή εικόνων της παρουσίασης και τοποθετήστε το σε ένα πλαίσιο εικόνας όπως φαίνεται στο προηγούμενο παράδειγμα.

### **Διαχείριση Ελλιπών ή Αποκλεισμένων Πόρων**

Επιστρέψτε `null` από τη `resolveUri` όταν μια URI πόρου είναι άκυρη, απαγορευμένη ή δεν μπορεί να επιλυθεί. Επιστρέψτε `null` από τη `getEntity` όταν ο πόρος δεν μπορεί να διαβαστεί. Το Aspose.Slides συνεχίζει την επεξεργασία του SVG χωρίς αυτόν τον πόρο όταν είναι δυνατόν.

Μπορεί να επιστραφεί εναλλακτικό ρεύμα για έναν ελλιπές πόρο, αλλά το περιεχόμενό του πρέπει να είναι συμβατό με τον τύπο του ζητούμενου πόρου. Για παράδειγμα, επιστρέψτε ένα ρεύμα εικόνας μόνο για μια χαμένη εικόνα, όχι για γραμματοσειρά ή φύλλο στυλ.

{{% alert title="Ασφάλεια" color="warning" %}}

Μην επιλύετε αυθαίρετες διαδρομές αρχείων ή ανεξέλεγκτες URL δικτύου από μη αξιόπιστα αρχεία SVG. Περιορίστε τα επιτρεπόμενα σχήματα, καταλόγους και κεντρικούς υπολογιστές. Για πόρους δικτύου, εφαρμόστε επίσης χρονικά όρια σύνδεσης, όρια μεγέθους απάντησης και επικύρωση του περιεχομένου.

{{% /alert %}}

## **Μετατροπή SVG σε Σύνολο Σχημάτων**

Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε σύνολο σχημάτων, παρόμοια με τη λειτουργία που παρέχει το PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Αυτή η λειτουργία παρέχεται από μια υπερφόρτωση της μεθόδου [addGroupShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) της διεπαφής [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection) που δέχεται ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISvgImage) ως πρώτο όρισμα.

Ο παρακάτω κώδικας Java δείχνει πώς να χρησιμοποιήσετε αυτή τη μέθοδο για να μετατρέψετε ένα αρχείο SVG σε σύνολο σχημάτων:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Όνομα αρχείου πηγής SVG.
String svgFileName = "sample.svg";

// Όνομα αρχείου εξόδου παρουσίασης.
String outPptxPath = "presentation.pptx";

// Δημιουργία νέας παρουσίασης.
IPresentation presentation = new Presentation();
try {
    // Ανάγνωση περιεχομένου αρχείου SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Δημιουργία αντικειμένου SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Λήψη του μεγέθους της διαφάνειας.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Μετατροπή της εικόνας SVG σε ομάδα σχημάτων και κλιμάκωση στο μέγεθος της διαφάνειας.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Αποθήκευση της παρουσίασης σε μορφή PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Εικόνων ως EMF στις Διαφάνειες**

Το Aspose.Slides for Java σας επιτρέπει να δημιουργείτε εικόνες EMF από φύλλα εργασίας Excel με το Aspose.Cells και να τις προσθέτετε στις διαφάνειες παρουσίασης.

Ο παρακάτω κώδικας Java δείχνει πώς να το κάνετε:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Αποθήκευση του βιβλίου εργασίας σε ροή.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Προσθήκη του αρχείου όπως είναι ώστε η εικόνα να παραμείνει διανυσματικό EMF αντί να ψηφιοποιηθεί.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Αντικατάσταση Εικόνων στη Συλλογή Εικόνων**

Το Aspose.Slides σας επιτρέπει να αντικαθιστάτε εικόνες που βρίσκονται στη συλλογή εικόνων μιας παρουσίασης, συμπεριλαμβανομένων των εικόνων που χρησιμοποιούνται από σχήματα διαφάνειας. Η ενότητα αυτή περιγράφει διάφορους τρόπους ενημέρωσης των εικόνων στη συλλογή. Μπορείτε να αντικαταστήσετε μια εικόνα χρησιμοποιώντας ακατέργαστα δεδομένα byte, μια παρουσία του [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/), ή μια άλλη εικόνα που υπάρχει ήδη στη συλλογή.

Ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Φορτώστε μια νέα εικόνα από αρχείο σε έναν πίνακα byte.
1. Αντικαταστήστε την εικόνα-στόχο με τη νέα εικόνα χρησιμοποιώντας τον πίνακα byte.
1. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε αντικείμενο [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) και αντικαταστήστε την εικόνα-στόχο με αυτό το αντικείμενο.
1. Στην τρίτη προσέγγιση, αντικαταστήστε την εικόνα-στόχο με μια εικόνα που υπάρχει ήδη στη συλλογή εικόνων της παρουσίασης.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Δημιουργήστε μια αντικειμενοποίηση της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ο πρώτος τρόπος.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Ο δεύτερος τρόπος.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // Ο τρίτος τρόπος.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Αποθηκεύστε την παρουσίαση σε αρχείο.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Πληροφορίες" color="info" %}}

Με το δωρεάν εργαλείο μετατροπής [Text to GIF](https://products.aspose.app/slides/el/text-to-gif) του Aspose, μπορείτε εύκολα να δημιουργήσετε κινούμενα GIF από κείμενο. 

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Παραμένει η αρχική ανάλυση της εικόνας μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς κλιμακώνεται η [picture](/slides/el/java/picture-frame/) στη διαφάνεια και από τυχόν συμπίεση κατά την αποθήκευση.

**Ποιος είναι ο καλύτερος τρόπος να αντικαταστήσω το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στο master slide ή σε μια διάταξη και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης—οι αλλαγές θα εξαπλωθούν σε όλα τα στοιχεία που χρησιμοποιούν αυτόν τον πόρο.

**Μπορεί ένα εισαχθέν SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετά από τα οποία τα μεμονωμένα μέρη γίνονται επεξεργάσιμα με τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως φόντο για πολλές διαφάνειες ταυτόχρονα;**

[Αναθέστε την εικόνα ως φόντο](/slides/el/java/presentation-background/) στο master slide ή στην αντίστοιχη διάταξη—οποιεσδήποτε διαφάνειες χρησιμοποιούν αυτόν τον master/διάταξη θα κληρονομήσουν το φόντο.

**Πώς μπορώ να αποτρέψω μια παρουσίαση να μεγαλώσει υπερβολικά λόγω πολλών εικόνων;**

Επαναχρησιμοποιήστε έναν ενιαίο πόρο εικόνας αντί για διπλές, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και κρατήστε τα επαναλαμβανόμενα γραφικά στο master όταν είναι κατάλληλο.