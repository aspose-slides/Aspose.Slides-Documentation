---
title: Μετατροπή διαφανειών PowerPoint σε PNG με C++
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/cpp/convert-powerpoint-to-png/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PNG
- παρουσίαση σε PNG
- διαφάνεια σε PNG
- PPT σε PNG
- PPTX σε PNG
- αποθήκευση PPT ως PNG
- αποθήκευση PPTX ως PNG
- εξαγωγή PPT σε PNG
- εξαγωγή PPTX σε PNG
- C++
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε υψηλής ποιότητας εικόνες PNG γρήγορα με Aspose.Slides για C++, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε διαφάνειες παρουσίασης σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides για C++. Μπορείτε να φορτώσετε παρουσιάσεις σε μορφές όπως PPT, PPTX και ODP, να αποδώσετε κάθε διαφάνεια και να την αποθηκεύσετε ως ξεχωριστή εικόνα PNG.

Τα παρακάτω παραδείγματα δείχνουν την απόδοση στην προεπιλεγμένη κλίμακα, την αύξηση της κλίμακας, τον καθορισμό των διαστάσεων εξόδου σε εικονοστοιχεία και την επιλογή ενός στυλ απόδοσης διαβάθμισης.

## **Μετατροπή PowerPoint σε PNG**

Φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις διαφάνειες της μέσω του προσπελάσιμου [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). Το παράδειγμα αποδίδει κάθε διαφάνεια με το [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) χωρίς παραμέτρους για τη δημιουργία μικρογραφίας. Στη συνέχεια καλεί το [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) με το [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) για να αποθηκεύσει κάθε αποδοθέντα διαφάνεια ως εικόνα PNG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Η υπερφόρτωση [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) χωρίς παραμέτρους αποδίδει σε κλίμακα 0,2. Για παράδειγμα, μια διαφάνεια μεγέθους 720 × 540 σημεία δημιουργεί μικρογραφία 144 × 108 εικονοστοιχείων. Για να ελέγξετε τις διαστάσεις εξόδου, χρησιμοποιήστε τις υπερφορτώσεις με παράγοντες κλίμακας ή ένα ρητό μέγεθος εικόνας όπως φαίνεται παρακάτω.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Περάστε οριζόντιους και κατακόρυφους παράγοντες κλίμακας στο [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) για να ελέγξετε τις αποδοθέντες διαστάσεις. Σε αυτό το παράδειγμα, και οι δύο παράγοντες είναι 2, έτσι μια διαφάνεια μεγέθους 720 × 540 σημεία παράγει εικόνα 1440 × 1080 εικονοστοιχείων. Οι ίσοι παράγοντες κλίμακας διατηρούν την αναλογία πλευρών της διαφάνειας. Κάθε εικόνα αποθηκεύεται σε μορφή PNG με το [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένο Μέγεθος**

Για να καθορίσετε τις διαστάσεις εξόδου σε εικονοστοιχεία, περάστε ένα μέγεθος στο [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) αντί για παράγοντες κλίμακας. Αυτό το παράδειγμα αποδίδει κάθε διαφάνεια σε 960 × 720 εικονοστοιχεία και αποθηκεύει το αποτέλεσμα με το [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Επιλέξτε διαστάσεις που ταιριάζουν στην αναλογία πλευρών της διαφάνειας ώστε να αποφύγετε την τέντωσή της.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Επιλογή Στυλ Απόδοσης Διαβάθμισης**

Υποθέστε ότι μια διαφάνεια περιέχει γεμίσεις με διαβάθμιση, αλλά οι μεταβάσεις στην εξαγόμενη PNG φαίνονται πιο ανοιχτές ή διαφορετικές από ό,τι βλέπετε στο PowerPoint. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) της κλάσης [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) για να επιλέξετε πώς θα αποδίδονται οι διαβαθμίσεις.

Κατεβάστε το [gradient-styles.pptx](gradient-styles.pptx) και τοποθετήστε το στον κατάλογο εργασίας της εφαρμογής. Η πρώτη διαφάνεια του περιέχει δύο γραμμικές διαβαθμίσεις: από κυανό σε πορτοκαλί στο επάνω μέρος και από μπλε σε κίτρινο στο κάτω μέρος. Κάθε διαβάθμιση έχει δύο στάσεις, στο 0 % και το 100 %.

Το παρακάτω παράδειγμα φορτώνει αυτήν την παρουσίαση και αποδίδει την ίδια πρώτη διαφάνεια και στις δύο λειτουργίες με το [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

Οι εικόνες παρακάτω δείχνουν το αποτέλεσμα από την ίδια διαφάνεια, με και τις δύο διαβαθμίσεις σε κάθε εικόνα:

| Default | PowerPointUI |
| --- | --- |
| ![Διαβαθμίσεις από κυανό σε πορτοκαλί και από μπλε σε κίτρινο αποδοθέντες με Default](gradient-Default.png) | ![Οι ίδιες διαβαθμίσεις αποδοθέντες με PowerPointUI](gradient-PowerPointUI.png) |

Σε αυτό το παράδειγμα, το `Default` παράγει πιο φωτεινά ενδιάμεσα χρώματα, ενώ το `PowerPointUI` παράγει πιο σκούρα ενδιάμεσα χρώματα. Η διαφορά εξαρτάται από τα χρώματα και τις στάσεις στη διαβάθμιση.

Επιλέξτε το `Default` όταν η τυπική έξοδος του Aspose.Slides ικανοποιεί τις ανάγκες σας. Δοκιμάστε το `PowerPointUI` όταν η προτεραιότητά σας είναι η αντιστοίχηση της εμφάνισης στο PowerPoint. Συγκρίνετε και τις δύο εξόδους με το επιθυμητό αποτέλεσμα· καμία λειτουργία δεν είναι καθολικά προτιμότερη.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξάγω ένα συγκεκριμένο σχήμα, όπως ένα γράφημα ή μια εικόνα, αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει τη [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/cpp/shape-thumbnails/), επιτρέποντάς σας να αποδώσετε ένα σχήμα ως εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;**

Ναι. Χρησιμοποιήστε ξεχωριστό αντικείμενο παρουσίασης για κάθε νήμα ή διεργασία· [μην μοιράζεστε ένα ενιαίο αντικείμενο μεταξύ νημάτων](/slides/el/cpp/multithreading/).

**Ποιες είναι οι περιορισμοί της δοκιμαστικής έκδοσης κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδατογράφημα στις έξοδοι εικόνες και εφαρμόζει [άλλους περιορισμούς](/slides/el/cpp/licensing/) μέχρι να εφαρμοστεί άδεια.