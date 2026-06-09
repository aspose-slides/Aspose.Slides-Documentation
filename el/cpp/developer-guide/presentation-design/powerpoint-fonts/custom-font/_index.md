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

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος της παρουσίασης σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να εξετάσετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να καθαρίσετε την κρυφή μνήμη γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταχώριση προσαρμοσμένων γραμματοσειρών για απόδοση είναι διαφορετική από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί μέσα στην παρουσίαση, χρησιμοποιήστε ρητά τις δυνατότητες ενσωμάτωσης γραμματοσειρών.

{{% alert color="primary" %}} 

Το Aspose Slides σάς επιτρέπει να φορτώνετε αυτές τις γραμματοσειρές χρησιμοποιώντας [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Γραμματοσειρές TrueType (.ttf) και TrueType Collection (.ttc). Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Γραμματοσειρές OpenType (.otf). Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σάς επιτρέπει να φορτώνετε γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαθιστάτε στο σύστημα. Αυτό επηρεάζει την έξοδο εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα τελικά έγγραφα να φαίνονται συνεπή σε διάφορα περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/loadexternalfonts/) για να φορτώσετε τις γραμματοσειρές από αυτούς τους φακέλους.
3. Φόρτωσε και απόδωσε/εξάγε την παρουσίαση.
4. Καλέστε το [FontsLoader.clearCache](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/clearcache/) για να καθαρίσετε την κρυφή μνήμη γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα επιδεικνύει τη διαδικασία φόρτωσης γραμματοσειρών:

```cpp
// Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Αποδώστε/εξάγετε την παρουσίαση (π.χ. σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Καθαρίστε την κρυφή μνήμη γραμματοσειρών μετά το τέλος της εργασίας.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/loadexternalfonts/) προσθέτει πρόσθετους φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά αρχικοποίησης των γραμματοσειρών. Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώνονται μέσω του [FontsLoader](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Λήψη Φακέλων Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides προσφέρει το [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/getfontfolders/) ώστε να μπορείτε να εντοπίσετε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας C++ δείχνει πώς να χρησιμοποιήσετε τη μέθοδο [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
// Αυτή η γραμμή εμφανίζει τους φακέλους που ελέγχονται για αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών που Χρησιμοποιούνται σε Παρουσίαση**

Το Aspose.Slides παρέχει την ιδιότητα [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

Αυτός ο κώδικας C++ δείχνει πώς να χρησιμοποιήσετε την ιδιότητα [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //εργαστείτε με την παρουσίαση
    //Τα CustomFont1, CustomFont2 καθώς και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/loadexternalfont/) ώστε να μπορείτε να φορτώσετε εξωτερικές γραμματοσειρές σε έναν πίνακα byte.

Αυτός ο κώδικας C++ επιδεικνύει τη διαδικασία φόρτωσης γραμματοσειράς σε πίνακα byte:

```cpp
// Η διαδρομή προς τον φάκελο εγγράφων
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);**

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον αποδοσηρό σε όλες τις μορφές εξαγωγής.

**Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο τελικό PPTX;**

Όχι. Η καταχώριση μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε PPTX. Εάν χρειάζεστε τη γραμματοσειρά εντός του αρχείου παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές [δυνατότητες ενσωμάτωσης](/slides/el/cpp/embedded-font/).

**Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής γραμματοσειράς όταν μια προσαρμοσμένη γραμματοσειρά λείπει κάποιες γλύφους;**

Ναι. Ρυθμίστε την [αντικατάσταση γραμματοσειρών](/slides/el/cpp/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/cpp/font-replacement/), και τα [σύνολα εναλλακτικών](/slides/el/cpp/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν λείπει το ζητούμενο γλύφο.

**Μπορώ να χρησιμοποιήσω γραμματοσειρές σε κοντέινερ Linux/Docker χωρίς να τις εγκαταστήσω σε ολόκληρο το σύστημα;**

Ναι. Κατευθύνετε στα δικά σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους φακέλους γραμματοσειρών του συστήματος στην εικόνα του κοντέινερ.

**Τι γίνεται με την άδεια χρήσης — μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;**

Είστε υπεύθυνοι για τη συμμόρφωση με την άδεια χρήσης των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή τη εμπορική χρήση. Πάντα ελέγχετε τη σύμβαση άδειας χρήσης (EULA) της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.