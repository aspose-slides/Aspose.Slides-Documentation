---
title: Μετατροπή παρουσιάσεων PowerPoint σε Markdown σε C++
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/cpp/convert-powerpoint-to-markdown/
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
- σύνδεσμοι εικόνων CDN
- PowerPoint
- παρουσίαση
- Markdown
- C++
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PPT και PPTX σε Markdown σε C++ και ελέγξτε πού αποθηκεύονται και αναφέρονται οι εξαχθείσες bitmap, metafile και SVG εικόνες."
---
## **Επισκόπηση**

Το Aspose.Slides για C++ μπορεί να μετατρέπει παρουσιάσεις PPT και PPTX σε Markdown για τεκμηρίωση, στατικές ιστοσελίδες, μεταφορά περιεχομένου και ροές εργασίας ελέγχου εκδόσεων. Μπορείτε να επιλέξετε μια παραλλαγή του Markdown, να ελέγξετε πώς αποδίδεται το περιεχόμενο των διαφανειών και να αποφασίσετε πού θα αποθηκευτούν οι εξαγόμενες εικόνες και πώς θα τις αναφέρει το παραγόμενο Markdown.

Από προεπιλογή, η εξαγωγή σε Markdown χρησιμοποιεί μόνο κείμενο. Για να εξάγετε οπτικό περιεχόμενο, ορίστε τη μέθοδο [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) στην τιμή `Sequential` ή `Visual` από την απαράθεση [MarkdownExportType](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownexporttype/). Η τιμή `Sequential` αποδίδει τα στοιχεία της διαφάνειας ξεχωριστά και με σειρά, ενώ η τιμή `Visual` διατηρεί ομαδοποιημένα τα στοιχεία για να διατηρήσει τη visual σχέση τους. Η τιμή `TextOnly` δεν παράγει πόρους εικόνας, επομένως οι εκδηλώσεις αποθήκευσης εικόνας δεν καλούνται σε αυτή τη λειτουργία.

## **Μετατροπή παρουσίασης σε Markdown**

Φορτώστε το πηγαίο αρχείο με την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) και στη συνέχεια καλέστε τη μέθοδο [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) με την τιμή `Md` από την απαράθεση [SaveFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Επιλογή παραλλαγής Markdown**

Η μέθοδος [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) ελέγχει την προδιαγραφή Markdown που χρησιμοποιείται για την έξοδο. Η απαράθεση [Flavor](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/flavor/) περιλαμβάνει CommonMark, GitHub Flavored Markdown και άλλες υποστηριζόμενες παραλλαγές.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση ως CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Εξαγωγή εικόνων με την προεπιλεγμένη συμπεριφορά τοπικής αποθήκευσης**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/) παρέχει δύο μεθόδους για τη διαμόρφωση τοπικά αποθηκευμένων εικόνων:

- [set_BasePath](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) καθορίζει τον βασικό φάκελο για το έγγραφο Markdown και τους πόρους του.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) καθορίζει το υποφάκελο εικόνων. Η προεπιλεγμένη τιμή του είναι `Images`.

Το παρακάτω παράδειγμα αποδίδει οπτικό περιεχόμενο, γράφει εικόνες στο `output/assets` και δημιουργεί σχετικούς συνδέσμους εικόνας στο έγγραφο Markdown:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Αυτή η συμπεριφορά λειτουργεί επίσης ως εφεδρική όταν ένας προσαρμοσμένος χειριστής αποθήκευσης εικόνας επιστρέφει `false`.

## **Προσαρμογή αποθήκευσης εικόνας και συνδέσμων Markdown**

Χρησιμοποιήστε το συμβάν `MarkdownSaveOptions::ImageSaving` για μη‑SVG bitmap και metafile πόρους που εκβάλλονται κατά την εξαγωγή σε Markdown. Ο εκχωρητής του [MarkdownImageSavingHandler](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) λαμβάνει το αντικείμενο [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/), το [ImageFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/imageformat/) του και τον παραγόμενο σύνδεσμο Markdown ως παράμετρο `System::String&`. Αποθηκεύστε ή ανεβάστε την εικόνα με τη δοσμένη μορφή και αντικαταστήστε το `link` με τη διεύθυνση που πρέπει να εμφανίζεται στην έξοδο Markdown.

Οι πόροι που εκβάλλονται σε μορφή SVG επεξεργάζονται ξεχωριστά. Εγγραφείτε στο συμβάν `MarkdownSaveOptions::SvgImageSaving`, του οποίου ο εκχωρητής [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) λαμβάνει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/) και την παράμετρο `System::String& link`. Ένα SVG δεν διαθέτει όρισμα `ImageFormat`; γράψτε ή ανεβάστε τα XML δεδομένα του μέσω της μεθόδου [ISvgImage::get_SvgData](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/get_svgdata/). Ανάλογα με τη λειτουργία εξαγωγής και την ομαδοποίηση, ένα SVG στην πηγή μπορεί να ραστεροποιηθεί ή να συνδυαστεί με άλλο περιεχόμενο· ο μη‑SVG πόρος που προκύπτει τότε μεταβιβάζεται στο `ImageSaving`. Εγγραφείτε και στα δύο συμβάντα όταν κάθε εξαγόμενο οπτικό πόρο απαιτεί προσαρμοσμένη επεξεργασία.

Η τιμή επιστροφής του χειριστή καθορίζει ποιος επεξεργάζεται την εικόνα:

- Επιστρέψτε `true` αφού ο χειριστής έχει αποθηκεύσει, ανεβάσει, μετατρέψει ή με οποιονδήποτε τρόπο επεξεργαστεί την εικόνα και έχει αναθέσει μια έγκυρη τιμή στο `link`. Το Aspose.Slides γράφει αυτήν την τιμή στο έγγραφο Markdown και δεν εκτελεί την προεπιλεγμένη τοπική αποθήκευση.
- Επιστρέψτε `false` για να αφήσετε το Aspose.Slides να αποθηκεύσει την εικόνα τοπικά και να δημιουργήσει το σύνδεσμο σύμφωνα με τις μεθόδους [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) και [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Σημαντικό" %}}

Ένας χειριστής που επιστρέφει `true` αναλαμβάνει την ευθύνη για την εικόνα. Εάν επιστρέψει `true` χωρίς να αναθέσει έγκυρο, μη κενό σύνδεσμο, η εξαγωγή αποτυγχάνει με `InvalidOperationException`.

{{% /alert %}}

### **Αποθήκευση εικόνων σε φάκελο προέλευσης CDN και χρήση εξωτερικών URL**

Το παρακάτω παράδειγμα αντιμετωπίζει το `cdn-origin/presentations/quarterly-report` ως προσαρτημένο ή συγχρονισμένο φάκελο προέλευσης CDN. Κάθε χειριστής εξάγει το όνομα του παραγόμενου αρχείου, αποθηκεύει την εικόνα σε αυτόν τον προσαρμοσμένο φάκελο και αντικαθιστά τον τοπικό σύνδεσμο με δημόσιο URL CDN. Το ίδιο το δείγμα δεν πραγματοποιεί καμία δικτυακή μεταφόρτωση: το URL γίνεται έγκυρο μόνο αφού ο φάκελος προσαρτηθεί ως προέλευση CDN ή τα αρχεία του δημοσιευτούν στο CDN. Για αποθήκευση αντικειμένων, αντικαταστήστε τη γραφή στο σύστημα αρχείων με την λειτουργία ανεβάσματος του SDK αποθήκευσης και αναθέστε το `link` μόνο μετά την επιτυχή μεταφόρτωση.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Ο χειριστής bitmap επιστρέφει σκόπιμα `false` για εικόνες μικρότερες των 128 × 128 pixels, ώστε το Aspose.Slides να τις αποθηκεύσει στο `output/fallback-images` χρησιμοποιώντας την προεπιλεγμένη συμπεριφορά. Μεγαλύτεροι bitmap και metafile πόροι, καθώς και πόροι SVG, διαχειρίζονται από τον προσαρμοσμένο κώδικα. Για παράδειγμα, ένας παραγόμενος τοπικός σύνδεσμος όπως `fallback-images/image1.png` γίνεται `https://cdn.example.com/presentations/quarterly-report/image1.png`. Οι χειριστές χρησιμοποιούν διαδρομές λειτουργικού συστήματος μόνο για τη γραφή αρχείων· οι σύνδεσμοι που γράφονται στο Markdown χρησιμοποιούν κάθετες κάθετες καθέτους και ονόματα αρχείων κωδικοποιημένα σε URL. Εφαρμόστε τον ίδιο κανόνα όταν δημιουργείτε σχετικούς συνδέσμους: χρησιμοποιήστε `/`, όχι το διαχωριστικό καταλόγου της πλατφόρμας.

## **Συχνές ερωτήσεις**

**Μπορεί ένας χειριστής να επεξεργαστεί τόσο raster εικόνες όσο και SVG εικόνες;**

Όχι. Χρησιμοποιήστε `MarkdownSaveOptions::ImageSaving` για bitmap και metafile πόρους που εκβάλλονται και `MarkdownSaveOptions::SvgImageSaving` για πόρους που εκβάλλονται ως SVG. Ο πρώτος παρέχει αντικείμενο [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) και [ImageFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/imageformat/); ο δεύτερος παρέχει αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/) του οποίου τα δεδομένα SVG μπορούν να αναγνωσθούν με [ISvgImage::get_SvgData](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/get_svgdata/). Ένα SVG στην πηγή που ραστεροποιηθεί κατά την εξαγωγή επεξεργάζεται από το `ImageSaving`.

**Τι συμβαίνει όταν ένας χειριστής αποθήκευσης εικόνας επιστρέφει `false`;**

Το Aspose.Slides χρησιμοποιεί την προεπιλεγμένη συμπεριφορά τοπικής αποθήκευσης. Η θέση της εικόνας και ο παραγόμενος σύνδεσμος ελέγχονται από τις μεθόδους [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) και [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Μπορεί ένας χειριστής να παρέχει URL χωρίς να αποθηκεύει την εικόνα τοπικά;**

Ναι. Ο χειριστής μπορεί να ανεβάσει την εικόνα σε αποθήκευση αντικειμένων ή να τη μεταβιβάσει σε άλλη υπηρεσία, να αναθέσει το παραγόμενο URL στο `link` και να επιστρέψει `true`. Ο χειριστής πρέπει να ολοκληρώσει την επεξεργασία μόνος του· η επιστροφή `true` αποτρέπει την προεπιλεγμένη τοπική αποθήκευση.

**Γιατί η εξαγωγή Markdown προκαλεί `InvalidOperationException` από έναν χειριστή;**

Η εξαίρεση εμφανίζεται όταν ο χειριστής επιστρέφει `true` αλλά δεν παρέχει έγκυρο σύνδεσμο. Αναθέστε τη σχετική διαδρομή ή το εξωτερικό URL που πρέπει να γραφτεί στο Markdown πριν επιστρέψετε `true`.

**Ποιο διαχωριστικό διαδρομής πρέπει να χρησιμοποιούν οι σύνδεσμοι εικόνας;**

Χρησιμοποιήστε κάθετους κάθετους (`/`) σε συνδέσμους Markdown και URLs. Χρησιμοποιήστε `Path::Combine` μόνο για διαδρομές συστήματος αρχείων, στη συνέχεια δημιουργήστε ή κανονικοποιήστε ξεχωριστά τη αναφορά Markdown.

**Διατηρούνται οι υπερσύνδεσμοι κατά την εξαγωγή σε Markdown;**

Ναι. Τα κειμενικά [hyperlinks](/slides/el/cpp/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/cpp/slide-transition/) και [animations](/slides/el/cpp/powerpoint-animation/) των διαφανειών δεν μετατρέπονται.

**Μπορούν οι παρουσιάσεις να μετατρέπονται σε Markdown παράλληλα;**

Μπορείτε να επεξεργαστείτε διαφορετικά αρχεία παρουσίασης ταυτόχρονα, αλλά μην μοιράζεστε το ίδιο στιγμιότυπο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) μεταξύ νημάτων. Ακολουθήστε τις [multithreading guidelines](/slides/el/cpp/multithreading/) και χρησιμοποιήστε ξεχωριστό στιγμιότυπο για κάθε αρχείο.