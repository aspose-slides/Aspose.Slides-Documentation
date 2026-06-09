---
title: Εξαγωγή Παρουσιάσεων σε HTML με Εξωτερικά Συνδεδεμένες Εικόνες
type: docs
weight: 50
url: /el/cpp/exporting-presentations-to-html-with-externally-linked-images/
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
- C++
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint και OpenDocument σε HTML με C++ χρησιμοποιώντας το Aspose.Slides, με εικόνες και άλλους πόρους αποθηκευμένους ως εξωτερικά συνδεδεμένα αρχεία."
---
## **Επισκόπηση**

Από προεπιλογή, το Aspose.Slides εξάγει μια παρουσίαση σε ένα αυτόνομο αρχείο HTML. Οι εικόνες και άλλοι πόροι γράφονται απευθείας στο HTML, συνήθως ως δεδομένα Base64. Αυτό είναι βολικό όταν χρειάζεστε ένα φορητό αρχείο, αλλά δεν είναι πάντα η καλύτερη μορφή για έναν ιστότοπο, ένα CMS ή μια διαδικασία μετατροπής από την πλευρά του διακομιστή.

Χρησιμοποιήστε εξωτερικά συνδεδεμένους πόρους όταν θέλετε να:

- μειώσετε το μέγεθος του εγγράφου HTML.
- αποθηκεύσετε στην cache εικόνες, γραμματοσειρές, ήχο ή βίντεο ξεχωριστά σε έναν περιηγητή ή CDN.
- εξετάσετε, αντικαταστήσετε, συμπιέσετε ή επεξεργαστείτε μεταγενέστερα τους παραγόμενους πόρους μετά την εξαγωγή.
- διατηρήσετε τη δομή εξόδου πιο κοντά σε αυτό που αναμένει μια εφαρμογή ιστού.

Για τη γενική ροή εργασίας μετατροπής HTML, δείτε [Μετατροπή Παρουσιάσεων PowerPoint σε HTML](/slides/el/cpp/convert-powerpoint-to-html/). Το άρθρο αυτό εστιάζει στο τμήμα σύνδεσης πόρων της εξαγωγής.

## **Πώς Λειτουργεί η Εξαγωγή Συνδεδεμένων Πόρων**

[ILinkEmbedController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ilinkembedcontroller/) επιτρέπει στην εφαρμογή σας να αποφασίζει, πόρος ανά πόρο, εάν ο εξαγωγέας ενσωματώνει τα δεδομένα στο HTML ή τα αποθηκεύει εξωτερικά και γράφει έναν σύνδεσμο.

Η διεπαφή έχει τρεις μεθόδους:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) αποφασίζει εάν ένας πόρος θα πρέπει να συνδεθεί ή να ενσωματωθεί.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) επιστρέφει τη διεύθυνση URL που θα γραφτεί στο παραγόμενο HTML ή σε έναν άλλο συνδεδεμένο πόρο.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) γράφει τα δεδομένα του συνδεδεμένου πόρου στο δίσκο ή σε άλλο στόχο αποθήκευσης.

Η διαδρομή του συστήματος αρχείων και η διεύθυνση URL του περιηγητή είναι ξεχωριστά ζητήματα. Για παράδειγμα, το παρακάτω παράδειγμα γράφει αρχεία πόρων στο `html-output/assets` στο δίσκο, ενώ το HTML περιέχει σχετικές URL όπως `assets/resource-1.svg`. Ένας περιηγητής επιλύει αυτές τις URL σε σχέση με το αρχείο που περιέχει τον σύνδεσμο. Συνεπώς, ένας σύνδεσμος από `presentation.html` σε ένα αρχείο SVG χρησιμοποιεί `assets/resource-1.svg`, ενώ ένας σύνδεσμος από εκείνο το αρχείο SVG σε εικόνα που είναι αποθηκευμένη στον ίδιο φάκελο `assets` χρησιμοποιεί `resource-4.jpg`.

## **Εξαγωγή HTML με Συνδεδεμένα Πόροι**

Το παρακάτω παράδειγμα C++ δημιουργεί έναν φάκελο εξόδου, αποθηκεύει το αρχείο HTML εκεί και αποθηκεύει τους συνδεδεμένους πόρους σε υποφάκελο `assets`. Ο ελεγκτής συνδέει κοινούς πόρους εικόνας, γραμματοσειράς, ήχου, βίντεο και CSS όταν το Aspose.Slides παρέχει ή μπορεί να προεγγλίσσει ασφαλή κατάληξη αρχείου. Οι πόροι που δεν αναγνωρίζονται παραμένουν ενσωματωμένοι.

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
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

Τα ακριβή αρχεία εξαρτώνται από το περιεχόμενο της παρουσίασης και τις επιλογές εξαγωγής. Για παράδειγμα, οι ραστερικές εικόνες συνήθως εξάγονται ως JPEG ή PNG. Το Aspose.Slides μπορεί να επιλέξει διαφορετικό κωδικοποιητή εικόνας από αυτόν που χρησιμοποιείται στην πηγαία παρουσίαση όταν αυτό παράγει μικρότερο ή πιο κατάλληλο αρχείο. Οι εικόνες με διαφάνεια εξάγονται ως PNG.

## **Επιλογή URL για Ανάπτυξη**

Το παράδειγμα χρησιμοποιεί ένα σχετικό πρόθεμα URL: `assets/`. Αν το `presentation.html` ανοίξει από `html-output/presentation.html`, ο περιηγητής φορτώνει `html-output/assets/resource-1.svg`.

Όταν ένας συνδεδεμένος πόρος αναφέρεται σε άλλο συνδεδεμένο πόρο, το παράδειγμα χρησιμοποιεί την παράμετρο `referrer` στην [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) και επιστρέφει μόνο το όνομα του αρχείου. Για παράδειγμα, αν τα `resource-1.svg` και `resource-4.jpg` βρίσκονται και τα δύο στον φάκελο `assets`, το αρχείο SVG πρέπει να αναφέρεται σε `resource-4.jpg`, όχι σε `assets/resource-4.jpg`.

Χρησιμοποιήστε διαφορετικό πρόθεμα URL όταν τα αρχεία αναπτυχθούν σε διαφορετική θέση:

- Χρησιμοποιήστε `assets/` όταν ο φάκελος πόρων βρίσκεται δίπλα στο αρχείο HTML.
- Χρησιμοποιήστε `../assets/` όταν ο φάκελος πόρων είναι ένα επίπεδο πάνω από το αρχείο HTML.
- Χρησιμοποιήστε `https://cdn.example.com/presentations/job-123/assets/` όταν τα αρχεία έχουν ανεβαστεί σε CDN ή σε στατικό διακομιστή αρχείων.

Η URL που επιστρέφεται από την [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) πρέπει να ταιριάζει με την τελική τοποθεσία του αρχείου που γράφει η [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). Σε εφαρμογές διακομιστή, χρησιμοποιήστε έναν μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης αντικειμένων για κάθε εργασία μετατροπής ώστε να αποφεύγονται οι αντικαταστάσεις αρχείων από άλλες εξαγωγές.

## **Πότε να Ενσωματώσετε Αντί για Συνδέσμους**

Το ενσωματωμένο Base64 HTML παραμένει χρήσιμο όταν η έξοδος πρέπει να είναι ένα μόνο αρχείο, όπως ένα συνημμένο email, μια offline προεπισκόπηση ή ένα έγγραφο που θα μεταφερθεί χωρίς φάκελο υποστηρικτικών πόρων. Οι συνδεδεμένοι πόροι είναι πιο κατάλληλοι όταν το HTML θα διανέμεται από μια εφαρμογή ιστού, αποθηκεύεται σε CMS, βελτιστοποιείται από γραμμή παραγωγής ή προσωρινά αποθηκεύεται από περιηγητές ανεξάρτητα από το HTML.

## **Συχνές Ερωτήσεις**

**Μπορώ να εξωτερικεύσω μόνο τις εικόνες και να διατηρήσω τους άλλους πόρους ενσωματωμένους;**

Ναι. Στην [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), επιστρέψτε `LinkEmbedDecision::Link` μόνο για τους τύπους περιεχομένου που θέλετε να αποθηκεύσετε ως ξεχωριστά αρχεία και επιστρέψτε `LinkEmbedDecision::Embed` για όλα τα άλλα.

**Γιατί η εξαγόμενη επέκταση εικόνας διαφέρει από την πηγαία παρουσίαση;**

Το Aspose.Slides μπορεί να κωδικοποιήσει ξανά τις ραστερικές εικόνες κατά την εξαγωγή HTML ώστε να βελτιώσει το μέγεθος ή τη συμβατότητα με τον περιηγητή. Για παράδειγμα, μια εικόνα από το πηγαίο αρχείο μπορεί να γραφτεί ως JPEG ή PNG ανάλογα με το αποτέλεσμα της απόδοσης.

**Λειτουργούν οι σχετικές URL μετά τη μετακίνηση του αρχείου HTML;**

Οι σχετικές URL λειτουργούν μόνο όταν διατηρείται η ίδια σχετική δομή φακέλων. Αν το HTML αναφέρεται σε `assets/resource-1.png`, ο φάκελος `assets` πρέπει να παραμείνει δίπλα στο αρχείο HTML, εκτός εάν δημιουργήσετε διαφορετικό πρόθεμα URL.

**Θα πρέπει οι εφαρμογές διακομιστή να επαναχρησιμοποιούν τον ίδιο φάκελο εξόδου;**

Όχι. Χρησιμοποιήστε έναν μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης για κάθε εργασία μετατροπής. Αυτό αποτρέπει συγκρούσεις ονομάτων αρχείων και εμποδίζει μια εξαγωγή να αντικαταστήσει πόρους που δημιουργήθηκαν από άλλη εξαγωγή.