---
title: Μετατροπή παρουσιάσεων PowerPoint σε Markdown με Java
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PPT και PPTX σε Markdown με Java και ελέγξτε πού αποθηκεύονται και παραπέπονται οι εξαχθέντες bitmap, metafile και SVG εικόνες."
---
## **Επισκόπηση**

Το Aspose.Slides for Java μπορεί να μετατρέψει παρουσιάσεις PPT και PPTX σε Markdown για τεκμηρίωση, στατικούς ιστότοπους, μεταφορά περιεχομένου και διαδικασίες ελέγχου εκδόσεων. Μπορείτε να επιλέξετε μια παραλλαγή του Markdown, να ελέγξετε πώς αποδίδεται το περιεχόμενο των διαφανειών και να αποφασίσετε πού αποθηκεύονται οι εξαγόμενες εικόνες και πώς οι παραγόμενοι σύνδεσμοι Markdown τις αναφέρονται.

Από προεπιλογή, η εξαγωγή σε Markdown χρησιμοποιεί μόνο κειμενική έξοδο. Για να εξάγετε οπτικό περιεχόμενο, ορίστε τον τύπο εξαγωγής με τη μέθοδο [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) στο `Sequential` ή `Visual` από την απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownexporttype/). Το `Sequential` αποδίδει τα στοιχεία της διαφάνειας ξεχωριστά και με σειρά, ενώ το `Visual` διατηρεί τα ομαδοποιημένα στοιχεία μαζί για να διατηρήσει τη οπτική τους σχέση. Η τιμή `TextOnly` δεν εκπέμπει πόρους εικόνας, έτσι οι callbacks αποθήκευσης εικόνας δεν καλούνται σε αυτή τη λειτουργία.

## **Μετατροπή Παρουσίασης σε Markdown**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) και στη συνέχεια καλέστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) με την τιμή `Md` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Επιλογή Παραλλαγής Markdown**

Η μέθοδος [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) ελέγχει την προδιαγραφή Markdown που χρησιμοποιείται για την έξοδο. Η απαρίθμηση [Flavor](https://reference.aspose.com/slides/el/java/com.aspose.slides/flavor/) περιλαμβάνει CommonMark, GitHub Flavored Markdown και άλλες υποστηριζόμενες παραλλαγές.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση ως CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή Εικόνων Χρησιμοποιώντας την Προεπιλεγμένη Συμπεριφορά Τοπικής Αποθήκευσης**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) παρέχει δύο μεθόδους για τη διαμόρφωση τοπικά αποθηκευμένων εικόνων:

- [setBasePath](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) καθορίζει τον βασικό φάκελο για το έγγραφο Markdown και τους πόρους του.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) καθορίζει τον υποφάκελο εικόνων. Η προεπιλεγμένη τιμή του είναι `Images`.

Το παρακάτω παράδειγμα αποδίδει οπτικό περιεχόμενο, γράφει τις εικόνες στο `output/assets` και δημιουργεί σχετικές αναφορές εικόνας στο έγγραφο Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Αυτή η συμπεριφορά λειτουργεί επίσης ως εφεδρική όταν ένας προσαρμοσμένος χειριστής αποθήκευσης εικόνας επιστρέφει `false`.

## **Προσαρμογή Αποθήκευσης Εικόνας και Συνδέσμων Markdown**

Χρησιμοποιήστε τη μέθοδο [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) για να καταχωρήσετε ένα callback για πόρους bitmap και metafile μη‑SVG που εκπέμπονται κατά την εξαγωγή σε Markdown. Το callback `MarkdownImageSavingHandler` λαμβάνει το αντικείμενο [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/), την τιμή [ImageFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/imageformat/), και τον παραγόμενο σύνδεσμο Markdown ως παράμετρο `String[]` μίας στοιχείου. Αποθηκεύστε ή ανεβάστε την εικόνα με τη δοσμένη μορφή και αντικαταστήστε το `link[0]` με την αναφορά που πρέπει να εμφανίζεται στην έξοδο Markdown.

Οι πόροι που εκπέμπονται σε μορφή SVG αντιμετωπίζονται ξεχωριστά. Καταχωρήστε ένα callback με τη μέθοδο [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/). Το callback `MarkdownSvgImageSavingHandler` λαμβάνει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/) και την παράμετρο `String[] link` μίας στοιχείου. Ένα SVG δεν έχει όρισμα `ImageFormat`; γράψτε ή ανεβάστε τα XML δεδομένα του μέσω της μεθόδου [ISvgImage.getSvgData](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/). Ανάλογα με τη λειτουργία εξαγωγής και την οπτική ομαδοποίηση, ένα SVG στην πηγή παρουσίασης μπορεί να μετατραπεί σε raster ή να συνδυαστεί με άλλο περιεχόμενο· ο προκύπτων πόρος μη‑SVG στη συνέχεια περνά στο callback αποθήκευσης εικόνας. Καταχωρήστε και τα δύο callbacks όταν κάθε εξαγόμενος οπτικός πόρος απαιτεί προσαρμοσμένη επεξεργασία.

Η τιμή επιστροφής του handler καθορίζει ποιος επεξεργάζεται την εικόνα:

- Επιστρέψτε `true` αφού ο handler έχει αποθηκεύσει, ανεβάσει, μετασχηματίσει ή με οποιονδήποτε τρόπο επεξεργαστεί την εικόνα και έχει αντιστοιχίσει μια έγκυρη τιμή στο `link[0]`. Το Aspose.Slides γράφει αυτή τη τιμή στο έγγραφο Markdown και δεν εκτελεί την προεπιλεγμένη τοπική αποθήκευση.
- Επιστρέψτε `false` για να αφήσετε το Aspose.Slides να αποθηκεύσει την εικόνα τοπικά και να δημιουργήσει τον σύνδεσμό της σύμφωνα με τις τιμές που έχουν οριστεί με [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) και [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Ένας handler που επιστρέφει `true` αναλαμβάνει την ευθύνη για την εικόνα. Εάν επιστρέψει `true` χωρίς να αντιστοιχίσει μια έγκυρη, μη κενή σύνδεση, η εξαγωγή αποτυγχάνει με `InvalidOperationException`.
{{% /alert %}}

### **Αποθήκευση Εικόνων σε Κατάλογο Προέλευσης CDN και Χρήση Εξωτερικών URL**

Το παρακάτω παράδειγμα αντιμετωπίζει το `cdn-origin/presentations/quarterly-report` ως κατάλογο προέλευσης CDN που έχει προσαρτηθεί ή συγχρονιστεί. Κάθε handler εξάγει το παραγόμενο όνομα αρχείου, αποθηκεύει την εικόνα σε αυτόν τον προσαρμοσμένο φάκελο και αντικαθιστά την παραγόμενη τοπική αναφορά με ένα δημόσιο URL CDN. Το ίδιο το παράδειγμα δεν εκτελεί καμία μεταφόρτωση δικτύου: το URL γίνεται έγκυρο μόνο μετά τοποθέτηση του καταλόγου ως προέλευση CDN ή δημοσίευση των αρχείων του στο CDN. Για αποθήκευση αντικειμένων, αντικαταστήστε τη γραφή στο σύστημα αρχείων με την ενέργεια ανεβάσματος του SDK αποθήκευσης και αντιστοιχίστε το `link[0]` μόνο μετά την επιτυχή μεταφόρτωση.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Ο χειριστής bitmap επιστρέφει επίσθετα `false` για εικόνες μικρότερες των 128 × 128 pixel, έτσι το Aspose.Slides αποθηκεύει αυτές τις εικόνες στο `output/fallback-images` χρησιμοποιώντας την προεπιλεγμένη συμπεριφορά. Μεγαλύτεροι πόροι bitmap και metafile, καθώς και πόροι SVG, διαχειρίζονται από τον προσαρμοσμένο κώδικα. Για παράδειγμα, μια παραγόμενη τοπική αναφορά όπως `fallback-images/image1.png` γίνεται `https://cdn.example.com/presentations/quarterly-report/image1.png`. Οι handlers χρησιμοποιούν διαδρομές λειτουργικού συστήματος μόνο όταν γράφουν αρχεία· οι σύνδεσμοι που γράφονται στο Markdown χρησιμοποιούν μπροστιές κάθετες γραμμές και ονόματα αρχείων κωδικοποιημένα σε URL. Εφαρμόστε τον ίδιο κανόνα όταν δημιουργείτε σχετικούς συνδέσμους: χρησιμοποιήστε `/`, όχι το διαχωριστικό καταλόγου της πλατφόρμας.

## **Συχνές Ερωτήσεις**

**Μπορεί ένας handler να επεξεργαστεί τόσο bitmap εικόνες όσο και SVG εικόνες;**

Όχι. Χρησιμοποιήστε [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) για τους εκπεμπόμενους πόρους bitmap και metafile και [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) για τους πόρους που εκπέμπονται ως SVG. Ο πρώτος παρέχει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) και μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/imageformat/); ο δεύτερος παρέχει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/) του οποίου τα δεδομένα SVG μπορούν να διαβαστούν με [ISvgImage.getSvgData](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/). Ένα SVG προέλευσης που μετατρέπεται σε raster κατά την εξαγωγή επεξεργάζεται από το callback αποθήκευσης εικόνας.

**Τι συμβαίνει όταν ένας χειριστής αποθήκευσης εικόνας επιστρέφει `false`;**

Το Aspose.Slides χρησιμοποιεί την προεπιλεγμένη τοπική συμπεριφορά αποθήκευσης. Η θέση της εικόνας και η παραγόμενη αναφορά ελέγχονται από τις τιμές που έχουν οριστεί με [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) και [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/).

**Μπορεί ένας handler να παρέχει ένα URL χωρίς να αποθηκεύει την εικόνα τοπικά;**

Ναι. Ο handler μπορεί να ανεβάσει την εικόνα σε αποθήκευση αντικειμένων ή να τη μεταβιβάσει σε άλλη υπηρεσία, να αντιστοιχίσει το προκύπτω URL στο `link[0]` και να επιστρέψει `true`. Ο handler πρέπει να ολοκληρώσει την επεξεργασία μόνος του· η επιστροφή `true` εμποδίζει την προεπιλεγμένη τοπική αποθήκευση.

**Γιατί η εξαγωγή Markdown ρίχνει `InvalidOperationException` από έναν handler;**

Αυτή η εξαίρεση εμφανίζεται όταν ο handler επιστρέφει `true` αλλά δεν παρέχει έγκυρο σύνδεσμο. Αντιστοιχίστε το σχετικό μονοπάτι ή το εξωτερικό URL που πρέπει να γραφτεί στο Markdown πριν επιστρέψετε `true`.

**Ποιο διαχωριστικό διαδρομής πρέπει να χρησιμοποιούν οι σύνδεσμοι εικόνων;**

Χρησιμοποιήστε μπροστιές κάθετες γραμμές (`/`) στους συνδέσμους Markdown και στα URL. Χρησιμοποιήστε το `Path.resolve` μόνο για διαδρομές συστήματος αρχείων, στη συνέχεια δημιουργήστε ή κανονικοποιήστε την αναφορά Markdown χωριστά.

**Διατηρούνται οι υπερσύνδεσμοι κατά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/java/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/java/slide-transition/) και [animations](/slides/el/java/powerpoint-animation/) των διαφανειών δεν μετατρέπονται.

**Μπορούν οι παρουσιάσεις να μετατραπούν σε Markdown παράλληλα;**

Μπορείτε να επεξεργαστείτε διαφορετικά αρχεία παρουσίασης παράλληλα, αλλά μην μοιράζεστε την ίδια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) μεταξύ νημάτων. Ακολουθήστε τις [multithreading guidelines](/slides/el/java/multithreading/) και χρησιμοποιήστε ξεχωριστό στιγμιότυπο για κάθε αρχείο.