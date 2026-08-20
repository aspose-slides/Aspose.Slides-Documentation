---
title: Διαχείριση Πλαισίων Εικόνας σε Παρουσιάσεις χρησιμοποιώντας C++
linktitle: Πλαίσιο Εικόνας
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
- εικόνα raster
- εικόνα SVG
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
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, περικόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στη Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: μια [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) διαχειρίζεται ενσωματωμένους πόρους εικόνας μέσω της [συλλογής εικόνων](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_images/), ενώ ένα [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) ελέγχει τη θέση, το μέγεθος, τη διαμόρφωση γραμμής, την περιστροφή, την περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις σε επίπεδο πλαισίου.

Αυτός ο διαχωρισμός είναι χρήσιμος όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστρεφόμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας κατά τη δημιουργία πλαισίων εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ρεαλιστικές εικόνες όπως PNG ή JPEG και διανυσματικές εικόνες SVG. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει τη φορητότητα, το μέγεθος του αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, οπότε είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με το [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapecollection/addpictureframe/). Η εικόνα γίνεται μέρος του πακέτου της παρουσίασης, ώστε η παρουσίαση να παραμένει αυτό-contained όταν μεταφερθεί σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια εικόνα JPEG, δημιουργεί ένα πλαίσιο στις εγγενείς διαστάσεις της εικόνας και εφαρμόζει διαμόρφωση γραμμής και περιστροφή:

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

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόνετε ή συμπιέζετε μια εικόνα αργότερα.

## **Χρήση σχετικής κλίμακας**

Το [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο. Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας πρέπει να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει τελικές διαστάσεις χειροκίνητα.

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

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ούτε συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας εντός της παρουσίασης και είναι επομένως η πιο ασφαλής επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική διαδρομή μέσω του [ISlidesPicture](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidespicture/) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν το όγκο των δεδομένων εικόνας που αποθηκεύονται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος γίνει μη διαθέσιμος, η συνδεδεμένη εικόνα μπορεί να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να σταλούν μέσω email, να αρχειοθετηθούν ή να αποδειχθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το συνδέει με ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμιγνύεται σε αυτό το παράδειγμα.

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

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι προγραμματισμένη. Μην τους χρησιμοποιείτε μόνο ως υποκατάστατο συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτό-contained παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξάγετε μια εικόνα από μια υπάρχουσα παρουσίαση, ελέγξτε ότι το σχήμα είναι πραγματικά ένα [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας μπορεί να μην περιέχουν bytes εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή ρεαλιστικής εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί το [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) απευθείας. Το παρακάτω παράδειγμα βρίσκει την πρώτη ενσωματωμένη ρεαλιστική εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

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

Η αποθήκευση μέσω του [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που αποθηκεύονται στην παρουσίαση αντί για ένα μετατρεπόμενο ρεαλιστικό αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή εικόνας SVG**

Για μια εικόνα SVG, το [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) εκθέτει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG απευθείας αντί να ραστεριστεί η εικόνα πρώτα.

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

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι εξαγωγές σε ρεαλιστικό μορφότυπο όπως PNG ή JPEG μετατρέπουν υποχρεωτικά αυτό το διανυσματικό περιεχόμενο σε pixel. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης μια διαδικασία απόδοσης, επομένως τα εξαγόμενα γραφικά δεν πρέπει να θεωρούνται ακριβές αντίγραφα byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα του ενσωματωμένου [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/) όταν απαιτείται ο ίδιος διανυσματικός πόρος.

## **Περικοπή εικόνας**

Η περικοπή αλλάζει ποιο τμήμα μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [IPictureFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η περικοπή δεν διαγράφει αρχικά τα κρυμμένα pixel από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

Το παρακάτω παράδειγμα βρίσκει με ασφάλεια ένα πλαίσιο εικόνας και εφαρμόζει τιμές περικοπής:

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

Επειδή τα κρυφά δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να τροποποιηθεί αργότερα χωρίς απώλεια των αρχικών pixel. Εάν το μέγεθος του αρχείου είναι πιο σημαντικό από την αντιστροφή, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων περικομμένων εικόνων**

Το [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) αφαιρεί δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα αφαιρεθέντα pixel δεν είναι πλέον διαθέσιμα για μετέπειτα επαναπέρικοπή.

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

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται και από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο, οπότε η διαγραφή των περικομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστερίζει το αποτέλεσμα σε PNG.

## **Συμπίεση ρεαλιστικών εικόνων**

Το [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/compressimage/) μειώνει την ανάλυση ρεαλιστικής εικόνας σε σχέση με το μέγεθος με το οποίο προβάλλεται η εικόνα. Μπορεί επίσης να αφαιρέσει περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα μεταβλήθηκε σε μέγεθος ή περικόπη και `false` όταν δεν χρειάστηκε αλλαγή.

Χρησιμοποιήστε μια προορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/picturescompression/) όταν μια τυπική στόχευση ανάλυσης είναι επαρκής:

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

Μια προσαρμοσμένη θετική τιμή DPI μπορεί να περάσει αντί για τιμή enum όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ρεαλιστικές εικόνες. Το περιεχόμενο SVG και των μεταφορμών δεν μειώνεται από αυτή τη ροή συμπίεσης ρεαλιστικών εικόνων. Επίσης, θυμηθείτε ότι η χαμηλότερη ανάλυση και οι διαγραμμένες περικομμένες περιοχές δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης βάσει του μεγαλύτερου μεγέθους στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Έλεγχος εφέ εικόνας**

Τα εφέ εικόνας αποθηκεύονται στην εικόνα που χρησιμοποιεί το πλαίσιο. Η συλλογή μετασχηματισμών εικόνας μπορεί να περιέχει εφέ όπως σταθερή διαμόρφωση alfa για διαφάνεια και φωτεινότητα για αντίθεση. Το παρακάτω παράδειγμα διαβάζει με ασφάλεια και τα δύο είδη εφέ από το πρώτο πλαίσιο εικόνας σε μια διαφάνεια:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
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
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

Αυτά τα εφέ αλλάζουν τον τρόπο απόδοσης της εικόνας στο πλαίσιο· δεν επανεγγράφουν τα αρχικά ενσωματωμένα bytes της εικόνας.

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις του [IPictureFrameLock](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το [κλείδωμα λόγου διαστάσεων](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) διατηρεί τις αναλογίες του σχήματος κατά την αλλαγή μεγέθους.

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

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματοληπτεί ή να μετατραπεί μόνιμα στο ίδιο λόγο διαστάσεων.

## **Ρύθμιση τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι «stretch», οι τιμές stretch‑offset στο [IPictureFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/) ορίζουν το ορθογώνιο γεμίσματος σε σχέση με το περιβόλι του πλαισίου εικόνας. Θετικά ποσοστά δημιουργούν εσοχές από την άκρη, ενώ αρνητικά ποσοστά δημιουργούν εξώματα.

Αυτό διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· τα stretch‑offset αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γεμίσμα εικόνας.

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

Χρησιμοποιήστε stretch‑offsets για τοποθέτηση γεμίσματος. Χρησιμοποιήστε τις ιδιότητες περικοπής όταν ο στόχος είναι η απόκρυψη των άκρων της πηγαίας εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και ζητήματα εξαγωγής**

Οι κύριες ανταλλαγές είναι πιο εύκολο να διαχειριστούν όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτό‑contained και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση στην πλευρά του διακομιστή, αλλά οι μεγάλες ρεαλιστικές εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να κρατήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή θέσεις.
- **Περικοπή** είναι αρχικά μη καταστροφική. Τα κρυμμένα pixel παραμένουν ενσωματωμένα μέχρι να διαγραφούν ρητά οι περικομμένες περιοχές ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθη ρεαλιστικές εικόνες, αλλά ανταλλάσσει την αρχική ανάλυση. Πρέπει να εφαρμοστεί μετά τον καθορισμό του τελικού μεγέθους στην διαφάνεια.
- **Εικόνες SVG** θα πρέπει να παραμένουν ως SVG όταν η διατήρηση διανυσματικού χαρακτήρα είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεστε τον ίδιο διανυσματικό πόρο. Οι εξαγωγές διαφάνειας σε ρεαλιστικό μορφότυπο πάντα μετατρέπουν τη διαφάνεια σε pixel.
- **Επαναλαμβανόμενες εικόνες** θα πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) όταν είναι δυνατόν αντί να φορτώνουν επανειλημμένα το ίδιο αρχείο στη ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν γίνεται επιλεκτικά: κρατήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες ανάλογα με το πραγματικό μέγεθος προβολής, αφαιρέστε περικομμένα pixel μόνο όταν δεν απαιτείται μετέπειτα επεξεργασία, και αποφύγετε εξωτερικούς συνδέσμους εκτός εάν η διαχείριση εξαρτήσεων είναι μέρος του σχεδίου διανομής.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου εικόνας και πόρου εικόνας;**

Ένα [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) αντιπροσωπεύει έναν πόρο εικόνας που συνδέεται με την παρουσίαση. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) είναι ένα σχήμα σε μια διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση σε επίπεδο πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Να ενσωματώνω ή να συνδέω εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή αποδοθεί χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές τοποθεσίες μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος του αρχείου PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν μέρη της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρήση του [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ή της συμπίεσης εικόνας με αφαίρεση περικομμένων περιοχών όταν τα pixel μπορούν να παραλειφθούν μόνιμα.

**Μπορώ να αποκαταστήσω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ρεαλιστική ανάλυση και η αφαίρεση περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Κρατήστε την αρχική πηγαία εικόνα εκτός της παρουσίασης εάν απαιτείται επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να διαχειρίζομαι τις εικόνες SVG;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η διανυσματική ακεραιότητα έχει σημασία. Το ενσωματωμένο [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides.isvgimage/) μπορεί να εξαχθεί απευθείας. Η απόδοση μιας διαφάνειας σε ρεαλιστικό μορφότυπο όπως PNG ή JPEG ραστερίζει το SVG ως μέρος της εικόνας διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπων όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Δοκιμάστε το σχήμα με το [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) πριν εφαρμόσετε μετατροπή τύπου χρόνου εκτέλεσης και εκχωρήστε το αποτέλεσμα σε τοπική μεταβλητή πριν προσπελάσετε μέλη πλαισίου εικόνας.