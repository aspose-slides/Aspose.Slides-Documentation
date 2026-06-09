---
title: Διαχείριση Φόντων Παρουσιάσεων σε C++
linktitle: Φόντο Διαφάνειας
type: docs
weight: 20
url: /el/cpp/presentation-background/
keywords:
- φόντο παρουσίασης
- φόντο διαφάνειας
- στερεό χρώμα
- διαβαθμισμένο χρώμα
- φόντο εικόνας
- διαφάνεια φόντου
- ιδιότητες φόντου
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να ορίζετε δυναμικά φόντα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++, με συμβουλές κώδικα για να ενισχύσετε τις παρουσιάσεις σας."
---
## **Εισαγωγή**

Οι στερεά χρώματα, οι διαβαθμίσεις και οι εικόνες χρησιμοποιούνται συνήθως ως φόντο διαφάνειας. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μια μόνο διαφάνεια) ή μια **κύρια διαφάνεια** (εφαρμόζεται σε πολλές διαφάνειες ταυτόχρονα).

![Φόντο PowerPoint](powerpoint-background.png)

## **Ορισμός Στερεού Χρώματος Φόντου για Κανονική Διαφάνεια**

Aspose.Slides σας επιτρέπει να ορίσετε ένα στερεό χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια σε μια παρουσίαση—ακόμη και αν η παρουσίαση χρησιμοποιεί μια κύρια διαφάνεια. Η αλλαγή εφαρμόζεται μόνο στη διαφάνεια που έχει επιλεγεί.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/cpp/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Solid` .
4. Χρησιμοποιήστε τη μέθοδο [get_SolidFillColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/get_solidfillcolor/) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/) για να ορίσετε το στερεό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```cpp
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Ορίστε το χρώμα φόντου της διαφάνειας σε μπλε.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Αποθηκεύστε την παρουσίαση στο δίσκο.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός Στερεού Χρώματος Φόντου για Κύρια Διαφάνεια**

Aspose.Slides σας επιτρέπει να ορίσετε ένα στερεό χρώμα ως φόντο για την κύρια διαφάνεια σε μια παρουσίαση. Η κύρια διαφάνεια λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση όλων των διαφανειών, έτσι όταν επιλέγετε ένα στερεό χρώμα για το φόντο της κύριας διαφάνειας, εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/cpp/aspose.slides/backgroundtype/) της κύριας διαφάνειας (μέσω `get_Masters`) σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του φόντου της κύριας διαφάνειας σε `Solid` .
4. Χρησιμοποιήστε τη μέθοδο [get_SolidFillColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/get_solidfillcolor/) για να ορίσετε το στερεό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```cpp
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Ορίστε το χρώμα φόντου για τη κύρια διαφάνεια σε Πράσινο δάσους.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Αποθηκεύστε την παρουσίαση στο δίσκο.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός Διαβαθμισμένου Φόντου για Διαφάνεια**

Μια διαβαθμίση είναι ένα γραφικό εφέ που δημιουργείται από μια σταδιακή αλλαγή χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, οι διαβαθμίσεις μπορούν να κάνουν τις παρουσιάσεις να φαίνονται πιο καλλιτεχνικές και επαγγελματικές. Aspose.Slides σας επιτρέπει να ορίσετε ένα χρώμα διαβαθμίσεως ως φόντο για διαφάνειες.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/cpp/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Gradient` .
4. Χρησιμοποιήστε τη μέθοδο [get_GradientFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/get_gradientformat/) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/) για να ρυθμίσετε τις προτιμώμενες ρυθμίσεις διαβαθμίσεως.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```cpp
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Εφαρμόστε ένα εφέ διαβάθμισης στο φόντο.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Αποθηκεύστε την παρουσίαση στο δίσκο.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός Εικόνας ως Φόντο Διαφάνειας**

Εκτός από στερεές και διαβαθμισμένες γεμίσεις, το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφάνειας.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/cpp/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Picture` .
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο της διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε τη μέθοδο [get_PictureFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/get_picturefillformat/) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/) για να ορίσετε την εικόνα ως φόντο.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```cpp
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
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

```cpp
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

{{% alert color="primary" %}}
Διαβάστε περισσότερα: [**Τοποθέτηση Εικόνας ως Υφή**](/slides/el/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Αλλαγή Διαφάνειας Φόντου Εικόνας**

Μπορεί να θέλετε να προσαρμόσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Ο παρακάτω κώδικας C++ δείχνει πώς να αλλάξετε τη διαφάνεια για μια εικόνα φόντου διαφάνειας:

```cpp
auto transparencyValue = 30; // Για παράδειγμα.

// Αποκτήστε τη συλλογή των μετασχηματισμών εικόνας.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Βρείτε ένα υπάρχον εφέ διαφανούς μεταβολής με σταθερό ποσοστό.
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
```

## **Λήψη Τιμής Φόντου Διαφάνειας**

Το Aspose.Slides παρέχει το interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibackgroundeffectivedata/) για την ανάκτηση των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Το interface αυτό εκθέτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) και το [EffectFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/).

Χρησιμοποιώντας τη μέθοδο `get_Background` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseslide/), μπορείτε να λάβετε το αποτελεσματικό φόντο για μια διαφάνεια.

```cpp
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Αποκτήστε το αποτελεσματικό φόντο, λαμβάνοντας υπόψη τη κύρια διαφάνεια, τη διάταξη και το θέμα.
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

**Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να αποκαταστήσω το φόντο του θέματος/διάταξης;**

Ναι. Αφαιρέστε το προσαρμοσμένο γέμισμα της διαφάνειας και το φόντο θα κληθεί ξανά από την αντίστοιχη διαφάνεια [διάταξης](/slides/el/cpp/slide-layout/)/[κύριας](/slides/el/cpp/slide-master/) (δηλαδή το [φόντο θέματος](/slides/el/cpp/presentation-theme/)).

**Τι συμβαίνει με το φόντο εάν αλλάξω αργότερα το θέμα της παρουσίασης;**

Εάν μια διαφάνεια έχει το δικό της γέμισμα, θα παραμείνει αμετάβλητη. Εάν το φόντο κληθεί από τη [διάταξη](/slides/el/cpp/slide-layout/)/[κύρια](/slides/el/cpp/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [νέο θέμα](/slides/el/cpp/presentation-theme/).