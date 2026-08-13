---
title: Προσαρμογή Γραμματοσειρών PowerPoint σε C++
linktitle: Προσαρμοσμένη Γραμματοσειρά
type: docs
weight: 20
url: /el/cpp/custom-font/
keywords:
- γραμματοσειρά
- προσαρμοσμένη γραμματοσειρά
- εξωτερική γραμματοσειρά
- φόρτωση γραμματοσειράς
- διαχείριση γραμματοσειρών
- φάκελος γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με το Aspose.Slides για C++ ώστε οι παρουσιάσεις σας να παραμένουν καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαθιστάτε στο λειτουργικό σύστημα. Μπορείτε να φορτώνετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου, ή να φορτώνετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά να διατηρείται η έξοδος της παρουσίασης συνεπής σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να εξετάζετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να διαγράψετε τη λανθάνουσα μνήμη (cache) γραμματοσειρών μετά από εργασία με εξωτερικές γραμματοσειρές.

Η εγγραφή προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί μέσα στην παρουσίαση, χρησιμοποιήστε ρητά τις δυνατότητες ενσωμάτωσης γραμματοσειρών.

{{% alert color="info" %}}

Το Aspose Slides σάς επιτρέπει να φορτώνετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) και TrueType Collection (.ttc) γραμματοσειρές. Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) γραμματοσειρές. Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σάς επιτρέπει να φορτώνετε γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαθιστάτε στο σύστημα. Αυτό επηρεάζει την έξοδο εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα παραγόμενα έγγραφα να φαίνονται συνεπή σε διαφορετικά περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειράς.
2. Καλέστε τη στατική μέθοδο [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/loadexternalfonts/) για να φορτώσετε γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε τη μέθοδο [FontsLoader.clearCache](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/clearcache/) για να εκκαθαρίσετε τη λανθάνουσα μνήμη γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειρών:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Ορίστε φακέλους που περιέχουν αρχεία προσαρμοσμένων γραμματοσειρών.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Αποδώστε/εξάγετε την παρουσίαση (π.χ., σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Καθαρίστε τη λανθάνουσα μνήμη γραμματοσειρών μετά το τέλος της εργασίας.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/loadexternalfonts/) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά εκκίνησης των γραμματοσειρών.
Οι γραμματοσειρές εκκινούνται με την εξής σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/getfontfolders/) ώστε να μπορείτε να εντοπίσετε τους φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και τους φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας C++ δείχνει πώς να χρησιμοποιήσετε τη μέθοδο [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/getfontfolders/) :

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Αυτή η γραμμή εμφανίζει τους φακέλους που ελέγχονται για αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών για Παρουσίαση**

Το Aspose.Slides παρέχει την ιδιότητα [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

Αυτός ο κώδικας C++ δείχνει πώς να χρησιμοποιήσετε την ιδιότητα [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) :

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // εργασία με την παρουσίαση
    // Οι CustomFont1, CustomFont2 καθώς και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/loadexternalfont/) ώστε να μπορείτε να φορτώσετε εξωτερικές γραμματοσειρές σε έναν πίνακα byte.

Αυτός ο κώδικας C++ δείχνει τη διαδικασία φόρτωσης γραμματοσειρών σε πίνακα byte:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Η διαδρομή προς το φάκελο εγγράφων
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **Συχνές Ερωτήσεις**

### Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον render στην εξαγωγή για όλες τις μορφές.

### Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο τελικό PPTX;

Όχι. Η καταγραφή μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε PPTX. Εάν χρειάζεστε τη γραμματοσειρά ενσωματωμένη μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές [δυνατότητες ενσωμάτωσης](/slides/el/cpp/embedded-font/).

### Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής γραμματοσειράς όταν μια προσαρμοσμένη γραμματοσειρά λείπουν συγκεκριμένα γλύφοι;

Ναι. Διαμορφώστε την [αντικατάσταση γραμματοσειρών](/slides/el/cpp/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/cpp/font-replacement/) και τα [σετ εναλλακτικών](/slides/el/cpp/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιείται όταν λείπει το ζητούμενο γλύφο.

### Μπορώ να χρησιμοποιήσω γραμματοσειρές σε Linux/Docker containers χωρίς να τις εγκαταστήσω σε όλο το σύστημα;

Ναι. Κατευθύνετε σε δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους φακέλους γραμματοσειρών του συστήματος στην εικόνα του container.

### Τι γίνεται με τις άδειες—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή τη εμπορική χρήση. Πάντα ελέγξτε τη σύμβαση χρήσης (EULA) της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.