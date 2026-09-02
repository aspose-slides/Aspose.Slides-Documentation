---
title: Μετατροπή παρουσιάσεων PowerPoint σε Markdown σε Android
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/androidjava/convert-powerpoint-to-markdown/
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
- εξαγωγή εικόνας Markdown
- σύνδεσμοι εικόνας CDN
- PowerPoint
- παρουσίαση
- Markdown
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PPT και PPTX σε Markdown σε Android μέσω Java και ελέγξτε πού αποθηκεύονται και αναφέρονται οι εξαγόμενες εικόνες bitmap, metafile και SVG."
---
## **Επισκόπηση**

Το Aspose.Slides for Android μέσω Java μπορεί να μετατρέπει παρουσιάσεις PPT και PPTX σε Markdown για τεκμηρίωση, στατικούς ιστότοπους, μεταφορά περιεχομένου και ροές εργασίας ελέγχου έκδοσης. Μπορείτε να επιλέξετε μια γεύση Markdown, να ελέγξετε πώς αποδίδεται το περιεχόμενο των διαφανειών και να αποφασίσετε πού αποθηκεύονται οι εξαγόμενες εικόνες και πώς οι παραγόμενες αναφορές Markdown τις αναφέρουν.

Από προεπιλογή, η εξαγωγή σε Markdown χρησιμοποιεί μόνο κείμενο. Για να εξάγετε οπτικό περιεχόμενο, ορίστε τον τύπο εξαγώνας με τη μέθοδο [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) στο `Sequential` ή `Visual` τιμή από την απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownexporttype/). Το `Sequential` αποδίδει τα στοιχεία της διαφάνειας ξεχωριστά και διαδοχικά, ενώ το `Visual` διατηρεί τα ομαδοποιημένα στοιχεία μαζί για να διατηρήσει τη οπτική τους σχέση. Η τιμή `TextOnly` δεν δημιουργεί πόρους εικόνας, έτσι οι κλήσεις επιστροφής αποθήκευσης εικόνας δεν εκτελούνται σε αυτήν τη λειτουργία.

## **Μετατροπή παρουσίασης σε Markdown**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και στη συνέχεια καλέστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) με την τιμή `Md` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/).

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

## **Επιλογή γεύσης Markdown**

Η μέθοδος [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) ελέγχει τη προδιαγραφή Markdown που χρησιμοποιείται για την έξοδο. Η απαρίθμηση [Flavor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/flavor/) περιλαμβάνει CommonMark, GitHub Flavored Markdown και άλλες υποστηριζόμενες παραλλαγές.

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

## **Εξαγωγή εικόνων χρησιμοποιώντας τη προεπιλεγμένη συμπεριφορά τοπικής αποθήκευσης**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) παρέχει δύο μεθόδους για διαμόρφωση τοπικά αποθηκευμένων εικόνων:

- [setBasePath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) καθορίζει τον βασικό κατάλογο για το έγγραφο Markdown και τους πόρους του.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) καθορίζει τον υποκατάλογο εικόνων. Η προεπιλεγμένη τιμή του είναι `Images`.

Το παρακάτω παράδειγμα αποδίδει οπτικό περιεχόμενο, γράφει εικόνες στο `output/assets` και δημιουργεί σχετικές αναφορές εικόνας στο έγγραφο Markdown:

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

Αυτή η συμπεριφορά λειτουργεί επίσης ως εναλλακτική λύση όταν ένας προσαρμοσμένος χειριστής αποθήκευσης εικόνας επιστρέφει `false`.

## **Προσαρμογή αποθήκευσης εικόνας και συνδέσμων Markdown**

Χρησιμοποιήστε τη μέθοδο [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) για να καταχωρίσετε μια κλήση επιστροφής για πόρους bitmap και metafile μη‑SVG που εκτυπώνονται κατά την εξαγωγή σε Markdown. Η κλήση επιστροφής `MarkdownImageSavingHandler` λαμβάνει το αντικείμενο [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/), την τιμή του [ImageFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imageformat/) και τον παραγόμενο σύνδεσμο Markdown ως παράμετρο `String[]` μίας στοιχείου. Αποθηκεύστε ή ανεβάστε την εικόνα με τη δοθείσα μορφή και αντικαταστήστε το `link[0]` με την αναφορά που πρέπει να εμφανίζεται στην έξοδο Markdown.

Οι πόροι που εκτυπώνονται σε μορφή SVG χειρίζονται ξεχωριστά. Καταχωρίστε μια κλήση επιστροφής με τη μέθοδο [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/). Η κλήση επιστροφής `MarkdownSvgImageSavingHandler` λαμβάνει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgimage/) και την παράμετρο `String[] link` μίας στοιχείου. Ένα SVG δεν έχει όρισμα `ImageFormat`; γράψτε ή ανεβάστε τα XML δεδομένα του μέσω της μεθόδου [ISvgImage.getSvgData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgimage/) αντί αυτού. Ανάλογα με τη λειτουργία εξαγωγής και την οπτική ομαδοποίηση, ένα SVG στην πηγαία παρουσίαση μπορεί να ραστεριστεί ή να συνδυαστεί με άλλο περιεχόμενο· ο προκύπτων μη‑SVG πόρος στη συνέχεια περνιέται στην κλήση επιστροφής αποθήκευσης εικόνας. Καταχωρίστε και τις δύο κλήσεις όταν κάθε εξαγόμενο οπτικό πόρο απαιτεί προσαρμοσμένη επεξεργασία.

Η τιμή επιστροφής του χειριστή καθορίζει ποιος επεξεργάζεται την εικόνα:

- Επιστρέψτε `true` αφού ο χειριστής έχει αποθηκεύσει, ανεβάσει, μετασχηματίσει ή με οποιονδήποτε τρόπο επεξεργασθεί την εικόνα και έχει αντιστοιχίσει μια έγκυρη τιμή στο `link[0]`. Η Aspose.Slides γράφει αυτήν την τιμή στο έγγραφο Markdown και δεν εκτελεί την προεπιλεγμένη τοπική αποθήκευση.
- Επιστρέψτε `false` για να αφήσετε την Aspose.Slides να αποθηκεύσει την εικόνα τοπικά και να δημιουργήσει τον σύνδεσμο της σύμφωνα με τις τιμές που ορίστηκαν με [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) και [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Ένας χειριστής που επιστρέφει `true` αναλαμβάνει την ευθύνη για την εικόνα. Εάν επιστρέψει `true` χωρίς να αντιστοιχίσει μια έγκυρη, μη‑κενή αναφορά, η εξαγωγή αποτυγχάνει με `InvalidOperationException`.
{{% /alert %}}

### **Αποθήκευση εικόνων σε φάκελο προέλευσης CDN και χρήση εξωτερικών URL**

Το παρακάτω παράδειγμα θεωρεί το `cdn-origin/presentations/quarterly-report` ως τοποθετημένο ή συγχρονισμένο φάκελο προέλευσης CDN. Κάθε χειριστής εξάγει το δημιουργημένο όνομα αρχείου, αποθηκεύει την εικόνα σε εκείνο τον προσαρμοσμένο φάκελο και αντικαθιστά την τοπική αναφορά με ένα δημόσιο URL CDN. Το παράδειγμα από μόνο του δεν κάνει καμία δικτυακή μεταφόρτωση: το URL γίνεται έγκυρο μόνο αφού ο φάκελος τοποθετηθεί ως προέλευση CDN ή τα αρχεία του δημοσιευτούν στο CDN. Για αποθήκευση αντικειμένων, αντικαταστήστε τη γραφή στο σύστημα αρχείων με την ενέργεια μεταφόρτωσης του SDK αποθήκευσης και αντιστοιχίστε το `link[0]` μόνο μετά την επιτυχή μεταφόρτωση.

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

Ο χειριστής bitmap επιστρέφει σκόπιμα `false` για εικόνες μικρότερες από 128 × 128 pixel, έτσι η Aspose.Slides αποθηκεύει αυτές τις εικόνες στο `output/fallback-images` χρησιμοποιώντας τη προεπιλεγμένη συμπεριφορά. Μεγαλύτεροι πόροι bitmap και metafile, καθώς και πόροι SVG, επεξεργάζονται από τον προσαρμοσμένο κώδικα. Για παράδειγμα, μια τοπική αναφορά όπως `fallback-images/image1.png` γίνεται `https://cdn.example.com/presentations/quarterly-report/image1.png`. Οι χειριστές χρησιμοποιούν διαδρομές λειτουργικού συστήματος μόνο όταν γράφουν αρχεία· οι σύνδεσμοι που γράφονται στο Markdown χρησιμοποιούν κάθετους (forward) διαχωριστές και ονόματα αρχείων κωδικοποιημένα σε URL. Εφαρμόστε τον ίδιο κανόνα όταν δημιουργείτε σχετικούς συνδέσμους: χρησιμοποιήστε `/`, όχι το διαχωριστικό καταλόγου της πλατφόρμας.

## **Συχνές ερωτήσεις**

**Μπορεί ένας χειριστής να επεξεργαστεί και raster εικόνες και SVG εικόνες;**

Όχι. Χρησιμοποιήστε [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) για bitmap και metafile πόρους και [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) για πόρους που εκτυπώνονται ως SVG. Ο πρώτος παρέχει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) και μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imageformat/). Ο δεύτερος παρέχει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgimage/) του οποίου τα δεδομένα SVG μπορούν να διαβαστούν με το [ISvgImage.getSvgData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgimage/). Ένα πηγαίο SVG που ραστερίζεται κατά την εξαγωγή επεξεργάζεται από την κλήση επιστροφής αποθήκευσης εικόνας αντί αυτού.

**Τι συμβαίνει όταν ένας χειριστής αποθήκευσης εικόνας επιστρέφει `false`;**

Η Aspose.Slides χρησιμοποιεί τη προεπιλεγμένη συμπεριφορά τοπικής αποθήκευσης. Η θέση της εικόνας και η δημιουργούμενη αναφορά ελέγχονται από τις τιμές που ορίστηκαν με [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) και [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/).

**Μπορεί ένας χειριστής να παρέχει URL χωρίς να αποθηκεύσει την εικόνα τοπικά;**

Ναι. Ο χειριστής μπορεί να ανεβάσει την εικόνα σε αποθήκευση αντικειμένων ή να την περάσει σε άλλη υπηρεσία, να αντιστοιχίσει το παραγόμενο URL στο `link[0]` και να επιστρέψει `true`. Ο χειριστής πρέπει να ολοκληρώσει την επεξεργασία μόνος του· η επιστροφή `true` εμποδίζει την προεπιλεγμένη τοπική αποθήκευση.

**Γιατί η εξαγωγή Markdown προκαλεί `InvalidOperationException` από έναν χειριστή;**

Αυτή η εξαίρεση εμφανίζεται όταν ο χειριστής επιστρέφει `true` αλλά δεν παρέχει έγκυρο σύνδεσμο. Αντιστοιχίστε τη σχετική διαδρομή ή το εξωτερικό URL που πρέπει να γραφτεί στο Markdown πριν επιστρέψετε `true`.

**Ποιος διαχωριστής διαδρομής πρέπει να χρησιμοποιούν οι σύνδεσμοι εικόνων;**

Χρησιμοποιήστε κάθετους (forward) διαχωριστές στις συνδέσεις Markdown και στα URL. Χρησιμοποιήστε `Path.resolve` μόνο για διαδρομές συστήματος αρχείων, έπειτα δημιουργήστε ή κανονικοποιήστε την αναφορά Markdown ξεχωριστά.

**Διατηρούνται οι υπερσυνδέσεις κατά την εξαγωγή σε Markdown;**

Ναι. Οι κειμενικοί [hyperlinks](/slides/el/androidjava/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/androidjava/slide-transition/) και [animations](/slides/el/androidjava/powerpoint-animation/) των διαφανειών δεν μετατρέπονται.

**Μπορούν οι παρουσιάσεις να μετατραπούν σε Markdown ταυτόχρονα;**

Μπορείτε να επεξεργαστείτε διαφορετικά αρχεία παρουσίασης ταυτόχρονα, αλλά μην μοιράζεστε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) μεταξύ νημάτων. Ακολουθήστε τις [multithreading guidelines](/slides/el/androidjava/multithreading/) και χρησιμοποιήστε ξεχωριστό αντικείμενο για κάθε αρχείο.