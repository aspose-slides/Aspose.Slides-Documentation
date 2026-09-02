---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις με PHP
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/php-java/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- προσθήκη bitmap
- αντικατάσταση εικόνας
- αντικατάσταση φωτογραφίας
- από το web
- υπόβαθρο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- εξωτερικοί πόροι SVG
- επιλυτής SVG
- συνδεδεμένες εικόνες SVG
- γραμματοσειρές SVG
- προσθήκη EMF
- προσθήκη WMF
- προσθήκη TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Απλοποιήστε τη διαχείριση εικόνων στο PowerPoint και στο OpenDocument με το Aspose.Slides για PHP μέσω Java, βελτιστοποιώντας την απόδοση και αυτοματοποιώντας τη ροή εργασίας σας."
---
## **Εισαγωγή**

Οι εικόνες κάνουν τις παρουσιάσεις πιο ελκυστικές και οπτικά εντυπωσιακές. Στο Microsoft PowerPoint, μπορείτε να εισάγετε εικόνες στις διαφάνειες από αρχεία, το διαδίκτυο ή άλλες πηγές. Αναλόγως, το Aspose.Slides επιτρέπει την προσθήκη εικόνων στις διαφάνειες παρουσίασης με διάφορους τρόπους.

{{% alert  title="Tip" color="primary" %}} 

Το Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που σας επιτρέπουν να δημιουργείτε γρήγορα παρουσιάσεις από εικόνες. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Αν θέλετε να προσθέσετε μια εικόνα ως πλαίσιο εικόνας—ειδικά αν σκοπεύετε να την αλλάξετε μέγεθος, να εφαρμόσετε εφέ ή να χρησιμοποιήσετε άλλες τυπικές επιλογές μορφοποίησης—δείτε το [Picture Frame](/slides/el/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Μπορείτε να μετατρέψετε εικόνες από τη μια μορφή στην άλλη. Δείτε τις παρακάτω σελίδες: μετατροπή [image to JPG](https://products.aspose.com/slides/el/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/el/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/el/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/el/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/el/php-java/conversion/png-to-svg/), και [SVG to PNG](https://products.aspose.com/slides/el/php-java/conversion/svg-to-png/).

{{% /alert %}}

Το Aspose.Slides υποστηρίζει εικόνες σε δημοφιλείς μορφές όπως JPEG, PNG, BMP, GIF και άλλες. 

## **Προσθήκη Εικόνων Αποθηκευμένων Τοπικά στις Διαφάνειες**

Μπορείτε να προσθέσετε μία ή περισσότερες εικόνες που είναι αποθηκευμένες στον υπολογιστή σας σε μια διαφάνεια παρουσίασης. Ο παρακάτω κώδικας PHP δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Προσθήκη Εικόνων από το Διαδίκτυο στις Διαφάνειες**

Αν η εικόνα που θέλετε να προσθέσετε σε μια διαφάνεια δεν είναι αποθηκευμένη στον υπολογιστή σας, μπορείτε να την προσθέσετε απευθείας από το διαδίκτυο. 

Ο παρακάτω κώδικας PHP δείχνει πώς να προσθέσετε μια εικόνα από το διαδίκτυο σε μια διαφάνεια:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Προσθήκη Εικόνων σε Master Διαφάνειας**

Ένα master διαφάνειας αποθηκεύει και ελέγχει πληροφορίες όπως το θέμα και τη διάταξη για τις διαφάνειες που το χρησιμοποιούν. Όταν προσθέτετε μια εικόνα σε ένα master διαφάνειας, η εικόνα εμφανίζεται σε κάθε διαφάνεια που βασίζεται σε αυτό το master. 

Ο παρακάτω κώδικας PHP δείχνει πώς να προσθέσετε μια εικόνα σε ένα master διαφάνειας:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Προσθήκη Εικόνων ως Υπόβαθρο Διαφανειών**

Μπορείτε να χρησιμοποιήσετε μια εικόνα ως υπόβαθρο για μία ή περισσότερες διαφάνειες. Για λεπτομέρειες, δείτε *[Setting Images as Backgrounds for Slides](/slides/el/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG σε Παρουσιάσεις**

Μπορείτε να προσθέσετε περιεχόμενο SVG σε μια παρουσίαση χρησιμοποιώντας την κλάση [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/). Το προκύπτον αντικείμενο SVG εικόνας μπορεί στη συνέχεια να προστεθεί στη συλλογή εικόνων της παρουσίασης και να χρησιμοποιηθεί για τη δημιουργία πλαισίου εικόνας.

Το παρακάτω παράδειγμα PHP εισάγει μια αυτόνομη συμβολοσειρά SVG. Όλες οι εικόνες, τα στυλ και άλλοι πόροι που χρησιμοποιεί αυτό το SVG ενσωματώνονται άμεσα στο περιεχόμενο του SVG.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Εισαγωγή Περιεχομένου SVG με Εξωτερικούς Πόρους**

Αρχεία SVG που εξάγονται από εργαλεία σχεδίασης, επεξεργαστές διαγραμμάτων, συστήματα εικονιδίων και διαδικτυακές αλυσίδες μπορεί να αναφέρονται σε πόρους που αποθηκεύονται εκτός του εγγράφου SVG. Για παράδειγμα, ένα SVG μπορεί να περιλαμβάνει έναν σύνδεσμο εικόνας όπως `images/photo.png`, μια τιμή CSS `url(...)` ή μια διεύθυνση URL γραμματοσειράς.

Για να εισαγάγετε τέτοιο περιεχόμενο SVG, δημιουργήστε μια υλοποίηση του [ExternalResourceResolver](https://reference.aspose.com/slides/el/php-java/aspose.slides/externalresourceresolver/) και περάστε την, μαζί με μια βασική URI, σε έναν κατάλληλο κατασκευαστή της κλάσης [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/). Η βασική URI προσδιορίζει τη θέση του εγγράφου SVG και χρησιμοποιείται για την επίλυση σχετικών συνδέσμων.

Το αντικείμενο SVG εικόνας παρέχει πρόσβαση σε πληροφορίες σχετικά με το εισαγόμενο SVG:

- `getSvgContent()` επιστρέφει το σήμανση SVG ως συμβολοσειρά.
- `getSvgData()` επιστρέφει το περιεχόμενο SVG ως πίνακα bytes.
- `getBaseUri()` επιστρέφει τη βασική URI που χρησιμοποιείται για σχετικούς συνδέσμους.
- `getExternalResourceResolver()` επιστρέφει τον επιλυτή που έχει ανατεθεί στην SVG εικόνα.

### **Υλοποίηση Εξωτερικού Επίλυσης Πόρων**

Ο επιλυτής έχει δύο μεθόδους:

- `resolveUri` συνδυάζει τη βασική URI και έναν σχετικό σύνδεσμο πόρου και επιστρέφει μια απόλυτη URI. Επιστρέψτε `null` όταν ο σύνδεσμος δεν μπορεί να επιλυθεί ή δεν επιτρέπεται.
- `getEntity` επιστρέφει ένα ρεύμα ανάγνωσης για μια απόλυτη URI πόρου. Επιστρέψτε `null` όταν ο πόρος λείπει, είναι φραγμένος ή μη διαθέσιμος. Ένα εναλλακτικό ρεύμα μπορεί επίσης να επιστραφεί όταν είναι κατάλληλο.

Ο παρακάτω επιλυτής φορτώνει συνδεδεμένους πόρους μόνο από έναν επιτρεπόμενο τοπικό φάκελο. Οι πόροι δικτύου και οι διαδρομές εκτός του επιτρεπόμενου φακέλου φράγονται. Μια προαιρετική εναλλακτική εικόνα επιστρέφεται για ανεπίλυτους συνδέσμους εικόνας.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Αυτός ο επιλυτής επιτρέπει σκόπιμα μόνο τοπικά αρχεία.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Χρησιμοποιήστε εναλλακτική μόνο για πηγές εικόνας.
            // Η επιστροφή ρεύματος εικόνας για ελλιπή γραμματοσειρά ή φύλλο στυλ δεν θα ήταν έγκυρη.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Επίλυση Συνδεδεμένων Πόρων Κατά τη διάρκεια Εισαγωγής SVG**

Υποθέστε ότι το `assets/diagram.svg` περιέχει μια σχετική αναφορά όπως:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Το παρακάτω παράδειγμα PHP περνά τη URI του αρχείου SVG ως βασική URI και παρέχει έναν προσαρμοσμένο επιλυτή. Ο επιλυτής μετατρέπει τον σχετικό σύνδεσμο εικόνας σε απόλυτη URI και επιστρέφει ένα ρεύμα που περιέχει τον συνδεδεμένο πόρο ενώ το Aspose.Slides επεξεργάζεται το SVG.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// Το βασικό URI αντιπροσωπεύει τη θέση του εγγράφου SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// Το αντικείμενο SVG εικόνας εκθέτει το πηγαίο περιεχόμενο, τα δυαδικά δεδομένα, το βασικό URI και τον επιλυτή.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η κλάση `SvgImage` παρέχει επίσης υπερφορτώσεις που δέχονται δεδομένα SVG ως πίνακα bytes ή ρεύμα εισόδου, μαζί με έναν εξωτερικό επιλυτή πόρων και μια βασική URI.

{{% alert title="Important" color="warning" %}}

Ο επιλυτής πόρων κάνει διαθέσιμους τους εξωτερικούς πόρους ενώ το Aspose.Slides επεξεργάζεται και αποδίδει το SVG. Δεν τροποποιεί το αρχικό σήμανση SVG ή ενσωματώνει αυτόματα τους επιλυμένους πόρους σε αυτό.

Όταν μια SVG εικόνα προστίθεται στη συλλογή εικόνων της παρουσίασης, το αρχείο PPTX μπορεί να περιέχει τόσο την αρχική αναπαράσταση SVG όσο και μια εναλλακτική ραστερ εικόνα. Ένας συνδεδεμένος πόρος μπορεί να εμφανιστεί στην παραγόμενη εναλλακτική εικόνα ενώ ένας σχετικός σύνδεσμος όπως `images/photo.png` παραμένει αμετάβλητος στο αποθηκευμένο SVG. Μια εφαρμογή που αποδίδει την εγγενή αναπαράσταση SVG μπορεί έτσι να παραλείψει το συνδεδεμένο περιεχόμενο όταν ο αρχικός εξωτερικός πόρος δεν είναι διαθέσιμος.

{{% /alert %}}

### **Δημιουργία Φορητής SVG Εικόνας**

Για να δημιουργήσετε μια SVG εικόνα που δεν εξαρτάται από εξωτερικά αρχεία, κάντε το SVG αυτόνομο πριν δημιουργήσετε το `SvgImage`. Για παράδειγμα, αντικαταστήστε τις URLs των συνδεδεμένων εικόνων με URIs τύπου `data:` που περιέχουν τα δεδομένα της εικόνας:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Αφού ενσωματωθούν όλοι οι απαιτούμενοι πόροι στο περιεχόμενο του SVG, δημιουργήστε το `SvgImage`, προσθέστε το στη συλλογή εικόνων της παρουσίασης και τοποθετήστε το σε ένα πλαίσιο εικόνας όπως φαίνεται στο προηγούμενο παράδειγμα.

### **Διαχείριση Ελλιπών ή Φραγμένων Πόρων**

Επιστρέψτε `null` από τη `resolveUri` όταν μια URI πόρου είναι άκυρη, απαγορευμένη ή δεν μπορεί να επιλυθεί. Επιστρέψτε `null` από τη `getEntity` όταν ο πόρος δεν μπορεί να διαβαστεί. Το Aspose.Slides συνεχίζει την επεξεργασία του SVG χωρίς αυτόν τον πόρο όταν είναι δυνατόν.

Ένα εναλλακτικό ρεύμα μπορεί να επιστραφεί για έναν ελλιπή πόρο, αλλά το περιεχόμενό του πρέπει να είναι συμβατό με τον ζητούμενο τύπο πόρου. Για παράδειγμα, επιστρέψτε ρεύμα εικόνας μόνο για ελλιπή εικόνα, όχι για γραμματοσειρά ή φύλλο στυλ.

{{% alert title="Security" color="warning" %}}

Μην επιλύετε αυθαίρετες διαδρομές αρχείων ή άνετα URLs δικτύου από μη αξιόπιστα αρχεία SVG. Περιορίστε τα επιτρεπόμενα schema, καταλόγους και διακομιστές. Για πόρους δικτύου, εφαρμόστε επίσης χρονικά όρια σύνδεσης, όρια μεγέθους απάντησης και επικύρωση περιεχομένου.

{{% /alert %}}

## **Μετατροπή SVG σε Σύνολο Σχημάτων**

Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε σύνολο σχημάτων, παρόμοιο με τη σχετική λειτουργικότητα στο PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Αυτή η λειτουργία παρέχεται από μια υπερφόρτωση της μεθόδου [addGroupShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addgroupshape/) της κλάσης [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/) που δέχεται ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/) ως πρώτο όρισμα.

Ο παρακάτω κώδικας PHP δείχνει πώς να χρησιμοποιήσετε αυτή τη μέθοδο για να μετατρέψετε ένα αρχείο SVG σε σύνολο σχημάτων:

```php
// Όνομα αρχείου SVG προέλευσης.
$svgFileName = "sample.svg";

// Όνομα αρχείου εξόδου της παρουσίασης.
$outPptxPath = "presentation.pptx";

// Δημιουργία νέας παρουσίασης.
$presentation = new Presentation();
try {
    // Ανάγνωση περιεχομένου αρχείου SVG.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Δημιουργία αντικειμένου SvgImage.
    $svgImage = new SvgImage($svgContent);

    // Λήψη μεγέθους της διαφάνειας.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Μετατροπή της εικόνας SVG σε ομάδα σχημάτων και κλιμάκωση στο μέγεθος της διαφάνειας.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Αποθήκευση της παρουσίασης σε μορφή PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Προσθήκη Εικόνων ως EMF στις Διαφάνειες**

Το Aspose.Slides για PHP μέσω Java σας επιτρέπει να δημιουργείτε εικόνες EMF από φύλλα εργασίας Excel με το Aspose.Cells και να τις προσθέτετε στις διαφάνειες της παρουσίασης.

Ο παρακάτω κώδικας PHP δείχνει πώς να το κάνετε:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Αποθήκευση του βιβλίου εργασίας σε ροή.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Προσθήκη του αρχείου όπως είναι ώστε η εικόνα παραμείνει διανυσματική EMF αντί να rasterαριστεί.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Αντικατάσταση Εικόνων στη Συλλογή Εικόνων**

Το Aspose.Slides σας επιτρέπει να αντικαθιστάτε εικόνες που είναι αποθηκευμένες στη συλλογή εικόνων μιας παρουσίασης, συμπεριλαμβανομένων των εικόνων που χρησιμοποιούνται από σχήματα διαφανειών. Αυτή η ενότητα περιγράφει διάφορους τρόπους ενημέρωσης των εικόνων στη συλλογή. Μπορείτε να αντικαταστήσετε μια εικόνα χρησιμοποιώντας ακατέργαστα δεδομένα bytes, ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) ή μια άλλη εικόνα που υπάρχει ήδη στη συλλογή.

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Φορτώστε μια νέα εικόνα από αρχείο σε ένα πίνακα bytes.
1. Αντικαταστήστε την εικόνα-στόχο με τη νέα εικόνα χρησιμοποιώντας τον πίνακα bytes.
1. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) και αντικαταστήστε την εικόνα-στόχο με αυτό το αντικείμενο.
1. Στην τρίτη προσέγγιση, αντικαταστήστε την εικόνα-στόχο με μια εικόνα που υπάρχει ήδη στη συλλογή εικόνων της παρουσίασης.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
// Δημιουργία μιας Presentation κλάσης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation("sample.pptx");
try {
    // Ο πρώτος τρόπος.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Ο δεύτερος τρόπος.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // Ο τρίτος τρόπος.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Αποθήκευση της παρουσίασης σε αρχείο.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Με τον δωρεάν μετατροπέα [Text to GIF](https://products.aspose.app/slides/el/text-to-gif) του Aspose, μπορείτε εύκολα να δημιουργείτε κίνηση κειμένου και να φτιάχνετε GIF από κείμενο. 

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μένει η αρχική ανάλυση της εικόνας αμετάβλητη μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς το [picture](/slides/el/php-java/picture-frame/) κλιμακώνεται στη διαφάνεια και από τυχόν συμπίεση κατά την αποθήκευση.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσετε το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στη master διαφάνεια ή σε μια διάταξη και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης—οι ενημερώσεις θα εξαπλωθούν σε όλα τα στοιχεία που χρησιμοποιούν αυτόν τον πόρο.

**Μπορεί ένα εισαχθέν SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετά από την οποία τα επιμέρους μέρη γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως υπόβαθρο για πολλές διαφάνειες ταυτόχρονα;**

[Ορίστε την εικόνα ως υπόβαθρο](/slides/el/php-java/presentation-background/) στη master διαφάνεια ή στη σχετική διάταξη—όλες οι διαφάνειες που χρησιμοποιούν αυτό το master/διάταξη θα κληρονομήσουν το υπόβαθρο.

**Πώς μπορώ να αποτρέψω μια παρουσίαση να γίνει πολύ μεγάλη εξαιτίας πολλών εικόνων;**

Επαναχρησιμοποιήστε έναν ενιαίο πόρο εικόνας αντί για διπλότυπα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και κρατήστε τα επαναλαμβανόμενα γραφικά στη master όπου είναι κατάλληλο.