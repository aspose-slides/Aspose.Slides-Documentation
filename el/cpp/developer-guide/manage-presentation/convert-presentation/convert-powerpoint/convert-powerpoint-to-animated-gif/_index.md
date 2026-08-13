---
title: Μετατροπή παρουσιάσεων PowerPoint σε κινούμενα GIF με C++
linktitle: PowerPoint σε GIF
type: docs
weight: 65
url: /el/cpp/convert-powerpoint-to-animated-gif/
keywords:
- κινούμενο GIF
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε GIF
- παρουσίαση σε GIF
- διαφάνεια σε GIF
- PPT σε GIF
- PPTX σε GIF
- αποθήκευση PPT ως GIF
- αποθήκευση PPTX ως GIF
- εξαγωγή PPT ως GIF
- εξαγωγή PPTX ως GIF
- προεπιλεγμένες ρυθμίσεις
- προσαρμοσμένες ρυθμίσεις
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Με απλότητα μετατρέψτε παρουσιάσεις PowerPoint (PPT, PPTX) σε κινούμενα GIF με το Aspose.Slides για C++. Γρήγορα, υψηλής ποιότητας αποτελέσματα."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να μετατρέπετε παρουσιάσεις PowerPoint σε αρχεία animated GIF με λίγες μόνο γραμμές κώδικα. Αυτό είναι χρήσιμο όταν χρειάζεται να μοιραστείτε το περιεχόμενο των διαφανειών σε ελαφρύ, ευρέως υποστηριζόμενο animated format που μπορεί να ενσωματωθεί σε ιστοσελίδες, messengers ή τεκμηρίωση. Αυτό το άρθρο εξηγεί πώς να εξάγετε μια παρουσίαση σε GIF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις και πώς να προσαρμόσετε το αποτέλεσμα διαμορφώνοντας επιλογές όπως το μέγεθος πλαισίου, η καθυστέρηση διαφάνειας και το ρυθμό καρέ μετάβασης μέσω [GifOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/gifoptions/).

## **Μετατροπή Παρουσιάσεων σε Animated GIF με Προεπιλεγμένες Ρυθμίσεις**

Αυτό το παράδειγμα κώδικα σε C++ δείχνει πώς να μετατρέψετε μια παρουσίαση σε animated GIF χρησιμοποιώντας τις τυπικές ρυθμίσεις:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Το animated GIF θα δημιουργηθεί με τις προεπιλεγμένες παραμέτρους.

{{%  alert  title="TIP"  color="info"  %}} 

Αν προτιμάτε να προσαρμόσετε τις παραμέτρους για το GIF, μπορείτε να χρησιμοποιήσετε την κλάση [GifOptions](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.gif_options). Δείτε το παρακάτω παράδειγμα κώδικα. 

{{% /alert %}} 

## **Μετατροπή Παρουσιάσεων σε Animated GIF με Προσαρμοσμένες Ρυθμίσεις**

Αυτό το παράδειγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση σε animated GIF χρησιμοποιώντας προσαρμοσμένες ρυθμίσεις σε C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// το μέγεθος του παραγόμενου GIF
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// πόσο χρόνο θα εμφανίζεται κάθε διαφάνεια πριν αλλάξει στην επόμενη
gifOptions->set_DefaultDelay(2000);
// αυξήστε τα FPS για καλύτερη ποιότητα κίνησης μετάβασης
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Μπορείτε να δοκιμάσετε έναν ΔΩΡΕΑΝ μετατροπέα [Text to GIF](https://products.aspose.app/slides/el/text-to-gif) που έχει αναπτύξει η Aspose. 

{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡ ΩΤΗΣΕΙΣ**

### Τι γίνεται αν οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση δεν είναι εγκατεστημένες στο σύστημα;

Εγκαταστήστε τις ελλιπείς γραμματοσειρές ή [ρυθμίστε εναλλακτικές γραμματοσειρές](/slides/el/cpp/powerpoint-fonts/). Η Aspose.Slides θα τις αντικαταστήσει, αλλά η εμφάνιση ενδέχεται να διαφέρει. Για branding, βεβαιωθείτε πάντα ότι οι απαιτούμενες γραμματοσειρές είναι ρητά διαθέσιμες.

### Μπορώ να επικάμψω υδατογράφημα πάνω στα καρέ του GIF;

Ναι. [Προσθέστε ένα ημιδιαφανές αντικείμενο/λογότυπο](/slides/el/cpp/watermark/) στο master slide ή σε μεμονωμένες διαφάνειες πριν από την εξαγωγή — το υδατογράφημα θα εμφανίζεται σε κάθε καρέ.