---
title: Εξαγωγή Παρουσιάσεων σε HTML με Εξωτερικά Συνδεδεμένες Εικόνες
type: docs
weight: 100
url: /el/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint και OpenDocument σε HTML σε Android μέσω Java χρησιμοποιώντας το Aspose.Slides, με εικόνες και άλλους πόρους αποθηκευμένους ως εξωτερικά συνδεδεμένα αρχεία."
---
## **Επισκόπηση**

Από προεπιλογή, το Aspose.Slides εξάγει μια παρουσίαση σε ένα αυτόνομο αρχείο HTML. Οι εικόνες και άλλοι πόροι γράφονται απευθείας στο HTML, συνήθως ως δεδομένα Base64. Αυτό είναι βολικό όταν χρειάζεστε ένα φορητό αρχείο, αλλά δεν είναι πάντα η καλύτερη μορφή για προβολή στο web, CMS ή διαδικασία μετατροπής στο διακομιστή που αργότερα δημοσιεύει το αποτέλεσμα.

Χρησιμοποιήστε εξωτερικά συνδεδεμένους πόρους όταν θέλετε να:

- μειώσετε το μέγεθος του εγγράφου HTML;
- αποθηκεύσετε στην cache εικόνες, γραμματοσειρές, ήχο ή βίντεο ξεχωριστά σε έναν περιηγητή ή CDN;
- ελέγξετε, αντικαταστήσετε, συμπιέσετε ή επεξεργαστείτε μεταγενέστερα τους παραγόμενους πόρους μετά την εξαγωγή;
- διατηρήσετε τη δομή του αποτελέσματος πιο κοντά σε αυτό που περιμένει μια web εφαρμογή.

Για τη γενική ροή μετατροπής HTML, δείτε [Μετατροπή παρουσιάσεων PowerPoint σε HTML](/slides/el/androidjava/convert-powerpoint-to-html/). Αυτό το άρθρο εστιάζει στο κομμάτι σύνδεσης πόρων της εξαγωγής.

## **Πώς λειτουργεί η εξαγωγή με συνδεδεμένους πόρους**

[ILinkEmbedController](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilinkembedcontroller/) επιτρέπει στην εφαρμογή σας να αποφασίζει, πόρος προς πόρο, αν ο εξαγωγέας ενσωματώνει τα δεδομένα στο HTML ή τα αποθηκεύει εξωτερικά και γράφει έναν σύνδεσμο.

Η διεπαφή έχει τρεις μεθόδους:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilinkembedcontroller/) αποφασίζει αν ένας πόρος θα πρέπει να συνδεθεί ή να ενσωματωθεί.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilinkembedcontroller/) επιστρέφει τη διεύθυνση URL που θα γραφτεί στο παραγόμενο HTML ή σε άλλον συνδεδεμένο πόρο.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilinkembedcontroller/) γράφει τα δεδομένα του συνδεδεμένου πόρου στον δίσκο ή σε άλλο στόχο αποθήκευσης.

Η διαδρομή του συστήματος αρχείων και η διεύθυνση URL του περιηγητή είναι ξεχωριστές προτεραιότητες. Για παράδειγμα, το παρακάτω δείγμα γράφει αρχεία πόρων στο `html-output/assets` στη αποθήκευση αρχείων της εφαρμογής, ενώ το HTML περιέχει σχετικές διευθύνσεις URL όπως `assets/resource-1.svg`. Ένας περιηγητής επιλύει αυτές τις διευθύνσεις URL σε σχέση με το αρχείο που περιέχει τον σύνδεσμο. Επομένως, ένας σύνδεσμος από το `presentation.html` σε ένα αρχείο SVG χρησιμοποιεί `assets/resource-1.svg`, ενώ ένας σύνδεσμος από αυτό το αρχείο SVG σε μια εικόνα που αποθηκεύεται στον ίδιο φάκελο `assets` χρησιμοποιεί `resource-4.jpg`.

## **Εξαγωγή HTML με συνδεδεμένους πόρους**

Το παρακάτω παράδειγμα Android Java δημιουργεί έναν φάκελο εξόδου, αποθηκεύει το αρχείο HTML εκεί, και αποθηκεύει τους συνδεδεμένους πόρους σε έναν υποφάκελο `assets`. Δώστε έναν φάκελο που ανήκει στην εφαρμογή, όπως `context.getFilesDir()`, ως `applicationFilesDirectory`. Ο κώδικας αποφεύγει τις API `java.nio.file`, ώστε να παραμένει συμβατός με Android `minSdk` 19.

Ο ελεγκτής συνδέει κοινές εικόνες, γραμματοσειρές, ήχους, βίντεο και πόρους CSS όταν το Aspose.Slides παρέχει ή μπορεί να συμπεράνει μια ασφαλή επέκταση αρχείου. Οι πόροι που δεν αναγνωρίζονται παραμένουν ενσωματωμένοι.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
            this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        }

        @Override
        public int getObjectStoringLocation(
                int resourceId,
                byte[] entityData,
                String semanticName,
                String contentType,
                String recommendedExtension) {
            String extension = resolveExtension(contentType, recommendedExtension);
            if (extension == null) {
                return LinkEmbedDecision.Embed;
            }

            fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
            return LinkEmbedDecision.Link;
        }

        @Override
        public String getUrl(int resourceId, int referrer) {
            String fileName = fileNamesByResourceId.get(resourceId);
            if (fileName == null) {
                return null;
            }

            if (fileNamesByResourceId.containsKey(referrer)) {
                return fileName;
            }

            return assetUrlPrefix + fileName;
        }

        @Override
        public void saveExternal(int resourceId, byte[] entityData) {
            String fileName = fileNamesByResourceId.get(resourceId);
            if (fileName == null) {
                throw new IllegalStateException(
                        "Resource " + resourceId + " was not registered for external storage.");
            }

            if (entityData == null || entityData.length == 0) {
                throw new IllegalStateException(
                        "Resource " + resourceId + " contains no data and cannot be saved.");
            }

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
        }

        private static String resolveExtension(String contentType, String recommendedExtension) {
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
                if (mappedExtension != null) {
                    return mappedExtension;
                }
            }

            if (!isSupportedContentType(contentType)) {
                return null;
            }

            return normalizeExtension(recommendedExtension);
        }

        private static boolean isSupportedContentType(String contentType) {
            return contentType != null &&
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
        }
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

Τα ακριβή αρχεία εξαρτώνται από το περιεχόμενο της παρουσίασης και τις επιλογές εξαγωγής. Για παράδειγμα, οι ραστροειδείς εικόνες εξάγονται συνήθως ως JPEG ή PNG. Το Aspose.Slides μπορεί να επιλέξει διαφορετικό κωδικοποιητή εικόνας από αυτόν που χρησιμοποιείται στην πηγαία παρουσίαση όταν αυτό παράγει μικρότερο ή πιο κατάλληλο αρχείο. Οι εικόνες με διαφάνεια εξάγονται ως PNG.

## **Επιλογή διευθύνσεων URL για Ανάπτυξη**

Το δείγμα χρησιμοποιεί ένα σχετικό πρόθεμα URL: `assets/`. Αν το `presentation.html` ανοίξει από το `html-output/presentation.html`, ο περιηγητής φορτώνει το `html-output/assets/resource-1.svg`.

Όταν ένας συνδεδεμένος πόρος αναφέρεται σε άλλο συνδεδεμένο πόρο, το δείγμα χρησιμοποιεί την παράμετρο `referrer` στη [ILinkEmbedController.getUrl] και επιστρέφει μόνο το όνομα αρχείου. Για παράδειγμα, εάν τα `resource-1.svg` και `resource-4.jpg` βρίσκονται και τα δύο στον φάκελο `assets`, το αρχείο SVG πρέπει να αναφέρεται στο `resource-4.jpg`, όχι στο `assets/resource-4.jpg`.

Χρησιμοποιήστε διαφορετικό πρόθεμα URL όταν τα αρχεία αναπτύσσονται αλλού:

- Χρησιμοποιήστε `assets/` όταν ο φάκελος περιουσιακών στοιχείων βρίσκεται δίπλα στο αρχείο HTML.
- Χρησιμοποιήστε `../assets/` όταν ο φάκελος περιουσιακών στοιχείων βρίσκεται ένα επίπεδο πάνω από το αρχείο HTML.
- Χρησιμοποιήστε `https://cdn.example.com/presentations/job-123/assets/` όταν τα αρχεία ανεβαίνουν σε CDN ή σε στατικό διακομιστή αρχείων.

Η διεύθυνση URL που επιστρέφεται από τη [ILinkEmbedController.getUrl] πρέπει να ταιριάζει με την τελική τοποθεσία του αρχείου που γράφεται από τη [ILinkEmbedController.saveExternal]. Σε εφαρμογές Android, χρησιμοποιήστε αποθήκευση ειδική για την εφαρμογή, φάκελο cache ή φάκελο που προέρχεται από το Storage Access Framework ανάλογα με τη ροή εργασίας δημοσίευσής σας. Σε εφαρμογές διακομιστή, χρησιμοποιήστε μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης αντικειμένων για κάθε εργασία μετατροπής ώστε να αποφεύγετε την αντικατάσταση αρχείων από άλλη εξαγωγή.

## **Πότε να ενσωματώσετε αντί αυτού**

Το ενσωματωμένο Base64 HTML είναι ακόμα χρήσιμο όταν το αποτέλεσμα πρέπει να είναι ένα μόνο αρχείο, όπως ένα συνημμένο email, μια προεπισκόπηση εκτός σύνδεσης ή ένα έγγραφο που θα μετακινηθεί χωρίς φάκελο περιουσιακών στοιχείων. Οι συνδεδεμένοι πόροι είναι πιο κατάλληλοι όταν το HTML θα εξυπηρετείται από μια web εφαρμογή, αποθηκεύεται σε CMS, βελτιστοποιείται από pipeline κατασκευής ή αποθηκεύεται στην cache των περιηγητών ανεξάρτητα από το HTML.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να εξωτερικεύσω μόνο εικόνες και να διατηρήσω τους άλλους πόρους ενσωματωμένους;**

Ναι. Στη [ILinkEmbedController.getObjectStoringLocation], επιστρέψτε `Link` από το [LinkEmbedDecision] μόνο για τους τύπους περιεχομένου που θέλετε να αποθηκεύσετε ως ξεχωριστά αρχεία, και επιστρέψτε `Embed` για όλα τα άλλα.

**Γιατί η εξαγόμενη επέκταση εικόνας διαφέρει από την πηγαία παρουσίαση;**

Το Aspose.Slides μπορεί να κωδικοποιήσει εκ νέου τις ραστροειδείς εικόνες κατά την εξαγωγή HTML για να βελτιώσει το μέγεθος ή τη συμβατότητα με τους περιηγητές. Για παράδειγμα, μια εικόνα από το πηγαίο αρχείο μπορεί να γραφτεί ως JPEG ή PNG ανάλογα με το αποτέλεσμα απόδοσης.

**Λειτουργούν οι σχετικές διευθύνσεις URL μετά τη μετακίνηση του αρχείου HTML;**

Οι σχετικές διευθύνσεις URL λειτουργούν μόνο όταν διατηρείται η ίδια σχετική δομή φακέλων. Εάν το HTML αναφέρει `assets/resource-1.png`, ο φάκελος `assets` πρέπει να παραμείνει δίπλα στο αρχείο HTML εκτός εάν δημιουργήσετε διαφορετικό πρόθεμα URL.

**Μπορώ να γράψω πόρους σε δημόσια εξωτερική αποθήκευση στο Android;**

Ναι, εφόσον η εφαρμογή σας διαθέτει έγκυρο προορισμό και μοντέλο δικαιωμάτων για την έκδοση Android-στόχο. Για παραγόμενο HTML που χρησιμοποιείται μόνο από την εφαρμογή σας, τα αρχεία ειδικά για την εφαρμογή ή οι φάκελοι cache είναι συνήθως πιο απλοί. Για έξοδο ορατή στον χρήστη, χρησιμοποιήστε τοποθεσία που επιλέγει ο χρήστης ή άλλη προσέγγιση αποθήκευσης που ταιριάζει στην εφαρμογή σας.

**Πρέπει οι εφαρμογές διακομιστή να επαναχρησιμοποιούν τον ίδιο φάκελο εξόδου;**

Όχι. Χρησιμοποιήστε μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης για κάθε εργασία μετατροπής. Αυτό αποτρέπει συγκρούσεις ονομάτων αρχείων και εμποδίζει μία εξαγωγή από το να αντικαταστήσει πόρους που δημιουργήθηκαν από άλλη εξαγωγή.