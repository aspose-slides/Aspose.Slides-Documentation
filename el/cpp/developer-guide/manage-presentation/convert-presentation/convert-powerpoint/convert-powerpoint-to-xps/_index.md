---
title: Μετατροπή Παρουσιάσεων PowerPoint σε XPS με C++
linktitle: PowerPoint σε XPS
type: docs
weight: 70
url: /el/cpp/convert-powerpoint-to-xps
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε XPS
- παρουσίαση σε XPS
- διαφάνεια σε XPS
- PPT σε XPS
- PPTX σε XPS
- αποθήκευση PPT ως XPS
- αποθήκευση PPTX ως XPS
- εξαγωγή PPT σε XPS
- εξαγωγή PPTX σε XPS
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε υψηλής ποιότητας, ανεξάρτητο από πλατφόρμα XPS με C++ χρησιμοποιώντας το Aspose.Slides. Λάβετε οδηγό βήμα-βήμα και δείγμα κώδικα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να μετατρέπετε παρουσιάσεις PowerPoint σε XPS αποθηκεύοντας ένα αρχείο PPT ή PPTX στη μορφή XPS. Αυτό το άρθρο εξηγεί πότε η μορφή XPS μπορεί να είναι χρήσιμη και δείχνει πώς να εκτελέσετε τη μετατροπή με το Aspose.Slides χρησιμοποιώντας είτε τις προεπιλεγμένες ρυθμίσεις είτε τις προσαρμοσμένες ρυθμίσεις [XpsOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/xpsoptions/) .

## **Σχετικά με το XPS**

Η Microsoft ανέπτυξε το [XPS](https://docs.fileformat.com/page-description-language/xps/) ως εναλλακτική λύση του [PDF](https://docs.fileformat.com/pdf/). Σας επιτρέπει να εκτυπώσετε περιεχόμενο δημιουργώντας ένα αρχείο πολύ παρόμοιο με ένα PDF. Η μορφή XPS βασίζεται στο XML. Η διαμόρφωση ή η δομή ενός αρχείου XPS παραμένει η ίδια σε όλα τα λειτουργικά συστήματα και τους εκτυπωτές. 

## **Πότε να χρησιμοποιήσετε τη μορφή Microsoft XPS**

{{% alert color="info" %}} 

Για να δείτε πώς το Aspose.Slides μετατρέπει μια παρουσίαση PPT ή PPTX στη μορφή XPS, μπορείτε να επισκεφθείτε [αυτή τη δωρεάν διαδικτυακή εφαρμογή μετατροπής](https://products.aspose.app/slides/el/conversion). 

{{% /alert %}} 

Αν θέλετε να μειώσετε το κόστος αποθήκευσης, μπορείτε να μετατρέψετε την παρουσίαση Microsoft PowerPoint σε μορφή XPS. Με αυτόν τον τρόπο, θα σας είναι πιο εύκολο να αποθηκεύετε, να μοιράζεστε και να εκτυπώνετε τα έγγραφά σας. 

Η Microsoft συνεχίζει να παρέχει ισχυρή υποστήριξη για το XPS στα Windows (ακόμη και στα Windows 10), οπότε ίσως να θέλετε να εξετάσετε την αποθήκευση αρχείων σε αυτή τη μορφή. Αν εργάζεστε με Windows 8.1, Windows 8, Windows 7 και Windows Vista, τότε το XPS μπορεί πραγματικά να είναι η καλύτερη επιλογή σας για ορισμένες λειτουργίες. 

- **Windows 8** χρησιμοποιεί τη μορφή OXPS (Open XPS) για αρχεία XPS. Το OXPS είναι μια τυποποιημένη έκδοση της αρχικής μορφής XPS. Τα Windows 8 παρέχουν καλύτερη υποστήριξη για αρχεία XPS από ό,τι για αρχεία PDF. 
  - **XPS:** Διαθέσιμο ενσωματωμένο πρόγραμμα προβολής/ανάγνωσης XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF**: Διαθέσιμο πρόγραμμα ανάγνωσης PDF αλλά χωρίς δυνατότητα εκτύπωσης σε PDF. 

- **Windows 7 και Windows Vista** χρησιμοποιούν την αρχική μορφή XPS. Αυτά τα λειτουργικά συστήματα παρέχουν επίσης καλύτερη υποστήριξη για αρχεία XPS από ό,τι για PDFs. 
  - **XPS**: Διαθέσιμο ενσωματωμένο πρόγραμμα προβολής XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF**: Δεν υπάρχει πρόγραμμα ανάγνωσης PDF. Δεν υπάρχει δυνατότητα εκτύπωσης σε PDF. 

|<p>**Είσοδος PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Έξοδος XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Η Microsoft τελικά υλοποίησε υποστήριξη για ενέργειες εκτύπωσης σε PDF μέσω της λειτουργίας Εκτύπωση σε PDF στα Windows 10. Πριν από αυτό, οι χρήστες έπρεπε να εκτυπώνουν έγγραφα μέσω της μορφής XPS. 

## **Μετατροπή XPS με το Aspose.Slides**

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/cpp/) για C++, μπορείτε να χρησιμοποιήσετε τη μέθοδο [**Save**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) που παρέχει η κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) για να μετατρέψετε ολόκληρη την παρουσίαση σε έγγραφο XPS. 

Κατά τη μετατροπή μιας παρουσίασης σε XPS, πρέπει να αποθηκεύσετε την παρουσίαση χρησιμοποιώντας μία από τις ακόλουθες ρυθμίσεις:

- Προεπιλεγμένες ρυθμίσεις (χωρίς [**XPSOptions**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.xps_options))
- Προσαρμοσμένες ρυθμίσεις (με [**XPSOptions**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.xps_options))

### **Μετατροπή παρουσιάσεων σε XPS με χρήση προεπιλεγμένων ρυθμίσεων**

Αυτό το δείγμα κώδικα σε C++ δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας τις τυπικές ρυθμίσεις:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instantiate a Presentation object that represents a presentation file
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Saving the presentation to XPS document
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Μετατροπή παρουσιάσεων σε XPS με χρήση προσαρμοσμένων ρυθμίσεων**

Αυτό το δείγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας προσαρμοσμένες ρυθμίσεις σε C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Δημιουργήστε ένα αντικείμενο της κλάσης TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Αποθηκεύστε τα MetaFiles ως PNG
options->set_SaveMetafilesAsPng(true);

// Αποθηκεύστε την παρουσίαση σε έγγραφο XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **Συχνές Ερωτήσεις**

### Μπορώ να αποθηκεύσω σε XPS σε ροή αντί για αρχείο;

Ναι—Το Aspose.Slides σας επιτρέπει να εξάγετε απευθείας σε ροή, κάτι που είναι ιδανικό για web APIs, pipelines διακομιστή ή οποιοδήποτε σενάριο όπου θέλετε να στείλετε το XPS χωρίς να επηρεάσετε το σύστημα αρχείων.

### Μεταφέρονται οι κρυφές διαφάνειες στο XPS και μπορώ να τις εξαιρέσω;

Από προεπιλογή, μόνο οι κανονικές (ορατές) διαφάνειες αποδίδονται. Μπορείτε να [συμπεριλάβετε ή εξαιρέσετε κρυφές διαφάνειες](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) μέσω [ρυθμίσεων εξαγωγής](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/xpsoptions/) πριν αποθηκεύσετε σε XPS, διασφαλίζοντας ότι η έξοδος περιέχει ακριβώς τις σελίδες που θέλετε.