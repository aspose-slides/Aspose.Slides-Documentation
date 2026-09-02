---
title: Διαχείριση Γραμματοσειρών Θέματος Κατά Script σε C++
linktitle: Γραμματοσειρές Θέματος Κατά Script
type: docs
weight: 15
url: /el/cpp/script-specific-font-mappings/
keywords:
- γραμματοσειρά κατά script
- αντιστοίχιση γραμματοσειράς θέματος
- πολυγλωσσική παρουσίαση
- σύστημα γραφής
- γραμματοσειρά κυριλλική
- γραμματοσειρά αραβική
- γραμματοσειρά ιαπωνική
- γραμματοσειρά γεωργιανή
- γραμματοσειρά θάανα
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Επιθεώρηση, προσθήκη, αντικατάσταση και αφαίρεση αντιστοιχίσεων γραμματοσειρών κατά script σε θέματα PowerPoint με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Ένα θέμα παρουσίασης μπορεί να επιλέγει διαφορετικές οικογένειες γραμματοσειρών για διαφορετικά συστήματα γραφής. Αυτό επιτρέπει κείμενο πολυγλωσσικό που εξακολουθεί να χρησιμοποιεί τις γραμματοσειρές του θέματος να ακολουθεί ένα ενιαίο σχήμα γραμματοσειρών, ενώ χρησιμοποιεί κατάλληλες γραμματοσειρές για κυριλλικό, αραβικό, ιαπωνικό, γεωργιανό, θάανα και άλλα σενάρια.

Το [IFontScheme](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/ifontscheme/) του θέματος περιλαμβάνει μια κύρια συλλογή γραμματοσειρών, που χρησιμοποιείται συνήθως για επικεφαλίδες, και μια δευτερεύουσα συλλογή, που χρησιμοποιείται συνήθως για το κύριο κείμενο. Εκτός από τις ιδιότητες των γραμματοσειρών Latin και East Asian, και οι δύο συλλογές εκθέτουν αντιστοιχίες από ετικέτες συστημάτων γραφής σε ονόματα οικογενειών γραμματοσειρών μέσω της διεπαφής [IFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifonts/).

Αυτό το άρθρο δείχνει πώς να εξετάσετε και να τροποποιήσετε αυτές τις αντιστοιχίες στο κύριο θέμα της παρουσίασης και να επαληθεύσετε ότι οι αλλαγές διατηρούνται μετά από αποθήκευση και επαναφόρτωση.

## **Κατανόηση Ετικετών Script**

Οι μέθοδοι γραμματοσειράς script χρησιμοποιούν τετραψήφιες υποετικέτες BCP 47 για να προσδιορίσουν συστήματα γραφής. Συνηθισμένες τιμές περιλαμβάνουν:

| Ετικέτα script | Σύστημα γραφής |
|---|---|
| `Cyrl` | Κυριλλικό |
| `Arab` | Αραβικό |
| `Hans` | Απλοποιημένη Κίνα |
| `Jpan` | Ιαπωνικό |
| `Geor` | Γεωργιανό |
| `Thaa` | Θάανα |

Αυτές οι αντιστοιχίες ανήκουν στο σχήμα γραμματοσειράς του θέματος, όχι σε μεμονωμένα τμήματα κειμένου. Μια παρουσίαση μπορεί να ορίσει διαφορετικές αντιστοιχίες για τις κύριες και δευτερεύουσες συλλογές και μπορεί να παραλείψει αντιστοιχίες για ορισμένα σενάρια.

## **Πρόσβαση και Έλεγχος Αντιστοιχίσεων Γραμματοσειράς Script**

Χρησιμοποιήστε [Presentation::get_MasterTheme](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_mastertheme/) για να αποκτήσετε πρόσβαση στο θέμα σε επίπεδο παρουσίασης. Οι μέθοδοι [FontScheme::get_Major](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/fontscheme/get_major/) και [FontScheme::get_Minor](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/fontscheme/get_minor/) επιστρέφουν τις δύο συλλογές [IFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifonts/).

Καλέστε [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/el/cpp/aspose.slides/fonts/getscriptfontmap/) για να ανακτήσετε όλες τις αντιστοιχίες από μια συλλογή. Για να αναζητήσετε ένα σύστημα γραφής, καλέστε [Fonts::GetScriptFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/fonts/getscriptfont/) με την ετικέτα script του. `GetScriptFont` επιστρέφει μια κενή (null) συμβολοσειρά όταν η συλλογή δεν ορίζει την απαιτούμενη αντιστοίχηση.

## **Τροποποίηση Αντιστοιχίσεων και Επαλήθευση Διατήρησης**

Χρησιμοποιήστε [Fonts::SetScriptFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/fonts/setscriptfont/) για να δημιουργήσετε μια αντιστοίχιση ή να αντικαταστήσετε την τρέχουσα οικογένεια γραμματοσειράς. Χρησιμοποιήστε [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/fonts/removescriptfont/) για να αφαιρέσετε μια αντιστοίχηση.

Το παρακάτω παράδειγμα ολοκληρωμένης ροής διαβάζει όλες τις υπάρχουσες κύριες και δευτερεύουσες αντιστοιχίες, εντοπίζει τη βασική γραμματοσειρά για Ιαπωνικό, αλλάζει τη βασική γραμματοσειρά για Κυριλλικό, αφαιρεί τη δευτερεύουσα αντιστοίχηση για Θάανα, αποθηκεύει την παρουσίαση και την ξαναφορτώνει για επαλήθευση και των δύο αλλαγών. Για να γίνει το βήμα αφαίρεσης ανεξάρτητο από το αρχικό θέμα, το παράδειγμα πρώτα δημιουργεί μια αντιστοίχηση Θάανα μόνο όταν δεν υπάρχει ήδη.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

Η επαλήθευση χρησιμοποιεί την ίδια συμπεριφορά κενής συμβολοσειράς όπως μια συνηθισμένη αναζήτηση: μετά την αποθήκευση της αφαίρεσης, `GetScriptFont(u"Thaa")` επιστρέφει κενή συμβολοσειρά για τη δευτερεύουσα συλλογή.

## **Διαχωρισμός Αντιστοιχιών Θέματος από Άλλες Ρυθμίσεις Γραμματοσειράς**

Οι αντιστοιχίσεις γραμματοσειράς θέματος ειδικές για script συμμετέχουν στην επιλογή γραμματοσειράς, αλλά λύνουν διαφορετικό πρόβλημα από τη άμεση μορφοποίηση κειμένου, την αντικατάσταση και την εναλλακτική παροχή:

| Μηχανισμός | Σκοπός | Αποτέλεσμα αλλαγής μιας αντιστοίχισης θέματος |
|---|---|---|
| Αντιστοίχηση γραμματοσειράς θέματος ανά script | Επιλέγει μια κύρια ή δευτερεύουσα γραμματοσειρά θέματος για ένα σύστημα γραφής. | Το κείμενο που εξακολουθεί να χρησιμοποιεί τη σχετική γραμματοσειρά θέματος μπορεί να επιλυθεί στη νέα αντιστοιχισμένη οικογένεια. |
| Γραμματοσειρά που έχει εκχωρηθεί ρητά σε τμήμα κειμένου | Καθορίζει την απαιτούμενη οικογένεια γραμματοσειράς σε αυτό το τμήμα αντί να βασίζεται στο θέμα. | Το τμήμα μπορεί να παραμείνει αμετάβλητο επειδή η άμεση μορφοποίησή του υπερισχύει της επιλογής του θέματος. |
| Αντικατάσταση γραμματοσειράς | Αντικαθιστά μια ζητούμενη γραμματοσειρά όταν αυτή δεν είναι διαθέσιμη ή όταν εφαρμόζεται κανόνας αντικατάστασης. | Λειτουργεί μετά την αίτηση μιας γραμματοσειράς· δεν επανορίζει την αντιστοίχηση script του θέματος. |
| Εναλλακτική (fallback) γραμματοσειρά | Παρέχει γλύφους που δεν περιέχει η επιλεγμένη γραμματοσειρά, συχνά για συγκεκριμένα εύρη Unicode. | Συμπληρώνει την έλλειψη γλύφων· δεν αλλάζει την αποθηκευμένη αντιστοίχηση θέματος. |

Για περισσότερες πληροφορίες σχετικά με τους τελευταίους δύο μηχανισμούς, δείτε [Αντικατάσταση Γραμματοσειράς](/slides/el/cpp/font-substitution/) και [Γραμματοσειρές fallback](/slides/el/cpp/fallback-font/).

Η αλλαγή μιας αντιστοίχισης στο [Presentation::get_MasterTheme](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_mastertheme/) επηρεάζει μόνο το περιεχόμενο του οποίου η αποτελεσματική μορφοποίηση εξαρτάται ακόμη από αυτό το θέμα. Το κείμενο μπορεί αντί αυτού να κληρονομήσει μια παράκαμψη θέματος από ένα master, layout ή διαφάνεια, ή να χρησιμοποιήσει μια ρητά εκχωρημένη γραμματοσειρά. Εξετάστε αυτά τα επίπεδα όταν το ορατό αποτέλεσμα δεν ακολουθεί την αντιστοίχηση σε επίπεδο παρουσίασης.

## **Κατάσταση Διαθεσιμότητας των Αντιστοιχισμένων Γραμματοσειρών και Επαλήθευση του Αποτελέσματος**

Μια αντιστοίχηση script αποθηκεύει ένα όνομα οικογένειας γραμματοσειράς· δεν εγκαθιστά ή φορτώνει το αντίστοιχο αρχείο γραμματοσειράς. Για συνεπή απόδοση και εξαγωγή, κάθε αντιστοιχισμένη γραμματοσειρά πρέπει να είναι εγκατεστημένη στο περιβάλλον ή να παρέχεται στο Aspose.Slides μέσω προσαρμοσμένης πηγής, όπως το [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/loadexternalfonts/) ή το [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Δείτε [Προσαρμοσμένες Γραμματοσειρές](/slides/el/cpp/custom-font/) για τις διαθέσιμες επιλογές φόρτωσης.

Η επαλήθευση της αποθηκευμένης αντιστοίχησης επιβεβαιώνει μόνο ότι ο ορισμός του θέματος διατηρήθηκε. Δεν αποδεικνύει ότι η γραμματοσειρά είναι διαθέσιμη, περιέχει όλους τους απαιτούμενους γλύφους ή παράγει την επιθυμητή διάταξη. Αποδώστε αντιπροσωπευτικό κείμενο για κάθε απαιτούμενο σύστημα γραφής σε εικόνα ή PDF και ελέγξτε το αποτέλεσμα. Αυτό εντοπίζει ελλείψεις γραμματοσειρών, ελλιπή κάλυψη γλύφων, συμπεριφορά fallback και αλλαγές διάταξης πριν διανεμηθεί η παρουσίαση. Δείτε [Μετατροπή Παρεμβάσεων PowerPoint](/slides/el/cpp/convert-powerpoint/) για παραδείγματα απόδοσης και εξαγωγής.

## **Συχνές Ερωτήσεις**

**Τι επιστρέφει το `GetScriptFont` όταν ένα script δεν είναι αντιστοιχισμένο;**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/fonts/getscriptfont/) επιστρέφει μια κενή (null) συμβολοσειρά όταν η ζητούμενη αντιστοίχηση script δεν ορίζεται στην αντίστοιχη κύρια ή δευτερεύουσα συλλογή γραμματοσειρών.

**Προσθέτει το `SetScriptFont` δεύτερη αντιστοίχιση όταν το script υπάρχει ήδη;**

Όχι. [Fonts::SetScriptFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/fonts/setscriptfont/) δημιουργεί την αντιστοίχιση όταν λείπει και αντικαθιστά την υπάρχουσα οικογένεια γραμματοσειράς όταν η ίδια ετικέτα script είναι ήδη παρούσα.

**Γιατί η αλλαγή μιας αντιστοίχισης θέματος δεν άλλαξε ορισμένο κείμενο;**

Το κείμενο μπορεί να έχει μια ρητά εκχωρημένη γραμματοσειρά, να κληρονομήσει διαφορετικό θέμα μέσω παράκαμψης ή να επηρεαστεί από αντικατάσταση ή fallback κατά την απόδοση. Μια αντιστοίχηση script σε επίπεδο παρουσίασης ελέγχει μόνο το κείμενο του οποίου η αποτελεσματική μορφοποίηση εξακολουθεί να αναφέρεται σε αυτή τη συλλογή γραμματοσειρών του θέματος.

**Είναι η αποθήκευση και επαναφορά επαρκής για την επαλήθευση πολυγλωσσικής εξόδου;**

Όχι. Η επαναφορά επαληθεύει τη διατήρηση των δεδομένων του θέματος. Επίσης, πρέπει να αποδοθεί αντιπροσωπευτικό κείμενο από κάθε απαιτούμενο σύστημα γραφής για να επιβεβαιωθεί ότι οι αντιστοιχισμένες γραμματοσειρές είναι διαθέσιμες και περιέχουν τους απαραίτητους γλύφους.