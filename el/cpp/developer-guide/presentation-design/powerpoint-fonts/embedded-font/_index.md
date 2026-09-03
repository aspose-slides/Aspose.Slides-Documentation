---
title: Ενσωμάτωση Γραμματοσειρών σε Παρουσιάσεις σε C++
linktitle: Ενσωματωμένες Γραμματοσειρές
type: docs
weight: 40
url: /el/cpp/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχείριση ενσωματωμένων γραμματοσειρών στο PowerPoint με το Aspose.Slides για C++. Προσθήκη, ανάκτηση, αφαίρεση και συμπίεση γραμματοσειρών για τη διατήρηση της εμφάνισης του κειμένου και τη μείωση του μεγέθους του αρχείου."
---
## **Εισαγωγή**

Η ενσωμάτωση γραμματοσειρών αποθηκεύει τα δεδομένα γραμματοσειράς μέσα σε μια παρουσίαση PowerPoint. Όταν ένας προβολέας υποστηρίζει ενσωματωμένες γραμματοσειρές, μπορεί να εμφανίσει το κείμενο χρησιμοποιώντας αυτές τις γραμματοσειρές ακόμη και αν δεν είναι εγκατεστημένες στο σύστημα‑στόχο. Αυτό βοηθά στη διατήρηση των αλλαγών γραμμής, του διαστήματος κειμένου και της διάταξης των διαφανειών.

Το Aspose.Slides for C++ σας επιτρέπει να ανακτήσετε, να προσθέσετε και να αφαιρέσετε ενσωματωμένες γραμματοσειρές μέσω της μεθόδου [Presentation::get_FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_fontsmanager/) ενός [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/). Μπορείτε επίσης να μειώσετε το μέγεθος των ενσωματωμένων δεδομένων γραμματοσειράς αφαιρώντας χαρακτήρες που δεν χρησιμοποιεί η παρουσίαση.

Τα παραδείγματα παρακάτω λειτουργούν με αρχεία PPTX. Πριν ενσωματώσετε μια γραμματοσειρά, βεβαιωθείτε ότι τα δεδομένα της γραμματοσειράς είναι διαθέσιμα στο Aspose.Slides και η άδειά της επιτρέπει την ενσωμάτωση.

## **Λήψη και Αφαίρεση Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε το [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) για να παραθέσετε τις γραμματοσειρές που είναι αποθηκευμένες σε μια παρουσίαση. Για να αφαιρέσετε μία, περάστε μια γραμματοσειρά από αυτή τη λίστα στο [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), στη συνέχεια αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα παραθέτει τις ενσωματωμένες γραμματοσειρές στο `EmbeddedFonts.pptx` και αφαιρεί τη Calibri εάν υπάρχει:
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Η αφαίρεση μιας ενσωματωμένης γραμματοσειράς αφαιρεί τα αποθηκευμένα δεδομένα της γραμματοσειράς· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο κείμενο. Εάν η γραμματοσειρά είναι εγκατεστημένη στο σύστημα‑στόχο, το κείμενο μπορεί ακόμη να τη χρησιμοποιήσει. Διαφορετικά, η απόδοση ενδέχεται να απαιτήσει [αντικατάσταση γραμματοσειράς](/slides/el/cpp/font-substitution/), το οποίο μπορεί να επηρεάσει τη διάταξη.

## **Έλεγχος Δεδομένων Γραμματοσειράς και Δικαιωμάτων Ενσωμάτωσης**

Χρησιμοποιήτε τη διεπαφή [IFontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/) για να ελέγξετε τις γραμματοσειρές πριν τις ενσωματώσετε. Καλείτε το [IFontsManager::GetFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getfonts/) για να ανακτήσετε τις γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση. Για κάθε γραμματοσειρά, περάστε ένα αντικείμενο [IFontData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontdata/) και την απαιτούμενη τιμή [FontStyleType](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontstyletype/) στο [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getfontbytes/). Η μέθοδος επιστρέφει τα δυαδικά δεδομένα για αυτό το στυλ γραμματοσειράς, ή `nullptr` όταν η ζητούμενη γραμματοσειρά ή το στυλ δεν είναι διαθέσιμο. Μην περάσετε ένα αποτέλεσμα `nullptr` στο [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), επειδή αυτή η μέθοδος απαιτεί έναν πίνακα byte.

Το [EmbeddingLevel](https://reference.aspose.com/slides/el/cpp/aspose.slides/embeddinglevel/) είναι μια απαρίθμηση σημαδιών που αναφέρει τους περιορισμούς ενσωμάτωσης που είναι αποθηκευμένοι στη γραμματοσειρά:

- `Installable` επιτρέπει την ενσωμάτωση και μόνιμη εγκατάσταση σε άλλο σύστημα, σύμφωνα με την άδεια της γραμματοσειράς.
- `Restricted` απαγορεύει την ενσωμάτωση εκτός εάν ληφθεί άδεια από τον νόμιμο κάτοχο της γραμματοσειράς όταν είναι η μοναδική σημαία άδειας χρήσης.
- `PreviewPrint` επιτρέπει προσωρινή χρήση για προβολή και εκτύπωση· ένα έγγραφο που περιέχει τη γραμματοσειρά πρέπει να είναι μόνο για ανάγνωση.
- `Editable` επιτρέπει προσωρινή χρήση και επιτρέπει την επεξεργασία και αποθήκευση του εγγράφου.
- `NoSubsetting` είναι ένας πρόσθετος περιορισμός που απαγορεύει την ενσωμάτωση μόνο ενός υποσυνόλου των γλυφών. Ενσωματώστε όλους τους χαρακτήρες όταν αυτή η σημαία είναι παρούσα.
- `BitmapOnly` είναι ένας πρόσθετος περιορισμός που επιτρέπει την ενσωμάτωση μόνο bitmap εκδόσεων, όχι δεδομένων περιγράμματος. Εάν η γραμματοσειρά δεν έχει bitmap εκδόσεις, δεν μπορεί να ενσωματωθεί.

Οι πρώτες τέσσερις τιμές περιγράφουν την άδεια χρήσης, ενώ τα `NoSubsetting` και `BitmapOnly` μπορούν να συνδυαστούν με αυτές. Ελέγξτε τους τροποποιητές με λογικές (bitwise) πράξεις. Επειδή το `Installable` είναι μηδέν, χρησιμεύστε σε μάσκα στα bits άδειας χρήσης και συγκρίνετε το αποτέλεσμα με το `Installable`. Οι τρέχουσες γραμματοσειρές πρέπει να ορίζουν το πολύ ένα bit άδειας χρήσης. Για συμβατότητα με παλαιότερες γραμματοσειρές που ορίζουν περισσότερα από ένα, ο βοηθητικός κώδικας παρακάτω επιλέγει την λιγότερο περιοριστική άδεια: `Editable`, μετά `PreviewPrint`, μετά `Restricted`.

Το παρακάτω παράδειγμα ελέγχει τα κανονικά, έντονα, πλαγία και έντονα‑πλαγια δεδομένα που είναι διαθέσιμα για κάθε γραμματοσειρά που επιστρέφεται από το `GetFonts`. Παράβλεπει τα μη διαθέσιμα στυλ, τις περιορισμένες γραμματοσειρές, τις γραμματοσειρές μόνο bitmap, τις γραμματοσειρές περιορισμένες σε προβολή και εκτύπωση επειδή το αποτέλεσμα παραμένει επεξεργάσιμο, και τις γραμματοσειρές που είναι ήδη ενσωματωμένες. Εάν κάποιο διαθέσιμο στυλ έχει `NoSubsetting`, ενσωματώνει όλους τους χαρακτήρες για αυτή την οικογένεια γραμματοσειρών.
```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Αυτή η εξέταση αναφέρει τους περιορισμούς που είναι κωδικοποιημένοι σε κάθε αρχείο γραμματοσειράς. Δεν παρέχει άδεια, δεν αποδεικνύει ότι αποκτήσατε τη γραμματοσειρά νόμιμα, ούτε αντικαθιστά τον έλεγχο της άδειας χρήσης της γραμματοσειράς πριν τη διανομή ενός ενσωματωμένου αντιγράφου.

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε το [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/addembeddedfont/) για να ενσωματώσετε μια γραμματοσειρά. Οι υπερφορτώσεις του δέχονται είτε ένα αντικείμενο [IFontData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontdata/) είτε έναν πίνακα byte που περιέχει τα δεδομένα της γραμματοσειράς. Η απαρίθμηση [EmbedFontCharacters](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/embedfontcharacters/) ελέγχει ποιοι χαρακτήρες περιλαμβάνονται:

- [All](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/embedfontcharacters/) ενσωματώνει όλους τους χαρακτήρες στη γραμματοσειρά. Χρησιμοποιήστε αυτή την επιλογή όταν οι παραλήπτες χρειάζεται να επεξεργαστούν την παρουσίαση και να εισάγουν νέο κείμενο.
- [OnlyUsed](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/embedfontcharacters/) ενσωματώνει μόνο τους χαρακτήρες που χρησιμοποιούνται στην παρουσίαση για να μειωθεί το μέγεθος του αρχείου. Επιλέξτε αυτή την επιλογή για μια τελική παρουσίαση που προορίζεται κυρίως για προβολή.

Το παρακάτω παράδειγμα χρησιμοποιεί το [IFontsManager::GetFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getfonts/) για να ανακτήσει τις γραμματοσειρές που χρησιμοποιούνται στο `Fonts.pptx` και ενσωματώνει εκείνες που δεν είναι ήδη ενσωματωμένες. Οι γραμματοσειρές που θα προστεθούν πρέπει να είναι διαθέσιμες στο μηχάνημα που εκτελεί τον κώδικα. Οι υπάρχουσες ενσωματωμένες γραμματοσειρές διατηρούν τα τρέχοντα σύνολα χαρακτήρων τους.
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

Η [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) μειώνει τα ενσωματωμένα δεδομένα γραμματοσειράς αφαιρώντας τους αχρησιμοποίητους χαρακτήρες. Λειτουργεί σε γραμματοσειρές που είναι ήδη ενσωματωμένες, έτσι η μείωση του μεγέθους εξαρτάται από το πόσα αχρησιμοποίητα δεδομένα γραμματοσειράς περιέχει η παρουσίαση.

Το παρακάτω παράδειγμα συμπιέζει τις γραμματοσειρές στο `EmbeddedFonts.pptx` και αποθηκεύει το αποτέλεσμα ως ξεχωριστό αρχείο:
```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Διατηρήστε το αρχικό αρχείο εάν οι παραλήπτες ενδέχεται να χρειαστεί να προσθέσουν κείμενο αργότερα. Οι χαρακτήρες που αφαιρέθηκαν κατά τη συμπίεση δεν είναι πλέον διαθέσιμοι από την ενσωματωμένη γραμματοσειρά, ακόμη και αν αρχικά ενσωματώσατε όλους τους χαρακτήρες.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν μια ενσωματωμένη γραμματοσειρά θα αντικατασταθεί ακόμη κατά την απόδοση;**

Καλέστε το [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getsubstitutions/) στο περιβάλλον όπου αποδίδετε την παρουσίαση για να δείτε ποιες γραμματοσειρές θα αντικαταστήσει το Aspose.Slides. Επίσης ελέγξτε τις ρυθμίσεις [αντικατάσταση γραμματοσειράς](/slides/el/cpp/font-substitution/) και τους κανόνες [εναλλακτική γραμματοσειράς](/slides/el/cpp/fallback-font/). Το fallback διαχειρίζεται τους ελλειπόντες χαρακτήρες, έτσι η ενσωμάτωση μιας γραμματοσειράς δεν επιλύει χαρακτήρες που η ίδια η γραμματοσειρά δεν περιέχει.

**Πρέπει να ενσωματώσω κοινές γραμματοσειρές όπως Arial και Calibri;**

Λάβετε την απόφαση με βάση το περιβάλλον‑στόχο. Εάν οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες σε κάθε μηχάνημα που ανοίγει ή αποδίδει την παρουσίαση, η ενσωμάτωση τους μπορεί να προσθέσει περιττό μέγεθος αρχείου. Εάν οι παραλήπτες ή οι διακομιστές μπορεί να μην διαθέτουν αυτές τις γραμματοσειρές, η ενσωμάτωσή τους μπορεί να βοηθήσει στη διατήρηση της προθυμημένης εμφάνισης, εφόσον οι άδειές τους το επιτρέπουν.