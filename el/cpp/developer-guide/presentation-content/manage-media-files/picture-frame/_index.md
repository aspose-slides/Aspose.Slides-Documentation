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
- προσθήκη εικόνας
- δημιουργία εικόνας
- εξαγωγή εικόνας
- ραστική εικόνα
- διανυσματική εικόνα
- περικοπή εικόνας
- περικομμένη περιοχή
- ιδιότητα StretchOff
- μορφοποίηση πλαισίου εικόνας
- ιδιότητες πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- λόγος διαστάσεων
- διαφάνεια εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για C++. Βελτιστοποιήστε τη ροή εργασίας σας και ενισχύστε τον σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Ένα πλαίσιο εικόνας είναι ένα σχήμα που περιέχει μια εικόνα—είναι όπως μια εικόνα σε ένα πλαίσιο.  

Μπορείτε να προσθέσετε μια εικόνα σε μια διαφάνεια μέσω ενός πλαισίου εικόνας. Με αυτόν τον τρόπο, μπορείτε να μορφοποιήσετε την εικόνα μορφοποιώντας το πλαίσιο εικόνας.  

{{% alert  title="Tip" color="info" %}} 
Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες.  
{{% /alert %}} 

## **Δημιουργία πλαισίου εικόνας**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation class](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_p_p_image) προσθέτοντας μια εικόνα στη [IImagescollection](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_image_collection) που είναι συσχετισμένη με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος.  
4. Καθορίστε το πλάτος και το ύψος της εικόνας.  
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.picture_frame) βασισμένο στο πλάτος και το ύψος της εικόνας, μέσω της μεθόδου `AddPictureFrame` που εκτίθεται από το αντικείμενο σχήματος που είναι συσχετισμένο με τη συγκεκριμένη διαφάνεια.  
6. Προσθέστε ένα πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

Αυτός ο κώδικας C++ δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας:

```c++
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
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Η διαδρομή προς τον φάκελο εγγράφων.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Φορτώνει την επιθυμητή παρουσίαση
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Προσπελαίνει την πρώτη διαφάνεια
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Φορτώνει την εικόνα που θα προστεθεί στη συλλογή εικόνων της παρουσίασης
// Λαμβάνει την εικόνα
auto image = Images::FromFile(filePath);

// Προσθέτει μια εικόνα στη συλλογή εικόνων της παρουσίασης
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Προσθέτει ένα πλαίσιο εικόνας στη διαφάνεια
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Ορίζει το σχετικό πλάτος και ύψος κλίμακας
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Εφαρμόζει μορφοποίηση στο PictureFrame
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Γράφει το αρχείο PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Τα πλαίσια εικόνας σάς επιτρέπουν να δημιουργήσετε γρήγορα διαφάνειες παρουσίασης βασισμένες σε εικόνες. Όταν συνδυάζετε το πλαίσιο εικόνας με τις επιλογές αποθήκευσης του Aspose.Slides, μπορείτε να χειριστείτε τις λειτουργίες εισόδου/εξόδου για να μετατρέψετε εικόνες από μια μορφή σε άλλη. Μπορείτε να δείτε τις παρακάτω σελίδες: μετατροπή [εικόνας σε JPG](https://products.aspose.com/slides/el/cpp/conversion/image-to-jpg/); μετατροπή [JPG σε εικόνα](https://products.aspose.com/slides/el/cpp/conversion/jpg-to-image/); μετατροπή [JPG σε PNG](https://products.aspose.com/slides/el/cpp/conversion/jpg-to-png/), μετατροπή [PNG σε JPG](https://products.aspose.com/slides/el/cpp/conversion/png-to-jpg/); μετατροπή [PNG σε SVG](https://products.aspose.com/slides/el/cpp/conversion/png-to-svg/), μετατροπή [SVG σε PNG](https://products.aspose.com/slides/el/cpp/conversion/svg-to-png/).  
{{% /alert %}}

## **Δημιουργία πλαισίου εικόνας με σχετική κλίμακα**

Με την αλλαγή της σχετικής κλιμάκωσης μιας εικόνας, μπορείτε να δημιουργήσετε ένα πιο σύνθετο πλαίσιο εικόνας.  

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation class](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε μια εικόνα στη συλλογή εικόνων της παρουσίασης.  
4. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_p_p_image) προσθέτοντας μια εικόνα στη [IImagescollection](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_image_collection) που είναι συσχετισμένη με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος.  
5. Καθορίστε το σχετικό πλάτος και ύψος της εικόνας στο πλαίσιο εικόνας.  
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

Ο παρακάτω κώδικας C++ δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας με σχετική κλίμακα:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Η διαδρομή προς το φάκελο εγγράφων.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Φορτώνει την επιθυμητή παρουσίαση
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Προσεγγίζει την πρώτη διαφάνεια
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Φορτώνει την εικόνα που θα προστεθεί στη συλλογή εικόνων της παρουσίασης
// Λαμβάνει την εικόνα
auto image = Images::FromFile(filePath);

// Προσθέτει μια εικόνα στη συλλογή εικόνων της παρουσίασης
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Προσθέτει ένα πλαίσιο εικόνας στη διαφάνεια
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Ορίζει το σχετικό πλάτος και ύψος κλίμακας
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Γράφει το αρχείο PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Εξαγωγή ραστών εικόνων από πλαίσια εικόνας**

Μπορείτε να εξάγετε ραστές εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.picture_frame) και να τις αποθηκεύσετε σε PNG, JPG και άλλες μορφές. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα από το έγγραφο "sample.pptx" και να την αποθηκεύσετε σε μορφή PNG.

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **Εξαγωγή SVG εικόνων από πλαίσια εικόνας**

Όταν μια παρουσίαση περιέχει SVG γραφικά τοποθετημένα μέσα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/pictureframe/), το Aspose.Slides για C++ σας επιτρέπει να ανακτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη πιστότητα. Διέρχοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/pictureframe/), να ελέγξετε αν το υποκείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) περιέχει SVG περιεχόμενο και, στη συνέχεια, να αποθηκεύσετε αυτήν την εικόνα σε δίσκο ή σε ροή στη φυσική της μορφή SVG.

Ο παρακάτω κώδικας C++ δείχνει πώς να εξάγετε μια SVG εικόνα από ένα πλαίσιο εικόνας:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
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
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Λήψη διαφάνειας μιας εικόνας**

Το Aspose.Slides σας επιτρέπει να λάβετε το εφέ διαφάνειας που εφαρμόζεται σε μια εικόνα. Αυτός ο κώδικας C++ δείχνει τη λειτουργία:

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="info" %}} 
Όλες οι επιδράσεις που εφαρμόζονται σε εικόνες μπορούν να βρεθούν στο [Aspose::Slides::Effects](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/).  
{{% /alert %}}

## **Λήψη φωτεινότητας και αντίθεσης μιας εικόνας**

Το Aspose.Slides σας επιτρέπει να λάβετε το εφέ φωτεινότητας και αντίθεσης που εφαρμόζεται σε μια εικόνα. Η διεπαφή [ILuminance](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iluminance/) αντιπροσωπεύει αυτό το εφέ μετασχηματισμού εικόνας.  

Αυτός ο κώδικας C++ δείχνει πώς να λάβετε τις ρυθμίσεις φωτεινότητας και αντίθεσης από ένα πλαίσιο εικόνας:

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Μορφοποίηση πλαισίου εικόνας**

Το Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορούν να εφαρμοστούν σε ένα πλαίσιο εικόνας. Χρησιμοποιώντας αυτές τις επιλογές, μπορείτε να τροποποιήσετε ένα πλαίσιο εικόνας ώστε να ταιριάζει σε συγκεκριμένες απαιτήσεις.  

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation class](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_p_p_image) προσθέτοντας μια εικόνα στη [IImagescollection](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_image_collection) που είναι συσχετισμένη με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος.  
4. Καθορίστε το πλάτος και το ύψος της εικόνας.  
5. Δημιουργήστε ένα `PictureFrame` βασισμένο στο πλάτος και το ύψος της εικόνας, μέσω της μεθόδου [AddPictureFrame](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) που εκτίθεται από το αντικείμενο [IShapes](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_shape_collection) που συνδέεται με τη συγκεκριμένη διαφάνεια.  
6. Προσθέστε το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.  
7. Ορίστε το χρώμα γραμμής του πλαισίου εικόνας.  
8. Ορίστε το πάχος γραμμής του πλαισίου εικόνας.  
9. Περιστρέψτε το πλαίσιο εικόνας δίνοντάς του είτε θετική είτε αρνητική τιμή.  
   * Μία θετική τιμή περιστρέφει την εικόνα δεξιόστροφα.  
   * Μία αρνητική τιμή περιστρέφει την εικόνα αριστερόστροφα.  
10. Προσθέστε το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.  
11. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

Αυτός ο κώδικας C++ δείχνει τη διαδικασία μορφοποίησης του πλαισίου εικόνας:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Η διαδρομή προς τον φάκελο εγγράφων.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Φορτώνει την επιθυμητή παρουσίαση
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Προσπελαίνει την πρώτη διαφάνεια
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Φορτώνει την εικόνα που θα προστεθεί στη συλλογή εικόνων της παρουσίασης
// Λαμβάνει την εικόνα
auto image = Images::FromFile(filePath);

// Προσθέτει μια εικόνα στη συλλογή εικόνων της παρουσίασης
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Προσθέτει ένα πλαίσιο εικόνας στη διαφάνεια
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Ορίζει το σχετικό πλάτος και ύψος κλίμακας
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Γράφει το αρχείο PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}
Η Aspose ανέπτυξε πρόσφατα έναν [δωρεάν Collage Maker](https://products.aspose.app/slides/el/collage). Αν χρειαστείτε ποτέ να [συγχωνεύσετε JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, [δημιουργήσετε π_grid από φωτογραφίες](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτήν την υπηρεσία.  
{{% /alert %}}

## **Προσθήκη εικόνας ως σύνδεσμο**

Για να αποτρέψετε μεγάλα μεγέθη παρουσιάσεων, μπορείτε να προσθέσετε εικόνες (ή βίντεο) μέσω συνδέσμων αντί να ενσωματώνετε τα αρχεία απευθείας στις παρουσιάσεις. Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε μια εικόνα και βίντεο σε μια θέση κράτησης:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Περικοπή εικόνων**

Αυτός ο κώδικας C++ δείχνει πώς να περικόψετε μια υπάρχουσα εικόνα σε μια διαφάνεια: 

```CPP
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// Δημιουργεί νέο αντικείμενο εικόνας
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Προσθέτει ένα πλαίσιο εικόνας σε μια διαφάνεια
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Περικόπτει την εικόνα (τιμές ποσοστών)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Αποθηκεύει το αποτέλεσμα
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Διαγραφή περιττών περιοχών μιας εικόνας**

Αν θέλετε να διαγράψετε τις περικομμένες περιοχές μιας εικόνας που βρίσκεται σε ένα πλαίσιο, μπορείτε να χρησιμοποιήσετε τη μέθοδο [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Αυτή η μέθοδος επιστρέφει την περικομμένη εικόνα ή την αρχική εικόνα εάν η περικοπή είναι περιττή.  

Αυτός ο κώδικας C++ δείχνει τη λειτουργία: 

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Λαμβάνει το PictureFrame από την πρώτη διαφάνεια
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Διαγράφει τις περικομμένες περιοχές της εικόνας του PictureFrame και επιστρέφει την περικομμένη εικόνα
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Αποθηκεύει το αποτέλεσμα
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 
Η μέθοδος [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) προσθέτει την περικομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Εάν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/pictureframe/), αυτή η ρύθμιση μπορεί να μειώσει το μέγεθος της παρουσίασης. Διαφορετικά, ο αριθμός των εικόνων στην τελική παρουσίαση θα αυξηθεί.  

Αυτή η μέθοδος μετατρέπει αρχεία WMF/EMF σε ραστές PNG εικόνες κατά τη διαδικασία περικοπής.  
{{% /alert %}}

## **Συμπίεση εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/compressimage/). Αυτή η μέθοδος συμπιέζει μια εικόνα μειώνοντας το μέγεθός της με βάση το μέγεθος του σχήματος και την καθορισμένη ανάλυση, με δυνατότητα διαγραφής των περικομμένων περιοχών.  

Αντιστοιχεί στην προσαρμογή μεγέθους και ανάλυσης της εικόνας όπως η λειτουργία **Picture Format -> Compress Pictures -> Resolution** του PowerPoint.  

Τα παρακάτω παραδείγματα C++ δείχνουν πώς να συμπιέσετε μια εικόνα σε μια παρουσίαση ορίζοντας μια στοχευμένη ανάλυση και, προαιρετικά, αφαιρώντας τις περικομμένες περιοχές:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Compress the image with a target resolution of 150 DPI (Web resolution) and remove cropped areas.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Check the result of the compression.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ή χρησιμοποιώντας απευθείας μια προσαρμοσμένη τιμή DPI:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Συμπιέζει την εικόνα στα 150 DPI (ανάλυση ιστού), αφαιρώντας τις περικομμένες περιοχές.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 
Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση με βάση το μέγεθος του σχήματος και το παρεχόμενο DPI. Οι περικομμένες περιοχές μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου.  
Αν η εικόνα είναι μεταγενέστερο αρχείο (WMF/EMF) ή SVG, η συμπίεση δεν θα εφαρμοστεί. Επιπλέον, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς ανάλογα με την ανάλυση, όπως συμβαίνει στο PowerPoint για εικόνες υψηλής ανάλυσης JPEG.  
{{% /alert %}}

## **Κλείδωμα λόγου διαστάσεων**

Αν θέλετε ένα σχήμα που περιέχει μια εικόνα να διατηρεί το λόγο διαστάσεων του ακόμη και μετά την αλλαγή των διαστάσεων της εικόνας, μπορείτε να χρησιμοποιήσετε τη μέθοδο [set_AspectRatioLocked()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) για να ορίσετε τη ρύθμιση *Lock Aspect Ratio*.  

Αυτός ο κώδικας C++ δείχνει πώς να κλειδώσετε το λόγο διαστάσεων ενός σχήματος:

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
Αυτή η ρύθμιση *Lock Aspect Ratio* διατηρεί μόνο το λόγο διαστάσεων του σχήματος και όχι της εικόνας που περιέχει.  
{{% /alert %}}

## **Χρήση της ιδιότητας StretchOff**

Χρησιμοποιώντας τις ιδιότητες [StretchOffsetLeft](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) και [StretchOffsetBottom](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) από τη διεπαφή [IPictureFillFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_picture_fill_format) και την κλάση [PictureFillFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.picture_fill_format), μπορείτε να ορίσετε ένα ορθογώνιο γεμίσματος.  

Όταν καθορίζεται η τέντωσή μιας εικόνας, ένα πηγαίο ορθογώνιο κλιμακώνεται ώστε να ταιριάζει στο καθορισμένο ορθογώνιο γεμίσματος. Κάθε πλευρά του ορθογωνίου γεμίσματος ορίζεται από ένα ποσοστό απόσταση από την αντίστοιχη πλευρά του οριοθετημένου κουτιού του σχήματος. Ένα θετικό ποσοστό ορίζει εντὸση. Ένα αρνητικό ποσοστό ορίζει έξταση.  

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ένα ορθογώνιο `AutoShape`.  
4. Δημιουργήστε μια εικόνα.  
5. Ορίστε τον τύπο γεμίσματος του σχήματος.  
6. Ορίστε τη λειτουργία γεμίσματος εικόνας του σχήματος.  
7. Προσθέστε μια εικόνα για να γεμίσει το σχήμα.  
8. Καθορίστε τις αποστάσεις της εικόνας από την αντίστοιχη πλευρά του οριοθετημένου κουτιού του σχήματος.  
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

Αυτός ο κώδικας C++ δείχνει μια διαδικασία όπου χρησιμοποιείται η ιδιότητα StretchOff:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

### Πώς μπορώ να μάθω ποια μορφές εικόνας υποστηρίζονται για το PictureFrame;

Το Aspose.Slides υποστηρίζει τόσο ραστές εικόνες (PNG, JPEG, BMP, GIF κ.λπ.) όσο και διανυσματικές εικόνες (π.χ., SVG) μέσω του αντικειμένου εικόνας που εκχωρείται σε ένα [PictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/pictureframe/). Η λίστα των υποστηριζόμενων μορφών γενικά επικαλύπτεται με τις δυνατότητες του κινητήρα μετατροπής διαφανειών και εικόνων.

### Πώς θα επηρεάσει η προσθήκη δεκάδων μεγάλων εικόνων το μέγεθος και την απόδοση του PPTX;

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση εικόνων βοηθά στη διατήρηση του μικρότερου μεγέθους της παρουσίασης, αλλά απαιτεί τα εξωτερικά αρχεία να παραμείνουν προσβάσιμα. Το Aspose.Slides παρέχει τη δυνατότητα προσθήκης εικόνων μέσω συνδέσμου για μείωση του μεγέθους του αρχείου.

### Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας ώστε να μην κινείται/μεγαλώνει τυχαία;

Χρησιμοποιήστε [shape locks](https://reference.aspose.com/slides/el/cpp/aspose.slides/pictureframe/get_pictureframelock/) για ένα [PictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/pictureframe/) (π.χ., απενεργοποίηση της μετακίνησης ή της αλλαγής μεγέθους). Ο μηχανισμός κλειδώματος περιγράφεται για σχήματα σε ένα ξεχωριστό [article about protection](/slides/el/cpp/applying-protection-to-presentation/) και υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένων των [PictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/pictureframe/).

### Διατηρείται η ακρίβεια του διανυσματικού SVG κατά την εξαγωγή μιας παρουσίασης σε PDF/εικόνες;

Το Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/pictureframe/) ως το αρχικό διάνυσμα. Κατά την [εξαγωγή σε PDF](/slides/el/cpp/convert-powerpoint-to-pdf/) ή σε [ραστικές μορφές](/slides/el/cpp/convert-powerpoint-to-png/), το αποτέλεσμα μπορεί να είναι ραστερισμένο ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG αποθηκεύεται ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.