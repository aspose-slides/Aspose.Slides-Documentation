---
title: Διαχείριση Εφέ Μετασχηματισμού Εικόνας σε Παρουσιάσεις με C++
linktitle: Εφέ Μετασχηματισμού Εικόνας
type: docs
weight: 11
url: /el/cpp/image-transform-effects/
keywords:
- μετασχηματισμός εικόνας
- εφέ εικόνας
- φωτεινότητα
- αντίθεση
- γκρι κλίμακα
- δυοτονικό
- απόχρωση
- HSL
- αντικατάσταση χρώματος
- θόλωση
- διαφάνεια
- εφέ άλφα
- αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Εφαρμόστε, συνδέστε, επιθεωρήστε, αφαιρέστε και επαληθεύστε εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με Aspose.Slides για C++."
---
## **Επισκόπηση**

Το Aspose.Slides αντιπροσωπεύει τις ρυθμίσεις εικόνας ως μια ταξινομημένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το πλαίσιο του [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) και αποκτήστε πρόσβαση στο [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/). Η επιστρεφόμενη [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) σας επιτρέπει να προσθέσετε, να απαριθμήσετε, να επιθεωρήσετε, να αφαιρέσετε και να καθαρίσετε τα εφέ χωρίς να ξαναγράψετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο δείχνει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετασχηματισμούς χρωμάτων, θολώση, διαφάνεια, τακτοποιημένες αλυσίδες εφέ, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση κυκλικής μεταφοράς PPTX.

## **Κατανόηση της Ιδιοκτησίας των Εφέ και Επαναχρησιμοποίησης Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) αποθηκεύει ή αναφέρεται στα δεδομένα της πηγής εικόνας που ανήκει στην παρουσίαση.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) ανήκει σε ένα γεμίσμα εικόνας και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμών εικόνας.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γεμίσμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Κατά συνέπεια, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). Όταν το ίδιο `IPPImage` περνάνε στο [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμών. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι, ακόμη και αν όλα επαναχρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `ISlidesPicture::get_ImageTransform` χρησιμοποιείται επίσης από άλλα γεμίσματα εικόνας, όπως σχήμα ή φόντο διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν στα πλαίσια εικόνας.

## **Χρήση Έγκυρων Εύρων Παραμέτρων και Μονάδων**

Οι παρουσιασμένες μέθοδοι χρησιμοποιούν τα ακόλουθα εννοιολογικά εύρη και μονάδες. Κρατήστε τις τιμές σε αυτά τα εύρη ακόμη και αν κάποια έκδοση της βιβλιοθήκης δεν απορρίψει αμέσως κάθε εκτός εύρος τιμή· η μορφή του στόχου παρουσίασης μπορεί να κανονικοποιήσει, παραλείψει ή απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίξει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` μέχρι `100`, ποσοστό· το `0` αφήνει το στοιχείο αμετάβλητο. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Καμία | Χωρίς αριθμητικές παραμέτρους. Το άλφα παραμένει αμετάβλητο. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Δύο χρώματα για σκούρα και ανοιχτά pixel. Τα κανάλια RGB και άλφα στο `System::Drawing::Color` χρησιμοποιούν τιμές από `0` έως `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Η απόχρωση είναι από `0` (συμπεριλαμβανομένου) έως `360` (αποκλειστικό) μοίρες· το ποσό είναι από `-100` μέχρι `100`, ποσοστό. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι από `0` (συμπεριλαμβανομένου) έως `360` (αποκλειστικό) μοίρες· η κορεστικότητα και φωτεινότητα είναι από `-100` μέχρι `100`, ποσοστό. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` έως `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετράται σε points· το `grow` ελέγχει αν το θολό περιεχόμενο μπορεί να εκτείνεται εκτός των αρχικών ορίων. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` έως `100` για κανονική κλιμάκωση διαφάνειας: το `0` είναι πλήρως διαφανές και το `100` διατηρεί το υπάρχον άλφα. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` έως `100`, ποσοστό διαφάνειας. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` έως `100`, ποσοστό ορίου άλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή πάνω γίνονται αδιαφανείς. |

Για σταθερή διαμόρφωση άλφα, η διαφάνεια και η αδιαφάνεια είναι συμπληρωματικές. Για παράδειγμα, η 35 % διαφάνεια αντιστοιχεί σε ποσό σταθεροποίησης άλφα 65 %.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) επιστρέφει μια λειτουργία [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/). Οι κλιμακωτές των παραμέτρων του παρέχονται κατά τη δημιουργία της λειτουργίας. Η μέθοδος `IBrightnessContrast::GetEffective` επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να επιθεωρηθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, έπειτα αποδίδει μια προεπισκόπηση χωρίς να τροποποιήσει την ενσωματωμένη εικόνα:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) είναι μια επέκταση εφέ εικόνας Office 2010 και είναι λιγότερο φορητή από το τυπικό εφέ φωτεινότητας DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά μια διαδρομή PPTX, χρησιμοποιήστε το [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα του αρχείου ξανά. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διάκριση με περισσότερες λεπτομέρειες.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν τον ίδιο πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, δυοτονικό, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `get_Color1` αντιστοιχίζει σκούρα pixel, ενώ το `get_Color2` αντιστοιχίζει ανοιχτά pixel. Αυτό το καθιστά ένα χρήσιμο παράδειγμα εφέ των ρυθμίσεων του οποίου είναι πιο πολύπλοκο από μια μονή κλιμακωτή τιμή.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα ενώ διατηρεί το άλφα. Είναι διαφορετικό από το [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), το οποίο αντιστοιχίζει ένα χρώμα προέλευσης σε άλλο και εκθέτει και τις μορφές χρώματος προέλευσης και προορισμού.

### **Εφαρμογή Κατωφλίου Φωτεινότητας**

Ένα κατώφλι φωτεινότητας μπορεί να κάνει τα αχνά σημάδια σε σαρωμένη σελίδα πιο ευανάγνωστα έναντι του φόντου. Το [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) διατηρεί ενδιάμεσες αποχρώσεις του γκρι. Το [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) αντιστοιχίζει τη φωτεινότητα σε μαύρο ή λευκό, ενώ το [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) εφαρμόζει ένα κατώφλι στην αδιαφάνεια.

Το κατώφλι φωτεινότητας κυμαίνεται από 0 % έως 100 %, συμπεριλαμβανομένου. Τα pixel κάτω από το κατώφλι γίνονται μαύρα. Τα pixel στο ή πάνω από αυτό γίνονται λευκά. Η αύξηση του κατωφλίου κάνει περισσότερες αποχρώσεις μαύρες επειδή περισσότερα pixel πέφτουν κάτω από το όριο.

Κατεβάστε το αρχείο [grayscale-swatches.png](grayscale-swatches.png) στον φάκελο εργασίας. Κάθε ετικέτα δείχνει το αρχικό επίπεδο γκρι σε κλίμακα από 0 έως 255. Το παράδειγμα τοποθετεί το αρχικό δίπλα σε δύο αντίγραφα και αποθηκεύει το κατώφλι κάθε αντιγράφου στην παρουσίαση.

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ανοίξτε την παραγόμενη παρουσίαση στο PowerPoint για να συγκρίνετε τα τρία πλαίσια. Το δείγμα με ετικέτα 96 έχει περίπου 38 % φωτεινότητα (96 από 255). Γίνεται λευκό στο κατώφλι 20 % και μαύρο στο κατώφλι 60 %.

![Αρχικά δείγματα γκρι κλίμακας δίπλα στα αποτελέσματα μαύρου‑λευκού σε κατώφλια φωτεινότητας 20 % και 60 %](luminance-threshold.png)

## **Προσθήκη Θολώσης, Διαφάνειας και Εφέ Άλφα**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του άλφα. Ορίστε το `grow` σε `true` όταν η θολή άκρη μπορεί να επεκταθεί πέρα από τα αρχικά όρια εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, έτσι τα μερικώς διαφανή pixel παραμένουν αντιπροσωπευτικά. Το [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) αντιθέτως εκχωρεί μία τιμή άλφα σε όλα τα pixel. Το [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) μετατρέπει το άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν το [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), το οποίο κάνει κάθε μη μηδενικό άλφα πλήρως αδιαφανές· το [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), το οποίο κάνει κάθε άλφα κάτω από 100 % πλήρως διαφανές· και το [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), το οποίο μετατρέπει το άλφα σε `100% - alpha`.

## **Δημιουργία Τακτοποιημένης Αλυσίδας Εφέ**

Κάθε μέθοδος `Add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο σχεδιαστής χρησιμοποιεί τη συλλογή ως μια τακτοποιημένη αλυσίδα επεξεργασίας: η έξοδος της λειτουργίας 0 γίνεται η είσοδος της λειτουργίας 1, κ.ο.π. Συνεπώς, οι ίδιες λειτουργίες αλλά σε διαφορετική σειρά μπορούν να παραγάγουν διαφορετική εικόνα.

Για παράδειγμα, η γκρι κλίμακα ακολουθούμενη από απόχρωση αφαιρεί πρώτα πληροφορία χρωμάτων και στη συνέχεια επαναχρωματίζει το αποτέλεσμα φωτεινότητας. Η απόχρωση ακολουθούμενη από γκρι κλίμακα αφαιρεί την απόχρωση ξανά. Ομοίως, η αντικατάσταση άλφα μπορεί να επικαλυφθεί με τιμές άλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές διαφορές τους.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ανοίγει ξανά την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργιών όσο και τη σειρά τους και αποδίδει το ξανά ανοιγμένο αποτέλεσμα:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που να περιορίζει λειτουργίες χρώματος, άλφα και θολώσης σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί τις διακυμάνσεις RGB που παρήχθηκαν από προηγούμενα εφέ χρώματος· η γκρι κλίμακα μετά το δυοτονικό αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες άλφα «ceiling», «floor», «replace» ή «bi‑level» μπορούν να απορρίψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Δημιουργήστε την αλυσίδα σύμφωνα με την επιθυμητή ακολουθία επεξεργασίας pixel αντί να τη θεωρείτε ως μη ταξινομημένες σημαίες μορφοποίησης.

<!-- visual-explanation:image-transform-effects:start -->
[![Η ίδια εικόνα περνάει πρώτα από γκρι κλίμακα και μετά από απόχρωση, και αντίστροφα. Οι δύο τελικές γκρι εικόνες έχουν διαφορετικούς τόνους.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Σε αυτή την εικονογραφική απόδοση Aspose.Slides for .NET 26.11, μια απόχρωση 220° στο 25 % δεν αλλάζει τη γκρι εικόνα. Η εφαρμογή της ίδιας απόχρωσης πριν από τη γκρι κλίμακα δημιουργεί διαφορετικούς τόνους.*
<!-- visual-explanation:image-transform-effects:end -->

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `ISlidesPicture::get_ImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει απευθείας εγγράψιμα μέλη. Για παράδειγμα, το [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) εκθέτει `set_Radius` και `set_Grow`, το [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) εκθέτει `set_Amount`, και το [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) εκθέτει `set_Threshold`. Τα εφέ χρώματος όπως το [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) εκθέτουν μεταβλητά αντικείμενα [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/).

Κάποια διεπαφή λειτουργιών, όπως τα [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/), και [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/), δεν εκθέτουν τις κλιμακωτές δημιουργίας τους ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στη ζητούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει το `GetEffective()` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων εξαρτημένων από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο σχεδιαστής, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και επιθεωρεί αποτελεσματικές τιμές για μερικές κοινές λειτουργίες:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
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

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
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

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Εφέ χωρίς παραμέτρους όπως γκρι κλίμακα, αλφα «ceiling» και αλφα «inverse» έχουν ακόμα αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν κλιμακωτές ρυθμίσεις για εκτύπωση. Η παρουσία τους και η θέση τους στη συλλογή είναι η σημαντική πληροφορία.

## **Αφαίρεση ή Εκκαθάριση Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) για να αφαιρέσετε μία λειτουργία με βάση το δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, αναζητήστε πρώτα τον στόχο και αφαιρέστε τον μετά τον εναύσον. Χρησιμοποιήστε τη μέθοδο `Clear()` για να αφαιρέσετε ολόκληρη την αλυσίδα.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
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
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Η αφαίρεση ή η εκκαθάριση των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν συμπιέζει ξανά και δεν τροποποιεί με κανιον τρόπο τον επαναχρησιμοποιούμενο πόρο [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).

## **Σκέψη για Μορφές Παρουσίασης και Στόχους Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, επομένως το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμη και με PPTX, δεν είναι όλες οι λειτουργίες εξίσου φορητές:

- Οι τυπικές λειτουργίες DrawingML όπως η φωτεινότητα, η γκρι κλίμακα, το δυοτονικό, η απόχρωση, το HSL, η θολώση και οι κοινές λειτουργίες άλφα έχουν τις περισσότερες πιθανότητες να διατηρηθούν μετά από μια διαδρομή PPTX. Πάντα ανοίξτε ξανά το παραγόμενο αρχείο και επιθεωρήστε τη συλλογή όταν η διατήρηση είναι απαίτηση.
- Το [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) είναι μια επέκταση Office 2010 αντί για την τυπική λειτουργία φωτεινότητας DrawingML. Μπορεί να χρησιμοποιηθεί για απόδοση στη μνήμη, όμως δεν εγγυάται ότι θα παραμείνει ως επεξεργάσιμο [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) μετά την αποθήκευση και το άνοιγμα ξανά του PPTX. Προτιμήστε το [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε υποσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για μια σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλη οπτική έξοδο εφαρμόζει την υποστηριζόμενη αλυσίδα στην εμφάνιση. Αυτές οι εξόδους δεν περιέχουν μια επεξεργάσιμη `IImageTransformOperationCollection`; οι μορφές raster ισοπεδώνουν το αποτέλεσμα σε pixel, ενώ οι εξαγωγές εγγράφου ή διανυσματικές αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν η παρουσίαση φορτώνεται.

Διαφορετικούς καταναλωτές παρουσίασης μπορούν να αποδίδουν περιθώρια διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες άλφα ή χρωματικής ποσοτικοποίησης. Για κρίσιμη έξοδο, δοκιμάστε τόσο την επεξεργάσιμη διαδρομή όσο και την τελική μορφή εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν τα εφέ μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `ISlidesPicture` που χρησιμοποιείται από το γεμίσμα εικόνας. Τα υποκείμενα bytes του `IPPImage` παραμένουν αμετάβλητα.

**Θα μοιραστούν δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρησιμοποίηση ενός `IPPImage` αποφεύγει διπλότυπα δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας κανονικά έχει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμών εικόνας.

**Μπορούν τα εφέ χρώματος, θολώσης και άλφα να συνδυαστούν;**

Ναι. Η συλλογή τα αποδέχεται σε μία τακτοποιημένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, επειδή λειτουργίες αντικατάστασης ή κατωφλίου μπορεί να απορρίψουν προηγούμενες λεπτομέρειες χρώματος ή άλφα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τις υπολογισμένες τιμές που χρησιμοποιεί ο σχεδιαστής, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που αποθηκεύεται στη συλλογή μετασχηματισμών όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμών;**

Χρησιμοποιήστε το PPTX και επαληθεύστε το αρχείο ανοίγοντας το ξανά. Το παλαιό PPT δεν μπορεί να αναπαραστήσει το πλήρες μοντέλο εφέ DrawingML και οι μορφές εξαγωγής αποθηκεύουν μόνο την εμφάνιση, όχι τις επεξεργάσιμες λειτουργίες μετασχηματισμού.