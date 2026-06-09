---
title: Export Presentations to HTML with Externally Linked Images
type: docs
weight: 100
url: /el/java/exporting-presentations-to-html-with-externally-linked-images/
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
- Java
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint και OpenDocument σε HTML με Java χρησιμοποιώντας το Aspose.Slides, με εικόνες και άλλους πόρους αποθηκευμένους ως εξωτερικά συνδεδεμένα αρχεία."
---
## **Επισκόπηση**

Από προεπιλογή, το Aspose.Slides εξάγει μια παρουσίαση σε ένα αυτόνομο αρχείο HTML. Οι εικόνες και άλλοι πόροι γράφονται άμεσα στο HTML, συνήθως ως δεδομένα Base64. Αυτό είναι βολικό όταν χρειάζεστε ένα φορητό αρχείο, αλλά δεν είναι πάντα η καλύτερη μορφή για έναν ιστότοπο, ένα CMS ή μια διαδικασία μετατροπής από την πλευρά του διακομιστή.

Χρησιμοποιήστε εξωτερικά συνδεδεμένους πόρους όταν θέλετε να:

- μειώσετε το μέγεθος του εγγράφου HTML·
- αποθηκεύσετε εικόνες, γραμματοσειρές, ήχο ή βίντεο ξεχωριστά σε προσαρτητή ή CDN·
- εξετάσετε, αντικαταστήσετε, συμπιέσετε ή μετα-επεξεργαστείτε τους παραγόμενους πόρους μετά την εξαγωγή·
- διατηρήσετε τη δομή εξόδου πιο κοντά σε αυτό που αναμένει μια web εφαρμογή.

Για τη γενική ροή εργασίας μετατροπής HTML, δείτε [Μετατροπή Παρουσιάσεων PowerPoint σε HTML](/slides/el/java/convert-powerpoint-to-html/). Αυτό το άρθρο εστιάζει στο τμήμα σύνδεσης πόρων της εξαγωγής.

## **Πώς Λειτουργεί η Εξαγωγή Συνδεδεμένων Πόρων**

[ILinkEmbedController](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) επιτρέπει στην εφαρμογή σας να αποφασίσει, πόρος ανά πόρο, εάν ο εξαγωγέας θα ενσωματώσει τα δεδομένα στο HTML ή θα τα αποθηκεύσει εξωτερικά και θα γράψει έναν σύνδεσμο.

Η διεπαφή έχει τρεις μεθόδους:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) αποφασίζει εάν ένας πόρος πρέπει να συνδεθεί ή να ενσωματωθεί·
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) επιστρέφει το URL που θα γραφτεί στο παραγόμενο HTML ή σε άλλον συνδεδεμένο πόρο·
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) γράφει τα δεδομένα του συνδεδεμένου πόρου στο δίσκο ή σε άλλο στόχο αποθήκευσης.

Η διαδρομή του συστήματος αρχείων και το URL του προσαρτητή είναι ξεχωριστά ζητήματα. Για παράδειγμα, το παρακάτω δείγμα γράφει αρχεία πόρων στο `html-output/assets` στο δίσκο, ενώ το HTML περιέχει σχετικές διευθύνσεις όπως `assets/resource-1.svg`. Ένας προσαρτητής επιλύει αυτές τις διευθύνσεις σχετικά με το αρχείο που περιέχει το σύνδεσμο. Συνεπώς, ένας σύνδεσμος από το `presentation.html` σε αρχείο SVG χρησιμοποιεί `assets/resource-1.svg`, ενώ ένας σύνδεσμος από εκείνο το αρχείο SVG σε εικόνα που αποθηκεύτηκε στον ίδιο φάκελο `assets` χρησιμοποιεί `resource-4.jpg`.

## **Εξαγωγή HTML με Συνδεδεμένους Πόρους**

Το παρακάτω παράδειγμα Java δημιουργεί έναν φάκελο εξόδου, αποθηκεύει εκεί το αρχείο HTML και αποθηκεύει τους συνδεδεμένους πόρους σε έναν υποφάκελο `assets`. Ο ελεγκτής συνδέει κοινές εικόνες, γραμματοσειρές, ήχο, βίντεο και πόρους CSS όταν το Aspose.Slides παρέχει ή μπορεί να συμπεράνει μία ασφαλή επέκταση αρχείου. Οι πόροι που δεν αναγνωρίζονται παραμένουν ενσωματωμένοι.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
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
            if (contentType != null && !contentType.trim().isEmpty()) {
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
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
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.ROOT);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.isEmpty()) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }
}
```

Μετά την εξαγωγή, ο φάκελος εξόδου έχει αυτή τη δομή:

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

Τα ακριβή αρχεία εξαρτώνται από το περιεχόμενο της παρουσίασης και τις επιλογές εξαγωγής. Για παράδειγμα, οι ραστερ εικόνες εξάγονται συνήθως ως JPEG ή PNG. Το Aspose.Slides μπορεί να επιλέξει διαφορετικό κωδικοποιητή εικόνας από αυτόν που χρησιμοποιείται στην πηγή παρουσίασης όταν αυτό παράγει μικρότερο ή πιο κατάλληλο αρχείο. Οι εικόνες με διαφάνεια εξάγονται ως PNG.

## **Επιλογή URL για Ανάπτυξη**

Το παράδειγμα χρησιμοποιεί ένα σχετικό πρόθεμα URL: `assets/`. Αν το `presentation.html` ανοιχτεί από το `html-output/presentation.html`, ο προσαρτητής φορτώνει το `html-output/assets/resource-1.svg`.

Όταν ένας συνδεδεμένος πόρος αναφέρεται σε άλλο συνδεδεμένο πόρο, το παράδειγμα χρησιμοποιεί την παράμετρο `referrer` στη [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) και επιστρέφει μόνο το όνομα αρχείου. Για παράδειγμα, αν τα `resource-1.svg` και `resource-4.jpg` βρίσκονται και τα δύο στον φάκελο `assets`, το αρχείο SVG πρέπει να αναφέρεται στο `resource-4.jpg`, όχι στο `assets/resource-4.jpg`.

Χρησιμοποιήστε διαφορετικό πρόθεμα URL όταν τα αρχεία αναπτύσσονται αλλού:

- Χρησιμοποιήστε `assets/` όταν ο φάκελος πόρων βρίσκεται δίπλα στο αρχείο HTML·
- Χρησιμοποιήστε `../assets/` όταν ο φάκελος πόρων είναι ένα επίπεδο πάνω από το αρχείο HTML·
- Χρησιμοποιήστε `https://cdn.example.com/presentations/job-123/assets/` όταν τα αρχεία ανεβαίνουν σε CDN ή σε στατικό διακομιστή αρχείων·

Το URL που επιστρέφεται από τη [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) πρέπει να ταιριάζει με την τελική τοποθεσία του αρχείου που γράφτηκε από τη [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/). Σε εφαρμογές διακομιστή, χρησιμοποιήστε έναν μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης αντικειμένων για κάθε εργασία μετατροπής ώστε να αποφύγετε την αντικατάσταση αρχείων από άλλη εξαγωγή.

## **Πότε να Ενσωματώσετε Αντί Για**

Το ενσωματωμένο Base64 HTML εξακολουθεί να είναι χρήσιμο όταν η έξοδος πρέπει να είναι ένα ενιαίο αρχείο, όπως συνημμένο email, offline προεπισκόπηση ή έγγραφο που θα μεταφερθεί χωρίς φάκελο πόρων. Οι συνδεδεμένοι πόροι είναι πιο κατάλληλοι όταν το HTML θα σερβιριστεί από μια web εφαρμογή, θα αποθηκευτεί σε CMS, θα βελτιστοποιηθεί από μια γραμμή κατασκευής ή θα αποθηκευτεί στην cache των προσαρτητών ανεξάρτητα από το HTML.

## **Συχνές Ερωτήσεις**

**Μπορώ να εξωτερικοποιήσω μόνο τις εικόνες και να διατηρήσω τους άλλους πόρους ενσωματωμένους;**

Ναι. Στη [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/), επιστρέψτε `LinkEmbedDecision.Link` μόνο για τους τύπους περιεχομένου που θέλετε να αποθηκευτούν ως ξεχωριστά αρχεία, και επιστρέψτε `LinkEmbedDecision.Embed` για όλα τα υπόλοιπα.

**Γιατί η επέκταση της εξαγόμενης εικόνας διαφέρει από αυτή της πηγής παρουσίασης;**

Το Aspose.Slides μπορεί να επανακωδικοποιήσει τις ραστερ εικόνες κατά τη διάρκεια της εξαγωγής HTML για να βελτιώσει το μέγεθος ή τη συμβατότητα με τον προσαρτητή. Για παράδειγμα, μια εικόνα από το αρχείο προέλευσης μπορεί να γραφτεί ως JPEG ή PNG ανάλογα με το αποτέλεσμα της απόδοσης.

**Λειτουργούν τα σχετικά URL μετά τη μετακίνηση του αρχείου HTML;**

Τα σχετικά URL λειτουργούν μόνο όταν η ίδια σχετική δομή φακέλων διατηρείται. Εάν το HTML αναφέρει το `assets/resource-1.png`, ο φάκελος `assets` πρέπει να παραμείνει δίπλα στο αρχείο HTML εκτός αν δημιουργήσετε διαφορετικό πρόθεμα URL.

**Θα πρέπει οι εφαρμογές διακομιστή να επαναχρησιμοποιούν τον ίδιο φάκελο εξόδου;**

Όχι. Χρησιμοποιήστε έναν μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης για κάθε εργασία μετατροπής. Έτσι αποφεύγονται συγκρούσεις ονομάτων αρχείων και αποτρέπεται μια εξαγωγή από το να αντικαταστήσει πόρους που έχουν δημιουργηθεί από άλλη εξαγωγή.