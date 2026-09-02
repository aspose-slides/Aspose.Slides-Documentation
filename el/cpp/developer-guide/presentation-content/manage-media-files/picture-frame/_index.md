---
title: Διαχείριση πλαισίων εικόνας σε παρουσιάσεις με C++
linktitle: Πλαίσιο εικόνας
type: docs
weight: 10
url: /el/cpp/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- ενσωματωμένη εικόνα
- συνδεδεμένη εικόνα
- εξαγωγή εικόνας
- ραστερ εικόνας
- SVG εικόνα
- περικοπή εικόνας
- διαγραφή περικομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- αναλογία διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, περικοπή, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με Aspose.Slides για C++."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος της εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) κατέχει ενσωματωμένους πόρους εικόνας μέσω της [συλλογή εικόνων](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_images/), ενώ ένα [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, την περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις σε επίπεδο πλαισίου.

Αυτή η διαχωρισμός είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, διατηρήστε το επιστρεφόμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας κατά τη δημιουργία πλαισίων εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστερ εικόνες όπως PNG ή JPEG και διανυσματικές εικόνες SVG. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει τη φορητότητα, το μέγεθος αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, επομένως είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν από την εφαρμογή μορφοποίησης ή βελτιστοποίησης.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapecollection/addpictureframe/). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, ώστε η παρουσίαση να παραμένει αυτόνομη όταν μεταφερθεί σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια εικόνα JPEG, δημιουργεί ένα πλαίσιο στις φυσικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το πλαίσιο εικόνας ελέγχει την εμφανιζόμενη γεωμετρία· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόψετε ή συμπιέζετε μια εικόνα αργότερα.

## **Χρήση σχετικού κλίμακας**

[IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο. Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγής αντί να υπολογίζει τελικά διαστάσεις χειροκίνητα.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ή συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και επομένως είναι η πιο ασφαλής επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική διαδρομή μέσω του συνδέσμου [ISlidesPicture](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidespicture/) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα των δεδομένων εικόνας που αποθηκεύονται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο από την εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν αλλάξει η διαδρομή, μετακινηθεί το αρχείο ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα ενδέχεται να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να σταλούν μέσω email, αρχειοθετηθούν ή αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το συνδέει με ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμειγνύεται σε αυτό το παράδειγμα.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε μόνο ως αντικατάσταση συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτόνομη παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξάγετε μια εικόνα από υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πράγματι ένα [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας ενδέχεται να μην περιέχουν τα bytes της εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή ραστερ εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί απευθείας το [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/). Το παρακάτω παράδειγμα βρίσκει την πρώτη ενσωματωμένη ραστερ εικόνα σε μια διαφάνεια και τη αποθηκεύει ως PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Η αποθήκευση μέσω του [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που αποθηκεύονται στην παρουσίαση αντί για ένα μετατραπείσας ραστερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή SVG εικόνας**

Για μια SVG εικόνα, το [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) εκθέτει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG άμεσα αντί να ραστεροποιήσετε πρώτα την εικόνα.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι εξαγωγές ραστερ όπως PNG ή JPEG απαραίτητα αποδίδουν αυτό το διανυσματικό περιεχόμενο σε pixel. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης μια λειτουργία απόδοσης, έτσι τα εξαχθέντα γραφικά δεν πρέπει να θεωρούνται αντίγραφο byte‑by‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα του ενσωματωμένου [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/) όταν απαιτείται ο αρχικός διανυσματικός πόρος.

## **Περικοπή εικόνας**

Η περικοπή αλλάζει ποιο μέρος μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [IPictureFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/) είναι ποσοστά των διαστάσεων της πηγής εικόνας. Η περικοπή δεν διαγράφει αρχικά τα κρυμμένα pixel από την ενσωματωμένη εικόνα· απλώς αλλάζει την ορατή περιοχή.

Το παρακάτω παράδειγμα εντοπίζει ένα πλαίσιο εικόνας με ασφάλεια και εφαρμόζει τιμές περικοπής:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Επειδή τα κρυμμένα δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να τροποποιηθεί αργότερα χωρίς απώλεια των αρχικών pixel. Εάν το μέγεθος του αρχείου έχει μεγαλύτερη σημασία από την αντιστροφικότητα, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων περικομμένων εικόνων**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) αφαιρεί τα δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά πρόκειται για μια καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα αφαιρούμενα pixel δεν είναι πλέον διαθέσιμα για μετέπειτα ανεπερικοπή.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

Η μέθοδος μπορεί να προσθέσει έναν νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, εκείνα τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο τους, επομένως η διαγραφή των περικομμένων περιοχών δεν μειώνει απαραίτητα το συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστεροποιεί το αποτέλεσμα σε PNG.

## **Συμπίεση ραστερ εικόνων**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/compressimage/) μειώνει την ανάλυση της ραστερ εικόνας σε σχέση με το μέγεθος με το οποίο εμφανίζεται η εικόνα. Μπορεί επίσης να αφαιρέσει τις περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα έχει αλλάξει μέγεθος ή περικοπεί και `false` όταν δεν απαιτήθηκε καμία αλλαγή.

Χρησιμοποιήστε μια προ‑καθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ppicturescompression/) όταν μια τυπική στόχευση ανάλυσης αρκεί:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Μπορείτε να περάσετε μια προσαρμοσμένη θετική τιμή DPI αντί για τιμή enum όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το περιεχόμενο SVG και μεταβολής δεν μειώνεται από αυτή τη ροή συμπίεσης ραστερ. Επίσης, θυμηθείτε ότι η χαμηλότερη ανάλυση και οι διαγραμμένες περικομμένες περιοχές δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης βάσει του μεγαλύτερου μεγέθους με το οποίο η εικόνα θα προβληθεί ή εξαγάγεται στην πραγματικότητα, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Διαχείριση εφέ μετασχηματισμού εικόνας**

Για μια πλήρη ροή εργασιών που καλύπτει φωτεινότητα, αντίθεση, μετασχηματισμούς χρώματος, θόλωση, εφέ άλφα, αλυσιδωτές λειτουργίες, επιθεώρηση, αφαίρεση και επαλήθευση κύκλου, δείτε [Image Transform Effects](/slides/el/cpp/image-transform-effects/).

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις του [IPictureFrameLock](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το [aspect‑ratio lock](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) διατηρεί τις αναλογίες του σχήματος κατά την αλλαγή μεγέθους.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματοληπτεί ή να αλλάξει μόνιμα στο ίδιο λόγο αναλογίας.

## **Ρύθμιση τιμών StretchOffset**

Όταν η μέθοδος γέμισης εικόνας είναι stretch, οι τιμές stretch‑offset στο [IPictureFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/) ορίζουν το ορθογώνιο γέμισης σε σχέση με το οριακό πλαίσιο του πλαισίου εικόνας. Τα θετικά ποσοστά δημιουργούν εσωτερική απόσταση από την άκρη, ενώ τα αρνητικά ποσοστά δημιουργούν εξωτερική απόσταση.

Αυτό διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο μέρος της πηγής εικόνας είναι ορατό· οι offset τέντωσης αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γέμισμα εικόνας.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Χρησιμοποιήστε offset τέντωσης για τοποθέτηση γέμισης. Χρησιμοποιήστε ιδιότητες περικοπής όταν ο στόχος είναι η απόκρυψη των άκρων της πηγής εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και considerations εξαγωγής**

Οι κύριες ανταλλαγές γίνονται πιο εύκολες όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου εικόνας αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και επεξεργασία από διακομιστή, αλλά μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμείνουν διαθέσιμα στις αποθηκευμένες διαδρομές ή τοποθεσίες.
- **Περικοπή** είναι αρχικά μη καταστροφική. Τα κρυμμένα pixel παραμένουν ενσωματωμένα μέχρι οι περικομμένες περιοχές να διαγραφούν ρητά ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθη ραστερ εικόνες, αλλά θυσιάζει την πηγή ανάλυσής τους. Πρέπει να εφαρμοστεί αφού το τελικό μέγεθος στην διαφάνεια είναι γνωστό.
- **SVG εικόνες** πρέπει να παραμένουν ως SVG όταν η διατήρηση των διανυσμάτων είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι εξαγωγές διαφανειών σε ραστερ πάντα μετατρέπουν τη διαφάνεια σε pixel.
- **Επαναλαμβανόμενες εικόνες** πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) όταν είναι δυνατόν αντί να φορτώνουν επανειλημμένα το ίδιο αρχείο στη ροή εργασίας παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνων είναι συνήθως πιο αποτελεσματική όταν γίνεται επιλεκτικά: διατηρήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες ανάλογα με το πραγματικό μέγεθος προβολής, αφαιρέστε περικομμένα pixel μόνο όταν δεν απαιτείται επεξεργασία αργότερα, και αποφύγετε εξωτερικούς συνδέσμους εκτός εάν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδίου ανάπτυξης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου εικόνας και ενός πόρου εικόνας;**

Ένα [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) αντιπροσωπεύει έναν πόρο εικόνας που συνδέεται με την παρουσίαση. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) είναι ένα σχήμα σε μια διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση σε επίπεδο πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώνω ή να συνδέω εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή αποδοθεί χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές τοποθεσίες μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος αρχείου PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν μέρη της πηγής εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρησιμοποιήστε το [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ή τη συμπίεση εικόνας με αφαίρεση περιοχών περικοπής όταν αυτά τα pixel μπορούν να αφαιρεθούν μόνιμα.

**Μπορώ να επαναφέρω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση και η αφαίρεση περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγή εικόνας εκτός της παρουσίασης αν μπορεί να απαιτηθεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να χειρίζομαι τις SVG εικόνες;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η διανυσματική ακρίβεια είναι σημαντική. Το ενσωματωμένο [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/) μπορεί να εξαχθεί απευθείας. Η απόδοση μιας διαφάνειας σε μορφή ραστερ όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας διαφάνειας.

**Πώς να αποτρέψω μη ασφαλείς μετατροπές όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Δοκιμάστε το σχήμα με [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) πριν εφαρμόσετε μετατροπή χρόνου εκτέλεσης και αποθηκεύστε το αποτέλεσμα της μετατροπής σε τοπική μεταβλητή πριν έχετε πρόσβαση σε μέλη ειδικά για πλαίσια εικόνας.