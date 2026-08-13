---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις Χρησιμοποιώντας C++
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/cpp/image/
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
- C++
- Aspose.Slides
description: "Απλοποιήστε τη διαχείριση εικόνων στο PowerPoint και το OpenDocument με το Aspose.Slides για C++, βελτιώνοντας την απόδοση και αυτοματοποιώντας τη ροή εργασίας σας."
---
## **Εισαγωγή**

Οι εικόνες καθιστούν τις παρουσιάσεις πιο ελκυστικές και οπτικά εντυπωσιακές. Στο Microsoft PowerPoint, μπορείτε να εισαγάγετε εικόνες στις διαφάνειες από αρχεία, το διαδίκτυο ή άλλες πηγές. Παρόμοια, το Aspose.Slides σάς επιτρέπει να προσθέτετε εικόνες σε διαφάνειες παρουσίασης με πολλούς τρόπους. 

{{% alert title="Συμβουλή" color="info" %}} 

Το Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που σας επιτρέπουν να δημιουργείτε γρήγορα παρουσιάσεις από εικόνες. 

{{% /alert %}} 

{{% alert title="Πληροφορία" color="info" %}}

Εάν θέλετε να προσθέσετε μια εικόνα ως πλαίσιο εικόνας—ιδιαίτερα αν σκοπεύετε να αλλάξετε το μέγεθός της, να εφαρμόσετε εφέ ή να χρησιμοποιήσετε άλλες τυπικές επιλογές μορφοποίησης—δείτε [Πλαίσιο Εικόνας](/slides/el/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Σημείωση" color="warning" %}}

Μπορείτε να μετατρέψετε τις εικόνες από μια μορφή σε άλλη. Δείτε τις ακόλουθες σελίδες: μετατρέψτε [εικόνα σε JPG](https://products.aspose.com/slides/el/cpp/conversion/image-to-jpg/), [JPG σε εικόνα](https://products.aspose.com/slides/el/cpp/conversion/jpg-to-image/), [JPG σε PNG](https://products.aspose.com/slides/el/cpp/conversion/jpg-to-png/), [PNG σε JPG](https://products.aspose.com/slides/el/cpp/conversion/png-to-jpg/), [PNG σε SVG](https://products.aspose.com/slides/el/cpp/conversion/png-to-svg/), και [SVG σε PNG](https://products.aspose.com/slides/el/cpp/conversion/svg-to-png/).

{{% /alert %}}

Το Aspose.Slides υποστηρίζει εικόνες σε δημοφιλείς μορφές όπως JPEG, PNG, BMP, GIF και άλλες. 

## **Προσθήκη Εικόνων αποθηκευμένων τοπικά στις Διαφάνειες**

Μπορείτε να προσθέσετε μία ή περισσότερες εικόνες που αποθηκεύονται στον υπολογιστή σας σε μια διαφάνεια παρουσίασης. Ο παρακάτω κώδικας C++ δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Προσθήκη Εικόνων από το Web στις Διαφάνειες**

Εάν η εικόνα που θέλετε να προσθέσετε σε μια διαφάνεια δεν είναι αποθηκευμένη στον υπολογιστή σας, μπορείτε να την προσθέσετε απευθείας από το web. 

Ο παρακάτω κώδικας C++ δείχνει πώς να προσθέσετε μια εικόνα από το web σε μια διαφάνεια:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Προσθήκη Εικόνων σε Slide Masters**

Ένα slide master αποθηκεύει και ελέγχει πληροφορίες όπως το θέμα και τη διάταξη για τις διαφάνειες που το χρησιμοποιούν. Όταν προσθέτετε μια εικόνα σε ένα slide master, η εικόνα εμφανίζεται σε κάθε διαφάνεια που βασίζεται σε αυτόν τον master. 

Ο παρακάτω κώδικας C++ δείχνει πώς να προσθέσετε μια εικόνα σε ένα slide master:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Προσθήκη Εικόνων ως Φόντο Διαφάνειας**

Μπορείτε να χρησιμοποιήσετε μια εικόνα ως φόντο για μία ή περισσότερες διαφάνειες. Για λεπτομέρειες, δείτε *[Ορισμός Εικόνων ως Φόντο για Διαφάνειες](/slides/el/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG στις Παρουσιάσεις**

Το περιεχόμενο SVG μπορεί να προστεθεί σε μια παρουσίαση χρησιμοποιώντας την κλάση [SvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/svgimage/). Το προκύπτον αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/) μπορεί στη συνέχεια να προστεθεί στη συλλογή εικόνων της παρουσίασης και να χρησιμοποιηθεί για τη δημιουργία πλαισίου εικόνας.

Ο παρακάτω κώδικας C++ εισάγει μια αυτόνομη συμβολοσειρά SVG. Όλες οι εικόνες, τα στυλ και άλλοι πόροι που χρησιμοποιούνται από αυτό το SVG είναι ενσωματωμένοι απευθείας στο περιεχόμενο SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Εισαγωγή Περιεχομένου SVG με Εξωτερικούς Πόρους**

Τα αρχεία SVG που εξάγονται από εργαλεία σχεδίασης, επεξεργαστές διαγραμμάτων, συστήματα εικονιδίων και διαδικτυακές αγωγές ενδέχεται να αναφέρονται σε πόρους που αποθηκεύονται εκτός του εγγράφου SVG. Για παράδειγμα, ένα SVG μπορεί να περιέχει σύνδεσμο σε εικόνα όπως `images/photo.png`, μια τιμή CSS `url(...)` ή ένα URL γραμματοσειράς.

Για να εισάγετε τέτοιο περιεχόμενο SVG, δημιουργήστε μια υλοποίηση του [IExternalResourceResolver](https://reference.aspose.com/slides/el/cpp/aspose.slides.import/iexternalresourceresolver/) και περάστε την, μαζί με ένα βασικό URI, σε έναν κατάλληλο κατασκευαστή `SvgImage`. Το βασικό URI προσδιορίζει τη θέση του εγγράφου SVG και χρησιμοποιείται για την επίλυση σχετικών συνδέσμων.

Η διεπαφή [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/) παρέχει πρόσβαση σε πληροφορίες σχετικά με το εισαχθέν SVG:

- `get_SvgContent()` επιστρέφει το στίγμα SVG ως συμβολοσειρά.
- `get_SvgData()` επιστρέφει το περιεχόμενο SVG ως πίνακα byte.
- `get_BaseUri()` επιστρέφει το βασικό URI που χρησιμοποιείται για σχετικούς συνδέσμους.
- `get_ExternalResourceResolver()` επιστρέφει τον επιλυτή που έχει αντιστοιχιστεί στην εικόνα SVG.

### **Υλοποίηση Εξωτερικού Επίλυσης Πόρων**

Ο επιλυτής διαθέτει δύο μεθόδους:

- [ResolveUri](https://reference.aspose.com/slides/el/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) συνδυάζει το βασικό URI και έναν σχετικό σύνδεσμο πόρου και επιστρέφει ένα απόλυτο URI. Επιστρέψτε μια κενή συμβολοσειρά όταν ο σύνδεσμος δεν μπορεί να επιλυθεί ή δεν επιτρέπεται.
- [GetEntity](https://reference.aspose.com/slides/el/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) επιστρέφει μια ροή αναγνώσιμη για ένα απόλυτο URI πόρου. Επιστρέψτε `nullptr` όταν ο πόρος λείπει, είναι φραγμένος ή μη διαθέσιμος. Μπορεί επίσης να επιστραφεί εναλλακτική ροή όταν είναι κατάλληλο.

Ο παρακάτω επιλυτής φορτώνει συνδεδεμένους πόρους μόνο από ένα επιτρεπόμενο τοπικό φάκελο. Οι πόροι δικτύου και οι διαδρομές εκτός του επιτρεπόμενου φακέλου μπλοκάρονται. Μια προαιρετική εναλλακτική εικόνα επιστρέφεται για συνδέσμους εικόνας που δεν επιλύθηκαν.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Αυτός ο επιλυτής επιτρέπει επίτηδες μόνο τοπικά αρχεία.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Χρησιμοποιήστε εναλλακτική μόνο για πόρους εικόνας.
        // Η επιστροφή ροής εικόνας για μια ελλιπή γραμματοσειρά ή φύλλο στυλ δεν θα ήταν έγκυρη.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Επίλυση Συνδεδεμένων Πόρων κατά τη Διαδικασία Εισαγωγής SVG**

Υποθέστε ότι `assets/diagram.svg` περιέχει μια σχετική αναφορά όπως:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ο παρακάτω κώδικας C++ περνά το URI του αρχείου SVG ως βασικό URI και παρέχει έναν προσαρμοσμένο επιλυτή. Ο επιλυτής μετατρέπει τον σχετικό σύνδεσμο εικόνας σε απόλυτο URI και επιστρέφει μια ροή που περιέχει τον συνδεδεμένο πόρο ενώ το Aspose.Slides επεξεργάζεται το SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// Το βασικό URI αντιπροσωπεύει τη θέση του εγγράφου SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// Το ISvgImage εκθέτει το περιεχόμενο προέλευσης, τα δυαδικά δεδομένα, το βασικό URI και τον επιλυτή.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η κλάση `SvgImage` προσφέρει επίσης υπερφορτώσεις που δέχονται δεδομένα SVG ως πίνακα byte ή ως ροή, μαζί με έναν εξωτερικό επιλυτή πόρων και ένα βασικό URI.

{{% alert title="Σημαντικό" color="warning" %}}

Ο επιλυτής πόρων καθιστά διαθέσιμους εξωτερικούς πόρους ενώ το Aspose.Slides επεξεργάζεται και αποδίδει το SVG. Δεν τροποποιεί το αρχικό στίγμα SVG ούτε ενσωματώνει αυτόματα τους επιλυμένους πόρους σε αυτό.

Όταν ένα `ISvgImage` προστίθεται στη συλλογή εικόνων της παρουσίασης, το αρχείο PPTX μπορεί να περιέχει τόσο την αρχική αναπαράσταση SVG όσο και μια εναλλακτική ραστερ εικόνα. Ένας συνδεδεμένος πόρος μπορεί να εμφανιστεί στην παραγόμενη εναλλακτική εικόνα, ενώ ένας σχετικός σύνδεσμος όπως `images/photo.png` παραμένει αμετάβλητος στο αποθηκευμένο SVG. Μια εφαρμογή που αποδίδει τη φυσική αναπαράσταση SVG μπορεί επομένως να παραλείψει το συνδεδεμένο περιεχόμενο όταν ο αρχικός εξωτερικός πόρος δεν είναι διαθέσιμος.

{{% /alert %}}

### **Δημιουργία Φορητής Εικόνας SVG**

Για να δημιουργήσετε μια εικόνα SVG που δεν εξαρτάται από εξωτερικά αρχεία, κάντε το SVG αυτόνομο πριν δημιουργήσετε το `SvgImage`. Για παράδειγμα, αντικαταστήστε συνδέσμους εικόνας με URIs `data:` που περιέχουν τα δεδομένα της εικόνας:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Αφού ενσωματωθούν όλα τα απαιτούμενα δεδομένα στο περιεχόμενο SVG, δημιουργήστε το `SvgImage`, προσθέστε το στη συλλογή εικόνων της παρουσίασης και τοποθετήστε το σε ένα πλαίσιο εικόνας όπως φαίνεται στο προηγούμενο παράδειγμα.

### **Διαχείριση Ελλιπών ή Φραγμένων Πόρων**

Επιστρέψτε μια κενή συμβολοσειρά από το `ResolveUri` όταν ένα URI πόρου είναι άκυρο, απαγορευμένο ή δεν μπορεί να επιλυθεί. Επιστρέψτε `nullptr` από το `GetEntity` όταν ο πόρος δεν μπορεί να διαβαστεί. Το Aspose.Slides συνεχίζει την επεξεργασία του SVG χωρίς αυτόν τον πόρο όταν είναι δυνατόν.

Μια εναλλακτική ροή μπορεί να επιστραφεί για έναν ελλιπές πόρο, αλλά το περιεχόμενό της πρέπει να είναι συμβατό με τον τύπο του ζητούμενου πόρου. Για παράδειγμα, επιστρέψτε μια ροή εικόνας μόνο για μια ελλιπή εικόνα, όχι για γραμματοσειρά ή φύλλο στυλ.

{{% alert title="Ασφάλεια" color="warning" %}}

Μην επιλύετε αυθαίρετες διαδρομές αρχείων ή απεριόριστα URLs δικτύου από μη αξιόπιστα αρχεία SVG. Περιορίστε τα επιτρεπόμενα σχήματα, φακέλους και κεντρικούς υπολογιστές. Για πόρους δικτύου, εφαρμόστε επίσης χρονικά όρια σύνδεσης, όρια μεγέθους απάντησης και επικύρωση περιεχομένου.

{{% /alert %}}

## **Μετατροπή SVG σε Σύνολο Σχημάτων**
Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε σύνολο σχημάτων, παρόμοια με την αντίστοιχη λειτουργία στο PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Αυτή η λειτουργία παρέχεται από μια υπερφόρτωση της μεθόδου [AddGroupShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/) του διεπαφικού τύπου [IShapeCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/) που δέχεται ως πρώτο όρισμα ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/).

``` cpp
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Όνομα αρχείου SVG πηγής
auto svgFileName = System::String(u"sample.svg");

// Όνομα αρχείου εξόδου παρουσίασης
auto outPptxPath = System::String(u"presentation.pptx");

// Δημιουργία νέας παρουσίασης
auto presentation = System::MakeObject<Presentation>();

// Ανάγνωση του περιεχομένου του αρχείου SVG
auto svgContent = File::ReadAllText(svgFileName);

// Δημιουργία αντικειμένου SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Λήψη του μεγέθους της διαφάνειας
auto slideSize = presentation->get_SlideSize()->get_Size();

// Μετατροπή της εικόνας SVG σε ομάδα σχημάτων και προσαρμογή της στο μέγεθος της διαφάνειας
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Αποθήκευση της παρουσίασης σε μορφή PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Προσθήκη Εικόνων ως EMF σε Διαφάνειες**
Το Aspose.Slides for C++ σας επιτρέπει να δημιουργήσετε εικόνες EMF από φύλλα εργασίας Excel με το Aspose.Cells και να τις προσθέσετε σε διαφάνειες παρουσίασης. 

Ο παρακάτω κώδικας C++ δείχνει πώς να το κάνετε αυτό:

``` cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Το Aspose.Cells για C++ πρέπει να ξεκινήσει πριν χρησιμοποιηθούν οποιουσδήποτε τύποι του.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Απόδοση του φύλλου εργασίας ως EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Το Aspose.Cells επιστρέφει τη σελίδα που αποδόθηκε ως buffer, το οποίο το Aspose.Slides προσθέτει ως εικόνα.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Αντικατάσταση Εικόνων στη Συλλογή Εικόνων**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε εικόνες που αποθηκεύονται στη συλλογή εικόνων μιας παρουσίασης, συμπεριλαμβανομένων των εικόνων που χρησιμοποιούνται από σχήματα διαφάνειας. Αυτή η ενότητα περιγράφει αρκετούς τρόπους ενημέρωσης των εικόνων στη συλλογή. Μπορείτε να αντικαταστήσετε μια εικόνα χρησιμοποιώντας ακατέργαστα δεδομένα byte, μια παρουσία [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) ή μια άλλη εικόνα που ήδη υπάρχει στη συλλογή.

Ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Φορτώστε μια νέα εικόνα από αρχείο σε έναν πίνακα byte.
1. Αντικαταστήστε την εικόνα-στόχο με τη νέα εικόνα χρησιμοποιώντας τον πίνακα byte.
1. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) και αντικαταστήστε την εικόνα-στόχο με αυτό το αντικείμενο.
1. Στην τρίτη προσέγγιση, αντικαταστήστε την εικόνα-στόχο με μια εικόνα που ήδη υπάρχει στη συλλογή εικόνων της παρουσίασης.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Δημιουργήστε μια παρουσίαση με την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ο πρώτος τρόπος.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Ο δεύτερος τρόπος.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Ο τρίτος τρόπος.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Αποθηκεύστε την παρουσίαση σε αρχείο.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Πληροφορία" color="info" %}}

Με το δωρεάν μετατροπέα [Text to GIF](https://products.aspose.app/slides/el/text-to-gif) του Aspose, μπορείτε εύκολα να ζωντανέψετε κείμενο και να δημιουργήσετε GIF από κείμενο. 

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Παραμένει η αρχική ανάλυση της εικόνας μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς η [εικόνα](/slides/el/cpp/picture-frame/) κλιμακώνεται στη διαφάνεια και τυχόν συμπίεση που εφαρμόζεται κατά την αποθήκευση.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσετε το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στη master διαφάνεια ή σε ένα layout και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης—οι ενημερώσεις θα εξαπλωθούν σε όλα τα στοιχεία που χρησιμοποιούν αυτόν τον πόρο.

**Μπορεί ένα εισαχθέν SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετά το οποίο τα επιμέρους μέρη γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως φόντο για πολλές διαφάνειες ταυτόχρονα;**

[Ορίστε την εικόνα ως φόντο](/slides/el/cpp/presentation-background/) στη master διαφάνεια ή στο σχετικό layout—οι διαφάνειες που χρησιμοποιούν αυτόν τον master/layout θα κληρονομήσουν το φόντο.

**Πώς μπορώ να αποφύγω ένα μεγάλο μέγεθος παρουσίασης εξαιτίας πολλών εικόνων;**

Επαναχρησιμοποιήστε έναν ενιαίο πόρο εικόνας αντί για διπλότυπα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και διατηρήστε τα επαναλαμβανόμενα γραφικά στο master όπου είναι κατάλληλο.