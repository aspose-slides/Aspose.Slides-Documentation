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
- δυοχρωματική απόχρωση
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
description: "Εφαρμόστε, συνδέστε, επιθεωρήστε, αφαιρέστε και επαληθεύστε τα εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με Aspose.Slides για C++."
---
## **Επισκόπηση**

Aspose.Slides αντιπροσωπεύει τις ρυθμίσεις εικόνας ως μια διατεταγμένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [ISlidesPicture](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidespicture/) του πλαισίου και προσπελάστε το [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidespicture/get_imagetransform/). Η επιστρεφόμενη [IImageTransformOperationCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/) σάς επιτρέπει να προσαρτήσετε, να απαριθμήσετε, να επιθεωρήσετε, να αφαιρέσετε και να καθαρίσετε εφέ χωρίς να ξαναγράψετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο παρουσιάζει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετασχηματισμούς χρωμάτων, θόλωση, διαφάνεια, αλυσίδες εφέ με σειρά, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση στρογγυλής διαδρομής PPTX.

## **Κατανόηση Ιδιοκτησίας Εφέ και Επαναχρήσης Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) αποθηκεύει ή παραπέμπει στα δεδομένα εικόνας που ανήκουν στην παρουσίαση.
- [ISlidesPicture](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidespicture/) ανήκει σε γέμισμα εικόνας και παραπέμπει σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμού εικόνας.
- [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Έτσι, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/). Όταν το ίδιο `IPPImage` περνάει στο [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addpictureframe/) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμών. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι, ακόμη κι αν όλα χρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `ISlidesPicture::get_ImageTransform` χρησιμοποιείται και από άλλες γεμίσεις εικόνας, όπως σχήμα ή φόντο διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν στα πλαίσια εικόνας.

## **Χρήση Έγκυρων Περιοχών Παραμέτρων και Μονάδων**

Οι μεθόδοι που παρουσιάζονται χρησιμοποιούν τις παρακάτω σημασιολογικές περιοχές και μονάδες. Διατηρήστε τις τιμές σε αυτές τις περιοχές ακόμη και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει άμεσα κάθε έξω από το εύρος τιμή. Η μορφή προορισμού μπορεί να κανονικοποιήσει, παραλείψει ή απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίγει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το συστατικό αμετάβλητο. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Καμία | Δεν υπάρχουν αριθμητικές παράμετροι. Το άλφα παραμένει αμετάβλητο. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Δύο χρώματα για σκοτεινά και φωτεινά pixel. Τα κανάλια RGB και άλφα στο `System::Drawing::Color` χρησιμοποιούν τιμές `0` έως `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Το `hue` είναι `0` (συμπεριλαμβανομένου) έως `360` (μη συμπεριλαμβανομένου) μοίρες· το `amount` είναι `-100` έως `100`, ποσοστό. |
| [AddHSLEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Το `hue` είναι `0` έως `360` μοίρες· η κορεσμός και η φωτεινότητα είναι `-100` έως `100`, ποσοστό. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών `0` έως `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [AddBlurEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετριέται σε points· `grow` ελέγχει αν το θολό περιεχόμενο μπορεί να επεκταθεί εκτός των αρχικών ορίων. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` έως `100` για κανονική κλιμάκωση αδιαφάνειας: `0` είναι πλήρως διαφανές και `100` διατηρεί το υπάρχον άλφα. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` έως `100`, ποσοστό αδιαφάνειας. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` έως `100`, ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή πάνω γίνονται αδιαφάνεια. |

Για σταθερή διαφάνεια, η διαφάνεια και η αδιαφάνεια είναι συμπληρωματικές. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό σταθεροποίησης άλφα 65 %.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) επιστρέφει μια λειτουργία [IBrightnessContrast](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/ibrightnesscontrast/). Οι βαθμωτοί ορισμοί της παρέχονται κατά τη δημιουργία της λειτουργίας. Η μέθοδος `IBrightnessContrast::GetEffective` επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να επιθεωρηθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, μετά αποδίδει μια προεπισκόπηση χωρίς να τροποποιήσει την ενσωματωμένη εικόνα:

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

[BrightnessContrast](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/brightnesscontrast/) είναι μια επέκταση εφέ εικόνας Office 2010 και είναι λιγότερο φορητό από το τυπικό εφέ luminance του DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από στρογγυλή διαδρομή PPTX, χρησιμοποιήστε το [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα του αρχείου. Η ενότητα περιορισμών μορφής εξηγεί αυτήν τη διάκριση με περισσότερες λεπτομέρειες.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που χρησιμοποιούν τον ίδιο πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, δυοχρωματική απόχρωση, απόχρωση τόνου, ρύθμιση HSL και αντικατάσταση χρώματος.

[IDuotone](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iduotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `get_Color1` αντιστοιχίζει τα σκοτεινά pixel, ενώ το `get_Color2` αντιστοιχίζει τα φωτεινά pixel. Αυτό το καθιστά χρήσιμο παράδειγμα εφέ με πιο σύνθετους ορισμούς από μία απλή βαθμωτή τιμή.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα διατηρώντας το άλφα. Είναι διαφορετικό από το [AddColorChangeEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), το οποίο αντιστοιχίζει ένα χρώμα προέλευσης σε ένα χρώμα προορισμού και εκθέτει και τις δύο μορφές χρωμάτων.

## **Προσθήκη Θόλωσης, Διαφάνειας και Εφέ Άλφα**

[AddBlurEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του άλφα. Ορίστε `grow` σε `true` όταν η θολή άκρη μπορεί να εκτείνεται πέρα από τα αρχικά όρια της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, έτσι ώστε τα ημιδιαφανή pixel να παραμένουν αναλογικά διαφορετικά. Το [AddAlphaReplaceEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) αντιθέτως αναθέτει μία τιμή άλφα σε όλα τα pixel. Το [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) μετατρέπει το άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

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

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν το [AddAlphaCeilingEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), το οποίο κάνει κάθε μη‑μηδενικό άλφα πλήρως αδιαφάνεια· το [AddAlphaFloorEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), που κάνει κάθε άλφα κάτω από 100 % πλήρως διαφανές· και το [AddAlphaInverseEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), που αλλάζει το άλφα σε `100% - alpha`.

## **Δημιουργία Διατεταγμένης Αλυσίδας Εφέ**

Κάθε μέθοδος `Add...Effect` προσαρτά μια νέα λειτουργία στο τέλος της συλλογής. Ο renderer χρησιμοποιεί τη συλλογή ως διατεταγμένη γραμμή εργασίας: η έξοδος της λειτουργίας 0 γίνεται είσοδος της λειτουργίας 1, κ.ο.κ. Συνεπώς, οι ίδιες λειτουργίες σε διαφορετική σειρά μπορούν να δημιουργήσουν διαφορετική εικόνα.

Για παράδειγμα, γκρι κλίμακα ακολουθούμενη από απόχρωση πρώτα αφαιρεί τις χρωματικές πληροφορίες και, στη συνέχεια, επαναχρωματίζει το αποτέλεσμα luminance. Η αντίστροφη σειρά (απόχρωση πριν γκρι κλίμακα) αφαιρεί την απόχρωση. Ομοίως, η αντικατάσταση άλφα μπορεί να παρακάμψει τιμές άλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές διαφορές.

Το παρακάτω παράδειγμα δημιουργεί αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ξαναφ аша το παρόν παρουσίαση, ελέγχει τόσο τους τύπους των λειτουργιών όσο και τη σειρά τους, και αποδίδει το ξαναανοιγμένο αποτέλεσμα:

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

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, άλφα και θόλωσης σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί τις διακυμάνσεις RGB που δημιουργήθηκαν από προηγούμενα εφέ χρώματος· η γκρι κλίμακα μετά δυοχρωματική αφαίρεση τα δύο επιλεγμένα χρώματα· και οι λειτουργίες άλφα (όριο, οροφή, αντικατάσταση) μπορούν να αγνοήσουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Κατασκευάστε την αλυσίδα σύμφωνα με την επιθυμητή ακολουθία επεξεργασίας pixel αντί να θεωρείτε τα στοιχεία της ως αταξικές σημαίες μορφοποίησης.

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `ISlidesPicture::get_ImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει εγγράψιμα μέλη άμεσα. Για παράδειγμα, το [IBlur](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iblur/) εκθέτει `set_Radius` και `set_Grow`, το [IAlphaModulateFixed](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/ialphamodulatefixed/) εκθέτει `set_Amount`, και το [IAlphaBiLevel](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/ialphabilevel/) εκθέτει `set_Threshold`. Τα εφέ χρώματος όπως το [IDuotone](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iduotone/) εκθέτουν μεταβλητά αντικείμενα [IColorFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/icolorformat/).

Ορισμένα interfaces λειτουργιών, όπως τα [IBrightnessContrast](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/itint/), και [IAlphaReplace](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/ialphareplace/), δεν εκθέτουν τα αρχικά τους scalars ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε το εφέ και προσθέστε ένα νέο στη ζητούμενη θέση.

Τα δεδομένα που επιστρέφονται από το `GetEffective()` είναι υπολογισμένα και μόνο για ανάγνωση. Χρησιμοποιούνται για την επίλυση χρωμάτων που εξαρτώνται από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο renderer, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και επιθεωρεί αποτελεσματικές τιμές για αρκετές κοινές λειτουργίες:

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

Τα εφέ χωρίς παραμέτρους όπως η γκρι κλίμακα, η οροφή άλφα και η αντιστροφή άλφα έχουν ακόμα αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν scalar ρυθμίσεις προς εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι οι σημαντικές πληροφορίες.

## **Αφαίρεση ή Καθαρισμός Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) για να αφαιρέσετε μία λειτουργία με βάση το δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, αναζητήστε πρώτα το στόχο και αφαιρέστε το μετά την απαρίθμηση. Χρησιμοποιήστε το `Clear()` για να αφαιρέσετε ολόκληρη την αλυσίδα.

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

Η αφαίρεση ή ο καθαρισμός των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν συμπιέζει ξανά και δεν τροποποιεί τον ξανά χρησιμοποιούμενο πόρο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/).

## **Σκέψη Μορφών Παρουσίασης και Στόχων Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, επομένως το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμη και με PPTX, δεν είναι όλες οι λειτουργίες εξίσου φορητές:

- Οι τυπικές λειτουργίες DrawingML όπως luminance, γκρι κλίμακα, δυοχρωματική απόχρωση, απόχρωση τόνου, HSL, θόλωση και κοινές λειτουργίες άλφα έχουν τις καλύτερες πιθανότητες να διατηρηθούν μετά από στρογγυλή διαδρομή PPTX. Πάντα ξαναανοίξτε το παραγόμενο αρχείο και ελέγξτε τη συλλογή όταν η διατήρηση είναι απαίτηση.
- Το [BrightnessContrast](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/brightnesscontrast/) είναι μια επέκταση Office 2010 και όχι το τυπικό εφέ luminance του DrawingML. Μπορεί να χρησιμοποιηθεί για απόδοση εν ενσωμάτωσης, αλλά δεν είναι εγγυημένο ότι θα παραμείνει επεξεργάσιμο ως [IBrightnessContrast](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/ibrightnesscontrast/) μετά την αποθήκευση και ξαναάνοιγμα του PPTX. Προτιμήστε το [AddLuminanceEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προϋπάρχει του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει την αλυσίδα σε υποσύνολο που υποστηρίζεται ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες μορφές εικόνας εφαρμόζει την υποστηριζόμενη αλυσίδα στην εμφάνιση. Αυτές οι εξαγωγές δεν περιέχουν επεξεργάσιμη `IImageTransformOperationCollection`; οι μορφές raster ισοσταθμίζουν το αποτέλεσμα σε pixels, ενώ οι εξαγωγές εγγράφου ή διανύσματος αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν καθιστούν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξαρτάται ακόμη από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν η παρουσίαση φορτώνεται.

Διαφορετικοί καταναλωτές παρουσίασης μπορεί να αποδίδουν ακραίες περιπτώσεις διαφορετικά, ειδικά όταν συνδυάζονται αρκετές λειτουργίες άλφα ή χρώματος. Για κρίσιμα αποτελέσματα, δοκιμάστε τόσο τη στρογγυλή επεξεργάσιμη διαδρομή όσο και την τελική μορφή εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται σε παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν τα εφέ μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `ISlidesPicture` που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα bytes του `IPPImage` παραμένουν αμετάβλητα.

**Μοιράζονται δύο πλαίσια εικόνας που χρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρήση ενός `IPPImage` αποφεύγει διπλότυπα δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας έχει συνήθως το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμού εικόνας.

**Μπορούν τα εφέ χρώματος, θόλωσης και άλφα να συνδυαστούν;**

Ναι. Η συλλογή τα δέχεται σε μία διατεταγμένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στο αποτέλεσμα της προηγούμενης, επειδή οι λειτουργίες αντικατάστασης και κατωφλίου μπορεί να απορρίψουν χρώμα ή άλφα που δημιουργήθηκαν νωρίτερα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τις υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που αποθηκεύεται στη συλλογή μετασχηματισμών όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε την και προσθέστε μια νέα με διαφορετικές παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για τη διατήρηση μιας αλυσίδας μετασχηματισμών;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντας το ξανά. Η παλιά μορφή PPT δεν μπορεί να αναπαραστήσει το πλήρες μοντέλο εφέ DrawingML, ενώ οι μορφές εξαγωγής αποδίδουν μόνο την εμφάνιση και όχι τις επεξεργάσιμες λειτουργίες μετασχηματισμού.