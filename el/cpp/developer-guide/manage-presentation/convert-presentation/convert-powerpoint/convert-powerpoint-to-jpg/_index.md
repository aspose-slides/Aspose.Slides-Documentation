---
title: Μετατροπή PPT και PPTX σε JPG σε C++
linktitle: PowerPoint σε JPG
type: docs
weight: 60
url: /el/cpp/convert-powerpoint-to-jpg/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε JPG
- παρουσίαση σε JPG
- διαφάνεια σε JPG
- PPT σε JPG
- PPTX σε JPG
- αποθήκευση PowerPoint ως JPG
- αποθήκευση παρουσίασης ως JPG
- αποθήκευση διαφάνειας ως JPG
- αποθήκευση PPT ως JPG
- αποθήκευση PPTX ως JPG
- εξαγωγή PPT σε JPG
- εξαγωγή PPTX σε JPG
- C++
- Aspose.Slides
description: "Μετατρέψτε τις διαφάνειες PowerPoint (PPT, PPTX) σε εικόνες JPG υψηλής ποιότητας σε C++ με την Aspose.Slides χρησιμοποιώντας γρήγορα, αξιόπιστα παραδείγματα κώδικα."
---
## **Εισαγωγή**

Η μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εικόνες JPG βοηθά στην κοινή χρήση των διαφανειών, στη βελτιστοποίηση της απόδοσης και στην ενσωμάτωση περιεχομένου σε ιστοτόπους ή εφαρμογές. Η Aspose.Slides για C++ σας επιτρέπει να μετατρέψετε αρχεία PPTX, PPT και ODP σε εικόνες JPEG υψηλής ποιότητας. Αυτός ο οδηγός εξηγεί διαφορετικές μεθόδους μετατροπής.

Με αυτές τις δυνατότητες, είναι εύκολο να υλοποιήσετε το δικό σας πρόγραμμα προβολής παρουσιάσεων και να δημιουργήσετε μικρογραφίες για κάθε διαφάνεια. Αυτό μπορεί να είναι χρήσιμο εάν θέλετε να προστατεύσετε τις διαφάνειες παρουσίασης από αντιγραφή ή να παρουσιάσετε την παρουσίαση σε λειτουργία μόνο για ανάγνωση. Η Aspose.Slides σας επιτρέπει να μετατρέψετε ολόκληρη την παρουσίαση ή μια συγκεκριμένη διαφάνεια σε μορφές εικόνας.

## **Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες JPG**

Ακολουθούν τα βήματα για τη μετατροπή ενός αρχείου PPT, PPTX ή ODP σε JPG:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Αποκτήστε το αντικείμενο διαφάνειας του τύπου [ISlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/) από τη συλλογή διαφανειών της παρουσίασης.
3. Δημιουργήστε μια εικόνα της διαφάνειας χρησιμοποιώντας τη μέθοδο [ISlide.GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage/).
4. Κλήστε τη μέθοδο [IImage.Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/save/) στο αντικείμενο εικόνας. Περάστε το όνομα του αρχείου εξόδου και τη μορφή εικόνας ως ορίσματα.

{{% alert color="info" %}} 
**Σημείωση:** Η μετατροπή PPT, PPTX ή ODP σε JPG διαφέρει από τη μετατροπή σε άλλες μορφές στο API της Aspose.Slides για C++. Για άλλες μορφές, συνήθως χρησιμοποιείτε τη μέθοδο [IPresentation.Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/save/). Ωστόσο, για τη μετατροπή σε JPG, πρέπει να χρησιμοποιήσετε τη μέθοδο [IImage.Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/save/).
{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Δημιουργήστε μια εικόνα διαφάνειας με την καθορισμένη κλίμακα.
    auto image = slide->GetImage(scaleX, scaleY);

    // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Μετατροπή Διαφανειών σε JPG με Προσαρμοσμένες Διαστάσεις**

Για να αλλάξετε τις διαστάσεις των παραγόμενων εικόνων JPG, μπορείτε να ορίσετε το μέγεθος της εικόνας περνώντας το στη μέθοδο [ISlide.GetImage(Size)](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Αυτό σας επιτρέπει να δημιουργήσετε εικόνες με συγκεκριμένες τιμές πλάτους και ύψους, εξασφαλίζοντας ότι η έξοδος πληροί τις απαιτήσεις σας για ανάλυση και αναλογία διαστάσεων. Αυτή η ευελιξία είναι ιδιαίτερα χρήσιμη κατά τη δημιουργία εικόνων για εφαρμογές web, αναφορές ή τεκμηρίωση, όπου απαιτούνται ακριβείς διαστάσεις εικόνας.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Δημιουργήστε μια εικόνα διαφάνειας με το καθορισμένο μέγεθος.
    auto image = slide->GetImage(imageSize);

    // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Απόδοση Σχολίων Κατά την Αποθήκευση Διαφανειών ως Εικόνες**

Η Aspose.Slides για C++ παρέχει μια λειτουργία που σας επιτρέπει να αποδίδετε σχόλια στις διαφάνειες μιας παρουσίασης όταν τις μετατρέπετε σε εικόνες JPG. Αυτό είναι ιδιαίτερα χρήσιμο για τη διατήρηση σχολίων, ανατροφοδότησης ή συζητήσεων που έχουν προσθέσει συνεργάτες σε παρουσιάσεις PowerPoint. Ενεργοποιώντας αυτήν την επιλογή, εξασφαλίζετε ότι τα σχόλια είναι ορατά στις παραγόμενες εικόνες, κάνοντας πιο εύκολο τον έλεγχο και την κοινή χρήση της ανατροφοδότησης χωρίς την ανάγκη ανοίγματος του αρχικού αρχείου παρουσίασης.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης, "sample.pptx", με μια διαφάνεια που περιέχει σχόλια:

![Η διαφάνεια με σχόλια](slide_with_comments.png)

Ο ακόλουθος κώδικας C++ μετατρέπει τη διαφάνεια σε εικόνα JPG διατηρώντας τα σχόλια:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Ορίστε τις επιλογές για τα σχόλια της διαφάνειας.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Μετατρέψτε τη πρώτη διαφάνεια σε εικόνα.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Το αποτέλεσμα:

![Η εικόνα JPG με σχόλια](image_with_comments.png)

## **Δείτε επίσης**

Δείτε άλλες επιλογές για μετατροπή PPT, PPTX ή ODP σε εικόνες, όπως:

- [Μετατροπή PowerPoint σε GIF](/slides/el/cpp/convert-powerpoint-to-animated-gif/)
- [Μετατροπή PowerPoint σε PNG](/slides/el/cpp/convert-powerpoint-to-png/)
- [Μετατροπή PowerPoint σε TIFF](/slides/el/cpp/convert-powerpoint-to-tiff/)
- [Μετατροπή PowerPoint σε SVG](/slides/el/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Για να δείτε πώς η Aspose.Slides μετατρέπει PowerPoint σε εικόνες JPG, δοκιμάστε αυτούς τους δωρεάν διαδικτυακούς μετατροπείς: PowerPoint [PPTX σε JPG](https://products.aspose.app/slides/el/conversion/pptx-to-jpg) και [PPT σε JPG](https://products.aspose.app/slides/el/conversion/ppt-to-jpg). 

{{% /alert %}}

![Δωρεάν Διαδικτυακός Μετατροπέας PPTX σε JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Η Aspose παρέχει μια [FREE Collage web app](https://products.aspose.app/slides/el/collage). Χρησιμοποιώντας αυτήν την διαδικτυακή υπηρεσία, μπορείτε να συγχωνεύσετε εικόνες [JPG σε JPG](https://products.aspose.app/slides/el/collage/jpg) ή PNG σε PNG, να δημιουργήσετε [photo grids](https://products.aspose.app/slides/el/collage/photo-grid), κ.λπ. 

Χρησιμοποιώντας τις ίδιες αρχές που περιγράφονται σε αυτό το άρθρο, μπορείτε να μετατρέψετε εικόνες από μια μορφή σε άλλη. Για περισσότερες πληροφορίες, δείτε αυτές τις σελίδες: μετατροπή [image to JPG](https://products.aspose.com/slides/el/cpp/conversion/image-to-jpg/); μετατροπή [JPG to image](https://products.aspose.com/slides/el/cpp/conversion/jpg-to-image/); μετατροπή [JPG to PNG](https://products.aspose.com/slides/el/cpp/conversion/jpg-to-png/), μετατροπή [PNG to JPG](https://products.aspose.com/slides/el/cpp/conversion/png-to-jpg/); μετατροπή [PNG to SVG](https://products.aspose.com/slides/el/cpp/conversion/png-to-svg/), μετατροπή [SVG to PNG](https://products.aspose.com/slides/el/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Συχνές Ερωτήσεις**

### Υποστηρίζει αυτή η μέθοδος τη μαζική μετατροπή;

Ναι, η Aspose.Slides επιτρέπει τη μαζική μετατροπή πολλαπλών διαφανειών σε JPG σε μια ενιαία λειτουργία.

### Υποστηρίζει η μετατροπή SmartArt, γραφήματα και άλλα σύνθετα αντικείμενα;

Ναί, η Aspose.Slides αποδίδει όλο το περιεχόμενο, συμπεριλαμβανομένων SmartArt, γραφημάτων, πινάκων, σχημάτων και άλλων. Ωστόσο, η ακρίβεια απόδοσης μπορεί να διαφέρει ελαφρώς σε σχέση με το PowerPoint, ιδιαίτερα όταν χρησιμοποιούνται προσαρμοσμένες ή ελλειπτικές γραμματοσειρές.

### Υπάρχουν περιορισμοί στον αριθμό των διαφανειών που μπορούν να υποβληθούν σε επεξεργασία;

Η Aspose.Slides από μόνη της δεν επιβάλλει αυστηρούς περιορισμούς στον αριθμό των διαφανειών που μπορείτε να επεξεργαστείτε. Ωστόσο, μπορεί να αντιμετωπίσετε σφάλμα έλλειψης μνήμης όταν εργάζεστε με μεγάλες παρουσιάσεις ή εικόνες υψηλής ανάλυσης.