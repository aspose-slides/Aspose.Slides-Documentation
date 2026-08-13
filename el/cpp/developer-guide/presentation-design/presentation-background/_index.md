---
title: Διαχείριση Φόντων Παρουσιάσεων σε C++
linktitle: Φόντο Διαφάνειας
type: docs
weight: 20
url: /el/cpp/presentation-background/
keywords:
- φόντο παρουσίασης
- φόντο διαφάνειας
- συμπαγές χρώμα
- διαβαθμισμένο χρώμα
- φόντο εικόνας
- διαφάνεια φόντου
- ιδιότητες φόντου
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να ορίζετε δυναμικά φόντα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++, με συμβουλές κώδικα για τη βελτίωση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα συμπαγή χρώματα, τα διαβαθμισμένα χρώματα και οι εικόνες χρησιμοποιούνται συνήθως ως φόντα διαφανειών. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μια μόνη διαφάνεια) ή μια **διαφάνεια master** (εφαρμόζεται σε πολλές διαφάνειες ταυτόχρονα).

![PowerPoint background](powerpoint-background.png)

## **Ορισμός συμπαγούς χρώματος φόντου για κανονική διαφάνεια**

Το Aspose.Slides σάς επιτρέπει να ορίσετε ένα συμπαγές χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια στην παρουσίαση—ακόμη κι αν η παρουσίαση χρησιμοποιεί μια διαφάνεια master. Η αλλαγή εφαρμόζεται μόνο στην επιλεγμένη διαφάνεια.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/cpp/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Solid` .
4. Χρησιμοποιήστε τη μέθοδο [get_SolidFillColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/get_solidfillcolor/) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/) για να ορίσετε το συμπαγές χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το ακόλουθο παράδειγμα C++ δείχνει πώς να ορίσετε ένα μπλε συμπαγές χρώμα ως φόντο για μια κανονική διαφάνεια:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Set the background color of the slide to blue.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the presentation to disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός συμπαγούς χρώματος φόντου για διαφάνεια master**

Το Aspose.Slides σάς επιτρέπει να ορίσετε ένα συμπαγές χρώμα ως φόντο για τη διαφάνεια master σε μια παρουσίαση. Η διαφάνεια master λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση για όλες τις διαφάνειες, επομένως όταν επιλέγετε ένα συμπαγές χρώμα για το φόντο της διαφάνειας master, εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/cpp/aspose.slides/backgroundtype/) της διαφάνειας master (μέσω `get_Masters`) σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του φόντου της διαφάνειας master σε `Solid` .
4. Χρησιμοποιήστε τη μέθοδο [get_SolidFillColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/get_solidfillcolor/) για να ορίσετε το συμπαγές χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το ακόλουθο παράδειγμα C++ δείχνει πώς να ορίσετε ένα συμπαγές χρώμα (πράσινο δάσους) ως φόντο για μια διαφάνεια master:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Set the background color for the Master slide to Forest Green.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Αποθηκεύστε την παρουσίαση στο δίσκο.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός διαβαθμισμένου φόντου για διαφάνεια**

Ένα διαβαθμισμένο χρώμα είναι ένα γραφικό εφέ που δημιουργείται από μια σταδιακή αλλαγή χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, τα διαβαθμισμένα χρώματα μπορούν να κάνουν τις παρουσιάσεις να φαίνονται πιο καλλιτεχνικές και επαγγελματικές. Το Aspose.Slides σάς επιτρέπει να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για διαφάνειες.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/cpp/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Gradient` .
4. Χρησιμοποιήστε τη μέθοδο [get_GradientFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/get_gradientformat/) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/) για να διαμορφώσετε τις προτιμώμενες ρυθμίσεις διαβάθμισης.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το ακόλουθο παράδειγμα C++ δείχνει πώς να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για μια διαφάνεια:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Εφαρμόστε ένα διαβαθμισμένο εφέ στο φόντο.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Αποθηκεύστε την παρουσίαση στο δίσκο.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός εικόνας ως φόντο διαφάνειας**

Εκτός από τα συμπαγή και διαβαθμισμένα γέμισμα, το Aspose.Slides σάς επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφάνειας.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/cpp/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Picture` .
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε τη μέθοδο [get_PictureFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/get_picturefillformat/) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/) για να ορίσετε την εικόνα ως φόντο.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το ακόλουθο παράδειγμα C++ δείχνει πώς να ορίσετε μια εικόνα ως φόντο για μια διαφάνεια:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Ορίστε τις ιδιότητες εικόνας φόντου.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Φορτώστε την εικόνα.
auto image = Images::FromFile(u"Tulips.jpg");
// Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Αποθηκεύστε την παρουσίαση στο δίσκο.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το ακόλουθο δείγμα κώδικα δείχνει πώς να ορίσετε τον τύπο γεμίσματος φόντου σε εικόνα επαναλαμβανόμενη (tiled) και να τροποποιήσετε τις ιδιότητες επικάλυψης:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}

Read more: [**Tile Picture As Texture**](/slides/el/cpp/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Αλλαγή διαφάνειας εικόνας φόντου**

Μπορεί να θέλετε να προσαρμόσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Ο παρακάτω κώδικας C++ δείχνει πώς να αλλάξετε τη διαφάνεια για την εικόνα φόντου μιας διαφάνειας:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Για παράδειγμα.

// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Λάβετε τη συλλογή των μετασχηματισμών εικόνας.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Βρείτε μια υπάρχουσα επίδραση διαφάνειας σταθερού ποσοστού.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Ορίστε τη νέα τιμή διαφάνειας.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Αποθηκεύστε την παρουσίαση στο δίσκο.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Λήψη τιμής φόντου διαφάνειας**

Το Aspose.Slides παρέχει το interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibackgroundeffectivedata/) για την ανάκτηση των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Αυτό το interface εκθέτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) και το [EffectFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) .

Χρησιμοποιώντας τη μέθοδο `get_Background` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseslide/), μπορείτε να λάβετε το αποτελεσματικό φόντο για μια διαφάνεια.

Το ακόλουθο παράδειγμα C++ δείχνει πώς να λάβετε την αποτελεσματική τιμή φόντου μιας διαφάνειας:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Ανακτήστε το αποτελεσματικό φόντο, λαμβάνοντας υπόψη το master, τη διάταξη και το θέμα.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **Συχνές Ερωτήσεις**

### Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να αποκαταστήσω το φόντο θέματος/διάταξης;

Ναι. Αφαιρέστε το προσαρμοσμένο γέμισμα της διαφάνειας και το φόντο θα κληρονομηθεί ξανά από την αντίστοιχη διαφάνεια [layout](/slides/el/cpp/slide-layout/)/[master](/slides/el/cpp/slide-master/) (δηλαδή από το [theme background](/slides/el/cpp/presentation-theme/)).

### Τι συμβαίνει με το φόντο αν αλλάξω αργότερα το θέμα της παρουσίασης;

Αν μια διαφάνεια έχει το δικό της γέμισμα, αυτό θα παραμείνει αμετάβλητο. Αν το φόντο κληρονομείται από το [layout](/slides/el/cpp/slide-layout/)/[master](/slides/el/cpp/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [new theme](/slides/el/cpp/presentation-theme/).