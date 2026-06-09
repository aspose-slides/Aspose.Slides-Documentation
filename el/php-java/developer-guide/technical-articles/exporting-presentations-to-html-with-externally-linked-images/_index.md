---
title: Εξαγωγή παρουσιάσεων σε HTML με εξωτερικά συνδεδεμένες εικόνες
type: docs
weight: 100
url: /el/php-java/exporting-presentations-to-html-with-externally-linked-images/
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
- PHP
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint και OpenDocument σε HTML σε PHP μέσω Java χρησιμοποιώντας το Aspose.Slides, με εικόνες και άλλους πόρους αποθηκευμένους ως εξωτερικά συνδεδεμένα αρχεία."
---
## **Επισκόπηση**

Από προεπιλογή, το Aspose.Slides εξάγει μια παρουσίαση σε ένα αυτόνομο αρχείο HTML. Οι εικόνες και άλλοι πόροι εγγράφονται απευθείας στο HTML, συνήθως ως δεδομένα Base64. Αυτό είναι βολικό όταν χρειάζεστε ένα μόνο φορητό αρχείο, αλλά δεν είναι πάντα η καλύτερη μορφή για ιστοσελίδα, CMS ή διακομιστή μετατροπής.

Χρησιμοποιήστε εξωτερικά συνδεδεμένους πόρους όταν θέλετε να:

- μειώσετε το μέγεθος του εγγράφου HTML·
- αποθηκεύσετε στην cache εικόνες, γραμματοσειρές, ήχους ή βίντεο ξεχωριστά σε πρόγραμμα περιήγησης ή CDN·
- επιθεωρήσετε, αντικαταστήσετε, συμπιέσετε ή επεξεργαστείτε μετά την εξαγωγή τους·
- διατηρήσετε τη δομή εξόδου πιο κοντά σε αυτό που αναμένει μια διαδικτυακή εφαρμογή.

Για τη γενική ροή εργασίας μετατροπής σε HTML, δείτε [Μετατροπή Παρουσιάσεων PowerPoint σε HTML](/slides/el/php-java/convert-powerpoint-to-html/). Αυτό το άρθρο εστιάζει στο τμήμα σύνδεσης πόρων της εξαγωγής.

## **Πώς Λειτουργεί η Εξαγωγή με Συνδεδεμένους Πόρους**

[HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/) μπορεί να χρησιμοποιήσει έναν προσαρμοσμένο ελεγκτή σύνδεσης/ενσωμάτωσης όταν το Aspose.Slides εξάγει μια παρουσίαση σε HTML. Στο PHP μέσω Java, αυτό το σενάριο υλοποιείται συνήθως με μια μικρή βοηθητική κλάση Java. Συναρμολογήστε τη βοηθητική κλάση, προσθέστε την στο classpath της PHP Java Bridge και δημιουργήστε την από PHP με `new Java(...)`.

Η βοηθητική κλάση αποφασίζει, πόρος κατά πόρο, αν ο εξαγωγέας ενσωματώνει τα δεδομένα στο HTML ή τα αποθηκεύει εξωτερικά και γράφει έναν σύνδεσμο. Χρειάζεται τρεις μεθόδους callback:

- `ExternalResourceController.getObjectStoringLocation` αποφασίζει αν ένας πόρος πρέπει να συνδεθεί ή να ενσωματωθεί.
- `ExternalResourceController.getUrl` επιστρέφει τη διεύθυνση URL που θα γραφτεί στο παραγόμενο HTML ή σε άλλον συνδεδεμένο πόρο.
- `ExternalResourceController.saveExternal` γράφει τα δεδομένα του συνδεδεμένου πόρου στο δίσκο ή σε άλλο αποθηκευτικό στόχο.

Η διαδρομή του συστήματος αρχείων και η διεύθυνση URL του προγράμματος περιήγησης είναι ξεχωριστά ζητήματα. Για παράδειγμα, το παρακάτω δείγμα γράφει αρχεία πόρων στο `html-output/assets` στο δίσκο, ενώ το HTML περιέχει σχετικές URL όπως `assets/resource-1.svg`. Ένας περιηγητής επιλύει αυτές τις URL σχετικά με το αρχείο που περιέχει το σύνδεσμο. Συνεπώς, ένας σύνδεσμος από `presentation.html` προς ένα αρχείο SVG χρησιμοποιεί `assets/resource-1.svg`, ενώ ένας σύνδεσμος από αυτό το αρχείο SVG προς μια εικόνα που βρίσκεται στον ίδιο φάκελο `assets` χρησιμοποιεί `resource-4.jpg`.

## **Δημιουργία της Βοηθητικής Κλάσης Java**

Δημιουργήστε μια κλάση Java όπως `com.example.slides.ExternalResourceController`, συναρμολογήστε την με το Aspose.Slides for Java στο classpath, και κάντε τη διαθέσιμη στο PHP Java Bridge.

Η παρακάτω βοηθητική κλάση συνδέει κοινά εικόνες, γραμματοσειρές, ήχους, βίντεο και πόρους CSS όταν το Aspose.Slides παρέχει ή μπορεί να προβλέψει ασφαλή επέκταση αρχείου. Πόροι που δεν αναγνωρίζονται παραμένουν ενσωματωμένοι.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
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

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
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
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
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
```

## **Εξαγωγή HTML με Συνδεδεμένους Πόρους**

Ο παρακάτω κώδικας PHP δημιουργεί έναν φάκελο εξόδου, αποθηκεύει το αρχείο HTML εκεί και αποθηκεύει τους συνδεδεμένους πόρους σε έναν υποφάκελο `assets`. Συνδυάζει [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideimageformat/) και [SaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/) για την εξαγωγή.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
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

Τα ακριβή αρχεία εξαρτώνται από το περιεχόμενο της παρουσίασης και τις επιλογές εξαγωγής. Για παράδειγμα, οι ραστερ εικόνες συνήθως εξάγονται ως JPEG ή PNG. Το Aspose.Slides μπορεί να επιλέξει διαφορετικό κωδικοποιητή εικόνας από αυτόν που χρησιμοποιείται στην πηγαία παρουσίαση όταν αυτό παράγει μικρότερο ή πιο κατάλληλο αρχείο. Εικόνες με διαφάνεια εξάγονται ως PNG.

## **Επιλογή URL για Ανάπτυξη**

Το δείγμα χρησιμοποιεί ένα σχετικό πρόθεμα URL: `assets/`. Αν το `presentation.html` ανοίξει από `html-output/presentation.html`, ο περιηγητής φορτώνει το `html-output/assets/resource-1.svg`.

Όταν ένας συνδεδεμένος πόρος παραπέμπει σε άλλο συνδεδεμένο πόρο, το δείγμα χρησιμοποιεί την παράμετρο `referrer` στη `ExternalResourceController.getUrl` και επιστρέφει μόνο το όνομα αρχείου. Για παράδειγμα, αν το `resource-1.svg` και το `resource-4.jpg` βρίσκονται και τα δύο στον φάκελο `assets`, το αρχείο SVG πρέπει να αναφέρεται στο `resource-4.jpg`, όχι στο `assets/resource-4.jpg`.

Χρησιμοποιήστε διαφορετικό πρόθεμα URL όταν τα αρχεία αναπτύσσονται αλλού:

- Χρησιμοποιήστε `assets/` όταν ο φάκελος των πόρων βρίσκεται δίπλα στο αρχείο HTML.
- Χρησιμοποιήστε `../assets/` όταν ο φάκελος των πόρων είναι ένα επίπεδο πάνω από το αρχείο HTML.
- Χρησιμοποιήστε `https://cdn.example.com/presentations/job-123/assets/` όταν τα αρχεία ανεβάζονται σε CDN ή σε στατικό διακομιστή αρχείων.

Το URL που επιστρέφει η `ExternalResourceController.getUrl` πρέπει να ταιριάζει με την τελική τοποθεσία που έχει αναπτυχθεί το αρχείο που γράφτηκε από τη `ExternalResourceController.saveExternal`. Σε εφαρμογές διακομιστή, χρησιμοποιήστε μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης αντικειμένων για κάθε εργασία μετατροπής ώστε να αποφεύγεται η αντικατάσταση αρχείων από άλλη εξαγωγή.

## **Πότε Να Ενσωματώσετε Αντί Για Σύνδεση**

Η ενσωματωμένη Base64 HTML είναι χρήσιμη όταν η έξοδος πρέπει να είναι ένα μόνο αρχείο, όπως επισύναψη email, εκτός σύνδεσης προεπισκόπηση ή έγγραφο που θα μετακινηθεί χωρίς φάκελο πόρων. Οι συνδεδεμένοι πόροι είναι πιο κατάλληλοι όταν το HTML θα σερβιριστεί από μια διαδικτυακή εφαρμογή, θα αποθηκευτεί σε CMS, θα βελτιστοποιηθεί από pipeline κατασκευής ή θα ληφθεί στην cache από browsers ανεξάρτητα από το HTML.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ (FAQ)**

**Μπορώ να εξωτερικοποιήσω μόνο τις εικόνες και να κρατήσω τους άλλους πόρους ενσωματωμένους;**

Ναι. Στη `ExternalResourceController.getObjectStoringLocation`, επιστρέψτε την τιμή `Link` από το [LinkEmbedDecision](https://reference.aspose.com/slides/el/php-java/aspose.slides/linkembeddecision/) μόνο για τους τύπους περιεχομένου που θέλετε να αποθηκεύσετε ως ξεχωριστά αρχεία και επιστρέψτε την τιμή `Embed` για όλα τα άλλα.

**Γιατί η εξαγόμενη επέκταση εικόνας διαφέρει από αυτή της πηγαίας παρουσίασης;**

Το Aspose.Slides μπορεί να ξανακωδικοποιήσει ραστερ εικόνες κατά την εξαγωγή σε HTML για να βελτιώσει το μέγεθος ή τη συμβατότητα με browsers. Για παράδειγμα, μια εικόνα από το πηγαίο αρχείο μπορεί να γραφτεί ως JPEG ή PNG ανάλογα με το αποτέλεσμα απόδοσης.

**Λειτουργούν οι σχετικές URL μετά τη μετακίνηση του αρχείου HTML;**

Οι σχετικές URL λειτουργούν μόνο όταν η ίδια σχετική δομή φακέλων παραμένει αμετάβλητη. Αν το HTML παραπέμπει σε `assets/resource-1.png`, ο φάκελος `assets` πρέπει να παραμείνει δίπλα στο αρχείο HTML εκτός εάν δημιουργήσετε διαφορετικό πρόθεμα URL.

**Θα πρέπει οι εφαρμογές διακομιστή να επαναχρησιμοποιούν τον ίδιο φάκελο εξόδου;**

Όχι. Χρησιμοποιήστε μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης για κάθε εργασία μετατροπής. Αυτό αποτρέπει συγκρούσεις ονομάτων αρχείων και αποτρέπει την αντικατάσταση πόρων που δημιουργήθηκαν από άλλη εξαγωγή.